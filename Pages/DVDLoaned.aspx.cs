using RopeyDVDs.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RopeyDVDs.Pages
{
    public partial class DVDLoaned : System.Web.UI.Page
    {
        LoanedDVDRepo loanedDVD = new LoanedDVDRepo();
        protected void Page_Load(object sender, EventArgs e)
        {
            getloanneddvd();
        }

        public void getloanneddvd()
        {
            try
            {
                loaneddvdview.DataSource = loanedDVD.getloaneddvd();
                loaneddvdview.DataBind();


            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Unable to load data from server.')", true);
            }
        }
    }
}