using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Brettle.Web.NeatUpload;
using System.IO;

namespace cld.admin.tm.x_unit.generic
{
    public partial class edit_forms_docs : System.Web.UI.Page
    {
        public string serverpath; public string doc_path = ""; public int status = 0; public string ack_status = "0";

        public Classes.tm t = new Classes.tm();
        public string cert_doc_newfilename = "";
        public string ass_doc_newfilename = "";
        public string merger_doc_newfilename = "";
        public string pub_doc_newfilename = "";
        public string logo_pic_newfilename = "";
        public string app_doc_newfilename = "";
        public string sup_doc_newfilename = "";
        public string pwalletID = "0";
        public string app_type = "";
        public string logo_desc = "no";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["app_type"] != null) { app_type = Session["app_type"].ToString(); }
            if (Session["cert_doc_newfilename"] != null) { cert_doc_newfilename = Session["cert_doc_newfilename"].ToString(); }
            if (Session["ass_doc_newfilename"] != null) { ass_doc_newfilename = Session["ass_doc_newfilename"].ToString(); }
            if (Session["merger_doc_newfilename"] != null) { merger_doc_newfilename = Session["merger_doc_newfilename"].ToString(); }
            if (Session["logo_pic_newfilename"] != null) { logo_pic_newfilename = Session["logo_pic_newfilename"].ToString(); }
            if (Session["app_doc_newfilename"] != null) { app_doc_newfilename = Session["app_doc_newfilename"].ToString(); }
            if (Session["pub_doc_newfilename"] != null) { pub_doc_newfilename = Session["pub_doc_newfilename"].ToString(); }
            if (Session["sup_doc_newfilename"] != null) { sup_doc_newfilename = Session["sup_doc_newfilename"].ToString(); }

            if (this.Session["g_pwallet"] != null) { this.pwalletID = this.Session["g_pwallet"].ToString(); }
            if (this.Session["logo_desc"] != null) { this.logo_desc = this.Session["logo_desc"].ToString(); }

            btn_all_doc.Click += new System.EventHandler(this.upload_Clicked);
            this.serverpath = base.Server.MapPath("~/");

            if (!Page.IsPostBack)
            {

            }
        }

        private void upload_Clicked(object sender, EventArgs e)
        {
            if (Session["new_miID"] != null)
            {
                doc_path = base.Server.MapPath("~/") + "admin/tm/gf/docz/" + Session["new_miID"].ToString() + "/";

                if (!Directory.Exists(doc_path)) { Directory.CreateDirectory(doc_path); }

                if (app_type == "cert")
                {
                    if (IsValid && fu_cert_doc.HasFile)
                    {
                        cert_doc_newfilename = Path.Combine(doc_path, fu_cert_doc.FileName.Replace(" ", "_"));
                        fu_cert_doc.MoveTo(Path.Combine(doc_path, fu_cert_doc.FileName.Replace(" ", "_")), MoveToOptions.Overwrite);
                        cert_doc_newfilename = cert_doc_newfilename.Replace(base.Server.MapPath("~/") + "admin/tm/gf/", "");
                        Session["cert_doc_newfilename"] = cert_doc_newfilename;
                    }
                    if (IsValid && fu_pub_doc.HasFile)
                    {
                        pub_doc_newfilename = Path.Combine(doc_path, fu_pub_doc.FileName.Replace(" ", "_"));
                        fu_pub_doc.MoveTo(pub_doc_newfilename, MoveToOptions.Overwrite);
                        pub_doc_newfilename = pub_doc_newfilename.Replace(base.Server.MapPath("~/") + "admin/tm/gf/", "");
                        Session["pub_doc_newfilename"] = pub_doc_newfilename;
                    }
                    if (Session["certID"] != null)
                    {
                        t.updateGeneral_G_TmDocz(cert_doc_newfilename, pub_doc_newfilename, "cert", Session["certID"].ToString());
                    }
                    app_type = "";
                }

                if (app_type == "ass")
                {
                    if (IsValid && fu_ass_doc.HasFile)
                    {
                        ass_doc_newfilename = Path.Combine(doc_path, fu_ass_doc.FileName.Replace(" ", "_"));
                        fu_ass_doc.MoveTo(ass_doc_newfilename, MoveToOptions.Overwrite);
                        ass_doc_newfilename = ass_doc_newfilename.Replace(base.Server.MapPath("~/") + "admin/tm/gf/", "");
                        Session["ass_doc_newfilename"] = ass_doc_newfilename;
                        if (Session["assID"] != null)
                        {
                            t.updateGeneral_G_TmDocz(ass_doc_newfilename, "", "ass", Session["assID"].ToString());
                        }
                    }
                    app_type = "";
                }

                if (app_type == "merger")
                {
                    if (IsValid && fu_merger_doc.HasFile)
                    {
                        merger_doc_newfilename = Path.Combine(doc_path, fu_merger_doc.FileName.Replace(" ", "_"));
                        fu_merger_doc.MoveTo(merger_doc_newfilename, MoveToOptions.Overwrite);
                        merger_doc_newfilename = merger_doc_newfilename.Replace(base.Server.MapPath("~/") + "admin/tm/gf/", "");
                        Session["merger_doc_newfilename"] = merger_doc_newfilename;
                        if (Session["mergerID"] != null)
                        {
                            t.updateGeneral_G_TmDocz(cert_doc_newfilename, "", "merger", Session["mergerID"].ToString());
                        }
                    }
                    app_type = "";
                }

                if ((Session["logo_desc"] != null) && (Session["logo_desc"].ToString() == "yes"))
                {
                    if (IsValid && fu_logo_pic.HasFile)
                    {
                        logo_pic_newfilename = Path.Combine(doc_path, fu_logo_pic.FileName.Replace(" ", "_"));
                        fu_logo_pic.MoveTo(logo_pic_newfilename, MoveToOptions.Overwrite);
                        logo_pic_newfilename = logo_pic_newfilename.Replace(base.Server.MapPath("~/") + "admin/tm/gf/", "");
                        Session["logo_pic_newfilename"] = logo_pic_newfilename;
                    }

                }
                if (IsValid && fu_app_doc.HasFile)
                {
                    app_doc_newfilename = Path.Combine(doc_path, fu_app_doc.FileName.Replace(" ", "_"));
                    fu_app_doc.MoveTo(app_doc_newfilename, MoveToOptions.Overwrite);
                    app_doc_newfilename = app_doc_newfilename.Replace(base.Server.MapPath("~/") + "admin/tm/gf/", "");
                    Session["app_doc_newfilename"] = app_doc_newfilename;
                }

                if (IsValid && fu_sup_doc.HasFile)
                {
                    sup_doc_newfilename = Path.Combine(doc_path, fu_sup_doc.FileName.Replace(" ", "_"));
                    fu_sup_doc.MoveTo(sup_doc_newfilename, MoveToOptions.Overwrite);
                    sup_doc_newfilename = sup_doc_newfilename.Replace(base.Server.MapPath("~/") + "admin/tm/gf/", "");
                    Session["sup_doc_newfilename"] = sup_doc_newfilename;
                }

                if (app_doc_newfilename != "")
                {
                    if ((Session["new_miID"] != null) && (Session["new_miID"].ToString() != "") && (Session["g_pwalletID"] != null) && (Session["g_pwalletID"].ToString() != ""))
                    {
                        if (Convert.ToInt16(t.updateG_TmDocz(app_doc_newfilename, logo_pic_newfilename, sup_doc_newfilename, Session["new_miID"].ToString())) > 0)
                        {
                            string p_succ = t.updateGPwalletStage(Session["g_pwalletID"].ToString(), "5");
                            this.status = 1;
                            if (p_succ != "")
                            {
                                // this.status = this.t.updateIpoApplicationReferenceStatus(Session["vid"].ToString(), Session["xgt"].ToString(), "1");
                                //if (this.status > 0)
                                //{
                                    ack_status = "1";
                                //}
                                //else
                                //{
                                   // base.Response.Redirect("http://www.iponigeria.com/userarea/dashboard");
                                //}
                            }
                        }
                        else
                        {
                            base.Response.Redirect("http://www.iponigeria.com/userarea/dashboard");
                        }
                    }
                    else
                    {
                        base.Response.Redirect("http://www.iponigeria.com/userarea/dashboard");
                    }

                }
            }
        }

        protected void btn_ack_Click(object sender, EventArgs e)
        {
            if (this.Session["vid"] != null)
            {
                base.Response.Redirect("./g_ack.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + Session["vid"].ToString());
            }
            else
            {
                Response.Redirect("./app_status.aspx");
            }
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("./profile.aspx");
        }
    }
}