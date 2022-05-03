using RopeyDVDs.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RopeyDVDs.Repository
{
    public class MembershipCategoryRepo
    {
        GlobalConnection gb = new GlobalConnection();
        SqlCommand cmd;
        SqlDataAdapter da;
        public int Addmembershipcategory(String membershipcatdesc, String membershipcattotalloan)
        {
            cmd = new SqlCommand("Insert into MembershipCategory" + "(MemberShipCategoryDescription,MembershipCategoryTotalLoans) values " + "(@membershipcatdesc,@membershipcattotalloan)", gb.cn);
            cmd.Parameters.AddWithValue("@membershipcatdesc", membershipcatdesc);
            cmd.Parameters.AddWithValue("@membershipcattotalloan", membershipcattotalloan);
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
        public int UpdateMembershipCat(int membershipcatnum, String membershipcatdesc, String membershipcattotalloan)
        {
            cmd = new SqlCommand("Update MembershipCategory set MembershipCategoryDescription = @membershipcatdesc,MembershipCategoryTotalLoans=@membershipcattotalloan where MembershipCategoryNumber = @membershipcatnum", gb.cn);
            cmd.Parameters.AddWithValue("@membershipcatdesc", membershipcatdesc);
            cmd.Parameters.AddWithValue("@membershipcattotalloan", membershipcattotalloan);
            cmd.Parameters.AddWithValue("@membershipcatnum", membershipcatnum);

            int k = cmd.ExecuteNonQuery();
            gb.cn.Close();
            return k;
        }

        public int DeleteMembershipCategory(int id)
        {
            cmd = new SqlCommand("Delete from MembershipCategory where MembershipCategoryNumber = @id", gb.cn);
            cmd.Parameters.AddWithValue("@id", id);
           int k = cmd.ExecuteNonQuery();
            gb.cn.Close();
            return k;
        }
    }
}