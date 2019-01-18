namespace cld
{
    using cld.Classes;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;
    using System.Transactions;
    using System.Configuration;

    public class trademark : Page
    {
        public string address_text = "";
        public string agentemail;
        public string agentname;
        public string agentpnumber;
        public string agt = "";
        public string amt = "";
        public string aos_address_text = "";
        public string aos_addressID = "1";
        public string aos_email_text = "";
        public string aos_name_text = "";
        public string aos_state_row = "0";
        public string aos_state_text = "";
        public string aos_telephone_text = "";
        protected TextBox aos_xaddress;
        protected TextBox aos_xemail;
        protected DropDownList aos_xselectState;
        protected TextBox aos_xstate;
        protected TextBox aos_xtelephone;
        public string applicantemail = "";
        public string applicantname = "";
        public string applicantpnumber = "";
        public HttpApplicationState appstate;
        protected FileUpload auth_doc;
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
        protected Label confirmLbl;
        protected Button ConfirmRepresentativeDetails;
        public string disclaimer_text = "0";
        protected SqlDataSource ds_AosState;
        protected SqlDataSource ds_DefaultCountry;
        protected SqlDataSource ds_LogoDescription;
        protected SqlDataSource ds_NationalClass;
        protected SqlDataSource ds_Nationality;
        protected SqlDataSource ds_RepCountry;
        protected SqlDataSource ds_RepState;
        protected SqlDataSource ds_State;
        protected SqlDataSource ds_TmType;
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
        protected HtmlForm form1;
        protected HiddenField G_Agent_infoemail;
        protected HiddenField G_Agent_infopnumber;
        public string gt = "";
        protected Label lblDoc1;
        protected Label lblDoc2;
        protected Label lblLogoPic;
        protected Label lblPoa;
        public string log_staffID = "0";
        public string logo_desc_text = "";
        protected DropDownList logo_description;
        protected FileUpload logo_pic;
        public string logo_pic_path = "";
        public string logo_pic_text = "";
        public string logo_text = "";
        public List<tm.State> lt_aos_state;
        public List<tm.NClass> lt_nclass;
        public List<tm.State> lt_rep_state;
        public List<tm.State> lt_state;
        public string name_text = "";
        protected DropDownList national_class;
        protected Label national_class_desc;
        public string national_class_text = "";
        protected DropDownList nationality;
        public int newState;
        protected TextBox nice_class_desc;
        public string nice_class_desc_text = "";
        public string pc = "";
        public string product_title;
        public string pwalletID = "0";
        protected RadioButtonList rbDisclaimer;
        protected string reg_date = DateTime.Today.Date.ToString("yyyy-MM-dd");
        protected TextBox rep_address;
        public string rep_address_text = "";
        public string rep_code_text = "";
        public string rep_email_text = "";
        public string rep_name_text = "";
        protected DropDownList rep_nationality;
        protected DropDownList rep_residence;
        public string rep_residence_text = "";
        public string rep_state_row = "0";
        public string rep_state_text = "";
        public string rep_state_visible = "0";
        public string rep_telephone_text = "";
        protected TextBox rep_xemail;
        protected TextBox rep_xname;
        protected TextBox rep_xstate;
        protected TextBox rep_xtelephone;
        protected DropDownList residence;
        public string residence_text = "";
        protected Button SaveDocs;
        protected Button SaveExit;
        public string serverpath;
        public string show_image_section = "1";
        public string show_imageMsg = "";
        public int showItems;
        protected SqlDataSource SqlDataSource2;
        public string state_row = "0";
        public string state_text = "";
        public string state_visible = "0";
        public int status=0;
        protected FileUpload sup_doc1;
        public string sup_doc1_path = "";
        public string sup_doc1_text = "";
        protected FileUpload sup_doc2;
        public string sup_doc2_path = "";
        public string sup_doc2_text = "";
        public tm t = new tm();
        public string telephone_text = "";
        protected TextBox title_of_product;
        public string title_of_product_text = "";
        public string tm_type_text = "";
        protected DropDownList tmType;
        public string transID = "";
        protected TextBox txt_discalimer;
        public string vid = "";
        protected string visible = "1";
        protected TextBox xaddress;
        protected HiddenField xagt;
        protected HiddenField xamt;
        protected HiddenField xapplicantname;
        public string xapplication = "";
        protected HiddenField xcname;
        protected TextBox xcode;
        public string xcode_text = "";
        public string xdesc_national_class = "0";
        protected TextBox xemail;
        protected HiddenField xgt;
        protected HiddenField xmarkID;
        protected TextBox xname;
        protected HiddenField xpc;
        protected HiddenField xproduct_title;
        protected HiddenField xpwalletID;
        protected HiddenField xref;
        protected DropDownList xselectRepState;
        protected DropDownList xselectState;
        protected TextBox xtelephone;
        protected string xtime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt");
        protected HiddenField xvid;
        public int d_succ = 0;
        public SortedList<string, string> sl_docz = new SortedList<string, string>();


        protected void ConfirmRepresentativeDetails_Click(object sender, EventArgs e)
        {
            if (Session["agt"] != null)
            {
                agt = Session["agt"].ToString();
            }
            if (Session["vid"] != null)
            {
                xvid.Value = Session["vid"].ToString();
            }
            if (Session["amt"] != null)
            {
                xamt.Value = Session["amt"].ToString();
            }
            if (Session["gt"] != null)
            {
                xgt.Value = Session["gt"].ToString();
            }
            if (Session["pc"] != null)
            {
                xpc.Value = Session["pc"].ToString();
            }
            if (Session["pwalletID"] != null)
            {
                xpwalletID.Value = Session["pwalletID"].ToString();
            }
            if (Session["agentemail"] != null)
            {
                G_Agent_infoemail.Value = Session["agentemail"].ToString();
            }
            if (Session["cname"] != null)
            {
                xcname.Value = Session["cname"].ToString();
            }
            if (Session["agentpnumber"] != null)
            {
                G_Agent_infopnumber.Value = Session["agentpnumber"].ToString();
            }
            if (Session["applicantname"] != null)
            {
                xapplicantname.Value = Session["applicantname"].ToString();
            }
            if (Session["product_title"] != null)
            {
                xproduct_title.Value = Session["product_title"].ToString();
            }
            int num = 0;
            if (xemail.Text == "")
            {
                email_text = "1";
                num++;
            }
            if (xtelephone.Text == "")
            {
                telephone_text = "1";
                num++;
            }
            if ((state_visible == "0") && (xselectState.Text == ""))
            {
                state_text = "1";
                num++;
            }
            if (xaddress.Text == "")
            {
                address_text = "1";
                num++;
            }
            if (nice_class_desc.Text == "")
            {
                nice_class_desc_text = "1";
                num++;
            }
            if (num != 0)
            {
                Response.Write("<script language=JavaScript>alert('Please fill in the marked fileds')</script>");
                show_image_section = "1";//show_image_section = "0";
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

        protected void logo_description_SelectedIndexChanged(object sender, EventArgs e)
        {
            national_class_desc.Text = t.getNationalClassDesc((national_class.SelectedIndex + 1).ToString());
            if (logo_description.SelectedValue != "2")
            {
                logo_text = "1";
            }
            else
            {
                logo_text = "";
            }
        }

        protected void national_class_SelectedIndexChanged(object sender, EventArgs e)
        {
            national_class_desc.Text = t.getNationalClassDesc((national_class.SelectedIndex + 1).ToString());
            if (national_class_desc.Text != "")
            {
                xdesc_national_class = "1";
            }
            if (logo_description.SelectedValue != "2")
            {
                logo_text = "1";
            }
            else
            {
                logo_text = "";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            show_image_section = "1";   SaveExit.Visible = false;
            serverpath = Server.MapPath("~/");
            if (Session["agt"] != null)
            {
                agt = Session["agt"].ToString();
                xcode.Text = Session["agt"].ToString();
            }
            if (Session["vid"] != null)
            {
                xvid.Value = Session["vid"].ToString();
            }
            else
            {
                Response.Redirect("http://www.iponigeria.com/userarea/dashboard");
            }
            if (Session["amt"] != null)
            {
                xamt.Value = Session["amt"].ToString();
            }
            if (Session["gt"] != null)
            {
                xgt.Value = Session["gt"].ToString();
            }
            if (Session["pc"] != null)
            {
                xpc.Value = Session["pc"].ToString();
            }
            if (Session["pwalletID"] != null)
            {
                xpwalletID.Value = Session["pwalletID"].ToString();
            }
            if (Session["agentemail"] != null)
            {
                rep_xemail.Text = Session["agentemail"].ToString();
            }
            if (Session["agentname"] != null)
            {
                rep_xname.Text = Session["agentname"].ToString();
            }
            if (Session["agentpnumber"] != null)
            {
                rep_xtelephone.Text = Session["agentpnumber"].ToString();
            }
            if (Session["applicantname"] != null)
            {
                xname.Text = Session["applicantname"].ToString();
            }
            if (Session["applicantemail"] != null)
            {
                xemail.Text = Session["applicantemail"].ToString();
            }
            if (Session["applicantpnumber"] != null)
            {
                xtelephone.Text = Session["applicantpnumber"].ToString();
            }
            if (Session["product_title"] != null)
            {
                title_of_product.Text = Session["product_title"].ToString();
            }
            if (Session["log_staffID"] != null)
            {
                log_staffID = Session["log_staffID"].ToString();
            }
            if (IsPostBack)
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
                national_class_desc.Text = t.getNationalClassDesc((national_class.SelectedIndex + 1).ToString());
                if (Session["agt"] != null)
                {
                    xcode.Text = Session["agt"].ToString();
                }
                if (Session["vid"] != null)
                {
                    xvid.Value = Session["vid"].ToString();
                }
                if (Session["amt"] != null)
                {
                    xamt.Value = Session["amt"].ToString();
                }
                if (Session["gt"] != null)
                {
                    xgt.Value = Session["gt"].ToString();
                }
                if (Session["pc"] != null)
                {
                    xpc.Value = Session["pc"].ToString();
                }
                if (Session["pwalletID"] != null)
                {
                    xpwalletID.Value = Session["pwalletID"].ToString();
                }
                if (Session["agentemail"] != null)
                {
                    rep_xemail.Text = Session["agentemail"].ToString();
                }
                if (Session["agentname"] != null)
                {
                    rep_xname.Text = Session["agentname"].ToString();
                }
                if (Session["agentpnumber"] != null)
                {
                    rep_xtelephone.Text = Session["agentpnumber"].ToString();
                }
                if (Session["applicantname"] != null)
                {
                    xname.Text = Session["applicantname"].ToString();
                }
                if (Session["applicantemail"] != null)
                {
                    xemail.Text = Session["applicantemail"].ToString();
                }
                if (Session["applicantpnumber"] != null)
                {
                    xtelephone.Text = Session["applicantpnumber"].ToString();
                }
                if (Session["product_title"] != null)
                {
                    title_of_product.Text = Session["product_title"].ToString();
                }
            }
            else
            {
                nationality.SelectedIndex = 0x9f;
                rep_nationality.SelectedIndex = 0x9f;
                residence.SelectedIndex = 0x9f;
                rep_residence.SelectedIndex = 0x9f;
                lt_nclass = t.getJNationalClasses();
                national_class_desc.Text = lt_nclass[0].xdescription.ToString();
            }
            transID = Session["vid"].ToString();
            Session["xref"] = Convert.ToInt32(Session["xref"]) + 1;
            bool flag1 = Session["xref"].ToString() != "1";
            if ((Session["xapplication"] != null) && (Session["xapplication"].ToString() != ""))
            {
                bool flag2 = transID != Session["xapplication"].ToString();
            }
            xdesc_national_class = "1";
            if (rbDisclaimer.SelectedValue == "YES")
            {
                disclaimer_text = "1";
            }
            else
            {
                disclaimer_text = "0";
            }
            if (logo_description.SelectedValue != "2")
            {
                logo_text = "1";
            }
            else
            {
                logo_text = "";
            }
            Session["logo_description"] = logo_description.SelectedValue;
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

        protected void rbDisclaimer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbDisclaimer.SelectedValue == "YES")
            {
                disclaimer_text = "1";
            }
            else
            {
                disclaimer_text = "0";
            }
        }

        protected void SaveAll_Click(object sender, EventArgs e)
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
                        c_pwall.validationID = transID;
                        c_pwall.amt = xamt.Value;
                        c_pwall.applicantID = xcode.Text;
                        c_pwall.log_officer = "0";
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
                      
                        xmarkID.Value = t.addTrademarkTx(c_app, c_mark, c_aos, c_rep, c_app_addy, c_rep_addy, c_pwall, sl_docz, logo_pic, auth_doc, sup_doc1, sup_doc2, Server.MapPath("~/"));
                        if (Convert.ToInt32(xmarkID.Value) > 0)
                        {
                            scope.Complete(); scope.Dispose();   
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
                    Response.Redirect("./tm_acknowledgement.aspx");
           
                }
                else
                {
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
                        c_pwall.log_officer = "0";
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
                       

                        xmarkID.Value = t.addTrademarkTx(c_app, c_mark, c_aos, c_rep, c_app_addy, c_rep_addy, c_pwall, sl_docz, logo_pic, auth_doc, sup_doc1, sup_doc2, Server.MapPath("~/"));
                        if (Convert.ToInt32(xmarkID.Value) > 0)
                        {
                            scope.Complete(); scope.Dispose(); 
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
                    Response.Redirect("./tm_acknowledgement.aspx");
           
                }
                else
                {
                    show_imageMsg = "PLEASE UPLOAD A VALID POWER OF ATTORNEY DOCUMENT!";

                }
            }


        }

        protected void SaveDocs_Click(object sender, EventArgs e)
        {
            SaveDocs.Visible = false;
            string str = "";
            string str2 = "";
            string str3 = "";
            string path = "";
            int num = 0;
            if ((logo_description.SelectedValue != "2") && !logo_pic.HasFile)
            {
                logo_text = "2";
                num++;
            }
            if (num != 0)
            {
                Response.Write("<script language=JavaScript>alert('Please fill in the marked fileds')</script>");
                show_image_section = "1";
            }
            else
            {
                if ((logo_description.SelectedValue != "2") && logo_pic.HasFile)
                {
                    path = t.doUploadPic(xmarkID.Value, xmarkID.Value + ".jpg", Server.MapPath("~/") + "admin/tm/Picz/", logo_pic);
                }
                if (auth_doc.HasFile)
                {
                    str3 = t.doUploadDoc(xmarkID.Value, Server.MapPath("~/") + "admin/tm/docz/", auth_doc);
                }
                if (sup_doc1.HasFile)
                {
                    str2 = t.doUploadDoc(xmarkID.Value, Server.MapPath("~/") + "admin/tm/docz/", sup_doc1);
                }
                if (sup_doc2.HasFile)
                {
                    str = t.doUploadDoc(xmarkID.Value, Server.MapPath("~/") + "admin/tm/docz/", sup_doc2);
                }
                if (logo_description.SelectedValue != "2")
                {
                    if (!File.Exists(path))
                    {
                        SaveDocs.Visible = true;
                        show_imageMsg = "PLEASE UPLOAD A VALID IMAGE!!";
                    }
                    else
                    {
                        path = path.Replace(Server.MapPath("~/") + "admin/tm/", "");
                        str3 = str3.Replace(Server.MapPath("~/") + "admin/tm/", "");
                        str2 = str2.Replace(Server.MapPath("~/") + "admin/tm/", "");
                        str = str.Replace(Server.MapPath("~/") + "admin/tm/", "");
                        if (t.updateMarkDocz(path, str3, str2, str, xpwalletID.Value) != "0")
                        {
                            status = t.updateIpoApplicationReferenceStatus(xvid.Value, xgt.Value, "1");
                            if (status == 1)
                            {
                                Response.Redirect("./tm_acknowledgement.aspx");
                            }
                            else
                            {
                                Response.Redirect("http://www.iponigeria.com/userarea/dashboard");
                            }
                        }
                    }
                }
                else
                {
                    path = path.Replace(Server.MapPath("~/") + "admin/tm/", "");
                    str3 = str3.Replace(Server.MapPath("~/") + "admin/tm/", "");
                    str2 = str2.Replace(Server.MapPath("~/") + "admin/tm/", "");
                    str = str.Replace(Server.MapPath("~/") + "admin/tm/", "");
                    if (t.updateMarkDocz(path, str3, str2, str, xpwalletID.Value) != "0")
                    {
                        status = t.updateIpoApplicationReferenceStatus(xvid.Value, xgt.Value, "1");
                        if (status == 1)
                        {
                            Response.Redirect("./tm_acknowledgement.aspx");
                        }
                        else
                        {
                            Response.Redirect("http://www.iponigeria.com/userarea/dashboard");
                        }
                    }
                }
            }
        }

         protected void SaveExit_Click(object sender, EventArgs e)
        {
            c_pwall.validationID = transID;
            c_pwall.amt = amt;
            c_pwall.applicantID = rep_xname.Text;
            c_pwall.log_officer = "0"; //c_pwall.log_officer = hwalletID;

            c_app.xname = xname.Text;
            c_app.nationality = nationality.Text;
            c_app.log_staff = "0";
            c_app.reg_date = reg_date;
            c_app.visible = visible;
            c_app.xtime = xtime;
            c_app_addy.countryID = residence.Text;
            c_app_addy.stateID = xselectState.Text;
            c_app_addy.city = "";
            c_app_addy.street = xaddress.Text;
            c_app_addy.telephone1 = xtelephone.Text;
            c_app_addy.email1 = xemail.Text;
            c_app_addy.log_staff = "0";
            c_app_addy.reg_date = reg_date;
            c_app_addy.visible = visible;
            c_app_addy.xtime = xtime;
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
            c_mark.xtime = xtime;
            c_aos.stateID = aos_xselectState.Text;
            c_aos.city = "";
            c_aos.street = aos_xaddress.Text;
            c_aos.telephone1 = aos_xtelephone.Text;
            c_aos.email1 = aos_xemail.Text;
            c_aos.log_staff = "0";
            c_aos.reg_date = reg_date;
            c_aos.visible = visible;
            c_aos.xtime = xtime;
            c_rep.agent_code = xcode.Text;
            c_rep.xname = rep_xname.Text;
            c_rep.nationality = rep_nationality.SelectedValue;
            c_rep.log_staff = "0";
            c_rep.reg_date = reg_date;
            c_rep.visible = visible;
            c_rep.xtime = xtime;
            c_rep_addy.countryID = rep_residence.SelectedValue;
            c_rep_addy.stateID = xselectRepState.SelectedValue;
            c_rep_addy.city = "";
            c_rep_addy.street = rep_address.Text;
            c_rep_addy.telephone1 = rep_xtelephone.Text;
            c_rep_addy.email1 = rep_xemail.Text;
            c_rep_addy.log_staff = "0";
            c_rep_addy.reg_date = reg_date;
            c_rep_addy.visible = visible;
            c_rep_addy.xtime = xtime;
            pwalletID = xpwalletID.Value;
            xmarkID.Value = t.addTrademark(c_app, c_mark, c_aos, c_rep, c_app_addy, c_rep_addy, log_staffID);
            if (xmarkID.Value != "0")
            {
                if (Session["agt"] != null)
                {
                    agt = Session["agt"].ToString();
                }
                Response.Redirect("appstatus.aspx?agt=" + agt);
            }
        }

        //protected int SaveDocs1(string xID)
        //{
        //    string str = "";
        //    string str2 = "";
        //    string str3 = "";
        //    string path = "";
        //    int num = 0;
        //    if (((Session["logo_descriptionxx"] != null) && (Session["logo_descriptionxx"].ToString() != "2")) && logo_pic.HasFile)
        //    {
        //        path = t.doUploadPic(xID, xID + ".jpg", Server.MapPath("~/") + "admin/tm/Picz/", logo_pic);
        //    }
        //    if (auth_doc.HasFile)
        //    {
        //        str3 = t.doUploadDoc(xID, Server.MapPath("~/") + "admin/tm/docz/", auth_doc);
        //    }
        //    if (sup_doc1.HasFile)
        //    {
        //        str2 = t.doUploadDoc(xID, Server.MapPath("~/") + "admin/tm/docz/", sup_doc1);
        //    }
        //    if (sup_doc2.HasFile)
        //    {
        //        str = t.doUploadDoc(xID, Server.MapPath("~/") + "admin/tm/docz/", sup_doc2);
        //    }
        //    if ((Session["logo_descriptionxx"] != null) && (Session["logo_descriptionxx"].ToString() != "2"))
        //    {
        //        if (!File.Exists(path))
        //        {
        //            show_imageMsg = "PLEASE UPLOAD A VALID IMAGE!!";
        //            return num;
        //        }
        //        path = path.Replace(Server.MapPath("~/") + "admin/tm/", "");
        //        str3 = str3.Replace(Server.MapPath("~/") + "admin/tm/", "");
        //        str2 = str2.Replace(Server.MapPath("~/") + "admin/tm/", "");
        //        str = str.Replace(Server.MapPath("~/") + "admin/tm/", "");
        //        return Convert.ToInt32(t.updateMarkDocz(path, str3, str2, str, xID));
        //    }
        //    path = path.Replace(Server.MapPath("~/") + "admin/tm/", "");
        //    str3 = str3.Replace(Server.MapPath("~/") + "admin/tm/", "");
        //    str2 = str2.Replace(Server.MapPath("~/") + "admin/tm/", "");
        //    str = str.Replace(Server.MapPath("~/") + "admin/tm/", "");
        //    return Convert.ToInt32(t.updateMarkDocz(path, str3, str2, str, xID));
        //}

    }
}

