using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Sardirimm
{
    class Siparis
    {
        General gnl = new General();
        private int _ID;
        private int _CheckID;
        private int _ProductID;
        private int _TableID;
        private int _Amount;

        public int ID { get => _ID; set => _ID = value; }
        public int CheckID { get => _CheckID; set => _CheckID = value; }
        public int ProductID { get => _ProductID; set => _ProductID = value; }
        public int TableID { get => _TableID; set => _TableID = value; }
        public int Amount { get => _Amount; set => _Amount = value; }


        public void getByOrder(ListView lv, int CheckID)
        {
            SqlConnection connection = new SqlConnection(gnl.conString);
            SqlCommand command = new SqlCommand("Select ProductName,PRICE,Sales.ID,PRODUCTID,sales.AMOUNT from sales Inner Join products on Sales.PRODUCTID=Products.ID Where CHECKID=@CheckID", connection);
            SqlDataReader dataReader = null;
            command.Parameters.Add("@CheckID", SqlDbType.Int).Value = CheckID;
            try
            {
                if (connection.State==ConnectionState.Closed)
                {
                    connection.Open();
                }
                dataReader = command.ExecuteReader();
                int sayac = 0;
                while (dataReader.Read())
                {
                    lv.Items.Add(dataReader["PRODUCTNAME"].ToString());
                    lv.Items[sayac].SubItems.Add(dataReader["AMOUNT"].ToString());
                    lv.Items[sayac].SubItems.Add(dataReader["PRODUCTID"].ToString());
                    lv.Items[sayac].SubItems.Add(Convert.ToString(Convert.ToDecimal(dataReader["PRICE"]) * Convert.ToDecimal(dataReader["AMOUNT"])));
                    lv.Items[sayac].SubItems.Add(dataReader["ID"].ToString());

                    sayac++;
                }
            }
            catch (SqlException ex)
            {

                string hata = ex.Message;
            }
            finally
            {
                dataReader.Close();
                connection.Dispose();
                connection.Close();
            }
        }
        public bool setSaveOrder(Siparis Bilgiler)
        {
            bool sonuc = false;

            SqlConnection connection = new SqlConnection(gnl.conString);
            SqlCommand command = new SqlCommand("Insert Into Sales(CheckID,ProductID,Amount,TableID) values(@CheckNo,@ProductId,@Amount,@tableID)",connection);
            try
            {
                if(connection.State==ConnectionState.Closed)
                {
                    connection.Open();
                }
                command.Parameters.Add("@CheckNo", SqlDbType.Int).Value = Bilgiler.CheckID;
                command.Parameters.Add("@ProductId", SqlDbType.Int).Value = Bilgiler.ProductID;
                command.Parameters.Add("@Amount", SqlDbType.Int).Value = Bilgiler.Amount;
                command.Parameters.Add("@tableId", SqlDbType.Int).Value = Bilgiler.TableID;
                sonuc = Convert.ToBoolean(command.ExecuteNonQuery());
            }
            catch (SqlException ex)
            {

                string hata = ex.Message;
            }
            finally 
            {
                connection.Dispose();
                connection.Close();
            }
            return sonuc;
        }

        public void setDeleteOrder(int salesID)
        {
            SqlConnection connection = new SqlConnection(gnl.conString);
            SqlCommand command = new SqlCommand("Delete From Sales Where ID=@SalesID", connection);

            command.Parameters.Add("@SalesID", SqlDbType.Int).Value = salesID;

            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            command.ExecuteNonQuery();
            connection.Dispose();
            connection.Close();
        }
    }
}
