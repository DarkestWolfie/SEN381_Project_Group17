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
    internal class customer_d
    {
        public customer_d()
        {
        }

        string con = "Server=.; Initial Catalog=ukupholisa; Integrated Security=SSPI";

        //Search
        public DataTable search(int id)
        {
            using (SqlConnection cn = new SqlConnection(con))
            {
                SqlCommand cmd = new SqlCommand("spSearchCustomer", cn);

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

            SqlDataAdapter adapter = new SqlDataAdapter("spGetCustomer", con);

            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            DataTable customerData = new DataTable();

            adapter.Fill(customerData); 

            return customerData;
        }

        //Update
        public string update(customer_b customer)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(con))
                {
                    SqlCommand cmd = new SqlCommand("spUpdateCustomer", cn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id", customer.CustomerID);
                    cmd.Parameters.AddWithValue("@custName", customer.CustName);
                    cmd.Parameters.AddWithValue("@custSurname", customer.CustSurname);
                    cmd.Parameters.AddWithValue("@dob", customer.Dob);
                    cmd.Parameters.AddWithValue("@idNumber", customer.IdNumber);
                    cmd.Parameters.AddWithValue("@gender", customer.Gender);
                    cmd.Parameters.AddWithValue("@familyID", customer.FamilyID);
                    cmd.Parameters.AddWithValue("@familyRole", customer.FamilyRole);
                    cmd.Parameters.AddWithValue("@customerAddressID", customer.CustomerAddress);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }

                return "Customer data updated successfully.";
            }
            catch (Exception eA)
            {
                return "The following error was encountered while trying to update Customer data:\n\n" + eA.Message;
            }
        }
    }
}
