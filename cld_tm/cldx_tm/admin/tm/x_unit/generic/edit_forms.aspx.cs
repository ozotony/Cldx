using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

namespace cld.admin.tm.x_unit.generic
{
    public partial class edit_forms : System.Web.UI.Page
    {
        public string adminID = "";
        public int showt=0;public string trans_status = "";

        protected int cert_show = 0; protected int merger_show = 0; protected int ass_show = 0; protected int change_show = 0;
        protected int prelim_show = 0; protected int renewal_show = 0; protected int others_show = 0;

        protected int app_succ = 0; protected int applicant_succ = 0; protected int tm_info_succ = 0; protected int agent_info_succ = 0;
        protected int x_succ = 0; protected string serverpath = ""; public string item_code = "1"; public string app_type = "";

        protected string xreg_date = DateTime.Now.ToString("yyyy-MM-dd");
        protected string xvisible = "1"; protected string xlog_staff = "1";

        public Classes.tm t = new Classes.tm();
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
        public List<Classes.XObjs.Fee_list> fee_list = new List<Classes.XObjs.Fee_list>();
        public Classes.XObjs.Trademark_item ti = new Classes.XObjs.Trademark_item();
        protected Classes.XObjs.Pwallet c_pwall = new Classes.XObjs.Pwallet();

        public Classes.Retriever ret = new Classes.Retriever();
        public Classes.Registration reg = new Classes.Registration();      

        protected void Page_Load(object sender, EventArgs e)
        {
            this.serverpath = base.Server.MapPath("~/");
            fee_list = ret.getFee_listByCat("tm");

            //if (this.Session["pwalletID"] != null)
            //{
            //    if (this.Session["pwalletID"].ToString() != "")
            //    {
            //        this.adminID = this.Session["pwalletID"].ToString();
            //    }
            //    else
            //    {
            //        base.Response.Redirect("../../lo.aspx");
            //    }
            //}
            //else
            //{
            //    base.Response.Redirect("../../lo.aspx");
            //}
            if (IsPostBack)
            {
                if (Session["showt"] != null) { showt = Convert.ToInt32(Session["showt"]); }
            }
            else
            {
            }
            if (Session["app_type"] != null) { app_type = Session["app_type"].ToString(); }
           
            if (Session["item_code"] != null){ ShowSection(Session["item_code"].ToString());  }
        }
        
 protected void SearchApplicant_Click(object sender, EventArgs e)
        {
            if (xref.Text != "")
            {
                if (xref.Text.Contains("OAI/TM/"))
                {
                    xref.Text = xref.Text.Replace("OAI/TM/", "");
                }
               Session["edit_transID"] = xref.Text;
                g_pwallet = ret.getG_PwalletByValidationID(xref.Text.Trim());
                if ((g_pwallet.xid != null) && (g_pwallet.xid != ""))
                {
                    Session["g_pwallet"] = g_pwallet; Session["g_pwalletID"] = g_pwallet.xid;
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
                    

                    foreach (Classes.XObjs.Fee_list item in fee_list)
                    { if (item.item_code == g_pwallet.log_officer) { lbl_type.Text = item.item.ToUpper(); } }
                    
                    if (g_app_info.id != null)
                    {
                        Session["g_app_info"] = g_app_info;
                        txt_rtm_no.Text = g_app_info.rtm_number;
                        txt_application_no.Text = g_app_info.application_no;
                        txt_application_date.Text = g_app_info.filing_date;
                    }

                    if (g_applicant_info.id != null)
                    {
                        Session["g_applicant_info"] = g_applicant_info;
                        txt_applicant_name.Text = g_applicant_info.xname;
                        txt_applicant_address.Text = g_applicant_info.address;
                        txt_applicant_email.Text = g_applicant_info.xemail;
                        txt_applicant_mobile.Text = g_applicant_info.xmobile;
                        txt_trading_as.Text = g_applicant_info.trading_as;
                        select_applicant_nationality.SelectedIndex = Convert.ToInt32(t.getCountryIDByName(g_applicant_info.nationality)) - 1;
                    }

                    if (g_tm_info.xid != null)
                    {
                        Session["g_tm_info"] = g_tm_info;
                        txt_title_of_trademark.Text = g_tm_info.tm_title;
                        txt_goods_desc.Text = g_tm_info.tm_desc;
                        txt_discalimer.Text = g_tm_info.disclaimer;
                        logo_description.SelectedIndex = Convert.ToInt32(t.getLogoDescriptionID(g_tm_info.logo_descID)) - 1;
                        select_class_of_trademark.SelectedIndex = Convert.ToInt32(g_tm_info.tm_class) - 1;
                        tmType.SelectedIndex = Convert.ToInt32(t.getTmTypeID(g_tm_info.xtype)) - 1;
                    }
                    if (g_agent_info.xid != null)
                    {
                        Session["g_agent_info"] = g_agent_info;
                        rep_xname.Text = g_agent_info.xname;
                        rep_code.Text = g_agent_info.code;
                        txt_rep_address.Text = g_agent_info.address;
                        txt_rep_email.Text = g_applicant_info.xemail;// g_agent_info.email;
                        txt_rep_telephone.Text = g_applicant_info.xmobile;// g_agent_info.telephone;
                        selectRepState.SelectedIndex = Convert.ToInt32(ret.getStateIDByName(g_agent_info.state)) - 1;
                    }

                    if (g_cert_info.xid != null)
                    {
                        Session["g_cert_info"] = g_cert_info;
                        txt_cert_publicationdate.Text = g_cert_info.pub_date;
                        txt_cert_details.Text = g_cert_info.pub_details;
                    }
                    if (g_ass_info.xid != null)
                    {
                        Session["g_ass_info"] = g_ass_info;
                        select_merger_ass.SelectedIndex = 0;
                        txt_assignee_name.Text = g_ass_info.assignee_name;
                        txt_assignee_address.Text = g_ass_info.assignee_address;
                        txt_assignor_name.Text = g_ass_info.assignor_name;
                        txt_assignor_address.Text = g_ass_info.assignor_address;
                        txt_assignment_date.Text = g_ass_info.date_of_assignment;
                        select_assignee_nationality.SelectedIndex = Convert.ToInt32(g_ass_info.assignee_nationality) - 1;
                        select_assignor_nationality.SelectedIndex = Convert.ToInt32(g_ass_info.assignor_nationality) - 1;
                    }
                    if (g_merger_info.xid != null)
                    {
                        Session["g_merger_info"] = g_merger_info;
                        select_merger_ass.SelectedIndex = 1;
                        txt_original_name.Text = g_merger_info.original_name;
                        txt_original_address.Text = g_merger_info.original_address;
                        txt_merging_name.Text = g_merger_info.merging_name;
                        txt_merging_address.Text = g_merger_info.merging_address;
                        txt_merged_coy_name.Text = g_merger_info.merged_coy_name;
                        txt_merger_date.Text = g_merger_info.merger_date;
                    }

                    if (g_change_info.xid != null)
                    {
                        Session["g_change_info"] = g_change_info;
                        txt_old_applicant_trademark.Text = g_change_info.old_name;
                        txt_old_applicant_address.Text = g_change_info.old_address;
                        txt_new_applicant_trademark.Text = g_change_info.new_name;
                        txt_new_applicant_address.Text = g_change_info.new_address;
                    }

                    if (g_prelim_search_info.xid != null)
                    {
                        Session["g_prelim_search_info"] = g_prelim_search_info;
                        txt_prelim_title.Text = g_prelim_search_info.xtitle;
                        select_prelim_class.SelectedIndex = Convert.ToInt32(g_prelim_search_info.xclass) - 1;
                        txt_prelim_desc.Text = g_prelim_search_info.xclass_desc;
                    }

                    if (g_renewal_info.xid != null)
                    {
                        Session["g_renewal_info"] = g_renewal_info;
                        txt_renewal_date.Text = g_renewal_info.prev_renewal_date;
                        try
                        {
                            select_renewal_type.SelectedIndex = Convert.ToInt32(g_renewal_info.renewal_type) - 1;
                        }
                        catch (Exception ee)
                        {

                        }
                    }
                    if (g_other_items_info.xid != null)
                    {
                        Session["g_other_items_info"] = g_other_items_info;
                        txt_details_of_request.Text = g_other_items_info.req_details;
                    }

                    ShowSection(g_pwallet.log_officer);
                    showt = 1; Session["showt"] = showt;
                }
                else
                { Response.Write("<script language=JavaScript>alert('PLEASE ENTER A VALID REFERENCE NUMBER')</script>"); }

            }
            else
            { Response.Write("<script language=JavaScript>alert('PLEASE ENTER A VALID REFERENCE NUMBER')</script>"); }
        }

 public void ShowSection(string item_code)
 {
     if (item_code == "T001") { prelim_show = 1; Session["item_code"] = item_code; Session["app_type"] = "prelim"; }
     else if (item_code == "T003") { cert_show = 1; Session["item_code"] = item_code; Session["app_type"] = "cert"; }
     else if (item_code == "T008") { change_show = 1; Session["item_code"] = item_code; Session["app_type"] = "change"; }
     else if (item_code == "T009") { renewal_show = 1; Session["item_code"] = item_code; Session["app_type"] = "renewal"; }
     else if (item_code == "T014") { ass_show = 1; merger_show = 1; Session["item_code"] = item_code; Session["app_type"] = "ass/merger"; }
     else if ((item_code != "T001") && (item_code != "T002") && (item_code != "T003") && (item_code != "T008") && (item_code != "T009") && (item_code != "T014"))
     { others_show = 1; Session["item_code"] = item_code; Session["app_type"] = "others"; }
 }


 protected void SaveEdit_Click(object sender, EventArgs e)
 {
     if (Session["item_code"] != null) { item_code = Session["item_code"].ToString(); }
     if (Session["g_pwallet"] != null) { g_pwallet = (Classes.XObjs.G_Pwallet)Session["g_pwallet"]; }
     if (Session["g_app_info"] != null) { g_app_info = (Classes.XObjs.G_App_info)Session["g_app_info"]; }
     if (Session["g_applicant_info"] != null) { g_applicant_info = (Classes.XObjs.G_Applicant_info)Session["g_applicant_info"]; }
     if (Session["g_tm_info"] != null) { g_tm_info = (Classes.XObjs.G_Tm_info)Session["g_tm_info"]; }
     if (Session["g_agent_info"] != null) { g_agent_info = (Classes.XObjs.Gen_Agent_info)Session["g_agent_info"]; }
     if (Session["g_ass_info"] != null) { g_ass_info = (Classes.XObjs.G_Ass_info)Session["g_ass_info"]; }
     if (Session["g_cert_info"] != null) { g_cert_info = (Classes.XObjs.G_Cert_info)Session["g_cert_info"]; }
     if (Session["g_change_info"] != null) { g_change_info = (Classes.XObjs.G_Change_info)Session["g_change_info"]; }
     if (Session["g_merger_info"] != null) { g_merger_info = (Classes.XObjs.G_Merger_info)Session["g_merger_info"]; }
     if (Session["g_renewal_info"] != null) { g_renewal_info = (Classes.XObjs.G_Renewal_info)Session["g_renewal_info"]; }
     if (Session["g_prelim_search_info"] != null) { g_prelim_search_info = (Classes.XObjs.G_Prelim_search_info)Session["g_prelim_search_info"]; }
     if (Session["g_other_items_info"] != null) { g_other_items_info = (Classes.XObjs.G_Other_items_info)Session["g_other_items_info"]; }

    g_app_info.filing_date = txt_application_date.Text;
    g_app_info.application_no = txt_application_no.Text;
    g_app_info.rtm_number = txt_rtm_no.Text;
    g_app_info.item_code = item_code;
    g_app_info.reg_no = "";
    g_app_info.log_staff = g_pwallet.xid;

    if (txt_new_date.Text != "") { g_pwallet.reg_date = txt_new_date.Text; }
    else
    {
        if ((g_pwallet.reg_date == null) || (g_pwallet.reg_date == "")) { g_pwallet.reg_date = xreg_date; }
    }
    if (g_app_info.id != null) { reg.update_G_Pwallet(g_pwallet); }
  

    if (txt_new_date.Text != "") { g_app_info.reg_date = txt_new_date.Text; }
    else
    {
        if((g_app_info.reg_date == null)||(g_app_info.reg_date == "") ) { g_app_info.reg_date = xreg_date; }
    }
    g_app_info.visible = xvisible;

   

    if (g_app_info.id != null)
    {
        app_succ = reg.update_App_info(g_app_info); Session["app_succID"] = app_succ;
    }
    else
    {
        app_succ = reg.addG_App_info(g_app_info); Session["app_succID"] = app_succ;
    }

    g_applicant_info.trading_as = txt_trading_as.Text;
    g_applicant_info.visible = xvisible;
    g_applicant_info.address = txt_applicant_address.Text;
    g_applicant_info.xemail = txt_applicant_email.Text;
    g_applicant_info.xmobile = txt_applicant_mobile.Text;
    g_applicant_info.xname = txt_applicant_name.Text;
    g_applicant_info.nationality = select_applicant_nationality.SelectedValue;
    g_applicant_info.log_staff = g_pwallet.xid;

    if (g_applicant_info.id != null)
    {
        applicant_succ = reg.update_Applicant_info(g_applicant_info); Session["applicant_succID"] = applicant_succ;
    }
    else
    {
        applicant_succ = reg.addG_Applicant_info(g_applicant_info); Session["applicant_succID"] = applicant_succ;
    }

    g_tm_info.disclaimer = txt_discalimer.Text;
    g_tm_info.tm_class = select_class_of_trademark.SelectedValue;
    g_tm_info.tm_desc = txt_goods_desc.Text;
    g_tm_info.tm_title = txt_title_of_trademark.Text;
    g_tm_info.xtype = tmType.SelectedValue;
    if ((g_tm_info.reg_number == null) || (g_tm_info.reg_number == "")) { g_tm_info.reg_number = ""; }
    g_tm_info.logo_descID = logo_description.SelectedValue;
    if (g_tm_info.logo_descID != "WORD MARK") { Session["logo_desc"] = "yes"; }
    if ((g_tm_info.logo_pic == null) || (g_tm_info.logo_pic == "")) { g_tm_info.logo_pic = ""; }
    if ((g_tm_info.auth_doc == null) || (g_tm_info.auth_doc == "")) { g_tm_info.auth_doc = ""; }
    if ((g_tm_info.sup_doc1 == null) || (g_tm_info.sup_doc1 == "")) { g_tm_info.sup_doc1 = ""; }
    if ((g_tm_info.app_letter_doc == null) || (g_tm_info.app_letter_doc == "")) { g_tm_info.app_letter_doc = ""; }   
    g_tm_info.log_staff = g_pwallet.xid;
    if (txt_new_date.Text != "") { g_tm_info.reg_date = txt_new_date.Text; }
    else
    {
        if ((g_tm_info.reg_date == null) || (g_tm_info.reg_date == "")) { g_tm_info.reg_date = xreg_date; }
    }
    g_tm_info.visible = xvisible;

    if (g_tm_info.xid != null)
    {
        Session["new_miID"] = g_tm_info.xid;
        tm_info_succ = reg.update_Tm_info(g_tm_info); 
    }
    else
    {
        tm_info_succ = reg.addG_Tm_info(g_tm_info);  Session["new_miID"] = tm_info_succ;
    }

    g_agent_info.code = rep_code.Text;
    g_agent_info.xname = rep_xname.Text;
    g_agent_info.xpassword = "";
    g_agent_info.nationality = txt_rep_nationality.Text;
    g_agent_info.country = txt_rep_country.Text;
    g_agent_info.state = selectRepState.SelectedValue;
    g_agent_info.address = txt_rep_address.Text;
    g_agent_info.telephone = txt_rep_telephone.Text;
    g_agent_info.email = txt_rep_email.Text;
    g_agent_info.log_staff = g_pwallet.xid;
    g_agent_info.xsync = "0";

    if (g_agent_info.xid != null)
    {
        agent_info_succ = reg.update_Gen_Agent_info(g_agent_info); Session["agent_info_succID"] = agent_info_succ;
    }
    else
    {
        agent_info_succ = reg.addGen_Agent_info(g_agent_info); Session["agent_info_succID"] = agent_info_succ;
    }

    g_ass_info.assignee_address = txt_assignee_address.Text;
    g_ass_info.assignee_name = txt_assignee_name.Text;
    g_ass_info.assignor_address = txt_assignor_address.Text;
    g_ass_info.assignee_nationality = select_assignee_nationality.SelectedValue;
    g_ass_info.assignor_name = txt_assignor_name.Text;
    g_ass_info.date_of_assignment = txt_assignment_date.Text;
    g_ass_info.assignor_nationality = select_assignor_nationality.SelectedValue;
    g_ass_info.log_staff = g_pwallet.xid;
    g_ass_info.xvisible = xvisible;
    if (( g_ass_info.ass_doc == null) || ( g_ass_info.ass_doc == "")) {  g_ass_info.ass_doc = ""; }

    if (g_ass_info.xid != null)
    {
        x_succ = reg.update_G_Ass_info(g_ass_info); Session["assID"] = x_succ; Session["app_type"] = "ass";
    }
    else
    {
        if (app_type == "ass/merger")
        {
            if ((ass_show > 0) && (select_merger_ass.SelectedValue == "Assignment"))
            {
                x_succ = reg.addG_Ass_info(g_ass_info); Session["assID"] = x_succ; Session["app_type"] = "ass";
            }
        }
    }

    g_merger_info.original_name = txt_original_name.Text;
    g_merger_info.original_address = txt_original_address.Text;
    g_merger_info.merging_name = txt_merging_name.Text;
    g_merger_info.merging_address = txt_merging_address.Text;
    g_merger_info.merged_coy_name = txt_merged_coy_name.Text;
    g_merger_info.merger_date = txt_merger_date.Text;
    g_merger_info.visible = xvisible;
    g_merger_info.log_staff = g_pwallet.xid;
    if ((g_merger_info.merger_doc == null) || (g_merger_info.merger_doc== "")) { g_merger_info.merger_doc = ""; }

    if (g_merger_info.xid != null)
    {
        x_succ = reg.update_G_Merger_info(g_merger_info); Session["mergerID"] = x_succ; Session["app_type"] = "merger";
    }
    else
    {
        if (app_type == "ass/merger")
        {
            if ((merger_show > 0) && (select_merger_ass.SelectedValue == "Merger"))
            {
                x_succ = reg.addG_Merger_info(g_merger_info); Session["mergerID"] = x_succ; Session["app_type"] = "merger";
            }
        }
    }

    g_cert_info.log_staff = g_pwallet.xid;
    if (txt_new_date.Text != "") { g_cert_info.reg_date = txt_new_date.Text; }
    else
    {
        if ((g_cert_info.reg_date == null) || (g_cert_info.reg_date == "")) { g_cert_info.reg_date = xreg_date; }
    }
    g_cert_info.xvisible = xvisible;
    g_cert_info.pub_date = txt_cert_publicationdate.Text;
    g_cert_info.pub_details = txt_cert_details.Text;
    if ((g_cert_info.cert_doc  == null) || (g_cert_info.cert_doc  == "")) { g_cert_info.cert_doc  = ""; }
    if ((g_cert_info.pub_doc == null) || (g_cert_info.pub_doc == "")) { g_cert_info.pub_doc = ""; }

    if (g_cert_info.xid != null)
    {
        x_succ = reg.update_G_Cert_info(g_cert_info); Session["certID"] = x_succ; Session["app_type"] = "cert";
    }
    else
    {
        if (app_type == "cert")
        {
            x_succ = reg.addG_Cert_info(g_cert_info); Session["certID"] = x_succ; Session["app_type"] = "cert";
        }
    }

    g_change_info.new_name = txt_new_applicant_trademark.Text;
    g_change_info.new_address = txt_new_applicant_address.Text;
    g_change_info.old_name = txt_old_applicant_trademark.Text;
    g_change_info.old_address = txt_old_applicant_address.Text;
    if (txt_new_date.Text != "") { g_change_info.reg_date = txt_new_date.Text; }
    else
    {
        if ((g_change_info.reg_date == null) || (g_change_info.reg_date == "")) { g_change_info.reg_date = xreg_date; }
    }
    g_change_info.visible = xvisible;
    g_change_info.log_staff = g_pwallet.xid;

    if (g_change_info.xid != null)
    {
        x_succ = reg.update_G_Change_info(g_change_info); Session["app_type"] = "change";
    }
    else
    {
        if (app_type == "change")
        {
            x_succ = reg.addG_Change_info(g_change_info); Session["app_type"] = "change";
        }
    }
    g_renewal_info.prev_renewal_date = txt_renewal_date.Text;
    g_renewal_info.renewal_type = select_renewal_type.SelectedValue;
    g_renewal_info.visible = xvisible;
    g_renewal_info.log_staff = g_pwallet.xid;
    if (txt_new_date.Text != "") { g_renewal_info.reg_date = txt_new_date.Text; }
    else
    {
        if ((g_renewal_info.reg_date == null) || (g_renewal_info.reg_date == "")) { g_renewal_info.reg_date = xreg_date; }
    }

    if (g_renewal_info.xid != null)
    {
        x_succ = reg.update_G_Renewal_info(g_renewal_info); Session["app_type"] = "renewal";
    }
    else
    {
        if (app_type == "renewal")
        {
            x_succ = reg.addG_Renewal_info(g_renewal_info); Session["app_type"] = "renewal";
        }
    }

    g_prelim_search_info.xtitle = txt_prelim_title.Text;
    g_prelim_search_info.xclass = select_prelim_class.SelectedValue;
    g_prelim_search_info.xclass_desc = txt_prelim_desc.Text;
    g_prelim_search_info.visible = xvisible;
    g_prelim_search_info.log_staff = g_pwallet.xid;
    if (txt_new_date.Text != "") { g_prelim_search_info.reg_date = txt_new_date.Text; }
    else
    {
        if ((g_prelim_search_info.reg_date == null) || (g_prelim_search_info.reg_date == "")) { g_prelim_search_info.reg_date = xreg_date; }
    }

    if (g_prelim_search_info.xid != null)
    {
        x_succ = reg.update_G_Prelim_search_info(g_prelim_search_info); Session["app_type"] = "prelim";
    }
    else
    {
        if (app_type == "prelim")
        {
            x_succ = reg.addG_Prelim_search_info(g_prelim_search_info); Session["app_type"] = "prelim";
        }
    }

    g_other_items_info.req_details = txt_details_of_request.Text;
    g_other_items_info.visible = xvisible;
    g_other_items_info.log_staff = g_pwallet.xid;
    if (txt_new_date.Text != "") { g_other_items_info.reg_date = txt_new_date.Text; }
    else
    {
        if ((g_other_items_info.reg_date == null) || (g_other_items_info.reg_date == "")) { g_other_items_info.reg_date = xreg_date; }
    }

    if (g_other_items_info.xid != null)
    {
        x_succ = reg.update_G_Other_items_info(g_other_items_info); Session["app_type"] = "others";
    }
    else
    {
        if (app_type == "others")
        {
            x_succ = reg.addG_Other_items_info(g_other_items_info); Session["app_type"] = "others";
        }
    }
    if (x_succ > 0)
    {
        //Session["x_succ"] = null;
        Response.Redirect("./edit_forms_docs.aspx");
    }
   
 }      

    }
}