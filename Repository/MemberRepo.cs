using RopeyDVDs.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RopeyDVDs.Repository
{
    public class MemberRepo
    {
        GlobalConnection gb = new GlobalConnection();
        SqlCommand cmd;
        SqlDataAdapter da;

        public int Addmember(int membercategorynumber, string lastname, string firstname, string address, string dob)
        {
            cmd = new SqlCommand("Insert into Member" + "(MembershipCategoryNumber,MemberLastName,MemberFirstName,MemberAddress,MemberDateOfBirth) values " + "(@membercategorynumber,@lastname,@firstname,@address,@dob)", gb.cn);
            cmd.Parameters.AddWithValue("@membercategorynumber", membercategorynumber);
            cmd.Parameters.AddWithValue("@lastname", lastname);
            cmd.Parameters.AddWithValue("@firstname", firstname);
            cmd.Parameters.AddWithValue("@address", address);
            cmd.Parameters.AddWithValue("@dob", dob);
            int k = cmd.ExecuteNonQuery();
            gb.cn.Close();
            return k;


        }

        public DataTable Getmembershipcategory()
        {
            string qry = "Select * from MembershipCategory";
            da = new SqlDataAdapter(qry, gb.cn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0];
        }
        public DataTable GetMember()
        {
            string qry = "Select * from Member";
            da = new SqlDataAdapter(qry, gb.cn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0];
        }
        public int UpdateMember(int membernumber, int membercategorynumber, string lastname, string firstname, string address, string dob)
        {
            cmd = new SqlCommand("Update Member set MembershipCategoryNumber = @membercategorynumber,MemberLastName=@lastname,MemberFirstName=@firstname,MemberAddress=@address,MemberDateOfBirth=@dob where MemberNumber = @membernumber", gb.cn);
            cmd.Parameters.AddWithValue("@membercategorynumber", membercategorynumber);
            cmd.Parameters.AddWithValue("@lastname", lastname);
            cmd.Parameters.AddWithValue("@firstname", firstname);
            cmd.Parameters.AddWithValue("@address", address);
            cmd.Parameters.AddWithValue("@dob", dob);
            cmd.Parameters.AddWithValue("@membernumber", membernumber);

            int k = cmd.ExecuteNonQuery();
            gb.cn.Close();
            return k;
        }
    }
}