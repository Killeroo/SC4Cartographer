using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

using SC4Parser;

namespace SC4CartographerUI
{
    class MapRenderer
    {
        public static Bitmap CreateMapBitmap(MapCreationParameters parameters)
        {
            Bitmap bmp = new Bitmap(
                parameters.GridSizeX * parameters.GridSegmentSize + 1, 
                parameters.GridSizeY * parameters.GridSegmentSize + 1);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(parameters.ColorDictionary[MapColorObject.Background]);
                Pen pen = new Pen(parameters.ColorDictionary[MapColorObject.GridLines]);
                pen.Width = 1;
                    
                foreach (var lot in parameters.SaveFile.GetLotSubfile().Lots)
                {
                    Rectangle rect = new Rectangle();

                    Color c = new Color();
                    switch (lot.ZoneType)
                    {
                        case SC4Parser.Constants.LOT_ZONE_TYPE_RESIDENTIAL_LOW:
                            c = parameters.ColorDictionary[MapColorObject.ResidentialLow];
                            break;

                        case SC4Parser.Constants.LOT_ZONE_TYPE_RESIDENTIAL_MEDIUM:
                            c = parameters.ColorDictionary[MapColorObject.ResidentialMid];
                            break;

                        case SC4Parser.Constants.LOT_ZONE_TYPE_RESIDENTIAL_HIGH:
                            c = parameters.ColorDictionary[MapColorObject.ResidentialHigh];
                            break;

                        case SC4Parser.Constants.LOT_ZONE_TYPE_COMMERCIAL_LOW:
                            c = parameters.ColorDictionary[MapColorObject.CommercialLow];
                            break;

                        case SC4Parser.Constants.LOT_ZONE_TYPE_COMMERCIAL_MEDIUM:
                            c = parameters.ColorDictionary[MapColorObject.CommercialMid];
                            break;

                        case SC4Parser.Constants.LOT_ZONE_TYPE_COMMERCIAL_HIGH:
                            c = parameters.ColorDictionary[MapColorObject.CommercialHigh];
                            break;

                        case SC4Parser.Constants.LOT_ZONE_TYPE_INDUSTRIAL_LOW:
                            c = parameters.ColorDictionary[MapColorObject.IndustrialLow];
                            break;

                        case SC4Parser.Constants.LOT_ZONE_TYPE_INDUSTRIAL_MEDIUM:
                            c = parameters.ColorDictionary[MapColorObject.IndustrialMid];
                            break;

                        case SC4Parser.Constants.LOT_ZONE_TYPE_INDUSTRIAL_HIGH:
                            c = parameters.ColorDictionary[MapColorObject.IndustrialHigh];
                            break;

                        case SC4Parser.Constants.LOT_ZONE_TYPE_PLOPPED_BUILDING:
                            c = parameters.ColorDictionary[MapColorObject.Building];
                            break;
                    }

                    switch (lot.Orientation)
                    {
                        case Constants.ORIENTATION_NORTH:
                        case Constants.ORIENTATION_SOUTH:
                            rect = new Rectangle(
                                (parameters.GridSegmentSize * lot.MinTileX) + parameters.SegmentOffsetX,
                                (parameters.GridSegmentSize * lot.MinTileZ) + parameters.SegmentOffsetY,
                                (parameters.GridSegmentSize * lot.SizeX) - parameters.SegmentPaddingX,
                                (parameters.GridSegmentSize * lot.SizeZ) - parameters.SegmentPaddingY);
                            break;

                        case Constants.ORIENTATION_WEST:
                        case Constants.ORIENTATION_EAST:
                            rect = new Rectangle(
                                (parameters.GridSegmentSize * lot.MinTileX) + parameters.SegmentOffsetX,
                                (parameters.GridSegmentSize * lot.MinTileZ) + parameters.SegmentOffsetY,
                                (parameters.GridSegmentSize * lot.SizeZ) - parameters.SegmentPaddingX,
                                (parameters.GridSegmentSize * lot.SizeX) - parameters.SegmentPaddingY);


                            break;

                    }

                    g.FillRectangle(new SolidBrush(c), rect);
                    //g.DrawRectangle(pen, rect);
                }

                if (parameters.ShowGridLines)
                {
                    for (int y = 0; y < parameters.GridSizeY; ++y)
                    {
                        g.DrawLine(pen, 0, y * parameters.GridSegmentSize, parameters.GridSizeY * parameters.GridSegmentSize, y * parameters.GridSegmentSize);
                    }

                    for (int x = 0; x < parameters.GridSizeX; ++x)
                    {
                        g.DrawLine(pen, x * parameters.GridSegmentSize, 0, x * parameters.GridSegmentSize, parameters.GridSizeY * parameters.GridSegmentSize);
                    }
                }

            }

            return bmp;
                
        }
    }
}
