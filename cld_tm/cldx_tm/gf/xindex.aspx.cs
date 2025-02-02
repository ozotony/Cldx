﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using cld.Classes;
using System.Configuration;
using System.Transactions;
using System.IO;
using cld.Ipo;

namespace cld.gf
{
    public partial class xind2 : System.Web.UI.Page
    {
        public string item_code = "";
        public string agent = "";
        public string agentname = "";
        public string agentemail = "";
        public string agentpnumber = "";
        public string aid = "";
        public string amt = "";
        public string applicantname = "";
        public string applicant_addy = "";
        public string applicantemail = "";
        public string applicantpnumber = "";
        public string log_staffID = "0";
        public string pc = "";
        public string product_title = "";
        public string pwalletID = "0";
        public string transID = "";
        public string vid = "";
        public string fee_detailsID = "";
        public string hwalletID = "";
        public string x = "";
        public string xapplication = "";
        public string xrep = "";
        public string xuserType = "";
        public int status = 0;
        public bool islogopic = false;
        public bool isagree = false;
        public GatewayService ipo_gateway = new GatewayService();
        protected Classes.tm t = new Classes.tm();

        //added code 

        protected int agent_info_succ = 0;
        public string agt = "";
        protected int app_succ = 0;
        public string applicant_email = "";
        public string applicant_no = "";
        protected int applicant_succ = 0;
        protected int ass_show = 0;
        protected int cert_show = 0;
        protected int change_show = 0;
        public List<XObjs.Fee_list> fee_list = new List<XObjs.Fee_list>();
        public XObjs.G_Pwallet c_pwall = new XObjs.G_Pwallet();
        public XObjs.Gen_Agent_info g_agent_info = new XObjs.Gen_Agent_info();
        public XObjs.G_App_info g_app_info = new XObjs.G_App_info();
        public XObjs.G_Applicant_info g_applicant_info = new XObjs.G_Applicant_info();
        public XObjs.G_Ass_info g_ass_info = new XObjs.G_Ass_info();
        public XObjs.G_Cert_info g_cert_info = new XObjs.G_Cert_info();
        public XObjs.G_Change_info g_change_info = new XObjs.G_Change_info();
        public XObjs.G_Merger_info g_merger_info = new XObjs.G_Merger_info();
        public XObjs.G_Other_items_info g_other_items_info = new XObjs.G_Other_items_info();
        public XObjs.G_Prelim_search_info g_prelim_search_info = new XObjs.G_Prelim_search_info();
        public XObjs.G_Renewal_info g_renewal_info = new XObjs.G_Renewal_info();
        public XObjs.G_Tm_info g_tm_info = new XObjs.G_Tm_info();
        public string gt = "";
        protected int merger_show = 0;
        protected int others_show = 0;
        protected int prelim_show = 0;
        public Registration reg = new Registration();
        protected int renewal_show = 0;
        public string request_type = "";
        public Retriever ret = new Retriever();
        private string serverpath = "";
        public XObjs.Trademark_item ti = new XObjs.Trademark_item();
        protected int tm_info_succ = 0;
        protected int x_succ = 0;
        public string xgt = "";
        protected string xlog_staff = "1";
        protected string xreg_date = DateTime.Now.ToString("yyyy-MM-dd");
        protected string xvisible = "1";
        public string show_image_section = "0";
        public string show_imageMsg = "";
        public string ack_status = "0";
        public string app_doc_newfilename = "";
        public string app_type = "";
        public string ass_doc_newfilename = "";
        public string cert_doc_newfilename = "";
        public string doc_path = "";
        public string logo_desc = "no";
        public string logo_pic_newfilename = "";
        public string merger_doc_newfilename = "";
        public string pub_doc_newfilename = "";
        public string sup_doc_newfilename = "";
    
        public XObjs.G_Pwallet g_pwallet = new XObjs.G_Pwallet();

        protected void btnDashBoard_Click(object sender, EventArgs e)
        {
            Response.Redirect(ConfigurationManager.AppSettings["ipo_profile_page"]);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
           if (Session["item_code"] != null) {
               this.item_code=Convert.ToString(Session["item_code"]);

               ShowSection( this.item_code);

           }
            
            

            if (!IsPostBack)
            {
                Session["fee_detailsID"] = null;
                Session["item_code"] = null;
                Session["hwalletID"] = null;
                Session["vid"] = null;
                Session["amt"] = null;
                Session["aid"] = null;
                Session["pc"] = null;
                Session["agentemail"] = null;
                Session["agentpnumber"] = null;
                Session["applicantname"] = null;
                Session["applicant_addy"] = null;
                Session["applicantemail"] = null;
                Session["applicant_no"] = null;
                Session["product_title"] = null;
                Session["xapplication"] = null;
                Session["pwalletID"] = null;
                Session["log_staffID"] = null;
                Session["xapplication"] = null;
                Session["new_miID"] = null;
                Session["pwalletID"] = null;
                Session["logo_desc"] = null;
                Session["app_succID"] = null;
                Session["applicant_succID"] = null;
                Session["agent_succID"] = null;
                Session["assID"] = null;
                Session["app_type"] = null;
                Session["mergerID"] = null;
                Session["certID"] = null;
                Session["vid"] = null;
                Session["amt"] = null;
                Session["agt"] = null;
                Session["xgt"] = null;
                Session["agentname"] = null;
                Session["agentemail"] = null;
                Session["agentpnumber"] = null;
                Session["applicantname"] = null;
                Session["applicantemail"] = null;
                Session["applicantpnumber"] = null;
                Session["product_title"] = null;
                Session["item_code"] = null;
                Session["cert_doc_newfilename"] = null;
                Session["ass_doc_newfilename"] = null;
                Session["merger_doc_newfilename"] = null;
                Session["logo_pic_newfilename"] = null;
                Session["app_doc_newfilename"] = null;
                Session["pub_doc_newfilename"] = null;
                Session["sup_doc_newfilename"] = null;
                Session["hwalletID"] = null;
                string serverpath = Server.MapPath("~/");
                if (Request.Form["item_code"] != null) { this.item_code = Request.Form["item_code"]; }
                if (Request.Form["fee_detailsID"] != null) { this.fee_detailsID = Request.Form["fee_detailsID"]; }
                if (Request.Form["transID"] != null) { this.transID = Request.Form["transID"]; }
                if (Request.Form["hwalletID"] != null) { this.hwalletID = Request.Form["hwalletID"]; }

               
                
                if (Request.Form["amt"] != null) { this.amt = Request.Form["amt"]; }
                if (Request.Form["agt"] != null) { this.agent = Request.Form["agt"]; }
                if (Request.Form["agent"] != null) { this.agent = Request.Form["agent"]; }
                if (Request.Form["xgt"] != null) { this.xgt = Request.Form["xgt"]; }
                if (Request.Form["agentemail"] != null) { this.agentemail = Request.Form["agentemail"]; }
                if (Request.Form["agentpnumber"] != null) { this.agentpnumber = Request.Form["agentpnumber"]; }
                if (Request.Form["applicantemail"] != null) { this.applicantemail = Request.Form["applicantemail"]; }
                if (Request.Form["applicantpnumber"] != null) { this.applicantpnumber = Request.Form["applicantpnumber"]; }
                if (Request.Form["applicant_addy"] != null)
                {
                    if (Request.Form["applicant_addy"].ToString().Contains("%26"))
                    { this.applicant_addy = Request.Form["applicant_addy"].Replace("%26", "&"); }
                    else { this.applicant_addy = Request.Form["applicant_addy"]; }
                }
                if (Request.Form["agentname"] != null)
                {
                    if (Request.Form["agentname"].ToString().Contains("%26"))
                    { this.agentname = Request.Form["agentname"].Replace("%26", "&"); }
                    else { this.agentname = Request.Form["agentname"]; }
                }

                if (Request.Form["applicantname"] != null)
                {
                    if (Request.Form["applicantname"].ToString().Contains("%26"))
                    { this.applicantname = Request.Form["applicantname"].Replace("%26", "&"); }
                    else { this.applicantname = Request.Form["applicantname"]; }
                }

                if (Request.Form["product_title"] != null)
                {
                    if (Request.Form["product_title"].ToString().Contains("%26"))
                    { this.product_title = Request.Form["product_title"].Replace("%26", "&"); }
                    else { this.product_title = Request.Form["product_title"]; }
                }

                //from here 

                if (
                  (this.item_code != "") &&
                  //   (this.fee_detailsID != "") &&
                  //   (this.hwalletID != "") &&
                  (this.transID != "") &&
                  (this.amt != "") &&
                  (this.agent != "") &&
                  (this.agentname != "") &&
                  (this.agentemail != "") &&
                  (this.agentpnumber != "") &&
                  (this.applicantname != "") &&
                  //   (this.applicant_addy != "") &&
                  (this.applicantemail != "") &&
                  (this.applicantpnumber != "") &&
                  (this.product_title != "")
                  )
                {
                    if (Session["xapplication"] != null)
                    {
                        this.xapplication = Session["xapplication"].ToString();
                        if (this.xapplication != this.transID)
                        {
                            if (Session["Trademark_item"] == null) { Response.Redirect("../a_violation.aspx"); }
                            else { Response.Redirect("../a_violation.aspx"); }
                        }
                    }
                    else
                    {
                        Session["xapplication"] = this.transID;
                    }
                    Session["item_code"] = this.item_code;


                    Session["fee_detailsID"] = this.fee_detailsID;
                    Session["hwalletID"] = this.hwalletID;
                    Session["vid"] = this.transID;
                    Session["amt"] = this.amt;
                    Session["aid"] = this.agent;
                    Session["agentemail"] = this.agentemail;
                    Session["agentname"] = this.agentname;
                    Session["agentpnumber"] = this.agentpnumber;
                    Session["applicantname"] = this.applicantname;
                    Session["applicant_addy"] = this.applicant_addy;
                    Session["applicantemail"] = this.applicantemail;
                    Session["applicantpnumber"] = this.applicantpnumber;
                    Session["product_title"] = this.product_title;

                    tm.Stage s = this.t.getStageBy_G_ValidationID(this.transID.Trim());
                    if ((s.ID != null) && (Convert.ToInt32(s.ID) > 0)) { Response.Redirect("./xxreturn.aspx"); }
                }
                else
                {
                    if (Session["hwalletID"].ToString() != "")
                    {
                        Response.Redirect(ConfigurationManager.AppSettings["ipo_profile_page"]);
                    }
                    else
                    {
                        Response.Redirect("http://www.iponigeria.com/userarea/approvedbranchcollect");

                    }
                }

            }
        }

        protected void newsProviderID_DataBound2(object sender, EventArgs e)
        {
            //simple test   
            select_applicant_nationality.SelectedValue = "Nigeria";
        }

       

        protected void cbAgree_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAgree.Checked == true) { 
                
                
                isagree = true;
                tt.Visible = false;
                tt2.Visible = true;

                show_imageMsg = "";
                fee_list = ret.getFee_listByCat("tm");
                serverpath = Server.MapPath("~/");
                if (logo_description.SelectedValue != "WORD MARK") { Session["logo_desc"] = "yes"; logo_desc = "yes"; } else { Session["logo_desc"] = "no"; logo_desc = "no"; }
                if (Session["aid"] != null) { agt = Session["aid"].ToString(); }
                if (Session["vid"] != null) { vid = Session["vid"].ToString(); }
                else { Response.Redirect(ConfigurationManager.AppSettings["ipo_profile_page"]); }
                if (Session["amt"] != null) { amt = Session["amt"].ToString(); }
                if (Session["xgt"] != null) { xgt = Session["xgt"].ToString(); }
                if (Session["pwalletID"] != null) { pwalletID = Session["pwalletID"].ToString(); }
                if (Session["hwalletID"] != null) { hwalletID = Session["hwalletID"].ToString(); }
                if (Session["agentemail"] != null) { agentemail = Session["agentemail"].ToString(); }
                if (Session["agentname"] != null) { agentname = Session["agentname"].ToString(); }
                if (Session["agentpnumber"] != null) { agentpnumber = Session["agentpnumber"].ToString(); }
                if (Session["applicantname"] != null) { applicantname = Session["applicantname"].ToString(); }
                if (Session["applicant_addy"] != null) { applicant_addy = Session["applicant_addy"].ToString(); }
                if (Session["applicantemail"] != null) { applicant_email = Session["applicantemail"].ToString(); }
                if (Session["applicantpnumber"] != null) { applicant_no = Session["applicantpnumber"].ToString(); }
                if (Session["product_title"] != null) { product_title = Session["product_title"].ToString(); }
                if (Session["item_code"] != null) { item_code = Session["item_code"].ToString(); ShowSection(Session["item_code"].ToString()); }
                if ((((((vid != null) && (vid != "")) && ((amt != null) && (amt != ""))) && (((agt != null) && (agt != "")) && ((agentname != null) && (agentname != "")))) && ((((agentemail != null) && (agentemail != "")) && ((agentpnumber != null) && (agentpnumber != ""))) && (((applicantname != null) && (applicantname != "")) && ((applicantname != null) && (applicantname != ""))))) && ((((applicant_email != null) && (applicant_email != "")) && ((applicant_no != null) && (applicant_no != ""))) && (((product_title != null) && (product_title != "")) && ((item_code != null) && (item_code != "")))))
                {
                    PopulateRenewalType();
                    Session["pwalletID"] = pwalletID;
                    rep_code.Text = agt;
                    rep_xname.Text = agentname;
                    txt_rep_telephone.Text = agentpnumber;
                    txt_rep_email.Text = agentemail;
                    txt_title_of_trademark.Text = product_title;
                    txt_applicant_name.Text = applicantname;
                    txt_applicant_address.Text = applicant_addy;
                    txt_applicant_email.Text = applicant_email;
                    txt_applicant_mobile.Text = applicant_no;
                    foreach (XObjs.Fee_list _list in fee_list)
                    {
                        if (_list.item_code == item_code)
                        {
                            lbl_type.Text = _list.item.ToUpper();
                        }
                    }
                    ShowSection(item_code);
                }
                else
                {
                    base.Response.Redirect(ConfigurationManager.AppSettings["ipo_profile_page"]);
                }
            
            } 
            
            else { isagree = false; }
        }

        protected void Gender_SelectedIndexChanged(object sender, EventArgs e)
        {
            item_code = Session["item_code"].ToString();
            ShowSection(item_code);
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
                ass_show = 1;
                merger_show = 1;
                Session["item_code"] = item_code;
            }
            else if ((((item_code != "T001") && (item_code != "T002")) && ((item_code != "T003") && (item_code != "T008"))) && ((item_code != "T009") && (item_code != "T014")))
            {
                others_show = 1;
                Session["item_code"] = item_code;
            }
        }
        public void PopulateRenewalType()
        {
            for (int i = 1; i <= 20; i++)
            {
                string text = i.ToString();
                ListItem item = new ListItem(text, i.ToString());
                select_renewal_type.Items.Add(item);
            }
        }

     

        protected void SaveAll_Click(object sender, EventArgs e)
        {
            item_code = Session["item_code"].ToString();
            ShowSection(item_code);
             serverpath = Server.MapPath("~/");
            if (logo_desc == "yes")
            {
                //if ((fu_logo_pic.HasFile) && (fu_app_doc.HasFile))
                //{
                    TransactionOptions transactionOptions = new TransactionOptions
                    {
                        IsolationLevel = IsolationLevel.ReadCommitted,
                        Timeout = new TimeSpan(0, 15, 0)
                    };
                    TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, transactionOptions);
                    //try
                    //{
                        c_pwall.twalletID = "0";
                        c_pwall.validationID = Session["vid"].ToString(); // vid;
                        c_pwall.applicantID = Session["aid"].ToString();  //agt;
                        c_pwall.log_officer = Session["item_code"].ToString();// item_code;
                        c_pwall.amt = Session["amt"].ToString();// amt;

                        g_app_info.filing_date = txt_application_date.Text;
                        g_app_info.application_no = txt_application_no.Text;
                        g_app_info.rtm_number = txt_rtm_no.Text;
                        g_app_info.item_code = Session["item_code"].ToString();// item_code;
                        g_app_info.log_staff = "0";
                        g_app_info.reg_no = "";
                        g_app_info.reg_date = xreg_date;
                        g_app_info.visible = xvisible;

                        g_applicant_info.trading_as = txt_trading_as.Text;
                        g_applicant_info.visible = xvisible;
                        g_applicant_info.address = txt_applicant_address.Text;
                        g_applicant_info.xemail = txt_applicant_email.Text;
                        g_applicant_info.xmobile = txt_applicant_mobile.Text;
                        g_applicant_info.xname = txt_applicant_name.Text;
                        g_applicant_info.nationality = select_applicant_nationality.SelectedValue;
                        g_applicant_info.log_staff = "0";

                        g_tm_info.disclaimer = txt_discalimer.Text;
                        g_tm_info.tm_class = select_class_of_trademark.SelectedValue;
                        g_tm_info.tm_desc = txt_goods_desc.Text;
                        g_tm_info.tm_title = txt_title_of_trademark.Text;
                        g_tm_info.xtype = tmType.SelectedValue;
                        g_tm_info.reg_number = "";
                        g_tm_info.logo_descID = logo_description.SelectedValue;
                        if (g_tm_info.logo_descID != "WORD MARK") { Session["logo_desc"] = "yes"; } else { Session["logo_desc"] = "no"; }
                        g_tm_info.logo_pic = "";
                        g_tm_info.auth_doc = "";
                        g_tm_info.sup_doc1 = "";
                        g_tm_info.app_letter_doc = "";
                        g_tm_info.log_staff = "0";
                        g_tm_info.reg_date = xreg_date;
                        g_tm_info.visible = xvisible;

                        g_agent_info.code = Session["aid"].ToString();  //agt;
                        g_agent_info.xname = rep_xname.Text;
                        g_agent_info.xpassword = "";
                        g_agent_info.nationality = txt_rep_nationality.Text;
                        g_agent_info.country = txt_rep_country.Text;
                        g_agent_info.state = selectRepState.SelectedValue;
                        g_agent_info.address = txt_rep_address.Text;
                        g_agent_info.telephone = txt_rep_telephone.Text;
                        g_agent_info.email = txt_rep_email.Text;
                        g_agent_info.log_staff = "0";
                        g_agent_info.xsync = "0";

                        if ((ass_show > 0) && (select_merger_ass.SelectedValue == "Assignment"))
                        {
                            g_ass_info.assignee_address = txt_assignee_address.Text;
                            g_ass_info.assignee_name = txt_assignee_name.Text;
                            g_ass_info.assignor_address = txt_assignor_address.Text;
                            g_ass_info.assignee_nationality = select_assignee_nationality.SelectedValue;
                            g_ass_info.assignor_name = txt_assignor_name.Text;
                            g_ass_info.date_of_assignment = txt_assignment_date.Text;
                            g_ass_info.assignor_nationality = select_assignor_nationality.SelectedValue;
                            g_ass_info.log_staff = "0";
                            g_ass_info.xvisible = xvisible;
                            g_ass_info.ass_doc = "";
                        }
                        else if ((merger_show > 0) && (select_merger_ass.SelectedValue == "Merger"))
                        {
                            g_merger_info.original_name = txt_original_name.Text;
                            g_merger_info.original_address = txt_original_address.Text;
                            g_merger_info.merging_name = txt_merging_name.Text;
                            g_merger_info.merging_address = txt_merging_address.Text;
                            g_merger_info.merged_coy_name = txt_merged_coy_name.Text;
                            g_merger_info.merger_date = txt_merger_date.Text;
                            g_merger_info.visible = xvisible;
                            g_merger_info.log_staff = "0";
                            g_merger_info.merger_doc = "";
                        }
                        else if (cert_show > 0)
                        {
                            g_cert_info.log_staff = "0";
                            g_cert_info.reg_date = xreg_date;
                            g_cert_info.xvisible = xvisible;
                            g_cert_info.pub_date = txt_cert_publicationdate.Text;
                            g_cert_info.pub_details = txt_cert_details.Text;
                            g_cert_info.cert_doc = "";
                            g_cert_info.pub_doc = "";
                        }
                        else if (change_show > 0)
                        {
                            g_change_info.new_name = txt_new_applicant_trademark.Text;
                            g_change_info.new_address = txt_new_applicant_address.Text;
                            g_change_info.old_name = txt_old_applicant_trademark.Text;
                            g_change_info.old_address = txt_old_applicant_address.Text;
                            g_change_info.reg_date = xreg_date;
                            g_change_info.visible = xvisible;
                            g_change_info.log_staff = "0";
                        }
                        else if (renewal_show > 0)
                        {
                            g_renewal_info.prev_renewal_date = txt_renewal_date.Text;
                            g_renewal_info.renewal_type = select_renewal_type.SelectedValue;
                            g_renewal_info.visible = xvisible;
                            g_renewal_info.log_staff = "0";
                            g_renewal_info.reg_date = xreg_date;
                        }
                        else if (prelim_show > 0)
                        {
                            g_prelim_search_info.xtitle = txt_prelim_title.Text;
                            g_prelim_search_info.xclass = select_prelim_class.SelectedValue;
                            g_prelim_search_info.xclass_desc = txt_prelim_desc.Text;
                            g_prelim_search_info.visible = xvisible;
                            g_prelim_search_info.log_staff = "0";
                            g_prelim_search_info.reg_date = xreg_date;
                        }
                        else if (others_show > 0)
                        {
                            g_other_items_info.req_details = txt_details_of_request.Text;
                            g_other_items_info.visible = xvisible;
                            g_other_items_info.log_staff = "0";
                            g_other_items_info.reg_date = xreg_date;
                        }
                        if (Session["hwalletID"] != null) { hwalletID = Session["hwalletID"].ToString(); }
                        x_succ = reg.addGenericTx(serverpath, c_pwall, g_app_info, g_applicant_info, g_tm_info, g_agent_info, g_ass_info, g_merger_info, g_cert_info, g_change_info, g_renewal_info,
                            g_prelim_search_info, g_other_items_info, fu_logo_pic, fu_sup_doc, fu_app_doc, fu_merger_doc, fu_ass_doc, fu_pub_doc, fu_cert_doc);

                        // if (x_succ > 0) {scope.Complete();}
                        if (x_succ > 0)
                        {
                            if (Session["hwalletID"].ToString() != "")
                            {
                              //  ws_payx.payx ws_p = new ws_payx.payx();
                              //  status = ws_p.UpdateHwallet(hwalletID, "Used", xreg_date, txt_title_of_trademark.Text);
                            }

                            else
                            {

                              //  this.status = this.t.updateIpoApplicationReferenceStatus(this.Session["vid"].ToString(), this.Session["aid"].ToString(), "1");
                                this.status = 1;
                              //  this.status = this.t.updateIpoApplicationReferenceStatus("000", "1111", "1");
                            }
                    // status = 1;
                    if (x_succ > 0)
                    {
                                scope.Complete(); scope.Dispose();
                        if (Session["hwalletID"].ToString() != "")
                        {
                            //  ws_payx.payx ws_p = new ws_payx.payx();
                            zues dd10 = new zues();
                            status = dd10.updateHwallet(hwalletID, "Used", xreg_date, txt_title_of_trademark.Text);
                            //  status = ws_p.UpdateHwallet(hwalletID, "Used", reg_date, title_of_product.Text);
                        }
                    }
                            else
                            {
                                scope.Dispose();
                                if (Session["hwalletID"].ToString() != "")
                                {
                                    Response.Redirect(ConfigurationManager.AppSettings["ipo_profile_page"]);
                                }
                                else
                                {
                                    Response.Redirect("http://www.iponigeria.com/userarea/approvedbranchcollect");

                                }
                              //  Response.Redirect(ConfigurationManager.AppSettings["ipo_profile_page"]);
                            }
                        }
                        else
                        {
                            scope.Dispose();
                            if (Session["hwalletID"].ToString() != "")
                            {
                                Response.Redirect(ConfigurationManager.AppSettings["ipo_profile_page"]);
                            }
                            else
                            {
                                Response.Redirect("http://www.iponigeria.com/userarea/approvedbranchcollect");

                            }
                          //  Response.Redirect(ConfigurationManager.AppSettings["ipo_profile_page"]);
                        }
                    //}
                    //catch (Exception exception)
                    //{
                    //    exception.ToString(); scope.Dispose(); //
                    //    if (Session["hwalletID"].ToString() != "")
                    //    {
                    //        Response.Redirect(ConfigurationManager.AppSettings["ipo_profile_page"]);
                    //    }
                    //    else
                    //    {
                    //        Response.Redirect("http://www.iponigeria.com/userarea/approvedbranchcollect");

                    //    }
                    
                    //}
                    //finally
                    //{
                    //    if (scope != null) { scope.Dispose(); }
                    //}

                    if (x_succ > 0) {
                        tt2.Visible = false;
                        tt3.Visible = true;
                        tm_img2.ImageUrl = "";
                        fee_list = ret.getFee_listByCat("tm");
                        if ((Session["vid"] != null) && (Session["vid"].ToString() != ""))
                        {
                            vid = Session["vid"].ToString();
                            g_pwallet = ret.getG_PwalletByValidationID2(vid);
                            if ((g_pwallet.xid != null) && (g_pwallet.xid != ""))
                            {

                                g_tm_info = ret.getG_Tm_infoByPwalletID(g_pwallet.xid);
                                g_app_info = ret.getG_App_infoByPwalletID(g_pwallet.xid);
                                g_applicant_info = ret.getG_Applicant_infoByPwalletID(g_pwallet.xid);
                                g_agent_info = ret.getGenAgentByPwalletID(g_pwallet.xid);
                                g_ass_info = ret.getG_Ass_infoByPwalletID(g_pwallet.xid);
                                g_cert_info = ret.getG_Cert_infoByPwalletID(g_pwallet.xid);
                                g_change_info = ret.getG_Change_infoByPwalletID(g_pwallet.xid);
                                g_merger_info = ret.getG_Merger_infoByPwalletID(g_pwallet.xid);
                                g_renewal_info = ret.getG_Renewal_infoByPwalletID(g_pwallet.xid);
                                g_prelim_search_info = ret.getG_Prelim_search_infoByPwalletID(g_pwallet.xid);
                                g_other_items_info = ret.getG_Other_items_infoByPwalletID(g_pwallet.xid);
                                if (g_tm_info.logo_pic != "")
                                {
                                   // tm_img.ImageUrl = "../admin/tm/gf/" + g_tm_info.logo_pic;

                                  //  tm_img2.ImageUrl = "~/admin/tm/gf/" + g_tm_info.logo_pic;

                                    string ssssp = Request.Url.GetLeftPart(UriPartial.Authority) + Request.ApplicationPath;

                                    tm_img2.ImageUrl = ssssp + "/admin/tm/gf/" + g_tm_info.logo_pic;

                                 //   tm_img2.ImageUrl = serverpath + "admin\\tm\\gf\\" + g_tm_info.logo_pic;
                                    if (File.Exists(serverpath + @"\admin\tm\gf\" + g_tm_info.logo_pic))
                                    {
                                        tm_img2.Height = new Unit(120.0, UnitType.Pixel);
                                        tm_img2.Width = new Unit(120.0, UnitType.Pixel);
                                        try
                                        {
                                            FileStream stream = new FileStream(serverpath + @"\admin\tm\gf\" + g_tm_info.logo_pic, FileMode.Open, FileAccess.Read);
                                            System.Drawing.Image image = System.Drawing.Image.FromStream(stream);
                                            string str = image.Height.ToString();
                                            string str2 = image.Width.ToString();
                                            if (((str != "") && (str2 != "")) && ((str != null) && (str2 != null)))
                                            {
                                                if (Convert.ToInt32(str) > Convert.ToInt32(str2))
                                                {
                                                    tm_img2.Height = new Unit(320.0, UnitType.Pixel);
                                                    tm_img2.Width = new Unit(240.0, UnitType.Pixel);
                                                }
                                                else
                                                {
                                                    tm_img2.Height = new Unit(240.0, UnitType.Pixel);
                                                    tm_img2.Width = new Unit(320.0, UnitType.Pixel);
                                                }
                                            }
                                            else
                                            {
                                                tm_img2.Visible = false;
                                            }
                                        }
                                        catch (Exception)
                                        {
                                            tm_img2.Visible = false;
                                        }
                                    }
                                    else
                                    {
                                        tm_img2.Visible = false;
                                    }
                                }
                                foreach (XObjs.Fee_list _list in fee_list)
                                {
                                    if (_list.item_code == g_pwallet.log_officer)
                                    {
                                        lbl_type.Text = _list.item.ToUpper();
                                    }
                                }
                                ShowSection(g_pwallet.log_officer);

                            }
                        }
                     Label1.Text =lbl_type.Text;

                     g_other_items_info.req_details = txt_details_of_request.Text;
                     g_prelim_search_info.xtitle = txt_prelim_title.Text;
                     g_prelim_search_info.xclass = select_prelim_class.SelectedItem.Text;
                     g_prelim_search_info.xclass_desc = txt_prelim_desc.Text;
                     g_cert_info.pub_date = txt_cert_publicationdate.Text;

                     g_cert_info.pub_details = txt_cert_details.Text;
                        //  base.Response.Redirect("./g_nack.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD");
                    }

                //}
                //else
                //{
                //    show_imageMsg = "PLEASE UPLOAD A VALID IMAGE AND POWER OF ATTORNEY DOCUMENT!!";
                //}


            }
            else
            {
                //if (fu_app_doc.HasFile)
                //{
                    TransactionOptions transactionOptions = new TransactionOptions
                    {
                        IsolationLevel = IsolationLevel.ReadCommitted,
                        Timeout = new TimeSpan(0, 15, 0)
                    };
                    TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, transactionOptions);
                  //  try
                  // {
                        c_pwall.twalletID = "0";
                        c_pwall.validationID = Session["vid"].ToString();// vid;
                        c_pwall.applicantID = Session["aid"].ToString(); //agt;
                        c_pwall.log_officer = Session["item_code"].ToString();// item_code;
                        c_pwall.amt = Session["amt"].ToString();// amt;

                        g_app_info.filing_date = txt_application_date.Text;
                        g_app_info.application_no = txt_application_no.Text;
                        g_app_info.rtm_number = txt_rtm_no.Text;
                        g_app_info.item_code = Session["item_code"].ToString(); // item_code;
                        g_app_info.log_staff = "0";
                        g_app_info.reg_no = "";
                        g_app_info.reg_date = xreg_date;
                        g_app_info.visible = xvisible;

                        g_applicant_info.trading_as = txt_trading_as.Text;
                        g_applicant_info.visible = xvisible;
                        g_applicant_info.address = txt_applicant_address.Text;
                        g_applicant_info.xemail = txt_applicant_email.Text;
                        g_applicant_info.xmobile = txt_applicant_mobile.Text;
                        g_applicant_info.xname = txt_applicant_name.Text;
                        g_applicant_info.nationality = select_applicant_nationality.SelectedValue;
                        g_applicant_info.log_staff = "0";

                        g_tm_info.disclaimer = txt_discalimer.Text;
                        g_tm_info.tm_class = select_class_of_trademark.SelectedValue;
                        g_tm_info.tm_desc = txt_goods_desc.Text;
                        g_tm_info.tm_title = txt_title_of_trademark.Text;
                        g_tm_info.xtype = tmType.SelectedValue;
                        g_tm_info.reg_number = "";
                        g_tm_info.logo_descID = logo_description.SelectedValue;
                        if (g_tm_info.logo_descID != "WORD MARK") { Session["logo_desc"] = "yes"; } else { Session["logo_desc"] = "no"; }
                        g_tm_info.logo_pic = "";
                        g_tm_info.auth_doc = "";
                        g_tm_info.sup_doc1 = "";
                        g_tm_info.app_letter_doc = "";
                        g_tm_info.log_staff = "0";
                        g_tm_info.reg_date = xreg_date;
                        g_tm_info.visible = xvisible;

                        g_agent_info.code = Session["aid"].ToString(); //agt;
                        g_agent_info.xname = rep_xname.Text;
                        g_agent_info.xpassword = "";
                        g_agent_info.nationality = txt_rep_nationality.Text;
                        g_agent_info.country = txt_rep_country.Text;
                        g_agent_info.state = selectRepState.SelectedValue;
                        g_agent_info.address = txt_rep_address.Text;
                        g_agent_info.telephone = txt_rep_telephone.Text;
                        g_agent_info.email = txt_rep_email.Text;
                        g_agent_info.log_staff = "0";
                        g_agent_info.xsync = "0";

                        if ((ass_show > 0) && (select_merger_ass.SelectedValue == "Assignment"))
                        {
                            g_ass_info.assignee_address = txt_assignee_address.Text;
                            g_ass_info.assignee_name = txt_assignee_name.Text;
                            g_ass_info.assignor_address = txt_assignor_address.Text;
                            g_ass_info.assignee_nationality = select_assignee_nationality.SelectedValue;
                            g_ass_info.assignor_name = txt_assignor_name.Text;
                            g_ass_info.date_of_assignment = txt_assignment_date.Text;
                            g_ass_info.assignor_nationality = select_assignor_nationality.SelectedValue;
                            g_ass_info.log_staff = "0";
                            g_ass_info.xvisible = xvisible;
                            g_ass_info.ass_doc = "";
                        }
                        else if ((merger_show > 0) && (select_merger_ass.SelectedValue == "Merger"))
                        {
                            g_merger_info.original_name = txt_original_name.Text;
                            g_merger_info.original_address = txt_original_address.Text;
                            g_merger_info.merging_name = txt_merging_name.Text;
                            g_merger_info.merging_address = txt_merging_address.Text;
                            g_merger_info.merged_coy_name = txt_merged_coy_name.Text;
                            g_merger_info.merger_date = txt_merger_date.Text;
                            g_merger_info.visible = xvisible;
                            g_merger_info.log_staff = "0";
                            g_merger_info.merger_doc = "";
                        }
                        else if (cert_show > 0)
                        {
                            g_cert_info.log_staff = "0";
                            g_cert_info.reg_date = xreg_date;
                            g_cert_info.xvisible = xvisible;
                            g_cert_info.pub_date = txt_cert_publicationdate.Text;
                            g_cert_info.pub_details = txt_cert_details.Text;
                            g_cert_info.cert_doc = "";
                            g_cert_info.pub_doc = "";
                        }
                        else if (change_show > 0)
                        {
                            g_change_info.new_name = txt_new_applicant_trademark.Text;
                            g_change_info.new_address = txt_new_applicant_address.Text;
                            g_change_info.old_name = txt_old_applicant_trademark.Text;
                            g_change_info.old_address = txt_old_applicant_address.Text;
                            g_change_info.reg_date = xreg_date;
                            g_change_info.visible = xvisible;
                            g_change_info.log_staff = "0";
                        }
                        else if (renewal_show > 0)
                        {
                            g_renewal_info.prev_renewal_date = txt_renewal_date.Text;
                            g_renewal_info.renewal_type = select_renewal_type.SelectedValue;
                            g_renewal_info.visible = xvisible;
                            g_renewal_info.log_staff = "0";
                            g_renewal_info.reg_date = xreg_date;
                        }
                        else if (prelim_show > 0)
                        {
                            g_prelim_search_info.xtitle = txt_prelim_title.Text;
                            g_prelim_search_info.xclass = select_prelim_class.SelectedValue;
                            g_prelim_search_info.xclass_desc = txt_prelim_desc.Text;
                            g_prelim_search_info.visible = xvisible;
                            g_prelim_search_info.log_staff = "0";
                            g_prelim_search_info.reg_date = xreg_date;
                        }
                        else if (others_show > 0)
                        {
                            g_other_items_info.req_details = txt_details_of_request.Text;
                          //  g_other_items_info.visible = xvisible;
                            g_other_items_info.log_staff = "0";
                            g_other_items_info.reg_date = xreg_date;
                        }
                        if (Session["hwalletID"] != null) { hwalletID = Session["hwalletID"].ToString(); }
                        x_succ = reg.addGenericTx(serverpath, c_pwall, g_app_info, g_applicant_info, g_tm_info, g_agent_info, g_ass_info, g_merger_info, g_cert_info, g_change_info, g_renewal_info,
                            g_prelim_search_info, g_other_items_info, fu_logo_pic, fu_sup_doc, fu_app_doc, fu_merger_doc, fu_ass_doc, fu_pub_doc, fu_cert_doc);
                        if (x_succ > 0)
                        {
                            if (Session["hwalletID"].ToString() != "")
                            {
                                ws_payx.payx ws_p = new ws_payx.payx();
                                status = ws_p.UpdateHwallet(hwalletID, "Used", xreg_date, txt_title_of_trademark.Text);
                            }
                            else
                            {
                                t = new Classes.tm();
                             


                             //  this.status = this.t.updateIpoApplicationReferenceStatus(this.Session["vid"].ToString(), this.Session["aid"].ToString(), "1");
                               this.status = 1;
                              //  this.status = this.t.updateIpoApplicationReferenceStatus("000", "1111", "1");

                            }
                    //  status = 1;
                    if (x_succ > 0)
                    {
                                scope.Complete(); scope.Dispose();

                        if (Session["hwalletID"].ToString() != "")
                        {
                            //  ws_payx.payx ws_p = new ws_payx.payx();
                            zues dd10 = new zues();
                            status = dd10.updateHwallet(hwalletID, "Used", xreg_date, txt_title_of_trademark.Text);
                            //  status = ws_p.UpdateHwallet(hwalletID, "Used", reg_date, title_of_product.Text);
                        }
                    }
                            else
                            {
                                scope.Dispose();
                                if (Session["hwalletID"].ToString() != "")
                                {
                                    Response.Redirect(ConfigurationManager.AppSettings["ipo_profile_page"]);
                                }
                                else
                                {
                                    Response.Redirect("http://www.iponigeria.com/userarea/approvedbranchcollect");

                                }
                               // Response.Redirect(ConfigurationManager.AppSettings["ipo_profile_page"]);
                            }
                        }
                        else
                        {
                            scope.Dispose();
                            if (Session["hwalletID"].ToString() != "")
                            {
                                Response.Redirect(ConfigurationManager.AppSettings["ipo_profile_page"]);
                            }
                            else
                            {
                                Response.Redirect("http://www.iponigeria.com/userarea/approvedbranchcollect");

                            }
                         //   Response.Redirect(ConfigurationManager.AppSettings["ipo_profile_page"]);
                        }
                   //}
                   // catch (Exception exception)
                   // {
                   //     exception.ToString(); scope.Dispose(); //
                   //     if (Session["hwalletID"].ToString() != "")
                   //     {
                   //         Response.Redirect(ConfigurationManager.AppSettings["ipo_profile_page"]);
                   //     }
                   //     else
                   //     {
                   //         Response.Redirect("http://www.iponigeria.com/userarea/approvedbranchcollect");

                   //     }

                   // }
                   // finally
                   // {
                   //     if (scope != null) { scope.Dispose(); }
                   // }

                    if (x_succ > 0) {
                        tt2.Visible = false;
                        tt3.Visible = true;
                        fee_list = ret.getFee_listByCat("tm");

                        tm_img2.ImageUrl = "";
                        if ((Session["vid"] != null) && (Session["vid"].ToString() != ""))
                        {
                            vid = Session["vid"].ToString();
                            g_pwallet = ret.getG_PwalletByValidationID2(vid);
                            if ((g_pwallet.xid != null) && (g_pwallet.xid != ""))
                            {

                                g_tm_info = ret.getG_Tm_infoByPwalletID(g_pwallet.xid);
                                g_app_info = ret.getG_App_infoByPwalletID(g_pwallet.xid);
                                g_applicant_info = ret.getG_Applicant_infoByPwalletID(g_pwallet.xid);
                                g_agent_info = ret.getGenAgentByPwalletID(g_pwallet.xid);
                                g_ass_info = ret.getG_Ass_infoByPwalletID(g_pwallet.xid);
                                g_cert_info = ret.getG_Cert_infoByPwalletID(g_pwallet.xid);
                                g_change_info = ret.getG_Change_infoByPwalletID(g_pwallet.xid);
                                g_merger_info = ret.getG_Merger_infoByPwalletID(g_pwallet.xid);
                                g_renewal_info = ret.getG_Renewal_infoByPwalletID(g_pwallet.xid);
                                g_prelim_search_info = ret.getG_Prelim_search_infoByPwalletID(g_pwallet.xid);
                                g_other_items_info = ret.getG_Other_items_infoByPwalletID(g_pwallet.xid);
                                if (g_tm_info.logo_pic != "")
                                {
                                   // tm_img.ImageUrl = "../admin/tm/gf/" + g_tm_info.logo_pic;
                                    string sss5 = "";
                                 //   tm_img2.ImageUrl = "~/admin/tm/gf/" + g_tm_info.logo_pic;

                                    string ssssp = Request.Url.GetLeftPart(UriPartial.Authority) + Request.ApplicationPath;

                                    tm_img2.ImageUrl = ssssp + "/admin/tm/gf/" + g_tm_info.logo_pic;

                                  //  tm_img2.ImageUrl = serverpath + @"\admin\tm\gf\" + g_tm_info.logo_pic;

                                    


                                    if (File.Exists(serverpath + @"\admin\tm\gf\" + g_tm_info.logo_pic))
                                    {
                                        tm_img2.Height = new Unit(120.0, UnitType.Pixel);
                                        tm_img2.Width = new Unit(120.0, UnitType.Pixel);
                                        try
                                        {
                                            FileStream stream = new FileStream(serverpath + @"\admin\tm\gf\" + g_tm_info.logo_pic, FileMode.Open, FileAccess.Read);
                                            System.Drawing.Image image = System.Drawing.Image.FromStream(stream);
                                            string str = image.Height.ToString();
                                            string str2 = image.Width.ToString();
                                            if (((str != "") && (str2 != "")) && ((str != null) && (str2 != null)))
                                            {
                                                if (Convert.ToInt32(str) > Convert.ToInt32(str2))
                                                {
                                                    tm_img2.Height = new Unit(320.0, UnitType.Pixel);
                                                    tm_img2.Width = new Unit(240.0, UnitType.Pixel);
                                                }
                                                else
                                                {
                                                    tm_img2.Height = new Unit(240.0, UnitType.Pixel);
                                                    tm_img2.Width = new Unit(320.0, UnitType.Pixel);
                                                }
                                            }
                                            else
                                            {
                                                tm_img2.Visible = false;
                                            }
                                        }
                                        catch (Exception)
                                        {
                                            tm_img2.Visible = false;
                                        }
                                    }
                                    else
                                    {
                                        tm_img2.Visible = false;
                                    }
                                }
                                foreach (XObjs.Fee_list _list in fee_list)
                                {
                                    if (_list.item_code == g_pwallet.log_officer)
                                    {
                                        lbl_type.Text = _list.item.ToUpper();
                                    }
                                }
                                ShowSection(g_pwallet.log_officer);

                            }
                        }
                      
                        Label1.Text =lbl_type.Text;
                       
                        g_other_items_info.req_details = txt_details_of_request.Text;
                        g_prelim_search_info.xtitle = txt_prelim_title.Text;
                        g_prelim_search_info.xclass = select_prelim_class.SelectedItem.Text;
                        g_prelim_search_info.xclass_desc = txt_prelim_desc.Text;
                        g_cert_info.pub_date = txt_cert_publicationdate.Text;

                        g_cert_info.pub_details = txt_cert_details.Text;
                        //base.Response.Redirect("./g_nack.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD"); 
                    
                    }
                //}

                //else
                //{
                //    // enable_RepSave = "1";
                //    show_imageMsg = "PLEASE UPLOAD A VALID POWER OF ATTORNEY DOCUMENT!!";
                //}
            }

        }
    }
}