using RopeyDVDs.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RopeyDVDs.Repository
{
    public class StudioRepo
    {
        GlobalConnection gb = new GlobalConnection();
        SqlCommand cmd;
        SqlDataAdapter da;
        public int AddStudio(int studioid,String sname)
        {
            cmd = new SqlCommand("Insert into Studio" + "(StudioNumber,StudioName) values " + "(@studioid,@sname)", gb.cn);
            cmd.Parameters.AddWithValue("@studioid", studioid);
            cmd.Parameters.AddWithValue("@sname", sname);           
            int k = cmd.ExecuteNonQuery();
            gb.cn.Close();
            return k;


        }
        public DataTable GetStudios()
        {
            string qry = "Select * from Studio";
            da = new SqlDataAdapter(qry, gb.cn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0];
        }

        public int UpdateStudio(int studionumber, String sname)
        {
            cmd = new SqlCommand("Update Studio set StudioName = @sname where StudioNumber = @studionumber", gb.cn);
            cmd.Parameters.AddWithValue("@sname", sname);
            cmd.Parameters.AddWithValue("@studionumber", studionumber);

            int k = cmd.ExecuteNonQuery();
            gb.cn.Close();
            return k;
        }
        public int DeleteStudio(int id)
        {
            cmd = new SqlCommand("Delete from Studio where StudioNumber = @id", gb.cn);
            cmd.Parameters.AddWithValue("@id", id);
            int k= cmd.ExecuteNonQuery();
            gb.cn.Close();
            return k;
        }
    }
}