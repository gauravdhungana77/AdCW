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
        public string role = string.Empty;
        public string username = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadproducer();
                loadcookies();
                if (string.IsNullOrEmpty(role))
                {

                    Response.Redirect("https://localhost:44360/Pages/Login.aspx");
                }
            }
        }
        public void loadcookies()
        {
            HttpCookie reqCookies = Request.Cookies["userInfo"];
            if (reqCookies != null)
            {
                username = reqCookies["Username"].ToString();
                role = reqCookies["role"].ToString();
            }
        }
        protected void add_Click(object sender, EventArgs e)
        {
            string producername = producernametxt.Text;
            if (!string.IsNullOrEmpty(producername))
            {
                var random = new Random();
                int producerid = random.Next();
                int k = producer.AddProducer(producerid, producername);

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
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please fill all the fields')", true);
            }
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
            try
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
            catch(FormatException)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Enter value in correct format')", true);
            }
        }

        protected void delete_Click(object sender, EventArgs e)
        {
            try
            {
                int producerid = Int32.Parse(producernum.Text);
                int k = producer.DeleteProducer(producerid);
                if (k != 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Successfully deleted')", true);

                    loadproducer();
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Unable to delete data')", true);
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Unable to delete data')", true);
            }
        }

      
    }
}