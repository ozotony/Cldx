using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using cld.Classes;
using System.Configuration;

namespace cld.gf
{
    public partial class xind_old : System.Web.UI.Page
    {
        public string item_code = "";
        public string agent = "";
        public string agentname = "";
        public string agentemail = "";
        public string agentpnumber = "";
        public string aid = "";
        public string amt = "";
        public string applicantname = "";
        public string applicant_addy = "";
        public string applicantemail = "";
        public string applicantpnumber = "";
       // public string cname = "";
        public string log_staffID = "0";
        public string pc = "";
        public string product_title = "";
        public string pwalletID = "0";
        public string transID = "";
        public string vid = "";
        public string fee_detailsID = "";
        public string hwalletID = "";
        public string x = "";
        public string xapplication = "";
        public string xrep = "";
        public string xuserType = "";
        public int status = 0;

        protected Classes.tm t = new Classes.tm();
        protected Classes.XObjs.Trademark_item ti = new Classes.XObjs.Trademark_item();
        protected Classes.XObjs.Pwallet c_pwall = new Classes.XObjs.Pwallet();
        protected Classes.XObjs.G_Agent_info c_xagt = new Classes.XObjs.G_Agent_info();
        protected Classes.XObjs.Address c_addy = new Classes.XObjs.Address();
        protected Classes.Retriever ret = new Classes.Retriever();
        public List<Classes.tm.Stage> lt_pw = new List<Classes.tm.Stage>();

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["fee_detailsID"] = null;
            Session["item_code"] = null;
            Session["hwalletID"] = null;
            Session["vid"] = null;
            Session["amt"] = null;
            Session["aid"] = null;
            Session["pc"] = null;
            Session["agentname"] = null;
            Session["agentemail"] = null;
            Session["agentpnumber"] = null;
            Session["applicantname"] = null;
            Session["applicant_addy"] = null;
            Session["applicantemail"] = null;
            Session["applicantpnumber"] = null;
            Session["product_title"] = null;
            Session["xapplication"] = null;
            Session["pwalletID"] = null;
            Session["log_staffID"] = null;
            Session["xapplication"] = null;
            Session["log_staffID"] = log_staffID;
            string serverpath = Server.MapPath("~/");

            if (Request.Form["item_code"] != null) { this.item_code = Request.Form["item_code"]; }
            if (Request.Form["fee_detailsID"] != null) { this.fee_detailsID = Request.Form["fee_detailsID"]; }
            if (Request.Form["hwalletID"] != null) { this.hwalletID = Request.Form["hwalletID"]; }
            if (Request.Form["transID"] != null) { this.transID = Request.Form["transID"]; }
            if (Request.Form["amt"] != null) { this.amt = Request.Form["amt"]; }
            if (Request.Form["agent"] != null) { this.agent = Request.Form["agent"]; }
            if (Request.Form["agentemail"] != null) { this.agentemail = Request.Form["agentemail"]; }
            if (Request.Form["agentpnumber"] != null) { this.agentpnumber = Request.Form["agentpnumber"]; }
            if (Request.Form["applicantemail"] != null) { this.applicantemail = Request.Form["applicantemail"]; }
            if (Request.Form["applicantpnumber"] != null) { this.applicantpnumber = Request.Form["applicantpnumber"]; }
            if (Request.Form["applicant_addy"] != null)
            {
                if (Request.Form["applicant_addy"].ToString().Contains("%26"))
                { this.applicant_addy = Request.Form["applicant_addy"].Replace("%26", "&"); }
                else { this.applicant_addy = Request.Form["applicant_addy"]; }
            }
            if (Request.Form["agentname"] != null)
            {
                if (Request.Form["agentname"].ToString().Contains("%26"))
                { this.agentname = Request.Form["agentname"].Replace("%26", "&"); }
                else { this.agentname = Request.Form["agentname"]; }
            }

            if (Request.Form["applicantname"] != null)
            {
                if (Request.Form["applicantname"].ToString().Contains("%26"))
                { this.applicantname = Request.Form["applicantname"].Replace("%26", "&"); }
                else { this.applicantname = Request.Form["applicantname"]; }
            }

            if (Request.Form["product_title"] != null)
            {
                if (Request.Form["product_title"].ToString().Contains("%26"))
                { this.product_title = Request.Form["product_title"].Replace("%26", "&"); }
                else { this.product_title = Request.Form["product_title"]; }
            }

            if (
                (this.item_code != "") &&
                (this.fee_detailsID != "") &&
                (this.hwalletID != "") &&
                (this.transID != "") &&
                (this.amt != "") &&
                (this.agent != "") &&
                (this.agentname != "") &&
                (this.agentemail != "") &&
                (this.agentpnumber != "") &&
                (this.applicantname != "") &&
                (this.applicant_addy != "") &&
                (this.applicantemail != "") &&
                (this.applicantpnumber != "") &&
                (this.product_title != "")
                )
            {
                if (Session["xapplication"] != null)
                {
                    this.xapplication = Session["xapplication"].ToString();
                    if (this.xapplication != this.transID)
                    {
                        if (Session["Trademark_item"] == null) { Response.Redirect("./violation.aspx"); }
                        else { Response.Redirect("./a_violation.aspx"); }
                    }
                }
                else
                { 
                Session["xapplication"] = this.transID; }
                Session["item_code"] = this.item_code;
                Session["fee_detailsID"] = this.fee_detailsID;
                Session["hwalletID"] = this.hwalletID;
                Session["vid"] = this.transID;
                Session["amt"] = this.amt;
                Session["aid"] = this.agent;
                Session["agentemail"] = this.agentemail;
                Session["agentname"] = this.agentname;
                Session["agentpnumber"] = this.agentpnumber;
                Session["applicantname"] = this.applicantname;
                Session["applicant_addy"] = this.applicant_addy;
                Session["applicantemail"] = this.applicantemail;
                Session["applicantpnumber"] = this.applicantpnumber;
                Session["product_title"] = this.product_title;

                tm.Stage s = this.t.getStageBy_G_ValidationID(this.transID.Trim());
                if (Convert.ToInt32(s.status) > 1) { Response.Redirect("./xreturn.aspx"); }
                else if (Convert.ToInt32(s.status) == 1) { Response.Redirect("./g_tm_refill.aspx"); }
                else if ((Convert.ToInt32(s.status) == 0) || (s.status == null) || (s.status == ""))
                {
                    this.pwalletID = this.t.addPwalletG(serverpath, "0", this.transID, this.agent, this.amt, this.item_code);
                    if (this.pwalletID != "0") { Session["pwalletID"] = this.pwalletID; }
                }
            }
            else
            {
                Response.Redirect(ConfigurationManager.AppSettings["ipo_profile_page"]);
            }

        }
    }
}