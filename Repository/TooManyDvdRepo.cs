using RopeyDVDs.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RopeyDVDs.Repository
{
    public class TooManyDvdRepo
    {
        GlobalConnection gb = new GlobalConnection();
        SqlCommand cmd;
        SqlDataAdapter da;

        public DataTable getoverloanedmembers()
        {
            string query = "Select Member.MemberFirstName,member.MemberLastName,Member.MemberDateOfBirth,Member.MemberAddress,MembershipCategory.MembershipCategoryTotalLoans ,  count(Loan.MemberNumber) TotalLoans,IIF(MembershipCategory.MembershipCategoryTotalLoans < count(Loan.MemberNumber), 'Too Many DVDs' , '') as message from member join MembershipCategory on Member.MembershipCategoryNumber = MembershipCategory.MembershipCategoryNumber full join Loan on Member.MemberNumber = Loan.MemberNumber group by Member.MemberFirstName,member.MemberLastName,Member.MemberDateOfBirth,Member.MemberAddress,MembershipCategory.MembershipCategoryTotalLoans;";
            cmd = new SqlCommand(query, gb.cn);
            da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0];
        }
    }
}