using RopeyDVDs.Repository;
using System;
using System.Collections.Generic;
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
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Unable to insert data')", true);
            }
            surnametxt.Text = "";
            firstnametxt.Text = "";
            
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
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Unable to load data from server due to ')", true);
            }

        }
    }
}