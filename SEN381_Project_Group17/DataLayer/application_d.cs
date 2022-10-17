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
    internal class application_d
    {
        public application_d()
        {
        }

        string con = "Server=.; Initial Catalog=ukupholisa; Integrated Security=SSPI";

        //Get
        public DataTable getAll()
        {
            SqlConnection cn = new SqlConnection(con);

            SqlDataAdapter adapter = new SqlDataAdapter("spGetApplication", con);

            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            DataTable customerData = new DataTable();

            adapter.Fill(customerData);

            return customerData;
        }

        //Update
        public string update(application_b application, int conditionID, int providerID, int customerID)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(con))
                {
                    SqlCommand cmd = new SqlCommand("spUpdateApplication", cn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id", application.ApplicationID);
                    cmd.Parameters.AddWithValue("@applicationDate", application.ApplicationDate);
                    cmd.Parameters.AddWithValue("@status", application.Status);
                    cmd.Parameters.AddWithValue("@applicationCustomerID", customerID);
                    cmd.Parameters.AddWithValue("@treatmentConditionID", conditionID);
                    cmd.Parameters.AddWithValue("@treatmentProviderID", providerID);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }

                return "Application data updated successfully.";
            }
            catch (Exception eA)
            {
                return "The following error was encountered while trying to update Application data:\n\n" + eA.Message;
            }
        }
    }
}
