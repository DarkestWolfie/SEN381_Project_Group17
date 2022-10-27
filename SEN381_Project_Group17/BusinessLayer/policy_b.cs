using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEN381_Project_Group17.BusinessLayer
{
    internal class policy_b
    {
        String policyName, policyID;
        Double price, installment, payout;

        public policy_b()
        {
        }

        public policy_b(string policyID, string policyName, double price, double installment, double payout)
        {
            this.PolicyID = policyID;
            this.PolicyName = policyName;
            this.Price = price;
            this.Installment = installment;
            this.Payout = payout;
        }

        public string PolicyID { get => policyID; set => policyID = value; }
        public string PolicyName { get => policyName; set => policyName = value; }
        public double Price { get => price; set => price = value; }
        public double Installment { get => installment; set => installment = value; }
        public double Payout { get => payout; set => payout = value; }
    }
}
