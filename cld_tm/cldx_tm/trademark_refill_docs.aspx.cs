using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Brettle.Web.NeatUpload;

namespace cld
{
    using Classes;
    public partial class trademark_refill_docs : System.Web.UI.Page
    {
        public string doc_path = "";
        public string pic_path = "";
        public string status ="0";
        public string pwalletID = "0";
        public string serverpath;
        public string ack_status = "0";
        public string vid = "";
        public string logo_text = "0";

        public string logo_pic_newfilename = "";
        public string auth_doc_newfilename = "";
        public string sup_doc1_newfilename = "";
        public string sup_doc2_newfilename = "";

        public tm t = new tm();

        private void upload_Clicked(object sender, EventArgs e)
        {
            if (Session["mi_updateID"] != null)
            {
                doc_path = base.Server.MapPath("~/") + "admin/tm/docz/" + Session["mi_updateID"].ToString() + "/";
                pic_path = base.Server.MapPath("~/") + "admin/tm/Picz/" + Session["mi_updateID"].ToString() + "/";
                if (!Directory.Exists(doc_path))
                {
                    Directory.CreateDirectory(doc_path);
                }
                if (!Directory.Exists(pic_path))
                {
                    Directory.CreateDirectory(pic_path);
                }   
                if (IsValid && fu_logo_pic.HasFile)
                {
                    logo_pic_newfilename = Path.Combine(pic_path, fu_logo_pic.FileName.Replace(" ", "_"));
                    fu_logo_pic.MoveTo(logo_pic_newfilename, MoveToOptions.Overwrite);
                }

                if (IsValid && fu_auth_doc.HasFile)
                {
                    auth_doc_newfilename = Path.Combine(doc_path, fu_auth_doc.FileName.Replace(" ", "_"));
                    fu_auth_doc.MoveTo(auth_doc_newfilename, MoveToOptions.Overwrite);
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
                logo_pic_newfilename = logo_pic_newfilename.Replace(base.Server.MapPath("~/") + "admin/tm/", "");
                auth_doc_newfilename = auth_doc_newfilename.Replace(base.Server.MapPath("~/") + "admin/tm/", "");
                sup_doc1_newfilename = sup_doc1_newfilename.Replace(base.Server.MapPath("~/") + "admin/tm/", "");
                sup_doc2_newfilename = sup_doc2_newfilename.Replace(base.Server.MapPath("~/") + "admin/tm/", "");

                Session["logo_pic_newfilename"] = logo_pic_newfilename;
                Session["auth_doc_newfilename"] = auth_doc_newfilename;
                Session["sup_doc1_newfilename"] = sup_doc1_newfilename;
                Session["sup_doc2_newfilename"] = sup_doc2_newfilename;

                if ((Session["logo_text"] != null) && (Session["logo_text"].ToString() != "2"))
                {
                    if (logo_pic_newfilename != "0")
                    {
                        if (t.UpdateMarkDocz(logo_pic_newfilename, auth_doc_newfilename, sup_doc1_newfilename, sup_doc2_newfilename, Session["mi_updateID"].ToString()) > 0)
                        {
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

                else
                {                   
                        if (t.UpdateMarkDocz(logo_pic_newfilename, auth_doc_newfilename, sup_doc1_newfilename, sup_doc2_newfilename, Session["mi_updateID"].ToString()) > 0)
                        {
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
            if (Session["logo_pic_newfilename"] != null) { logo_pic_newfilename = Session["logo_pic_newfilename"].ToString(); }
            if (Session["auth_doc_newfilename"] != null) { auth_doc_newfilename = Session["auth_doc_newfilename"].ToString(); }
            if (Session["sup_doc1_newfilename"] != null) { sup_doc1_newfilename = Session["sup_doc1_newfilename"].ToString(); }
            if (Session["sup_doc2_newfilename"] != null) { sup_doc2_newfilename = Session["sup_doc2_newfilename"].ToString(); }
            if ((Session["logo_text"] != null)&&(Session["logo_text"].ToString() != "2")) { logo_text = "1"; }
            
            btn_all_doc.Click += new System.EventHandler(this.upload_Clicked);
            this.serverpath = base.Server.MapPath("~/"); 
            
        }

        protected void btn_ack_Click(object sender, EventArgs e)
        {
            if ((this.Session["vid"] != null)&&(this.Session["aid"] != null))
            {
             int stat =  this.t.updateIpoApplicationReferenceStatus(Session["vid"].ToString(), Session["aid"].ToString(), "1");
             if (stat ==1)
             {
                 base.Response.Redirect("./tm_ackrep.aspx?0001234445=" + Session["vid"].ToString() + "&94384238=" + Session["aid"].ToString());
             }
            }
            else
            {
                base.Response.Redirect("./tm_ackrep.aspx?0001234445=" + Session["vid"].ToString() + "&94384238=" + Session["aid"].ToString());
            }
        }
    }
}