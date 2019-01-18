namespace cld.admin.tm.publication_unit
{
    using admin;
    using Classes;
    using System;
    using System.Collections.Generic;
    using System.Web.UI;
    using System.Web.UI.WebControls;


    public partial class pubview : System.Web.UI.Page
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

        protected void Page_Load(object sender, EventArgs e)
        {
        this.lt_mi = this.z.getCriPublishMarkInfoRS("5", "Published");

        }
    }
}