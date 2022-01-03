using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace BussinessLayer
{
    public class ProductVariety
    {
        public void getByProductTypes(ListView Kalemler, Button btn)
        {
            DataLayer.ProductVariety UrunCesitleri = new DataLayer.ProductVariety();
            return UrunCesitleri.getByProductTypes(Kalemler, btn);
        }
    }
}
