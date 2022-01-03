using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer
{
    public class Musteriler
    {
        public bool MusteriVarMi(string tlf)
        {
            DataLayer.Musteriler mv = new DataLayer.Musteriler();
            return mv.MusteriVarMi(tlf);
        }
    }
}
