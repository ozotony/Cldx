namespace cld.admin.tm
{
    using Classes ;
    using System;
    using System.Collections.Generic;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class edit_mark : Page
    {
        public string adminID = "";
        protected Label appID;
        protected FileUpload auth_doc;
        protected Label auth_doc_lbl;
        public string auth_doc_path = "";
        private string auth_doc_succ = "";
        public string auth_doc_text = "";
        public string disclaimer_text = "0";
        protected SqlDataSource ds_LogoDescription;
        protected SqlDataSource ds_NationalClass;
        protected SqlDataSource ds_TmType;
        public string enable_Confirm = "0";
        public string enable_Save = "1";
        public string enable_Save_Doc = "1";
        protected HtmlForm form1;
        public string logo_desc_text = "";
        protected DropDownList logo_description;
        protected FileUpload logo_pic;
        protected Label logo_pic_lbl;
        public string logo_pic_path = "";
        private string logo_pic_succ = "";
        public string logo_pic_text = "";
        public string logo_text = "0";
        public List<updateX.MarkInfo> lt_app;
        public List<updateX.NClass> lt_nclass;
        public List<updateX.State> lt_state;
        public string mark_infoID = "0";
        protected DropDownList national_class;
        protected Label national_class_desc;
        public string national_class_text = "";
        public int newState;
        protected TextBox nice_class;
        protected TextBox nice_class_desc;
        public string nice_class_desc_text = "";
        public string nice_class_text = "";
        protected RadioButtonList rbDisclaimer;
        protected Button SearchApplicant;
        protected TextBox searchno;
        public int showItems;
        public string showsearch = "0";
        public string showsucc = "0";
        public string showupdateform = "0";
        protected TextBox sign_type;
        public string sign_type_text = "";
        public string state_row = "0";
        public string succ_text = "";
        protected FileUpload sup_doc1;
        protected Label sup_doc1_lbl;
        public string sup_doc1_path = "";
        private string sup_doc1_succ = "";
        public string sup_doc1_text = "";
        protected FileUpload sup_doc2;
        protected Label sup_doc2_lbl;
        public string sup_doc2_path = "";
        private string sup_doc2_succ = "";
        public string sup_doc2_text = "";
        public updateX t = new updateX();
        protected TextBox title_of_product;
        public string title_of_product_text = "";
        public string tm_type_text = "";
        protected DropDownList tmType;
        protected TextBox txt_discalimer;
        protected Button UpdateApplicant;
        public int updateID;
        protected TextBox vienna_classes;
        public string vienna_classes_text = "";
        public string xcode_text = "";
        public string xdesc_national_class = "0";

        protected void logo_description_SelectedIndexChanged(object sender, EventArgs e)
        {
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
            this.national_class_desc.Text = this.t.getNationalClassDesc(this.national_class.SelectedValue);
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
                this.logo_text = "0";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["pwalletID"] != null)
            {
                if (this.Session["pwalletID"].ToString() != "")
                {
                    this.adminID = this.Session["pwalletID"].ToString();
                }
                else
                {
                    base.Response.Redirect("./xcontrol.aspx");
                }
            }
            else
            {
                base.Response.Redirect("./xcontrol.aspx");
            }
            if (base.IsPostBack)
            {
                this.national_class_desc.Text = this.t.getNationalClassDesc(this.national_class.SelectedValue);
                this.xdesc_national_class = "1";
                this.showsucc = "0";
                this.showsearch = "0";
                this.showupdateform = "1";
            }
            else
            {
                this.lt_nclass = this.t.getJNationalClasses();
                this.national_class_desc.Text = this.lt_nclass[0].xdescription.ToString();
                this.xdesc_national_class = "1";
                this.showsucc = "0";
                this.showsearch = "1";
                this.showupdateform = "0";
            }
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
                this.logo_text = "0";
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
            if (this.logo_description.SelectedValue != "2")
            {
                this.logo_text = "1";
            }
            else
            {
                this.logo_text = "0";
            }
        }

        protected void SearchApplicant_Click(object sender, EventArgs e)
        {
            this.state_row = "0";
            if (this.searchno.Text != "")
            {
                if (this.searchno.Text.Contains("OAI/TM/"))
                {
                    this.searchno.Text = this.searchno.Text.Replace("OAI/TM/", "");
                }
                this.lt_app = this.t.getMarkByRefID(this.searchno.Text);
                if (this.lt_app.Count > 0)
                {
                    if (this.lt_app.Count > 1)
                    {
                        for (int i = 1; i <= this.lt_app.Count; i++)
                        {
                            this.t.deleteMarkInfo(this.lt_app[i].xID);
                            this.lt_app.RemoveAt(i);
                        }
                    }
                    this.appID.Text = this.lt_app[0].xID;
                    this.title_of_product.Text = this.lt_app[0].product_title;
                    this.nice_class.Text = this.lt_app[0].nice_class;
                    this.nice_class_desc.Text = this.lt_app[0].nice_class_desc;
                    this.sign_type.Text = this.lt_app[0].sign_type;
                    this.vienna_classes.Text = this.lt_app[0].vienna_class;
                    this.txt_discalimer.Text = this.lt_app[0].disclaimer;
                    if (this.lt_app[0].disclaimer != "")
                    {
                        this.rbDisclaimer.SelectedValue = "YES";
                        this.disclaimer_text = "1";
                    }
                    this.tmType.SelectedIndex = Convert.ToInt32(this.lt_app[0].tm_typeID) - 1;
                    this.logo_description.SelectedIndex = Convert.ToInt32(this.lt_app[0].logo_descriptionID) - 1;
                    this.national_class.SelectedIndex = Convert.ToInt32(this.lt_app[0].national_classID) - 1;
                    this.national_class_desc.Text = this.t.getNationalClassDesc(this.lt_app[0].national_classID);
                    this.xdesc_national_class = "1";
                    if (this.logo_description.SelectedValue != "2")
                    {
                        this.logo_text = "1";
                    }
                    else
                    {
                        this.logo_text = "0";
                    }
                    if (this.lt_app[0].logo_pic != "")
                    {
                        this.logo_pic_lbl.Text = this.lt_app[0].logo_pic;
                    }
                    if (this.lt_app[0].auth_doc != "")
                    {
                        this.auth_doc_lbl.Text = this.lt_app[0].auth_doc;
                    }
                    if (this.lt_app[0].sup_doc1 != "")
                    {
                        this.sup_doc1_lbl.Text = this.lt_app[0].sup_doc1;
                    }
                    if (this.lt_app[0].sup_doc2 != "")
                    {
                        this.sup_doc2_lbl.Text = this.lt_app[0].sup_doc2;
                    }
                    this.showsucc = "0";
                    this.showsearch = "0";
                    this.showupdateform = "1";
                }
                else
                {
                    this.showsucc = "1";
                    this.showsearch = "1";
                    this.showupdateform = "0";
                    this.succ_text = "PLEASE CROSS CHECK THE REFERENCE NUMBER AND SEARCH AGAIN";
                }
            }
        }

        protected void UpdateApplicant_Click(object sender, EventArgs e)
        {
            this.updateID = this.t.UpdateMark(this.tmType.SelectedValue, this.logo_description.SelectedValue, this.title_of_product.Text, this.nice_class.Text, this.nice_class_desc.Text, this.national_class.SelectedValue, this.sign_type.Text, this.vienna_classes.Text, this.txt_discalimer.Text, this.appID.Text);
            string path = base.Server.MapPath("~/") + "admin/tm/Picz/";
            string str2 = base.Server.MapPath("~/") + "admin/tm/docz/";
            string oldpath = base.Server.MapPath("~/") + "admin/tm/" + this.logo_pic_lbl.Text;
            string str4 = base.Server.MapPath("~/") + "admin/tm/" + this.auth_doc_lbl.Text;
            string str5 = base.Server.MapPath("~/") + "admin/tm/" + this.sup_doc1_lbl.Text;
            string str6 = base.Server.MapPath("~/") + "admin/tm/" + this.sup_doc2_lbl.Text;
            if (this.updateID > 0)
            {
                if (this.logo_pic.HasFile)
                {
                    this.logo_pic_succ = this.t.doUploadUpDoc(this.appID.Text, path, oldpath, this.logo_pic);
                    this.logo_pic_succ = this.logo_pic_succ.Replace(base.Server.MapPath("~/") + "admin/tm/", "");
                    this.t.UpdateMarkLogo(this.logo_pic_succ, this.appID.Text);
                }
                if (this.auth_doc.HasFile)
                {
                    this.auth_doc_succ = this.t.doUploadUpDoc(this.appID.Text, str2, str4, this.auth_doc);
                    this.auth_doc_succ = this.auth_doc_succ.Replace(base.Server.MapPath("~/") + "admin/tm/", "");
                    this.t.UpdateMarkAuth(this.auth_doc_succ, this.appID.Text);
                }
                if (this.sup_doc1.HasFile)
                {
                    this.sup_doc1_succ = this.t.doUploadUpDoc(this.appID.Text, str2, str5, this.sup_doc1);
                    this.sup_doc1_succ = this.sup_doc1_succ.Replace(base.Server.MapPath("~/") + "admin/tm/", "");
                    this.t.UpdateMarkSupDoc1(this.sup_doc1_succ, this.appID.Text);
                }
                if (this.sup_doc2.HasFile)
                {
                    this.sup_doc2_succ = this.t.doUploadUpDoc(this.appID.Text, str2, str6, this.sup_doc2);
                    this.sup_doc2_succ = this.sup_doc2_succ.Replace(base.Server.MapPath("~/") + "admin/tm/", "");
                    this.t.UpdateMarkSupDoc2(this.sup_doc2_succ, this.appID.Text);
                }
                this.succ_text = "THE MARK DATA HAS BEEN UPDATED SUCCESSFULLY!!";
                this.showsucc = "1";
                this.showsearch = "1";
                this.showupdateform = "0";
            }
        }
    }
}

