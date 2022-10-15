using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEN381_Project_Group17.BusinessLayer
{
    internal class application
    {
        int applicationID, applicationCustomerID, applicationProviderID;
        DateTime applicationDate;
        String status;

        public application()
        {
        }

        public application(int applicationID, int applicationCustomerID, int applicationProviderID, DateTime applicationDate, string status)
        {
            this.ApplicationID = applicationID;
            this.ApplicationCustomerID = applicationCustomerID;
            this.ApplicationProviderID = applicationProviderID;
            this.ApplicationDate = applicationDate;
            this.Status = status;
        }

        public int ApplicationID { get => applicationID; set => applicationID = value; }
        public int ApplicationCustomerID { get => applicationCustomerID; set => applicationCustomerID = value; }
        public int ApplicationProviderID { get => applicationProviderID; set => applicationProviderID = value; }
        public DateTime ApplicationDate { get => applicationDate; set => applicationDate = value; }
        public string Status { get => status; set => status = value; }
    }
}
