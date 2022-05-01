using RopeyDVDs.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RopeyDVDs.Pages
{
    public partial class InactiveMembers : System.Web.UI.Page
    {
        InactiveMembersRepo inactive = new InactiveMembersRepo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getExpiredCopies();
            }

        }
        public void getExpiredCopies()
        {
            try
            {
                inactivememberview.DataSource = inactive.getinactivemembers();
                inactivememberview.DataBind();


            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Unable to load data from server.')", true);
            }
        }
    }
}