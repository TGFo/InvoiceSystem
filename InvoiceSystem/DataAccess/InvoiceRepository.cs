using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace InvoiceSystem.DataAccess
{
    public class InvoiceRepository
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["InvoiceDBConnection"].ConnectionString;

        // Retrieves all invoices using the spGetAllInvoices stored procedure.
        public DataTable GetAllInvoices()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("spGetAllInvoices", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    dt.Load(cmd.ExecuteReader());
                }
            }
            return dt;
        }

        // Retrieves a single invoice by ID using the spGetInvoiceById stored procedure.
        public DataRow GetInvoiceById(int invoiceId)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("spGetInvoiceById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@InvoiceID", invoiceId);
                    conn.Open();
                    dt.Load(cmd.ExecuteReader());
                }
            }
            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }

        // Inserts a new invoice using the spAddInvoice stored procedure and returns the new InvoiceID.
        public int AddInvoice(int customerId, DateTime invoiceDate, decimal totalAmount)
        {
            int newInvoiceId = 0;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("spAddInvoice", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CustomerID", customerId);
                    cmd.Parameters.AddWithValue("@InvoiceDate", invoiceDate);
                    cmd.Parameters.AddWithValue("@TotalAmount", totalAmount);
                    conn.Open();
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        newInvoiceId = Convert.ToInt32(result);
                    }
                }
            }
            return newInvoiceId;
        }

        // Updates an existing invoice using the spUpdateInvoice stored procedure.
        public void UpdateInvoice(int invoiceId, int customerId, DateTime invoiceDate, decimal totalAmount)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("spUpdateInvoice", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@InvoiceID", invoiceId);
                    cmd.Parameters.AddWithValue("@CustomerID", customerId);
                    cmd.Parameters.AddWithValue("@InvoiceDate", invoiceDate);
                    cmd.Parameters.AddWithValue("@TotalAmount", totalAmount);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Deletes an invoice using the spDeleteInvoice stored procedure.
        public void DeleteInvoice(int invoiceId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("spDeleteInvoice", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@InvoiceID", invoiceId);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public DataTable GetInvoiceItems(int invoiceId)
        {
            InvoiceItemRepository itemRepo = new InvoiceItemRepository();
            return itemRepo.GetInvoiceItems(invoiceId);
        }
    }
}
