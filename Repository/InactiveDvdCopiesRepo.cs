using RopeyDVDs.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RopeyDVDs.Repository
{
    public class InactiveDvdCopiesRepo
    {

        GlobalConnection gb = new GlobalConnection();
        SqlCommand cmd;
        SqlDataAdapter da;

        public DataTable getinactivedvdcopies()
        {
            string query = "Select DVDCopy.CopyNumber,DVDTitle.DVDNumber,DVDTitle.DVDTitle,Loan.DateOut  from Loan full join DVDCopy on Loan.CopyNumber = DVDCopy.CopyNumber join DVDTitle on DVDCopy.DVDNumber =  DVDTitle.DVDNumber where CONVERT(varchar(50),Loan.DateOut,105) <= GETDATE()-31 or DVDCopy.CopyNumber not in (select CopyNumber from Loan);";
            cmd = new SqlCommand(query, gb.cn);
            da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0];
        }
    }
}