using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Entity;

namespace DataLayer
{
    public class Siparis
    {
        General gnl = new General();

        public List<SalesModel> getByOrder(int CheckID)

        {
            List<SalesModel> result = new List<SalesModel>();
            SqlConnection connection = new SqlConnection(gnl.conString);
            SqlCommand command = new SqlCommand("Select ProductName,Price,Sales.ID,ProductID,Sales.Amount from Sales Inner Join products on Sales.PRODUCTID=Products.ID Where CHECKID=@CheckID", connection);
            SqlDataReader dataReader = null;
            command.Parameters.Add("@CheckID", SqlDbType.Int).Value = CheckID;
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                dataReader = command.ExecuteReader();
                int sayac = 0;
                while (dataReader.Read())
                {
                    SalesModel model = new SalesModel();
                    model.Id = Convert.ToInt32(dataReader["ID"]);
                    model.TotalAmount = Convert.ToDecimal(dataReader["Price"]) * Convert.ToDecimal(dataReader["AMOUNT"]);
                    model.ProductName = Convert.ToString(dataReader["ProductName"]);
                    model.Amount = Convert.ToDecimal(dataReader["Amount"]);
                    model.Price = Convert.ToDecimal(dataReader["Price"]);
                    model.ProductId = Convert.ToInt32(dataReader["ProductID"]);

                    
                    result.Add(model);

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

            return result;
        }
        public bool setSaveOrder(Siparis Bilgiler)
        {
            bool sonuc = false;

            SqlConnection connection = new SqlConnection(gnl.conString);
            SqlCommand command = new SqlCommand("Insert Into Sales(CheckID,ProductID,Amount,TableID) values(@CheckNo,@ProductId,@Amount,@tableID)", connection);
            try
            {
                if (connection.State == ConnectionState.Closed)
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
