using RopeyDVDs.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RopeyDVDs.Repository
{
    public class UserRepo
    {
        GlobalConnection gb = new GlobalConnection();
        SqlCommand cmd;
        SqlDataAdapter da;
        public int AddUser(String username, String usertype,string userpassword)
        {
            cmd = new SqlCommand("Insert into Users" + "(UserName,UserType,UserPassword) values " + "(@username,@usertype,@userpassword)", gb.cn);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@usertype", usertype);
            cmd.Parameters.AddWithValue("@userpassword", userpassword);
            int k = cmd.ExecuteNonQuery();
            gb.cn.Close();
            return k;

        }

        public DataTable GetUser()
        {
            string qry = "Select * from Users";
            da = new SqlDataAdapter(qry, gb.cn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0];
        }
    }
}