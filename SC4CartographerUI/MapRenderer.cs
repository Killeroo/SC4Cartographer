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
            // Get map parameters based on city size
            int GridSizeX = 0;
            int GridSizeY = 0;
            switch (parameters.SaveFile.GetRegionViewSubfile().CitySizeX)
            {
                case 4: // Large map
                    GridSizeX = 256;
                    GridSizeY = 256;
                    break;
                case 2: // Medium map
                    GridSizeX = 128;
                    GridSizeY = 128;
                    break;
                case 1: // Small map
                    GridSizeX = 64;
                    GridSizeY = 64;
                    break;
                default:
                    GridSizeX = 256;
                    GridSizeY = 256;
                    break;
            }

            Bitmap bmp = new Bitmap(
                GridSizeX * parameters.GridSegmentSize + 1, 
                GridSizeY * parameters.GridSegmentSize + 1);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(parameters.ColorDictionary[MapColorObject.Background]);
                Pen zoneOutlinePen = new Pen(parameters.ColorDictionary[MapColorObject.ZoneOutline]);
                Pen gridLinesPen = new Pen(parameters.ColorDictionary[MapColorObject.GridLines]);
                gridLinesPen.Width = 1;
                zoneOutlinePen.Width = 1;
                    
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

                        case SC4Parser.Constants.LOT_ZONE_TYPE_MILITARY:
                            c = parameters.ColorDictionary[MapColorObject.Military];
                            break;

                        case SC4Parser.Constants.LOT_ZONE_TYPE_AIRPORT:
                            c = parameters.ColorDictionary[MapColorObject.Airport];
                            break;

                        case SC4Parser.Constants.LOT_ZONE_TYPE_SEAPORT:
                            c = parameters.ColorDictionary[MapColorObject.Seaport];
                            break;

                        case SC4Parser.Constants.LOT_ZONE_TYPE_SPACEPORT:
                            c = parameters.ColorDictionary[MapColorObject.Spaceport];
                            break;

                        case SC4Parser.Constants.LOT_ZONE_TYPE_PLOPPED_BUILDING:
                            c = parameters.ColorDictionary[MapColorObject.PloppedBuilding];
                            break;
                        case SC4Parser.Constants.LOT_ZONE_TYPE_PLOPPED_BUILDING_ALT:
                            c = parameters.ColorDictionary[MapColorObject.Military];
                            break;
                        default:
                            c = parameters.ColorDictionary[MapColorObject.PloppedBuilding];
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

                    if (parameters.ShowZoneOutlines)
                    {
                        g.DrawRectangle(zoneOutlinePen, rect);
                    }
                }

                if (parameters.ShowGridLines)
                {
                    for (int y = 0; y < GridSizeY; ++y)
                    {
                        g.DrawLine(gridLinesPen, 0, y * parameters.GridSegmentSize, GridSizeY * parameters.GridSegmentSize, y * parameters.GridSegmentSize);
                    }

                    for (int x = 0; x < GridSizeX; ++x)
                    {
                        g.DrawLine(gridLinesPen, x * parameters.GridSegmentSize, 0, x * parameters.GridSegmentSize, GridSizeY * parameters.GridSegmentSize);
                    }
                }

            }

            return bmp;
                
        }
    }
}
