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
    using Brettle.Web.NeatUpload;
    using System.IO;
    using System.Transactions;

    public partial class g_application : Page
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
        protected int cert_show;
        protected int change_show;
        public string agentname;
        public string fee_detailsID = "";
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
        public int status = 0;
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
        public tm t = new tm();

        protected void Page_Load(object sender, EventArgs e)
        {
            show_imageMsg = "";
            fee_list = ret.getFee_listByCat("tm");
            serverpath =Server.MapPath("~/");
            if (logo_description.SelectedValue != "WORD MARK") { Session["logo_desc"] = "yes"; logo_desc = "yes"; } else { Session["logo_desc"] = "no"; logo_desc = "no"; }
            if (Session["agt"] != null) { agt = Session["agt"].ToString(); }
            if (Session["vid"] != null) { vid = Session["vid"].ToString(); }
            else { Response.Redirect("http://www.iponigeria.com/userarea/dashboard"); }
            if (Session["amt"] != null) { amt = Session["amt"].ToString(); }
            if (Session["xgt"] != null) { xgt = Session["xgt"].ToString(); }
            if (Session["pwalletID"] != null) { pwalletID = Session["pwalletID"].ToString(); }
            if (Session["agentemail"] != null) { agentemail = Session["agentemail"].ToString(); }
            if (Session["agentname"] != null) { agentname = Session["agentname"].ToString(); }
            if (Session["agentpnumber"] != null) { agentpnumber = Session["agentpnumber"].ToString(); }
            if (Session["applicantname"] != null) { applicantname = Session["applicantname"].ToString(); }
            if (Session["applicant_addy"] != null) { applicant_addy = Session["applicant_addy"].ToString(); }
            if (Session["applicantemail"] != null) { applicant_email = Session["applicantemail"].ToString(); }
            if (Session["applicantpnumber"] != null) { applicant_no = Session["applicantpnumber"].ToString(); }
            if (Session["product_title"] != null) { product_title = Session["product_title"].ToString(); }
            if (Session["item_code"] != null) { item_code = Session["item_code"].ToString(); ShowSection(Session["item_code"].ToString()); }

            if (!Page.IsPostBack)
            {
                if ((((((vid != null) && (vid != "")) && ((amt != null) && (amt != ""))) && (((agt != null) && (agt != "")) && ((agentname != null) && (agentname != "")))) && ((((agentemail != null) && (agentemail != "")) && ((agentpnumber != null) && (agentpnumber != ""))) && (((applicantname != null) && (applicantname != "")) && ((applicant_addy != null) && (applicant_addy != ""))))) && ((((applicant_email != null) && (applicant_email != "")) && ((applicant_no != null) && (applicant_no != ""))) && (((product_title != null) && (product_title != "")) && ((item_code != null) && (item_code != "")))))
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
                    base.  Response.Redirect("http://www.iponigeria.com/userarea/dashboard");
                }
            }
            else if (Session["pwalletID"] != null)
            {
                pwalletID = Session["pwalletID"].ToString();
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
            if (logo_desc == "yes")
            {
                if ((fu_logo_pic.HasFile) && (fu_app_doc.HasFile))
                {
                    TransactionOptions transactionOptions = new TransactionOptions
                    {
                        IsolationLevel = IsolationLevel.ReadCommitted,
                        Timeout = new TimeSpan(0, 15, 0)
                    };
                    TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, transactionOptions);
                    try
                    {
                        c_pwall.twalletID = "0";
                        c_pwall.validationID = vid;
                        c_pwall.applicantID = agt;
                        c_pwall.log_officer = item_code;
                        c_pwall.amt = amt;

                        g_app_info.filing_date = txt_application_date.Text;
                        g_app_info.application_no = txt_application_no.Text;
                        g_app_info.rtm_number = txt_rtm_no.Text;
                        g_app_info.item_code = item_code;
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

                        g_agent_info.code = agt;
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
                        if (x_succ > 0)
                        {
                           
                        }
                        else
                        {
                            scope.Dispose();
                              Response.Redirect("http://www.iponigeria.com/userarea/dashboard");
                        }
                    }
                    catch (Exception exception)
                    {
                        exception.ToString();
                        scope.Dispose();
                          Response.Redirect("http://www.iponigeria.com/userarea/dashboard");
                    }
                    finally
                    {
                        if (scope != null)
                        {
                            scope.Dispose();

                        }
                    }

                    if (x_succ > 0) { base.Response.Redirect("./g_ack.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + transID); }

                }
                else
                {
                    show_imageMsg = "PLEASE UPLOAD A VALID IMAGE AND POWER OF ATTORNEY DOCUMENT!!";

                }


            }
            else if (fu_app_doc.HasFile)
            {
                TransactionOptions transactionOptions = new TransactionOptions
                {
                    IsolationLevel = IsolationLevel.ReadCommitted,
                    Timeout = new TimeSpan(0, 15, 0)
                };
                TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, transactionOptions);
                try
                {
                    c_pwall.twalletID = "0";
                    c_pwall.validationID = vid;
                    c_pwall.applicantID = agt;
                    c_pwall.log_officer = item_code;
                    c_pwall.amt = amt;

                    g_app_info.filing_date = txt_application_date.Text;
                    g_app_info.application_no = txt_application_no.Text;
                    g_app_info.rtm_number = txt_rtm_no.Text;
                    g_app_info.item_code = item_code;
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

                    g_agent_info.code = agt;
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
                    if (x_succ > 0)
                    {
                        
                    }
                    else
                    {
                        scope.Dispose();
                          Response.Redirect("http://www.iponigeria.com/userarea/dashboard");
                    }
                }
                catch (Exception exception)
                {
                    exception.ToString();
                    scope.Dispose();
                      Response.Redirect("http://www.iponigeria.com/userarea/dashboard");
                }
                finally
                {
                    if (scope != null)
                    {
                        scope.Dispose();

                    }
                }

                if (x_succ > 0)
                {
                    if (Session["vid"] != null)
                    {
                        base.Response.Redirect("./g_ack.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + Session["vid"].ToString());
                    }
                }

            }
            else
            {
                show_imageMsg = "PLEASE UPLOAD A VALID POWER OF ATTORNEY DOCUMENT!!";

            }


        }
    }
}

