﻿using RopeyDVDs.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using Ubiety.Dns.Core;

namespace RopeyDVDs.Repository
{
    public class ActorRepo
    {
        GlobalConnection gb = new GlobalConnection();
        SqlCommand cmd;
        SqlDataAdapter da;
        public int AddActor(int actorid,String surname, String firstname)
        {
            cmd = new SqlCommand("Insert into Actor" + "(ActorNumber,ActorSurname,ActorFirstName) values " + "(@actorid,@surname,@firstname)", gb.cn);
            cmd.Parameters.AddWithValue("@actorid", actorid);
            cmd.Parameters.AddWithValue("@surname", surname);
            cmd.Parameters.AddWithValue("@firstname", firstname);
            int k = cmd.ExecuteNonQuery();
            gb.cn.Close();
            return k;
            

        }
        public DataTable GetActors()
        {          
            string qry = "Select * from Actor";
            da = new SqlDataAdapter(qry, gb.cn);
            DataSet ds = new DataSet();         
            da.Fill(ds);
            return ds.Tables[0];
        }
        public void DeleteActor()
        {
           
        }

        public int UpdateActor(int actornumber, String surname, String firstname)
        {
            cmd = new SqlCommand("Update Actor set ActorSurname = @surname,ActorFirstName=@firstname where ActorNumber = @actornumber", gb.cn);
            cmd.Parameters.AddWithValue("@surname", surname);
            cmd.Parameters.AddWithValue("@firstname", firstname);
            cmd.Parameters.AddWithValue("@actornumber", actornumber);
            int k = cmd.ExecuteNonQuery();
            gb.cn.Close();
            return k;
        }
    }
}