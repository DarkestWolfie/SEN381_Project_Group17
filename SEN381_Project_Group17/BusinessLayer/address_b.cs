using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEN381_Project_Group17.BusinessLayer
{
    internal class address_b
    {
        int addressID;
        String addressLine, city, province, postalCode;

        public address_b()
        {
        }

        public address_b(int addressID, string addressLine, string city, string province, string postalCode)
        {
            AddressID = addressID;
            AddressLine = addressLine;
            City = city;
            Province = province;
            PostalCode = postalCode;
        }

        public address_b(string addressLine, string city, string province, string postalCode)
        {
            AddressLine = addressLine;
            City = city;
            Province = province;
            PostalCode = postalCode;
        }

        public int AddressID { get => addressID; set => addressID = value; }
        public string AddressLine { get => addressLine; set => addressLine = value; }
        public string City { get => city; set => city = value; }
        public string Province { get => province; set => province = value; }
        public string PostalCode { get => postalCode; set => postalCode = value; }
    }
}
