using RopeyDVDs.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RopeyDVDs.Repository
{
    public class DVDCopyRepo
    {
        GlobalConnection gb = new GlobalConnection();
        SqlCommand cmd;
        SqlDataAdapter da;

        public DataTable Getdvdnum()
        {
            string qry = "Select * from DVDTitle";
            da = new SqlDataAdapter(qry, gb.cn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0];
        }
        public int Adddvdcopy(int dvdnumber, string datepurchased)
        {
            cmd = new SqlCommand("Insert into DVDCopy" + "(DVDNumber,DatePurchased) values " + "(@dvdnumber,@datepurchased)", gb.cn);
            cmd.Parameters.AddWithValue("@dvdnumber", dvdnumber);
            cmd.Parameters.AddWithValue("@datepurchased", datepurchased);       
            int k = cmd.ExecuteNonQuery();
            gb.cn.Close();
            return k;


        }
        public DataTable Getdvdcopy()
        {
            string qry = "Select * from DVDCopy";
            da = new SqlDataAdapter(qry, gb.cn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0];
        }

        public int UpdateDvdCopy(int copynumber, int dvdnumber, string datepurchased)
        {
            cmd = new SqlCommand("Update DVDCopy set DVDNumber = @dvdnumber,DatePurchased=@datepurchased where CopyNumber = @copynumber", gb.cn);
            cmd.Parameters.AddWithValue("@dvdnumber", dvdnumber);
            cmd.Parameters.AddWithValue("@datepurchased", datepurchased);
            cmd.Parameters.AddWithValue("@copynumber", copynumber);
            int k = cmd.ExecuteNonQuery();
            gb.cn.Close();
            return k;
        }
        public int DeleteDvdCopy(int id)
        {
            cmd = new SqlCommand("Delete from DVDCopy where CopyNumber = @id", gb.cn);
            cmd.Parameters.AddWithValue("@id", id);
           int k = cmd.ExecuteNonQuery();
            gb.cn.Close();
            return k;
        }
    }
}