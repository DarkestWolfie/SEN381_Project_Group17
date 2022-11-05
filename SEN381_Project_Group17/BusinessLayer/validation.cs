using SEN381_Project_Group17.DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEN381_Project_Group17.BusinessLayer
{
    internal class validation
    {
        public validation()
        {
        }

        public List<product_b> populateProduct()
        {
            List<product_b> list = new List<product_b>();

            product_d dh = new product_d();

            DataTable dt = dh.getAll();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                product_b obj = new product_b();
                obj.ProductID = Convert.ToInt32(dt.Rows[i]["productID"]);

                list.Add(obj);
            }

            return list;
        }

        public List<customer_b> populateCustomer()
        {
            List<customer_b> list = new List<customer_b>();

            customer_d dh = new customer_d();

            DataTable dt = dh.getAll();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                customer_b obj = new customer_b();
                obj.CustomerID = dt.Rows[i]["customerID"].ToString();
                obj.CustName = dt.Rows[i]["custName"].ToString();
                obj.CustSurname = dt.Rows[i]["custSurname"].ToString();

                list.Add(obj);
            }

            return list;
        }

        public List<employee_b> populateEmployee()
        {
            List<employee_b> list = new List<employee_b>();

            employee_d dh = new employee_d();

            DataTable dt = dh.getAll();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                employee_b obj = new employee_b();
                obj.EmployeeID = Convert.ToInt32(dt.Rows[i]["employeeID"]);
                obj.EmployeeName = dt.Rows[i]["empName"].ToString();

                list.Add(obj);
            }

            return list;
        }

        public List<policy_b> populatePolicy()
        {
            List<policy_b> list = new List<policy_b>();

            policy_d dh = new policy_d();

            DataTable dt = dh.getAll();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                policy_b obj = new policy_b();
                obj.PolicyID = dt.Rows[i]["policyID"].ToString();
                obj.PolicyName = dt.Rows[i]["policyName"].ToString();

                list.Add(obj);
            }

            return list;
        }

        public List<product_history_b> populateProHistory()
        {
            List<product_history_b> list = new List<product_history_b>();

            product_history_d dh = new product_history_d();

            DataTable dt = dh.getAll();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                product_history_b obj = new product_history_b();
                obj.PorHistoryID = Convert.ToInt32(dt.Rows[i]["proHistoryID"]);

                list.Add(obj);
            }

            return list;
        }

        public List<condition_b> populateCondition()
        {
            List<condition_b> list = new List<condition_b>();

            condition_d dh = new condition_d();

            DataTable dt = dh.getAll();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                condition_b obj = new condition_b();
                obj.ConditionID = Convert.ToInt32(dt.Rows[i]["conditionID"]);
                obj.ConditionCode = dt.Rows[i]["conitionCode"].ToString();

                list.Add(obj);
            }

            return list;
        }

        public List<provider_b> populateProvider()
        {
            List<provider_b> list = new List<provider_b>();

            provider_d dh = new provider_d();

            DataTable dt = dh.getAll();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                provider_b obj = new provider_b();
                obj.ProviderID = Convert.ToInt32(dt.Rows[i]["providerID"]);
                obj.ProviderName = dt.Rows[i]["providerName"].ToString();

                list.Add(obj);
            }

            return list;
        }
    }
}
