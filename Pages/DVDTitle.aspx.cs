using RopeyDVDs.Repository;
using RopeyDVDs.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RopeyDVDs.Pages
{
	public partial class DVDTitle : System.Web.UI.Page
	{
        DVDTitleRepo dVDTitle = new DVDTitleRepo();
        ActorRepo actor = new ActorRepo();
		protected void Page_Load(object sender, EventArgs e)
		{
            if (!IsPostBack)
            {
                loaddvdtitle();
                loadActors();
                loaddvdcategory();
                loadproducer();
                loadstudio();
                loadActors();
            }
        }

        public void loaddvdcategory()
        {
            try
            {
                
                catnumdrop.DataTextField = dVDTitle.Getdvdcategory().Columns["CategoryDescription"].ToString();
                catnumdrop.DataValueField = dVDTitle.Getdvdcategory().Columns["CategoryNumber"].ToString();             
                catnumdrop.DataSource = dVDTitle.Getdvdcategory(); 
                catnumdrop.DataBind();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Unable to load data from server.')", true);
            }

        }
        public void loadstudio()
        {
            try
            {

                stdnumdrop.DataTextField = dVDTitle.Getstudio().Columns["StudioName"].ToString();
                stdnumdrop.DataValueField = dVDTitle.Getstudio().Columns["StudioNumber"].ToString();
                stdnumdrop.DataSource = dVDTitle.Getstudio();
                stdnumdrop.DataBind();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Unable to load data from server.')", true);
            }

        }
        public void loadproducer()
        {
            try
            {

                prdcnumdrop.DataTextField = dVDTitle.GetProducer().Columns["ProducerName"].ToString();
                prdcnumdrop.DataValueField = dVDTitle.GetProducer().Columns["ProducerNumber"].ToString();
                prdcnumdrop.DataSource = dVDTitle.GetProducer();
                prdcnumdrop.DataBind();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Unable to load data from server.')", true);
            }

        }
        public void loadActors()
        {
            try
            {
                actornumberdrop.DataTextField = actor.GetActors().Columns["ActorFirstName"].ToString();
                actornumberdrop.DataValueField = actor.GetActors().Columns["ActorNumber"].ToString();
                actornumberdrop.DataSource = actor.GetActors();
                actornumberdrop.DataBind();

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Unable to load data from server.')", true);
            }

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            int catnumber = Int32.Parse(catnumdrop.SelectedValue);
            int studionumber = Int32.Parse(stdnumdrop.SelectedValue);
            int producernumber = Int32.Parse(prdcnumdrop.SelectedValue);
            string dvdtitle = dvdtitletxt.Text;
            string daterelease = Calendar.SelectedDate.ToShortDateString();
            int standardCharge = Int32.Parse(stdchargetxt.Text);
            int penaltycharge = Int32.Parse(peneltychargetxt.Text);
            int actornum = Int32.Parse(actornumberdrop.SelectedValue);

            var random = new Random();
            int dvdid = random.Next();

            int k = dVDTitle.Adddvdtitle(actornum, dvdid, catnumber, studionumber, producernumber, dvdtitle, daterelease, standardCharge, penaltycharge);

            if (k != 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Inserted Successfully')", true);
                loaddvdtitle();
                //surnametxt.Text = "";
                //firstnametxt.Text = "";
                //loadvisitors();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Unable to insert data')", true);
            }

        }

        public void loaddvdtitle()
        {
            try
            {
                dvdtitleview.DataSource = dVDTitle.Getdvdtitle();
                dvdtitleview.DataBind();
                

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Unable to load data from server.')", true);
            }

        }
        protected void dvdtitleviewCommand(object sender, GridViewCommandEventArgs e)
        {
            GlobalConnection gc = new GlobalConnection();
            SqlCommand sql = new SqlCommand();
            string index = Convert.ToString(e.CommandArgument);
            string strdata = "Select * from DVDTitle where DVDNumber ='" + index + "'";
            SqlDataAdapter da = new SqlDataAdapter(strdata, gc.cn);

            DataSet ds = new DataSet();
            da.Fill(ds, "DVDTitle");
            DataTable dt = ds.Tables[0];

            dvdnumber.Text = dt.Rows[0]["DVDNumber"].ToString();
            catnumdrop.SelectedValue = dt.Rows[0]["CategoryNumber"].ToString();
            stdnumdrop.SelectedValue = dt.Rows[0]["StudioNumber"].ToString();
            prdcnumdrop.SelectedValue = dt.Rows[0]["ProducerNumber"].ToString();
            dvdtitletxt.Text = dt.Rows[0]["DVDTitle"].ToString();
            Calendar.SelectedDate = Convert.ToDateTime(dt.Rows[0]["DateReleased"].ToString());
            stdchargetxt.Text = dt.Rows[0]["StandardCharge"].ToString();
            peneltychargetxt.Text = dt.Rows[0]["PenaltyCharge"].ToString();

        }

        protected void edit_Click(object sender, EventArgs e)
        {
            int catnumber = Int32.Parse(catnumdrop.SelectedValue);
            int studionumber = Int32.Parse(stdnumdrop.SelectedValue);
            int producernumber = Int32.Parse(prdcnumdrop.SelectedValue);
            string dvdtitle = dvdtitletxt.Text;
            string daterelease = Calendar.SelectedDate.ToShortDateString();
            int standardCharge = Int32.Parse(stdchargetxt.Text);
            int penaltycharge = Int32.Parse(peneltychargetxt.Text);
            string dvdnum = dvdnumber.Text;
            int k = dVDTitle.UpdateDvdTitle(Int32.Parse(dvdnum), catnumber, studionumber, producernumber, dvdtitle, daterelease, standardCharge, penaltycharge);

            if (k != 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Updated Successfully')", true);
                loaddvdtitle();
                //surnametxt.Text = "";
                //firstnametxt.Text = "";
                //loadvisitors();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Unable to update data')", true);
            }
        }

        protected void delete_Click(object sender, EventArgs e)
        {
            try
            {
                int dvdtitleid = Int32.Parse(dvdnumber.Text);
                int k = dVDTitle.DeleteDvdtitle(dvdtitleid);
                if (k != 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Successfully deleted')", true);

                    loaddvdcategory();
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Unable to delete data')", true);
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Unable to delete data')", true);
            }
        }
    }
}