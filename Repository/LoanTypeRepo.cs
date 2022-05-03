using RopeyDVDs.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RopeyDVDs.Repository
{
    public class LoanTypeRepo
    {
        GlobalConnection gb = new GlobalConnection();
        SqlCommand cmd;
        SqlDataAdapter da;
        public int AddLoanType(String LoanType, String Duration)
        {
            cmd = new SqlCommand("Insert into LoanType" + "(LoanType,LoanDuration) values " + "(@LoanType,@Duration)", gb.cn);
            cmd.Parameters.AddWithValue("@LoanType", LoanType);
            cmd.Parameters.AddWithValue("@Duration", Duration);
            int k = cmd.ExecuteNonQuery();
            gb.cn.Close();
            return k;


        }
        public DataTable GetLoanType()
        {
            string qry = "Select * from LoanType";
            da = new SqlDataAdapter(qry, gb.cn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0];
        }
        public int UpdateLoanType(int loantypenumber, String LoanType, String Duration)
        {
            cmd = new SqlCommand("Update LoanType set LoanType = @LoanType,LoanDuration=@Duration where LoanTypeNumber = @loantypenumber", gb.cn);
            cmd.Parameters.AddWithValue("@LoanType", LoanType);
            cmd.Parameters.AddWithValue("@Duration", Duration);
            cmd.Parameters.AddWithValue("@loantypenumber", loantypenumber);

            int k = cmd.ExecuteNonQuery();
            gb.cn.Close();
            return k;
        }
        public int DeleteLoanType(int id)
        {
            cmd = new SqlCommand("Delete from LoanType where LoanTypeNumber = @id", gb.cn);
            cmd.Parameters.AddWithValue("@id", id);
           int k = cmd.ExecuteNonQuery();
            gb.cn.Close();
            return k;
        }
    }
}