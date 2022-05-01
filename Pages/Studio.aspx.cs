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
    }
}