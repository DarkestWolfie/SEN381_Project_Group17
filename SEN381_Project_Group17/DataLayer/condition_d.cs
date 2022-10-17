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
    internal class condition_d
    {
        public condition_d()
        {
        }

        string con = "Server=.; Initial Catalog=ukupholisa; Integrated Security=SSPI";

        //Get
        public DataTable getAll()
        {
            SqlConnection cn = new SqlConnection(con);

            SqlDataAdapter adapter = new SqlDataAdapter("spGetCondition", con);

            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            DataTable customerData = new DataTable();

            adapter.Fill(customerData);

            return customerData;
        }

        //Update
        public string update(condition_b condition, int policyID)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(con))
                {
                    SqlCommand cmd = new SqlCommand("spUpdateCondition", cn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id", condition.ConditionID);
                    cmd.Parameters.AddWithValue("@conditionName", condition.ConditionName);
                    cmd.Parameters.AddWithValue("@conditionPolicyID", policyID);
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }

                return "Condition data updated successfully.";
            }
            catch (Exception eA)
            {
                return "The following error was encountered while trying to update Condition data:\n\n" + eA.Message;
            }
        }
    }
}
