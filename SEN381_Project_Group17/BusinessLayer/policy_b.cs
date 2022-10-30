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

        public string GenerateID(string Date, String Importance)
        {
            string newPolicyID = "";

            DataLayer.policy_d policy = new DataLayer.policy_d();


            string polID = policy.getCount();

            string count = "";

            foreach (char character in polID)
            {
                if (character != '0')
                {
                    count += character;
                }
            }

            newPolicyID += Date;

            Random rnd = new Random();
            char randomLetter = Convert.ToChar(rnd.Next(65, 91));
            bool found = false;

            while (found == false)
            {
                if (randomLetter == 'I' || randomLetter == 'O')
                {
                    randomLetter = Convert.ToChar(rnd.Next(65, 91));
                }
                else
                {
                    found = true;
                }
            }

            newPolicyID += randomLetter;

            newPolicyID += Importance;

            if (count == "")
            {
                count = "1";
            }
            else
            {
                count = (int.Parse(count) + 1).ToString();
            }

            for (int i = 6; i > count.Length; i--)
            {
                newPolicyID += "0";
            }

            newPolicyID += count;

            return newPolicyID;
        }
    }
}
