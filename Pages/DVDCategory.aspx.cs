using RopeyDVDs.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RopeyDVDs.Pages
{
    public partial class DVDCategory : System.Web.UI.Page
    {
        DVDCategoryRepo dVDCategory = new DVDCategoryRepo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loaddvdcategory();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string catdesc = catdesctxt.Text;
            string agerest = ageresttxt.Text;

            int k = dVDCategory.AddDvdCategory(catdesc, agerest);

            if (k != 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Inserted Successfully')", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Unable to insert data')", true);
            }
            catdesctxt.Text = "";
            ageresttxt.Text = "";
        }

        public void loaddvdcategory()
        {
            try
            {
                dvdcategoryview.DataSource = dVDCategory.GetDvdCategory();
                dvdcategoryview.DataBind();
                dVDCategory = null;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Unable to load data from server due to ')", true);
            }

        }
    }
}