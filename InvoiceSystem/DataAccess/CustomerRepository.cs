using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace InvoiceSystem.DataAccess
{
    public class CustomerRepository
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["InvoiceDBConnection"].ConnectionString;

        public DataTable GetAllCustomers()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("spGetAllCustomers", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                dt.Load(cmd.ExecuteReader());
            }
            return dt;
        }

        public DataRow GetCustomerById(int customerId)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("spGetCustomerById", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CustomerID", customerId);
                conn.Open();
                dt.Load(cmd.ExecuteReader());
            }
            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }

        public int AddCustomer(string name, string address, string contactInfo)
        {
            int newCustomerId = 0;
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("spAddCustomer", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Address", address);
                cmd.Parameters.AddWithValue("@ContactInfo", contactInfo);
                conn.Open();
                object result = cmd.ExecuteScalar();
                if (result != null)
                    newCustomerId = Convert.ToInt32(result);
            }
            return newCustomerId;
        }

        public void UpdateCustomer(int customerId, string name, string address, string contactInfo)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("spUpdateCustomer", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CustomerID", customerId);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Address", address);
                cmd.Parameters.AddWithValue("@ContactInfo", contactInfo);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteCustomer(int customerId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("spDeleteCustomer", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CustomerID", customerId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
