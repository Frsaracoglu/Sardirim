using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace Sardirimm
{
    class General
    {
        public string conString = ("Server=.;Database=Sardirimm;Trusted_Connection=True");
        public static int _Id;
        public static int _TitleId;
        public static int _musteriEkleme;

        public static string ButtonValue;
        public static string ButtonName;
        public static int _ServisTypeNo;
        public static string _AdisyonId;
    }
}
