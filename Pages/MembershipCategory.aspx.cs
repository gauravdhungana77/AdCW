﻿using RopeyDVDs.Repository;
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
    public partial class MembershipCategory : System.Web.UI.Page
    {
        MembershipCategoryRepo category = new MembershipCategoryRepo();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetMambershipCategory();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string desc = categorydesctxt.Text;
            string loan = membershiploantxt.Text;
            int k = category.Addmembershipcategory(desc, loan);

            if (k != 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Inserted Successfully')", true);
                GetMambershipCategory();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Unable to insert data')", true);
            }
            categorydesctxt.Text = "";
            membershiploantxt.Text = "";
        }
        public void GetMambershipCategory()
        {
            try
            {
                membershipcategoryview.DataSource = category.Getmembershipcategory();
                membershipcategoryview.DataBind();
                category = null;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Unable to load data from server.')", true);
            }

        }
        protected void membershipcategoryCommand(object sender, GridViewCommandEventArgs e)
        {
            GlobalConnection gc = new GlobalConnection();
            SqlCommand sql = new SqlCommand();
            string index = Convert.ToString(e.CommandArgument);
            string strdata = "Select * from MembershipCategory where MembershipCategoryNumber ='" + index + "'";
            SqlDataAdapter da = new SqlDataAdapter(strdata, gc.cn);

            DataSet ds = new DataSet();
            da.Fill(ds, "MembershipCategory");
            DataTable dt = ds.Tables[0];
            membershipcatnum.Text = dt.Rows[0]["MembershipCategoryNumber"].ToString();
            categorydesctxt.Text = dt.Rows[0]["MemberShipCategoryDescription"].ToString();
            membershiploantxt.Text = dt.Rows[0]["MembershipCategoryTotalLoans"].ToString();

        }

        protected void edit_Click(object sender, EventArgs e)
        {
            string desc = categorydesctxt.Text;
            string loan = membershiploantxt.Text;
            string membershipcatnumber = membershipcatnum.Text;
            int k = category.UpdateMembershipCat(Int32.Parse(membershipcatnumber),desc, loan);

            if (k != 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Updated Successfully')", true);
                GetMambershipCategory();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Unable to update data')", true);
            }
            categorydesctxt.Text = "";
            membershiploantxt.Text = "";
        }
    }
}