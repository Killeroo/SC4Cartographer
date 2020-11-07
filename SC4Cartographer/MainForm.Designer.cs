namespace SC4CartographerUI
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.OpenTextLabel = new System.Windows.Forms.Label();
            this.MapPictureBox = new System.Windows.Forms.PictureBox();
            this.SaveButton = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.FilterNewCitiesCheckbox = new System.Windows.Forms.CheckBox();
            this.FileBrowserButton = new System.Windows.Forms.Button();
            this.SavePathTextbox = new System.Windows.Forms.TextBox();
            this.FileTreeView = new System.Windows.Forms.TreeView();
            this.FileTreeViewImageList = new System.Windows.Forms.ImageList(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadSC4SaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.savegameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.folderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AppearanceButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MapPictureBox)).BeginInit();
            this.groupBox6.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Location = new System.Drawing.Point(204, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(671, 685);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Preview";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.OpenTextLabel);
            this.panel1.Controls.Add(this.MapPictureBox);
            this.panel1.Location = new System.Drawing.Point(6, 20);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(659, 659);
            this.panel1.TabIndex = 2;
            // 
            // OpenTextLabel
            // 
            this.OpenTextLabel.AutoSize = true;
            this.OpenTextLabel.Location = new System.Drawing.Point(153, 294);
            this.OpenTextLabel.Name = "OpenTextLabel";
            this.OpenTextLabel.Size = new System.Drawing.Size(400, 13);
            this.OpenTextLabel.TabIndex = 3;
            this.OpenTextLabel.Text = "Open a save game from the left hand side or by going to File -> Open -> Save game" +
    "";
            // 
            // MapPictureBox
            // 
            this.MapPictureBox.Cursor = System.Windows.Forms.Cursors.Cross;
            this.MapPictureBox.Location = new System.Drawing.Point(3, 3);
            this.MapPictureBox.Name = "MapPictureBox";
            this.MapPictureBox.Size = new System.Drawing.Size(653, 653);
            this.MapPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.MapPictureBox.TabIndex = 2;
            this.MapPictureBox.TabStop = false;
            this.MapPictureBox.Click += new System.EventHandler(this.MapPictureBox_Clicked);
            // 
            // SaveButton
            // 
            this.SaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveButton.Enabled = false;
            this.SaveButton.Location = new System.Drawing.Point(751, 717);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(124, 23);
            this.SaveButton.TabIndex = 0;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox6.Controls.Add(this.FilterNewCitiesCheckbox);
            this.groupBox6.Controls.Add(this.FileBrowserButton);
            this.groupBox6.Controls.Add(this.SavePathTextbox);
            this.groupBox6.Controls.Add(this.FileTreeView);
            this.groupBox6.Location = new System.Drawing.Point(12, 26);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(186, 685);
            this.groupBox6.TabIndex = 0;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Save games";
            // 
            // FilterNewCitiesCheckbox
            // 
            this.FilterNewCitiesCheckbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.FilterNewCitiesCheckbox.AutoSize = true;
            this.FilterNewCitiesCheckbox.Checked = true;
            this.FilterNewCitiesCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.FilterNewCitiesCheckbox.Location = new System.Drawing.Point(7, 662);
            this.FilterNewCitiesCheckbox.Name = "FilterNewCitiesCheckbox";
            this.FilterNewCitiesCheckbox.Size = new System.Drawing.Size(144, 17);
            this.FilterNewCitiesCheckbox.TabIndex = 4;
            this.FilterNewCitiesCheckbox.Text = "Filter \'New City\' save files";
            this.FilterNewCitiesCheckbox.UseVisualStyleBackColor = true;
            this.FilterNewCitiesCheckbox.CheckedChanged += new System.EventHandler(this.FilterNewCitiesCheckbox_CheckedChanged);
            // 
            // FileBrowserButton
            // 
            this.FileBrowserButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FileBrowserButton.Location = new System.Drawing.Point(155, 20);
            this.FileBrowserButton.Name = "FileBrowserButton";
            this.FileBrowserButton.Size = new System.Drawing.Size(25, 20);
            this.FileBrowserButton.TabIndex = 3;
            this.FileBrowserButton.Text = "...";
            this.FileBrowserButton.UseVisualStyleBackColor = true;
            this.FileBrowserButton.Click += new System.EventHandler(this.FileBrowserButton_Click);
            // 
            // SavePathTextbox
            // 
            this.SavePathTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SavePathTextbox.Location = new System.Drawing.Point(7, 20);
            this.SavePathTextbox.Name = "SavePathTextbox";
            this.SavePathTextbox.Size = new System.Drawing.Size(142, 20);
            this.SavePathTextbox.TabIndex = 1;
            this.SavePathTextbox.TextChanged += new System.EventHandler(this.SavePathTextbox_TextChanged);
            // 
            // FileTreeView
            // 
            this.FileTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FileTreeView.ImageIndex = 0;
            this.FileTreeView.ImageList = this.FileTreeViewImageList;
            this.FileTreeView.Location = new System.Drawing.Point(7, 46);
            this.FileTreeView.Name = "FileTreeView";
            this.FileTreeView.SelectedImageIndex = 0;
            this.FileTreeView.Size = new System.Drawing.Size(174, 610);
            this.FileTreeView.TabIndex = 0;
            this.FileTreeView.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.FileTreeView_BeforeExpand);
            this.FileTreeView.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.FileTreeView_OnNodeMouseDoubleClick);
            // 
            // FileTreeViewImageList
            // 
            this.FileTreeViewImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("FileTreeViewImageList.ImageStream")));
            this.FileTreeViewImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.FileTreeViewImageList.Images.SetKeyName(0, "1346238561_folder_classic.png");
            this.FileTreeViewImageList.Images.SetKeyName(1, "1346238604_folder_classic_opened.png");
            this.FileTreeViewImageList.Images.SetKeyName(2, "1346228331_drive.png");
            this.FileTreeViewImageList.Images.SetKeyName(3, "1346228337_drive_cd.png");
            this.FileTreeViewImageList.Images.SetKeyName(4, "1346228356_drive_cd_empty.png");
            this.FileTreeViewImageList.Images.SetKeyName(5, "1346228364_drive_disk.png");
            this.FileTreeViewImageList.Images.SetKeyName(6, "1346228591_drive_network.png");
            this.FileTreeViewImageList.Images.SetKeyName(7, "1346228618_drive_link.png");
            this.FileTreeViewImageList.Images.SetKeyName(8, "1346228623_drive_error.png");
            this.FileTreeViewImageList.Images.SetKeyName(9, "1346228633_drive_go.png");
            this.FileTreeViewImageList.Images.SetKeyName(10, "1346228636_drive_delete.png");
            this.FileTreeViewImageList.Images.SetKeyName(11, "1346228639_drive_burn.png");
            this.FileTreeViewImageList.Images.SetKeyName(12, "1346238642_folder_classic_locked.png");
            this.FileTreeViewImageList.Images.SetKeyName(13, "file.png");
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(887, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadSC4SaveToolStripMenuItem,
            this.toolStripMenuItem1,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadSC4SaveToolStripMenuItem
            // 
            this.loadSC4SaveToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.savegameToolStripMenuItem,
            this.folderToolStripMenuItem});
            this.loadSC4SaveToolStripMenuItem.Name = "loadSC4SaveToolStripMenuItem";
            this.loadSC4SaveToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.loadSC4SaveToolStripMenuItem.Text = "Open..";
            // 
            // savegameToolStripMenuItem
            // 
            this.savegameToolStripMenuItem.Name = "savegameToolStripMenuItem";
            this.savegameToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.savegameToolStripMenuItem.Text = "Save game";
            this.savegameToolStripMenuItem.Click += new System.EventHandler(this.savegameToolStripMenuItem_Click);
            // 
            // folderToolStripMenuItem
            // 
            this.folderToolStripMenuItem.Name = "folderToolStripMenuItem";
            this.folderToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.folderToolStripMenuItem.Text = "Folder";
            this.folderToolStripMenuItem.Click += new System.EventHandler(this.folderToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(120, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Enabled = false;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Enabled = false;
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.saveAsToolStripMenuItem.Text = "Save As...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(120, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.editToolStripMenuItem.Text = "About";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // AppearanceButton
            // 
            this.AppearanceButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AppearanceButton.Enabled = false;
            this.AppearanceButton.Location = new System.Drawing.Point(621, 717);
            this.AppearanceButton.Name = "AppearanceButton";
            this.AppearanceButton.Size = new System.Drawing.Size(124, 23);
            this.AppearanceButton.TabIndex = 9;
            this.AppearanceButton.Text = "Appearance";
            this.AppearanceButton.UseVisualStyleBackColor = true;
            this.AppearanceButton.Click += new System.EventHandler(this.PropertiesButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(444, 712);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(887, 747);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.AppearanceButton);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "SC4Cartographer";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MapPictureBox)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button FileBrowserButton;
        private System.Windows.Forms.TextBox SavePathTextbox;
        private System.Windows.Forms.TreeView FileTreeView;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadSC4SaveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.Button AppearanceButton;
        private System.Windows.Forms.ImageList FileTreeViewImageList;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox MapPictureBox;
        private System.Windows.Forms.CheckBox FilterNewCitiesCheckbox;
        private System.Windows.Forms.ToolStripMenuItem savegameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem folderToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Label OpenTextLabel;
        private System.Windows.Forms.Button button1;
    }
}

