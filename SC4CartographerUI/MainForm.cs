using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using SC4Parser.DataStructures;
using SC4Parser.Files;
using SC4Parser.Types;
using SC4Parser.Subfiles;

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

        private RichTextBoxLogger logger = null;

        public MainForm()
        {
            InitializeComponent();
            logger = new RichTextBoxLogger(LogTextBox);
        }

        public void SetMapCreationParameters(MapCreationParameters parameters)
        {
            mapCreationParameters = parameters;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            //MapPictureBox.Image = Image.FromFile("TestPoster.png");
        }

        /// <summary>
        /// When main form loads
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            //logger = new RichTextBoxLogger(LogTextBox);
            if (Directory.Exists(RootSimCitySavePath))
            {
                SavePathTextbox.Text = RootSimCitySavePath;
                string test = FindRandomSavegameFileInPath(RootSimCitySavePath);

                LogTextBox.AppendText(test);//Path.GetFileName(@"C:\Users\Shadowfax\Documents\SimCity 4\Regions\London\City - Luxuria.sc4"));
                mapCreationParameters.SaveFile = new SC4SaveFile(test);// @"C:\Users\Shadowfax\Documents\SimCity 4\Regions\London\City - Luxuria.sc4");
                mapCreationParameters.SaveFilePath = test;

                // TODO: Need a way to work out city size
                Bitmap mapBitmap = MapRenderer.CreateMapBitmap(mapCreationParameters);
            https://stackoverflow.com/a/10916023

                MapPictureBox.Image = mapBitmap;

            }
            else
            {
                SavePathTextbox.Text = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
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

                // Only show files with sc4 extension and don't show cities that haven't been
                // founded yet
                if (!file.Contains("City - New City (")
                    && file.Contains(".sc4"))
                {
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

                        // Only show files with sc4 extension and don't show cities that haven't been
                        // founded yet
                        if (!file.Contains("City - New City (")
                            && file.Contains(".sc4"))
                        {
                            // Add to node
                            e.Node.Nodes.Add(node);
                        }
                    }
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

        private void LogTextBox_TextChanged(object sender, EventArgs e)
        {
            // Set caret position to end of current text
            LogTextBox.SelectionStart = LogTextBox.Text.Length;

            // Scroll to bottom automatically
            //LogTextBox.ScrollToCaret();
        }

        private void PropertiesButton_Click(object sender, EventArgs e)
        {
            var propertiesForm = new PropertiesForm(mapCreationParameters, this);
            propertiesForm.StartPosition = FormStartPosition.CenterParent;
            propertiesForm.ShowDialog();
        }
    }
}
