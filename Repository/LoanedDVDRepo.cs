using RopeyDVDs.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RopeyDVDs.Repository
{
    public class LoanedDVDRepo
    {
        GlobalConnection gb = new GlobalConnection();
        SqlCommand cmd;
        SqlDataAdapter da;
       // List of all DVD copies currently on loan, in date order of date out with the loans of a particular day ordered by the title.
        public DataTable getloaneddvd()
        {
            string query = "Select Max(DVDCopy.DVDNumber)DVDNumber,DVDTitle.DVDTitle, Max(DVDCopy.CopyNumber)CopyNumber,Max(Member.MemberFirstName)MemberFirstName,Max(Member.MemberLastName)MemberLastName,Max(Loan.DateOut)DateOut,COUNT(Loan.MemberNumber) Numberofloans from Loan join DVDCopy on Loan.CopyNumber =  DVDCopy.CopyNumber join DVDTitle on DVDCopy.DVDNumber = DVDTitle.DVDNumber  join Member on Loan.MemberNumber = Member.MemberNumber group by Loan.MemberNumber, Loan.DateOut,DVDTitle.DVDTitle order by Loan.DateOut,DVDTitle;";
            cmd = new SqlCommand(query, gb.cn);
            da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0];
        }
    }
}