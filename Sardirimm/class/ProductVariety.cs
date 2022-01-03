using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sardirimm
{
    class ProductVariety
    {
        General gnl = new General();
        private int ProductTypeNo;
        private int CategoryName;
        private int Explanation;

        public int ProductTypeNo1 { get => ProductTypeNo; set => ProductTypeNo = value; }
        public int CategoryName1 { get => CategoryName; set => CategoryName = value; }
        public int Explanation1 { get => Explanation; set => Explanation = value; }

        public void getByProductTypes(ListView Kalemler, Button btn)
        {
            Kalemler.Items.Clear();
            SqlConnection connection = new SqlConnection(gnl.conString);
            SqlCommand command = new SqlCommand("Select ProductName,Price,Products.ID From categories Inner Join Products on categories.ID=Products.CategoryID where Products.CategoryID=@CategoryID", connection);

            string xx = btn.Name;
            int uzunluk = xx.Length;

            command.Parameters.Add("@CATEGORYID", SqlDbType.Int).Value = xx.Substring(uzunluk - 1, 1);
            if (connection.State==ConnectionState.Closed)
            {
                connection.Open();
            }
            SqlDataReader dataReader = command.ExecuteReader();
            int i = 0;
            while (dataReader.Read())
            {
                Kalemler.Items.Add(dataReader["ProductName"].ToString());
                Kalemler.Items[i].SubItems.Add(dataReader["Price"].ToString());
                Kalemler.Items[i].SubItems.Add(dataReader["ID"].ToString());
                i++;
            }
        }
    }
}
