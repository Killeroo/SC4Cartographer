using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

            return parameters;
        }

        #region UI Event Callbacks

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            MapCreationParameters p = GetParametersFromUIValues();
            parentForm.SetMapCreationParameters(p);

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

                // Refresh map on main form
                parentForm.SetMapCreationParameters(GetParametersFromUIValues());
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

                // Refresh map on main form
                parentForm.SetMapCreationParameters(GetParametersFromUIValues());
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

                // Refresh map on main form
                parentForm.SetMapCreationParameters(GetParametersFromUIValues());
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

                // Refresh map on main form
                parentForm.SetMapCreationParameters(GetParametersFromUIValues());
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

                // Refresh map on main form
                parentForm.SetMapCreationParameters(GetParametersFromUIValues());
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

                // Refresh map on main form
                parentForm.SetMapCreationParameters(GetParametersFromUIValues());
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

                // Refresh map on main form
                parentForm.SetMapCreationParameters(GetParametersFromUIValues());
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

                // Refresh map on main form
                parentForm.SetMapCreationParameters(GetParametersFromUIValues());
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

                // Refresh map on main form
                parentForm.SetMapCreationParameters(GetParametersFromUIValues());
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

                // Refresh map on main form
                parentForm.SetMapCreationParameters(GetParametersFromUIValues());
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

                // Refresh map on main form
                parentForm.SetMapCreationParameters(GetParametersFromUIValues());
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

                // Refresh map on main form
                parentForm.SetMapCreationParameters(GetParametersFromUIValues());
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

                // Refresh map on main form
                parentForm.SetMapCreationParameters(GetParametersFromUIValues());
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

                // Refresh map on main form
                parentForm.SetMapCreationParameters(GetParametersFromUIValues());
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

                // Refresh map on main form
                parentForm.SetMapCreationParameters(GetParametersFromUIValues());
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

                // Refresh map on main form
                parentForm.SetMapCreationParameters(GetParametersFromUIValues());
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

                // Refresh map on main form
                parentForm.SetMapCreationParameters(GetParametersFromUIValues());
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
            parentForm.SetMapCreationParameters(pristineParameters);
        }
        private void GridSegmentSizeNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            // Refresh map on main form
            parentForm.SetMapCreationParameters(GetParametersFromUIValues());
        }

        private void SegmentPaddingNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            parentForm.SetMapCreationParameters(GetParametersFromUIValues());
        }

        private void SegmentOffsetNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            parentForm.SetMapCreationParameters(GetParametersFromUIValues());
        }

        private void ShowGridLinesCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (ShowGridLinesCheckbox.Checked)
                parentForm.SetMapCreationParameters(GetParametersFromUIValues());
        }

        private void ShowZoneOutlinesCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (ShowZoneOutlinesCheckbox.Checked)
                parentForm.SetMapCreationParameters(GetParametersFromUIValues());
        }

        private void PropertiesForm_OnFormClosing(object sender, FormClosingEventArgs e)
        {
            // If the changes haven't been confirmed (using the OK button) then revert them to what they originally were
            if (confirmedChanged == false)
            {
                parentForm.SetMapCreationParameters(originalParameters);
            }
        }

        #endregion

    }
}
