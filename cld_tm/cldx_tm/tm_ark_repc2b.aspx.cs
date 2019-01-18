using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using cld.Classes;
namespace cld
{
    public partial class tm_ark_repc2b : System.Web.UI.Page
    {
        protected string agt = "";
        protected tm.AddressService c_aos = new tm.AddressService();
        protected tm.Applicant c_app = new tm.Applicant();
        protected tm.Address c_app_addy = new tm.Address();
        protected tm.MarkInfo c_mark = new tm.MarkInfo();
        protected tm.Representative c_rep = new tm.Representative();
        protected tm.Address c_rep_addy = new tm.Address();
        protected tm.Stage c_stage = new tm.Stage();
        protected string pwalletID = "";
        protected tm t = new tm();
        protected string validationID = "";
        protected string vid = "";
        protected void Page_Load(object sender, EventArgs e)
        {

            if (base.Request.QueryString["0001234445"] != null)
            {
                this.vid = base.Request.QueryString["0001234445"].ToString();
                if (this.vid.Contains("OAI/TM/"))
                {
                    this.vid = this.vid.Replace("OAI/TM/", "");
                }
            }
            else
            {
                base.Response.Redirect("./appstatusc.aspx");
            }
            //if (base.Request.QueryString["94384238"] != null)
            //{
            //    this.agt = base.Request.QueryString["94384238"].ToString();
            //}
            //else
            //{
            //    base.Response.Redirect("./appstatusc.aspx");
            //}
            this.pwalletID = this.t.getCheckStatusDetails3(this.vid);
            if (this.pwalletID != "")
            {
                this.c_mark = this.t.getMarkInfoClassByUserID(this.pwalletID);
                this.c_rep = this.t.getRepClassByUserID(this.pwalletID);
                this.c_stage = this.t.getStageClassByUserID(this.pwalletID);
                this.c_app = this.t.getApplicantClassByID(this.pwalletID);
                if ((c_app.addressID != null) && (c_app.addressID != "") && (c_app.addressID != "0"))
                {
                    this.c_app_addy = this.t.getAddressClassByID(this.c_app.addressID);
                }
                if ((c_rep.addressID != null) && (c_rep.addressID != "") && (c_rep.addressID != "0"))
                {
                    this.c_rep_addy = this.t.getAddressClassByID(this.c_rep.addressID);
                }
            }
            else
            {
                // base.Response.Redirect("./appstatusc.aspx");
            }
        }
    }
}