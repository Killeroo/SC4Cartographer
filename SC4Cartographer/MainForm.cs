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

using SC4Parser.DataStructures;
using SC4Parser.Files;
using SC4Parser.Types;
using SC4Parser.Subfiles;
using SC4Parser;

namespace SC4CartographerUI
{
    public partial class MainForm : Form
    {
        string RootSimCitySavePath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
            "Documents", 
            "SimCity 4", 
            "Regions");

        private MapCreationParameters mapCreationParameters = new MapCreationParameters();
        private Bitmap previewNormalMapBitmap;
        private Bitmap previewZoomedMapBitmap;
        private bool previewZoomed = false;

        private RichTextBoxLogger logger = null;

        public MainForm()
        {
            InitializeComponent();
            //logger = new RichTextBoxLogger(LogTextBox);
        }

        #region Form functionality

        public void SetMapCreationParameters(MapCreationParameters parameters)
        {
            mapCreationParameters = parameters;
        }

        /// <summary>
        /// Generates and sets preview map image on form
        /// </summary>
        public void GenerateMapPreview()
        {
            // Generate normal preview image
            MapCreationParameters normalMapPreviewParameters = new MapCreationParameters(mapCreationParameters);
            //normalMapPreviewParameters.GridSegmentSize = 5;// 4;
            //normalMapPreviewParameters.SegmentPaddingX = 2;
            //normalMapPreviewParameters.SegmentPaddingY = 2;
            //normalMapPreviewParameters.SegmentOffsetX = 1;
            //normalMapPreviewParameters.SegmentOffsetY = 1;
            previewNormalMapBitmap = MapRenderer.CreateMapBitmap(normalMapPreviewParameters);

            // Generate zoomed preview image
            MapCreationParameters zoomedMapPreviewParameters = new MapCreationParameters(mapCreationParameters);
            zoomedMapPreviewParameters.GridSegmentSize = 10;
            //zoomedMapPreviewParameters.SegmentPaddingX = 4;
            //zoomedMapPreviewParameters.SegmentPaddingY = 4;
            //zoomedMapPreviewParameters.SegmentOffsetX = 2;
            //zoomedMapPreviewParameters.SegmentOffsetY = 2;
            previewZoomedMapBitmap = MapRenderer.CreateMapBitmap(zoomedMapPreviewParameters);

            // If small map, change the picture box to center the image 
            // (we need to switch this back for other maps so the scrollbars appear)
            if (mapCreationParameters.SaveFile.GetRegionViewSubfile().CitySizeX == 64)
            {
                MapPictureBox.SizeMode = PictureBoxSizeMode.CenterImage;
            }
            else
            {
                MapPictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
            }

            // Set image, reset zoom
            MapPictureBox.Image = previewNormalMapBitmap;
            previewZoomed = false;
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
            // Load the save file
            try
            {
                mapCreationParameters.SaveFile = new SC4SaveFile(path);
            }
            catch (DBPFParsingException e)
            {
                var errorForm = new MapErrorForm(
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
                mapCreationParameters.SaveFile.GetLotSubfile();
            }
            catch (SubfileNotFoundException e)
            {
                var errorForm = new MapErrorForm(
                    "Error loading save game",
                    $"Could not create map for '{Path.GetFileName(path)}'. Could not load zone data or it does not exist.",
                    e,
                    true);

                errorForm.StartPosition = FormStartPosition.CenterParent;
                errorForm.ShowDialog();

                return;
            }
                
            try
            {
                // Generate and set map preview images
                GenerateMapPreview();
            }
            catch (SubfileNotFoundException e)
            {
                var errorForm = new MapErrorForm(
                    "Error creating preview",
                    $"Could not create preview map for '{Path.GetFileName(path)}'.",
                    e,
                    true);

                errorForm.StartPosition = FormStartPosition.CenterParent;
                errorForm.ShowDialog();

                return;
            }


            // Set window title
            this.Text = "SC4Cartographer - '" + Path.GetFileName(path) + "'";
                
            EnableSaveButtons();

            // Call garbage collector to cleanup anything left over from last load
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        public string GenerateDefaultMapFilename()
        {
            string savefile = Path.GetFileNameWithoutExtension(mapCreationParameters.SaveFile.FilePath);
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
            switch (mapCreationParameters.OutputFormat)
            {
                case OutFormat.PNG:
                    extension = ".png";
                    break;
                case OutFormat.JPEG:
                    extension = ".jpg";
                    break;
            }

            // Yeah this is hacky, sue me.
            string currentFilename = filePath + extension;
            bool goodFilename = false;
            int counter = 0;
            while (goodFilename == false)
            {
                if (File.Exists(currentFilename))
                {
                    counter++;
                    currentFilename = filePath + $"({counter})" + extension;
                }
                else
                {
                    goodFilename = true;
                }
            }

            try
            {
                // Get the bitmap (this time we actually generate it from what the user inputted
                // not what we needed when we were generating the preview)
                Bitmap outBitmap = MapRenderer.CreateMapBitmap(mapCreationParameters);

                // Actually save out the image
                switch (mapCreationParameters.OutputFormat)
                {
                    case OutFormat.PNG:
                        outBitmap.Save(currentFilename, ImageFormat.Png);
                        break;
                    case OutFormat.JPEG:
                        outBitmap.Save(currentFilename, ImageFormat.Jpeg);
                        break;
                }

                // Show form when successfully created
                var mapCreatedForm = new MapCreatedForm(Path.GetDirectoryName(currentFilename), Path.GetFileName(currentFilename));
                mapCreatedForm.StartPosition = FormStartPosition.CenterParent;
                mapCreatedForm.ShowDialog();

            }
            catch (Exception e)
            {
                var errorForm = new MapErrorForm(
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

        /// <summary>
        /// Switch between zoomed and normal images
        /// </summary>
        public void TogglePreviewImage()
        {
            previewZoomed = !previewZoomed;

            if (previewZoomed)
            {
                MapPictureBox.Image = previewZoomedMapBitmap;
            }
            else
            {
                MapPictureBox.Image = previewNormalMapBitmap;
            }
        }

        /// <summary>
        /// We don't want these buttons to be enabled when nothing is loaded
        /// </summary>
        private void EnableSaveButtons()
        {
            saveToolStripMenuItem.Enabled = true;
            saveAsToolStripMenuItem.Enabled = true;
            AppearanceButton.Enabled = true;
            SaveButton.Enabled = true;
            mapAppearanceToolStripMenuItem.Enabled = true;

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
                    MessageBox.Show(ex.Message, "DirectoryLister", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
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

        #endregion

        #region UI Event Callbacks

        private void SaveButton_Click(object sender, EventArgs e)
        {
            string name = GenerateDefaultMapFilename();
            SaveMap(mapCreationParameters.OutputPath, name);
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
            mapCreationParameters.OutputPath = Directory.GetCurrentDirectory();

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
                    MessageBox.Show(ex.Message, "DirectoryLister", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
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
                            MessageBox.Show(ex.Message, "DirectoryLister", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
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
            var propertiesForm = new PropertiesForm(mapCreationParameters, this);
            propertiesForm.StartPosition = FormStartPosition.CenterParent;
            propertiesForm.ShowDialog();

            // Generate map again
            LoadSaveGame(mapCreationParameters.SaveFile.FilePath);
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
            SaveMap(mapCreationParameters.OutputPath, name);
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
                fileDialog.Title = "Load Simcity 4 save game";
                fileDialog.InitialDirectory = SavePathTextbox.Text;
                fileDialog.RestoreDirectory = true;
                fileDialog.CheckFileExists = true;
                fileDialog.CheckPathExists = true;
                fileDialog.Filter = "Simcity 4 save files (*.sc4)|*.sc4";
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
        private void mapAppearanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var propertiesForm = new PropertiesForm(mapCreationParameters, this);
            propertiesForm.StartPosition = FormStartPosition.CenterParent;
            propertiesForm.ShowDialog();

            // Generate map again
            LoadSaveGame(mapCreationParameters.SaveFile.FilePath);
        }

        private void reportABugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Version v = Assembly.GetExecutingAssembly().GetName().Version;
            string version = Assembly.GetExecutingAssembly().GetName().Name + " v" + v.Major + "." + v.Minor + "." + v.Build + " (r" + v.Revision + ") ";
            version = version.Replace(' ', '+');

            string issueLink = @"https://github.com/killeroo/SC4Cartographer/issues/new?body=%0A%0A%0A---------%0A" + version;
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

        #endregion

    }
}
