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
    public partial class Studio : System.Web.UI.Page
    {
        StudioRepo studio = new StudioRepo();
        public string role = string.Empty;
        public string username = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadstudio();
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
        protected void Button1_Click(object sender, EventArgs e)
        {
            string studioname = studionametxt.Text;
            var random = new Random();
            int studioid = random.Next();
            int k = studio.AddStudio(studioid,studioname);

         
            if (k != 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Inserted Successfully')", true);
                loadstudio();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Unable to insert data')", true);
            }
            studionametxt.Text = "";
        }

        public void loadstudio()
        {
            try
            {
                studioview.DataSource = studio.GetStudios();
                studioview.DataBind();
                studio = null;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Unable to load data from server.')", true);
            }

        }
        protected void studioviewCommand(object sender, GridViewCommandEventArgs e)
        {
            GlobalConnection gc = new GlobalConnection();
            SqlCommand sql = new SqlCommand();
            string index = Convert.ToString(e.CommandArgument);
            string strdata = "Select * from Studio where StudioNumber ='" + index + "'";
            SqlDataAdapter da = new SqlDataAdapter(strdata, gc.cn);

            DataSet ds = new DataSet();
            da.Fill(ds, "Studio");
            DataTable dt = ds.Tables[0];
            studionum.Text = dt.Rows[0]["StudioNumber"].ToString();
            studionametxt.Text = dt.Rows[0]["StudioName"].ToString();
            

        }

        protected void edit_Click(object sender, EventArgs e)
        {
            string studioname = studionametxt.Text;
            string studionumber = studionum.Text;
            int k = studio.UpdateStudio(Int32.Parse(studionumber), studioname);

            if (k != 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Updated Successfully')", true);
                loadstudio();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Unable to update data')", true);
            }
            studionametxt.Text = "";
        }

        protected void delete_Click(object sender, EventArgs e)
        {
            try
            {
                int studioid = Int32.Parse(studionum.Text);
                int k = studio.DeleteStudio(studioid);
                if (k != 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Successfully deleted')", true);

                    loadstudio();
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