namespace cld.admin.tm
{
    using admin ;
    using Classes ;
    using System;
    using System.Collections.Generic;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public class pubview_data : UserControl
    {
        public string admin = "";
        public string admin_status = "2";
        public int i;
        protected Label Label27;
        protected Label Label28;
        protected Label Label29;
        protected Label Label34;
        protected Label Label35;
        protected Label Label36;
        protected Label Label37;
        protected Label Label38;
        protected Label Label40;
        protected Label Label41;
        protected Label Label42;
        protected Label Label44;
        protected Label Label46;
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

