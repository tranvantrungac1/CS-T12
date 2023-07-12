using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using T12.DTO;

namespace T12.DAL
{
    public class DeviceDAL
    {
        SqlConnection conn;

        public DeviceDAL()
        {
            conn = new DBConnector().GetConnection();
            conn.Open();
        }
        public Device? SelectById(int id)
        {
            Device d = null;
            string sql = "SELECT * FROM DEVICES WHERE id = @0";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("0", id);

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                d = new Device();
                d.Id = (int)reader["id"];
                d.Name = (string)reader["name"];
                d.Quantity = (int)reader["quantity"];
            }
            reader.Close();
            return d;
        }

        public List<Device> SelectByName(string name)
        {
            List<Device> list = new List<Device>();
            string sql = "SELECT * FROM DEVICES WHERE name like @0";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("0", name);

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Device d = new Device();
                d.Id = (int)reader["id"];
                d.Name = (string)reader["name"];
                d.Quantity = (int)reader["quantity"];
                list.Add(d);
            }
            reader.Close();
            return list;
        }
        public List<Device> SelectByQuantity(int quantity)
        {
            List<Device> list = new List<Device>();
            string sql = "SELECT * FROM DEVICES WHERE quantity = @0";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("0", quantity);

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Device d = new Device();
                d.Id = (int)reader["id"];
                d.Name = (string)reader["name"];
                d.Quantity = (int)reader["quantity"];
                list.Add(d);
            }
            reader.Close();
            return list;
        }
        public List<Device> SelectByIdOrQuantity(int idOrQuantity)
        {
            List<Device> list = new List<Device>();
            string sql = "SELECT * FROM DEVICES WHERE quantity = @0 OR id = @1";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("0", idOrQuantity);
            cmd.Parameters.AddWithValue("1", idOrQuantity);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Device d = new Device();
                d.Id = (int)reader["id"];
                d.Name = (string)reader["name"];
                d.Quantity = (int)reader["quantity"];
                list.Add(d);
            }
            reader.Close();
            return list;
        }
        public List<Device> SelectAll()
        {
            List<Device> list = new List<Device>();
            string sql = "SELECT * FROM DEVICES";
            SqlCommand cmd = new SqlCommand(sql, conn);

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Device d = new Device();
                d.Id = (int)reader["id"];
                d.Name = (string)reader["name"];
                d.Quantity = (int)reader["quantity"];
                list.Add(d);
            }
            reader.Close();
            return list;
        }

        public int Insert(Device d)
        {
            string sql = "INSERT INTO  DEVICES (name,quantity) VALUES (@0,@1)";
            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("0", d.Name);
            cmd.Parameters.AddWithValue("1", d.Quantity);
            return cmd.ExecuteNonQuery();
        }
        public int UpdateName(Device d)
        {
            string sql = "UPDATE DEVICES SET name = @1 WHERE id=@0";
            SqlCommand command = new SqlCommand(sql, conn);
            command.Parameters.AddWithValue("@0", d.Id);
            command.Parameters.AddWithValue("@1", d.Name);
            return command.ExecuteNonQuery();
        }
        public int UpdateQuantity(Device d)
        {
            string sql = "UPDATE DEVICES SET quantity = @1 WHERE id=@0";
            SqlCommand command = new SqlCommand(sql, conn);
            command.Parameters.AddWithValue("@0", d.Id);
            command.Parameters.AddWithValue("@1", d.Quantity);
            return command.ExecuteNonQuery();
        }
        public int Delete(int id)
        {
            string sql = "DELETE FROM DEVICES WHERE id=@0";
            SqlCommand command = new SqlCommand(sql, conn);
            command.Parameters.AddWithValue("@0", id);
            return command.ExecuteNonQuery();
        }
        public void Close()
        {
            conn.Close();
        }
    }
}

