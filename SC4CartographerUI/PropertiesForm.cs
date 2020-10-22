using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SC4CartographerUI
{
    public partial class PropertiesForm : Form
    {
        private MapCreationParameters parameters = new MapCreationParameters();

        public PropertiesForm(MapCreationParameters p)
        {
            InitializeComponent();

            parameters = p;
        }

        private void SetValuesUsingProperties()
        {

        }
        private void GetProperitesFromValues()
        {

        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            int i = 2;
        }
    }
}
