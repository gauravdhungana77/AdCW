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
    public partial class Loan : System.Web.UI.Page
    {
        LoanRepo loan = new LoanRepo();
        public string role = string.Empty;
        public string username = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadloantypenumber();
                loadcopynumber();
                loadmembernumber();
                loadloan();
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

        public void loadloantypenumber()
        {
            try
            {

                loantypenumdrop.DataTextField = loan.Getloantypenumber().Columns["LoanType"].ToString();
                loantypenumdrop.DataValueField = loan.Getloantypenumber().Columns["LoanTypeNumber"].ToString();
                loantypenumdrop.DataSource = loan.Getloantypenumber();
                loantypenumdrop.DataBind();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Unable to load data from server.')", true);
            }

        }
        public void loadcopynumber()
        {
            try
            {

                copynumberdrop.DataTextField = loan.Getcopynumber().Columns["CopyNumber"].ToString();
                copynumberdrop.DataValueField = loan.Getcopynumber().Columns["CopyNumber"].ToString();
                copynumberdrop.DataSource = loan.Getcopynumber();
                copynumberdrop.DataBind();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Unable to load data from server.')", true);
            }

        }
        public void loadmembernumber()
        {
            try
            {

                membernumberdrop.DataTextField = loan.Getmember().Columns["MemberFirstName"].ToString();
                membernumberdrop.DataTextField = loan.Getmember().Columns["MemberNumber"].ToString();
                membernumberdrop.DataSource = loan.Getmember();
                membernumberdrop.DataBind();
            }
            catch (Exception ex)        
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Unable to load data from server.')", true);
            }

        }
        protected void add_Click(object sender, EventArgs e)
        {
            int loantypenumber = Int32.Parse(loantypenumdrop.SelectedValue);
            int copynumber = Int32.Parse(copynumberdrop.SelectedValue);
            int membernumber = Int32.Parse(membernumberdrop.SelectedValue);
            string dateout = Dateout.SelectedDate.ToShortDateString();
            string duedate = datedue.SelectedDate.ToShortDateString();
            string returndate = null;

            if (loantypenumber != 0 || copynumber != 0 || membernumber != 0 || !string.IsNullOrEmpty(dateout) || !string.IsNullOrEmpty(duedate))
            {
                int k = loan.Addloan(loantypenumber, copynumber, membernumber, dateout, duedate, returndate);

                if (k == 1)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Inserted Successfully')", true);
                    loadloan();
                    //surnametxt.Text = "";
                    //firstnametxt.Text = "";
                    //loadvisitors();
                }
                else if (k == 2)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Member category limit reached')", true);
                }
                else if (k == 3)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('DVD is age restricted')", true);
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Pleasse fill all the fields')", true);
            }
        }
    
        public void loadloan()
        {
            try
            {
                loanview.DataSource = loan.GetLoan();
                loanview.DataBind();


            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Unable to load data from server.')", true);
            }

        }

        protected void loancommandview(object sender, GridViewCommandEventArgs e)
        {
            GlobalConnection gc = new GlobalConnection();
            SqlCommand sql = new SqlCommand();
            string index = Convert.ToString(e.CommandArgument);
            int id = Int32.Parse(index);
            string strdata = "Select * from Loan where LoanNumber ='" + id + "'";
            SqlDataAdapter da = new SqlDataAdapter(strdata, gc.cn);


            DataSet ds = new DataSet();
            da.Fill(ds, "loan");
            DataTable dt = ds.Tables[0];

            loansnumber.Text = dt.Rows[0]["LoanNumber"].ToString();
            loantypenumdrop.SelectedValue = dt.Rows[0]["LoanTypeNumber"].ToString();
            copynumberdrop.SelectedValue = dt.Rows[0]["CopyNumber"].ToString();
            membernumberdrop.SelectedValue = dt.Rows[0]["MemberNumber"].ToString();
            Dateout.SelectedDate = Convert.ToDateTime(dt.Rows[0]["DateOut"].ToString());
            datedue.SelectedDate = Convert.ToDateTime(dt.Rows[0]["DateDue"].ToString());

            if (string.IsNullOrEmpty((dt.Rows[0]["DateReturned"].ToString())))
            {
                datereturned.SelectedDate = Convert.ToDateTime("1/1/0001");
            }
            else
            {
                datereturned.SelectedDate = Convert.ToDateTime(dt.Rows[0]["DateReturned"].ToString());
            }

            //sql = new SqlCommand("Delete from DVDCopy where CopyNumber = @copyid", gc.cn);
            //sql.Parameters.AddWithValue("@copyid", copyid);
            //sql.ExecuteNonQuery();
            //gc.cn.Close();
            //getExpiredCopies();
        }

        protected void Editbutton_Click(object sender, EventArgs e)
        {
            try
            {
                int loannumber = Int32.Parse(loansnumber.Text);
                int loantypenumber = Int32.Parse(loantypenumdrop.SelectedValue);
                int copynumber = Int32.Parse(copynumberdrop.SelectedValue);
                int membernumber = Int32.Parse(membernumberdrop.SelectedValue);
                string dateout = Dateout.SelectedDate.ToShortDateString();
                string duedate = datedue.SelectedDate.ToShortDateString();
                string returndate = datereturned.SelectedDate.ToShortDateString(); ;
                
                int k = loan.UpdateLoan(loannumber,loantypenumber, copynumber, membernumber, dateout, duedate, returndate);

                if (k != 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Updated Successfully')", true);
                    loadloan();

                    //surnametxt.Text = "";
                    //firstnametxt.Text = "";
                    //loadvisitors();
                }
                
                else 
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Unable to update loan details')", true);
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Enter value in correct format')", true);
            }
        }

        protected void delete_Click(object sender, EventArgs e)
        {
            try
            {
                int loanid = Int32.Parse(loansnumber.Text);
                int k = loan.DeleteLoan(loanid);
                if (k != 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Successfully deleted')", true);

                    loadloan();
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