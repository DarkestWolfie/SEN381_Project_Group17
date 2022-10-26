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
    internal class account_d
    {
        public account_d()
        {
        }

        string con = "Server=.; Initial Catalog=ukupholisa; Integrated Security=SSPI";

        //Get
        public DataTable getAll()
        {
            SqlConnection cn = new SqlConnection(con);

            SqlDataAdapter adapter = new SqlDataAdapter("spGetAccount", con);

            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            DataTable customerData = new DataTable();

            adapter.Fill(customerData);

            return customerData;
        }

        //Update
        public string update(customer_account_b account)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(con))
                {
                    SqlCommand cmd = new SqlCommand("spUpdateAccount", cn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id", account.AccountCustomerID);
                    cmd.Parameters.AddWithValue("@accountCustomerID", account.AccountCustomerID);
                    cmd.Parameters.AddWithValue("@amountDue", account.AmountDue);
                    cmd.Parameters.AddWithValue("@installmentDate", account.InstallmentDate);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }

                return "Customer Account data updated successfully.";
            }
            catch (Exception eA)
            {
                return "The following error was encountered while trying to update Customer Account data:\n\n" + eA.Message;
            }
        }
    }
}
