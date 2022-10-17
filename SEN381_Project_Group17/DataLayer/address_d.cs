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
    internal class address_d
    {
        public address_d()
        {
        }

        string con = "Server=.; Initial Catalog=ukupholisa; Integrated Security=SSPI";

        //Get
        public DataTable getAll()
        {
            SqlConnection cn = new SqlConnection(con);

            SqlDataAdapter adapter = new SqlDataAdapter("spGetAdress", con);

            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            DataTable customerData = new DataTable();

            adapter.Fill(customerData);

            return customerData;
        }

        //Update
        public string update(address_b adsress)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(con))
                {
                    SqlCommand cmd = new SqlCommand("spUpdateAddress", cn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id", adsress.AddressID);
                    cmd.Parameters.AddWithValue("@addressLine", adsress.AddressLine);
                    cmd.Parameters.AddWithValue("@city", adsress.City);
                    cmd.Parameters.AddWithValue("@province", adsress.Province);
                    cmd.Parameters.AddWithValue("@postalCode", adsress.PostalCode);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }

                return "Address data updated successfully.";
            }
            catch (Exception eA)
            {
                return "The following error was encountered while trying to update Address data:\n\n" + eA.Message;
            }
        }
    }
}
