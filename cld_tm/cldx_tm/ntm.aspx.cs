namespace cld
{
    using cld.Classes;
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.IO;
    using System.Transactions;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public partial class ntm : Page
    {
        public string address_text = "";
        public string agentpnumber;
        public string aid = "";
        public string amt = "";
        public string aos_address_text = "";
        public string aos_addressID = "1";
        public string aos_city_text = "";
        public string aos_email_text = "";
        public string aos_name_text = "";
        public string aos_state_row = "0";
        public string aos_state_text = "";
        public string aos_telephone_text = "";
        public string applicantname;
        public string auth_doc_path = "";
        public string auth_doc_text = "";
        public string auth_text = "";
        public tm.AddressService c_aos = new tm.AddressService();
        public tm.Applicant c_app = new tm.Applicant();
        public tm.Address c_app_addy = new tm.Address();
        public tm.MarkInfo c_mark = new tm.MarkInfo();
        public tm.Representative c_rep = new tm.Representative();
        public tm.Address c_rep_addy = new tm.Address();
        public tm.Stage c_pwall = new tm.Stage();
        public string city_text = "";
        public string cname;
        public int d_succ;
        public string disclaimer_text = "0";
        public string email_text = "";
        public string enable_AosConfirm = "0";
        public string enable_AosSave = "1";
        public string enable_AppConfirm = "0";
        public string enable_AppSave = "1";
        public string enable_MarkConfirm = "0";
        public string enable_MarkSave = "1";
        public string enable_RepConfirm = "0";
        public string enable_RepSave = "1";
        public string enable_Save_Doc = "1";
        public string fee_detailsID = "";
        public string gt = "";
        public string hwalletID = "";
        public string log_staffID = "0";
        public string logo_desc_text = "";
        public string logo_pic_path = "";
        public string logo_pic_text = "";
        public List<tm.State> lt_aos_state;
        public List<tm.NClass> lt_nclass;
        public List<tm.State> lt_rep_state;
        public List<tm.State> lt_state;
        public string name_text = "";
        public string national_class_text = "";
        public int newState;
        public string nice_class_desc_text = "";
        public string pc = "";
        public string product_title;
        public string pwalletID = "0";
        public Registration reg = new Registration();
        protected string reg_date = DateTime.Today.Date.ToString("yyyy-MM-dd");
        public string rep_address_text = "";
        public string rep_city_text = "";
        public string rep_code_text = "";
        public string rep_email_text = "";
        public string rep_name_text = "";
        public string rep_residence_text = "";
        public string rep_state_row = "0";
        public string rep_state_text = "";
        public string rep_state_visible = "0";
        public string rep_telephone_text = "";
        public string residence_text = "";
        public string serverpath;
        public string show_image_section = "0";
        public string show_imageMsg = "";
        public int showItems;
        public string state_row = "0";
        public string state_text = "";
        public string state_visible = "0";
        public int status=0;
        public string sup_doc1_path = "";
        public string sup_doc1_text = "";
        public string sup_doc2_path = "";
        public string sup_doc2_text = "";
        public tm t = new tm();
        public string telephone_text = "";
        public string title_of_product_text = "";
        public string tm_type_text = "";
        public string transID = "";
        public string vid = "";
        protected string visible = "1";
        public string xapplication = "";
        public string xcode_text = "";
        public string xdesc_national_class = "0";
        public SortedList<string,string> sl_docz=new SortedList<string,string>();



        protected void ConfirmRepresentativeDetails_Click(object sender, EventArgs e)
        {
            if (Session["aid"] != null){   xaid.Value = Session["aid"].ToString(); }
            if (Session["vid"] != null) {   xvid.Value = Session["vid"].ToString(); }
            if (Session["amt"] != null)   {  xamt.Value = Session["amt"].ToString(); }
            if (Session["gt"] != null)  {  xgt.Value = Session["gt"].ToString();  }
            if (Session["pc"] != null)   {   xpc.Value = Session["pc"].ToString();  }
            if (Session["pwalletID"] != null)  { xpwalletID.Value = Session["pwalletID"].ToString(); }
            if (Session["agentemail"] != null) {   agent_email.Value = Session["agentemail"].ToString();   }
            if (Session["agentname"] != null)  {  xcname.Value = Session["agentname"].ToString(); }
            if (Session["agentpnumber"] != null) {agent_no.Value = Session["agentpnumber"].ToString();     }
            if (Session["applicantname"] != null)   { xapplicantname.Value = Session["applicantname"].ToString(); }
            if (Session["applicant_addy"] != null) {     xapplicant_addy.Value = Session["applicant_addy"].ToString(); }
            if (Session["applicantemail"] != null)   {xapplicant_email.Value = Session["applicantemail"].ToString();   }
            if (Session["applicantpnumber"] != null) { xapplicant_no.Value = Session["applicantpnumber"].ToString(); }
            if (Session["product_title"] != null)  { xproduct_title.Value = Session["product_title"].ToString(); }
            int num = 0;
            if (xemail.Text == "")  { email_text = "1";  num++; }
            if (xtelephone.Text == "") {  telephone_text = "1";  num++;  }
            if ((state_visible == "0") && (xselectState.Text == ""))   {  state_text = "1";   num++;  }
            if (xaddress.Text == "")  {  address_text = "1";   num++;  }
            if (nice_class_desc.Text == "")  { nice_class_desc_text = "1";  num++; }
            if (num != 0)
            {
                base.Response.Write("<script language=JavaScript>alert('Please fill in the marked fileds')</script>");
                show_image_section = "0";
            }
            else
            {
                enable_AppSave = "0";
                enable_AppConfirm = "1";
                enable_MarkSave = "0";
                enable_MarkConfirm = "1";
                enable_Save_Doc = "0";
                enable_RepConfirm = "1";
                enable_RepSave = "0";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            serverpath = base.Server.MapPath("~/");
            if (Session["vid"] != null)
            {  xvid.Value = reg.DecodeChar(Session["vid"].ToString()); transID = reg.DecodeChar(Session["vid"].ToString()); }
            else
            {  base.Response.Redirect(ConfigurationManager.AppSettings["ipo_profile_page"]); }
            if (Session["aid"] != null)   { xaid.Value =reg.DecodeChar( Session["aid"].ToString());  }
            if (Session["amt"] != null)  {  xamt.Value = reg.DecodeChar(Session["amt"].ToString()); }
            if (Session["xgt"] != null) {xgt.Value = reg.DecodeChar(Session["xgt"].ToString());  }
            if (Session["item_code"] != null) { xpc.Value = reg.DecodeChar(Session["item_code"].ToString()); }
            if (Session["pwalletID"] != null){ xpwalletID.Value = reg.DecodeChar(Session["pwalletID"].ToString());}
            if (Session["hwalletID"] != null) { hwalletID = reg.DecodeChar(Session["hwalletID"].ToString()); }
            if (Session["agentemail"] != null) {  agent_email.Value = reg.DecodeChar(Session["agentemail"].ToString());}
            if (Session["agentname"] != null) {  xcname.Value = reg.DecodeChar(Session["agentname"].ToString()); }
            if (Session["agentpnumber"] != null) {  agent_no.Value = reg.DecodeChar(Session["agentpnumber"].ToString()); }
            if (Session["applicantname"] != null){  xapplicantname.Value = reg.DecodeChar(Session["applicantname"].ToString());    }
            if (Session["applicant_addy"] != null) {   xapplicant_addy.Value = reg.DecodeChar(Session["applicant_addy"].ToString());}
            if (Session["applicantemail"] != null)  { xapplicant_email.Value = reg.DecodeChar(Session["applicantemail"].ToString());  }
            if (Session["applicantpnumber"] != null) { xapplicant_no.Value = reg.DecodeChar(Session["applicantpnumber"].ToString());}
            if (Session["product_title"] != null) {  xproduct_title.Value = reg.DecodeChar(Session["product_title"].ToString()); }
            if (Session["log_staffID"] != null) { log_staffID = reg.DecodeChar(Session["log_staffID"].ToString());  }
            title_of_product.Text = xproduct_title.Value;
            xname.Text = xapplicantname.Value;
            xaddress.Text = xapplicant_addy.Value;
            xtelephone.Text = xapplicant_no.Value;
            xemail.Text = xapplicant_email.Value;
            xcode.Text = xaid.Value;
            rep_xname.Text = xcname.Value;
            rep_xemail.Text = agent_email.Value;
            rep_xtelephone.Text = agent_no.Value;
            national_class_desc.Text = t.getNationalClassDesc((national_class.SelectedIndex + 1).ToString());
            xdesc_national_class = "1";
            if (rbDisclaimer.SelectedValue == "YES")
            {
                disclaimer_text = "1";
            }
            else
            {
                disclaimer_text = "0";
            }
            Session["logo_description"] = logo_description.SelectedValue;
            if (base.IsPostBack)
            {
                lt_state = t.getState(residence.SelectedValue);
                if (lt_state.Count == 0)
                {
                    state_row = "1";
                    state_visible = "1";
                }
                lt_rep_state = t.getState(rep_residence.SelectedValue);
                if (lt_rep_state.Count == 0)
                {
                    rep_state_row = "1";
                    state_visible = "1";
                }
            }
            else
            {
                nationality.SelectedIndex = 0x9f;
                rep_nationality.SelectedIndex = 0x9f;
                residence.SelectedIndex = 0x9f;
                rep_residence.SelectedIndex = 0x9f;
                national_class_desc.Text = t.getNationalClassDesc("1");
            }
            Session["xref"] = Convert.ToInt32(Session["xref"]) + 1;
            bool flag1 = Session["xref"].ToString() != "1";
            if ((Session["xapplication"] != null) && (Session["xapplication"].ToString() != ""))
            {
                bool flag2 = transID != Session["xapplication"].ToString();
            }
            if ((Session["logo_pic"] == null) && logo_pic.HasFile)
            {
                Session["logo_pic"] = logo_pic;
                lblLogoPic.Text = logo_pic.FileName;
            }
            else if ((Session["logo_pic"] != null) && !logo_pic.HasFile)
            {
                logo_pic = (FileUpload)Session["logo_pic"];
                lblLogoPic.Text = logo_pic.FileName;
            }
            else if (logo_pic.HasFile)
            {
                Session["logo_pic"] = logo_pic;
                lblLogoPic.Text = logo_pic.FileName;
            }
            if ((Session["auth_doc"] == null) && auth_doc.HasFile)
            {
                Session["auth_doc"] = auth_doc;
                lblPoa.Text = auth_doc.FileName;
            }
            else if ((Session["auth_doc"] != null) && !auth_doc.HasFile)
            {
                auth_doc = (FileUpload)Session["auth_doc"];
                lblPoa.Text = auth_doc.FileName;
            }
            else if (auth_doc.HasFile)
            {
                Session["auth_doc"] = auth_doc;
                lblPoa.Text = auth_doc.FileName;
            }
            if ((Session["sup_doc1"] == null) && sup_doc1.HasFile)
            {
                Session["sup_doc1"] = sup_doc1;
                lblDoc1.Text = sup_doc1.FileName;
            }
            else if ((Session["sup_doc1"] != null) && !sup_doc1.HasFile)
            {
                sup_doc1 = (FileUpload)Session["sup_doc1"];
                lblDoc1.Text = sup_doc1.FileName;
            }
            else if (sup_doc1.HasFile)
            {
                Session["sup_doc1"] = sup_doc1;
                lblDoc1.Text = sup_doc1.FileName;
            }
            if ((Session["sup_doc2"] == null) && sup_doc2.HasFile)
            {
                Session["sup_doc2"] = sup_doc2;
                lblDoc2.Text = sup_doc2.FileName;
            }
            else if ((Session["sup_doc2"] != null) && !sup_doc2.HasFile)
            {
                sup_doc2 = (FileUpload)Session["sup_doc2"];
                lblDoc2.Text = sup_doc2.FileName;
            }
            else if (sup_doc2.HasFile)
            {
                Session["sup_doc2"] = sup_doc2;
                lblDoc2.Text = sup_doc2.FileName;
            }
        }

        protected void SaveAll_Click(object sender, EventArgs e)
        {
            if (logo_description.SelectedValue != "2")
            {
                if ((logo_pic.HasFile)&&(auth_doc.HasFile))
                {
                   
                    TransactionOptions transactionOptions = new TransactionOptions
                    {
                        IsolationLevel = IsolationLevel.ReadCommitted,
                        Timeout = new TimeSpan(0, 15, 0)
                    };
                    TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, transactionOptions);
                    try
                    {
                        c_pwall.validationID = transID;
                        c_pwall.amt = xamt.Value;
                        c_pwall.applicantID = xcode.Text;
                        c_pwall.log_officer = hwalletID;
                        c_app.xname = xapplicantname.Value;
                        c_app.nationality = nationality.Text;
                        c_app.log_staff = "0";
                        c_app.reg_date = reg_date;
                        c_app.visible = visible;
                        c_app_addy.countryID = residence.Text;
                        c_app_addy.stateID = xselectState.Text;
                        c_app_addy.street = xaddress.Text;
                        c_app_addy.telephone1 = xtelephone.Text;
                        c_app_addy.email1 = xemail.Text;
                        c_app_addy.log_staff = "0";
                        c_app_addy.reg_date = reg_date;
                        c_app_addy.visible = visible;
                        c_mark.tm_typeID = tmType.SelectedValue;
                        c_mark.logo_descriptionID = logo_description.SelectedValue;  
                        c_mark.product_title = title_of_product.Text;
                        c_mark.nice_class = national_class.SelectedValue;
                        c_mark.nice_class_desc = nice_class_desc.Text;
                        c_mark.national_classID = national_class.SelectedValue;
                        c_mark.disclaimer = txt_discalimer.Text;
                        c_mark.log_staff = "0";
                        c_mark.reg_date = reg_date;
                        c_mark.xvisible = visible;
                        c_aos.stateID = aos_xselectState.Text;
                        c_aos.city = "";
                        c_aos.street = aos_xaddress.Text;
                        c_aos.telephone1 = aos_xtelephone.Text;
                        c_aos.email1 = aos_xemail.Text;
                        c_aos.log_staff = "0";
                        c_aos.reg_date = reg_date;
                        c_aos.visible = visible;
                        c_rep.agent_code = xcode.Text;
                        c_rep.xname = rep_xname.Text;
                        c_rep.nationality = rep_nationality.SelectedValue;
                        c_rep.log_staff = "0";
                        c_rep.reg_date = reg_date;
                        c_rep.visible = visible;
                        c_rep_addy.countryID = rep_residence.SelectedValue;
                        c_rep_addy.stateID = xselectRepState.SelectedValue;
                        c_rep_addy.city = "";
                        c_rep_addy.street = rep_address.Text;
                        c_rep_addy.telephone1 = rep_xtelephone.Text;
                        c_rep_addy.email1 = rep_xemail.Text;
                        c_rep_addy.log_staff = "0";
                        c_rep_addy.reg_date = reg_date;
                        c_rep_addy.visible = visible;
                        pwalletID = xpwalletID.Value;
                        if (Session["hwalletID"] != null){ hwalletID = Session["hwalletID"].ToString();  }
                
                            xmarkID.Value = t.addTrademarkTx(c_app, c_mark, c_aos, c_rep, c_app_addy, c_rep_addy, c_pwall, sl_docz, logo_pic, auth_doc, sup_doc1, sup_doc2, Server.MapPath("~/"));
                          //  if (Convert.ToInt32(xmarkID.Value) > 0) { scope.Complete(); /*Response.Write(xmarkID.Value);*/ }
                            if (Convert.ToInt32(xmarkID.Value) > 0)
                            {
                                ws_payx.payx ws_p = new ws_payx.payx();
                                status = ws_p.UpdateHwallet(hwalletID, "Used", reg_date, title_of_product.Text);
                                if (status >= 0)
                                {
                                    scope.Complete(); scope.Dispose();
                                }
                                else
                                {
                                    scope.Dispose(); 
                                    Response.Redirect(ConfigurationManager.AppSettings["ipo_profile_page"]);
                                }
                            }
                            else
                            {
                                scope.Dispose(); 
                                 Response.Redirect(ConfigurationManager.AppSettings["ipo_profile_page"]);
                            }
                /////
                    }
                    catch (Exception exception)
                    {
                        exception.ToString(); scope.Dispose(); 
                        Response.Redirect(ConfigurationManager.AppSettings["ipo_profile_page"]);
                    }
                    finally
                    {
                        if (scope != null) { scope.Dispose(); }
                    }
                    if (Convert.ToInt32(xmarkID.Value) > 0)  {  Response.Redirect("./ntm_acknowledgement.aspx"); }
                }
                else
                {
                    enable_RepSave = "1";
                    show_imageMsg = "PLEASE UPLOAD A VALID IMAGE AND POWER OF ATTORNEY DOCUMENT!!";                   
                }
         }

                   //////////No Logo
        else
        {
            if (auth_doc.HasFile)
            {

                TransactionOptions transactionOptions = new TransactionOptions
                {
                    IsolationLevel = IsolationLevel.ReadCommitted,
                    Timeout = new TimeSpan(0, 15, 0)
                };
                TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, transactionOptions);
                try
                {
                    c_pwall.validationID = transID;
                    c_pwall.amt = xamt.Value;
                    c_pwall.applicantID = xcode.Text;
                    c_pwall.log_officer = hwalletID;
                    c_app.xname = xapplicantname.Value;
                    c_app.nationality = nationality.Text;
                    c_app.log_staff = "0";
                    c_app.reg_date = reg_date;
                    c_app.visible = visible;
                    c_app_addy.countryID = residence.Text;
                    c_app_addy.stateID = xselectState.Text;
                    c_app_addy.street = xaddress.Text;
                    c_app_addy.telephone1 = xtelephone.Text;
                    c_app_addy.email1 = xemail.Text;
                    c_app_addy.log_staff = "0";
                    c_app_addy.reg_date = reg_date;
                    c_app_addy.visible = visible;
                    c_mark.tm_typeID = tmType.SelectedValue;
                    c_mark.logo_descriptionID = logo_description.SelectedValue;
                    c_mark.product_title = title_of_product.Text;
                    c_mark.nice_class = national_class.SelectedValue;
                    c_mark.nice_class_desc = nice_class_desc.Text;
                    c_mark.national_classID = national_class.SelectedValue;
                    c_mark.disclaimer = txt_discalimer.Text;
                    c_mark.log_staff = "0";
                    c_mark.reg_date = reg_date;
                    c_mark.xvisible = visible;
                    c_aos.stateID = aos_xselectState.Text;
                    c_aos.city = "";
                    c_aos.street = aos_xaddress.Text;
                    c_aos.telephone1 = aos_xtelephone.Text;
                    c_aos.email1 = aos_xemail.Text;
                    c_aos.log_staff = "0";
                    c_aos.reg_date = reg_date;
                    c_aos.visible = visible;
                    c_rep.agent_code = xcode.Text;
                    c_rep.xname = rep_xname.Text;
                    c_rep.nationality = rep_nationality.SelectedValue;
                    c_rep.log_staff = "0";
                    c_rep.reg_date = reg_date;
                    c_rep.visible = visible;
                    c_rep_addy.countryID = rep_residence.SelectedValue;
                    c_rep_addy.stateID = xselectRepState.SelectedValue;
                    c_rep_addy.city = "";
                    c_rep_addy.street = rep_address.Text;
                    c_rep_addy.telephone1 = rep_xtelephone.Text;
                    c_rep_addy.email1 = rep_xemail.Text;
                    c_rep_addy.log_staff = "0";
                    c_rep_addy.reg_date = reg_date;
                    c_rep_addy.visible = visible;
                    pwalletID = xpwalletID.Value;
                    if (Session["hwalletID"] != null)  {  hwalletID = Session["hwalletID"].ToString();  }

                    xmarkID.Value = t.addTrademarkTx(c_app, c_mark, c_aos, c_rep, c_app_addy, c_rep_addy, c_pwall, sl_docz, logo_pic, auth_doc, sup_doc1, sup_doc2, Server.MapPath("~/"));
                    if (Convert.ToInt32(xmarkID.Value) > 0)
                    {
                        ws_payx.payx ws_p = new ws_payx.payx();
                        status = ws_p.UpdateHwallet(hwalletID, "Used", reg_date, title_of_product.Text);
                        if (status >= 0)
                        {
                            scope.Complete(); scope.Dispose();
                        }
                        else
                        {
                            scope.Dispose();
                            Response.Redirect(ConfigurationManager.AppSettings["ipo_profile_page"]);
                        }
                    }
                    else
                    {
                        scope.Dispose();
                        Response.Redirect(ConfigurationManager.AppSettings["ipo_profile_page"]);
                    }
                }
                catch (Exception exception)
                {
                    exception.ToString(); Response.Write("Single" +exception.ToString());
                   scope.Dispose();
                    Response.Redirect(ConfigurationManager.AppSettings["ipo_profile_page"]);
                }
                finally
                {
                    if (scope != null) { scope.Dispose(); }
                }
               if (Convert.ToInt32(xmarkID.Value) > 0) {  Response.Redirect("./ntm_acknowledgement.aspx");  }
            }
            else
            {
                enable_RepSave = "1";
                show_imageMsg = "PLEASE UPLOAD A VALID POWER OF ATTORNEY DOCUMENT!";

            }      
        }


   }

    
    }
}

