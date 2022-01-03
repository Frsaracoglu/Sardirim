using Entity;
using System;
using System.Collections.Generic;
using System.Text;
using DataLayer;

namespace BussinessLayer
{
    public class Check
    {
        public int getByAddition(int TableID)
        {
            DataLayer.Check Hesap = new DataLayer.Check();
            return Hesap.getByAddition(TableID);
        }
        public bool setByAdditionNew(Check Bilgiler)
        {
            DataLayer.Check Addition = new DataLayer.Check();
            return Addition.setByAdditionNew(Bilgiler);
        }
        public bool CheckClose(int CheckID, int status)
        {
            DataLayer.Check cc = new DataLayer.Check();
            return cc.CheckClose(CheckID, status);
        }

    }
}
