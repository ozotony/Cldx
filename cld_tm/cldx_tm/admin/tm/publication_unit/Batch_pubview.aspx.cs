namespace cld.admin.tm.publication_unit
{
    using admin;
    using Classes;
    using System;
    using System.Collections.Generic;
    using System.Web.UI;
    using System.Web.UI.WebControls;


    public partial class Batch_pubview : System.Web.UI.Page
    {
        public string admin = "";
        public string admin_status = "4";
        public int i;
        public List<tm.Address> lt_addy = new List<tm.Address>();
        public List<tm.AddressService> lt_addy_service = new List<tm.AddressService>();
        public List<tm.Applicant> lt_app = new List<tm.Applicant>();
        public List<zues.MarkInfo> lt_mi = new List<zues.MarkInfo>();
        public List<zues.Pwallet> lt_p = new List<zues.Pwallet>();
        public List<tm.Representative> lt_rep = new List<tm.Representative>();
        public List<tm.Address> lt_rep_addy = new List<tm.Address>();
        public List<tm.Stage> lt_stage = new List<tm.Stage>();
        public string mark_infoID;
        public string pID;
        public string rbval_text = "";
        public string succ;
        public tm t = new tm();
        public string xofficer;
        public zues z = new zues();
        public int current_batch_no;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["pwalletID"] != null)
            {
                if (Session["pwalletID"].ToString() != "")
                { this.admin = Session["pwalletID"].ToString(); }
                else
                { base.Response.Redirect("../lo.aspx"); }
            }
            else
            { base.Response.Redirect("../lo.aspx"); }
            if ((Request.QueryString["bno"] != null) && (Request.QueryString["bno"].ToString() != ""))
            {
                current_batch_no = Convert.ToInt32(Request.QueryString["bno"].ToString());
                this.lt_mi = this.z.getBatchPublishMarkInfoRS("5", "Published", Request.QueryString["bno"].ToString());
            }
        }
    }
}