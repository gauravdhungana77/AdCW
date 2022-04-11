using RopeyDVDs.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RopeyDVDs.Pages
{
    public partial class Studio : System.Web.UI.Page
    {
        StudioRepo studio = new StudioRepo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadstudio();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string studioname = studionametxt.Text;
           
            int k = studio.AddStudio(studioname);

            if (k != 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Inserted Successfully')", true);
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
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Unable to load data from server due to ')", true);
            }

        }
    }
}