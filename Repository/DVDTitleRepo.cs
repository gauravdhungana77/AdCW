using RopeyDVDs.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RopeyDVDs.Repository
{
    public class DVDTitleRepo
    {
        GlobalConnection gb = new GlobalConnection();
        SqlCommand cmd;
        SqlDataAdapter da;
        public int Adddvdtitle(int catnumber, int studionum, int producernum,string dvdtitle,string daterelease,int standardcharge, int penaltycharge )
        {
            cmd = new SqlCommand("Insert into DVDTitle" + "(CategoryNumber,StudioNumber,ProducerNumber,DVDTitle,DateReleased,StandardCharge,PenaltyCharge) values " + "(@catnumber,@studionum,@producernum,@dvdtitle,@daterelease,@standardcharge,@penaltycharge)", gb.cn);
            cmd.Parameters.AddWithValue("@catnumber", catnumber);
            cmd.Parameters.AddWithValue("@studionum", studionum);
            cmd.Parameters.AddWithValue("@producernum", producernum);
            cmd.Parameters.AddWithValue("@dvdtitle", dvdtitle);
            cmd.Parameters.AddWithValue("@daterelease", daterelease);
            cmd.Parameters.AddWithValue("@standardcharge", standardcharge);
            cmd.Parameters.AddWithValue("@penaltycharge", penaltycharge);
            int k = cmd.ExecuteNonQuery();
            gb.cn.Close();
            return k;
        }
        public DataTable Getdvdcategory()
        {
            string qry = "Select * from DVDCategory";
            da = new SqlDataAdapter(qry, gb.cn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0];
        }
        public DataTable Getstudio()
        {
            string qry = "Select * from Studio";
            da = new SqlDataAdapter(qry, gb.cn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0];
        }
        public DataTable GetProducer()
        {
            string qry = "Select * from Producer";
            da = new SqlDataAdapter(qry, gb.cn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0];
        }
        public DataTable Getdvdtitle()
        {
            string qry = "Select * from DVDTitle";
            da = new SqlDataAdapter(qry, gb.cn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0];
        }

        public int UpdateDvdTitle(int dvdnumber, int catnumber, int studionum, int producernum, string dvdtitle, string daterelease, int standardcharge, int penaltycharge)
        {
            cmd = new SqlCommand("Update DVDTitle set CategoryNumber = @catnumber,StudioNumber=@studionum,ProducerNumber=@producernum,DVDTitle=@dvdtitle,DateReleased=@daterelease,StandardCharge=@standardcharge,PenaltyCharge=@penaltycharge where DVDNumber = @dvdnumber", gb.cn);
            cmd.Parameters.AddWithValue("@catnumber", catnumber);
            cmd.Parameters.AddWithValue("@studionum", studionum);
            cmd.Parameters.AddWithValue("@producernum", producernum);
            cmd.Parameters.AddWithValue("@dvdtitle", dvdtitle);
            cmd.Parameters.AddWithValue("@daterelease", daterelease);
            cmd.Parameters.AddWithValue("@standardcharge", standardcharge);
            cmd.Parameters.AddWithValue("@penaltycharge", penaltycharge);
            cmd.Parameters.AddWithValue("@dvdnumber", dvdnumber);
            int k = cmd.ExecuteNonQuery();
            gb.cn.Close();
            return k;
        }
    }
}