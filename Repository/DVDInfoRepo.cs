using RopeyDVDs.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RopeyDVDs.Repository
{
    public class DVDInfoRepo
    {
        GlobalConnection gb = new GlobalConnection();
        SqlCommand cmd;
        SqlDataAdapter da;
        public DataTable getdvddetailinfo()
        {
            string query = "Select Producer.ProducerNumber,Producer.ProducerName,Studio.StudioNumber,Studio.StudioName, DVDTitle.DVDTitle,DVDTitle.DateReleased, Actor.ActorNumber,Actor.ActorFirstName,Actor.ActorSurname from DVDTitle join Producer on DVDTitle.ProducerNumber = Producer.ProducerNumber join Studio on DVDTitle.StudioNumber =  Studio.StudioNumber join CastMember on DVDTitle.DVDNumber = CastMember.DVDNumber join Actor on CastMember.ActorNumber = Actor.ActorNumber order by CONVERT(varchar(50),DVDTitle.DateReleased,105),Actor.ActorSurname;";
            cmd = new SqlCommand(query, gb.cn);
            
            da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0];
        }
    }
}