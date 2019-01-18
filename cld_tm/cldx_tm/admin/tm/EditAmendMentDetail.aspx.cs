using System;
using System.Collections.Generic;
using cld;
using cld;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Net.Mail;
using cld.model;

namespace cld.admin.tm
{
    public partial class EditAmendMentDetail : System.Web.UI.Page
    {
        public string admin = "";
        public string admin_status = "5";
        public cld.Classes.tm.AddressService c_aos = new cld.Classes.tm.AddressService();
        public cld.Classes.tm.Applicant c_app = new cld.Classes.tm.Applicant();
        public cld.Classes.tm.Address c_app_addy = new cld.Classes.tm.Address();
        public cld.Classes.zues.MarkInfo c_mark = new cld.Classes.zues.MarkInfo();
        public cld.Classes.zues.Pwallet c_p = new cld.Classes.zues.Pwallet();
        public cld.Classes.tm.Representative c_rep = new cld.Classes.tm.Representative();
        public cld.Classes.tm.Address c_rep_addy = new cld.Classes.tm.Address();
        protected TextBox comment;
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
        public List<cld.Classes.zues.TmOffice> lt_tm_office = new List<cld.Classes.zues.TmOffice>();
        public cld.Classes.zues.Adminz lt_x_admin_details = new cld.Classes.zues.Adminz();
        public string pID;
        public string rbval_text = "";
        protected RadioButtonList rbValid;
        public string search_doc_succ1 = "";
        public string search_doc_succ2 = "";
        public string search_doc_succ3 = "";
        public string succ = "";
        public cld.Classes.tm.SWallet swallet = new cld.Classes.tm.SWallet();
        public cld.Classes.tm.SWallet swallet2 = new cld.Classes.tm.SWallet();
        public cld.Classes.tm t = new cld.Classes.tm();
        protected Button Verify;
        public string xcomments = "";
        public string xofficer;
        public cld.Classes.zues z = new cld.Classes.zues();

        protected void Page_Load(object sender, EventArgs e)
        {
            Verify.Visible = false;
            if (this.rbValid.SelectedValue == "Aproved")
            {
                this.admin_status = "5";
                Verify.Visible = true;
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
                //  this.swallet = this.t.getSwalletByID(this.pID);
                //  this.swallet2 = this.t.getSwalletByID2(this.pID);
                this.c_mark = this.z.getMarkInfoByUserID2(this.pID);
                this.c_p = this.z.getPwalletDetailsByID2(this.c_mark.log_staff);

              
                this.c_app = this.t.getApplicantByUserID2(this.c_p.ID);
                this.c_aos = this.t.getAddressServiceByID2(this.c_p.ID);
                this.c_rep = this.t.getRepByUserID2(this.c_p.ID);
                if ((c_app.addressID != null) && (c_app.addressID != "") && (c_app.addressID != "0"))
                {
                    this.c_app_addy = this.t.getAddressClassByID2(this.c_app.addressID);
                }
                if ((c_rep.addressID != null) && (c_rep.addressID != "") && (c_rep.addressID != "0"))
                {
                    this.c_rep_addy = this.t.getAddressClassByID2(this.c_rep.addressID);
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
                base.Response.Redirect("./opposed.aspx");
            }
        }

        protected void rbValid_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.rbValid.SelectedValue == "Aproved")
            {
               // this.rbval_text = "Opposed";
                this.admin_status = "5";
                Verify.Visible = true;
            }
           
        }

        public void approveTnx(cld.Classes.zues.Pwallet  pxx)
        {

            ba2xai_cldx_backupEntities1 app = new ba2xai_cldx_backupEntities1();
            long vid = Convert.ToInt64(pxx.ID);
            String  vid2 = Convert.ToString(pxx.ID);
            String vid3 = Convert.ToString(pxx.log_staff);

            var pwallet2 = (from c in app.pwallets where c.ID == pxx.log_staff select c).FirstOrDefault();

            var pwalletAmendment2 = (from c in app.pwalletAmendments where c.ID == vid select c).FirstOrDefault();

            pwallet2.acc_p = pwalletAmendment2.acc_p;

            pwallet2.amt = pwalletAmendment2.amt;

            pwallet2.applicantID = pwalletAmendment2.applicantID;

            pwalletAmendment2.ApprovedBy = this.admin;

            pwalletAmendment2.AmendmentStatus = "Approved";
            pwallet2.reg_date = pwalletAmendment2.reg_date;

            pwallet2.rtm = pwalletAmendment2.rtm;

            pwallet2.TransactionId = pwalletAmendment2.TransactionId;


            pwallet2.validationID = pwalletAmendment2.validationID;


            app.SaveChanges();


            var applicantAmendment2 = (from c in app.applicantAmendments where c.log_staff == vid2  select c).FirstOrDefault();
            var applicant2 = (from c in app.applicants where c.log_staff == vid3 select c).FirstOrDefault();

           // applicant2.addressID = applicantAmendment2.addressID;
            applicant2.individual_id_number = applicantAmendment2.individual_id_number;

            applicant2.nationality = applicantAmendment2.nationality;

            applicant2.nationality = applicantAmendment2.nationality;

            applicant2.reg_date = applicantAmendment2.reg_date;

            applicant2.tax_id_number = applicantAmendment2.tax_id_number;

            applicant2.tax_id_type = applicantAmendment2.tax_id_type;

            applicant2.xname = applicantAmendment2.xname;

            applicant2.xold = applicantAmendment2.xold;

            app.SaveChanges();


            long appaddressid = Convert.ToInt64(applicant2.addressID);

            long appaddressid2 = Convert.ToInt64(applicantAmendment2.addressID);
            var addressAmendment2 = (from c in app.addressAmendments where c.log_staff == vid2 && c.ID== appaddressid2 select c).FirstOrDefault();
            var address2 = (from c in app.addresses where c.log_staff == vid3 && c.ID == appaddressid select c).FirstOrDefault();

            //  var address2 = (from c in app.addresses where c.log_staff == vid3  select c).FirstOrDefault();

            try {

                address2.city = addressAmendment2.city;

                address2.countryID = addressAmendment2.countryID;

                address2.email1 = addressAmendment2.email1;

                address2.email2 = addressAmendment2.email2;

                address2.lgaID = addressAmendment2.lgaID;

                address2.reg_date = addressAmendment2.reg_date;

                address2.stateID = addressAmendment2.stateID;

                address2.street = addressAmendment2.street;


                address2.telephone1 = addressAmendment2.telephone1;

                address2.telephone2 = addressAmendment2.telephone2;

                address2.zip = addressAmendment2.zip;

                app.SaveChanges();
            }

            catch(Exception ee)
            {


            }
        

            var address_serviceAmendment2 = (from c in app.address_serviceAmendment where c.log_staff == vid2 select c).FirstOrDefault();

            var address_service2 = (from c in app.address_service where c.log_staff == vid3 select c).FirstOrDefault();

            address_service2.city = address_serviceAmendment2.city;

            address_service2.countryID = address_serviceAmendment2.countryID;

            address_service2.email1 = address_serviceAmendment2.email1;

            address_service2.email2 = address_serviceAmendment2.email2;

            address_service2.lgaID = address_serviceAmendment2.lgaID;

            address_service2.reg_date = address_serviceAmendment2.reg_date;

            address_service2.stateID = address_serviceAmendment2.stateID;

            address_service2.street = address_serviceAmendment2.street;


            address_service2.telephone1 = address_serviceAmendment2.telephone1;

            address_service2.telephone2 = address_serviceAmendment2.telephone2;

            address_service2.zip = address_serviceAmendment2.zip;

            app.SaveChanges();


           var representativeAmendment2 = (from c in app.representativeAmendments where c.log_staff == vid2 select c).FirstOrDefault();


            var representative2 = (from c in app.representatives where c.log_staff == vid3 select c).FirstOrDefault();

          //  representative2.addressID = representativeAmendment2.addressID;

            representative2.agent_code = representativeAmendment2.agent_code;

            representative2.individual_id_number = representativeAmendment2.individual_id_number;

            representative2.individual_id_type = representativeAmendment2.individual_id_type;

            representative2.nationality = representativeAmendment2.nationality;


            representative2.nationality = representativeAmendment2.nationality;

            representative2.reg_date = representativeAmendment2.reg_date;

            representative2.xname = representativeAmendment2.xname;

            app.SaveChanges();

            long appaddressid3 = Convert.ToInt64(representative2.addressID);
            long appaddressid4 = Convert.ToInt64(representativeAmendment2.addressID);
            var addressAmendment3 = (from c in app.addressAmendments where c.log_staff == vid2 && c.ID == appaddressid4 select c).FirstOrDefault();
            var address3 = (from c in app.addresses where c.log_staff == vid3 && c.ID == appaddressid3 select c).FirstOrDefault();
            try {
                address3.city = addressAmendment3.city;

                address3.countryID = addressAmendment3.countryID;

                address3.email1 = addressAmendment3.email1;

                address3.email2 = addressAmendment3.email2;

                address3.lgaID = addressAmendment3.lgaID;

                address3.reg_date = addressAmendment3.reg_date;

                address3.stateID = addressAmendment3.stateID;

                address3.street = addressAmendment3.street;


                address3.telephone1 = addressAmendment3.telephone1;

                address3.telephone2 = addressAmendment3.telephone2;

                address3.zip = addressAmendment3.zip;

                app.SaveChanges();


            }

            catch(Exception ee)
            {


            }


            var mark_infoAmendment2 = (from c in app.mark_infoAmendment where c.log_staff == vid2 select c).FirstOrDefault();

            var mark_info2 = (from c in app.mark_info where c.log_staff == vid3 select c).FirstOrDefault();


            mark_info2.auth_doc = mark_infoAmendment2.auth_doc;

            mark_info2.disclaimer = mark_infoAmendment2.disclaimer;

            mark_info2.logo_descriptionID = mark_infoAmendment2.logo_descriptionID;

            mark_info2.logo_pic = mark_infoAmendment2.logo_pic;

            mark_info2.national_classID = mark_infoAmendment2.national_classID;

            mark_info2.nice_class = mark_infoAmendment2.nice_class;

            mark_info2.nice_class_desc = mark_infoAmendment2.nice_class_desc;

            mark_info2.product_title = mark_infoAmendment2.product_title;

            mark_info2.reg_date = mark_infoAmendment2.reg_date;

            mark_info2.reg_number = mark_infoAmendment2.reg_number;

            mark_info2.sign_type = mark_infoAmendment2.sign_type;

            mark_info2.sup_doc1 = mark_infoAmendment2.sup_doc1;

            mark_info2.sup_doc2 = mark_infoAmendment2.sup_doc2;

            mark_info2.tm_typeID = mark_infoAmendment2.tm_typeID;

            mark_info2.upload_date = mark_infoAmendment2.upload_date;

            mark_info2.vienna_class = mark_infoAmendment2.vienna_class;

            app.SaveChanges();


        }

     

        protected void Verify_Click(object sender, EventArgs e)
        {
            this.succ = this.z.a_tm_office3(this.c_mark.log_staff, this.admin_status, "amendment", this.comment.Text, this.search_doc_succ1, this.search_doc_succ2, this.search_doc_succ3, this.admin);
            if (this.succ != "0")
            {
                approveTnx(this.c_p);
                base.Response.Write("<script language=JavaScript>alert('Data updated successfully')</script>");
                base.Response.Redirect("./EditAmendMent.aspx");
            }
            else
            {
                base.Response.Write("<script language=JavaScript>alert('Data not verified, Please try again later')</script>");
            }
        }
    }
}
