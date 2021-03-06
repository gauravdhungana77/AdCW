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
    public partial class Actors : System.Web.UI.Page
    {
        ActorRepo actor = new ActorRepo();
        public string role = string.Empty;
        public string username = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadvisitors();
                loadcookies();
                if (string.IsNullOrEmpty(role))
                {

                    Response.Redirect("https://localhost:44360/Pages/Login.aspx");
                }
            }
        }
        protected void add_Click(object sender, EventArgs e)
        {
            string lastname = surnametxt.Text;
            string firstname = firstnametxt.Text;
            if (!String.IsNullOrEmpty(lastname) || !String.IsNullOrEmpty(lastname))
            {
                var random = new Random();
                int actorid = random.Next();
                int k = actor.AddActor(actorid, lastname, firstname);

                if (k != 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Inserted Successfully')", true);
                    surnametxt.Text = "";
                    firstnametxt.Text = "";
                    loadvisitors();
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Unable to insert data')", true);
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please fill all the fields')", true);
            }
        }
           
        public void loadvisitors()
        {
            try
            {
                actorview.DataSource = actor.GetActors();
                actorview.DataBind();
                actor = null;

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Unable to load data from server.')", true);
            }

        }


        protected void actorviewCommand(object sender, GridViewCommandEventArgs e)
        {
            GlobalConnection gc = new GlobalConnection();
            SqlCommand sql = new SqlCommand();
            string index = Convert.ToString(e.CommandArgument);
            string strdata = "Select * from Actor where ActorNumber ='" + index + "'";
            SqlDataAdapter da = new SqlDataAdapter(strdata, gc.cn);

            DataSet ds = new DataSet();
            da.Fill(ds, "Actor");
            DataTable dt = ds.Tables[0];

            actornumber.Text = dt.Rows[0]["ActorNumber"].ToString();
            surnametxt.Text = dt.Rows[0]["ActorSurname"].ToString();
            firstnametxt.Text = dt.Rows[0]["ActorFirstName"].ToString();

        }

        protected void edit_Click(object sender, EventArgs e)
        {
            try
            {
                string lastname = surnametxt.Text;
                string firstname = firstnametxt.Text;
                string actornum = actornumber.Text;
                int k = actor.UpdateActor(Int32.Parse(actornum),lastname, firstname);

                if (k != 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Updated Successfully')", true);
                    surnametxt.Text = "";
                    firstnametxt.Text = "";
                    loadvisitors();
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Unable to update data')", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Unable to update actor details')", true);
            }
        }

        protected void delete_Click(object sender, EventArgs e)
        {
            try
            {
                int actorid = Int32.Parse(actornumber.Text);
               int k =  actor.DeleteActor(actorid);
                if (k != 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Successfully deleted')", true);
                   
                    loadvisitors();
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

        public void loadcookies()
        {
            HttpCookie reqCookies = Request.Cookies["userInfo"];
            if (reqCookies != null)
            {
                username = reqCookies["Username"].ToString();
                role = reqCookies["role"].ToString();
            }
        }

      
    }
}