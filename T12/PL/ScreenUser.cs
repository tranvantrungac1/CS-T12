using System;
using T12.BL;
using T12.DTO;

namespace T12.PL
{
    public class ScreenUser
    {
        UserManager userManager;

        public ScreenUser()
        {
            this.userManager = new UserManager();
        }

        public User? PrintLoginScreen()
        {
            bool checkLogin = false;
            do
            {
                Console.WriteLine("===== EMPLOYEE MANAGE =====");
                Console.WriteLine("=====       LOGIN     =====");
                Console.Write("Username: ");
                string uname = Console.ReadLine();
                Console.Write("Password: ");
                string pwd = Console.ReadLine();

                // --> Check Login
                User? employee = userManager.Login(uname, pwd);
                if (employee == null)
                {
                    Console.WriteLine("Login fail! Wrong uname or password");
                    return null;
                }
                else
                {
                    checkLogin = true;
                    Console.WriteLine("Login success!");
                    
                    // Dieu huong
                    if (employee.Role == UserRole.MANAGER)
                    {
                        PrintManagerScreen();
                    }
                    else if (employee.Role == UserRole.USER)
                    {
                        PrintUserScreen();
                    }
                    return employee;
                }
            } while (!checkLogin);
        }
        public void PrintManagerScreen()
        {
            int selected = 0;

            do
            {
                Console.WriteLine("***USER MANAGER***");
                Console.WriteLine("\t1.Search User by Name or ID");
                Console.WriteLine("\t2.Add New User");
                Console.WriteLine("\t3.Update User");
                Console.WriteLine("\t4.Delete User");
                Console.WriteLine("\t5.Export User Data");
                Console.WriteLine("\t6.Import User Data");
                Console.WriteLine("\t7.Exit");
                Console.Write("Select (1-7): ");
                selected = Convert.ToInt16(Console.ReadLine());


                switch (selected)
                {
                    case 1:
                        PrintFindUserScreen();
                        break;
                    case 2:
                        PrintAddUserScreen();
                        break;
                    case 3:
                        PrintUpdateUserScreen();
                        break;
                    case 4:
                        PrintDeleteUserScreen();
                        break;
                    case 5:
                        PrintExportUserScreen();
                        break;
                    case 6:
                        PrintImportUserScreen();
                        break;
                    case 7:
                        Console.WriteLine("------------END----------");
                        break;
                    default:
                        Console.WriteLine("Invalid");
                        break;
                }
            } while (selected != 7);
        }
        public void PrintUserScreen()
        {
            int selected = 0;
            do
            {
                Console.WriteLine("***USER FUNCTION");
                Console.WriteLine("1. Device Manager");
                Console.WriteLine("2. Password Change");
                Console.WriteLine("3. Exit");
                Console.WriteLine("Select (1-3)");
                selected = Convert.ToInt32(Console.ReadLine());
                switch (selected)
                {
                    case 1:
                        PrintUserDeviceManager();
                        break;
                    case 2:
                        PrintUserPasswordChange();
                        break;
                }
            }
            while (selected != 3);
        }


        private void PrintFindUserScreen()
        {
            Console.WriteLine("***USER SEARCHING***");
            Console.Write("enter Id or name/fullname: ");
            string key = Console.ReadLine();

            List<User> users = userManager.Find(key);
            if (users.Count > 0)
            {
                DisplayUsers(users);
            }
            else
            {
                Console.WriteLine("Data not found!");
            }
        }

        private void PrintAddUserScreen()
        {
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Full Name: ");
            string fullname = Console.ReadLine();
            Console.Write("Is Manager y/n:");
            UserRole role = UserRole.USER;
            if (Console.ReadLine().ToUpper() == "Y")
            {
                role = UserRole.MANAGER;
            }
            Console.Write("Password:");
            string password = Console.ReadLine();
            userManager.AddNew(new User(0, name, fullname, password, role));
        }


        private void PrintDeleteUserScreen()
        {
            Console.WriteLine("***DELETE USER SCREEN***");
            Console.Write("enter Id or name/fullname want delete: ");
            string key = Console.ReadLine();

            List<User> users = userManager.Find(key);
            if (users.Count > 0)
            {
                DisplayUsers(users);
                Console.WriteLine("Chon Id muon xoa");
                int idDelete = Convert.ToInt32(Console.ReadLine());
                foreach (User item in users)
                {
                    if (item.Id == idDelete)
                    {
                        userManager.Delete(item);
                    }
                }
            }
            else
            {
                Console.WriteLine("Data not found!");
            }
        }
        public void PrintExportUserScreen()
        {
            Console.WriteLine("***EXPORT USER SCREEN***");
            Console.WriteLine("Du lieu duoc Export ra thu muc C:\\User\\ADMIN\\Export");
            userManager.Export("C:\\User\\ADMIN\\Export.csv");
        }

        public void PrintImportUserScreen()
        {
            Console.WriteLine("***IMPORT USER SCREEN***");
            Console.WriteLine("Du lieu duoc Import tu thu muc C:\\User\\ADMIN\\Import");
            userManager.Import("C:\\User\\ADMIN\\Import.csv");
        }











        public void PrintUserDeviceManager()
        {
            int selected = 0;
            do
            {
                Console.WriteLine("***DEVICE MANAGER***");
                Console.WriteLine("1. Search Device");
                Console.WriteLine("2. Add New Device");
                Console.WriteLine("3. Update Device Name");
                Console.WriteLine("4. Update Device Quantity");
                selected = Convert.ToInt32(Console.ReadLine());
                switch (selected)
                {
                    case 1:
                        PrintDeviceFindScreen();
                        break;
                    case 2:
                        PrintDeviceAddScreen();
                        break;
                    case 3:
                        PrintUpdateDeviceNameScreen();
                        break;
                    case 4:
                        PrintUpdateDeviceQuantityScreen();
                        break;
                }
            } while (selected != 4);
        }

        public void PrintUserPasswordChange()
        {
            Console.WriteLine("Password Change Screen");
            Console.WriteLine("Nhap Password moi");
            string password = Console.ReadLine();
            userManager.UpdatePassword();

        }
        
        
        private void PrintFindDeviceScreen()
        {
            Console.WriteLine("***DEVICE SEARCHING***");
            Console.Write("enter Id or name or quantity: ");
            string key = Console.ReadLine();

            List<Device> devices = deviceManager.Find(key);
            if (devices.Count > 0)
            {
                DisplayDevices(devices);
            }
            else
            {
                Console.WriteLine("Data not found!");
            }
        }
        
        private void PrintUpdateUserScreen()
        {

            Console.Write("enter Id or name/fullname: ");
            string key = Console.ReadLine();

            List<User> users = userManager.Find(key);
            if (users.Count > 0)
            {
                DisplayUsers(users);
            }
            else
            {
                Console.WriteLine("Data not found!");
            }

        }
        private void PrintAddDeviceScreen()
        {
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Quantity: ");
            int quantity = Convert.ToInt32(Console.ReadLine());
            deviceManager.AddNew(new Device(0, name, quantity));
        }




        private void DisplayUsers(List<User> users)
        {
            foreach (User item in users)
            {
                Console.WriteLine(item);
            }
        }
        private void DisplayDevices(List<Device> devices)
        {
            foreach (Device item in devices)
            {
                Console.WriteLine(item);
            }
        }

        
    }
}

