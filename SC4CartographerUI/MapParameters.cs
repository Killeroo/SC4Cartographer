using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

using SC4Parser.DataStructures;
using SC4Parser.Files;
using System.Windows.Forms.VisualStyles;

namespace SC4CartographerUI
{
    public enum MapColorObject
    {
        Background,
        GridLines,
        ZoneOutline,
        PloppedBuilding,
        Military,
        Airport,
        Seaport,
        Spaceport,
        ResidentialHigh,
        ResidentialMid,
        ResidentialLow,
        CommercialHigh,
        CommercialMid,
        CommercialLow,
        IndustrialHigh,
        IndustrialMid,
        IndustrialLow
    }

    public enum OutFormat
    {
        PNG,
        JPEG,
    }

    /// <summary>
    /// Stores parameters required to create a map
    /// </summary>
    public class MapCreationParameters
    {
        public SC4SaveFile SaveFile;

        #region Ouput

        public string OutputPath;
        public int OutputDPI = 300;
        public OutFormat OutputFormat = OutFormat.PNG;

        #endregion

        #region Dimensions/Grid properties

        public bool ShowGridLines = false;
        public bool ShowZoneOutlines = false;
        public int GridSegmentSize = 10;
        public int SegmentPaddingX = 4;
        public int SegmentPaddingY = 4;
        public int SegmentOffsetX = 2;
        public int SegmentOffsetY = 2;
        public int GridSizeX = 256;//128;
        public int GridSizeY = 256;//128;

        #endregion

        #region Colors

        public Dictionary<MapColorObject, Color> ColorDictionary = new Dictionary<MapColorObject, Color>()
        {
            {MapColorObject.Background, Color.FromArgb(64, 64, 64)},
            {MapColorObject.GridLines, Color.FromArgb(73, 73, 73)},
            {MapColorObject.ZoneOutline, Color.FromArgb(73, 73, 73)},
            {MapColorObject.PloppedBuilding, Color.FromArgb(121, 121, 121)},
            {MapColorObject.Military, Color.FromArgb(121, 121, 121)},
            {MapColorObject.Airport, Color.FromArgb(116, 116, 146)},
            {MapColorObject.Seaport, Color.FromArgb(116, 116, 146)},
            {MapColorObject.Spaceport, Color.FromArgb(116, 116, 146)},
            {MapColorObject.ResidentialHigh, Color.FromArgb(30, 145, 30)},
            {MapColorObject.ResidentialMid, Color.FromArgb(68, 204, 34)},
            {MapColorObject.ResidentialLow, Color.FromArgb(0, 255, 0)},
            {MapColorObject.CommercialHigh, Color.FromArgb(60, 66, 173)},
            {MapColorObject.CommercialMid, Color.FromArgb(61, 110, 184)},
            {MapColorObject.CommercialLow, Color.FromArgb(91, 129, 208)},
            {MapColorObject.IndustrialHigh, Color.FromArgb(188, 159, 55)},
            {MapColorObject.IndustrialMid, Color.FromArgb(198, 183, 51)},
            {MapColorObject.IndustrialLow, Color.FromArgb(208, 208, 48)},
        };

        #endregion

    }
}
