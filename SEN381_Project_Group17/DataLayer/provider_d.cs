﻿using SEN381_Project_Group17.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEN381_Project_Group17.DataLayer
{
    internal class provider_d
    {
        public provider_d()
        {
        }

        string con = "Server=.; Initial Catalog=ukupholisa; Integrated Security=SSPI";

        //Search
        public DataTable search(int id)
        {
            using (SqlConnection cn = new SqlConnection(con))
            {
                SqlCommand cmd = new SqlCommand("spSearchProvider", cn);

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

            SqlDataAdapter adapter = new SqlDataAdapter("spGetProvider", con);

            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            DataTable customerData = new DataTable();

            adapter.Fill(customerData); 

            return customerData;
        }

        //Update
        public string update(provider_b provider)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(con))
                {
                    SqlCommand cmd = new SqlCommand("spUpdateProvider", cn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id", provider.ProviderID);
                    cmd.Parameters.AddWithValue("@providerName", provider.ProviderName);
                    cmd.Parameters.AddWithValue("@status", provider.Status);
                    cmd.Parameters.AddWithValue("@province", provider.Province);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }

                return "Provider data updated successfully.";
            }
            catch (Exception eA)
            {
                return "The following error was encountered while trying to update Provider data:\n\n" + eA.Message;
            }
        }

        //Add
        public string add(provider_b provider)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(con))
                {
                    SqlCommand cmd = new SqlCommand("spAddProvider", cn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@providerName", provider.ProviderName);
                    cmd.Parameters.AddWithValue("@status", provider.Status);
                    cmd.Parameters.AddWithValue("@province", provider.Province);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }

                return "Provider data added successfully.";
            }
            catch (Exception eA)
            {
                return "The following error was encountered while trying to add Provider data:\n\n" + eA.Message;
            }
        }

        //Delete
        public string delete(int provider)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(con))
                {
                    SqlCommand cmd = new SqlCommand("spDeleteProvider", cn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id", provider);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }

                return "Provider data deleted successfully.";
            }
            catch (Exception eA)
            {
                return "The following error was encountered while trying to delete Provider data:\n\n" + eA.Message;
            }
        }
    }
}
