namespace cld
{
    using Classes;
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Collections.Generic;

    public class index : Page
    {
        public string agent = "";
        public string agentemail = "";
        public string agentpnumber = "";
        public string aid = "";
        public string amt = "";
        public string applicantname = "";
        public string cname = "";
        protected HtmlForm form1;
        protected HtmlHead Head1;
        public string log_staffID = "0";
        public string pc = "";
        public string product_title = "";
        public string pwalletID = "0";
        public tm t = new tm();
        public string transID = "";
        public string vid = "";
        public string x = "";
        public string xapplication = "";
        public string xgt = "";
        public string xrep = "";
        public string xuserType = "";
        public int status = 0;
        public bool islogopic = true;

        protected cld.Classes.XObjs.Trademark_item ti = new cld.Classes.XObjs.Trademark_item();
        protected cld.Classes.XObjs.Pwallet c_pwall = new cld.Classes.XObjs.Pwallet();
        protected cld.Classes.XObjs.G_Agent_info c_xagt = new cld.Classes.XObjs.G_Agent_info();
        protected cld.Classes.XObjs.Address c_addy = new cld.Classes.XObjs.Address();
        protected cld.Classes.Retriever ret = new cld.Classes.Retriever();
        public List<tm.Stage> lt_pw = new List<tm.Stage>();

        public List<tm.Applicant> lt_app = new List<tm.Applicant>();
        public List<tm.MarkInfo> lt_mi = new List<tm.MarkInfo>();
        public List<tm.AddressService> lt_aos = new List<tm.AddressService>();
        public List<tm.Representative> lt_rep = new List<tm.Representative>();
        public List<tm.Address> lt_appaddy = new List<tm.Address>();
        public List<tm.Address> lt_repaddy = new List<tm.Address>();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Session["vid"] = null;
            this.Session["amt"] = null;
            this.Session["aid"] = null;
            this.Session["gt"] = null;
            this.Session["pc"] = null;
            this.Session["agentemail"] = null;
            this.Session["cname"] = null;
            this.Session["agentpnumber"] = null;
            this.Session["applicantname"] = null;
            this.Session["product_title"] = null;
            this.Session["xapplication"] = null;
            this.Session["pwalletID"] = null;
            this.Session["log_staffID"] = null;
            this.Session["xapplication"] = null;
            this.Session["log_staffID"] = this.log_staffID;
            string serverpath = base.Server.MapPath("~/");

            if (Session["Trademark_item"] == null)
            {
                this.transID = base.Request.Params["transID"];
                this.amt = base.Request.Params["amt"];
                this.agent = base.Request.Params["agent"];
                this.xgt = base.Request.Params["xgt"];
                this.cname = base.Request.Params["cname"].Replace("%26", "&");
                this.agentemail = base.Request.Params["agentemail"];
                this.agentpnumber = base.Request.Params["agentpnumber"];
                this.applicantname = base.Request.Params["applicantname"].Replace("%26", "&");
                this.product_title = base.Request.Params["product_title"].Replace("%26", "&");
            }
            else if (Session["Trademark_item"] != null)
            {
                ti = (cld.Classes.XObjs.Trademark_item)Session["Trademark_item"];
                c_pwall = ret.getPwalletByID(ti.xmemberID);
                c_xagt = ret.getAgentByID(c_pwall.xmemberID);

                this.transID = ti.transID;
                this.amt = ti.amt;
                this.agent = c_xagt.sys_ID;
                this.xgt = ti.xgt;
                this.cname = c_xagt.cname;
                this.agentemail = c_pwall.xemail;
                this.agentpnumber = c_pwall.xmobile;
                this.applicantname = ti.applicant_name;
                this.product_title = ti.product_title;
            }

            if (((((this.transID != "") && (this.amt != "")) && ((this.agent != "") && (this.xgt != ""))) && (((this.cname != "") && (this.agentemail != "")) && ((this.agentpnumber != "") && (this.applicantname != "")))) && (this.product_title != ""))
            {
                if (this.Session["xapplication"] != null)
                {
                    this.xapplication = this.Session["xapplication"].ToString();
                    if (this.xapplication != this.transID)
                    {
                        if (this.Session["Trademark_item"] == null)
                        {
                            base.Response.Redirect("./violation.aspx");
                        }
                        else
                        {
                            Response.Redirect("./a_violation.aspx");
                        }
                    }
                }
                else
                {
                    this.Session["xapplication"] = this.transID;
                }
                this.Session["vid"] = this.transID;
                this.Session["amt"] = this.amt;
                this.Session["aid"] = this.agent;
                this.Session["gt"] = this.xgt;
                this.Session["agentemail"] = this.agentemail;
                this.Session["cname"] = this.cname;
                this.Session["agentpnumber"] = this.agentpnumber;
                this.Session["applicantname"] = this.applicantname;
                this.Session["product_title"] = this.product_title;


                tm.Stage s = this.t.getStatusIDByvalidationID(this.transID.Trim());
                lt_app = t.getApplicantListByUserID(s.ID);
                lt_mi = t.getMarkInfoByUserID(s.ID);
                lt_aos = t.getAddressServiceListByID(s.ID);
                lt_rep = t.getRepListByUserID(s.ID);
                if (this.lt_app.Count > 0)
                {
                    if ((lt_app[0].addressID != null) && (lt_app[0].addressID != "") && (lt_app[0].addressID != "0"))
                    {
                        lt_appaddy = t.getAddressByID(lt_app[0].addressID);
                    }
                }
                if (this.lt_rep.Count > 0)
                {
                    if ((lt_rep[0].addressID != null) && (lt_rep[0].addressID != "") && (lt_rep[0].addressID != "0"))
                    {
                        lt_repaddy = t.getAddressByID(lt_rep[0].addressID);
                    }
                }
                if (this.lt_mi.Count > 0)
                {
                    if ((lt_mi[0].logo_descriptionID != "2") && (lt_mi[0].logo_pic == "")) { islogopic = false; }
                }

                if (Convert.ToInt32(s.status) > 1)
                {
                    this.status = this.t.updateIpoApplicationReferenceStatus(this.transID, this.xgt, "1");
                    Response.Redirect("./xreturn.aspx");
                }
                else if (Convert.ToInt32(s.status) == 1)
                {
                    if ((lt_app.Count == 0) || (lt_aos.Count == 0) || (lt_rep.Count == 0) || (lt_mi.Count == 0) || (lt_appaddy.Count == 0) || (lt_repaddy.Count == 0))
                    {
                        Response.Redirect("./xrefill.aspx");
                    }
                    else
                    {
                        if (islogopic == false)//Trademark is missing
                        {
                            Response.Redirect("./xrefill.aspx");
                        }
                        else
                        {
                            Response.Redirect("./xreturn.aspx");
                        }
                    }
                }
                else if ((Convert.ToInt32(s.status) == 0) || (s.status == null) || (s.status == ""))
                {
                    this.pwalletID = this.t.addPwallet(this.transID, this.agent, this.amt, this.log_staffID);
                    if (this.pwalletID != "0") { this.Session["pwalletID"] = this.pwalletID; }
                }
            }
            else
            {
                if (this.Session["Trademark_item"] == null)
                {
                    base.Response.Redirect("http://www.iponigeria.com/userarea/dashboard");
                }
                else
                {
                    // Response.Redirect("./XPay/A/profile.aspx");
                }
            }
        }
    }
}

