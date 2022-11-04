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
    internal class treatment_d
    {
        public treatment_d()
        {
        }

        string con = "Server=.; Initial Catalog=ukupholisa; Integrated Security=SSPI";

        //Search
        public DataTable search(int id)
        {
            using (SqlConnection cn = new SqlConnection(con))
            {
                SqlCommand cmd = new SqlCommand("spSearchTreatment", cn);

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

            SqlDataAdapter adapter = new SqlDataAdapter("spGetTreatment", con);

            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            DataTable customerData = new DataTable();

            adapter.Fill(customerData);

            return customerData;
        }

        //Update
        public string update(treatment_b treatment)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(con))
                {
                    SqlCommand cmd = new SqlCommand("spUpdateTreatment", cn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id", treatment.TreatmentID);
                    cmd.Parameters.AddWithValue("@treatmentName", treatment.TreatmentName);
                    cmd.Parameters.AddWithValue("@description", treatment.Description);
                    cmd.Parameters.AddWithValue("@cost", treatment.Cost);
                    cmd.Parameters.AddWithValue("@treatmentConditionID", treatment.TreatmentConditionID);
                    cmd.Parameters.AddWithValue("@treatmentProviderID", treatment.TreatmentProviderID);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }

                return "Treatment data updated successfully.";
            }
            catch (Exception eA)
            {
                return "The following error was encountered while trying to update Treatment data:\n\n" + eA.Message;
            }
        }

        //Add
        public string add(treatment_b treatment)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(con))
                {
                    SqlCommand cmd = new SqlCommand("spAddTreatment", cn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@treatmentName", treatment.TreatmentName);
                    cmd.Parameters.AddWithValue("@description", treatment.Description);
                    cmd.Parameters.AddWithValue("@cost", treatment.Cost);
                    cmd.Parameters.AddWithValue("@treatmentConditionID", treatment.TreatmentConditionID);
                    cmd.Parameters.AddWithValue("@treatmentProviderID", treatment.TreatmentProviderID);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }

                return "Treatment data added successfully.";
            }
            catch (Exception eA)
            {
                return "The following error was encountered while trying to add Treatment data:\n\n" + eA.Message;
            }
        }

        //Delete
        public string delete(int treatment)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(con))
                {
                    SqlCommand cmd = new SqlCommand("spDeleteTreatment", cn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id", treatment);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }

                return "Treatment data deleted successfully.";
            }
            catch (Exception eA)
            {
                return "The following error was encountered while trying to delete Treatment data:\n\n" + eA.Message;
            }
        }
    }
}
