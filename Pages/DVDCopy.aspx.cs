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
    public partial class DVDCopy : System.Web.UI.Page
    {
        DVDCopyRepo dVDCopy = new DVDCopyRepo();
        public string role = string.Empty;
        public string username = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loaddvdnumber();
                loaddvdcopy();
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
            int dvdnumber = Int32.Parse(dvdnumberdrop.SelectedValue);
            string datepurchased = Calendar.SelectedDate.ToShortDateString();
            if (dvdnumber != 0 || !string.IsNullOrEmpty(datepurchased))
            {


                int k = dVDCopy.Adddvdcopy(dvdnumber, datepurchased);

                if (k != 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Inserted Successfully')", true);
                    //surnametxt.Text = "";
                    //firstnametxt.Text = "";
                    //loadvisitors();
                    loaddvdcopy();
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
      

        public void loaddvdnumber()
        {
            try
            {

                dvdnumberdrop.DataTextField = dVDCopy.Getdvdnum().Columns["DVDTitle"].ToString();
                dvdnumberdrop.DataValueField = dVDCopy.Getdvdnum().Columns["DVDNumber"].ToString();
                dvdnumberdrop.DataSource = dVDCopy.Getdvdnum();
                dvdnumberdrop.DataBind();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Unable to load data from server.')", true);
            }

        }
        public void loaddvdcopy()
        {
            try
            {
                dvdcopyview.DataSource = dVDCopy.Getdvdcopy();
                dvdcopyview.DataBind();


            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Unable to load data from server.')", true);
            }

        }
        protected void dvdcopyviewCommand(object sender, GridViewCommandEventArgs e)
        {
            GlobalConnection gc = new GlobalConnection();
            SqlCommand sql = new SqlCommand();
            string index = Convert.ToString(e.CommandArgument);
            string strdata = "Select * from DVDCopy where CopyNumber ='" + index + "'";
            SqlDataAdapter da = new SqlDataAdapter(strdata, gc.cn);

            DataSet ds = new DataSet();
            da.Fill(ds, "DVDCategory");
            DataTable dt = ds.Tables[0];

            copynumber.Text = dt.Rows[0]["CopyNumber"].ToString();
            dvdnumberdrop.SelectedValue = dt.Rows[0]["DVDNumber"].ToString();
            Calendar.SelectedDate =Convert.ToDateTime(dt.Rows[0]["DatePurchased"].ToString());
   

        }

        protected void edit_Click(object sender, EventArgs e)
        {
            int dvdnumber = Int32.Parse(dvdnumberdrop.SelectedValue);
            string datepurchased = Calendar.SelectedDate.ToShortDateString();
            string copynum = copynumber.Text;
            int k = dVDCopy.UpdateDvdCopy(Int32.Parse(copynum), dvdnumber, datepurchased);

            if (k != 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Updated Successfully')", true);
                //surnametxt.Text = "";
                //firstnametxt.Text = "";
                //loadvisitors();
                loaddvdcopy();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Unable to update data')", true);
            }
        }

        protected void delete_Click(object sender, EventArgs e)
        {

            try
            {
                int copyid = Int32.Parse(copynumber.Text);
                int k = dVDCopy.DeleteDvdCopy(copyid);
                if (k != 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Successfully deleted')", true);

                    loaddvdcopy();
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