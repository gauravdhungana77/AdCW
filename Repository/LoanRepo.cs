using RopeyDVDs.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RopeyDVDs.Repository
{
   
    public class LoanRepo
    {
        GlobalConnection gb = new GlobalConnection();
        SqlCommand cmd;
        SqlDataAdapter da;
       

        public int Addloan(int loanntype, int copynum,int membernumber,string dateout,string datedue,string datereturned)
        {
           
            da = new SqlDataAdapter(" Select MembershipCategory.MembershipCategoryTotalLoans, DATEDIFF(YEAR, CONVERT(varchar(50), Member.MemberDateOfBirth, 105), GETDATE()) Age from MembershipCategory join Member on MembershipCategory.MembershipCategoryNumber = Member.MembershipCategoryNumber where Member.MemberNumber  = '" + membernumber + "';", gb.cn);

            DataSet ds = new DataSet();
            da.Fill(ds, "MembershipCategory");
            DataTable dt = ds.Tables[0];
            int allowedloand = Int32.Parse(dt.Rows[0]["MembershipCategoryTotalLoans"].ToString());
            int age  = Int32.Parse(dt.Rows[0]["Age"].ToString());

            ds.Clear();
            dt.Clear();

           
            da = new SqlDataAdapter("Select COUNT(Member.MemberNumber) Totalloan from Member full join Loan on Member.MemberNumber = Loan.MemberNumber where DateReturned is null and Member.MemberNumber  = '" + membernumber + "' group by member.MemberNumber;", gb.cn);
          
            da.Fill(ds, "MembershipCategory");
            dt = ds.Tables[0];
            int totalloans = Int32.Parse(dt.Rows[0]["Totalloan"].ToString());

            ds.Clear();
            dt.Clear();

            if (totalloans >= allowedloand)
            {
                return 2;
            }

            da = new SqlDataAdapter("Select DVDCategory.AgeRestricted from DVDCategory join DVDTitle on DVDCategory.CategoryNumber = DVDTitle.CategoryNumber join DVDCopy on DVDTitle.DVDNumber = DVDCopy.DVDNumber where DVDCopy.CopyNumber = '" + copynum + "';", gb.cn);

            da.Fill(ds, "MembershipCategory");
            dt = ds.Tables[0];
            string agerestrictedstatus = dt.Rows[0]["AgeRestricted"].ToString();

            if (agerestrictedstatus.Equals("Yes") && age<18)
            {
                return 3;
            }

            cmd = new SqlCommand("Insert into Loan" + "(LoanTypeNumber,CopyNumber,MemberNumber,DateOut,DateDue,DateReturned) values " + "(@loanntype,@copynum,@membernumber,@dateout,@datedue,null)", gb.cn);
            cmd.Parameters.AddWithValue("@loanntype", loanntype);
            cmd.Parameters.AddWithValue("@copynum", copynum);
            cmd.Parameters.AddWithValue("@membernumber", membernumber);
            cmd.Parameters.AddWithValue("@dateout", dateout);
            cmd.Parameters.AddWithValue("@datedue", datedue);
            //cmd.Parameters.AddWithValue("@datereturned", null);
            int k = cmd.ExecuteNonQuery();
            gb.cn.Close();
            return k;


        }

        public DataTable Getloantypenumber()
        {
            string qry = "Select * from LoanType";
            da = new SqlDataAdapter(qry, gb.cn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0];
        }
        public DataTable Getcopynumber()
        {
            string qry = "Select * from DVDCopy";
            da = new SqlDataAdapter(qry, gb.cn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0];
        }
        public DataTable Getmember()
        {
            string qry = "Select * from Member";
            da = new SqlDataAdapter(qry, gb.cn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0];
        }
        public DataTable GetLoan()
        {
            string qry = "Select * from Loan";
            da = new SqlDataAdapter(qry, gb.cn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0];
        }
        public int UpdateLoan(int loannumber,int loantype, int copynum, int membernumber, string dateout, string datedue, string datereturned)
        {
            cmd = new SqlCommand("Update Loan set LoanTypeNumber = @loantype,CopyNumber=@copynum,MemberNumber=@membernumber,DateOut=@dateout,DateDue=@datedue,DateReturned=@datereturned where LoanNumber = @loannumber", gb.cn);
            cmd.Parameters.AddWithValue("@loantype", loantype);
            cmd.Parameters.AddWithValue("@copynum", copynum);
            cmd.Parameters.AddWithValue("@membernumber", membernumber);
            cmd.Parameters.AddWithValue("@dateout", dateout);
            cmd.Parameters.AddWithValue("@datedue", datedue);
            cmd.Parameters.AddWithValue("@datereturned", datereturned);
            cmd.Parameters.AddWithValue("@loannumber", loannumber);

            int k = cmd.ExecuteNonQuery();
            gb.cn.Close();
            return k;
        }
    }
}