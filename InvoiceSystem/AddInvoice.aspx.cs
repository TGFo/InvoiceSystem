using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InvoiceSystem.DataAccess;

namespace InvoiceSystem
{
    public partial class AddInvoice : System.Web.UI.Page
    {
        InvoiceRepository repo = new InvoiceRepository();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCustomers();
            }
        }

        // Loads customers into the DropDownList.
        private void BindCustomers()
        {
            // Using a direct query for customer list loading.
            string connectionString = ConfigurationManager.ConnectionStrings["InvoiceDBConnection"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT CustomerID, Name FROM Customers";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    dt.Load(cmd.ExecuteReader());
                    ddlCustomers.DataSource = dt;
                    ddlCustomers.DataTextField = "Name";
                    ddlCustomers.DataValueField = "CustomerID";
                    ddlCustomers.DataBind();
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int customerId = int.Parse(ddlCustomers.SelectedValue);
            DateTime invoiceDate = DateTime.Parse(txtDate.Text);
            decimal totalAmount = decimal.Parse(txtTotal.Text);

            // Insert the invoice using our repository (which uses stored procedures).
            int newInvoiceId = repo.AddInvoice(customerId, invoiceDate, totalAmount);

            // Redirect to the invoice details page for the newly created invoice.
            Response.Redirect("InvoiceDetails.aspx?InvoiceID=" + newInvoiceId);
        }
    }
}