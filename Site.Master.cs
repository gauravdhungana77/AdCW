using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RopeyDVDs
{
    public partial class SiteMaster : MasterPage
    {
       public string role = string.Empty;
       public string username = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            loadcookies();
            if (string.IsNullOrEmpty(role))
            {

                Response.Redirect("https://localhost:44360/Pages/Login.aspx");
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