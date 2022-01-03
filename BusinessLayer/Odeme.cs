using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer
{
    public class Odeme
    {

        public bool billClose(Odeme bill)
        {
            DataLayer.Odeme HesapKapa = new DataLayer.Odeme();
            return HesapKapa.billClose(bill);
        }
        public decimal sumTotalforClientId(int clientId)
        {
            DataLayer.Odeme Tutar = new DataLayer.Odeme();
            return Tutar.sumTotalforClientId(clientId);
        }
    }
}
