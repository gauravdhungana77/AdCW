using RopeyDVDs.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RopeyDVDs.Repository
{
    public class DVDCategoryRepo
    {
        GlobalConnection gb = new GlobalConnection();
        SqlCommand cmd;
        SqlDataAdapter da;
        public int AddDvdCategory(String categorydescription, String agerestricted)
        {
            cmd = new SqlCommand("Insert into DVDCategory" + "(CategoryDescription,AgeRestricted) values " + "(@categorydescription,@agerestricted)", gb.cn);
            cmd.Parameters.AddWithValue("@categorydescription", categorydescription);
            cmd.Parameters.AddWithValue("@agerestricted", agerestricted);
            int k = cmd.ExecuteNonQuery();
            gb.cn.Close();
            return k;


        }
        public DataTable GetDvdCategory()
        {
            string qry = "Select * from DVDCategory";
            da = new SqlDataAdapter(qry, gb.cn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0];
        }
    }
}