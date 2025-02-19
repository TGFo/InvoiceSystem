using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InvoiceSystem.DataAccess;

namespace InvoiceSystem
{
    public partial class InvoiceDetails : System.Web.UI.Page
    {
        InvoiceRepository repo = new InvoiceRepository();
        int invoiceId;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Validate and retrieve InvoiceID from the query string.
                if (int.TryParse(Request.QueryString["InvoiceID"], out invoiceId))
                {
                    // Bind invoice header details and items.
                    BindInvoiceDetails(invoiceId);
                    LoadInvoiceItems(invoiceId);
                    // Bind customers to the update form's dropdown.
                    BindCustomers();
                }
                else
                {
                    lblMessage.Text = "Invalid Invoice ID.";
                }
            }
        }

        // Loads the invoice header details and fills the update form controls.
        private void BindInvoiceDetails(int invoiceId)
        {
            DataRow dr = repo.GetInvoiceById(invoiceId);
            if (dr != null)
            {
                // Display invoice header details.
                lblInvoiceInfo.Text = "Invoice ID: " + dr["InvoiceID"] + "<br />" +
                                      "Invoice Date: " + Convert.ToDateTime(dr["InvoiceDate"]).ToShortDateString() + "<br />" +
                                      "Total Amount: " + Convert.ToDecimal(dr["TotalAmount"]).ToString("C");

                // Populate update form controls.
                txtInvoiceDate.Text = Convert.ToDateTime(dr["InvoiceDate"]).ToString("yyyy-MM-dd");
                txtTotal.Text = Convert.ToDecimal(dr["TotalAmount"]).ToString();

                // Set the selected customer in the dropdown.
                if (dr.Table.Columns.Contains("CustomerID"))
                {
                    ddlCustomers.SelectedValue = dr["CustomerID"].ToString();
                }
            }
            else
            {
                lblInvoiceInfo.Text = "Invoice not found.";
            }
        }

        // Loads invoice items into the GridView.
        private void LoadInvoiceItems(int invoiceId)
        {
            DataTable dt = repo.GetInvoiceItems(invoiceId);
            GridViewItems.DataSource = dt;
            GridViewItems.DataBind();
        }

        // Loads the customer list into the dropdown for the update form.
        private void BindCustomers()
        {
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

        // Handles updating the invoice.
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (int.TryParse(Request.QueryString["InvoiceID"], out invoiceId))
            {
                int customerId = int.Parse(ddlCustomers.SelectedValue);
                DateTime invoiceDate = DateTime.Parse(txtInvoiceDate.Text);
                decimal totalAmount = decimal.Parse(txtTotal.Text);

                // Call the repository method to update the invoice.
                repo.UpdateInvoice(invoiceId, customerId, invoiceDate, totalAmount);
                lblMessage.Text = "Invoice updated successfully!";
                // Refresh the displayed details.
                BindInvoiceDetails(invoiceId);
            }
        }

        // Handles deleting the invoice.
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (int.TryParse(Request.QueryString["InvoiceID"], out invoiceId))
            {
                // Call the repository method to delete the invoice.
                repo.DeleteInvoice(invoiceId);
                Response.Redirect("Default.aspx");
            }
        }
    }
}