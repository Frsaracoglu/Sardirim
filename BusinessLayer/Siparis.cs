using System;
using System.Collections.Generic;
using System.Text;
using Entity;

namespace BussinessLayer
{
    public class BLSiparis
    {
        public List<SalesModel> getByOrder(int CheckID)
        {
            DataLayer.Siparis siparis = new DataLayer.Siparis();
            return siparis.getByOrder(CheckID);
        }

        public bool setSaveOrder(Siparis Bilgiler)
        {
            DataLayer.Siparis SiparisKayıt = new DataLayer.Siparis();
            return SiparisKayıt.setSaveOrder(Bilgiler);
        }
    }
}
