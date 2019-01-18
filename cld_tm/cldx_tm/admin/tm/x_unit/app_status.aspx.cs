using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace cld.admin.tm.x_unit
{
    using admin;
    using Classes;
    public partial class app_status : System.Web.UI.Page
    {
        public string agt;
        public List<tm.Stage> lt_pw = new List<tm.Stage>();
        public List<tm.Applicant> lt_app = new List<tm.Applicant>();
        public List<tm.MarkInfo> lt_mi = new List<tm.MarkInfo>();
        public List<tm.AddressService> lt_aos = new List<tm.AddressService>();
        public List<tm.Representative> lt_rep = new List<tm.Representative>();
        public List<tm.Address> lt_appaddy = new List<tm.Address>();
        public List<tm.Address> lt_repaddy = new List<tm.Address>();
        public string r;
        public int showt;
        public string trans_status = "";
        public string multiple_status = "";
        public string multiple_succ_status = "";
        public string pwallet_status = "None";
        public string appx_status = "None";
        public string mark_status = "None";
        public string aos_status = "None";
        public string rep_status = "None";
        public string appaddy_status = "None";
        public string repaddy_status = "None";
        public string admin = "";
        public tm t = new tm();
        public zues z = new zues();

        protected void BtnCheckStatus_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("./appstatus.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["pwalletID"] != null)
            {
                if (this.Session["pwalletID"].ToString() != "")
                {
                    this.admin = this.Session["pwalletID"].ToString();
                    this.Session["xofficer"] = this.admin;
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
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            if (this.xref.Text != "")
            {
                if (this.xref.Text.Contains("OAI/TM/"))
                {
                    this.xref.Text = this.xref.Text.Replace("OAI/TM/", "");
                }
                this.r = this.xref.Text; Session["edit_transID"] = xref.Text;
                multiple_succ_status = Session["edit_transID"].ToString();
                this.lt_pw = this.t.getStageByValidationID(this.xref.Text);
                if (this.lt_pw.Count != 0)
                {
                    pwallet_status = "RECORD EXISTS.";

                    lt_app = t.getApplicantListByUserID(lt_pw[0].ID);
                    if (this.lt_app.Count != 0)   { appx_status = "RECORD EXISTS."; }
                    lt_mi = t.getMarkInfoByUserID(lt_pw[0].ID);
                    if (this.lt_mi.Count != 0) {    mark_status = "RECORD EXISTS."; }
                    lt_aos = t.getAddressServiceListByID(lt_pw[0].ID);
                    if (this.lt_aos.Count != 0)  { aos_status = "RECORD EXISTS."; }
                    lt_rep = t.getRepListByUserID(lt_pw[0].ID);
                    if (this.lt_rep.Count != 0) {  rep_status = "RECORD EXISTS.";  }
                    if (this.lt_app.Count != 0)  { 
                        lt_appaddy = t.getAddressListByID(lt_app[0].addressID);
                        if (this.lt_appaddy.Count != 0)  {  appaddy_status = "RECORD EXISTS."; }
                    }
                    if (this.lt_rep.Count != 0) {
                        lt_repaddy = t.getAddressListByID(lt_rep[0].addressID);
                        if (this.lt_repaddy.Count != 0)  {     repaddy_status = "RECORD EXISTS."; }
                    }
                    if ((lt_aos.Count > 1) || (lt_app.Count > 1) || (lt_rep.Count > 1) || (lt_mi.Count > 1) || (lt_appaddy.Count > 1) || (lt_repaddy.Count > 1) || (lt_pw.Count > 1))
                    {
                        multiple_status = "1";
                    }
                    this.showt = 1;
                    //this.admin = this.Session["pwalletID"].ToString();
                    //t.activity_log(this.admin, "Edit Status", "Update", lt_pw[0].ID , lt_pw[0].data_status );
                }
                else
                {   trans_status = "THE REFERENCE NUMBER DOESN'T EXIST ON THE SYSTEM";  }
               
            }
            else
            {  Response.Write("<script language=JavaScript>alert('PLEASE ENTER A VALID REFERENCE NUMBER')</script>"); }
        }

        protected void btnRefresh0_Click(object sender, EventArgs e)
        {
            Response.Redirect("./app_status.aspx");
        }
        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            Response.Redirect("./app_status.aspx");
        }
        protected void btnApp_Click(object sender, EventArgs e)
        {
            Response.Redirect("../edit_applicant.aspx?t=" + Session["edit_transID"].ToString());
        }
        protected void btnMark_Click(object sender, EventArgs e)
        {
            Response.Redirect("../edit_mark.aspx?t=" + Session["edit_transID"].ToString());
        }
        protected void btnAos_Click(object sender, EventArgs e)
        {
            Response.Redirect("../edit_aos.aspx?t=" + Session["edit_transID"].ToString());
        }
        protected void btnRep_Click(object sender, EventArgs e)
        {
            Response.Redirect("../edit_rep.aspx?t=" + Session["edit_transID"].ToString());
        }
        protected void btnAppAddy_Click(object sender, EventArgs e)
        {
            Response.Redirect("../edit_applicant.aspx?t=" + Session["edit_transID"].ToString());
        }
        protected void btnRepAddy_Click(object sender, EventArgs e)
        {
            Response.Redirect("../edit_rep.aspx?t=" + Session["edit_transID"].ToString());
        }

        protected void btnDeleteMultiple_Click(object sender, EventArgs e)
        {
            string path = Server.MapPath("~/");
            lt_pw = t.getStageByValidationID(Session["edit_transID"].ToString());
            if (lt_pw.Count > 0)
            {
                lt_app = t.getApplicantListByUserID(lt_pw[0].ID);
                lt_mi = t.getMarkInfoByUserID(lt_pw[0].ID);
                lt_aos = t.getAddressServiceListByID(lt_pw[0].ID);
                lt_rep = t.getRepListByUserID(lt_pw[0].ID);
                if (lt_app.Count > 0) { lt_appaddy = t.getAddressListByID(lt_app[0].addressID); }
                if (lt_rep.Count > 0) { lt_repaddy = t.getAddressListByID(lt_rep[0].addressID); }
            }
            if (lt_pw.Count > 1)
            {
                for(int i=0;i<lt_pw.Count-1;i++)
                {
                    t.flushPwalletByID(lt_pw[i].ID);
                }
            }

            if (lt_app.Count > 1)
            {
                for (int i = 0; i < lt_app.Count-1; i++)
                {
                    t.flushApplicantByID(lt_app[i].ID);
                    t.flushAddressByID(lt_app[i].addressID);
                }
            }

            if (lt_mi.Count > 1)
            {
                for (int i = 0; i < lt_mi.Count-1; i++)
                {
                    t.flushMark_infoByID(path,lt_mi[i].xID);
                }
            }

            if (lt_aos.Count > 1)
            {
                for (int i = 0; i < lt_aos.Count-1; i++)
                {
                    t.flushAddress_serviceByID(lt_aos[i].ID);
                }
            }

            if (lt_rep.Count > 1)
            {
                for (int i = 0; i < lt_rep.Count-1; i++)
                {
                    t.flushRepresentativeByID(lt_rep[i].ID);
                    t.flushAddressByID(lt_rep[i].addressID);
                }
            }

            multiple_succ_status = "Entries Deleted Successfully!!";

            this.lt_pw = this.t.getStageByValidationID(Session["edit_transID"].ToString());
            if (this.lt_pw.Count != 0)
            {
                pwallet_status = "RECORD EXISTS.";

                lt_app = t.getApplicantListByUserID(lt_pw[0].ID);
                if (this.lt_app.Count != 0) { appx_status = "RECORD EXISTS."; }
                lt_mi = t.getMarkInfoByUserID(lt_pw[0].ID);
                if (this.lt_mi.Count != 0) { mark_status = "RECORD EXISTS."; }
                lt_aos = t.getAddressServiceListByID(lt_pw[0].ID);
                if (this.lt_aos.Count != 0) { aos_status = "RECORD EXISTS."; }
                lt_rep = t.getRepListByUserID(lt_pw[0].ID);
                if (this.lt_rep.Count != 0) { rep_status = "RECORD EXISTS."; }
                if (this.lt_app.Count != 0)
                {
                    lt_appaddy = t.getAddressListByID(lt_app[0].addressID);
                    if (this.lt_appaddy.Count != 0) { appaddy_status = "RECORD EXISTS."; }
                }
                if (this.lt_rep.Count != 0)
                {
                    lt_repaddy = t.getAddressListByID(lt_rep[0].addressID);
                    if (this.lt_repaddy.Count != 0) { repaddy_status = "RECORD EXISTS."; }
                }
                if ((lt_aos.Count > 1) || (lt_app.Count > 1) || (lt_rep.Count > 1) || (lt_mi.Count > 1) || (lt_appaddy.Count > 1) || (lt_repaddy.Count > 1) || (lt_pw.Count > 1))
                {
                    multiple_status = "1";
                }
                this.showt = 1;
            }
            else
            { trans_status = "THE REFERENCE NUMBER DOESN'T EXIST ON THE SYSTEM"; }
               
        }

        protected void btnAddApp_Click(object sender, EventArgs e)
        {
            Response.Redirect("./add_applicant.aspx?0636tghvoh450=" + Session["edit_transID"].ToString());
        }

        protected void btnAddMark_Click(object sender, EventArgs e)
        {
            Response.Redirect("./add_mark.aspx?0636tghvoh450=" + Session["edit_transID"].ToString());
        }

        protected void btnAddAos_Click(object sender, EventArgs e)
        {
            Response.Redirect("./add_aos.aspx?0636tghvoh450=" + Session["edit_transID"].ToString());
        }

        protected void btnAddRep_Click(object sender, EventArgs e)
        {
            Response.Redirect("./add_rep.aspx?0636tghvoh450=" + Session["edit_transID"].ToString());
        }
        
    }
}