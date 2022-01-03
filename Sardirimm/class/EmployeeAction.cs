using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sardirimm
{
    class EmployeeAction
    {
        General gnl = new General();
        private int _ID;
        private int _EmplooyeesID;
        private int _Action;
        private DateTime _Date;
        private bool _Status;

        public int ID { get => _ID; set => _ID = value; }
        public int EmplooyeesID { get => _EmplooyeesID; set => _EmplooyeesID = value; }
        public int Action { get => _Action; set => _Action = value; }
        public DateTime Date { get => _Date; set => _Date = value; }
        public bool Status { get => _Status; set => _Status = value; }


        public bool EmployeesActionSave(EmployeeAction ea)
        {
            bool result = false;
            SqlConnection connection = new SqlConnection(gnl.conString);
            SqlCommand command = new SqlCommand("Insert Into employeesAction(EmployeesID,Action,Date)Values(@employeesID,@action,@date)",connection);

            try
            {
                if (connection.State==ConnectionState.Closed)
                {
                    connection.Open();
                }

                command.Parameters.Add("@employeesID", SqlDbType.Int).Value = ea._EmplooyeesID;
                command.Parameters.Add("@action", SqlDbType.VarChar).Value =ea._Action;
                command.Parameters.Add("@date", SqlDbType.DateTime).Value =ea._Date;

                result = Convert.ToBoolean(command.ExecuteNonQuery());

            }
            catch (SqlException ex)
            {
                string error = ex.Message;
                throw;
            }
            return result;
        }
    }
}
