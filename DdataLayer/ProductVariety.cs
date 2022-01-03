using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace DataLayer
{
    public class ProductVariety
    {
        General gnl = new General();
        public void getByProductTypes(ListView Kalemler, Button btn)
        {
            Kalemler.Items.Clear();
            SqlConnection connection = new SqlConnection(gnl.conString);
            SqlCommand command = new SqlCommand("Select ProductName,Price,Products.ID From categories Inner Join Products on categories.ID=Products.CategoryID where Products.CategoryID=@CategoryID", connection);

            string xx = btn.Name;
            int uzunluk = xx.Length;

            command.Parameters.Add("@CATEGORYID", SqlDbType.Int).Value = xx.Substring(uzunluk - 1, 1);
            if (connection.State == ConnectionState.Closed)
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
