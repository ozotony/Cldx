using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using cld.Classes;
namespace cld
{
    public partial class tm_acknowledgement_c : System.Web.UI.Page
    {
        public string aid = "";
        public string amt = "";
        public tm.AddressService c_aos = new tm.AddressService();
        public tm.Applicant c_app = new tm.Applicant();
        public tm.Address c_app_addy = new tm.Address();
        public tm.MarkInfo c_mark = new tm.MarkInfo();
        public tm.Representative c_rep = new tm.Representative();
        public tm.Address c_rep_addy = new tm.Address();
        public tm.Stage c_stage = new tm.Stage();
        public string gt = "";
        public string pwalletID = "";
        public tm t = new tm();
        public string validationID = "";
        public string vid = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["vid"] != null)
            {
                this.vid = Session["vid"].ToString();
            }
            if (Session["amt"] != null)
            {
                this.amt = Session["amt"].ToString();
            }
            if (Session["aid"] != null)
            {
                this.aid = Session["aid"].ToString();
            }
            if (Session["gt"] != null)
            {
                this.gt = Session["gt"].ToString();
            }
            this.pwalletID = this.t.getPwalletID(this.vid);
            if (this.pwalletID != "")
            {
                this.c_mark = this.t.getMarkInfoClassByUserID(this.pwalletID);
                this.c_rep = this.t.getRepClassByUserID(this.pwalletID);
                this.c_stage = this.t.getStageClassByUserID(this.pwalletID);
                this.c_app = this.t.getApplicantClassByID(this.pwalletID);
                this.c_app_addy = this.t.getAddressClassByID(this.c_app.addressID);
                Session["xserviceaddress"] = null;
                Session["xrepresentative"] = null;
                Session["xmarkinfo"] = null;
                Session["xapplication"] = null;
                Session["vid"] = null;
                Session["amt"] = null;
                Session["aid"] = null;
                Session["g"] = null;
                Session["pc"] = null;
            }
        }
    }
}