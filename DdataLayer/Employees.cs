using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;
using Entity;

namespace DataLayer
{
    public class Employees
    {
        General gnl = new General();
        public bool EmployeesEntryControl(string password, int UserId)
        {
            bool result = false;

            SqlConnection connection = new SqlConnection(gnl.conString);
            SqlCommand command = new SqlCommand("Select * from Employees where ID=@Id and Password=@password", connection);
            command.Parameters.Add("@Id", SqlDbType.VarChar).Value = UserId;
            command.Parameters.Add("@Password", SqlDbType.VarChar).Value = password;

            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                result = Convert.ToBoolean(command.ExecuteScalar());


            }
            catch (SqlException ex)
            {
                string error = ex.Message;
                throw;
            }

            return true;
        }

        public void EmployeesGetbyInformation(ComboBox cb)
        {
            cb.Items.Clear();
            SqlConnection connection = new SqlConnection(gnl.conString);
            SqlCommand command = new SqlCommand("Select * from Employees", connection);

            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            SqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                Employees e = new Employees();
                e.ID = Convert.ToInt32(dataReader["ID"]);
                e.TitleID = Convert.ToInt32(dataReader["TitleID"]);
                e.Name = Convert.ToString(dataReader["Name"]);
                e.Surname = Convert.ToString(dataReader["Surname"]);
                e.Password = Convert.ToString(dataReader["Password"]);
                e.UserName = Convert.ToString(dataReader["UserName"]);
                e.Status = Convert.ToBoolean(dataReader["Status"]);
                cb.Items.Add(e);
            }
            dataReader.Close();
            connection.Close();
        }

        public override string ToString()
        {
            return Name + " " + Surname;
        }
    }
}

