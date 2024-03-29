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
    internal class product_history_d
    {
        public product_history_d()
        {
        }

        string con = "Server=.; Initial Catalog=ukupholisa; Integrated Security=SSPI";

        //Search
        public DataTable search(int id)
        {
            using (SqlConnection cn = new SqlConnection(con))
            {
                SqlCommand cmd = new SqlCommand("spSearchProductHistory", cn);

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

            SqlDataAdapter adapter = new SqlDataAdapter("spGetProductHistory", con);

            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            DataTable customerData = new DataTable();

            adapter.Fill(customerData);

            return customerData;
        }

        //Update
        public string update(product_history_b productHistory)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(con))
                {
                    SqlCommand cmd = new SqlCommand("spUpdateProductHistory", cn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id", productHistory.PorHistoryID);
                    cmd.Parameters.AddWithValue("@start", productHistory.Start);
                    cmd.Parameters.AddWithValue("@end", productHistory.End);
                    cmd.Parameters.AddWithValue("@historyProductID", productHistory.HistoryProductID);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }

                return "Product History data updated successfully.";
            }
            catch (Exception eA)
            {
                return "The following error was encountered while trying to update Product History data:\n\n" + eA.Message;
            }
        }

        //Add
        public string add(product_history_b productHistory)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(con))
                {
                    SqlCommand cmd = new SqlCommand("spAddProductHistory", cn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@start", productHistory.Start);
                    cmd.Parameters.AddWithValue("@end", productHistory.End);
                    cmd.Parameters.AddWithValue("@historyProductID", productHistory.HistoryProductID);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }

                return "Product History data added successfully.";
            }
            catch (Exception eA)
            {
                return "The following error was encountered while trying to add Product History data:\n\n" + eA.Message;
            }
        }
    }
}
