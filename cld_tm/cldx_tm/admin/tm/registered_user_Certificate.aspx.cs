﻿using cld.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace cld.admin.tm
{
    public partial class registered_user_Certificate : System.Web.UI.Page
    {

        public string pwalletID = "0";
        public string admin = "";
        public cld.Classes.tm t = new cld.Classes.tm();
        public string admin_status = "9";
        public string vid = null;
        public string status = "0";
        public string xcomments = "";

        public string xhistory = "";
        public string xrecordal = "";
        public string vid2 = "";
        public zues z = new zues();
        public Classes.XObjs.G_Pwallet g_pwallet = new Classes.XObjs.G_Pwallet();
        public Classes.XObjs.G_App_info g_app_info = new Classes.XObjs.G_App_info();
        public Classes.XObjs.G_Applicant_info g_applicant_info = new Classes.XObjs.G_Applicant_info();
        public Classes.XObjs.Gen_Agent_info g_agent_info = new Classes.XObjs.Gen_Agent_info();
        public Classes.XObjs.G_Tm_info g_tm_info = new Classes.XObjs.G_Tm_info();
        public Classes.XObjs.G_Ass_info g_ass_info = new Classes.XObjs.G_Ass_info();
        public Classes.XObjs.G_Cert_info g_cert_info = new Classes.XObjs.G_Cert_info();
        public Classes.XObjs.G_Change_info g_change_info = new Classes.XObjs.G_Change_info();
        public Classes.XObjs.G_Merger_info g_merger_info = new Classes.XObjs.G_Merger_info();
        public Classes.XObjs.G_Renewal_info g_renewal_info = new Classes.XObjs.G_Renewal_info();
        public Classes.XObjs.G_Prelim_search_info g_prelim_search_info = new Classes.XObjs.G_Prelim_search_info();
        public Classes.XObjs.G_Other_items_info g_other_items_info = new Classes.XObjs.G_Other_items_info();

        public cld.Classes.tm.AddressService c_aos = new cld.Classes.tm.AddressService();
        public cld.Classes.tm.Applicant c_app = new cld.Classes.tm.Applicant();
        public cld.Classes.tm.Address c_app_addy = new cld.Classes.tm.Address();
        public cld.Classes.tm.MarkInfo c_mark = new cld.Classes.tm.MarkInfo();
        public cld.Classes.tm.Representative c_rep = new cld.Classes.tm.Representative();
        public cld.Classes.tm.Address c_rep_addy = new cld.Classes.tm.Address();
        public cld.Classes.tm.Stage c_stage = new cld.Classes.tm.Stage();
        public cld.Classes.XObjs.Pwallet pwallet = new cld.Classes.XObjs.Pwallet();
        public String spwallet = "";
        public string succ = "";
        public List<zues.G_TmOffice> lt_tm_office = new List<zues.G_TmOffice>();
        public zues.Adminz lt_x_admin_details = new zues.Adminz();
        public List<Classes.XObjs.Fee_list> fee_list = new List<Classes.XObjs.Fee_list>();
        public Classes.Retriever ret = new Classes.Retriever();
        public Odyssey.Odyssey ody = new Odyssey.Odyssey();
        // public tm t = new tm();
        public string rbval_text = "";
        public Label Label1;
        public Label Label2;
        public Label Label3;
        public Label Label4;
        public Label Label5;
        public Label Label6;
        public Label Label7;
        public Label Label8;
        public Label Label9;
        public Label Label10;
        public Label Label11;
        public Label Label12;
        public Label Label13;
        public List<Recordal_Detail> xp = new List<Recordal_Detail>();
        public String vofficer = "";
        public List<Recordal> vd = new List<Recordal>();
        public zues.Adminz xxk = new zues.Adminz();
        // protected RadioButtonList rbValid;
        protected int cert_show = 0; protected int merger_show = 0; protected int ass_show = 0; protected int change_show = 0;
        protected int prelim_show = 0; protected int renewal_show = 0; protected int others_show = 0;

        protected int app_succ = 0; protected int applicant_succ = 0; protected int tm_info_succ = 0;
        protected int x_succ = 0; protected string serverpath = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            vupdate();
        }

        public void vupdate()
        {
            if ((this.Session["pwalletID"] != null) && (this.Session["pwalletID"].ToString() != ""))
            {


                admin = Convert.ToString(Session["pwalletID"]);
            }


            if ((this.Request.QueryString["0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD"] != null) &&
                    (this.Request.QueryString["0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD"] != "")
                )
            {
                vid = Request.QueryString["0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD"];
                vid2 = Request.QueryString["Recordalid"];
                spwallet = ret.getCheckStatusDetails(vid);
                this.c_mark = this.t.getMarkInfoClassByUserID(spwallet);
                this.c_rep = this.t.getRepClassByUserID(spwallet);
                this.c_stage = this.t.getStageClassByUserID(spwallet);
                this.c_app = this.t.getApplicantClassByID(spwallet);






                if ((c_app.addressID != null) && (c_app.addressID != "") && (c_app.addressID != "0"))
                {
                    this.c_app_addy = this.t.getAddressClassByID(this.c_app.addressID);



                }
                if ((c_rep.addressID != null) && (c_rep.addressID != "") && (c_rep.addressID != "0"))
                {
                    this.c_rep_addy = this.t.getAddressClassByID(this.c_rep.addressID);
                }
                serverpath = base.Server.MapPath("~/");
                if (c_mark.logo_pic != "")
                {
                    tm_img.ImageUrl = "~/admin/tm/" + c_mark.logo_pic;

                    if (File.Exists(serverpath + "\\admin\\tm\\" + c_mark.logo_pic))
                    {
                        tm_img.Height = new Unit(120, UnitType.Pixel); tm_img.Width = new Unit(120, UnitType.Pixel);
                        try
                        {
                            FileStream st = new FileStream(serverpath + "\\admin\\tm\\" + c_mark.logo_pic, FileMode.Open, FileAccess.Read);
                            System.Drawing.Image new_img = System.Drawing.Image.FromStream(st);
                            string ht = new_img.Height.ToString();
                            string wt = new_img.Width.ToString();
                            if ((ht != "") && (wt != "") && (ht != null) && (wt != null))
                            {
                                tm_img.Height = new Unit(120, UnitType.Pixel); tm_img.Width = new Unit(220, UnitType.Pixel);
                                //if (Convert.ToInt32(ht) > Convert.ToInt32(wt))
                                //{
                                //    tm_img.Height = new Unit(300, UnitType.Pixel); tm_img.Width = new Unit(240, UnitType.Pixel);
                                //}
                                //else
                                //{
                                //    tm_img.Height = new Unit(120, UnitType.Pixel); tm_img.Width = new Unit(220, UnitType.Pixel);
                                //}
                            }
                            else
                            {
                                tm_img.Visible = false;// tm_img.Height = new Unit(120, UnitType.Pixel); tm_img.Width = new Unit(120, UnitType.Pixel);
                            }
                        }
                        catch (Exception ex)
                        {
                            tm_img.Visible = false;
                        }
                    }
                    else
                    {
                        tm_img.Visible = false;// tm_img.Height = new Unit(120, UnitType.Pixel);  tm_img.Width = new Unit(120, UnitType.Pixel);
                    }
                }

                if ((vid != null))
                {
                    //Label1.Text = c_mark.reg_number;
                    //Label2.Text = c_stage.rtm;
                    //Label3.Text = c_mark.nice_class;
                    //Label4.Text = c_mark.product_title;




                    //Label10.Text = c_rep_addy.street;
                    //Label11.Text = c_rep_addy.email1;

                    //this.lt_tm_office = this.z.getG_TmOfficeDetailsByID(g_pwallet.xid);
                    zues zz2 = new zues();
                    Int32 vint2 = zz2.getMaxId(spwallet);
                    vint2 = Convert.ToInt32(vid2);
                    vd = ret.getG_PwalletByID3(vint2);
                    String vdate = vd[0].RECORDAL_APPROVE_DATE.ToString("yyyy-MM-dd");
                    string sid = z.getLastTmOfficeByID2(c_mark.log_staff, vdate).xofficer;

                    try
                    {

                        vofficer = z.getAdminDetails(sid).xname.ToUpper();

                    }

                    catch (Exception ee)
                    {

                        var kk = ee.Message;
                    }

                    //if (vd[0].OFFICER != "" || vd[0].OFFICER != null) {

                    //    vofficer = z.getAdminDetails(vd[0].OFFICER).xname.ToUpper();



                    //}




                    //int vvs = vd.Count() - 1;
                    // xxk = z.getAdminDetails(vd[vvs].OFFICER);


                    xp = ret.get_RecordalDetail(vd[0].Detail_Id);



                    //Label8.Text =xp[0].newApplicantName;
                    //Label9.Text = xp[0].newApplicantAddress;
                    //Label5.Text = vd[vvs].RECORDAL_REQUEST_DATE.ToString("d"); ;
                    //Label6.Text = vd[vvs].OLD_APPLICANTADDRESS;
                    //Label7.Text = vd[vvs].NEW_APPLICANTADDRESS;
                    //Label12.Text = vd[vvs].RECORDAL_APPROVE_DATE.ToString("d"); ;



                    //Label13.Text = xxk.xname;


                }

            }
        }
    }
}