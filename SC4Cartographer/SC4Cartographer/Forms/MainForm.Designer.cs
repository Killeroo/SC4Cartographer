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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Terrain");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Buildings");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Low Density");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Medium Density");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("High Density");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Residential", new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode4,
            treeNode5});
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Low Density");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Medium Density");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("High Density");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Commercial", new System.Windows.Forms.TreeNode[] {
            treeNode7,
            treeNode8,
            treeNode9});
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Low Density");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Medium Density");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("High Density");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Industrial", new System.Windows.Forms.TreeNode[] {
            treeNode11,
            treeNode12,
            treeNode13});
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Plopped Building");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("Military");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("Airports");
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("Seaport");
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("Spaceport");
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("Other", new System.Windows.Forms.TreeNode[] {
            treeNode15,
            treeNode16,
            treeNode17,
            treeNode18,
            treeNode19});
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("Zones", new System.Windows.Forms.TreeNode[] {
            treeNode6,
            treeNode10,
            treeNode14,
            treeNode20});
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("Streets");
            System.Windows.Forms.TreeNode treeNode23 = new System.Windows.Forms.TreeNode("Roads");
            System.Windows.Forms.TreeNode treeNode24 = new System.Windows.Forms.TreeNode("One Way Roads");
            System.Windows.Forms.TreeNode treeNode25 = new System.Windows.Forms.TreeNode("Avenues");
            System.Windows.Forms.TreeNode treeNode26 = new System.Windows.Forms.TreeNode("Railways");
            System.Windows.Forms.TreeNode treeNode27 = new System.Windows.Forms.TreeNode("Subways");
            System.Windows.Forms.TreeNode treeNode28 = new System.Windows.Forms.TreeNode("Transport", new System.Windows.Forms.TreeNode[] {
            treeNode22,
            treeNode23,
            treeNode24,
            treeNode25,
            treeNode26,
            treeNode27});
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
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.appearanceStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.restoreDefaultsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.VisibleObjectsTreeView = new System.Windows.Forms.TreeView();
            this.BlendTerrainColorsCheckBox = new System.Windows.Forms.CheckBox();
            this.OutputFormatLabel = new System.Windows.Forms.Label();
            this.JPEGRadioButton = new System.Windows.Forms.RadioButton();
            this.PNGRadioButton = new System.Windows.Forms.RadioButton();
            this.EditOutputPathButton = new System.Windows.Forms.Button();
            this.PixelLabel2 = new System.Windows.Forms.Label();
            this.OutputPathTextbox = new System.Windows.Forms.TextBox();
            this.OutputPathLabel = new System.Windows.Forms.Label();
            this.PixelLabel1 = new System.Windows.Forms.Label();
            this.ShowZoneOutlinesCheckbox = new System.Windows.Forms.CheckBox();
            this.GridSegmentSizeNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.SegmentPaddingLabel = new System.Windows.Forms.Label();
            this.GridSegmentSizeLabel = new System.Windows.Forms.Label();
            this.ShowGridLinesCheckbox = new System.Windows.Forms.CheckBox();
            this.ColorsTabControl = new System.Windows.Forms.TabControl();
            this.GridTabPage = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.GridLinesEditTextbox = new System.Windows.Forms.Button();
            this.GridBackgroundEditButton = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.GridLinesTextbox = new System.Windows.Forms.TextBox();
            this.GridBackgroundTextbox = new System.Windows.Forms.TextBox();
            this.ZonesTabPage = new System.Windows.Forms.TabPage();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
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
            this.SegmentPaddingNumericUpDown = new System.Windows.Forms.NumericUpDown();
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
            this.PloppedBuildingsEditButton = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.PloppedBuildingsTextbox = new System.Windows.Forms.TextBox();
            this.TransportTabPage = new System.Windows.Forms.TabPage();
            this.SubwayEditButton = new System.Windows.Forms.Button();
            this.label45 = new System.Windows.Forms.Label();
            this.SubwayTextBox = new System.Windows.Forms.TextBox();
            this.RailwayEditButton = new System.Windows.Forms.Button();
            this.label44 = new System.Windows.Forms.Label();
            this.RailwayTextBox = new System.Windows.Forms.TextBox();
            this.AvenueEditButton = new System.Windows.Forms.Button();
            this.label43 = new System.Windows.Forms.Label();
            this.AvenueTextBox = new System.Windows.Forms.TextBox();
            this.OneWayRoadEditButton = new System.Windows.Forms.Button();
            this.label42 = new System.Windows.Forms.Label();
            this.OneWayRoadTextBox = new System.Windows.Forms.TextBox();
            this.RoadEditButton = new System.Windows.Forms.Button();
            this.label41 = new System.Windows.Forms.Label();
            this.RoadTextBox = new System.Windows.Forms.TextBox();
            this.StreetEditButton = new System.Windows.Forms.Button();
            this.label30 = new System.Windows.Forms.Label();
            this.StreetTextBox = new System.Windows.Forms.TextBox();
            this.TerrainTabPage = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.TerrainLayer23CheckBox = new System.Windows.Forms.CheckBox();
            this.TerrainLayer23AliasTextBox = new System.Windows.Forms.TextBox();
            this.TerrainLayer23Button = new System.Windows.Forms.Button();
            this.TerrainLayer23ColorTextBox = new System.Windows.Forms.TextBox();
            this.TerrainLayer23NumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.TerrainLayer22CheckBox = new System.Windows.Forms.CheckBox();
            this.TerrainLayer22AliasTextBox = new System.Windows.Forms.TextBox();
            this.TerrainLayer22Button = new System.Windows.Forms.Button();
            this.TerrainLayer22ColorTextBox = new System.Windows.Forms.TextBox();
            this.TerrainLayer22NumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.TerrainLayer21CheckBox = new System.Windows.Forms.CheckBox();
            this.TerrainLayer21AliasTextBox = new System.Windows.Forms.TextBox();
            this.TerrainLayer21Button = new System.Windows.Forms.Button();
            this.TerrainLayer21ColorTextBox = new System.Windows.Forms.TextBox();
            this.TerrainLayer21NumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.TerrainLayer20CheckBox = new System.Windows.Forms.CheckBox();
            this.TerrainLayer20AliasTextBox = new System.Windows.Forms.TextBox();
            this.TerrainLayer20Button = new System.Windows.Forms.Button();
            this.TerrainLayer20ColorTextBox = new System.Windows.Forms.TextBox();
            this.TerrainLayer20NumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.TerrainLayer19CheckBox = new System.Windows.Forms.CheckBox();
            this.TerrainLayer19AliasTextBox = new System.Windows.Forms.TextBox();
            this.TerrainLayer19Button = new System.Windows.Forms.Button();
            this.TerrainLayer19ColorTextBox = new System.Windows.Forms.TextBox();
            this.TerrainLayer19NumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.TerrainLayer18CheckBox = new System.Windows.Forms.CheckBox();
            this.TerrainLayer18AliasTextBox = new System.Windows.Forms.TextBox();
            this.TerrainLayer18Button = new System.Windows.Forms.Button();
            this.TerrainLayer18ColorTextBox = new System.Windows.Forms.TextBox();
            this.TerrainLayer18NumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.TerrainLayer17CheckBox = new System.Windows.Forms.CheckBox();
            this.TerrainLayer17AliasTextBox = new System.Windows.Forms.TextBox();
            this.TerrainLayer17Button = new System.Windows.Forms.Button();
            this.TerrainLayer17ColorTextBox = new System.Windows.Forms.TextBox();
            this.TerrainLayer17NumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.TerrainLayer16CheckBox = new System.Windows.Forms.CheckBox();
            this.TerrainLayer16AliasTextBox = new System.Windows.Forms.TextBox();
            this.TerrainLayer16Button = new System.Windows.Forms.Button();
            this.TerrainLayer16ColorTextBox = new System.Windows.Forms.TextBox();
            this.TerrainLayer16NumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.TerrainLayer15CheckBox = new System.Windows.Forms.CheckBox();
            this.TerrainLayer15AliasTextBox = new System.Windows.Forms.TextBox();
            this.TerrainLayer15Button = new System.Windows.Forms.Button();
            this.TerrainLayer15ColorTextBox = new System.Windows.Forms.TextBox();
            this.TerrainLayer15NumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.TerrainLayer14CheckBox = new System.Windows.Forms.CheckBox();
            this.TerrainLayer14AliasTextBox = new System.Windows.Forms.TextBox();
            this.TerrainLayer14Button = new System.Windows.Forms.Button();
            this.TerrainLayer14ColorTextBox = new System.Windows.Forms.TextBox();
            this.TerrainLayer14NumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.TerrainLayer13CheckBox = new System.Windows.Forms.CheckBox();
            this.TerrainLayer13AliasTextBox = new System.Windows.Forms.TextBox();
            this.TerrainLayer13Button = new System.Windows.Forms.Button();
            this.TerrainLayer13ColorTextBox = new System.Windows.Forms.TextBox();
            this.TerrainLayer13NumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.TerrainLayer12CheckBox = new System.Windows.Forms.CheckBox();
            this.TerrainLayer12AliasTextBox = new System.Windows.Forms.TextBox();
            this.TerrainLayer12Button = new System.Windows.Forms.Button();
            this.TerrainLayer12ColorTextBox = new System.Windows.Forms.TextBox();
            this.TerrainLayer12NumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.TerrainLayer11CheckBox = new System.Windows.Forms.CheckBox();
            this.TerrainLayer11AliasTextBox = new System.Windows.Forms.TextBox();
            this.TerrainLayer11Button = new System.Windows.Forms.Button();
            this.TerrainLayer11ColorTextBox = new System.Windows.Forms.TextBox();
            this.TerrainLayer11NumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.TerrainLayer10CheckBox = new System.Windows.Forms.CheckBox();
            this.TerrainLayer10AliasTextBox = new System.Windows.Forms.TextBox();
            this.TerrainLayer10Button = new System.Windows.Forms.Button();
            this.TerrainLayer10ColorTextBox = new System.Windows.Forms.TextBox();
            this.TerrainLayer10NumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.TerrainLayer9CheckBox = new System.Windows.Forms.CheckBox();
            this.TerrainLayer9AliasTextBox = new System.Windows.Forms.TextBox();
            this.TerrainLayer9Button = new System.Windows.Forms.Button();
            this.TerrainLayer9ColorTextBox = new System.Windows.Forms.TextBox();
            this.TerrainLayer9NumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.TerrainLayer8CheckBox = new System.Windows.Forms.CheckBox();
            this.TerrainLayer8AliasTextBox = new System.Windows.Forms.TextBox();
            this.TerrainLayer8Button = new System.Windows.Forms.Button();
            this.TerrainLayer8ColorTextBox = new System.Windows.Forms.TextBox();
            this.TerrainLayer8NumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.TerrainLayer7CheckBox = new System.Windows.Forms.CheckBox();
            this.TerrainLayer7AliasTextBox = new System.Windows.Forms.TextBox();
            this.TerrainLayer7Button = new System.Windows.Forms.Button();
            this.TerrainLayer7ColorTextBox = new System.Windows.Forms.TextBox();
            this.TerrainLayer7NumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.TerrainLayer6CheckBox = new System.Windows.Forms.CheckBox();
            this.TerrainLayer6AliasTextBox = new System.Windows.Forms.TextBox();
            this.TerrainLayer6Button = new System.Windows.Forms.Button();
            this.TerrainLayer6ColorTextBox = new System.Windows.Forms.TextBox();
            this.TerrainLayer6NumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.TerrainLayer5CheckBox = new System.Windows.Forms.CheckBox();
            this.TerrainLayer5AliasTextBox = new System.Windows.Forms.TextBox();
            this.TerrainLayer5Button = new System.Windows.Forms.Button();
            this.TerrainLayer5ColorTextBox = new System.Windows.Forms.TextBox();
            this.TerrainLayer5NumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.TerrainLayer4CheckBox = new System.Windows.Forms.CheckBox();
            this.TerrainLayer4AliasTextBox = new System.Windows.Forms.TextBox();
            this.TerrainLayer4Button = new System.Windows.Forms.Button();
            this.TerrainLayer4ColorTextBox = new System.Windows.Forms.TextBox();
            this.TerrainLayer4NumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.TerrainLayer3CheckBox = new System.Windows.Forms.CheckBox();
            this.TerrainLayer3AliasTextBox = new System.Windows.Forms.TextBox();
            this.TerrainLayer3Button = new System.Windows.Forms.Button();
            this.TerrainLayer3ColorTextBox = new System.Windows.Forms.TextBox();
            this.TerrainLayer3NumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.TerrainLayer2CheckBox = new System.Windows.Forms.CheckBox();
            this.TerrainLayer2AliasTextBox = new System.Windows.Forms.TextBox();
            this.TerrainLayer2Button = new System.Windows.Forms.Button();
            this.TerrainLayer2ColorTextBox = new System.Windows.Forms.TextBox();
            this.TerrainLayer2NumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.TerrainLayer1CheckBox = new System.Windows.Forms.CheckBox();
            this.TerrainLayer1AliasTextBox = new System.Windows.Forms.TextBox();
            this.TerrainLayer1Button = new System.Windows.Forms.Button();
            this.TerrainLayer1ColorTextBox = new System.Windows.Forms.TextBox();
            this.TerrainLayer1NumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.BuildingTabPage = new System.Windows.Forms.TabPage();
            this.BuildingsOutlineEditButton = new System.Windows.Forms.Button();
            this.label22 = new System.Windows.Forms.Label();
            this.BuildingsOutlineTextBox = new System.Windows.Forms.TextBox();
            this.ShowBuildingOutlinesCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.BuildingsEditButton = new System.Windows.Forms.Button();
            this.label21 = new System.Windows.Forms.Label();
            this.BuildingsTextBox = new System.Windows.Forms.TextBox();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.ZoomTrackBar = new System.Windows.Forms.TrackBar();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.ResetZoomButton = new System.Windows.Forms.Button();
            this.SizesComboBox = new System.Windows.Forms.ComboBox();
            this.SizeLabel = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MapPictureBox)).BeginInit();
            this.groupBox6.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.AppearanceGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridSegmentSizeNumericUpDown)).BeginInit();
            this.ColorsTabControl.SuspendLayout();
            this.GridTabPage.SuspendLayout();
            this.ZonesTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SegmentPaddingNumericUpDown)).BeginInit();
            this.TransportTabPage.SuspendLayout();
            this.TerrainTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TerrainLayer23NumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TerrainLayer22NumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TerrainLayer21NumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TerrainLayer20NumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TerrainLayer19NumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TerrainLayer18NumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TerrainLayer17NumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TerrainLayer16NumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TerrainLayer15NumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TerrainLayer14NumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TerrainLayer13NumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TerrainLayer12NumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TerrainLayer11NumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TerrainLayer10NumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TerrainLayer9NumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TerrainLayer8NumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TerrainLayer7NumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TerrainLayer6NumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TerrainLayer5NumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TerrainLayer4NumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TerrainLayer3NumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TerrainLayer2NumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TerrainLayer1NumericUpDown)).BeginInit();
            this.BuildingTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ZoomTrackBar)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
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
            this.groupBox1.Size = new System.Drawing.Size(665, 677);
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
            this.panel1.Size = new System.Drawing.Size(653, 651);
            this.panel1.TabIndex = 2;
            this.panel1.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.Panel1_MouseWheel);
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
            this.MapPictureBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.MapPictureBox.Location = new System.Drawing.Point(0, 0);
            this.MapPictureBox.Name = "MapPictureBox";
            this.MapPictureBox.Size = new System.Drawing.Size(653, 651);
            this.MapPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.MapPictureBox.TabIndex = 2;
            this.MapPictureBox.TabStop = false;
            this.MapPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MapPictureBox_MouseDown);
            this.MapPictureBox.MouseLeave += new System.EventHandler(this.MapPictureBox_MouseLeave);
            this.MapPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MapPictureBox_MouseMove);
            this.MapPictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MapPictureBox_MouseUp);
            // 
            // SaveButton
            // 
            this.SaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveButton.Enabled = false;
            this.SaveButton.Location = new System.Drawing.Point(875, 665);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(295, 38);
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
            this.groupBox6.Size = new System.Drawing.Size(186, 677);
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
            this.FilterNewCitiesCheckbox.Location = new System.Drawing.Point(7, 654);
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
            this.FileTreeView.Size = new System.Drawing.Size(174, 602);
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
            this.appearanceStripMenuItem,
            this.helpToolStripMenuItem});
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
            this.loadSC4SaveToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.loadSC4SaveToolStripMenuItem.Text = "Open";
            // 
            // savegameToolStripMenuItem
            // 
            this.savegameToolStripMenuItem.Name = "savegameToolStripMenuItem";
            this.savegameToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.savegameToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.savegameToolStripMenuItem.Text = "Save Game...";
            this.savegameToolStripMenuItem.Click += new System.EventHandler(this.savegameToolStripMenuItem_Click);
            // 
            // folderToolStripMenuItem
            // 
            this.folderToolStripMenuItem.Name = "folderToolStripMenuItem";
            this.folderToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.folderToolStripMenuItem.Text = "Folder...";
            this.folderToolStripMenuItem.Click += new System.EventHandler(this.folderToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(195, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Enabled = false;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Enabled = false;
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.saveAsToolStripMenuItem.Text = "Save As....";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(195, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // appearanceStripMenuItem
            // 
            this.appearanceStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem1,
            this.loadToolStripMenuItem,
            this.toolStripSeparator6,
            this.restoreDefaultsToolStripMenuItem});
            this.appearanceStripMenuItem.Name = "appearanceStripMenuItem";
            this.appearanceStripMenuItem.Size = new System.Drawing.Size(82, 20);
            this.appearanceStripMenuItem.Text = "Appearance";
            // 
            // saveToolStripMenuItem1
            // 
            this.saveToolStripMenuItem1.Name = "saveToolStripMenuItem1";
            this.saveToolStripMenuItem1.Size = new System.Drawing.Size(159, 22);
            this.saveToolStripMenuItem1.Text = "Save...";
            this.saveToolStripMenuItem1.Click += new System.EventHandler(this.saveToolStripMenuItem1_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.loadToolStripMenuItem.Text = "Load...";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(156, 6);
            // 
            // restoreDefaultsToolStripMenuItem
            // 
            this.restoreDefaultsToolStripMenuItem.Name = "restoreDefaultsToolStripMenuItem";
            this.restoreDefaultsToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.restoreDefaultsToolStripMenuItem.Text = "Restore Defaults";
            this.restoreDefaultsToolStripMenuItem.Click += new System.EventHandler(this.restoreDefaultsToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UpdatesToolStripMenuItem,
            this.toolStripSeparator4,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.toolStripSeparator5,
            this.toolStripMenuItem6,
            this.toolStripSeparator3,
            this.toolStripMenuItem5});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // UpdatesToolStripMenuItem
            // 
            this.UpdatesToolStripMenuItem.Name = "UpdatesToolStripMenuItem";
            this.UpdatesToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.UpdatesToolStripMenuItem.Text = "Check for Updates";
            this.UpdatesToolStripMenuItem.Click += new System.EventHandler(this.UpdatesToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(168, 6);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(171, 22);
            this.toolStripMenuItem3.Text = "Project Webpage";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.projectWebpageToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(171, 22);
            this.toolStripMenuItem4.Text = "Report an Issue";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.reportABugToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(168, 6);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(171, 22);
            this.toolStripMenuItem6.Text = "Show Log...";
            this.toolStripMenuItem6.Click += new System.EventHandler(this.toolStripMenuItem6_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(168, 6);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(171, 22);
            this.toolStripMenuItem5.Text = "About";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MapSizeToolStripStatusLabel,
            this.MemoryUsedToolStripStatusLabel,
            this.MousePositionToolStripStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 709);
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
            this.AppearanceGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AppearanceGroupBox.Controls.Add(this.VisibleObjectsTreeView);
            this.AppearanceGroupBox.Enabled = false;
            this.AppearanceGroupBox.Location = new System.Drawing.Point(875, 27);
            this.AppearanceGroupBox.Name = "AppearanceGroupBox";
            this.AppearanceGroupBox.Size = new System.Drawing.Size(295, 195);
            this.AppearanceGroupBox.TabIndex = 11;
            this.AppearanceGroupBox.TabStop = false;
            this.AppearanceGroupBox.Text = "Layers";
            // 
            // VisibleObjectsTreeView
            // 
            this.VisibleObjectsTreeView.CheckBoxes = true;
            this.VisibleObjectsTreeView.Location = new System.Drawing.Point(6, 19);
            this.VisibleObjectsTreeView.Name = "VisibleObjectsTreeView";
            treeNode1.Name = "Node1";
            treeNode1.Tag = "TerrainMap";
            treeNode1.Text = "Terrain";
            treeNode2.Name = "Node1";
            treeNode2.Tag = "Buildings";
            treeNode2.Text = "Buildings";
            treeNode3.Name = "ResidentialLowDensity";
            treeNode3.Tag = "ResidentialLowZone";
            treeNode3.Text = "Low Density";
            treeNode4.Name = "ResidentialMediumDensity";
            treeNode4.Tag = "ResidentialMidZone";
            treeNode4.Text = "Medium Density";
            treeNode5.Name = "ResidentialHighDensity";
            treeNode5.Tag = "ResidentialHighZone";
            treeNode5.Text = "High Density";
            treeNode6.Name = "ResidentialRootNode";
            treeNode6.Tag = "Residential";
            treeNode6.Text = "Residential";
            treeNode7.Name = "CommercialLowDensity";
            treeNode7.Tag = "CommercialLowZone";
            treeNode7.Text = "Low Density";
            treeNode8.Name = "CommercialMediumDensity";
            treeNode8.Tag = "CommercialMidZone";
            treeNode8.Text = "Medium Density";
            treeNode9.Name = "CommercialHighDensity";
            treeNode9.Tag = "CommercialHighZone";
            treeNode9.Text = "High Density";
            treeNode10.Name = "CommercialRootNode";
            treeNode10.Tag = "Commercial";
            treeNode10.Text = "Commercial";
            treeNode11.Name = "IndustrialLowDensity";
            treeNode11.Tag = "IndustrialLowZone";
            treeNode11.Text = "Low Density";
            treeNode12.Name = "IndustrialMediumDensity";
            treeNode12.Tag = "IndustrialMidZone";
            treeNode12.Text = "Medium Density";
            treeNode13.Name = "IndustrialHighDensity";
            treeNode13.Tag = "IndustrialHighZone";
            treeNode13.Text = "High Density";
            treeNode14.Name = "IndustrialRootNode";
            treeNode14.Tag = "Industrial";
            treeNode14.Text = "Industrial";
            treeNode15.Name = "PloppedBuildingZone";
            treeNode15.Tag = "PloppedBuildingZone";
            treeNode15.Text = "Plopped Building";
            treeNode16.Name = "MilitaryZone";
            treeNode16.Tag = "MilitaryZone";
            treeNode16.Text = "Military";
            treeNode17.Name = "AirportsZone";
            treeNode17.Tag = "AirportZone";
            treeNode17.Text = "Airports";
            treeNode18.Name = "SeaportZones";
            treeNode18.Tag = "SeaportZone";
            treeNode18.Text = "Seaport";
            treeNode19.Name = "SpaceportZone";
            treeNode19.Tag = "SpaceportZone";
            treeNode19.Text = "Spaceport";
            treeNode20.Name = "Other";
            treeNode20.Tag = "Other";
            treeNode20.Text = "Other";
            treeNode21.Name = "Node0";
            treeNode21.Tag = "Zones";
            treeNode21.Text = "Zones";
            treeNode22.Name = "Streets";
            treeNode22.Tag = "Streets";
            treeNode22.Text = "Streets";
            treeNode23.Name = "Roads";
            treeNode23.Tag = "Roads";
            treeNode23.Text = "Roads";
            treeNode24.Name = "OneWayRoads";
            treeNode24.Tag = "OneWayRoads";
            treeNode24.Text = "One Way Roads";
            treeNode25.Name = "Avenues";
            treeNode25.Tag = "Avenues";
            treeNode25.Text = "Avenues";
            treeNode26.Name = "Railways";
            treeNode26.Tag = "Railways";
            treeNode26.Text = "Railways";
            treeNode27.Name = "Subways";
            treeNode27.Tag = "Subways";
            treeNode27.Text = "Subways";
            treeNode28.Name = "Node0";
            treeNode28.Text = "Transport";
            this.VisibleObjectsTreeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode21,
            treeNode28});
            this.VisibleObjectsTreeView.Size = new System.Drawing.Size(283, 168);
            this.VisibleObjectsTreeView.TabIndex = 1;
            this.VisibleObjectsTreeView.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.VisibleObjectsTreeView_AfterCheck);
            // 
            // BlendTerrainColorsCheckBox
            // 
            this.BlendTerrainColorsCheckBox.AutoSize = true;
            this.BlendTerrainColorsCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BlendTerrainColorsCheckBox.Location = new System.Drawing.Point(10, 9);
            this.BlendTerrainColorsCheckBox.Name = "BlendTerrainColorsCheckBox";
            this.BlendTerrainColorsCheckBox.Size = new System.Drawing.Size(121, 17);
            this.BlendTerrainColorsCheckBox.TabIndex = 70;
            this.BlendTerrainColorsCheckBox.Text = "Blend Terrain Colors";
            this.BlendTerrainColorsCheckBox.UseVisualStyleBackColor = true;
            // 
            // OutputFormatLabel
            // 
            this.OutputFormatLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.OutputFormatLabel.AutoSize = true;
            this.OutputFormatLabel.Location = new System.Drawing.Point(12, 48);
            this.OutputFormatLabel.Name = "OutputFormatLabel";
            this.OutputFormatLabel.Size = new System.Drawing.Size(39, 13);
            this.OutputFormatLabel.TabIndex = 69;
            this.OutputFormatLabel.Text = "Format";
            // 
            // JPEGRadioButton
            // 
            this.JPEGRadioButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.JPEGRadioButton.AutoSize = true;
            this.JPEGRadioButton.Location = new System.Drawing.Point(150, 46);
            this.JPEGRadioButton.Name = "JPEGRadioButton";
            this.JPEGRadioButton.Size = new System.Drawing.Size(52, 17);
            this.JPEGRadioButton.TabIndex = 68;
            this.JPEGRadioButton.TabStop = true;
            this.JPEGRadioButton.Text = "JPEG";
            this.JPEGRadioButton.UseVisualStyleBackColor = true;
            this.JPEGRadioButton.CheckedChanged += new System.EventHandler(this.JPEGRadioButton_CheckedChanged);
            // 
            // PNGRadioButton
            // 
            this.PNGRadioButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.PNGRadioButton.AutoSize = true;
            this.PNGRadioButton.Location = new System.Drawing.Point(96, 46);
            this.PNGRadioButton.Name = "PNGRadioButton";
            this.PNGRadioButton.Size = new System.Drawing.Size(48, 17);
            this.PNGRadioButton.TabIndex = 67;
            this.PNGRadioButton.TabStop = true;
            this.PNGRadioButton.Text = "PNG";
            this.PNGRadioButton.UseVisualStyleBackColor = true;
            this.PNGRadioButton.CheckedChanged += new System.EventHandler(this.PNGRadioButton_CheckedChanged);
            // 
            // EditOutputPathButton
            // 
            this.EditOutputPathButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.EditOutputPathButton.Location = new System.Drawing.Point(257, 67);
            this.EditOutputPathButton.Name = "EditOutputPathButton";
            this.EditOutputPathButton.Size = new System.Drawing.Size(30, 23);
            this.EditOutputPathButton.TabIndex = 63;
            this.EditOutputPathButton.Text = "...";
            this.EditOutputPathButton.UseVisualStyleBackColor = true;
            // 
            // PixelLabel2
            // 
            this.PixelLabel2.AutoSize = true;
            this.PixelLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PixelLabel2.Location = new System.Drawing.Point(175, 9);
            this.PixelLabel2.Name = "PixelLabel2";
            this.PixelLabel2.Size = new System.Drawing.Size(18, 13);
            this.PixelLabel2.TabIndex = 59;
            this.PixelLabel2.Text = "px";
            // 
            // OutputPathTextbox
            // 
            this.OutputPathTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.OutputPathTextbox.Location = new System.Drawing.Point(96, 69);
            this.OutputPathTextbox.Name = "OutputPathTextbox";
            this.OutputPathTextbox.Size = new System.Drawing.Size(155, 20);
            this.OutputPathTextbox.TabIndex = 62;
            this.OutputPathTextbox.TextChanged += new System.EventHandler(this.OutputPathTextbox_TextChanged);
            // 
            // OutputPathLabel
            // 
            this.OutputPathLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.OutputPathLabel.AutoSize = true;
            this.OutputPathLabel.Location = new System.Drawing.Point(13, 72);
            this.OutputPathLabel.Name = "OutputPathLabel";
            this.OutputPathLabel.Size = new System.Drawing.Size(29, 13);
            this.OutputPathLabel.TabIndex = 61;
            this.OutputPathLabel.Text = "Path";
            // 
            // PixelLabel1
            // 
            this.PixelLabel1.AutoSize = true;
            this.PixelLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PixelLabel1.Location = new System.Drawing.Point(175, 9);
            this.PixelLabel1.Name = "PixelLabel1";
            this.PixelLabel1.Size = new System.Drawing.Size(18, 13);
            this.PixelLabel1.TabIndex = 58;
            this.PixelLabel1.Text = "px";
            // 
            // ShowZoneOutlinesCheckbox
            // 
            this.ShowZoneOutlinesCheckbox.AutoSize = true;
            this.ShowZoneOutlinesCheckbox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ShowZoneOutlinesCheckbox.Location = new System.Drawing.Point(16, 32);
            this.ShowZoneOutlinesCheckbox.Name = "ShowZoneOutlinesCheckbox";
            this.ShowZoneOutlinesCheckbox.Size = new System.Drawing.Size(122, 17);
            this.ShowZoneOutlinesCheckbox.TabIndex = 56;
            this.ShowZoneOutlinesCheckbox.Text = "Show Zone Outlines";
            this.ShowZoneOutlinesCheckbox.UseVisualStyleBackColor = true;
            // 
            // GridSegmentSizeNumericUpDown
            // 
            this.GridSegmentSizeNumericUpDown.Location = new System.Drawing.Point(123, 6);
            this.GridSegmentSizeNumericUpDown.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.GridSegmentSizeNumericUpDown.Name = "GridSegmentSizeNumericUpDown";
            this.GridSegmentSizeNumericUpDown.Size = new System.Drawing.Size(49, 20);
            this.GridSegmentSizeNumericUpDown.TabIndex = 53;
            // 
            // SegmentPaddingLabel
            // 
            this.SegmentPaddingLabel.AutoSize = true;
            this.SegmentPaddingLabel.Location = new System.Drawing.Point(46, 9);
            this.SegmentPaddingLabel.Name = "SegmentPaddingLabel";
            this.SegmentPaddingLabel.Size = new System.Drawing.Size(74, 13);
            this.SegmentPaddingLabel.TabIndex = 51;
            this.SegmentPaddingLabel.Text = "Zone Padding";
            // 
            // GridSegmentSizeLabel
            // 
            this.GridSegmentSizeLabel.AutoSize = true;
            this.GridSegmentSizeLabel.Location = new System.Drawing.Point(25, 9);
            this.GridSegmentSizeLabel.Name = "GridSegmentSizeLabel";
            this.GridSegmentSizeLabel.Size = new System.Drawing.Size(94, 13);
            this.GridSegmentSizeLabel.TabIndex = 50;
            this.GridSegmentSizeLabel.Text = "Grid Segment Size";
            // 
            // ShowGridLinesCheckbox
            // 
            this.ShowGridLinesCheckbox.AutoSize = true;
            this.ShowGridLinesCheckbox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ShowGridLinesCheckbox.Location = new System.Drawing.Point(34, 32);
            this.ShowGridLinesCheckbox.Name = "ShowGridLinesCheckbox";
            this.ShowGridLinesCheckbox.Size = new System.Drawing.Size(103, 17);
            this.ShowGridLinesCheckbox.TabIndex = 49;
            this.ShowGridLinesCheckbox.Text = "Show Grid Lines";
            this.ShowGridLinesCheckbox.UseVisualStyleBackColor = true;
            // 
            // ColorsTabControl
            // 
            this.ColorsTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ColorsTabControl.Controls.Add(this.GridTabPage);
            this.ColorsTabControl.Controls.Add(this.ZonesTabPage);
            this.ColorsTabControl.Controls.Add(this.TransportTabPage);
            this.ColorsTabControl.Controls.Add(this.TerrainTabPage);
            this.ColorsTabControl.Controls.Add(this.BuildingTabPage);
            this.ColorsTabControl.Location = new System.Drawing.Point(12, 19);
            this.ColorsTabControl.Name = "ColorsTabControl";
            this.ColorsTabControl.SelectedIndex = 0;
            this.ColorsTabControl.Size = new System.Drawing.Size(277, 305);
            this.ColorsTabControl.TabIndex = 2;
            // 
            // GridTabPage
            // 
            this.GridTabPage.Controls.Add(this.groupBox2);
            this.GridTabPage.Controls.Add(this.GridLinesEditTextbox);
            this.GridTabPage.Controls.Add(this.GridBackgroundEditButton);
            this.GridTabPage.Controls.Add(this.label11);
            this.GridTabPage.Controls.Add(this.label10);
            this.GridTabPage.Controls.Add(this.GridLinesTextbox);
            this.GridTabPage.Controls.Add(this.GridBackgroundTextbox);
            this.GridTabPage.Controls.Add(this.ShowGridLinesCheckbox);
            this.GridTabPage.Controls.Add(this.GridSegmentSizeLabel);
            this.GridTabPage.Controls.Add(this.GridSegmentSizeNumericUpDown);
            this.GridTabPage.Controls.Add(this.PixelLabel1);
            this.GridTabPage.Location = new System.Drawing.Point(4, 22);
            this.GridTabPage.Name = "GridTabPage";
            this.GridTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.GridTabPage.Size = new System.Drawing.Size(269, 279);
            this.GridTabPage.TabIndex = 3;
            this.GridTabPage.Text = "Grid";
            this.GridTabPage.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(6, 55);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(266, 2);
            this.groupBox2.TabIndex = 72;
            this.groupBox2.TabStop = false;
            // 
            // GridLinesEditTextbox
            // 
            this.GridLinesEditTextbox.Location = new System.Drawing.Point(228, 88);
            this.GridLinesEditTextbox.Name = "GridLinesEditTextbox";
            this.GridLinesEditTextbox.Size = new System.Drawing.Size(34, 23);
            this.GridLinesEditTextbox.TabIndex = 71;
            this.GridLinesEditTextbox.Text = "Edit";
            this.GridLinesEditTextbox.UseVisualStyleBackColor = true;
            // 
            // GridBackgroundEditButton
            // 
            this.GridBackgroundEditButton.Location = new System.Drawing.Point(228, 65);
            this.GridBackgroundEditButton.Name = "GridBackgroundEditButton";
            this.GridBackgroundEditButton.Size = new System.Drawing.Size(34, 23);
            this.GridBackgroundEditButton.TabIndex = 67;
            this.GridBackgroundEditButton.Text = "Edit";
            this.GridBackgroundEditButton.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(10, 93);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(54, 13);
            this.label11.TabIndex = 70;
            this.label11.Text = "Grid Lines";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 70);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(87, 13);
            this.label10.TabIndex = 69;
            this.label10.Text = "Grid Background";
            // 
            // GridLinesTextbox
            // 
            this.GridLinesTextbox.Enabled = false;
            this.GridLinesTextbox.ForeColor = System.Drawing.Color.Maroon;
            this.GridLinesTextbox.Location = new System.Drawing.Point(138, 90);
            this.GridLinesTextbox.Name = "GridLinesTextbox";
            this.GridLinesTextbox.Size = new System.Drawing.Size(84, 20);
            this.GridLinesTextbox.TabIndex = 68;
            // 
            // GridBackgroundTextbox
            // 
            this.GridBackgroundTextbox.Enabled = false;
            this.GridBackgroundTextbox.ForeColor = System.Drawing.Color.Maroon;
            this.GridBackgroundTextbox.Location = new System.Drawing.Point(138, 67);
            this.GridBackgroundTextbox.Name = "GridBackgroundTextbox";
            this.GridBackgroundTextbox.Size = new System.Drawing.Size(84, 20);
            this.GridBackgroundTextbox.TabIndex = 66;
            // 
            // ZonesTabPage
            // 
            this.ZonesTabPage.AutoScroll = true;
            this.ZonesTabPage.Controls.Add(this.ShowZoneOutlinesCheckbox);
            this.ZonesTabPage.Controls.Add(this.groupBox7);
            this.ZonesTabPage.Controls.Add(this.IndustrialZoneLowEditButton);
            this.ZonesTabPage.Controls.Add(this.IndustrialZoneMidEditButton);
            this.ZonesTabPage.Controls.Add(this.IndustrialZoneHighEditButton);
            this.ZonesTabPage.Controls.Add(this.CommercialZoneHighEditButton);
            this.ZonesTabPage.Controls.Add(this.CommercialZoneMidEditButton);
            this.ZonesTabPage.Controls.Add(this.IndustrialZoneMidTextbox);
            this.ZonesTabPage.Controls.Add(this.CommercialZoneLowEditButton);
            this.ZonesTabPage.Controls.Add(this.IndustrialZoneHighTextbox);
            this.ZonesTabPage.Controls.Add(this.CommercialZoneMidTextbox);
            this.ZonesTabPage.Controls.Add(this.PixelLabel2);
            this.ZonesTabPage.Controls.Add(this.CommercialZoneHighTextbox);
            this.ZonesTabPage.Controls.Add(this.IndustrialZoneLowTextbox);
            this.ZonesTabPage.Controls.Add(this.CommercialZoneLowTextbox);
            this.ZonesTabPage.Controls.Add(this.ResidentialZoneLowEditButton);
            this.ZonesTabPage.Controls.Add(this.SegmentPaddingNumericUpDown);
            this.ZonesTabPage.Controls.Add(this.ResidentialZoneHighEditButton);
            this.ZonesTabPage.Controls.Add(this.ResidentialZoneMidEditButton);
            this.ZonesTabPage.Controls.Add(this.label7);
            this.ZonesTabPage.Controls.Add(this.SegmentPaddingLabel);
            this.ZonesTabPage.Controls.Add(this.label8);
            this.ZonesTabPage.Controls.Add(this.label9);
            this.ZonesTabPage.Controls.Add(this.label6);
            this.ZonesTabPage.Controls.Add(this.label5);
            this.ZonesTabPage.Controls.Add(this.label4);
            this.ZonesTabPage.Controls.Add(this.label13);
            this.ZonesTabPage.Controls.Add(this.label14);
            this.ZonesTabPage.Controls.Add(this.ResidentialZoneHighTextbox);
            this.ZonesTabPage.Controls.Add(this.ResidentialZoneMidTextbox);
            this.ZonesTabPage.Controls.Add(this.ResidentialZoneLowTextbox);
            this.ZonesTabPage.Controls.Add(this.label15);
            this.ZonesTabPage.Controls.Add(this.SpaceportEditButton);
            this.ZonesTabPage.Controls.Add(this.label1);
            this.ZonesTabPage.Controls.Add(this.SpaceportTextbox);
            this.ZonesTabPage.Controls.Add(this.SeaportsEditButton);
            this.ZonesTabPage.Controls.Add(this.label2);
            this.ZonesTabPage.Controls.Add(this.SeaportTextbox);
            this.ZonesTabPage.Controls.Add(this.AirportsEditButton);
            this.ZonesTabPage.Controls.Add(this.label3);
            this.ZonesTabPage.Controls.Add(this.AirportsTextbox);
            this.ZonesTabPage.Controls.Add(this.MilitaryEditButton);
            this.ZonesTabPage.Controls.Add(this.label17);
            this.ZonesTabPage.Controls.Add(this.MilitaryTextbox);
            this.ZonesTabPage.Controls.Add(this.ZoneOutlinesEditButton);
            this.ZonesTabPage.Controls.Add(this.label16);
            this.ZonesTabPage.Controls.Add(this.ZoneOutlinesTextbox);
            this.ZonesTabPage.Controls.Add(this.PloppedBuildingsEditButton);
            this.ZonesTabPage.Controls.Add(this.label12);
            this.ZonesTabPage.Controls.Add(this.PloppedBuildingsTextbox);
            this.ZonesTabPage.Location = new System.Drawing.Point(4, 22);
            this.ZonesTabPage.Name = "ZonesTabPage";
            this.ZonesTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.ZonesTabPage.Size = new System.Drawing.Size(269, 279);
            this.ZonesTabPage.TabIndex = 0;
            this.ZonesTabPage.Text = "Zones";
            this.ZonesTabPage.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            this.groupBox7.Location = new System.Drawing.Point(6, 53);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(241, 5);
            this.groupBox7.TabIndex = 108;
            this.groupBox7.TabStop = false;
            // 
            // IndustrialZoneLowEditButton
            // 
            this.IndustrialZoneLowEditButton.Location = new System.Drawing.Point(215, 341);
            this.IndustrialZoneLowEditButton.Name = "IndustrialZoneLowEditButton";
            this.IndustrialZoneLowEditButton.Size = new System.Drawing.Size(34, 23);
            this.IndustrialZoneLowEditButton.TabIndex = 107;
            this.IndustrialZoneLowEditButton.Text = "Edit";
            this.IndustrialZoneLowEditButton.UseVisualStyleBackColor = true;
            // 
            // IndustrialZoneMidEditButton
            // 
            this.IndustrialZoneMidEditButton.Location = new System.Drawing.Point(215, 364);
            this.IndustrialZoneMidEditButton.Name = "IndustrialZoneMidEditButton";
            this.IndustrialZoneMidEditButton.Size = new System.Drawing.Size(34, 23);
            this.IndustrialZoneMidEditButton.TabIndex = 106;
            this.IndustrialZoneMidEditButton.Text = "Edit";
            this.IndustrialZoneMidEditButton.UseVisualStyleBackColor = true;
            // 
            // IndustrialZoneHighEditButton
            // 
            this.IndustrialZoneHighEditButton.Location = new System.Drawing.Point(215, 387);
            this.IndustrialZoneHighEditButton.Name = "IndustrialZoneHighEditButton";
            this.IndustrialZoneHighEditButton.Size = new System.Drawing.Size(34, 23);
            this.IndustrialZoneHighEditButton.TabIndex = 105;
            this.IndustrialZoneHighEditButton.Text = "Edit";
            this.IndustrialZoneHighEditButton.UseVisualStyleBackColor = true;
            // 
            // CommercialZoneHighEditButton
            // 
            this.CommercialZoneHighEditButton.Location = new System.Drawing.Point(215, 318);
            this.CommercialZoneHighEditButton.Name = "CommercialZoneHighEditButton";
            this.CommercialZoneHighEditButton.Size = new System.Drawing.Size(34, 23);
            this.CommercialZoneHighEditButton.TabIndex = 94;
            this.CommercialZoneHighEditButton.Text = "Edit";
            this.CommercialZoneHighEditButton.UseVisualStyleBackColor = true;
            // 
            // CommercialZoneMidEditButton
            // 
            this.CommercialZoneMidEditButton.Location = new System.Drawing.Point(215, 295);
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
            this.IndustrialZoneMidTextbox.Location = new System.Drawing.Point(125, 366);
            this.IndustrialZoneMidTextbox.Name = "IndustrialZoneMidTextbox";
            this.IndustrialZoneMidTextbox.Size = new System.Drawing.Size(84, 20);
            this.IndustrialZoneMidTextbox.TabIndex = 104;
            // 
            // CommercialZoneLowEditButton
            // 
            this.CommercialZoneLowEditButton.Location = new System.Drawing.Point(215, 272);
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
            this.IndustrialZoneHighTextbox.Location = new System.Drawing.Point(125, 389);
            this.IndustrialZoneHighTextbox.Name = "IndustrialZoneHighTextbox";
            this.IndustrialZoneHighTextbox.Size = new System.Drawing.Size(84, 20);
            this.IndustrialZoneHighTextbox.TabIndex = 103;
            // 
            // CommercialZoneMidTextbox
            // 
            this.CommercialZoneMidTextbox.Enabled = false;
            this.CommercialZoneMidTextbox.ForeColor = System.Drawing.Color.Maroon;
            this.CommercialZoneMidTextbox.Location = new System.Drawing.Point(125, 297);
            this.CommercialZoneMidTextbox.Name = "CommercialZoneMidTextbox";
            this.CommercialZoneMidTextbox.Size = new System.Drawing.Size(84, 20);
            this.CommercialZoneMidTextbox.TabIndex = 102;
            // 
            // CommercialZoneHighTextbox
            // 
            this.CommercialZoneHighTextbox.Enabled = false;
            this.CommercialZoneHighTextbox.ForeColor = System.Drawing.Color.Maroon;
            this.CommercialZoneHighTextbox.Location = new System.Drawing.Point(125, 320);
            this.CommercialZoneHighTextbox.Name = "CommercialZoneHighTextbox";
            this.CommercialZoneHighTextbox.Size = new System.Drawing.Size(84, 20);
            this.CommercialZoneHighTextbox.TabIndex = 101;
            // 
            // IndustrialZoneLowTextbox
            // 
            this.IndustrialZoneLowTextbox.Enabled = false;
            this.IndustrialZoneLowTextbox.ForeColor = System.Drawing.Color.Maroon;
            this.IndustrialZoneLowTextbox.Location = new System.Drawing.Point(125, 343);
            this.IndustrialZoneLowTextbox.Name = "IndustrialZoneLowTextbox";
            this.IndustrialZoneLowTextbox.Size = new System.Drawing.Size(84, 20);
            this.IndustrialZoneLowTextbox.TabIndex = 100;
            // 
            // CommercialZoneLowTextbox
            // 
            this.CommercialZoneLowTextbox.Enabled = false;
            this.CommercialZoneLowTextbox.ForeColor = System.Drawing.Color.Maroon;
            this.CommercialZoneLowTextbox.Location = new System.Drawing.Point(125, 274);
            this.CommercialZoneLowTextbox.Name = "CommercialZoneLowTextbox";
            this.CommercialZoneLowTextbox.Size = new System.Drawing.Size(84, 20);
            this.CommercialZoneLowTextbox.TabIndex = 99;
            // 
            // ResidentialZoneLowEditButton
            // 
            this.ResidentialZoneLowEditButton.Location = new System.Drawing.Point(215, 203);
            this.ResidentialZoneLowEditButton.Name = "ResidentialZoneLowEditButton";
            this.ResidentialZoneLowEditButton.Size = new System.Drawing.Size(34, 23);
            this.ResidentialZoneLowEditButton.TabIndex = 98;
            this.ResidentialZoneLowEditButton.Text = "Edit";
            this.ResidentialZoneLowEditButton.UseVisualStyleBackColor = true;
            // 
            // SegmentPaddingNumericUpDown
            // 
            this.SegmentPaddingNumericUpDown.Location = new System.Drawing.Point(123, 6);
            this.SegmentPaddingNumericUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.SegmentPaddingNumericUpDown.Name = "SegmentPaddingNumericUpDown";
            this.SegmentPaddingNumericUpDown.Size = new System.Drawing.Size(49, 20);
            this.SegmentPaddingNumericUpDown.TabIndex = 54;
            // 
            // ResidentialZoneHighEditButton
            // 
            this.ResidentialZoneHighEditButton.Location = new System.Drawing.Point(215, 249);
            this.ResidentialZoneHighEditButton.Name = "ResidentialZoneHighEditButton";
            this.ResidentialZoneHighEditButton.Size = new System.Drawing.Size(34, 23);
            this.ResidentialZoneHighEditButton.TabIndex = 97;
            this.ResidentialZoneHighEditButton.Text = "Edit";
            this.ResidentialZoneHighEditButton.UseVisualStyleBackColor = true;
            // 
            // ResidentialZoneMidEditButton
            // 
            this.ResidentialZoneMidEditButton.Location = new System.Drawing.Point(215, 226);
            this.ResidentialZoneMidEditButton.Name = "ResidentialZoneMidEditButton";
            this.ResidentialZoneMidEditButton.Size = new System.Drawing.Size(34, 23);
            this.ResidentialZoneMidEditButton.TabIndex = 93;
            this.ResidentialZoneMidEditButton.Text = "Edit";
            this.ResidentialZoneMidEditButton.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 369);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 13);
            this.label7.TabIndex = 92;
            this.label7.Text = "Industrial Zone Mid";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 392);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(102, 13);
            this.label8.TabIndex = 91;
            this.label8.Text = "Industrial Zone High";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 346);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 13);
            this.label9.TabIndex = 90;
            this.label9.Text = "Industrial Zone Low";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 300);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 13);
            this.label6.TabIndex = 89;
            this.label6.Text = "Commercial Zone Mid";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 323);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 13);
            this.label5.TabIndex = 88;
            this.label5.Text = "Commercial Zone High";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 231);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 13);
            this.label4.TabIndex = 87;
            this.label4.Text = "Residential Zone Mid";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(10, 254);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(112, 13);
            this.label13.TabIndex = 86;
            this.label13.Text = "Residential Zone High";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(10, 277);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(112, 13);
            this.label14.TabIndex = 85;
            this.label14.Text = "Commercial Zone Low";
            // 
            // ResidentialZoneHighTextbox
            // 
            this.ResidentialZoneHighTextbox.Enabled = false;
            this.ResidentialZoneHighTextbox.ForeColor = System.Drawing.Color.Maroon;
            this.ResidentialZoneHighTextbox.Location = new System.Drawing.Point(125, 251);
            this.ResidentialZoneHighTextbox.Name = "ResidentialZoneHighTextbox";
            this.ResidentialZoneHighTextbox.Size = new System.Drawing.Size(84, 20);
            this.ResidentialZoneHighTextbox.TabIndex = 84;
            // 
            // ResidentialZoneMidTextbox
            // 
            this.ResidentialZoneMidTextbox.Enabled = false;
            this.ResidentialZoneMidTextbox.ForeColor = System.Drawing.Color.Maroon;
            this.ResidentialZoneMidTextbox.Location = new System.Drawing.Point(125, 228);
            this.ResidentialZoneMidTextbox.Name = "ResidentialZoneMidTextbox";
            this.ResidentialZoneMidTextbox.Size = new System.Drawing.Size(84, 20);
            this.ResidentialZoneMidTextbox.TabIndex = 83;
            // 
            // ResidentialZoneLowTextbox
            // 
            this.ResidentialZoneLowTextbox.Enabled = false;
            this.ResidentialZoneLowTextbox.ForeColor = System.Drawing.Color.Maroon;
            this.ResidentialZoneLowTextbox.Location = new System.Drawing.Point(125, 205);
            this.ResidentialZoneLowTextbox.Name = "ResidentialZoneLowTextbox";
            this.ResidentialZoneLowTextbox.Size = new System.Drawing.Size(84, 20);
            this.ResidentialZoneLowTextbox.TabIndex = 82;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(10, 208);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(110, 13);
            this.label15.TabIndex = 81;
            this.label15.Text = "Residential Zone Low";
            // 
            // SpaceportEditButton
            // 
            this.SpaceportEditButton.Location = new System.Drawing.Point(215, 180);
            this.SpaceportEditButton.Name = "SpaceportEditButton";
            this.SpaceportEditButton.Size = new System.Drawing.Size(34, 23);
            this.SpaceportEditButton.TabIndex = 80;
            this.SpaceportEditButton.Text = "Edit";
            this.SpaceportEditButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 185);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 79;
            this.label1.Text = "Spaceports";
            // 
            // SpaceportTextbox
            // 
            this.SpaceportTextbox.Enabled = false;
            this.SpaceportTextbox.ForeColor = System.Drawing.Color.Maroon;
            this.SpaceportTextbox.Location = new System.Drawing.Point(125, 182);
            this.SpaceportTextbox.Name = "SpaceportTextbox";
            this.SpaceportTextbox.Size = new System.Drawing.Size(84, 20);
            this.SpaceportTextbox.TabIndex = 78;
            // 
            // SeaportsEditButton
            // 
            this.SeaportsEditButton.Location = new System.Drawing.Point(215, 157);
            this.SeaportsEditButton.Name = "SeaportsEditButton";
            this.SeaportsEditButton.Size = new System.Drawing.Size(34, 23);
            this.SeaportsEditButton.TabIndex = 77;
            this.SeaportsEditButton.Text = "Edit";
            this.SeaportsEditButton.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 162);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 76;
            this.label2.Text = "Seaports";
            // 
            // SeaportTextbox
            // 
            this.SeaportTextbox.Enabled = false;
            this.SeaportTextbox.ForeColor = System.Drawing.Color.Maroon;
            this.SeaportTextbox.Location = new System.Drawing.Point(125, 159);
            this.SeaportTextbox.Name = "SeaportTextbox";
            this.SeaportTextbox.Size = new System.Drawing.Size(84, 20);
            this.SeaportTextbox.TabIndex = 75;
            // 
            // AirportsEditButton
            // 
            this.AirportsEditButton.Location = new System.Drawing.Point(215, 134);
            this.AirportsEditButton.Name = "AirportsEditButton";
            this.AirportsEditButton.Size = new System.Drawing.Size(34, 23);
            this.AirportsEditButton.TabIndex = 74;
            this.AirportsEditButton.Text = "Edit";
            this.AirportsEditButton.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 73;
            this.label3.Text = "Airports";
            // 
            // AirportsTextbox
            // 
            this.AirportsTextbox.Enabled = false;
            this.AirportsTextbox.ForeColor = System.Drawing.Color.Maroon;
            this.AirportsTextbox.Location = new System.Drawing.Point(125, 136);
            this.AirportsTextbox.Name = "AirportsTextbox";
            this.AirportsTextbox.Size = new System.Drawing.Size(84, 20);
            this.AirportsTextbox.TabIndex = 72;
            // 
            // MilitaryEditButton
            // 
            this.MilitaryEditButton.Location = new System.Drawing.Point(215, 111);
            this.MilitaryEditButton.Name = "MilitaryEditButton";
            this.MilitaryEditButton.Size = new System.Drawing.Size(34, 23);
            this.MilitaryEditButton.TabIndex = 71;
            this.MilitaryEditButton.Text = "Edit";
            this.MilitaryEditButton.UseVisualStyleBackColor = true;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(10, 116);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(39, 13);
            this.label17.TabIndex = 70;
            this.label17.Text = "Military";
            // 
            // MilitaryTextbox
            // 
            this.MilitaryTextbox.Enabled = false;
            this.MilitaryTextbox.ForeColor = System.Drawing.Color.Maroon;
            this.MilitaryTextbox.Location = new System.Drawing.Point(125, 113);
            this.MilitaryTextbox.Name = "MilitaryTextbox";
            this.MilitaryTextbox.Size = new System.Drawing.Size(84, 20);
            this.MilitaryTextbox.TabIndex = 69;
            // 
            // ZoneOutlinesEditButton
            // 
            this.ZoneOutlinesEditButton.Location = new System.Drawing.Point(215, 65);
            this.ZoneOutlinesEditButton.Name = "ZoneOutlinesEditButton";
            this.ZoneOutlinesEditButton.Size = new System.Drawing.Size(34, 23);
            this.ZoneOutlinesEditButton.TabIndex = 68;
            this.ZoneOutlinesEditButton.Text = "Edit";
            this.ZoneOutlinesEditButton.UseVisualStyleBackColor = true;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(10, 70);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(68, 13);
            this.label16.TabIndex = 67;
            this.label16.Text = "Zone Outline";
            // 
            // ZoneOutlinesTextbox
            // 
            this.ZoneOutlinesTextbox.Enabled = false;
            this.ZoneOutlinesTextbox.ForeColor = System.Drawing.Color.Maroon;
            this.ZoneOutlinesTextbox.Location = new System.Drawing.Point(125, 67);
            this.ZoneOutlinesTextbox.Name = "ZoneOutlinesTextbox";
            this.ZoneOutlinesTextbox.Size = new System.Drawing.Size(84, 20);
            this.ZoneOutlinesTextbox.TabIndex = 66;
            // 
            // PloppedBuildingsEditButton
            // 
            this.PloppedBuildingsEditButton.Location = new System.Drawing.Point(215, 88);
            this.PloppedBuildingsEditButton.Name = "PloppedBuildingsEditButton";
            this.PloppedBuildingsEditButton.Size = new System.Drawing.Size(34, 23);
            this.PloppedBuildingsEditButton.TabIndex = 64;
            this.PloppedBuildingsEditButton.Text = "Edit";
            this.PloppedBuildingsEditButton.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(10, 93);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(91, 13);
            this.label12.TabIndex = 63;
            this.label12.Text = "Plopped Buildings";
            // 
            // PloppedBuildingsTextbox
            // 
            this.PloppedBuildingsTextbox.Enabled = false;
            this.PloppedBuildingsTextbox.ForeColor = System.Drawing.Color.Maroon;
            this.PloppedBuildingsTextbox.Location = new System.Drawing.Point(125, 90);
            this.PloppedBuildingsTextbox.Name = "PloppedBuildingsTextbox";
            this.PloppedBuildingsTextbox.Size = new System.Drawing.Size(84, 20);
            this.PloppedBuildingsTextbox.TabIndex = 60;
            // 
            // TransportTabPage
            // 
            this.TransportTabPage.AutoScroll = true;
            this.TransportTabPage.Controls.Add(this.SubwayEditButton);
            this.TransportTabPage.Controls.Add(this.label45);
            this.TransportTabPage.Controls.Add(this.SubwayTextBox);
            this.TransportTabPage.Controls.Add(this.RailwayEditButton);
            this.TransportTabPage.Controls.Add(this.label44);
            this.TransportTabPage.Controls.Add(this.RailwayTextBox);
            this.TransportTabPage.Controls.Add(this.AvenueEditButton);
            this.TransportTabPage.Controls.Add(this.label43);
            this.TransportTabPage.Controls.Add(this.AvenueTextBox);
            this.TransportTabPage.Controls.Add(this.OneWayRoadEditButton);
            this.TransportTabPage.Controls.Add(this.label42);
            this.TransportTabPage.Controls.Add(this.OneWayRoadTextBox);
            this.TransportTabPage.Controls.Add(this.RoadEditButton);
            this.TransportTabPage.Controls.Add(this.label41);
            this.TransportTabPage.Controls.Add(this.RoadTextBox);
            this.TransportTabPage.Controls.Add(this.StreetEditButton);
            this.TransportTabPage.Controls.Add(this.label30);
            this.TransportTabPage.Controls.Add(this.StreetTextBox);
            this.TransportTabPage.Location = new System.Drawing.Point(4, 22);
            this.TransportTabPage.Name = "TransportTabPage";
            this.TransportTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.TransportTabPage.Size = new System.Drawing.Size(269, 279);
            this.TransportTabPage.TabIndex = 2;
            this.TransportTabPage.Text = "Transport";
            this.TransportTabPage.UseVisualStyleBackColor = true;
            // 
            // SubwayEditButton
            // 
            this.SubwayEditButton.Location = new System.Drawing.Point(222, 121);
            this.SubwayEditButton.Name = "SubwayEditButton";
            this.SubwayEditButton.Size = new System.Drawing.Size(34, 23);
            this.SubwayEditButton.TabIndex = 78;
            this.SubwayEditButton.Text = "Edit";
            this.SubwayEditButton.UseVisualStyleBackColor = true;
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(6, 127);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(45, 13);
            this.label45.TabIndex = 79;
            this.label45.Text = "Subway";
            // 
            // SubwayTextBox
            // 
            this.SubwayTextBox.Enabled = false;
            this.SubwayTextBox.ForeColor = System.Drawing.Color.Maroon;
            this.SubwayTextBox.Location = new System.Drawing.Point(132, 123);
            this.SubwayTextBox.Name = "SubwayTextBox";
            this.SubwayTextBox.Size = new System.Drawing.Size(84, 20);
            this.SubwayTextBox.TabIndex = 77;
            // 
            // RailwayEditButton
            // 
            this.RailwayEditButton.Location = new System.Drawing.Point(222, 98);
            this.RailwayEditButton.Name = "RailwayEditButton";
            this.RailwayEditButton.Size = new System.Drawing.Size(34, 23);
            this.RailwayEditButton.TabIndex = 75;
            this.RailwayEditButton.Text = "Edit";
            this.RailwayEditButton.UseVisualStyleBackColor = true;
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(6, 103);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(44, 13);
            this.label44.TabIndex = 76;
            this.label44.Text = "Railway";
            // 
            // RailwayTextBox
            // 
            this.RailwayTextBox.Enabled = false;
            this.RailwayTextBox.ForeColor = System.Drawing.Color.Maroon;
            this.RailwayTextBox.Location = new System.Drawing.Point(132, 100);
            this.RailwayTextBox.Name = "RailwayTextBox";
            this.RailwayTextBox.Size = new System.Drawing.Size(84, 20);
            this.RailwayTextBox.TabIndex = 74;
            // 
            // AvenueEditButton
            // 
            this.AvenueEditButton.Location = new System.Drawing.Point(222, 75);
            this.AvenueEditButton.Name = "AvenueEditButton";
            this.AvenueEditButton.Size = new System.Drawing.Size(34, 23);
            this.AvenueEditButton.TabIndex = 72;
            this.AvenueEditButton.Text = "Edit";
            this.AvenueEditButton.UseVisualStyleBackColor = true;
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(6, 80);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(44, 13);
            this.label43.TabIndex = 73;
            this.label43.Text = "Avenue";
            // 
            // AvenueTextBox
            // 
            this.AvenueTextBox.Enabled = false;
            this.AvenueTextBox.ForeColor = System.Drawing.Color.Maroon;
            this.AvenueTextBox.Location = new System.Drawing.Point(132, 77);
            this.AvenueTextBox.Name = "AvenueTextBox";
            this.AvenueTextBox.Size = new System.Drawing.Size(84, 20);
            this.AvenueTextBox.TabIndex = 71;
            // 
            // OneWayRoadEditButton
            // 
            this.OneWayRoadEditButton.Location = new System.Drawing.Point(222, 52);
            this.OneWayRoadEditButton.Name = "OneWayRoadEditButton";
            this.OneWayRoadEditButton.Size = new System.Drawing.Size(34, 23);
            this.OneWayRoadEditButton.TabIndex = 69;
            this.OneWayRoadEditButton.Text = "Edit";
            this.OneWayRoadEditButton.UseVisualStyleBackColor = true;
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(6, 57);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(81, 13);
            this.label42.TabIndex = 70;
            this.label42.Text = "One Way Road";
            // 
            // OneWayRoadTextBox
            // 
            this.OneWayRoadTextBox.Enabled = false;
            this.OneWayRoadTextBox.ForeColor = System.Drawing.Color.Maroon;
            this.OneWayRoadTextBox.Location = new System.Drawing.Point(132, 54);
            this.OneWayRoadTextBox.Name = "OneWayRoadTextBox";
            this.OneWayRoadTextBox.Size = new System.Drawing.Size(84, 20);
            this.OneWayRoadTextBox.TabIndex = 68;
            // 
            // RoadEditButton
            // 
            this.RoadEditButton.Location = new System.Drawing.Point(222, 29);
            this.RoadEditButton.Name = "RoadEditButton";
            this.RoadEditButton.Size = new System.Drawing.Size(34, 23);
            this.RoadEditButton.TabIndex = 66;
            this.RoadEditButton.Text = "Edit";
            this.RoadEditButton.UseVisualStyleBackColor = true;
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(6, 11);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(35, 13);
            this.label41.TabIndex = 67;
            this.label41.Text = "Street";
            // 
            // RoadTextBox
            // 
            this.RoadTextBox.Enabled = false;
            this.RoadTextBox.ForeColor = System.Drawing.Color.Maroon;
            this.RoadTextBox.Location = new System.Drawing.Point(132, 31);
            this.RoadTextBox.Name = "RoadTextBox";
            this.RoadTextBox.Size = new System.Drawing.Size(84, 20);
            this.RoadTextBox.TabIndex = 65;
            // 
            // StreetEditButton
            // 
            this.StreetEditButton.Location = new System.Drawing.Point(222, 6);
            this.StreetEditButton.Name = "StreetEditButton";
            this.StreetEditButton.Size = new System.Drawing.Size(34, 23);
            this.StreetEditButton.TabIndex = 63;
            this.StreetEditButton.Text = "Edit";
            this.StreetEditButton.UseVisualStyleBackColor = true;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(6, 34);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(33, 13);
            this.label30.TabIndex = 64;
            this.label30.Text = "Road";
            // 
            // StreetTextBox
            // 
            this.StreetTextBox.Enabled = false;
            this.StreetTextBox.ForeColor = System.Drawing.Color.Maroon;
            this.StreetTextBox.Location = new System.Drawing.Point(132, 8);
            this.StreetTextBox.Name = "StreetTextBox";
            this.StreetTextBox.Size = new System.Drawing.Size(84, 20);
            this.StreetTextBox.TabIndex = 62;
            // 
            // TerrainTabPage
            // 
            this.TerrainTabPage.AutoScroll = true;
            this.TerrainTabPage.Controls.Add(this.BlendTerrainColorsCheckBox);
            this.TerrainTabPage.Controls.Add(this.groupBox4);
            this.TerrainTabPage.Controls.Add(this.TerrainLayer23CheckBox);
            this.TerrainTabPage.Controls.Add(this.TerrainLayer23AliasTextBox);
            this.TerrainTabPage.Controls.Add(this.TerrainLayer23Button);
            this.TerrainTabPage.Controls.Add(this.TerrainLayer23ColorTextBox);
            this.TerrainTabPage.Controls.Add(this.TerrainLayer23NumericUpDown);
            this.TerrainTabPage.Controls.Add(this.TerrainLayer22CheckBox);
            this.TerrainTabPage.Controls.Add(this.TerrainLayer22AliasTextBox);
            this.TerrainTabPage.Controls.Add(this.TerrainLayer22Button);
            this.TerrainTabPage.Controls.Add(this.TerrainLayer22ColorTextBox);
            this.TerrainTabPage.Controls.Add(this.TerrainLayer22NumericUpDown);
            this.TerrainTabPage.Controls.Add(this.TerrainLayer21CheckBox);
            this.TerrainTabPage.Controls.Add(this.TerrainLayer21AliasTextBox);
            this.TerrainTabPage.Controls.Add(this.TerrainLayer21Button);
            this.TerrainTabPage.Controls.Add(this.TerrainLayer21ColorTextBox);
            this.TerrainTabPage.Controls.Add(this.TerrainLayer21NumericUpDown);
            this.TerrainTabPage.Controls.Add(this.TerrainLayer20CheckBox);
            this.TerrainTabPage.Controls.Add(this.TerrainLayer20AliasTextBox);
            this.TerrainTabPage.Controls.Add(this.TerrainLayer20Button);
            this.TerrainTabPage.Controls.Add(this.TerrainLayer20ColorTextBox);
            this.TerrainTabPage.Controls.Add(this.TerrainLayer20NumericUpDown);
            this.TerrainTabPage.Controls.Add(this.TerrainLayer19CheckBox);
            this.TerrainTabPage.Controls.Add(this.TerrainLayer19AliasTextBox);
            this.TerrainTabPage.Controls.Add(this.TerrainLayer19Button);
            this.TerrainTabPage.Controls.Add(this.TerrainLayer19ColorTextBox);
            this.TerrainTabPage.Controls.Add(this.TerrainLayer19NumericUpDown);
            this.TerrainTabPage.Controls.Add(this.TerrainLayer18CheckBox);
            this.TerrainTabPage.Controls.Add(this.TerrainLayer18AliasTextBox);
            this.TerrainTabPage.Controls.Add(this.TerrainLayer18Button);
            this.TerrainTabPage.Controls.Add(this.TerrainLayer18ColorTextBox);
            this.TerrainTabPage.Controls.Add(this.TerrainLayer18NumericUpDown);
            this.TerrainTabPage.Controls.Add(this.TerrainLayer17CheckBox);
            this.TerrainTabPage.Controls.Add(this.TerrainLayer17AliasTextBox);
            this.TerrainTabPage.Controls.Add(this.TerrainLayer17Button);
            this.TerrainTabPage.Controls.Add(this.TerrainLayer17ColorTextBox);
            this.TerrainTabPage.Controls.Add(this.TerrainLayer17NumericUpDown);
            this.TerrainTabPage.Controls.Add(this.TerrainLayer16CheckBox);
            this.TerrainTabPage.Controls.Add(this.TerrainLayer16AliasTextBox);
            this.TerrainTabPage.Controls.Add(this.TerrainLayer16Button);
            this.TerrainTabPage.Controls.Add(this.TerrainLayer16ColorTextBox);
            this.TerrainTabPage.Controls.Add(this.TerrainLayer16NumericUpDown);
            this.TerrainTabPage.Controls.Add(this.TerrainLayer15CheckBox);
            this.TerrainTabPage.Controls.Add(this.TerrainLayer15AliasTextBox);
            this.TerrainTabPage.Controls.Add(this.TerrainLayer15Button);
            this.TerrainTabPage.Controls.Add(this.TerrainLayer15ColorTextBox);
            this.TerrainTabPage.Controls.Add(this.TerrainLayer15NumericUpDown);
            this.TerrainTabPage.Controls.Add(this.TerrainLayer14CheckBox);
            this.TerrainTabPage.Controls.Add(this.TerrainLayer14AliasTextBox);
            this.TerrainTabPage.Controls.Add(this.TerrainLayer14Button);
            this.TerrainTabPage.Controls.Add(this.TerrainLayer14ColorTextBox);
            this.TerrainTabPage.Controls.Add(this.TerrainLayer14NumericUpDown);
            this.TerrainTabPage.Controls.Add(this.TerrainLayer13CheckBox);
            this.TerrainTabPage.Controls.Add(this.TerrainLayer13AliasTextBox);
            this.TerrainTabPage.Controls.Add(this.TerrainLayer13Button);
            this.TerrainTabPage.Controls.Add(this.TerrainLayer13ColorTextBox);
            this.TerrainTabPage.Controls.Add(this.TerrainLayer13NumericUpDown);
            this.TerrainTabPage.Controls.Add(this.TerrainLayer12CheckBox);
            this.TerrainTabPage.Controls.Add(this.TerrainLayer12AliasTextBox);
            this.TerrainTabPage.Controls.Add(this.TerrainLayer12Button);
            this.TerrainTabPage.Controls.Add(this.TerrainLayer12ColorTextBox);
            this.TerrainTabPage.Controls.Add(this.TerrainLayer12NumericUpDown);
            this.TerrainTabPage.Controls.Add(this.TerrainLayer11CheckBox);
            this.TerrainTabPage.Controls.Add(this.TerrainLayer11AliasTextBox);
            this.TerrainTabPage.Controls.Add(this.TerrainLayer11Button);
            this.TerrainTabPage.Controls.Add(this.TerrainLayer11ColorTextBox);
            this.TerrainTabPage.Controls.Add(this.TerrainLayer11NumericUpDown);
            this.TerrainTabPage.Controls.Add(this.TerrainLayer10CheckBox);
            this.TerrainTabPage.Controls.Add(this.TerrainLayer10AliasTextBox);
            this.TerrainTabPage.Controls.Add(this.TerrainLayer10Button);
            this.TerrainTabPage.Controls.Add(this.TerrainLayer10ColorTextBox);
            this.TerrainTabPage.Controls.Add(this.TerrainLayer10NumericUpDown);
            this.TerrainTabPage.Controls.Add(this.TerrainLayer9CheckBox);
            this.TerrainTabPage.Controls.Add(this.TerrainLayer9AliasTextBox);
            this.TerrainTabPage.Controls.Add(this.TerrainLayer9Button);
            this.TerrainTabPage.Controls.Add(this.TerrainLayer9ColorTextBox);
            this.TerrainTabPage.Controls.Add(this.TerrainLayer9NumericUpDown);
            this.TerrainTabPage.Controls.Add(this.TerrainLayer8CheckBox);
            this.TerrainTabPage.Controls.Add(this.TerrainLayer8AliasTextBox);
            this.TerrainTabPage.Controls.Add(this.TerrainLayer8Button);
            this.TerrainTabPage.Controls.Add(this.TerrainLayer8ColorTextBox);
            this.TerrainTabPage.Controls.Add(this.TerrainLayer8NumericUpDown);
            this.TerrainTabPage.Controls.Add(this.TerrainLayer7CheckBox);
            this.TerrainTabPage.Controls.Add(this.TerrainLayer7AliasTextBox);
            this.TerrainTabPage.Controls.Add(this.TerrainLayer7Button);
            this.TerrainTabPage.Controls.Add(this.TerrainLayer7ColorTextBox);
            this.TerrainTabPage.Controls.Add(this.TerrainLayer7NumericUpDown);
            this.TerrainTabPage.Controls.Add(this.TerrainLayer6CheckBox);
            this.TerrainTabPage.Controls.Add(this.TerrainLayer6AliasTextBox);
            this.TerrainTabPage.Controls.Add(this.TerrainLayer6Button);
            this.TerrainTabPage.Controls.Add(this.TerrainLayer6ColorTextBox);
            this.TerrainTabPage.Controls.Add(this.TerrainLayer6NumericUpDown);
            this.TerrainTabPage.Controls.Add(this.TerrainLayer5CheckBox);
            this.TerrainTabPage.Controls.Add(this.TerrainLayer5AliasTextBox);
            this.TerrainTabPage.Controls.Add(this.TerrainLayer5Button);
            this.TerrainTabPage.Controls.Add(this.TerrainLayer5ColorTextBox);
            this.TerrainTabPage.Controls.Add(this.TerrainLayer5NumericUpDown);
            this.TerrainTabPage.Controls.Add(this.TerrainLayer4CheckBox);
            this.TerrainTabPage.Controls.Add(this.TerrainLayer4AliasTextBox);
            this.TerrainTabPage.Controls.Add(this.TerrainLayer4Button);
            this.TerrainTabPage.Controls.Add(this.TerrainLayer4ColorTextBox);
            this.TerrainTabPage.Controls.Add(this.TerrainLayer4NumericUpDown);
            this.TerrainTabPage.Controls.Add(this.TerrainLayer3CheckBox);
            this.TerrainTabPage.Controls.Add(this.TerrainLayer3AliasTextBox);
            this.TerrainTabPage.Controls.Add(this.TerrainLayer3Button);
            this.TerrainTabPage.Controls.Add(this.TerrainLayer3ColorTextBox);
            this.TerrainTabPage.Controls.Add(this.TerrainLayer3NumericUpDown);
            this.TerrainTabPage.Controls.Add(this.TerrainLayer2CheckBox);
            this.TerrainTabPage.Controls.Add(this.TerrainLayer2AliasTextBox);
            this.TerrainTabPage.Controls.Add(this.TerrainLayer2Button);
            this.TerrainTabPage.Controls.Add(this.TerrainLayer2ColorTextBox);
            this.TerrainTabPage.Controls.Add(this.TerrainLayer2NumericUpDown);
            this.TerrainTabPage.Controls.Add(this.TerrainLayer1CheckBox);
            this.TerrainTabPage.Controls.Add(this.TerrainLayer1AliasTextBox);
            this.TerrainTabPage.Controls.Add(this.TerrainLayer1Button);
            this.TerrainTabPage.Controls.Add(this.TerrainLayer1ColorTextBox);
            this.TerrainTabPage.Controls.Add(this.TerrainLayer1NumericUpDown);
            this.TerrainTabPage.Location = new System.Drawing.Point(4, 22);
            this.TerrainTabPage.Name = "TerrainTabPage";
            this.TerrainTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.TerrainTabPage.Size = new System.Drawing.Size(269, 279);
            this.TerrainTabPage.TabIndex = 1;
            this.TerrainTabPage.Text = "Terrain";
            this.TerrainTabPage.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Location = new System.Drawing.Point(6, 30);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(238, 5);
            this.groupBox4.TabIndex = 212;
            this.groupBox4.TabStop = false;
            // 
            // TerrainLayer23CheckBox
            // 
            this.TerrainLayer23CheckBox.AutoSize = true;
            this.TerrainLayer23CheckBox.Location = new System.Drawing.Point(6, 615);
            this.TerrainLayer23CheckBox.Name = "TerrainLayer23CheckBox";
            this.TerrainLayer23CheckBox.Size = new System.Drawing.Size(15, 14);
            this.TerrainLayer23CheckBox.TabIndex = 211;
            this.TerrainLayer23CheckBox.UseVisualStyleBackColor = true;
            // 
            // TerrainLayer23AliasTextBox
            // 
            this.TerrainLayer23AliasTextBox.Location = new System.Drawing.Point(22, 612);
            this.TerrainLayer23AliasTextBox.Name = "TerrainLayer23AliasTextBox";
            this.TerrainLayer23AliasTextBox.Size = new System.Drawing.Size(72, 20);
            this.TerrainLayer23AliasTextBox.TabIndex = 210;
            this.TerrainLayer23AliasTextBox.Text = "water deep";
            this.TerrainLayer23AliasTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxDisallowSpecialCharacters_KeyPress);
            // 
            // TerrainLayer23Button
            // 
            this.TerrainLayer23Button.Location = new System.Drawing.Point(215, 610);
            this.TerrainLayer23Button.Name = "TerrainLayer23Button";
            this.TerrainLayer23Button.Size = new System.Drawing.Size(34, 23);
            this.TerrainLayer23Button.TabIndex = 209;
            this.TerrainLayer23Button.Text = "Edit";
            this.TerrainLayer23Button.UseVisualStyleBackColor = true;
            // 
            // TerrainLayer23ColorTextBox
            // 
            this.TerrainLayer23ColorTextBox.Enabled = false;
            this.TerrainLayer23ColorTextBox.ForeColor = System.Drawing.Color.Maroon;
            this.TerrainLayer23ColorTextBox.Location = new System.Drawing.Point(157, 612);
            this.TerrainLayer23ColorTextBox.Name = "TerrainLayer23ColorTextBox";
            this.TerrainLayer23ColorTextBox.Size = new System.Drawing.Size(52, 20);
            this.TerrainLayer23ColorTextBox.TabIndex = 208;
            // 
            // TerrainLayer23NumericUpDown
            // 
            this.TerrainLayer23NumericUpDown.Location = new System.Drawing.Point(100, 612);
            this.TerrainLayer23NumericUpDown.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.TerrainLayer23NumericUpDown.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.TerrainLayer23NumericUpDown.Name = "TerrainLayer23NumericUpDown";
            this.TerrainLayer23NumericUpDown.Size = new System.Drawing.Size(51, 20);
            this.TerrainLayer23NumericUpDown.TabIndex = 207;
            this.TerrainLayer23NumericUpDown.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            // 
            // TerrainLayer22CheckBox
            // 
            this.TerrainLayer22CheckBox.AutoSize = true;
            this.TerrainLayer22CheckBox.Location = new System.Drawing.Point(6, 589);
            this.TerrainLayer22CheckBox.Name = "TerrainLayer22CheckBox";
            this.TerrainLayer22CheckBox.Size = new System.Drawing.Size(15, 14);
            this.TerrainLayer22CheckBox.TabIndex = 206;
            this.TerrainLayer22CheckBox.UseVisualStyleBackColor = true;
            // 
            // TerrainLayer22AliasTextBox
            // 
            this.TerrainLayer22AliasTextBox.Location = new System.Drawing.Point(22, 586);
            this.TerrainLayer22AliasTextBox.Name = "TerrainLayer22AliasTextBox";
            this.TerrainLayer22AliasTextBox.Size = new System.Drawing.Size(72, 20);
            this.TerrainLayer22AliasTextBox.TabIndex = 205;
            this.TerrainLayer22AliasTextBox.Text = "water deep";
            this.TerrainLayer22AliasTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxDisallowSpecialCharacters_KeyPress);
            // 
            // TerrainLayer22Button
            // 
            this.TerrainLayer22Button.Location = new System.Drawing.Point(215, 584);
            this.TerrainLayer22Button.Name = "TerrainLayer22Button";
            this.TerrainLayer22Button.Size = new System.Drawing.Size(34, 23);
            this.TerrainLayer22Button.TabIndex = 204;
            this.TerrainLayer22Button.Text = "Edit";
            this.TerrainLayer22Button.UseVisualStyleBackColor = true;
            // 
            // TerrainLayer22ColorTextBox
            // 
            this.TerrainLayer22ColorTextBox.Enabled = false;
            this.TerrainLayer22ColorTextBox.ForeColor = System.Drawing.Color.Maroon;
            this.TerrainLayer22ColorTextBox.Location = new System.Drawing.Point(157, 586);
            this.TerrainLayer22ColorTextBox.Name = "TerrainLayer22ColorTextBox";
            this.TerrainLayer22ColorTextBox.Size = new System.Drawing.Size(52, 20);
            this.TerrainLayer22ColorTextBox.TabIndex = 203;
            // 
            // TerrainLayer22NumericUpDown
            // 
            this.TerrainLayer22NumericUpDown.Location = new System.Drawing.Point(100, 586);
            this.TerrainLayer22NumericUpDown.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.TerrainLayer22NumericUpDown.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.TerrainLayer22NumericUpDown.Name = "TerrainLayer22NumericUpDown";
            this.TerrainLayer22NumericUpDown.Size = new System.Drawing.Size(51, 20);
            this.TerrainLayer22NumericUpDown.TabIndex = 202;
            this.TerrainLayer22NumericUpDown.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            // 
            // TerrainLayer21CheckBox
            // 
            this.TerrainLayer21CheckBox.AutoSize = true;
            this.TerrainLayer21CheckBox.Location = new System.Drawing.Point(6, 563);
            this.TerrainLayer21CheckBox.Name = "TerrainLayer21CheckBox";
            this.TerrainLayer21CheckBox.Size = new System.Drawing.Size(15, 14);
            this.TerrainLayer21CheckBox.TabIndex = 201;
            this.TerrainLayer21CheckBox.UseVisualStyleBackColor = true;
            // 
            // TerrainLayer21AliasTextBox
            // 
            this.TerrainLayer21AliasTextBox.Location = new System.Drawing.Point(22, 560);
            this.TerrainLayer21AliasTextBox.Name = "TerrainLayer21AliasTextBox";
            this.TerrainLayer21AliasTextBox.Size = new System.Drawing.Size(72, 20);
            this.TerrainLayer21AliasTextBox.TabIndex = 200;
            this.TerrainLayer21AliasTextBox.Text = "water deep";
            this.TerrainLayer21AliasTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxDisallowSpecialCharacters_KeyPress);
            // 
            // TerrainLayer21Button
            // 
            this.TerrainLayer21Button.Location = new System.Drawing.Point(215, 558);
            this.TerrainLayer21Button.Name = "TerrainLayer21Button";
            this.TerrainLayer21Button.Size = new System.Drawing.Size(34, 23);
            this.TerrainLayer21Button.TabIndex = 199;
            this.TerrainLayer21Button.Text = "Edit";
            this.TerrainLayer21Button.UseVisualStyleBackColor = true;
            // 
            // TerrainLayer21ColorTextBox
            // 
            this.TerrainLayer21ColorTextBox.Enabled = false;
            this.TerrainLayer21ColorTextBox.ForeColor = System.Drawing.Color.Maroon;
            this.TerrainLayer21ColorTextBox.Location = new System.Drawing.Point(157, 560);
            this.TerrainLayer21ColorTextBox.Name = "TerrainLayer21ColorTextBox";
            this.TerrainLayer21ColorTextBox.Size = new System.Drawing.Size(52, 20);
            this.TerrainLayer21ColorTextBox.TabIndex = 198;
            // 
            // TerrainLayer21NumericUpDown
            // 
            this.TerrainLayer21NumericUpDown.Location = new System.Drawing.Point(100, 560);
            this.TerrainLayer21NumericUpDown.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.TerrainLayer21NumericUpDown.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.TerrainLayer21NumericUpDown.Name = "TerrainLayer21NumericUpDown";
            this.TerrainLayer21NumericUpDown.Size = new System.Drawing.Size(51, 20);
            this.TerrainLayer21NumericUpDown.TabIndex = 197;
            this.TerrainLayer21NumericUpDown.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            // 
            // TerrainLayer20CheckBox
            // 
            this.TerrainLayer20CheckBox.AutoSize = true;
            this.TerrainLayer20CheckBox.Location = new System.Drawing.Point(6, 537);
            this.TerrainLayer20CheckBox.Name = "TerrainLayer20CheckBox";
            this.TerrainLayer20CheckBox.Size = new System.Drawing.Size(15, 14);
            this.TerrainLayer20CheckBox.TabIndex = 196;
            this.TerrainLayer20CheckBox.UseVisualStyleBackColor = true;
            // 
            // TerrainLayer20AliasTextBox
            // 
            this.TerrainLayer20AliasTextBox.Location = new System.Drawing.Point(22, 534);
            this.TerrainLayer20AliasTextBox.Name = "TerrainLayer20AliasTextBox";
            this.TerrainLayer20AliasTextBox.Size = new System.Drawing.Size(72, 20);
            this.TerrainLayer20AliasTextBox.TabIndex = 195;
            this.TerrainLayer20AliasTextBox.Text = "water deep";
            this.TerrainLayer20AliasTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxDisallowSpecialCharacters_KeyPress);
            // 
            // TerrainLayer20Button
            // 
            this.TerrainLayer20Button.Location = new System.Drawing.Point(215, 532);
            this.TerrainLayer20Button.Name = "TerrainLayer20Button";
            this.TerrainLayer20Button.Size = new System.Drawing.Size(34, 23);
            this.TerrainLayer20Button.TabIndex = 194;
            this.TerrainLayer20Button.Text = "Edit";
            this.TerrainLayer20Button.UseVisualStyleBackColor = true;
            // 
            // TerrainLayer20ColorTextBox
            // 
            this.TerrainLayer20ColorTextBox.Enabled = false;
            this.TerrainLayer20ColorTextBox.ForeColor = System.Drawing.Color.Maroon;
            this.TerrainLayer20ColorTextBox.Location = new System.Drawing.Point(157, 534);
            this.TerrainLayer20ColorTextBox.Name = "TerrainLayer20ColorTextBox";
            this.TerrainLayer20ColorTextBox.Size = new System.Drawing.Size(52, 20);
            this.TerrainLayer20ColorTextBox.TabIndex = 193;
            // 
            // TerrainLayer20NumericUpDown
            // 
            this.TerrainLayer20NumericUpDown.Location = new System.Drawing.Point(100, 534);
            this.TerrainLayer20NumericUpDown.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.TerrainLayer20NumericUpDown.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.TerrainLayer20NumericUpDown.Name = "TerrainLayer20NumericUpDown";
            this.TerrainLayer20NumericUpDown.Size = new System.Drawing.Size(51, 20);
            this.TerrainLayer20NumericUpDown.TabIndex = 192;
            this.TerrainLayer20NumericUpDown.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            // 
            // TerrainLayer19CheckBox
            // 
            this.TerrainLayer19CheckBox.AutoSize = true;
            this.TerrainLayer19CheckBox.Location = new System.Drawing.Point(6, 511);
            this.TerrainLayer19CheckBox.Name = "TerrainLayer19CheckBox";
            this.TerrainLayer19CheckBox.Size = new System.Drawing.Size(15, 14);
            this.TerrainLayer19CheckBox.TabIndex = 191;
            this.TerrainLayer19CheckBox.UseVisualStyleBackColor = true;
            // 
            // TerrainLayer19AliasTextBox
            // 
            this.TerrainLayer19AliasTextBox.Location = new System.Drawing.Point(22, 508);
            this.TerrainLayer19AliasTextBox.Name = "TerrainLayer19AliasTextBox";
            this.TerrainLayer19AliasTextBox.Size = new System.Drawing.Size(72, 20);
            this.TerrainLayer19AliasTextBox.TabIndex = 190;
            this.TerrainLayer19AliasTextBox.Text = "water deep";
            this.TerrainLayer19AliasTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxDisallowSpecialCharacters_KeyPress);
            // 
            // TerrainLayer19Button
            // 
            this.TerrainLayer19Button.Location = new System.Drawing.Point(215, 506);
            this.TerrainLayer19Button.Name = "TerrainLayer19Button";
            this.TerrainLayer19Button.Size = new System.Drawing.Size(34, 23);
            this.TerrainLayer19Button.TabIndex = 189;
            this.TerrainLayer19Button.Text = "Edit";
            this.TerrainLayer19Button.UseVisualStyleBackColor = true;
            // 
            // TerrainLayer19ColorTextBox
            // 
            this.TerrainLayer19ColorTextBox.Enabled = false;
            this.TerrainLayer19ColorTextBox.ForeColor = System.Drawing.Color.Maroon;
            this.TerrainLayer19ColorTextBox.Location = new System.Drawing.Point(157, 508);
            this.TerrainLayer19ColorTextBox.Name = "TerrainLayer19ColorTextBox";
            this.TerrainLayer19ColorTextBox.Size = new System.Drawing.Size(52, 20);
            this.TerrainLayer19ColorTextBox.TabIndex = 188;
            // 
            // TerrainLayer19NumericUpDown
            // 
            this.TerrainLayer19NumericUpDown.Location = new System.Drawing.Point(100, 508);
            this.TerrainLayer19NumericUpDown.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.TerrainLayer19NumericUpDown.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.TerrainLayer19NumericUpDown.Name = "TerrainLayer19NumericUpDown";
            this.TerrainLayer19NumericUpDown.Size = new System.Drawing.Size(51, 20);
            this.TerrainLayer19NumericUpDown.TabIndex = 187;
            this.TerrainLayer19NumericUpDown.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            // 
            // TerrainLayer18CheckBox
            // 
            this.TerrainLayer18CheckBox.AutoSize = true;
            this.TerrainLayer18CheckBox.Location = new System.Drawing.Point(6, 485);
            this.TerrainLayer18CheckBox.Name = "TerrainLayer18CheckBox";
            this.TerrainLayer18CheckBox.Size = new System.Drawing.Size(15, 14);
            this.TerrainLayer18CheckBox.TabIndex = 186;
            this.TerrainLayer18CheckBox.UseVisualStyleBackColor = true;
            // 
            // TerrainLayer18AliasTextBox
            // 
            this.TerrainLayer18AliasTextBox.Location = new System.Drawing.Point(22, 482);
            this.TerrainLayer18AliasTextBox.Name = "TerrainLayer18AliasTextBox";
            this.TerrainLayer18AliasTextBox.Size = new System.Drawing.Size(72, 20);
            this.TerrainLayer18AliasTextBox.TabIndex = 185;
            this.TerrainLayer18AliasTextBox.Text = "water deep";
            this.TerrainLayer18AliasTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxDisallowSpecialCharacters_KeyPress);
            // 
            // TerrainLayer18Button
            // 
            this.TerrainLayer18Button.Location = new System.Drawing.Point(215, 480);
            this.TerrainLayer18Button.Name = "TerrainLayer18Button";
            this.TerrainLayer18Button.Size = new System.Drawing.Size(34, 23);
            this.TerrainLayer18Button.TabIndex = 184;
            this.TerrainLayer18Button.Text = "Edit";
            this.TerrainLayer18Button.UseVisualStyleBackColor = true;
            // 
            // TerrainLayer18ColorTextBox
            // 
            this.TerrainLayer18ColorTextBox.Enabled = false;
            this.TerrainLayer18ColorTextBox.ForeColor = System.Drawing.Color.Maroon;
            this.TerrainLayer18ColorTextBox.Location = new System.Drawing.Point(157, 482);
            this.TerrainLayer18ColorTextBox.Name = "TerrainLayer18ColorTextBox";
            this.TerrainLayer18ColorTextBox.Size = new System.Drawing.Size(52, 20);
            this.TerrainLayer18ColorTextBox.TabIndex = 183;
            // 
            // TerrainLayer18NumericUpDown
            // 
            this.TerrainLayer18NumericUpDown.Location = new System.Drawing.Point(100, 482);
            this.TerrainLayer18NumericUpDown.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.TerrainLayer18NumericUpDown.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.TerrainLayer18NumericUpDown.Name = "TerrainLayer18NumericUpDown";
            this.TerrainLayer18NumericUpDown.Size = new System.Drawing.Size(51, 20);
            this.TerrainLayer18NumericUpDown.TabIndex = 182;
            this.TerrainLayer18NumericUpDown.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            // 
            // TerrainLayer17CheckBox
            // 
            this.TerrainLayer17CheckBox.AutoSize = true;
            this.TerrainLayer17CheckBox.Location = new System.Drawing.Point(6, 459);
            this.TerrainLayer17CheckBox.Name = "TerrainLayer17CheckBox";
            this.TerrainLayer17CheckBox.Size = new System.Drawing.Size(15, 14);
            this.TerrainLayer17CheckBox.TabIndex = 181;
            this.TerrainLayer17CheckBox.UseVisualStyleBackColor = true;
            // 
            // TerrainLayer17AliasTextBox
            // 
            this.TerrainLayer17AliasTextBox.Location = new System.Drawing.Point(22, 456);
            this.TerrainLayer17AliasTextBox.Name = "TerrainLayer17AliasTextBox";
            this.TerrainLayer17AliasTextBox.Size = new System.Drawing.Size(72, 20);
            this.TerrainLayer17AliasTextBox.TabIndex = 180;
            this.TerrainLayer17AliasTextBox.Text = "water deep";
            this.TerrainLayer17AliasTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxDisallowSpecialCharacters_KeyPress);
            // 
            // TerrainLayer17Button
            // 
            this.TerrainLayer17Button.Location = new System.Drawing.Point(215, 454);
            this.TerrainLayer17Button.Name = "TerrainLayer17Button";
            this.TerrainLayer17Button.Size = new System.Drawing.Size(34, 23);
            this.TerrainLayer17Button.TabIndex = 179;
            this.TerrainLayer17Button.Text = "Edit";
            this.TerrainLayer17Button.UseVisualStyleBackColor = true;
            // 
            // TerrainLayer17ColorTextBox
            // 
            this.TerrainLayer17ColorTextBox.Enabled = false;
            this.TerrainLayer17ColorTextBox.ForeColor = System.Drawing.Color.Maroon;
            this.TerrainLayer17ColorTextBox.Location = new System.Drawing.Point(157, 456);
            this.TerrainLayer17ColorTextBox.Name = "TerrainLayer17ColorTextBox";
            this.TerrainLayer17ColorTextBox.Size = new System.Drawing.Size(52, 20);
            this.TerrainLayer17ColorTextBox.TabIndex = 178;
            // 
            // TerrainLayer17NumericUpDown
            // 
            this.TerrainLayer17NumericUpDown.Location = new System.Drawing.Point(100, 456);
            this.TerrainLayer17NumericUpDown.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.TerrainLayer17NumericUpDown.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.TerrainLayer17NumericUpDown.Name = "TerrainLayer17NumericUpDown";
            this.TerrainLayer17NumericUpDown.Size = new System.Drawing.Size(51, 20);
            this.TerrainLayer17NumericUpDown.TabIndex = 177;
            this.TerrainLayer17NumericUpDown.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            // 
            // TerrainLayer16CheckBox
            // 
            this.TerrainLayer16CheckBox.AutoSize = true;
            this.TerrainLayer16CheckBox.Location = new System.Drawing.Point(6, 433);
            this.TerrainLayer16CheckBox.Name = "TerrainLayer16CheckBox";
            this.TerrainLayer16CheckBox.Size = new System.Drawing.Size(15, 14);
            this.TerrainLayer16CheckBox.TabIndex = 176;
            this.TerrainLayer16CheckBox.UseVisualStyleBackColor = true;
            // 
            // TerrainLayer16AliasTextBox
            // 
            this.TerrainLayer16AliasTextBox.Location = new System.Drawing.Point(22, 430);
            this.TerrainLayer16AliasTextBox.Name = "TerrainLayer16AliasTextBox";
            this.TerrainLayer16AliasTextBox.Size = new System.Drawing.Size(72, 20);
            this.TerrainLayer16AliasTextBox.TabIndex = 175;
            this.TerrainLayer16AliasTextBox.Text = "water deep";
            this.TerrainLayer16AliasTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxDisallowSpecialCharacters_KeyPress);
            // 
            // TerrainLayer16Button
            // 
            this.TerrainLayer16Button.Location = new System.Drawing.Point(215, 428);
            this.TerrainLayer16Button.Name = "TerrainLayer16Button";
            this.TerrainLayer16Button.Size = new System.Drawing.Size(34, 23);
            this.TerrainLayer16Button.TabIndex = 174;
            this.TerrainLayer16Button.Text = "Edit";
            this.TerrainLayer16Button.UseVisualStyleBackColor = true;
            // 
            // TerrainLayer16ColorTextBox
            // 
            this.TerrainLayer16ColorTextBox.Enabled = false;
            this.TerrainLayer16ColorTextBox.ForeColor = System.Drawing.Color.Maroon;
            this.TerrainLayer16ColorTextBox.Location = new System.Drawing.Point(157, 430);
            this.TerrainLayer16ColorTextBox.Name = "TerrainLayer16ColorTextBox";
            this.TerrainLayer16ColorTextBox.Size = new System.Drawing.Size(52, 20);
            this.TerrainLayer16ColorTextBox.TabIndex = 173;
            // 
            // TerrainLayer16NumericUpDown
            // 
            this.TerrainLayer16NumericUpDown.Location = new System.Drawing.Point(100, 430);
            this.TerrainLayer16NumericUpDown.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.TerrainLayer16NumericUpDown.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.TerrainLayer16NumericUpDown.Name = "TerrainLayer16NumericUpDown";
            this.TerrainLayer16NumericUpDown.Size = new System.Drawing.Size(51, 20);
            this.TerrainLayer16NumericUpDown.TabIndex = 172;
            this.TerrainLayer16NumericUpDown.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            // 
            // TerrainLayer15CheckBox
            // 
            this.TerrainLayer15CheckBox.AutoSize = true;
            this.TerrainLayer15CheckBox.Location = new System.Drawing.Point(6, 407);
            this.TerrainLayer15CheckBox.Name = "TerrainLayer15CheckBox";
            this.TerrainLayer15CheckBox.Size = new System.Drawing.Size(15, 14);
            this.TerrainLayer15CheckBox.TabIndex = 171;
            this.TerrainLayer15CheckBox.UseVisualStyleBackColor = true;
            // 
            // TerrainLayer15AliasTextBox
            // 
            this.TerrainLayer15AliasTextBox.Location = new System.Drawing.Point(22, 404);
            this.TerrainLayer15AliasTextBox.Name = "TerrainLayer15AliasTextBox";
            this.TerrainLayer15AliasTextBox.Size = new System.Drawing.Size(72, 20);
            this.TerrainLayer15AliasTextBox.TabIndex = 170;
            this.TerrainLayer15AliasTextBox.Text = "water deep";
            this.TerrainLayer15AliasTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxDisallowSpecialCharacters_KeyPress);
            // 
            // TerrainLayer15Button
            // 
            this.TerrainLayer15Button.Location = new System.Drawing.Point(215, 402);
            this.TerrainLayer15Button.Name = "TerrainLayer15Button";
            this.TerrainLayer15Button.Size = new System.Drawing.Size(34, 23);
            this.TerrainLayer15Button.TabIndex = 169;
            this.TerrainLayer15Button.Text = "Edit";
            this.TerrainLayer15Button.UseVisualStyleBackColor = true;
            // 
            // TerrainLayer15ColorTextBox
            // 
            this.TerrainLayer15ColorTextBox.Enabled = false;
            this.TerrainLayer15ColorTextBox.ForeColor = System.Drawing.Color.Maroon;
            this.TerrainLayer15ColorTextBox.Location = new System.Drawing.Point(157, 404);
            this.TerrainLayer15ColorTextBox.Name = "TerrainLayer15ColorTextBox";
            this.TerrainLayer15ColorTextBox.Size = new System.Drawing.Size(52, 20);
            this.TerrainLayer15ColorTextBox.TabIndex = 168;
            // 
            // TerrainLayer15NumericUpDown
            // 
            this.TerrainLayer15NumericUpDown.Location = new System.Drawing.Point(100, 404);
            this.TerrainLayer15NumericUpDown.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.TerrainLayer15NumericUpDown.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.TerrainLayer15NumericUpDown.Name = "TerrainLayer15NumericUpDown";
            this.TerrainLayer15NumericUpDown.Size = new System.Drawing.Size(51, 20);
            this.TerrainLayer15NumericUpDown.TabIndex = 167;
            this.TerrainLayer15NumericUpDown.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            // 
            // TerrainLayer14CheckBox
            // 
            this.TerrainLayer14CheckBox.AutoSize = true;
            this.TerrainLayer14CheckBox.Location = new System.Drawing.Point(6, 381);
            this.TerrainLayer14CheckBox.Name = "TerrainLayer14CheckBox";
            this.TerrainLayer14CheckBox.Size = new System.Drawing.Size(15, 14);
            this.TerrainLayer14CheckBox.TabIndex = 166;
            this.TerrainLayer14CheckBox.UseVisualStyleBackColor = true;
            // 
            // TerrainLayer14AliasTextBox
            // 
            this.TerrainLayer14AliasTextBox.Location = new System.Drawing.Point(22, 378);
            this.TerrainLayer14AliasTextBox.Name = "TerrainLayer14AliasTextBox";
            this.TerrainLayer14AliasTextBox.Size = new System.Drawing.Size(72, 20);
            this.TerrainLayer14AliasTextBox.TabIndex = 165;
            this.TerrainLayer14AliasTextBox.Text = "water deep";
            this.TerrainLayer14AliasTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxDisallowSpecialCharacters_KeyPress);
            // 
            // TerrainLayer14Button
            // 
            this.TerrainLayer14Button.Location = new System.Drawing.Point(215, 376);
            this.TerrainLayer14Button.Name = "TerrainLayer14Button";
            this.TerrainLayer14Button.Size = new System.Drawing.Size(34, 23);
            this.TerrainLayer14Button.TabIndex = 164;
            this.TerrainLayer14Button.Text = "Edit";
            this.TerrainLayer14Button.UseVisualStyleBackColor = true;
            // 
            // TerrainLayer14ColorTextBox
            // 
            this.TerrainLayer14ColorTextBox.Enabled = false;
            this.TerrainLayer14ColorTextBox.ForeColor = System.Drawing.Color.Maroon;
            this.TerrainLayer14ColorTextBox.Location = new System.Drawing.Point(157, 378);
            this.TerrainLayer14ColorTextBox.Name = "TerrainLayer14ColorTextBox";
            this.TerrainLayer14ColorTextBox.Size = new System.Drawing.Size(52, 20);
            this.TerrainLayer14ColorTextBox.TabIndex = 163;
            // 
            // TerrainLayer14NumericUpDown
            // 
            this.TerrainLayer14NumericUpDown.Location = new System.Drawing.Point(100, 378);
            this.TerrainLayer14NumericUpDown.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.TerrainLayer14NumericUpDown.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.TerrainLayer14NumericUpDown.Name = "TerrainLayer14NumericUpDown";
            this.TerrainLayer14NumericUpDown.Size = new System.Drawing.Size(51, 20);
            this.TerrainLayer14NumericUpDown.TabIndex = 162;
            this.TerrainLayer14NumericUpDown.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            // 
            // TerrainLayer13CheckBox
            // 
            this.TerrainLayer13CheckBox.AutoSize = true;
            this.TerrainLayer13CheckBox.Location = new System.Drawing.Point(6, 355);
            this.TerrainLayer13CheckBox.Name = "TerrainLayer13CheckBox";
            this.TerrainLayer13CheckBox.Size = new System.Drawing.Size(15, 14);
            this.TerrainLayer13CheckBox.TabIndex = 161;
            this.TerrainLayer13CheckBox.UseVisualStyleBackColor = true;
            // 
            // TerrainLayer13AliasTextBox
            // 
            this.TerrainLayer13AliasTextBox.Location = new System.Drawing.Point(22, 352);
            this.TerrainLayer13AliasTextBox.Name = "TerrainLayer13AliasTextBox";
            this.TerrainLayer13AliasTextBox.Size = new System.Drawing.Size(72, 20);
            this.TerrainLayer13AliasTextBox.TabIndex = 160;
            this.TerrainLayer13AliasTextBox.Text = "water deep";
            this.TerrainLayer13AliasTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxDisallowSpecialCharacters_KeyPress);
            // 
            // TerrainLayer13Button
            // 
            this.TerrainLayer13Button.Location = new System.Drawing.Point(215, 350);
            this.TerrainLayer13Button.Name = "TerrainLayer13Button";
            this.TerrainLayer13Button.Size = new System.Drawing.Size(34, 23);
            this.TerrainLayer13Button.TabIndex = 159;
            this.TerrainLayer13Button.Text = "Edit";
            this.TerrainLayer13Button.UseVisualStyleBackColor = true;
            // 
            // TerrainLayer13ColorTextBox
            // 
            this.TerrainLayer13ColorTextBox.Enabled = false;
            this.TerrainLayer13ColorTextBox.ForeColor = System.Drawing.Color.Maroon;
            this.TerrainLayer13ColorTextBox.Location = new System.Drawing.Point(157, 352);
            this.TerrainLayer13ColorTextBox.Name = "TerrainLayer13ColorTextBox";
            this.TerrainLayer13ColorTextBox.Size = new System.Drawing.Size(52, 20);
            this.TerrainLayer13ColorTextBox.TabIndex = 158;
            // 
            // TerrainLayer13NumericUpDown
            // 
            this.TerrainLayer13NumericUpDown.Location = new System.Drawing.Point(100, 352);
            this.TerrainLayer13NumericUpDown.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.TerrainLayer13NumericUpDown.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.TerrainLayer13NumericUpDown.Name = "TerrainLayer13NumericUpDown";
            this.TerrainLayer13NumericUpDown.Size = new System.Drawing.Size(51, 20);
            this.TerrainLayer13NumericUpDown.TabIndex = 157;
            this.TerrainLayer13NumericUpDown.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            // 
            // TerrainLayer12CheckBox
            // 
            this.TerrainLayer12CheckBox.AutoSize = true;
            this.TerrainLayer12CheckBox.Location = new System.Drawing.Point(6, 329);
            this.TerrainLayer12CheckBox.Name = "TerrainLayer12CheckBox";
            this.TerrainLayer12CheckBox.Size = new System.Drawing.Size(15, 14);
            this.TerrainLayer12CheckBox.TabIndex = 156;
            this.TerrainLayer12CheckBox.UseVisualStyleBackColor = true;
            // 
            // TerrainLayer12AliasTextBox
            // 
            this.TerrainLayer12AliasTextBox.Location = new System.Drawing.Point(22, 326);
            this.TerrainLayer12AliasTextBox.Name = "TerrainLayer12AliasTextBox";
            this.TerrainLayer12AliasTextBox.Size = new System.Drawing.Size(72, 20);
            this.TerrainLayer12AliasTextBox.TabIndex = 155;
            this.TerrainLayer12AliasTextBox.Text = "water deep";
            this.TerrainLayer12AliasTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxDisallowSpecialCharacters_KeyPress);
            // 
            // TerrainLayer12Button
            // 
            this.TerrainLayer12Button.Location = new System.Drawing.Point(215, 324);
            this.TerrainLayer12Button.Name = "TerrainLayer12Button";
            this.TerrainLayer12Button.Size = new System.Drawing.Size(34, 23);
            this.TerrainLayer12Button.TabIndex = 154;
            this.TerrainLayer12Button.Text = "Edit";
            this.TerrainLayer12Button.UseVisualStyleBackColor = true;
            // 
            // TerrainLayer12ColorTextBox
            // 
            this.TerrainLayer12ColorTextBox.Enabled = false;
            this.TerrainLayer12ColorTextBox.ForeColor = System.Drawing.Color.Maroon;
            this.TerrainLayer12ColorTextBox.Location = new System.Drawing.Point(157, 326);
            this.TerrainLayer12ColorTextBox.Name = "TerrainLayer12ColorTextBox";
            this.TerrainLayer12ColorTextBox.Size = new System.Drawing.Size(52, 20);
            this.TerrainLayer12ColorTextBox.TabIndex = 153;
            // 
            // TerrainLayer12NumericUpDown
            // 
            this.TerrainLayer12NumericUpDown.Location = new System.Drawing.Point(100, 326);
            this.TerrainLayer12NumericUpDown.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.TerrainLayer12NumericUpDown.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.TerrainLayer12NumericUpDown.Name = "TerrainLayer12NumericUpDown";
            this.TerrainLayer12NumericUpDown.Size = new System.Drawing.Size(51, 20);
            this.TerrainLayer12NumericUpDown.TabIndex = 152;
            this.TerrainLayer12NumericUpDown.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            // 
            // TerrainLayer11CheckBox
            // 
            this.TerrainLayer11CheckBox.AutoSize = true;
            this.TerrainLayer11CheckBox.Location = new System.Drawing.Point(6, 303);
            this.TerrainLayer11CheckBox.Name = "TerrainLayer11CheckBox";
            this.TerrainLayer11CheckBox.Size = new System.Drawing.Size(15, 14);
            this.TerrainLayer11CheckBox.TabIndex = 151;
            this.TerrainLayer11CheckBox.UseVisualStyleBackColor = true;
            // 
            // TerrainLayer11AliasTextBox
            // 
            this.TerrainLayer11AliasTextBox.Location = new System.Drawing.Point(22, 300);
            this.TerrainLayer11AliasTextBox.Name = "TerrainLayer11AliasTextBox";
            this.TerrainLayer11AliasTextBox.Size = new System.Drawing.Size(72, 20);
            this.TerrainLayer11AliasTextBox.TabIndex = 150;
            this.TerrainLayer11AliasTextBox.Text = "water deep";
            this.TerrainLayer11AliasTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxDisallowSpecialCharacters_KeyPress);
            // 
            // TerrainLayer11Button
            // 
            this.TerrainLayer11Button.Location = new System.Drawing.Point(215, 298);
            this.TerrainLayer11Button.Name = "TerrainLayer11Button";
            this.TerrainLayer11Button.Size = new System.Drawing.Size(34, 23);
            this.TerrainLayer11Button.TabIndex = 149;
            this.TerrainLayer11Button.Text = "Edit";
            this.TerrainLayer11Button.UseVisualStyleBackColor = true;
            // 
            // TerrainLayer11ColorTextBox
            // 
            this.TerrainLayer11ColorTextBox.Enabled = false;
            this.TerrainLayer11ColorTextBox.ForeColor = System.Drawing.Color.Maroon;
            this.TerrainLayer11ColorTextBox.Location = new System.Drawing.Point(157, 300);
            this.TerrainLayer11ColorTextBox.Name = "TerrainLayer11ColorTextBox";
            this.TerrainLayer11ColorTextBox.Size = new System.Drawing.Size(52, 20);
            this.TerrainLayer11ColorTextBox.TabIndex = 148;
            // 
            // TerrainLayer11NumericUpDown
            // 
            this.TerrainLayer11NumericUpDown.Location = new System.Drawing.Point(100, 300);
            this.TerrainLayer11NumericUpDown.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.TerrainLayer11NumericUpDown.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.TerrainLayer11NumericUpDown.Name = "TerrainLayer11NumericUpDown";
            this.TerrainLayer11NumericUpDown.Size = new System.Drawing.Size(51, 20);
            this.TerrainLayer11NumericUpDown.TabIndex = 147;
            this.TerrainLayer11NumericUpDown.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            // 
            // TerrainLayer10CheckBox
            // 
            this.TerrainLayer10CheckBox.AutoSize = true;
            this.TerrainLayer10CheckBox.Location = new System.Drawing.Point(6, 277);
            this.TerrainLayer10CheckBox.Name = "TerrainLayer10CheckBox";
            this.TerrainLayer10CheckBox.Size = new System.Drawing.Size(15, 14);
            this.TerrainLayer10CheckBox.TabIndex = 146;
            this.TerrainLayer10CheckBox.UseVisualStyleBackColor = true;
            // 
            // TerrainLayer10AliasTextBox
            // 
            this.TerrainLayer10AliasTextBox.Location = new System.Drawing.Point(22, 274);
            this.TerrainLayer10AliasTextBox.Name = "TerrainLayer10AliasTextBox";
            this.TerrainLayer10AliasTextBox.Size = new System.Drawing.Size(72, 20);
            this.TerrainLayer10AliasTextBox.TabIndex = 145;
            this.TerrainLayer10AliasTextBox.Text = "water deep";
            this.TerrainLayer10AliasTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxDisallowSpecialCharacters_KeyPress);
            // 
            // TerrainLayer10Button
            // 
            this.TerrainLayer10Button.Location = new System.Drawing.Point(215, 272);
            this.TerrainLayer10Button.Name = "TerrainLayer10Button";
            this.TerrainLayer10Button.Size = new System.Drawing.Size(34, 23);
            this.TerrainLayer10Button.TabIndex = 144;
            this.TerrainLayer10Button.Text = "Edit";
            this.TerrainLayer10Button.UseVisualStyleBackColor = true;
            // 
            // TerrainLayer10ColorTextBox
            // 
            this.TerrainLayer10ColorTextBox.Enabled = false;
            this.TerrainLayer10ColorTextBox.ForeColor = System.Drawing.Color.Maroon;
            this.TerrainLayer10ColorTextBox.Location = new System.Drawing.Point(157, 274);
            this.TerrainLayer10ColorTextBox.Name = "TerrainLayer10ColorTextBox";
            this.TerrainLayer10ColorTextBox.Size = new System.Drawing.Size(52, 20);
            this.TerrainLayer10ColorTextBox.TabIndex = 143;
            // 
            // TerrainLayer10NumericUpDown
            // 
            this.TerrainLayer10NumericUpDown.Location = new System.Drawing.Point(100, 274);
            this.TerrainLayer10NumericUpDown.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.TerrainLayer10NumericUpDown.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.TerrainLayer10NumericUpDown.Name = "TerrainLayer10NumericUpDown";
            this.TerrainLayer10NumericUpDown.Size = new System.Drawing.Size(51, 20);
            this.TerrainLayer10NumericUpDown.TabIndex = 142;
            this.TerrainLayer10NumericUpDown.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            // 
            // TerrainLayer9CheckBox
            // 
            this.TerrainLayer9CheckBox.AutoSize = true;
            this.TerrainLayer9CheckBox.Location = new System.Drawing.Point(6, 251);
            this.TerrainLayer9CheckBox.Name = "TerrainLayer9CheckBox";
            this.TerrainLayer9CheckBox.Size = new System.Drawing.Size(15, 14);
            this.TerrainLayer9CheckBox.TabIndex = 141;
            this.TerrainLayer9CheckBox.UseVisualStyleBackColor = true;
            // 
            // TerrainLayer9AliasTextBox
            // 
            this.TerrainLayer9AliasTextBox.Location = new System.Drawing.Point(22, 248);
            this.TerrainLayer9AliasTextBox.Name = "TerrainLayer9AliasTextBox";
            this.TerrainLayer9AliasTextBox.Size = new System.Drawing.Size(72, 20);
            this.TerrainLayer9AliasTextBox.TabIndex = 140;
            this.TerrainLayer9AliasTextBox.Text = "water deep";
            this.TerrainLayer9AliasTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxDisallowSpecialCharacters_KeyPress);
            // 
            // TerrainLayer9Button
            // 
            this.TerrainLayer9Button.Location = new System.Drawing.Point(215, 246);
            this.TerrainLayer9Button.Name = "TerrainLayer9Button";
            this.TerrainLayer9Button.Size = new System.Drawing.Size(34, 23);
            this.TerrainLayer9Button.TabIndex = 139;
            this.TerrainLayer9Button.Text = "Edit";
            this.TerrainLayer9Button.UseVisualStyleBackColor = true;
            // 
            // TerrainLayer9ColorTextBox
            // 
            this.TerrainLayer9ColorTextBox.Enabled = false;
            this.TerrainLayer9ColorTextBox.ForeColor = System.Drawing.Color.Maroon;
            this.TerrainLayer9ColorTextBox.Location = new System.Drawing.Point(157, 248);
            this.TerrainLayer9ColorTextBox.Name = "TerrainLayer9ColorTextBox";
            this.TerrainLayer9ColorTextBox.Size = new System.Drawing.Size(52, 20);
            this.TerrainLayer9ColorTextBox.TabIndex = 138;
            // 
            // TerrainLayer9NumericUpDown
            // 
            this.TerrainLayer9NumericUpDown.Location = new System.Drawing.Point(100, 248);
            this.TerrainLayer9NumericUpDown.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.TerrainLayer9NumericUpDown.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.TerrainLayer9NumericUpDown.Name = "TerrainLayer9NumericUpDown";
            this.TerrainLayer9NumericUpDown.Size = new System.Drawing.Size(51, 20);
            this.TerrainLayer9NumericUpDown.TabIndex = 137;
            this.TerrainLayer9NumericUpDown.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            // 
            // TerrainLayer8CheckBox
            // 
            this.TerrainLayer8CheckBox.AutoSize = true;
            this.TerrainLayer8CheckBox.Location = new System.Drawing.Point(6, 225);
            this.TerrainLayer8CheckBox.Name = "TerrainLayer8CheckBox";
            this.TerrainLayer8CheckBox.Size = new System.Drawing.Size(15, 14);
            this.TerrainLayer8CheckBox.TabIndex = 136;
            this.TerrainLayer8CheckBox.UseVisualStyleBackColor = true;
            // 
            // TerrainLayer8AliasTextBox
            // 
            this.TerrainLayer8AliasTextBox.Location = new System.Drawing.Point(22, 222);
            this.TerrainLayer8AliasTextBox.Name = "TerrainLayer8AliasTextBox";
            this.TerrainLayer8AliasTextBox.Size = new System.Drawing.Size(72, 20);
            this.TerrainLayer8AliasTextBox.TabIndex = 135;
            this.TerrainLayer8AliasTextBox.Text = "water deep";
            this.TerrainLayer8AliasTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxDisallowSpecialCharacters_KeyPress);
            // 
            // TerrainLayer8Button
            // 
            this.TerrainLayer8Button.Location = new System.Drawing.Point(215, 220);
            this.TerrainLayer8Button.Name = "TerrainLayer8Button";
            this.TerrainLayer8Button.Size = new System.Drawing.Size(34, 23);
            this.TerrainLayer8Button.TabIndex = 134;
            this.TerrainLayer8Button.Text = "Edit";
            this.TerrainLayer8Button.UseVisualStyleBackColor = true;
            // 
            // TerrainLayer8ColorTextBox
            // 
            this.TerrainLayer8ColorTextBox.Enabled = false;
            this.TerrainLayer8ColorTextBox.ForeColor = System.Drawing.Color.Maroon;
            this.TerrainLayer8ColorTextBox.Location = new System.Drawing.Point(157, 222);
            this.TerrainLayer8ColorTextBox.Name = "TerrainLayer8ColorTextBox";
            this.TerrainLayer8ColorTextBox.Size = new System.Drawing.Size(52, 20);
            this.TerrainLayer8ColorTextBox.TabIndex = 133;
            // 
            // TerrainLayer8NumericUpDown
            // 
            this.TerrainLayer8NumericUpDown.Location = new System.Drawing.Point(100, 222);
            this.TerrainLayer8NumericUpDown.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.TerrainLayer8NumericUpDown.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.TerrainLayer8NumericUpDown.Name = "TerrainLayer8NumericUpDown";
            this.TerrainLayer8NumericUpDown.Size = new System.Drawing.Size(51, 20);
            this.TerrainLayer8NumericUpDown.TabIndex = 132;
            this.TerrainLayer8NumericUpDown.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            // 
            // TerrainLayer7CheckBox
            // 
            this.TerrainLayer7CheckBox.AutoSize = true;
            this.TerrainLayer7CheckBox.Location = new System.Drawing.Point(6, 199);
            this.TerrainLayer7CheckBox.Name = "TerrainLayer7CheckBox";
            this.TerrainLayer7CheckBox.Size = new System.Drawing.Size(15, 14);
            this.TerrainLayer7CheckBox.TabIndex = 131;
            this.TerrainLayer7CheckBox.UseVisualStyleBackColor = true;
            // 
            // TerrainLayer7AliasTextBox
            // 
            this.TerrainLayer7AliasTextBox.Location = new System.Drawing.Point(22, 196);
            this.TerrainLayer7AliasTextBox.Name = "TerrainLayer7AliasTextBox";
            this.TerrainLayer7AliasTextBox.Size = new System.Drawing.Size(72, 20);
            this.TerrainLayer7AliasTextBox.TabIndex = 130;
            this.TerrainLayer7AliasTextBox.Text = "water deep";
            this.TerrainLayer7AliasTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxDisallowSpecialCharacters_KeyPress);
            // 
            // TerrainLayer7Button
            // 
            this.TerrainLayer7Button.Location = new System.Drawing.Point(215, 194);
            this.TerrainLayer7Button.Name = "TerrainLayer7Button";
            this.TerrainLayer7Button.Size = new System.Drawing.Size(34, 23);
            this.TerrainLayer7Button.TabIndex = 129;
            this.TerrainLayer7Button.Text = "Edit";
            this.TerrainLayer7Button.UseVisualStyleBackColor = true;
            // 
            // TerrainLayer7ColorTextBox
            // 
            this.TerrainLayer7ColorTextBox.Enabled = false;
            this.TerrainLayer7ColorTextBox.ForeColor = System.Drawing.Color.Maroon;
            this.TerrainLayer7ColorTextBox.Location = new System.Drawing.Point(157, 196);
            this.TerrainLayer7ColorTextBox.Name = "TerrainLayer7ColorTextBox";
            this.TerrainLayer7ColorTextBox.Size = new System.Drawing.Size(52, 20);
            this.TerrainLayer7ColorTextBox.TabIndex = 128;
            // 
            // TerrainLayer7NumericUpDown
            // 
            this.TerrainLayer7NumericUpDown.Location = new System.Drawing.Point(100, 196);
            this.TerrainLayer7NumericUpDown.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.TerrainLayer7NumericUpDown.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.TerrainLayer7NumericUpDown.Name = "TerrainLayer7NumericUpDown";
            this.TerrainLayer7NumericUpDown.Size = new System.Drawing.Size(51, 20);
            this.TerrainLayer7NumericUpDown.TabIndex = 127;
            this.TerrainLayer7NumericUpDown.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            // 
            // TerrainLayer6CheckBox
            // 
            this.TerrainLayer6CheckBox.AutoSize = true;
            this.TerrainLayer6CheckBox.Location = new System.Drawing.Point(6, 173);
            this.TerrainLayer6CheckBox.Name = "TerrainLayer6CheckBox";
            this.TerrainLayer6CheckBox.Size = new System.Drawing.Size(15, 14);
            this.TerrainLayer6CheckBox.TabIndex = 126;
            this.TerrainLayer6CheckBox.UseVisualStyleBackColor = true;
            // 
            // TerrainLayer6AliasTextBox
            // 
            this.TerrainLayer6AliasTextBox.Location = new System.Drawing.Point(22, 170);
            this.TerrainLayer6AliasTextBox.Name = "TerrainLayer6AliasTextBox";
            this.TerrainLayer6AliasTextBox.Size = new System.Drawing.Size(72, 20);
            this.TerrainLayer6AliasTextBox.TabIndex = 125;
            this.TerrainLayer6AliasTextBox.Text = "water deep";
            this.TerrainLayer6AliasTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxDisallowSpecialCharacters_KeyPress);
            // 
            // TerrainLayer6Button
            // 
            this.TerrainLayer6Button.Location = new System.Drawing.Point(215, 168);
            this.TerrainLayer6Button.Name = "TerrainLayer6Button";
            this.TerrainLayer6Button.Size = new System.Drawing.Size(34, 23);
            this.TerrainLayer6Button.TabIndex = 124;
            this.TerrainLayer6Button.Text = "Edit";
            this.TerrainLayer6Button.UseVisualStyleBackColor = true;
            // 
            // TerrainLayer6ColorTextBox
            // 
            this.TerrainLayer6ColorTextBox.Enabled = false;
            this.TerrainLayer6ColorTextBox.ForeColor = System.Drawing.Color.Maroon;
            this.TerrainLayer6ColorTextBox.Location = new System.Drawing.Point(157, 170);
            this.TerrainLayer6ColorTextBox.Name = "TerrainLayer6ColorTextBox";
            this.TerrainLayer6ColorTextBox.Size = new System.Drawing.Size(52, 20);
            this.TerrainLayer6ColorTextBox.TabIndex = 123;
            // 
            // TerrainLayer6NumericUpDown
            // 
            this.TerrainLayer6NumericUpDown.Location = new System.Drawing.Point(100, 170);
            this.TerrainLayer6NumericUpDown.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.TerrainLayer6NumericUpDown.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.TerrainLayer6NumericUpDown.Name = "TerrainLayer6NumericUpDown";
            this.TerrainLayer6NumericUpDown.Size = new System.Drawing.Size(51, 20);
            this.TerrainLayer6NumericUpDown.TabIndex = 122;
            this.TerrainLayer6NumericUpDown.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            // 
            // TerrainLayer5CheckBox
            // 
            this.TerrainLayer5CheckBox.AutoSize = true;
            this.TerrainLayer5CheckBox.Location = new System.Drawing.Point(6, 147);
            this.TerrainLayer5CheckBox.Name = "TerrainLayer5CheckBox";
            this.TerrainLayer5CheckBox.Size = new System.Drawing.Size(15, 14);
            this.TerrainLayer5CheckBox.TabIndex = 121;
            this.TerrainLayer5CheckBox.UseVisualStyleBackColor = true;
            // 
            // TerrainLayer5AliasTextBox
            // 
            this.TerrainLayer5AliasTextBox.Location = new System.Drawing.Point(22, 144);
            this.TerrainLayer5AliasTextBox.Name = "TerrainLayer5AliasTextBox";
            this.TerrainLayer5AliasTextBox.Size = new System.Drawing.Size(72, 20);
            this.TerrainLayer5AliasTextBox.TabIndex = 120;
            this.TerrainLayer5AliasTextBox.Text = "water deep";
            this.TerrainLayer5AliasTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxDisallowSpecialCharacters_KeyPress);
            // 
            // TerrainLayer5Button
            // 
            this.TerrainLayer5Button.Location = new System.Drawing.Point(215, 142);
            this.TerrainLayer5Button.Name = "TerrainLayer5Button";
            this.TerrainLayer5Button.Size = new System.Drawing.Size(34, 23);
            this.TerrainLayer5Button.TabIndex = 119;
            this.TerrainLayer5Button.Text = "Edit";
            this.TerrainLayer5Button.UseVisualStyleBackColor = true;
            // 
            // TerrainLayer5ColorTextBox
            // 
            this.TerrainLayer5ColorTextBox.Enabled = false;
            this.TerrainLayer5ColorTextBox.ForeColor = System.Drawing.Color.Maroon;
            this.TerrainLayer5ColorTextBox.Location = new System.Drawing.Point(157, 144);
            this.TerrainLayer5ColorTextBox.Name = "TerrainLayer5ColorTextBox";
            this.TerrainLayer5ColorTextBox.Size = new System.Drawing.Size(52, 20);
            this.TerrainLayer5ColorTextBox.TabIndex = 118;
            // 
            // TerrainLayer5NumericUpDown
            // 
            this.TerrainLayer5NumericUpDown.Location = new System.Drawing.Point(100, 144);
            this.TerrainLayer5NumericUpDown.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.TerrainLayer5NumericUpDown.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.TerrainLayer5NumericUpDown.Name = "TerrainLayer5NumericUpDown";
            this.TerrainLayer5NumericUpDown.Size = new System.Drawing.Size(51, 20);
            this.TerrainLayer5NumericUpDown.TabIndex = 117;
            this.TerrainLayer5NumericUpDown.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            // 
            // TerrainLayer4CheckBox
            // 
            this.TerrainLayer4CheckBox.AutoSize = true;
            this.TerrainLayer4CheckBox.Location = new System.Drawing.Point(6, 121);
            this.TerrainLayer4CheckBox.Name = "TerrainLayer4CheckBox";
            this.TerrainLayer4CheckBox.Size = new System.Drawing.Size(15, 14);
            this.TerrainLayer4CheckBox.TabIndex = 116;
            this.TerrainLayer4CheckBox.UseVisualStyleBackColor = true;
            // 
            // TerrainLayer4AliasTextBox
            // 
            this.TerrainLayer4AliasTextBox.Location = new System.Drawing.Point(22, 118);
            this.TerrainLayer4AliasTextBox.Name = "TerrainLayer4AliasTextBox";
            this.TerrainLayer4AliasTextBox.Size = new System.Drawing.Size(72, 20);
            this.TerrainLayer4AliasTextBox.TabIndex = 115;
            this.TerrainLayer4AliasTextBox.Text = "water deep";
            this.TerrainLayer4AliasTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxDisallowSpecialCharacters_KeyPress);
            // 
            // TerrainLayer4Button
            // 
            this.TerrainLayer4Button.Location = new System.Drawing.Point(215, 116);
            this.TerrainLayer4Button.Name = "TerrainLayer4Button";
            this.TerrainLayer4Button.Size = new System.Drawing.Size(34, 23);
            this.TerrainLayer4Button.TabIndex = 114;
            this.TerrainLayer4Button.Text = "Edit";
            this.TerrainLayer4Button.UseVisualStyleBackColor = true;
            // 
            // TerrainLayer4ColorTextBox
            // 
            this.TerrainLayer4ColorTextBox.Enabled = false;
            this.TerrainLayer4ColorTextBox.ForeColor = System.Drawing.Color.Maroon;
            this.TerrainLayer4ColorTextBox.Location = new System.Drawing.Point(157, 118);
            this.TerrainLayer4ColorTextBox.Name = "TerrainLayer4ColorTextBox";
            this.TerrainLayer4ColorTextBox.Size = new System.Drawing.Size(52, 20);
            this.TerrainLayer4ColorTextBox.TabIndex = 113;
            // 
            // TerrainLayer4NumericUpDown
            // 
            this.TerrainLayer4NumericUpDown.Location = new System.Drawing.Point(100, 118);
            this.TerrainLayer4NumericUpDown.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.TerrainLayer4NumericUpDown.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.TerrainLayer4NumericUpDown.Name = "TerrainLayer4NumericUpDown";
            this.TerrainLayer4NumericUpDown.Size = new System.Drawing.Size(51, 20);
            this.TerrainLayer4NumericUpDown.TabIndex = 112;
            this.TerrainLayer4NumericUpDown.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            // 
            // TerrainLayer3CheckBox
            // 
            this.TerrainLayer3CheckBox.AutoSize = true;
            this.TerrainLayer3CheckBox.Location = new System.Drawing.Point(6, 95);
            this.TerrainLayer3CheckBox.Name = "TerrainLayer3CheckBox";
            this.TerrainLayer3CheckBox.Size = new System.Drawing.Size(15, 14);
            this.TerrainLayer3CheckBox.TabIndex = 111;
            this.TerrainLayer3CheckBox.UseVisualStyleBackColor = true;
            // 
            // TerrainLayer3AliasTextBox
            // 
            this.TerrainLayer3AliasTextBox.Location = new System.Drawing.Point(22, 92);
            this.TerrainLayer3AliasTextBox.Name = "TerrainLayer3AliasTextBox";
            this.TerrainLayer3AliasTextBox.Size = new System.Drawing.Size(72, 20);
            this.TerrainLayer3AliasTextBox.TabIndex = 110;
            this.TerrainLayer3AliasTextBox.Text = "water deep";
            this.TerrainLayer3AliasTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxDisallowSpecialCharacters_KeyPress);
            // 
            // TerrainLayer3Button
            // 
            this.TerrainLayer3Button.Location = new System.Drawing.Point(215, 90);
            this.TerrainLayer3Button.Name = "TerrainLayer3Button";
            this.TerrainLayer3Button.Size = new System.Drawing.Size(34, 23);
            this.TerrainLayer3Button.TabIndex = 109;
            this.TerrainLayer3Button.Text = "Edit";
            this.TerrainLayer3Button.UseVisualStyleBackColor = true;
            // 
            // TerrainLayer3ColorTextBox
            // 
            this.TerrainLayer3ColorTextBox.Enabled = false;
            this.TerrainLayer3ColorTextBox.ForeColor = System.Drawing.Color.Maroon;
            this.TerrainLayer3ColorTextBox.Location = new System.Drawing.Point(157, 92);
            this.TerrainLayer3ColorTextBox.Name = "TerrainLayer3ColorTextBox";
            this.TerrainLayer3ColorTextBox.Size = new System.Drawing.Size(52, 20);
            this.TerrainLayer3ColorTextBox.TabIndex = 108;
            // 
            // TerrainLayer3NumericUpDown
            // 
            this.TerrainLayer3NumericUpDown.Location = new System.Drawing.Point(100, 92);
            this.TerrainLayer3NumericUpDown.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.TerrainLayer3NumericUpDown.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.TerrainLayer3NumericUpDown.Name = "TerrainLayer3NumericUpDown";
            this.TerrainLayer3NumericUpDown.Size = new System.Drawing.Size(51, 20);
            this.TerrainLayer3NumericUpDown.TabIndex = 107;
            this.TerrainLayer3NumericUpDown.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            // 
            // TerrainLayer2CheckBox
            // 
            this.TerrainLayer2CheckBox.AutoSize = true;
            this.TerrainLayer2CheckBox.Location = new System.Drawing.Point(6, 69);
            this.TerrainLayer2CheckBox.Name = "TerrainLayer2CheckBox";
            this.TerrainLayer2CheckBox.Size = new System.Drawing.Size(15, 14);
            this.TerrainLayer2CheckBox.TabIndex = 106;
            this.TerrainLayer2CheckBox.UseVisualStyleBackColor = true;
            // 
            // TerrainLayer2AliasTextBox
            // 
            this.TerrainLayer2AliasTextBox.Location = new System.Drawing.Point(22, 66);
            this.TerrainLayer2AliasTextBox.Name = "TerrainLayer2AliasTextBox";
            this.TerrainLayer2AliasTextBox.Size = new System.Drawing.Size(72, 20);
            this.TerrainLayer2AliasTextBox.TabIndex = 105;
            this.TerrainLayer2AliasTextBox.Text = "water deep";
            this.TerrainLayer2AliasTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxDisallowSpecialCharacters_KeyPress);
            // 
            // TerrainLayer2Button
            // 
            this.TerrainLayer2Button.Location = new System.Drawing.Point(215, 64);
            this.TerrainLayer2Button.Name = "TerrainLayer2Button";
            this.TerrainLayer2Button.Size = new System.Drawing.Size(34, 23);
            this.TerrainLayer2Button.TabIndex = 104;
            this.TerrainLayer2Button.Text = "Edit";
            this.TerrainLayer2Button.UseVisualStyleBackColor = true;
            // 
            // TerrainLayer2ColorTextBox
            // 
            this.TerrainLayer2ColorTextBox.Enabled = false;
            this.TerrainLayer2ColorTextBox.ForeColor = System.Drawing.Color.Maroon;
            this.TerrainLayer2ColorTextBox.Location = new System.Drawing.Point(157, 66);
            this.TerrainLayer2ColorTextBox.Name = "TerrainLayer2ColorTextBox";
            this.TerrainLayer2ColorTextBox.Size = new System.Drawing.Size(52, 20);
            this.TerrainLayer2ColorTextBox.TabIndex = 103;
            // 
            // TerrainLayer2NumericUpDown
            // 
            this.TerrainLayer2NumericUpDown.Location = new System.Drawing.Point(100, 66);
            this.TerrainLayer2NumericUpDown.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.TerrainLayer2NumericUpDown.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.TerrainLayer2NumericUpDown.Name = "TerrainLayer2NumericUpDown";
            this.TerrainLayer2NumericUpDown.Size = new System.Drawing.Size(51, 20);
            this.TerrainLayer2NumericUpDown.TabIndex = 102;
            this.TerrainLayer2NumericUpDown.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            // 
            // TerrainLayer1CheckBox
            // 
            this.TerrainLayer1CheckBox.AutoSize = true;
            this.TerrainLayer1CheckBox.Location = new System.Drawing.Point(6, 43);
            this.TerrainLayer1CheckBox.Name = "TerrainLayer1CheckBox";
            this.TerrainLayer1CheckBox.Size = new System.Drawing.Size(15, 14);
            this.TerrainLayer1CheckBox.TabIndex = 101;
            this.TerrainLayer1CheckBox.UseVisualStyleBackColor = true;
            // 
            // TerrainLayer1AliasTextBox
            // 
            this.TerrainLayer1AliasTextBox.Location = new System.Drawing.Point(22, 40);
            this.TerrainLayer1AliasTextBox.Name = "TerrainLayer1AliasTextBox";
            this.TerrainLayer1AliasTextBox.Size = new System.Drawing.Size(72, 20);
            this.TerrainLayer1AliasTextBox.TabIndex = 100;
            this.TerrainLayer1AliasTextBox.Text = "water deep";
            this.TerrainLayer1AliasTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxDisallowSpecialCharacters_KeyPress);
            // 
            // TerrainLayer1Button
            // 
            this.TerrainLayer1Button.Location = new System.Drawing.Point(215, 38);
            this.TerrainLayer1Button.Name = "TerrainLayer1Button";
            this.TerrainLayer1Button.Size = new System.Drawing.Size(34, 23);
            this.TerrainLayer1Button.TabIndex = 30;
            this.TerrainLayer1Button.Text = "Edit";
            this.TerrainLayer1Button.UseVisualStyleBackColor = true;
            // 
            // TerrainLayer1ColorTextBox
            // 
            this.TerrainLayer1ColorTextBox.Enabled = false;
            this.TerrainLayer1ColorTextBox.ForeColor = System.Drawing.Color.Maroon;
            this.TerrainLayer1ColorTextBox.Location = new System.Drawing.Point(157, 40);
            this.TerrainLayer1ColorTextBox.Name = "TerrainLayer1ColorTextBox";
            this.TerrainLayer1ColorTextBox.Size = new System.Drawing.Size(52, 20);
            this.TerrainLayer1ColorTextBox.TabIndex = 29;
            // 
            // TerrainLayer1NumericUpDown
            // 
            this.TerrainLayer1NumericUpDown.Location = new System.Drawing.Point(100, 40);
            this.TerrainLayer1NumericUpDown.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.TerrainLayer1NumericUpDown.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.TerrainLayer1NumericUpDown.Name = "TerrainLayer1NumericUpDown";
            this.TerrainLayer1NumericUpDown.Size = new System.Drawing.Size(51, 20);
            this.TerrainLayer1NumericUpDown.TabIndex = 27;
            this.TerrainLayer1NumericUpDown.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            // 
            // BuildingTabPage
            // 
            this.BuildingTabPage.Controls.Add(this.BuildingsOutlineEditButton);
            this.BuildingTabPage.Controls.Add(this.label22);
            this.BuildingTabPage.Controls.Add(this.BuildingsOutlineTextBox);
            this.BuildingTabPage.Controls.Add(this.ShowBuildingOutlinesCheckBox);
            this.BuildingTabPage.Controls.Add(this.groupBox8);
            this.BuildingTabPage.Controls.Add(this.BuildingsEditButton);
            this.BuildingTabPage.Controls.Add(this.label21);
            this.BuildingTabPage.Controls.Add(this.BuildingsTextBox);
            this.BuildingTabPage.Location = new System.Drawing.Point(4, 22);
            this.BuildingTabPage.Name = "BuildingTabPage";
            this.BuildingTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.BuildingTabPage.Size = new System.Drawing.Size(269, 279);
            this.BuildingTabPage.TabIndex = 4;
            this.BuildingTabPage.Text = "Buildings";
            this.BuildingTabPage.UseVisualStyleBackColor = true;
            // 
            // BuildingsOutlineEditButton
            // 
            this.BuildingsOutlineEditButton.Location = new System.Drawing.Point(228, 63);
            this.BuildingsOutlineEditButton.Name = "BuildingsOutlineEditButton";
            this.BuildingsOutlineEditButton.Size = new System.Drawing.Size(34, 23);
            this.BuildingsOutlineEditButton.TabIndex = 77;
            this.BuildingsOutlineEditButton.Text = "Edit";
            this.BuildingsOutlineEditButton.UseVisualStyleBackColor = true;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(10, 68);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(85, 13);
            this.label22.TabIndex = 76;
            this.label22.Text = "Building Outlines";
            // 
            // BuildingsOutlineTextBox
            // 
            this.BuildingsOutlineTextBox.Enabled = false;
            this.BuildingsOutlineTextBox.ForeColor = System.Drawing.Color.Maroon;
            this.BuildingsOutlineTextBox.Location = new System.Drawing.Point(121, 65);
            this.BuildingsOutlineTextBox.Name = "BuildingsOutlineTextBox";
            this.BuildingsOutlineTextBox.Size = new System.Drawing.Size(101, 20);
            this.BuildingsOutlineTextBox.TabIndex = 75;
            // 
            // ShowBuildingOutlinesCheckBox
            // 
            this.ShowBuildingOutlinesCheckBox.AutoSize = true;
            this.ShowBuildingOutlinesCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ShowBuildingOutlinesCheckBox.Location = new System.Drawing.Point(10, 9);
            this.ShowBuildingOutlinesCheckBox.Name = "ShowBuildingOutlinesCheckBox";
            this.ShowBuildingOutlinesCheckBox.Size = new System.Drawing.Size(139, 17);
            this.ShowBuildingOutlinesCheckBox.TabIndex = 74;
            this.ShowBuildingOutlinesCheckBox.Text = "Show Buildings Outlines";
            this.ShowBuildingOutlinesCheckBox.UseVisualStyleBackColor = true;
            // 
            // groupBox8
            // 
            this.groupBox8.Location = new System.Drawing.Point(6, 33);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(266, 2);
            this.groupBox8.TabIndex = 73;
            this.groupBox8.TabStop = false;
            // 
            // BuildingsEditButton
            // 
            this.BuildingsEditButton.Location = new System.Drawing.Point(228, 37);
            this.BuildingsEditButton.Name = "BuildingsEditButton";
            this.BuildingsEditButton.Size = new System.Drawing.Size(34, 23);
            this.BuildingsEditButton.TabIndex = 71;
            this.BuildingsEditButton.Text = "Edit";
            this.BuildingsEditButton.UseVisualStyleBackColor = true;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(10, 42);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(49, 13);
            this.label21.TabIndex = 70;
            this.label21.Text = "Buildings";
            // 
            // BuildingsTextBox
            // 
            this.BuildingsTextBox.Enabled = false;
            this.BuildingsTextBox.ForeColor = System.Drawing.Color.Maroon;
            this.BuildingsTextBox.Location = new System.Drawing.Point(121, 39);
            this.BuildingsTextBox.Name = "BuildingsTextBox";
            this.BuildingsTextBox.Size = new System.Drawing.Size(101, 20);
            this.BuildingsTextBox.TabIndex = 69;
            // 
            // ZoomTrackBar
            // 
            this.ZoomTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ZoomTrackBar.AutoSize = false;
            this.ZoomTrackBar.Enabled = false;
            this.ZoomTrackBar.LargeChange = 1;
            this.ZoomTrackBar.Location = new System.Drawing.Point(655, 710);
            this.ZoomTrackBar.Maximum = 4;
            this.ZoomTrackBar.Minimum = -4;
            this.ZoomTrackBar.Name = "ZoomTrackBar";
            this.ZoomTrackBar.Size = new System.Drawing.Size(141, 23);
            this.ZoomTrackBar.TabIndex = 13;
            this.ZoomTrackBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ZoomTrackBar_MouseUp);
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(582, 713);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(59, 13);
            this.label18.TabIndex = 14;
            this.label18.Text = "Zoom level";
            // 
            // label19
            // 
            this.label19.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(793, 709);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(17, 18);
            this.label19.TabIndex = 15;
            this.label19.Text = "+";
            // 
            // label20
            // 
            this.label20.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(647, 709);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(13, 18);
            this.label20.TabIndex = 16;
            this.label20.Text = "-";
            // 
            // ResetZoomButton
            // 
            this.ResetZoomButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ResetZoomButton.Enabled = false;
            this.ResetZoomButton.Location = new System.Drawing.Point(816, 709);
            this.ResetZoomButton.Name = "ResetZoomButton";
            this.ResetZoomButton.Size = new System.Drawing.Size(53, 20);
            this.ResetZoomButton.TabIndex = 18;
            this.ResetZoomButton.Text = "Reset";
            this.ResetZoomButton.UseVisualStyleBackColor = true;
            this.ResetZoomButton.Click += new System.EventHandler(this.ResetZoomButton_Click);
            // 
            // SizesComboBox
            // 
            this.SizesComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SizesComboBox.FormattingEnabled = true;
            this.SizesComboBox.Items.AddRange(new object[] {
            "1280 x 720",
            "1920 x 1080",
            "2560 x 1200",
            "3840 x 2160",
            "7680 x 4320"});
            this.SizesComboBox.Location = new System.Drawing.Point(96, 19);
            this.SizesComboBox.Name = "SizesComboBox";
            this.SizesComboBox.Size = new System.Drawing.Size(121, 21);
            this.SizesComboBox.TabIndex = 70;
            // 
            // SizeLabel
            // 
            this.SizeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SizeLabel.AutoSize = true;
            this.SizeLabel.Location = new System.Drawing.Point(12, 22);
            this.SizeLabel.Name = "SizeLabel";
            this.SizeLabel.Size = new System.Drawing.Size(27, 13);
            this.SizeLabel.TabIndex = 71;
            this.SizeLabel.Text = "Size";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.ColorsTabControl);
            this.groupBox3.Location = new System.Drawing.Point(875, 228);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(295, 330);
            this.groupBox3.TabIndex = 19;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Colours and Options";
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.SizeLabel);
            this.groupBox5.Controls.Add(this.OutputPathTextbox);
            this.groupBox5.Controls.Add(this.EditOutputPathButton);
            this.groupBox5.Controls.Add(this.SizesComboBox);
            this.groupBox5.Controls.Add(this.OutputPathLabel);
            this.groupBox5.Controls.Add(this.PNGRadioButton);
            this.groupBox5.Controls.Add(this.OutputFormatLabel);
            this.groupBox5.Controls.Add(this.JPEGRadioButton);
            this.groupBox5.Location = new System.Drawing.Point(875, 564);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(295, 95);
            this.groupBox5.TabIndex = 20;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Output";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 733);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.ResetZoomButton);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.ZoomTrackBar);
            this.Controls.Add(this.AppearanceGroupBox);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(750, 500);
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "SC4Cartographer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResizeBegin += new System.EventHandler(this.MainForm_ResizeBegin);
            this.ResizeEnd += new System.EventHandler(this.MainForm_ResizeEnd);
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
            ((System.ComponentModel.ISupportInitialize)(this.GridSegmentSizeNumericUpDown)).EndInit();
            this.ColorsTabControl.ResumeLayout(false);
            this.GridTabPage.ResumeLayout(false);
            this.GridTabPage.PerformLayout();
            this.ZonesTabPage.ResumeLayout(false);
            this.ZonesTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SegmentPaddingNumericUpDown)).EndInit();
            this.TransportTabPage.ResumeLayout(false);
            this.TransportTabPage.PerformLayout();
            this.TerrainTabPage.ResumeLayout(false);
            this.TerrainTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TerrainLayer23NumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TerrainLayer22NumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TerrainLayer21NumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TerrainLayer20NumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TerrainLayer19NumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TerrainLayer18NumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TerrainLayer17NumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TerrainLayer16NumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TerrainLayer15NumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TerrainLayer14NumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TerrainLayer13NumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TerrainLayer12NumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TerrainLayer11NumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TerrainLayer10NumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TerrainLayer9NumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TerrainLayer8NumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TerrainLayer7NumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TerrainLayer6NumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TerrainLayer5NumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TerrainLayer4NumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TerrainLayer3NumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TerrainLayer2NumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TerrainLayer1NumericUpDown)).EndInit();
            this.BuildingTabPage.ResumeLayout(false);
            this.BuildingTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ZoomTrackBar)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
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
        private System.Windows.Forms.Label OpenTextLabel;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem UpdatesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel MapSizeToolStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel MousePositionToolStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel MemoryUsedToolStripStatusLabel;
        private System.Windows.Forms.GroupBox AppearanceGroupBox;
        private System.Windows.Forms.TreeView VisibleObjectsTreeView;
        private System.Windows.Forms.TabControl ColorsTabControl;
        private System.Windows.Forms.TabPage ZonesTabPage;
        private System.Windows.Forms.TabPage TerrainTabPage;
        private System.Windows.Forms.TabPage TransportTabPage;
        private System.Windows.Forms.Button TerrainLayer1Button;
        private System.Windows.Forms.TextBox TerrainLayer1ColorTextBox;
        private System.Windows.Forms.NumericUpDown TerrainLayer1NumericUpDown;
        private System.Windows.Forms.Button EditOutputPathButton;
        private System.Windows.Forms.Label PixelLabel2;
        private System.Windows.Forms.TextBox OutputPathTextbox;
        private System.Windows.Forms.Label OutputPathLabel;
        private System.Windows.Forms.Label PixelLabel1;
        private System.Windows.Forms.CheckBox ShowZoneOutlinesCheckbox;
        private System.Windows.Forms.NumericUpDown GridSegmentSizeNumericUpDown;
        private System.Windows.Forms.Label SegmentPaddingLabel;
        private System.Windows.Forms.Label GridSegmentSizeLabel;
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
        private System.Windows.Forms.Button PloppedBuildingsEditButton;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox PloppedBuildingsTextbox;
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
        private System.Windows.Forms.Button SubwayEditButton;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.TextBox SubwayTextBox;
        private System.Windows.Forms.Button RailwayEditButton;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.TextBox RailwayTextBox;
        private System.Windows.Forms.Button AvenueEditButton;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.TextBox AvenueTextBox;
        private System.Windows.Forms.Button OneWayRoadEditButton;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.TextBox OneWayRoadTextBox;
        private System.Windows.Forms.Button RoadEditButton;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.TextBox RoadTextBox;
        private System.Windows.Forms.Button StreetEditButton;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.TextBox StreetTextBox;
        private System.Windows.Forms.RadioButton JPEGRadioButton;
        private System.Windows.Forms.RadioButton PNGRadioButton;
        private System.Windows.Forms.Label OutputFormatLabel;
        private System.Windows.Forms.CheckBox TerrainLayer1CheckBox;
        private System.Windows.Forms.TextBox TerrainLayer1AliasTextBox;
        private System.Windows.Forms.CheckBox TerrainLayer23CheckBox;
        private System.Windows.Forms.TextBox TerrainLayer23AliasTextBox;
        private System.Windows.Forms.Button TerrainLayer23Button;
        private System.Windows.Forms.TextBox TerrainLayer23ColorTextBox;
        private System.Windows.Forms.NumericUpDown TerrainLayer23NumericUpDown;
        private System.Windows.Forms.CheckBox TerrainLayer22CheckBox;
        private System.Windows.Forms.TextBox TerrainLayer22AliasTextBox;
        private System.Windows.Forms.Button TerrainLayer22Button;
        private System.Windows.Forms.TextBox TerrainLayer22ColorTextBox;
        private System.Windows.Forms.NumericUpDown TerrainLayer22NumericUpDown;
        private System.Windows.Forms.CheckBox TerrainLayer21CheckBox;
        private System.Windows.Forms.TextBox TerrainLayer21AliasTextBox;
        private System.Windows.Forms.Button TerrainLayer21Button;
        private System.Windows.Forms.TextBox TerrainLayer21ColorTextBox;
        private System.Windows.Forms.NumericUpDown TerrainLayer21NumericUpDown;
        private System.Windows.Forms.CheckBox TerrainLayer20CheckBox;
        private System.Windows.Forms.TextBox TerrainLayer20AliasTextBox;
        private System.Windows.Forms.Button TerrainLayer20Button;
        private System.Windows.Forms.TextBox TerrainLayer20ColorTextBox;
        private System.Windows.Forms.NumericUpDown TerrainLayer20NumericUpDown;
        private System.Windows.Forms.CheckBox TerrainLayer19CheckBox;
        private System.Windows.Forms.TextBox TerrainLayer19AliasTextBox;
        private System.Windows.Forms.Button TerrainLayer19Button;
        private System.Windows.Forms.TextBox TerrainLayer19ColorTextBox;
        private System.Windows.Forms.NumericUpDown TerrainLayer19NumericUpDown;
        private System.Windows.Forms.CheckBox TerrainLayer18CheckBox;
        private System.Windows.Forms.TextBox TerrainLayer18AliasTextBox;
        private System.Windows.Forms.Button TerrainLayer18Button;
        private System.Windows.Forms.TextBox TerrainLayer18ColorTextBox;
        private System.Windows.Forms.NumericUpDown TerrainLayer18NumericUpDown;
        private System.Windows.Forms.CheckBox TerrainLayer17CheckBox;
        private System.Windows.Forms.TextBox TerrainLayer17AliasTextBox;
        private System.Windows.Forms.Button TerrainLayer17Button;
        private System.Windows.Forms.TextBox TerrainLayer17ColorTextBox;
        private System.Windows.Forms.NumericUpDown TerrainLayer17NumericUpDown;
        private System.Windows.Forms.CheckBox TerrainLayer16CheckBox;
        private System.Windows.Forms.TextBox TerrainLayer16AliasTextBox;
        private System.Windows.Forms.Button TerrainLayer16Button;
        private System.Windows.Forms.TextBox TerrainLayer16ColorTextBox;
        private System.Windows.Forms.NumericUpDown TerrainLayer16NumericUpDown;
        private System.Windows.Forms.CheckBox TerrainLayer15CheckBox;
        private System.Windows.Forms.TextBox TerrainLayer15AliasTextBox;
        private System.Windows.Forms.Button TerrainLayer15Button;
        private System.Windows.Forms.TextBox TerrainLayer15ColorTextBox;
        private System.Windows.Forms.NumericUpDown TerrainLayer15NumericUpDown;
        private System.Windows.Forms.CheckBox TerrainLayer14CheckBox;
        private System.Windows.Forms.TextBox TerrainLayer14AliasTextBox;
        private System.Windows.Forms.Button TerrainLayer14Button;
        private System.Windows.Forms.TextBox TerrainLayer14ColorTextBox;
        private System.Windows.Forms.NumericUpDown TerrainLayer14NumericUpDown;
        private System.Windows.Forms.CheckBox TerrainLayer13CheckBox;
        private System.Windows.Forms.TextBox TerrainLayer13AliasTextBox;
        private System.Windows.Forms.Button TerrainLayer13Button;
        private System.Windows.Forms.TextBox TerrainLayer13ColorTextBox;
        private System.Windows.Forms.NumericUpDown TerrainLayer13NumericUpDown;
        private System.Windows.Forms.CheckBox TerrainLayer12CheckBox;
        private System.Windows.Forms.TextBox TerrainLayer12AliasTextBox;
        private System.Windows.Forms.Button TerrainLayer12Button;
        private System.Windows.Forms.TextBox TerrainLayer12ColorTextBox;
        private System.Windows.Forms.NumericUpDown TerrainLayer12NumericUpDown;
        private System.Windows.Forms.CheckBox TerrainLayer11CheckBox;
        private System.Windows.Forms.TextBox TerrainLayer11AliasTextBox;
        private System.Windows.Forms.Button TerrainLayer11Button;
        private System.Windows.Forms.TextBox TerrainLayer11ColorTextBox;
        private System.Windows.Forms.NumericUpDown TerrainLayer11NumericUpDown;
        private System.Windows.Forms.CheckBox TerrainLayer10CheckBox;
        private System.Windows.Forms.TextBox TerrainLayer10AliasTextBox;
        private System.Windows.Forms.Button TerrainLayer10Button;
        private System.Windows.Forms.TextBox TerrainLayer10ColorTextBox;
        private System.Windows.Forms.NumericUpDown TerrainLayer10NumericUpDown;
        private System.Windows.Forms.CheckBox TerrainLayer9CheckBox;
        private System.Windows.Forms.TextBox TerrainLayer9AliasTextBox;
        private System.Windows.Forms.Button TerrainLayer9Button;
        private System.Windows.Forms.TextBox TerrainLayer9ColorTextBox;
        private System.Windows.Forms.NumericUpDown TerrainLayer9NumericUpDown;
        private System.Windows.Forms.CheckBox TerrainLayer8CheckBox;
        private System.Windows.Forms.TextBox TerrainLayer8AliasTextBox;
        private System.Windows.Forms.Button TerrainLayer8Button;
        private System.Windows.Forms.TextBox TerrainLayer8ColorTextBox;
        private System.Windows.Forms.NumericUpDown TerrainLayer8NumericUpDown;
        private System.Windows.Forms.CheckBox TerrainLayer7CheckBox;
        private System.Windows.Forms.TextBox TerrainLayer7AliasTextBox;
        private System.Windows.Forms.Button TerrainLayer7Button;
        private System.Windows.Forms.TextBox TerrainLayer7ColorTextBox;
        private System.Windows.Forms.NumericUpDown TerrainLayer7NumericUpDown;
        private System.Windows.Forms.CheckBox TerrainLayer6CheckBox;
        private System.Windows.Forms.TextBox TerrainLayer6AliasTextBox;
        private System.Windows.Forms.Button TerrainLayer6Button;
        private System.Windows.Forms.TextBox TerrainLayer6ColorTextBox;
        private System.Windows.Forms.NumericUpDown TerrainLayer6NumericUpDown;
        private System.Windows.Forms.CheckBox TerrainLayer5CheckBox;
        private System.Windows.Forms.TextBox TerrainLayer5AliasTextBox;
        private System.Windows.Forms.Button TerrainLayer5Button;
        private System.Windows.Forms.TextBox TerrainLayer5ColorTextBox;
        private System.Windows.Forms.NumericUpDown TerrainLayer5NumericUpDown;
        private System.Windows.Forms.CheckBox TerrainLayer4CheckBox;
        private System.Windows.Forms.TextBox TerrainLayer4AliasTextBox;
        private System.Windows.Forms.Button TerrainLayer4Button;
        private System.Windows.Forms.TextBox TerrainLayer4ColorTextBox;
        private System.Windows.Forms.NumericUpDown TerrainLayer4NumericUpDown;
        private System.Windows.Forms.CheckBox TerrainLayer3CheckBox;
        private System.Windows.Forms.TextBox TerrainLayer3AliasTextBox;
        private System.Windows.Forms.Button TerrainLayer3Button;
        private System.Windows.Forms.TextBox TerrainLayer3ColorTextBox;
        private System.Windows.Forms.NumericUpDown TerrainLayer3NumericUpDown;
        private System.Windows.Forms.CheckBox TerrainLayer2CheckBox;
        private System.Windows.Forms.TextBox TerrainLayer2AliasTextBox;
        private System.Windows.Forms.Button TerrainLayer2Button;
        private System.Windows.Forms.TextBox TerrainLayer2ColorTextBox;
        private System.Windows.Forms.NumericUpDown TerrainLayer2NumericUpDown;
        private System.Windows.Forms.CheckBox BlendTerrainColorsCheckBox;
        private System.Windows.Forms.TrackBar ZoomTrackBar;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button ResetZoomButton;
        private System.Windows.Forms.ToolStripMenuItem appearanceStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem restoreDefaultsToolStripMenuItem;
        private System.Windows.Forms.ComboBox SizesComboBox;
        private System.Windows.Forms.TabPage GridTabPage;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button GridLinesEditTextbox;
        private System.Windows.Forms.Button GridBackgroundEditButton;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox GridLinesTextbox;
        private System.Windows.Forms.TextBox GridBackgroundTextbox;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.TabPage BuildingTabPage;
        private System.Windows.Forms.CheckBox ShowBuildingOutlinesCheckBox;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Button BuildingsEditButton;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox BuildingsTextBox;
        private System.Windows.Forms.NumericUpDown SegmentPaddingNumericUpDown;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button BuildingsOutlineEditButton;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox BuildingsOutlineTextBox;
        private System.Windows.Forms.Label SizeLabel;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox5;
    }
}

