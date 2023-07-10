namespace T12;

class Program
{
    static void Main(string[] args)
    {
        Screen screen = new Screen();
        screen.PrintLoginScreen();
    }
}

// 3 layer

// --> presentation layer
//     Screen.class
//          --> Tao ra menu
//          --> Nhan vao cac hanh dong cua ng dung --> Nhap lua chon, Nhap thong tin
//          --> Hien thi ket qua cho ng dung

// --> business layer
//     EmplyeeBL.class // EmployeeManager.class // EmployeeService.class
//      --> Search
//      --> AddNew
//      --> Import / Export
//         .....
//

// --> data access layer
//     EmployeeDAL.class
//          --> Insert DB
//          --> UPdate DB, Delete Db
//          --> Select DB
//

// DTO = Data Transfer Object
//   --> Employee


// MVC -> Model View Controller

// class diagram