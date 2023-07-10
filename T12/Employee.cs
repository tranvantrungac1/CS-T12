using System;
namespace T12
{
	public class Employee
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public EmployeeRole Role { get; set; } // Manager - User

		public Employee()
		{
		}

        public Employee(int id, string name, string email, string password, EmployeeRole role)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
            Role = role;
        }

        public override string? ToString()
        {
            return " | " + Id + " | " + Name + " | " + Email + " | " + Role + " | ";
        }
    }
}

