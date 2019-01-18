using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using cld.Classes;

namespace cld.Handlers
{
    /// <summary>
    /// Summary description for add_new_tm
    /// </summary>
    public class add_new_gen_tm : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        public string hID = null;
        public string agent = "";
        public string agentemail = "";
        public string agentpnumber = "";
        public string amt = "";
        public string applicantname = "";
        public string cname = "";
        public string transID = "";
        public string vid = "";
        public string item_code = "";
        public string log_staffID = "0";
        public string product_title = null;
        public tm t = new tm();
        public string xapplication = "";
        public string request_type = "";
        public string xgt = null;
        public string agt = null;
        public int status = 0;
        protected string pwalletID = "0";

        protected XObjs.Trademark_item ti = new XObjs.Trademark_item();
        protected XObjs.Pwallet c_pwall = new XObjs.Pwallet();
        protected XObjs.G_Agent_info c_xagt = new XObjs.G_Agent_info();
        protected XObjs.Address c_addy = new XObjs.Address();
        protected cld.Classes.Retriever ret = new cld.Classes.Retriever();
        public List<tm.Stage> lt_pw = new List<tm.Stage>();


        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
        
            string serverpath = context.Server.MapPath("~/");
            if (
              (context.Request.Headers["transID"] != null) &&
              (context.Request.Headers["transID"].ToString() != "") &&
              (context.Request.Headers["amt"] != null) &&
              (context.Request.Headers["amt"].ToString() != "") &&
              (context.Request.Headers["agt"] != null) &&
              (context.Request.Headers["agt"].ToString() != "") &&
              (context.Request.Headers["cname"] != null) &&
              (context.Request.Headers["cname"].ToString() != "") &&
              (context.Request.Headers["agentemail"] != null) &&
              (context.Request.Headers["agentemail"].ToString() != "") &&
              (context.Request.Headers["agentpnumber"] != null) &&
              (context.Request.Headers["agentpnumber"].ToString() != "") &&
              (context.Request.Headers["applicantname"] != null) &&
              (context.Request.Headers["applicantname"].ToString() != "") &&
              (context.Request.Headers["product_title"] != null) &&
              (context.Request.Headers["product_title"].ToString() != "") &&
              (context.Request.Headers["item_code"] != null) &&
              (context.Request.Headers["item_code"].ToString() != "")
              )
            {
                this.transID = context.Request.Headers["transID"];
                this.amt = context.Request.Headers["amt"];
                this.agent = context.Request.Headers["agt"];
                this.xgt = context.Request.Headers["xgt"];

                if (context.Request.Headers["cname"].Contains("%26") == true)
                {
                    this.cname = context.Request.Headers["cname"].Replace("%26", "&");
                }
                else
                { this.cname = context.Request.Headers["cname"]; }
                this.agentemail = context.Request.Headers["agentemail"];
                this.agentpnumber = context.Request.Headers["agentpnumber"];

                if (context.Request.Headers["applicantname"].Contains("%26") == true)
                {
                    this.applicantname = context.Request.Headers["applicantname"].Replace("%26", "&");
                }
                else
                { this.applicantname = context.Request.Headers["applicantname"]; }

                if (context.Request.Headers["product_title"].Contains("%26") == true)
                {
                    this.product_title = context.Request.Headers["product_title"].Replace("%26", "&");
                }
                else
                { this.product_title = context.Request.Headers["product_title"]; }

                this.item_code = context.Request.Headers["item_code"];

                if (((((this.transID != "") && (this.amt != "")) && ((this.agent != "") && (this.xgt != ""))) && (((this.cname != "") && (this.agentemail != "")) && ((this.agentpnumber != "") && (this.applicantname != "")))) && (this.product_title != "") && (this.item_code != ""))
                {

                    context.Session["vid"] = this.transID;
                    context.Session["amt"] = this.amt;
                    context.Session["agt"] = this.agent;
                    context.Session["xgt"] = this.xgt;
                    context.Session["agentemail"] = this.agentemail;
                    context.Session["cname"] = this.cname;
                    context.Session["agentpnumber"] = this.agentpnumber;
                    context.Session["applicantname"] = this.applicantname;
                    context.Session["product_title"] = this.product_title;
                    context.Session["item_code"] = this.item_code;

                    tm.Stage s = this.t.getStageBy_G_ValidationID(this.transID.Trim());

                    if (Convert.ToInt32(s.status) > 1)
                    {
                        context.Response.Redirect("./g_appstatus.aspx?agt=" + context.Session["agt"].ToString());
                    }
                    else if (Convert.ToInt32(s.status) == 1)
                    {
                        context.Response.Redirect("./g_appstatus.aspx?agt=" + context.Session["agt"].ToString());
                        //  Response.Redirect("./xrefill.aspx");
                    }
                    else if (Convert.ToInt32(s.status) == 0)
                    {
                        this.pwalletID = this.t.addPwalletG(serverpath, "0", this.transID, this.agent, this.amt, this.item_code);
                        if (this.pwalletID != "0")
                        {
                            context.Session["pwalletID"] = this.pwalletID;
                            context.Response.Write(this.pwalletID);
                        }
                    }
                }
                else
                {
                    //context.Response.Redirect("http://www.iponigeria.com/userarea/dashboard");
                }

            }
             


           // context.Response.Write("Hello World");



        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}