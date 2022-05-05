using RopeyDVDs.Services;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RopeyDVDs.Repository
{
    public class ChangePasswordRepo
    {
        GlobalConnection gb = new GlobalConnection();
        SqlCommand cmd;
        SqlDataAdapter da;
        public int ChangePassword(string username, String Password)
        {
            cmd = new SqlCommand("Update Users set UserPassword=@Password where UserName = @username", gb.cn);            
            cmd.Parameters.AddWithValue("@Password", Password);            
            cmd.Parameters.AddWithValue("@username", username);
            int k = cmd.ExecuteNonQuery();
            gb.cn.Close();
            return k;
        }
    }
}