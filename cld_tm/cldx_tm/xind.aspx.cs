using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;


namespace cld
{
    using Classes;
    using System.Transactions;
    using System.IO;
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
        protected CheckBox cbAgree;
        //test
        // imported
        public string address_text = "";
        public string aos_address_text = "";
        public string aos_addressID = "1";
        public string aos_city_text = "";
        public string aos_email_text = "";
        public string aos_name_text = "";
        public string aos_state_row = "0";
        public string aos_state_text = "";
        public string aos_telephone_text = "";
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
        public string gt = "";
        public string logo_desc_text = "";
        public string logo_pic_path = "";
        public int logo_pic_text = 1;
        public List<tm.State> lt_aos_state;
        public List<tm.NClass> lt_nclass;
        public List<tm.State> lt_rep_state;
        public List<tm.State> lt_state;
        public string name_text = "";
        public string national_class_text = "";
        public int newState;
        public string nice_class_desc_text = "";
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
        public string sup_doc1_path = "";
        public string sup_doc1_text = "";
        public string sup_doc2_path = "";
        public string sup_doc2_text = "";
        public string telephone_text = "";
        public string title_of_product_text = "";
        public string tm_type_text = "";
        protected string visible = "1";
        public string xcode_text = "";
        public string xdesc_national_class = "0";
        public SortedList<string, string> sl_docz = new SortedList<string, string>();


        protected cld.Classes.XObjs.Trademark_item ti = new cld.Classes.XObjs.Trademark_item();
        public tm.Stage c_stage = new tm.Stage();

        protected Classes.tm t = new Classes.tm();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (logo_description.SelectedItem.Value != "2") { logo_pic_text = 1; } else { logo_pic_text = 0; }
            serverpath = base.Server.MapPath("~/");

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
                Session["agentname"] = null;
                Session["agentpnumber"] = null;
                Session["applicantname"] = null;
                Session["applicant_addy"] = null;
                Session["applicantemail"] = null;
                Session["applicantpnumber"] = null;
                Session["product_title"] = null;
                Session["xapplication"] = null;
                Session["pwalletID"] = null;
                Session["log_staffID"] = null;
                Session["xapplication"] = null;
                Session["log_staffID"] = log_staffID;


                if (Request.Form["item_code"] != null) { this.item_code = Request.Form["item_code"]; }
                if (Request.Form["fee_detailsID"] != null) { this.fee_detailsID = Request.Form["fee_detailsID"]; }
                if (Request.Form["hwalletID"] != null) { this.hwalletID = Request.Form["hwalletID"]; }
                if (Request.Form["transID"] != null) { this.transID = Request.Form["transID"]; }
                if (Request.Form["amt"] != null) { this.amt = Request.Form["amt"]; }
                if (Request.Form["agent"] != null) { this.agent = Request.Form["agent"]; }
                if (Request.Form["agentname"] != null) { this.agentname = Request.Form["agentname"]; }
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

                if (
                  //  (this.item_code != "") && (this.fee_detailsID != "") && (this.hwalletID != "") && (this.transID != "") &&
                     (this.item_code != "")  && (this.transID != "") &&
                    (this.amt != "") && (this.agent != "") && (this.agentname != "") && (this.agentemail != "") && (this.agentpnumber != "") &&
                    (this.applicantname != "")  && (this.applicantemail != "") && (this.applicantpnumber != "") && (this.product_title != "")
                    )
                {
                    if (Session["xapplication"] != null)
                    {
                        this.xapplication = Session["xapplication"].ToString();
                        if (this.xapplication != this.transID) { Response.Redirect("./violation.aspx"); }
                    }
                    else
                    {
                        Session["xapplication"] = this.transID.Trim();
                    }
                    Session["item_code"] = this.item_code.Trim();
                    Session["fee_detailsID"] = this.fee_detailsID.Trim();
                    Session["hwalletID"] = this.hwalletID.Trim();
                    Session["vid"] = this.transID.Trim();
                    Session["amt"] = this.amt.Trim();
                    Session["aid"] = this.agent.Trim();
                    Session["agentemail"] = this.agentemail.Trim();
                    Session["agentname"] = this.agentname.Trim();
                    Session["agentpnumber"] = this.agentpnumber.Trim();
                    Session["applicantname"] = this.applicantname.Trim();
                    Session["applicant_addy"] = this.applicant_addy.Trim();
                    Session["applicantemail"] = this.applicantemail.Trim();
                    Session["applicantpnumber"] = this.applicantpnumber.Trim();
                    Session["product_title"] = this.product_title.Trim();

                    Classes.tm.Stage s = this.t.getStatusIDByvalidationID(this.transID.Trim());

                    if ((s.ID != null) && (Convert.ToInt32(s.ID) > 0)) { Response.Redirect("./xxreturn.aspx"); }

                    nationality.SelectedIndex = 0x9f;
                    rep_nationality.SelectedIndex = 0x9f;
                    residence.SelectedIndex = 0x9f;
                    rep_residence.SelectedIndex = 0x9f;
                    national_class_desc.Text = t.getNationalClassDesc("1");
                }
                else
                {
                    Response.Redirect(ConfigurationManager.AppSettings["ipo_profile_page"]);
                }
            }
            else
            {
                lt_state = t.getState(residence.SelectedValue);
                if (lt_state.Count == 0) { state_row = "1"; state_visible = "1"; }
                lt_rep_state = t.getState(rep_residence.SelectedValue);
                if (lt_rep_state.Count == 0) { rep_state_row = "0"; state_visible = "1"; }
                national_class_desc.Text = t.getNationalClassDesc((national_class.SelectedIndex + 1).ToString());
                xdesc_national_class = "1";
            }
        }

        protected void cbAgree_CheckedChanged(object sender, EventArgs e)
        {

            if (cbAgree.Checked == true)
            {
                isagree = true; tt.Visible = false; tt2.Visible = true;

                title_of_product.Text = (String)Session["product_title"];
                xname.Text = (String)Session["applicantname"];
                xaddress.Text = (String)Session["applicant_addy"];
                xtelephone.Text = (String)Session["applicantpnumber"];
                xemail.Text = (String)Session["applicantemail"];
                xcode.Text = (String)Session["aid"];
                rep_xname.Text = (String)Session["agentname"];
                rep_xemail.Text = (String)Session["agentemail"];
                rep_xtelephone.Text = (String)Session["agentpnumber"];
                //national_class_desc.Text = t.getNationalClassDesc((national_class.SelectedIndex + 1).ToString());
                national_class_desc.Text = t.getNationalClassDesc("1");
                xdesc_national_class = "1";

                Session["logo_description"] = logo_description.SelectedValue;
                if (base.IsPostBack)
                {
                    //lt_state = t.getState(residence.SelectedValue);
                    //if (lt_state.Count == 0)  {    state_row = "1";   state_visible = "1";  }
                    //lt_rep_state = t.getState(rep_residence.SelectedValue);
                    //if (lt_rep_state.Count == 0)  {   rep_state_row = "1";  state_visible = "1";  }
                }
                else
                {
                    //nationality.SelectedIndex = 0x9f;
                    //rep_nationality.SelectedIndex = 0x9f;
                    //residence.SelectedIndex = 0x9f;
                    //rep_residence.SelectedIndex = 0x9f;
                    //national_class_desc.Text = t.getNationalClassDesc("1");
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
            else { isagree = false; tt.Visible = true; tt2.Visible = false; }


        }
        protected void newsProviderID_DataBound2(object sender, EventArgs e)
        {
            //simple test   
            residence.SelectedValue = "160";
        }

        protected void newsProviderID_DataBound3(object sender, EventArgs e)
        {
            //simple test   
            rep_nationality.SelectedValue = "160";
        }

        protected void newsProviderID_DataBound(object sender, EventArgs e)
        {
            //simple test   
            nationality.SelectedValue = "160";
        }
        protected void ConfirmRepresentativeDetails_Click(object sender, EventArgs e)
        {
            if (Session["aid"] != null) { xaid.Value = Session["aid"].ToString(); }
            if (Session["vid"] != null) { xvid.Value = Session["vid"].ToString(); }
            if (Session["amt"] != null) { xamt.Value = Session["amt"].ToString(); }
            if (Session["gt"] != null) { xgt.Value = Session["gt"].ToString(); }
            if (Session["pc"] != null) { xpc.Value = Session["pc"].ToString(); }
            if (Session["pwalletID"] != null) { xpwalletID.Value = Session["pwalletID"].ToString(); }
            if (Session["agentemail"] != null) { agent_email.Value = Session["agentemail"].ToString(); }
            if (Session["agentname"] != null) { xcname.Value = Session["agentname"].ToString(); }
            if (Session["agentpnumber"] != null) { agent_no.Value = Session["agentpnumber"].ToString(); }
            if (Session["applicantname"] != null) { xapplicantname.Value = Session["applicantname"].ToString(); }
            if (Session["applicant_addy"] != null) { xapplicant_addy.Value = Session["applicant_addy"].ToString(); }
            if (Session["applicantemail"] != null) { xapplicant_email.Value = Session["applicantemail"].ToString(); }
            if (Session["applicantpnumber"] != null) { xapplicant_no.Value = Session["applicantpnumber"].ToString(); }
            if (Session["product_title"] != null) { xproduct_title.Value = Session["product_title"].ToString(); }
            int num = 0;
            if (xemail.Text == "") { email_text = "1"; num++; }
            if (xtelephone.Text == "") { telephone_text = "1"; num++; }
            if ((state_visible == "0") && (xselectState.Text == "")) { state_text = "1"; num++; }
            if (xaddress.Text == "") { address_text = "1"; num++; }
            if (nice_class_desc.Text == "") { nice_class_desc_text = "1"; num++; }
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

        protected void SaveAll_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {

                if (logo_description.SelectedValue != "2")
                {
                    if ((logo_pic.HasFile) && (auth_doc.HasFile))
                    {

                        TransactionOptions transactionOptions = new TransactionOptions
                        {
                            IsolationLevel = IsolationLevel.ReadCommitted,
                            Timeout = new TimeSpan(0, 15, 0)
                        };
                        TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, transactionOptions);
                        try
                        {
                            c_pwall.validationID = (String)Session["vid"]; // transID;
                            c_pwall.amt = (String)Session["amt"]; // xamt.Value;
                            c_pwall.applicantID = xcode.Text;
                            c_pwall.log_officer = (String)Session["hwalletID"];// hwalletID;
                            c_app.xname = (String)Session["applicantname"];// xapplicantname.Value;
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
                            c_aos.countryID = "160";
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
                            if (Session["hwalletID"] != null) { hwalletID = Session["hwalletID"].ToString(); }

                            xmarkID.Value = t.addTrademarkTx(c_app, c_mark, c_aos, c_rep, c_app_addy, c_rep_addy, c_pwall, sl_docz, logo_pic, auth_doc, sup_doc1, sup_doc2, Server.MapPath("~/"));
                            if (Convert.ToInt32(xmarkID.Value) > 0)
                            {
                                //if (Session["hwalletID"].ToString() != "")
                                //{
                                //  //  ws_payx.payx ws_p = new ws_payx.payx();
                                //    zues dd10 = new zues();
                                //    status = dd10.updateHwallet(hwalletID, "Used", reg_date, title_of_product.Text);
                                //  //  status = ws_p.UpdateHwallet(hwalletID, "Used", reg_date, title_of_product.Text);
                                //}
                                //else
                                //{
                                //  //  this.status = this.t.updateIpoApplicationReferenceStatus(this.Session["vid"].ToString(), this.Session["aid"].ToString(), "1");
                                //}
                                //  status = 1;
                                //if (status >= 0)
                                if (Convert.ToInt32(xmarkID.Value) > 0)
                                {
                                    scope.Complete(); scope.Dispose();

                                    if (Convert.ToInt32(xmarkID.Value) > 0)
                                    {
                                        if (Session["hwalletID"].ToString() != "")
                                        {
                                            //  ws_payx.payx ws_p = new ws_payx.payx();
                                            zues dd10 = new zues();
                                            status = dd10.updateHwallet(hwalletID, "Used", reg_date, title_of_product.Text);
                                            //  status = ws_p.UpdateHwallet(hwalletID, "Used", reg_date, title_of_product.Text);
                                        }
                                        else
                                        {
                                            //  this.status = this.t.updateIpoApplicationReferenceStatus(this.Session["vid"].ToString(), this.Session["aid"].ToString(), "1");
                                        }

                                    }


                                }
                                else
                                {
                                    scope.Dispose();
                                    Response.Redirect(ConfigurationManager.AppSettings["ipo_profile_page"]);
                                }

                            }
                            // }
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
                            if (scope != null)    {    scope.Dispose();   }
                        }
                        if (Convert.ToInt32(xmarkID.Value) > 0)
                        {

                            tt2.Visible = false;     tt3.Visible = true;

                            serverpath = base.Server.MapPath("~/");
                            if (Session["vid"] != null) { vid = Session["vid"].ToString(); }
                            if (Session["amt"] != null) { amt = Session["amt"].ToString(); }
                            if (Session["aid"] != null) { aid = Session["aid"].ToString(); }
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
                                        tm_img.Height = new Unit(120, UnitType.Pixel); tm_img.Width = new Unit(120, UnitType.Pixel);
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
                                                    tm_img.Height = new Unit(320, UnitType.Pixel); tm_img.Width = new Unit(240, UnitType.Pixel);
                                                }
                                                else
                                                {
                                                    tm_img.Height = new Unit(240, UnitType.Pixel); tm_img.Width = new Unit(320, UnitType.Pixel);
                                                }
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

                                Session["xserviceaddress"] = null;
                                Session["xrepresentative"] = null;
                                Session["xmarkinfo"] = null;
                                Session["xapplication"] = null;
                                Session["vid"] = null;
                                Session["amt"] = null;
                                Session["aid"] = null;
                                Session["g"] = null;
                                Session["pc"] = null;

                                //   pwalletID = t.getPwalletID(vid);

                                tt2.Visible = false;
                                tt3.Visible = true;
                                //     Response.Redirect("./ntm_acknowledgement.aspx"); }
                            }
                            else
                            {
                                enable_RepSave = "1";
                                show_imageMsg = "PLEASE UPLOAD A VALID IMAGE AND POWER OF ATTORNEY DOCUMENT!!";
                            }
                        }
                    }
                    //////////No Logo
                }
                else
                {
                  //  tt2.Visible = false;
                  //  tt3.Visible = true;
                    if (auth_doc.HasFile)
                    {

                        TransactionOptions transactionOptions2 = new TransactionOptions
                        {
                            IsolationLevel = IsolationLevel.ReadCommitted,
                            Timeout = new TimeSpan(0, 15, 0)
                        };
                        TransactionScope scope2 = new TransactionScope(TransactionScopeOption.Required, transactionOptions2);
                        try
                        {
                            c_pwall.validationID = (String)Session["vid"];// transID;
                            c_pwall.amt = (String)Session["amt"];// xamt.Value;
                            c_pwall.applicantID = xcode.Text;
                            c_pwall.log_officer = (String)Session["hwalletID"];// hwalletID;
                            c_app.xname = (String)Session["applicantname"];// xapplicantname.Value;
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
                            if (Session["logo_description"] != null)
                            {
                                c_mark.logo_descriptionID = Session["logo_description"].ToString();
                                Session["logo_descriptionxx"] = Session["logo_description"].ToString();
                            }
                            else
                            {
                                c_mark.logo_descriptionID = logo_description.SelectedValue;
                            }
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
                            c_aos.countryID = rep_residence.SelectedValue;
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
                            if (Session["hwalletID"] != null) { hwalletID = Session["hwalletID"].ToString(); }

                            xmarkID.Value = t.addTrademarkTx(c_app, c_mark, c_aos, c_rep, c_app_addy, c_rep_addy, c_pwall, sl_docz, logo_pic, auth_doc, sup_doc1, sup_doc2, Server.MapPath("~/"));
                            if (Convert.ToInt32(xmarkID.Value) > 0)
                            {
                                if (Session["hwalletID"].ToString() != "")
                                {
                                  //  ws_payx.payx ws_p = new ws_payx.payx();
                                  //  status = ws_p.UpdateHwallet(hwalletID, "Used", reg_date, title_of_product.Text);
                                }
                                else
                                {
                                 //   this.status = this.t.updateIpoApplicationReferenceStatus(this.Session["vid"].ToString(), this.Session["aid"].ToString(), "1");

                                }
                                //if (status >= 0)
                                if (Convert.ToInt32(xmarkID.Value) > 0)
                                {
                                    scope2.Complete(); scope2.Dispose();

                                    if (Convert.ToInt32(xmarkID.Value) > 0)
                                    {
                                        if (Session["hwalletID"].ToString() != "")
                                        {
                                            //  ws_payx.payx ws_p = new ws_payx.payx();
                                            zues dd10 = new zues();
                                            status = dd10.updateHwallet(hwalletID, "Used", reg_date, title_of_product.Text);
                                            //  status = ws_p.UpdateHwallet(hwalletID, "Used", reg_date, title_of_product.Text);
                                        }
                                        else
                                        {
                                            //  this.status = this.t.updateIpoApplicationReferenceStatus(this.Session["vid"].ToString(), this.Session["aid"].ToString(), "1");
                                        }

                                    }
                                }
                                else
                                {
                                    scope2.Dispose();
                                    Response.Redirect(ConfigurationManager.AppSettings["ipo_profile_page"]);
                                }
                            }
                            else
                            {
                                scope2.Dispose();
                                Response.Redirect(ConfigurationManager.AppSettings["ipo_profile_page"]);
                            }


                            if (Convert.ToInt32(xmarkID.Value) > 0)
                            {

                                tt2.Visible = false; tt3.Visible = true;

                                serverpath = base.Server.MapPath("~/");
                                if (Session["vid"] != null) { vid = Session["vid"].ToString(); }
                                if (Session["amt"] != null) { amt = Session["amt"].ToString(); }
                                if (Session["aid"] != null) { aid = Session["aid"].ToString(); }
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
                                            tm_img.Height = new Unit(120, UnitType.Pixel); tm_img.Width = new Unit(120, UnitType.Pixel);
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
                                                        tm_img.Height = new Unit(320, UnitType.Pixel); tm_img.Width = new Unit(240, UnitType.Pixel);
                                                    }
                                                    else
                                                    {
                                                        tm_img.Height = new Unit(240, UnitType.Pixel); tm_img.Width = new Unit(320, UnitType.Pixel);
                                                    }
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

                                    Session["xserviceaddress"] = null;
                                    Session["xrepresentative"] = null;
                                    Session["xmarkinfo"] = null;
                                    Session["xapplication"] = null;
                                    Session["vid"] = null;
                                    Session["amt"] = null;
                                    Session["aid"] = null;
                                    Session["g"] = null;
                                    Session["pc"] = null;
                                    tt2.Visible = false;
                                    tt3.Visible = true;
                                }
                                else
                                {
                                    enable_RepSave = "1";
                                    show_imageMsg = "PLEASE UPLOAD A VALID IMAGE AND POWER OF ATTORNEY DOCUMENT!!";
                                }
                            }
                        }
                        catch (Exception exception)
                        {
                            exception.ToString(); Response.Write("Single" + exception.ToString());
                            scope2.Dispose();
                            Response.Redirect(ConfigurationManager.AppSettings["ipo_profile_page"]);
                        }
                        finally
                        {
                            if (scope2 != null) { scope2.Dispose(); }
                        }
                        //  if (Convert.ToInt32(xmarkID.Value) > 0) { Response.Redirect("./ntm_acknowledgement.aspx"); }

                        if (Convert.ToInt32(xmarkID.Value) > 0)
                        {
                            //   Response.Redirect("./xind.aspx"); 
                        }
                    }
                    else
                    {
                        enable_RepSave = "1";
                        show_imageMsg = "PLEASE UPLOAD A VALID POWER OF ATTORNEY DOCUMENT!";

                    }
                }
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