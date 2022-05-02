using RopeyDVDs.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RopeyDVDs.Pages
{
    public partial class CastMember : System.Web.UI.Page
    {
        CastMemberRepo castMember = new CastMemberRepo();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                //loaddvdtitle();
                //loadactor();
               // loadcastmember();
                joiningtables();
         
            }
         
          



        }

        //public void loaddvdtitle()
        //{
        //    try
        //    {

        //        dvdnumberdrop.DataTextField = castMember.Getdvdtitle().Columns["DVDTitle"].ToString();
        //        dvdnumberdrop.DataValueField = castMember.Getdvdtitle().Columns["DVDNumber"].ToString();
        //        dvdnumberdrop.DataSource = castMember.Getdvdtitle();
        //        dvdnumberdrop.DataBind();
        //    }
        //    catch (Exception ex)
        //    {
        //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Unable to load data from server.')", true);
        //    }

        //}
        //public void loadactor()
        //{
        //    try
        //    {

        //        actornumberdrop.DataTextField = castMember.Getactor().Columns["ActorFirstName"].ToString();
        //        actornumberdrop.DataValueField = castMember.Getactor().Columns["ActorNumber"].ToString();
        //        actornumberdrop.DataSource = castMember.Getactor();
        //        actornumberdrop.DataBind();
        //    }
        //    catch (Exception ex)
        //    {
        //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Unable to load data from server.')", true);
        //    }

        //}

        //public void loadcastmember()
        //{
        //    try
        //    {
        //        castmemberview.DataSource = castMember.Getcastmember();
        //        castmemberview.DataBind();
               

        //    }
        //    catch (Exception ex)
        //    {
        //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Unable to load data from server.')", true);
        //    }
        //}
        public void joiningtables()
        {
            try
            {
                jointableview.DataSource = castMember.JoinTables();
                jointableview.DataBind();
              
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Unable to load data from server.')", true);
            }
        }

        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    string dvdnumber = dvdnumberdrop.SelectedValue;
        //    string actornumber = actornumberdrop.SelectedValue;
        //    int k = castMember.Addcastmember(Int32.Parse(dvdnumber), Int32.Parse (actornumber));

        //    if (k != 0)
        //    {
        //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Inserted Successfully')", true);

        //      //  loadcastmember();
        //        joiningtables();
        //    }
        //    else
        //    {
        //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Unable to insert data')", true);
        //    }
        //}

 

    }
}