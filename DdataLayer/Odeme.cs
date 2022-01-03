using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DataLayer
{
    public class Odeme
    {
        General gnl = new General();

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
                if (connection.State == ConnectionState.Closed)
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
