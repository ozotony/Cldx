using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using cld.Classes;
using cld.admin;

namespace cld
{
    public partial class appstatusc : System.Web.UI.Page
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
        protected string agent_msg = "";

        protected void Page_Load(object sender, EventArgs e)
        {
         
        }

        protected void BtnCheckStatus_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("./appstatusc.aspx");
        }
        protected void Save_Click(object sender, EventArgs e)
        {
            if (this.xref.Text != "")
            {
                if (this.xref.Text.Contains("OAI/TM/"))
                {
                    this.xref.Text = this.xref.Text.Replace("OAI/TM/", "");
                }
                this.r = this.xref.Text;
                this.lt_pw = this.t.getStageByClientIDAcc(this.xref.Text);
                if (this.lt_pw.Count != 0)
                {
                    Session["xvid"] = this.xref.Text;
                    this.lt_mi = this.t.getMarkInfoByUserID(this.lt_pw[0].ID);
                    this.lt_rep = this.t.getRepByUserID(this.lt_pw[0].ID);
                    if (lt_pw[0].status == "1")
                    {
                        this.status = "Verification";
                        if (lt_pw[0].data_status == "Fresh")
                        {
                            data_status = "Untreated";
                            agent_msg = "<strong>\"Verification Office\"</strong>";
                        }
                    }
                    if (lt_pw[0].status == "2")
                    {
                        if (lt_pw[0].data_status == "Re-conduct search")
                        {
                            data_status = "being re-conducted"; this.status = "Search";
                            agent_msg = "<strong>\"Search Office\"</strong>";
                        }
                        else if (lt_pw[0].data_status == "Valid")
                        {
                            data_status = "awaiting attendance"; this.status = "Search";
                            agent_msg = "<strong>\"Verification Office\"</strong>";
                        }
                    }
                    if (lt_pw[0].status == "22")
                    {
                        this.status = "Search 2";
                        if (lt_pw[0].data_status == "Re-conduct search 1")
                        {
                            data_status = "being re-conducted";
                            agent_msg = "<strong>\"Search Office\"</strong>";
                        }
                    }
                    if (lt_pw[0].status == "3")
                    {
                        if (lt_pw[0].data_status == "Search Conducted")
                        {
                            data_status = "being processed"; this.status = "Search 2";
                            agent_msg = "<strong>\"Verification Office\"</strong>";

                        }
                        else if (lt_pw[0].data_status == "Re-examine")
                        {
                            data_status = "being re-examined"; this.status = "Examiners";
                            agent_msg = "<strong>\"Verification Office\"</strong>";
                        }
                    }
                    if (lt_pw[0].status == "33")
                    {
                        this.status = "Examiners";
                        if (lt_pw[0].data_status == "Search 2 Conducted")
                        {
                            data_status = "being examined";
                            agent_msg = "being examined";
                        }
                    }
                    if (lt_pw[0].status == "4")
                    {
                        this.status = "Acceptance";
                        if (lt_pw[0].data_status == "Registrable")
                        {
                            data_status = "Accepted";
                            agent_msg = "<strong>\"Acceptance Office\"</strong> and is registrable";
                        }
                        else if (lt_pw[0].data_status == "Refused")
                        {
                            data_status = "Refused";
                            agent_msg = "<strong>\"Acceptance Office\"</strong> and is not-registrable";
                        }
                        else if (lt_pw[0].data_status == "Non-registrable")
                        {
                            data_status = "not-registrable";
                            agent_msg = "<strong>\"Acceptance Office\"</strong> and is not-registrable";
                        }
                    }
     //  || status == "11" || status == "13"
                    if (lt_pw[0].status == "5" || lt_pw[0].status == "11" || lt_pw[0].status == "13")
                    {
                        if (lt_pw[0].data_status == "Accepted")
                        {
                            data_status = "being published"; this.status = "Publication";
                            agent_msg = "<strong>\"Publication Office\"</strong> and your acceptance letter is ready for collection";
                        }
                        else if (lt_pw[0].data_status == "Deferred")
                        {
                            data_status = "been deferred"; this.status = "Publication";
                            agent_msg = "<strong>\"Publication Office\"</strong>";
                        }
                        else if (lt_pw[0].data_status == "acc_printed")
                        {
                            data_status = "being published"; this.status = "Acceptance (Printed)";
                            agent_msg = "<strong>\"Publication Office\"</strong> and your acceptance letter is ready for collection";
                        }
                        else if (lt_pw[0].data_status == "Withdraw")
                        {
                            data_status = "being published"; this.status = "Acceptance (Withdrawal)";
                            agent_msg = "<strong>\"Publication Office\"</strong> and your application has been withdrawn";
                        }
                        else if (lt_pw[0].data_status == "kiv")
                        {
                            data_status = "being processed"; this.status = "Acceptance (KIV)";
                            agent_msg = "<strong>\"Publication Office\"</strong> and is being processed";
                        }

                    }
                    if (lt_pw[0].status == "6")
                    {
                        this.status = "Opposition";
                        if (lt_pw[0].data_status == "Published")
                        {
                            data_status = "being published";
                            agent_msg = "<strong>\"Verification Office\"</strong>";
                        }
                        else
                        {
                            data_status = "been opposed";
                            agent_msg = "<strong>\"Verification Office\"</strong>";
                        }
                    }
                    if (lt_pw[0].status == "7")
                    {
                        if (lt_pw[0].data_status == "Not Opposed")
                        {
                            data_status = "being processed"; this.status = "Certification";
                            agent_msg = "<strong>\"Verification Office\"</strong>";
                        }
                        else if (lt_pw[0].data_status == "Deferred")
                        {
                            data_status = "been deferred"; this.status = "Certification";
                            agent_msg = "<strong>\"Verification Office\"</strong>";
                        }
                    }
                    if (lt_pw[0].status == "8")
                    {
                        this.status = "Registrars";
                        if (lt_pw[0].data_status == "Certified")
                        {
                            data_status = "being processed";
                            agent_msg = "<strong>\"Verification Office\"</strong>";
                        }
                    }
                    if (lt_pw[0].status == "9")
                    {
                        this.status = "Registrars";
                        if (lt_pw[0].data_status == "Registered")
                        {
                            data_status = "being registered";
                            agent_msg = "<strong>\"Verification Office\"</strong>";
                        }
                    }
                    this.showt = 1;
                }
                else
                {
                    this.status = "N/A";
                }
            }
            else
            {
                base.Response.Write("<script language=JavaScript>alert('PLEASE ENTER A VALID REFERENCE NUMBER')</script>");
            }
        }
    }
}