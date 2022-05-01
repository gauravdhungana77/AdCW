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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadvisitors();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
          
            string lastname = surnametxt.Text;
            string firstname = firstnametxt.Text;
            int k = actor.AddActor(lastname,firstname);
         
            if (k !=0)
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
    }
}