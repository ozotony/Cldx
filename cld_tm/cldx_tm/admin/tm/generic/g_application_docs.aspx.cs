using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Brettle.Web.NeatUpload;

namespace cld.admin.tm.generic
{
    using Classes;
    public partial class g_application_docs : System.Web.UI.Page
    {
        public string doc_path = "";
        public string pic_path = "";
        public string status ="0";
        public string pwalletID = "0";
        public string serverpath;
        public string ack_status = "0";
        public string vid = "";
        public string logo_text = "0";
        
        public string sup_doc1_newfilename = "";
        public string sup_doc2_newfilename = "";
        public string sup_doc3_newfilename = "";

        public tm t = new tm();

        private void upload_Clicked(object sender, EventArgs e)
        {
            if (Session["g_officeID"] != null)
            {
                doc_path = base.Server.MapPath("~/") + "admin/tm/generic/G_Docz/" + Session["g_officeID"].ToString() + "/";
                if (!Directory.Exists(doc_path))
                {
                    Directory.CreateDirectory(doc_path);
                }              
                
                if (IsValid && fu_sup_doc1.HasFile)
                {
                    sup_doc1_newfilename = Path.Combine(doc_path, fu_sup_doc1.FileName.Replace(" ", "_"));
                    fu_sup_doc1.MoveTo(sup_doc1_newfilename, MoveToOptions.Overwrite);
                }
                if (IsValid && fu_sup_doc2.HasFile)
                {
                    sup_doc2_newfilename = Path.Combine(doc_path, fu_sup_doc2.FileName.Replace(" ", "_"));
                    fu_sup_doc2.MoveTo(sup_doc2_newfilename, MoveToOptions.Overwrite);
                }
                if (IsValid && fu_sup_doc3.HasFile)
                {
                    sup_doc3_newfilename = Path.Combine(doc_path, fu_sup_doc3.FileName.Replace(" ", "_"));
                    fu_sup_doc3.MoveTo(sup_doc3_newfilename, MoveToOptions.Overwrite);
                }
                sup_doc1_newfilename = sup_doc1_newfilename.Replace(base.Server.MapPath("~/") + "admin/tm/", "");
                sup_doc2_newfilename = sup_doc2_newfilename.Replace(base.Server.MapPath("~/") + "admin/tm/", "");
                sup_doc3_newfilename = sup_doc3_newfilename.Replace(base.Server.MapPath("~/") + "admin/tm/", "");

               
                Session["sup_doc1_newfilename"] = sup_doc1_newfilename;
                Session["sup_doc2_newfilename"] = sup_doc2_newfilename;
                Session["sup_doc3_newfilename"] = sup_doc3_newfilename;

                if (Session["g_officeID"] != null)
                {
                    if (t.UpdateG_TmOfficeDocz(sup_doc1_newfilename, sup_doc2_newfilename, sup_doc3_newfilename, Session["g_officeID"].ToString()) > 0)
                        {
                            logo_text = "1";
                            this.status = "1";
                            if (this.status == "1")
                            {
                                ack_status = "1";
                            }
                            else
                            {
                                // base.Response.Redirect("http://www.iponigeria.com/userarea/dashboard");
                            }
                        }                    
                }

             }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["sup_doc1_newfilename"] != null) { sup_doc1_newfilename = Session["sup_doc1_newfilename"].ToString(); }
            if (Session["sup_doc2_newfilename"] != null) { sup_doc2_newfilename = Session["sup_doc2_newfilename"].ToString(); }
            if (Session["sup_doc3_newfilename"] != null) { sup_doc3_newfilename = Session["sup_doc3_newfilename"].ToString(); }
           
            btn_all_doc.Click += new System.EventHandler(this.upload_Clicked);
            this.serverpath = base.Server.MapPath("~/"); 
            
        }

        protected void btn_ack_Click(object sender, EventArgs e)
        {
            if (Session["Office"] != null)
            {
                string office = Session["Office"].ToString();
                if (office == "Search") { Response.Redirect("../search_unit/generic_profile.aspx"); }
                if (office == "Opposition") { Response.Redirect("../opposition_unit/generic_profile.aspx"); }
                if (office == "Certificate") { Response.Redirect("../certification_unit/generic_profile.aspx"); }
                if (office == "Acceptance") { Response.Redirect("../acceptance_unit/generic_profile.aspx"); }
            }
            
        }
    }
}