using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace cld.admin.tm.x_unit
{
    using Classes;
    public partial class edit_status3 : System.Web.UI.Page
    {
        public string agt;
        public List<tm.Stage> lt_pw = new List<tm.Stage>();
        public List<tm.Applicant> lt_app = new List<tm.Applicant>();
        public List<tm.MarkInfo> lt_mi = new List<tm.MarkInfo>();
        public List<tm.AddressService> lt_aos = new List<tm.AddressService>();
        public List<tm.Representative> lt_rep = new List<tm.Representative>();
        public List<tm.Address> lt_appaddy = new List<tm.Address>();
        public List<tm.Address> lt_repaddy = new List<tm.Address>();
        public List<tm.TmOffice> lt_office = new List<tm.TmOffice>();
        public string r;
        public int showt;
        public string trans_status = "";
        public string xcomment = "REVERSAL";
        public string pwallet_status = "None";
        public string appx_status = "None";
        public string mark_status = "None";
        public string aos_status = "None";
        public string rep_status = "None";
        public string appaddy_status = "None";
        public string repaddy_status = "None";
        public string adminID = "";
        public string status = "N/A";
        public string data_status = "N/A";
        public string xstatus = "";
        public string xoffice = "";

        public tm t = new tm();
        public tm.TmOffice c_office = new tm.TmOffice();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["pwalletID"] != null)
            {
                if (Session["pwalletID"].ToString() != "")
                {
                    adminID = Session["pwalletID"].ToString();
                    Session["xofficer"] = adminID;
                }
                else
                {
                    base.Response.Redirect("../lo.aspx");
                }
            }
            else
            {
                base.Response.Redirect("../lo.aspx");
            }
            if (Session["trans_status"] != null)
            {
                trans_status = Session["trans_status"].ToString();
            }
            if (IsPostBack)
            {
                xstatus = select_xoffice.SelectedValue;
            }
            else
            { showt = 0; }
        }

        protected void SearchApplicant_Click(object sender, EventArgs e)
        {
            if (xref.Text != "")
            {
                if (xref.Text.Contains("OAI/TM/"))
                {
                    xref.Text = xref.Text.Replace("OAI/TM/", "");
                }
                r = xref.Text; Session["edit_transID"] = xref.Text;
                lt_pw = t.getStageByValidationID(xref.Text);
                if (lt_pw.Count > 0)
                {
                    pwallet_status = "RECORD EXISTS.";
                    Session["pwID"] = lt_pw[0].ID;
                    lt_app = t.getApplicantListByUserID(lt_pw[0].ID);
                    if (lt_app.Count != 0) { appx_status = "RECORD EXISTS."; }
                    lt_mi = t.getMarkInfoByUserID(lt_pw[0].ID);
                    if (lt_mi.Count != 0) { mark_status = "RECORD EXISTS."; }
                    lt_aos = t.getAddressServiceListByID(lt_pw[0].ID);
                    if (lt_aos.Count != 0) { aos_status = "RECORD EXISTS."; }
                    lt_rep = t.getRepListByUserID(lt_pw[0].ID);
                    if (lt_rep.Count != 0) { rep_status = "RECORD EXISTS."; }
                    if (lt_app.Count != 0)
                    {
                        lt_appaddy = t.getAddressListByID(lt_app[0].addressID);
                        if (lt_appaddy.Count != 0) { appaddy_status = "RECORD EXISTS."; }
                    }
                    if (lt_rep.Count != 0)
                    {
                        lt_repaddy = t.getAddressListByID(lt_rep[0].addressID);
                        if (lt_repaddy.Count != 0) { repaddy_status = "RECORD EXISTS."; }
                    }
                    if ((lt_aos.Count > 0) && (lt_app.Count > 0) && (lt_rep.Count > 0) && (lt_mi.Count > 0) && (lt_appaddy.Count > 0) && (lt_repaddy.Count > 0) && (lt_pw.Count > 0))
                    {
                        if ((lt_pw[0].stage.Trim() == "5") && (lt_pw[0].status.Trim() != "33") && (lt_pw[0].status.Trim() != "22") && (Convert.ToInt32(lt_pw[0].status.Trim()) >= 4))
                        {
                            lt_office = t.getTmOfficeDetailsByID(lt_pw[0].ID);
                            getCurrentStage(lt_office);
                            showt = 1;
                        }

                        //multiple_status = "1";
                    }
                }
                else
                { trans_status = "THE REFERENCE NUMBER DOESN'T EXIST ON THE SYSTEM"; }

            }
            else
            { Response.Write("<script language=JavaScript>alert('PLEASE ENTER A VALID REFERENCE NUMBER')</script>"); }
        }
        protected void getCurrentStage(List<tm.TmOffice> lt_pwx)
        {
            if (lt_pwx[0].admin_status == "1")
            {
                status = "Verification";
                if (lt_pwx[0].data_status == "Fresh") { data_status = "Untreated"; }
            }

            if (lt_pwx[0].admin_status == "14")
            {
                status = "Verification";
                if (lt_pwx[0].data_status == "Kiv") { data_status = "Kiv"; }
            }
            if (lt_pwx[0].admin_status == "2")
            {
                status = "Search";
                if (lt_pwx[0].data_status == "Re-conduct search") { data_status = "being re-conducted"; }
            }
            if (lt_pwx[0].admin_status == "22")
            {
                status = "Search 2";
                if (lt_pwx[0].data_status == "Re-conduct search 1") { data_status = "being re-conducted"; }
            }
            if (lt_pwx[0].admin_status == "3")
            {
                if (lt_pwx[0].data_status == "Search Conducted") { data_status = "being processed"; status = "Search 2"; }
                else if (lt_pwx[0].data_status == "Re-examine") { data_status = "being re-examined"; status = "Examiners"; }
            }
            if (lt_pwx[0].admin_status == "33")
            {
                status = "Examiners";
                if (lt_pwx[0].data_status == "Search 2 Conducted") { data_status = "being processed"; }
            }
            if (lt_pwx[0].admin_status == "4")
            {
                status = "Acceptance";
                if (lt_pwx[0].data_status == "Registrable") { data_status = "Accepted"; }
                else if (lt_pwx[0].data_status == "Refused") { data_status = "Refused"; }
                else if (lt_pwx[0].data_status == "Non-registrable") { data_status = "not-registrable"; }
            }
            if (lt_pwx[0].admin_status == "5")
            {
                if (lt_pwx[0].data_status == "Accepted") { data_status = "being published"; status = "Publication"; }
                else if (lt_pwx[0].data_status == "Deferred") { data_status = "been deferred"; status = "Publication"; }
            }
            if (lt_pwx[0].admin_status == "6")
            {
                status = "Opposition";
                if (lt_pwx[0].data_status == "Published") { data_status = "being published"; } else { data_status = "been opposed"; }
            }
            if (lt_pwx[0].admin_status == "7")
            {
                if (lt_pwx[0].data_status == "Not Opposed") { data_status = "being processed"; status = "Certification"; }
                else if (lt_pwx[0].data_status == "Deferred") { data_status = "been deferred"; status = "Certification"; }
            }
            if (lt_pwx[0].admin_status == "8")
            {
                status = "Registrars";
                if (lt_pwx[0].data_status == "Certified") { data_status = "being processed"; }
            }
            if (lt_pwx[0].admin_status == "9")
            {
                status = "Registrars";
                if (lt_pwx[0].data_status == "Registered") { data_status = "being registered"; }
            }

            trans_status = "Your application (\"OAI/TM/" + Session["edit_transID"].ToString() + ") is currently at the <strong> \"" + status + " Office\"</strong> and is currently <strong>\"" + data_status + "\"</strong><br />";
            Session["trans_status"] = trans_status;

        }

        protected void UpdateApplicant_Click(object sender, EventArgs e)
        {
            if (Session["pwID"] != null)
            {
                c_office.pwalletID = Session["pwID"].ToString();
            }
            c_office.data_status = select_xoffice.SelectedValue.Split('|')[0];
            c_office.admin_status = select_xoffice.SelectedValue.Split('|')[1];
            c_office.xcomment = "REVERSAL PROCESS: " + txt_comment.Text;
            c_office.xdoc1 = "";
            c_office.xdoc2 = "";
            c_office.xdoc3 = "";
            c_office.xofficer = Session["pwalletID"].ToString();
            c_office.reg_date = DateTime.Today.Date.ToString("yyyy-MM-dd"); ;
            c_office.xvisible = "1";
            int rev_succ = t.addReversal(c_office);
            if (rev_succ > 0)
            {
                txt_comment.Text = "";
                select_xoffice.SelectedIndex = 0;
                if (Session["edit_transID"] != null)
                {
                    trans_status = "<strong>THE STATUS FOR TRANSACTION ID " + Session["edit_transID"].ToString() + " FOR HAS BEEN UPDATED SUCCESSFULLY!!</strong>";
                }
                showt = 1;

                t.activity_log(adminID, "Edit Status", "Update", c_office.pwalletID, c_office.data_status, "", "", "", "", "", "");
            }
        }
    }
}