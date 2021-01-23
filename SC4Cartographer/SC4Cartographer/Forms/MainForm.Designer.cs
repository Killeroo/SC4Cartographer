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
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("Terrain");
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("Low Density");
            System.Windows.Forms.TreeNode treeNode23 = new System.Windows.Forms.TreeNode("Medium Density");
            System.Windows.Forms.TreeNode treeNode24 = new System.Windows.Forms.TreeNode("High Density");
            System.Windows.Forms.TreeNode treeNode25 = new System.Windows.Forms.TreeNode("Residential", new System.Windows.Forms.TreeNode[] {
            treeNode22,
            treeNode23,
            treeNode24});
            System.Windows.Forms.TreeNode treeNode26 = new System.Windows.Forms.TreeNode("Low Density");
            System.Windows.Forms.TreeNode treeNode27 = new System.Windows.Forms.TreeNode("Medium Density");
            System.Windows.Forms.TreeNode treeNode28 = new System.Windows.Forms.TreeNode("High Density");
            System.Windows.Forms.TreeNode treeNode29 = new System.Windows.Forms.TreeNode("Commercial", new System.Windows.Forms.TreeNode[] {
            treeNode26,
            treeNode27,
            treeNode28});
            System.Windows.Forms.TreeNode treeNode30 = new System.Windows.Forms.TreeNode("Low Density");
            System.Windows.Forms.TreeNode treeNode31 = new System.Windows.Forms.TreeNode("Medium Density");
            System.Windows.Forms.TreeNode treeNode32 = new System.Windows.Forms.TreeNode("High Density");
            System.Windows.Forms.TreeNode treeNode33 = new System.Windows.Forms.TreeNode("Industrial", new System.Windows.Forms.TreeNode[] {
            treeNode30,
            treeNode31,
            treeNode32});
            System.Windows.Forms.TreeNode treeNode34 = new System.Windows.Forms.TreeNode("Plopped Building");
            System.Windows.Forms.TreeNode treeNode35 = new System.Windows.Forms.TreeNode("Military");
            System.Windows.Forms.TreeNode treeNode36 = new System.Windows.Forms.TreeNode("Airports");
            System.Windows.Forms.TreeNode treeNode37 = new System.Windows.Forms.TreeNode("Seaport");
            System.Windows.Forms.TreeNode treeNode38 = new System.Windows.Forms.TreeNode("Spaceport");
            System.Windows.Forms.TreeNode treeNode39 = new System.Windows.Forms.TreeNode("Other", new System.Windows.Forms.TreeNode[] {
            treeNode34,
            treeNode35,
            treeNode36,
            treeNode37,
            treeNode38});
            System.Windows.Forms.TreeNode treeNode40 = new System.Windows.Forms.TreeNode("Zones", new System.Windows.Forms.TreeNode[] {
            treeNode25,
            treeNode29,
            treeNode33,
            treeNode39});
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
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.UpdatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.MapSizeToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.MemoryUsedToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.MousePositionToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.AppearanceGroupBox = new System.Windows.Forms.GroupBox();
            this.label33 = new System.Windows.Forms.Label();
            this.JPEGRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.PNGRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.EditOutputPathButton = new System.Windows.Forms.Button();
            this.label39 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.OutputPathTextbox = new System.Windows.Forms.TextBox();
            this.label40 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.ShowZoneOutlinesCheckbox = new System.Windows.Forms.CheckBox();
            this.SegmentOffsetNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.SegmentPaddingNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.GridSegmentSizeNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label34 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.ShowGridLinesCheckbox = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.IndustrialZoneLowEditButton = new System.Windows.Forms.Button();
            this.IndustrialZoneMidEditButton = new System.Windows.Forms.Button();
            this.IndustrialZoneHighEditButton = new System.Windows.Forms.Button();
            this.CommercialZoneHighEditButton = new System.Windows.Forms.Button();
            this.CommercialZoneMidEditButton = new System.Windows.Forms.Button();
            this.IndustrialZoneMidTextbox = new System.Windows.Forms.TextBox();
            this.CommercialZoneLowEditButton = new System.Windows.Forms.Button();
            this.IndustrialZoneHighTextbox = new System.Windows.Forms.TextBox();
            this.CommercialZoneMidTextbox = new System.Windows.Forms.TextBox();
            this.CommercialZoneHighTextbox = new System.Windows.Forms.TextBox();
            this.IndustrialZoneLowTextbox = new System.Windows.Forms.TextBox();
            this.CommercialZoneLowTextbox = new System.Windows.Forms.TextBox();
            this.ResidentialZoneLowEditButton = new System.Windows.Forms.Button();
            this.ResidentialZoneHighEditButton = new System.Windows.Forms.Button();
            this.ResidentialZoneMidEditButton = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.ResidentialZoneHighTextbox = new System.Windows.Forms.TextBox();
            this.ResidentialZoneMidTextbox = new System.Windows.Forms.TextBox();
            this.ResidentialZoneLowTextbox = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.SpaceportEditButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SpaceportTextbox = new System.Windows.Forms.TextBox();
            this.SeaportsEditButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SeaportTextbox = new System.Windows.Forms.TextBox();
            this.AirportsEditButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.AirportsTextbox = new System.Windows.Forms.TextBox();
            this.MilitaryEditButton = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.MilitaryTextbox = new System.Windows.Forms.TextBox();
            this.ZoneOutlinesEditButton = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.ZoneOutlinesTextbox = new System.Windows.Forms.TextBox();
            this.GridLinesEditTextbox = new System.Windows.Forms.Button();
            this.BuildingsEditButton = new System.Windows.Forms.Button();
            this.GridBackgroundEditButton = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.BuildingsTextbox = new System.Windows.Forms.TextBox();
            this.GridLinesTextbox = new System.Windows.Forms.TextBox();
            this.GridBackgroundTextbox = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.button11 = new System.Windows.Forms.Button();
            this.label47 = new System.Windows.Forms.Label();
            this.textBox14 = new System.Windows.Forms.TextBox();
            this.button10 = new System.Windows.Forms.Button();
            this.label46 = new System.Windows.Forms.Label();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.button9 = new System.Windows.Forms.Button();
            this.label45 = new System.Windows.Forms.Label();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.button8 = new System.Windows.Forms.Button();
            this.label44 = new System.Windows.Forms.Label();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.button7 = new System.Windows.Forms.Button();
            this.label43 = new System.Windows.Forms.Label();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.label42 = new System.Windows.Forms.Label();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.label41 = new System.Windows.Forms.Label();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.label30 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.numericUpDown18 = new System.Windows.Forms.NumericUpDown();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.numericUpDown17 = new System.Windows.Forms.NumericUpDown();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.numericUpDown16 = new System.Windows.Forms.NumericUpDown();
            this.textBox32 = new System.Windows.Forms.TextBox();
            this.button29 = new System.Windows.Forms.Button();
            this.textBox29 = new System.Windows.Forms.TextBox();
            this.numericUpDown13 = new System.Windows.Forms.NumericUpDown();
            this.button30 = new System.Windows.Forms.Button();
            this.textBox30 = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.numericUpDown14 = new System.Windows.Forms.NumericUpDown();
            this.button31 = new System.Windows.Forms.Button();
            this.textBox31 = new System.Windows.Forms.TextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.numericUpDown15 = new System.Windows.Forms.NumericUpDown();
            this.button26 = new System.Windows.Forms.Button();
            this.textBox26 = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.numericUpDown10 = new System.Windows.Forms.NumericUpDown();
            this.button27 = new System.Windows.Forms.Button();
            this.textBox27 = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.numericUpDown11 = new System.Windows.Forms.NumericUpDown();
            this.button28 = new System.Windows.Forms.Button();
            this.textBox28 = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.numericUpDown12 = new System.Windows.Forms.NumericUpDown();
            this.button23 = new System.Windows.Forms.Button();
            this.textBox23 = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.numericUpDown7 = new System.Windows.Forms.NumericUpDown();
            this.button24 = new System.Windows.Forms.Button();
            this.textBox24 = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.numericUpDown8 = new System.Windows.Forms.NumericUpDown();
            this.button25 = new System.Windows.Forms.Button();
            this.textBox25 = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.numericUpDown9 = new System.Windows.Forms.NumericUpDown();
            this.button20 = new System.Windows.Forms.Button();
            this.textBox20 = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.numericUpDown4 = new System.Windows.Forms.NumericUpDown();
            this.button21 = new System.Windows.Forms.Button();
            this.textBox21 = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.numericUpDown5 = new System.Windows.Forms.NumericUpDown();
            this.button22 = new System.Windows.Forms.Button();
            this.textBox22 = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.numericUpDown6 = new System.Windows.Forms.NumericUpDown();
            this.button19 = new System.Windows.Forms.Button();
            this.textBox19 = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.button18 = new System.Windows.Forms.Button();
            this.textBox18 = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.button17 = new System.Windows.Forms.Button();
            this.textBox17 = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.VisibleObjectsTreeView = new System.Windows.Forms.TreeView();
            this.RestoreDefaultsButton = new System.Windows.Forms.Button();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MapPictureBox)).BeginInit();
            this.groupBox6.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.AppearanceGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SegmentOffsetNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SegmentPaddingNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridSegmentSizeNumericUpDown)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
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
            this.groupBox1.Size = new System.Drawing.Size(665, 682);
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
            this.panel1.Size = new System.Drawing.Size(653, 656);
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
            this.MapPictureBox.Location = new System.Drawing.Point(0, 0);
            this.MapPictureBox.Name = "MapPictureBox";
            this.MapPictureBox.Size = new System.Drawing.Size(653, 651);
            this.MapPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.MapPictureBox.TabIndex = 2;
            this.MapPictureBox.TabStop = false;
            this.MapPictureBox.Click += new System.EventHandler(this.MapPictureBox_Clicked);
            this.MapPictureBox.MouseLeave += new System.EventHandler(this.MapPictureBox_MouseLeave);
            this.MapPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MapPictureBox_MouseMove);
            // 
            // SaveButton
            // 
            this.SaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveButton.Enabled = false;
            this.SaveButton.Location = new System.Drawing.Point(744, 714);
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
            this.groupBox6.Size = new System.Drawing.Size(186, 715);
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
            this.FilterNewCitiesCheckbox.Location = new System.Drawing.Point(7, 692);
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
            this.FileTreeView.Size = new System.Drawing.Size(174, 640);
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
            this.toolStripMenuItem2});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1182, 24);
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
            this.toolStripSeparator2,
            this.toolStripMenuItem8,
            this.toolStripMenuItem7,
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
            this.loadSC4SaveToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
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
            this.toolStripMenuItem1.Size = new System.Drawing.Size(190, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Enabled = false;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Enabled = false;
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.saveAsToolStripMenuItem.Text = "Save As...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(190, 6);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(193, 22);
            this.toolStripMenuItem8.Text = "Save Map Appearance";
            this.toolStripMenuItem8.Click += new System.EventHandler(this.toolStripMenuItem8_Click);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(193, 22);
            this.toolStripMenuItem7.Text = "Load Map Appearance";
            this.toolStripMenuItem7.Click += new System.EventHandler(this.toolStripMenuItem7_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(190, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UpdatesToolStripMenuItem,
            this.toolStripSeparator4,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.toolStripSeparator5,
            this.toolStripMenuItem6,
            this.toolStripSeparator3,
            this.toolStripMenuItem5});
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(44, 20);
            this.toolStripMenuItem2.Text = "Help";
            // 
            // UpdatesToolStripMenuItem
            // 
            this.UpdatesToolStripMenuItem.Name = "UpdatesToolStripMenuItem";
            this.UpdatesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.UpdatesToolStripMenuItem.Text = "Check for Updates";
            this.UpdatesToolStripMenuItem.Click += new System.EventHandler(this.UpdatesToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(177, 6);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem3.Text = "Project Webpage";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.projectWebpageToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem4.Text = "Report an Issue";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.reportABugToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(177, 6);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem6.Text = "Show Log...";
            this.toolStripMenuItem6.Click += new System.EventHandler(this.toolStripMenuItem6_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(177, 6);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem5.Text = "About";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MapSizeToolStripStatusLabel,
            this.MemoryUsedToolStripStatusLabel,
            this.MousePositionToolStripStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 744);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1182, 24);
            this.statusStrip1.TabIndex = 10;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // MapSizeToolStripStatusLabel
            // 
            this.MapSizeToolStripStatusLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)));
            this.MapSizeToolStripStatusLabel.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.MapSizeToolStripStatusLabel.Name = "MapSizeToolStripStatusLabel";
            this.MapSizeToolStripStatusLabel.Size = new System.Drawing.Size(68, 19);
            this.MapSizeToolStripStatusLabel.Text = "Size: 0x0px";
            this.MapSizeToolStripStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MemoryUsedToolStripStatusLabel
            // 
            this.MemoryUsedToolStripStatusLabel.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.MemoryUsedToolStripStatusLabel.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.MemoryUsedToolStripStatusLabel.Name = "MemoryUsedToolStripStatusLabel";
            this.MemoryUsedToolStripStatusLabel.Size = new System.Drawing.Size(121, 19);
            this.MemoryUsedToolStripStatusLabel.Text = "Memory Usage: 0mb";
            // 
            // MousePositionToolStripStatusLabel
            // 
            this.MousePositionToolStripStatusLabel.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.MousePositionToolStripStatusLabel.Name = "MousePositionToolStripStatusLabel";
            this.MousePositionToolStripStatusLabel.Size = new System.Drawing.Size(12, 19);
            this.MousePositionToolStripStatusLabel.Text = "-";
            this.MousePositionToolStripStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AppearanceGroupBox
            // 
            this.AppearanceGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AppearanceGroupBox.Controls.Add(this.label33);
            this.AppearanceGroupBox.Controls.Add(this.JPEGRadioButton);
            this.AppearanceGroupBox.Controls.Add(this.groupBox5);
            this.AppearanceGroupBox.Controls.Add(this.PNGRadioButton);
            this.AppearanceGroupBox.Controls.Add(this.groupBox4);
            this.AppearanceGroupBox.Controls.Add(this.groupBox3);
            this.AppearanceGroupBox.Controls.Add(this.EditOutputPathButton);
            this.AppearanceGroupBox.Controls.Add(this.label39);
            this.AppearanceGroupBox.Controls.Add(this.label38);
            this.AppearanceGroupBox.Controls.Add(this.OutputPathTextbox);
            this.AppearanceGroupBox.Controls.Add(this.label40);
            this.AppearanceGroupBox.Controls.Add(this.label37);
            this.AppearanceGroupBox.Controls.Add(this.ShowZoneOutlinesCheckbox);
            this.AppearanceGroupBox.Controls.Add(this.SegmentOffsetNumericUpDown);
            this.AppearanceGroupBox.Controls.Add(this.SegmentPaddingNumericUpDown);
            this.AppearanceGroupBox.Controls.Add(this.GridSegmentSizeNumericUpDown);
            this.AppearanceGroupBox.Controls.Add(this.label34);
            this.AppearanceGroupBox.Controls.Add(this.label35);
            this.AppearanceGroupBox.Controls.Add(this.label36);
            this.AppearanceGroupBox.Controls.Add(this.ShowGridLinesCheckbox);
            this.AppearanceGroupBox.Controls.Add(this.tabControl1);
            this.AppearanceGroupBox.Controls.Add(this.VisibleObjectsTreeView);
            this.AppearanceGroupBox.Location = new System.Drawing.Point(875, 27);
            this.AppearanceGroupBox.Name = "AppearanceGroupBox";
            this.AppearanceGroupBox.Size = new System.Drawing.Size(295, 714);
            this.AppearanceGroupBox.TabIndex = 11;
            this.AppearanceGroupBox.TabStop = false;
            this.AppearanceGroupBox.Text = "Appearance";
            // 
            // label33
            // 
            this.label33.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(13, 666);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(74, 13);
            this.label33.TabIndex = 69;
            this.label33.Text = "Output Format";
            // 
            // JPEGRadioButton
            // 
            this.JPEGRadioButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.JPEGRadioButton.AutoSize = true;
            this.JPEGRadioButton.Location = new System.Drawing.Point(148, 664);
            this.JPEGRadioButton.Name = "JPEGRadioButton";
            this.JPEGRadioButton.Size = new System.Drawing.Size(52, 17);
            this.JPEGRadioButton.TabIndex = 68;
            this.JPEGRadioButton.TabStop = true;
            this.JPEGRadioButton.Text = "JPEG";
            this.JPEGRadioButton.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Location = new System.Drawing.Point(6, 116);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(283, 5);
            this.groupBox5.TabIndex = 68;
            this.groupBox5.TabStop = false;
            // 
            // PNGRadioButton
            // 
            this.PNGRadioButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.PNGRadioButton.AutoSize = true;
            this.PNGRadioButton.Location = new System.Drawing.Point(94, 664);
            this.PNGRadioButton.Name = "PNGRadioButton";
            this.PNGRadioButton.Size = new System.Drawing.Size(48, 17);
            this.PNGRadioButton.TabIndex = 67;
            this.PNGRadioButton.TabStop = true;
            this.PNGRadioButton.Text = "PNG";
            this.PNGRadioButton.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox4.Location = new System.Drawing.Point(6, 562);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(283, 5);
            this.groupBox4.TabIndex = 67;
            this.groupBox4.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox3.Location = new System.Drawing.Point(12, 653);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(283, 5);
            this.groupBox3.TabIndex = 66;
            this.groupBox3.TabStop = false;
            // 
            // EditOutputPathButton
            // 
            this.EditOutputPathButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.EditOutputPathButton.Location = new System.Drawing.Point(255, 685);
            this.EditOutputPathButton.Name = "EditOutputPathButton";
            this.EditOutputPathButton.Size = new System.Drawing.Size(30, 23);
            this.EditOutputPathButton.TabIndex = 63;
            this.EditOutputPathButton.Text = "...";
            this.EditOutputPathButton.UseVisualStyleBackColor = true;
            // 
            // label39
            // 
            this.label39.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label39.AutoSize = true;
            this.label39.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label39.Location = new System.Drawing.Point(173, 626);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(18, 13);
            this.label39.TabIndex = 60;
            this.label39.Text = "px";
            // 
            // label38
            // 
            this.label38.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label38.AutoSize = true;
            this.label38.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label38.Location = new System.Drawing.Point(173, 602);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(18, 13);
            this.label38.TabIndex = 59;
            this.label38.Text = "px";
            // 
            // OutputPathTextbox
            // 
            this.OutputPathTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.OutputPathTextbox.Location = new System.Drawing.Point(94, 687);
            this.OutputPathTextbox.Name = "OutputPathTextbox";
            this.OutputPathTextbox.Size = new System.Drawing.Size(155, 20);
            this.OutputPathTextbox.TabIndex = 62;
            // 
            // label40
            // 
            this.label40.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(14, 690);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(64, 13);
            this.label40.TabIndex = 61;
            this.label40.Text = "Output Path";
            // 
            // label37
            // 
            this.label37.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label37.AutoSize = true;
            this.label37.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label37.Location = new System.Drawing.Point(173, 578);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(18, 13);
            this.label37.TabIndex = 58;
            this.label37.Text = "px";
            // 
            // ShowZoneOutlinesCheckbox
            // 
            this.ShowZoneOutlinesCheckbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ShowZoneOutlinesCheckbox.AutoSize = true;
            this.ShowZoneOutlinesCheckbox.Location = new System.Drawing.Point(197, 603);
            this.ShowZoneOutlinesCheckbox.Name = "ShowZoneOutlinesCheckbox";
            this.ShowZoneOutlinesCheckbox.Size = new System.Drawing.Size(92, 17);
            this.ShowZoneOutlinesCheckbox.TabIndex = 56;
            this.ShowZoneOutlinesCheckbox.Text = "Zone Outlines";
            this.ShowZoneOutlinesCheckbox.UseVisualStyleBackColor = true;
            // 
            // SegmentOffsetNumericUpDown
            // 
            this.SegmentOffsetNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SegmentOffsetNumericUpDown.Location = new System.Drawing.Point(121, 624);
            this.SegmentOffsetNumericUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.SegmentOffsetNumericUpDown.Name = "SegmentOffsetNumericUpDown";
            this.SegmentOffsetNumericUpDown.Size = new System.Drawing.Size(49, 20);
            this.SegmentOffsetNumericUpDown.TabIndex = 55;
            // 
            // SegmentPaddingNumericUpDown
            // 
            this.SegmentPaddingNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SegmentPaddingNumericUpDown.Location = new System.Drawing.Point(121, 600);
            this.SegmentPaddingNumericUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.SegmentPaddingNumericUpDown.Name = "SegmentPaddingNumericUpDown";
            this.SegmentPaddingNumericUpDown.Size = new System.Drawing.Size(49, 20);
            this.SegmentPaddingNumericUpDown.TabIndex = 54;
            // 
            // GridSegmentSizeNumericUpDown
            // 
            this.GridSegmentSizeNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.GridSegmentSizeNumericUpDown.Location = new System.Drawing.Point(121, 575);
            this.GridSegmentSizeNumericUpDown.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.GridSegmentSizeNumericUpDown.Name = "GridSegmentSizeNumericUpDown";
            this.GridSegmentSizeNumericUpDown.Size = new System.Drawing.Size(49, 20);
            this.GridSegmentSizeNumericUpDown.TabIndex = 53;
            // 
            // label34
            // 
            this.label34.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(14, 626);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(80, 13);
            this.label34.TabIndex = 52;
            this.label34.Text = "Segment Offset";
            // 
            // label35
            // 
            this.label35.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(14, 602);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(91, 13);
            this.label35.TabIndex = 51;
            this.label35.Text = "Segment Padding";
            // 
            // label36
            // 
            this.label36.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(14, 578);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(94, 13);
            this.label36.TabIndex = 50;
            this.label36.Text = "Grid Segment Size";
            // 
            // ShowGridLinesCheckbox
            // 
            this.ShowGridLinesCheckbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ShowGridLinesCheckbox.AutoSize = true;
            this.ShowGridLinesCheckbox.Location = new System.Drawing.Point(197, 577);
            this.ShowGridLinesCheckbox.Name = "ShowGridLinesCheckbox";
            this.ShowGridLinesCheckbox.Size = new System.Drawing.Size(73, 17);
            this.ShowGridLinesCheckbox.TabIndex = 49;
            this.ShowGridLinesCheckbox.Text = "Grid Lines";
            this.ShowGridLinesCheckbox.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(6, 127);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(283, 429);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.AutoScroll = true;
            this.tabPage1.Controls.Add(this.IndustrialZoneLowEditButton);
            this.tabPage1.Controls.Add(this.IndustrialZoneMidEditButton);
            this.tabPage1.Controls.Add(this.IndustrialZoneHighEditButton);
            this.tabPage1.Controls.Add(this.CommercialZoneHighEditButton);
            this.tabPage1.Controls.Add(this.CommercialZoneMidEditButton);
            this.tabPage1.Controls.Add(this.IndustrialZoneMidTextbox);
            this.tabPage1.Controls.Add(this.CommercialZoneLowEditButton);
            this.tabPage1.Controls.Add(this.IndustrialZoneHighTextbox);
            this.tabPage1.Controls.Add(this.CommercialZoneMidTextbox);
            this.tabPage1.Controls.Add(this.CommercialZoneHighTextbox);
            this.tabPage1.Controls.Add(this.IndustrialZoneLowTextbox);
            this.tabPage1.Controls.Add(this.CommercialZoneLowTextbox);
            this.tabPage1.Controls.Add(this.ResidentialZoneLowEditButton);
            this.tabPage1.Controls.Add(this.ResidentialZoneHighEditButton);
            this.tabPage1.Controls.Add(this.ResidentialZoneMidEditButton);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label13);
            this.tabPage1.Controls.Add(this.label14);
            this.tabPage1.Controls.Add(this.ResidentialZoneHighTextbox);
            this.tabPage1.Controls.Add(this.ResidentialZoneMidTextbox);
            this.tabPage1.Controls.Add(this.ResidentialZoneLowTextbox);
            this.tabPage1.Controls.Add(this.label15);
            this.tabPage1.Controls.Add(this.SpaceportEditButton);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.SpaceportTextbox);
            this.tabPage1.Controls.Add(this.SeaportsEditButton);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.SeaportTextbox);
            this.tabPage1.Controls.Add(this.AirportsEditButton);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.AirportsTextbox);
            this.tabPage1.Controls.Add(this.MilitaryEditButton);
            this.tabPage1.Controls.Add(this.label17);
            this.tabPage1.Controls.Add(this.MilitaryTextbox);
            this.tabPage1.Controls.Add(this.ZoneOutlinesEditButton);
            this.tabPage1.Controls.Add(this.label16);
            this.tabPage1.Controls.Add(this.ZoneOutlinesTextbox);
            this.tabPage1.Controls.Add(this.GridLinesEditTextbox);
            this.tabPage1.Controls.Add(this.BuildingsEditButton);
            this.tabPage1.Controls.Add(this.GridBackgroundEditButton);
            this.tabPage1.Controls.Add(this.label12);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.BuildingsTextbox);
            this.tabPage1.Controls.Add(this.GridLinesTextbox);
            this.tabPage1.Controls.Add(this.GridBackgroundTextbox);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(275, 403);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Zones";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // IndustrialZoneLowEditButton
            // 
            this.IndustrialZoneLowEditButton.Location = new System.Drawing.Point(222, 328);
            this.IndustrialZoneLowEditButton.Name = "IndustrialZoneLowEditButton";
            this.IndustrialZoneLowEditButton.Size = new System.Drawing.Size(34, 23);
            this.IndustrialZoneLowEditButton.TabIndex = 107;
            this.IndustrialZoneLowEditButton.Text = "Edit";
            this.IndustrialZoneLowEditButton.UseVisualStyleBackColor = true;
            // 
            // IndustrialZoneMidEditButton
            // 
            this.IndustrialZoneMidEditButton.Location = new System.Drawing.Point(222, 351);
            this.IndustrialZoneMidEditButton.Name = "IndustrialZoneMidEditButton";
            this.IndustrialZoneMidEditButton.Size = new System.Drawing.Size(34, 23);
            this.IndustrialZoneMidEditButton.TabIndex = 106;
            this.IndustrialZoneMidEditButton.Text = "Edit";
            this.IndustrialZoneMidEditButton.UseVisualStyleBackColor = true;
            // 
            // IndustrialZoneHighEditButton
            // 
            this.IndustrialZoneHighEditButton.Location = new System.Drawing.Point(222, 374);
            this.IndustrialZoneHighEditButton.Name = "IndustrialZoneHighEditButton";
            this.IndustrialZoneHighEditButton.Size = new System.Drawing.Size(34, 23);
            this.IndustrialZoneHighEditButton.TabIndex = 105;
            this.IndustrialZoneHighEditButton.Text = "Edit";
            this.IndustrialZoneHighEditButton.UseVisualStyleBackColor = true;
            // 
            // CommercialZoneHighEditButton
            // 
            this.CommercialZoneHighEditButton.Location = new System.Drawing.Point(222, 305);
            this.CommercialZoneHighEditButton.Name = "CommercialZoneHighEditButton";
            this.CommercialZoneHighEditButton.Size = new System.Drawing.Size(34, 23);
            this.CommercialZoneHighEditButton.TabIndex = 94;
            this.CommercialZoneHighEditButton.Text = "Edit";
            this.CommercialZoneHighEditButton.UseVisualStyleBackColor = true;
            // 
            // CommercialZoneMidEditButton
            // 
            this.CommercialZoneMidEditButton.Location = new System.Drawing.Point(222, 282);
            this.CommercialZoneMidEditButton.Name = "CommercialZoneMidEditButton";
            this.CommercialZoneMidEditButton.Size = new System.Drawing.Size(34, 23);
            this.CommercialZoneMidEditButton.TabIndex = 96;
            this.CommercialZoneMidEditButton.Text = "Edit";
            this.CommercialZoneMidEditButton.UseVisualStyleBackColor = true;
            // 
            // IndustrialZoneMidTextbox
            // 
            this.IndustrialZoneMidTextbox.Enabled = false;
            this.IndustrialZoneMidTextbox.ForeColor = System.Drawing.Color.Maroon;
            this.IndustrialZoneMidTextbox.Location = new System.Drawing.Point(132, 353);
            this.IndustrialZoneMidTextbox.Name = "IndustrialZoneMidTextbox";
            this.IndustrialZoneMidTextbox.Size = new System.Drawing.Size(84, 20);
            this.IndustrialZoneMidTextbox.TabIndex = 104;
            // 
            // CommercialZoneLowEditButton
            // 
            this.CommercialZoneLowEditButton.Location = new System.Drawing.Point(222, 259);
            this.CommercialZoneLowEditButton.Name = "CommercialZoneLowEditButton";
            this.CommercialZoneLowEditButton.Size = new System.Drawing.Size(34, 23);
            this.CommercialZoneLowEditButton.TabIndex = 95;
            this.CommercialZoneLowEditButton.Text = "Edit";
            this.CommercialZoneLowEditButton.UseVisualStyleBackColor = true;
            // 
            // IndustrialZoneHighTextbox
            // 
            this.IndustrialZoneHighTextbox.Enabled = false;
            this.IndustrialZoneHighTextbox.ForeColor = System.Drawing.Color.Maroon;
            this.IndustrialZoneHighTextbox.Location = new System.Drawing.Point(132, 376);
            this.IndustrialZoneHighTextbox.Name = "IndustrialZoneHighTextbox";
            this.IndustrialZoneHighTextbox.Size = new System.Drawing.Size(84, 20);
            this.IndustrialZoneHighTextbox.TabIndex = 103;
            // 
            // CommercialZoneMidTextbox
            // 
            this.CommercialZoneMidTextbox.Enabled = false;
            this.CommercialZoneMidTextbox.ForeColor = System.Drawing.Color.Maroon;
            this.CommercialZoneMidTextbox.Location = new System.Drawing.Point(132, 284);
            this.CommercialZoneMidTextbox.Name = "CommercialZoneMidTextbox";
            this.CommercialZoneMidTextbox.Size = new System.Drawing.Size(84, 20);
            this.CommercialZoneMidTextbox.TabIndex = 102;
            // 
            // CommercialZoneHighTextbox
            // 
            this.CommercialZoneHighTextbox.Enabled = false;
            this.CommercialZoneHighTextbox.ForeColor = System.Drawing.Color.Maroon;
            this.CommercialZoneHighTextbox.Location = new System.Drawing.Point(132, 307);
            this.CommercialZoneHighTextbox.Name = "CommercialZoneHighTextbox";
            this.CommercialZoneHighTextbox.Size = new System.Drawing.Size(84, 20);
            this.CommercialZoneHighTextbox.TabIndex = 101;
            // 
            // IndustrialZoneLowTextbox
            // 
            this.IndustrialZoneLowTextbox.Enabled = false;
            this.IndustrialZoneLowTextbox.ForeColor = System.Drawing.Color.Maroon;
            this.IndustrialZoneLowTextbox.Location = new System.Drawing.Point(132, 330);
            this.IndustrialZoneLowTextbox.Name = "IndustrialZoneLowTextbox";
            this.IndustrialZoneLowTextbox.Size = new System.Drawing.Size(84, 20);
            this.IndustrialZoneLowTextbox.TabIndex = 100;
            // 
            // CommercialZoneLowTextbox
            // 
            this.CommercialZoneLowTextbox.Enabled = false;
            this.CommercialZoneLowTextbox.ForeColor = System.Drawing.Color.Maroon;
            this.CommercialZoneLowTextbox.Location = new System.Drawing.Point(132, 261);
            this.CommercialZoneLowTextbox.Name = "CommercialZoneLowTextbox";
            this.CommercialZoneLowTextbox.Size = new System.Drawing.Size(84, 20);
            this.CommercialZoneLowTextbox.TabIndex = 99;
            // 
            // ResidentialZoneLowEditButton
            // 
            this.ResidentialZoneLowEditButton.Location = new System.Drawing.Point(222, 190);
            this.ResidentialZoneLowEditButton.Name = "ResidentialZoneLowEditButton";
            this.ResidentialZoneLowEditButton.Size = new System.Drawing.Size(34, 23);
            this.ResidentialZoneLowEditButton.TabIndex = 98;
            this.ResidentialZoneLowEditButton.Text = "Edit";
            this.ResidentialZoneLowEditButton.UseVisualStyleBackColor = true;
            // 
            // ResidentialZoneHighEditButton
            // 
            this.ResidentialZoneHighEditButton.Location = new System.Drawing.Point(222, 236);
            this.ResidentialZoneHighEditButton.Name = "ResidentialZoneHighEditButton";
            this.ResidentialZoneHighEditButton.Size = new System.Drawing.Size(34, 23);
            this.ResidentialZoneHighEditButton.TabIndex = 97;
            this.ResidentialZoneHighEditButton.Text = "Edit";
            this.ResidentialZoneHighEditButton.UseVisualStyleBackColor = true;
            // 
            // ResidentialZoneMidEditButton
            // 
            this.ResidentialZoneMidEditButton.Location = new System.Drawing.Point(222, 213);
            this.ResidentialZoneMidEditButton.Name = "ResidentialZoneMidEditButton";
            this.ResidentialZoneMidEditButton.Size = new System.Drawing.Size(34, 23);
            this.ResidentialZoneMidEditButton.TabIndex = 93;
            this.ResidentialZoneMidEditButton.Text = "Edit";
            this.ResidentialZoneMidEditButton.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 356);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 13);
            this.label7.TabIndex = 92;
            this.label7.Text = "Industrial Zone Mid";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 379);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(102, 13);
            this.label8.TabIndex = 91;
            this.label8.Text = "Industrial Zone High";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 333);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 13);
            this.label9.TabIndex = 90;
            this.label9.Text = "Industrial Zone Low";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 287);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 13);
            this.label6.TabIndex = 89;
            this.label6.Text = "Commercial Zone Mid";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 310);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 13);
            this.label5.TabIndex = 88;
            this.label5.Text = "Commercial Zone High";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 218);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 13);
            this.label4.TabIndex = 87;
            this.label4.Text = "Residential Zone Mid";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(4, 241);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(112, 13);
            this.label13.TabIndex = 86;
            this.label13.Text = "Residential Zone High";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(4, 264);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(112, 13);
            this.label14.TabIndex = 85;
            this.label14.Text = "Commercial Zone Low";
            // 
            // ResidentialZoneHighTextbox
            // 
            this.ResidentialZoneHighTextbox.Enabled = false;
            this.ResidentialZoneHighTextbox.ForeColor = System.Drawing.Color.Maroon;
            this.ResidentialZoneHighTextbox.Location = new System.Drawing.Point(132, 238);
            this.ResidentialZoneHighTextbox.Name = "ResidentialZoneHighTextbox";
            this.ResidentialZoneHighTextbox.Size = new System.Drawing.Size(84, 20);
            this.ResidentialZoneHighTextbox.TabIndex = 84;
            // 
            // ResidentialZoneMidTextbox
            // 
            this.ResidentialZoneMidTextbox.Enabled = false;
            this.ResidentialZoneMidTextbox.ForeColor = System.Drawing.Color.Maroon;
            this.ResidentialZoneMidTextbox.Location = new System.Drawing.Point(132, 215);
            this.ResidentialZoneMidTextbox.Name = "ResidentialZoneMidTextbox";
            this.ResidentialZoneMidTextbox.Size = new System.Drawing.Size(84, 20);
            this.ResidentialZoneMidTextbox.TabIndex = 83;
            // 
            // ResidentialZoneLowTextbox
            // 
            this.ResidentialZoneLowTextbox.Enabled = false;
            this.ResidentialZoneLowTextbox.ForeColor = System.Drawing.Color.Maroon;
            this.ResidentialZoneLowTextbox.Location = new System.Drawing.Point(132, 192);
            this.ResidentialZoneLowTextbox.Name = "ResidentialZoneLowTextbox";
            this.ResidentialZoneLowTextbox.Size = new System.Drawing.Size(84, 20);
            this.ResidentialZoneLowTextbox.TabIndex = 82;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(4, 195);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(110, 13);
            this.label15.TabIndex = 81;
            this.label15.Text = "Residential Zone Low";
            // 
            // SpaceportEditButton
            // 
            this.SpaceportEditButton.Location = new System.Drawing.Point(222, 167);
            this.SpaceportEditButton.Name = "SpaceportEditButton";
            this.SpaceportEditButton.Size = new System.Drawing.Size(34, 23);
            this.SpaceportEditButton.TabIndex = 80;
            this.SpaceportEditButton.Text = "Edit";
            this.SpaceportEditButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 172);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 79;
            this.label1.Text = "Spaceports";
            // 
            // SpaceportTextbox
            // 
            this.SpaceportTextbox.Enabled = false;
            this.SpaceportTextbox.ForeColor = System.Drawing.Color.Maroon;
            this.SpaceportTextbox.Location = new System.Drawing.Point(132, 169);
            this.SpaceportTextbox.Name = "SpaceportTextbox";
            this.SpaceportTextbox.Size = new System.Drawing.Size(84, 20);
            this.SpaceportTextbox.TabIndex = 78;
            // 
            // SeaportsEditButton
            // 
            this.SeaportsEditButton.Location = new System.Drawing.Point(222, 144);
            this.SeaportsEditButton.Name = "SeaportsEditButton";
            this.SeaportsEditButton.Size = new System.Drawing.Size(34, 23);
            this.SeaportsEditButton.TabIndex = 77;
            this.SeaportsEditButton.Text = "Edit";
            this.SeaportsEditButton.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 149);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 76;
            this.label2.Text = "Seaports";
            // 
            // SeaportTextbox
            // 
            this.SeaportTextbox.Enabled = false;
            this.SeaportTextbox.ForeColor = System.Drawing.Color.Maroon;
            this.SeaportTextbox.Location = new System.Drawing.Point(132, 146);
            this.SeaportTextbox.Name = "SeaportTextbox";
            this.SeaportTextbox.Size = new System.Drawing.Size(84, 20);
            this.SeaportTextbox.TabIndex = 75;
            // 
            // AirportsEditButton
            // 
            this.AirportsEditButton.Location = new System.Drawing.Point(222, 121);
            this.AirportsEditButton.Name = "AirportsEditButton";
            this.AirportsEditButton.Size = new System.Drawing.Size(34, 23);
            this.AirportsEditButton.TabIndex = 74;
            this.AirportsEditButton.Text = "Edit";
            this.AirportsEditButton.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 73;
            this.label3.Text = "Airports";
            // 
            // AirportsTextbox
            // 
            this.AirportsTextbox.Enabled = false;
            this.AirportsTextbox.ForeColor = System.Drawing.Color.Maroon;
            this.AirportsTextbox.Location = new System.Drawing.Point(132, 123);
            this.AirportsTextbox.Name = "AirportsTextbox";
            this.AirportsTextbox.Size = new System.Drawing.Size(84, 20);
            this.AirportsTextbox.TabIndex = 72;
            // 
            // MilitaryEditButton
            // 
            this.MilitaryEditButton.Location = new System.Drawing.Point(222, 98);
            this.MilitaryEditButton.Name = "MilitaryEditButton";
            this.MilitaryEditButton.Size = new System.Drawing.Size(34, 23);
            this.MilitaryEditButton.TabIndex = 71;
            this.MilitaryEditButton.Text = "Edit";
            this.MilitaryEditButton.UseVisualStyleBackColor = true;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(4, 103);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(39, 13);
            this.label17.TabIndex = 70;
            this.label17.Text = "Military";
            // 
            // MilitaryTextbox
            // 
            this.MilitaryTextbox.Enabled = false;
            this.MilitaryTextbox.ForeColor = System.Drawing.Color.Maroon;
            this.MilitaryTextbox.Location = new System.Drawing.Point(132, 100);
            this.MilitaryTextbox.Name = "MilitaryTextbox";
            this.MilitaryTextbox.Size = new System.Drawing.Size(84, 20);
            this.MilitaryTextbox.TabIndex = 69;
            // 
            // ZoneOutlinesEditButton
            // 
            this.ZoneOutlinesEditButton.Location = new System.Drawing.Point(222, 52);
            this.ZoneOutlinesEditButton.Name = "ZoneOutlinesEditButton";
            this.ZoneOutlinesEditButton.Size = new System.Drawing.Size(34, 23);
            this.ZoneOutlinesEditButton.TabIndex = 68;
            this.ZoneOutlinesEditButton.Text = "Edit";
            this.ZoneOutlinesEditButton.UseVisualStyleBackColor = true;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(4, 57);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(73, 13);
            this.label16.TabIndex = 67;
            this.label16.Text = "Zone Outlines";
            // 
            // ZoneOutlinesTextbox
            // 
            this.ZoneOutlinesTextbox.Enabled = false;
            this.ZoneOutlinesTextbox.ForeColor = System.Drawing.Color.Maroon;
            this.ZoneOutlinesTextbox.Location = new System.Drawing.Point(132, 54);
            this.ZoneOutlinesTextbox.Name = "ZoneOutlinesTextbox";
            this.ZoneOutlinesTextbox.Size = new System.Drawing.Size(84, 20);
            this.ZoneOutlinesTextbox.TabIndex = 66;
            // 
            // GridLinesEditTextbox
            // 
            this.GridLinesEditTextbox.Location = new System.Drawing.Point(222, 29);
            this.GridLinesEditTextbox.Name = "GridLinesEditTextbox";
            this.GridLinesEditTextbox.Size = new System.Drawing.Size(34, 23);
            this.GridLinesEditTextbox.TabIndex = 65;
            this.GridLinesEditTextbox.Text = "Edit";
            this.GridLinesEditTextbox.UseVisualStyleBackColor = true;
            // 
            // BuildingsEditButton
            // 
            this.BuildingsEditButton.Location = new System.Drawing.Point(222, 75);
            this.BuildingsEditButton.Name = "BuildingsEditButton";
            this.BuildingsEditButton.Size = new System.Drawing.Size(34, 23);
            this.BuildingsEditButton.TabIndex = 64;
            this.BuildingsEditButton.Text = "Edit";
            this.BuildingsEditButton.UseVisualStyleBackColor = true;
            // 
            // GridBackgroundEditButton
            // 
            this.GridBackgroundEditButton.Location = new System.Drawing.Point(222, 6);
            this.GridBackgroundEditButton.Name = "GridBackgroundEditButton";
            this.GridBackgroundEditButton.Size = new System.Drawing.Size(34, 23);
            this.GridBackgroundEditButton.TabIndex = 58;
            this.GridBackgroundEditButton.Text = "Edit";
            this.GridBackgroundEditButton.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(4, 80);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(91, 13);
            this.label12.TabIndex = 63;
            this.label12.Text = "Plopped Buildings";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(4, 34);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(54, 13);
            this.label11.TabIndex = 62;
            this.label11.Text = "Grid Lines";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(4, 11);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(87, 13);
            this.label10.TabIndex = 61;
            this.label10.Text = "Grid Background";
            // 
            // BuildingsTextbox
            // 
            this.BuildingsTextbox.Enabled = false;
            this.BuildingsTextbox.ForeColor = System.Drawing.Color.Maroon;
            this.BuildingsTextbox.Location = new System.Drawing.Point(132, 77);
            this.BuildingsTextbox.Name = "BuildingsTextbox";
            this.BuildingsTextbox.Size = new System.Drawing.Size(84, 20);
            this.BuildingsTextbox.TabIndex = 60;
            // 
            // GridLinesTextbox
            // 
            this.GridLinesTextbox.Enabled = false;
            this.GridLinesTextbox.ForeColor = System.Drawing.Color.Maroon;
            this.GridLinesTextbox.Location = new System.Drawing.Point(132, 31);
            this.GridLinesTextbox.Name = "GridLinesTextbox";
            this.GridLinesTextbox.Size = new System.Drawing.Size(84, 20);
            this.GridLinesTextbox.TabIndex = 59;
            // 
            // GridBackgroundTextbox
            // 
            this.GridBackgroundTextbox.Enabled = false;
            this.GridBackgroundTextbox.ForeColor = System.Drawing.Color.Maroon;
            this.GridBackgroundTextbox.Location = new System.Drawing.Point(132, 8);
            this.GridBackgroundTextbox.Name = "GridBackgroundTextbox";
            this.GridBackgroundTextbox.Size = new System.Drawing.Size(84, 20);
            this.GridBackgroundTextbox.TabIndex = 57;
            // 
            // tabPage3
            // 
            this.tabPage3.AutoScroll = true;
            this.tabPage3.Controls.Add(this.button11);
            this.tabPage3.Controls.Add(this.label47);
            this.tabPage3.Controls.Add(this.textBox14);
            this.tabPage3.Controls.Add(this.button10);
            this.tabPage3.Controls.Add(this.label46);
            this.tabPage3.Controls.Add(this.textBox13);
            this.tabPage3.Controls.Add(this.button9);
            this.tabPage3.Controls.Add(this.label45);
            this.tabPage3.Controls.Add(this.textBox12);
            this.tabPage3.Controls.Add(this.button8);
            this.tabPage3.Controls.Add(this.label44);
            this.tabPage3.Controls.Add(this.textBox11);
            this.tabPage3.Controls.Add(this.button7);
            this.tabPage3.Controls.Add(this.label43);
            this.tabPage3.Controls.Add(this.textBox10);
            this.tabPage3.Controls.Add(this.button6);
            this.tabPage3.Controls.Add(this.label42);
            this.tabPage3.Controls.Add(this.textBox9);
            this.tabPage3.Controls.Add(this.button5);
            this.tabPage3.Controls.Add(this.label41);
            this.tabPage3.Controls.Add(this.textBox8);
            this.tabPage3.Controls.Add(this.button4);
            this.tabPage3.Controls.Add(this.label30);
            this.tabPage3.Controls.Add(this.textBox7);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(275, 403);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Transport";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(224, 180);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(34, 23);
            this.button11.TabIndex = 84;
            this.button11.Text = "Edit";
            this.button11.UseVisualStyleBackColor = true;
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Location = new System.Drawing.Point(6, 185);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(87, 13);
            this.label47.TabIndex = 85;
            this.label47.Text = "Grid Background";
            // 
            // textBox14
            // 
            this.textBox14.Enabled = false;
            this.textBox14.ForeColor = System.Drawing.Color.Maroon;
            this.textBox14.Location = new System.Drawing.Point(134, 182);
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new System.Drawing.Size(84, 20);
            this.textBox14.TabIndex = 83;
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(224, 153);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(34, 23);
            this.button10.TabIndex = 81;
            this.button10.Text = "Edit";
            this.button10.UseVisualStyleBackColor = true;
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Location = new System.Drawing.Point(6, 158);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(87, 13);
            this.label46.TabIndex = 82;
            this.label46.Text = "Grid Background";
            // 
            // textBox13
            // 
            this.textBox13.Enabled = false;
            this.textBox13.ForeColor = System.Drawing.Color.Maroon;
            this.textBox13.Location = new System.Drawing.Point(134, 155);
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new System.Drawing.Size(84, 20);
            this.textBox13.TabIndex = 80;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(224, 128);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(34, 23);
            this.button9.TabIndex = 78;
            this.button9.Text = "Edit";
            this.button9.UseVisualStyleBackColor = true;
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(6, 133);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(87, 13);
            this.label45.TabIndex = 79;
            this.label45.Text = "Grid Background";
            // 
            // textBox12
            // 
            this.textBox12.Enabled = false;
            this.textBox12.ForeColor = System.Drawing.Color.Maroon;
            this.textBox12.Location = new System.Drawing.Point(134, 130);
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(84, 20);
            this.textBox12.TabIndex = 77;
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(224, 105);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(34, 23);
            this.button8.TabIndex = 75;
            this.button8.Text = "Edit";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(6, 110);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(87, 13);
            this.label44.TabIndex = 76;
            this.label44.Text = "Grid Background";
            // 
            // textBox11
            // 
            this.textBox11.Enabled = false;
            this.textBox11.ForeColor = System.Drawing.Color.Maroon;
            this.textBox11.Location = new System.Drawing.Point(134, 107);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(84, 20);
            this.textBox11.TabIndex = 74;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(224, 82);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(34, 23);
            this.button7.TabIndex = 72;
            this.button7.Text = "Edit";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(6, 87);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(87, 13);
            this.label43.TabIndex = 73;
            this.label43.Text = "Grid Background";
            // 
            // textBox10
            // 
            this.textBox10.Enabled = false;
            this.textBox10.ForeColor = System.Drawing.Color.Maroon;
            this.textBox10.Location = new System.Drawing.Point(134, 84);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(84, 20);
            this.textBox10.TabIndex = 71;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(224, 56);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(34, 23);
            this.button6.TabIndex = 69;
            this.button6.Text = "Edit";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(6, 61);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(87, 13);
            this.label42.TabIndex = 70;
            this.label42.Text = "Grid Background";
            // 
            // textBox9
            // 
            this.textBox9.Enabled = false;
            this.textBox9.ForeColor = System.Drawing.Color.Maroon;
            this.textBox9.Location = new System.Drawing.Point(134, 58);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(84, 20);
            this.textBox9.TabIndex = 68;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(224, 32);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(34, 23);
            this.button5.TabIndex = 66;
            this.button5.Text = "Edit";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(6, 37);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(44, 13);
            this.label41.TabIndex = 67;
            this.label41.Text = "Railway";
            // 
            // textBox8
            // 
            this.textBox8.Enabled = false;
            this.textBox8.ForeColor = System.Drawing.Color.Maroon;
            this.textBox8.Location = new System.Drawing.Point(134, 34);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(84, 20);
            this.textBox8.TabIndex = 65;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(224, 8);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(34, 23);
            this.button4.TabIndex = 63;
            this.button4.Text = "Edit";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(6, 13);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(33, 13);
            this.label30.TabIndex = 64;
            this.label30.Text = "Road";
            // 
            // textBox7
            // 
            this.textBox7.Enabled = false;
            this.textBox7.ForeColor = System.Drawing.Color.Maroon;
            this.textBox7.Location = new System.Drawing.Point(134, 10);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(84, 20);
            this.textBox7.TabIndex = 62;
            // 
            // tabPage2
            // 
            this.tabPage2.AutoScroll = true;
            this.tabPage2.Controls.Add(this.textBox5);
            this.tabPage2.Controls.Add(this.button3);
            this.tabPage2.Controls.Add(this.textBox6);
            this.tabPage2.Controls.Add(this.numericUpDown18);
            this.tabPage2.Controls.Add(this.textBox3);
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Controls.Add(this.textBox4);
            this.tabPage2.Controls.Add(this.numericUpDown17);
            this.tabPage2.Controls.Add(this.textBox1);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.textBox2);
            this.tabPage2.Controls.Add(this.numericUpDown16);
            this.tabPage2.Controls.Add(this.textBox32);
            this.tabPage2.Controls.Add(this.button29);
            this.tabPage2.Controls.Add(this.textBox29);
            this.tabPage2.Controls.Add(this.numericUpDown13);
            this.tabPage2.Controls.Add(this.button30);
            this.tabPage2.Controls.Add(this.textBox30);
            this.tabPage2.Controls.Add(this.label31);
            this.tabPage2.Controls.Add(this.numericUpDown14);
            this.tabPage2.Controls.Add(this.button31);
            this.tabPage2.Controls.Add(this.textBox31);
            this.tabPage2.Controls.Add(this.label32);
            this.tabPage2.Controls.Add(this.numericUpDown15);
            this.tabPage2.Controls.Add(this.button26);
            this.tabPage2.Controls.Add(this.textBox26);
            this.tabPage2.Controls.Add(this.label27);
            this.tabPage2.Controls.Add(this.numericUpDown10);
            this.tabPage2.Controls.Add(this.button27);
            this.tabPage2.Controls.Add(this.textBox27);
            this.tabPage2.Controls.Add(this.label28);
            this.tabPage2.Controls.Add(this.numericUpDown11);
            this.tabPage2.Controls.Add(this.button28);
            this.tabPage2.Controls.Add(this.textBox28);
            this.tabPage2.Controls.Add(this.label29);
            this.tabPage2.Controls.Add(this.numericUpDown12);
            this.tabPage2.Controls.Add(this.button23);
            this.tabPage2.Controls.Add(this.textBox23);
            this.tabPage2.Controls.Add(this.label23);
            this.tabPage2.Controls.Add(this.numericUpDown7);
            this.tabPage2.Controls.Add(this.button24);
            this.tabPage2.Controls.Add(this.textBox24);
            this.tabPage2.Controls.Add(this.label25);
            this.tabPage2.Controls.Add(this.numericUpDown8);
            this.tabPage2.Controls.Add(this.button25);
            this.tabPage2.Controls.Add(this.textBox25);
            this.tabPage2.Controls.Add(this.label26);
            this.tabPage2.Controls.Add(this.numericUpDown9);
            this.tabPage2.Controls.Add(this.button20);
            this.tabPage2.Controls.Add(this.textBox20);
            this.tabPage2.Controls.Add(this.label20);
            this.tabPage2.Controls.Add(this.numericUpDown4);
            this.tabPage2.Controls.Add(this.button21);
            this.tabPage2.Controls.Add(this.textBox21);
            this.tabPage2.Controls.Add(this.label21);
            this.tabPage2.Controls.Add(this.numericUpDown5);
            this.tabPage2.Controls.Add(this.button22);
            this.tabPage2.Controls.Add(this.textBox22);
            this.tabPage2.Controls.Add(this.label22);
            this.tabPage2.Controls.Add(this.numericUpDown6);
            this.tabPage2.Controls.Add(this.button19);
            this.tabPage2.Controls.Add(this.textBox19);
            this.tabPage2.Controls.Add(this.label19);
            this.tabPage2.Controls.Add(this.numericUpDown3);
            this.tabPage2.Controls.Add(this.button18);
            this.tabPage2.Controls.Add(this.textBox18);
            this.tabPage2.Controls.Add(this.label18);
            this.tabPage2.Controls.Add(this.numericUpDown2);
            this.tabPage2.Controls.Add(this.button17);
            this.tabPage2.Controls.Add(this.textBox17);
            this.tabPage2.Controls.Add(this.label24);
            this.tabPage2.Controls.Add(this.numericUpDown1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(275, 403);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Terrain";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(3, 385);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(91, 20);
            this.textBox5.TabIndex = 99;
            this.textBox5.Text = "water deep";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(236, 385);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(34, 23);
            this.button3.TabIndex = 98;
            this.button3.Text = "Edit";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // textBox6
            // 
            this.textBox6.Enabled = false;
            this.textBox6.ForeColor = System.Drawing.Color.Maroon;
            this.textBox6.Location = new System.Drawing.Point(178, 386);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(52, 20);
            this.textBox6.TabIndex = 97;
            // 
            // numericUpDown18
            // 
            this.numericUpDown18.Location = new System.Drawing.Point(105, 386);
            this.numericUpDown18.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numericUpDown18.Name = "numericUpDown18";
            this.numericUpDown18.Size = new System.Drawing.Size(67, 20);
            this.numericUpDown18.TabIndex = 96;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(3, 362);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(91, 20);
            this.textBox3.TabIndex = 95;
            this.textBox3.Text = "water deep";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(236, 362);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(34, 23);
            this.button2.TabIndex = 94;
            this.button2.Text = "Edit";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // textBox4
            // 
            this.textBox4.Enabled = false;
            this.textBox4.ForeColor = System.Drawing.Color.Maroon;
            this.textBox4.Location = new System.Drawing.Point(178, 363);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(52, 20);
            this.textBox4.TabIndex = 93;
            // 
            // numericUpDown17
            // 
            this.numericUpDown17.Location = new System.Drawing.Point(105, 363);
            this.numericUpDown17.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numericUpDown17.Name = "numericUpDown17";
            this.numericUpDown17.Size = new System.Drawing.Size(67, 20);
            this.numericUpDown17.TabIndex = 92;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(3, 339);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(91, 20);
            this.textBox1.TabIndex = 91;
            this.textBox1.Text = "water deep";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(236, 339);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(34, 23);
            this.button1.TabIndex = 90;
            this.button1.Text = "Edit";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.ForeColor = System.Drawing.Color.Maroon;
            this.textBox2.Location = new System.Drawing.Point(178, 340);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(52, 20);
            this.textBox2.TabIndex = 89;
            // 
            // numericUpDown16
            // 
            this.numericUpDown16.Location = new System.Drawing.Point(105, 340);
            this.numericUpDown16.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numericUpDown16.Name = "numericUpDown16";
            this.numericUpDown16.Size = new System.Drawing.Size(67, 20);
            this.numericUpDown16.TabIndex = 88;
            // 
            // textBox32
            // 
            this.textBox32.Location = new System.Drawing.Point(3, 316);
            this.textBox32.Name = "textBox32";
            this.textBox32.Size = new System.Drawing.Size(91, 20);
            this.textBox32.TabIndex = 87;
            this.textBox32.Text = "water deep";
            // 
            // button29
            // 
            this.button29.Location = new System.Drawing.Point(236, 316);
            this.button29.Name = "button29";
            this.button29.Size = new System.Drawing.Size(34, 23);
            this.button29.TabIndex = 86;
            this.button29.Text = "Edit";
            this.button29.UseVisualStyleBackColor = true;
            // 
            // textBox29
            // 
            this.textBox29.Enabled = false;
            this.textBox29.ForeColor = System.Drawing.Color.Maroon;
            this.textBox29.Location = new System.Drawing.Point(178, 317);
            this.textBox29.Name = "textBox29";
            this.textBox29.Size = new System.Drawing.Size(52, 20);
            this.textBox29.TabIndex = 85;
            // 
            // numericUpDown13
            // 
            this.numericUpDown13.Location = new System.Drawing.Point(105, 317);
            this.numericUpDown13.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numericUpDown13.Name = "numericUpDown13";
            this.numericUpDown13.Size = new System.Drawing.Size(67, 20);
            this.numericUpDown13.TabIndex = 83;
            // 
            // button30
            // 
            this.button30.Location = new System.Drawing.Point(236, 294);
            this.button30.Name = "button30";
            this.button30.Size = new System.Drawing.Size(34, 23);
            this.button30.TabIndex = 82;
            this.button30.Text = "Edit";
            this.button30.UseVisualStyleBackColor = true;
            // 
            // textBox30
            // 
            this.textBox30.Enabled = false;
            this.textBox30.ForeColor = System.Drawing.Color.Maroon;
            this.textBox30.Location = new System.Drawing.Point(178, 295);
            this.textBox30.Name = "textBox30";
            this.textBox30.Size = new System.Drawing.Size(52, 20);
            this.textBox30.TabIndex = 81;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(3, 295);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(63, 13);
            this.label31.TabIndex = 80;
            this.label31.Text = "Water deep";
            // 
            // numericUpDown14
            // 
            this.numericUpDown14.Location = new System.Drawing.Point(105, 295);
            this.numericUpDown14.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numericUpDown14.Name = "numericUpDown14";
            this.numericUpDown14.Size = new System.Drawing.Size(67, 20);
            this.numericUpDown14.TabIndex = 79;
            // 
            // button31
            // 
            this.button31.Location = new System.Drawing.Point(236, 272);
            this.button31.Name = "button31";
            this.button31.Size = new System.Drawing.Size(34, 23);
            this.button31.TabIndex = 78;
            this.button31.Text = "Edit";
            this.button31.UseVisualStyleBackColor = true;
            // 
            // textBox31
            // 
            this.textBox31.Enabled = false;
            this.textBox31.ForeColor = System.Drawing.Color.Maroon;
            this.textBox31.Location = new System.Drawing.Point(178, 273);
            this.textBox31.Name = "textBox31";
            this.textBox31.Size = new System.Drawing.Size(52, 20);
            this.textBox31.TabIndex = 77;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(3, 273);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(63, 13);
            this.label32.TabIndex = 76;
            this.label32.Text = "Water deep";
            // 
            // numericUpDown15
            // 
            this.numericUpDown15.Location = new System.Drawing.Point(105, 273);
            this.numericUpDown15.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numericUpDown15.Name = "numericUpDown15";
            this.numericUpDown15.Size = new System.Drawing.Size(67, 20);
            this.numericUpDown15.TabIndex = 75;
            // 
            // button26
            // 
            this.button26.Location = new System.Drawing.Point(236, 248);
            this.button26.Name = "button26";
            this.button26.Size = new System.Drawing.Size(34, 23);
            this.button26.TabIndex = 74;
            this.button26.Text = "Edit";
            this.button26.UseVisualStyleBackColor = true;
            // 
            // textBox26
            // 
            this.textBox26.Enabled = false;
            this.textBox26.ForeColor = System.Drawing.Color.Maroon;
            this.textBox26.Location = new System.Drawing.Point(178, 249);
            this.textBox26.Name = "textBox26";
            this.textBox26.Size = new System.Drawing.Size(52, 20);
            this.textBox26.TabIndex = 73;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(3, 249);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(63, 13);
            this.label27.TabIndex = 72;
            this.label27.Text = "Water deep";
            // 
            // numericUpDown10
            // 
            this.numericUpDown10.Location = new System.Drawing.Point(105, 249);
            this.numericUpDown10.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numericUpDown10.Name = "numericUpDown10";
            this.numericUpDown10.Size = new System.Drawing.Size(67, 20);
            this.numericUpDown10.TabIndex = 71;
            // 
            // button27
            // 
            this.button27.Location = new System.Drawing.Point(236, 226);
            this.button27.Name = "button27";
            this.button27.Size = new System.Drawing.Size(34, 23);
            this.button27.TabIndex = 70;
            this.button27.Text = "Edit";
            this.button27.UseVisualStyleBackColor = true;
            // 
            // textBox27
            // 
            this.textBox27.Enabled = false;
            this.textBox27.ForeColor = System.Drawing.Color.Maroon;
            this.textBox27.Location = new System.Drawing.Point(178, 227);
            this.textBox27.Name = "textBox27";
            this.textBox27.Size = new System.Drawing.Size(52, 20);
            this.textBox27.TabIndex = 69;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(3, 227);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(63, 13);
            this.label28.TabIndex = 68;
            this.label28.Text = "Water deep";
            // 
            // numericUpDown11
            // 
            this.numericUpDown11.Location = new System.Drawing.Point(105, 227);
            this.numericUpDown11.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numericUpDown11.Name = "numericUpDown11";
            this.numericUpDown11.Size = new System.Drawing.Size(67, 20);
            this.numericUpDown11.TabIndex = 67;
            // 
            // button28
            // 
            this.button28.Location = new System.Drawing.Point(236, 204);
            this.button28.Name = "button28";
            this.button28.Size = new System.Drawing.Size(34, 23);
            this.button28.TabIndex = 66;
            this.button28.Text = "Edit";
            this.button28.UseVisualStyleBackColor = true;
            // 
            // textBox28
            // 
            this.textBox28.Enabled = false;
            this.textBox28.ForeColor = System.Drawing.Color.Maroon;
            this.textBox28.Location = new System.Drawing.Point(178, 205);
            this.textBox28.Name = "textBox28";
            this.textBox28.Size = new System.Drawing.Size(52, 20);
            this.textBox28.TabIndex = 65;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(3, 205);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(63, 13);
            this.label29.TabIndex = 64;
            this.label29.Text = "Water deep";
            // 
            // numericUpDown12
            // 
            this.numericUpDown12.Location = new System.Drawing.Point(105, 205);
            this.numericUpDown12.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numericUpDown12.Name = "numericUpDown12";
            this.numericUpDown12.Size = new System.Drawing.Size(67, 20);
            this.numericUpDown12.TabIndex = 63;
            // 
            // button23
            // 
            this.button23.Location = new System.Drawing.Point(236, 181);
            this.button23.Name = "button23";
            this.button23.Size = new System.Drawing.Size(34, 23);
            this.button23.TabIndex = 62;
            this.button23.Text = "Edit";
            this.button23.UseVisualStyleBackColor = true;
            // 
            // textBox23
            // 
            this.textBox23.Enabled = false;
            this.textBox23.ForeColor = System.Drawing.Color.Maroon;
            this.textBox23.Location = new System.Drawing.Point(178, 182);
            this.textBox23.Name = "textBox23";
            this.textBox23.Size = new System.Drawing.Size(52, 20);
            this.textBox23.TabIndex = 61;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(3, 182);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(63, 13);
            this.label23.TabIndex = 60;
            this.label23.Text = "Water deep";
            // 
            // numericUpDown7
            // 
            this.numericUpDown7.Location = new System.Drawing.Point(105, 182);
            this.numericUpDown7.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numericUpDown7.Name = "numericUpDown7";
            this.numericUpDown7.Size = new System.Drawing.Size(67, 20);
            this.numericUpDown7.TabIndex = 59;
            // 
            // button24
            // 
            this.button24.Location = new System.Drawing.Point(236, 159);
            this.button24.Name = "button24";
            this.button24.Size = new System.Drawing.Size(34, 23);
            this.button24.TabIndex = 58;
            this.button24.Text = "Edit";
            this.button24.UseVisualStyleBackColor = true;
            // 
            // textBox24
            // 
            this.textBox24.Enabled = false;
            this.textBox24.ForeColor = System.Drawing.Color.Maroon;
            this.textBox24.Location = new System.Drawing.Point(178, 160);
            this.textBox24.Name = "textBox24";
            this.textBox24.Size = new System.Drawing.Size(52, 20);
            this.textBox24.TabIndex = 57;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(3, 160);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(63, 13);
            this.label25.TabIndex = 56;
            this.label25.Text = "Water deep";
            // 
            // numericUpDown8
            // 
            this.numericUpDown8.Location = new System.Drawing.Point(105, 160);
            this.numericUpDown8.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numericUpDown8.Name = "numericUpDown8";
            this.numericUpDown8.Size = new System.Drawing.Size(67, 20);
            this.numericUpDown8.TabIndex = 55;
            // 
            // button25
            // 
            this.button25.Location = new System.Drawing.Point(236, 137);
            this.button25.Name = "button25";
            this.button25.Size = new System.Drawing.Size(34, 23);
            this.button25.TabIndex = 54;
            this.button25.Text = "Edit";
            this.button25.UseVisualStyleBackColor = true;
            // 
            // textBox25
            // 
            this.textBox25.Enabled = false;
            this.textBox25.ForeColor = System.Drawing.Color.Maroon;
            this.textBox25.Location = new System.Drawing.Point(178, 138);
            this.textBox25.Name = "textBox25";
            this.textBox25.Size = new System.Drawing.Size(52, 20);
            this.textBox25.TabIndex = 53;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(3, 138);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(63, 13);
            this.label26.TabIndex = 52;
            this.label26.Text = "Water deep";
            // 
            // numericUpDown9
            // 
            this.numericUpDown9.Location = new System.Drawing.Point(105, 138);
            this.numericUpDown9.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numericUpDown9.Name = "numericUpDown9";
            this.numericUpDown9.Size = new System.Drawing.Size(67, 20);
            this.numericUpDown9.TabIndex = 51;
            // 
            // button20
            // 
            this.button20.Location = new System.Drawing.Point(236, 113);
            this.button20.Name = "button20";
            this.button20.Size = new System.Drawing.Size(34, 23);
            this.button20.TabIndex = 50;
            this.button20.Text = "Edit";
            this.button20.UseVisualStyleBackColor = true;
            // 
            // textBox20
            // 
            this.textBox20.Enabled = false;
            this.textBox20.ForeColor = System.Drawing.Color.Maroon;
            this.textBox20.Location = new System.Drawing.Point(178, 114);
            this.textBox20.Name = "textBox20";
            this.textBox20.Size = new System.Drawing.Size(52, 20);
            this.textBox20.TabIndex = 49;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(3, 114);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(63, 13);
            this.label20.TabIndex = 48;
            this.label20.Text = "Water deep";
            // 
            // numericUpDown4
            // 
            this.numericUpDown4.Location = new System.Drawing.Point(105, 114);
            this.numericUpDown4.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numericUpDown4.Name = "numericUpDown4";
            this.numericUpDown4.Size = new System.Drawing.Size(67, 20);
            this.numericUpDown4.TabIndex = 47;
            // 
            // button21
            // 
            this.button21.Location = new System.Drawing.Point(236, 91);
            this.button21.Name = "button21";
            this.button21.Size = new System.Drawing.Size(34, 23);
            this.button21.TabIndex = 46;
            this.button21.Text = "Edit";
            this.button21.UseVisualStyleBackColor = true;
            // 
            // textBox21
            // 
            this.textBox21.Enabled = false;
            this.textBox21.ForeColor = System.Drawing.Color.Maroon;
            this.textBox21.Location = new System.Drawing.Point(178, 92);
            this.textBox21.Name = "textBox21";
            this.textBox21.Size = new System.Drawing.Size(52, 20);
            this.textBox21.TabIndex = 45;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(3, 92);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(63, 13);
            this.label21.TabIndex = 44;
            this.label21.Text = "Water deep";
            // 
            // numericUpDown5
            // 
            this.numericUpDown5.Location = new System.Drawing.Point(105, 92);
            this.numericUpDown5.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numericUpDown5.Name = "numericUpDown5";
            this.numericUpDown5.Size = new System.Drawing.Size(67, 20);
            this.numericUpDown5.TabIndex = 43;
            // 
            // button22
            // 
            this.button22.Location = new System.Drawing.Point(236, 69);
            this.button22.Name = "button22";
            this.button22.Size = new System.Drawing.Size(34, 23);
            this.button22.TabIndex = 42;
            this.button22.Text = "Edit";
            this.button22.UseVisualStyleBackColor = true;
            // 
            // textBox22
            // 
            this.textBox22.Enabled = false;
            this.textBox22.ForeColor = System.Drawing.Color.Maroon;
            this.textBox22.Location = new System.Drawing.Point(178, 70);
            this.textBox22.Name = "textBox22";
            this.textBox22.Size = new System.Drawing.Size(52, 20);
            this.textBox22.TabIndex = 41;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(3, 70);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(63, 13);
            this.label22.TabIndex = 40;
            this.label22.Text = "Water deep";
            // 
            // numericUpDown6
            // 
            this.numericUpDown6.Location = new System.Drawing.Point(105, 70);
            this.numericUpDown6.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numericUpDown6.Name = "numericUpDown6";
            this.numericUpDown6.Size = new System.Drawing.Size(67, 20);
            this.numericUpDown6.TabIndex = 39;
            // 
            // button19
            // 
            this.button19.Location = new System.Drawing.Point(236, 46);
            this.button19.Name = "button19";
            this.button19.Size = new System.Drawing.Size(34, 23);
            this.button19.TabIndex = 38;
            this.button19.Text = "Edit";
            this.button19.UseVisualStyleBackColor = true;
            // 
            // textBox19
            // 
            this.textBox19.Enabled = false;
            this.textBox19.ForeColor = System.Drawing.Color.Maroon;
            this.textBox19.Location = new System.Drawing.Point(178, 47);
            this.textBox19.Name = "textBox19";
            this.textBox19.Size = new System.Drawing.Size(52, 20);
            this.textBox19.TabIndex = 37;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(3, 47);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(63, 13);
            this.label19.TabIndex = 36;
            this.label19.Text = "Water deep";
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.Location = new System.Drawing.Point(105, 47);
            this.numericUpDown3.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(67, 20);
            this.numericUpDown3.TabIndex = 35;
            // 
            // button18
            // 
            this.button18.Location = new System.Drawing.Point(236, 24);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(34, 23);
            this.button18.TabIndex = 34;
            this.button18.Text = "Edit";
            this.button18.UseVisualStyleBackColor = true;
            // 
            // textBox18
            // 
            this.textBox18.Enabled = false;
            this.textBox18.ForeColor = System.Drawing.Color.Maroon;
            this.textBox18.Location = new System.Drawing.Point(178, 25);
            this.textBox18.Name = "textBox18";
            this.textBox18.Size = new System.Drawing.Size(52, 20);
            this.textBox18.TabIndex = 33;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(3, 25);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(60, 13);
            this.label18.TabIndex = 32;
            this.label18.Text = "Mountain 1";
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(105, 25);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(67, 20);
            this.numericUpDown2.TabIndex = 31;
            // 
            // button17
            // 
            this.button17.Location = new System.Drawing.Point(236, 2);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(34, 23);
            this.button17.TabIndex = 30;
            this.button17.Text = "Edit";
            this.button17.UseVisualStyleBackColor = true;
            // 
            // textBox17
            // 
            this.textBox17.Enabled = false;
            this.textBox17.ForeColor = System.Drawing.Color.Maroon;
            this.textBox17.Location = new System.Drawing.Point(178, 3);
            this.textBox17.Name = "textBox17";
            this.textBox17.Size = new System.Drawing.Size(52, 20);
            this.textBox17.TabIndex = 29;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(3, 3);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(63, 13);
            this.label24.TabIndex = 28;
            this.label24.Text = "Water deep";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(105, 3);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(67, 20);
            this.numericUpDown1.TabIndex = 27;
            // 
            // VisibleObjectsTreeView
            // 
            this.VisibleObjectsTreeView.CheckBoxes = true;
            this.VisibleObjectsTreeView.Location = new System.Drawing.Point(6, 19);
            this.VisibleObjectsTreeView.Name = "VisibleObjectsTreeView";
            treeNode21.Name = "Node1";
            treeNode21.Tag = "TerrainMap";
            treeNode21.Text = "Terrain";
            treeNode22.Name = "ResidentialLowDensity";
            treeNode22.Tag = "ResidentialLowZone";
            treeNode22.Text = "Low Density";
            treeNode23.Name = "ResidentialMediumDensity";
            treeNode23.Tag = "ResidentialMidZone";
            treeNode23.Text = "Medium Density";
            treeNode24.Name = "ResidentialHighDensity";
            treeNode24.Tag = "ResidentialHighZone";
            treeNode24.Text = "High Density";
            treeNode25.Name = "ResidentialRootNode";
            treeNode25.Tag = "Residential";
            treeNode25.Text = "Residential";
            treeNode26.Name = "CommercialLowDensity";
            treeNode26.Tag = "CommercialLowZone";
            treeNode26.Text = "Low Density";
            treeNode27.Name = "CommercialMediumDensity";
            treeNode27.Tag = "CommercialMidZone";
            treeNode27.Text = "Medium Density";
            treeNode28.Name = "CommercialHighDensity";
            treeNode28.Tag = "CommercialHighZone";
            treeNode28.Text = "High Density";
            treeNode29.Name = "CommercialRootNode";
            treeNode29.Tag = "Commercial";
            treeNode29.Text = "Commercial";
            treeNode30.Name = "IndustrialLowDensity";
            treeNode30.Tag = "IndustrialLowZone";
            treeNode30.Text = "Low Density";
            treeNode31.Name = "IndustrialMediumDensity";
            treeNode31.Tag = "IndustrialMidZone";
            treeNode31.Text = "Medium Density";
            treeNode32.Name = "IndustrialHighDensity";
            treeNode32.Tag = "IndustrialHighZone";
            treeNode32.Text = "High Density";
            treeNode33.Name = "IndustrialRootNode";
            treeNode33.Tag = "Industrial";
            treeNode33.Text = "Industrial";
            treeNode34.Name = "PloppedBuildingZone";
            treeNode34.Tag = "PloppedBuildingZone";
            treeNode34.Text = "Plopped Building";
            treeNode35.Name = "MilitaryZone";
            treeNode35.Tag = "MilitaryZone";
            treeNode35.Text = "Military";
            treeNode36.Name = "AirportsZone";
            treeNode36.Tag = "AirportZone";
            treeNode36.Text = "Airports";
            treeNode37.Name = "SeaportZones";
            treeNode37.Tag = "SeaportZone";
            treeNode37.Text = "Seaport";
            treeNode38.Name = "SpaceportZone";
            treeNode38.Tag = "SpaceportZone";
            treeNode38.Text = "Spaceport";
            treeNode39.Name = "Other";
            treeNode39.Tag = "Other";
            treeNode39.Text = "Other";
            treeNode40.Name = "Node0";
            treeNode40.Tag = "Zones";
            treeNode40.Text = "Zones";
            this.VisibleObjectsTreeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode21,
            treeNode40});
            this.VisibleObjectsTreeView.Size = new System.Drawing.Size(283, 91);
            this.VisibleObjectsTreeView.TabIndex = 1;
            this.VisibleObjectsTreeView.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.VisibleObjectsTreeView_AfterCheck);
            // 
            // RestoreDefaultsButton
            // 
            this.RestoreDefaultsButton.Location = new System.Drawing.Point(417, 711);
            this.RestoreDefaultsButton.Name = "RestoreDefaultsButton";
            this.RestoreDefaultsButton.Size = new System.Drawing.Size(96, 23);
            this.RestoreDefaultsButton.TabIndex = 12;
            this.RestoreDefaultsButton.Text = "Restore Defaults";
            this.RestoreDefaultsButton.UseVisualStyleBackColor = true;
            this.RestoreDefaultsButton.Click += new System.EventHandler(this.RestoreDefaultsButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1182, 768);
            this.Controls.Add(this.RestoreDefaultsButton);
            this.Controls.Add(this.AppearanceGroupBox);
            this.Controls.Add(this.statusStrip1);
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
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MapPictureBox)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.AppearanceGroupBox.ResumeLayout(false);
            this.AppearanceGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SegmentOffsetNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SegmentPaddingNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridSegmentSizeNumericUpDown)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
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
        private System.Windows.Forms.ImageList FileTreeViewImageList;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox MapPictureBox;
        private System.Windows.Forms.CheckBox FilterNewCitiesCheckbox;
        private System.Windows.Forms.ToolStripMenuItem savegameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem folderToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Label OpenTextLabel;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem UpdatesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel MapSizeToolStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel MousePositionToolStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel MemoryUsedToolStripStatusLabel;
        private System.Windows.Forms.GroupBox AppearanceGroupBox;
        private System.Windows.Forms.TreeView VisibleObjectsTreeView;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button button17;
        private System.Windows.Forms.TextBox textBox17;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button button29;
        private System.Windows.Forms.TextBox textBox29;
        private System.Windows.Forms.NumericUpDown numericUpDown13;
        private System.Windows.Forms.Button button30;
        private System.Windows.Forms.TextBox textBox30;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.NumericUpDown numericUpDown14;
        private System.Windows.Forms.Button button31;
        private System.Windows.Forms.TextBox textBox31;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.NumericUpDown numericUpDown15;
        private System.Windows.Forms.Button button26;
        private System.Windows.Forms.TextBox textBox26;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.NumericUpDown numericUpDown10;
        private System.Windows.Forms.Button button27;
        private System.Windows.Forms.TextBox textBox27;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.NumericUpDown numericUpDown11;
        private System.Windows.Forms.Button button28;
        private System.Windows.Forms.TextBox textBox28;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.NumericUpDown numericUpDown12;
        private System.Windows.Forms.Button button23;
        private System.Windows.Forms.TextBox textBox23;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.NumericUpDown numericUpDown7;
        private System.Windows.Forms.Button button24;
        private System.Windows.Forms.TextBox textBox24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.NumericUpDown numericUpDown8;
        private System.Windows.Forms.Button button25;
        private System.Windows.Forms.TextBox textBox25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.NumericUpDown numericUpDown9;
        private System.Windows.Forms.Button button20;
        private System.Windows.Forms.TextBox textBox20;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.NumericUpDown numericUpDown4;
        private System.Windows.Forms.Button button21;
        private System.Windows.Forms.TextBox textBox21;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.NumericUpDown numericUpDown5;
        private System.Windows.Forms.Button button22;
        private System.Windows.Forms.TextBox textBox22;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.NumericUpDown numericUpDown6;
        private System.Windows.Forms.Button button19;
        private System.Windows.Forms.TextBox textBox19;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.NumericUpDown numericUpDown3;
        private System.Windows.Forms.Button button18;
        private System.Windows.Forms.TextBox textBox18;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.TextBox textBox32;
        private System.Windows.Forms.Button RestoreDefaultsButton;
        private System.Windows.Forms.Button EditOutputPathButton;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.TextBox OutputPathTextbox;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.CheckBox ShowZoneOutlinesCheckbox;
        private System.Windows.Forms.NumericUpDown SegmentOffsetNumericUpDown;
        private System.Windows.Forms.NumericUpDown SegmentPaddingNumericUpDown;
        private System.Windows.Forms.NumericUpDown GridSegmentSizeNumericUpDown;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.CheckBox ShowGridLinesCheckbox;
        private System.Windows.Forms.Button SpaceportEditButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox SpaceportTextbox;
        private System.Windows.Forms.Button SeaportsEditButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox SeaportTextbox;
        private System.Windows.Forms.Button AirportsEditButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox AirportsTextbox;
        private System.Windows.Forms.Button MilitaryEditButton;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox MilitaryTextbox;
        private System.Windows.Forms.Button ZoneOutlinesEditButton;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox ZoneOutlinesTextbox;
        private System.Windows.Forms.Button GridLinesEditTextbox;
        private System.Windows.Forms.Button BuildingsEditButton;
        private System.Windows.Forms.Button GridBackgroundEditButton;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox BuildingsTextbox;
        private System.Windows.Forms.TextBox GridLinesTextbox;
        private System.Windows.Forms.TextBox GridBackgroundTextbox;
        private System.Windows.Forms.Button IndustrialZoneLowEditButton;
        private System.Windows.Forms.Button IndustrialZoneMidEditButton;
        private System.Windows.Forms.Button IndustrialZoneHighEditButton;
        private System.Windows.Forms.Button CommercialZoneHighEditButton;
        private System.Windows.Forms.Button CommercialZoneMidEditButton;
        private System.Windows.Forms.TextBox IndustrialZoneMidTextbox;
        private System.Windows.Forms.Button CommercialZoneLowEditButton;
        private System.Windows.Forms.TextBox IndustrialZoneHighTextbox;
        private System.Windows.Forms.TextBox CommercialZoneMidTextbox;
        private System.Windows.Forms.TextBox CommercialZoneHighTextbox;
        private System.Windows.Forms.TextBox IndustrialZoneLowTextbox;
        private System.Windows.Forms.TextBox CommercialZoneLowTextbox;
        private System.Windows.Forms.Button ResidentialZoneLowEditButton;
        private System.Windows.Forms.Button ResidentialZoneHighEditButton;
        private System.Windows.Forms.Button ResidentialZoneMidEditButton;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox ResidentialZoneHighTextbox;
        private System.Windows.Forms.TextBox ResidentialZoneMidTextbox;
        private System.Windows.Forms.TextBox ResidentialZoneLowTextbox;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.NumericUpDown numericUpDown18;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.NumericUpDown numericUpDown17;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.NumericUpDown numericUpDown16;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.TextBox textBox14;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.TextBox textBox13;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.TextBox textBox12;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton JPEGRadioButton;
        private System.Windows.Forms.RadioButton PNGRadioButton;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label33;
    }
}

