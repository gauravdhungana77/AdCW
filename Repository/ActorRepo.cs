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
        public int AddActor(String surname, String firstname)
        {
            cmd = new SqlCommand("Insert into Actor" + "(ActorSurname,ActorFirstName) values " + "(@surname,@firstname)", gb.cn);
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
    }
}