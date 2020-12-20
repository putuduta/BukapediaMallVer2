using Bukapediamall.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Bukapediamall.Repositories
{
    public class PulsaRepository : DBConnection
    {
        public List<Pulsa> View()
        {
            SqlDataReader reader;

            List<Pulsa> listPulsa = new List<Pulsa>();

            string query = "SELECT * FROM Pulsa";

            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.CommandText = query;

            connection.Open();

            reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["ID"].ToString());
                    int harga = Convert.ToInt32(reader["Harga"].ToString());
                    string nohp = reader["NoHp"].ToString();

                    Pulsa pulsa = new Pulsa(id, harga, nohp);

                    listPulsa.Add(pulsa);
                }
            }

            reader.Close();
            connection.Close();
            command.Dispose();

            return listPulsa;

        }

        public void Insert(Pulsa pulsa)
        {
            string query = "INSERT INTO Pulsa VALUES(@NoHp, @Harga)";

            command.Parameters.Add("@NoHp", SqlDbType.VarChar, 255).Value = pulsa.NoHp;
            command.Parameters.Add("@Harga", SqlDbType.Int).Value = pulsa.Harga;

            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.CommandText = query;

            connection.Open();

            command.ExecuteNonQuery();

            connection.Close();
            command.Dispose();
        }

        public void Update(Pulsa pulsa)
        {
            string query = "UPDATE Pulsa SET [NoHp] = @NoHp2, Harga = @Harga2 WHERE ID = @ID";
            command.Parameters.Add("@ID", SqlDbType.Int).Value = pulsa.Id;
            command.Parameters.Add("@NoHp2", SqlDbType.VarChar, 255).Value = pulsa.NoHp;
            command.Parameters.Add("@Harga2", SqlDbType.Int).Value = pulsa.Harga;

            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.CommandText = query;

            connection.Open();

            command.ExecuteNonQuery();

            connection.Close();
            command.Dispose();
        }

        public void Delete(int id)
        {
            string query = "DELETE FROM Pulsa WHERE ID = @ID2";
            command.Parameters.Add("@ID2", SqlDbType.Int).Value = id;

            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.CommandText = query;

            connection.Open();

            command.ExecuteNonQuery();

            connection.Close();
            command.Dispose();
        }
    }
}
