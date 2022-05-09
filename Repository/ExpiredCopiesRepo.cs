using RopeyDVDs.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RopeyDVDs.Repository
{
    public class ExpiredCopiesRepo
    {
        GlobalConnection gb = new GlobalConnection();
        SqlCommand cmd;
        SqlDataAdapter da;
        // Gets the DVD Copies older than 1 years.
        public DataTable getexpireddvdcopies()
        {
            string query = "Select DVDCopy.CopyNumber,DVDCopy.DatePurchased, DVDCopy.DVDNumber, DVDTitle.DVDTitle from DVDCopy join DVDTitle on DVDCopy.DVDNumber = DVDTitle.DVDNumber full join Loan on DVDCopy.CopyNumber = Loan.CopyNumber where DVDCopy.DatePurchased < GETDATE()-365 and DVDCopy.CopyNumber not in(Select CopyNumber from Loan where Loan.DateReturned is null);";
            cmd = new SqlCommand(query, gb.cn);         
            da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0];
        }
    }
}