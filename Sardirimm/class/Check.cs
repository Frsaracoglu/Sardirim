using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Sardirimm
{
    class Check
    {
        General gnl = new General();

        private int _ID;
        private int _ServiceTypeNo;
        private int _EmployeeID;
        private int _Amount;
        private int _Date;
        private int _TableID;
        private int _Status;

        public int ID { get => _ID; set => _ID = value; }
        public int ServiceTypeNo { get => _ServiceTypeNo; set => _ServiceTypeNo = value; }
        public int EmployeeID { get => _EmployeeID; set => _EmployeeID = value; }
        public int Amount { get => _Amount; set => _Amount = value; }
        public int Date { get => _Date; set => _Date = value; }
        public int TableID { get => _TableID; set => _TableID = value; }
        public int Status { get => _Status; set => _Status = value; }


        public int GetByAddition(int TableID)
        {
            SqlConnection connection = new SqlConnection(gnl.conString);
            SqlCommand command = new SqlCommand("Select top 1 ID From Check Where TABLEID=@TableID Order by ID dec", connection);

            command.Parameters.Add("@TableID", SqlDbType.Int).Value = TableID;
            try
            {
                if (connection.State==ConnectionState.Closed)
                {
                    connection.Open();
                }
                TableID = Convert.ToInt32(command.ExecuteScalar());
            }
            catch (SqlException ex)
            {

                string hata = ex.Message;
            }
            finally 
            {
                connection.Close();
            }
            return TableID;
        }
        public bool setByAdditionNew(Check Bilgiler)
        {
            bool sonuc = false;
            SqlConnection connection = new SqlConnection(gnl.conString);
            SqlCommand command = new SqlCommand("Insert Into Check(ServiceTypeNo,Date,EmployeeID,TableID,Status) values(@ServiceTypeNo,@Date,@EmployeeID,@TableID,@Status)", connection);
            try
            {
                if (connection.State==ConnectionState.Closed)
                {
                    connection.Open();
                }

                command.Parameters.Add("@ServiceTypeNo", SqlDbType.Int).Value = Bilgiler.ServiceTypeNo;
                command.Parameters.Add("@Date", SqlDbType.DateTime).Value = Bilgiler.Date;
                command.Parameters.Add("@EmployeeID", SqlDbType.Int).Value = Bilgiler.EmployeeID;
                command.Parameters.Add("@TableID", SqlDbType.Int).Value = Bilgiler.TableID;
                command.Parameters.Add("@Status", SqlDbType.Bit).Value = 0;
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
        public bool CheckClose(int CheckID, int status)
        {
            bool result = false;
            SqlConnection connection = new SqlConnection(gnl.conString);
            SqlCommand command = new SqlCommand("Update Check set status=@status where ID=@additionId", connection);
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                command.Parameters.Add("additionId", SqlDbType.Int).Value = CheckID;
                command.Parameters.Add("status", SqlDbType.Int).Value = status;
                result = Convert.ToBoolean(command.ExecuteScalar());
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
    }
}
