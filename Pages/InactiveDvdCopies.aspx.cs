using RopeyDVDs.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RopeyDVDs.Pages
{
    public partial class InactiveDvdCopies : System.Web.UI.Page
    {
        InactiveDvdCopiesRepo inactiveDvdcopies = new InactiveDvdCopiesRepo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getinactivedvdcopiesCopies();
            }
        }
        public void getinactivedvdcopiesCopies()
        {
            try
            {
                inactivcopiesview.DataSource = inactiveDvdcopies.getinactivedvdcopies();
                inactivcopiesview.DataBind();


            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Unable to load data from server.')", true);
            }
        }
    }
}