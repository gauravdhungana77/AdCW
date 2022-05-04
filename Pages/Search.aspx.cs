using RopeyDVDs.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RopeyDVDs.Pages
{
    public partial class Search : System.Web.UI.Page
    {
        public string role = string.Empty;
        public string username = string.Empty;
        SearchRepo search = new SearchRepo();
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
    
    protected void searchbtn_Click(object sender, EventArgs e)
        {
            string searchvalue = searchbox.Text;
            if (!string.IsNullOrEmpty(searchvalue))
            {
                jointableview.DataSource = search.getSelectedmember(searchvalue);
                jointableview.DataBind();

                //ScriptManager.RegisterClientScriptBlock(this, Page.GetType(), "Pop",
                //       "OpenModal();",
                //       true);
                //ClientScript.RegisterStartupScript(this.GetType(), "Pop", "OpenModal();", true);
                //upModal.Update();
            }

            searchbox.Text = "";
            //ClientScript.RegisterStartupScript(this.GetType(), "Pop", "OpenModal();", true);


        }
        protected void searchbtn2_Click(object sender, EventArgs e)
        {
            string searchvalue = searchbox2.Text;
            if (!string.IsNullOrEmpty(searchvalue))
            {
                dvdcopiescount.DataSource = search.getdvdtitlewithcount(searchvalue);
                dvdcopiescount.DataBind();

            
                //ClientScript.RegisterStartupScript(this.GetType(), "copycount", "CopyCount();", true);
                
            }

            searchbox2.Text = "";
            
        }

        protected void searchbtn3_Click(object sender, EventArgs e)
        {
            string searchvalue = searchbox3.Text;
            if (!string.IsNullOrEmpty(searchvalue))
            {
                gridview3.DataSource = search.getmemberloan(searchvalue);
                gridview3.DataBind();

                
                //ClientScript.RegisterStartupScript(this.GetType(), "memberloan", "MemberLoan();", true);
               
            }

            searchbox3.Text = "";
            

           
        }

        protected void searchbtn4_Click(object sender, EventArgs e)
        {
            try
            {
                string searchvalue = searchbox4.Text;
                if (!string.IsNullOrEmpty(searchvalue))
                {
                    gridview4.DataSource = search.getlatestcopyloaned(Int32.Parse(searchvalue));
                    gridview4.DataBind();


                    //ClientScript.RegisterStartupScript(this.GetType(), "latestcopyloan", "copyLoan();", true);

                }

                searchbox4.Text = "";
            }
            catch
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Enter valid copy number')", true);
            }

        }
    }
}