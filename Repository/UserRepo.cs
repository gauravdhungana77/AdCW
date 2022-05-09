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
        //registers the new user into the system
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
        //Checks the presence of user in the system
        public DataTable CheckUser(string username)
        {
            string sql = "Select * from Users where UserName='" + username + "'";
            SqlDataAdapter sda = new SqlDataAdapter(sql, gb.cn);
            DataSet ds = new DataSet();
            sda.Fill(ds, "Users");
            return ds.Tables[0];
        }
        //Updates the user information
        public int UpdateUser(int usernumber,String Username, String Password,string role)
        {
            cmd = new SqlCommand("Update Users set UserName = @Username, UserType=@role,UserPassword=@Password where UserNumber = @usernumber", gb.cn);
            cmd.Parameters.AddWithValue("@Username", Username);
            cmd.Parameters.AddWithValue("@Password", Password);
            cmd.Parameters.AddWithValue("@role", role);
            cmd.Parameters.AddWithValue("@usernumber", usernumber);
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
        public int DeleteUser(int id)
        {
            cmd = new SqlCommand("Delete from Users where UserNumber = @id", gb.cn);
            cmd.Parameters.AddWithValue("@id", id);
            int k = cmd.ExecuteNonQuery();
            gb.cn.Close();
            return k;
        }
    }
}