namespace cld
{
    using Classes ;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class trademarkx : Page
    {
        public string address_text = "";
        public string agentemail;
        public string agentpnumber;
        public string aid = "";
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
        public string applicantname;
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
        public string cname;
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
        protected Button SaveAll;
        protected Button SaveDocs;
        public string serverpath;
        public string show_image_section = "0";
        public string show_imageMsg = "";
        public int showItems;
        protected SqlDataSource SqlDataSource2;
        public string state_row = "0";
        public string state_text = "";
        public string state_visible = "0";
        public string status = "";
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
        protected TextBox xaddress;
        protected HiddenField G_Agent_infoemail;
        protected HiddenField G_Agent_infopnumber;
        protected HiddenField xaid;
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
        protected HiddenField xvid;
        protected string reg_date = DateTime.Today.Date.ToString("yyyy-MM-dd");
        protected string visible = "1";
        protected string xtime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt");

        protected cld.Classes.XObjs.Trademark_item ti = new cld.Classes.XObjs.Trademark_item();
        protected cld.Classes.XObjs.Pwallet c_pwall = new cld.Classes.XObjs.Pwallet();
        protected cld.Classes.XObjs.G_Agent_info c_xmem = new cld.Classes.XObjs.G_Agent_info();
        protected cld.Classes.XObjs.Address c_addy = new cld.Classes.XObjs.Address();
        protected cld.Classes.Retriever ret = new cld.Classes.Retriever();
        protected cld.Classes.Registration reg = new cld.Classes.Registration();

        protected void ConfirmRepresentativeDetails_Click(object sender, EventArgs e)
        {
            if (this.Session["aid"] != null)
            {
                this.xaid.Value = this.Session["aid"].ToString();
            }
            if (this.Session["vid"] != null)
            {
                this.xvid.Value = this.Session["vid"].ToString();
            }
            if (this.Session["amt"] != null)
            {
                this.xamt.Value = this.Session["amt"].ToString();
            }
            if (this.Session["gt"] != null)
            {
                this.xgt.Value = this.Session["gt"].ToString();
            }
            if (this.Session["pc"] != null)
            {
                this.xpc.Value = this.Session["pc"].ToString();
            }
            if (this.Session["pwalletID"] != null)
            {
                this.xpwalletID.Value = this.Session["pwalletID"].ToString();
            }
            if (this.Session["agentemail"] != null)
            {
                this.G_Agent_infoemail.Value = this.Session["agentemail"].ToString();
            }
            if (this.Session["cname"] != null)
            {
                this.xcname.Value = this.Session["cname"].ToString();
            }
            if (this.Session["agentpnumber"] != null)
            {
                this.G_Agent_infopnumber.Value = this.Session["agentpnumber"].ToString();
            }
            if (this.Session["applicantname"] != null)
            {
                this.xapplicantname.Value = this.Session["applicantname"].ToString();
            }
            if (this.Session["product_title"] != null)
            {
                this.xproduct_title.Value = this.Session["product_title"].ToString();
            }
            int num = 0;
            if (this.xemail.Text == "")
            {
                this.email_text = "1";
                num++;
            }
            if (this.xtelephone.Text == "")
            {
                this.telephone_text = "1";
                num++;
            }
            if ((this.state_visible == "0") && (this.xselectState.Text == ""))
            {
                this.state_text = "1";
                num++;
            }
           
            if (this.xaddress.Text == "")
            {
                this.address_text = "1";
                num++;
            }
            if (this.nice_class_desc.Text == "")
            {
                this.nice_class_desc_text = "1";
                num++;
            }
            if (num != 0)
            {
                base.Response.Write("<script language=JavaScript>alert('Please fill in the marked fileds')</script>");
                this.show_image_section = "0";
            }
            else
            {
                this.enable_AppSave = "0";
                this.enable_AppConfirm = "1";
                this.enable_MarkSave = "0";
                this.enable_MarkConfirm = "1";
                this.enable_Save_Doc = "0";
                this.enable_RepConfirm = "1";
                this.enable_RepSave = "0";
            }
        }

        protected void logo_description_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.national_class_desc.Text = this.t.getNationalClassDesc((this.national_class.SelectedIndex + 1).ToString());
            if (this.logo_description.SelectedValue != "2")
            {
                this.logo_text = "1";
            }
            else
            {
                this.logo_text = "";
            }
        }

        protected void national_class_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.national_class_desc.Text = this.t.getNationalClassDesc((this.national_class.SelectedIndex + 1).ToString());
            if (this.national_class_desc.Text != "")
            {
                this.xdesc_national_class = "1";
            }
            if (this.logo_description.SelectedValue != "2")
            {
                this.logo_text = "1";
            }
            else
            {
                this.logo_text = "";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.serverpath = base.Server.MapPath("~/");
            if (this.Session["aid"] != null)
            {
                this.xaid.Value = this.Session["aid"].ToString(); this.xcode.Text = this.Session["aid"].ToString();
            }
            if (this.Session["vid"] != null)
            {
                this.xvid.Value = this.Session["vid"].ToString();
            }
            else
            {
                if (this.Session["Trademark_item"] == null)
                {
                    base.Response.Redirect("http://www.iponigeria.com/userarea/dashboard");
                }
                else
                {
                    Response.Redirect("./XPay/A/profile.aspx");
                }
            }
            if (this.Session["amt"] != null)
            {
                this.xamt.Value = this.Session["amt"].ToString();
            }
            if (this.Session["gt"] != null)
            {
                this.xgt.Value = this.Session["gt"].ToString();
            }
            if (this.Session["pc"] != null)
            {
                this.xpc.Value = this.Session["pc"].ToString();
            }
            if (this.Session["pwalletID"] != null)
            {
                this.xpwalletID.Value = this.Session["pwalletID"].ToString();
            }
            if (this.Session["agentemail"] != null)
            {
                this.G_Agent_infoemail.Value = this.Session["agentemail"].ToString();
            }
            if (this.Session["cname"] != null)
            {
                this.xcname.Value = this.Session["cname"].ToString();
            }
            if (this.Session["agentpnumber"] != null)
            {
                this.G_Agent_infopnumber.Value = this.Session["agentpnumber"].ToString();
            }
            if (this.Session["applicantname"] != null)
            {
                this.xapplicantname.Value = this.Session["applicantname"].ToString();
            }
            if (this.Session["product_title"] != null)
            {
                this.xproduct_title.Value = this.Session["product_title"].ToString();
            }
            if (this.Session["log_staffID"] != null)
            {
                this.log_staffID = this.Session["log_staffID"].ToString();
            }
            
            this.xname.Text = this.xapplicantname.Value;
            if (base.IsPostBack)
            {
                this.lt_state = this.t.getState(this.residence.SelectedValue);
                if (this.lt_state.Count == 0)
                {
                    this.state_row = "1";
                    this.state_visible = "1";
                }
                this.lt_rep_state = this.t.getState(this.rep_residence.SelectedValue);
                if (this.lt_rep_state.Count == 0)
                {
                    this.rep_state_row = "1";
                    this.state_visible = "1";
                }
                this.national_class_desc.Text = this.t.getNationalClassDesc((this.national_class.SelectedIndex + 1).ToString());
                if (this.Session["aid"] != null)
                {
                    this.xaid.Value = this.Session["aid"].ToString();
                }
                if (this.Session["vid"] != null)
                {
                    this.xvid.Value = this.Session["vid"].ToString();
                }
                if (this.Session["amt"] != null)
                {
                    this.xamt.Value = this.Session["amt"].ToString();
                }
                if (this.Session["gt"] != null)
                {
                    this.xgt.Value = this.Session["gt"].ToString();
                }
                if (this.Session["pc"] != null)
                {
                    this.xpc.Value = this.Session["pc"].ToString();
                }
                if (this.Session["pwalletID"] != null)
                {
                    this.xpwalletID.Value = this.Session["pwalletID"].ToString();
                }
                if (this.Session["agentemail"] != null)
                {
                    this.G_Agent_infoemail.Value = this.Session["agentemail"].ToString();
                }
                if (this.Session["cname"] != null)
                {
                    this.xcname.Value = this.Session["cname"].ToString();
                }
                if (this.Session["agentpnumber"] != null)
                {
                    this.G_Agent_infopnumber.Value = this.Session["agentpnumber"].ToString();
                }
                if (this.Session["applicantname"] != null)
                {
                    this.xapplicantname.Value = this.Session["applicantname"].ToString();
                }
                if (this.Session["product_title"] != null)
                {
                    this.xproduct_title.Value = this.Session["product_title"].ToString();
                }
            }
            else
            {
                if (Session["Trademark_item"] != null)
                {
                    ti = (cld.Classes.XObjs.Trademark_item)Session["Trademark_item"];
                    c_pwall = ret.getPwalletByID(ti.xmemberID);
                    c_xmem = ret.getAgentByID(c_pwall.xmemberID);
                    c_addy = ret.getAddressByID(c_xmem.addressID);

                    title_of_product.Text = ti.product_title;
                    xname.Text = ti.applicant_name;
                    this.nationality.SelectedIndex = 159;
                    this.residence.SelectedIndex = 159;
                    //Representative
                    xcode.Text = c_xmem.sys_ID;
                    rep_xname.Text = c_xmem.cname;
                    rep_nationality.SelectedIndex = Convert.ToInt32(c_addy.countryID) - 1;
                    rep_residence.SelectedIndex = Convert.ToInt32(c_addy.countryID) - 1;
                    xselectRepState.SelectedIndex = Convert.ToInt32(c_addy.stateID) - 1;
                    rep_address.Text = c_addy.street;
                    rep_xemail.Text = c_addy.email1;
                    rep_xtelephone.Text = c_addy.telephone1;

                    aos_xselectState.SelectedIndex = Convert.ToInt32(c_addy.stateID) - 1;
                    aos_xemail.Text = c_addy.email1;
                    aos_xtelephone.Text = c_addy.telephone1;
                    aos_xaddress.Text = c_addy.street;

                    this.lt_nclass = this.t.getJNationalClasses();
                    this.national_class_desc.Text = this.lt_nclass[0].xdescription.ToString();
                }
                else
                {
                    this.nationality.SelectedIndex = 159;
                    this.rep_nationality.SelectedIndex = 159;
                    this.residence.SelectedIndex = 159;
                    this.rep_residence.SelectedIndex = 159;
                    this.lt_nclass = this.t.getJNationalClasses();
                    this.national_class_desc.Text = this.lt_nclass[0].xdescription.ToString();
                    this.rep_xname.Text = this.xcname.Value;
                    this.rep_xemail.Text = this.G_Agent_infoemail.Value;
                    this.title_of_product.Text = this.xproduct_title.Value;
                    this.rep_xtelephone.Text = this.G_Agent_infopnumber.Value;
                }
                this.transID = this.Session["vid"].ToString();
                this.Session["xref"] = Convert.ToInt32(this.Session["xref"]) + 1;
                if (this.Session["xref"].ToString() != "1")
                {
                    if (this.Session["Trademark_item"] == null)
                    {
                        base.Response.Redirect("./violation.aspx");
                    }
                    else
                    {
                        Response.Redirect("./a_violation.aspx");
                    }
                }
                if (((this.Session["xapplication"] != null) && (this.Session["xapplication"].ToString() != "")) && (this.transID != this.Session["xapplication"].ToString()))
                {
                    if (this.Session["Trademark_item"] == null)
                    {
                        base.Response.Redirect("./violation.aspx");
                    }
                    else
                    {
                        Response.Redirect("./a_violation.aspx");
                    }
                }

            }
            this.xdesc_national_class = "1";
            if (this.rbDisclaimer.SelectedValue == "YES")
            {
                this.disclaimer_text = "1";
            }
            else
            {
                this.disclaimer_text = "0";
            }
            if (this.logo_description.SelectedValue != "2")
            {
                this.logo_text = "1";
            }
            else
            {
                this.logo_text = "";
            }
            if ((this.Session["logo_pic"] == null) && this.logo_pic.HasFile)
            {
                this.Session["logo_pic"] = this.logo_pic;
                this.lblLogoPic.Text = this.logo_pic.FileName;
            }
            else if ((this.Session["logo_pic"] != null) && !this.logo_pic.HasFile)
            {
                this.logo_pic = (FileUpload)this.Session["logo_pic"];
                this.lblLogoPic.Text = this.logo_pic.FileName;
            }
            else if (this.logo_pic.HasFile)
            {
                this.Session["logo_pic"] = this.logo_pic;
                this.lblLogoPic.Text = this.logo_pic.FileName;
            }
            if ((this.Session["auth_doc"] == null) && this.auth_doc.HasFile)
            {
                this.Session["auth_doc"] = this.auth_doc;
                this.lblPoa.Text = this.auth_doc.FileName;
            }
            else if ((this.Session["auth_doc"] != null) && !this.auth_doc.HasFile)
            {
                this.auth_doc = (FileUpload)this.Session["auth_doc"];
                this.lblPoa.Text = this.auth_doc.FileName;
            }
            else if (this.auth_doc.HasFile)
            {
                this.Session["auth_doc"] = this.auth_doc;
                this.lblPoa.Text = this.auth_doc.FileName;
            }
            if ((this.Session["sup_doc1"] == null) && this.sup_doc1.HasFile)
            {
                this.Session["sup_doc1"] = this.sup_doc1;
                this.lblDoc1.Text = this.sup_doc1.FileName;
            }
            else if ((this.Session["sup_doc1"] != null) && !this.sup_doc1.HasFile)
            {
                this.sup_doc1 = (FileUpload)this.Session["sup_doc1"];
                this.lblDoc1.Text = this.sup_doc1.FileName;
            }
            else if (this.sup_doc1.HasFile)
            {
                this.Session["sup_doc1"] = this.sup_doc1;
                this.lblDoc1.Text = this.sup_doc1.FileName;
            }
            if ((this.Session["sup_doc2"] == null) && this.sup_doc2.HasFile)
            {
                this.Session["sup_doc2"] = this.sup_doc2;
                this.lblDoc2.Text = this.sup_doc2.FileName;
            }
            else if ((this.Session["sup_doc2"] != null) && !this.sup_doc2.HasFile)
            {
                this.sup_doc2 = (FileUpload)this.Session["sup_doc2"];
                this.lblDoc2.Text = this.sup_doc2.FileName;
            }
            else if (this.sup_doc2.HasFile)
            {
                this.Session["sup_doc2"] = this.sup_doc2;
                this.lblDoc2.Text = this.sup_doc2.FileName;
            }
        }

        protected void rbDisclaimer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.rbDisclaimer.SelectedValue == "YES")
            {
                this.disclaimer_text = "1";
            }
            else
            {
                this.disclaimer_text = "0";
            }
        }

        protected void SaveAll_Click(object sender, EventArgs e)
        {
            this.SaveAll.Visible = false;
            this.c_app.xname = this.xapplicantname.Value;
            this.c_app.nationality = this.nationality.Text;
            this.c_app.log_staff = this.xpwalletID.Value;
            this.c_app.reg_date = reg_date;
            this.c_app.visible = visible;
            this.c_app.xtime = xtime;
            this.c_app_addy.countryID = this.residence.Text;
            this.c_app_addy.stateID = this.xselectState.Text;
            this.c_app_addy.city = "";
            this.c_app_addy.street = this.xaddress.Text;
            this.c_app_addy.telephone1 = this.xtelephone.Text;
            this.c_app_addy.email1 = this.xemail.Text;
            this.c_app_addy.log_staff = this.xpwalletID.Value;
            this.c_app_addy.reg_date = reg_date;
            this.c_app_addy.visible = visible;
            this.c_app_addy.xtime = xtime;
            this.c_mark.tm_typeID = this.tmType.SelectedValue;
            this.c_mark.logo_descriptionID = this.logo_description.SelectedValue;
            this.c_mark.product_title = this.title_of_product.Text;
            this.c_mark.nice_class = this.national_class.SelectedValue;
            this.c_mark.nice_class_desc = this.nice_class_desc.Text;
            this.c_mark.national_classID = this.national_class.SelectedValue;
            this.c_mark.disclaimer = this.txt_discalimer.Text;
            this.c_mark.log_staff = this.xpwalletID.Value;
            this.c_mark.reg_date = reg_date;
            this.c_mark.xvisible = visible;
            this.c_mark.xtime = xtime;
            this.c_aos.stateID = this.aos_xselectState.Text;
            this.c_aos.city = "";
            this.c_aos.street = this.aos_xaddress.Text;
            this.c_aos.telephone1 = this.aos_xtelephone.Text;
            this.c_aos.email1 = this.aos_xemail.Text;
            this.c_aos.log_staff = this.xpwalletID.Value;
            this.c_aos.reg_date = reg_date;
            this.c_aos.visible = visible;
            this.c_aos.xtime = xtime;
            this.c_rep.agent_code = xcode.Text;
            this.c_rep.xname = this.rep_xname.Text;
            this.c_rep.nationality = this.rep_nationality.SelectedValue;
            this.c_rep.log_staff = this.xpwalletID.Value;
            this.c_rep.reg_date = reg_date;
            this.c_rep.visible = visible;
            this.c_rep.xtime = xtime;
            this.c_rep_addy.countryID = this.rep_residence.SelectedValue;
            this.c_rep_addy.stateID = this.xselectRepState.SelectedValue;
            this.c_rep_addy.city = "";
            this.c_rep_addy.street = this.rep_address.Text;
            this.c_rep_addy.telephone1 = this.rep_xtelephone.Text;
            this.c_rep_addy.email1 = this.rep_xemail.Text;
            this.c_rep_addy.log_staff = this.xpwalletID.Value;
            this.c_rep_addy.reg_date = reg_date;
            this.c_rep_addy.visible = visible;
            this.c_rep_addy.xtime = xtime;

            this.pwalletID = this.xpwalletID.Value;
            this.xmarkID.Value = this.t.addTrademark(this.c_app, this.c_mark, this.c_aos, this.c_rep, this.c_app_addy, this.c_rep_addy, this.log_staffID);
            if (this.xmarkID.Value != "0")
            {
                this.show_image_section = "1";
            }
        }

        protected void SaveDocs_Click(object sender, EventArgs e)
        {
            if (Session["Trademark_item"] != null)
            {
                ti = (cld.Classes.XObjs.Trademark_item)Session["Trademark_item"];
            }

            this.SaveDocs.Visible = false;
            string str = "";
            string str2 = "";
            string str3 = "";
            string path = "";
            int num = 0;
            if ((this.logo_description.SelectedValue != "2") && !this.logo_pic.HasFile)
            {
                this.logo_text = "2";
                num++;
            }
            if (num != 0)
            {
                base.Response.Write("<script language=JavaScript>alert('Please fill in the marked fileds')</script>");
                this.show_image_section = "1";
            }
            else
            {
                if ((this.logo_description.SelectedValue != "2") && this.logo_pic.HasFile)
                {
                    path = this.t.doUploadPic(this.xmarkID.Value, this.xmarkID.Value + ".jpg", base.Server.MapPath("~/") + "admin/tm/Picz/", this.logo_pic);
                }
                if (this.auth_doc.HasFile)
                {
                    str3 = this.t.doUploadDoc(this.xmarkID.Value, base.Server.MapPath("~/") + "admin/tm/docz/", this.auth_doc);
                }
                if (this.sup_doc1.HasFile)
                {
                    str2 = this.t.doUploadDoc(this.xmarkID.Value, base.Server.MapPath("~/") + "admin/tm/docz/", this.sup_doc1);
                }
                if (this.sup_doc2.HasFile)
                {
                    str = this.t.doUploadDoc(this.xmarkID.Value, base.Server.MapPath("~/") + "admin/tm/docz/", this.sup_doc2);
                }
                if (this.logo_description.SelectedValue != "2")
                {
                    if (!File.Exists(path))
                    {
                        this.SaveDocs.Visible = true;
                        this.show_imageMsg = "PLEASE UPLOAD A VALID IMAGE!!";
                    }
                    else
                    {
                        path = path.Replace(base.Server.MapPath("~/") + "admin/tm/", "");
                        str3 = str3.Replace(base.Server.MapPath("~/") + "admin/tm/", "");
                        str2 = str2.Replace(base.Server.MapPath("~/") + "admin/tm/", "");
                        str = str.Replace(base.Server.MapPath("~/") + "admin/tm/", "");
                        if (this.t.updateMarkDocz(path, str3, str2, str, this.xpwalletID.Value) != "0")
                        {
                            if (this.Session["Trademark_item"] == null)
                            {
                              //  this.status = this.t.updateIpoApplicationReferenceStatus(this.xvid.Value, this.xgt.Value, "1");
                                this.status = reg.updateHwallet(ti.hwalletID, "Used", reg_date, ti.product_title).ToString();
                                if (this.status == "1")
                                {
                                    base.Response.Redirect("./tm_acknowledgementx.aspx");
                                }
                                else
                                {
                                   // this.t.cleanseTmByValidation(this.serverpath, this.xvid.Value);
                                   // base.Response.Redirect("http://www.iponigeria.com/userarea/dashboard");
                                }
                            }
                            else
                            {
                                this.status = reg.updateHwallet(ti.hwalletID, "Used", reg_date, ti.product_title).ToString();
                                if (this.status == "1")
                                {
                                    base.Response.Redirect("./tm_acknowledgementx.aspx");
                                }
                            }

                        }
                    }
                }
                else
                {
                    path = path.Replace(base.Server.MapPath("~/") + "admin/tm/", "");
                    str3 = str3.Replace(base.Server.MapPath("~/") + "admin/tm/", "");
                    str2 = str2.Replace(base.Server.MapPath("~/") + "admin/tm/", "");
                    str = str.Replace(base.Server.MapPath("~/") + "admin/tm/", "");
                    if (this.t.updateMarkDocz(path, str3, str2, str, this.xpwalletID.Value) != "0")
                    {
                        if (this.Session["Trademark_item"] == null)
                        {
                           // this.status = this.t.updateIpoApplicationReferenceStatus(this.xvid.Value, this.xgt.Value, "1");
                            this.status = reg.updateHwallet(ti.hwalletID, "Used", reg_date, ti.product_title).ToString();
                            if (this.status == "1")
                            {
                                base.Response.Redirect("./tm_acknowledgementx.aspx");
                            }
                            else
                            {
                               // this.t.cleanseTmByValidation(this.serverpath, this.xvid.Value);
                               // base.Response.Redirect("http://www.iponigeria.com/userarea/dashboard");
                            }
                        }
                        else
                        {
                            this.status = reg.updateHwallet(ti.hwalletID, "Used", reg_date, ti.product_title).ToString();
                            if (this.status == "1")
                            {
                                base.Response.Redirect("./tm_acknowledgementx.aspx");
                            }
                        }
                    }
                }
            }
        }
    }
}

