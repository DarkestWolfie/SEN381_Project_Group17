using SEN381_Project_Group17.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEN381_Project_Group17.DataLayer
{
    internal class policy_d
    {
        public policy_d()
        {
        }

        string con = "Server=.; Initial Catalog=ukupholisa; Integrated Security=SSPI";

        //Search
        public DataTable search(string id)
        {
            using (SqlConnection cn = new SqlConnection(con))
            {
                SqlCommand cmd = new SqlCommand("spSearchPolicy", cn);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", id);

                cn.Open();

                DataTable data = new DataTable();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    data.Load(dr);

                    return data;
                }
            }
        }

        //Get
        public DataTable getAll()
        {
            SqlConnection cn = new SqlConnection(con);

            SqlDataAdapter adapter = new SqlDataAdapter("spGetPolicy", con);

            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            DataTable customerData = new DataTable();

            adapter.Fill(customerData);

            return customerData;
        }

        //GetCount
        public string getCount()
        {
            SqlConnection cn = new SqlConnection(con);

            SqlCommand cmd = new SqlCommand("spPolicyCount", cn);

            cn.Open();
            var addressCount = cmd.ExecuteScalar();

            Console.WriteLine(addressCount.ToString());

            if (addressCount != null)
            {
                return addressCount.ToString();
            }
            else
            {
                return "0";
            }
        }

        //Update
        public string update(policy_b policy)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(con))
                {
                    SqlCommand cmd = new SqlCommand("spUpdatePolicy", cn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id", policy.PolicyID);
                    cmd.Parameters.AddWithValue("@policyName", policy.PolicyName);
                    cmd.Parameters.AddWithValue("@price", policy.Price);
                    cmd.Parameters.AddWithValue("@installment", policy.Installment);
                    cmd.Parameters.AddWithValue("@payout", policy.Payout);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }

                return "Policy data updated successfully.";
            }
            catch (Exception eA)
            {
                return "The following error was encountered while trying to update Policy data:\n\n" + eA.Message;
            }
        }

        //Add
        public string add(policy_b policy)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(con))
                {
                    SqlCommand cmd = new SqlCommand("spAddPolicy", cn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@policyID", policy.PolicyID);
                    cmd.Parameters.AddWithValue("@policyName", policy.PolicyName);
                    cmd.Parameters.AddWithValue("@price", policy.Price);
                    cmd.Parameters.AddWithValue("@installment", policy.Installment);
                    cmd.Parameters.AddWithValue("@payout", policy.Payout);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }

                return "Policy data added successfully.";
            }
            catch (Exception eA)
            {
                return "The following error was encountered while trying to add Policy data:\n\n" + eA.Message;
            }
        }

        //Delete
        public string delete(string policy)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(con))
                {
                    SqlCommand cmd = new SqlCommand("spDeletePolicy", cn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id", policy);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }

                return "Policy data deleted successfully.";
            }
            catch (Exception eA)
            {
                return "The following error was encountered while trying to delete Policy data:\n\n" + eA.Message;
            }
        }
    }
}
