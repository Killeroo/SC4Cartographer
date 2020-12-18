using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;

using System.Drawing;

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
        public MapCreationParameters() { }
        public MapCreationParameters(MapCreationParameters parameters)
        {
            OutputPath = parameters.OutputPath;
            OutputFormat = parameters.OutputFormat;
            ShowGridLines = parameters.ShowGridLines;
            ShowZoneOutlines = parameters.ShowZoneOutlines;
            SegmentPaddingX = parameters.SegmentPaddingX;
            SegmentPaddingY = parameters.SegmentPaddingY;
            SegmentOffsetX = parameters.SegmentOffsetX;
            SegmentOffsetY = parameters.SegmentOffsetY;
            GridSegmentSize = parameters.GridSegmentSize;
            ColorDictionary = parameters.ColorDictionary;
        }

        #region Ouput

        public string OutputPath;
        public OutFormat OutputFormat = OutFormat.PNG;

        #endregion

        #region Dimensions/Grid properties

        public bool ShowGridLines = false;
        public bool ShowZoneOutlines = false;
        public int GridSegmentSize = 5;//10;
        public int SegmentPaddingX = 2;//4;
        public int SegmentPaddingY = 2;//4;
        public int SegmentOffsetX = 1;//2;
        public int SegmentOffsetY = 1;//2;

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

        public void SaveToFile(string path)
        {
            List<string> properties = new List<string>();

            // Get the properties as a list of strings
            properties.Add("Version:1;");
            properties.Add($"ShowGridLines:{(ShowGridLines ? "true" : "false")};");
            properties.Add($"ShowZoneOutlines:{(ShowZoneOutlines ? "true" : "false")};");
            properties.Add($"GridSegmentSize:{GridSegmentSize};");
            properties.Add($"SegmentPaddingX:{SegmentPaddingX};");
            properties.Add($"SegmentPaddingY:{SegmentPaddingY};");
            properties.Add($"SegmentOffsetX:{SegmentOffsetX};");
            properties.Add($"SegmentOffsetY:{SegmentOffsetY};");
            properties.Add($"Color@Background:{ColorDictionary[MapColorObject.Background].R},{ColorDictionary[MapColorObject.Background].G},{ColorDictionary[MapColorObject.Background].B};");
            properties.Add($"Color@GridLines:{ColorDictionary[MapColorObject.GridLines].R},{ColorDictionary[MapColorObject.GridLines].G},{ColorDictionary[MapColorObject.GridLines].B};");
            properties.Add($"Color@ZoneOutline:{ColorDictionary[MapColorObject.ZoneOutline].R},{ColorDictionary[MapColorObject.ZoneOutline].G},{ColorDictionary[MapColorObject.ZoneOutline].B};");
            properties.Add($"Color@PloppedBuilding:{ColorDictionary[MapColorObject.PloppedBuilding].R},{ColorDictionary[MapColorObject.PloppedBuilding].G},{ColorDictionary[MapColorObject.PloppedBuilding].B};");
            properties.Add($"Color@Military:{ColorDictionary[MapColorObject.Military].R},{ColorDictionary[MapColorObject.Military].G},{ColorDictionary[MapColorObject.Military].B};");
            properties.Add($"Color@Airport:{ColorDictionary[MapColorObject.Airport].R},{ColorDictionary[MapColorObject.Airport].G},{ColorDictionary[MapColorObject.Airport].B};");
            properties.Add($"Color@Seaport:{ColorDictionary[MapColorObject.Seaport].R},{ColorDictionary[MapColorObject.Seaport].G},{ColorDictionary[MapColorObject.Seaport].B};");
            properties.Add($"Color@Spaceport:{ColorDictionary[MapColorObject.Spaceport].R},{ColorDictionary[MapColorObject.Spaceport].G},{ColorDictionary[MapColorObject.Spaceport].B};");
            properties.Add($"Color@ResidentialHigh:{ColorDictionary[MapColorObject.ResidentialHigh].R},{ColorDictionary[MapColorObject.ResidentialHigh].G},{ColorDictionary[MapColorObject.ResidentialHigh].B};");
            properties.Add($"Color@ResidentialMid:{ColorDictionary[MapColorObject.ResidentialMid].R},{ColorDictionary[MapColorObject.ResidentialMid].G},{ColorDictionary[MapColorObject.ResidentialMid].B};");
            properties.Add($"Color@ResidentialLow:{ColorDictionary[MapColorObject.ResidentialLow].R},{ColorDictionary[MapColorObject.ResidentialLow].G},{ColorDictionary[MapColorObject.ResidentialLow].B};");
            properties.Add($"Color@CommercialHigh:{ColorDictionary[MapColorObject.CommercialHigh].R},{ColorDictionary[MapColorObject.CommercialHigh].G},{ColorDictionary[MapColorObject.CommercialHigh].B};");
            properties.Add($"Color@CommercialMid:{ColorDictionary[MapColorObject.CommercialMid].R},{ColorDictionary[MapColorObject.CommercialMid].G},{ColorDictionary[MapColorObject.CommercialMid].B};");
            properties.Add($"Color@CommercialLow:{ColorDictionary[MapColorObject.CommercialLow].R},{ColorDictionary[MapColorObject.CommercialLow].G},{ColorDictionary[MapColorObject.CommercialLow].B};");
            properties.Add($"Color@IndustrialHigh:{ColorDictionary[MapColorObject.IndustrialHigh].R},{ColorDictionary[MapColorObject.IndustrialHigh].G},{ColorDictionary[MapColorObject.IndustrialHigh].B};");
            properties.Add($"Color@IndustrialMid:{ColorDictionary[MapColorObject.IndustrialMid].R},{ColorDictionary[MapColorObject.IndustrialMid].G},{ColorDictionary[MapColorObject.IndustrialMid].B};");
            properties.Add($"Color@IndustrialLow:{ColorDictionary[MapColorObject.IndustrialLow].R},{ColorDictionary[MapColorObject.IndustrialLow].G},{ColorDictionary[MapColorObject.IndustrialLow].B};");

            // Write each properties to a line in a file
            using (StreamWriter writer = new StreamWriter(path))
            {
                foreach (string property in properties)
                {
                    writer.WriteLine(property);
                }
            }
        }

        public void LoadFromFile(string path)
        {
            MapCreationParameters mapCreationParameters = new MapCreationParameters(this);
            Dictionary<MapColorObject, Color> colors = ColorDictionary;

            Dictionary<string, string> properties = new Dictionary<string, string>();

            string line = "";
            using (StreamReader reader = new StreamReader(path))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    // Split the line via ':'
                    string[] lineData = line.Replace(";", "").Split(':');

                    string propertyKey = lineData.First().ToLower();
                    string propertyValue = lineData.Last().ToLower();

                    // Add line info to properties dictionary
                    // (first part is the property name, second part is property value)
                    properties.Add(propertyKey, propertyValue);
                }
            }
            

            if (properties["version"] == "")
            {
                // Could not find version
            }

            if (int.Parse(properties["version"]) > 1)
            {
                // too high a version
            }

            foreach (var property in properties)
            {
                if (property.Key.Contains("colors@"))
                {
                    string colorKey = property.Key.Split('@').Last();
                    string[] colorValues = property.Key.Split(',');
                    int r = int.Parse(colorValues[0]);
                    int g = int.Parse(colorValues[1]);
                    int b = int.Parse(colorValues[2]);
                    switch (colorKey)
                    {
                        case "Background":
                            colors[MapColorObject.Background] = Color.FromArgb(r, g, b);
                            break;
                        case "GridLines":
                            colors[MapColorObject.GridLines] = Color.FromArgb(r, g, b);
                            break;
                        case "ZoneOutline":
                            colors[MapColorObject.ZoneOutline] = Color.FromArgb(r, g, b);
                            break;
                        case "PloppedBuilding":
                            colors[MapColorObject.PloppedBuilding] = Color.FromArgb(r, g, b);
                            break;
                        case "Military":
                            colors[MapColorObject.Military] = Color.FromArgb(r, g, b);
                            break;
                        case "Airport":
                            colors[MapColorObject.Airport] = Color.FromArgb(r, g, b);
                            break;
                        case "Seaport":
                            colors[MapColorObject.Seaport] = Color.FromArgb(r, g, b);
                            break;
                        case "Spaceport":
                            colors[MapColorObject.Spaceport] = Color.FromArgb(r, g, b);
                            break;
                        case "ResidentialHigh":
                            colors[MapColorObject.ResidentialHigh] = Color.FromArgb(r, g, b);
                            break;
                        case "ResidentialMid":
                            colors[MapColorObject.ResidentialMid] = Color.FromArgb(r, g, b);
                            break;
                        case "ResidentialLow":
                            colors[MapColorObject.ResidentialLow] = Color.FromArgb(r, g, b);
                            break;
                        case "CommercialHigh":
                            colors[MapColorObject.CommercialHigh] = Color.FromArgb(r, g, b);
                            break;
                        case "CommercialMid":
                            colors[MapColorObject.CommercialMid] = Color.FromArgb(r, g, b);
                            break;
                        case "CommercialLow":
                            colors[MapColorObject.CommercialLow] = Color.FromArgb(r, g, b);
                            break;
                        case "IndustrialHigh":
                            colors[MapColorObject.IndustrialHigh] = Color.FromArgb(r, g, b);
                            break;
                        case "IndustrialMid":
                            colors[MapColorObject.IndustrialMid] = Color.FromArgb(r, g, b);
                            break;
                        case "IndustrialLow":
                            colors[MapColorObject.IndustrialLow] = Color.FromArgb(r, g, b);
                            break;
                    }
                }
                else
                {
                    switch (property.Key)
                    {
                        case "ShowGridLines":
                            if (property.Value == "true")
                                mapCreationParameters.ShowGridLines = true;
                            else
                                mapCreationParameters.ShowGridLines = false;
                            break;
                        case "ShowZoneOutlines":
                            if (property.Value == "true")
                                mapCreationParameters.ShowZoneOutlines = true;
                            else
                                mapCreationParameters.ShowZoneOutlines = false;
                            break;
                        case "GridSegmentSize":
                            mapCreationParameters.GridSegmentSize = int.Parse(property.Value);
                            break;
                        case "SegmentPaddingX":
                            mapCreationParameters.SegmentPaddingX = int.Parse(property.Value);
                            break;
                        case "SegmentPaddingY":
                            mapCreationParameters.SegmentPaddingY = int.Parse(property.Value);
                            break;
                        case "SegmentOffsetX":
                            mapCreationParameters.SegmentOffsetX = int.Parse(property.Value);
                            break;
                        case "SegmentOffsetY":
                            mapCreationParameters.SegmentOffsetY = int.Parse(property.Value);
                            break;
                    }
                }
            }

            this.ColorDictionary = colors;
            this.ShowGridLines = mapCreationParameters.ShowGridLines;
            this.ShowZoneOutlines = mapCreationParameters.ShowZoneOutlines;
            this.GridSegmentSize = mapCreationParameters.GridSegmentSize;
            this.SegmentPaddingX = mapCreationParameters.SegmentPaddingX;
            this.SegmentPaddingY = mapCreationParameters.SegmentPaddingY;
            this.SegmentOffsetX = mapCreationParameters.SegmentOffsetX;
            this.SegmentOffsetY = mapCreationParameters.SegmentOffsetY;
        }

    }
}
