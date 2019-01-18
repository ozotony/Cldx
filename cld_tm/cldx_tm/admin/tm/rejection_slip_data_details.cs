namespace cld.admin.tm
{
    using admin ;
    using Classes ;
    using System;
    using System.Collections.Generic;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.IO;

    public class rejection_slip_data_details : UserControl
    {
        public string admin = "";
        public string admin_status;
        public tm.AddressService c_aos = new tm.AddressService();
        public tm.Applicant c_app = new tm.Applicant();
        public tm.Address c_app_addy = new tm.Address();
        public zues.MarkInfo c_mark = new zues.MarkInfo();
        public zues.Pwallet c_p = new zues.Pwallet();
        public tm.Representative c_rep = new tm.Representative();
        public tm.Address c_rep_addy = new tm.Address();
        protected Label Label1;
        protected Label Label2;
        protected Label Label4;
        protected Label Label5;
        public zues.Adminz lt_tm_admin_details = new zues.Adminz();
        public List<zues.TmOffice> lt_tm_office = new List<zues.TmOffice>();
        public string pID;
        public string rbval_text = "";
        public string search_doc_succ1 = "";
        public string search_doc_succ2 = "";
        public string search_doc_succ3 = "";
        public string succ = "";
        public tm t = new tm();
        public string xofficer;
        public zues z = new zues();
        public string xreason = "";
        protected Image tm_img;
        protected string serverpath = "";

        protected Panel pp7;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.serverpath = base.Server.MapPath("~/");
            if (base.Request.QueryString["x"] != null)
            {
                //if (Session["pwalletID"] != null)
                //{
                //    if (Session["pwalletID"].ToString() != "")
                //    {
                //        this.admin = Session["pwalletID"].ToString();
                //    }
                //    else
                //    {
                //        base.Response.Redirect("./xcontrol.aspx");
                //    }
                //}
                //else
                //{
                //    base.Response.Redirect("./xcontrol.aspx");
                //}

                if (!this.IsPostBack)
                {

                    //string script = "document.getElementById('bgMark').style.background = \"url(\" + document.getElementById('"
                    //+ imgWaterMark.ClientID + "').src + \")  0 20  repeat \";";
                    //if (ScriptManager.GetCurrent(this.Page) == null)
                    //    Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "block", script, true);
                    //else
                    //    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "block", script, true);

                    string ID = "test";
                    if (base.Request.QueryString["x2"] != null)
                    {
                        //  imgWaterMark.ImageUrl = ResolveUrl("~") + string.Format("Handlers/WaterMarks.ashx?id={0}", ID);
                        pp7.BackImageUrl = ResolveUrl("~") + string.Format("Handlers/WaterMarks.ashx?id={0}", ID);

                    }


                }



                this.pID = base.Request.QueryString["x"].ToString();
                this.c_mark = this.z.getMarkInfoByUserID(this.pID);
                this.c_p = this.z.getPwalletDetailsByID(this.c_mark.log_staff);
                this.c_app = this.t.getApplicantByUserID(this.c_p.ID);
                this.c_aos = this.t.getAddressServiceByID(this.c_p.ID);
                this.c_rep = this.t.getRepByUserID(this.c_p.ID);
                if ((c_app.addressID != null) && (c_app.addressID != "") && (c_app.addressID != "0"))
                {
                    this.c_app_addy = this.t.getAddressClassByID(this.c_app.addressID);
                }
                if ((c_rep.addressID != null) && (c_rep.addressID != "") && (c_rep.addressID != "0"))
                {
                    this.c_rep_addy = this.t.getAddressClassByID(this.c_rep.addressID);
                }
                this.lt_tm_office = this.z.getTmOfficeDetailsByID(this.c_p.ID);
                this.lt_tm_admin_details = this.z.getTmAdminDetailsByID(this.lt_tm_office[0].xofficer);
                xreason = lt_tm_office[lt_tm_office.Count - 1].xcomment;
                if (c_mark.logo_pic != "")
                {
                    tm_img.ImageUrl = "./" + c_mark.logo_pic;

                    //if (File.Exists(serverpath + "\\admin\\tm\\" + c_mark.logo_pic))
                    //{
                    //    tm_img.Height = new Unit(120, UnitType.Pixel);
                    //    tm_img.Width = new Unit(120, UnitType.Pixel);
                    //    try
                    //    {
                    //        FileStream st = new FileStream(serverpath + "\\admin\\tm\\" + c_mark.logo_pic, FileMode.Open, FileAccess.Read);
                    //        System.Drawing.Image new_img = System.Drawing.Image.FromStream(st);
                    //        string ht = new_img.Height.ToString();
                    //        string wt = new_img.Width.ToString();
                    //        if ((ht != "") && (wt != "") && (ht != null) && (wt != null))
                    //        {

                    //            if (Convert.ToInt32(ht) > Convert.ToInt32(wt))
                    //            {
                    //                tm_img.Height = new Unit(320, UnitType.Pixel);
                    //                tm_img.Width = new Unit(240, UnitType.Pixel);
                    //            }
                    //            else
                    //            {
                    //                tm_img.Height = new Unit(240, UnitType.Pixel);
                    //                tm_img.Width = new Unit(320, UnitType.Pixel);
                    //            }
                    //        }
                    //        else
                    //        {
                    //            // tm_img.Height = new Unit(120, UnitType.Pixel);
                    //            // tm_img.Width = new Unit(120, UnitType.Pixel);
                    //            tm_img.Visible = false;
                    //        }
                    //    }
                    //    catch (Exception ex)
                    //    {
                    //        tm_img.Visible = false;
                    //    }
                    //}
                    //else
                    //{
                    //    // tm_img.Height = new Unit(120, UnitType.Pixel);
                    //    // tm_img.Width = new Unit(120, UnitType.Pixel);
                    //    tm_img.Visible = false;
                    //}


                }
            }
            else
            {
                base.Response.Redirect("./rejection_slip.aspx");
            }
        }
    }
}

