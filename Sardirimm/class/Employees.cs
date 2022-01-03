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
    class Employees
    {
        General gnl = new General();

        private int _Id;
        private int _TitleId;
        private string _Name;
        private string _Surname;
        private string _Password;
        private string _UserName;
        private bool _Status;

        public int Id { get => _Id; set => _Id = value; }
        public int TitleId { get => _TitleId; set => _TitleId = value; }
        public string Name { get => _Name; set => _Name = value; }
        public string Surname { get => _Surname; set => _Surname = value; }
        public string Password { get => _Password; set => _Password = value; }
        public string UserName { get => _UserName; set => _UserName = value; }
        public bool Status { get => _Status; set => _Status = value; }

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
                e._Id = Convert.ToInt32(dataReader["ID"]);
                e._TitleId = Convert.ToInt32(dataReader["TitleID"]);
                e._Name = Convert.ToString(dataReader["Name"]);
                e._Surname = Convert.ToString(dataReader["Surname"]);
                e._Password = Convert.ToString(dataReader["Password"]);
                e._UserName = Convert.ToString(dataReader["UserName"]);
                e._Status = Convert.ToBoolean(dataReader["Status"]);
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
