using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

using SC4Parser;
using SC4Parser.SubFiles;

namespace SC4CartographerUI
{
    class Map
    {
        public static readonly Color BACKGROUND_COLOR = Color.FromArgb(64, 64, 64);
        public static readonly Color INTERNAL_GRID_COLOR = Color.FromArgb(32, 32, 95);
        public static readonly Color BUILDING_COLOR = Color.FromArgb(121, 121, 121);
        
        public static readonly Color RESIDENTIAL_HIGH_COLOR = Color.FromArgb(0, 126, 47);
        public static readonly Color RESIDENTIAL_MEDIUM_COLOR = Color.FromArgb(2, 207, 79);
        public static readonly Color RESIDENTIAL_LOW_COLOR = Color.FromArgb(4, 255, 98);
        public static readonly Color COMMERCIAL_HIGH_COLOR = Color.FromArgb(4, 1, 128);
        public static readonly Color COMMERCIAL_MEDIUM_COLOR = Color.FromArgb(1, 93, 188);
        public static readonly Color COMMERCIAL_LOW_COLOR = Color.FromArgb(0, 126, 255);
        public static readonly Color INDUSTRIAL_HIGH_COLOR = Color.FromArgb(103, 103, 22);
        public static readonly Color INDUSTRIAL_MEDIUM_COLOR = Color.FromArgb(129, 129, 43);
        public static readonly Color INDUSTRIAL_LOW_COLOR = Color.FromArgb(180, 180, 46);

        public static Bitmap CreateBitmapFromLot(int maxXCells, int maxYCells, int boxSize, LotSubFile lots)
        {
            Bitmap bmp = new Bitmap(maxXCells * boxSize + 1, maxYCells * boxSize + 1);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(BACKGROUND_COLOR);
                Pen pen = new Pen(INTERNAL_GRID_COLOR);
                pen.Width = 1;
                    
                foreach (var lot in lots.Lots)
                {
                    Rectangle rect = new Rectangle();

                    Color c = new Color();
                    switch (lot.ZoneType)
                    {
                        case SC4Parser.Constants.LOT_ZONE_TYPE_RESIDENTIAL_LOW:
                            c = RESIDENTIAL_LOW_COLOR;
                            break;

                        case SC4Parser.Constants.LOT_ZONE_TYPE_RESIDENTIAL_MEDIUM:
                            c = RESIDENTIAL_MEDIUM_COLOR;
                            break;

                        case SC4Parser.Constants.LOT_ZONE_TYPE_RESIDENTIAL_HIGH:
                            c = RESIDENTIAL_HIGH_COLOR;
                            break;

                        case SC4Parser.Constants.LOT_ZONE_TYPE_COMMERCIAL_LOW:
                            c = COMMERCIAL_HIGH_COLOR;
                            break;

                        case SC4Parser.Constants.LOT_ZONE_TYPE_COMMERCIAL_MEDIUM:
                            c = COMMERCIAL_MEDIUM_COLOR;
                            break;

                        case SC4Parser.Constants.LOT_ZONE_TYPE_COMMERCIAL_HIGH:
                            c = COMMERCIAL_LOW_COLOR;
                            break;

                        case SC4Parser.Constants.LOT_ZONE_TYPE_INDUSTRIAL_LOW:
                            c = INDUSTRIAL_LOW_COLOR;
                            break;

                        case SC4Parser.Constants.LOT_ZONE_TYPE_INDUSTRIAL_MEDIUM:
                            c = INDUSTRIAL_MEDIUM_COLOR;
                            break;

                        case SC4Parser.Constants.LOT_ZONE_TYPE_INDUSTRIAL_HIGH:
                            c = INDUSTRIAL_HIGH_COLOR;
                            break;

                        case SC4Parser.Constants.LOT_ZONE_TYPE_PLOPPED_BUILDING:
                            c = BUILDING_COLOR;
                            break;
                    }

                    switch (lot.Orientation)
                    {
                        case Constants.ORIENTATION_NORTH:
                        case Constants.ORIENTATION_SOUTH:
                            rect = new Rectangle((boxSize * lot.MinTileX) + 2, (boxSize * lot.MinTileZ) + 2, (boxSize * lot.SizeX) - 4, (boxSize * lot.SizeZ) - 4);
                            break;

                        case Constants.ORIENTATION_WEST:
                        case Constants.ORIENTATION_EAST:
                            rect = new Rectangle((boxSize * lot.MinTileX) + 2, (boxSize * lot.MinTileZ) + 2, (boxSize * lot.SizeZ) - 4, (boxSize * lot.SizeX) - 4);


                            break;

                    }

                    g.FillRectangle(new SolidBrush(c), rect);
                }

            }

            return bmp;
                
        }
    }
}
