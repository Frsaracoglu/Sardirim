using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer
{
    public class Rezervasyon
    {
        public int getByClientIdFromReservation(int tableId)
        {
            DataLayer.Rezervasyon MusteriBul = new DataLayer.Rezervasyon();
            return MusteriBul.getByClientIdFromReservation(tableId);
        }
        public void reservationClose(int CheckID)
        {
            DataLayer.Rezervasyon RezervasyonKapa = new DataLayer.Rezervasyon();
            return RezervasyonKapa.reservationClose(CheckID);
        }
    }
}
