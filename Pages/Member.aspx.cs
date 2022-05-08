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
    public partial class Member : System.Web.UI.Page
    {
        MemberRepo member = new MemberRepo();
        public string role = string.Empty;
        public string username = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadmembershipcategorynumber();
                loadmember();
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
        public void loadmembershipcategorynumber()
        {
            try
            {

                membershipcategorynumberdrop.DataTextField = member.Getmembershipcategory().Columns["MembershipCategoryDescription"].ToString();
                membershipcategorynumberdrop.DataValueField = member.Getmembershipcategory().Columns["MembershipCategoryNumber"].ToString();
                membershipcategorynumberdrop.DataSource = member.Getmembershipcategory();
                membershipcategorynumberdrop.DataBind();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Unable to load data from server.')", true);
            }

        }
        protected void add_Click(object sender, EventArgs e)
        {

            int membercategorynum = Int32.Parse(membershipcategorynumberdrop.SelectedValue);
            string lastname = lastnametxt.Text;
            string firstname = firstnametxt.Text;
            string memberaddress = memberaddresstxt.Text;
            string dateofbirth = dobcalander.SelectedDate.ToShortDateString();
            if (!string.IsNullOrEmpty(lastname) || !string.IsNullOrEmpty(firstname) || !string.IsNullOrEmpty(memberaddress) || !string.IsNullOrEmpty(dateofbirth) || membercategorynum != 0)
            {


                int k = member.Addmember(membercategorynum, lastname, firstname, memberaddress, dateofbirth);
                if (k != 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Inserted Successfully')", true);
                    loadmember();
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Unable to insert data')", true);
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Pleasse fill all the fields.')", true);
            }
        }
       

        public void loadmember()
        {
            try
            {
                memberview.DataSource = member.GetMember();
                memberview.DataBind();
                
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Unable to load data from server.')", true);
            }

        }
        protected void MemberviewCommand(object sender, GridViewCommandEventArgs e)
        {
            GlobalConnection gc = new GlobalConnection();
            SqlCommand sql = new SqlCommand();
            string index = Convert.ToString(e.CommandArgument);
            string strdata = "Select * from Member where MemberNumber ='" + index + "'";
            SqlDataAdapter da = new SqlDataAdapter(strdata, gc.cn);

            DataSet ds = new DataSet();
            da.Fill(ds, "LoanType");
            DataTable dt = ds.Tables[0];
            membernumber.Text = dt.Rows[0]["MemberNumber"].ToString();
            membershipcategorynumberdrop.SelectedValue = dt.Rows[0]["MembershipCategoryNumber"].ToString();
            lastnametxt.Text = dt.Rows[0]["MemberLastName"].ToString();
            firstnametxt.Text = dt.Rows[0]["MemberFirstName"].ToString();
            memberaddresstxt.Text = dt.Rows[0]["MemberAddress"].ToString();
            dobcalander.SelectedDate = Convert.ToDateTime(dt.Rows[0]["MemberDateOfBirth"].ToString());
        }

        protected void edit_Click(object sender, EventArgs e)
        {
            int membercategorynum = Int32.Parse(membershipcategorynumberdrop.SelectedValue);
            string lastname = lastnametxt.Text;
            string firstname = firstnametxt.Text;
            string memberaddress = memberaddresstxt.Text;
            string dateofbirth = dobcalander.SelectedDate.ToShortDateString();
            string membernum = membernumber.Text;
            int k = member.UpdateMember(Int32.Parse(membernum), membercategorynum, lastname, firstname,  memberaddress, dateofbirth);
            if (k != 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Updated Successfully')", true);
                loadmember();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Unable to update data')", true);
            }
        }

        protected void delete_Click(object sender, EventArgs e)
        {
            try
            {
                int loanid = Int32.Parse(membernumber.Text);
                int k = member.DeleteMember(loanid);
                if (k != 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Successfully deleted')", true);

                    loadmember();
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