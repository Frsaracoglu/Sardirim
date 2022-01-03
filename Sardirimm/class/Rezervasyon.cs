using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Sardirimm
{
    class Rezervasyon
    {
        General gnl = new General();
        private int _ID;
        private int _TableId;
        private int _ClientId;
        private DateTime _Date;
        private int _CleintCount;
        private string _Description;
        private int _AdditionId;

        public int ID { get => _ID; set => _ID = value; }
        public int TableId { get => _TableId; set => _TableId = value; }
        public int ClientId { get => _ClientId; set => _ClientId = value; }
        public DateTime Date { get => _Date; set => _Date = value; }
        public int CleintCount { get => _CleintCount; set => _CleintCount = value; }
        public string Description { get => _Description; set => _Description = value; }
        public int AdditionId { get => _AdditionId; set => _AdditionId = value; }

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
            //bool result = false;
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
