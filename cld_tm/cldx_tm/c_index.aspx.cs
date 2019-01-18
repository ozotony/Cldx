using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace cld
{
    public partial class c_index : System.Web.UI.Page
    {
        protected string transID = "";
        protected string agent = "";
        protected string agentemail = "";
        protected string agentpnumber = "";
        protected string aid = "";
        protected string amt = "";
        protected string applicantname = "";
        public string cname = "";
        protected string log_staffID = "0";
        protected string pc = "";
        protected string product_title = "";
        protected string pwalletID = "0";
        protected string vid = "";
        protected string x = "";
        protected string xapplication = "";
        protected string xgt = "";
        protected string xrep = "";
        protected string xuserType = "";

        public cld.Classes.tm t = new cld.Classes.tm();
        protected cld.Classes.XObjs.Trademark_item ti = new cld.Classes.XObjs.Trademark_item();
        protected cld.Classes.XObjs.Pwallet c_pwall = new cld.Classes.XObjs.Pwallet();
        protected cld.Classes.XObjs.XMember c_xmem = new cld.Classes.XObjs.XMember();
        protected cld.Classes.XObjs.Address c_addy = new cld.Classes.XObjs.Address();
        protected cld.Classes.Retriever ret = new cld.Classes.Retriever();

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

            if (Session["Trademark_item"] != null)
            {
                ti = (cld.Classes.XObjs.Trademark_item)Session["Trademark_item"];
                c_pwall = ret.getPwalletByID(ti.xmemberID);
                c_xmem = ret.getMemberByID(c_pwall.xmemberID);

                this.transID = ti.transID;
                this.amt = ti.amt;
                this.agent = c_xmem.sys_ID;
                this.xgt = ti.xgt;
                this.cname = c_xmem.cname;
                this.agentemail = c_pwall.xemail;
                this.agentpnumber = c_pwall.xmobile;
                this.applicantname = c_xmem.xname;
                this.product_title = ti.product_title;
            }
            
            if (((((this.transID != "") && (this.amt != "")) && ((this.agent != "") && (this.xgt != ""))) && (((this.cname != "") && (this.agentemail != "")) && ((this.agentpnumber != "") && (this.applicantname != "")))) && (this.product_title != ""))
            {
                if (this.Session["xapplication"] != null)
                {
                    this.xapplication = this.Session["xapplication"].ToString();
                    if (this.xapplication != this.transID)
                    {
                        base.Response.Redirect("./c_violation.aspx");
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

               this.pwalletID = this.t.addPwallet(this.transID, this.agent, this.amt, this.log_staffID);
                if (this.pwalletID != "0")
                {
                    this.Session["pwalletID"] = this.pwalletID;
                }
            }
            else
            {
                base.Response.Redirect("./XPay/C/profile.aspx");
            }
        }
    }
}