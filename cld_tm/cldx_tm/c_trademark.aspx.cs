using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using cld.Classes;
using System.IO;

namespace cld
{
    public partial class c_trademark : System.Web.UI.Page
    {
        public string address_text = "";
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
        public string auth_doc_path = "";
        public string auth_doc_text = "";
        public string auth_text = "";
        public tm.AddressService c_aos = new tm.AddressService();
        public tm.Applicant c_app = new tm.Applicant();
        public tm.Address c_app_addy = new tm.Address();
        public tm.MarkInfo c_mark = new tm.MarkInfo();
        public tm.Representative c_rep = new tm.Representative();
        public tm.Address c_rep_addy = new tm.Address();
        public string city_text = "";
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
        public string gt = "";
        public string log_staffID = "0";
        public string logo_desc_text = "";
        public string logo_pic_path = "";
        public string logo_pic_text = "";
        public string logo_text = "";
        public List<tm.State> lt_aos_state;
        public List<tm.NClass> lt_nclass;
        public List<tm.State> lt_rep_state;
        public List<tm.State> lt_state;
        public string name_text = "";
        public string national_class_text = "";
        public int newState;
        public string nice_class_desc_text = "";
        public string pc = "";
        public string pwalletID = "0";
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
        public string show_image_section = "0";
        public string show_imageMsg = "";
        public int showItems;
        public string state_row = "0";
        public string state_text = "";
        public string state_visible = "0";
        public int status;
        public string sup_doc1_path = "";
        public string sup_doc1_text = "";
        public string sup_doc2_path = "";
        public string sup_doc2_text = "";
        
        public string telephone_text = "";
        public string title_of_product_text = "";
        public string tm_type_text = "";
        public string transID = "0";
        public string vid = "";
        public string xdesc_national_class = "0";
        protected string reg_date = DateTime.Today.Date.ToString("yyyy-MM-dd");
        protected string visible = "1";

        public tm t = new tm();
        protected cld.Classes.XObjs.Trademark_item ti = new cld.Classes.XObjs.Trademark_item();
        protected cld.Classes.XObjs.Pwallet c_pwall = new cld.Classes.XObjs.Pwallet();
        protected cld.Classes.XObjs.XMember c_xmem = new cld.Classes.XObjs.XMember();
        protected cld.Classes.XObjs.Address c_addy = new cld.Classes.XObjs.Address();
        protected cld.Classes.Retriever ret = new cld.Classes.Retriever();
        protected cld.Classes.Registration reg = new cld.Classes.Registration();

        protected void ConfirmRepresentativeDetails_Click(object sender, EventArgs e)
        {
            int num = 0;
           
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
            if (Session["Trademark_item"] != null)
            {
                ti = (cld.Classes.XObjs.Trademark_item)Session["Trademark_item"];
                c_pwall = ret.getPwalletByID(ti.xmemberID);
                c_xmem = ret.getMemberByID(c_pwall.xmemberID);
                c_addy = ret.getAddressByID(c_xmem.addressID);

                title_of_product.Text = ti.product_title;
                xname.Text = c_xmem.cname;
                residence.SelectedIndex=Convert.ToInt32(c_addy.countryID)-1;
                xselectState.SelectedIndex = Convert.ToInt32(c_addy.stateID) - 1;
                aos_xselectState.SelectedIndex = Convert.ToInt32(c_addy.stateID) - 1;
                aos_xcity.Text = c_addy.city; 
                aos_xemail.Text = c_addy.email1; xemail.Text = c_addy.email1;
                aos_xtelephone.Text = c_addy.telephone1; xtelephone.Text = c_addy.telephone1;
                aos_xaddress.Text = c_addy.street; xaddress.Text = c_addy.street;
            }
            base.Server.MapPath("~/");
            if (this.Session["aid"] != null)
            {
                this.xaid.Value = this.Session["aid"].ToString();
            }
            else
            {
                base.Response.Redirect("./XPay/C/profile.aspx");
            }
            if (this.Session["vid"] != null)
            {
                this.xvid.Value = this.Session["vid"].ToString();
            }
            else
            {
                base.Response.Redirect("./XPay/C/profile.aspx");
            }
            if (this.Session["amt"] != null)
            {
                this.xamt.Value = this.Session["amt"].ToString();
            }
            else
            {
                base.Response.Redirect("./XPay/C/profile.aspx");
            }
            if (this.Session["gt"] != null)
            {
                this.xgt.Value = this.Session["gt"].ToString();
            }
            else
            {
                base.Response.Redirect("./XPay/C/profile.aspx");
            }
            if (this.Session["pwalletID"] != null)
            {
                this.xpwalletID.Value = this.Session["pwalletID"].ToString();
            }
            if (this.Session["xofficer"] != null)
            {
                this.log_staffID = this.Session["xofficer"].ToString();
            }
            if (this.Session["transID"] != null)
            {
                this.transID = this.Session["transID"].ToString();
            }
            this.Session["xapplication"] = this.xvid.Value;
            if (base.IsPostBack)
            {
                this.lt_state = this.t.getState(this.residence.SelectedValue);
                if (this.lt_state.Count == 0)
                {
                    this.state_row = "1";
                    this.state_visible = "1";
                }              
                this.national_class_desc.Text = this.t.getNationalClassDesc((this.national_class.SelectedIndex + 1).ToString());
            }
            else
            {
               
                this.residence.SelectedIndex = 0x9f;
                this.lt_nclass = this.t.getJNationalClasses();
                this.national_class_desc.Text = this.lt_nclass[0].xdescription.ToString();
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
            this.c_app.xname = this.xname.Text;
            this.c_app.nationality = this.nationality.Text;
            this.c_app.log_staff = this.xpwalletID.Value;
            this.c_app.reg_date = reg_date;
            this.c_app.visible = visible;
            this.c_app_addy.countryID = this.residence.Text;
            this.c_app_addy.stateID = this.xselectState.Text;
            this.c_app_addy.city = "";
            this.c_app_addy.street = this.xaddress.Text;
            this.c_app_addy.telephone1 = this.xtelephone.Text;
            this.c_app_addy.email1 = this.xemail.Text;
            this.c_app_addy.log_staff = this.xpwalletID.Value;
            this.c_app_addy.reg_date = reg_date;
            this.c_app_addy.visible = visible;
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
            this.c_aos.stateID = this.aos_xselectState.Text;
            this.c_aos.city = this.aos_xcity.Text;
            this.c_aos.street = this.aos_xaddress.Text;
            this.c_aos.telephone1 = this.aos_xtelephone.Text;
            this.c_aos.email1 = this.aos_xemail.Text;
            this.c_aos.log_staff = this.xpwalletID.Value;
            this.c_aos.reg_date = reg_date;
            this.c_aos.visible = visible;
            this.c_rep.agent_code = this.xaid.Value;
            this.c_rep.xname = "Not Applicable";
            this.c_rep.nationality ="160";
            this.c_rep.log_staff = this.xpwalletID.Value;
            this.c_rep.reg_date = reg_date;
            this.c_rep.visible = visible;
            this.c_rep_addy.countryID = "160";
            this.c_rep_addy.stateID = "20";
            this.c_rep_addy.street = "Not Applicable";
            this.c_rep_addy.telephone1 = "Not Applicable";
            this.c_rep_addy.email1 = "Not Applicable";
            this.c_rep_addy.log_staff = this.xpwalletID.Value;
            this.c_rep_addy.reg_date = reg_date;
            this.c_rep_addy.visible = visible;

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
                            this.status = reg.updateHwallet(ti.hwalletID, "Used", reg_date, ti.product_title);
                            if (this.status == 1)
                            {                                
                                base.Response.Redirect("./tm_acknowledgement_c.aspx");
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
                        this.status = reg.updateHwallet(ti.hwalletID, "Used", reg_date, ti.product_title);
                        if (this.status == 1)
                        {
                            base.Response.Redirect("./tm_acknowledgement_c.aspx");
                        }
                    }
                }
            }
        }
    }
}