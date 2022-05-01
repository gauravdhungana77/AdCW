using RopeyDVDs.Repository;
using RopeyDVDs.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
            string agerest = ageresttxtdrop.SelectedValue;

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
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Unable to load data from server.')", true);
            }

        }

        protected void dvdcategoryviewCommand(object sender, GridViewCommandEventArgs e)
        {
            GlobalConnection gc = new GlobalConnection();
            SqlCommand sql = new SqlCommand();
            string index = Convert.ToString(e.CommandArgument);
            string strdata = "Select * from DVDCategory where CategoryNumber ='" + index + "'";
            SqlDataAdapter da = new SqlDataAdapter(strdata, gc.cn);

            DataSet ds = new DataSet();
            da.Fill(ds, "DVDCategory");
            DataTable dt = ds.Tables[0];

            categorynumber.Text = dt.Rows[0]["CategoryNumber"].ToString();
            catdesctxt.Text = dt.Rows[0]["CategoryDescription"].ToString();
            ageresttxtdrop.SelectedValue = dt.Rows[0]["AgeRestricted"].ToString();

        }

        protected void edit_Click(object sender, EventArgs e)
        {
            string catdesc = catdesctxt.Text;
            string agerest = ageresttxtdrop.SelectedValue;
            string dvdcat = categorynumber.Text;
            int k = dVDCategory.UpdateDvdCategory(Int32.Parse(dvdcat), catdesc, agerest);

            if (k != 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Updated Successfully')", true);
                loaddvdcategory();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Unable to update data')", true);
            }
            catdesctxt.Text = "";
        }
    }
}