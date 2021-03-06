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
    public partial class LoanType : System.Web.UI.Page
    {
        LoanTypeRepo loan = new LoanTypeRepo();
        public string role = string.Empty;
        public string username = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadLoanType();
                loadcookies();
                if (string.IsNullOrEmpty(role))
                {

                    Response.Redirect("https://localhost:44360/Pages/Login.aspx");
                }
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
        protected void add_Click(object sender, EventArgs e)
        {
            string loantype = loantypetxt.Text;
            string duration = loandurationtxt.Text;
            if (!string.IsNullOrEmpty(loantype) || !string.IsNullOrEmpty(duration))
            {
                int k = loan.AddLoanType(loantype, duration);

                if (k != 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Inserted Successfully')", true);
                    loadLoanType();
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Unable to insert data')", true);
                }
                loantypetxt.Text = "";
                loandurationtxt.Text = "";
            }

            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please fill all the fields')", true);
            }
        }
        public void loadLoanType()
        {
            try
            {
                loantypeview.DataSource = loan.GetLoanType();
                loantypeview.DataBind();
                loan = null;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Unable to load data from server.')", true);
            }

        }
        protected void LoantypeCommand(object sender, GridViewCommandEventArgs e)
        {
            GlobalConnection gc = new GlobalConnection();
            SqlCommand sql = new SqlCommand();
            string index = Convert.ToString(e.CommandArgument);
            string strdata = "Select * from LoanType where LoanTypeNumber ='" + index + "'";
            SqlDataAdapter da = new SqlDataAdapter(strdata, gc.cn);

            DataSet ds = new DataSet();
            da.Fill(ds, "LoanType");
            DataTable dt = ds.Tables[0];
            loantypenumber.Text = dt.Rows[0]["LoanTypeNumber"].ToString();
            loantypetxt.Text = dt.Rows[0]["LoanType"].ToString();
            loandurationtxt.Text = dt.Rows[0]["LoanDuration"].ToString();

        }

        protected void edit_Click(object sender, EventArgs e)
        {
            try
            {
                string loantype = loantypetxt.Text;
                string duration = loandurationtxt.Text;
                string loantypenum = loantypenumber.Text;
                int k = loan.UpdateLoanType(Int32.Parse(loantypenum), loantype, duration);

                if (k != 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Updated Successfully')", true);
                    loadLoanType();
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Unable to update data')", true);
                }
                loantypetxt.Text = "";
                loandurationtxt.Text = "";
            }
            catch
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Enter value in correct format')", true);
            }
        }

        protected void delete_Click(object sender, EventArgs e)
        {
            try
            {
                int loantypeid = Int32.Parse(loantypenumber.Text);
                int k = loan.DeleteLoanType(loantypeid);
                if (k != 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Successfully deleted')", true);

                    loadLoanType();
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Unable to delete data')", true);
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Unable to delete data')", true);
            }
        }

      
    }
}