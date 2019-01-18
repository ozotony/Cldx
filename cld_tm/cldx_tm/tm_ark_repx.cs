namespace cld
{
    using Classes ;
    using System;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.IO;

    public class tm_ark_repx : UserControl
    {
        public string agt = "";
        public tm.AddressService c_aos = new tm.AddressService();
        public tm.Applicant c_app = new tm.Applicant();
        public tm.Address c_app_addy = new tm.Address();
        public tm.MarkInfo c_mark = new tm.MarkInfo();
        public tm.Representative c_rep = new tm.Representative();
        public tm.Address c_rep_addy = new tm.Address();
        public tm.Stage c_stage = new tm.Stage();
        protected Label Label1;
        protected Label Label11;
        protected Label Label2;
        protected Label Label3;
        protected Label Label4;
        protected Label Label5;
        protected Label Label6;
        protected Label Label7;
        protected Label Label8;
        protected Label Label9;
        protected Image tm_img;
        public string pwalletID = "";
        public tm t = new tm();
        public string validationID = "";
        public string vid = "";
        protected string serverpath ="";

        protected void Page_Load(object sender, EventArgs e)
        {
            this.serverpath = base.Server.MapPath("~/");
            if (base.Request.QueryString["0001234445"] != null)
            {
                this.vid = base.Request.QueryString["0001234445"].ToString();
                if (this.vid.Contains("OAI/TM/"))
                {
                    this.vid = this.vid.Replace("OAI/TM/", "");
                }
            }
            else
            {
                base.Response.Redirect("./appstatus.aspx");
            }
            if (base.Request.QueryString["94384238"] != null)
            {
                this.agt = base.Request.QueryString["94384238"].ToString();
            }
            else
            {
                base.Response.Redirect("./appstatus.aspx");
            }
            this.pwalletID = this.t.getCheckStatusDetails(this.vid, this.agt);
            if (this.pwalletID != "")
            {
                
                this.c_mark = this.t.getMarkInfoClassByUserID(this.pwalletID);
                this.c_rep = this.t.getRepClassByUserID(this.pwalletID);
                this.c_stage = this.t.getStageClassByUserID(this.pwalletID);
                this.c_app = this.t.getApplicantClassByID(this.pwalletID);
                if ((c_app.addressID != null) && (c_app.addressID != "") && (c_app.addressID != "0"))
                {
                this.c_app_addy = this.t.getAddressClassByID(this.c_app.addressID);
                }
                if ((c_rep.addressID != null) && (c_rep.addressID != "") && (c_rep.addressID != "0"))
                { 
                    this.c_rep_addy = this.t.getAddressClassByID(this.c_rep.addressID); 
                }

                if (c_mark.logo_pic != "")
                {
                    tm_img.ImageUrl = "./admin/tm/" + c_mark.logo_pic;

                    //if (File.Exists(serverpath + "\\admin\\tm\\" + c_mark.logo_pic))
                    //{
                    //    tm_img.Height = new Unit(120, UnitType.Pixel);
                    //    tm_img.Width = new Unit(120, UnitType.Pixel);
                        //try
                        //{
                        //    FileStream st = new FileStream(serverpath + "\\admin\\tm\\" + c_mark.logo_pic, FileMode.Open, FileAccess.Read);
                        //    System.Drawing.Image new_img = System.Drawing.Image.FromStream(st);
                        //    string ht = new_img.Height.ToString();
                        //    string wt = new_img.Width.ToString();
                        //    if ((ht != "") && (wt != "") && (ht != null) && (wt != null))
                        //    {

                        //        if (Convert.ToInt32(ht) > Convert.ToInt32(wt))
                        //        {
                        //            tm_img.Height = new Unit(320, UnitType.Pixel);
                        //            tm_img.Width = new Unit(240, UnitType.Pixel);
                        //        }
                        //        else
                        //        {
                        //            tm_img.Height = new Unit(240, UnitType.Pixel);
                        //            tm_img.Width = new Unit(320, UnitType.Pixel);
                        //        }
                        //    }
                        //    else
                        //    {
                        //        // tm_img.Height = new Unit(120, UnitType.Pixel);
                        //        // tm_img.Width = new Unit(120, UnitType.Pixel);
                        //        tm_img.Visible = false;
                        //    }
                        //}
                        //catch (Exception ex)
                        //{
                        //    tm_img.Visible = false;
                        //}
                    //}
                    //else
                    //{
                    //    // tm_img.Height = new Unit(120, UnitType.Pixel);
                    //    // tm_img.Width = new Unit(120, UnitType.Pixel);
                    //    tm_img.Visible = false;
                    //}
                }
                Session["xserviceaddress"] = null;
                Session["xrepresentative"] = null;
                Session["xmarkinfo"] = null;
                Session["xapplication"] = null;
                Session["vid"] = null;
                Session["amt"] = null;
                Session["aid"] = null;
                Session["g"] = null;
                Session["pc"] = null;
            }
            else
            {
                base.Response.Redirect("./appstatus.aspx");
            }
        }
    }
}

