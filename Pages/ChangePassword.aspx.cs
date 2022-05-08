using RopeyDVDs.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RopeyDVDs.Pages
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        public string role = string.Empty;
        public string username = string.Empty;
        ChangePasswordRepo changepassword = new ChangePasswordRepo();


        protected void Page_Load(object sender, EventArgs e)
        {
            loadcookies();
            if (string.IsNullOrEmpty(role))
            {
                Response.Redirect("https://localhost:44360/Pages/Login.aspx");
            }
        }
  

        protected void changepass_Click(object sender, EventArgs e)
        {         
            try
            {
                string currentpass = currentpasswtxt.Text;
                string newpass = newpasswordtxt.Text;
                string confirmpassword = confpassword.Text;

                if (!string.IsNullOrEmpty(currentpass) || !string.IsNullOrEmpty(newpass) || !string.IsNullOrEmpty(confirmpassword))
                {

                    if (newpass.Equals(confirmpassword))
                    {
                        int k = changepassword.ChangePassword(username, newpass);

                        if (k != 0)
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Password Successfully Changed')", true);

                        }
                        else
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Unable to change password')", true);
                        }
                        currentpasswtxt.Text = "";
                        newpasswordtxt.Text = "";
                        confpassword.Text = "";
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Password and confirm password doesnot match')", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please fill all the fields')", true);
                }

            }
            catch (FormatException)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please enter data in correct format')", true);
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
