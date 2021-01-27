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

namespace SC4CartographerUI
{
    public partial class MainForm : Form
    {
        struct Map
        {
            public SC4SaveFile Save;
            public MapCreationParameters Parameters;
        }

        string RootSimCitySavePath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
            "Documents", 
            "SimCity 4", 
            "Regions");

        private Map map = new Map();
        private Bitmap previewNormalMapBitmap;
        private Bitmap previewZoomedMapBitmap;
        private bool previewZoomed = false;

        private RichTextBoxLogger logger = null;
        private FileLogger fileLogger = null;

        // Locally cached data from our currently loaded save game
        // Used when getting pixel data from map
        // (saves excessive logging calls that happen when using map.Save directly)
        private float[][] terrainData = null;
        private List<Lot> zoneData = null;

        public MainForm()
        {
            InitializeComponent();

            // Setup cleanup timer
            cleanupTimer = new System.Timers.Timer(4000);
            cleanupTimer.AutoReset = false;
            cleanupTimer.Elapsed += OnCleanupTimerElapsed;

            // Setup parser logger
            //logger = new RichTextBoxLogger(LogTextBox);
            fileLogger = new FileLogger();

            // Create some new default map parameters
            map.Parameters = new MapCreationParameters();

            // Setup appearance tab
            SetAppearanceUIValuesUsingParameters(map.Parameters);
            RegisterAppearanceEvents();

        }
        public MainForm(string path) : this()
        {
            // Try and load parameters from path if they have been given to program
            // (this is called when an associated file [.sc4cart] is used to call program)
            LoadMapParameters(path);
        }

        #region Core functionality
        #endregion

        #region Preview and Save game functionality
        // TODO: Seperate out

        System.Timers.Timer cleanupTimer = new System.Timers.Timer(1000);

        /// <summary>
        /// Sets map creation parameters and refreshes preview
        /// </summary>
        /// <param name="parameters"></param>
        public void SetAndUpdateMapCreationParameters(MapCreationParameters parameters)
        {
            map.Parameters = parameters;

            GenerateMapPreview();

            // Call garbage collector to cleanup anything left over from generating new preview
            // gets a bit spammy sometimes.... man modern constructs like GC have made me weak
            // and this is almost certainly not a good move
            // but.....

            if (cleanupTimer.Enabled == false)
            {
                cleanupTimer.Enabled = true;
            }


        }

        private void OnCleanupTimerElapsed(Object source, ElapsedEventArgs e)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        /// <summary>
        /// Generates and sets preview map image on form
        /// </summary>
        public void GenerateMapPreview()
        {
            // Generate normal preview image
            MapCreationParameters normalMapPreviewParameters = new MapCreationParameters(map.Parameters);
            previewNormalMapBitmap = MapRenderer.CreateMapBitmap(map.Save, normalMapPreviewParameters);

            // Don't bother rendering a zoomed in map if the segment size is bigger than 10 pixels (zoomed in map size)
            // We perform the same check in TogglePreviewImage()
            if (map.Parameters.GridSegmentSize <= 10)
            {
                // Generate zoomed preview image
                MapCreationParameters zoomedMapPreviewParameters = new MapCreationParameters(map.Parameters);
                zoomedMapPreviewParameters.GridSegmentSize = 10;
                zoomedMapPreviewParameters.SegmentPaddingX = 4;
                zoomedMapPreviewParameters.SegmentPaddingY = 4;
                previewZoomedMapBitmap = MapRenderer.CreateMapBitmap(map.Save, zoomedMapPreviewParameters);

                // Change cursor to show we can zoom in
                MapPictureBox.Cursor = Cursors.Cross;
            }
            else
            {
                // Reset the cursor to whatever the user is currently using
                MapPictureBox.Cursor = Cursors.Default;
            }

            // Set image, reset zoom
            MapPictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
            CenterPictureBox(MapPictureBox, previewNormalMapBitmap);
            previewZoomed = false;

            // Setup toolstrip details
            Process proc = Process.GetCurrentProcess();
            MemoryUsedToolStripStatusLabel.Text = $"Memory used: {Math.Truncate(Helper.ConvertBytesToMegabytes(proc.PrivateMemorySize64)).ToString()} MB";
            MapSizeToolStripStatusLabel.Text = $"Size: {previewNormalMapBitmap.Width.ToString()} x {previewNormalMapBitmap.Height.ToString()}px";
        }

        /// <summary>
        /// Check if a save has the subfile we need, if it does then we can load it
        /// if not avoid it otherwise SC4Parsernwill throw an exception
        /// </summary>
        public bool CheckSaveCanLoad(string path)
        {
            try
            {
                SC4SaveFile save = new SC4SaveFile(path);
                save.GetLotSubfile();
                return true;
            }
            catch (Exception)
            {
                return false;
            } 
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
                save.GetLotSubfile();
            }
            catch (SubfileNotFoundException e)
            {
                var errorForm = new ErrorForm(
                    "Error loading save game",
                    $"Could not create map for '{Path.GetFileName(path)}'. Could not load zone data or it does not exist.",
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
                // Generate and set map preview images
                GenerateMapPreview();
            }
            catch (SubfileNotFoundException e)
            {
                var errorForm = new ErrorForm(
                    "Error creating preview",
                    $"Could not create preview map for '{Path.GetFileName(path)}'.",
                    e,
                    true);

                errorForm.StartPosition = FormStartPosition.CenterParent;
                errorForm.ShowDialog();

                return;
            }

            // Cache some save data for map pixel lookup
            terrainData = save.GetTerrainMapSubfile().Map;
            zoneData = save.GetLotSubfile().Lots;

            // Set window title
            this.Text = "SC4Cartographer - '" + Path.GetFileName(path) + "'";
                
            EnableSaveButtons();

            // Call garbage collector to cleanup anything left over from last load
            //GC.Collect();
            //GC.WaitForPendingFinalizers();
        }

        public string GenerateDefaultMapFilename()
        {
            string savefile = Path.GetFileNameWithoutExtension(map.Save.FilePath);
            savefile = savefile.Replace("City - ", "");
            return savefile;
        }

        /// <summary>
        /// Common function that saves out a map to a file
        /// </summary>
        public void SaveMap(string path, string name)
        {
            string filePath = Path.Combine(path, name);

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
                // Get the bitmap (this time we actually generate it from what the user inputted
                // not what we needed when we were generating the preview)
                Bitmap outBitmap = MapRenderer.CreateMapBitmap(map.Save, map.Parameters);

                // Actually save out the image
                switch (map.Parameters.OutputFormat)
                {
                    case OutFormat.PNG:
                        outBitmap.Save(currentFilename, ImageFormat.Png);
                        break;
                    case OutFormat.JPEG:
                        outBitmap.Save(currentFilename, ImageFormat.Jpeg);
                        break;
                }

                // Show form when successfully created
                var mapCreatedForm = new SuccessForm(
                    "Map Saved",
                    $"Map '{Path.GetFileName(currentFilename)}' has been successfully saved to",
                    Path.GetDirectoryName(currentFilename),
                    currentFilename);

                mapCreatedForm.StartPosition = FormStartPosition.CenterParent;
                mapCreatedForm.ShowDialog();

            }
            catch (Exception e)
            {
                var errorForm = new ErrorForm(
                    "Error saving map",
                    $"There was an error while trying to save a map for '{path}'.",
                    e,
                    true);

                errorForm.StartPosition = FormStartPosition.CenterParent;
                errorForm.ShowDialog();
            }

            // Cleanup any stuff after saving (these bitmaps can take up a fair amount of memory)
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        public void SaveMapParametersWithDialog()
        {
            // Create generic name at current directory
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "map_appearance.sc4cart");
            filePath = Helper.GenerateFilename(filePath);

            using (SaveFileDialog fileDialog = new SaveFileDialog())
            {
                fileDialog.Title = "Save SC4Cartographer map properties";
                fileDialog.InitialDirectory = Directory.GetCurrentDirectory();
                fileDialog.FileName = Path.GetFileName(filePath);
                fileDialog.RestoreDirectory = true;
                //fileDialog.CheckFileExists = true;
                fileDialog.CheckPathExists = true;
                fileDialog.Filter = "SC4Cartographer properties file (*.sc4cart)|*.sc4cart";
                if (fileDialog.ShowDialog(this) == DialogResult.OK)
                {
                    SaveMapParameters(fileDialog.FileName);
                }
            }
        }

        /// <summary>
        /// Common function called when saving map parameters/properties/appearance to a file
        /// </summary>
        /// <param name="path"></param>
        public void SaveMapParameters(string path)
        {
            try
            {
                map.Parameters.SaveToFile(path);

                var successForm = new SuccessForm(
                    "Map appearance saved",
                    $"Map appearance file '{Path.GetFileName(path)}' has been successfully saved to",
                    Path.GetDirectoryName(path),
                    path);

                successForm.StartPosition = FormStartPosition.CenterParent;
                successForm.ShowDialog();
            }
            catch (Exception ex)
            {
                ErrorForm form = new ErrorForm(
                    "Could not save map properties",
                    $"An error occured while trying to save map properties file ({path})",
                    ex,
                    false);

                form.StartPosition = FormStartPosition.CenterParent;
                form.ShowDialog();
            }
        }

        /// <summary>
        /// Common function called when loading map parameters/properties/appearance from file
        /// </summary>
        /// <param name="path"></param>
        public void LoadMapParameters(string path)
        {
            try
            {
                // Try and load parameters from a file
                map.Parameters.LoadFromFile(path);

                // Populate appearance ui items with new parameters
                SetAppearanceUIValuesUsingParameters(map.Parameters);
            }
            catch (Exception ex)
            {
                ErrorForm form = new ErrorForm(
                    "Could not load map properties",
                    $"An error occured while trying to load map properties from file ({path})",
                    ex,
                    false);

                form.StartPosition = FormStartPosition.CenterParent;
                form.ShowDialog();

                return;
            }
        }

        /// <summary>
        /// Switch between zoomed and normal images
        /// </summary>
        public void TogglePreviewImage()
        {
            previewZoomed = !previewZoomed;

            // Don't show preview image if the grid size is already bigger than the zoomed in size
            if (map.Parameters.GridSegmentSize > 10)
            {
                return;
            }

            if (previewZoomed)
            {
                CenterPictureBox(MapPictureBox, previewZoomedMapBitmap);
            }
            else
            {
                CenterPictureBox(MapPictureBox, previewNormalMapBitmap);
            }
        }

        /// <summary>
        /// We don't want these buttons to be enabled when nothing is loaded
        /// </summary>
        private void EnableSaveButtons()
        {
            saveToolStripMenuItem.Enabled = true;
            saveAsToolStripMenuItem.Enabled = true;
            SaveButton.Enabled = true;
            AppearanceGroupBox.Enabled = true;

            OpenTextLabel.Visible = false;
        }

        /// <summary>
        /// Rebuilds tree view and its contents
        /// </summary>
        private void RefreshTreeView()
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
            // TODO: Handle this exception, put in log

            return savegames[rand.Next(savegames.Count)];
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

        /// <summary>
        /// Gets information for a specific pixel on the map. Returned as a string
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private string GetMapPixelInfo(int x, int y)
        {
            string result = "";

            int cityX = 0;
            int cityY = 0;

            if (previewZoomed)
            {
                cityX = x / 10;
                cityY = y / 10;
            }
            else
            {
                // Work out coordinates on map
                cityX = x / map.Parameters.GridSegmentSize;
                cityY = y / map.Parameters.GridSegmentSize;
            }

            result = $"Mouse: {x}, {y}px (tile: {cityX}x, {cityY}z) ";

            try
            {
                result += $" (height: {terrainData[cityY][cityX]})";
            }
            catch (IndexOutOfRangeException) { } // Silently continue when we accidently get a range outside of the terrain map bounds 

            // See if there is any zone data on that segment
            foreach (Lot lot in zoneData)
            {
                for (int lotZ = lot.MinTileZ; lotZ <= lot.MaxTileZ; lotZ++)
                {
                    if (lotZ == cityY)
                    {
                        for (int lotX = lot.MinTileX; lotX <= lot.MaxTileX; lotX++)
                        {
                            if (lotX == cityX)
                            {
                                result += $" (zone: {SC4Parser.Constants.LOT_ZONE_TYPE_STRINGS[lot.ZoneType]} [{SC4Parser.Constants.LOT_ZONE_WEALTH_STRINGS[lot.ZoneWealth]}])";
                            }
                        }
                    }
                }
            }

            return result;
        }

        #endregion

        #region Savegames and Preview Callbacks
        // TODO: Seperate out

        private void SaveButton_Click(object sender, EventArgs e)
        {
            string name = GenerateDefaultMapFilename();
            SaveMap(map.Parameters.OutputPath, name);
        }

        /// <summary>
        /// When main form loads
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            // Load a random map on open
            //logger = new RichTextBoxLogger(LogTextBox);
            if (Directory.Exists(RootSimCitySavePath))
            {
                bool validSaveFound = false;
                string path = "";

                // Find a save that will load without errors (probably doesn't have a lot subfile :/)
                while (validSaveFound == false)
                {
                    SavePathTextbox.Text = RootSimCitySavePath;
                    path = FindRandomSavegameFileInPath(RootSimCitySavePath);
                    if (CheckSaveCanLoad(path))
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
                        if (file.Contains(".sc4") )
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

        private void LogTextBox_TextChanged(object sender, EventArgs e)
        {
            // Set caret position to end of current text
            //LogTextBox.SelectionStart = LogTextBox.Text.Length;

            // Scroll to bottom automatically
            //LogTextBox.ScrollToCaret();
        }

        private void PropertiesButton_Click(object sender, EventArgs e)
        {

            // Generate map again
            //LoadSaveGame(mapCreationParameters.SaveFile.FilePath);
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
                
                LoadSaveGame((string) e.Node.Tag);

            }
        }

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

        private void MapPictureBox_Clicked(object sender, EventArgs e)
        {
            TogglePreviewImage();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string name = GenerateDefaultMapFilename();
            SaveMap(map.Parameters.OutputPath, name);
        }

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

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void savegameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog fileDialog = new OpenFileDialog())
            {
                fileDialog.Title = "Load SimCity 4 save game";
                fileDialog.InitialDirectory = SavePathTextbox.Text;
                fileDialog.RestoreDirectory = true;
                fileDialog.CheckFileExists = true;
                fileDialog.CheckPathExists = true;
                fileDialog.Filter = "Simcity 4 save file (*.sc4)|*.sc4";
                if (fileDialog.ShowDialog(this) == DialogResult.OK)
                    LoadSaveGame(fileDialog.FileName);
            }
        }

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

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var mapCreatedForm = new AboutBox();
            mapCreatedForm.StartPosition = FormStartPosition.CenterParent;
            mapCreatedForm.ShowDialog();
        }

        private void FilterNewCitiesCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            RefreshTreeView();
        }

        private void reportABugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Version v = Assembly.GetExecutingAssembly().GetName().Version;
            string version = Assembly.GetExecutingAssembly().GetName().Name + " v" + v.Major + "." + v.Minor + "." + v.Build + " (r" + v.Revision + ") ";
            version = version.Replace(' ', '+');
            string parserVersion = "SC4Parser+v1.0.0.0";

            string issueLink = @"https://github.com/killeroo/SC4Cartographer/issues/new?body=%0A%0A%0A---------%0A" + version + "%0A" + parserVersion;
            System.Diagnostics.Process.Start(issueLink);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var mapCreatedForm = new AboutBox();
            mapCreatedForm.StartPosition = FormStartPosition.CenterParent;
            mapCreatedForm.ShowDialog();
        }
       
        private void projectWebpageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"https://github.com/killeroo/SC4Cartographer");
        }
       
        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            var mapCreatedForm = new LogForm(fileLogger.LogPath, fileLogger.Created);
            mapCreatedForm.StartPosition = FormStartPosition.CenterParent;
            mapCreatedForm.ShowDialog();
        }

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

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            SaveMapParametersWithDialog();
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog fileDialog = new OpenFileDialog())
            {
                fileDialog.Title = "Load SC4Cartographer map properties";
                fileDialog.InitialDirectory = Directory.GetCurrentDirectory();
                fileDialog.RestoreDirectory = true;
                fileDialog.CheckFileExists = true;
                fileDialog.CheckPathExists = true;
                fileDialog.Filter = "SC4Cartographer properties file (*.sc4cart)|*.sc4cart";
                if (fileDialog.ShowDialog(this) == DialogResult.OK)
                {
                    // Load new parameters and regenerate preview
                    LoadMapParameters(fileDialog.FileName);
                    GenerateMapPreview();
                }
            }
        }

        private void MapPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            MousePositionToolStripStatusLabel.Text = GetMapPixelInfo(e.X, e.Y);
        }

        private void MapPictureBox_MouseLeave(object sender, EventArgs e)
        {
            MousePositionToolStripStatusLabel.Text = "";
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (previewZoomed)
            {
                CenterPictureBox(MapPictureBox, previewZoomedMapBitmap);
            }
            else
            {
                CenterPictureBox(MapPictureBox, previewNormalMapBitmap);
            }
        }

        private void MainForm_ResizeBegin(object sender, EventArgs e)
        {
            ShowAppearanceTabUI(false);
        }

        private void MainForm_ResizeEnd(object sender, EventArgs e)
        {
            ShowAppearanceTabUI(true);
        }

        #endregion


        #region Appearance Group Functionality

        private void ShowAppearanceTabUI(bool show)
        {
            VisibleObjectsTreeView.Visible = show;
            ColorsTabControl.Visible = show;
            GridSegmentSizeLabel.Visible = show;
            SegmentOffsetLabel.Visible = show;
            SegmentPaddingLabel.Visible = show;
            OutputFormatLabel.Visible = show;
            OutputPathLabel.Visible = show;
            PixelLabel1.Visible = show;
            PixelLabel2.Visible = show;
            PixelLabel3.Visible = show;
            GridSegmentSizeNumericUpDown.Visible = show;
            SegmentOffsetNumericUpDown.Visible = show;
            SegmentPaddingNumericUpDown.Visible = show;
            SegmentOffsetLabel.Visible = show;
            ShowGridLinesCheckbox.Visible = show;
            ShowZoneOutlinesCheckbox.Visible = show;
            PNGRadioButton.Visible = show;
            JPEGRadioButton.Visible = show;
            OutputPathTextbox.Visible = show;
            EditOutputPathButton.Visible = show;
        }

        /// <summary>
        /// We seperated out registering events from their components creation so we can set the UI values without having 
        /// their callbacks fire
        /// </summary>
        private void RegisterAppearanceEvents()
        {
            this.ShowZoneOutlinesCheckbox.CheckedChanged += new System.EventHandler(this.ShowZoneOutlinesCheckbox_CheckedChanged);
            this.SegmentOffsetNumericUpDown.ValueChanged += new System.EventHandler(this.SegmentOffsetNumericUpDown_ValueChanged);
            this.SegmentPaddingNumericUpDown.ValueChanged += new System.EventHandler(this.SegmentPaddingNumericUpDown_ValueChanged);
            this.GridSegmentSizeNumericUpDown.ValueChanged += new System.EventHandler(this.GridSegmentSizeNumericUpDown_ValueChanged);
            this.ShowGridLinesCheckbox.CheckedChanged += new System.EventHandler(this.ShowGridLinesCheckbox_CheckedChanged);
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
            this.BuildingsEditButton.Click += new System.EventHandler(this.BuildingsEditButton_Click);
            this.ResidentialZoneLowEditButton.Click += new System.EventHandler(this.ResidentialZoneLowEditButton_Click);
            this.ResidentialZoneHighEditButton.Click += new System.EventHandler(this.ResidentialZoneHighEditButton_Click);
            this.ResidentialZoneMidEditButton.Click += new System.EventHandler(this.ResidentialZoneMidEditButton_Click);
            this.GridBackgroundEditButton.Click += new System.EventHandler(this.GridBackgroundEditButton_Click);

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
        }

        private void SetAppearanceUIValuesUsingParameters(MapCreationParameters parameters)
        {
            // Fill zone stuff
            GridBackgroundTextbox.BackColor = parameters.ColorDictionary[MapColorObject.Background];
            GridLinesTextbox.BackColor = parameters.ColorDictionary[MapColorObject.GridLines];
            BuildingsTextbox.BackColor = parameters.ColorDictionary[MapColorObject.PloppedBuilding];
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
            SegmentOffsetNumericUpDown.Value = parameters.SegmentOffsetX;
            ShowGridLinesCheckbox.Checked = parameters.ShowGridLines;
            ShowZoneOutlinesCheckbox.Checked = parameters.ShowZoneOutlines;

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

            // Layers tree
            VisibleObjectsTreeView.AfterCheck -= VisibleObjectsTreeView_AfterCheck;
            PopulateLayersTreeView(VisibleObjectsTreeView.Nodes, parameters.VisibleMapObjects);
            VisibleObjectsTreeView.ExpandAll();
            VisibleObjectsTreeView.AfterCheck += VisibleObjectsTreeView_AfterCheck;

        }
        private MapCreationParameters GetParametersFromAppearanceUIValues()
        {
            MapCreationParameters parameters = new MapCreationParameters();

            parameters.ColorDictionary[MapColorObject.Background] = GridBackgroundTextbox.BackColor;
            parameters.ColorDictionary[MapColorObject.GridLines] = GridLinesTextbox.BackColor;
            parameters.ColorDictionary[MapColorObject.PloppedBuilding] = BuildingsTextbox.BackColor;
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
            parameters.SegmentOffsetX = (int)SegmentOffsetNumericUpDown.Value;
            parameters.SegmentOffsetY = (int)SegmentOffsetNumericUpDown.Value;
            parameters.ShowGridLines = ShowGridLinesCheckbox.Checked;
            parameters.ShowZoneOutlines = ShowZoneOutlinesCheckbox.Checked;

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
                        case "TerrainMap":
                            if (objects.Contains(MapObject.TerrainMap))
                            {
                                node.Checked = true;
                            }
                            break;
                    }
                }
            }
        }

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
                        }
                    }
                }
            }

            return objects;
        }

        private void CheckParent(TreeNode parent, bool check)
        {
            if (parent == null)
                return;

            parent.Checked = check;
        }

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

        private void CheckAllParents(TreeNode parent, bool check)
        {
            parent.Checked = check;

            if (parent.Parent != null)
            {
                CheckAllParents(parent.Parent, check);
            }
        }

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

        #region Appearance Group Callbacks

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

        private void BuildingsEditButton_Click(object sender, EventArgs e)
        {
            colorDialog = new ColorDialog();
            colorDialog.Color = BuildingsTextbox.BackColor;
            colorDialog.AllowFullOpen = true;
            colorDialog.FullOpen = true;
            //colorDialog.StartPosition = FormStartPosition.CenterParent;

            if (colorDialog.ShowDialog(this) == DialogResult.OK)
            {
                BuildingsTextbox.BackColor = colorDialog.Color;

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

        private void EditOutputPathButton_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.SelectedPath = OutputPathTextbox.Text;
                if (folderDialog.ShowDialog(this) == DialogResult.OK)
                    OutputPathTextbox.Text = folderDialog.SelectedPath;
            }
        }

        private void RestoreDefaultsButton_Click(object sender, EventArgs e)
        {
            MapCreationParameters pristineParameters = new MapCreationParameters();

            // Copy over the output path
            // TODO: Watch it....
            // TODO: need common method for resetting and setting ui
            pristineParameters.OutputPath = map.Parameters.OutputPath;

            SetAppearanceUIValuesUsingParameters(pristineParameters);
            SetAndUpdateMapCreationParameters(pristineParameters);
        }

        private void GridSegmentSizeNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
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

        private void TerrainLayer1CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            TerrainLayer1AliasTextBox.Enabled = TerrainLayer1CheckBox.Checked;
            TerrainLayer1NumericUpDown.Enabled = TerrainLayer1CheckBox.Checked;
            TerrainLayer1Button.Enabled = TerrainLayer1CheckBox.Checked;

            SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
        }

        private void TerrainLayer2CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            TerrainLayer2AliasTextBox.Enabled = TerrainLayer2CheckBox.Checked;
            TerrainLayer2NumericUpDown.Enabled = TerrainLayer2CheckBox.Checked;
            TerrainLayer2Button.Enabled = TerrainLayer2CheckBox.Checked;

            SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
        }

        private void TerrainLayer3CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            TerrainLayer3AliasTextBox.Enabled = TerrainLayer3CheckBox.Checked;
            TerrainLayer3NumericUpDown.Enabled = TerrainLayer3CheckBox.Checked;
            TerrainLayer3Button.Enabled = TerrainLayer3CheckBox.Checked;

            SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
        }

        private void TerrainLayer4CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            TerrainLayer4AliasTextBox.Enabled = TerrainLayer4CheckBox.Checked;
            TerrainLayer4NumericUpDown.Enabled = TerrainLayer4CheckBox.Checked;
            TerrainLayer4Button.Enabled = TerrainLayer4CheckBox.Checked;

            SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
        }

        private void TerrainLayer5CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            TerrainLayer5AliasTextBox.Enabled = TerrainLayer5CheckBox.Checked;
            TerrainLayer5NumericUpDown.Enabled = TerrainLayer5CheckBox.Checked;
            TerrainLayer5Button.Enabled = TerrainLayer5CheckBox.Checked;

            SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
        }

        private void TerrainLayer6CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            TerrainLayer6AliasTextBox.Enabled = TerrainLayer6CheckBox.Checked;
            TerrainLayer6NumericUpDown.Enabled = TerrainLayer6CheckBox.Checked;
            TerrainLayer6Button.Enabled = TerrainLayer6CheckBox.Checked;

            SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
        }

        private void TerrainLayer7CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            TerrainLayer7AliasTextBox.Enabled = TerrainLayer7CheckBox.Checked;
            TerrainLayer7NumericUpDown.Enabled = TerrainLayer7CheckBox.Checked;
            TerrainLayer7Button.Enabled = TerrainLayer7CheckBox.Checked;

            SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
        }

        private void TerrainLayer8CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            TerrainLayer8AliasTextBox.Enabled = TerrainLayer8CheckBox.Checked;
            TerrainLayer8NumericUpDown.Enabled = TerrainLayer8CheckBox.Checked;
            TerrainLayer8Button.Enabled = TerrainLayer8CheckBox.Checked;

            SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
        }

        private void TerrainLayer9CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            TerrainLayer9AliasTextBox.Enabled = TerrainLayer9CheckBox.Checked;
            TerrainLayer9NumericUpDown.Enabled = TerrainLayer9CheckBox.Checked;
            TerrainLayer9Button.Enabled = TerrainLayer9CheckBox.Checked;

            SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
        }

        private void TerrainLayer10CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            TerrainLayer10AliasTextBox.Enabled = TerrainLayer10CheckBox.Checked;
            TerrainLayer10NumericUpDown.Enabled = TerrainLayer10CheckBox.Checked;
            TerrainLayer10Button.Enabled = TerrainLayer10CheckBox.Checked;

            SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
        }

        private void TerrainLayer11CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            TerrainLayer11AliasTextBox.Enabled = TerrainLayer11CheckBox.Checked;
            TerrainLayer11NumericUpDown.Enabled = TerrainLayer11CheckBox.Checked;
            TerrainLayer11Button.Enabled = TerrainLayer11CheckBox.Checked;

            SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
        }

        private void TerrainLayer12CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            TerrainLayer12AliasTextBox.Enabled = TerrainLayer12CheckBox.Checked;
            TerrainLayer12NumericUpDown.Enabled = TerrainLayer12CheckBox.Checked;
            TerrainLayer12Button.Enabled = TerrainLayer12CheckBox.Checked;

            SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
        }

        private void TerrainLayer13CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            TerrainLayer13AliasTextBox.Enabled = TerrainLayer13CheckBox.Checked;
            TerrainLayer13NumericUpDown.Enabled = TerrainLayer13CheckBox.Checked;
            TerrainLayer13Button.Enabled = TerrainLayer13CheckBox.Checked;

            SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
        }

        private void TerrainLayer14CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            TerrainLayer14AliasTextBox.Enabled = TerrainLayer14CheckBox.Checked;
            TerrainLayer14NumericUpDown.Enabled = TerrainLayer14CheckBox.Checked;
            TerrainLayer14Button.Enabled = TerrainLayer14CheckBox.Checked;

            SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
        }

        private void TerrainLayer15CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            TerrainLayer15AliasTextBox.Enabled = TerrainLayer15CheckBox.Checked;
            TerrainLayer15NumericUpDown.Enabled = TerrainLayer15CheckBox.Checked;
            TerrainLayer15Button.Enabled = TerrainLayer15CheckBox.Checked;

            SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
        }

        private void TerrainLayer16CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            TerrainLayer16AliasTextBox.Enabled = TerrainLayer16CheckBox.Checked;
            TerrainLayer16NumericUpDown.Enabled = TerrainLayer16CheckBox.Checked;
            TerrainLayer16Button.Enabled = TerrainLayer16CheckBox.Checked;

            SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
        }

        private void TerrainLayer17CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            TerrainLayer17AliasTextBox.Enabled = TerrainLayer17CheckBox.Checked;
            TerrainLayer17NumericUpDown.Enabled = TerrainLayer17CheckBox.Checked;
            TerrainLayer17Button.Enabled = TerrainLayer17CheckBox.Checked;

            SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
        }

        private void TerrainLayer18CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            TerrainLayer18AliasTextBox.Enabled = TerrainLayer18CheckBox.Checked;
            TerrainLayer18NumericUpDown.Enabled = TerrainLayer18CheckBox.Checked;
            TerrainLayer18Button.Enabled = TerrainLayer18CheckBox.Checked;

            SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
        }

        private void TerrainLayer19CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            TerrainLayer19AliasTextBox.Enabled = TerrainLayer19CheckBox.Checked;
            TerrainLayer19NumericUpDown.Enabled = TerrainLayer19CheckBox.Checked;
            TerrainLayer19Button.Enabled = TerrainLayer19CheckBox.Checked;

            SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
        }

        private void TerrainLayer20CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            TerrainLayer20AliasTextBox.Enabled = TerrainLayer20CheckBox.Checked;
            TerrainLayer20NumericUpDown.Enabled = TerrainLayer20CheckBox.Checked;
            TerrainLayer20Button.Enabled = TerrainLayer20CheckBox.Checked;

            SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
        }

        private void TerrainLayer21CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            TerrainLayer21AliasTextBox.Enabled = TerrainLayer21CheckBox.Checked;
            TerrainLayer21NumericUpDown.Enabled = TerrainLayer21CheckBox.Checked;
            TerrainLayer21Button.Enabled = TerrainLayer21CheckBox.Checked;

            SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
        }

        private void TerrainLayer22CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            TerrainLayer22AliasTextBox.Enabled = TerrainLayer22CheckBox.Checked;
            TerrainLayer22NumericUpDown.Enabled = TerrainLayer22CheckBox.Checked;
            TerrainLayer22Button.Enabled = TerrainLayer22CheckBox.Checked;

            SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
        }

        private void TerrainLayer23CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            TerrainLayer23AliasTextBox.Enabled = TerrainLayer23CheckBox.Checked;
            TerrainLayer23NumericUpDown.Enabled = TerrainLayer23CheckBox.Checked;
            TerrainLayer23Button.Enabled = TerrainLayer23CheckBox.Checked;

            SetAndUpdateMapCreationParameters(GetParametersFromAppearanceUIValues());
        }

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
    }
}
