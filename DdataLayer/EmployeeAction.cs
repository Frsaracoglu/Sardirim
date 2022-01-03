using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DataLayer
{
    public class EmployeeAction
    {
        General gnl = new General();
        public bool EmployeesActionSave(EmployeeAction ea)
        {

            bool result = false;
            SqlConnection connection = new SqlConnection(gnl.conString);
            SqlCommand command = new SqlCommand("Insert Into employeesAction(EmployeesID,Action,Date)Values(@employeesID,@action,@date)", connection);

            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                command.Parameters.Add("@employeesID", SqlDbType.Int).Value = ea._EmplooyeesID;
                command.Parameters.Add("@action", SqlDbType.VarChar).Value = ea._Action;
                command.Parameters.Add("@date", SqlDbType.DateTime).Value = ea._Date;

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
