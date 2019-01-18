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

    public partial class g_ipo_rep_ack : Page
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
        protected int renewal_show;
        public Retriever ret = new Retriever();
        protected string serverpath = "";
        public string status = "0";
        protected int tm_info_succ;
        public string vid;
        protected int x_succ;

        protected void btnDashBoard_Click(object sender, EventArgs e)
        {
            base.Response.Redirect(ConfigurationManager.AppSettings["ipo_profile_page"]);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.serverpath = base.Server.MapPath("~/");
            this.fee_list = this.ret.getFee_listByCat("tm");
            if (!this.Page.IsPostBack)
            {
                if ((base.Request.QueryString["0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD"] != null) && (base.Request.QueryString["0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD"] != ""))
                {
                    this.vid = base.Request.QueryString["0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD"];
                    this.g_pwallet = this.ret.getG_PwalletByValidationID(this.vid);
                    if ((this.g_pwallet.xid != null) && (this.g_pwallet.xid != ""))
                    {
                        this.g_tm_info = this.ret.getG_Tm_infoByPwalletID(this.g_pwallet.xid);
                        this.g_app_info = this.ret.getG_App_infoByPwalletID(this.g_pwallet.xid);
                        this.g_applicant_info = this.ret.getG_Applicant_infoByPwalletID(this.g_pwallet.xid);
                        this.g_agent_info = this.ret.getGenAgentByPwalletID(this.g_pwallet.xid);
                        this.g_ass_info = this.ret.getG_Ass_infoByPwalletID(this.g_pwallet.xid);
                        this.g_cert_info = this.ret.getG_Cert_infoByPwalletID(this.g_pwallet.xid);
                        this.g_change_info = this.ret.getG_Change_infoByPwalletID(this.g_pwallet.xid);
                        this.g_merger_info = this.ret.getG_Merger_infoByPwalletID(this.g_pwallet.xid);
                        this.g_renewal_info = this.ret.getG_Renewal_infoByPwalletID(this.g_pwallet.xid);
                        this.g_prelim_search_info = this.ret.getG_Prelim_search_infoByPwalletID(this.g_pwallet.xid);
                        this.g_other_items_info = this.ret.getG_Other_items_infoByPwalletID(this.g_pwallet.xid);
                        if (this.g_tm_info.logo_pic != "")
                        {
                            this.tm_img.ImageUrl = "../admin/tm/gf/" + this.g_tm_info.logo_pic;
                            if (File.Exists(this.serverpath + @"\admin\tm\gf\" + this.g_tm_info.logo_pic))
                            {
                                this.tm_img.Height = new Unit(120.0, UnitType.Pixel);
                                this.tm_img.Width = new Unit(120.0, UnitType.Pixel);
                                try
                                {
                                    FileStream stream = new FileStream(this.serverpath + @"\admin\tm\gf\" + this.g_tm_info.logo_pic, FileMode.Open, FileAccess.Read);
                                    System.Drawing.Image image = System.Drawing.Image.FromStream(stream);
                                    string str = image.Height.ToString();
                                    string str2 = image.Width.ToString();
                                    if (((str != "") && (str2 != "")) && ((str != null) && (str2 != null)))
                                    {
                                        if (Convert.ToInt32(str) > Convert.ToInt32(str2))
                                        {
                                            this.tm_img.Height = new Unit(320.0, UnitType.Pixel);
                                            this.tm_img.Width = new Unit(240.0, UnitType.Pixel);
                                        }
                                        else
                                        {
                                            this.tm_img.Height = new Unit(240.0, UnitType.Pixel);
                                            this.tm_img.Width = new Unit(320.0, UnitType.Pixel);
                                        }
                                    }
                                    else
                                    {
                                        this.tm_img.Visible = false;
                                    }
                                }
                                catch (Exception)
                                {
                                    this.tm_img.Visible = false;
                                }
                            }
                            else
                            {
                                this.tm_img.Visible = false;
                            }
                        }
                        foreach (XObjs.Fee_list _list in this.fee_list)
                        {
                            if (_list.item_code == this.g_pwallet.log_officer)
                            {
                                this.lbl_type.Text = _list.item.ToUpper();
                            }
                        }
                        this.ShowSection(this.g_pwallet.log_officer);
                    }
                }
            }
            else if (this.Session["pwalletID"] != null)
            {
                this.pwalletID = this.Session["pwalletID"].ToString();
            }
        }

        public void ShowSection(string item_code)
        {
            if (item_code == "T001")
            {
                this.prelim_show = 1;
                this.Session["item_code"] = item_code;
            }
            else if (item_code == "T003")
            {
                this.cert_show = 1;
                this.Session["item_code"] = item_code;
            }
            else if (item_code == "T008")
            {
                this.change_show = 1;
                this.Session["item_code"] = item_code;
            }
            else if (item_code == "T009")
            {
                this.renewal_show = 1;
                this.Session["item_code"] = item_code;
            }
            else if (item_code == "T014")
            {
                this.ass_show = 1;
                this.merger_show = 1;
                this.Session["item_code"] = item_code;
            }
            else if ((((item_code != "T001") && (item_code != "T002")) && ((item_code != "T003") && (item_code != "T008"))) && ((item_code != "T009") && (item_code != "T014")))
            {
                this.others_show = 1;
                this.Session["item_code"] = item_code;
            }
        }
    }
}

