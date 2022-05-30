using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Net;
using System.Diagnostics;
using System.Timers;

using Timer = System.Timers.Timer;

using SC4Parser.DataStructures;
using SC4Parser.Files;
using SC4Parser.Types;
using SC4Parser.Subfiles;
using SC4Parser;
using SC4Parser.Logging;
using System.Text.RegularExpressions;

namespace SC4CartographerUI
{

    /// <summary>
    /// Map struct contains current save and map creation parameters
    /// Bundled together for convience
    /// </summary>
    public struct Map
    {
        public SC4SaveFile Save;
        public MapCreationParameters Parameters;
    }

    public partial class MainForm : Form
    {
        private const int MAX_ZOOM_SIZE = 10000;
        private const string SC4PARSER_VERSION = "v1.1.0 (c31bdd4)";

        /// <summary>
        /// Currently loaded map
        /// </summary>
        public Map map = new Map();
        
        private readonly MapAppearanceSaveLoadDialogs mapApperanceSaveLoadDialogs;
        private readonly MapAppearanceSerializer mapApperanceSerializer = new MapAppearanceSerializer();

        /// <summary>
        /// Map Bitmaps used for preview and for actually saving to a file
        /// mapBitmap is what the map is created using the MapCreationParameters
        /// zoomedMapBitmap is mapBitmap zoomed in depending on the zoomFactor
        /// </summary>
        private Bitmap mapBitmap; 
        private Bitmap zoomedMapBitmap;

        /// <summary>
        /// FileLogger is the logger that SC4Parser uses to log out internal goings on
        /// </summary>
        private FileLogger fileLogger = null;

        /// <summary> 
        /// Locally cached data from our currently loaded save game
        /// Used when getting pixel data from map
        /// (saves excessive logging calls that happen when using map.Save directly)
        /// </summary>
        private float[][] terrainData = null;
        private List<Lot> zoneData = null;

        /// <summary>
        /// GC timer is set off when a map preview is generated, it is used to cleanup any old map data when a new 
        /// bitmap is generated
        /// </summary>
        private Timer garbageCollectorCleanupTimer = new System.Timers.Timer(4000);

        /// <summary>
        /// Time for periodically update memory used display on main form
        /// </summary>
        private Timer memoryUsedUpdateTimer = new System.Timers.Timer(1500);

        /// <summary>
        /// Root to look for simcity save games in
        /// </summary>
        private string rootSimCitySavePath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
            "Documents",
            "SimCity 4",
            "Regions");
        
        private bool mapLoaded = false;
        private bool forceRecenter = false;
        private int oldSegmentSize = 0;
        private int zoomFactor = 1;

        // Picture box drag move variables
        private int picturePosX;
        private int picturePosY;
        private bool draggingMap;
        private bool skipTick = false;

        public MainForm()
        {
            // Setup parser logger
            // (Do this first so the logger is ready for when we load the first map
            //logger = new RichTextBoxLogger(LogTextBox);
            fileLogger = new FileLogger();

            InitializeComponent();

            // Setup cleanup timer
            garbageCollectorCleanupTimer = new System.Timers.Timer(4000);
            garbageCollectorCleanupTimer.AutoReset = false;
            garbageCollectorCleanupTimer.Elapsed += OnCleanupTimerElapsed;

            // Setup mem usage time
            memoryUsedUpdateTimer = new System.Timers.Timer(1500);
            memoryUsedUpdateTimer.SynchronizingObject = this;
            memoryUsedUpdateTimer.AutoReset = true;
            memoryUsedUpdateTimer.Elapsed += MemoryUsedUpdateTimer_Elapsed;
            memoryUsedUpdateTimer.Start();

            mapApperanceSaveLoadDialogs = new MapAppearanceSaveLoadDialogs(this, mapApperanceSerializer);

            // Try load map parameters from file, otherwise create some new default map parameters
            if (mapApperanceSerializer.TryLoadFromUserTempFolder(out MapCreationParameters loaded))
                map.Parameters = loaded;
            else
                map.Parameters = new MapCreationParameters();

            // Setup appearance tab
            SetAppearanceUIValuesUsingParameters(map.Parameters);
            //RegisterAppearanceEvents();

            // Set our default save location to be our current directory
            // (Don't save to system32 which is sometimes our path when starting sometimes)
            string initialDirectory = Directory.GetCurrentDirectory();
            if (initialDirectory == @"C:\WINDOWS\system32")
            {
                initialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            }
            OutputPathTextbox.Text = initialDirectory;

            // Set cursor to end of textbox
            OutputPathTextbox.SelectionStart = OutputPathTextbox.Text.Length;
            OutputPathTextbox.SelectionLength = 0;

            // Focus on save button at start up
            SaveButton.Select();
        }

        public MainForm(string path) : this()
        {
            switch (Path.GetExtension(path))
            {
                case ".sc4cart":
                    {
                        // Try and load parameters from path if they have been given to program
                        // (this is called when an associated file [.sc4cart] is used to call program)
                        if(mapApperanceSaveLoadDialogs.TryLoadWithErrorDialog(path, out MapCreationParameters parameters))
                            SetAppearanceUIValuesUsingParameters(parameters);
                        break;
                    }
                case ".sc4":
                    {
                        // Try and load the save game at the path given to us
                        LoadSaveGame(path);
                        break;
                    }
            }
        }

        #region Form Functionality

        #region Core Functionality

        /// <summary>
        /// Common function that saves out a map to a file
        /// </summary>
        public void SaveMap(string path, string name)
        {
            // If the directory path is empty then use our current location
            if (string.IsNullOrEmpty(path))
            {
                path = Directory.GetCurrentDirectory();
            }

            // Try to get a full path to save to
            string filePath = "";
            try
            {
                filePath = Path.Combine(path, name);
            }
            catch (ArgumentException e)
            {
                var errorForm = new ErrorForm(
                    "Error saving map",
                    $"Could resolve path to save map to. Please check the output path and try again.",
                    e,
                    false);

                errorForm.StartPosition = FormStartPosition.CenterParent;
                errorForm.ShowDialog();

                return;
            }

            // Check path exists
            if (Directory.Exists(path) == false)
            {
                var errorForm = new ErrorForm(
                    "Error saving map",
                    $"Could not save map, the path \"{path}\" does not exist or is invalid.",
                    new DirectoryNotFoundException("The path \"{path}\" does not exist or is invalid."),
                    false);

                errorForm.StartPosition = FormStartPosition.CenterParent;
                errorForm.ShowDialog();

                return;
            }

            // Get current extension
            string extension = "";
            switch (map.Parameters.OutputFormat)
            {
                case OutFormat.PNG:
                    extension = ".png";
                    break;
                case OutFormat.JPEG:
                    extension = ".jpg";
                    break;
            }

            string currentFilename = filePath + extension;
            currentFilename = Helper.GenerateFilename(currentFilename);

            try
            {
                // Set a nice lil waiting cursor
                this.Cursor = Cursors.WaitCursor;

                // So the original map preview we use is actually the true map
                // that the user has generated with their intended colours and such
                // so instead of generating another we just save that map to a file 
                // (this saves ALOT of memory for bigger maps)

                // Actually save out the image
                switch (map.Parameters.OutputFormat)
                {
                    case OutFormat.PNG:
                        mapBitmap.Save(currentFilename, ImageFormat.Png);
                        break;
                    case OutFormat.JPEG:
                        mapBitmap.Save(currentFilename, ImageFormat.Jpeg);
                        break;
                }

                // Change back cursor
                this.Cursor = Cursors.Default;

                // Show form when successfully created
                var mapCreatedForm = new SuccessForm(
                    "Map Saved",
                    $"Map '{Path.GetFileName(currentFilename)}' has been successfully saved to:",
                    Path.GetDirectoryName(currentFilename),
                    currentFilename);

                mapCreatedForm.StartPosition = FormStartPosition.CenterParent;
                mapCreatedForm.ShowDialog();

            }
            catch (Exception e)
            {
                // Change back cursor
                this.Cursor = Cursors.Default;

                var errorForm = new ErrorForm(
                    "Error saving map",
                    $"There was an error trying to save a map to '{path}'. Please check that you can access and save to that folder and try again.",
                    e,
                    false);

                errorForm.StartPosition = FormStartPosition.CenterParent;
                errorForm.ShowDialog();
            }

            // Cleanup any stuff after saving (these bitmaps can take up a fair amount of memory)
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        /// <summary>
        /// Common function to load a save game and create a map from it
        /// </summary>
        /// <param name="path"></param>
        public void LoadSaveGame(string path)
        {
            SC4SaveFile save = null;

            // Load the save file
            try
            {
                save = new SC4SaveFile(path);
            }
            catch (DBPFParsingException e)
            {
                var errorForm = new ErrorForm(
                    "Error loading save game",
                    $"Could not load save game '{Path.GetFileName(path)}'.",
                    e,
                    true);
                errorForm.StartPosition = FormStartPosition.CenterParent;
                errorForm.ShowDialog();

                return;
            }

            // see if lots subfile exists
            try
            {
                save.GetTerrainMapSubfile();
            }
            catch (SubfileNotFoundException e)
            {
                var errorForm = new ErrorForm(
                    "Error loading save game",
                    $"Could not create map for '{Path.GetFileName(path)}'. Could not find terrain data in the save.",
                    e,
                    true);

                errorForm.StartPosition = FormStartPosition.CenterParent;
                errorForm.ShowDialog();

                return;
            }

            // Save seems to load alright, copy it over to out map creation parameters
            map.Save = save;

            try
            {
                // Change cursor to indicate that we are working on the preview
                this.Cursor = Cursors.WaitCursor;

                // Generate and set map preview images
                forceRecenter = true;
                GenerateMapPreviewBitmaps(true);

                // Reset cursor 
                this.Cursor = Cursors.Default;
            }
            catch (SubfileNotFoundException e)
            {
                // Reset cursor 
                this.Cursor = Cursors.Default;

                var errorForm = new ErrorForm(
                    "Error creating preview",
                    $"Could not create preview map for '{Path.GetFileName(path)}'.",
                    e,
                    true);

                errorForm.StartPosition = FormStartPosition.CenterParent;
                errorForm.ShowDialog();

                return;
            }

            // Cache some save data for map pixel lookup (if it's there)
            if (save.ContainsTerrainMapSubfile())
                terrainData = save.GetTerrainMapSubfile().Map;
            else
                terrainData = null;
            if (save.ContainsLotSubfile())
                zoneData = save.GetLotSubfile().Lots;
            else
                zoneData = null;

            // Set window title
            this.Text = "SC4Cartographer - '" + Path.GetFileName(path) + "'";

            EnableMapButtons();

            mapLoaded = true;

            // Call garbage collector to cleanup anything left over from last load
            //GC.Collect();
            //GC.WaitForPendingFinalizers();
        }

        /// <summary>
        /// Generates and sets preview map image on form
        /// </summary>
        public void GenerateMapPreviewBitmaps(bool newMap)
        {
            // Dispose of any old map previews before generating the new ones
            mapBitmap?.Dispose();
            zoomedMapBitmap?.Dispose();

            // Generate normal preview image
            MapCreationParameters normalMapPreviewParameters = new MapCreationParameters(map.Parameters);
            mapBitmap = MapRenderer.CreateMapBitmap(map.Save, normalMapPreviewParameters);

            // Recenter the image if the size has changed
            if (oldSegmentSize != map.Parameters.GridSegmentSize)
            {
                forceRecenter = true;
            }

            // Set image
            MapPictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
            if (zoomFactor != 1)
            {
                ZoomImage(forceRecenter);
            }
            else
            {
                if (forceRecenter)
                {
                    CenterPictureBox(MapPictureBox, mapBitmap);
                }
                else
                {

                    MapPictureBox.Image = mapBitmap;
                }
            }

            // Update status label
            MapSizeToolStripStatusLabel.Text = $"Size: {mapBitmap.Width.ToString()} x {mapBitmap.Height.ToString()}px";

            forceRecenter = false;
            oldSegmentSize = map.Parameters.GridSegmentSize;
        }

        /// <summary>
        /// Sets map creation parameters and refreshes preview
        /// </summary>
        /// <param name="parameters"></param>
        public void SetAndUpdateMapCreationParameters(MapCreationParameters parameters)
        {
            map.Parameters = parameters;

            // Add wait cursor
            this.Cursor = Cursors.WaitCursor;

            GenerateMapPreviewBitmaps(false);

            // Reset cursor 
            this.Cursor = Cursors.Default;

            // Call garbage collector to cleanup anything left over from generating new preview
            // gets a bit spammy sometimes.... man modern constructs like GC have made me weak
            // and this is almost certainly not a good move
            // but.....

            if (garbageCollectorCleanupTimer.Enabled == false)
            {
                garbageCollectorCleanupTimer.Enabled = true;
            }
        }

        /// <summary>
        /// We don't want these buttons to be enabled when nothing is loaded
        /// </summary>
        private void EnableMapButtons()
        {
            saveToolStripMenuItem.Enabled = true;
            saveAsToolStripMenuItem.Enabled = true;
            SaveButton.Enabled = true;

            AppearanceGroupBox.Enabled = true;

            ResetZoomButton.Enabled = true;
            ZoomTrackBar.Enabled = true;

            OpenTextLabel.Visible = false;
        }

        /// <summary>
        /// Generates a default name for a map that is being saved
        /// </summary>
        /// <returns></returns>
        public string GenerateDefaultMapFilename()
        {
            string savefile = Path.GetFileNameWithoutExtension(map.Save.FilePath);
            savefile = savefile.Replace("City - ", "");
            return savefile;
        }

        /// <summary>
        /// Check if a save has a lot subfile
        /// </summary>
        public bool CheckSaveContainsLotSubfile(string path)
        {
            SC4SaveFile save = new SC4SaveFile(path);
            return save.ContainsLotSubfile();
        }

        /// <summary>
        /// Searches through a folder and returns a random SC4 savegame 
        /// </summary>
        /// <returns></returns>
        private string FindRandomSavegameFileInPath(string path)
        {
            Random rand = new Random();
            List<string> savegames = new List<string>();

            try
            {
                foreach (string dir in Directory.GetDirectories(path))
                {
                    foreach (string file in Directory.GetFiles(dir))
                    {
                        if (file.ToLower().Contains(".sc4")
                            && !file.Contains("City - New City")
                            && !file.Contains("Tutorial"))
                        {
                            savegames.Add(file);
                        }
                    }
                }
            }
            catch (Exception e) { }

            return savegames[rand.Next(savegames.Count)];
        }

        /// <summary>
        /// Cleanup timer code, calls GC 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private void OnCleanupTimerElapsed(Object source, ElapsedEventArgs e)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        /// <summary>
        /// Updates memory used label every so often with the current memory used by program
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private void MemoryUsedUpdateTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            // Setup toolstrip details
            Process currentProc = Process.GetCurrentProcess();
            MemoryUsedToolStripStatusLabel.Text = $"Memory used: {Math.Truncate(Helper.ConvertBytesToMegabytes(currentProc.PrivateMemorySize64)).ToString()} MB";
        }

        /// <summary>
        /// Callback called when check for update (call to github to fetch info about latest release)
        /// has been performed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnUpdateChecked(object sender, DownloadStringCompletedEventArgs e)
        {
            // If we encounter an error then silently continue
            if (e.Error != null)
            {
                return;
            }

            UpdateInfo info = null;
            try
            {
                info = new UpdateInfo(e.Result);
            }
            catch (Exception)
            {
                // Again this parser _might_ fail so we want to silently continue for an auto update
                // (oh well)
                return;
            }

            if (info.NewVersionAvailable)
            {
                var updateFormat = new UpdateForm(info);
                updateFormat.ShowDialog();
            }
        }

        #endregion

        #region Save Games Control Functionality

        /// <summary>
        /// Rebuilds Save Game tree view and its contents
        /// </summary>
        private void RefreshSaveGamesTreeView()
        {
            // Clear the tree
            FileTreeView.Nodes.Clear();

            // If entered directory doesnt exist, dont bother rendering tree
            if (!Directory.Exists(SavePathTextbox.Text))
                return;

            // Get folders and files
            string[] dirs = Directory.GetDirectories(SavePathTextbox.Text);
            string[] files = Directory.GetFiles(SavePathTextbox.Text);

            foreach (string dir in dirs)
            {
                DirectoryInfo di = new DirectoryInfo(dir);
                TreeNode node = new TreeNode(di.Name, 0, 1);

                try
                {
                    node.Tag = dir;  //keep the directory's full path in the tag for use later

                    //if the directory has any sub directories add the place holder
                    if (di.GetFiles().Count() > 0 || di.GetDirectories().Count() > 0)//GetDirectories().Count() > 0) di.GetDirectories().Count() > 0)
                        node.Nodes.Add(null, "...", 0, 0);
                }
                catch (UnauthorizedAccessException)
                {
                    //if an unauthorized access exception occured display a locked folder
                    node.ImageIndex = 12;
                    node.SelectedImageIndex = 12;
                }
                catch (Exception ex)
                {
                    ErrorForm form = new ErrorForm(
                        "Directory tree error",
                        "An error occured while trying to populate save game file tree.",
                        ex,
                        false);

                    form.StartPosition = FormStartPosition.CenterParent;
                    form.ShowDialog();
                }
                finally
                {
                    FileTreeView.Nodes.Add(node);
                }
            }

            foreach (string file in files)
            {
                // Creat new node with file name
                TreeNode node = new TreeNode(Path.GetFileName(file), 0, 1);

                // Display file image on node
                node.ImageIndex = 13;
                node.SelectedImageIndex = 13;
                node.Tag = file;

                // Only show files with sc4 extension and don't show cities that haven't been
                // founded yet
                if (file.Contains(".sc4"))
                //&& !file.Contains("City - New City ("))
                {
                    if (FilterNewCitiesCheckbox.Checked
                        && file.Contains("City - New City ("))
                    {
                        continue;
                    }

                    // Add to node
                    FileTreeView.Nodes.Add(node);
                }
            }
        }

        #endregion

        #region Appearance Controls Functionality

        /// <summary>
        /// Register all appearance UI events 
        /// We seperated out registering events from their components creation so we can set the UI values without having 
        /// their callbacks fire
        /// NOTE: Don't call this without calling deregister method, events can be hooked twice
        /// </summary>
        private void RegisterAppearanceEvents()
        {
            this.ShowZoneOutlinesCheckbox.CheckedChanged += new System.EventHandler(this.ShowZoneOutlinesCheckbox_CheckedChanged);
            this.SegmentPaddingNumericUpDown.ValueChanged += new System.EventHandler(this.SegmentPaddingNumericUpDown_ValueChanged);
            this.GridSegmentSizeNumericUpDown.ValueChanged += new System.EventHandler(this.GridSegmentSizeNumericUpDown_ValueChanged);
            this.ShowGridLinesCheckbox.CheckedChanged += new System.EventHandler(this.ShowGridLinesCheckbox_CheckedChanged);
            this.ShowBuildingOutlinesCheckBox.CheckedChanged += new System.EventHandler(this.ShowBuildingOutlinesCheckBox_CheckedChanged);
            this.BlendTerrainColorsCheckBox.CheckedChanged += new System.EventHandler(this.BlendTerrainColorsCheckBox_CheckedChanged);
            this.SpaceportEditButton.Click += new System.EventHandler(this.SpaceportEditButton_Click);
            this.SeaportsEditButton.Click += new System.EventHandler(this.SeaportsEditButton_Click);
            this.AirportsEditButton.Click += new System.EventHandler(this.AirportsEditButton_Click);
            this.MilitaryEditButton.Click += new System.EventHandler(this.MilitaryEditButton_Click);
            this.ZoneOutlinesEditButton.Click += new System.EventHandler(this.ZoneOutlinesEditButton_Click);
            this.IndustrialZoneLowEditButton.Click += new System.EventHandler(this.IndustrialZoneLowEditButton_Click);
            this.IndustrialZoneMidEditButton.Click += new System.EventHandler(this.IndustrialZoneMidEditButton_Click);
            this.IndustrialZoneHighEditButton.Click += new System.EventHandler(this.IndustrialZoneHighEditButton_Click);
            this.CommercialZoneHighEditButton.Click += new System.EventHandler(this.CommercialZoneHighEditButton_Click);
            this.CommercialZoneMidEditButton.Click += new System.EventHandler(this.CommercialZoneMidEditButton_Click);
            this.CommercialZoneLowEditButton.Click += new System.EventHandler(this.CommercialZoneLowEditButton_Click);
            this.GridLinesEditTextbox.Click += new System.EventHandler(this.GridLinesEditTextbox_Click);
            this.PloppedBuildingsEditButton.Click += new System.EventHandler(this.PloppableBuildingsEditButton_Click);
            this.ResidentialZoneLowEditButton.Click += new System.EventHandler(this.ResidentialZoneLowEditButton_Click);
            this.ResidentialZoneHighEditButton.Click += new System.EventHandler(this.ResidentialZoneHighEditButton_Click);
            this.ResidentialZoneMidEditButton.Click += new System.EventHandler(this.ResidentialZoneMidEditButton_Click);
            this.GridBackgroundEditButton.Click += new System.EventHandler(this.GridBackgroundEditButton_Click);
            this.StreetEditButton.Click += new System.EventHandler(this.StreetEditButton_Click);
            this.RoadEditButton.Click += new System.EventHandler(this.RoadEditButton_Click);
            this.OneWayRoadEditButton.Click += new System.EventHandler(this.OneWayRoadEditButton_Click);
            this.AvenueEditButton.Click += new System.EventHandler(this.AvenueEditButton_Click);
            this.RailwayEditButton.Click += new System.EventHandler(this.RailwayEditButton_Click);
            this.SubwayEditButton.Click += new System.EventHandler(this.SubwayEditButton_Click);
            this.EditOutputPathButton.Click += new System.EventHandler(this.EditOutputPathButton_Click);

            this.BuildingsEditButton.Click += new System.EventHandler(this.BuildingsEditButton_Click);
            this.BuildingsOutlineEditButton.Click += new System.EventHandler(this.BuildingsOutlineEditButton_Click);

            this.TerrainLayer1CheckBox.CheckedChanged += new System.EventHandler(this.TerrainLayer1CheckBox_CheckedChanged);
            this.TerrainLayer2CheckBox.CheckedChanged += new System.EventHandler(this.TerrainLayer2CheckBox_CheckedChanged);
            this.TerrainLayer3CheckBox.CheckedChanged += new System.EventHandler(this.TerrainLayer3CheckBox_CheckedChanged);
            this.TerrainLayer4CheckBox.CheckedChanged += new System.EventHandler(this.TerrainLayer4CheckBox_CheckedChanged);
            this.TerrainLayer5CheckBox.CheckedChanged += new System.EventHandler(this.TerrainLayer5CheckBox_CheckedChanged);
            this.TerrainLayer6CheckBox.CheckedChanged += new System.EventHandler(this.TerrainLayer6CheckBox_CheckedChanged);
            this.TerrainLayer7CheckBox.CheckedChanged += new System.EventHandler(this.TerrainLayer7CheckBox_CheckedChanged);
            this.TerrainLayer8CheckBox.CheckedChanged += new System.EventHandler(this.TerrainLayer8CheckBox_CheckedChanged);
            this.TerrainLayer9CheckBox.CheckedChanged += new System.EventHandler(this.TerrainLayer9CheckBox_CheckedChanged);
            this.TerrainLayer10CheckBox.CheckedChanged += new System.EventHandler(this.TerrainLayer10CheckBox_CheckedChanged);
            this.TerrainLayer11CheckBox.CheckedChanged += new System.EventHandler(this.TerrainLayer11CheckBox_CheckedChanged);
            this.TerrainLayer12CheckBox.CheckedChanged += new System.EventHandler(this.TerrainLayer12CheckBox_CheckedChanged);
            this.TerrainLayer13CheckBox.CheckedChanged += new System.EventHandler(this.TerrainLayer13CheckBox_CheckedChanged);
            this.TerrainLayer14CheckBox.CheckedChanged += new System.EventHandler(this.TerrainLayer14CheckBox_CheckedChanged);
            this.TerrainLayer15CheckBox.CheckedChanged += new System.EventHandler(this.TerrainLayer15CheckBox_CheckedChanged);
            this.TerrainLayer16CheckBox.CheckedChanged += new System.EventHandler(this.TerrainLayer16CheckBox_CheckedChanged);
            this.TerrainLayer17CheckBox.CheckedChanged += new System.EventHandler(this.TerrainLayer17CheckBox_CheckedChanged);
            this.TerrainLayer18CheckBox.CheckedChanged += new System.EventHandler(this.TerrainLayer18CheckBox_CheckedChanged);
            this.TerrainLayer19CheckBox.CheckedChanged += new System.EventHandler(this.TerrainLayer19CheckBox_CheckedChanged);
            this.TerrainLayer20CheckBox.CheckedChanged += new System.EventHandler(this.TerrainLayer20CheckBox_CheckedChanged);
            this.TerrainLayer21CheckBox.CheckedChanged += new System.EventHandler(this.TerrainLayer21CheckBox_CheckedChanged);
            this.TerrainLayer22CheckBox.CheckedChanged += new System.EventHandler(this.TerrainLayer22CheckBox_CheckedChanged);
            this.TerrainLayer23CheckBox.CheckedChanged += new System.EventHandler(this.TerrainLayer23CheckBox_CheckedChanged);
            this.TerrainLayer1NumericUpDown.ValueChanged += new System.EventHandler(this.TerrainLayer1NumericUpDown_ValueChanged);
            this.TerrainLayer2NumericUpDown.ValueChanged += new System.EventHandler(this.TerrainLayer2NumericUpDown_ValueChanged);
            this.TerrainLayer3NumericUpDown.ValueChanged += new System.EventHandler(this.TerrainLayer3NumericUpDown_ValueChanged);
            this.TerrainLayer4NumericUpDown.ValueChanged += new System.EventHandler(this.TerrainLayer4NumericUpDown_ValueChanged);
            this.TerrainLayer5NumericUpDown.ValueChanged += new System.EventHandler(this.TerrainLayer5NumericUpDown_ValueChanged);
            this.TerrainLayer6NumericUpDown.ValueChanged += new System.EventHandler(this.TerrainLayer6NumericUpDown_ValueChanged);
            this.TerrainLayer7NumericUpDown.ValueChanged += new System.EventHandler(this.TerrainLayer7NumericUpDown_ValueChanged);
            this.TerrainLayer8NumericUpDown.ValueChanged += new System.EventHandler(this.TerrainLayer8NumericUpDown_ValueChanged);
            this.TerrainLayer9NumericUpDown.ValueChanged += new System.EventHandler(this.TerrainLayer9NumericUpDown_ValueChanged);
            this.TerrainLayer10NumericUpDown.ValueChanged += new System.EventHandler(this.TerrainLayer10NumericUpDown_ValueChanged);
            this.TerrainLayer11NumericUpDown.ValueChanged += new System.EventHandler(this.TerrainLayer11NumericUpDown_ValueChanged);
            this.TerrainLayer12NumericUpDown.ValueChanged += new System.EventHandler(this.TerrainLayer12NumericUpDown_ValueChanged);
            this.TerrainLayer13NumericUpDown.ValueChanged += new System.EventHandler(this.TerrainLayer13NumericUpDown_ValueChanged);
            this.TerrainLayer14NumericUpDown.ValueChanged += new System.EventHandler(this.TerrainLayer14NumericUpDown_ValueChanged);
            this.TerrainLayer15NumericUpDown.ValueChanged += new System.EventHandler(this.TerrainLayer15NumericUpDown_ValueChanged);
            this.TerrainLayer16NumericUpDown.ValueChanged += new System.EventHandler(this.TerrainLayer16NumericUpDown_ValueChanged);
            this.TerrainLayer17NumericUpDown.ValueChanged += new System.EventHandler(this.TerrainLayer17NumericUpDown_ValueChanged);
            this.TerrainLayer18NumericUpDown.ValueChanged += new System.EventHandler(this.TerrainLayer18NumericUpDown_ValueChanged);
            this.TerrainLayer19NumericUpDown.ValueChanged += new System.EventHandler(this.TerrainLayer19NumericUpDown_ValueChanged);
            this.TerrainLayer20NumericUpDown.ValueChanged += new System.EventHandler(this.TerrainLayer20NumericUpDown_ValueChanged);
            this.TerrainLayer21NumericUpDown.ValueChanged += new System.EventHandler(this.TerrainLayer21NumericUpDown_ValueChanged);
            this.TerrainLayer22NumericUpDown.ValueChanged += new System.EventHandler(this.TerrainLayer22NumericUpDown_ValueChanged);
            this.TerrainLayer23NumericUpDown.ValueChanged += new System.EventHandler(this.TerrainLayer23NumericUpDown_ValueChanged);
            this.TerrainLayer1Button.Click += new System.EventHandler(this.TerrainLayer1Button_click);
            this.TerrainLayer2Button.Click += new System.EventHandler(this.TerrainLayer2Button_click);
            this.TerrainLayer3Button.Click += new System.EventHandler(this.TerrainLayer3Button_click);
            this.TerrainLayer4Button.Click += new System.EventHandler(this.TerrainLayer4Button_click);
            this.TerrainLayer5Button.Click += new System.EventHandler(this.TerrainLayer5Button_click);
            this.TerrainLayer6Button.Click += new System.EventHandler(this.TerrainLayer6Button_click);
            this.TerrainLayer7Button.Click += new System.EventHandler(this.TerrainLayer7Button_click);
            this.TerrainLayer8Button.Click += new System.EventHandler(this.TerrainLayer8Button_click);
            this.TerrainLayer9Button.Click += new System.EventHandler(this.TerrainLayer9Button_click);
            this.TerrainLayer10Button.Click += new System.EventHandler(this.TerrainLayer10Button_click);
            this.TerrainLayer11Button.Click += new System.EventHandler(this.TerrainLayer11Button_click);
            this.TerrainLayer12Button.Click += new System.EventHandler(this.TerrainLayer12Button_click);
            this.TerrainLayer13Button.Click += new System.EventHandler(this.TerrainLayer13Button_click);
            this.TerrainLayer14Button.Click += new System.EventHandler(this.TerrainLayer14Button_click);
            this.TerrainLayer15Button.Click += new System.EventHandler(this.TerrainLayer15Button_click);
            this.TerrainLayer16Button.Click += new System.EventHandler(this.TerrainLayer16Button_click);
            this.TerrainLayer17Button.Click += new System.EventHandler(this.TerrainLayer17Button_click);
            this.TerrainLayer18Button.Click += new System.EventHandler(this.TerrainLayer18Button_click);
            this.TerrainLayer19Button.Click += new System.EventHandler(this.TerrainLayer19Button_click);
            this.TerrainLayer20Button.Click += new System.EventHandler(this.TerrainLayer20Button_click);
            this.TerrainLayer21Button.Click += new System.EventHandler(this.TerrainLayer21Button_click);
            this.TerrainLayer22Button.Click += new System.EventHandler(this.TerrainLayer22Button_click);
            this.TerrainLayer23Button.Click += new System.EventHandler(this.TerrainLayer23Button_click);

            // Register mouse wheel callbacks to stop mouse wheels incrementing values too quickly
            this.GridSegmentSizeNumericUpDown.MouseWheel += NumericUpDown_MouseWheel;
            this.SegmentPaddingNumericUpDown.MouseWheel += NumericUpDown_MouseWheel;
            this.TerrainLayer1NumericUpDown.MouseWheel += NumericUpDown_MouseWheel;
            this.TerrainLayer2NumericUpDown.MouseWheel += NumericUpDown_MouseWheel;
            this.TerrainLayer3NumericUpDown.MouseWheel += NumericUpDown_MouseWheel;
            this.TerrainLayer4NumericUpDown.MouseWheel += NumericUpDown_MouseWheel;
            this.TerrainLayer5NumericUpDown.MouseWheel += NumericUpDown_MouseWheel;
            this.TerrainLayer6NumericUpDown.MouseWheel += NumericUpDown_MouseWheel;
            this.TerrainLayer7NumericUpDown.MouseWheel += NumericUpDown_MouseWheel;
            this.TerrainLayer8NumericUpDown.MouseWheel += NumericUpDown_MouseWheel;
            this.TerrainLayer9NumericUpDown.MouseWheel += NumericUpDown_MouseWheel;
            this.TerrainLayer10NumericUpDown.MouseWheel += NumericUpDown_MouseWheel;
            this.TerrainLayer11NumericUpDown.MouseWheel += NumericUpDown_MouseWheel;
            this.TerrainLayer12NumericUpDown.MouseWheel += NumericUpDown_MouseWheel;
            this.TerrainLayer13NumericUpDown.MouseWheel += NumericUpDown_MouseWheel;
            this.TerrainLayer14NumericUpDown.MouseWheel += NumericUpDown_MouseWheel;
            this.TerrainLayer15NumericUpDown.MouseWheel += NumericUpDown_MouseWheel;
            this.TerrainLayer16NumericUpDown.MouseWheel += NumericUpDown_MouseWheel;
            this.TerrainLayer17NumericUpDown.MouseWheel += NumericUpDown_MouseWheel;
            this.TerrainLayer18NumericUpDown.MouseWheel += NumericUpDown_MouseWheel;
            this.TerrainLayer19NumericUpDown.MouseWheel += NumericUpDown_MouseWheel;
            this.TerrainLayer20NumericUpDown.MouseWheel += NumericUpDown_MouseWheel;
            this.TerrainLayer21NumericUpDown.MouseWheel += NumericUpDown_MouseWheel;
            this.TerrainLayer22NumericUpDown.MouseWheel += NumericUpDown_MouseWheel;
            this.TerrainLayer23NumericUpDown.MouseWheel += NumericUpDown_MouseWheel;
        }

        /// <summary>
        /// Deregister all appearance callbacks, we use this to temporarily disable all callbacks when loading map parameters
        /// when no map is loaded
        /// </summary>
        private void DeregisterAppearanceEvents()
        {
            this.ShowZoneOutlinesCheckbox.CheckedChanged -= new System.EventHandler(this.ShowZoneOutlinesCheckbox_CheckedChanged);
            this.SegmentPaddingNumericUpDown.ValueChanged -= new System.EventHandler(this.SegmentPaddingNumericUpDown_ValueChanged);
            this.GridSegmentSizeNumericUpDown.ValueChanged -= new System.EventHandler(this.GridSegmentSizeNumericUpDown_ValueChanged);
            this.ShowGridLinesCheckbox.CheckedChanged -= new System.EventHandler(this.ShowGridLinesCheckbox_CheckedChanged);
            this.BlendTerrainColorsCheckBox.CheckedChanged -= new System.EventHandler(this.BlendTerrainColorsCheckBox_CheckedChanged);
            this.ShowBuildingOutlinesCheckBox.CheckedChanged -= new System.EventHandler(this.ShowBuildingOutlinesCheckBox_CheckedChanged);
            this.SpaceportEditButton.Click -= new System.EventHandler(this.SpaceportEditButton_Click);
            this.SeaportsEditButton.Click -= new System.EventHandler(this.SeaportsEditButton_Click);
            this.AirportsEditButton.Click -= new System.EventHandler(this.AirportsEditButton_Click);
            this.MilitaryEditButton.Click -= new System.EventHandler(this.MilitaryEditButton_Click);
            this.ZoneOutlinesEditButton.Click -= new System.EventHandler(this.ZoneOutlinesEditButton_Click);
            this.IndustrialZoneLowEditButton.Click -= new System.EventHandler(this.IndustrialZoneLowEditButton_Click);
            this.IndustrialZoneMidEditButton.Click -= new System.EventHandler(this.IndustrialZoneMidEditButton_Click);
            this.IndustrialZoneHighEditButton.Click -= new System.EventHandler(this.IndustrialZoneHighEditButton_Click);
            this.CommercialZoneHighEditButton.Click -= new System.EventHandler(this.CommercialZoneHighEditButton_Click);
            this.CommercialZoneMidEditButton.Click -= new System.EventHandler(this.CommercialZoneMidEditButton_Click);
            this.CommercialZoneLowEditButton.Click -= new System.EventHandler(this.CommercialZoneLowEditButton_Click);
            this.GridLinesEditTextbox.Click -= new System.EventHandler(this.GridLinesEditTextbox_Click);
            this.PloppedBuildingsEditButton.Click -= new System.EventHandler(this.PloppableBuildingsEditButton_Click);
            this.ResidentialZoneLowEditButton.Click -= new System.EventHandler(this.ResidentialZoneLowEditButton_Click);
            this.ResidentialZoneHighEditButton.Click -= new System.EventHandler(this.ResidentialZoneHighEditButton_Click);
            this.ResidentialZoneMidEditButton.Click -= new System.EventHandler(this.ResidentialZoneMidEditButton_Click);
            this.GridBackgroundEditButton.Click -= new System.EventHandler(this.GridBackgroundEditButton_Click);
            this.StreetEditButton.Click -= new System.EventHandler(this.StreetEditButton_Click);
            this.RoadEditButton.Click -= new System.EventHandler(this.RoadEditButton_Click);
            this.OneWayRoadEditButton.Click -= new System.EventHandler(this.OneWayRoadEditButton_Click);
            this.AvenueEditButton.Click -= new System.EventHandler(this.AvenueEditButton_Click);
            this.RailwayEditButton.Click -= new System.EventHandler(this.RailwayEditButton_Click);
            this.SubwayEditButton.Click -= new System.EventHandler(this.SubwayEditButton_Click);
            this.EditOutputPathButton.Click -= new System.EventHandler(this.EditOutputPathButton_Click);
            this.BuildingsEditButton.Click -= new System.EventHandler(this.BuildingsEditButton_Click);
            this.BuildingsOutlineEditButton.Click -= new System.EventHandler(this.BuildingsOutlineEditButton_Click);

            this.TerrainLayer1CheckBox.CheckedChanged -= new System.EventHandler(this.TerrainLayer1CheckBox_CheckedChanged);
            this.TerrainLayer2CheckBox.CheckedChanged -= new System.EventHandler(this.TerrainLayer2CheckBox_CheckedChanged);
            this.TerrainLayer3CheckBox.CheckedChanged -= new System.EventHandler(this.TerrainLayer3CheckBox_CheckedChanged);
            this.TerrainLayer4CheckBox.CheckedChanged -= new System.EventHandler(this.TerrainLayer4CheckBox_CheckedChanged);
            this.TerrainLayer5CheckBox.CheckedChanged -= new System.EventHandler(this.TerrainLayer5CheckBox_CheckedChanged);
            this.TerrainLayer6CheckBox.CheckedChanged -= new System.EventHandler(this.TerrainLayer6CheckBox_CheckedChanged);
            this.TerrainLayer7CheckBox.CheckedChanged -= new System.EventHandler(this.TerrainLayer7CheckBox_CheckedChanged);
            this.TerrainLayer8CheckBox.CheckedChanged -= new System.EventHandler(this.TerrainLayer8CheckBox_CheckedChanged);
            this.TerrainLayer9CheckBox.CheckedChanged -= new System.EventHandler(this.TerrainLayer9CheckBox_CheckedChanged);
            this.TerrainLayer10CheckBox.CheckedChanged -= new System.EventHandler(this.TerrainLayer10CheckBox_CheckedChanged);
            this.TerrainLayer11CheckBox.CheckedChanged -= new System.EventHandler(this.TerrainLayer11CheckBox_CheckedChanged);
            this.TerrainLayer12CheckBox.CheckedChanged -= new System.EventHandler(this.TerrainLayer12CheckBox_CheckedChanged);
            this.TerrainLayer13CheckBox.CheckedChanged -= new System.EventHandler(this.TerrainLayer13CheckBox_CheckedChanged);
            this.TerrainLayer14CheckBox.CheckedChanged -= new System.EventHandler(this.TerrainLayer14CheckBox_CheckedChanged);
            this.TerrainLayer15CheckBox.CheckedChanged -= new System.EventHandler(this.TerrainLayer15CheckBox_CheckedChanged);
            this.TerrainLayer16CheckBox.CheckedChanged -= new System.EventHandler(this.TerrainLayer16CheckBox_CheckedChanged);
            this.TerrainLayer17CheckBox.CheckedChanged -= new System.EventHandler(this.TerrainLayer17CheckBox_CheckedChanged);
            this.TerrainLayer18CheckBox.CheckedChanged -= new System.EventHandler(this.TerrainLayer18CheckBox_CheckedChanged);
            this.TerrainLayer19CheckBox.CheckedChanged -= new System.EventHandler(this.TerrainLayer19CheckBox_CheckedChanged);
            this.TerrainLayer20CheckBox.CheckedChanged -= new System.EventHandler(this.TerrainLayer20CheckBox_CheckedChanged);
            this.TerrainLayer21CheckBox.CheckedChanged -= new System.EventHandler(this.TerrainLayer21CheckBox_CheckedChanged);
            this.TerrainLayer22CheckBox.CheckedChanged -= new System.EventHandler(this.TerrainLayer22CheckBox_CheckedChanged);
            this.TerrainLayer23CheckBox.CheckedChanged -= new System.EventHandler(this.TerrainLayer23CheckBox_CheckedChanged);
            this.TerrainLayer1NumericUpDown.ValueChanged -= new System.EventHandler(this.TerrainLayer1NumericUpDown_ValueChanged);
            this.TerrainLayer2NumericUpDown.ValueChanged -= new System.EventHandler(this.TerrainLayer2NumericUpDown_ValueChanged);
            this.TerrainLayer3NumericUpDown.ValueChanged -= new System.EventHandler(this.TerrainLayer3NumericUpDown_ValueChanged);
            this.TerrainLayer4NumericUpDown.ValueChanged -= new System.EventHandler(this.TerrainLayer4NumericUpDown_ValueChanged);
            this.TerrainLayer5NumericUpDown.ValueChanged -= new System.EventHandler(this.TerrainLayer5NumericUpDown_ValueChanged);
            this.TerrainLayer6NumericUpDown.ValueChanged -= new System.EventHandler(this.TerrainLayer6NumericUpDown_ValueChanged);
            this.TerrainLayer7NumericUpDown.ValueChanged -= new System.EventHandler(this.TerrainLayer7NumericUpDown_ValueChanged);
            this.TerrainLayer8NumericUpDown.ValueChanged -= new System.EventHandler(this.TerrainLayer8NumericUpDown_ValueChanged);
            this.TerrainLayer9NumericUpDown.ValueChanged -= new System.EventHandler(this.TerrainLayer9NumericUpDown_ValueChanged);
            this.TerrainLayer10NumericUpDown.ValueChanged -= new System.EventHandler(this.TerrainLayer10NumericUpDown_ValueChanged);
            this.TerrainLayer11NumericUpDown.ValueChanged -= new System.EventHandler(this.TerrainLayer11NumericUpDown_ValueChanged);
            this.TerrainLayer12NumericUpDown.ValueChanged -= new System.EventHandler(this.TerrainLayer12NumericUpDown_ValueChanged);
            this.TerrainLayer13NumericUpDown.ValueChanged -= new System.EventHandler(this.TerrainLayer13NumericUpDown_ValueChanged);
            this.TerrainLayer14NumericUpDown.ValueChanged -= new System.EventHandler(this.TerrainLayer14NumericUpDown_ValueChanged);
            this.TerrainLayer15NumericUpDown.ValueChanged -= new System.EventHandler(this.TerrainLayer15NumericUpDown_ValueChanged);
            this.TerrainLayer16NumericUpDown.ValueChanged -= new System.EventHandler(this.TerrainLayer16NumericUpDown_ValueChanged);
            this.TerrainLayer17NumericUpDown.ValueChanged -= new System.EventHandler(this.TerrainLayer17NumericUpDown_ValueChanged);
            this.TerrainLayer18NumericUpDown.ValueChanged -= new System.EventHandler(this.TerrainLayer18NumericUpDown_ValueChanged);
            this.TerrainLayer19NumericUpDown.ValueChanged -= new System.EventHandler(this.TerrainLayer19NumericUpDown_ValueChanged);
            this.TerrainLayer20NumericUpDown.ValueChanged -= new System.EventHandler(this.TerrainLayer20NumericUpDown_ValueChanged);
            this.TerrainLayer21NumericUpDown.ValueChanged -= new System.EventHandler(this.TerrainLayer21NumericUpDown_ValueChanged);
            this.TerrainLayer22NumericUpDown.ValueChanged -= new System.EventHandler(this.TerrainLayer22NumericUpDown_ValueChanged);
            this.TerrainLayer23NumericUpDown.ValueChanged -= new System.EventHandler(this.TerrainLayer23NumericUpDown_ValueChanged);
            this.TerrainLayer1Button.Click -= new System.EventHandler(this.TerrainLayer1Button_click);
            this.TerrainLayer2Button.Click -= new System.EventHandler(this.TerrainLayer2Button_click);
            this.TerrainLayer3Button.Click -= new System.EventHandler(this.TerrainLayer3Button_click);
            this.TerrainLayer4Button.Click -= new System.EventHandler(this.TerrainLayer4Button_click);
            this.TerrainLayer5Button.Click -= new System.EventHandler(this.TerrainLayer5Button_click);
            this.TerrainLayer6Button.Click -= new System.EventHandler(this.TerrainLayer6Button_click);
            this.TerrainLayer7Button.Click -= new System.EventHandler(this.TerrainLayer7Button_click);
            this.TerrainLayer8Button.Click -= new System.EventHandler(this.TerrainLayer8Button_click);
            this.TerrainLayer9Button.Click -= new System.EventHandler(this.TerrainLayer9Button_click);
            this.TerrainLayer10Button.Click -= new System.EventHandler(this.TerrainLayer10Button_click);
            this.TerrainLayer11Button.Click -= new System.EventHandler(this.TerrainLayer11Button_click);
            this.TerrainLayer12Button.Click -= new System.EventHandler(this.TerrainLayer12Button_click);
            this.TerrainLayer13Button.Click -= new System.EventHandler(this.TerrainLayer13Button_click);
            this.TerrainLayer14Button.Click -= new System.EventHandler(this.TerrainLayer14Button_click);
            this.TerrainLayer15Button.Click -= new System.EventHandler(this.TerrainLayer15Button_click);
            this.TerrainLayer16Button.Click -= new System.EventHandler(this.TerrainLayer16Button_click);
            this.TerrainLayer17Button.Click -= new System.EventHandler(this.TerrainLayer17Button_click);
            this.TerrainLayer18Button.Click -= new System.EventHandler(this.TerrainLayer18Button_click);
            this.TerrainLayer19Button.Click -= new System.EventHandler(this.TerrainLayer19Button_click);
            this.TerrainLayer20Button.Click -= new System.EventHandler(this.TerrainLayer20Button_click);
            this.TerrainLayer21Button.Click -= new System.EventHandler(this.TerrainLayer21Button_click);
            this.TerrainLayer22Button.Click -= new System.EventHandler(this.TerrainLayer22Button_click);
            this.TerrainLayer23Button.Click -= new System.EventHandler(this.TerrainLayer23Button_click);

            this.GridSegmentSizeNumericUpDown.MouseWheel -= NumericUpDown_MouseWheel;
            this.SegmentPaddingNumericUpDown.MouseWheel -= NumericUpDown_MouseWheel;
            this.TerrainLayer1NumericUpDown.MouseWheel -= NumericUpDown_MouseWheel;
            this.TerrainLayer2NumericUpDown.MouseWheel -= NumericUpDown_MouseWheel;
            this.TerrainLayer3NumericUpDown.MouseWheel -= NumericUpDown_MouseWheel;
            this.TerrainLayer4NumericUpDown.MouseWheel -= NumericUpDown_MouseWheel;
            this.TerrainLayer5NumericUpDown.MouseWheel -= NumericUpDown_MouseWheel;
            this.TerrainLayer6NumericUpDown.MouseWheel -= NumericUpDown_MouseWheel;
            this.TerrainLayer7NumericUpDown.MouseWheel -= NumericUpDown_MouseWheel;
            this.TerrainLayer8NumericUpDown.MouseWheel -= NumericUpDown_MouseWheel;
            this.TerrainLayer9NumericUpDown.MouseWheel -= NumericUpDown_MouseWheel;
            this.TerrainLayer10NumericUpDown.MouseWheel -= NumericUpDown_MouseWheel;
            this.TerrainLayer11NumericUpDown.MouseWheel -= NumericUpDown_MouseWheel;
            this.TerrainLayer12NumericUpDown.MouseWheel -= NumericUpDown_MouseWheel;
            this.TerrainLayer13NumericUpDown.MouseWheel -= NumericUpDown_MouseWheel;
            this.TerrainLayer14NumericUpDown.MouseWheel -= NumericUpDown_MouseWheel;
            this.TerrainLayer15NumericUpDown.MouseWheel -= NumericUpDown_MouseWheel;
            this.TerrainLayer16NumericUpDown.MouseWheel -= NumericUpDown_MouseWheel;
            this.TerrainLayer17NumericUpDown.MouseWheel -= NumericUpDown_MouseWheel;
            this.TerrainLayer18NumericUpDown.MouseWheel -= NumericUpDown_MouseWheel;
            this.TerrainLayer19NumericUpDown.MouseWheel -= NumericUpDown_MouseWheel;
            this.TerrainLayer20NumericUpDown.MouseWheel -= NumericUpDown_MouseWheel;
            this.TerrainLayer21NumericUpDown.MouseWheel -= NumericUpDown_MouseWheel;
            this.TerrainLayer22NumericUpDown.MouseWheel -= NumericUpDown_MouseWheel;
            this.TerrainLayer23NumericUpDown.MouseWheel -= NumericUpDown_MouseWheel;
        }

        /// <summary>
        /// Sets the appearance UI items from a given MapCreationParameters object
        /// The map appearance UI works by loading in a given MapCreationParameter object and it's values into the appearance
        /// UI controls, the user then modifies the ui controls, the ui controls are then turned into a MapCreationParameter object
        /// that is used to generate the map. This function is a key part of this and is used to convert from a parameters object to ui values
        /// modifi
        /// </summary>
        /// <param name="parameters"></param>
        private void SetAppearanceUIValuesUsingParameters(MapCreationParameters parameters)
        {
            DeregisterAppearanceEvents();

            // Fill zone stuff
            GridBackgroundTextbox.BackColor = parameters.ColorDictionary[MapColorObject.Background];
            GridLinesTextbox.BackColor = parameters.ColorDictionary[MapColorObject.GridLines];
            PloppedBuildingsTextbox.BackColor = parameters.ColorDictionary[MapColorObject.PloppedBuilding];
            ZoneOutlinesTextbox.BackColor = parameters.ColorDictionary[MapColorObject.ZoneOutline];
            MilitaryTextbox.BackColor = parameters.ColorDictionary[MapColorObject.Military];
            AirportsTextbox.BackColor = parameters.ColorDictionary[MapColorObject.Airport];
            SeaportTextbox.BackColor = parameters.ColorDictionary[MapColorObject.Seaport];
            SpaceportTextbox.BackColor = parameters.ColorDictionary[MapColorObject.Spaceport];
            ResidentialZoneLowTextbox.BackColor = parameters.ColorDictionary[MapColorObject.ResidentialLow];
            ResidentialZoneMidTextbox.BackColor = parameters.ColorDictionary[MapColorObject.ResidentialMid];
            ResidentialZoneHighTextbox.BackColor = parameters.ColorDictionary[MapColorObject.ResidentialHigh];
            CommercialZoneLowTextbox.BackColor = parameters.ColorDictionary[MapColorObject.CommercialLow];
            CommercialZoneMidTextbox.BackColor = parameters.ColorDictionary[MapColorObject.CommercialMid];
            CommercialZoneHighTextbox.BackColor = parameters.ColorDictionary[MapColorObject.CommercialHigh];
            IndustrialZoneLowTextbox.BackColor = parameters.ColorDictionary[MapColorObject.IndustrialLow];
            IndustrialZoneMidTextbox.BackColor = parameters.ColorDictionary[MapColorObject.IndustrialMid];
            IndustrialZoneHighTextbox.BackColor = parameters.ColorDictionary[MapColorObject.IndustrialHigh];

            // Transport stuff
            StreetTextBox.BackColor = parameters.ColorDictionary[MapColorObject.Street];
            RoadTextBox.BackColor = parameters.ColorDictionary[MapColorObject.Road];
            OneWayRoadTextBox.BackColor = parameters.ColorDictionary[MapColorObject.OneWayRoad];
            AvenueTextBox.BackColor = parameters.ColorDictionary[MapColorObject.Avenue];
            RailwayTextBox.BackColor = parameters.ColorDictionary[MapColorObject.Railway];
            SubwayTextBox.BackColor = parameters.ColorDictionary[MapColorObject.Subway];

            // Building stuff
            BuildingsTextBox.BackColor = parameters.ColorDictionary[MapColorObject.Buildings];
            BuildingsOutlineTextBox.BackColor = parameters.ColorDictionary[MapColorObject.BuildingsOutline];

            // Terrain stuff
            TerrainLayer1CheckBox.Checked = parameters.TerrainDataDictionary[TerrainObject.Layer1].enabled;
            TerrainLayer1AliasTextBox.Text = parameters.TerrainDataDictionary[TerrainObject.Layer1].alias;
            TerrainLayer1NumericUpDown.Value = parameters.TerrainDataDictionary[TerrainObject.Layer1].height;
            TerrainLayer1ColorTextBox.BackColor = parameters.ColorDictionary[parameters.TerrainDataDictionary[TerrainObject.Layer1].colorObject];
            if (parameters.TerrainDataDictionary[TerrainObject.Layer1].enabled == false)
            {
                TerrainLayer1AliasTextBox.Enabled = false;
                TerrainLayer1NumericUpDown.Enabled = false;
                TerrainLayer1Button.Enabled = false;
            }
            TerrainLayer2CheckBox.Checked = parameters.TerrainDataDictionary[TerrainObject.Layer2].enabled;
            TerrainLayer2AliasTextBox.Text = parameters.TerrainDataDictionary[TerrainObject.Layer2].alias;
            TerrainLayer2NumericUpDown.Value = parameters.TerrainDataDictionary[TerrainObject.Layer2].height;
            TerrainLayer2ColorTextBox.BackColor = parameters.ColorDictionary[parameters.TerrainDataDictionary[TerrainObject.Layer2].colorObject];
            if (parameters.TerrainDataDictionary[TerrainObject.Layer2].enabled == false)
            {
                TerrainLayer2AliasTextBox.Enabled = false;
                TerrainLayer2NumericUpDown.Enabled = false;
                TerrainLayer2Button.Enabled = false;
            }
            TerrainLayer3CheckBox.Checked = parameters.TerrainDataDictionary[TerrainObject.Layer3].enabled;
            TerrainLayer3AliasTextBox.Text = parameters.TerrainDataDictionary[TerrainObject.Layer3].alias;
            TerrainLayer3NumericUpDown.Value = parameters.TerrainDataDictionary[TerrainObject.Layer3].height;
            TerrainLayer3ColorTextBox.BackColor = parameters.ColorDictionary[parameters.TerrainDataDictionary[TerrainObject.Layer3].colorObject];
            if (parameters.TerrainDataDictionary[TerrainObject.Layer3].enabled == false)
            {
                TerrainLayer3AliasTextBox.Enabled = false;
                TerrainLayer3NumericUpDown.Enabled = false;
                TerrainLayer3Button.Enabled = false;
            }
            TerrainLayer4CheckBox.Checked = parameters.TerrainDataDictionary[TerrainObject.Layer4].enabled;
            TerrainLayer4AliasTextBox.Text = parameters.TerrainDataDictionary[TerrainObject.Layer4].alias;
            TerrainLayer4NumericUpDown.Value = parameters.TerrainDataDictionary[TerrainObject.Layer4].height;
            TerrainLayer4ColorTextBox.BackColor = parameters.ColorDictionary[parameters.TerrainDataDictionary[TerrainObject.Layer4].colorObject];
            if (parameters.TerrainDataDictionary[TerrainObject.Layer4].enabled == false)
            {
                TerrainLayer4AliasTextBox.Enabled = false;
                TerrainLayer4NumericUpDown.Enabled = false;
                TerrainLayer4Button.Enabled = false;
            }
            TerrainLayer5CheckBox.Checked = parameters.TerrainDataDictionary[TerrainObject.Layer5].enabled;
            TerrainLayer5AliasTextBox.Text = parameters.TerrainDataDictionary[TerrainObject.Layer5].alias;
            TerrainLayer5NumericUpDown.Value = parameters.TerrainDataDictionary[TerrainObject.Layer5].height;
            TerrainLayer5ColorTextBox.BackColor = parameters.ColorDictionary[parameters.TerrainDataDictionary[TerrainObject.Layer5].colorObject];
            if (parameters.TerrainDataDictionary[TerrainObject.Layer5].enabled == false)
            {
                TerrainLayer5AliasTextBox.Enabled = false;
                TerrainLayer5NumericUpDown.Enabled = false;
                TerrainLayer5Button.Enabled = false;
            }
            TerrainLayer6CheckBox.Checked = parameters.TerrainDataDictionary[TerrainObject.Layer6].enabled;
            TerrainLayer6AliasTextBox.Text = parameters.TerrainDataDictionary[TerrainObject.Layer6].alias;
            TerrainLayer6NumericUpDown.Value = parameters.TerrainDataDictionary[TerrainObject.Layer6].height;
            TerrainLayer6ColorTextBox.BackColor = parameters.ColorDictionary[parameters.TerrainDataDictionary[TerrainObject.Layer6].colorObject];
            if (parameters.TerrainDataDictionary[TerrainObject.Layer6].enabled == false)
            {
                TerrainLayer6AliasTextBox.Enabled = false;
                TerrainLayer6NumericUpDown.Enabled = false;
                TerrainLayer6Button.Enabled = false;
            }
            TerrainLayer7CheckBox.Checked = parameters.TerrainDataDictionary[TerrainObject.Layer7].enabled;
            TerrainLayer7AliasTextBox.Text = parameters.TerrainDataDictionary[TerrainObject.Layer7].alias;
            TerrainLayer7NumericUpDown.Value = parameters.TerrainDataDictionary[TerrainObject.Layer7].height;
            TerrainLayer7ColorTextBox.BackColor = parameters.ColorDictionary[parameters.TerrainDataDictionary[TerrainObject.Layer7].colorObject];
            if (parameters.TerrainDataDictionary[TerrainObject.Layer7].enabled == false)
            {
                TerrainLayer7AliasTextBox.Enabled = false;
                TerrainLayer7NumericUpDown.Enabled = false;
                TerrainLayer7Button.Enabled = false;
            }
            TerrainLayer8CheckBox.Checked = parameters.TerrainDataDictionary[TerrainObject.Layer8].enabled;
            TerrainLayer8AliasTextBox.Text = parameters.TerrainDataDictionary[TerrainObject.Layer8].alias;
            TerrainLayer8NumericUpDown.Value = parameters.TerrainDataDictionary[TerrainObject.Layer8].height;
            TerrainLayer8ColorTextBox.BackColor = parameters.ColorDictionary[parameters.TerrainDataDictionary[TerrainObject.Layer8].colorObject];
            if (parameters.TerrainDataDictionary[TerrainObject.Layer8].enabled == false)
            {
                TerrainLayer8AliasTextBox.Enabled = false;
                TerrainLayer8NumericUpDown.Enabled = false;
                TerrainLayer8Button.Enabled = false;
            }
            TerrainLayer9CheckBox.Checked = parameters.TerrainDataDictionary[TerrainObject.Layer9].enabled;
            TerrainLayer9AliasTextBox.Text = parameters.TerrainDataDictionary[TerrainObject.Layer9].alias;
            TerrainLayer9NumericUpDown.Value = parameters.TerrainDataDictionary[TerrainObject.Layer9].height;
            TerrainLayer9ColorTextBox.BackColor = parameters.ColorDictionary[parameters.TerrainDataDictionary[TerrainObject.Layer9].colorObject];
            if (parameters.TerrainDataDictionary[TerrainObject.Layer9].enabled == false)
            {
                TerrainLayer9AliasTextBox.Enabled = false;
                TerrainLayer9NumericUpDown.Enabled = false;
                TerrainLayer9Button.Enabled = false;
            }
            TerrainLayer10CheckBox.Checked = parameters.TerrainDataDictionary[TerrainObject.Layer10].enabled;
            TerrainLayer10AliasTextBox.Text = parameters.TerrainDataDictionary[TerrainObject.Layer10].alias;
            TerrainLayer10NumericUpDown.Value = parameters.TerrainDataDictionary[TerrainObject.Layer10].height;
            TerrainLayer10ColorTextBox.BackColor = parameters.ColorDictionary[parameters.TerrainDataDictionary[TerrainObject.Layer10].colorObject];
            if (parameters.TerrainDataDictionary[TerrainObject.Layer10].enabled == false)
            {
                TerrainLayer10AliasTextBox.Enabled = false;
                TerrainLayer10NumericUpDown.Enabled = false;
                TerrainLayer10Button.Enabled = false;
            }
            TerrainLayer11CheckBox.Checked = parameters.TerrainDataDictionary[TerrainObject.Layer11].enabled;
            TerrainLayer11AliasTextBox.Text = parameters.TerrainDataDictionary[TerrainObject.Layer11].alias;
            TerrainLayer11NumericUpDown.Value = parameters.TerrainDataDictionary[TerrainObject.Layer11].height;
            TerrainLayer11ColorTextBox.BackColor = parameters.ColorDictionary[parameters.TerrainDataDictionary[TerrainObject.Layer11].colorObject];
            if (parameters.TerrainDataDictionary[TerrainObject.Layer11].enabled == false)
            {
                TerrainLayer11AliasTextBox.Enabled = false;
                TerrainLayer11NumericUpDown.Enabled = false;
                TerrainLayer11Button.Enabled = false;
            }
            TerrainLayer12CheckBox.Checked = parameters.TerrainDataDictionary[TerrainObject.Layer12].enabled;
            TerrainLayer12AliasTextBox.Text = parameters.TerrainDataDictionary[TerrainObject.Layer12].alias;
            TerrainLayer12NumericUpDown.Value = parameters.TerrainDataDictionary[TerrainObject.Layer12].height;
            TerrainLayer12ColorTextBox.BackColor = parameters.ColorDictionary[parameters.TerrainDataDictionary[TerrainObject.Layer12].colorObject];
            if (parameters.TerrainDataDictionary[TerrainObject.Layer12].enabled == false)
            {
                TerrainLayer12AliasTextBox.Enabled = false;
                TerrainLayer12NumericUpDown.Enabled = false;
                TerrainLayer12Button.Enabled = false;
            }
            TerrainLayer13CheckBox.Checked = parameters.TerrainDataDictionary[TerrainObject.Layer13].enabled;
            TerrainLayer13AliasTextBox.Text = parameters.TerrainDataDictionary[TerrainObject.Layer13].alias;
            TerrainLayer13NumericUpDown.Value = parameters.TerrainDataDictionary[TerrainObject.Layer13].height;
            TerrainLayer13ColorTextBox.BackColor = parameters.ColorDictionary[parameters.TerrainDataDictionary[TerrainObject.Layer13].colorObject];
            if (parameters.TerrainDataDictionary[TerrainObject.Layer13].enabled == false)
            {
                TerrainLayer13AliasTextBox.Enabled = false;
                TerrainLayer13NumericUpDown.Enabled = false;
                TerrainLayer13Button.Enabled = false;
            }
            TerrainLayer14CheckBox.Checked = parameters.TerrainDataDictionary[TerrainObject.Layer14].enabled;
            TerrainLayer14AliasTextBox.Text = parameters.TerrainDataDictionary[TerrainObject.Layer14].alias;
            TerrainLayer14NumericUpDown.Value = parameters.TerrainDataDictionary[TerrainObject.Layer14].height;
            TerrainLayer14ColorTextBox.BackColor = parameters.ColorDictionary[parameters.TerrainDataDictionary[TerrainObject.Layer14].colorObject];
            if (parameters.TerrainDataDictionary[TerrainObject.Layer14].enabled == false)
            {
                TerrainLayer14AliasTextBox.Enabled = false;
                TerrainLayer14NumericUpDown.Enabled = false;
                TerrainLayer14Button.Enabled = false;
            }
            TerrainLayer15CheckBox.Checked = parameters.TerrainDataDictionary[TerrainObject.Layer15].enabled;
            TerrainLayer15AliasTextBox.Text = parameters.TerrainDataDictionary[TerrainObject.Layer15].alias;
            TerrainLayer15NumericUpDown.Value = parameters.TerrainDataDictionary[TerrainObject.Layer15].height;
            TerrainLayer15ColorTextBox.BackColor = parameters.ColorDictionary[parameters.TerrainDataDictionary[TerrainObject.Layer15].colorObject];
            if (parameters.TerrainDataDictionary[TerrainObject.Layer15].enabled == false)
            {
                TerrainLayer15AliasTextBox.Enabled = false;
                TerrainLayer15NumericUpDown.Enabled = false;
                TerrainLayer15Button.Enabled = false;
            }
            TerrainLayer16CheckBox.Checked = parameters.TerrainDataDictionary[TerrainObject.Layer16].enabled;
            TerrainLayer16AliasTextBox.Text = parameters.TerrainDataDictionary[TerrainObject.Layer16].alias;
            TerrainLayer16NumericUpDown.Value = parameters.TerrainDataDictionary[TerrainObject.Layer16].height;
            TerrainLayer16ColorTextBox.BackColor = parameters.ColorDictionary[parameters.TerrainDataDictionary[TerrainObject.Layer16].colorObject];
            if (parameters.TerrainDataDictionary[TerrainObject.Layer16].enabled == false)
            {
                TerrainLayer16AliasTextBox.Enabled = false;
                TerrainLayer16NumericUpDown.Enabled = false;
                TerrainLayer16Button.Enabled = false;
            }
            TerrainLayer17CheckBox.Checked = parameters.TerrainDataDictionary[TerrainObject.Layer17].enabled;
            TerrainLayer17AliasTextBox.Text = parameters.TerrainDataDictionary[TerrainObject.Layer17].alias;
            TerrainLayer17NumericUpDown.Value = parameters.TerrainDataDictionary[TerrainObject.Layer17].height;
            TerrainLayer17ColorTextBox.BackColor = parameters.ColorDictionary[parameters.TerrainDataDictionary[TerrainObject.Layer17].colorObject];
            if (parameters.TerrainDataDictionary[TerrainObject.Layer17].enabled == false)
            {
                TerrainLayer17AliasTextBox.Enabled = false;
                TerrainLayer17NumericUpDown.Enabled = false;
                TerrainLayer17Button.Enabled = false;
            }
            TerrainLayer18CheckBox.Checked = parameters.TerrainDataDictionary[TerrainObject.Layer18].enabled;
            TerrainLayer18AliasTextBox.Text = parameters.TerrainDataDictionary[TerrainObject.Layer18].alias;
            TerrainLayer18NumericUpDown.Value = parameters.TerrainDataDictionary[TerrainObject.Layer18].height;
            TerrainLayer18ColorTextBox.BackColor = parameters.ColorDictionary[parameters.TerrainDataDictionary[TerrainObject.Layer18].colorObject];
            if (parameters.TerrainDataDictionary[TerrainObject.Layer18].enabled == false)
            {
                TerrainLayer18AliasTextBox.Enabled = false;
                TerrainLayer18NumericUpDown.Enabled = false;
                TerrainLayer18Button.Enabled = false;
            }
            TerrainLayer19CheckBox.Checked = parameters.TerrainDataDictionary[TerrainObject.Layer19].enabled;
            TerrainLayer19AliasTextBox.Text = parameters.TerrainDataDictionary[TerrainObject.Layer19].alias;
            TerrainLayer19NumericUpDown.Value = parameters.TerrainDataDictionary[TerrainObject.Layer19].height;
            TerrainLayer19ColorTextBox.BackColor = parameters.ColorDictionary[parameters.TerrainDataDictionary[TerrainObject.Layer19].colorObject];
            if (parameters.TerrainDataDictionary[TerrainObject.Layer19].enabled == false)
            {
                TerrainLayer19AliasTextBox.Enabled = false;
                TerrainLayer19NumericUpDown.Enabled = false;
                TerrainLayer19Button.Enabled = false;
            }
            TerrainLayer20CheckBox.Checked = parameters.TerrainDataDictionary[TerrainObject.Layer20].enabled;
            TerrainLayer20AliasTextBox.Text = parameters.TerrainDataDictionary[TerrainObject.Layer20].alias;
            TerrainLayer20NumericUpDown.Value = parameters.TerrainDataDictionary[TerrainObject.Layer20].height;
            TerrainLayer20ColorTextBox.BackColor = parameters.ColorDictionary[parameters.TerrainDataDictionary[TerrainObject.Layer20].colorObject];
            if (parameters.TerrainDataDictionary[TerrainObject.Layer20].enabled == false)
            {
                TerrainLayer20AliasTextBox.Enabled = false;
                TerrainLayer20NumericUpDown.Enabled = false;
                TerrainLayer20Button.Enabled = false;
            }
            TerrainLayer21CheckBox.Checked = parameters.TerrainDataDictionary[TerrainObject.Layer21].enabled;
            TerrainLayer21AliasTextBox.Text = parameters.TerrainDataDictionary[TerrainObject.Layer21].alias;
            TerrainLayer21NumericUpDown.Value = parameters.TerrainDataDictionary[TerrainObject.Layer21].height;
            TerrainLayer21ColorTextBox.BackColor = parameters.ColorDictionary[parameters.TerrainDataDictionary[TerrainObject.Layer21].colorObject];
            if (parameters.TerrainDataDictionary[TerrainObject.Layer21].enabled == false)
            {
                TerrainLayer21AliasTextBox.Enabled = false;
                TerrainLayer21NumericUpDown.Enabled = false;
                TerrainLayer21Button.Enabled = false;
            }
            TerrainLayer22CheckBox.Checked = parameters.TerrainDataDictionary[TerrainObject.Layer22].enabled;
            TerrainLayer22AliasTextBox.Text = parameters.TerrainDataDictionary[TerrainObject.Layer22].alias;
            TerrainLayer22NumericUpDown.Value = parameters.TerrainDataDictionary[TerrainObject.Layer22].height;
            TerrainLayer22ColorTextBox.BackColor = parameters.ColorDictionary[parameters.TerrainDataDictionary[TerrainObject.Layer22].colorObject];
            if (parameters.TerrainDataDictionary[TerrainObject.Layer22].enabled == false)
            {
                TerrainLayer22AliasTextBox.Enabled = false;
                TerrainLayer22NumericUpDown.Enabled = false;
                TerrainLayer22Button.Enabled = false;
            }
            TerrainLayer23CheckBox.Checked = parameters.TerrainDataDictionary[TerrainObject.Layer23].enabled;
            TerrainLayer23AliasTextBox.Text = parameters.TerrainDataDictionary[TerrainObject.Layer23].alias;
            TerrainLayer23NumericUpDown.Value = parameters.TerrainDataDictionary[TerrainObject.Layer23].height;
            TerrainLayer23ColorTextBox.BackColor = parameters.ColorDictionary[parameters.TerrainDataDictionary[TerrainObject.Layer23].colorObject];
            if (parameters.TerrainDataDictionary[TerrainObject.Layer23].enabled == false)
            {
                TerrainLayer23AliasTextBox.Enabled = false;
                TerrainLayer23NumericUpDown.Enabled = false;
                TerrainLayer23Button.Enabled = false;
            }


            // Grid stuff
            GridSegmentSizeNumericUpDown.Value = parameters.GridSegmentSize;
            SegmentPaddingNumericUpDown.Value = parameters.SegmentPaddingX;
            ShowGridLinesCheckbox.Checked = parameters.ShowGridLines;
            ShowZoneOutlinesCheckbox.Checked = parameters.ShowZoneOutlines;
            ShowBuildingOutlinesCheckBox.Checked = parameters.ShowBuildingOutlines;
            BlendTerrainColorsCheckBox.Checked = parameters.BlendTerrainLayers;

            // Output stuff
            OutputPathTextbox.Text = parameters.OutputPath;
            if (parameters.OutputFormat == OutFormat.PNG)
            {
                PNGRadioButton.Checked = true;
                JPEGRadioButton.Checked = false;
            }
            else
            {
                PNGRadioButton.Checked = false;
                JPEGRadioButton.Checked = true;
            }

            // Setup visible layers tree
            VisibleObjectsTreeView.AfterCheck -= VisibleObjectsTreeView_AfterCheck;             // Remove callbacks 
            CheckAllNodes(VisibleObjectsTreeView.Nodes, false);                                 // Uncheck everything first
            PopulateLayersTreeView(VisibleObjectsTreeView.Nodes, parameters.VisibleMapObjects); // Fill up the tree
            VisibleObjectsTreeView.CollapseAll();                                               // Collapse everything 
            ShowUncheckedNodes(VisibleObjectsTreeView.Nodes);                                   // Make sure unchecked items are expanded
            VisibleObjectsTreeView.Nodes[0].EnsureVisible();                                    // Hacky but make sure that we are focusing on the top item
            VisibleObjectsTreeView.AfterCheck += VisibleObjectsTreeView_AfterCheck;             // Renable callbacks

            RegisterAppearanceEvents();
        }

        /// <summary>
        /// Creates a MapCreationParameter object from the current appearance UI values
        /// 
        /// The map appearance UI works by loading in a given MapCreationParameter object and it's values into the appearance
        /// UI controls, the user then modifies the ui controls, the ui controls are then turned into a MapCreationParameter object
        /// that is used to generate the map. This function is a key part of this and is used to convert from UI to a parameters object
        /// </summary>
        /// <returns></returns>
        private MapCreationParameters GetParametersFromAppearanceUIValues()
        {
            MapCreationParameters parameters = new MapCreationParameters();

            parameters.ColorDictionary[MapColorObject.Background] = GridBackgroundTextbox.BackColor;
            parameters.ColorDictionary[MapColorObject.GridLines] = GridLinesTextbox.BackColor;
            parameters.ColorDictionary[MapColorObject.PloppedBuilding] = PloppedBuildingsTextbox.BackColor;
            parameters.ColorDictionary[MapColorObject.ZoneOutline] = ZoneOutlinesTextbox.BackColor;
            parameters.ColorDictionary[MapColorObject.Military] = MilitaryTextbox.BackColor;
            parameters.ColorDictionary[MapColorObject.Airport] = AirportsTextbox.BackColor;
            parameters.ColorDictionary[MapColorObject.Seaport] = SeaportTextbox.BackColor;
            parameters.ColorDictionary[MapColorObject.Spaceport] = SpaceportTextbox.BackColor;
            parameters.ColorDictionary[MapColorObject.ResidentialLow] = ResidentialZoneLowTextbox.BackColor;
            parameters.ColorDictionary[MapColorObject.ResidentialMid] = ResidentialZoneMidTextbox.BackColor;
            parameters.ColorDictionary[MapColorObject.ResidentialHigh] = ResidentialZoneHighTextbox.BackColor;
            parameters.ColorDictionary[MapColorObject.CommercialLow] = CommercialZoneLowTextbox.BackColor;
            parameters.ColorDictionary[MapColorObject.CommercialMid] = CommercialZoneMidTextbox.BackColor;
            parameters.ColorDictionary[MapColorObject.CommercialHigh] = CommercialZoneHighTextbox.BackColor;
            parameters.ColorDictionary[MapColorObject.IndustrialLow] = IndustrialZoneLowTextbox.BackColor;
            parameters.ColorDictionary[MapColorObject.IndustrialMid] = IndustrialZoneMidTextbox.BackColor;
            parameters.ColorDictionary[MapColorObject.IndustrialHigh] = IndustrialZoneHighTextbox.BackColor;

            parameters.ColorDictionary[MapColorObject.Street] = StreetTextBox.BackColor;
            parameters.ColorDictionary[MapColorObject.Road] = RoadTextBox.BackColor;
            parameters.ColorDictionary[MapColorObject.OneWayRoad] = OneWayRoadTextBox.BackColor;
            parameters.ColorDictionary[MapColorObject.Avenue] = AvenueTextBox.BackColor;
            parameters.ColorDictionary[MapColorObject.Railway] = RailwayTextBox.BackColor;
            parameters.ColorDictionary[MapColorObject.Subway] = SubwayTextBox.BackColor;

            parameters.ColorDictionary[MapColorObject.Buildings] = BuildingsTextBox.BackColor;
            parameters.ColorDictionary[MapColorObject.BuildingsOutline] = BuildingsOutlineTextBox.BackColor;

            parameters.ColorDictionary[MapColorObject.TerrainLayer1] = TerrainLayer1ColorTextBox.BackColor;
            parameters.ColorDictionary[MapColorObject.TerrainLayer2] = TerrainLayer2ColorTextBox.BackColor;
            parameters.ColorDictionary[MapColorObject.TerrainLayer3] = TerrainLayer3ColorTextBox.BackColor;
            parameters.ColorDictionary[MapColorObject.TerrainLayer4] = TerrainLayer4ColorTextBox.BackColor;
            parameters.ColorDictionary[MapColorObject.TerrainLayer5] = TerrainLayer5ColorTextBox.BackColor;
            parameters.ColorDictionary[MapColorObject.TerrainLayer6] = TerrainLayer6ColorTextBox.BackColor;
            parameters.ColorDictionary[MapColorObject.TerrainLayer7] = TerrainLayer7ColorTextBox.BackColor;
            parameters.ColorDictionary[MapColorObject.TerrainLayer8] = TerrainLayer8ColorTextBox.BackColor;
            parameters.ColorDictionary[MapColorObject.TerrainLayer9] = TerrainLayer9ColorTextBox.BackColor;
            parameters.ColorDictionary[MapColorObject.TerrainLayer10] = TerrainLayer10ColorTextBox.BackColor;
            parameters.ColorDictionary[MapColorObject.TerrainLayer11] = TerrainLayer11ColorTextBox.BackColor;
            parameters.ColorDictionary[MapColorObject.TerrainLayer12] = TerrainLayer12ColorTextBox.BackColor;
            parameters.ColorDictionary[MapColorObject.TerrainLayer13] = TerrainLayer13ColorTextBox.BackColor;
            parameters.ColorDictionary[MapColorObject.TerrainLayer14] = TerrainLayer14ColorTextBox.BackColor;
            parameters.ColorDictionary[MapColorObject.TerrainLayer15] = TerrainLayer15ColorTextBox.BackColor;
            parameters.ColorDictionary[MapColorObject.TerrainLayer16] = TerrainLayer16ColorTextBox.BackColor;
            parameters.ColorDictionary[MapColorObject.TerrainLayer17] = TerrainLayer17ColorTextBox.BackColor;
            parameters.ColorDictionary[MapColorObject.TerrainLayer18] = TerrainLayer18ColorTextBox.BackColor;
            parameters.ColorDictionary[MapColorObject.TerrainLayer19] = TerrainLayer19ColorTextBox.BackColor;
            parameters.ColorDictionary[MapColorObject.TerrainLayer20] = TerrainLayer20ColorTextBox.BackColor;
            parameters.ColorDictionary[MapColorObject.TerrainLayer21] = TerrainLayer21ColorTextBox.BackColor;
            parameters.ColorDictionary[MapColorObject.TerrainLayer22] = TerrainLayer22ColorTextBox.BackColor;
            parameters.ColorDictionary[MapColorObject.TerrainLayer23] = TerrainLayer23ColorTextBox.BackColor;

            parameters.TerrainDataDictionary[TerrainObject.Layer1] = (TerrainLayer1CheckBox.Checked, TerrainLayer1AliasTextBox.Text, MapColorObject.TerrainLayer1, Convert.ToInt32(TerrainLayer1NumericUpDown.Value));
            parameters.TerrainDataDictionary[TerrainObject.Layer2] = (TerrainLayer2CheckBox.Checked, TerrainLayer2AliasTextBox.Text, MapColorObject.TerrainLayer2, Convert.ToInt32(TerrainLayer2NumericUpDown.Value));
            parameters.TerrainDataDictionary[TerrainObject.Layer3] = (TerrainLayer3CheckBox.Checked, TerrainLayer3AliasTextBox.Text, MapColorObject.TerrainLayer3, Convert.ToInt32(TerrainLayer3NumericUpDown.Value));
            parameters.TerrainDataDictionary[TerrainObject.Layer4] = (TerrainLayer4CheckBox.Checked, TerrainLayer4AliasTextBox.Text, MapColorObject.TerrainLayer4, Convert.ToInt32(TerrainLayer4NumericUpDown.Value));
            parameters.TerrainDataDictionary[TerrainObject.Layer5] = (TerrainLayer5CheckBox.Checked, TerrainLayer5AliasTextBox.Text, MapColorObject.TerrainLayer5, Convert.ToInt32(TerrainLayer5NumericUpDown.Value));
            parameters.TerrainDataDictionary[TerrainObject.Layer6] = (TerrainLayer6CheckBox.Checked, TerrainLayer6AliasTextBox.Text, MapColorObject.TerrainLayer6, Convert.ToInt32(TerrainLayer6NumericUpDown.Value));
            parameters.TerrainDataDictionary[TerrainObject.Layer7] = (TerrainLayer7CheckBox.Checked, TerrainLayer7AliasTextBox.Text, MapColorObject.TerrainLayer7, Convert.ToInt32(TerrainLayer7NumericUpDown.Value));
            parameters.TerrainDataDictionary[TerrainObject.Layer8] = (TerrainLayer8CheckBox.Checked, TerrainLayer8AliasTextBox.Text, MapColorObject.TerrainLayer8, Convert.ToInt32(TerrainLayer8NumericUpDown.Value));
            parameters.TerrainDataDictionary[TerrainObject.Layer9] = (TerrainLayer9CheckBox.Checked, TerrainLayer9AliasTextBox.Text, MapColorObject.TerrainLayer9, Convert.ToInt32(TerrainLayer9NumericUpDown.Value));
            parameters.TerrainDataDictionary[TerrainObject.Layer10] = (TerrainLayer10CheckBox.Checked, TerrainLayer10AliasTextBox.Text, MapColorObject.TerrainLayer10, Convert.ToInt32(TerrainLayer10NumericUpDown.Value));
            parameters.TerrainDataDictionary[TerrainObject.Layer11] = (TerrainLayer11CheckBox.Checked, TerrainLayer11AliasTextBox.Text, MapColorObject.TerrainLayer11, Convert.ToInt32(TerrainLayer11NumericUpDown.Value));
            parameters.TerrainDataDictionary[TerrainObject.Layer12] = (TerrainLayer12CheckBox.Checked, TerrainLayer12AliasTextBox.Text, MapColorObject.TerrainLayer12, Convert.ToInt32(TerrainLayer12NumericUpDown.Value));
            parameters.TerrainDataDictionary[TerrainObject.Layer13] = (TerrainLayer13CheckBox.Checked, TerrainLayer13AliasTextBox.Text, MapColorObject.TerrainLayer13, Convert.ToInt32(TerrainLayer13NumericUpDown.Value));
            parameters.TerrainDataDictionary[TerrainObject.Layer14] = (TerrainLayer14CheckBox.Checked, TerrainLayer14AliasTextBox.Text, MapColorObject.TerrainLayer14, Convert.ToInt32(TerrainLayer14NumericUpDown.Value));
            parameters.TerrainDataDictionary[TerrainObject.Layer15] = (TerrainLayer15CheckBox.Checked, TerrainLayer15AliasTextBox.Text, MapColorObject.TerrainLayer15, Convert.ToInt32(TerrainLayer15NumericUpDown.Value));
            parameters.TerrainDataDictionary[TerrainObject.Layer16] = (TerrainLayer16CheckBox.Checked, TerrainLayer16AliasTextBox.Text, MapColorObject.TerrainLayer16, Convert.ToInt32(TerrainLayer16NumericUpDown.Value));
            parameters.TerrainDataDictionary[TerrainObject.Layer17] = (TerrainLayer17CheckBox.Checked, TerrainLayer17AliasTextBox.Text, MapColorObject.TerrainLayer17, Convert.ToInt32(TerrainLayer17NumericUpDown.Value));
            parameters.TerrainDataDictionary[TerrainObject.Layer18] = (TerrainLayer18CheckBox.Checked, TerrainLayer18AliasTextBox.Text, MapColorObject.TerrainLayer18, Convert.ToInt32(TerrainLayer18NumericUpDown.Value));
            parameters.TerrainDataDictionary[TerrainObject.Layer19] = (TerrainLayer19CheckBox.Checked, TerrainLayer19AliasTextBox.Text, MapColorObject.TerrainLayer19, Convert.ToInt32(TerrainLayer19NumericUpDown.Value));
            parameters.TerrainDataDictionary[TerrainObject.Layer20] = (TerrainLayer20CheckBox.Checked, TerrainLayer20AliasTextBox.Text, MapColorObject.TerrainLayer20, Convert.ToInt32(TerrainLayer20NumericUpDown.Value));
            parameters.TerrainDataDictionary[TerrainObject.Layer21] = (TerrainLayer21CheckBox.Checked, TerrainLayer21AliasTextBox.Text, MapColorObject.TerrainLayer21, Convert.ToInt32(TerrainLayer21NumericUpDown.Value));
            parameters.TerrainDataDictionary[TerrainObject.Layer22] = (TerrainLayer22CheckBox.Checked, TerrainLayer22AliasTextBox.Text, MapColorObject.TerrainLayer22, Convert.ToInt32(TerrainLayer22NumericUpDown.Value));
            parameters.TerrainDataDictionary[TerrainObject.Layer23] = (TerrainLayer23CheckBox.Checked, TerrainLayer23AliasTextBox.Text, MapColorObject.TerrainLayer23, Convert.ToInt32(TerrainLayer23NumericUpDown.Value));

            parameters.GridSegmentSize = (int)GridSegmentSizeNumericUpDown.Value;
            parameters.SegmentPaddingX = (int)SegmentPaddingNumericUpDown.Value;
            parameters.SegmentPaddingY = (int)SegmentPaddingNumericUpDown.Value;
            parameters.ShowGridLines = ShowGridLinesCheckbox.Checked;
            parameters.ShowBuildingOutlines = ShowBuildingOutlinesCheckBox.Checked;
            parameters.ShowZoneOutlines = ShowZoneOutlinesCheckbox.Checked;
            parameters.BlendTerrainLayers = BlendTerrainColorsCheckBox.Checked;

            parameters.OutputPath = OutputPathTextbox.Text;
            if (PNGRadioButton.Checked)
            {
                parameters.OutputFormat = OutFormat.PNG;
            }
            else
            {
                parameters.OutputFormat = OutFormat.JPEG;
            }

            parameters.VisibleMapObjects = ParseLayersTreeView(VisibleObjectsTreeView.Nodes);

            return parameters;
        }

        /// <summary>
        /// Toggle visiblity of appearance controls, used for hidding appearance UI for performance
        /// </summary>
        /// <param name="show"></param>
        private void ShowAppearanceTabUI(bool show)
        {
            VisibleObjectsTreeView.Visible = show;
            ColorsTabControl.Visible = show;
            GridSegmentSizeLabel.Visible = show;
            SegmentPaddingLabel.Visible = show;
            OutputFormatLabel.Visible = show;
            OutputPathLabel.Visible = show;
            SizeLabel.Visible = show;
            SizesComboBox.Visible = show;
            PixelLabel1.Visible = show;
            PixelLabel2.Visible = show;
            GridSegmentSizeNumericUpDown.Visible = show;
            SegmentPaddingNumericUpDown.Visible = show;
            ShowGridLinesCheckbox.Visible = show;
            ShowZoneOutlinesCheckbox.Visible = show;
            BlendTerrainColorsCheckBox.Visible = show;
            PNGRadioButton.Visible = show;
            JPEGRadioButton.Visible = show;
            OutputPathTextbox.Visible = show;
            EditOutputPathButton.Visible = show;
        }

        #region Appearance Visible layers TreeView functionality

        /// <summary>
        /// Populate visible layers tree view with objects from MapCreationParameters
        /// </summary>
        /// <param name="nodes"></param>
        /// <param name="objects"></param>
        public void PopulateLayersTreeView(TreeNodeCollection nodes, List<MapObject> objects)
        {
            foreach (TreeNode node in nodes)
            {
                if (node.Nodes.Count != 0)
                {
                    PopulateLayersTreeView(node.Nodes, objects);
                }
                else
                {
                    switch (node.Tag)
                    {
                        case "ResidentialLowZone":
                            if (objects.Contains(MapObject.ResidentialLowZone))
                            {
                                node.Checked = true;
                                CheckAllParents(node.Parent, true);
                            }
                            break;
                        case "ResidentialMidZone":
                            if (objects.Contains(MapObject.ResidentialMidZone))
                            {
                                node.Checked = true;
                                CheckAllParents(node.Parent, true);
                            }
                            break;
                        case "ResidentialHighZone":
                            if (objects.Contains(MapObject.ResidentialHighZone))
                            {
                                node.Checked = true;
                                CheckAllParents(node.Parent, true);
                            }
                            break;
                        case "CommercialLowZone":
                            if (objects.Contains(MapObject.CommercialLowZone))
                            {
                                node.Checked = true;
                                CheckAllParents(node.Parent, true);
                            }
                            break;
                        case "CommercialMidZone":
                            if (objects.Contains(MapObject.CommercialMidZone))
                            {
                                node.Checked = true;
                                CheckAllParents(node.Parent, true);
                            }
                            break;
                        case "CommercialHighZone":
                            if (objects.Contains(MapObject.CommercialHighZone))
                            {
                                node.Checked = true;
                                CheckAllParents(node.Parent, true);
                            }
                            break;
                        case "IndustrialHighZone":
                            if (objects.Contains(MapObject.IndustrialHighZone))
                            {
                                node.Checked = true;
                                CheckAllParents(node.Parent, true);
                            }
                            break;
                        case "IndustrialMidZone":
                            if (objects.Contains(MapObject.IndustrialMidZone))
                            {
                                node.Checked = true;
                                CheckAllParents(node.Parent, true);
                            }
                            break;
                        case "IndustrialLowZone":
                            if (objects.Contains(MapObject.IndustrialLowZone))
                            {
                                node.Checked = true;
                                CheckAllParents(node.Parent, true);
                            }
                            break;
                        case "PloppedBuildingZone":
                            if (objects.Contains(MapObject.PloppedBuildingZone))
                            {
                                node.Checked = true;
                                CheckAllParents(node.Parent, true);
                            }
                            break;
                        case "MilitaryZone":
                            if (objects.Contains(MapObject.MilitaryZone))
                            {
                                node.Checked = true;
                                CheckAllParents(node.Parent, true);
                            }
                            break;
                        case "AirportZone":
                            if (objects.Contains(MapObject.AirportZone))
                            {
                                node.Checked = true;
                                CheckAllParents(node.Parent, true);
                            }
                            break;
                        case "SeaportZone":
                            if (objects.Contains(MapObject.SeaportZone))
                            {
                                node.Checked = true;
                                CheckAllParents(node.Parent, true);
                            }
                            break;
                        case "SpaceportZone":
                            if (objects.Contains(MapObject.SpaceportZone))
                            {
                                node.Checked = true;
                                CheckAllParents(node.Parent, true);
                            }
                            break;
                        case "Streets":
                            if (objects.Contains(MapObject.StreetNetwork1))
                            {
                                node.Checked = true;
                                CheckAllParents(node.Parent, true);
                            }
                            break;
                        case "Roads":
                            if (objects.Contains(MapObject.RoadNetwork1))
                            {
                                node.Checked = true;
                                CheckAllParents(node.Parent, true);
                            }
                            break;
                        case "OneWayRoads":
                            if (objects.Contains(MapObject.OneWayRoadNetwork1))
                            {
                                node.Checked = true;
                                CheckAllParents(node.Parent, true);
                            }
                            break;
                        case "Avenues":
                            if (objects.Contains(MapObject.AvenueNetwork1))
                            {
                                node.Checked = true;
                                CheckAllParents(node.Parent, true);
                            }
                            break;
                        case "Railways":
                            if (objects.Contains(MapObject.RailwayNetwork1))
                            {
                                node.Checked = true;
                                CheckAllParents(node.Parent, true);
                            }
                            break;
                        case "Subways":
                            if (objects.Contains(MapObject.SubwayNetwork2))
                            {
                                node.Checked = true;
                                CheckAllParents(node.Parent, true);
                            }
                            break;
                        case "TerrainMap":
                            if (objects.Contains(MapObject.TerrainMap))
                            {
                                node.Checked = true;
                            }
                            break;
                        case "Buildings":
                            if (objects.Contains(MapObject.Building))
                            {
                                node.Checked = true;
                            }
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// Parse a visible layers tree view and extract any checked visible objects
        /// </summary>
        /// <param name="nodes"></param>
        /// <returns></returns>
        public List<MapObject> ParseLayersTreeView(TreeNodeCollection nodes)
        {
            List<MapObject> objects = new List<MapObject>();

            foreach (TreeNode node in nodes)
            {
                if (node.Nodes.Count != 0)
                {
                    objects.AddRange(ParseLayersTreeView(node.Nodes));
                }
                else
                {
                    if (node.Checked)
                    {
                        switch (node.Tag)
                        {
                            case "ResidentialLowZone":
                                objects.Add(MapObject.ResidentialLowZone);
                                break;
                            case "ResidentialMidZone":
                                objects.Add(MapObject.ResidentialMidZone);
                                break;
                            case "ResidentialHighZone":
                                objects.Add(MapObject.ResidentialHighZone);
                                break;
                            case "CommercialLowZone":
                                objects.Add(MapObject.CommercialLowZone);
                                break;
                            case "CommercialMidZone":
                                objects.Add(MapObject.CommercialMidZone);
                                break;
                            case "CommercialHighZone":
                                objects.Add(MapObject.CommercialHighZone);
                                break;
                            case "IndustrialHighZone":
                                objects.Add(MapObject.IndustrialHighZone);
                                break;
                            case "IndustrialMidZone":
                                objects.Add(MapObject.IndustrialMidZone);
                                break;
                            case "IndustrialLowZone":
                                objects.Add(MapObject.IndustrialLowZone);
                                break;
                            case "PloppedBuildingZone":
                                objects.Add(MapObject.PloppedBuildingZone);
                                break;
                            case "MilitaryZone":
                                objects.Add(MapObject.MilitaryZone);
                                break;
                            case "AirportZone":
                                objects.Add(MapObject.AirportZone);
                                break;
                            case "SeaportZone":
                                objects.Add(MapObject.SeaportZone);
                                break;
                            case "SpaceportZone":
                                objects.Add(MapObject.SpaceportZone);
                                break;
                            case "TerrainMap":
                                objects.Add(MapObject.TerrainMap);
                                break;
                            case "Streets":
                                objects.Add(MapObject.StreetNetwork1);
                                break;
                            case "Roads":
                                objects.Add(MapObject.RoadNetwork1);
                                break;
                            case "OneWayRoads":
                                objects.Add(MapObject.OneWayRoadNetwork1);
                                break;
                            case "Avenues":
                                objects.Add(MapObject.AvenueNetwork1);
                                break;
                            case "Railways":
                                objects.Add(MapObject.RailwayNetwork1);
                                break;
                            case "Subways":
                                objects.Add(MapObject.SubwayNetwork2);
                                break;
                            case "Buildings":
                                objects.Add(MapObject.Building);
                                break;
                        }
                    }
                }
            }

            return objects;
        }

        /// <summary>
        /// Parses recursively through a treenode collection and makes sure that any node that
        /// is unchecked is expanded
        /// </summary>
        /// <param name="nodes"></param>
        public void ShowUncheckedNodes(TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                if (node.Nodes.Count != 0)
                {
                    ShowUncheckedNodes(node.Nodes);
                }
                else
                {
                    if (node.Checked == false)
                        node.EnsureVisible();
                }   
            }
        }

        /// <summary>
        /// Checks a tree node's parent
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="check"></param>
        private void CheckParent(TreeNode parent, bool check)
        {
            if (parent == null)
                return;

            parent.Checked = check;
        }

        /// <summary>
        /// Check all nodes in a tree view
        /// </summary>
        /// <param name="nodes"></param>
        /// <param name="check"></param>
        private void CheckAllNodes(TreeNodeCollection nodes, bool check)
        {
            foreach (TreeNode node in nodes)
            {
                node.Checked = check;

                if (node.Nodes.Count != 0)
                {
                    CheckAllNodes(node.Nodes, check);
                }
            }
        }

        /// <summary>
        /// Check all parent nodes of a node
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="check"></param>
        private void CheckAllParents(TreeNode parent, bool check)
        {
            parent.Checked = check;

            if (parent.Parent != null)
            {
                CheckAllParents(parent.Parent, check);
            }
        }

        /// <summary>
        /// Checks if sibling nodes are checked
        /// </summary>
        /// <param name="nodes"></param>
        /// <returns></returns>
        private bool AreSiblingsChecked(TreeNodeCollection nodes)
        {
            bool isChecked = false;

            foreach (TreeNode node in nodes)
            {
                if (node.Checked)
                {
                    isChecked = true;
                }
            }

            return isChecked;
        }

        #endregion

        #endregion

        #region Map zoom and center functionality

        /// <summary>
        /// Applies zoom to map bitmap, used zoomFactor variable to set zoom
        /// </summary>
        /// <param name="center"></param>
        private void ZoomImage(bool center)
        {
            if (zoomFactor == 1)
            {
                zoomedMapBitmap?.Dispose(); // Delete old zoomed in image
                CenterPictureBox(MapPictureBox, mapBitmap);
                return;
            }

            Size newSize = new Size();
            if (zoomFactor < 0)
            {
                newSize = new Size((int)(mapBitmap.Width / Math.Abs(zoomFactor)), (int)(mapBitmap.Height / Math.Abs(zoomFactor)));
            }
            else
            {
                newSize = new Size((int)(mapBitmap.Width * zoomFactor), (int)(mapBitmap.Height * zoomFactor));
            }


            // Don't zoom in on anything that is already ridiculously big
            if (newSize.Width > MAX_ZOOM_SIZE)
            {
                // Recursively reset zoom until we reach a more 'restrained' zoom size
                zoomFactor--;
                ZoomTrackBar.Value--;
                ZoomImage(center);
                return;
            }

            // add nice lil wait cursor
            this.Cursor = Cursors.WaitCursor;

            zoomedMapBitmap?.Dispose(); // Delete old zoomed in image
            zoomedMapBitmap = new Bitmap(mapBitmap, newSize);

            if (center)
            {
                CenterPictureBox(MapPictureBox, zoomedMapBitmap);
            }
            else
            {
                MapPictureBox.Image = zoomedMapBitmap;
            }

            // reset cursor
            this.Cursor = Cursors.Default;

            //GC.Collect();
            //GC.WaitForPendingFinalizers();
        }

        /// <summary>
        /// Center bitmap inside picture box (amazing)
        /// Source: https://stackoverflow.com/a/9383029
        /// </summary>
        /// <param name="picBox"></param>
        /// <param name="picImage"></param>
        private void CenterPictureBox(PictureBox picBox, Bitmap picImage)
        {
            // Set image
            MapPictureBox.Image = picImage;

            // Center scroll bars
            panel1.AutoScrollPosition =
                new Point
                {
                    X = (MapPictureBox.Width - panel1.Width) / 2,
                    Y = (MapPictureBox.Height - panel1.Height) / 2
                };

            // Center image in picturebox
            picBox.Location = new Point((picBox.Parent.ClientSize.Width / 2) - (picImage.Width / 2),
                                        (picBox.Parent.ClientSize.Height / 2) - (picImage.Height / 2));
            picBox.Refresh();
        }

        #endregion

        #region Status Strip Functionality

        /// <summary>
        /// Gets information for a specific pixel on the map. Returned as a string
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private string result = "";
        private int cityTileX = 0;
        private int cityTileY = 0;
        private double cityCoordX = 0;
        private double cityCoordY = 0;
        private string GetMapPixelInfo(int x, int y)
        {
            // If we are zoomed in (or out) don't both getting map pixel info
            // it will be wrong and be time consuming;
            if (zoomFactor != 1)
                return "";

            // Don't try and fetch any details if nothing is loaded
            if (mapLoaded == false)
                return "";

            // Work out coordinates on map
            cityTileX = x / map.Parameters.GridSegmentSize;
            cityTileY = y / map.Parameters.GridSegmentSize;
            cityCoordX = x / (map.Parameters.GridSegmentSize / 16d);
            cityCoordY = y / (map.Parameters.GridSegmentSize / 16d);

            result = $"Mouse: {x}, {y}px (tile: {cityTileX}x, {cityTileY}z) (coord: {cityCoordX}x{cityCoordY})";

            if (terrainData != null)
            {
                try
                {
                    result += $" (height: {terrainData[cityTileY][cityTileX]})";
                }
                catch (IndexOutOfRangeException) { } // Silently continue when we accidently get a range outside of the terrain map bounds 
            }

            if (zoneData != null)
            {
                // See if there is any zone data on that segment
                foreach (Lot lot in zoneData)
                {
                    for (int lotZ = lot.MinTileZ; lotZ <= lot.MaxTileZ; lotZ++)
                    {
                        if (lotZ == cityTileY)
                        {
                            for (int lotX = lot.MinTileX; lotX <= lot.MaxTileX; lotX++)
                            {
                                if (lotX == cityTileX)
                                {
                                    result += $" (zone: {SC4Parser.Constants.LOT_ZONE_TYPE_STRINGS[lot.ZoneType]} [{SC4Parser.Constants.LOT_ZONE_WEALTH_STRINGS[lot.ZoneWealth]}])";
                                }
                            }
                        }
                    }
                }
            }

            return result;
        }

        #endregion

        #endregion

        #region UI Events

        #region MainForm Events

        /// <summary>
        /// When main form loads
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            // Load a random map on open
            //logger = new RichTextBoxLogger(LogTextBox);
            if (Directory.Exists(rootSimCitySavePath) && mapLoaded != true)
            {
                bool validSaveFound = false;
                string path = "";

                // Find a save that will load without errors (probably doesn't have a lot subfile :/)
                while (validSaveFound == false)
                {
                    SavePathTextbox.Text = rootSimCitySavePath;
                    path = FindRandomSavegameFileInPath(rootSimCitySavePath);
                    if (CheckSaveContainsLotSubfile(path))
                    {
                        validSaveFound = true;
                    }
                }

                // Found a good save, load it
                LoadSaveGame(path);
            }
            else
            {
                SavePathTextbox.Text = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            }

            // Set current path as output path
            map.Parameters.OutputPath = Directory.GetCurrentDirectory();


            // Check for update on startup
            if (Properties.Settings.Default.IgnoreUpdatePrompts == false)
            {
                UpdateChecker.GetLatestReleaseInfoAsync(OnUpdateChecked);
            }
        }

        /// <summary>
        /// MainForm resize event, whenever the main form is resized we recenter the map so it is in the center of
        /// the picture box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Resize(object sender, EventArgs e)
        {
            // Don't mess with picture box if nothing is loaded
            if (mapLoaded == false)
                return;

            // Work out if we should be showing the zoomed or normal bitmap
            if (zoomFactor != 1)
            {
                CenterPictureBox(MapPictureBox, zoomedMapBitmap);
            }
            else
            {
                CenterPictureBox(MapPictureBox, mapBitmap);
            }
        }

        /// <summary>
        /// Resize begin event, we use this to hide the appearance tab when the form is being moved
        /// or resize. We do this for performance reasons
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_ResizeBegin(object sender, EventArgs e)
        {
            ShowAppearanceTabUI(false);
        }

        /// <summary>
        /// Resize end event, we use this to show the appearance tab again once the window is done being moved.
        /// Again, we hide it in the first place for performance reasons
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_ResizeEnd(object sender, EventArgs e)
        {
            ShowAppearanceTabUI(true);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            mapApperanceSerializer.TrySaveToUserTempFolder(map.Parameters);
        }

        #endregion

        #region Menu Strip Events

        /// <summary>
        /// Save map menu strip button (saves map with default name)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string name = GenerateDefaultMapFilename();
            SaveMap(map.Parameters.OutputPath, name);
        }

        /// <summary>
        /// Map Save as menu strip button (save file with dialog)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog fileDialog = new SaveFileDialog())
            {
                fileDialog.Title = "Save SimCity 4 map";
                fileDialog.InitialDirectory = Directory.GetCurrentDirectory();
                fileDialog.RestoreDirectory = true;
                //fileDialog.CheckFileExists = true;
                fileDialog.CheckPathExists = true;
                //fileDialog.Filter = "Simcity 4 save files (*.sc4)|*.sc4";
                if (fileDialog.ShowDialog(this) == DialogResult.OK)
                {
                    SaveMap(Path.GetDirectoryName(fileDialog.FileName), Path.GetFileNameWithoutExtension(fileDialog.FileName));
                }
            }
        }

        /// <summary>
        /// Exit menu strip item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        /// <summary>
        /// Load save game menu strip item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void savegameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog fileDialog = new OpenFileDialog())
            {
                fileDialog.Title = "Load SimCity 4 Save Game";
                fileDialog.InitialDirectory = SavePathTextbox.Text;
                fileDialog.RestoreDirectory = true;
                fileDialog.CheckFileExists = true;
                fileDialog.CheckPathExists = true;
                fileDialog.Filter = "Simcity 4 save file (*.sc4)|*.sc4";
                if (fileDialog.ShowDialog(this) == DialogResult.OK)
                    LoadSaveGame(fileDialog.FileName);
            }
        }

        /// <summary>
        /// Open folder menu strip item (opens folder in save game section)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void folderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Create folder browser dialog
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.SelectedPath = SavePathTextbox.Text;
                if (folderDialog.ShowDialog(this) == DialogResult.OK)
                    SavePathTextbox.Text = folderDialog.SelectedPath;
            }
        }

        /// <summary>
        /// Menu item that allows you to report a bug on github
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void reportABugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Version v = Assembly.GetExecutingAssembly().GetName().Version;
            string version = Assembly.GetExecutingAssembly().GetName().Name + " v" + v.Major + "." + v.Minor + "." + v.Build + " (r" + v.Revision + ") ";
            version = version.Replace(' ', '+');
            string parserVersion = "SC4Parser+" + SC4PARSER_VERSION;

            string issueLink = @"https://github.com/killeroo/SC4Cartographer/issues/new?body=%0A%0A%0A---------%0A" + version + "%0A" + parserVersion;
            System.Diagnostics.Process.Start(issueLink);
        }

        /// <summary>
        /// About menu item, opens about form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var mapCreatedForm = new AboutBox();
            mapCreatedForm.StartPosition = FormStartPosition.CenterParent;
            mapCreatedForm.ShowDialog();
        }

        /// <summary>
        /// Project webpage item, opens project page in browser
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void projectWebpageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"https://github.com/killeroo/SC4Cartographer");
        }

        /// <summary>
        /// Show log item, opens log form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            var mapCreatedForm = new LogForm(fileLogger.LogPath, fileLogger.Created);
            mapCreatedForm.StartPosition = FormStartPosition.CenterParent;
            mapCreatedForm.ShowDialog();
        }

        /// <summary>
        /// Update item, opens up dialog to check if an update is available
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateInfo info = null;

            try
            {
                // Try and fetch latest release info from github
                info = UpdateChecker.GetLatestReleaseInfo();
            }
            catch (Exception ex)
            {
                var errorForm = new ErrorForm(
                    "Error fetching SC4Cartographer update info",
                    $"Could not get current release information from github.",
                    ex,
                    false);
                errorForm.StartPosition = FormStartPosition.CenterParent;
                errorForm.ShowDialog();

                return;
            }

            if (info.NewVersionAvailable)
            {
                var updateFormat = new UpdateForm(info);
                updateFormat.ShowDialog();
            }
            else
            {

                var successForm = new SuccessForm(
                    "Up to date!",
                    "You are using the most recent version of SC4Cartographer.",
                    "");

                successForm.StartPosition = FormStartPosition.CenterParent;
                successForm.ShowDialog();
            }
        }

        /// <summary>
        /// Save map parameters menu strip item for saving current map parameters to a file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            mapApperanceSaveLoadDialogs.SaveMapParametersWithDialog(map.Parameters);
        }

        /// <summary>
        /// Load map properties menu strip item, opens dialog to load map parameters from a file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Load new parameters and regenerate preview
            if(mapApperanceSaveLoadDialogs.TryLoadMapParametersWithDialog(out MapCreationParameters parameters))
            { 
                SetAppearanceUIValuesUsingParameters(parameters);
                
                // Change cursor to indicate that we are working on the preview
                Cursor = Cursors.WaitCursor;

                // Only update preview if a map is loaded 
                if (mapLoaded)
                    GenerateMapPreviewBitmaps(false);

                // Reset cursor 
                Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Restore menu strip item to restore map appearances to defaults
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void restoreDefaultsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MapCreationParameters pristineParameters = new MapCreationParameters();

            // Copy over the output path
            pristineParameters.OutputPath = map.Parameters.OutputPath;

            SetAppearanceUIValuesUsingParameters(pristineParameters);
            SetAndUpdateMapCreationParameters(pristineParameters);
        }


        #endregion

        #region Save Button Event

        /// <summary>
        /// Event for save button click, creates a default name and saves the map to the inputted output path
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveButton_Click(object sender, EventArgs e)
        {
            string name = GenerateDefaultMapFilename();
            SaveMap(map.Parameters.OutputPath, name);
        }

        #endregion

        #region Zoom Controls Events

        /// <summary>
        /// Initiates zoom when mouse click is release while on zoom track bar
        /// We do this on mouse up for performance, instead of everytime a value on bar changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ZoomTrackBar_MouseUp(object sender, MouseEventArgs e)
        {
            //zoomFactor = ZoomTrackBar.Value;
            if (ZoomTrackBar.Value < 0)
            {
                zoomFactor = ZoomTrackBar.Value - 1;
            }
            else if (ZoomTrackBar.Value >= 0)
            {
                zoomFactor = ZoomTrackBar.Value + 1;
            }

            ZoomImage(true);
        }

        /// <summary>
        /// Resets current zoom
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ResetZoomButton_Click(object sender, EventArgs e)
        {
            if (zoomFactor != 1)
            {
                zoomFactor = 1;
                ZoomTrackBar.Value = 0;
                ZoomImage(true);
            }
        }

        #endregion

        #region MapPictureBox Events

        /// <summary>
        /// Mouse move event for picture box, used to populate info on bottom tool strip and move the map when holding left
        /// mouse button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        int mouseX = 0;
        int mouseY = 0;
        private void MapPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            mouseX = e.X;
            mouseY = e.Y;
            // Don't show any map info while drag moving the map
            if (!draggingMap)
            {
                MousePositionToolStripStatusLabel.Text = GetMapPixelInfo(e.X, e.Y);
            }

            // Skip everyother picture box reposition, done for performance reasons
            // the map bleeds weirdly when moved on every tick, especially around the edges
            // this produces some slight gittering but is better in my mind than tearing and other
            // weirdness
            skipTick = !skipTick;

            if (!draggingMap || sender == null || skipTick)
            {
                return;
            }

            var pictureBox = sender as PictureBox;

            // Move the picture box coordinates relative to where the picture was first dragged from
            pictureBox.Top = e.Y + pictureBox.Top - picturePosY;
            pictureBox.Left = e.X + pictureBox.Left - picturePosX;
        }

        /// <summary>
        /// Mouse leave event used to reset string on bottom tool strip bar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MapPictureBox_MouseLeave(object sender, EventArgs e)
        {
            MousePositionToolStripStatusLabel.Text = "";
        }

        /// <summary>
        /// Mouse click event, used when mouse starting to dragging map.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MapPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            // Only drag move picture when pressing left click
            if (e.Button != MouseButtons.Left) return;
            draggingMap = true;

            // Store the position we originally clicked on
            // we will use this to move the image relative to this point
            picturePosX = e.X;
            picturePosY = e.Y;
        }

        /// <summary>
        /// Use when mouse is released on the map. To stop moving map.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MapPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (sender == null) return;
            var pictureBox = sender as PictureBox;

            // Stop moving picture
            draggingMap = false;
        }

        /// <summary>
        /// Trying to implement control scroll to zoom in, works but doesn't feel natural because it should
        /// zoom in on the part of the map that the mouse is hovering over but I cba
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Panel1_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            //if (ModifierKeys.HasFlag(Keys.Control))
            //{
            //    if (e.Delta > 0)
            //    {
            //        // Scroll up

            //        // Shitty hack to get around the fact that we can't have 0 as a zoomfactor
            //        if (zoomFactor == -1)
            //            zoomFactor = 1;
            //        else
            //            zoomFactor++;
            //    }
            //    else
            //    {
            //        // Scroll down
            //        if (zoomFactor == 1)
            //            zoomFactor = -1;
            //        else
            //            zoomFactor--;
            //    }

            //    if (zoomFactor > 4)
            //    {
            //        zoomFactor = 4;
            //    }
            //    else if (zoomFactor < -4)
            //    {
            //        zoomFactor = -4;
            //    }

            //    ZoomTrackBar.Value = zoomFactor;

            //    ZoomImage(false);
            //}
            //else
            //{
            ((HandledMouseEventArgs)e).Handled = true;
            //}
        }

        #endregion

        #region Save Games Control Events

        /// <summary>
        /// Populates FileTreeView when SavegamePathTextbox's text changes
        /// </summary>
        private void SavePathTextbox_TextChanged(object sender, EventArgs e)
        {
            // Clear the tree
            FileTreeView.Nodes.Clear();

            // If entered directory doesnt exist, dont bother rendering tree
            if (!Directory.Exists(SavePathTextbox.Text))
                return;

            // Get folders and files
            string[] dirs = Directory.GetDirectories(SavePathTextbox.Text);
            string[] files = Directory.GetFiles(SavePathTextbox.Text);

            foreach (string dir in dirs)
            {
                DirectoryInfo di = new DirectoryInfo(dir);
                TreeNode node = new TreeNode(di.Name, 0, 1);

                try
                {
                    node.Tag = dir;  //keep the directory's full path in the tag for use later

                    //if the directory has any sub directories add the place holder
                    if (di.GetFiles().Count() > 0 || di.GetDirectories().Count() > 0)//GetDirectories().Count() > 0) di.GetDirectories().Count() > 0)
                        node.Nodes.Add(null, "...", 0, 0);
                }
                catch (UnauthorizedAccessException)
                {
                    //if an unauthorized access exception occured display a locked folder
                    node.ImageIndex = 12;
                    node.SelectedImageIndex = 12;
                }
                catch (Exception ex)
                {
                    ErrorForm form = new ErrorForm(
                        "Directory tree error",
                        "An error occured while trying to populate save game file tree.",
                        ex,
                        false);

                    form.StartPosition = FormStartPosition.CenterParent;
                    form.ShowDialog();
                }
                finally
                {
                    FileTreeView.Nodes.Add(node);
                }
            }

            foreach (string file in files)
            {
                // Creat new node with file name
                TreeNode node = new TreeNode(Path.GetFileName(file), 0, 1);

                // Display file image on node
                node.ImageIndex = 13;
                node.SelectedImageIndex = 13;
                node.Tag = file;

                // Only show files with sc4 extension and don't show cities that haven't been
                // founded yet
                if (file.Contains(".sc4"))
                //&& !file.Contains("City - New City ("))
                {
                    if (FilterNewCitiesCheckbox.Checked
                        && file.Contains("City - New City"))
                    {
                        continue;
                    }

                    // Add to node
                    FileTreeView.Nodes.Add(node);
                }
            }
        }

        /// <summary>
        /// Generates a list of files and folders and adds them to the FileTreeView as nodes are expanded
        /// </summary>
        private void FileTreeView_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Nodes.Count > 0)
            {
                if (e.Node.Nodes[0].Text == "..." && e.Node.Nodes[0].Tag == null)
                {
                    e.Node.Nodes.Clear();

                    // get the list of sub directories & files
                    string[] dirs = Directory.GetDirectories(e.Node.Tag.ToString());
                    string[] files = Directory.GetFiles(e.Node.Tag.ToString());

                    foreach (string dir in dirs)
                    {
                        DirectoryInfo di = new DirectoryInfo(dir);
                        TreeNode node = new TreeNode(di.Name, 0, 1);

                        try
                        {
                            //keep the directory's full path in the tag for use later
                            node.Tag = dir;

                            //if the directory has any sub directories add the place holder
                            if (di.GetFiles().Count() > 0 || di.GetDirectories().Count() > 0)//GetDirectories().Count() > 0)
                                node.Nodes.Add(null, "...", 0, 0);
                        }
                        catch (UnauthorizedAccessException)
                        {
                            //if an unauthorized access exception occured display a locked folder
                            node.ImageIndex = 12;
                            node.SelectedImageIndex = 12;
                        }
                        catch (Exception ex)
                        {
                            ErrorForm form = new ErrorForm(
                                "Directory tree error",
                                "An error occured while trying to populate save game file tree.",
                                ex,
                                false);

                            form.StartPosition = FormStartPosition.CenterParent;
                            form.ShowDialog();
                        }
                        finally
                        {
                            e.Node.Nodes.Add(node);
                        }
                    }

                    foreach (string file in files)
                    {
                        // Creat new node with file name
                        TreeNode node = new TreeNode(Path.GetFileName(file), 0, 1);

                        // Display file image on node
                        node.ImageIndex = 13;
                        node.SelectedImageIndex = 13;
                        node.Tag = file;

                        // Only show files with sc4 extension and don't show cities that haven't been
                        // founded yet
                        if (file.Contains(".sc4"))
                        //&& !file.Contains("City - New City (")
                        {
                            if (FilterNewCitiesCheckbox.Checked
                                && file.Contains("City - New City"))
                            {
                                continue;
                            }

                            // Add to node
                            e.Node.Nodes.Add(node);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Load a file from the tree view
        /// </summary>
        private void FileTreeView_OnNodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            // Check the node we have clicked on is a file
            // (check the image index that we have set earlier, this is the easiest way)
            if (e.Node.ImageIndex == 13)
            {

                LoadSaveGame((string)e.Node.Tag);

            }
        }

        /// <summary>
        /// when user clicks the browse file button 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FileBrowserButton_Click(object sender, EventArgs e)
        {
            // Create folder browser dialog
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.SelectedPath = SavePathTextbox.Text;
                if (folderDialog.ShowDialog(this) == DialogResult.OK)
                    SavePathTextbox.Text = folderDialog.SelectedPath;
            }
        }

        /// <summary>
        /// Checkbox button that filters out any new cities from the SaveGames tree view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FilterNewCitiesCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            RefreshSaveGamesTreeView();
        }

        #endregion

        #region Appearance Control Events

        #region Visible Objects TreeView Events

        /// <summary>
        /// After check event for visible objects treeview, used to check parents and children 
        /// after a check event in tree view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VisibleObjectsTreeView_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Parent != null)
            {
                VisibleObjectsTreeView.AfterCheck -= VisibleObjectsTreeView_AfterCheck;
                if (AreSiblingsChecked(e.Node.Parent.Nodes))
                {
                    CheckParent(e.Node.Parent, true);
                }
                else
                {
                    CheckParent(e.Node.Parent, false);
                }
                VisibleObjectsTreeView.AfterCheck += VisibleObjectsTreeView_AfterCheck;
            }
            if (e.Node.Nodes.Count != 0)
            {
                VisibleObjectsTreeView.AfterCheck -= VisibleObjectsTreeView_AfterCheck;
                CheckAllNodes(e.Node.Nodes, e.Node.Checked);
                VisibleObjectsTreeView.AfterCheck += VisibleObjectsTreeView_AfterCheck;
            }

            SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
        }

        #endregion

        #region Zones Tab Events

        /// <summary>
        /// Zone edit color buttons, all do the same thing.
        /// Opens color picker, sets the color of the matching textbox to that color,
        /// calls setandupdate parameters which regenerates the preview
        /// </summary>

        private void GridBackgroundEditButton_Click(object sender, EventArgs e)
        {
            colorDialog = new ColorDialog();
            colorDialog.Color = GridBackgroundTextbox.BackColor;
            colorDialog.AllowFullOpen = true;
            colorDialog.FullOpen = true;
            //colorDialog.StartPosition = FormStartPosition.CenterParent;

            if (colorDialog.ShowDialog(this) == DialogResult.OK)
            {
                GridBackgroundTextbox.BackColor = colorDialog.Color;

                SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
            }
        }

        private void GridLinesEditTextbox_Click(object sender, EventArgs e)
        {
            colorDialog = new ColorDialog();
            colorDialog.Color = GridLinesTextbox.BackColor;
            colorDialog.AllowFullOpen = true;
            colorDialog.FullOpen = true;
            //colorDialog.StartPosition = FormStartPosition.CenterParent;

            if (colorDialog.ShowDialog(this) == DialogResult.OK)
            {
                GridLinesTextbox.BackColor = colorDialog.Color;

                SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
            }
        }

        private void PloppableBuildingsEditButton_Click(object sender, EventArgs e)
        {
            colorDialog = new ColorDialog();
            colorDialog.Color = PloppedBuildingsTextbox.BackColor;
            colorDialog.AllowFullOpen = true;
            colorDialog.FullOpen = true;
            //colorDialog.StartPosition = FormStartPosition.CenterParent;

            if (colorDialog.ShowDialog(this) == DialogResult.OK)
            {
                PloppedBuildingsTextbox.BackColor = colorDialog.Color;

                SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
            }
        }

        private void ResidentialZoneLowEditButton_Click(object sender, EventArgs e)
        {
            colorDialog = new ColorDialog();
            colorDialog.Color = ResidentialZoneLowTextbox.BackColor;
            colorDialog.AllowFullOpen = true;
            colorDialog.FullOpen = true;
            //colorDialog.StartPosition = FormStartPosition.CenterParent;

            if (colorDialog.ShowDialog(this) == DialogResult.OK)
            {
                ResidentialZoneLowTextbox.BackColor = colorDialog.Color;

                SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
            }
        }

        private void ResidentialZoneMidEditButton_Click(object sender, EventArgs e)
        {
            colorDialog = new ColorDialog();
            colorDialog.Color = ResidentialZoneMidTextbox.BackColor;
            colorDialog.AllowFullOpen = true;
            colorDialog.FullOpen = true;
            //colorDialog.StartPosition = FormStartPosition.CenterParent;

            if (colorDialog.ShowDialog(this) == DialogResult.OK)
            {
                ResidentialZoneMidTextbox.BackColor = colorDialog.Color;

                SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
            }
        }

        private void ResidentialZoneHighEditButton_Click(object sender, EventArgs e)
        {
            colorDialog = new ColorDialog();
            colorDialog.Color = ResidentialZoneHighTextbox.BackColor;
            colorDialog.AllowFullOpen = true;
            colorDialog.FullOpen = true;
            //colorDialog.StartPosition = FormStartPosition.CenterParent;

            if (colorDialog.ShowDialog(this) == DialogResult.OK)
            {
                ResidentialZoneHighTextbox.BackColor = colorDialog.Color;

                SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
            }
        }

        private void CommercialZoneLowEditButton_Click(object sender, EventArgs e)
        {
            colorDialog = new ColorDialog();
            colorDialog.Color = CommercialZoneLowTextbox.BackColor;
            colorDialog.AllowFullOpen = true;
            colorDialog.FullOpen = true;
            //colorDialog.StartPosition = FormStartPosition.CenterParent;

            if (colorDialog.ShowDialog(this) == DialogResult.OK)
            {
                CommercialZoneLowTextbox.BackColor = colorDialog.Color;

                SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
            }
        }

        private void CommercialZoneMidEditButton_Click(object sender, EventArgs e)
        {
            colorDialog = new ColorDialog();
            colorDialog.Color = CommercialZoneMidTextbox.BackColor;
            colorDialog.AllowFullOpen = true;
            colorDialog.FullOpen = true;
            //colorDialog.StartPosition = FormStartPosition.CenterParent;

            if (colorDialog.ShowDialog(this) == DialogResult.OK)
            {
                CommercialZoneMidTextbox.BackColor = colorDialog.Color;

                SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
            }
        }

        private void CommercialZoneHighEditButton_Click(object sender, EventArgs e)
        {
            colorDialog = new ColorDialog();
            colorDialog.Color = CommercialZoneHighTextbox.BackColor;
            colorDialog.AllowFullOpen = true;
            colorDialog.FullOpen = true;
            //colorDialog.StartPosition = FormStartPosition.CenterParent;

            if (colorDialog.ShowDialog(this) == DialogResult.OK)
            {
                CommercialZoneHighTextbox.BackColor = colorDialog.Color;

                SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
            }
        }

        private void IndustrialZoneLowEditButton_Click(object sender, EventArgs e)
        {
            colorDialog = new ColorDialog();
            colorDialog.Color = IndustrialZoneLowTextbox.BackColor;
            colorDialog.AllowFullOpen = true;
            colorDialog.FullOpen = true;
            //colorDialog.StartPosition = FormStartPosition.CenterParent;

            if (colorDialog.ShowDialog(this) == DialogResult.OK)
            {
                IndustrialZoneLowTextbox.BackColor = colorDialog.Color;

                SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
            }
        }

        private void IndustrialZoneMidEditButton_Click(object sender, EventArgs e)
        {
            colorDialog = new ColorDialog();
            colorDialog.Color = IndustrialZoneMidTextbox.BackColor;
            colorDialog.AllowFullOpen = true;
            colorDialog.FullOpen = true;
            //colorDialog.StartPosition = FormStartPosition.CenterParent;

            if (colorDialog.ShowDialog(this) == DialogResult.OK)
            {
                IndustrialZoneMidTextbox.BackColor = colorDialog.Color;

                SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
            }
        }

        private void IndustrialZoneHighEditButton_Click(object sender, EventArgs e)
        {
            colorDialog = new ColorDialog();
            colorDialog.Color = IndustrialZoneHighTextbox.BackColor;
            colorDialog.AllowFullOpen = true;
            colorDialog.FullOpen = true;
            //colorDialog.StartPosition = FormStartPosition.CenterParent;

            if (colorDialog.ShowDialog(this) == DialogResult.OK)
            {
                IndustrialZoneHighTextbox.BackColor = colorDialog.Color;

                SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
            }
        }

        private void ZoneOutlinesEditButton_Click(object sender, EventArgs e)
        {
            colorDialog = new ColorDialog();
            colorDialog.Color = ZoneOutlinesTextbox.BackColor;
            colorDialog.AllowFullOpen = true;
            colorDialog.FullOpen = true;
            //colorDialog.StartPosition = FormStartPosition.CenterParent;

            if (colorDialog.ShowDialog(this) == DialogResult.OK)
            {
                ZoneOutlinesTextbox.BackColor = colorDialog.Color;

                SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
            }
        }

        private void MilitaryEditButton_Click(object sender, EventArgs e)
        {
            colorDialog = new ColorDialog();
            colorDialog.Color = MilitaryTextbox.BackColor;
            colorDialog.AllowFullOpen = true;
            colorDialog.FullOpen = true;
            //colorDialog.StartPosition = FormStartPosition.CenterParent;

            if (colorDialog.ShowDialog(this) == DialogResult.OK)
            {
                MilitaryTextbox.BackColor = colorDialog.Color;

                SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
            }
        }

        private void AirportsEditButton_Click(object sender, EventArgs e)
        {
            colorDialog = new ColorDialog();
            colorDialog.Color = AirportsTextbox.BackColor;
            colorDialog.AllowFullOpen = true;
            colorDialog.FullOpen = true;
            //colorDialog.StartPosition = FormStartPosition.CenterParent;

            if (colorDialog.ShowDialog(this) == DialogResult.OK)
            {
                AirportsTextbox.BackColor = colorDialog.Color;

                SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
            }
        }

        private void SeaportsEditButton_Click(object sender, EventArgs e)
        {
            colorDialog = new ColorDialog();
            colorDialog.Color = SeaportTextbox.BackColor;
            colorDialog.AllowFullOpen = true;
            colorDialog.FullOpen = true;
            //colorDialog.StartPosition = FormStartPosition.CenterParent;

            if (colorDialog.ShowDialog(this) == DialogResult.OK)
            {
                SeaportTextbox.BackColor = colorDialog.Color;

                SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
            }
        }

        private void SpaceportEditButton_Click(object sender, EventArgs e)
        {
            colorDialog = new ColorDialog();
            colorDialog.Color = SpaceportTextbox.BackColor;
            colorDialog.AllowFullOpen = true;
            colorDialog.FullOpen = true;
            //colorDialog.StartPosition = FormStartPosition.CenterParent;

            if (colorDialog.ShowDialog(this) == DialogResult.OK)
            {
                SpaceportTextbox.BackColor = colorDialog.Color;

                SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
            }
        }

        #endregion

        #region Transport Tab Events

        /// <summary>
        /// Transport edit color buttons, all do the same thing.
        /// Opens color picker, sets the color of the matching textbox to that color,
        /// calls setandupdate parameters which regenerates the preview
        /// </summary>

        private void StreetEditButton_Click(object sender, EventArgs e)
        {
            colorDialog = new ColorDialog();
            colorDialog.Color = StreetTextBox.BackColor;
            colorDialog.AllowFullOpen = true;
            colorDialog.FullOpen = true;
            //colorDialog.StartPosition = FormStartPosition.CenterParent;

            if (colorDialog.ShowDialog(this) == DialogResult.OK)
            {
                StreetTextBox.BackColor = colorDialog.Color;

                SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
            }
        }

        private void RoadEditButton_Click(object sender, EventArgs e)
        {
            colorDialog = new ColorDialog();
            colorDialog.Color = RoadTextBox.BackColor;
            colorDialog.AllowFullOpen = true;
            colorDialog.FullOpen = true;
            //colorDialog.StartPosition = FormStartPosition.CenterParent;

            if (colorDialog.ShowDialog(this) == DialogResult.OK)
            {
                RoadTextBox.BackColor = colorDialog.Color;

                SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
            }
        }

        private void OneWayRoadEditButton_Click(object sender, EventArgs e)
        {
            colorDialog = new ColorDialog();
            colorDialog.Color = OneWayRoadTextBox.BackColor;
            colorDialog.AllowFullOpen = true;
            colorDialog.FullOpen = true;
            //colorDialog.StartPosition = FormStartPosition.CenterParent;

            if (colorDialog.ShowDialog(this) == DialogResult.OK)
            {
                OneWayRoadTextBox.BackColor = colorDialog.Color;

                SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
            }
        }

        private void AvenueEditButton_Click(object sender, EventArgs e)
        {
            colorDialog = new ColorDialog();
            colorDialog.Color = AvenueTextBox.BackColor;
            colorDialog.AllowFullOpen = true;
            colorDialog.FullOpen = true;
            //colorDialog.StartPosition = FormStartPosition.CenterParent;

            if (colorDialog.ShowDialog(this) == DialogResult.OK)
            {
                AvenueTextBox.BackColor = colorDialog.Color;

                SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
            }
        }

        private void RailwayEditButton_Click(object sender, EventArgs e)
        {
            colorDialog = new ColorDialog();
            colorDialog.Color = RailwayTextBox.BackColor;
            colorDialog.AllowFullOpen = true;
            colorDialog.FullOpen = true;
            //colorDialog.StartPosition = FormStartPosition.CenterParent;

            if (colorDialog.ShowDialog(this) == DialogResult.OK)
            {
                RailwayTextBox.BackColor = colorDialog.Color;

                SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
            }
        }

        private void SubwayEditButton_Click(object sender, EventArgs e)
        {
            colorDialog = new ColorDialog();
            colorDialog.Color = SubwayTextBox.BackColor;
            colorDialog.AllowFullOpen = true;
            colorDialog.FullOpen = true;
            //colorDialog.StartPosition = FormStartPosition.CenterParent;

            if (colorDialog.ShowDialog(this) == DialogResult.OK)
            {
                SubwayTextBox.BackColor = colorDialog.Color;

                SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
            }
        }

        #endregion

        #region Terrain Tab Events

        /// <summary>
        /// Slightly different than zones and transport functionality.
        /// Each terrain layer has a few items associated with them:
        /// - Color edit button
        /// - Alias textbox
        /// - Enabled checkbox
        /// - Height value numericupdown
        /// Each works slightly differently but they all do generally the same thing as before:
        /// When they are updated they regenerate the preview.
        /// 
        /// NOTE: All the callbacks for a lot of these are setup manually after the application has loaded.
        /// this is to avoid the callbacks being fired when they are being set with values from the MapCreationParameters
        /// 
        /// Prepare for a lot of copy and pasting
        /// </summary>

        #region Terrain Tab CheckBox Events

        private void TerrainLayer1CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Check how many terrain items are enabled 
            var enabledItems = map.Parameters.TerrainDataDictionary.Where(i => i.Value.enabled == true).ToList();
            if (enabledItems.Count == 1 && TerrainLayer1CheckBox.Checked == false)
            {
                // Don't allow user to disable all terrain layers or we will crash
                TerrainLayer1CheckBox.Checked = true;
                return;
            }

            // Disabled or enable all controls for the terrain layer
            TerrainLayer1AliasTextBox.Enabled = TerrainLayer1CheckBox.Checked;
            TerrainLayer1NumericUpDown.Enabled = TerrainLayer1CheckBox.Checked;
            TerrainLayer1Button.Enabled = TerrainLayer1CheckBox.Checked;

            // Update preview
            SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
        }

        private void TerrainLayer2CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Check how many terrain items are enabled 
            var enabledItems = map.Parameters.TerrainDataDictionary.Where(i => i.Value.enabled == true).ToList();
            if (enabledItems.Count == 1 && TerrainLayer2CheckBox.Checked == false)
            {
                // Don't allow user to disable all terrain layers or we will crash
                TerrainLayer2CheckBox.Checked = true;
                return;
            }

            // Disabled or enable all controls for the terrain layer
            TerrainLayer2AliasTextBox.Enabled = TerrainLayer2CheckBox.Checked;
            TerrainLayer2NumericUpDown.Enabled = TerrainLayer2CheckBox.Checked;
            TerrainLayer2Button.Enabled = TerrainLayer2CheckBox.Checked;

            // Update preview
            SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
        }

        private void TerrainLayer3CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Check how many terrain items are enabled 
            var enabledItems = map.Parameters.TerrainDataDictionary.Where(i => i.Value.enabled == true).ToList();
            if (enabledItems.Count == 1 && TerrainLayer3CheckBox.Checked == false)
            {
                // Don't allow user to disable all terrain layers or we will crash
                TerrainLayer3CheckBox.Checked = true;
                return;
            }

            // Disabled or enable all controls for the terrain layer
            TerrainLayer3AliasTextBox.Enabled = TerrainLayer3CheckBox.Checked;
            TerrainLayer3NumericUpDown.Enabled = TerrainLayer3CheckBox.Checked;
            TerrainLayer3Button.Enabled = TerrainLayer3CheckBox.Checked;

            // Update preview
            SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
        }

        private void TerrainLayer4CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Check how many terrain items are enabled 
            var enabledItems = map.Parameters.TerrainDataDictionary.Where(i => i.Value.enabled == true).ToList();
            if (enabledItems.Count == 1 && TerrainLayer4CheckBox.Checked == false)
            {
                // Don't allow user to disable all terrain layers or we will crash
                TerrainLayer4CheckBox.Checked = true;
                return;
            }

            // Disabled or enable all controls for the terrain layer
            TerrainLayer4AliasTextBox.Enabled = TerrainLayer4CheckBox.Checked;
            TerrainLayer4NumericUpDown.Enabled = TerrainLayer4CheckBox.Checked;
            TerrainLayer4Button.Enabled = TerrainLayer4CheckBox.Checked;

            // Update preview
            SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
        }

        private void TerrainLayer5CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Check how many terrain items are enabled 
            var enabledItems = map.Parameters.TerrainDataDictionary.Where(i => i.Value.enabled == true).ToList();
            if (enabledItems.Count == 1 && TerrainLayer5CheckBox.Checked == false)
            {
                // Don't allow user to disable all terrain layers or we will crash
                TerrainLayer5CheckBox.Checked = true;
                return;
            }

            // Disabled or enable all controls for the terrain layer
            TerrainLayer5AliasTextBox.Enabled = TerrainLayer5CheckBox.Checked;
            TerrainLayer5NumericUpDown.Enabled = TerrainLayer5CheckBox.Checked;
            TerrainLayer5Button.Enabled = TerrainLayer5CheckBox.Checked;

            // Update preview
            SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
        }

        private void TerrainLayer6CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Check how many terrain items are enabled 
            var enabledItems = map.Parameters.TerrainDataDictionary.Where(i => i.Value.enabled == true).ToList();
            if (enabledItems.Count == 1 && TerrainLayer6CheckBox.Checked == false)
            {
                // Don't allow user to disable all terrain layers or we will crash
                TerrainLayer6CheckBox.Checked = true;
                return;
            }

            // Disabled or enable all controls for the terrain layer
            TerrainLayer6AliasTextBox.Enabled = TerrainLayer6CheckBox.Checked;
            TerrainLayer6NumericUpDown.Enabled = TerrainLayer6CheckBox.Checked;
            TerrainLayer6Button.Enabled = TerrainLayer6CheckBox.Checked;

            // Update preview
            SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
        }

        private void TerrainLayer7CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Check how many terrain items are enabled 
            var enabledItems = map.Parameters.TerrainDataDictionary.Where(i => i.Value.enabled == true).ToList();
            if (enabledItems.Count == 1 && TerrainLayer7CheckBox.Checked == false)
            {
                // Don't allow user to disable all terrain layers or we will crash
                TerrainLayer7CheckBox.Checked = true;
                return;
            }

            // Disabled or enable all controls for the terrain layer
            TerrainLayer7AliasTextBox.Enabled = TerrainLayer7CheckBox.Checked;
            TerrainLayer7NumericUpDown.Enabled = TerrainLayer7CheckBox.Checked;
            TerrainLayer7Button.Enabled = TerrainLayer7CheckBox.Checked;

            // Update preview
            SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
        }

        private void TerrainLayer8CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Check how many terrain items are enabled 
            var enabledItems = map.Parameters.TerrainDataDictionary.Where(i => i.Value.enabled == true).ToList();
            if (enabledItems.Count == 1 && TerrainLayer8CheckBox.Checked == false)
            {
                // Don't allow user to disable all terrain layers or we will crash
                TerrainLayer8CheckBox.Checked = true;
                return;
            }

            // Disabled or enable all controls for the terrain layer
            TerrainLayer8AliasTextBox.Enabled = TerrainLayer8CheckBox.Checked;
            TerrainLayer8NumericUpDown.Enabled = TerrainLayer8CheckBox.Checked;
            TerrainLayer8Button.Enabled = TerrainLayer8CheckBox.Checked;

            // Update preview
            SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
        }

        private void TerrainLayer9CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Check how many terrain items are enabled 
            var enabledItems = map.Parameters.TerrainDataDictionary.Where(i => i.Value.enabled == true).ToList();
            if (enabledItems.Count == 1 && TerrainLayer9CheckBox.Checked == false)
            {
                // Don't allow user to disable all terrain layers or we will crash
                TerrainLayer9CheckBox.Checked = true;
                return;
            }

            // Disabled or enable all controls for the terrain layer
            TerrainLayer9AliasTextBox.Enabled = TerrainLayer9CheckBox.Checked;
            TerrainLayer9NumericUpDown.Enabled = TerrainLayer9CheckBox.Checked;
            TerrainLayer9Button.Enabled = TerrainLayer9CheckBox.Checked;

            // Update preview
            SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
        }

        private void TerrainLayer10CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Check how many terrain items are enabled 
            var enabledItems = map.Parameters.TerrainDataDictionary.Where(i => i.Value.enabled == true).ToList();
            if (enabledItems.Count == 1 && TerrainLayer10CheckBox.Checked == false)
            {
                // Don't allow user to disable all terrain layers or we will crash
                TerrainLayer10CheckBox.Checked = true;
                return;
            }

            // Disabled or enable all controls for the terrain layer
            TerrainLayer10AliasTextBox.Enabled = TerrainLayer10CheckBox.Checked;
            TerrainLayer10NumericUpDown.Enabled = TerrainLayer10CheckBox.Checked;
            TerrainLayer10Button.Enabled = TerrainLayer10CheckBox.Checked;

            // Update preview
            SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
        }

        private void TerrainLayer11CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Check how many terrain items are enabled 
            var enabledItems = map.Parameters.TerrainDataDictionary.Where(i => i.Value.enabled == true).ToList();
            if (enabledItems.Count == 1 && TerrainLayer11CheckBox.Checked == false)
            {
                // Don't allow user to disable all terrain layers or we will crash
                TerrainLayer11CheckBox.Checked = true;
                return;
            }

            // Disabled or enable all controls for the terrain layer
            TerrainLayer11AliasTextBox.Enabled = TerrainLayer11CheckBox.Checked;
            TerrainLayer11NumericUpDown.Enabled = TerrainLayer11CheckBox.Checked;
            TerrainLayer11Button.Enabled = TerrainLayer11CheckBox.Checked;

            // Update preview
            SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
        }

        private void TerrainLayer12CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Check how many terrain items are enabled 
            var enabledItems = map.Parameters.TerrainDataDictionary.Where(i => i.Value.enabled == true).ToList();
            if (enabledItems.Count == 1 && TerrainLayer12CheckBox.Checked == false)
            {
                // Don't allow user to disable all terrain layers or we will crash
                TerrainLayer12CheckBox.Checked = true;
                return;
            }

            // Disabled or enable all controls for the terrain layer
            TerrainLayer12AliasTextBox.Enabled = TerrainLayer12CheckBox.Checked;
            TerrainLayer12NumericUpDown.Enabled = TerrainLayer12CheckBox.Checked;
            TerrainLayer12Button.Enabled = TerrainLayer12CheckBox.Checked;

            // Update preview
            SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
        }

        private void TerrainLayer13CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Check how many terrain items are enabled 
            var enabledItems = map.Parameters.TerrainDataDictionary.Where(i => i.Value.enabled == true).ToList();
            if (enabledItems.Count == 1 && TerrainLayer13CheckBox.Checked == false)
            {
                // Don't allow user to disable all terrain layers or we will crash
                TerrainLayer13CheckBox.Checked = true;
                return;
            }

            // Disabled or enable all controls for the terrain layer
            TerrainLayer13AliasTextBox.Enabled = TerrainLayer13CheckBox.Checked;
            TerrainLayer13NumericUpDown.Enabled = TerrainLayer13CheckBox.Checked;
            TerrainLayer13Button.Enabled = TerrainLayer13CheckBox.Checked;

            // Update preview
            SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
        }

        private void TerrainLayer14CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Check how many terrain items are enabled 
            var enabledItems = map.Parameters.TerrainDataDictionary.Where(i => i.Value.enabled == true).ToList();
            if (enabledItems.Count == 1 && TerrainLayer14CheckBox.Checked == false)
            {
                // Don't allow user to disable all terrain layers or we will crash
                TerrainLayer14CheckBox.Checked = true;
                return;
            }

            // Disabled or enable all controls for the terrain layer
            TerrainLayer14AliasTextBox.Enabled = TerrainLayer14CheckBox.Checked;
            TerrainLayer14NumericUpDown.Enabled = TerrainLayer14CheckBox.Checked;
            TerrainLayer14Button.Enabled = TerrainLayer14CheckBox.Checked;

            // Update preview
            SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
        }

        private void TerrainLayer15CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Check how many terrain items are enabled 
            var enabledItems = map.Parameters.TerrainDataDictionary.Where(i => i.Value.enabled == true).ToList();
            if (enabledItems.Count == 1 && TerrainLayer15CheckBox.Checked == false)
            {
                // Don't allow user to disable all terrain layers or we will crash
                TerrainLayer15CheckBox.Checked = true;
                return;
            }

            // Disabled or enable all controls for the terrain layer
            TerrainLayer15AliasTextBox.Enabled = TerrainLayer15CheckBox.Checked;
            TerrainLayer15NumericUpDown.Enabled = TerrainLayer15CheckBox.Checked;
            TerrainLayer15Button.Enabled = TerrainLayer15CheckBox.Checked;

            // Update preview
            SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
        }

        private void TerrainLayer16CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Check how many terrain items are enabled 
            var enabledItems = map.Parameters.TerrainDataDictionary.Where(i => i.Value.enabled == true).ToList();
            if (enabledItems.Count == 1 && TerrainLayer16CheckBox.Checked == false)
            {
                // Don't allow user to disable all terrain layers or we will crash
                TerrainLayer16CheckBox.Checked = true;
                return;
            }

            // Disabled or enable all controls for the terrain layer
            TerrainLayer16AliasTextBox.Enabled = TerrainLayer16CheckBox.Checked;
            TerrainLayer16NumericUpDown.Enabled = TerrainLayer16CheckBox.Checked;
            TerrainLayer16Button.Enabled = TerrainLayer16CheckBox.Checked;

            // Update preview
            SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
        }

        private void TerrainLayer17CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Check how many terrain items are enabled 
            var enabledItems = map.Parameters.TerrainDataDictionary.Where(i => i.Value.enabled == true).ToList();
            if (enabledItems.Count == 1 && TerrainLayer17CheckBox.Checked == false)
            {
                // Don't allow user to disable all terrain layers or we will crash
                TerrainLayer17CheckBox.Checked = true;
                return;
            }

            // Disabled or enable all controls for the terrain layer
            TerrainLayer17AliasTextBox.Enabled = TerrainLayer17CheckBox.Checked;
            TerrainLayer17NumericUpDown.Enabled = TerrainLayer17CheckBox.Checked;
            TerrainLayer17Button.Enabled = TerrainLayer17CheckBox.Checked;

            // Update preview
            SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
        }

        private void TerrainLayer18CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Check how many terrain items are enabled 
            var enabledItems = map.Parameters.TerrainDataDictionary.Where(i => i.Value.enabled == true).ToList();
            if (enabledItems.Count == 1 && TerrainLayer18CheckBox.Checked == false)
            {
                // Don't allow user to disable all terrain layers or we will crash
                TerrainLayer18CheckBox.Checked = true;
                return;
            }

            // Disabled or enable all controls for the terrain layer
            TerrainLayer18AliasTextBox.Enabled = TerrainLayer18CheckBox.Checked;
            TerrainLayer18NumericUpDown.Enabled = TerrainLayer18CheckBox.Checked;
            TerrainLayer18Button.Enabled = TerrainLayer18CheckBox.Checked;

            // Update preview
            SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
        }

        private void TerrainLayer19CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Check how many terrain items are enabled 
            var enabledItems = map.Parameters.TerrainDataDictionary.Where(i => i.Value.enabled == true).ToList();
            if (enabledItems.Count == 1 && TerrainLayer19CheckBox.Checked == false)
            {
                // Don't allow user to disable all terrain layers or we will crash
                TerrainLayer19CheckBox.Checked = true;
                return;
            }

            // Disabled or enable all controls for the terrain layer
            TerrainLayer19AliasTextBox.Enabled = TerrainLayer19CheckBox.Checked;
            TerrainLayer19NumericUpDown.Enabled = TerrainLayer19CheckBox.Checked;
            TerrainLayer19Button.Enabled = TerrainLayer19CheckBox.Checked;

            // Update preview
            SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
        }

        private void TerrainLayer20CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Check how many terrain items are enabled 
            var enabledItems = map.Parameters.TerrainDataDictionary.Where(i => i.Value.enabled == true).ToList();
            if (enabledItems.Count == 1 && TerrainLayer20CheckBox.Checked == false)
            {
                // Don't allow user to disable all terrain layers or we will crash
                TerrainLayer20CheckBox.Checked = true;
                return;
            }

            // Disabled or enable all controls for the terrain layer
            TerrainLayer20AliasTextBox.Enabled = TerrainLayer20CheckBox.Checked;
            TerrainLayer20NumericUpDown.Enabled = TerrainLayer20CheckBox.Checked;
            TerrainLayer20Button.Enabled = TerrainLayer20CheckBox.Checked;

            // Update preview
            SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
        }

        private void TerrainLayer21CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Check how many terrain items are enabled 
            var enabledItems = map.Parameters.TerrainDataDictionary.Where(i => i.Value.enabled == true).ToList();
            if (enabledItems.Count == 1 && TerrainLayer21CheckBox.Checked == false)
            {
                // Don't allow user to disable all terrain layers or we will crash
                TerrainLayer21CheckBox.Checked = true;
                return;
            }

            // Disabled or enable all controls for the terrain layer
            TerrainLayer21AliasTextBox.Enabled = TerrainLayer21CheckBox.Checked;
            TerrainLayer21NumericUpDown.Enabled = TerrainLayer21CheckBox.Checked;
            TerrainLayer21Button.Enabled = TerrainLayer21CheckBox.Checked;

            // Update preview
            SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
        }

        private void TerrainLayer22CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Check how many terrain items are enabled 
            var enabledItems = map.Parameters.TerrainDataDictionary.Where(i => i.Value.enabled == true).ToList();
            if (enabledItems.Count == 1 && TerrainLayer22CheckBox.Checked == false)
            {
                // Don't allow user to disable all terrain layers or we will crash
                TerrainLayer22CheckBox.Checked = true;
                return;
            }

            // Disabled or enable all controls for the terrain layer
            TerrainLayer22AliasTextBox.Enabled = TerrainLayer22CheckBox.Checked;
            TerrainLayer22NumericUpDown.Enabled = TerrainLayer22CheckBox.Checked;
            TerrainLayer22Button.Enabled = TerrainLayer22CheckBox.Checked;

            // Update preview
            SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
        }

        private void TerrainLayer23CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Check how many terrain items are enabled 
            var enabledItems = map.Parameters.TerrainDataDictionary.Where(i => i.Value.enabled == true).ToList();
            if (enabledItems.Count == 1 && TerrainLayer23CheckBox.Checked == false)
            {
                // Don't allow user to disable all terrain layers or we will crash
                TerrainLayer23CheckBox.Checked = true;
                return;
            }

            // Disabled or enable all controls for the terrain layer
            TerrainLayer23AliasTextBox.Enabled = TerrainLayer23CheckBox.Checked;
            TerrainLayer23NumericUpDown.Enabled = TerrainLayer23CheckBox.Checked;
            TerrainLayer23Button.Enabled = TerrainLayer23CheckBox.Checked;

            // Update preview
            SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
        }

        #endregion

        #region Terrain Tab NumericUpDown Events

        private void TerrainLayer1NumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
        }

        private void TerrainLayer2NumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
        }

        private void TerrainLayer3NumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
        }

        private void TerrainLayer4NumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
        }

        private void TerrainLayer5NumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
        }

        private void TerrainLayer6NumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
        }

        private void TerrainLayer7NumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
        }

        private void TerrainLayer8NumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
        }

        private void TerrainLayer9NumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
        }

        private void TerrainLayer10NumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
        }

        private void TerrainLayer11NumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
        }

        private void TerrainLayer12NumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
        }

        private void TerrainLayer13NumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
        }

        private void TerrainLayer14NumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
        }

        private void TerrainLayer15NumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
        }

        private void TerrainLayer16NumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
        }

        private void TerrainLayer17NumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
        }

        private void TerrainLayer18NumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
        }

        private void TerrainLayer19NumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
        }

        private void TerrainLayer20NumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
        }

        private void TerrainLayer21NumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
        }

        private void TerrainLayer22NumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
        }

        private void TerrainLayer23NumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
        }

        #endregion

        #region Terrain Tab Button Events

        private void TerrainLayer1Button_click(object sender, EventArgs e)
        {
            colorDialog = new ColorDialog();
            colorDialog.Color = TerrainLayer1ColorTextBox.BackColor;
            colorDialog.AllowFullOpen = true;
            colorDialog.FullOpen = true;
            //colorDialog.StartPosition = FormStartPosition.CenterParent;

            if (colorDialog.ShowDialog(this) == DialogResult.OK)
            {
                TerrainLayer1ColorTextBox.BackColor = colorDialog.Color;

                SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
            }
        }

        private void TerrainLayer2Button_click(object sender, EventArgs e)
        {
            colorDialog = new ColorDialog();
            colorDialog.Color = TerrainLayer2ColorTextBox.BackColor;
            colorDialog.AllowFullOpen = true;
            colorDialog.FullOpen = true;
            //colorDialog.StartPosition = FormStartPosition.CenterParent;

            if (colorDialog.ShowDialog(this) == DialogResult.OK)
            {
                TerrainLayer2ColorTextBox.BackColor = colorDialog.Color;

                SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
            }
        }

        private void TerrainLayer3Button_click(object sender, EventArgs e)
        {
            colorDialog = new ColorDialog();
            colorDialog.Color = TerrainLayer3ColorTextBox.BackColor;
            colorDialog.AllowFullOpen = true;
            colorDialog.FullOpen = true;
            //colorDialog.StartPosition = FormStartPosition.CenterParent;

            if (colorDialog.ShowDialog(this) == DialogResult.OK)
            {
                TerrainLayer3ColorTextBox.BackColor = colorDialog.Color;

                SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
            }
        }

        private void TerrainLayer4Button_click(object sender, EventArgs e)
        {
            colorDialog = new ColorDialog();
            colorDialog.Color = TerrainLayer4ColorTextBox.BackColor;
            colorDialog.AllowFullOpen = true;
            colorDialog.FullOpen = true;
            //colorDialog.StartPosition = FormStartPosition.CenterParent;

            if (colorDialog.ShowDialog(this) == DialogResult.OK)
            {
                TerrainLayer4ColorTextBox.BackColor = colorDialog.Color;

                SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
            }
        }

        private void TerrainLayer5Button_click(object sender, EventArgs e)
        {
            colorDialog = new ColorDialog();
            colorDialog.Color = TerrainLayer5ColorTextBox.BackColor;
            colorDialog.AllowFullOpen = true;
            colorDialog.FullOpen = true;
            //colorDialog.StartPosition = FormStartPosition.CenterParent;

            if (colorDialog.ShowDialog(this) == DialogResult.OK)
            {
                TerrainLayer5ColorTextBox.BackColor = colorDialog.Color;

                SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
            }
        }

        private void TerrainLayer6Button_click(object sender, EventArgs e)
        {
            colorDialog = new ColorDialog();
            colorDialog.Color = TerrainLayer6ColorTextBox.BackColor;
            colorDialog.AllowFullOpen = true;
            colorDialog.FullOpen = true;
            //colorDialog.StartPosition = FormStartPosition.CenterParent;

            if (colorDialog.ShowDialog(this) == DialogResult.OK)
            {
                TerrainLayer6ColorTextBox.BackColor = colorDialog.Color;

                SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
            }
        }

        private void TerrainLayer7Button_click(object sender, EventArgs e)
        {
            colorDialog = new ColorDialog();
            colorDialog.Color = TerrainLayer7ColorTextBox.BackColor;
            colorDialog.AllowFullOpen = true;
            colorDialog.FullOpen = true;
            //colorDialog.StartPosition = FormStartPosition.CenterParent;

            if (colorDialog.ShowDialog(this) == DialogResult.OK)
            {
                TerrainLayer7ColorTextBox.BackColor = colorDialog.Color;

                SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
            }
        }

        private void TerrainLayer8Button_click(object sender, EventArgs e)
        {
            colorDialog = new ColorDialog();
            colorDialog.Color = TerrainLayer8ColorTextBox.BackColor;
            colorDialog.AllowFullOpen = true;
            colorDialog.FullOpen = true;
            //colorDialog.StartPosition = FormStartPosition.CenterParent;

            if (colorDialog.ShowDialog(this) == DialogResult.OK)
            {
                TerrainLayer8ColorTextBox.BackColor = colorDialog.Color;

                SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
            }
        }

        private void TerrainLayer9Button_click(object sender, EventArgs e)
        {
            colorDialog = new ColorDialog();
            colorDialog.Color = TerrainLayer9ColorTextBox.BackColor;
            colorDialog.AllowFullOpen = true;
            colorDialog.FullOpen = true;
            //colorDialog.StartPosition = FormStartPosition.CenterParent;

            if (colorDialog.ShowDialog(this) == DialogResult.OK)
            {
                TerrainLayer9ColorTextBox.BackColor = colorDialog.Color;

                SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
            }
        }

        private void TerrainLayer10Button_click(object sender, EventArgs e)
        {
            colorDialog = new ColorDialog();
            colorDialog.Color = TerrainLayer10ColorTextBox.BackColor;
            colorDialog.AllowFullOpen = true;
            colorDialog.FullOpen = true;
            //colorDialog.StartPosition = FormStartPosition.CenterParent;

            if (colorDialog.ShowDialog(this) == DialogResult.OK)
            {
                TerrainLayer10ColorTextBox.BackColor = colorDialog.Color;

                SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
            }
        }

        private void TerrainLayer11Button_click(object sender, EventArgs e)
        {
            colorDialog = new ColorDialog();
            colorDialog.Color = TerrainLayer11ColorTextBox.BackColor;
            colorDialog.AllowFullOpen = true;
            colorDialog.FullOpen = true;
            //colorDialog.StartPosition = FormStartPosition.CenterParent;

            if (colorDialog.ShowDialog(this) == DialogResult.OK)
            {
                TerrainLayer11ColorTextBox.BackColor = colorDialog.Color;

                SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
            }
        }

        private void TerrainLayer12Button_click(object sender, EventArgs e)
        {
            colorDialog = new ColorDialog();
            colorDialog.Color = TerrainLayer12ColorTextBox.BackColor;
            colorDialog.AllowFullOpen = true;
            colorDialog.FullOpen = true;
            //colorDialog.StartPosition = FormStartPosition.CenterParent;

            if (colorDialog.ShowDialog(this) == DialogResult.OK)
            {
                TerrainLayer12ColorTextBox.BackColor = colorDialog.Color;

                SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
            }
        }

        private void TerrainLayer13Button_click(object sender, EventArgs e)
        {
            colorDialog = new ColorDialog();
            colorDialog.Color = TerrainLayer13ColorTextBox.BackColor;
            colorDialog.AllowFullOpen = true;
            colorDialog.FullOpen = true;
            //colorDialog.StartPosition = FormStartPosition.CenterParent;

            if (colorDialog.ShowDialog(this) == DialogResult.OK)
            {
                TerrainLayer13ColorTextBox.BackColor = colorDialog.Color;

                SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
            }
        }

        private void TerrainLayer14Button_click(object sender, EventArgs e)
        {
            colorDialog = new ColorDialog();
            colorDialog.Color = TerrainLayer14ColorTextBox.BackColor;
            colorDialog.AllowFullOpen = true;
            colorDialog.FullOpen = true;
            //colorDialog.StartPosition = FormStartPosition.CenterParent;

            if (colorDialog.ShowDialog(this) == DialogResult.OK)
            {
                TerrainLayer14ColorTextBox.BackColor = colorDialog.Color;

                SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
            }
        }

        private void TerrainLayer15Button_click(object sender, EventArgs e)
        {
            colorDialog = new ColorDialog();
            colorDialog.Color = TerrainLayer15ColorTextBox.BackColor;
            colorDialog.AllowFullOpen = true;
            colorDialog.FullOpen = true;
            //colorDialog.StartPosition = FormStartPosition.CenterParent;

            if (colorDialog.ShowDialog(this) == DialogResult.OK)
            {
                TerrainLayer15ColorTextBox.BackColor = colorDialog.Color;

                SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
            }
        }

        private void TerrainLayer16Button_click(object sender, EventArgs e)
        {
            colorDialog = new ColorDialog();
            colorDialog.Color = TerrainLayer16ColorTextBox.BackColor;
            colorDialog.AllowFullOpen = true;
            colorDialog.FullOpen = true;
            //colorDialog.StartPosition = FormStartPosition.CenterParent;

            if (colorDialog.ShowDialog(this) == DialogResult.OK)
            {
                TerrainLayer16ColorTextBox.BackColor = colorDialog.Color;

                SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
            }
        }

        private void TerrainLayer17Button_click(object sender, EventArgs e)
        {
            colorDialog = new ColorDialog();
            colorDialog.Color = TerrainLayer17ColorTextBox.BackColor;
            colorDialog.AllowFullOpen = true;
            colorDialog.FullOpen = true;
            //colorDialog.StartPosition = FormStartPosition.CenterParent;

            if (colorDialog.ShowDialog(this) == DialogResult.OK)
            {
                TerrainLayer17ColorTextBox.BackColor = colorDialog.Color;

                SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
            }
        }

        private void TerrainLayer18Button_click(object sender, EventArgs e)
        {
            colorDialog = new ColorDialog();
            colorDialog.Color = TerrainLayer18ColorTextBox.BackColor;
            colorDialog.AllowFullOpen = true;
            colorDialog.FullOpen = true;
            //colorDialog.StartPosition = FormStartPosition.CenterParent;

            if (colorDialog.ShowDialog(this) == DialogResult.OK)
            {
                TerrainLayer18ColorTextBox.BackColor = colorDialog.Color;

                SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
            }
        }

        private void TerrainLayer19Button_click(object sender, EventArgs e)
        {
            colorDialog = new ColorDialog();
            colorDialog.Color = TerrainLayer19ColorTextBox.BackColor;
            colorDialog.AllowFullOpen = true;
            colorDialog.FullOpen = true;
            //colorDialog.StartPosition = FormStartPosition.CenterParent;

            if (colorDialog.ShowDialog(this) == DialogResult.OK)
            {
                TerrainLayer19ColorTextBox.BackColor = colorDialog.Color;

                SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
            }
        }

        private void TerrainLayer20Button_click(object sender, EventArgs e)
        {
            colorDialog = new ColorDialog();
            colorDialog.Color = TerrainLayer20ColorTextBox.BackColor;
            colorDialog.AllowFullOpen = true;
            colorDialog.FullOpen = true;
            //colorDialog.StartPosition = FormStartPosition.CenterParent;

            if (colorDialog.ShowDialog(this) == DialogResult.OK)
            {
                TerrainLayer20ColorTextBox.BackColor = colorDialog.Color;

                SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
            }
        }

        private void TerrainLayer21Button_click(object sender, EventArgs e)
        {
            colorDialog = new ColorDialog();
            colorDialog.Color = TerrainLayer21ColorTextBox.BackColor;
            colorDialog.AllowFullOpen = true;
            colorDialog.FullOpen = true;
            //colorDialog.StartPosition = FormStartPosition.CenterParent;

            if (colorDialog.ShowDialog(this) == DialogResult.OK)
            {
                TerrainLayer21ColorTextBox.BackColor = colorDialog.Color;

                SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
            }
        }

        private void TerrainLayer22Button_click(object sender, EventArgs e)
        {
            colorDialog = new ColorDialog();
            colorDialog.Color = TerrainLayer22ColorTextBox.BackColor;
            colorDialog.AllowFullOpen = true;
            colorDialog.FullOpen = true;
            //colorDialog.StartPosition = FormStartPosition.CenterParent;

            if (colorDialog.ShowDialog(this) == DialogResult.OK)
            {
                TerrainLayer22ColorTextBox.BackColor = colorDialog.Color;

                SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
            }
        }

        private void TerrainLayer23Button_click(object sender, EventArgs e)
        {
            colorDialog = new ColorDialog();
            colorDialog.Color = TerrainLayer23ColorTextBox.BackColor;
            colorDialog.AllowFullOpen = true;
            colorDialog.FullOpen = true;
            //colorDialog.StartPosition = FormStartPosition.CenterParent;

            if (colorDialog.ShowDialog(this) == DialogResult.OK)
            {
                TerrainLayer23ColorTextBox.BackColor = colorDialog.Color;

                SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
            }
        }

        #endregion

        #endregion

        #region Buildings Tab Events

        private void BuildingsEditButton_Click(object sender, EventArgs e)
        {
            colorDialog = new ColorDialog();
            colorDialog.Color = BuildingsTextBox.BackColor;
            colorDialog.AllowFullOpen = true;
            colorDialog.FullOpen = true;
            //colorDialog.StartPosition = FormStartPosition.CenterParent;

            if (colorDialog.ShowDialog(this) == DialogResult.OK)
            {
                BuildingsTextBox.BackColor = colorDialog.Color;

                SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
            }
        }

        private void BuildingsOutlineEditButton_Click(object sender, EventArgs e)
        {
            colorDialog = new ColorDialog();
            colorDialog.Color = BuildingsOutlineTextBox.BackColor;
            colorDialog.AllowFullOpen = true;
            colorDialog.FullOpen = true;
            //colorDialog.StartPosition = FormStartPosition.CenterParent;

            if (colorDialog.ShowDialog(this) == DialogResult.OK)
            {
                BuildingsOutlineTextBox.BackColor = colorDialog.Color;

                SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
            }
        }

        #endregion

        #region Grid, Zone and Terrain Properties Events

        /// <summary>
        /// All pretty basic, when the value is changed they call the update preview function (apart from segment size)
        /// 
        /// NOTE: All the callbacks for a lot of these are setup manually after the application has loaded.
        /// this is to avoid the callbacks being fired when they are being set with values from the MapCreationParameters
        /// </summary>

        private void GridSegmentSizeNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());

            // Reset zoom when changing segment size
            zoomFactor = 1;
            ZoomTrackBar.Value = 0;
            ZoomImage(true);
        }

        private void SegmentPaddingNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
        }

        private void SegmentOffsetNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
        }

        private void ShowGridLinesCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
        }

        private void ShowZoneOutlinesCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
        }

        private void BlendTerrainColorsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
        }

        private void ShowBuildingOutlinesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
        }

        #endregion

        #region Output Events

        private void EditOutputPathButton_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.SelectedPath = OutputPathTextbox.Text;
                if (folderDialog.ShowDialog(this) == DialogResult.OK)
                {
                    // put path into output path textbox
                    OutputPathTextbox.Text = folderDialog.SelectedPath;

                    // Set cursor to end of textbox
                    OutputPathTextbox.SelectionStart = OutputPathTextbox.Text.Length;
                    OutputPathTextbox.SelectionLength = 0;
                }
            }
        }

        private void PNGRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (PNGRadioButton.Checked)
                map.Parameters.OutputFormat = OutFormat.PNG;
            else
                map.Parameters.OutputFormat = OutFormat.JPEG;
        }

        private void JPEGRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (JPEGRadioButton.Checked)
                map.Parameters.OutputFormat = OutFormat.JPEG;
            else
                map.Parameters.OutputFormat = OutFormat.PNG;
        }

        private void OutputPathTextbox_TextChanged(object sender, EventArgs e)
        {
            // Copy over whatever is in this box to our parameter's output path
            map.Parameters.OutputPath = OutputPathTextbox.Text;
        }

        #endregion

        #region Common Events

        /// <summary>
        /// A bunch of common events used by multiple ui items in appearance group
        /// </summary>
        
        /// <summary>
        /// Stub mouse wheel event for numeric controls, used to stop mouse wheels incrementing values of 
        /// numericupdown control too quickly
        /// Source: https://stackoverflow.com/a/59863542
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumericUpDown_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }

        /// <summary>
        /// Textbox event that allows only alpha numeric values to be entered into textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxDisallowSpecialCharacters_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Regex expression that negatively match any characters that aren't alphanumeric
            Regex regex = new Regex(@"[^a-zA-Z0-9\s]");

            if (regex.IsMatch(e.KeyChar.ToString()))
            {
                // Ignore the inputted character if it matches 
                e.Handled = true;
            }

        }

        #endregion

        #endregion

        #endregion
    }
}
