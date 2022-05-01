using RopeyDVDs.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RopeyDVDs.Repository
{
    public class SearchRepo
    {
        GlobalConnection gb = new GlobalConnection();
        SqlCommand cmd;
        SqlDataAdapter da;
        public DataTable getSelectedmember(string surname)
        {
            string query = "Select CastMember.ActorNumber,Actor.ActorFirstName,Actor.ActorSurname,CastMember.DVDNumber,DVDTitle.DVDTitle from CastMember join Actor on CastMember.ActorNumber = Actor.ActorNumber join DVDTitle on Castmember.DVDNumber = DVDTitle.DVDNumber where Actor.ActorSurname = @surname";
            cmd = new SqlCommand(query, gb.cn);
            cmd.Parameters.AddWithValue("@surname", surname);
            da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0];
        }
        public DataTable getdvdtitlewithcount(string surname)
        {
            string query = "Select  DVDTitle.DVDTitle,COUNT(DVDCopy.CopyNumber) Copy  from CastMember join Actor on CastMember.ActorNumber = Actor.ActorNumber join DVDTitle on Castmember.DVDNumber = DVDTitle.DVDNumber join DVDCopy on DVDTitle.DVDNumber = DVDCopy.DVDNumber full join Loan on DVDCopy.CopyNumber = Loan.CopyNumber where Actor.ActorSurname = @surname and DVDCopy.CopyNumber not in(Select CopyNumber from Loan where Loan.DateReturned is null) GROUP BY DVDTitle.DVDTitle;";
            cmd = new SqlCommand(query, gb.cn);
            cmd.Parameters.AddWithValue("@surname", surname);
            da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0];
        }
        public DataTable getmemberloan(string lastname)
        {
            string query = " Select Loan.MemberNumber,Member.MemberFirstName, DVDTitle.DVDTitle, DVDCopy.CopyNumber from Loan join Member on Loan.MemberNumber = Member.MemberNumber join DVDCopy on Loan.CopyNumber = DVDCopy.CopyNumber join DVDTitle on DVDCopy.DVDNumber = DVDTitle.DVDNumber where Member.MemberLastName = @lastname and  CONVERT(varchar(50),Loan.DateOut,105)  >= GETDATE()-31;";
            cmd = new SqlCommand(query, gb.cn);
            cmd.Parameters.AddWithValue("@lastname", lastname);
            da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0];
        }
        public DataTable getlatestcopyloaned(int copynumber)
        {
            string query = "select Top 1 DVDCopy.CopyNumber,Loan.LoanNumber,Loan.DateOut,Loan.DateDue,Loan.DateReturned,Member.MemberFirstName,Member.MemberLastName,DVDTitle.DVDTitle from DVDCopy join Loan on DVDCopy.CopyNumber = Loan.CopyNumber join Member on Loan.MemberNumber = Member.MemberNumber join DVDTitle on DVDCopy.DVDNumber = DVDTitle.DVDNumber where DVDCopy.CopyNumber = @copynumber order by CONVERT(varchar(50),Loan.DateOut,105)desc;";
            cmd = new SqlCommand(query, gb.cn);
            cmd.Parameters.AddWithValue("@copynumber", copynumber);
            da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0];
        }
    }
}