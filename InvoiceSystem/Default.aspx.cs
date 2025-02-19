using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InvoiceSystem.DataAccess;

namespace InvoiceSystem
{
    public partial class _Default : Page
    {
        // Create an instance of our InvoiceRepository.
        InvoiceRepository repo = new InvoiceRepository();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindInvoices();
            }
        }

        private void BindInvoices()
        {
            DataTable dt = repo.GetAllInvoices();
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }
}