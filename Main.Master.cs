using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RopeyDVDs
{
    public partial class Main : System.Web.UI.MasterPage
    {
        public string role = string.Empty;
        public string username = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            loadcookies();
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
        protected void logout_Click(object sender, EventArgs e)
        {
            HttpCookie reqCookies = Request.Cookies["userInfo"];
            if (reqCookies != null)
            {
                reqCookies.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(reqCookies);
                HttpContext.Current.Request.Cookies.Clear();
                Response.Redirect("https://localhost:44360/Default.aspx");
            }
        }
    }
}