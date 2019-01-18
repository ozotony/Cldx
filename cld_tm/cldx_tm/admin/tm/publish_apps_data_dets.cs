namespace cld.admin.tm
{
    using admin ;
    using Classes ;
    using System;
    using System.Collections.Generic;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public class publish_apps_data_dets : UserControl
    {
        public string admin = "";
        public string admin_status = "6";
        public tm.AddressService c_aos = new tm.AddressService();
        public tm.Applicant c_app = new tm.Applicant();
        public tm.Address c_app_addy = new tm.Address();
        public zues.MarkInfo c_mark = new zues.MarkInfo();
        public zues.Pwallet c_p = new zues.Pwallet();
        public tm.Representative c_rep = new tm.Representative();
        public tm.Address c_rep_addy = new tm.Address();
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
        public zues.Adminz lt_tm_acceptance_details = new zues.Adminz();
        public zues.Adminz lt_tm_examination_details = new zues.Adminz();
        public List<zues.TmOffice> lt_tm_office = new List<zues.TmOffice>();
        public zues.Adminz lt_tm_search_details = new zues.Adminz();
        public zues.Adminz lt_tm_verification_details = new zues.Adminz();
        public string pID;
        public string rbval_text = "";
        public string search_doc_succ1 = "";
        public string search_doc_succ2 = "";
        public string search_doc_succ3 = "";
        public string succ = "";
        public tm t = new tm();
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
                if (c_p.applicantID != "CLD/SA/22")
                {
                    this.lt_tm_office = this.z.getTmOfficeDetailsByID(this.c_p.ID);
                    if (this.lt_tm_office.Count > 0)
                    {
                        if (this.lt_tm_office[0].xofficer != "")
                        {
                            this.lt_tm_verification_details = this.z.getTmAdminDetailsByID(this.lt_tm_office[0].xofficer);
                        }
                    }
                    if (this.lt_tm_office.Count > 1)
                    {
                        if (this.lt_tm_office[1].xofficer != "")
                        {
                            this.lt_tm_search_details = this.z.getTmAdminDetailsByID(this.lt_tm_office[1].xofficer);
                        }
                    }
                    if (this.lt_tm_office.Count > 2)
                    {
                        if (this.lt_tm_office[2].xofficer != "")
                        {
                            this.lt_tm_examination_details = this.z.getTmAdminDetailsByID(this.lt_tm_office[2].xofficer);
                        }
                    }
                    if (this.lt_tm_office.Count > 3)
                    {

                        if (this.lt_tm_office[3].xofficer != "")
                        {
                            this.lt_tm_acceptance_details = this.z.getTmAdminDetailsByID(this.lt_tm_office[3].xofficer);
                        }
                    }
                }
            }
            else
            {
                base.Response.Redirect("./publication.aspx");
            }
        }
    }
}

