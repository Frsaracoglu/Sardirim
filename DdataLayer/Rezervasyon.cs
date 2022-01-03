using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DataLayer
{
    public class Rezervasyon
    {
        General gnl = new General();

        public int getByClientIdFromReservation(int tableId)
        {
            int clientId = 0;


            SqlConnection connection = new SqlConnection(gnl.conString);
            SqlCommand command = new SqlCommand("Select top 1 CustomerID from Reservation where TableID=tableId order by CustomerID Desc@", connection);

            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                command.Parameters.Add("tableId", SqlDbType.Int).Value = tableId;


                clientId = Convert.ToInt32(command.ExecuteNonQuery());

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
            return clientId;
        }
        public void reservationClose(int CheckID)
        {
            SqlConnection connection = new SqlConnection(gnl.conString);
            SqlCommand command = new SqlCommand("Update Reservation set status=0 where CheckID=@additionId", connection);
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                command.Parameters.Add("additionId", SqlDbType.Int).Value = CheckID;
                command.ExecuteNonQuery();
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

        }
    }
}
