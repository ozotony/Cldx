namespace cld.admin.tm
{
    using admin ;
    using Classes ;
    using System;
    using System.Collections.Generic;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public class search_data_details : UserControl
    {
        public string admin = "";
        public string admin_status = "3";
        protected Button btnPerformSearch;
        protected Button btnViewSearchReport;
        public tm.AddressService c_aos = new tm.AddressService();
        public tm.Applicant c_app = new tm.Applicant();
        public tm.Address c_app_addy = new tm.Address();
        public zues.MarkInfo c_mark = new zues.MarkInfo();
        public zues.Pwallet c_p = new zues.Pwallet();
        public tm.Representative c_rep = new tm.Representative();
        public tm.Address c_rep_addy = new tm.Address();
        protected TextBox comment;
        public string cri = "";
        protected Label Label1;
        protected Label Label10;
        protected Label Label11;
        protected Label Label12;
        protected Label Label13;
        protected Label Label14;
        protected Label Label19;
        protected Label Label2;
        protected Label Label20;
        protected Label Label21;
        protected Label Label22;
        protected Label Label23;
        protected Label Label25;
        protected Label Label26;
        protected Label Label27;
        protected Label Label28;
        protected Label Label3;
        protected Label Label4;
        protected Label Label5;
        protected Label Label6;
        protected Label Label7;
        protected FileUpload doc1;
        protected FileUpload doc2;
        protected FileUpload doc3;
        public List<zues.TmOffice> lt_tm_office = new List<zues.TmOffice>();
        public zues.Adminz lt_x_admin_details = new zues.Adminz();
        public string pID;
        public string rbval_text = "Search Conducted";
    
        public string search_doc_succ1 = "";
        public string search_doc_succ2 = "";
        public string search_doc_succ3 = "";
        public string succ = "";
        public tm.SWallet swallet = new tm.SWallet();
        public tm t = new tm();
        protected Button Verify;
        public string xcomments = "";
        public string xofficer;
        public zues z = new zues();

        protected void btnPerformSearch_Click(object sender, EventArgs e)
        {
            
           // string ss3 = base.Request.QueryString["x2"].ToString();
            string ss3 = c_mark.product_title.ToUpper();
            string ss4 = c_mark.national_classID;

            Session["x2"] = ss3;
            Session["x3"] = ss4;
            base.Response.Redirect("./searcho.aspx?x=" + this.pID, false);
        }

        protected void btnViewSearchReport_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("./view_searcho.aspx?x=" + this.pID,false);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (base.Request.QueryString["cri"] != null)
            {
                this.cri = base.Request.QueryString["cri"].ToString();
            }
            if (base.Request.QueryString["x"] != null)
            {
                if (Session["pwalletID"] != null)
                {
                    if (Session["pwalletID"].ToString() != "")
                    {
                        this.admin = Session["pwalletID"].ToString();
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
                this.pID = base.Request.QueryString["x"].ToString();
                Session["appID"] = base.Request.QueryString["x"].ToString();
                this.swallet = this.t.getSwalletByID(this.pID);
                this.c_mark = this.z.getMarkInfoByUserID(this.pID);
                this.c_p = this.z.getPwalletDetailsByID(this.c_mark.log_staff);
                this.c_app = this.t.getApplicantByUserID(this.c_p.ID);
                this.c_aos = this.t.getAddressServiceByID(this.c_p.ID);
                this.c_rep = this.t.getRepByUserID(this.c_p.ID);
                if ((c_app.addressID != null) && (c_app.addressID != "") && (c_app.addressID != "0"))
                {
                    this.c_app_addy = this.t.getAddressClassByID(this.c_app.addressID);
                }
                if ((c_rep.addressID != null) && (c_rep.addressID != "") && (c_rep.addressID != "0"))
                {
                    this.c_rep_addy = this.t.getAddressClassByID(this.c_rep.addressID);
                }
                this.lt_tm_office = this.z.getTmOfficeDetailsByID(this.c_p.ID);
                for (int i = 0; i < this.lt_tm_office.Count; i++)
                {
                    this.xcomments = this.xcomments + "<tr>";
                    this.xcomments = this.xcomments + "<td align=\"center\" colspan=\"2\">";
                    this.xcomments = this.xcomments + "<strong>" + this.lt_tm_office[i].xcomment.ToUpper() + "</strong><br />";
                    this.lt_x_admin_details = this.z.getTmAdminDetailsByID(this.lt_tm_office[i].xofficer);
                    string xcomments = this.xcomments;
                    this.xcomments = xcomments + "COMMENT BY: <strong>" + this.lt_x_admin_details.xname.ToUpper() + "( " + this.z.getRoleNameByID(this.lt_x_admin_details.xroleID).ToUpper() + " UNIT)</strong><br />   Date: <strong>" + this.lt_tm_office[i].reg_date.ToUpper() + "</strong>";
                    this.xcomments = this.xcomments + "</td>";
                    this.xcomments = this.xcomments + "</tr>";
                    this.xcomments = this.xcomments + "<tr>";
                    this.xcomments = this.xcomments + "<td class=\"coltbbg\" colspan=\"2\" align=\"center\">";
                    this.xcomments = this.xcomments + "&nbsp;";
                    this.xcomments = this.xcomments + "</td>";
                    this.xcomments = this.xcomments + "</tr>";
                }
            }
            else
            {
                base.Response.Redirect("./search_unit/searchprofile.aspx");
            }
        }

        protected void Verify_Click(object sender, EventArgs e)
        {
            string path = base.Server.MapPath("~/") + "admin/tm/search1_docz/";
            int num = 0;
            if (num != 0)
            {
                base.Response.Write("<script language=JavaScript>alert('Please select a valid JPG or PDF document')</script>");
            }
            else
            {
                this.succ = this.z.a_tm_office(this.c_mark.log_staff, this.admin_status, this.rbval_text, this.comment.Text, this.search_doc_succ1, this.search_doc_succ2, this.search_doc_succ3, this.admin);
                if (this.succ != "0")
                {
                    if (this.doc1.HasFile)
                    {
                        this.search_doc_succ1 = this.t.doUploadDocNoLimit(succ, path, this.doc1);
                        this.search_doc_succ1 = this.search_doc_succ1.Replace(base.Server.MapPath("~/") + "admin/tm/", "");
                    }
                    if (this.doc2.HasFile)
                    {
                        this.search_doc_succ2 = this.t.doUploadDocNoLimit(succ, path, this.doc2);
                        this.search_doc_succ2 = this.search_doc_succ2.Replace(base.Server.MapPath("~/") + "admin/tm/", "");
                    }
                    if (this.doc3.HasFile)
                    {
                        this.search_doc_succ3 = this.t.doUploadDocNoLimit(succ, path, this.doc3);
                        this.search_doc_succ3 = this.search_doc_succ3.Replace(base.Server.MapPath("~/") + "admin/tm/", "");
                    }
                    this.t.UpdateTmOfficeDoc(this.search_doc_succ1, this.search_doc_succ2, this.search_doc_succ3, succ);
                    base.Response.Write("<script language=JavaScript>alert('Data updated successfully')</script>");
                    base.Response.Redirect("./search_unit/searchprofile.aspx");
                }
                else
                {
                    base.Response.Write("<script language=JavaScript>alert('Data not verified, Please try again later')</script>");
                }
            }
        }
    }
}

