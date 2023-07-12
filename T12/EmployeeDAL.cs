using System;
using System.Data.SqlClient;
using System.Reflection.Emit;
using Microsoft.VisualBasic;

namespace T12
{
	public class EmployeeDAL
	{
		SqlConnection conn;

        public EmployeeDAL()
		{
			conn = new DBConnector().GetConnection();
            conn.Open();
        }

		public User? SelectByUsernameAndPassword(string username, string password)
		{
			User emp = null;
            string sql = "SELECT * FROM EMPL WHERE name = @0 AND password = @1";
            SqlCommand cmd = new SqlCommand(sql, conn);
			cmd.Parameters.AddWithValue("0", username);
            cmd.Parameters.AddWithValue("1", password);

            SqlDataReader reader = cmd.ExecuteReader();
			while (reader.Read())
			{
				emp = new User();
				emp.Id = (int) reader["id"];
				emp.Name = (string) reader["name"];
                emp.Email = (string) reader["email"];
				emp.Role = (UserRole) reader["role"];
            }
            reader.Close();
            return emp;
        }

        public User? SelectById(int id)
        {
            User emp = null;
            string sql = "SELECT * FROM EMPL WHERE id = @0";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("0", id);
            
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                emp = new User();
                emp.Id = (int)reader["id"];
                emp.Name = (string)reader["name"];
                emp.Email = (string)reader["email"];
                emp.Role = (UserRole)reader["role"];
            }
            reader.Close();
            return emp;
        }

        public List<User> SelectByKey(string key)
        {
            List<User> list = new List<User>();
            string sql = "SELECT * FROM EMPL WHERE email like @0 OR name like @1";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("0", key);
            cmd.Parameters.AddWithValue("1", key);

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                User emp = new User();
                emp.Id = (int)reader["id"];
                emp.Name = (string)reader["name"];
                emp.Email = (string)reader["email"];
                emp.Role = (UserRole)reader["role"];
                list.Add(emp);
            }
            reader.Close();
            return list;
        }

        public List<User> SelectAll()
		{
            List<User> list = new List<User>();
            string sql = "SELECT * FROM EMPL";
            SqlCommand cmd = new SqlCommand(sql, conn);
            
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                User emp = new User();
                emp.Id = (int)reader["id"];
                emp.Name = (string)reader["name"];
                emp.Email = (string)reader["email"];
                emp.Role = (UserRole)reader["role"];
                list.Add(emp);
            }
            reader.Close();
            return list;
        }

		public int Insert(User emp)
		{
            string sql = "INSERT INTO  EMPL(name,email,password,role) VALUES (@0,@1,@2,@3)";
            SqlCommand cmd = new SqlCommand(sql, conn);
            
            cmd.Parameters.AddWithValue("0", emp.Name);
            cmd.Parameters.AddWithValue("1", emp.Email);
            cmd.Parameters.AddWithValue("2", emp.Password);
            cmd.Parameters.AddWithValue("3", emp.Role);
            return cmd.ExecuteNonQuery();
		}

        public int Update(User emp)
        {
            string sql = "UPDATE EMPL SET email = @1 WHERE id=@0";
            SqlCommand command = new SqlCommand(sql, conn);
            command.Parameters.AddWithValue("@0", emp.Id);
            command.Parameters.AddWithValue("@1", emp.Name);
            return command.ExecuteNonQuery();
        }

        public int Delete(int id)
        {
            string sql = "DELETE FROM EMPL WHERE id=@0";
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

