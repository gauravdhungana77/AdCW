using RopeyDVDs.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RopeyDVDs.Pages
{
    public partial class Login : System.Web.UI.Page
    {
        LoginRepo login = new LoginRepo();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void loginbtn_Click(object sender, EventArgs e)
        {
            try
            {
                string username = usernametxt.Text;
                string password = passwordtxt.Text;
                string role = roledrop.SelectedValue;
         
                DataTable dt = login.CheckUser(username, password,
                    role);

                if (dt.Rows.Count > 0)
                {
                    string uname = dt.Rows[0]["Username"].ToString();
                    string pwd = dt.Rows[0]["UserPassword"].ToString();
                    string usertype = dt.Rows[0]["UserType"].ToString();
                    if (uname.Equals(username) && pwd.Equals(password) && usertype.Equals(role))
                    {
                        HttpCookie userInfo = new HttpCookie("userInfo");
                        userInfo["username"] = uname;
                        userInfo["role"] = usertype;
                        
                       
                        Response.Cookies.Add(userInfo);
                        
                        //Response.Cookies["role"].Value = usertype;
                        //Response.Cookies["username"].Value = uname;

                        Session["role"] = usertype;
                        Session["username"] = uname;

                        Response.Redirect("https://localhost:44360/Default.aspx");
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Wrong Username and password')", true);
                        
                    }

                    //if (uname.Equals(TextBox1.Text) && pwd.Equals(TextBox2.Text) && usertype.Equals(DropDown_type.SelectedItem.Value = "Normal"))
                    //{
                    //    //  Session["user_name"] = txtUsername.Text;
                    //    Session["normal"] = DropDown_type.SelectedIndex == 0;
                    //    Session["username"] = TextBox1.Text;


                    //    Response.Redirect("dashboard.aspx");
                    //}
                    //else
                    //{
                    //    ltrMessage.Text = "Wrong Username and password";
                    //}
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Wrong Username and password')", true);
                }

            }
            catch (Exception ex)
            {

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Wrong Username and password')", true);
            }
        }
    }
    
}