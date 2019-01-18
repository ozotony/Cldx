namespace cld.gf
{
    using cld.Classes;
    using System;
    using System.Collections.Generic;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public partial class g_tm_refill : Page
    {
        protected int agent_info_succ;
        protected int app_succ;
        public string app_type = "";
        protected int applicant_succ;
        protected int ass_show;
        protected XObjs.Pwallet c_pwall = new XObjs.Pwallet();
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
        public string item_code = "1";
        protected int merger_show;
        protected int others_show;
        protected int prelim_show;
        public Registration reg = new Registration();
        protected int renewal_show;
        public Retriever ret = new Retriever();
        protected string serverpath = "";
        public int showt;
        public tm t = new tm();
        public XObjs.Trademark_item ti = new XObjs.Trademark_item();
        protected int tm_info_succ;
        public string trans_status = "";
        public string vid = "";
        protected int x_succ;
        protected string xlog_staff = "1";
        protected string xreg_date = DateTime.Now.ToString("yyyy-MM-dd");
        protected string xvisible = "1";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (base.Request.QueryString["0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD"] != null)
            {
                this.vid = base.Request.QueryString["0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD"].ToString();
                this.Session["vid"] = this.vid;
            }
            this.serverpath = base.Server.MapPath("~/");
            this.fee_list = this.ret.getFee_listByCat("tm");
            if (this.Session["app_type"] != null)
            {
                this.app_type = this.Session["app_type"].ToString();
            }
            if (this.Session["showt"] != null)
            {
                this.showt = Convert.ToInt32(this.Session["showt"]);
            }
            if (this.Session["item_code"] != null)
            {
                this.ShowSection(this.Session["item_code"].ToString());
            }
            this.Session["edit_transID"] = this.vid;
            this.g_pwallet = this.ret.getG_PwalletByValidationID(this.vid);
            if ((this.g_pwallet.xid != null) && (this.g_pwallet.xid != ""))
            {
                this.rep_code.Text = this.g_pwallet.applicantID;
                this.Session["g_pwallet"] = this.g_pwallet;
                this.Session["g_pwalletID"] = this.g_pwallet.xid;
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
                foreach (XObjs.Fee_list _list in this.fee_list)
                {
                    if (_list.item_code == this.g_pwallet.log_officer)
                    {
                        this.lbl_type.Text = _list.item.ToUpper();
                    }
                }
                if (this.g_app_info.id != null)
                {
                    this.Session["g_app_info"] = this.g_app_info;
                    this.txt_rtm_no.Text = this.g_app_info.rtm_number;
                    this.txt_application_no.Text = this.g_app_info.application_no;
                    this.txt_application_date.Text = this.g_app_info.filing_date;
                }
                if (this.g_applicant_info.id != null)
                {
                    this.Session["g_applicant_info"] = this.g_applicant_info;
                    this.txt_applicant_name.Text = this.g_applicant_info.xname;
                    this.txt_applicant_address.Text = this.g_applicant_info.address;
                    this.txt_applicant_email.Text = this.g_applicant_info.xemail;
                    this.txt_applicant_mobile.Text = this.g_applicant_info.xmobile;
                    this.txt_trading_as.Text = this.g_applicant_info.trading_as;
                    this.select_applicant_nationality.SelectedIndex = Convert.ToInt32(this.t.getCountryIDByName(this.g_applicant_info.nationality)) - 1;
                }
                if (this.g_tm_info.xid != null)
                {
                    this.Session["g_tm_info"] = this.g_tm_info;
                    this.txt_title_of_trademark.Text = this.g_tm_info.tm_title;
                    this.txt_goods_desc.Text = this.g_tm_info.tm_desc;
                    this.txt_discalimer.Text = this.g_tm_info.disclaimer;
                    this.logo_description.SelectedIndex = Convert.ToInt32(this.t.getLogoDescriptionID(this.g_tm_info.logo_descID)) - 1;
                    this.select_class_of_trademark.SelectedIndex = Convert.ToInt32(this.g_tm_info.tm_class) - 1;
                    this.tmType.SelectedIndex = Convert.ToInt32(this.t.getTmTypeID(this.g_tm_info.xtype)) - 1;
                }
                if (this.g_agent_info.xid != null)
                {
                    this.Session["g_agent_info"] = this.g_agent_info;
                    this.rep_xname.Text = this.g_agent_info.xname;
                    this.txt_rep_address.Text = this.g_agent_info.address;
                    this.txt_rep_email.Text = this.g_agent_info.email;
                    this.txt_rep_telephone.Text = this.g_agent_info.telephone;
                    this.selectRepState.SelectedIndex = Convert.ToInt32(this.ret.getStateIDByName(this.g_agent_info.state)) - 1;
                }
                if (this.g_cert_info.xid != null)
                {
                    this.Session["g_cert_info"] = this.g_cert_info;
                    this.txt_cert_publicationdate.Text = this.g_cert_info.pub_date;
                    this.txt_cert_details.Text = this.g_cert_info.pub_details;
                }
                if (this.g_ass_info.xid != null)
                {
                    this.Session["g_ass_info"] = this.g_ass_info;
                    this.select_merger_ass.SelectedIndex = 0;
                    this.txt_assignee_name.Text = this.g_ass_info.assignee_name;
                    this.txt_assignee_address.Text = this.g_ass_info.assignee_address;
                    this.txt_assignor_name.Text = this.g_ass_info.assignor_name;
                    this.txt_assignor_address.Text = this.g_ass_info.assignor_address;
                    this.txt_assignment_date.Text = this.g_ass_info.date_of_assignment;
                    this.select_assignee_nationality.SelectedIndex = Convert.ToInt32(this.g_ass_info.assignee_nationality) - 1;
                    this.select_assignor_nationality.SelectedIndex = Convert.ToInt32(this.g_ass_info.assignor_nationality) - 1;
                }
                if (this.g_merger_info.xid != null)
                {
                    this.Session["g_merger_info"] = this.g_merger_info;
                    this.select_merger_ass.SelectedIndex = 1;
                    this.txt_original_name.Text = this.g_merger_info.original_name;
                    this.txt_original_address.Text = this.g_merger_info.original_address;
                    this.txt_merging_name.Text = this.g_merger_info.merging_name;
                    this.txt_merging_address.Text = this.g_merger_info.merging_address;
                    this.txt_merged_coy_name.Text = this.g_merger_info.merged_coy_name;
                    this.txt_merger_date.Text = this.g_merger_info.merger_date;
                }
                if (this.g_change_info.xid != null)
                {
                    this.Session["g_change_info"] = this.g_change_info;
                    this.txt_old_applicant_trademark.Text = this.g_change_info.old_name;
                    this.txt_old_applicant_address.Text = this.g_change_info.old_address;
                    this.txt_new_applicant_trademark.Text = this.g_change_info.new_name;
                    this.txt_new_applicant_address.Text = this.g_change_info.new_address;
                }
                if (this.g_prelim_search_info.xid != null)
                {
                    this.Session["g_prelim_search_info"] = this.g_prelim_search_info;
                    this.txt_prelim_title.Text = this.g_prelim_search_info.xtitle;
                    this.select_prelim_class.SelectedIndex = Convert.ToInt32(this.g_prelim_search_info.xclass) - 1;
                    this.txt_prelim_desc.Text = this.g_prelim_search_info.xclass_desc;
                }
                if (this.g_renewal_info.xid != null)
                {
                    this.Session["g_renewal_info"] = this.g_renewal_info;
                    this.txt_renewal_date.Text = this.g_renewal_info.prev_renewal_date;
                    this.select_renewal_type.SelectedIndex = Convert.ToInt32(this.g_renewal_info.renewal_type) - 1;
                }
                if (this.g_other_items_info.xid != null)
                {
                    this.Session["g_other_items_info"] = this.g_other_items_info;
                    this.txt_details_of_request.Text = this.g_other_items_info.req_details;
                }
                this.ShowSection(this.g_pwallet.log_officer);
                this.showt = 1;
                this.Session["showt"] = this.showt;
            }
            else
            {
                base.Response.Write("<script language=JavaScript>alert('PLEASE ENTER A VALID REFERENCE NUMBER')</script>");
                base.Response.Redirect("http://www.ipo.cldng.com/A/v_bask.aspx");
            }
        }

        protected void SaveEdit_Click(object sender, EventArgs e)
        {
            if (this.Session["item_code"] != null)
            {
                this.item_code = this.Session["item_code"].ToString();
            }
            if (this.Session["g_pwallet"] != null)
            {
                this.g_pwallet = (XObjs.G_Pwallet)this.Session["g_pwallet"];
            }
            if (this.Session["g_app_info"] != null)
            {
                this.g_app_info = (XObjs.G_App_info)this.Session["g_app_info"];
            }
            if (this.Session["g_applicant_info"] != null)
            {
                this.g_applicant_info = (XObjs.G_Applicant_info)this.Session["g_applicant_info"];
            }
            if (this.Session["g_tm_info"] != null)
            {
                this.g_tm_info = (XObjs.G_Tm_info)this.Session["g_tm_info"];
            }
            if (this.Session["g_agent_info"] != null)
            {
                this.g_agent_info = (XObjs.Gen_Agent_info)this.Session["g_agent_info"];
            }
            if (this.Session["g_ass_info"] != null)
            {
                this.g_ass_info = (XObjs.G_Ass_info)this.Session["g_ass_info"];
            }
            if (this.Session["g_cert_info"] != null)
            {
                this.g_cert_info = (XObjs.G_Cert_info)this.Session["g_cert_info"];
            }
            if (this.Session["g_change_info"] != null)
            {
                this.g_change_info = (XObjs.G_Change_info)this.Session["g_change_info"];
            }
            if (this.Session["g_merger_info"] != null)
            {
                this.g_merger_info = (XObjs.G_Merger_info)this.Session["g_merger_info"];
            }
            if (this.Session["g_renewal_info"] != null)
            {
                this.g_renewal_info = (XObjs.G_Renewal_info)this.Session["g_renewal_info"];
            }
            if (this.Session["g_prelim_search_info"] != null)
            {
                this.g_prelim_search_info = (XObjs.G_Prelim_search_info)this.Session["g_prelim_search_info"];
            }
            if (this.Session["g_other_items_info"] != null)
            {
                this.g_other_items_info = (XObjs.G_Other_items_info)this.Session["g_other_items_info"];
            }
            this.g_app_info.filing_date = this.txt_application_date.Text;
            this.g_app_info.application_no = this.txt_application_no.Text;
            this.g_app_info.rtm_number = this.txt_rtm_no.Text;
            this.g_app_info.item_code = this.item_code;
            this.g_app_info.reg_no = "";
            this.g_app_info.log_staff = this.g_pwallet.xid;
            this.g_app_info.reg_date = this.xreg_date;
            this.g_app_info.visible = this.xvisible;
            if (this.g_app_info.id != null)
            {
                this.app_succ = this.reg.update_App_info(this.g_app_info);
                this.Session["app_succID"] = this.app_succ;
            }
            else
            {
                this.app_succ = this.reg.addG_App_info(this.g_app_info);
                this.Session["app_succID"] = this.app_succ;
            }
            this.g_applicant_info.trading_as = this.txt_trading_as.Text;
            this.g_applicant_info.visible = this.xvisible;
            this.g_applicant_info.address = this.txt_applicant_address.Text;
            this.g_applicant_info.xemail = this.txt_applicant_email.Text;
            this.g_applicant_info.xmobile = this.txt_applicant_mobile.Text;
            this.g_applicant_info.xname = this.txt_applicant_name.Text;
            this.g_applicant_info.nationality = this.select_applicant_nationality.SelectedValue;
            this.g_applicant_info.log_staff = this.g_pwallet.xid;
            if (this.g_applicant_info.id != null)
            {
                this.applicant_succ = this.reg.update_Applicant_info(this.g_applicant_info);
                this.Session["applicant_succID"] = this.applicant_succ;
            }
            else
            {
                this.applicant_succ = this.reg.addG_Applicant_info(this.g_applicant_info);
                this.Session["applicant_succID"] = this.applicant_succ;
            }
            string str = "TM/GF/" + this.item_code + "/" + DateTime.Now.ToString("yyyy") + "/" + this.g_pwallet.xid;
            this.g_tm_info.disclaimer = this.txt_discalimer.Text;
            this.g_tm_info.tm_class = this.select_class_of_trademark.SelectedValue;
            this.g_tm_info.tm_desc = this.txt_goods_desc.Text;
            this.g_tm_info.tm_title = this.txt_title_of_trademark.Text;
            this.g_tm_info.xtype = this.tmType.SelectedValue;
            if ((this.g_tm_info.reg_number == null) || (this.g_tm_info.reg_number == ""))
            {
                this.g_tm_info.reg_number = "";
            }
            this.g_tm_info.logo_descID = this.logo_description.SelectedValue;
            if (this.g_tm_info.logo_descID != "WORD MARK")
            {
                this.Session["logo_desc"] = "yes";
            }
            if ((this.g_tm_info.logo_pic == null) || (this.g_tm_info.logo_pic == ""))
            {
                this.g_tm_info.logo_pic = "";
            }
            if ((this.g_tm_info.auth_doc == null) || (this.g_tm_info.auth_doc == ""))
            {
                this.g_tm_info.auth_doc = "";
            }
            if ((this.g_tm_info.sup_doc1 == null) || (this.g_tm_info.sup_doc1 == ""))
            {
                this.g_tm_info.sup_doc1 = "";
            }
            if ((this.g_tm_info.app_letter_doc == null) || (this.g_tm_info.app_letter_doc == ""))
            {
                this.g_tm_info.app_letter_doc = "";
            }
            this.g_tm_info.log_staff = this.g_pwallet.xid;
            this.g_tm_info.reg_date = this.xreg_date;
            this.g_tm_info.visible = this.xvisible;
            this.g_tm_info.reg_number = str;
            if (this.g_tm_info.xid != null)
            {
                this.Session["new_miID"] = this.g_tm_info.xid;
                this.tm_info_succ = this.reg.update_Tm_info(this.g_tm_info);
            }
            else
            {
                this.tm_info_succ = this.reg.addG_Tm_info(this.g_tm_info);
                this.Session["new_miID"] = this.tm_info_succ;
            }
            this.g_agent_info.code = this.rep_code.Text;
            this.g_agent_info.xname = this.rep_xname.Text;
            this.g_agent_info.xpassword = "";
            this.g_agent_info.nationality = this.txt_rep_nationality.Text;
            this.g_agent_info.country = this.txt_rep_country.Text;
            this.g_agent_info.state = this.selectRepState.SelectedValue;
            this.g_agent_info.address = this.txt_rep_address.Text;
            this.g_agent_info.telephone = this.txt_rep_telephone.Text;
            this.g_agent_info.email = this.txt_rep_email.Text;
            this.g_agent_info.log_staff = this.g_pwallet.xid;
            this.g_agent_info.xsync = "0";
            if (this.g_agent_info.xid != null)
            {
                this.agent_info_succ = this.reg.update_Gen_Agent_info(this.g_agent_info);
                this.Session["agent_info_succID"] = this.agent_info_succ;
            }
            else
            {
                this.agent_info_succ = this.reg.addGen_Agent_info(this.g_agent_info);
                this.Session["agent_info_succID"] = this.agent_info_succ;
            }
            this.g_ass_info.assignee_address = this.txt_assignee_address.Text;
            this.g_ass_info.assignee_name = this.txt_assignee_name.Text;
            this.g_ass_info.assignor_address = this.txt_assignor_address.Text;
            this.g_ass_info.assignee_nationality = this.select_assignee_nationality.SelectedValue;
            this.g_ass_info.assignor_name = this.txt_assignor_name.Text;
            this.g_ass_info.date_of_assignment = this.txt_assignment_date.Text;
            this.g_ass_info.assignor_nationality = this.select_assignor_nationality.SelectedValue;
            this.g_ass_info.log_staff = this.g_pwallet.xid;
            this.g_ass_info.xvisible = this.xvisible;
            if ((this.g_ass_info.ass_doc == null) || (this.g_ass_info.ass_doc == ""))
            {
                this.g_ass_info.ass_doc = "";
            }
            if (this.g_ass_info.xid != null)
            {
                this.x_succ = this.reg.update_G_Ass_info(this.g_ass_info);
                this.Session["assID"] = this.x_succ;
                this.Session["app_type"] = "ass";
            }
            else if (((this.app_type == "ass/merger") && (this.ass_show > 0)) && (this.select_merger_ass.SelectedValue == "Assignment"))
            {
                this.x_succ = this.reg.addG_Ass_info(this.g_ass_info);
                this.Session["assID"] = this.x_succ;
                this.Session["app_type"] = "ass";
            }
            this.g_merger_info.original_name = this.txt_original_name.Text;
            this.g_merger_info.original_address = this.txt_original_address.Text;
            this.g_merger_info.merging_name = this.txt_merging_name.Text;
            this.g_merger_info.merging_address = this.txt_merging_address.Text;
            this.g_merger_info.merged_coy_name = this.txt_merged_coy_name.Text;
            this.g_merger_info.merger_date = this.txt_merger_date.Text;
            this.g_merger_info.visible = this.xvisible;
            this.g_merger_info.log_staff = this.g_pwallet.xid;
            if ((this.g_merger_info.merger_doc == null) || (this.g_merger_info.merger_doc == ""))
            {
                this.g_merger_info.merger_doc = "";
            }
            if (this.g_merger_info.xid != null)
            {
                this.x_succ = this.reg.update_G_Merger_info(this.g_merger_info);
                this.Session["mergerID"] = this.x_succ;
                this.Session["app_type"] = "merger";
            }
            else if (((this.app_type == "ass/merger") && (this.merger_show > 0)) && (this.select_merger_ass.SelectedValue == "Merger"))
            {
                this.x_succ = this.reg.addG_Merger_info(this.g_merger_info);
                this.Session["mergerID"] = this.x_succ;
                this.Session["app_type"] = "merger";
            }
            this.g_cert_info.log_staff = this.g_pwallet.xid;
            this.g_cert_info.reg_date = this.xreg_date;
            this.g_cert_info.xvisible = this.xvisible;
            this.g_cert_info.pub_date = this.txt_cert_publicationdate.Text;
            this.g_cert_info.pub_details = this.txt_cert_details.Text;
            if ((this.g_cert_info.cert_doc == null) || (this.g_cert_info.cert_doc == ""))
            {
                this.g_cert_info.cert_doc = "";
            }
            if ((this.g_cert_info.pub_doc == null) || (this.g_cert_info.pub_doc == ""))
            {
                this.g_cert_info.pub_doc = "";
            }
            if (this.g_cert_info.xid != null)
            {
                this.x_succ = this.reg.update_G_Cert_info(this.g_cert_info);
                this.Session["certID"] = this.x_succ;
                this.Session["app_type"] = "cert";
            }
            else if (this.app_type == "cert")
            {
                this.x_succ = this.reg.addG_Cert_info(this.g_cert_info);
                this.Session["certID"] = this.x_succ;
                this.Session["app_type"] = "cert";
            }
            this.g_change_info.new_name = this.txt_new_applicant_trademark.Text;
            this.g_change_info.new_address = this.txt_new_applicant_address.Text;
            this.g_change_info.old_name = this.txt_old_applicant_trademark.Text;
            this.g_change_info.old_address = this.txt_old_applicant_address.Text;
            this.g_change_info.reg_date = this.xreg_date;
            this.g_change_info.visible = this.xvisible;
            this.g_change_info.log_staff = this.g_pwallet.xid;
            if (this.g_change_info.xid != null)
            {
                this.x_succ = this.reg.update_G_Change_info(this.g_change_info);
                this.Session["app_type"] = "change";
            }
            else if (this.app_type == "change")
            {
                this.x_succ = this.reg.addG_Change_info(this.g_change_info);
                this.Session["app_type"] = "change";
            }
            this.g_renewal_info.prev_renewal_date = this.txt_renewal_date.Text;
            this.g_renewal_info.renewal_type = this.select_renewal_type.SelectedValue;
            this.g_renewal_info.visible = this.xvisible;
            this.g_renewal_info.log_staff = this.g_pwallet.xid;
            this.g_renewal_info.reg_date = this.xreg_date;
            if (this.g_renewal_info.xid != null)
            {
                this.x_succ = this.reg.update_G_Renewal_info(this.g_renewal_info);
                this.Session["app_type"] = "renewal";
            }
            else if (this.app_type == "renewal")
            {
                this.x_succ = this.reg.addG_Renewal_info(this.g_renewal_info);
                this.Session["app_type"] = "renewal";
            }
            this.g_prelim_search_info.xtitle = this.txt_prelim_title.Text;
            this.g_prelim_search_info.xclass = this.select_prelim_class.SelectedValue;
            this.g_prelim_search_info.xclass_desc = this.txt_prelim_desc.Text;
            this.g_prelim_search_info.visible = this.xvisible;
            this.g_prelim_search_info.log_staff = this.g_pwallet.xid;
            this.g_prelim_search_info.reg_date = this.xreg_date;
            if (this.g_prelim_search_info.xid != null)
            {
                this.x_succ = this.reg.update_G_Prelim_search_info(this.g_prelim_search_info);
                this.Session["app_type"] = "prelim";
            }
            else if (this.app_type == "prelim")
            {
                this.x_succ = this.reg.addG_Prelim_search_info(this.g_prelim_search_info);
                this.Session["app_type"] = "prelim";
            }
            this.g_other_items_info.req_details = this.txt_details_of_request.Text;
            this.g_other_items_info.visible = this.xvisible;
            this.g_other_items_info.log_staff = this.g_pwallet.xid;
            this.g_other_items_info.reg_date = this.xreg_date;
            if (this.g_other_items_info.xid != null)
            {
                this.x_succ = this.reg.update_G_Other_items_info(this.g_other_items_info);
                this.Session["app_type"] = "others";
            }
            else if (this.app_type == "others")
            {
                this.x_succ = this.reg.addG_Other_items_info(this.g_other_items_info);
                this.Session["app_type"] = "others";
            }
            if (this.x_succ > 0)
            {
                base.Response.Redirect("./g_tm_refill_docs.aspx");
            }
        }

        public void ShowSection(string item_code)
        {
            if (item_code == "T001")
            {
                this.prelim_show = 1;
                this.Session["item_code"] = item_code;
                this.Session["app_type"] = "prelim";
            }
            else if (item_code == "T003")
            {
                this.cert_show = 1;
                this.Session["item_code"] = item_code;
                this.Session["app_type"] = "cert";
            }
            else if (item_code == "T008")
            {
                this.change_show = 1;
                this.Session["item_code"] = item_code;
                this.Session["app_type"] = "change";
            }
            else if (item_code == "T009")
            {
                this.renewal_show = 1;
                this.Session["item_code"] = item_code;
                this.Session["app_type"] = "renewal";
            }
            else if (item_code == "T014")
            {
                this.ass_show = 1;
                this.merger_show = 1;
                this.Session["item_code"] = item_code;
                this.Session["app_type"] = "ass/merger";
            }
            else if ((((item_code != "T001") && (item_code != "T002")) && ((item_code != "T003") && (item_code != "T008"))) && ((item_code != "T009") && (item_code != "T014")))
            {
                this.others_show = 1;
                this.Session["item_code"] = item_code;
                this.Session["app_type"] = "others";
            }
        }
    }
}

