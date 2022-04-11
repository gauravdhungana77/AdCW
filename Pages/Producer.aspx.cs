using RopeyDVDs.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RopeyDVDs.Pages
{
    public partial class Producer : System.Web.UI.Page
    {
        ProducerRepo producer = new ProducerRepo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadproducer();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string producername = producernametxt.Text;

            int k = producer.AddProducer(producername);

            if (k != 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Inserted Successfully')", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Unable to insert data')", true);
            }
            producernametxt.Text = "";
        }

        public void loadproducer()
        {
            try
            {
                producerview.DataSource = producer.GetProducer();
                producerview.DataBind();
                producer = null;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Unable to load data from server due to ')", true);
            }

        }
    }
}