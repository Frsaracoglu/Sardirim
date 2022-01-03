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
    class Tables
    {
        private int _ID;
        private int _Capacity;
        private int _ServisType;
        private int _Status;
        private int _Confirmation;

        public int ID { get => _ID; set => _ID = value; }
        public int Capacity { get => _Capacity; set => _Capacity = value; }
        public int ServisType { get => _ServisType; set => _ServisType = value; }
        public int Status { get => _Status; set => _Status = value; }
        public int Confirmation { get => _Confirmation; set => _Confirmation = value; }

        General gnl = new General();
        public string Summary(int state,string tableID)
        {
            string dt = "";
            SqlConnection connection = new SqlConnection(gnl.conString);
            SqlCommand command = new SqlCommand("Select Date,TableID from Check Right Join Tables on Check.TableID=Tables.ID Where Tables.Status=@status and Check.Status=0 and Tables.ID=@tableID", connection);
            SqlDataReader dataReader = null;
            command.Parameters.Add("@status", SqlDbType.Int).Value = state;
            command.Parameters.Add("@tableID", SqlDbType.Int).Value = Convert.ToInt32(tableID);

            try 
            {
                if (connection.State==ConnectionState.Closed)
                {
                    connection.Open();
                }
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    dt = Convert.ToDateTime(dataReader["Date"]).ToString();
                }
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
                throw;
            }
            finally
            {
                dataReader.Close();
                connection.Dispose();
                connection.Close();
            }
            return dt;
        }

        public int TableGetbyNumber (string TableValue)
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

        public bool TableGetbyState(int ButtonName, int state)
        {
            bool result = false;
            SqlConnection connection = new SqlConnection(gnl.conString);
            SqlCommand command = new SqlCommand("Select status From Tables Where Id=@TableId and STATUS=@state", connection);

            command.Parameters.Add("@TableId", SqlDbType.Int).Value = ButtonName;
            command.Parameters.Add("@state", SqlDbType.Int).Value = state;
            try
            {
                if (connection.State==ConnectionState.Closed)
                {
                    connection.Open();
                }
                result = Convert.ToBoolean(command.ExecuteScalar());
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
            return result;
        }

        public void setChangeTableState(string buttonName, int state)
        {
            SqlConnection connection = new SqlConnection(gnl.conString);
            SqlCommand command = new SqlCommand("Update tables Set Status=@Status where ID=@TableNo", connection);
            string tableNo = "";
            if (connection.State==ConnectionState.Closed)
            {
                connection.Open();
            }
            string xx = buttonName;
            int uzunluk = xx.Length;
            command.Parameters.Add("@Status", SqlDbType.Int).Value = state;
            if (uzunluk>8)
            {
                tableNo = xx.Substring(uzunluk -2, 2);
            }
            else
            {
                tableNo = xx.Substring(uzunluk - 1, 1);
            }
            
            command.Parameters.Add("@tableNo", SqlDbType.Int).Value = tableNo;
            command.ExecuteNonQuery();
            connection.Dispose();
            connection.Close();
        }
    }
   
}
