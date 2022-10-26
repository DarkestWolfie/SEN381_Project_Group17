using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEN381_Project_Group17.BusinessLayer
{
    internal class customer_b
    {
        int familyID, customerAddress;
        String customerID, custName, custSurname, idNumber, gender, familyRole, dob;

        public customer_b()
        {
        }

        public customer_b(string customerID, int familyID, int customerAddress, string custName, string custSurname, string idNumber, string gender, string familyRole, string dob)
        {
            CustomerID = customerID;
            FamilyID = familyID;
            CustomerAddress = customerAddress;
            CustName = custName;
            CustSurname = custSurname;
            IdNumber = idNumber;
            Gender = gender;
            FamilyRole = familyRole;
            Dob = dob;
        }

        public string CustomerID { get => customerID; set => customerID = value; }
        public int FamilyID { get => familyID; set => familyID = value; }
        public int CustomerAddress { get => customerAddress; set => customerAddress = value; }
        public string CustName { get => custName; set => custName = value; }
        public string CustSurname { get => custSurname; set => custSurname = value; }
        public string IdNumber { get => idNumber; set => idNumber = value; }
        public string Gender { get => gender; set => gender = value; }
        public string FamilyRole { get => familyRole; set => familyRole = value; }
        public string Dob { get => dob; set => dob = value; }
    }
}
