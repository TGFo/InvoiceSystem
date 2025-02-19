using System;
using System.Data;
using InvoiceSystem.DataAccess;

namespace InvoiceSystem
{
    public partial class Customers : System.Web.UI.Page
    {
        // Instantiate the customer repository.
        CustomerRepository repo = new CustomerRepository();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCustomers();
            }
        }

        // Binds the customer data to the GridView.
        private void BindCustomers()
        {
            GridViewCustomers.DataSource = repo.GetAllCustomers();
            GridViewCustomers.DataBind();
        }

        // Handles the Add/Update button click.
        protected void btnAddUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(hfCustomerID.Value))
            {
                // No CustomerID provided means we are adding a new customer.
                int newId = repo.AddCustomer(txtName.Text, txtAddress.Text, txtContactInfo.Text);
                lblMessage.Text = "Customer added with ID: " + newId;
            }
            else
            {
                // A CustomerID is present, so we update the existing customer.
                int customerId = int.Parse(hfCustomerID.Value);
                repo.UpdateCustomer(customerId, txtName.Text, txtAddress.Text, txtContactInfo.Text);
                lblMessage.Text = "Customer updated.";
                hfCustomerID.Value = "";
                btnAddUpdate.Text = "Add Customer";
            }
            ClearForm();
            BindCustomers();
        }

        // Handles the GridView RowCommand for edit and delete commands.
        protected void GridViewCustomers_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            int customerId = Convert.ToInt32(GridViewCustomers.DataKeys[index]["CustomerID"]);

            if (e.CommandName == "EditCustomer")
            {
                // When editing, retrieve the customer details and populate the form.
                DataRow dr = repo.GetCustomerById(customerId);
                if (dr != null)
                {
                    hfCustomerID.Value = customerId.ToString();
                    txtName.Text = dr["Name"].ToString();
                    txtAddress.Text = dr["Address"].ToString();
                    txtContactInfo.Text = dr["ContactInfo"].ToString();
                    btnAddUpdate.Text = "Update Customer";
                }
            }
            else if (e.CommandName == "DeleteCustomer")
            {
                // Delete the customer.
                repo.DeleteCustomer(customerId);
                lblMessage.Text = "Customer deleted.";
                BindCustomers();
            }
        }

        // Clears the input form.
        private void ClearForm()
        {
            txtName.Text = "";
            txtAddress.Text = "";
            txtContactInfo.Text = "";
        }
    }
}
