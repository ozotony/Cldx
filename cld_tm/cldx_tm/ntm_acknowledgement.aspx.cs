using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Configuration;

namespace cld
{
    using Classes;
    public partial class ntm_acknowledgement : System.Web.UI.Page
    {
        public string aid = "";
        public string amt = "";        
        public string gt = "";
        public string pwalletID = "";
        public string hwalletID = "";
        public tm t = new tm();
        public string validationID = "";
        public string vid = "";
        public string serverpath = "";        

        protected cld.Classes.XObjs.Trademark_item ti = new cld.Classes.XObjs.Trademark_item();
        public tm.AddressService c_aos = new tm.AddressService();
        public tm.Applicant c_app = new tm.Applicant();
        public tm.Address c_app_addy = new tm.Address();
        public tm.MarkInfo c_mark = new tm.MarkInfo();
        public tm.Representative c_rep = new tm.Representative();
        public tm.Address c_rep_addy = new tm.Address();
        public tm.Stage c_stage = new tm.Stage();
        protected Retriever ret = new Retriever();

        protected void Page_Load(object sender, EventArgs e)
        {
            serverpath = base.Server.MapPath("~/");
            if (Session["vid"] != null)  { vid = Session["vid"].ToString();   }
            if (Session["amt"] != null) {  amt = Session["amt"].ToString();}
            if (Session["aid"] != null) {  aid = Session["aid"].ToString(); }
            if (Session["gt"] != null) { gt = Session["gt"].ToString(); }            

            pwalletID = t.getPwalletID(vid);
            if (pwalletID != "")
            {    
                        c_mark = t.getMarkInfoClassByUserID(pwalletID);
                        c_rep = t.getRepClassByUserID(pwalletID);
                        c_stage = t.getStageClassByUserID(pwalletID);
                        c_app = t.getApplicantClassByID(pwalletID);
                        c_app_addy = t.getAddressClassByID(c_app.addressID);

                        if (c_mark.logo_pic != "")
                        {
                            tm_img.ImageUrl = "./admin/tm/" + c_mark.logo_pic;

                            if (File.Exists(serverpath + "\\admin\\tm\\" + c_mark.logo_pic))
                            {
                                tm_img.Height = new Unit(120, UnitType.Pixel);  tm_img.Width = new Unit(120, UnitType.Pixel);
                                try
                                {
                                    FileStream st = new FileStream(serverpath + "\\admin\\tm\\" + c_mark.logo_pic, FileMode.Open, FileAccess.Read);
                                    System.Drawing.Image new_img = System.Drawing.Image.FromStream(st);
                                    string ht = new_img.Height.ToString();
                                    string wt = new_img.Width.ToString();
                                    if ((ht != "") && (wt != "") && (ht != null) && (wt != null))
                                    {
                                        if (Convert.ToInt32(ht) > Convert.ToInt32(wt))
                                        {
                                            tm_img.Height = new Unit(320, UnitType.Pixel);    tm_img.Width = new Unit(240, UnitType.Pixel);
                                        }
                                        else
                                        {
                                            tm_img.Height = new Unit(240, UnitType.Pixel); tm_img.Width = new Unit(320, UnitType.Pixel);
                                        }
                                    }
                                    else
                                    {
                                        // tm_img.Height = new Unit(120, UnitType.Pixel); tm_img.Width = new Unit(120, UnitType.Pixel);
                                        tm_img.Visible = false;
                                    }
                                }
                                catch (Exception ex)
                                {
                                    tm_img.Visible = false;
                                }
                            }
                            else
                            {
                                // tm_img.Height = new Unit(120, UnitType.Pixel);  tm_img.Width = new Unit(120, UnitType.Pixel);
                                tm_img.Visible = false;
                            }
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
        }

        protected void btnDashboard_Click(object sender, EventArgs e)
        {
            Response.Redirect(ConfigurationManager.AppSettings["ipo_profile_page"]);
        }

        protected void btnDashboard2_Click(object sender, EventArgs e)
        {
            Response.Redirect(ConfigurationManager.AppSettings["ipo_profile_page"]);
        }
    }
}