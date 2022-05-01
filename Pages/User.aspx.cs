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
    public partial class User : System.Web.UI.Page
    {
        UserRepo user = new UserRepo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadUsers();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string username = usernametxt.Text;
            string usertype = usertypetxt.Text;
            string password = passwordtxt.Text;
            int k = user.AddUser(username, usertype, password);

            if (k != 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Inserted Successfully')", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Unable to insert data')", true);
            }
            usernametxt.Text = "";
            usertypetxt.Text = "";
            passwordtxt.Text = "";
        }

        public void loadUsers()
        {
            try
            {
                userview.DataSource = user.GetUser();
                userview.DataBind();
                user = null;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Unable to load data from server.')", true);
            }

        }
        protected void userviewCommand(object sender, GridViewCommandEventArgs e)
        {
            GlobalConnection gc = new GlobalConnection();
            SqlCommand sql = new SqlCommand();
            string index = Convert.ToString(e.CommandArgument);
            string strdata = "Select * from User where UserNumber ='" + index + "'";
            SqlDataAdapter da = new SqlDataAdapter(strdata, gc.cn);

            DataSet ds = new DataSet();
            da.Fill(ds, "User");
            DataTable dt = ds.Tables[0];

            usernametxt.Text = dt.Rows[0]["StudioName"].ToString();


        }
    }
}