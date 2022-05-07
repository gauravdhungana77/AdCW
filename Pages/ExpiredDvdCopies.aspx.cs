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
    public partial class ExpiredDvdCpoies : System.Web.UI.Page
    {
        ExpiredCopiesRepo expiredCopies = new ExpiredCopiesRepo();
        public string role = string.Empty;
        public string username = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getExpiredCopies();
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
        public void getExpiredCopies()
        {
            try
            {
                expireddvdcopies.DataSource = expiredCopies.getexpireddvdcopies();
                expireddvdcopies.DataBind();
                

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Unable to load data from server.')", true);
            }
        }
        protected void dvdcopyview(object sender, GridViewCommandEventArgs e)
        {
            GlobalConnection gc = new GlobalConnection();
            SqlCommand sql = new SqlCommand();
            string index = Convert.ToString(e.CommandArgument);
            int id = Int32.Parse(index);
            string strdata = "Select * from DVDCopy where CopyNumber ='" + id + "'";
            SqlDataAdapter da = new SqlDataAdapter(strdata, gc.cn);


            DataSet ds = new DataSet();
            da.Fill(ds, "DVDCopy");
            DataTable dt = ds.Tables[0];

            int copyid = Int32.Parse(dt.Rows[0]["CopyNumber"].ToString());
            //firstnametxt.Text = dt.Rows[0]["ActorFirstName"].ToString();

            sql = new SqlCommand("Delete from DVDCopy where CopyNumber = @copyid", gc.cn);
            sql.Parameters.AddWithValue("@copyid", copyid);
            sql.ExecuteNonQuery();
            gc.cn.Close();
            getExpiredCopies();
        }
    }
}