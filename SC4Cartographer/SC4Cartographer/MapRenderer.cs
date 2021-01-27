﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

using SC4Parser;
using SC4Parser.Files;
using SC4Parser.DataStructures;

namespace SC4CartographerUI
{
    class MapRenderer
    {
        public static float Map(float value, float valueMin, float valueMax, float outMin, float outMax)
        {
            return (value - valueMin) / (valueMax - valueMin) * (outMax - outMin) + outMin;
        }
        public static Color MapColor(float value, float valueMin, float valueMax, Color colorMin, Color colorMax)
        {
            float red = Map(value, valueMin, valueMax, colorMin.R, colorMax.R);
            float green = Map(value, valueMin, valueMax, colorMin.G, colorMax.G);
            float blue = Map(value, valueMin, valueMax, colorMin.B, colorMax.B);

            return Color.FromArgb((int)red, (int)green, (int)blue);
        }

        // Create a map from MapCreationParameters
        public static Bitmap CreateMapBitmap(SC4SaveFile save, MapCreationParameters parameters)
        {
            int gridSizeX = (int) save.GetRegionViewSubfile().CitySizeX;
            int gridSizeY = (int) save.GetRegionViewSubfile().CitySizeY;

            float[][] heightMap = save.GetTerrainMapSubfile().Map;
            Bitmap bmp = new Bitmap(
                gridSizeX * parameters.GridSegmentSize + 1,
                gridSizeY * parameters.GridSegmentSize + 1);

            using (Graphics g = Graphics.FromImage(bmp))
            {

                // Render terrain map first
                // this can almost certainly done better but yeah...
                // Did you know I spent 6 months writing this tool and the parser? :/
                if (parameters.VisibleMapObjects.Contains(MapObject.TerrainMap))
                {
                    // First create a list of enabled terrain layers, their height and respective colorObject
                    // We want stuff in a list because it more easy to work with than a dictionary
                    // (we want to be able to seek backwards and forwards from an index which is not so easy with a dict)
                    List<(int height, MapColorObject colorObject)> sortedTerrainList = new List<(int, MapColorObject)>();
                    foreach (var terrainData in parameters.TerrainDataDictionary)
                    {
                        if (terrainData.Value.enabled == false)
                        {
                            continue;
                        }

                        sortedTerrainList.Add((terrainData.Value.height, terrainData.Value.colorObject));
                    }

                    // Order it by height
                    sortedTerrainList.OrderBy(terrain => terrain.height);

                    // Go through each height in the height map
                    for (int x = 0; x < gridSizeX; x++)
                    {
                        for (int y = 0; y < gridSizeY; y++)
                        {
                            // one grid segment has one height value, so we colour that grid segment
                            Rectangle rect = new Rectangle();
                            rect = new Rectangle(
                                    (parameters.GridSegmentSize * x),
                                    (parameters.GridSegmentSize * y),
                                    (parameters.GridSegmentSize),
                                    (parameters.GridSegmentSize));

                            float height = heightMap[y][x];
                            Color c;

                            // Find the closest terrain layer
                            // Go through the sorted list and find the index of the layer
                            // that has the closest height to our current height
                            float currentBestDifference = 999999;
                            int currentBestIndex = 0;
                            for (int index = 0; index < sortedTerrainList.Count(); index++)
                            {
                                float diff = ((float)sortedTerrainList[index].height) - height;

                                if (diff > 0 && diff < currentBestDifference)
                                {
                                    currentBestIndex = index;
                                    currentBestDifference = diff;

                                    // Because the list is ordered, the first instance where we 
                                    // get a positive difference is going to be the closest layer to 
                                    // our current height. 
                                    // If we get out early then we save some time by not going through the whole list
                                    break;
                                }
                                else if (index == sortedTerrainList.Count)
                                {
                                    // If we are at the end of the list and have found nothing then just
                                    // grab the last index and move out
                                    currentBestIndex = index;
                                }
                            }

                            // Fetch the colour 
                            if (currentBestIndex == 0 || currentBestIndex == sortedTerrainList.Count())
                            {
                                // If the closest index that we found is the start or end of the list then we just
                                // use that colour uniformaly 
                                c = parameters.ColorDictionary[sortedTerrainList[currentBestIndex].colorObject];
                            }
                            else
                            {
                                // If we are not at the start or end of the list we are safe to fetch the previous index
                                // and map the value to a color between the 2 closest color layers 
                                c = MapColor(
                                    height,
                                    sortedTerrainList[currentBestIndex - 1].height,
                                    sortedTerrainList[currentBestIndex].height,
                                    parameters.ColorDictionary[sortedTerrainList[currentBestIndex - 1].colorObject],
                                    parameters.ColorDictionary[sortedTerrainList[currentBestIndex].colorObject]);

                            }

                            // Paint the actual grid
                            g.FillRectangle(new SolidBrush(c), rect);
                        }
                    }
                }
                else
                {
                    // if not rendering terrain map, render the background color
                    g.Clear(parameters.ColorDictionary[MapColorObject.Background]);
                }

                Pen zoneOutlinePen = new Pen(parameters.ColorDictionary[MapColorObject.ZoneOutline]);
                Pen gridLinesPen = new Pen(parameters.ColorDictionary[MapColorObject.GridLines]);
                gridLinesPen.Width = 1;
                zoneOutlinePen.Width = 1;

                foreach (var lot in save.GetLotSubfile().Lots)
                {
                    Rectangle rect = new Rectangle();

                    // Get colour of zone (and check if it should be displayed)
                    Color c = new Color();
                    switch (lot.ZoneType)
                    {
                        case SC4Parser.Constants.LOT_ZONE_TYPE_RESIDENTIAL_LOW:
                            {
                                // Check the zone is in the list of visible map objects
                                if (parameters.VisibleMapObjects.Contains(MapObject.ResidentialLowZone))
                                {
                                    c = parameters.ColorDictionary[MapColorObject.ResidentialLow];
                                }
                                else
                                {
                                    // if not skip it
                                    continue;
                                }

                                break;
                            }

                        case SC4Parser.Constants.LOT_ZONE_TYPE_RESIDENTIAL_MEDIUM:
                            {
                                if (parameters.VisibleMapObjects.Contains(MapObject.ResidentialMidZone))
                                {
                                    c = parameters.ColorDictionary[MapColorObject.ResidentialMid];
                                }
                                else
                                {
                                    continue;
                                }

                                break;
                            }
                        case SC4Parser.Constants.LOT_ZONE_TYPE_RESIDENTIAL_HIGH:
                            {
                                if (parameters.VisibleMapObjects.Contains(MapObject.ResidentialHighZone))
                                {
                                    c = parameters.ColorDictionary[MapColorObject.ResidentialHigh];
                                }
                                else
                                { 
                                    continue;                               
                                }

                                break;
                            }
                        case SC4Parser.Constants.LOT_ZONE_TYPE_COMMERCIAL_LOW:
                            {
                                if (parameters.VisibleMapObjects.Contains(MapObject.CommercialLowZone))
                                {
                                    c = parameters.ColorDictionary[MapColorObject.CommercialLow];
                                }
                                else
                                {
                                    continue;
                                }

                                break;
                            }
                        case SC4Parser.Constants.LOT_ZONE_TYPE_COMMERCIAL_MEDIUM:
                            {
                                if (parameters.VisibleMapObjects.Contains(MapObject.CommercialMidZone))
                                {
                                    c = parameters.ColorDictionary[MapColorObject.CommercialMid];
                                }
                                else
                                {
                                    continue;
                                }

                                break;
                            }
                        case SC4Parser.Constants.LOT_ZONE_TYPE_COMMERCIAL_HIGH:
                            {
                                if (parameters.VisibleMapObjects.Contains(MapObject.CommercialHighZone))
                                {
                                    c = parameters.ColorDictionary[MapColorObject.CommercialHigh];
                                }
                                else
                                {
                                    continue;
                                }

                                break;
                            }
                        case SC4Parser.Constants.LOT_ZONE_TYPE_INDUSTRIAL_LOW:
                            {
                                if (parameters.VisibleMapObjects.Contains(MapObject.IndustrialLowZone))
                                {
                                    c = parameters.ColorDictionary[MapColorObject.IndustrialLow];
                                }
                                else
                                {
                                    continue;
                                }

                                break;
                            }
                        case SC4Parser.Constants.LOT_ZONE_TYPE_INDUSTRIAL_MEDIUM:
                            {
                                if (parameters.VisibleMapObjects.Contains(MapObject.IndustrialMidZone))
                                {
                                    c = parameters.ColorDictionary[MapColorObject.IndustrialMid];
                                }
                                else
                                {
                                    continue;
                                }

                                break;
                            }
                        case SC4Parser.Constants.LOT_ZONE_TYPE_INDUSTRIAL_HIGH:
                            {
                                if (parameters.VisibleMapObjects.Contains(MapObject.IndustrialHighZone))
                                {
                                    c = parameters.ColorDictionary[MapColorObject.IndustrialHigh];
                                }
                                else
                                {
                                    continue;
                                }

                                break;
                            }
                        case SC4Parser.Constants.LOT_ZONE_TYPE_MILITARY:
                            {
                                if (parameters.VisibleMapObjects.Contains(MapObject.MilitaryZone))
                                {
                                    c = parameters.ColorDictionary[MapColorObject.Military];
                                }
                                else
                                {
                                    continue;
                                }

                                break;
                            }
                        case SC4Parser.Constants.LOT_ZONE_TYPE_AIRPORT:
                            {
                                if (parameters.VisibleMapObjects.Contains(MapObject.AirportZone))
                                {
                                    c = parameters.ColorDictionary[MapColorObject.Airport];
                                }
                                else
                                {
                                    continue;
                                }

                                break;
                            }
                        case SC4Parser.Constants.LOT_ZONE_TYPE_SEAPORT:
                            {
                                if (parameters.VisibleMapObjects.Contains(MapObject.SeaportZone))
                                {
                                    c = parameters.ColorDictionary[MapColorObject.Seaport];
                                }
                                else
                                {
                                    continue;
                                }

                                break;
                            }
                        case SC4Parser.Constants.LOT_ZONE_TYPE_SPACEPORT:
                            {
                                if (parameters.VisibleMapObjects.Contains(MapObject.SpaceportZone))
                                {
                                    c = parameters.ColorDictionary[MapColorObject.Spaceport];
                                }
                                else
                                {
                                    continue;
                                }

                                break;
                            }
                        case SC4Parser.Constants.LOT_ZONE_TYPE_PLOPPED_BUILDING:
                            {
                                if (parameters.VisibleMapObjects.Contains(MapObject.PloppedBuildingZone))
                                {
                                    c = parameters.ColorDictionary[MapColorObject.PloppedBuilding];
                                }
                                else
                                {
                                    continue;
                                }

                                break;
                            }
                        case SC4Parser.Constants.LOT_ZONE_TYPE_PLOPPED_BUILDING_ALT:
                            {
                                if (parameters.VisibleMapObjects.Contains(MapObject.PloppedBuildingZone))
                                {
                                    c = parameters.ColorDictionary[MapColorObject.PloppedBuilding];
                                }
                                else
                                {
                                    continue;
                                }

                                break;
                            }
                        default:
                            c = parameters.ColorDictionary[MapColorObject.PloppedBuilding];
                            break;
                    }

                    // Get the actual dimensions of the zone
                    switch (lot.Orientation)
                    {
                        case Constants.ORIENTATION_NORTH:
                        case Constants.ORIENTATION_SOUTH:
                            rect = new Rectangle(
                                parameters.SegmentPaddingX + (parameters.GridSegmentSize * lot.MinTileX) + parameters.SegmentOffsetX,
                                parameters.SegmentPaddingY + (parameters.GridSegmentSize * lot.MinTileZ) + parameters.SegmentOffsetY,
                                (parameters.GridSegmentSize * lot.SizeX) - parameters.SegmentPaddingX,
                                (parameters.GridSegmentSize * lot.SizeZ) - parameters.SegmentPaddingY);
                            break;

                        case Constants.ORIENTATION_WEST:
                        case Constants.ORIENTATION_EAST:
                            rect = new Rectangle(
                                parameters.SegmentPaddingX + (parameters.GridSegmentSize * lot.MinTileX) + parameters.SegmentOffsetX,
                                parameters.SegmentPaddingY + (parameters.GridSegmentSize * lot.MinTileZ) + parameters.SegmentOffsetY,
                                (parameters.GridSegmentSize * lot.SizeZ) - parameters.SegmentPaddingX,
                                (parameters.GridSegmentSize * lot.SizeX) - parameters.SegmentPaddingY);


                            break;

                    }

                    // Draw the zone on the bitmap
                    g.FillRectangle(new SolidBrush(c), rect);

                    // draw an outline if that option is enabled
                    if (parameters.ShowZoneOutlines)
                    {
                        g.DrawRectangle(zoneOutlinePen, rect);
                    }
                }

                //foreach (NetworkTile tile in save.GetNetworkSubfile1().Tiles)
                //{
                //    if (tile.MaxSizeX > 0  && tile.MaxSizeZ > 0)
                //    {
                //        Rectangle rect = new Rectangle(
                //            parameters.GridSegmentSize * (int) (Math.Truncate(tile.MinSizeX / 16)),
                //            parameters.GridSegmentSize * (int) (Math.Truncate(tile.MinSizeZ / 16)),
                //            parameters.GridSegmentSize * (int) (Math.Truncate((tile.MaxSizeX - tile.MinSizeX) / 16)),
                //            parameters.GridSegmentSize * (int) (Math.Truncate((tile.MaxSizeZ - tile.MinSizeZ) / 16))
                //        );

                //        g.FillRectangle(new SolidBrush(Color.White), rect);
                //    }
                //}

                // Render grid lines
                if (parameters.ShowGridLines)
                {
                    for (int y = 0; y < gridSizeY; ++y)
                    {
                        g.DrawLine(gridLinesPen, 0, y * parameters.GridSegmentSize, gridSizeY * parameters.GridSegmentSize, y * parameters.GridSegmentSize);
                    }

                    for (int x = 0; x < gridSizeX; ++x)
                    {
                        g.DrawLine(gridLinesPen, x * parameters.GridSegmentSize, 0, x * parameters.GridSegmentSize, gridSizeY * parameters.GridSegmentSize);
                    }
                }

            }

            return bmp;
                
        }
    }
}
