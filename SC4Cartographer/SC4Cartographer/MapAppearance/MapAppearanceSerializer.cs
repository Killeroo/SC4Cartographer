using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Drawing;


namespace SC4CartographerUI
{
    public class MapAppearanceSerializer
    {
        private const string tempFilename = "map_appearance_autosave.sc4cart";
        private readonly string tempFilePath = Path.Combine(Path.GetTempPath(), tempFilename);
        private const int VERSION = 1;

        public void SaveToUserTempFolder(MapCreationParameters parameters)
        {
            SaveToFile(parameters, tempFilePath);
        }
        
        public bool TryLoadFromUserTempFolder(out MapCreationParameters parameters)
        {
            bool sucsess = false;
            parameters = null;

            if (File.Exists(tempFilePath))
            {
                try
                {
                    parameters = LoadFromFile(tempFilePath);
                    sucsess = true;
                }
                catch (Exception)
                {
                    // should probably log this
                }
            }

            return sucsess;
        }

        /// <summary>
        /// Save the a MapParameters object to a file.
        /// Does not handle exceptions.
        /// </summary>
        /// <param name="parameters">The MapParameters object to save.</param>
        /// <param name="path">Path to file to save to</param>
        public void SaveToFile(MapCreationParameters parameters, string path)
        {
            List<string> properties = parameters.ToStrings();
            properties.Insert(0, $"Version:{VERSION};");
            properties.Insert(1, "!!!WARNING: This file is Case-Sensitive!!!");

            WritePropertiesToFile(path, properties);
        }

        private static void WritePropertiesToFile(string path, List<string> properties)
        {
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
        public MapCreationParameters LoadFromFile(string path)
        {
            MapCreationParameters parameters = new MapCreationParameters();
            Dictionary<MapColorObject, Color> colors = parameters.ColorDictionary;
            Dictionary<TerrainObject, (bool enabled, string alias, MapColorObject colorObject, int height)> terrainData = parameters.TerrainDataDictionary;

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
                            parameters.ShowGridLines = Convert.ToBoolean(property.Value);
                            break;
                        case "ShowZoneOutlines":
                            parameters.ShowZoneOutlines = Convert.ToBoolean(property.Value);
                            break;
                        case "BlendTerrainColors":
                            parameters.BlendTerrainLayers = Convert.ToBoolean(property.Value);
                            break;
                        case "GridSegmentSize":
                            parameters.GridSegmentSize = int.Parse(property.Value);
                            break;
                        case "SegmentPaddingX":
                            parameters.SegmentPaddingX = int.Parse(property.Value);
                            break;
                        case "SegmentPaddingY":
                            parameters.SegmentPaddingY = int.Parse(property.Value);
                            break;
                        case "SegmentOffsetX":
                            parameters.SegmentOffsetX = int.Parse(property.Value);
                            break;
                        case "SegmentOffsetY":
                            parameters.SegmentOffsetY = int.Parse(property.Value);
                            break;
                        case "VisibleObjects":
                            parameters.VisibleMapObjects = new List<MapObject>();

                            foreach (string mapObject in property.Value.Split(','))
                            {
                                parameters.VisibleMapObjects.Add((MapObject)Enum.Parse(typeof(MapObject), mapObject));
                            }
                            break;
                    }
                }
            }

            // Now everything has been loaded safely
            return parameters;
        }
    }
}
