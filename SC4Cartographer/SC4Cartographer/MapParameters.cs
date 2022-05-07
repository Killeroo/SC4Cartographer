using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;

using System.Drawing;

namespace SC4CartographerUI
{

    public enum MapObject
    {
        TerrainMap,
        GridLines,
        ZoneOutline,
        PloppedBuildingZone,
        MilitaryZone,
        AirportZone,
        SeaportZone,
        SpaceportZone,
        ResidentialHighZone,
        ResidentialMidZone,
        ResidentialLowZone,
        CommercialHighZone,
        CommercialMidZone,
        CommercialLowZone,
        IndustrialHighZone,
        IndustrialMidZone,
        IndustrialLowZone,  
        Building,
        StreetNetwork1,
        RoadNetwork1,
        OneWayRoadNetwork1,
        AvenueNetwork1,
        RailwayNetwork1,
        SubwayNetwork2
    }

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
        IndustrialLow,

        Buildings,
        BuildingsOutline,

        Street,
        Road,
        OneWayRoad,
        Avenue,
        Railway,
        Subway,

        TerrainLayer1,
        TerrainLayer2,
        TerrainLayer3,
        TerrainLayer4,
        TerrainLayer5,
        TerrainLayer6,
        TerrainLayer7,
        TerrainLayer8,
        TerrainLayer9,
        TerrainLayer10,
        TerrainLayer11,
        TerrainLayer12,
        TerrainLayer13,
        TerrainLayer14,
        TerrainLayer15,
        TerrainLayer16,
        TerrainLayer17,
        TerrainLayer18,
        TerrainLayer19,
        TerrainLayer20,
        TerrainLayer21,
        TerrainLayer22,
        TerrainLayer23
    }

    public enum TerrainObject
    {
        None,
        Layer1,
        Layer2,
        Layer3,
        Layer4,
        Layer5,
        Layer6,
        Layer7,
        Layer8,
        Layer9,
        Layer10,
        Layer11,
        Layer12,
        Layer13,
        Layer14,
        Layer15,
        Layer16,
        Layer17,
        Layer18,
        Layer19,
        Layer20,
        Layer21,
        Layer22,
        Layer23,
    }

    public enum OutFormat
    {
        PNG,
        JPEG
    }

    /// <summary>
    /// Stores parameters required to create a map
    /// </summary>
    public class MapCreationParameters
    {
        public static int VERSION = 1;

        public MapCreationParameters() { }
        public MapCreationParameters(MapCreationParameters parameters)
        {
            OutputPath = parameters.OutputPath;
            OutputFormat = parameters.OutputFormat;
            ShowGridLines = parameters.ShowGridLines;
            ShowZoneOutlines = parameters.ShowZoneOutlines;
            ShowBuildingOutlines = parameters.ShowBuildingOutlines;
            BlendTerrainLayers = parameters.BlendTerrainLayers;
            SegmentPaddingX = parameters.SegmentPaddingX;
            SegmentPaddingY = parameters.SegmentPaddingY;
            SegmentOffsetX = parameters.SegmentOffsetX;
            SegmentOffsetY = parameters.SegmentOffsetY;
            GridSegmentSize = parameters.GridSegmentSize;
            ColorDictionary = parameters.ColorDictionary;
            VisibleMapObjects = parameters.VisibleMapObjects;
            TerrainDataDictionary = parameters.TerrainDataDictionary;
        }

        #region Ouput

        public string OutputPath;
        public OutFormat OutputFormat = OutFormat.PNG;

        #endregion

        #region Dimensions/Grid properties

        public bool ShowGridLines = false;
        public bool ShowZoneOutlines = false;
        public bool ShowBuildingOutlines = true;
        public bool BlendTerrainLayers = false;
        public int GridSegmentSize = 5;//10;
        public int SegmentPaddingX = 1;//4;
        public int SegmentPaddingY = 1;//4;

        public List<MapObject> VisibleMapObjects = new List<MapObject>()
        {
            MapObject.TerrainMap,
            MapObject.PloppedBuildingZone,
            MapObject.MilitaryZone,
            MapObject.AirportZone,
            MapObject.SeaportZone,
            MapObject.SpaceportZone,
            MapObject.ResidentialHighZone,
            MapObject.ResidentialMidZone,
            MapObject.ResidentialLowZone,
            MapObject.CommercialHighZone,
            MapObject.CommercialMidZone,
            MapObject.CommercialLowZone,
            MapObject.IndustrialHighZone,
            MapObject.IndustrialMidZone,
            MapObject.IndustrialLowZone,
            //MapObject.Building,
            MapObject.StreetNetwork1,
            MapObject.RoadNetwork1,
            MapObject.OneWayRoadNetwork1,
            MapObject.AvenueNetwork1,
            MapObject.RailwayNetwork1,
        };

        public Dictionary<TerrainObject, (bool enabled, string alias, MapColorObject colorObject, int height)> TerrainDataDictionary
            = new Dictionary<TerrainObject, (bool enabled, string alias, MapColorObject colorObject, int height)>()
        {
            {TerrainObject.Layer1, (true, "Deep water", MapColorObject.TerrainLayer1, 219) },
            {TerrainObject.Layer2, (true, "Shallow water 1", MapColorObject.TerrainLayer2, 220) },
            {TerrainObject.Layer3, (true, "Shallow water 2", MapColorObject.TerrainLayer3, 230) },
            {TerrainObject.Layer4, (true, "Shallow water 3", MapColorObject.TerrainLayer4, 237) },
            {TerrainObject.Layer5, (true, "Sand ", MapColorObject.TerrainLayer5, 254) },
            {TerrainObject.Layer6, (true, "Grass 1", MapColorObject.TerrainLayer6, 261) },
            {TerrainObject.Layer7, (true, "Grass 2", MapColorObject.TerrainLayer7, 264) },
            {TerrainObject.Layer8, (true, "Grass 3", MapColorObject.TerrainLayer8, 268) },
            {TerrainObject.Layer9, (true, "Grass 4", MapColorObject.TerrainLayer9, 272) },
            {TerrainObject.Layer10, (true, "Grass 5", MapColorObject.TerrainLayer10, 275) },
            {TerrainObject.Layer11, (true, "Hill 1", MapColorObject.TerrainLayer11, 297) },
            {TerrainObject.Layer12, (true, "Hill 2", MapColorObject.TerrainLayer12, 289) },
            {TerrainObject.Layer13, (true, "Hill 3", MapColorObject.TerrainLayer13, 305) },
            {TerrainObject.Layer14, (true, "Hill 4", MapColorObject.TerrainLayer14, 307) },
            {TerrainObject.Layer15, (true, "Hill 5", MapColorObject.TerrainLayer15, 315) },
            {TerrainObject.Layer16, (true, "Mountain 1", MapColorObject.TerrainLayer16, 355) },
            {TerrainObject.Layer17, (true, "Mountain 2", MapColorObject.TerrainLayer17, 372) },
            {TerrainObject.Layer18, (true, "Mountain 3", MapColorObject.TerrainLayer18, 401) },
            {TerrainObject.Layer19, (true, "Mountain 4", MapColorObject.TerrainLayer19, 481) },
            {TerrainObject.Layer20, (true, "Mountain 5", MapColorObject.TerrainLayer20, 526) },
            {TerrainObject.Layer21, (true, "Mountain 6", MapColorObject.TerrainLayer21, 807) },
            {TerrainObject.Layer22, (true, "Mountain 7", MapColorObject.TerrainLayer22, 1011) },
            {TerrainObject.Layer23, (true, "Mountain 8", MapColorObject.TerrainLayer23, 1600) },
        };


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

            {MapColorObject.Buildings, Color.FromArgb(178, 178, 178)},
            {MapColorObject.BuildingsOutline, Color.FromArgb(153, 153, 153)},

            {MapColorObject.Street, Color.FromArgb(225, 225, 225) },
            {MapColorObject.Road, Color.FromArgb(225, 225, 225)},
            {MapColorObject.OneWayRoad, Color.FromArgb(225, 225, 225)},
            {MapColorObject.Avenue, Color.FromArgb(80, 80, 80)},
            {MapColorObject.Railway, Color.FromArgb(179, 24, 21)},
            {MapColorObject.Subway, Color.FromArgb(120, 0, 180)},

            {MapColorObject.TerrainLayer1, Color.FromArgb(61, 102, 180)},
            {MapColorObject.TerrainLayer2, Color.FromArgb(65, 108, 182)},
            {MapColorObject.TerrainLayer3, Color.FromArgb(90, 126, 172)},
            {MapColorObject.TerrainLayer4, Color.FromArgb(112, 136, 156)},
            {MapColorObject.TerrainLayer5, Color.FromArgb(161, 147, 111)},
            {MapColorObject.TerrainLayer6, Color.FromArgb(123, 136, 81)},
            {MapColorObject.TerrainLayer7, Color.FromArgb(120, 133, 79)},
            {MapColorObject.TerrainLayer8, Color.FromArgb(100, 125, 64)},
            {MapColorObject.TerrainLayer9, Color.FromArgb(79, 118, 48)},
            {MapColorObject.TerrainLayer10, Color.FromArgb(81, 120, 63)},
            {MapColorObject.TerrainLayer11, Color.FromArgb(93, 135, 112)},
            {MapColorObject.TerrainLayer12, Color.FromArgb(86, 130, 96)},
            {MapColorObject.TerrainLayer13, Color.FromArgb(92, 130, 108)},
            {MapColorObject.TerrainLayer14, Color.FromArgb(94, 129, 105)},
            {MapColorObject.TerrainLayer15, Color.FromArgb(94, 124, 100)},
            {MapColorObject.TerrainLayer16, Color.FromArgb(115, 113, 83)},
            {MapColorObject.TerrainLayer17, Color.FromArgb(121, 108, 77)},
            {MapColorObject.TerrainLayer18, Color.FromArgb(124, 111, 82)},
            {MapColorObject.TerrainLayer19, Color.FromArgb(131, 120, 93)},
            {MapColorObject.TerrainLayer20, Color.FromArgb(136, 125, 100)},
            {MapColorObject.TerrainLayer21, Color.FromArgb(162, 156, 141)},
            {MapColorObject.TerrainLayer22, Color.FromArgb(181, 179, 171)},
            {MapColorObject.TerrainLayer23, Color.FromArgb(200, 200, 200)},

        };

        #endregion

        /// <summary>
        /// Saves the current MapParameters object to a file. This method expects exceptions to be handled
        /// outside of the method
        /// </summary>
        /// <param name="path">Path to file to save to</param>
        public void SaveToFile(string path)
        {
            List<string> properties = new List<string>();

            // Get the properties as a list of strings
            properties.Add($"Version:{VERSION};");
            properties.Add("!!!WARNING: This file is Case-Sensitive!!!");
            properties.Add($"ShowGridLines:{(ShowGridLines ? "true" : "false")};");
            properties.Add($"ShowZoneOutlines:{(ShowZoneOutlines ? "true" : "false")};");
            properties.Add($"ShowBuildingOutlines:{(ShowBuildingOutlines ? "true" : "false")};");
            properties.Add($"BlendTerrainColors:{(BlendTerrainLayers ? "true" : "false")};");
            properties.Add($"GridSegmentSize:{GridSegmentSize};");
            properties.Add($"SegmentPaddingX:{SegmentPaddingX};");
            properties.Add($"SegmentPaddingY:{SegmentPaddingY};");
            properties.Add($"VisibleObjects:{string.Join(",", VisibleMapObjects)};");
            foreach (var data in TerrainDataDictionary)
            {
                properties.Add($"TerrainData@{data.Key}:{(data.Value.enabled ? "true" : "false")},\"{data.Value.alias}\",{data.Value.colorObject},{data.Value.height};");
            }
            foreach (var color in ColorDictionary)
            {
                properties.Add($"Color@{color.Key}:{color.Value.R},{color.Value.G},{color.Value.B};");
            }

            // Write each properties to a line in a file
            using (StreamWriter writer = new StreamWriter(path))
            {
                foreach (string property in properties)
                {
                    writer.WriteLine(property);
                }
            }
        }

        /// <summary>
        /// Loads MapParameters from a file and fills object with values. Expects exceptions to be handled externally
        /// </summary>
        /// <param name="path">path to map parameters file</param>
        public void LoadFromFile(string path)
        {
            MapCreationParameters mapCreationParameters = new MapCreationParameters(this);
            Dictionary<MapColorObject, Color> colors = ColorDictionary;
            Dictionary<TerrainObject, (bool enabled, string alias, MapColorObject colorObject, int height)> terrainData = TerrainDataDictionary;

            Dictionary<string, string> properties = new Dictionary<string, string>();

            string line = "";
            using (StreamReader reader = new StreamReader(path))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    // Split the line via ':'
                    string[] lineData = line.Replace(";", "").Split(':');

                    string propertyKey = lineData.First();//.ToLower();
                    string propertyValue = lineData.Last();//.ToLower();

                    // Add line info to properties dictionary
                    // (first part is the property name, second part is property value)
                    properties.Add(propertyKey, propertyValue);
                }
            }
            

            if (properties["Version"] == "")
            {
                throw new Exception($"Could not find version of properties file. Can't parse file.");
            }

            if (int.Parse(properties["Version"]) > VERSION)
            {
                throw new Exception($"Properties file version too high. Can only parse version {VERSION} or lower, version {properties["version"]} found in file");
            }

            // Loop through each property 
            foreach (var property in properties)
            {
                // Sort and assign colours seperately
                if (property.Key.Contains("Color@"))
                {
                    string colorKey = property.Key.Split('@').Last();
                    string[] colorValues = property.Value.Split(',');
                    int r = int.Parse(colorValues[0]);
                    int g = int.Parse(colorValues[1]);
                    int b = int.Parse(colorValues[2]);

                    // Load the colors from the file into the dictionary
                    colors[(MapColorObject)Enum.Parse(typeof(MapColorObject), colorKey)] = Color.FromArgb(r, g, b);
                }
                else if (property.Key.Contains("TerrainData@"))
                {
                    string dataKey = property.Key.Split('@').Last();
                    string[] dataValues = property.Value.Split(',');

                    bool enabled = (dataValues[0] == "true" ? true : false);
                    string alias = dataValues[1].Replace("\"", ""); 
                    MapColorObject colorObject = (MapColorObject)Enum.Parse(typeof(MapColorObject), dataValues[2]);
                    int height = int.Parse(dataValues[3]);

                    // Load terrain data into dictionary
                    terrainData[(TerrainObject)Enum.Parse(typeof(TerrainObject), dataKey)] = (enabled, alias, colorObject, height);
                }
                else
                {
                    // Sort all other properties
                    switch (property.Key)
                    {
                        case "ShowGridLines":
                            if (property.Value == "true")
                                mapCreationParameters.ShowGridLines = true;
                            else
                                mapCreationParameters.ShowGridLines = false;
                            break;
                        case "ShowZoneOutLines":
                            if (property.Value == "true")
                                mapCreationParameters.ShowZoneOutlines = true;
                            else
                                mapCreationParameters.ShowZoneOutlines = false;
                            break;
                        case "ShowBuildingOutlines":
                            if (property.Value == "true")
                                mapCreationParameters.ShowBuildingOutlines = true;
                            else
                                mapCreationParameters.ShowBuildingOutlines = false;
                            break;
                        case "BlendTerrainColors":
                            if (property.Value == "true")
                                mapCreationParameters.BlendTerrainLayers = true;
                            else
                                mapCreationParameters.BlendTerrainLayers = false;
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
                        case "VisibleObjects":
                            mapCreationParameters.VisibleMapObjects = new List<MapObject>();

                            foreach (string mapObject in property.Value.Split(','))
                            {
                                mapCreationParameters.VisibleMapObjects.Add((MapObject)Enum.Parse(typeof(MapObject), mapObject));
                            }
                            break;
                    }
                }
            }

            // Now everything has been loaded safely, apply them to our current map properties object
            this.ColorDictionary = colors;
            this.ShowGridLines = mapCreationParameters.ShowGridLines;
            this.ShowZoneOutlines = mapCreationParameters.ShowZoneOutlines;
            this.ShowBuildingOutlines = mapCreationParameters.ShowBuildingOutlines;
            this.BlendTerrainLayers = mapCreationParameters.BlendTerrainLayers;
            this.GridSegmentSize = mapCreationParameters.GridSegmentSize;
            this.SegmentPaddingX = mapCreationParameters.SegmentPaddingX;
            this.SegmentPaddingY = mapCreationParameters.SegmentPaddingY;
            this.SegmentOffsetX = mapCreationParameters.SegmentOffsetX;
            this.SegmentOffsetY = mapCreationParameters.SegmentOffsetY;
            this.VisibleMapObjects = mapCreationParameters.VisibleMapObjects;
        }

        // Helper lookup dictionary for network tile types and their related enum
        public static Dictionary<byte, MapObject> NetworkTypeToMapObject = new Dictionary<byte, MapObject>()
        {
            {0x00, MapObject.RoadNetwork1},
            {0x01, MapObject.RailwayNetwork1},
            {0x03, MapObject.StreetNetwork1},
            {0x06, MapObject.AvenueNetwork1},
            {0x07, MapObject.SubwayNetwork2},
            {0x0A, MapObject.OneWayRoadNetwork1},
        };
    }
}
