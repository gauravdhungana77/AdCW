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
        //adds new dvdcategory to the database
        public int AddDvdCategory(String categorydescription, String agerestricted)
        {
            cmd = new SqlCommand("Insert into DVDCategory" + "(CategoryDescription,AgeRestricted) values " + "(@categorydescription,@agerestricted)", gb.cn);
            cmd.Parameters.AddWithValue("@categorydescription", categorydescription);
            cmd.Parameters.AddWithValue("@agerestricted", agerestricted);
            int k = cmd.ExecuteNonQuery();
            gb.cn.Close();
            return k;


        }
        //gets dvdcategory 
        public DataTable GetDvdCategory()
        {
            string qry = "Select * from DVDCategory";
            da = new SqlDataAdapter(qry, gb.cn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0];
        }
        //takes edited info and updates the current information of dvd category
        public int UpdateDvdCategory(int categorynumber, String categorydescription, String agerestricted)
        {
            cmd = new SqlCommand("Update DVDCategory set CategoryDescription = @categorydescription,AgeRestricted=@agerestricted where CategoryNumber = @categorynumber", gb.cn);
            cmd.Parameters.AddWithValue("@categorydescription", categorydescription);
            cmd.Parameters.AddWithValue("@agerestricted", agerestricted);
            cmd.Parameters.AddWithValue("@categorynumber", categorynumber);
            int k = cmd.ExecuteNonQuery();
            gb.cn.Close();
            return k;
        }

        //Removes the selected dvdcategory from the database
        public int DeleteDvdCategory(int id)
        {
            cmd = new SqlCommand("Delete from DVDCategory where CategoryNumber = @id", gb.cn);
            cmd.Parameters.AddWithValue("@id", id);
           int k =  cmd.ExecuteNonQuery();
            gb.cn.Close();
            return k;
        }
    }
}