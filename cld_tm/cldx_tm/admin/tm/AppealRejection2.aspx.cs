using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using cld.admin;
using cld.Classes;
using static cld.Classes.zues;

namespace cld.admin.tm
{
    public partial class AppealRejection2 : System.Web.UI.Page
    {
        public string admin = "";
        public string admin_status = "2";
        public Boolean showvisible = true;
        public cld.Classes.tm.AddressService c_aos = new cld.Classes.tm.AddressService();
        public cld.Classes.tm.Applicant c_app = new cld.Classes.tm.Applicant();
        public cld.Classes.tm.Address c_app_addy = new cld.Classes.tm.Address();
        public zues.MarkInfo c_mark = new zues.MarkInfo();
        public zues.Pwallet c_p = new zues.Pwallet();
        public cld.Classes.tm.Representative c_rep = new cld.Classes.tm.Representative();
        public cld.Classes.tm.Address c_rep_addy = new cld.Classes.tm.Address();
        public List<zues.TmOffice> lt_tm_office = new List<zues.TmOffice>();
        public zues.Adminz lt_x_admin_details = new zues.Adminz();

        public AppealUpload appealupload = new AppealUpload();

        //protected TextBox comment;
        //protected Label Label1;
        //protected Label Label10;
        //protected Label Label11;
        //protected Label Label12;
        //protected Label Label13;
        //protected Label Label14;
        //protected Label Label19;
        //protected Label Label2;
        //protected Label Label20;
        //protected Label Label21;
        //protected Label Label22;
        //protected Label Label23;
        //protected Label Label25;
        //protected Label Label26;
        //protected Label Label27;
        //protected Label Label28;
        //protected Label Label3;
        //protected Label Label4;
        //protected Label Label5;
        //protected Label Label6;
        //protected Label Label7;
        public string mark_infoID;
        public string pID;
        public string rbval_text = "";
        //  protected RadioButtonList rbValid;
        public string succ;
        public cld.Classes.tm t = new cld.Classes.tm();
        // protected Button Verify;
        public string xofficer;
        public string xcomments = "";
        public zues z = new zues();

        protected void Page_Load(object sender, EventArgs e)
        {
            Verify.Visible = false;
            if (this.rbValid.SelectedValue == "Accepted")
            {
                this.admin_status = "5";
                Verify.Visible = true;
            }
            else if (this.rbValid.SelectedValue == "Refused")
            {
                this.admin_status = "4";
                Verify.Visible = true;
            }

            else if (this.rbValid.SelectedValue == "Kiv")
            {
                this.admin_status = "14";
                Verify.Visible = true;
            }
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
            if (base.Request.QueryString["x"] != null)
            {
                this.pID = base.Request.QueryString["x"].ToString();
                string tt2  = base.Request.QueryString["x2"].ToString();
                this.c_mark = this.z.getMarkInfoByUserID(this.pID);
                appealupload = this.t.getAppealRefusal(tt2);

               

                if (appealupload.Status != "Pending")
                {

                    showvisible = false;
                    rbValid.Visible = false;
                    comment.Visible = false;
                }

                txtAddress.Text = appealupload.Comment;
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
                xname.Value = c_p.applicantID;
                xname2.Value = c_mark.product_title;

                xname3.Value = c_mark.reg_number;

                xname4.Value = c_p.validationID;
                xname5.Value = c_mark.log_staff;

                xname6.Value = c_p.applicantID;

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
                base.Response.Redirect("./verify_data.aspx");
            }
        }

        protected void rbValid_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.rbValid.SelectedValue == "Accepted")
            {
                this.rbval_text = "Accepted";
                this.admin_status = "5";
                Verify.Visible = true;
            }
            else if (this.rbValid.SelectedValue == "Refused")
            {
                this.rbval_text = "Refused";
                this.admin_status = "4";
                Verify.Visible = true;
            }

            else if (this.rbValid.SelectedValue == "Kiv")
            {
                this.rbval_text = "Invalid";
                this.admin_status = "14";
                Verify.Visible = true;
            }
        }

        protected void Verify_Click(object sender, EventArgs e)
        {
           // if (this.rbval_text == "") { this.rbval_text = "Accepted"; }

            //this.c_mark = this.z.getMarkInfoByUserID(this.pID);
            //string repname = c_rep.xname;
            //string repemail = c_aos.email1;

            //var vapplicant = z.getApplicant(c_mark.log_staff);

            //TmOffice toffice = z.getLastTmOfficeByID(c_mark.log_staff);
            //string oldstatus = "";
            //string olddatastatus = "";

            //if (toffice != null)
            //{
            //    oldstatus = z.getCurrentStage2(toffice);
            //    olddatastatus = toffice.data_status;
            //}
            this.succ = this.z.a_tm_office(this.c_mark.log_staff, this.admin_status, this.rbValid.SelectedValue, this.comment.Text, "", "", "", this.admin);

            if (this.succ != "0")
            {
                
                z.AppealRejection2(appealupload.id, this.admin, DateTime.Now.ToString(), this.rbValid.SelectedValue);
                //   z.sendemail2(repname, c_mark, repemail, this.comment.Text, this.admin_status, this.admin_status, oldstatus, olddatastatus);
                base.Response.Write("<script language=JavaScript>alert('Data verified successfully')</script>");
                base.Response.Redirect("./AppealRejection.aspx");
            }
            else
            {
                base.Response.Write("<script language=JavaScript>alert('Data not verified, Please try again later')</script>");
            }


            //  




        }
    }
}