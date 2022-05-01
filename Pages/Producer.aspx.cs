using RopeyDVDs.Repository;
using RopeyDVDs.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
                loadproducer();
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
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Unable to load data from server.')", true);
            }

        }
        protected void producerviewNumber(object sender, GridViewCommandEventArgs e)
        {
            GlobalConnection gc = new GlobalConnection();
            SqlCommand sql = new SqlCommand();
            string index = Convert.ToString(e.CommandArgument);
            string strdata = "Select * from Producer where ProducerNumber ='" + index + "'";
            SqlDataAdapter da = new SqlDataAdapter(strdata, gc.cn);

            DataSet ds = new DataSet();
            da.Fill(ds, "Producer");
            DataTable dt = ds.Tables[0];

            producernum.Text = dt.Rows[0]["ProducerNumber"].ToString();
            producernametxt.Text = dt.Rows[0]["ProducerName"].ToString();
           
        }

        protected void edit_Click(object sender, EventArgs e)
        {
            string producername = producernametxt.Text;
            string producernumber = producernum.Text;
            int k = producer.UpdateProducer(Int32.Parse(producernumber), producername);

            if (k != 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Updated Successfully')", true);
                loadproducer();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Unable to update data')", true);
            }
            producernametxt.Text = "";
        }
    }
}