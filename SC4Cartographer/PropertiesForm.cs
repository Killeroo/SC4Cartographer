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
        private MapCreationParameters parameters = new MapCreationParameters();
        private MainForm parentForm;

        public PropertiesForm(MapCreationParameters p, MainForm main)
        {
            InitializeComponent();

            parameters = p;
            parentForm = main;
            SetUIValuesUsingParameters();
        }

        private void SetUIValuesUsingParameters()
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
        private void GetParametersFromUIValues()
        {
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
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            GetParametersFromUIValues();
            parentForm.SetMapCreationParameters(parameters);
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
    }
}
