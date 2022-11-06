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

        public bool loginValidation(string username, string password)
        {
            if (username != string.Empty && password != string.Empty)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool clientClaimVal(string status, string custID, string condID, string provID, string date)
        {
            if (status != string.Empty && custID != string.Empty && condID != string.Empty && provID != string.Empty && date != string.Empty)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool clientInfoVal(string name, string surname, string ID, string famID,
            string famRole, string gender, string addrLine, string city, string prov, string postcode)
        {
            if (name != string.Empty && surname != string.Empty && ID != string.Empty &&
                famID != string.Empty && famRole != string.Empty && gender != string.Empty &&
                addrLine != string.Empty && city != string.Empty && prov != string.Empty &&
                postcode != string.Empty)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool conditionVal(string polName, string polCode, string polID)
        {
            if (polName != string.Empty && polCode != string.Empty && polID != string.Empty)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool custAccVal(string cID, string amntDue, string date)
        {
            if (cID != string.Empty && amntDue != string.Empty && date != string.Empty)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool custHistoryVal(string active, string custID, string prodID, string start, string end)
        {
            if (active != string.Empty && custID != string.Empty && prodID != string.Empty && start != string.Empty && end != string.Empty)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool empInfoVal(string name, string email, string num, string role, string username, string password)
        {
            if (name != string.Empty && email != string.Empty && num != string.Empty &&
                role != string.Empty && password != string.Empty && username != string.Empty)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool polInfoVal(string name, string price, string installment, string payout)
        {
            if (name != string.Empty && price != string.Empty && installment != string.Empty &&
                payout != string.Empty)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool prodInfoVal(string discount, string avail, string polID)
        {
            if (discount != string.Empty && avail != string.Empty && polID != string.Empty)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool prodHistoryVal(string prodID, string start, string end)
        {
            if (prodID != string.Empty && start != string.Empty && end != string.Empty)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool provInfoVal(string compName, string status, string province)
        {
            if (compName != string.Empty && status != string.Empty && province != string.Empty)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool treatInfoVal(string name, string desc, string cost, string condID, string provID)
        {
            if (name != string.Empty && desc != string.Empty && cost != string.Empty &&
                condID != string.Empty && provID != string.Empty)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool callVal(string cusID, string empID, string start, string end, string duration, string date)
        {
            if (cusID != string.Empty && empID != string.Empty && start != string.Empty &&
                end != string.Empty && duration != string.Empty && date != string.Empty)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
