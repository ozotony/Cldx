﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace cld.admin.tm
{
    using admin;
    using Classes;
    public partial class registrar_issue : System.Web.UI.Page
    {
        public string admin = "";
        public string admin_status = "9";
        public tm.AddressService c_aos = new tm.AddressService();
        public tm.Applicant c_app = new tm.Applicant();
        public tm.Address c_app_addy = new tm.Address();
        public zues.MarkInfo c_mark = new zues.MarkInfo();
        public zues.Pwallet c_p = new zues.Pwallet();
        public tm.Representative c_rep = new tm.Representative();
        public tm.Address c_rep_addy = new tm.Address();       
        public List<zues.TmOffice> lt_tm_office = new List<zues.TmOffice>();
        public zues.Adminz lt_x_admin_details = new zues.Adminz();
        public string pID;
        public string rbval_text = "";
        public string search_doc_succ1 = "";
        public string search_doc_succ2 = "";
        public string search_doc_succ3 = "";
        public string succ = "";
        public tm.SWallet swallet = new tm.SWallet();
        public tm.SWallet swallet2 = new tm.SWallet();
        public tm t = new tm();
        public string xcomments = "";
        public string xofficer;
        public zues z = new zues();

        protected void Page_Load(object sender, EventArgs e)
        {           
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
                        if ((this.swallet.search_str != "") && (this.swallet.search_str != null))
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
                        if ((this.swallet2.search_str != "") && (this.swallet2.search_str != null))
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
                base.Response.Redirect("./registrar.aspx");
            }
        }

        protected void VAcpt_Click(object sender, EventArgs e)
        {
            Response.Redirect("./registrar_acpt.aspx?x=" + pID);
        }

        protected void VAck_Click(object sender, EventArgs e)
        {
            Response.Redirect("./registrar_ack.aspx?0001234445=" + c_p.validationID + "&94384238=" + c_p.applicantID);
        }

        protected void VCert_Click(object sender, EventArgs e)
        {
            Response.Redirect("registrar_c_data_detailsx.aspx?x=" + pID);
        }

      

    }
}