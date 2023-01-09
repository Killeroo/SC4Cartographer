using System;
using System.Drawing;

namespace SC4CartographerUI.SC4Cartographer
{
    public class RegionConfig
    {

        public void Load(string path)
        {
            using (Bitmap image = new Bitmap(path))
            {
                for (int i = 0; i < image.Width; i++)
                {
                    for (int j = 0; j < image.Height; j++)
                    {
                        Color pixel = image.GetPixel(i, j);
                        // TODO: It's laid out with coords in region view + 1 as the coord
                    }
                }
            }
        }
    }
}
