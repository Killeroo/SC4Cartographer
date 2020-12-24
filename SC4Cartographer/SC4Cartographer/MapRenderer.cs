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

namespace SC4CartographerUI
{
    class MapRenderer
    {
        public static float Map(float value, float valueMin, float valueMax, float outMin, float outMax)
        {
            return (value - valueMin) / (valueMax - valueMin) * (outMax - outMin) + outMin;
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
                float max = 0; //2500 max value
                float min = 1000; // 20 min

                Color minWaterColor = Color.FromArgb(61, 102, 180);
                Color maxWaterColor = Color.FromArgb(94, 129, 170);
                Color minSandColor = Color.FromArgb(136, 136, 119);
                Color maxSandColor = Color.FromArgb(187, 170, 136);
                Color minGrassColor = Color.FromArgb(102, 136, 68);
                Color maxGrassColor = Color.FromArgb(68, 102, 51);
                Color minHillColor = Color.FromArgb(51, 81, 51);
                Color maxHillColor = Color.FromArgb(119, 136, 102);

                int deepWaterHeight = 200;
                int waterMaxHeight = 237;
                int sandMinHeight = 240;
                int sandMaxHeight = 246;//255;// 260;
                int grassMinHeight = 270;
                int grassMaxHeight = 290;
                int hillMinHeight = 310;
                int hillMaxHeight = 310;

                for (int x = 0; x < gridSizeX; x++)
                {
                    for (int y = 0; y < gridSizeY; y++)
                    {
                        Rectangle rect = new Rectangle();
                        rect = new Rectangle(
                                (parameters.GridSegmentSize * x),
                                (parameters.GridSegmentSize * y),
                                (parameters.GridSegmentSize),
                                (parameters.GridSegmentSize));

                        float height = heightMap[y][x];
                        Color c;

                        if (height < deepWaterHeight)
                        {
                            c = minWaterColor;
                        }
                        else if (height <= waterMaxHeight)
                        {
                            float red = Map(height, deepWaterHeight, waterMaxHeight, minWaterColor.R, maxWaterColor.R);
                            float green = Map(height, deepWaterHeight, waterMaxHeight, minWaterColor.G, maxWaterColor.G);
                            float blue = Map(height, deepWaterHeight, waterMaxHeight, minWaterColor.B, maxWaterColor.B);

                            c = Color.FromArgb((int)red, (int)green, (int)blue);
                        }
                        else if (height <= sandMinHeight)
                        {
                            float red = Map(height, waterMaxHeight, sandMinHeight, maxWaterColor.R, minSandColor.R);
                            float green = Map(height, waterMaxHeight, sandMinHeight, maxWaterColor.G, minSandColor.G);
                            float blue = Map(height, waterMaxHeight, sandMinHeight, maxWaterColor.B, minSandColor.B);

                            c = Color.FromArgb((int)red, (int)green, (int)blue);
                        }
                        else if (height <= sandMaxHeight)
                        {
                            float red = Map(height, sandMinHeight, sandMaxHeight, minSandColor.R, maxSandColor.R);
                            float green = Map(height, sandMinHeight, sandMaxHeight, minSandColor.G, maxSandColor.G);
                            float blue = Map(height, sandMinHeight, sandMaxHeight, minSandColor.B, maxSandColor.B);

                            c = Color.FromArgb((int)red, (int)green, (int)blue);
                        }
                        else if (height <= grassMinHeight)
                        {
                            float red = Map(height, sandMaxHeight, grassMinHeight, maxSandColor.R, minGrassColor.R);
                            float green = Map(height, sandMaxHeight, grassMinHeight, maxSandColor.G, minGrassColor.G);
                            float blue = Map(height, sandMaxHeight, grassMinHeight, maxSandColor.B, minGrassColor.B);

                            c = Color.FromArgb((int)red, (int)green, (int)blue);
                        }
                        else if (height <= grassMaxHeight)
                        {
                            float red = Map(height, grassMinHeight, grassMaxHeight, minGrassColor.R, minHillColor.R);
                            float green = Map(height, grassMinHeight, grassMaxHeight, minGrassColor.G, minHillColor.G);
                            float blue = Map(height, grassMinHeight, grassMaxHeight, minGrassColor.B, minHillColor.B);

                            c = Color.FromArgb((int)red, (int)green, (int)blue);
                        }
                        //else if (height <= hillMinHeight)
                        //{
                        //    float red = Map(height, grassMaxHeight, hillMinHeight, maxGrassColor.R, minHillColor.R);
                        //    float green = Map(height, grassMaxHeight, hillMinHeight, maxGrassColor.G, minHillColor.G);
                        //    float blue = Map(height, grassMaxHeight, hillMinHeight, maxGrassColor.B, minHillColor.B);

                        //    c = Color.FromArgb((int)red, (int)green, (int)blue);
                        //}
                        //else if (height <= hillMaxHeight)
                        //{
                        //    float red = Map(height, hillMinHeight, hillMaxHeight, minHillColor.R, maxHillColor.R);
                        //    float green = Map(height, hillMinHeight, hillMaxHeight, minHillColor.G, maxHillColor.G);
                        //    float blue = Map(height, hillMinHeight, hillMaxHeight, minHillColor.B, maxHillColor.B);

                        //    c = Color.FromArgb((int)red, (int)green, (int)blue);
                        //}
                        //else if (height <= 500)
                        //{
                        //    float red = Map(height, 350, 500, 107, 149);
                        //    float green = Map(height, 350, 500, 157, 137);
                        //    float blue = Map(height, 350, 500, 130, 104);

                        //    c = Color.FromArgb((int)red, (int)green, (int)blue);
                        //}
                        else
                        {
                            float height_max = 2500;
                            float height_min = 0;
                            float color_max = 255;
                            float color_min = 0;
                            float color = (height - height_min) / (height_max - height_min) * (color_max - color_min) + color_min;

                            c = Color.FromArgb((int)color, (int)color, (int)color);
                        }

                        //float height_max = 500;//2500;
                        //float height_min = 0;
                        //float color_max = 255;
                        //float color_min = 0;
                        //float color = (height - height_min) / (height_max - height_min) * (color_max - color_min) + color_min;

                        //c = Color.FromArgb((int)color, (int)color, (int)color);

                        g.FillRectangle(new SolidBrush(c), rect);
                    }
                }

                //g.Clear(parameters.ColorDictionary[MapColorObject.Background]);

                //    Pen zoneOutlinePen = new Pen(parameters.ColorDictionary[MapColorObject.ZoneOutline]);
                //    Pen gridLinesPen = new Pen(parameters.ColorDictionary[MapColorObject.GridLines]);
                //    gridLinesPen.Width = 1;
                //    zoneOutlinePen.Width = 1;

                //    foreach (var lot in save.GetLotSubfile().Lots)
                //    {
                //        Rectangle rect = new Rectangle();

                //        Color c = new Color();
                //        switch (lot.ZoneType)
                //        {
                //            case SC4Parser.Constants.LOT_ZONE_TYPE_RESIDENTIAL_LOW:
                //                c = parameters.ColorDictionary[MapColorObject.ResidentialLow];
                //                break;

                //            case SC4Parser.Constants.LOT_ZONE_TYPE_RESIDENTIAL_MEDIUM:
                //                c = parameters.ColorDictionary[MapColorObject.ResidentialMid];
                //                break;

                //            case SC4Parser.Constants.LOT_ZONE_TYPE_RESIDENTIAL_HIGH:
                //                c = parameters.ColorDictionary[MapColorObject.ResidentialHigh];
                //                break;

                //            case SC4Parser.Constants.LOT_ZONE_TYPE_COMMERCIAL_LOW:
                //                c = parameters.ColorDictionary[MapColorObject.CommercialLow];
                //                break;

                //            case SC4Parser.Constants.LOT_ZONE_TYPE_COMMERCIAL_MEDIUM:
                //                c = parameters.ColorDictionary[MapColorObject.CommercialMid];
                //                break;

                //            case SC4Parser.Constants.LOT_ZONE_TYPE_COMMERCIAL_HIGH:
                //                c = parameters.ColorDictionary[MapColorObject.CommercialHigh];
                //                break;

                //            case SC4Parser.Constants.LOT_ZONE_TYPE_INDUSTRIAL_LOW:
                //                c = parameters.ColorDictionary[MapColorObject.IndustrialLow];
                //                break;

                //            case SC4Parser.Constants.LOT_ZONE_TYPE_INDUSTRIAL_MEDIUM:
                //                c = parameters.ColorDictionary[MapColorObject.IndustrialMid];
                //                break;

                //            case SC4Parser.Constants.LOT_ZONE_TYPE_INDUSTRIAL_HIGH:
                //                c = parameters.ColorDictionary[MapColorObject.IndustrialHigh];
                //                break;

                //            case SC4Parser.Constants.LOT_ZONE_TYPE_MILITARY:
                //                c = parameters.ColorDictionary[MapColorObject.Military];
                //                break;

                //            case SC4Parser.Constants.LOT_ZONE_TYPE_AIRPORT:
                //                c = parameters.ColorDictionary[MapColorObject.Airport];
                //                break;

                //            case SC4Parser.Constants.LOT_ZONE_TYPE_SEAPORT:
                //                c = parameters.ColorDictionary[MapColorObject.Seaport];
                //                break;

                //            case SC4Parser.Constants.LOT_ZONE_TYPE_SPACEPORT:
                //                c = parameters.ColorDictionary[MapColorObject.Spaceport];
                //                break;

                //            case SC4Parser.Constants.LOT_ZONE_TYPE_PLOPPED_BUILDING:
                //                c = parameters.ColorDictionary[MapColorObject.PloppedBuilding];
                //                break;
                //            case SC4Parser.Constants.LOT_ZONE_TYPE_PLOPPED_BUILDING_ALT:
                //                c = parameters.ColorDictionary[MapColorObject.Military];
                //                break;
                //            default:
                //                c = parameters.ColorDictionary[MapColorObject.PloppedBuilding];
                //                break;
                //        }

                //        switch (lot.Orientation)
                //        {
                //            case Constants.ORIENTATION_NORTH:
                //            case Constants.ORIENTATION_SOUTH:
                //                rect = new Rectangle(
                //                    (parameters.GridSegmentSize * lot.MinTileX) + parameters.SegmentOffsetX,
                //                    (parameters.GridSegmentSize * lot.MinTileZ) + parameters.SegmentOffsetY,
                //                    (parameters.GridSegmentSize * lot.SizeX) - parameters.SegmentPaddingX,
                //                    (parameters.GridSegmentSize * lot.SizeZ) - parameters.SegmentPaddingY);
                //                break;

                //            case Constants.ORIENTATION_WEST:
                //            case Constants.ORIENTATION_EAST:
                //                rect = new Rectangle(
                //                    (parameters.GridSegmentSize * lot.MinTileX) + parameters.SegmentOffsetX,
                //                    (parameters.GridSegmentSize * lot.MinTileZ) + parameters.SegmentOffsetY,
                //                    (parameters.GridSegmentSize * lot.SizeZ) - parameters.SegmentPaddingX,
                //                    (parameters.GridSegmentSize * lot.SizeX) - parameters.SegmentPaddingY);


                //                break;

                //        }

                //        g.FillRectangle(new SolidBrush(c), rect);

                //        if (parameters.ShowZoneOutlines)
                //        {
                //            g.DrawRectangle(zoneOutlinePen, rect);
                //        }
                //    }

                //    if (parameters.ShowGridLines)
                //    {
                //        for (int y = 0; y < gridSizeY; ++y)
                //        {
                //            g.DrawLine(gridLinesPen, 0, y * parameters.GridSegmentSize, gridSizeY * parameters.GridSegmentSize, y * parameters.GridSegmentSize);
                //        }

                //        for (int x = 0; x < gridSizeX; ++x)
                //        {
                //            g.DrawLine(gridLinesPen, x * parameters.GridSegmentSize, 0, x * parameters.GridSegmentSize, gridSizeY * parameters.GridSegmentSize);
                //        }
                //    }

                }

            return bmp;
                
        }
    }
}
