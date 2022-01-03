using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer
{
    public class Tables
    {
        public string Summary(int state, string tableID)
        {
            DataLayer.Tables ozet = new DataLayer.Tables();
            return ozet.Summary(state, tableID);
        }
        public int TableGetbyNumber(string TableValue)
        {
            string tblValue = TableValue;
            int lenght = tblValue.Length;

            if (lenght > 8)
            {
                return Convert.ToInt32(tblValue.Substring(lenght - 2, 2));
            }
            else
            {
                return Convert.ToInt32(tblValue.Substring(lenght - 1, 1));
            }

            DataLayer.Tables MasaNo = new DataLayer.Tables();
            return MasaNo.TableGetbyNumber(TableValue);
        }

        public bool TableGetbyState(int ButtonName, int state)
        {
            DataLayer.Tables MasaDurum = new DataLayer.Tables();
            return MasaDurum.TableGetbyState(ButtonName, state);
        }

        public void setChangeTableState(string buttonName, int state)
        {
            DataLayer.Tables MasaDurumDegistir = new DataLayer.Tables();
            return MasaDurumDegistir.setChangeTableState(buttonName, state);
        }


        public int TableGetbyNumber(string TableValue)
        {
            string tblValue = TableValue;
            int lenght = tblValue.Length;

            if (lenght > 8)
            {
                return Convert.ToInt32(tblValue.Substring(lenght - 2, 2));
            }
            else
            {
                return Convert.ToInt32(tblValue.Substring(lenght - 1, 1));
            }
        }
    }
}
