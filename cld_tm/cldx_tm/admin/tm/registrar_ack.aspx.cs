using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace cld.admin.tm
{
    using admin;
    using Classes;
    public partial class registrar_ack : System.Web.UI.Page
    {
        public string admin = "0";
        public string agt = "";
        public tm.AddressService c_aos = new tm.AddressService();
        public tm.Applicant c_app = new tm.Applicant();
        public tm.Address c_app_addy = new tm.Address();
        public tm.MarkInfo c_mark = new tm.MarkInfo();
        public tm.Representative c_rep = new tm.Representative();
        public tm.Address c_rep_addy = new tm.Address();
        public tm.Stage c_stage = new tm.Stage();
        protected Image tm_img;
        public string pwalletID = "";
        public tm t = new tm();
        public string validationID = "";
        public string vid = "";
        protected string serverpath = "";


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
                 //   base.Response.Redirect("./xcontrol.aspx");
                }
            }
            else
            {
             //   base.Response.Redirect("./xcontrol.aspx");
            }

            this.serverpath = base.Server.MapPath("~/");
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
              //  base.Response.Redirect("./xcontrol.aspx");
            }
            if (base.Request.QueryString["94384238"] != null)
            {
                this.agt = base.Request.QueryString["94384238"].ToString();
            }
            else
            {
               // base.Response.Redirect("./xcontrol.aspx");
            }
            this.pwalletID = this.t.getCheckStatusDetails(this.vid, this.agt);
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

                if (c_mark.logo_pic != "")
                {
                    tm_img.ImageUrl = "../../admin/tm/" + c_mark.logo_pic;
                }
               
            }
            else
            {
              //  base.Response.Redirect("./xcontrol.aspx");
            }
        }
      

    }
}