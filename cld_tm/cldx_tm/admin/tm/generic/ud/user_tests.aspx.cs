    using Odyssey;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

namespace cld.admin.tm.generic.ud
{
    using Classes;
    public partial class user_tests : Page
    {
       
        public string admin = "";
        protected int app_succ;
        protected int applicant_succ;
        protected int ass_show;
        public Email c_email = new Email();
        protected int cert_show;
        protected int change_show;
        public List<XObjs.Fee_list> fee_list = new List<XObjs.Fee_list>();
        public int file_len = 0x400;
        public string file_string = "Xavier";
        public XObjs.Gen_Agent_info g_agent_info = new XObjs.Gen_Agent_info();
        public XObjs.G_App_info g_app_info = new XObjs.G_App_info();
        public XObjs.G_Applicant_info g_applicant_info = new XObjs.G_Applicant_info();
        public XObjs.G_Ass_info g_ass_info = new XObjs.G_Ass_info();
        public XObjs.G_Cert_info g_cert_info = new XObjs.G_Cert_info();
        public XObjs.G_Change_info g_change_info = new XObjs.G_Change_info();
        public XObjs.G_Merger_info g_merger_info = new XObjs.G_Merger_info();
        public XObjs.G_Other_items_info g_other_items_info = new XObjs.G_Other_items_info();
        public XObjs.G_Prelim_search_info g_prelim_search_info = new XObjs.G_Prelim_search_info();
        public XObjs.G_Pwallet g_pwallet = new XObjs.G_Pwallet();
        public XObjs.G_Renewal_info g_renewal_info = new XObjs.G_Renewal_info();
        public XObjs.G_Tm_info g_tm_info = new XObjs.G_Tm_info();
        public string html_msg = "";
        public zues.Adminz lt_cur_admin_details = new zues.Adminz();
        public List<zues.G_TmOffice> lt_g_tm_office = new List<zues.G_TmOffice>();
        public zues.Adminz lt_x_admin_details = new zues.Adminz();
        protected int merger_show;
        protected int others_show;
        public string pID;
        protected int prelim_show;
        public string pwalletID = "0";
        public string rbval_text = "";
        protected int renewal_show;
        public Retriever ret = new Retriever();
        public string serverpath = "";
        public string status = "0";
        public string succ;
        public tm t = new tm();
        protected int tm_info_succ;
        protected int x_succ;
        public string xcomments = "";
        public string xofficer;
        public zues z = new zues();
        public UserDocs c_ud = new UserDocs();

        protected void Page_Load(object sender, EventArgs e)
        {  
            //if (this.Session["pwalletID"] != null) { }
            //else {  base.Response.Redirect("../../lo.aspx");  }
            
        }

     
       
    }
}