using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEN381_Project_Group17.BusinessLayer
{
    internal class application_b
    {
        int applicationID, applicationProviderID, applicationConditionID;
        String status, applicationCustomerID, applicationDate;

        public application_b()
        {
        }

        public application_b(int applicationID, string applicationCustomerID, int applicationConditionID, int applicationProviderID, string applicationDate, string status)
        {
            this.ApplicationID = applicationID;
            this.ApplicationCustomerID = applicationCustomerID;
            this.ApplicationConditionID = applicationConditionID;
            this.ApplicationProviderID = applicationProviderID;
            this.ApplicationDate = applicationDate;
            this.Status = status;
        }

        public int ApplicationID { get => applicationID; set => applicationID = value; }
        public string ApplicationCustomerID { get => applicationCustomerID; set => applicationCustomerID = value; }
        public int ApplicationProviderID { get => applicationProviderID; set => applicationProviderID = value; }
        public string ApplicationDate { get => applicationDate; set => applicationDate = value; }
        public string Status { get => status; set => status = value; }
        public int ApplicationConditionID { get => applicationConditionID; set => applicationConditionID = value; }
    }
}
