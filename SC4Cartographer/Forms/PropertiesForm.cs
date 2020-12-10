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
        private MapCreationParameters modifiedParameters = new MapCreationParameters();
        private MapCreationParameters originalParameters = new MapCreationParameters();
        private MainForm parentForm;


        public PropertiesForm(MapCreationParameters p, MainForm main)
        {
            InitializeComponent();

            modifiedParameters = p;
            originalParameters = new MapCreationParameters(p);
            parentForm = main;
            SetUIValuesUsingParameters();
        }

        private void SetUIValuesUsingParameters()
        {
            GridBackgroundTextbox.BackColor = modifiedParameters.ColorDictionary[MapColorObject.Background];
            GridLinesTextbox.BackColor = modifiedParameters.ColorDictionary[MapColorObject.GridLines];
            BuildingsTextbox.BackColor = modifiedParameters.ColorDictionary[MapColorObject.PloppedBuilding];
            ZoneOutlinesTextbox.BackColor = modifiedParameters.ColorDictionary[MapColorObject.ZoneOutline];
            MilitaryTextbox.BackColor = modifiedParameters.ColorDictionary[MapColorObject.Military];
            AirportsTextbox.BackColor = modifiedParameters.ColorDictionary[MapColorObject.Airport];
            SeaportTextbox.BackColor = modifiedParameters.ColorDictionary[MapColorObject.Seaport];
            SpaceportTextbox.BackColor = modifiedParameters.ColorDictionary[MapColorObject.Spaceport];
            ResidentialZoneLowTextbox.BackColor = modifiedParameters.ColorDictionary[MapColorObject.ResidentialLow];
            ResidentialZoneMidTextbox.BackColor = modifiedParameters.ColorDictionary[MapColorObject.ResidentialMid];
            ResidentialZoneHighTextbox.BackColor = modifiedParameters.ColorDictionary[MapColorObject.ResidentialHigh];
            CommercialZoneLowTextbox.BackColor = modifiedParameters.ColorDictionary[MapColorObject.CommercialLow];
            CommercialZoneMidTextbox.BackColor = modifiedParameters.ColorDictionary[MapColorObject.CommercialMid];
            CommercialZoneHighTextbox.BackColor = modifiedParameters.ColorDictionary[MapColorObject.CommercialHigh];
            IndustrialZoneLowTextbox.BackColor = modifiedParameters.ColorDictionary[MapColorObject.IndustrialLow];
            IndustrialZoneMidTextbox.BackColor = modifiedParameters.ColorDictionary[MapColorObject.IndustrialMid];
            IndustrialZoneHighTextbox.BackColor = modifiedParameters.ColorDictionary[MapColorObject.IndustrialHigh];

            GridSegmentSizeNumericUpDown.Value = modifiedParameters.GridSegmentSize;
            SegmentPaddingNumericUpDown.Value = modifiedParameters.SegmentPaddingX;
            SegmentOffsetNumericUpDown.Value = modifiedParameters.SegmentOffsetX;
            ShowGridLinesCheckbox.Checked = modifiedParameters.ShowGridLines;
            ShowZoneOutlinesCheckbox.Checked = modifiedParameters.ShowZoneOutlines;

            OutputPathTextbox.Text = modifiedParameters.OutputPath;
            if (modifiedParameters.OutputFormat == OutFormat.PNG)
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
        private void GetParametersFromUIValues()
        {
            modifiedParameters.ColorDictionary[MapColorObject.Background] = GridBackgroundTextbox.BackColor;
            modifiedParameters.ColorDictionary[MapColorObject.GridLines] = GridLinesTextbox.BackColor;
            modifiedParameters.ColorDictionary[MapColorObject.PloppedBuilding] = BuildingsTextbox.BackColor;
            modifiedParameters.ColorDictionary[MapColorObject.ZoneOutline] = ZoneOutlinesTextbox.BackColor;
            modifiedParameters.ColorDictionary[MapColorObject.Military] = MilitaryTextbox.BackColor;
            modifiedParameters.ColorDictionary[MapColorObject.Airport] = AirportsTextbox.BackColor;
            modifiedParameters.ColorDictionary[MapColorObject.Seaport] = SeaportTextbox.BackColor;
            modifiedParameters.ColorDictionary[MapColorObject.Spaceport] = SpaceportTextbox.BackColor;
            modifiedParameters.ColorDictionary[MapColorObject.ResidentialLow] = ResidentialZoneLowTextbox.BackColor;
            modifiedParameters.ColorDictionary[MapColorObject.ResidentialMid] = ResidentialZoneMidTextbox.BackColor;
            modifiedParameters.ColorDictionary[MapColorObject.ResidentialHigh] = ResidentialZoneHighTextbox.BackColor;
            modifiedParameters.ColorDictionary[MapColorObject.CommercialLow] = CommercialZoneLowTextbox.BackColor;
            modifiedParameters.ColorDictionary[MapColorObject.CommercialMid] = CommercialZoneMidTextbox.BackColor;
            modifiedParameters.ColorDictionary[MapColorObject.CommercialHigh] = CommercialZoneHighTextbox.BackColor;
            modifiedParameters.ColorDictionary[MapColorObject.IndustrialLow] = IndustrialZoneLowTextbox.BackColor;
            modifiedParameters.ColorDictionary[MapColorObject.IndustrialMid] = IndustrialZoneMidTextbox.BackColor;
            modifiedParameters.ColorDictionary[MapColorObject.IndustrialHigh] = IndustrialZoneHighTextbox.BackColor;

            modifiedParameters.GridSegmentSize = (int) GridSegmentSizeNumericUpDown.Value;
            modifiedParameters.SegmentPaddingX = (int)SegmentPaddingNumericUpDown.Value;
            modifiedParameters.SegmentPaddingY = (int)SegmentPaddingNumericUpDown.Value;
            modifiedParameters.SegmentOffsetX = (int)SegmentOffsetNumericUpDown.Value;
            modifiedParameters.SegmentOffsetY = (int)SegmentOffsetNumericUpDown.Value;
            modifiedParameters.ShowGridLines = ShowGridLinesCheckbox.Checked;
            modifiedParameters.ShowZoneOutlines = ShowZoneOutlinesCheckbox.Checked;

            modifiedParameters.OutputPath = OutputPathTextbox.Text;
            if (PNGRadioButton.Checked)
            {
                modifiedParameters.OutputFormat = OutFormat.PNG;
            }
            else
            {
                modifiedParameters.OutputFormat = OutFormat.JPEG;
            }
        }

        #region UI Event Callbacks

        private void CancelButton_Click(object sender, EventArgs e)
        {
            //modifiedParameters.ColorDictionary[MapColorObject.ResidentialHigh] = Color.Pink;
            modifiedParameters = originalParameters;
            parentForm.SetMapCreationParameters(originalParameters);
            Close();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            GetParametersFromUIValues();
            parentForm.SetMapCreationParameters(modifiedParameters);
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

                GetParametersFromUIValues();
                parentForm.SetMapCreationParameters(modifiedParameters);
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

            modifiedParameters.ColorDictionary[MapColorObject.Background] = pristineParameters.ColorDictionary[MapColorObject.Background];
            modifiedParameters.ColorDictionary[MapColorObject.GridLines] = pristineParameters.ColorDictionary[MapColorObject.GridLines];
            modifiedParameters.ColorDictionary[MapColorObject.PloppedBuilding] = pristineParameters.ColorDictionary[MapColorObject.PloppedBuilding];
            modifiedParameters.ColorDictionary[MapColorObject.ZoneOutline] = pristineParameters.ColorDictionary[MapColorObject.ZoneOutline];
            modifiedParameters.ColorDictionary[MapColorObject.Military] = pristineParameters.ColorDictionary[MapColorObject.Military];
            modifiedParameters.ColorDictionary[MapColorObject.Airport] = pristineParameters.ColorDictionary[MapColorObject.Airport];
            modifiedParameters.ColorDictionary[MapColorObject.Seaport] = pristineParameters.ColorDictionary[MapColorObject.Seaport];
            modifiedParameters.ColorDictionary[MapColorObject.Spaceport] = pristineParameters.ColorDictionary[MapColorObject.Spaceport];
            modifiedParameters.ColorDictionary[MapColorObject.ResidentialLow] = pristineParameters.ColorDictionary[MapColorObject.ResidentialLow];
            modifiedParameters.ColorDictionary[MapColorObject.ResidentialMid] = pristineParameters.ColorDictionary[MapColorObject.ResidentialMid];
            modifiedParameters.ColorDictionary[MapColorObject.ResidentialHigh] = pristineParameters.ColorDictionary[MapColorObject.ResidentialHigh];
            modifiedParameters.ColorDictionary[MapColorObject.CommercialLow] = pristineParameters.ColorDictionary[MapColorObject.CommercialLow];
            modifiedParameters.ColorDictionary[MapColorObject.CommercialMid] = pristineParameters.ColorDictionary[MapColorObject.CommercialMid];
            modifiedParameters.ColorDictionary[MapColorObject.CommercialHigh] = pristineParameters.ColorDictionary[MapColorObject.CommercialHigh];
            modifiedParameters.ColorDictionary[MapColorObject.IndustrialLow] = pristineParameters.ColorDictionary[MapColorObject.IndustrialLow];
            modifiedParameters.ColorDictionary[MapColorObject.IndustrialMid] = pristineParameters.ColorDictionary[MapColorObject.IndustrialMid];
            modifiedParameters.ColorDictionary[MapColorObject.IndustrialHigh] = pristineParameters.ColorDictionary[MapColorObject.IndustrialHigh];

            modifiedParameters.GridSegmentSize = pristineParameters.GridSegmentSize;
            modifiedParameters.SegmentPaddingX = pristineParameters.SegmentPaddingX;
            modifiedParameters.SegmentPaddingY = pristineParameters.SegmentPaddingY;
            modifiedParameters.SegmentOffsetX = pristineParameters.SegmentOffsetX;
            modifiedParameters.SegmentOffsetY = pristineParameters.SegmentOffsetY;
            modifiedParameters.ShowGridLines = pristineParameters.ShowGridLines;
            modifiedParameters.ShowZoneOutlines = pristineParameters.ShowZoneOutlines;

            SetUIValuesUsingParameters();
        }

        #endregion

    }
}
