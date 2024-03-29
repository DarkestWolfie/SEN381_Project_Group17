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
    internal class application_d
    {
        public application_d()
        {
        }

        string con = "Server=.; Initial Catalog=ukupholisa; Integrated Security=SSPI";

        //Search
        public DataTable search(int id)
        {
            using (SqlConnection cn = new SqlConnection(con))
            {
                SqlCommand cmd = new SqlCommand("spSearchApplication", cn);

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

            SqlDataAdapter adapter = new SqlDataAdapter("spGetApplication", con);

            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            DataTable customerData = new DataTable();

            adapter.Fill(customerData);

            return customerData;
        }

        //Update
        public string update(application_b application)
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
                    cmd.Parameters.AddWithValue("@applicationCustomerID", application.ApplicationCustomerID);
                    cmd.Parameters.AddWithValue("@applicationConditionID", application.ApplicationConditionID);
                    cmd.Parameters.AddWithValue("@applicationProviderID", application.ApplicationProviderID);

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

        //Add
        public string add(application_b application)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(con))
                {
                    SqlCommand cmd = new SqlCommand("spAddApplication", cn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@applicationDate", application.ApplicationDate);
                    cmd.Parameters.AddWithValue("@status", application.Status);
                    cmd.Parameters.AddWithValue("@applicationCustomerID", application.ApplicationCustomerID);
                    cmd.Parameters.AddWithValue("@applicationConditionID", application.ApplicationConditionID);
                    cmd.Parameters.AddWithValue("@applicationProviderID", application.ApplicationProviderID);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }

                return "Application data added successfully.";
            }
            catch (Exception eA)
            {
                return "The following error was encountered while trying to add Application data:\n\n" + eA.Message;
            }
        }

        //Delete
        public string delete(int application)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(con))
                {
                    SqlCommand cmd = new SqlCommand("spDeleteApplication", cn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id", application);
                    
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }

                return "Application data deleted successfully.";
            }
            catch (Exception eA)
            {
                return "The following error was encountered while trying to delete Application data:\n\n" + eA.Message;
            }
        }
    }
}
