namespace cld.gf
{
    using cld.Classes;
    using Odyssey;
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public partial class g_napplication_old : Page
    {
        protected int agent_info_succ;
        public string agentemail;
        public string agentpnumber;
        public string agt;
        public string amt;
        protected int app_succ;
        public string applicant_addy;
        public string applicant_email;
        public string applicant_no;
        protected int applicant_succ;
        public string applicantname;
        protected int ass_show;
        protected XObjs.Pwallet c_pwall = new XObjs.Pwallet();
        protected int cert_show;
        protected int change_show;
        public string cname;
        public string fee_detailsID = "";
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
        public string gt;
        public string hwalletID = "";
        public string item_code;
        protected int merger_show;
        public Odyssey ody = new Odyssey();
        protected int others_show;
        protected int prelim_show;
        public string product_title;
        public string pwalletID = "0";
        public Registration reg = new Registration();
        protected int renewal_show;
        public string request_type;
        public Retriever ret = new Retriever();
        private string serverpath = "";
        public string status = "0";
        public XObjs.Trademark_item ti = new XObjs.Trademark_item();
        protected int tm_info_succ;
        public string transID;
        public string vid;
        protected int x_succ;
        public string xapplication;
        public string xgt;
        protected string xlog_staff = "1";
        protected string xreg_date = DateTime.Now.ToString("yyyy-MM-dd");
        protected string xvisible = "1";

        protected void Page_Load(object sender, EventArgs e)
        {
            this.fee_list = this.ret.getFee_listByCat("tm");
            this.serverpath = base.Server.MapPath("~/");
            if (this.Session["aid"] != null)
            {
                this.agt = this.Session["aid"].ToString();
            }
            if (this.Session["vid"] != null)
            {
                this.vid = this.Session["vid"].ToString();
            }
            else
            {
                base.Response.Redirect(ConfigurationManager.AppSettings["ipo_profile_page"]);
            }
            if (this.Session["amt"] != null)
            {
                this.amt = this.Session["amt"].ToString();
            }
            if (this.Session["xgt"] != null)
            {
                this.xgt = this.Session["xgt"].ToString();
            }
            if (this.Session["pwalletID"] != null)
            {
                this.pwalletID = this.Session["pwalletID"].ToString();
            }
            if (this.Session["agentemail"] != null)
            {
                this.agentemail = this.Session["agentemail"].ToString();
            }
            if (this.Session["cname"] != null)
            {
                this.cname = this.Session["cname"].ToString();
            }
            if (this.Session["agentpnumber"] != null)
            {
                this.agentpnumber = this.Session["agentpnumber"].ToString();
            }
            if (this.Session["applicantname"] != null)
            {
                this.applicantname = this.Session["applicantname"].ToString();
            }
            if (this.Session["applicant_addy"] != null)
            {
                this.applicant_addy = this.Session["applicant_addy"].ToString();
            }
            if (this.Session["applicant_email"] != null)
            {
                this.applicant_email = this.Session["applicant_email"].ToString();
            }
            if (this.Session["applicant_no"] != null)
            {
                this.applicant_no = this.Session["applicant_no"].ToString();
            }
            if (this.Session["product_title"] != null)
            {
                this.product_title = this.Session["product_title"].ToString();
            }
            if (this.Session["item_code"] != null)
            {
                this.item_code = this.Session["item_code"].ToString();
                this.ShowSection(this.Session["item_code"].ToString());
            }
            if (!this.Page.IsPostBack)
            {
                if ((((((this.vid != null) && (this.vid != "")) && ((this.amt != null) && (this.amt != ""))) && (((this.agt != null) && (this.agt != "")) && ((this.cname != null) && (this.cname != "")))) && ((((this.agentemail != null) && (this.agentemail != "")) && ((this.agentpnumber != null) && (this.agentpnumber != ""))) && (((this.applicantname != null) && (this.applicantname != "")) && ((this.applicant_addy != null) && (this.applicant_addy != ""))))) && ((((this.applicant_email != null) && (this.applicant_email != "")) && ((this.applicant_no != null) && (this.applicant_no != ""))) && (((this.product_title != null) && (this.product_title != "")) && ((this.item_code != null) && (this.item_code != "")))))
                {
                    this.PopulateRenewalType();
                    this.Session["pwalletID"] = this.pwalletID;
                    this.rep_code.Text = this.agt;
                    this.rep_xname.Text = this.cname;
                    this.txt_rep_telephone.Text = this.agentpnumber;
                    this.txt_rep_email.Text = this.agentemail;
                    this.txt_title_of_trademark.Text = this.product_title;
                    this.txt_applicant_name.Text = this.applicantname;
                    this.txt_applicant_address.Text = this.applicant_addy;
                    this.txt_applicant_email.Text = this.applicant_email;
                    this.txt_applicant_mobile.Text = this.applicant_no;
                    foreach (XObjs.Fee_list _list in this.fee_list)
                    {
                        if (_list.item_code == this.item_code)
                        {
                            this.lbl_type.Text = _list.item.ToUpper();
                        }
                    }
                    this.ShowSection(this.item_code);
                }
                else
                {
                    base.Response.Redirect(ConfigurationManager.AppSettings["ipo_profile_page"]);
                }
            }
            else if (this.Session["pwalletID"] != null)
            {
                this.pwalletID = this.Session["pwalletID"].ToString();
            }
        }

        public void PopulateRenewalType()
        {
            for (int i = 1; i <= 20; i++)
            {
                string text = i.ToString();
                ListItem item = new ListItem(text, i.ToString());
                this.select_renewal_type.Items.Add(item);
            }
        }

        protected void SaveAll_Click(object sender, EventArgs e)
        {
            this.g_app_info.filing_date = this.txt_application_date.Text;
            this.g_app_info.application_no = this.txt_application_no.Text;
            this.g_app_info.rtm_number = this.txt_rtm_no.Text;
            this.g_app_info.item_code = this.item_code;
            this.g_app_info.log_staff = this.pwalletID;
            this.g_app_info.reg_no = "";
            this.g_app_info.reg_date = this.xreg_date;
            this.g_app_info.visible = this.xvisible;
            this.app_succ = this.reg.addG_App_info(this.g_app_info);
            this.Session["app_succID"] = this.app_succ;
            if (this.app_succ > 0)
            {
                string str = string.Concat(new object[] { "TM/GF/", this.item_code, "/", DateTime.Now.ToString("yyyy"), "/", this.app_succ });
                this.reg.updateGAppInfoReg(this.app_succ.ToString(), str);
                this.g_applicant_info.trading_as = this.txt_trading_as.Text;
                this.g_applicant_info.visible = this.xvisible;
                this.g_applicant_info.address = this.txt_applicant_address.Text;
                this.g_applicant_info.xemail = this.txt_applicant_email.Text;
                this.g_applicant_info.xmobile = this.txt_applicant_mobile.Text;
                this.g_applicant_info.xname = this.txt_applicant_name.Text;
                this.g_applicant_info.nationality = this.select_applicant_nationality.SelectedValue;
                this.g_applicant_info.log_staff = this.pwalletID;
                this.applicant_succ = this.reg.addG_Applicant_info(this.g_applicant_info);
                this.Session["applicant_succID"] = this.applicant_succ;
                if (this.applicant_succ > 0)
                {
                    this.g_tm_info.disclaimer = this.txt_discalimer.Text;
                    this.g_tm_info.tm_class = this.select_class_of_trademark.SelectedValue;
                    this.g_tm_info.tm_desc = this.txt_goods_desc.Text;
                    this.g_tm_info.tm_title = this.txt_title_of_trademark.Text;
                    this.g_tm_info.xtype = this.tmType.SelectedValue;
                    this.g_tm_info.reg_number = "";
                    this.g_tm_info.logo_descID = this.logo_description.SelectedValue;
                    if (this.g_tm_info.logo_descID != "WORD MARK")
                    {
                        this.Session["logo_desc"] = "yes";
                    }
                    else
                    {
                        this.Session["logo_desc"] = "no";
                    }
                    this.g_tm_info.logo_pic = "";
                    this.g_tm_info.auth_doc = "";
                    this.g_tm_info.sup_doc1 = "";
                    this.g_tm_info.app_letter_doc = "";
                    this.g_tm_info.log_staff = this.pwalletID;
                    this.g_tm_info.reg_date = this.xreg_date;
                    this.g_tm_info.visible = this.xvisible;
                    this.tm_info_succ = this.reg.addG_Tm_info(this.g_tm_info);
                    this.Session["new_miID"] = this.tm_info_succ;
                    if (this.tm_info_succ > 0)
                    {
                        this.g_agent_info.code = this.agt;
                        this.g_agent_info.xname = this.rep_xname.Text;
                        this.g_agent_info.xpassword = "";
                        this.g_agent_info.nationality = this.txt_rep_nationality.Text;
                        this.g_agent_info.country = this.txt_rep_country.Text;
                        this.g_agent_info.state = this.selectRepState.SelectedValue;
                        this.g_agent_info.address = this.txt_rep_address.Text;
                        this.g_agent_info.telephone = this.txt_rep_telephone.Text;
                        this.g_agent_info.email = this.txt_rep_email.Text;
                        this.g_agent_info.log_staff = this.pwalletID;
                        this.g_agent_info.xsync = "0";
                        this.agent_info_succ = this.reg.addGen_Agent_info(this.g_agent_info);
                        this.Session["agent_succID"] = this.agent_info_succ;
                        if (this.agent_info_succ > 0)
                        {
                            if (this.Session["hwalletID"] != null)
                            {
                                this.hwalletID = this.Session["hwalletID"].ToString();
                                this.status = this.reg.updateHwallet(this.hwalletID, "Used", this.xreg_date, this.g_tm_info.tm_title).ToString();
                            }
                            if ((this.ass_show > 0) && (this.select_merger_ass.SelectedValue == "Assignment"))
                            {
                                this.g_ass_info.assignee_address = this.txt_assignee_address.Text;
                                this.g_ass_info.assignee_name = this.txt_assignee_name.Text;
                                this.g_ass_info.assignor_address = this.txt_assignor_address.Text;
                                this.g_ass_info.assignee_nationality = this.select_assignee_nationality.SelectedValue;
                                this.g_ass_info.assignor_name = this.txt_assignor_name.Text;
                                this.g_ass_info.date_of_assignment = this.txt_assignment_date.Text;
                                this.g_ass_info.assignor_nationality = this.select_assignor_nationality.SelectedValue;
                                this.g_ass_info.log_staff = this.pwalletID;
                                this.g_ass_info.xvisible = this.xvisible;
                                this.g_ass_info.ass_doc = "";
                                this.x_succ = this.reg.addG_Ass_info(this.g_ass_info);
                                this.Session["assID"] = this.x_succ;
                                this.Session["app_type"] = "ass";
                            }
                            else if ((this.merger_show > 0) && (this.select_merger_ass.SelectedValue == "Merger"))
                            {
                                this.g_merger_info.original_name = this.txt_original_name.Text;
                                this.g_merger_info.original_address = this.txt_original_address.Text;
                                this.g_merger_info.merging_name = this.txt_merging_name.Text;
                                this.g_merger_info.merging_address = this.txt_merging_address.Text;
                                this.g_merger_info.merged_coy_name = this.txt_merged_coy_name.Text;
                                this.g_merger_info.merger_date = this.txt_merger_date.Text;
                                this.g_merger_info.visible = this.xvisible;
                                this.g_merger_info.log_staff = this.pwalletID;
                                this.g_merger_info.merger_doc = "";
                                this.x_succ = this.reg.addG_Merger_info(this.g_merger_info);
                                this.Session["mergerID"] = this.x_succ;
                                this.Session["app_type"] = "merger";
                            }
                            else if (this.cert_show > 0)
                            {
                                this.g_cert_info.log_staff = this.pwalletID;
                                this.g_cert_info.reg_date = this.xreg_date;
                                this.g_cert_info.xvisible = this.xvisible;
                                this.g_cert_info.pub_date = this.txt_cert_publicationdate.Text;
                                this.g_cert_info.pub_details = this.txt_cert_details.Text;
                                this.g_cert_info.cert_doc = "";
                                this.g_cert_info.pub_doc = "";
                                this.x_succ = this.reg.addG_Cert_info(this.g_cert_info);
                                this.Session["certID"] = this.x_succ;
                                this.Session["app_type"] = "cert";
                            }
                            else if (this.change_show > 0)
                            {
                                this.g_change_info.new_name = this.txt_new_applicant_trademark.Text;
                                this.g_change_info.new_address = this.txt_new_applicant_address.Text;
                                this.g_change_info.old_name = this.txt_old_applicant_trademark.Text;
                                this.g_change_info.old_address = this.txt_old_applicant_address.Text;
                                this.g_change_info.reg_date = this.xreg_date;
                                this.g_change_info.visible = this.xvisible;
                                this.g_change_info.log_staff = this.pwalletID;
                                this.x_succ = this.reg.addG_Change_info(this.g_change_info);
                                this.Session["app_type"] = "change";
                            }
                            else if (this.renewal_show > 0)
                            {
                                this.g_renewal_info.prev_renewal_date = this.txt_renewal_date.Text;
                                this.g_renewal_info.renewal_type = this.select_renewal_type.SelectedValue;
                                this.g_renewal_info.visible = this.xvisible;
                                this.g_renewal_info.log_staff = this.pwalletID;
                                this.g_renewal_info.reg_date = this.xreg_date;
                                this.x_succ = this.reg.addG_Renewal_info(this.g_renewal_info);
                                this.Session["app_type"] = "renewal";
                            }
                            else if (this.prelim_show > 0)
                            {
                                this.g_prelim_search_info.xtitle = this.txt_prelim_title.Text;
                                this.g_prelim_search_info.xclass = this.select_prelim_class.SelectedValue;
                                this.g_prelim_search_info.xclass_desc = this.txt_prelim_desc.Text;
                                this.g_prelim_search_info.visible = this.xvisible;
                                this.g_prelim_search_info.log_staff = this.pwalletID;
                                this.g_prelim_search_info.reg_date = this.xreg_date;
                                this.x_succ = this.reg.addG_Prelim_search_info(this.g_prelim_search_info);
                                this.Session["app_type"] = "prelim";
                            }
                            else if (this.others_show > 0)
                            {
                                this.g_other_items_info.req_details = this.txt_details_of_request.Text;
                                this.g_other_items_info.visible = this.xvisible;
                                this.g_other_items_info.log_staff = this.pwalletID;
                                this.g_other_items_info.reg_date = this.xreg_date;
                                this.x_succ = this.reg.addG_Other_items_info(this.g_other_items_info);
                                this.Session["app_type"] = "others";
                            }
                        }
                    }
                }
            }
            if (this.x_succ > 0)
            {
                base.Response.Redirect("./g_napplication_docs.aspx");
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

