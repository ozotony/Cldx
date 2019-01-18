    using Odyssey;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

namespace cld.admin.tm.generic
{
    using Classes;
    public partial class g_application_details : Page
    {

        public string admin = "";
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
        public string vreg_no = "";
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
        public string item_code = "";
        public string code_title = "";
        protected UserDocs c_ud = new UserDocs();


        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["item_code"] != null) && (Session["item_code"] != null)) { item_code = Session["item_code"].ToString(); }
            if ((Session["code_title"] != null) && (Session["code_title"] != null)) { code_title = Session["code_title"].ToString(); }
            serverpath = base.Server.MapPath("~/");
            string path = serverpath + @"Handlers\bf.kez";
            if (File.Exists(path))
            {
                StreamReader reader = new StreamReader(path, true);
                file_string = reader.ReadToEnd();
                reader.Close();
                if (file_string != null)
                {
                    string oldValue = file_string.Substring(0, file_string.IndexOf("</BitStrength>") + 14);
                    file_string = file_string.Replace(oldValue, "");
                }
            }
            Verify.Visible = false;
            if (rbValid.SelectedValue == "Treated")
            {
                rbval_text = "Treated";
                Verify.Visible = true;
            }
            else if (rbValid.SelectedValue == "Kiv")
            {
                rbval_text = "Kiv";
                Verify.Visible = true;
            }
            else if (rbValid.SelectedValue == "Contact")
            {
                rbval_text = "Contact";
                Verify.Visible = true;
            }
            if (Session["pwalletID"] != null)
            {
                if (Session["pwalletID"].ToString() != "")
                {
                    admin = Session["pwalletID"].ToString();
                    PopulateOffice(admin);
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
            fee_list = ret.getFee_listByCat("tm");
            if (!Page.IsPostBack)
            {
                if ((base.Request.QueryString["x"] == null) || (base.Request.QueryString["x"] == ""))
                {
                    base.Response.Redirect("./g_application.aspx");
                }
                else
                {
                    vid = base.Request.QueryString["x"];
                    g_pwallet = ret.getG_PwalletByID(vid);
                   
                    if ((g_pwallet.xid != null) && (g_pwallet.xid != ""))
                    {
                        Session["g_pwallet"] = g_pwallet;
                        Session["xid"] = g_pwallet.xid;
                        Session["validationID"] = g_pwallet.validationID;
                        lt_cur_admin_details = z.getTmAdminDetailsByID(admin);
                        if ((lt_cur_admin_details.xID != null) && (lt_cur_admin_details.xID != ""))
                        {
                            Session["lt_cur_admin_details"] = lt_cur_admin_details;
                        }
                        g_tm_info = ret.getG_Tm_infoByPwalletID(g_pwallet.xid);
                        if ((g_tm_info.xid != null) && (g_tm_info.xid != ""))
                        {
                            Session["g_tm_info"] = g_tm_info;
                        }
                        g_app_info = ret.getG_App_infoByPwalletID(g_pwallet.xid);
                        if ((g_app_info.id != null) && (g_app_info.id != ""))
                        {
                            Session["g_app_info"] = g_app_info;
                        }
                        g_applicant_info = ret.getG_Applicant_infoByPwalletID(g_pwallet.xid);
                        if ((g_applicant_info.id != null) && (g_applicant_info.id != ""))
                        {
                            Session["g_applicant_info"] = g_applicant_info;
                        }
                        g_agent_info = ret.getGenAgentByPwalletID(g_pwallet.xid);
                        if ((g_agent_info.xid != null) && (g_agent_info.xid != ""))
                        {
                            Session["g_agent_info"] = g_agent_info;
                        }
                        g_ass_info = ret.getG_Ass_infoByPwalletID(g_pwallet.xid);
                        if ((g_ass_info.xid != null) && (g_ass_info.xid != ""))
                        {
                            Session["g_ass_info"] = g_ass_info;
                        }
                        g_cert_info = ret.getG_Cert_infoByPwalletID(g_pwallet.xid);
                        if ((g_cert_info.xid != null) && (g_cert_info.xid != ""))
                        {
                            Session["g_cert_info"] = g_cert_info;
                        }
                        g_change_info = ret.getG_Change_infoByPwalletID(g_pwallet.xid);
                        if ((g_change_info.xid != null) && (g_change_info.xid != ""))
                        {
                            Session["g_change_info"] = g_change_info;
                        }
                        g_merger_info = ret.getG_Merger_infoByPwalletID(g_pwallet.xid);
                        if ((g_merger_info.xid != null) && (g_merger_info.xid != ""))
                        {
                            Session["g_merger_info"] = g_merger_info;
                        }
                        g_renewal_info = ret.getG_Renewal_infoByPwalletID(g_pwallet.xid);
                        if ((g_renewal_info.xid != null) && (g_renewal_info.xid != ""))
                        {
                            Session["g_renewal_info"] = g_renewal_info;
                        }
                        g_prelim_search_info = ret.getG_Prelim_search_infoByPwalletID(g_pwallet.xid);
                        if ((g_prelim_search_info.xid != null) && (g_prelim_search_info.xid != ""))
                        {
                            Session["g_prelim_search_info"] = g_prelim_search_info;
                        }
                        g_other_items_info = ret.getG_Other_items_infoByPwalletID(g_pwallet.xid);
                        if ((g_other_items_info.xid != null) && (g_other_items_info.xid != ""))
                        {
                            Session["g_other_items_info"] = g_other_items_info;
                        }
                        lt_g_tm_office = z.getG_TmOfficeDetailsByID(g_pwallet.xid);
                        if (lt_g_tm_office.Count > 0)
                        {
                            Session["lt_g_tm_office"] = lt_g_tm_office;
                        }


                        if( (g_app_info.reg_no !="") )
                        {

                            vreg_no = g_app_info.reg_no;
                            Session["vreg_no"]=vreg_no;
                        }
                        else
                        {
                            vreg_no = g_app_info.application_no;
                            Session["vreg_no"] = vreg_no;
                        }
                        for (int i = 0; i < lt_g_tm_office.Count; i++)
                        {
                            xcomments = xcomments + "<tr>";
                            xcomments = xcomments + "<td align=\"center\" colspan=\"4\">";
                            xcomments = xcomments + "<strong>" + lt_g_tm_office[i].xcomment.ToUpper() + "</strong><br />";
                            lt_x_admin_details = z.getTmAdminDetailsByID(lt_g_tm_office[i].xofficer);

                            xcomments = xcomments + "COMMENT BY: <strong>" + lt_x_admin_details.xname.ToUpper() + "( " + z.getRoleNameByID(lt_x_admin_details.xroleID).ToUpper() + " UNIT)</strong><br />   Date: <strong>" + lt_g_tm_office[i].reg_date.ToUpper() + "</strong>";
                            xcomments = xcomments + "</td>";
                            xcomments = xcomments + "</tr>";
                            string str4 = "";
                            string str5 = "";
                            string str6 = "";
                            if (((lt_g_tm_office[i].xdoc1 != "") || (lt_g_tm_office[i].xdoc2 != "")) || (lt_g_tm_office[i].xdoc3 != ""))
                            {
                                xcomments = xcomments + "<tr>";
                                xcomments = xcomments + "<td colspan=\"4\" align=\"center\" class=\"tbbg\">";
                                xcomments = xcomments + "--- SUPPORTING DOCUMENTS ---";
                                xcomments = xcomments + "</td>";
                                xcomments = xcomments + "</tr>";
                            }
                            if (lt_g_tm_office[i].xdoc1 != "")
                            {
                                if (lt_g_tm_office[i].xdoc1.Contains("generic/"))
                                {
                                    str4 = lt_g_tm_office[i].xdoc1.Replace("generic/", "");
                                }
                                xcomments = xcomments + "<tr>";
                                xcomments = xcomments + "<td colspan=\"4\" align=\"center\">";
                                xcomments = xcomments + "View Document 1: <a href=" + str4 + " target='_blank'>View</a>";
                                xcomments = xcomments + "</td>";
                                xcomments = xcomments + "</tr>";
                            }
                            if (lt_g_tm_office[i].xdoc2 != "")
                            {
                                if (lt_g_tm_office[i].xdoc2.Contains("generic/"))
                                {
                                    str5 = lt_g_tm_office[i].xdoc2.Replace("generic/", "");
                                }
                                xcomments = xcomments + "<tr>";
                                xcomments = xcomments + "<td colspan=\"4\" align=\"center\">";
                                xcomments = xcomments + "View Document 2: <a href=" + str5 + " target='_blank'>View</a>";
                                xcomments = xcomments + "</td>";
                                xcomments = xcomments + "</tr>";
                            }
                            if (lt_g_tm_office[i].xdoc3 != "")
                            {
                                if (lt_g_tm_office[i].xdoc3.Contains("generic/"))
                                {
                                    str6 = lt_g_tm_office[i].xdoc3.Replace("generic/", "");
                                }
                                xcomments = xcomments + "<tr>";
                                xcomments = xcomments + "<td colspan=\"4\" align=\"center\">";
                                xcomments = xcomments + "View Document 3: <a href=" + str6 + " target='_blank'>View</a>";
                                xcomments = xcomments + "</td>";
                                xcomments = xcomments + "</tr>";
                            }
                            xcomments = xcomments + "<tr>";
                            xcomments = xcomments + "<td class=\"coltbbg\" colspan=\"4\" align=\"center\">";
                            xcomments = xcomments + "&nbsp;";
                            xcomments = xcomments + "</td>";
                            xcomments = xcomments + "</tr>";
                        }
                        if ((g_tm_info.xid != null) && (g_tm_info.xid != ""))
                        {
                            string str7 = "../../../../admin/tm/gf/";
                            xcomments = xcomments + "<tr>";
                            xcomments = xcomments + "<td colspan=\"4\" align=\"center\" class=\"tbbg\">";
                            xcomments = xcomments + "--- UPLOADED DOCUMENTS ---";
                            xcomments = xcomments + "</td>";
                            xcomments = xcomments + "</tr>";
                            if (g_tm_info.logo_pic != "")
                            {
                                xcomments = xcomments + "<tr>";
                                xcomments = xcomments + "<td colspan=\"4\" align=\"center\">";
                                xcomments = xcomments + "<a href=" + str7 + g_tm_info.logo_pic + " target='_blank'>VIEW TRADEMARK REPRESENTATION</a>";
                                xcomments = xcomments + "</td>";
                                xcomments = xcomments + "</tr>";
                            }
                            if (g_tm_info.app_letter_doc != "")
                            {
                                xcomments = xcomments + "<tr>";
                                xcomments = xcomments + "<td colspan=\"4\" align=\"center\">";
                                xcomments = xcomments + "<a href=" + str7 + g_tm_info.app_letter_doc + " target='_blank'>VIEW APPLICATION LETTER</a>";
                                xcomments = xcomments + "</td>";
                                xcomments = xcomments + "</tr>";
                            }
                            if (g_tm_info.sup_doc1 != "")
                            {
                                xcomments = xcomments + "<tr>";
                                xcomments = xcomments + "<td colspan=\"4\" align=\"center\">";
                                xcomments = xcomments + "<a href=" + str7 + g_tm_info.sup_doc1 + " target='_blank'>VIEW SUPPORTING DOCUMENT</a>";
                                xcomments = xcomments + "</td>";
                                xcomments = xcomments + "</tr>";
                            }
                            if ((g_cert_info.cert_doc != null) && (g_cert_info.cert_doc != ""))
                            {
                                xcomments = xcomments + "<tr>";
                                xcomments = xcomments + "<td colspan=\"4\" align=\"center\">";
                                xcomments = xcomments + "<a href=" + str7 + g_cert_info.cert_doc + " target='_blank'>VIEW COPY OF CERTIFICATE</a>";
                                xcomments = xcomments + "</td>";
                                xcomments = xcomments + "</tr>";
                            }
                            if ((g_ass_info.ass_doc != null) && (g_ass_info.ass_doc != ""))
                            {
                                xcomments = xcomments + "<tr>";
                                xcomments = xcomments + "<td colspan=\"4\" align=\"center\">";
                                xcomments = xcomments + "<a href=" + str7 + g_ass_info.ass_doc + " target='_blank'>VIEW COPY OF ASSIGNMENT</a>";
                                xcomments = xcomments + "</td>";
                                xcomments = xcomments + "</tr>";
                            }
                            if ((g_merger_info.merger_doc != null) && (g_merger_info.merger_doc != ""))
                            {
                                xcomments = xcomments + "<tr>";
                                xcomments = xcomments + "<td colspan=\"4\" align=\"center\">";
                                xcomments = xcomments + "<a href=" + str7 + g_merger_info.merger_doc + " target='_blank'>VIEW COPY OF MERGER</a>";
                                xcomments = xcomments + "</td>";
                                xcomments = xcomments + "</tr>";
                            }
                            if ((g_cert_info.pub_doc != null) && (g_cert_info.pub_doc != ""))
                            {
                                xcomments = xcomments + "<tr>";
                                xcomments = xcomments + "<td colspan=\"4\" align=\"center\">";
                                xcomments = xcomments + "<a href=" + str7 + g_cert_info.pub_doc + " target='_blank'>VIEW COPY OF PUBLICATION</a>";
                                xcomments = xcomments + "</td>";
                                xcomments = xcomments + "</tr>";
                            }
                            xcomments = xcomments + "<tr>";
                            xcomments = xcomments + "<td class=\"coltbbg\" colspan=\"4\" align=\"center\">";
                            xcomments = xcomments + "&nbsp;";
                            xcomments = xcomments + "</td>";
                            xcomments = xcomments + "</tr>";
                            Session["xcomments"] = xcomments;
                        }
                        foreach (XObjs.Fee_list _list in fee_list)
                        {
                            if (_list.item_code == g_pwallet.log_officer)
                            {
                                lbl_type.Text = _list.item.ToUpper(); Session["code_title"] = _list.xdesc; code_title = _list.xdesc;
                            }
                        }
                        Session["item_code"] = g_pwallet.log_officer; item_code = g_pwallet.log_officer;
                        ShowSection(g_pwallet.log_officer);
                    }
                }
            }
            else
            {
                if (Session["xcomments"] != null) { xcomments = Session["xcomments"].ToString(); }
                if (Session["pwalletID"] != null) { pwalletID = Session["pwalletID"].ToString(); }
                if (Session["lt_cur_admin_details"] != null) { lt_cur_admin_details = (zues.Adminz)Session["lt_cur_admin_details"]; }
                if (Session["g_pwallet"] != null) { g_pwallet = (XObjs.G_Pwallet)Session["g_pwallet"]; }
                if (Session["g_tm_info"] != null) { g_tm_info = (XObjs.G_Tm_info)Session["g_tm_info"]; }
                if (Session["g_app_info"] != null) { g_app_info = (XObjs.G_App_info)Session["g_app_info"]; }
                if (Session["g_applicant_info"] != null) { g_applicant_info = (XObjs.G_Applicant_info)Session["g_applicant_info"]; }
                if (Session["g_agent_info"] != null) { g_agent_info = (XObjs.Gen_Agent_info)Session["g_agent_info"]; }
                if (Session["g_ass_info"] != null) { g_ass_info = (XObjs.G_Ass_info)Session["g_ass_info"]; }
                if (Session["g_cert_info"] != null) { g_cert_info = (XObjs.G_Cert_info)Session["g_cert_info"]; }
                if (Session["g_change_info"] != null) { g_change_info = (XObjs.G_Change_info)Session["g_change_info"]; }
                if (Session["g_merger_info"] != null) { g_merger_info = (XObjs.G_Merger_info)Session["g_merger_info"]; }
                if (Session["g_renewal_info"] != null) { g_renewal_info = (XObjs.G_Renewal_info)Session["g_renewal_info"]; }
                if (Session["g_prelim_search_info"] != null) { g_prelim_search_info = (XObjs.G_Prelim_search_info)Session["g_prelim_search_info"]; }
                if (Session["g_other_items_info"] != null) { g_other_items_info = (XObjs.G_Other_items_info)Session["g_other_items_info"]; }
                if (Session["lt_g_tm_office"] != null) { lt_g_tm_office = (List<zues.G_TmOffice>)Session["lt_g_tm_office"]; }
                if (Session["code_title"] != null) { code_title = Session["code_title"].ToString(); }
                if (Session["item_code"] != null) { item_code = Session["item_code"].ToString(); }
            }
        }

        public void PopulateOffice(string admin)
        {
            string str = z.getRoleNameByID(z.getAdminDetails(admin).xroleID).Trim();
            if ((str != null) && (str != ""))
            {
                if (str == "Search")
                {
                    Session["Office"] = str;
                    Session["OfficeID"] = "2";
                }
                if (str == "Opposition")
                {
                    Session["Office"] = str;
                    Session["OfficeID"] = "3";
                }
                if (str == "Certificate")
                {
                    Session["Office"] = str;
                    Session["OfficeID"] = "4";
                }
                if (str == "Acceptance")
                {
                    Session["Office"] = str;
                    Session["OfficeID"] = "5";
                }
            }
        }

        protected void rbValid_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbValid.SelectedValue == "Treated")
            {
                rbval_text = "Treated";
                Verify.Visible = true;
            }
            else if (rbValid.SelectedValue == "Kiv")
            {
                rbval_text = "Kiv";
                Verify.Visible = true;
            }
            else if (rbValid.SelectedValue == "Contact")
            {
                rbval_text = "Contact";
                Verify.Visible = true;
            }
        }

        public void ShowSection(string item_code)
        {
            if (item_code == "T001")
            {
                prelim_show = 1;
                Session["item_code"] = item_code;
            }
            else if (item_code == "T003")
            {
                cert_show = 1;
                Session["item_code"] = item_code;
            }
            else if (item_code == "T008")
            {
                change_show = 1;
                Session["item_code"] = item_code;
            }
            else if (item_code == "T009")
            {
                renewal_show = 1;
                Session["item_code"] = item_code;
            }
            else if (item_code == "T014")
            {
                ass_show = 1;
                merger_show = 1;
                Session["item_code"] = item_code;
            }
            else if ((((item_code != "T001") && (item_code != "T002")) && ((item_code != "T003") && (item_code != "T008"))) && ((item_code != "T009") && (item_code != "T014")))
            {
                others_show = 1;
                Session["item_code"] = item_code;
            }
        }

        protected void Verify_Click(object sender, EventArgs e)
        {
            if (comment.Text != "" && selectDestinationUnit.SelectedValue !="selectDestinationUnit")
            {
               // succ = z.a_g_tm_office(Session["xid"].ToString(), Session["OfficeID"].ToString(), rbValid.SelectedValue, comment.Text, "", "", "", admin);
                succ = z.a_g_tm_office(Session["xid"].ToString(), selectDestinationUnit.SelectedValue, rbValid.SelectedValue, comment.Text, "", "", "", admin);

         
                if (Convert.ToInt32(succ) > 0)
                {

                    if (rbValid.SelectedValue == "Treated")
                    {
                        Email email = new Email();

                        if (Session["g_agent_info"] != null) { g_agent_info = (XObjs.Gen_Agent_info)Session["g_agent_info"]; }
                        if (Session["g_app_info"] != null) { g_app_info = (XObjs.G_App_info)Session["g_app_info"]; }
                        if (Session["g_applicant_info"] != null) { g_applicant_info = (XObjs.G_Applicant_info)Session["g_applicant_info"]; }
                        if (Session["g_tm_info"] != null) { g_tm_info = (XObjs.G_Tm_info)Session["g_tm_info"]; }
                        if (Session["g_ass_info"] != null) { g_ass_info = (XObjs.G_Ass_info)Session["g_ass_info"]; }
                        if (Session["g_cert_info"] != null) { g_cert_info = (XObjs.G_Cert_info)Session["g_cert_info"]; }
                        if (Session["g_change_info"] != null) { g_change_info = (XObjs.G_Change_info)Session["g_change_info"]; }
                        if (Session["g_merger_info"] != null) { g_merger_info = (XObjs.G_Merger_info)Session["g_merger_info"]; }
                        if (Session["g_other_items_info"] != null) { g_other_items_info = (XObjs.G_Other_items_info)Session["g_other_items_info"]; }
                        if (Session["g_prelim_search_info"] != null) { g_prelim_search_info = (XObjs.G_Prelim_search_info)Session["g_prelim_search_info"]; }
                        if (Session["g_renewal_info"] != null) { g_renewal_info = (XObjs.G_Renewal_info)Session["g_renewal_info"]; }
                        if (Session["validationID"] != null) { vid = Session["validationID"].ToString(); }


                        string user_doc = c_ud.returnDoc(vid, g_pwallet, g_app_info, g_applicant_info, g_tm_info, g_agent_info, g_ass_info, g_cert_info, g_change_info,
                  g_merger_info, g_other_items_info, g_prelim_search_info, g_renewal_info, comment.Text.Trim(), z.getTmAdminDetailsByID(pwalletID).xname, code_title, "mail", lt_g_tm_office[lt_g_tm_office.Count - 1].reg_date);
                        Session["user_doc"] = user_doc;
                       // email.sendMail("CLD Status Response", "anthony@3nitix.com", "info@einaosolutions.com", "CLD: Response for: " + g_tm_info.tm_title, user_doc, "");
                        try
                        {
                            email.sendMail("CLD Status Response", g_applicant_info.xemail, "info@einaosolutions.com", "CLD: Response for: " + g_tm_info.tm_title, user_doc, "");
                        }
                        catch (Exception ee)
                        {


                        }
                    }
                    Response.Write("<script type=\"text/javascript\">alert('Data updated successfully')</script>");
                    Response.Redirect("./g_applications.aspx");
                }
                else
                {
                    Response.Write("<script type=\"text/javascript\">alert('Data not updated, Please try again later')</script>");
                }
            }
            else
            {
                Response.Write("<script type=\"text/javascript\">alert('Please enter a comment to proceed!!')</script>");
            }
        }

        protected void BtnProfile_Click(object sender, EventArgs e)
        {
            if ((Session["profileUrl"] != null) && Session["profileUrl"].ToString() != "") { Response.Redirect(Session["profileUrl"].ToString().Trim()); }
        }

        
    }
}