using RopeyDVDs.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RopeyDVDs.Repository
{
    public class CastMemberRepo
    {
        GlobalConnection gb = new GlobalConnection();
        SqlCommand cmd;
        SqlDataAdapter da;
        public int Addcastmember(int dvdnumber, int actornumber)
        {
            cmd = new SqlCommand("Insert into CastMember" + "(DVDNumber,ActorNumber) values " + "(@dvdnumber,@actornumber)", gb.cn);
            cmd.Parameters.AddWithValue("@dvdnumber", dvdnumber);
            cmd.Parameters.AddWithValue("@actornumber", actornumber);
     
            int k = cmd.ExecuteNonQuery();
            gb.cn.Close();
            return k;
        }

        public DataTable Getdvdtitle()
        {
            string qry = "Select * from DVDTitle";
            da = new SqlDataAdapter(qry, gb.cn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0];
        }
        public DataTable Getactor()
        {
            string qry = "Select * from Actor";
            da = new SqlDataAdapter(qry, gb.cn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0];
        }
        public DataTable Getcastmember()
        {
            string qry = "Select * from CastMember";
            da = new SqlDataAdapter(qry, gb.cn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0];
        }
        public DataTable JoinTables()
        {
            string query = "Select CastMember.ActorNumber,Actor.ActorFirstName,Actor.ActorSurname,CastMember.DVDNumber,DVDTitle.DVDTitle from CastMember join Actor on CastMember.ActorNumber = Actor.ActorNumber join DVDTitle on Castmember.DVDNumber = DVDTitle.DVDNumber";
            cmd = new SqlCommand(query, gb.cn);
            da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0];
        }
       

    }
}