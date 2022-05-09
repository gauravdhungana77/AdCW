using RopeyDVDs.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RopeyDVDs.Repository
{
    public class LoginRepo
    {
        GlobalConnection gb = new GlobalConnection();
        SqlCommand cmd;
        SqlDataAdapter sda;

        //Checks whether the user is already registered or not

        public DataTable CheckUser(string username, string Password, string role)
        {
            string sql = "Select * from Users where UserName='" + username + "' and UserPassword='" + Password + "' and UserType='" + role + "'";
            sda = new SqlDataAdapter(sql, gb.cn);
            DataSet ds = new DataSet();
            sda.Fill(ds, "Users");
            return ds.Tables[0];
        }
    }
}