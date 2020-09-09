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
            this.MapPictureBox = new System.Windows.Forms.PictureBox();
            this.SaveButton = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.FileBrowserButton = new System.Windows.Forms.Button();
            this.SavePathTextbox = new System.Windows.Forms.TextBox();
            this.FileTreeView = new System.Windows.Forms.TreeView();
            this.FileTreeViewImageList = new System.Windows.Forms.ImageList(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadSC4SaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PropertiesButton = new System.Windows.Forms.Button();
            this.LogTextBox = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MapPictureBox)).BeginInit();
            this.groupBox6.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.MapPictureBox);
            this.groupBox1.Location = new System.Drawing.Point(204, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(580, 616);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Preview";
            // 
            // MapPictureBox
            // 
            this.MapPictureBox.Location = new System.Drawing.Point(6, 19);
            this.MapPictureBox.Name = "MapPictureBox";
            this.MapPictureBox.Size = new System.Drawing.Size(568, 591);
            this.MapPictureBox.TabIndex = 1;
            this.MapPictureBox.TabStop = false;
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(660, 648);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(124, 23);
            this.SaveButton.TabIndex = 0;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.FileBrowserButton);
            this.groupBox6.Controls.Add(this.SavePathTextbox);
            this.groupBox6.Controls.Add(this.FileTreeView);
            this.groupBox6.Location = new System.Drawing.Point(12, 26);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(186, 645);
            this.groupBox6.TabIndex = 0;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Save games";
            // 
            // FileBrowserButton
            // 
            this.FileBrowserButton.Location = new System.Drawing.Point(155, 20);
            this.FileBrowserButton.Name = "FileBrowserButton";
            this.FileBrowserButton.Size = new System.Drawing.Size(25, 20);
            this.FileBrowserButton.TabIndex = 3;
            this.FileBrowserButton.Text = "...";
            this.FileBrowserButton.UseVisualStyleBackColor = true;
            // 
            // SavePathTextbox
            // 
            this.SavePathTextbox.Location = new System.Drawing.Point(7, 20);
            this.SavePathTextbox.Name = "SavePathTextbox";
            this.SavePathTextbox.Size = new System.Drawing.Size(142, 20);
            this.SavePathTextbox.TabIndex = 1;
            this.SavePathTextbox.TextChanged += new System.EventHandler(this.SavePathTextbox_TextChanged);
            // 
            // FileTreeView
            // 
            this.FileTreeView.ImageIndex = 0;
            this.FileTreeView.ImageList = this.FileTreeViewImageList;
            this.FileTreeView.Location = new System.Drawing.Point(6, 42);
            this.FileTreeView.Name = "FileTreeView";
            this.FileTreeView.SelectedImageIndex = 0;
            this.FileTreeView.Size = new System.Drawing.Size(174, 597);
            this.FileTreeView.TabIndex = 0;
            this.FileTreeView.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.FileTreeView_BeforeExpand);
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
            this.menuStrip1.Size = new System.Drawing.Size(798, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.loadSC4SaveToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.newToolStripMenuItem.Text = "New";
            // 
            // loadSC4SaveToolStripMenuItem
            // 
            this.loadSC4SaveToolStripMenuItem.Name = "loadSC4SaveToolStripMenuItem";
            this.loadSC4SaveToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.loadSC4SaveToolStripMenuItem.Text = "Load SC4 Save..";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.saveAsToolStripMenuItem.Text = "Save As...";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(153, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.editToolStripMenuItem.Text = "About";
            // 
            // PropertiesButton
            // 
            this.PropertiesButton.Location = new System.Drawing.Point(530, 648);
            this.PropertiesButton.Name = "PropertiesButton";
            this.PropertiesButton.Size = new System.Drawing.Size(124, 23);
            this.PropertiesButton.TabIndex = 9;
            this.PropertiesButton.Text = "Properties";
            this.PropertiesButton.UseVisualStyleBackColor = true;
            // 
            // LogTextBox
            // 
            this.LogTextBox.Location = new System.Drawing.Point(12, 677);
            this.LogTextBox.Name = "LogTextBox";
            this.LogTextBox.Size = new System.Drawing.Size(772, 160);
            this.LogTextBox.TabIndex = 10;
            this.LogTextBox.Text = "";
            this.LogTextBox.TextChanged += new System.EventHandler(this.LogTextBox_TextChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 849);
            this.Controls.Add(this.LogTextBox);
            this.Controls.Add(this.PropertiesButton);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "SC4Cartographer";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
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
        private System.Windows.Forms.PictureBox MapPictureBox;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button FileBrowserButton;
        private System.Windows.Forms.TextBox SavePathTextbox;
        private System.Windows.Forms.TreeView FileTreeView;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadSC4SaveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.Button PropertiesButton;
        private System.Windows.Forms.ImageList FileTreeViewImageList;
        private System.Windows.Forms.RichTextBox LogTextBox;
    }
}

