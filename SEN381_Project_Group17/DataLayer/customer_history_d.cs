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
    internal class customer_history_d
    {
        public customer_history_d()
        {
        }

        string con = "Server=.; Initial Catalog=ukupholisa; Integrated Security=SSPI";

        //Search
        public DataTable search(int id)
        {
            using (SqlConnection cn = new SqlConnection(con))
            {
                SqlCommand cmd = new SqlCommand("spSearchCustomerHistory", cn);

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

            SqlDataAdapter adapter = new SqlDataAdapter("spGetCustomerHistory", con);

            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            DataTable customerData = new DataTable();

            adapter.Fill(customerData);

            return customerData;
        }

        //Update
        public string update(customer_history_b customerHistory)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(con))
                {
                    SqlCommand cmd = new SqlCommand("spUpdateCustomerHistory", cn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id", customerHistory.CusHistoryID);
                    cmd.Parameters.AddWithValue("@start", customerHistory.Start);
                    cmd.Parameters.AddWithValue("@end", customerHistory.End);
                    cmd.Parameters.AddWithValue("@active", customerHistory.Active);
                    cmd.Parameters.AddWithValue("@historyCustomerID", customerHistory.HistoryCustomerID);
                    cmd.Parameters.AddWithValue("@historyProductHistoryID", customerHistory.HistoryProductHistory);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }

                return "Customer History data updated successfully.";
            }
            catch (Exception eA)
            {
                return "The following error was encountered while trying to update Customer History data:\n\n" + eA.Message;
            }
        }

        //Add
        public string add(customer_history_b customerHistory)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(con))
                {
                    SqlCommand cmd = new SqlCommand("spAddCustomerHistory", cn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@start", customerHistory.Start);
                    cmd.Parameters.AddWithValue("@end", customerHistory.End);
                    cmd.Parameters.AddWithValue("@active", customerHistory.Active);
                    cmd.Parameters.AddWithValue("@historyCustomerID", customerHistory.HistoryCustomerID);
                    cmd.Parameters.AddWithValue("@historyProductHistoryID", customerHistory.HistoryProductHistory);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }

                return "Customer History data added successfully.";
            }
            catch (Exception eA)
            {
                return "The following error was encountered while trying to add Customer History data:\n\n" + eA.Message;
            }
        }
    }
}
