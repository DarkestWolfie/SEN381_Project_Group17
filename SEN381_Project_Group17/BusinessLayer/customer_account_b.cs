using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEN381_Project_Group17.BusinessLayer
{
    internal class customer_account_b
    {
        int accountID, accountCustomerID;
        Double amountDue;
        DateTime installmentDate;

        public customer_account_b()
        {
        }

        public customer_account_b(int accountID, int accountCustomerID, double amountDue, DateTime installmentDate)
        {
            AccountID = accountID;
            AccountCustomerID = accountCustomerID;
            AmountDue = amountDue;
            InstallmentDate = installmentDate;
        }

        public int AccountID { get => accountID; set => accountID = value; }
        public int AccountCustomerID { get => accountCustomerID; set => accountCustomerID = value; }
        public double AmountDue { get => amountDue; set => amountDue = value; }
        public DateTime InstallmentDate { get => installmentDate; set => installmentDate = value; }
    }
}
