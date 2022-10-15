using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEN381_Project_Group17.BusinessLayer
{
    internal class employee_b
    {
        int employeeID;
        String employeeName, email, phoneNumber, role, userName, password;

        public employee_b()
        {
        }

        public employee_b(int employeeID, string employeeName, string email, string phoneNumber, string role, string userName, string password)
        {
            EmployeeID = employeeID;
            EmployeeName = employeeName;
            Email = email;
            PhoneNumber = phoneNumber;
            Role = role;
            UserName = userName;
            Password = password;
        }

        public int EmployeeID { get => employeeID; set => employeeID = value; }
        public string EmployeeName { get => employeeName; set => employeeName = value; }
        public string Email { get => email; set => email = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string Role { get => role; set => role = value; }
        public string UserName { get => userName; set => userName = value; }
        public string Password { get => password; set => password = value; }
    }
}
