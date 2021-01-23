using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;

namespace SC4CartographerUI
{
    public partial class PropertiesForm : Form
    {
        private MapCreationParameters originalParameters = new MapCreationParameters();
        private MainForm parentForm;
        private bool confirmedChanged = false;

        public PropertiesForm(MapCreationParameters p, MainForm main)
        {
            InitializeComponent();

            SetUIValuesUsingParameters(p);

            // Register UI events _after_ setting up the ui values to avoid firing off a load of callbacks
            RegisterEvents();

            // Save original parameters to revert to
            originalParameters = new MapCreationParameters(p);

            // Save form to send parameters to
            parentForm = main;

        }

        private void SetUIValuesUsingParameters(MapCreationParameters parameters)
        {
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

            GridSegmentSizeNumericUpDown.Value = parameters.GridSegmentSize;
            SegmentPaddingNumericUpDown.Value = parameters.SegmentPaddingX;
            SegmentOffsetNumericUpDown.Value = parameters.SegmentOffsetX;
            ShowGridLinesCheckbox.Checked = parameters.ShowGridLines;
            ShowZoneOutlinesCheckbox.Checked = parameters.ShowZoneOutlines;

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

            VisibleObjectsTreeView.AfterCheck -= VisibleObjectsTreeView_AfterCheck;
            PopulateLayersTreeView(VisibleObjectsTreeView.Nodes, parameters.VisibleMapObjects);
            VisibleObjectsTreeView.ExpandAll();
            VisibleObjectsTreeView.AfterCheck += VisibleObjectsTreeView_AfterCheck;

        }
        private MapCreationParameters GetParametersFromUIValues()
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
            
            parameters.GridSegmentSize = (int) GridSegmentSizeNumericUpDown.Value;
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

        #region UI Event Callbacks

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            MapCreationParameters p = GetParametersFromUIValues();
            parentForm.SetAndUpdateMapCreationParameters(p);

            // This makes sure that we don't reverse the changes when the form closes
            confirmedChanged = true;

            Close();
        }

        private void PropertiesForm_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

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

                parentForm.SetAndUpdateMapCreationParameters(GetParametersFromUIValues());
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

                parentForm.SetAndUpdateMapCreationParameters(GetParametersFromUIValues());
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

                parentForm.SetAndUpdateMapCreationParameters(GetParametersFromUIValues());
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

                parentForm.SetAndUpdateMapCreationParameters(GetParametersFromUIValues());
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

                parentForm.SetAndUpdateMapCreationParameters(GetParametersFromUIValues());
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

                parentForm.SetAndUpdateMapCreationParameters(GetParametersFromUIValues());
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

                parentForm.SetAndUpdateMapCreationParameters(GetParametersFromUIValues());
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

                parentForm.SetAndUpdateMapCreationParameters(GetParametersFromUIValues());
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

                parentForm.SetAndUpdateMapCreationParameters(GetParametersFromUIValues());
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

                parentForm.SetAndUpdateMapCreationParameters(GetParametersFromUIValues());
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

                parentForm.SetAndUpdateMapCreationParameters(GetParametersFromUIValues());
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

                parentForm.SetAndUpdateMapCreationParameters(GetParametersFromUIValues());
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

                parentForm.SetAndUpdateMapCreationParameters(GetParametersFromUIValues());
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

                parentForm.SetAndUpdateMapCreationParameters(GetParametersFromUIValues());
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

                parentForm.SetAndUpdateMapCreationParameters(GetParametersFromUIValues());
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

                parentForm.SetAndUpdateMapCreationParameters(GetParametersFromUIValues());
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

                parentForm.SetAndUpdateMapCreationParameters(GetParametersFromUIValues());
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
            MapCreationParameters currentParameters = GetParametersFromUIValues();
            MapCreationParameters pristineParameters = new MapCreationParameters();

            // Copy over the output path
            pristineParameters.OutputPath = currentParameters.OutputPath;
            
            SetUIValuesUsingParameters(pristineParameters);
            parentForm.SetAndUpdateMapCreationParameters(pristineParameters);
        }
        private void GridSegmentSizeNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            parentForm.SetAndUpdateMapCreationParameters(GetParametersFromUIValues());
        }

        private void SegmentPaddingNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            parentForm.SetAndUpdateMapCreationParameters(GetParametersFromUIValues());
        }

        private void SegmentOffsetNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            parentForm.SetAndUpdateMapCreationParameters(GetParametersFromUIValues());
        }

        private void ShowGridLinesCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            parentForm.SetAndUpdateMapCreationParameters(GetParametersFromUIValues());
        }

        private void ShowZoneOutlinesCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            parentForm.SetAndUpdateMapCreationParameters(GetParametersFromUIValues());
        }

        private void PropertiesForm_OnFormClosing(object sender, FormClosingEventArgs e)
        {
            // If the changes haven't been confirmed (using the OK button) then revert them to what they originally were
            if (confirmedChanged == false)
            {
                parentForm.SetAndUpdateMapCreationParameters(originalParameters);
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            parentForm.SaveMapParametersWithDialog();
        }

        private void LoadButton_Click(object sender, EventArgs e)
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
                    try
                    {
                        MapCreationParameters loadedParameters = new MapCreationParameters();
                        MapCreationParameters currentParameters = GetParametersFromUIValues();

                        loadedParameters.LoadFromFile(fileDialog.FileName);
                        
                        // Copy over the output path
                        loadedParameters.OutputPath = currentParameters.OutputPath;

                        // Set loaded parameters up on the form
                        SetUIValuesUsingParameters(loadedParameters);
                    }
                    catch (Exception ex)
                    {
                        ErrorForm form = new ErrorForm(
                            "Could not load map properties",
                            $"An error occured while trying to load map properties from file ({fileDialog.FileName})",
                            ex,
                            false);

                        form.StartPosition = FormStartPosition.CenterParent;
                        form.ShowDialog();

                        return;
                    }
                }
            }
        }

        #endregion

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

            parentForm.SetAndUpdateMapCreationParameters(GetParametersFromUIValues());
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
    }
}
