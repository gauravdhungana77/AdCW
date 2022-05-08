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
        public string role = string.Empty;
        public string username = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadUsers();
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
        protected void register_Click(object sender, EventArgs e)
        {
            string username = usernametxt.Text;
            string usertype = roledrop.SelectedValue;
            string password = passwordtxt.Text;

            DataTable dt = user.CheckUser(username);

            if (dt.Rows.Count == 0)
            {
                int k = user.AddUser(username, usertype, password);

                if (k != 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Inserted Successfully')", true);
                    loadUsers();
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Unable to insert data')", true);
                }
                usernametxt.Text = "";

                passwordtxt.Text = "";
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('User with this username already exists.')", true);
            }
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
            string strdata = "Select * from Users where UserNumber ='" + index + "'";
            SqlDataAdapter da = new SqlDataAdapter(strdata, gc.cn);

            DataSet ds = new DataSet();
            da.Fill(ds, "Users");
            DataTable dt = ds.Tables[0];
            usernumber.Text = dt.Rows[0]["UserNumber"].ToString();
            usernametxt.Text = dt.Rows[0]["UserName"].ToString();
            roledrop.SelectedValue = dt.Rows[0]["UserType"].ToString();
            passwordtxt.Text = dt.Rows[0]["UserPassword"].ToString();
            confpassword.Text = dt.Rows[0]["UserPassword"].ToString();


        }

        protected void edit_Click(object sender, EventArgs e)
        {
            try
            {
                int userid = Int32.Parse(usernumber.Text);
                string UserName = usernametxt.Text;
                string Password = passwordtxt.Text;
                string confirmpasword = confpassword.Text;
                string role = roledrop.SelectedValue;
                DataTable dt = user.CheckUser(UserName);

                if (Password.Equals(confirmpasword))
                {
                    int k = user.UpdateUser(userid, UserName, Password, role);

                    if (k != 0)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('User Updated Successfully')", true);
                        loadUsers();
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Unable to update data')", true);
                    }
                    usernametxt.Text = "";
                    passwordtxt.Text = "";
                    confpassword.Text = "";
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Password and confirm password doesnot match')", true);
                }

            }
            catch (FormatException)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please enter data in correct format')", true);
            }


        }

        protected void delete_Click(object sender, EventArgs e)
        {
            try
            {
                int Userid = Int32.Parse(usernumber.Text);
                int k = user.DeleteUser(Userid);
                if (k != 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('User Successfully deleted')", true);

                    loadUsers();
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Unable to delete user')", true);
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Unable to delete user')", true);
            }
        }

    
    }
}