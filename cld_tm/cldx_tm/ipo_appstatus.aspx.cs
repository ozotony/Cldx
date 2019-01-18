using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using cld.Classes;
using cld.admin;
using System.Configuration;

namespace cld
{
    public partial class ipo_appstatus : System.Web.UI.Page
    {       
        protected List<tm.MarkInfo> lt_mi = new List<tm.MarkInfo>();
        protected List<tm.Stage> lt_pw = new List<tm.Stage>();
        protected tm.Representative lt_rep = new tm.Representative();
        protected string r;
        protected int showt;
        protected string status = "N/A";
        protected string data_status = "N/A";
        protected tm t = new tm();
        protected zues z = new zues();

        protected void Page_Load(object sender, EventArgs e)
        {
         
        }

        protected void BtnCheckStatus_Click(object sender, EventArgs e)
        {
          //  base.Response.Redirect("./appstatusc.aspx");
            showt = 0;
        }
        protected void Save_Click(object sender, EventArgs e)
        {
            if (this.xref.Text != "")
            {
                if (this.xref.Text.Contains("OAI/TM/"))
                {
                    this.xref.Text = this.xref.Text.Replace("OAI/TM/", "");
                }
                this.r = this.xref.Text.Trim();
                this.lt_pw = this.t.getStageByClientIDAcc(this.xref.Text);
                if (this.lt_pw.Count != 0)
                {
                    Session["xvid"] = this.xref.Text.Trim(); 
                    this.lt_mi = this.t.getMarkInfoByUserID(this.lt_pw[0].ID);
                    this.lt_rep = this.t.getRepByUserID(this.lt_pw[0].ID);
                    Session["agent_code"] = lt_rep.agent_code;
                    if (this.lt_pw[0].status == "1")
                    {
                        this.status = "Verification";
                        if (lt_pw[0].data_status == "Fresh") { data_status = "Untreated"; }
                    }
                    if (this.lt_pw[0].status == "2")
                    {
                        this.status = "Search";
                        if (lt_pw[0].data_status == "Re-conduct search") { data_status = "being re-conducted"; }
                    }
                    if (this.lt_pw[0].status == "22")
                    {
                        this.status = "Search 2";
                        if (lt_pw[0].data_status == "Re-conduct search 1") { data_status = "being re-conducted"; }
                    }
                    if (this.lt_pw[0].status == "3")
                    {
                        this.status = "Search 2";
                        if (lt_pw[0].data_status == "Search Conducted") { data_status = "being processed"; }
                    }
                    if (this.lt_pw[0].status == "33")
                    {
                        this.status = "Examiners";
                        if (lt_pw[0].data_status == "Search 2 Conducted") { data_status = "being processed"; }
                    }
                    if (this.lt_pw[0].status == "4")
                    {
                        this.status = "Acceptance";
                        if (lt_pw[0].data_status == "Registrable") { data_status = "Accepted"; }
                        else if (lt_pw[0].data_status == "Refused") { data_status = "Refused"; }
                        else if (lt_pw[0].data_status == "Non-registrable") { data_status = "not-registrable"; }
                    }
                    if (this.lt_pw[0].status == "5")
                    {
                        this.status = "Publication";
                        if (lt_pw[0].data_status == "Accepted") { data_status = "being published"; }
                    }
                    if (this.lt_pw[0].status == "6")
                    {
                        this.status = "Opposition";
                        if (lt_pw[0].data_status == "Published") { data_status = "being published"; } else { data_status = "been opposed"; }
                    }
                    if (this.lt_pw[0].status == "7")
                    {
                        this.status = "Certification";
                        if (lt_pw[0].data_status == "Not Opposed") { data_status = "being processed"; }
                    }
                    if (this.lt_pw[0].status == "8")
                    {
                        this.status = "Registrars";
                        if (lt_pw[0].data_status == "Certified") { data_status = "being processed"; }
                    }
                    if (this.lt_pw[0].status == "9")
                    {
                        this.status = "Registrars";
                        if (lt_pw[0].data_status == "Registered") { data_status = "being registered"; }
                    }
                    this.showt = 1;
                }
                else
                {
                    this.status = "N/A";
                    this.showt = 1;
                }
            }
            else
            {
                base.Response.Write("<script language=JavaScript>alert('PLEASE ENTER A VALID REFERENCE NUMBER')</script>");
            }
        }

        protected void BtnDashBoard_Click(object sender, EventArgs e)
        {
            Response.Redirect(ConfigurationManager.AppSettings["ipo_profile_page"]);
        }

        protected void BtnReprintAck_Click(object sender, EventArgs e)
        {
            string agent_code = "";
            if ((Session["xvid"] != null) && (Session["xvid"].ToString() != ""))
            { r = Session["xvid"].ToString(); }
            if ((Session["agent_code"] != null) && (Session["agent_code"].ToString() != ""))
            { agent_code = Session["agent_code"].ToString(); }

           Response.Redirect("./ipo_ark.aspx?0001234445=" + r + "&94384238=" + agent_code);
        }
    }
}