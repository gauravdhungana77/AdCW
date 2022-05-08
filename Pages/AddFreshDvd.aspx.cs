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
        public string role = string.Empty;
        public string username = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            loaddvdcategory();
            loadcookies();
            if (string.IsNullOrEmpty(role))
            {

                Response.Redirect("https://localhost:44360/Pages/Login.aspx");
            }
        }
        public void loadcookies()
        {
            HttpCookie reqCookies = Request.Cookies["userInfo"];
            if (reqCookies != null)
            {
                username = reqCookies["Username"].ToString();
                role = reqCookies["role"].ToString();
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
        protected void add_Click(object sender, EventArgs e)
        {
            try
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

                if (!String.IsNullOrEmpty(actorsurname) || !String.IsNullOrEmpty(actorfirstnamename) || !String.IsNullOrEmpty(studioname) || !String.IsNullOrEmpty(producername) || !String.IsNullOrEmpty(dvdtitle) || !String.IsNullOrEmpty(daterelease) || standardCharge != 0 || penaltycharge != 0)
                {
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
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please fill all the fields')", true);

                }
            }
            catch
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Enter value in correct format')", true);
            }
           
        }          
    }
}