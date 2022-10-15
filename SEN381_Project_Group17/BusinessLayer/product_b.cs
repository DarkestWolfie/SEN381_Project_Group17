using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEN381_Project_Group17.BusinessLayer
{
    internal class product_b
    {
        int productID, productPolicyID;
        Double policyDiscount;
        String availibility;

        public product_b()
        {
        }

        public product_b(int productID, int productPolicyID, double policyDiscount, string availibility)
        {
            this.ProductID = productID;
            this.ProductPolicyID = productPolicyID;
            this.PolicyDiscount = policyDiscount;
            this.Availibility = availibility;
        }

        public int ProductID { get => productID; set => productID = value; }
        public int ProductPolicyID { get => productPolicyID; set => productPolicyID = value; }
        public double PolicyDiscount { get => policyDiscount; set => policyDiscount = value; }
        public string Availibility { get => availibility; set => availibility = value; }
    }
}
