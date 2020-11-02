using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SC4CartographerUI
{
    public enum Layers
    {
        Lot,
        Building
    }

    public class MapOptions
    {
        public string SavegamePath = "";
        public int GridSegmentSize = 5;
        public int GridSegmentSizePadding = 2;
        public int GridSegmentPositionPadding = 4;
        public bool ShowGrid = false;
        public Color ResidentialHighColor = Color.FromArgb(0, 126, 47);
        public Color ResidentialMediumColor = Color.FromArgb(2, 207, 79);
        public Color ResidentialLowColor = Color.FromArgb(4, 255, 98);
        public Color CommercialHighColor = Color.FromArgb(4, 1, 128);
        public Color CommercialMediumColor = Color.FromArgb(1, 93, 188);
        public Color CommercialLowColor = Color.FromArgb(0, 126, 255);
        public Color IndustrialHighColor = Color.FromArgb(103, 103, 22);
        public Color IndustrialMediumColor = Color.FromArgb(129, 129, 43);
        public Color IndustrialLowColor = Color.FromArgb(180, 180, 46);
        public List<Layers> SelectedLayers = new List<Layers>();
    }
}
