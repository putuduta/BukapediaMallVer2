using Bukapediamall.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Bukapediamall.Repositories
{
    public class BarangRepository : DBConnection
    {

        public List<Barang> View()
        {
            SqlDataReader reader;

            List<Barang> listBarang = new List<Barang>();

            string query = "SELECT * FROM Barang";

            command.Connection = connection;
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = query;

            connection.Open();

            reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["ID"].ToString());
                    int harga = Convert.ToInt32(reader["Harga"].ToString());
                    string name = reader["Nama"].ToString();
                    int qty = Convert.ToInt32(reader["Qty"].ToString());

                    Barang barang = new Barang(id, harga, name, qty);

                    listBarang.Add(barang);
                }
            }

            reader.Close();
            connection.Close();
            command.Dispose();

            return listBarang;

        }

        public void Insert(Barang barang)
        {
            string query = "INSERT INTO Barang VALUES(@Nama, @Harga, @Qty)";

            command.Parameters.Add("@Nama", SqlDbType.VarChar, 255).Value = barang.Nama;
            command.Parameters.Add("@Harga", SqlDbType.Int).Value = barang.Harga;
            command.Parameters.Add("@Qty", SqlDbType.Int).Value = barang.Qty;

            command.Connection = connection;
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = query;

            connection.Open();

            command.ExecuteNonQuery();
            
            connection.Close();
            command.Dispose();
        }
    }
}
