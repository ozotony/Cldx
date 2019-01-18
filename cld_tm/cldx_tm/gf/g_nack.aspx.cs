namespace cld.gf
{
    using cld.Classes;
    using Odyssey;
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Drawing;
    using System.IO;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public partial class g_nack : Page
    {
        protected int app_succ;
        protected int applicant_succ;
        protected int ass_show;
        protected int cert_show;
        protected int change_show;
        public List<XObjs.Fee_list> fee_list = new List<XObjs.Fee_list>();
        public XObjs.Gen_Agent_info g_agent_info = new XObjs.Gen_Agent_info();
        public XObjs.G_App_info g_app_info = new XObjs.G_App_info();
        public XObjs.G_Applicant_info g_applicant_info = new XObjs.G_Applicant_info();
        public XObjs.G_Ass_info g_ass_info = new XObjs.G_Ass_info();
        public XObjs.G_Cert_info g_cert_info = new XObjs.G_Cert_info();
        public XObjs.G_Change_info g_change_info = new XObjs.G_Change_info();
        public XObjs.G_Merger_info g_merger_info = new XObjs.G_Merger_info();
        public XObjs.G_Other_items_info g_other_items_info = new XObjs.G_Other_items_info();
        public XObjs.G_Prelim_search_info g_prelim_search_info = new XObjs.G_Prelim_search_info();
        public XObjs.G_Pwallet g_pwallet = new XObjs.G_Pwallet();
        public XObjs.G_Renewal_info g_renewal_info = new XObjs.G_Renewal_info();
        public XObjs.G_Tm_info g_tm_info = new XObjs.G_Tm_info();
        protected int merger_show;
        public Odyssey ody = new Odyssey();
        protected int others_show;
        protected int prelim_show;
        public string pwalletID = "0";
        public string hwalletID = "0";
        protected int renewal_show;
        public Retriever ret = new Retriever();
        protected string serverpath = "";
        public string status = "0";
        protected int tm_info_succ;
        public string vid;
        protected int x_succ;     

        protected void btnDashBoard_Click(object sender, EventArgs e)
        {
           Response.Redirect(ConfigurationManager.AppSettings["ipo_profile_page"]);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
          
           serverpath =Server.MapPath("~/");
           fee_list =ret.getFee_listByCat("tm");
            if (!Page.IsPostBack)
            {
               tm_img.ImageUrl = "";
               if ((Session["vid"] != null) && (Session["vid"].ToString() != ""))
                {
                    vid = Session["vid"].ToString();
                   g_pwallet =ret.getG_PwalletByValidationID(vid);
                    if ((g_pwallet.xid != null) && (g_pwallet.xid != ""))
                    {
                      
                       g_tm_info =ret.getG_Tm_infoByPwalletID(g_pwallet.xid);
                       g_app_info =ret.getG_App_infoByPwalletID(g_pwallet.xid);
                       g_applicant_info =ret.getG_Applicant_infoByPwalletID(g_pwallet.xid);
                       g_agent_info =ret.getGenAgentByPwalletID(g_pwallet.xid);
                       g_ass_info =ret.getG_Ass_infoByPwalletID(g_pwallet.xid);
                       g_cert_info =ret.getG_Cert_infoByPwalletID(g_pwallet.xid);
                       g_change_info =ret.getG_Change_infoByPwalletID(g_pwallet.xid);
                       g_merger_info =ret.getG_Merger_infoByPwalletID(g_pwallet.xid);
                       g_renewal_info =ret.getG_Renewal_infoByPwalletID(g_pwallet.xid);
                       g_prelim_search_info =ret.getG_Prelim_search_infoByPwalletID(g_pwallet.xid);
                       g_other_items_info =ret.getG_Other_items_infoByPwalletID(g_pwallet.xid);
                        if (g_tm_info.logo_pic != "")
                        {
                           tm_img.ImageUrl = "../admin/tm/gf/" +g_tm_info.logo_pic;
                            if (File.Exists(serverpath + @"\admin\tm\gf\" +g_tm_info.logo_pic))
                            {
                               tm_img.Height = new Unit(120.0, UnitType.Pixel);
                               tm_img.Width = new Unit(120.0, UnitType.Pixel);
                                try
                                {
                                    FileStream stream = new FileStream(serverpath + @"\admin\tm\gf\" +g_tm_info.logo_pic, FileMode.Open, FileAccess.Read);
                                    System.Drawing.Image image = System.Drawing.Image.FromStream(stream);
                                    string str = image.Height.ToString();
                                    string str2 = image.Width.ToString();
                                    if (((str != "") && (str2 != "")) && ((str != null) && (str2 != null)))
                                    {
                                        if (Convert.ToInt32(str) > Convert.ToInt32(str2))
                                        {
                                           tm_img.Height = new Unit(320.0, UnitType.Pixel);
                                           tm_img.Width = new Unit(240.0, UnitType.Pixel);
                                        }
                                        else
                                        {
                                           tm_img.Height = new Unit(240.0, UnitType.Pixel);
                                           tm_img.Width = new Unit(320.0, UnitType.Pixel);
                                        }
                                    }
                                    else
                                    {
                                       tm_img.Visible = false;
                                    }
                                }
                                catch (Exception)
                                {
                                   tm_img.Visible = false;
                                }
                            }
                            else
                            {
                               tm_img.Visible = false;
                            }
                        }
                        foreach (XObjs.Fee_list _list in fee_list)
                        {
                            if (_list.item_code ==g_pwallet.log_officer)
                            {
                               lbl_type.Text = _list.item.ToUpper();
                            }
                        }
                       ShowSection(g_pwallet.log_officer);
                      
                  }
                }
            }
            else if (Session["pwalletID"] != null)
            {
               pwalletID =Session["pwalletID"].ToString();
            }
        }

        public void ShowSection(string item_code)
        {
            if (item_code == "T001")
            {
               prelim_show = 1;
               Session["item_code"] = item_code;
            }
            else if (item_code == "T003")
            {
               cert_show = 1;
               Session["item_code"] = item_code;
            }
            else if (item_code == "T008")
            {
               change_show = 1;
               Session["item_code"] = item_code;
            }
            else if (item_code == "T009")
            {
               renewal_show = 1;
               Session["item_code"] = item_code;
            }
            else if (item_code == "T014")
            {
                if (g_merger_info.xid != null) { merger_show = 1; ass_show = 0; } else { merger_show = 0; ass_show = 1; }             
              
               Session["item_code"] = item_code;
            }
            else if ((((item_code != "T001") && (item_code != "T002")) && ((item_code != "T003") && (item_code != "T008"))) && ((item_code != "T009") && (item_code != "T014")))
            {
               others_show = 1;
               Session["item_code"] = item_code;
            }
        }
    }
}

