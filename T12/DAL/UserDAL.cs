using System;
using System.Data.SqlClient;
using System.Reflection.Emit;
using Microsoft.VisualBasic;
using T12.DTO;

namespace T12.DAL
{
    public class UserDAL
    {
        SqlConnection conn;

        public UserDAL()
        {
            conn = new DBConnector().GetConnection();
            conn.Open();
        }

        public User? SelectByUsernameAndPassword(string username, string password)
        {
            User u = null;
            string sql = "SELECT * FROM USERS WHERE username = @0 AND password = @1";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("0", username);
            cmd.Parameters.AddWithValue("1", Utils.Hash(password));

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                u = new User();
                u.Id = (int)reader["id"];
                u.Username = (string)reader["username"];
                u.Fullname = (string)reader["fullname"];
                u.Role = (UserRole)reader["role"];
            }
            reader.Close();
            return u;
        }

        public User? SelectById(int id)
        {
            User u = null;
            string sql = "SELECT * FROM USERS WHERE id = @0";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("0", id);

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                u = new User();
                u.Id = (int)reader["id"];
                u.Username = (string)reader["username"];
                u.Fullname = (string)reader["fullname"];
                u.Role = (UserRole)reader["role"];
            }
            reader.Close();
            return u;
        }

        public List<User> SelectByKey(string key)
        {
            List<User> list = new List<User>();
            string sql = "SELECT * FROM USERS WHERE username like @0 OR fullname like @1";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("0", key);
            cmd.Parameters.AddWithValue("1", key);

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                User u = new User();
                u.Id = (int)reader["id"];
                u.Username = (string)reader["username"];
                u.Fullname = (string)reader["fullname"];
                u.Role = (UserRole)reader["role"];
                list.Add(u);
            }
            reader.Close();
            return list;
        }

        public List<User> SelectAll()
        {
            List<User> list = new List<User>();
            string sql = "SELECT * FROM USERS";
            SqlCommand cmd = new SqlCommand(sql, conn);

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                User emp = new User();
                emp.Id = (int)reader["id"];
                emp.Username = (string)reader["username"];
                emp.Fullname = (string)reader["fullname"];
                emp.Role = (UserRole)reader["role"];
                list.Add(emp);
            }
            reader.Close();
            return list;
        }

        public int Insert(User u)
        {
            string sql = "INSERT INTO  USERS (username,fullname,password,role) VALUES (@0,@1,@2,@3)";
            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("0", u.Username);
            cmd.Parameters.AddWithValue("1", u.Fullname);
            cmd.Parameters.AddWithValue("2", Utils.Hash(u.Password));
            cmd.Parameters.AddWithValue("3", u.Role);
            return cmd.ExecuteNonQuery();
        }

        public int UpdateFullname(int id, string fullname)
        {
            string sql = "UPDATE USERS SET fullname = @1 WHERE id=@0";
            SqlCommand command = new SqlCommand(sql, conn);
            command.Parameters.AddWithValue("@0", id);
            command.Parameters.AddWithValue("@1", fullname);
            return command.ExecuteNonQuery();
        }
        public int UpdateRole(int id, UserRole role)
        {
            string sql = "UPDATE USERS SET role = @1 WHERE id=@0";
            SqlCommand command = new SqlCommand(sql, conn);
            command.Parameters.AddWithValue("@0", id);
            command.Parameters.AddWithValue("@1", role);
            return command.ExecuteNonQuery();
        }
        public int UpdatePassword(int id, string password)
        {
            string sql = "UPDATE USERS SET password = @1 WHERE id=@0";
            SqlCommand command = new SqlCommand(sql, conn);
            command.Parameters.AddWithValue("@0", id);
            command.Parameters.AddWithValue("@1", Utils.Hash(password));
            return command.ExecuteNonQuery();
        }
        public int Delete(int id)
        {
            string sql = "DELETE FROM USERS WHERE id=@0";
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

