using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace cld.admin.tm.x_unit
{
    public partial class add_mark : System.Web.UI.Page
    {
        public string adminID = "";
        public string auth_doc_path = "";
        private string auth_doc_succ = "";
        public string auth_doc_text = "";
        public string disclaimer_text = "0";
        public string enable_Confirm = "0";
        public string enable_Save = "1";
        public string enable_Save_Doc = "1";
        public string logo_desc_text = "";
        public string logo_pic_path = "";
        private string logo_pic_succ = "";
        public string logo_pic_text = "";
        public string logo_text = "0";
        public List<cld.Classes.tm.MarkInfo> lt_app;
        public List<cld.Classes.tm.NClass> lt_nclass;
        public List<cld.Classes.tm.State> lt_state;
        public string mark_infoID = "0";
        public string national_class_text = "";
        public int newState;
        public string nice_class_desc_text = "";
        public string nice_class_text = "";
        public int showItems;
        public string showsucc = "0";
        public string sign_type_text = "";
        public string state_row = "1";
        public string succ_text = "";
        public string sup_doc1_path = "";
        private string sup_doc1_succ = "";
        public string sup_doc1_text = "";
        public string sup_doc2_path = "";
        private string sup_doc2_succ = "";
        public string sup_doc2_text = "";
        public cld.Classes.tm t = new cld.Classes.tm();
        public string title_of_product_text = "";
        public string tm_type_text = "";
        public string updateID;
        public string vienna_classes_text = "";
        public string xcode_text = "";
        public string xdesc_national_class = "0";
        public List<cld.Classes.tm.Stage> lt_pw;
        public cld.Classes.tm.MarkInfo c_mark = new Classes.tm.MarkInfo();

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
                    base.Response.Redirect("../lo.aspx");
                }
            }
            else
            {
                base.Response.Redirect("../lo.aspx");
            }
            if (base.IsPostBack)
            {
                this.national_class_desc.Text = this.t.getNationalClassDesc(this.national_class.SelectedValue);
                this.xdesc_national_class = "1";
                this.showsucc = "0";
            }
            else
            {
                if ((Request.QueryString["0636tghvoh450"] != null) && (Request.QueryString["0636tghvoh450"].ToString() != ""))
                {
                    Session["transID"] = Request.QueryString["0636tghvoh450"].ToString();
                    lt_pw = t.getStageByValidationID(Session["transID"].ToString());
                    if (lt_pw.Count == 0)
                    {
                        Response.Redirect("./app_status.aspx");
                    }
                    else
                    {
                        Session["pwID"] = lt_pw[0].ID;
                        Session["reg_date"] = lt_pw[0].reg_date;
                        Session["stage"] = Convert.ToInt32(lt_pw[0].stage);
                    }
                }

                this.lt_nclass = this.t.getJNationalClasses();
                this.national_class_desc.Text = this.lt_nclass[0].xdescription.ToString();
                this.xdesc_national_class = "1";
                this.showsucc = "0";
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

      
        protected void UpdateApplicant_Click(object sender, EventArgs e)
        {
            string path = base.Server.MapPath("~/") + "admin/tm/Picz/";
            string docpath = base.Server.MapPath("~/") + "admin/tm/docz/";           

            c_mark.disclaimer = txt_discalimer.Text;
            c_mark.log_staff = Session["pwID"].ToString();
            c_mark.logo_descriptionID = logo_description.SelectedValue;
            c_mark.reg_date = Session["reg_date"].ToString();
            c_mark.xvisible = "1";
            c_mark.tm_typeID = tmType.SelectedValue;
            c_mark.product_title = title_of_product.Text;
            c_mark.nice_class = national_class.SelectedValue;
            c_mark.nice_class_desc = nice_class_desc.Text;
            c_mark.national_classID = national_class.SelectedValue;

            this.updateID = this.t.addMark(c_mark, adminID);           

            if (Convert.ToInt32(this.updateID) > 0)
            {
                if ((Session["pwID"] != null) && (Session["pwalletID"] != null) && (Session["stage"] != null) && (Session["reg_date"] != null))
                {
                    string yr = Session["reg_date"].ToString().Substring(0,4);
                    t.updateOldDateMarkReg(updateID, c_mark.tm_typeID,yr);
                    t.updatePwalletStage(Session["pwID"].ToString(), Session["pwalletID"].ToString(), Session["stage"].ToString());

                    if (this.logo_pic.HasFile)
                    {
                        this.logo_pic_succ = this.t.doUploadDoc(updateID, path, this.logo_pic);
                        this.logo_pic_succ = this.logo_pic_succ.Replace(base.Server.MapPath("~/") + "admin/tm/", "");
                        this.t.UpdateMarkLogo(this.logo_pic_succ, updateID);
                    }
                    if (this.auth_doc.HasFile)
                    {
                        this.auth_doc_succ = this.t.doUploadDoc(updateID, docpath, this.auth_doc);
                        this.auth_doc_succ = this.auth_doc_succ.Replace(base.Server.MapPath("~/") + "admin/tm/", "");
                        this.t.UpdateMarkAuth(this.auth_doc_succ, updateID);
                    }
                    if (this.sup_doc1.HasFile)
                    {
                        this.sup_doc1_succ = this.t.doUploadDoc(updateID, docpath, this.sup_doc1);
                        this.sup_doc1_succ = this.sup_doc1_succ.Replace(base.Server.MapPath("~/") + "admin/tm/", "");
                        this.t.UpdateMarkSupDoc1(this.sup_doc1_succ, updateID);
                    }
                    if (this.sup_doc2.HasFile)
                    {
                        this.sup_doc2_succ = this.t.doUploadDoc(updateID, docpath, this.sup_doc2);
                        this.sup_doc2_succ = this.sup_doc2_succ.Replace(base.Server.MapPath("~/") + "admin/tm/", "");
                        this.t.UpdateMarkSupDoc2(this.sup_doc2_succ, updateID);
                    }
                    this.succ_text = "THE TRADE MARK HAS BEEN ADDED SUCCESSFULLY!!";
                    this.showsucc = "1";
                    
                }
            }
        }

        protected void Back_Click(object sender, EventArgs e)
        {
            Session["pwID"] = null; Session["stage"] = null; Session["reg_date"] = null;
            Response.Redirect("./app_status.aspx");
        }

        protected void BackProfile_Click(object sender, EventArgs e)
        {
            Session["pwID"] = null; Session["stage"] = null; Session["reg_date"] = null;
            Response.Redirect("./profile.aspx");
        }
    }
}