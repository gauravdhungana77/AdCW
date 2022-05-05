using RopeyDVDs.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RopeyDVDs.Pages
{
    public partial class TooManyDvd : System.Web.UI.Page
    {
        TooManyDvdRepo tooMany = new TooManyDvdRepo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getoverloanned();
            }
        }
        public void getoverloanned()
        {
            try
            {
                overloaneddvd.DataSource = tooMany.getoverloanedmembers ();
                overloaneddvd.DataBind();


            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Unable to load data from server.')", true);
            }
        }
    }
}