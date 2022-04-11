using RopeyDVDs.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RopeyDVDs.Repository
{
    public class ProducerRepo
    {
        GlobalConnection gb = new GlobalConnection();
        SqlCommand cmd;
        SqlDataAdapter da;
        public int AddProducer(String pname)
        {
            cmd = new SqlCommand("Insert into Producer" + "(ProducerName) values " + "(@pname)", gb.cn);
            cmd.Parameters.AddWithValue("@pname", pname);
            int k = cmd.ExecuteNonQuery();
            gb.cn.Close();
            return k;


        }
        public DataTable GetProducer()
        {
            string qry = "Select * from Producer";
            da = new SqlDataAdapter(qry, gb.cn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0];
        }
    }
}