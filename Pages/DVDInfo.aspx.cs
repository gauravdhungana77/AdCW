using RopeyDVDs.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RopeyDVDs.Pages
{
    public partial class DVDInfo : System.Web.UI.Page
    {
        DVDInfoRepo dVDInfo = new DVDInfoRepo();
        protected void Page_Load(object sender, EventArgs e)
        {
            getdvdinfo();
        }

        public void getdvdinfo()
        {
            try
            {
                Dvdinfoview.DataSource = dVDInfo.getdvddetailinfo();
                Dvdinfoview.DataBind();
                

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Unable to load data from server.')", true);
            }

        }
    }
}