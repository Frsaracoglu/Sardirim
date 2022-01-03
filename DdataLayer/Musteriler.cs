using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DataLayer
{
    public class Musteriler
    {
        General gnl = new General();

        public bool MusteriVarMi(string tlf)
        {
            bool sonuc = false;

            SqlConnection connection = new SqlConnection(gnl.conString);
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "MusteriVarMi";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@telefon", SqlDbType.VarChar).Value = tlf;
            command.Parameters.Add("@sonuc", SqlDbType.Int);
            command.Parameters["@sonuc"].Direction = ParameterDirection.Output;

            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            try
            {
                command.ExecuteNonQuery();
                sonuc = Convert.ToBoolean(command.Parameters["@sonuc"].Value);
            }
            catch (SqlException ex)
            {

                string hata = ex.Message;
            }
            finally
            {
                connection.Close();
            }
            return sonuc;
        }

        public int musteriEkle(Musteriler m)
        {
            int sonuc = 0;
            SqlConnection connection = new SqlConnection(gnl.conString);
            SqlCommand command = new SqlCommand("Insert Into Customers(Name,Surname,Phone,Adress,Email) values(@name,@surname,@phone,@adress,@email);select SCOPE_IDENTITY()", connection);
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                command.Parameters.Add("@name", SqlDbType.VarChar).Value = m._musteriad;
                command.Parameters.Add("@surname", SqlDbType.VarChar).Value = m._musterisoyad;
                command.Parameters.Add("@phone", SqlDbType.VarChar).Value = m._telefon;
                command.Parameters.Add("@adress", SqlDbType.VarChar).Value = m._adres;
                command.Parameters.Add("@email", SqlDbType.VarChar).Value = m._email;
                sonuc = Convert.ToInt32(command.ExecuteScalar());
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

        public bool musteriBilgileriGuncelle(Musteriler m)
        {
            bool sonuc = false;
            SqlConnection connection = new SqlConnection(gnl.conString);
            SqlCommand command = new SqlCommand("Update Customers set Name=@name,Surname=@surname,Phone=@phone,Adress=@adress,@email where ID=@musteriId", connection);
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                command.Parameters.Add("@name", SqlDbType.VarChar).Value = m._musteriad;
                command.Parameters.Add("@surname", SqlDbType.VarChar).Value = m._musterisoyad;
                command.Parameters.Add("@phone", SqlDbType.VarChar).Value = m._telefon;
                command.Parameters.Add("@adress", SqlDbType.VarChar).Value = m._adres;
                command.Parameters.Add("@email", SqlDbType.VarChar).Value = m._email;
                command.Parameters.Add("@email", SqlDbType.VarChar).Value = m._musteriid;
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
    }
}
