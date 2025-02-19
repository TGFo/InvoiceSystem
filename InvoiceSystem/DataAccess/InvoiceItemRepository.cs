using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace InvoiceSystem.DataAccess
{
    public class InvoiceItemRepository
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["InvoiceDBConnection"].ConnectionString;

        // Retrieves invoice items using the spGetInvoiceItems stored procedure.
        public DataTable GetInvoiceItems(int invoiceId)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("spGetInvoiceItems", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@InvoiceID", invoiceId);
                    conn.Open();
                    dt.Load(cmd.ExecuteReader());
                }
            }
            return dt;
        }

        // Inserts a new invoice itme using the spAddInvoiceItem stored procedure and returns the new InvoiceItemID
        public int AddInvoiceItem(int invoiceId, int itemId, int quantity)
        {
            int newInvoiceItemId = 0;
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("spAddInvoiceItem", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@InvoiceID", invoiceId);
                cmd.Parameters.AddWithValue("@ItemID", itemId);
                cmd.Parameters.AddWithValue("@Quantity", quantity);
                conn.Open();
                object result = cmd.ExecuteScalar();
                if (result != null)
                    newInvoiceItemId = Convert.ToInt32(result);
            }
            return newInvoiceItemId;
        }

        public void UpdateInvoiceItem(int invoiceItemId, int invoiceId, int itemId, int quantity)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("spUpdateInvoiceItem", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@InvoiceItemID", invoiceItemId);
                cmd.Parameters.AddWithValue("@InvoiceID", invoiceId);
                cmd.Parameters.AddWithValue("@ItemID", itemId);
                cmd.Parameters.AddWithValue("@Quantity", quantity);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteInvoiceItem(int invoiceItemId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("spDeleteInvoiceItem", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@InvoiceItemID", invoiceItemId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
