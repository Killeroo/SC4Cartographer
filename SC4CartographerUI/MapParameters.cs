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
        Building,
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
        public string SaveFilePath;

        #region Ouput

        public string OutputPath;
        public int OutputDPI = 300;
        public OutFormat OutputFormat = OutFormat.PNG;

        #endregion

        #region Dimensions 

        public bool ShowGridLines = false;
        public int GridSegmentSize = 10;
        public int SegmentPaddingX = 4;
        public int SegmentPaddingY = 4;
        public int SegmentOffsetX = 2;
        public int SegmentOffsetY = 2;
        public int GridSizeX = 128;
        public int GridSizeY = 128;

        #endregion

        #region Colors

        public Dictionary<MapColorObject, Color> ColorDictionary = new Dictionary<MapColorObject, Color>()
        {
            {MapColorObject.Background, Color.FromArgb(64, 64, 64)},
            {MapColorObject.GridLines, Color.FromArgb(73, 73, 73)},
            {MapColorObject.Building, Color.FromArgb(121, 121, 121)},
            {MapColorObject.ResidentialHigh, Color.FromArgb(0, 126, 47)},
            {MapColorObject.ResidentialMid, Color.FromArgb(2, 207, 79)},
            {MapColorObject.ResidentialLow, Color.FromArgb(4, 255, 98)},
            {MapColorObject.CommercialHigh, Color.FromArgb(4, 1, 128)},
            {MapColorObject.CommercialMid, Color.FromArgb(1, 93, 188)},
            {MapColorObject.CommercialLow, Color.FromArgb(0, 126, 255)},
            {MapColorObject.IndustrialHigh, Color.FromArgb(103, 103, 22)},
            {MapColorObject.IndustrialMid, Color.FromArgb(129, 129, 43)},
            {MapColorObject.IndustrialLow, Color.FromArgb(180, 180, 46)},
        };

        #endregion

    }
}
