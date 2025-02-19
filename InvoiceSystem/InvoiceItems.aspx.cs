using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using InvoiceSystem.DataAccess;

namespace InvoiceSystem
{
    public partial class InvoiceItems : System.Web.UI.Page
    {
        InvoiceItemRepository repo = new InvoiceItemRepository();
        int invoiceId;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Ensure an InvoiceID is provided in the query string.
                if (!int.TryParse(Request.QueryString["InvoiceID"], out invoiceId))
                {
                    lblMessage.Text = "InvoiceID not provided.";
                    return;
                }
                BindInvoiceItems();
                BindItemsDropdown();
            }
        }

        // Bind the grid with invoice items for the current invoice.
        private void BindInvoiceItems()
        {
            DataTable dt = repo.GetInvoiceItems(invoiceId);
            GridViewInvoiceItems.DataSource = dt;
            GridViewInvoiceItems.DataBind();
        }

        // Bind the Items dropdown list from the Items table.
        private void BindItemsDropdown()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["InvoiceDBConnection"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT ItemID, Name FROM Items";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    dt.Load(cmd.ExecuteReader());
                    ddlItems.DataSource = dt;
                    ddlItems.DataTextField = "Name";
                    ddlItems.DataValueField = "ItemID";
                    ddlItems.DataBind();
                }
            }
        }

        // Handle adding a new invoice item or updating an existing one.
        protected void btnAddUpdate_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(Request.QueryString["InvoiceID"], out invoiceId))
            {
                lblMessage.Text = "Invalid InvoiceID.";
                return;
            }

            int itemId = int.Parse(ddlItems.SelectedValue);
            int quantity;
            if (!int.TryParse(txtQuantity.Text, out quantity))
            {
                lblMessage.Text = "Enter a valid quantity.";
                return;
            }

            // Check whether we are adding a new item or updating an existing one.
            if (string.IsNullOrEmpty(hfInvoiceItemID.Value))
            {
                // Add new invoice item.
                int newId = repo.AddInvoiceItem(invoiceId, itemId, quantity);
                lblMessage.Text = "Invoice item added with ID: " + newId;
            }
            else
            {
                // Update existing invoice item.
                int invoiceItemId = int.Parse(hfInvoiceItemID.Value);
                repo.UpdateInvoiceItem(invoiceItemId, invoiceId, itemId, quantity);
                lblMessage.Text = "Invoice item updated.";
                hfInvoiceItemID.Value = "";
                btnAddUpdate.Text = "Add Invoice Item";
            }
            txtQuantity.Text = "";
            BindInvoiceItems();
        }

        // Handle GridView commands for editing or deleting an invoice item.
        protected void GridViewInvoiceItems_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            // Retrieve the row index.
            int index = Convert.ToInt32(e.CommandArgument);
            // Retrieve the DataKeys from the GridView.
            int invoiceItemId = Convert.ToInt32(GridViewInvoiceItems.DataKeys[index]["InvoiceItemID"]);
            if (e.CommandName == "EditItem")
            {
                // When editing, populate the form controls.
                hfInvoiceItemID.Value = invoiceItemId.ToString();
                int itemId = Convert.ToInt32(GridViewInvoiceItems.DataKeys[index]["ItemID"]);
                ddlItems.SelectedValue = itemId.ToString();

                // Retrieve quantity from the GridView cell.
                string quantityText = GridViewInvoiceItems.Rows[index].Cells[2].Text;
                txtQuantity.Text = quantityText;
                btnAddUpdate.Text = "Update Invoice Item";
            }
            else if (e.CommandName == "DeleteItem")
            {
                // Delete the invoice item.
                repo.DeleteInvoiceItem(invoiceItemId);
                lblMessage.Text = "Invoice item deleted.";
                BindInvoiceItems();
            }
        }
    }
}
