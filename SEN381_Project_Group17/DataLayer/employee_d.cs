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
    internal class employee_d
    {
        public employee_d()
        {
        }

        string con = "Server=.; Initial Catalog=ukupholisa; Integrated Security=SSPI";

        //Search
        public DataTable search(int id)
        {
            using (SqlConnection cn = new SqlConnection(con))
            {
                SqlCommand cmd = new SqlCommand("spSearchEmployee", cn);

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

            SqlDataAdapter adapter = new SqlDataAdapter("spGetEmployee", con);

            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            DataTable customerData = new DataTable();

            adapter.Fill(customerData); //uncomment this later

            return customerData;
        }

        //Update
        public string update(employee_b employee)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(con))
                {
                    SqlCommand cmd = new SqlCommand("spUpdateEmployee", cn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id", employee.EmployeeID);
                    cmd.Parameters.AddWithValue("@empName", employee.EmployeeName);
                    cmd.Parameters.AddWithValue("@email", employee.Email);
                    cmd.Parameters.AddWithValue("@phoneNumber", employee.PhoneNumber);
                    cmd.Parameters.AddWithValue("@role", employee.Role);
                    cmd.Parameters.AddWithValue("@userName", employee.UserName);
                    cmd.Parameters.AddWithValue("@password", employee.Password);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }

                return "Employee data updated successfully.";
            }
            catch (Exception eA)
            {
                return "The following error was encountered while trying to update Employee data:\n\n" + eA.Message;
            }
        }

        //Add
        public string add(employee_b employee)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(con))
                {
                    SqlCommand cmd = new SqlCommand("spAddEmployee", cn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@empName", employee.EmployeeName);
                    cmd.Parameters.AddWithValue("@email", employee.Email);
                    cmd.Parameters.AddWithValue("@phoneNumber", employee.PhoneNumber);
                    cmd.Parameters.AddWithValue("@role", employee.Role);
                    cmd.Parameters.AddWithValue("@userName", employee.UserName);
                    cmd.Parameters.AddWithValue("@password", employee.Password);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }

                return "Employee data added successfully.";
            }
            catch (Exception eA)
            {
                return "The following error was encountered while trying to add Employee data:\n\n" + eA.Message;
            }
        }

        //Delete
        public string delete(int employee)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(con))
                {
                    SqlCommand cmd = new SqlCommand("spDeleteEmployee", cn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id", employee);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }

                return "Employee data deleted successfully.";
            }
            catch (Exception eA)
            {
                return "The following error was encountered while trying to delete Employee data:\n\n" + eA.Message;
            }
        }

        //Check Login
        public string checkLogin(string userName, string password)
        {
            SqlConnection cn = new SqlConnection(con);

            SqlCommand cmd = new SqlCommand("spLogin", cn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@userName", userName);
            cmd.Parameters.AddWithValue("@passowrd", password);

            cn.Open();
            var role = cmd.ExecuteScalar();
            cn.Close();

            if (role != null)
            {
                return role.ToString();
            }
            else
            {
                return "No user founnd";
            }

        }
    }
}
