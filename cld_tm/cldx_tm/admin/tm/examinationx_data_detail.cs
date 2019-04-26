namespace cld.admin.tm
{
    using admin ;
    using Classes ;
    using System;
    using System.Collections.Generic;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public class examinationx_data_detail : UserControl
    {
        public string admin = "";
        public string admin_status = "4";
        public tm.AddressService c_aos = new tm.AddressService();
        public tm.Applicant c_app = new tm.Applicant();
        public tm.Address c_app_addy = new tm.Address();
        public zues.MarkInfo c_mark = new zues.MarkInfo();
        public zues.Pwallet c_p = new zues.Pwallet();
        public tm.Representative c_rep = new tm.Representative();
        public tm.Address c_rep_addy = new tm.Address();
        protected TextBox comment;
        public string cri = "";
        public string folderpath = "";
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
        protected FileUpload exam_doc1;
        protected FileUpload exam_doc2;
        protected FileUpload exam_doc3;
        public List<zues.TmOffice> lt_tm_office = new List<zues.TmOffice>();
        public zues.Adminz lt_x_admin_details = new zues.Adminz();
        public string pID;
        public string rbval_text = "";
        protected RadioButtonList rbValid;
        public string succ = "";
        public int show_exam_docs = 0;
        public tm.SWallet swallet = new tm.SWallet();
        public tm.SWallet swallet2 = new tm.SWallet();
        public tm t = new tm();
        protected Button Verify;
        public string xcomments = "";
        public string xofficer;
        public zues z = new zues();

        protected void Page_Load(object sender, EventArgs e)
        {
            Verify.Visible = false;
            if (this.rbValid.SelectedValue == "Registrable")
            {
                this.admin_status = "4";
                Verify.Visible = true;
                show_exam_docs = 1;
            }
            else if (this.rbValid.SelectedValue == "Non-registrable")
            {
                this.admin_status = "4";
                Verify.Visible = true;
                show_exam_docs = 1;
            }
            else if (this.rbValid.SelectedValue == "Re-conduct search")
            {
                this.rbval_text = "Re-conduct search";
                this.admin_status = "2";
                Verify.Visible = true;
                show_exam_docs = 1;
            }

            else if (this.rbValid.SelectedValue == "Re-examine")
            {
                this.rbval_text = "Re-examine";
                this.admin_status = "3";
                Verify.Visible = true;
                show_exam_docs = 1;
            }

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
                this.swallet = this.t.getSwalletByID(this.pID);
                this.swallet2 = this.t.getSwalletByID2(this.pID);
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
                    if (lt_tm_office[i].xdoc1 != "")
                    {
                        this.xcomments = this.xcomments + "<tr>";
                        this.xcomments = this.xcomments + "<td colspan=\"2\" align=\"center\">";
                        this.xcomments = this.xcomments + "View Document 1: <a href=" + lt_tm_office[i].xdoc1 + " target='_blank'>View</a>";
                        this.xcomments = this.xcomments + "</td>";
                        this.xcomments = this.xcomments + "</tr>";
                    }

                    if (lt_tm_office[i].xdoc2 != "")
                    {
                        this.xcomments = this.xcomments + "<tr>";
                        this.xcomments = this.xcomments + "<td colspan=\"2\" align=\"center\">";
                        this.xcomments = this.xcomments + "View Document 2: <a href=" + lt_tm_office[i].xdoc2 + " target='_blank'>View</a>";
                        this.xcomments = this.xcomments + "</td>";
                        this.xcomments = this.xcomments + "</tr>";
                    }

                    if (lt_tm_office[i].xdoc3 != "")
                    {
                        this.xcomments = this.xcomments + "<tr>";
                        this.xcomments = this.xcomments + "<td colspan=\"2\" align=\"center\">";
                        this.xcomments = this.xcomments + "View Document 3: <a href=" + lt_tm_office[i].xdoc3 + " target='_blank'>View</a>";
                        this.xcomments = this.xcomments + "</td>";
                        this.xcomments = this.xcomments + "</tr>";
                    }
                    this.xcomments = this.xcomments + "<tr>";
                    this.xcomments = this.xcomments + "<td class=\"coltbbg\" colspan=\"2\" align=\"center\">";
                    this.xcomments = this.xcomments + "&nbsp;";
                    this.xcomments = this.xcomments + "</td>";
                    this.xcomments = this.xcomments + "</tr>";
                    if (this.lt_tm_office[i].admin_status == "3")
                    {
                        this.xcomments = this.xcomments + "<tr>";
                        this.xcomments = this.xcomments + "<td class=\"coltbbg\" colspan=\"2\" align=\"center\">";
                        this.xcomments = this.xcomments + "--- SUPPORTING SEARCH DOCUMENTS ---";
                        this.xcomments = this.xcomments + "</td>";
                        this.xcomments = this.xcomments + "</tr>";
                        this.xcomments = this.xcomments + "<tr>";
                        this.xcomments = this.xcomments + "<td align=\"right\">";
                        this.xcomments = this.xcomments + "Attached Document:";
                        this.xcomments = this.xcomments + "</td>";
                        this.xcomments = this.xcomments + "<td>";
                        if ((this.swallet.search_str != "")&&(this.swallet.search_str != null))
                        {
                            this.xcomments = this.xcomments + "<a href=view_searcho.aspx?x=" + this.pID + " target='_blank'>View</a>";
                        }
                        else
                        {
                            this.xcomments = this.xcomments + "NONE";
                        }
                        this.xcomments = this.xcomments + "</td>";
                        this.xcomments = this.xcomments + "</tr>";
                        this.xcomments = this.xcomments + "<tr>";
                        this.xcomments = this.xcomments + "<td class=\"coltbbg\" colspan=\"2\" align=\"center\">";
                        this.xcomments = this.xcomments + "&nbsp;";
                        this.xcomments = this.xcomments + "</td>";
                        this.xcomments = this.xcomments + "</tr>";
                    }

                    //////////
                        if (this.lt_tm_office[i].admin_status == "33")
                    {
                        this.xcomments = this.xcomments + "<tr>";
                        this.xcomments = this.xcomments + "<td class=\"coltbbg\" colspan=\"2\" align=\"center\">";
                        this.xcomments = this.xcomments + "--- SUPPORTING SEARCH 2 DOCUMENTS ---";
                        this.xcomments = this.xcomments + "</td>";
                        this.xcomments = this.xcomments + "</tr>";
                        this.xcomments = this.xcomments + "<tr>";
                        this.xcomments = this.xcomments + "<td align=\"right\">";
                        this.xcomments = this.xcomments + "Attached Document:";
                        this.xcomments = this.xcomments + "</td>";
                        this.xcomments = this.xcomments + "<td>";
                        if ((this.swallet2.search_str != "")&&(this.swallet2.search_str != null))
                        {
                            this.xcomments = this.xcomments + "<a href=view_searcho2.aspx?x=" + this.pID + " target='_blank'>View</a>";
                        }
                        else
                        {
                            this.xcomments = this.xcomments + "NONE";
                        }

                        this.xcomments = this.xcomments + "</td>";
                        this.xcomments = this.xcomments + "</tr>";
                       
                        this.xcomments = this.xcomments + "<tr>";
                        this.xcomments = this.xcomments + "<td class=\"coltbbg\" colspan=\"2\" align=\"center\">";
                        this.xcomments = this.xcomments + "&nbsp;";
                        this.xcomments = this.xcomments + "</td>";
                        this.xcomments = this.xcomments + "</tr>";
                    } //////////
                }
            }
            else
            {
                if (this.cri == "n")
                {
                    base.Response.Redirect("./examiners.aspx?x=n");
                }
                else
                {
                    base.Response.Redirect("./examiners.aspx?x=r");
                }
            }
        }

        protected void rbValid_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.rbValid.SelectedValue == "Registrable")
            {
                this.rbval_text = "Registrable";
                this.admin_status = "4";
                Verify.Visible = true;
                show_exam_docs = 1;
            }
            else if (this.rbValid.SelectedValue == "Non-registrable")
            {
                this.rbval_text = "Non-registrable";
                this.admin_status = "4";
                Verify.Visible = true;
                show_exam_docs = 1;
            }
            else if (this.rbValid.SelectedValue == "Re-conduct search")
            {
                this.rbval_text = "Re-conduct search";
                this.admin_status = "2";
                Verify.Visible = true;
                show_exam_docs = 1;
            }

            else if (this.rbValid.SelectedValue == "Re-examine")
            {
                this.rbval_text = "Re-examine";
                this.admin_status = "3";
                Verify.Visible = true;
                show_exam_docs = 1;
            }
        }

        protected void Verify_Click(object sender, EventArgs e)
        {           
            this.succ = this.z.a_tm_office(this.c_mark.log_staff, this.admin_status, this.rbValid.SelectedValue, this.comment.Text, "", "", "", this.admin);
            if (this.succ != "0")
            {
                base.Response.Write("<script language=JavaScript>alert('Data updated successfully')</script>");
                SaveExamDocs(succ);
               
            }
            else
            {
                base.Response.Write("<script language=JavaScript>alert('Data not verified, Please try again later')</script>");
            }
        }

        protected void SaveExamDocs(string tm_officeID)
        {
            string str1 = "";
            string str2 = "";
            string str3 = "";


            if (this.exam_doc1.HasFile)
                {
                    str1 = this.t.doUploadDoc(this.c_mark.log_staff, base.Server.MapPath("~/") + "admin/tm/exam_docz/", this.exam_doc1);
                }
            if (this.exam_doc2.HasFile)
                {
                    str2 = this.t.doUploadDoc(this.c_mark.log_staff, base.Server.MapPath("~/") + "admin/tm/exam_docz/", this.exam_doc2);
                }
            if (this.exam_doc3.HasFile)
                {
                    str3 = this.t.doUploadDoc(this.c_mark.log_staff, base.Server.MapPath("~/") + "admin/tm/exam_docz/", this.exam_doc3);
                }
               
                    str3 = str3.Replace(base.Server.MapPath("~/") + "admin/tm/", "");
                    str2 = str2.Replace(base.Server.MapPath("~/") + "admin/tm/", "");
                    str1 = str1.Replace(base.Server.MapPath("~/") + "admin/tm/", "");
                    if (this.t.UpdateTmOfficeDoc(str1, str2, str3, tm_officeID) > 0)
                    {
                        if (this.cri == "n")
                        {
                            base.Response.Redirect("./Re_examiners.aspx?x=n");
                        }
                        else
                        {
                            base.Response.Redirect("./Re_examiners.aspx?x=r");
                        }

                    }              
        }
    }
}

