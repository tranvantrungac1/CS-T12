using System;
namespace T12
{
	public class User
	{
		public int Id { get; set; }
		public string Username { get; set; }
		public string Fullname { get; set; }
		public string Password { get; set; }
		public UserRole Role { get; set; } // Manager - User

		public User()
		{
		}

        public User(int id, string username, string fullname, string password, UserRole role)
        {
            Id = id;
            Username = username;
            Fullname = fullname;
            Password = password;
            Role = role;
        }

        public override string? ToString()
        {
            return " | " + Id + " | " + Username + " | " + Fullname + " | " + Role + " | ";
        }
    }
}

