using cld.admin;
using cld.Classes;
using Odyssey;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace cld.admin.tm.verification_unit
{
    using Classes;
    public partial class g_application_details : Page
    {
        public string admin = "4";
        public string admin_status = "2";
        protected int app_succ;
        protected int applicant_succ;
        protected int ass_show;
        public Email c_email = new Email();
        protected int cert_show;
        protected int change_show;
        public List<XObjs.Fee_list> fee_list = new List<XObjs.Fee_list>();
        public int file_len = 0x400;
        public string file_string = "Xavier";
        public XObjs.Gen_Agent_info g_agent_info = new XObjs.Gen_Agent_info();
        public XObjs.G_App_info g_app_info = new XObjs.G_App_info();
        public XObjs.G_Applicant_info g_applicant_info = new XObjs.G_Applicant_info();
        public XObjs.G_Ass_info g_ass_info = new XObjs.G_Ass_info();
        public XObjs.G_Cert_info g_cert_info = new XObjs.G_Cert_info();
        public XObjs.G_Change_info g_change_info = new XObjs.G_Change_info();
        public XObjs.G_Merger_info g_merger_info = new XObjs.G_Merger_info();
        public XObjs.G_Other_items_info g_other_items_info = new XObjs.G_Other_items_info();
        public XObjs.G_Prelim_search_info g_prelim_search_info = new XObjs.G_Prelim_search_info();
        public XObjs.G_Pwallet g_pwallet = new XObjs.G_Pwallet();
        public XObjs.G_Renewal_info g_renewal_info = new XObjs.G_Renewal_info();
        public XObjs.G_Tm_info g_tm_info = new XObjs.G_Tm_info();
        public string html_msg = "";
        public zues.Adminz lt_cur_admin_details = new zues.Adminz();
        public List<zues.G_TmOffice> lt_g_tm_office = new List<zues.G_TmOffice>();
        public zues.Adminz lt_x_admin_details = new zues.Adminz();
        protected int merger_show;
        public Odyssey.Odyssey ody = new Odyssey.Odyssey();
        protected int others_show;
        public string pID;
        protected int prelim_show;
        public string pwalletID = "0";
        public string rbval_text = "";
        protected int renewal_show;
        public Retriever ret = new Retriever();
        public string serverpath = "";
        public string status = "0";
        public string succ;
        public tm t = new tm();
        protected int tm_info_succ;
        public string vid;
        protected int x_succ;
        public string xcomments = "";
        public string xofficer;
        public zues z = new zues();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.serverpath = base.Server.MapPath("~/");
            string path = this.serverpath + @"Handlers\bf.kez";
            if (File.Exists(path))
            {
                StreamReader reader = new StreamReader(path, true);
                this.file_string = reader.ReadToEnd();
                reader.Close();
                if (this.file_string != null)
                {
                    string oldValue = this.file_string.Substring(0, this.file_string.IndexOf("</BitStrength>") + 14);
                    this.file_string = this.file_string.Replace(oldValue, "");
                }
            }
            this.Verify.Visible = false;
            if (this.rbValid.SelectedValue == "Valid")
            {
                this.rbval_text = "New";
                this.Verify.Visible = true;
            }
            else if (this.rbValid.SelectedValue == "Invalid")
            {
                this.rbval_text = "Invalid";
                this.Verify.Visible = true;
            }
            this.PopulateOffice(this.admin);
            if (this.Session["pwalletID"] != null)
            {
                if (this.Session["pwalletID"].ToString() != "")
                {
                    this.admin = this.Session["pwalletID"].ToString();
                    this.PopulateOffice(this.admin);
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
            this.fee_list = this.ret.getFee_listByCat("tm");
            if ((base.Request.QueryString["x"] != null) && (base.Request.QueryString["x"] != ""))
            {
                this.vid = base.Request.QueryString["x"];
                this.g_pwallet = this.ret.getG_PwalletByID(this.vid);
                if ((this.g_pwallet.xid != null) && (this.g_pwallet.xid != ""))
                {
                    this.Session["xid"] = this.g_pwallet.xid;
                    this.Session["validationID"] = this.g_pwallet.validationID;
                    this.lt_cur_admin_details = this.z.getTmAdminDetailsByID(this.admin);
                    if ((this.lt_cur_admin_details.xID != null) && (this.lt_cur_admin_details.xID != ""))
                    {
                        this.Session["lt_cur_admin_details"] = this.lt_cur_admin_details;
                    }
                    this.g_tm_info = this.ret.getG_Tm_infoByPwalletID(this.g_pwallet.xid);
                    if ((this.g_tm_info.xid != null) && (this.g_tm_info.xid != ""))
                    {
                        this.Session["g_tm_info"] = this.g_tm_info;
                    }
                    this.g_app_info = this.ret.getG_App_infoByPwalletID(this.g_pwallet.xid);
                    if ((this.g_app_info.id != null) && (this.g_app_info.id != ""))
                    {
                        this.Session["g_app_info"] = this.g_app_info;
                    }
                    this.g_applicant_info = this.ret.getG_Applicant_infoByPwalletID(this.g_pwallet.xid);
                    if ((this.g_applicant_info.id != null) && (this.g_applicant_info.id != ""))
                    {
                        this.Session["g_applicant_info"] = this.g_applicant_info;
                    }
                    this.g_agent_info = this.ret.getGenAgentByPwalletID(this.g_pwallet.xid);
                    if ((this.g_agent_info.xid != null) && (this.g_agent_info.xid != ""))
                    {
                        this.Session["g_agent_info"] = this.g_agent_info;
                    }
                    this.g_ass_info = this.ret.getG_Ass_infoByPwalletID(this.g_pwallet.xid);
                    if ((this.g_ass_info.xid != null) && (this.g_ass_info.xid != ""))
                    {
                        this.Session["g_ass_info"] = this.g_ass_info;
                    }
                    this.g_cert_info = this.ret.getG_Cert_infoByPwalletID(this.g_pwallet.xid);
                    if ((this.g_cert_info.xid != null) && (this.g_cert_info.xid != ""))
                    {
                        this.Session["g_cert_info"] = this.g_cert_info;
                    }
                    this.g_change_info = this.ret.getG_Change_infoByPwalletID(this.g_pwallet.xid);
                    if ((this.g_change_info.xid != null) && (this.g_change_info.xid != ""))
                    {
                        this.Session["g_change_info"] = this.g_change_info;
                    }
                    this.g_merger_info = this.ret.getG_Merger_infoByPwalletID(this.g_pwallet.xid);
                    if ((this.g_merger_info.xid != null) && (this.g_merger_info.xid != ""))
                    {
                        this.Session["g_merger_info"] = this.g_merger_info;
                    }
                    this.g_renewal_info = this.ret.getG_Renewal_infoByPwalletID(this.g_pwallet.xid);
                    if ((this.g_renewal_info.xid != null) && (this.g_renewal_info.xid != ""))
                    {
                        this.Session["g_renewal_info"] = this.g_renewal_info;
                    }
                    this.g_prelim_search_info = this.ret.getG_Prelim_search_infoByPwalletID(this.g_pwallet.xid);
                    if ((this.g_prelim_search_info.xid != null) && (this.g_prelim_search_info.xid != ""))
                    {
                        this.Session["g_prelim_search_info"] = this.g_prelim_search_info;
                    }
                    this.g_other_items_info = this.ret.getG_Other_items_infoByPwalletID(this.g_pwallet.xid);
                    if ((this.g_other_items_info.xid != null) && (this.g_other_items_info.xid != ""))
                    {
                        this.Session["g_other_items_info"] = this.g_other_items_info;
                    }
                    this.lt_g_tm_office = this.z.getG_TmOfficeDetailsByID(this.g_pwallet.xid);
                    if (this.lt_g_tm_office.Count > 0)
                    {
                        this.Session["lt_g_tm_office"] = this.lt_g_tm_office;
                    }
                    if ((this.g_tm_info.xid != null) && (this.g_tm_info.xid != ""))
                    {
                        string str3 = "../../../admin/tm/gf/";
                        this.xcomments = this.xcomments + "<tr>";
                        this.xcomments = this.xcomments + "<td colspan=\"4\" align=\"center\" class=\"tbbg\">";
                        this.xcomments = this.xcomments + "--- UPLOADED DOCUMENTS ---";
                        this.xcomments = this.xcomments + "</td>";
                        this.xcomments = this.xcomments + "</tr>";
                        if (this.g_tm_info.logo_pic != "")
                        {
                            this.xcomments = this.xcomments + "<tr>";
                            this.xcomments = this.xcomments + "<td colspan=\"4\" align=\"center\">";
                            this.xcomments = this.xcomments + "<a href=" + str3 + this.g_tm_info.logo_pic + " target='_blank'>VIEW TRADEMARK REPRESENTATION</a>";
                            this.xcomments = this.xcomments + "</td>";
                            this.xcomments = this.xcomments + "</tr>";
                        }
                        if (this.g_tm_info.app_letter_doc != "")
                        {
                            this.xcomments = this.xcomments + "<tr>";
                            this.xcomments = this.xcomments + "<td colspan=\"4\" align=\"center\">";
                            this.xcomments = this.xcomments + "<a href=" + str3 + this.g_tm_info.app_letter_doc + " target='_blank'>VIEW APPLICATION LETTER</a>";
                            this.xcomments = this.xcomments + "</td>";
                            this.xcomments = this.xcomments + "</tr>";
                        }
                        if (this.g_tm_info.sup_doc1 != "")
                        {
                            this.xcomments = this.xcomments + "<tr>";
                            this.xcomments = this.xcomments + "<td colspan=\"4\" align=\"center\">";
                            this.xcomments = this.xcomments + "<a href=" + str3 + this.g_tm_info.sup_doc1 + " target='_blank'>VIEW SUPPORTING DOCUMENT</a>";
                            this.xcomments = this.xcomments + "</td>";
                            this.xcomments = this.xcomments + "</tr>";
                        }
                        if ((this.g_cert_info.cert_doc != null) && (this.g_cert_info.cert_doc != ""))
                        {
                            this.xcomments = this.xcomments + "<tr>";
                            this.xcomments = this.xcomments + "<td colspan=\"4\" align=\"center\">";
                            this.xcomments = this.xcomments + "<a href=" + str3 + this.g_cert_info.cert_doc + " target='_blank'>VIEW COPY OF CERTIFICATE</a>";
                            this.xcomments = this.xcomments + "</td>";
                            this.xcomments = this.xcomments + "</tr>";
                        }
                        if ((this.g_ass_info.ass_doc != null) && (this.g_ass_info.ass_doc != ""))
                        {
                            this.xcomments = this.xcomments + "<tr>";
                            this.xcomments = this.xcomments + "<td colspan=\"4\" align=\"center\">";
                            this.xcomments = this.xcomments + "<a href=" + str3 + this.g_ass_info.ass_doc + " target='_blank'>VIEW COPY OF ASSIGNMENT</a>";
                            this.xcomments = this.xcomments + "</td>";
                            this.xcomments = this.xcomments + "</tr>";
                        }
                        if ((this.g_merger_info.merger_doc != null) && (this.g_merger_info.merger_doc != ""))
                        {
                            this.xcomments = this.xcomments + "<tr>";
                            this.xcomments = this.xcomments + "<td colspan=\"4\" align=\"center\">";
                            this.xcomments = this.xcomments + "<a href=" + str3 + this.g_merger_info.merger_doc + " target='_blank'>VIEW COPY OF MERGER</a>";
                            this.xcomments = this.xcomments + "</td>";
                            this.xcomments = this.xcomments + "</tr>";
                        }
                        if ((this.g_cert_info.pub_doc != null) && (this.g_cert_info.pub_doc != ""))
                        {
                            this.xcomments = this.xcomments + "<tr>";
                            this.xcomments = this.xcomments + "<td colspan=\"4\" align=\"center\">";
                            this.xcomments = this.xcomments + "<a href=" + str3 + this.g_cert_info.pub_doc + " target='_blank'>VIEW COPY OF PUBLICATION</a>";
                            this.xcomments = this.xcomments + "</td>";
                            this.xcomments = this.xcomments + "</tr>";
                        }
                        this.xcomments = this.xcomments + "<tr>";
                        this.xcomments = this.xcomments + "<td class=\"coltbbg\" colspan=\"4\" align=\"center\">";
                        this.xcomments = this.xcomments + "&nbsp;";
                        this.xcomments = this.xcomments + "</td>";
                        this.xcomments = this.xcomments + "</tr>";
                    }
                    foreach (XObjs.Fee_list _list in this.fee_list)
                    {
                        if (_list.item_code == this.g_pwallet.log_officer)
                        {
                            this.lbl_type.Text = _list.item.ToUpper();
                        }
                    }
                    this.ShowSection(this.g_pwallet.log_officer);
                }
                else
                {
                    base.Response.Redirect("./g_applications.aspx");
                }
            }
            else if (this.Session["pwalletID"] != null)
            {
                this.pwalletID = this.Session["pwalletID"].ToString();
            }
        }

        public void PopulateOffice(string admin)
        {
            string str = this.z.getRoleNameByID(this.z.getAdminDetails(admin).xroleID).Trim();
            if ((str != null) && (str != ""))
            {
                if (str == "Verification")
                {
                    this.Session["Office"] = str;
                    this.Session["OfficeID"] = "1";
                }
                if (str == "Search")
                {
                    this.Session["Office"] = str;
                    this.Session["OfficeID"] = "2";
                }
                if (str == "Opposition")
                {
                    this.Session["Office"] = str;
                    this.Session["OfficeID"] = "3";
                }
                if (str == "Certificate")
                {
                    this.Session["Office"] = str;
                    this.Session["OfficeID"] = "4";
                }
                if (str == "Acceptance")
                {
                    this.Session["Office"] = str;
                    this.Session["OfficeID"] = "5";
                }
            }
        }

        protected void rbValid_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.rbValid.SelectedValue == "Valid")
            {
                this.rbval_text = "New";
                this.Verify.Visible = true;
            }
            else if (this.rbValid.SelectedValue == "Invalid")
            {
                this.rbval_text = "Invalid";
                this.Verify.Visible = true;
            }
        }

        public void ShowSection(string item_code)
        {
            if (item_code == "T001")
            {
                this.prelim_show = 1;
                this.Session["item_code"] = item_code;
            }
            else if (item_code == "T003")
            {
                this.cert_show = 1;
                this.Session["item_code"] = item_code;
            }
            else if (item_code == "T008")
            {
                this.change_show = 1;
                this.Session["item_code"] = item_code;
            }
            else if (item_code == "T009")
            {
                this.renewal_show = 1;
                this.Session["item_code"] = item_code;
            }
            else if (item_code == "T014")
            {
                this.ass_show = 1;
                this.merger_show = 1;
                this.Session["item_code"] = item_code;
            }
            else if ((((item_code != "T001") && (item_code != "T002")) && ((item_code != "T003") && (item_code != "T008"))) && ((item_code != "T009") && (item_code != "T014")))
            {
                this.others_show = 1;
                this.Session["item_code"] = item_code;
            }
        }

        protected void Verify_Click(object sender, EventArgs e)
        {
            if (this.rbValid.SelectedValue == "Valid")
            {
                this.succ = this.z.a_g_tm_office(this.Session["xid"].ToString(), this.selectDestinationUnit.SelectedValue, this.rbval_text, this.comment.Text, "", "", "", this.admin);
            }
            else if (this.rbValid.SelectedValue == "Invalid")
            {
                this.succ = this.z.a_g_tm_office(this.Session["xid"].ToString(), "1", this.rbval_text, this.comment.Text, "", "", "", this.admin);
            }
            if (this.succ != "0")
            {
                string str = "";
                string from = "";
                if (this.Session["g_agent_info"] != null)
                {
                    this.g_agent_info = (XObjs.Gen_Agent_info)this.Session["g_agent_info"];
                }
                if (this.Session["lt_cur_admin_details"] != null)
                {
                    this.lt_cur_admin_details = (zues.Adminz)this.Session["lt_cur_admin_details"];
                    from = this.ody.DecryptString(this.lt_cur_admin_details.xemail, this.file_len, this.file_string);
                }
                this.Session["g_officeID"] = this.succ;
                if (this.Session["validationID"] != null)
                {
                    str = this.Session["validationID"].ToString();
                }
                string str3 = this.z.getRoleNameByID(this.lt_cur_admin_details.xroleID);
                string subject = "Message from the \"" + str3 + " Unit\" concerning the application with trasaction ID: " + str;
                if (this.Session["Office"] != null)
                {
                    this.Session["Office"].ToString();
                }
                this.html_msg = this.html_msg + "Dear " + this.g_agent_info.xname + ",<br/>";
                this.html_msg = this.html_msg + "Your application has currently been sent to the " + this.selectDestinationUnit.SelectedItem.Text + " Unit<br/>";
                this.html_msg = this.html_msg + "Regards,<br/>";
                string str5 = this.html_msg;
                this.html_msg = str5 + this.lt_cur_admin_details.xname + "(" + str3 + " Unit)";
                if (((this.g_agent_info.email != null) && (this.g_agent_info.email != "")) && ((from != null) && (from != "")))
                {
                    this.c_email.sendMail("CLD " + str3 + " Unit Notification", this.g_agent_info.email, from, subject, this.html_msg, "");
                }
                base.Response.Write("<script language=JavaScript>alert('Data verified successfully')</script>");
                base.Response.Redirect("./g_applications.aspx");
            }
            else
            {
                base.Response.Write("<script language=JavaScript>alert('Data not verified, Please try again later')</script>");
            }
        }
    }
}