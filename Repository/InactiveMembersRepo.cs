using RopeyDVDs.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RopeyDVDs.Repository
{
    public class InactiveMembersRepo
    {
        GlobalConnection gb = new GlobalConnection();
        SqlCommand cmd;
        SqlDataAdapter da;

        public DataTable getinactivemembers()
        {
            string query = "select Loan.MemberNumber,Member.MemberFirstName,Member.MemberLastName,Member.MemberAddress,Loan.DateOut,DVDTitle.DVDTitle, DATEDIFF(day,Loan.DateOut,GETDATE()) AS 'No of days since last loan' from Loan join Member on Loan.MemberNumber = Member.MemberNumber join DVDCopy on Loan.CopyNumber =  DVDCopy.CopyNumber join DVDTitle on DVDCopy.DVDNumber = DVDTitle.DVDNumber where CONVERT(varchar(50),Loan.DateOut,105) <= GETDATE()-31;";
            cmd = new SqlCommand(query, gb.cn);
            da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0];
        }
    }
}