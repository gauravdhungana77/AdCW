using RopeyDVDs.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RopeyDVDs.Pages
{
    public partial class AddFreshDvd : System.Web.UI.Page
    {
        ActorRepo actor = new ActorRepo();
        DVDTitleRepo dVDTitle = new DVDTitleRepo();
        ProducerRepo producer = new ProducerRepo();
        StudioRepo studio = new StudioRepo();
        int k;
        protected void Page_Load(object sender, EventArgs e)
        {
            loaddvdcategory();
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            string actorsurname = surnametxt.Text;
            string actorfirstnamename = firstnametxt.Text;
            string studioname = studionametxt.Text;
            string producername = producernametxt.Text;
            string dvdtitle = dvdtitletxt.Text;
            int catnumber = Int32.Parse(catnumdrop.SelectedValue);
            string daterelease = Calendar.SelectedDate.ToShortDateString();
            int standardCharge = Int32.Parse(stdchargetxt.Text);
            int penaltycharge = Int32.Parse(peneltychargetxt.Text);
           
            var random = new Random();
            int dvdid = random.Next();
            int actoridid = random.Next();
            int producerid = random.Next();
            int studioid = random.Next();

            k = actor.AddActor(actoridid, actorsurname, actorfirstnamename);
            k = producer.AddProducer(producerid, producername);
            k = studio.AddStudio(studioid, studioname);
            k = dVDTitle.Adddvdtitle(actoridid, dvdid, catnumber, studioid, producerid, dvdtitle, daterelease, standardCharge, penaltycharge);

            if (k != 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Inserted Successfully')", true);
              
                //surnametxt.Text = "";
                //firstnametxt.Text = "";
                //loadvisitors();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Unable to insert data')", true);
            }
        }
    }
}