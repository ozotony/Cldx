using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace cld.gf
{
    using admin;
    using Classes;
    public partial class g_appstatus : System.Web.UI.Page
    {       
        public List<tm.Stage> lt_pw = new List<tm.Stage>();
        public int showt;
        public string status = "N/A";
        public string data_status = "N/A";
        public tm t = new tm();
        public zues z = new zues();

        public Classes.XObjs.G_Pwallet g_pwallet = new Classes.XObjs.G_Pwallet();
        public Classes.XObjs.G_App_info g_app_info = new Classes.XObjs.G_App_info();
        public Classes.XObjs.G_Applicant_info g_applicant_info = new Classes.XObjs.G_Applicant_info();
        public Classes.XObjs.Gen_Agent_info g_agent_info = new Classes.XObjs.Gen_Agent_info();
        public Classes.XObjs.G_Tm_info g_tm_info = new Classes.XObjs.G_Tm_info();
        public Classes.XObjs.G_Ass_info g_ass_info = new Classes.XObjs.G_Ass_info();
        public Classes.XObjs.G_Cert_info g_cert_info = new Classes.XObjs.G_Cert_info();
        public Classes.XObjs.G_Change_info g_change_info = new Classes.XObjs.G_Change_info();
        public Classes.XObjs.G_Merger_info g_merger_info = new Classes.XObjs.G_Merger_info();
        public Classes.XObjs.G_Renewal_info g_renewal_info = new Classes.XObjs.G_Renewal_info();
        public Classes.XObjs.G_Prelim_search_info g_prelim_search_info = new Classes.XObjs.G_Prelim_search_info();
        public Classes.XObjs.G_Other_items_info g_other_items_info = new Classes.XObjs.G_Other_items_info();

        public Retriever ret = new Retriever();

        public int refill = 0;

       

        protected void Page_Load(object sender, EventArgs e)
        {
            if (base.Request.QueryString["agt"] != null)
            {
                Session["agt"] = base.Request.QueryString["agt"].ToString();
            }
            else
            {
                //base.Response.Redirect("http://www.iponigeria.com");
            }
           
        }

        protected void BtnCheckStatus_Click(object sender, EventArgs e)
        {
            if (Session["agt"] != null)
            {
                base.Response.Redirect("./g_appstatus.aspx?agt=" + Session["agt"].ToString());
            }
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            if (this.xref.Text != "")
            {
                if (this.xref.Text.Contains("TM/GF/"))
                {
                    this.xref.Text = this.xref.Text.Replace("TM/GF/", "");
                }
                g_pwallet = ret.getG_PwalletByValidationID(xref.Text.Trim());
                if ((g_pwallet.xid != null) && (g_pwallet.xid != ""))
                {
                    this.showt = 1;
                    Session["g_pwallet"] = g_pwallet;
                    g_tm_info = ret.getG_Tm_infoByPwalletID(g_pwallet.xid);
                    g_app_info = ret.getG_App_infoByPwalletID(g_pwallet.xid);
                    g_applicant_info = ret.getG_Applicant_infoByPwalletID(g_pwallet.xid);
                    g_agent_info = ret.getGenAgentByPwalletID(g_pwallet.xid);
                    g_ass_info = ret.getG_Ass_infoByPwalletID(g_pwallet.xid);
                    g_cert_info = ret.getG_Cert_infoByPwalletID(g_pwallet.xid);
                    g_change_info = ret.getG_Change_infoByPwalletID(g_pwallet.xid);
                    g_merger_info = ret.getG_Merger_infoByPwalletID(g_pwallet.xid);
                    g_renewal_info = ret.getG_Renewal_infoByPwalletID(g_pwallet.xid);
                    g_prelim_search_info = ret.getG_Prelim_search_infoByPwalletID(g_pwallet.xid);
                    g_other_items_info = ret.getG_Other_items_infoByPwalletID(g_pwallet.xid);

                    if (
                            (Convert.ToInt32(g_pwallet.status) == 1)&&
                            (g_tm_info.xid != null) && (g_app_info.id != null) &&
                            (g_applicant_info.id != null) && (g_agent_info.xid != null) &&
                            (
                            (g_ass_info.xid != null) || (g_cert_info.xid != null) || (g_cert_info.xid != null)||
                            (g_change_info.xid != null) || (g_merger_info.xid != null) || (g_renewal_info.xid != null)||
                            (g_prelim_search_info.xid != null) || (g_other_items_info.xid != null) 
                            )
                        )
                    {
                        if (t.getLogoDescriptionID(g_tm_info.logo_descID) != "2")
                        {
                            if (g_tm_info.logo_pic != "")
                            {
                                refill = 0;
                                showStatus(g_pwallet);
                            }
                            else
                            {
                                status = "Filing"; data_status = "Uncompleted";
                                refill = 1;
                            }
                        }
                        else
                        {
                            refill = 0;
                            showStatus(g_pwallet);
                        }
                    }
                    else if (
                        (Convert.ToInt32(g_pwallet.status) == 1)
                        &&
                         (
                        (g_tm_info.xid == null) || (g_app_info.id == null) ||
                        (g_applicant_info.id == null) || (g_agent_info.xid == null)
                        )
                        &&
                        (
                            (g_ass_info.xid == null) || (g_cert_info.xid == null) || (g_cert_info.xid == null) ||
                            (g_change_info.xid == null) || (g_merger_info.xid != null) || (g_renewal_info.xid == null) ||
                            (g_prelim_search_info.xid == null) || (g_other_items_info.xid == null)
                            )
                        )
                    {
                        status = "Filing"; data_status = "Uncompleted";
                        refill = 1;
                    }
                    else if (Convert.ToInt32(g_pwallet.status) > 1)
                    {
                        refill = 0;
                        if (g_pwallet.xid !=null)
                        {
                            Session["xvid"] = this.xref.Text;
                            g_tm_info = ret.getG_Tm_infoByPwalletID(g_pwallet.xid);
                            g_agent_info = ret.getGenAgentByPwalletID(g_pwallet.xid);
                            showStatus(g_pwallet);

                        }
                        else
                        {
                            this.status = "N/A";
                        }
                    }
                }

            }
            else
            {
                base.Response.Write("<script language=JavaScript>alert('PLEASE ENTER A VALID REFERENCE NUMBER')</script>");
            }
        }

        public void showStatus(Classes.XObjs.G_Pwallet g_p)
        {
            if (g_p.status == "1")
            {
                this.status = "Verification";
                if (g_p.data_status == "Fresh") { data_status = "Untreated"; }
            }
            if (g_p.status == "2")
            {
                if (g_p.data_status == "Treated")
                { data_status = "Treated"; this.status = "Search"; }
                else if (g_p.data_status == "Kiv") 
                { data_status = "KIV"; this.status = "Search"; }
                else if (g_p.data_status == "Contact")
                { data_status = "Contacting Agent"; this.status = "Search"; }
            }

            if (g_p.status == "3")
            {
                if (g_p.data_status == "Treated")
                { data_status = "Treated"; this.status = "Opposition"; }
                else if (g_p.data_status == "Kiv")
                { data_status = "KIV"; this.status = "Opposition"; }
                else if (g_p.data_status == "Contact")
                { data_status = "Contacting Agent"; this.status = "Opposition"; }
            }

            if (g_p.status == "4")
            {
                if (g_p.data_status == "Treated")
                { data_status = "Treated"; this.status = "Certificate"; }
                else if (g_p.data_status == "Kiv")
                { data_status = "KIV"; this.status = "Certificate"; }
                else if (g_p.data_status == "Contact")
                { data_status = "Contacting Agent"; this.status = "Certificate"; }
            }

            if (g_p.status == "5")
            {
                if (g_p.data_status == "Treated")
                { data_status = "Treated"; this.status = "Acceptance"; }
                else if (g_p.data_status == "Kiv")
                { data_status = "KIV"; this.status = "Acceptance"; }
                else if (g_p.data_status == "Contact")
                { data_status = "Contacting Agent"; this.status = "Acceptance"; }
            }
           
        }
    }
}