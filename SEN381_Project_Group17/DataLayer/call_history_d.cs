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
    internal class call_history_d
    {
        public call_history_d()
        {
        }

        string con = "Server=.; Initial Catalog=ukupholisa; Integrated Security=SSPI";

        //Get
        public DataTable getAll()
        {
            SqlConnection cn = new SqlConnection(con);

            SqlDataAdapter adapter = new SqlDataAdapter("spGetCallHistory", con);

            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            DataTable customerData = new DataTable();

            adapter.Fill(customerData);

            return customerData;
        }

        //Update
        public string update(call_history_b call, int empID, int CustID)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(con))
                {
                    SqlCommand cmd = new SqlCommand("spUpdateCallHistory", cn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id", call.CallID);
                    cmd.Parameters.AddWithValue("@callCustomerID", CustID);
                    cmd.Parameters.AddWithValue("@callEmployeeID", empID);
                    cmd.Parameters.AddWithValue("@start", call.Strat);
                    cmd.Parameters.AddWithValue("@end", call.End);
                    cmd.Parameters.AddWithValue("@dateCreated", call.DateCreated);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }

                return "Call History data updated successfully.";
            }
            catch (Exception eA)
            {
                return "The following error was encountered while trying to update Call History data:\n\n" + eA.Message;
            }
        }
    }
}
