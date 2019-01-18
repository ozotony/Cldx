namespace cld.admin.tm
{
    using admin ;
    using Classes ;
    using System;
    using System.Collections.Generic;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public class profilea_data : UserControl
    {
        public string admin = "";
        public string admin_status = "2";
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
        protected Label Label15;
        protected Label Label16;
        protected Label Label17;
        protected Label Label18;
        protected Label Label19;
        protected Label Label2;
        protected Label Label20;
        protected Label Label21;
        protected Label Label22;
        protected Label Label23;
        protected Label Label24;
        protected Label Label25;
        protected Label Label26;
        protected Label Label3;
        protected Label Label4;
        protected Label Label5;
        protected Label Label6;
        protected Label Label7;
        protected Label Label8;
        protected Label Label9;
        public List<zues.TmOffice> lt_tm_office = new List<zues.TmOffice>();
        public string mark_infoID;
        public string pID;
        public string rbval_text = "";
        public string succ;
        public tm t = new tm();
        public string xofficer;
        public zues z = new zues();

        protected void Page_Load(object sender, EventArgs e)
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
            if (base.Request.QueryString["x"] != null)
            {
                this.pID = base.Request.QueryString["x"].ToString();
                this.c_mark = this.z.getMarkInfoByUserID(this.pID);
                this.c_p = this.z.getPwalletDetailsByID(this.c_mark.log_staff);
                this.c_app = this.t.getApplicantByUserID(this.c_p.ID);
                this.c_app_addy = this.t.getAddressClassByID(this.c_app.addressID);
                this.c_aos = this.t.getAddressServiceByID(this.c_p.ID);
                this.c_rep = this.t.getRepByUserID(this.c_p.ID);
                this.c_rep_addy = this.t.getAddressClassByID(this.c_rep.addressID);
                this.lt_tm_office = this.z.getTmOfficeDetailsByID(this.c_p.ID);
            }
            else
            {
                base.Response.Redirect("./profilea_data.aspx");
            }
        }
    }
}

