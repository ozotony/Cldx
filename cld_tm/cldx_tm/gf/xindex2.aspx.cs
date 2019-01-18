namespace cld.gf
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using cld.Classes;
    using System.Configuration;

    public partial class xindex : Page
    {
        public string item_code = "";
        public string agent = "";
        public string agentname = "";
        public string agentemail = "";
        public string agentpnumber = "";
        public string agt = "";
        public string xgt = "";
        public string amt = "";
        public string applicantname = "";
        public string applicant_addy = "";
        public string applicantemail = "";
        public string applicantpnumber = "";
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
        public bool islogopic = false;
        public bool isagree = false;

        protected Classes.tm t = new Classes.tm();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["fee_detailsID"] = null;
                Session["item_code"] = null;
                Session["hwalletID"] = null;
                Session["vid"] = null;
                Session["amt"] = null;
                Session["aid"] = null;
                Session["pc"] = null;
                Session["agentemail"] = null;
                Session["agentpnumber"] = null;
                Session["applicantname"] = null;
                Session["applicant_addy"] = null;
                Session["applicantemail"] = null;
                Session["applicant_no"] = null;
                Session["product_title"] = null;
                Session["xapplication"] = null;
                Session["pwalletID"] = null;
                Session["log_staffID"] = null;
                Session["xapplication"] = null;
                Session["new_miID"] = null;
                Session["pwalletID"] = null;
                Session["logo_desc"] = null;
                Session["app_succID"] = null;
                Session["applicant_succID"] = null;
                Session["agent_succID"] = null;
                Session["assID"] = null;
                Session["app_type"] = null;
                Session["mergerID"] = null;
                Session["certID"] = null;
                Session["vid"] = null;
                Session["amt"] = null;
                Session["agt"] = null;
                Session["xgt"] = null;
                Session["agentname"] = null;
                Session["agentemail"] = null;
                Session["agentpnumber"] = null;
                Session["applicantname"] = null;
                Session["applicantemail"] = null;
                Session["applicantpnumber"] = null;
                Session["product_title"] = null;
                Session["item_code"] = null;
                Session["cert_doc_newfilename"] = null;
                Session["ass_doc_newfilename"] = null;
                Session["merger_doc_newfilename"] = null;
                Session["logo_pic_newfilename"] = null;
                Session["app_doc_newfilename"] = null;
                Session["pub_doc_newfilename"] = null;
                Session["sup_doc_newfilename"] = null;
                Session["hwalletID"] = null;
                string serverpath = Server.MapPath("~/");

                if (Request.Form["item_code"] != null) { this.item_code = Request.Form["item_code"]; }
                if (Request.Form["agt"] != null) { this.agt = Request.Form["agt"]; }
                if (Request.Form["xgt"] != null) { this.xgt = Request.Form["xgt"]; }
                if (Request.Form["transID"] != null) { this.transID = Request.Form["transID"]; }
                if (Request.Form["amt"] != null) { this.amt = Request.Form["amt"]; }
                if (Request.Form["agentemail"] != null) { this.agentemail = Request.Form["agentemail"]; }
                if (Request.Form["agentpnumber"] != null) { this.agentpnumber = Request.Form["agentpnumber"]; }
                if (Request.Form["applicantemail"] != null) { this.applicantemail = Request.Form["applicantemail"]; }
                if (Request.Form["applicantpnumber"] != null) { this.applicantpnumber = Request.Form["applicantpnumber"]; }
               
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
                    (this.agt != "") &&
                     (this.xgt != "") &&
                    (this.transID != "") &&
                    (this.amt != "") &&
                    (this.agentname != "") &&
                    (this.agentemail != "") &&
                    (this.agentpnumber != "") &&
                    (this.applicantname != "") &&
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
                            if (Session["Trademark_item"] == null) { Response.Redirect("../violation.aspx"); }
                            else { Response.Redirect("../violation.aspx"); }
                        }
                    }
                    else
                    {
                        Session["xapplication"] = this.transID;
                    }
                    Session["item_code"] = this.item_code;
                    Session["agt"] = this.agt;
                    Session["xgt"] = this.xgt;
                    Session["vid"] = this.transID;
                    Session["amt"] = this.amt;                    
                    Session["agentemail"] = this.agentemail;
                    Session["agentname"] = this.agentname;
                    Session["agentpnumber"] = this.agentpnumber;
                    Session["applicantname"] = this.applicantname;
                    Session["applicantemail"] = this.applicantemail;
                    Session["applicantpnumber"] = this.applicantpnumber;
                    Session["product_title"] = this.product_title;

                    tm.Stage s = this.t.getStageBy_G_ValidationID(this.transID.Trim());
                    if ((s.ID != null) && (Convert.ToInt32(s.ID) > 0)) { Response.Redirect("./xreturn.aspx"); }
                }
                else
                {
                    Response.Redirect("http://www.iponigeria.com/userarea/dashboard");
                }
            }
        }

        protected void cbAgree_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAgree.Checked == true) { isagree = true; } else { isagree = false; }
        }
    }
}

