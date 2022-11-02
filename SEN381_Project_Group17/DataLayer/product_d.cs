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
    internal class product_d
    {
        public product_d()
        {
        }

        string con = "Server=.; Initial Catalog=ukupholisa; Integrated Security=SSPI";

        //Search
        public DataTable search(int id)
        {
            using (SqlConnection cn = new SqlConnection(con))
            {
                SqlCommand cmd = new SqlCommand("spSearchProduct", cn);

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

            SqlDataAdapter adapter = new SqlDataAdapter("spGetProduct", con);

            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            DataTable customerData = new DataTable();

            adapter.Fill(customerData);

            return customerData;
        }

        //Update
        public string update(product_b product)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(con))
                {
                    SqlCommand cmd = new SqlCommand("spUpdateProduct", cn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id", product.ProductID);
                    cmd.Parameters.AddWithValue("@policyDiscount", product.PolicyDiscount);
                    cmd.Parameters.AddWithValue("@availability", product.Availibility);
                    cmd.Parameters.AddWithValue("@productPolicyID", product.ProductPolicyID);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }

                return "Product data updated successfully.";
            }
            catch (Exception eA)
            {
                return "The following error was encountered while trying to update Product data:\n\n" + eA.Message;
            }
        }

        //Add
        public string add(product_b product)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(con))
                {
                    SqlCommand cmd = new SqlCommand("spAddProduct", cn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@policyDiscount", product.PolicyDiscount);
                    cmd.Parameters.AddWithValue("@availability", product.Availibility);
                    cmd.Parameters.AddWithValue("@productPolicyID", product.ProductPolicyID);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }

                return "Product data added successfully.";
            }
            catch (Exception eA)
            {
                return "The following error was encountered while trying to add Product data:\n\n" + eA.Message;
            }
        }
    }
}
