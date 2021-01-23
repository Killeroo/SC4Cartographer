using System;
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
                Color deepWaterColor = Color.FromArgb(61, 102, 180);
                Color shallowWaterColor1 = Color.FromArgb(65, 108, 182);
                Color shallowWaterColor2 = Color.FromArgb(90, 126, 172);
                Color shallowWaterColor3 = Color.FromArgb(112, 136, 156);
                Color sandColor1 = Color.FromArgb(161, 147, 111);
                Color grassColor1 = Color.FromArgb(123, 136, 81);
                Color grassColor2 = Color.FromArgb(120, 133, 79);
                Color grassColor3 = Color.FromArgb(100, 125, 64);
                Color grassColor4 = Color.FromArgb(79, 118, 48);
                Color grassColor5 = Color.FromArgb(81, 120, 63);
                Color hillColor1 = Color.FromArgb(93, 135, 112);
                Color hillColor2 = Color.FromArgb(86, 130, 96);
                Color hillColor3 = Color.FromArgb(92, 130, 108);
                Color hillColor4 = Color.FromArgb(94, 129, 105);
                Color hillColor5 = Color.FromArgb(94, 124, 100);
                Color mountainColor1 = Color.FromArgb(115, 113, 83);
                Color mountainColor2 = Color.FromArgb(121, 108, 77);
                Color mountainColor3 = Color.FromArgb(124, 111, 82);
                Color mountainColor4 = Color.FromArgb(131, 120, 93);
                Color mountainColor5 = Color.FromArgb(136, 125, 100);
                Color mountainColor6 = Color.FromArgb(162, 156, 141);
                Color mountainColor7 = Color.FromArgb(181, 179, 171);
                Color mountainColor8 = Color.FromArgb(200, 200, 200);

                int deepWaterHeight = 220;
                //int shallowWater1Height = // Basically anything between 220 and 230
                int shallowWater2Height = 230;
                int shallowWater3Height = 237;
                int sand1Height = 254;
                int grass1Height = 261;
                int grass2Height = 264;
                int grass3Height = 268;
                int grass4Height = 272;
                int grass5Height = 275;
                int hill1Height = 297;
                int hill2Height = 289;
                int hill3Height = 305;
                int hill4Height = 307;
                int hill5Height = 315;
                int mountain1Height = 355;
                int mountain2Height = 372;
                int mountain3Height = 401;
                int mountain4Height = 481;
                int mountain5Height = 526;
                int mountain6Height = 807;
                int mountain7Height = 1011;
                int mountain8Height = 1600;

                // Render terrain map
                // this can almost certainly done better but yeah...
                // Did you know I spent 6 months writing this tool and the parser? :/
                if (parameters.VisibleMapObjects.Contains(MapObject.TerrainMap))
                {
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

                            // Determine colour 
                            // (this is the part that can be done better btws
                            if (height < deepWaterHeight)
                            {
                                c = deepWaterColor;
                            }
                            else if (height <= shallowWater2Height)
                            {
                                c = MapColor(height, deepWaterHeight, shallowWater2Height, shallowWaterColor1, shallowWaterColor2);
                            }
                            else if (height <= shallowWater3Height)
                            {
                                c = MapColor(height, shallowWater2Height, shallowWater3Height, shallowWaterColor2, shallowWaterColor3);
                            }
                            else if (height <= sand1Height)
                            {
                                c = MapColor(height, shallowWater3Height, sand1Height, shallowWaterColor3, sandColor1);
                            }
                            else if (height <= grass1Height)
                            {
                                c = MapColor(height, sand1Height, grass1Height, sandColor1, grassColor1);
                            }
                            else if (height <= grass2Height)
                            {
                                c = MapColor(height, grass1Height, grass2Height, grassColor1, grassColor2);
                            }
                            else if (height <= grass3Height)
                            {
                                c = MapColor(height, grass2Height, grass3Height, grassColor2, grassColor3);
                            }
                            else if (height <= grass4Height)
                            {
                                c = MapColor(height, grass3Height, grass4Height, grassColor3, grassColor4);
                            }
                            else if (height <= grass5Height)
                            {
                                c = MapColor(height, grass4Height, grass5Height, grassColor4, grassColor5);
                            }
                            else if (height <= hill1Height)
                            {
                                c = MapColor(height, grass5Height, hill1Height, grassColor5, hillColor1);
                            }
                            else if (height <= hill2Height)
                            {
                                c = MapColor(height, hill1Height, hill2Height, hillColor1, hillColor2);
                            }
                            else if (height <= hill3Height)
                            {
                                c = MapColor(height, hill2Height, hill3Height, hillColor2, hillColor3);
                            }
                            else if (height <= hill4Height)
                            {
                                c = MapColor(height, hill3Height, hill4Height, hillColor3, hillColor4);
                            }
                            else if (height <= hill5Height)
                            {
                                c = MapColor(height, hill4Height, hill5Height, hillColor4, hillColor5);
                            }
                            else if (height <= mountain1Height)
                            {
                                c = MapColor(height, hill5Height, mountain1Height, hillColor5, mountainColor1);
                            }
                            else if (height <= mountain2Height)
                            {
                                c = MapColor(height, mountain1Height, mountain2Height, mountainColor1, mountainColor2);
                            }
                            else if (height <= mountain3Height)
                            {
                                c = MapColor(height, mountain2Height, mountain3Height, mountainColor2, mountainColor3);
                            }
                            else if (height <= mountain4Height)
                            {
                                c = MapColor(height, mountain3Height, mountain4Height, mountainColor3, mountainColor4);
                            }
                            else if (height <= mountain5Height)
                            {
                                c = MapColor(height, mountain4Height, mountain5Height, mountainColor4, mountainColor5);
                            }
                            else if (height <= mountain6Height)
                            {
                                c = MapColor(height, mountain5Height, mountain6Height, mountainColor5, mountainColor6);
                            }
                            else if (height <= mountain7Height)
                            {
                                c = MapColor(height, mountain6Height, mountain7Height, mountainColor6, mountainColor7);
                            }
                            else if (height <= mountain8Height)
                            {
                                c = MapColor(height, mountain7Height, mountain8Height, mountainColor7, mountainColor8);
                            }
                            else
                            {
                                c = mountainColor8;
                            }

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
