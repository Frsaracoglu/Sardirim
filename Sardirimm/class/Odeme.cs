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

    class Odeme
    {
        General gnl = new General();

        #region Fields
        private int _ID;
        private int _CheckID;
        private int _PaymentTypeID;
        private decimal _SubTotal;
        private decimal _Discount;
        private decimal _KDV;
        private decimal _LastTotal;
        private DateTime _Date;
        private int _CustomerID;

        public int ID { get => _ID; set => _ID = value; }
        public int CheckID { get => _CheckID; set => _CheckID = value; }
        public int PaymentTypeID { get => _PaymentTypeID; set => _PaymentTypeID = value; }
        public decimal SubTotal { get => _SubTotal; set => _SubTotal = value; }
        public decimal Discount { get => _Discount; set => _Discount = value; }
        public decimal KDV { get => _KDV; set => _KDV = value; }
        public decimal LastTotal { get => _LastTotal; set => _LastTotal = value; }
        public DateTime Date { get => _Date; set => _Date = value; }
        public int CustomerID { get => _CustomerID; set => _CustomerID = value; }
        #endregion




        public bool billClose(Odeme bill)
        {
            General gnl = new General();
            bool result = false;
            SqlConnection connection = new SqlConnection(gnl.conString);
            SqlCommand command = new SqlCommand("Insert Into CheckPayments(CheckID,PaymentTypeID,CustomerID,SubTotal,KDV,LastTotal,Discount) values(@CheckID,@PaymentTypeID,@CustomerID,@SubTotal,@KDV,@LastTotal,@Discount)", connection);

            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                command.Parameters.Add("CheckID", SqlDbType.Int).Value = bill.CheckID;
                command.Parameters.Add("PaymentTypeID", SqlDbType.Int).Value = bill.PaymentTypeID;
                command.Parameters.Add("CustomerID", SqlDbType.Int).Value = bill.CustomerID;
                command.Parameters.Add("SubTotal", SqlDbType.Money).Value = bill.SubTotal;
                command.Parameters.Add("KDV", SqlDbType.Money).Value = bill.KDV;
                command.Parameters.Add("Discount", SqlDbType.Money).Value = bill.Discount;
                command.Parameters.Add("LastTotal", SqlDbType.Money).Value = bill.LastTotal;

                result = Convert.ToBoolean(command.ExecuteNonQuery());

            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
                throw;
            }
            finally
            {
                connection.Dispose();
                connection.Close();
            }
            return result;
        }

        public decimal sumTotalforClientId(int clientId)
        {
            decimal total = 0;
            SqlConnection connection = new SqlConnection(gnl.conString);
            SqlCommand command = new SqlCommand("Select sum(LastTotal) as total from CheckPayments Where CustomerID=@clientId", connection);
            try
            {
                if (connection.State==ConnectionState.Closed)
                {
                    connection.Open();
                }
                command.Parameters.Add("clientId", SqlDbType.Int).Value = clientId;
                total = Convert.ToDecimal(command.ExecuteScalar());
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
                throw;
            }
            finally
            {
                connection.Dispose();
                connection.Close();
            }
            
            return total;
        }
    }
}
