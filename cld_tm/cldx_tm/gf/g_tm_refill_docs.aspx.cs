namespace cld.gf
{
    using Brettle.Web.NeatUpload;
    using cld.Classes;
    using System;
    using System.IO;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public partial class g_tm_refill_docs : Page
    {
        public string ack_status = "0";
        public string app_doc_newfilename = "";
        public string app_type = "";
        public string ass_doc_newfilename = "";
        public string cert_doc_newfilename = "";
        public string doc_path = "";
        public string logo_desc = "no";
        public string logo_pic_newfilename = "";
        public string merger_doc_newfilename = "";
        public string pub_doc_newfilename = "";
        public string pwalletID = "0";
        public string serverpath;
        public int status;
        public string sup_doc_newfilename = "";
        public tm t = new tm();

        protected void btn_ack_Click(object sender, EventArgs e)
        {
            if (this.Session["vid"] != null)
            {
                base.Response.Redirect("./g_ack.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + this.Session["vid"].ToString());
            }
            else
            {
                base.Response.Redirect("./g_appstatus.aspx");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["app_type"] != null)
            {
                this.app_type = this.Session["app_type"].ToString();
            }
            if (this.Session["cert_doc_newfilename"] != null)
            {
                this.cert_doc_newfilename = this.Session["cert_doc_newfilename"].ToString();
            }
            if (this.Session["ass_doc_newfilename"] != null)
            {
                this.ass_doc_newfilename = this.Session["ass_doc_newfilename"].ToString();
            }
            if (this.Session["merger_doc_newfilename"] != null)
            {
                this.merger_doc_newfilename = this.Session["merger_doc_newfilename"].ToString();
            }
            if (this.Session["logo_pic_newfilename"] != null)
            {
                this.logo_pic_newfilename = this.Session["logo_pic_newfilename"].ToString();
            }
            if (this.Session["app_doc_newfilename"] != null)
            {
                this.app_doc_newfilename = this.Session["app_doc_newfilename"].ToString();
            }
            if (this.Session["pub_doc_newfilename"] != null)
            {
                this.pub_doc_newfilename = this.Session["pub_doc_newfilename"].ToString();
            }
            if (this.Session["sup_doc_newfilename"] != null)
            {
                this.sup_doc_newfilename = this.Session["sup_doc_newfilename"].ToString();
            }
            if (this.Session["g_pwallet"] != null)
            {
                this.pwalletID = this.Session["g_pwallet"].ToString();
            }
            if (this.Session["logo_desc"] != null)
            {
                this.logo_desc = this.Session["logo_desc"].ToString();
            }
            this.btn_all_doc.Click += new EventHandler(this.upload_Clicked);
            this.serverpath = base.Server.MapPath("~/");
            bool isPostBack = this.Page.IsPostBack;
        }

        private void upload_Clicked(object sender, EventArgs e)
        {
            if (this.Session["new_miID"] != null)
            {
                this.doc_path = base.Server.MapPath("~/") + "admin/tm/gf/docz/" + this.Session["new_miID"].ToString() + "/";
                if (!Directory.Exists(this.doc_path))
                {
                    Directory.CreateDirectory(this.doc_path);
                }
                if (this.app_type == "cert")
                {
                    if (base.IsValid && this.fu_cert_doc.HasFile)
                    {
                        this.cert_doc_newfilename = Path.Combine(this.doc_path, this.fu_cert_doc.FileName.Replace(" ", "_"));
                        this.fu_cert_doc.MoveTo(Path.Combine(this.doc_path, this.fu_cert_doc.FileName.Replace(" ", "_")), MoveToOptions.Overwrite);
                        this.cert_doc_newfilename = this.cert_doc_newfilename.Replace(base.Server.MapPath("~/") + "admin/tm/gf/", "");
                        this.Session["cert_doc_newfilename"] = this.cert_doc_newfilename;
                    }
                    if (base.IsValid && this.fu_pub_doc.HasFile)
                    {
                        this.pub_doc_newfilename = Path.Combine(this.doc_path, this.fu_pub_doc.FileName.Replace(" ", "_"));
                        this.fu_pub_doc.MoveTo(this.pub_doc_newfilename, MoveToOptions.Overwrite);
                        this.pub_doc_newfilename = this.pub_doc_newfilename.Replace(base.Server.MapPath("~/") + "admin/tm/gf/", "");
                        this.Session["pub_doc_newfilename"] = this.pub_doc_newfilename;
                    }
                    if (this.Session["certID"] != null)
                    {
                        this.t.updateGeneral_G_TmDocz(this.cert_doc_newfilename, this.pub_doc_newfilename, "cert", this.Session["certID"].ToString());
                    }
                    this.app_type = "";
                }
                if (this.app_type == "ass")
                {
                    if (base.IsValid && this.fu_ass_doc.HasFile)
                    {
                        this.ass_doc_newfilename = Path.Combine(this.doc_path, this.fu_ass_doc.FileName.Replace(" ", "_"));
                        this.fu_ass_doc.MoveTo(this.ass_doc_newfilename, MoveToOptions.Overwrite);
                        this.ass_doc_newfilename = this.ass_doc_newfilename.Replace(base.Server.MapPath("~/") + "admin/tm/gf/", "");
                        this.Session["ass_doc_newfilename"] = this.ass_doc_newfilename;
                        if (this.Session["assID"] != null)
                        {
                            this.t.updateGeneral_G_TmDocz(this.ass_doc_newfilename, "", "ass", this.Session["assID"].ToString());
                        }
                    }
                    this.app_type = "";
                }
                if (this.app_type == "merger")
                {
                    if (base.IsValid && this.fu_merger_doc.HasFile)
                    {
                        this.merger_doc_newfilename = Path.Combine(this.doc_path, this.fu_merger_doc.FileName.Replace(" ", "_"));
                        this.fu_merger_doc.MoveTo(this.merger_doc_newfilename, MoveToOptions.Overwrite);
                        this.merger_doc_newfilename = this.merger_doc_newfilename.Replace(base.Server.MapPath("~/") + "admin/tm/gf/", "");
                        this.Session["merger_doc_newfilename"] = this.merger_doc_newfilename;
                        if (this.Session["mergerID"] != null)
                        {
                            this.t.updateGeneral_G_TmDocz(this.cert_doc_newfilename, "", "merger", this.Session["mergerID"].ToString());
                        }
                    }
                    this.app_type = "";
                }
                if (((this.Session["logo_desc"] != null) && (this.Session["logo_desc"].ToString() == "yes")) && (base.IsValid && this.fu_logo_pic.HasFile))
                {
                    this.logo_pic_newfilename = Path.Combine(this.doc_path, this.fu_logo_pic.FileName.Replace(" ", "_"));
                    this.fu_logo_pic.MoveTo(this.logo_pic_newfilename, MoveToOptions.Overwrite);
                    this.logo_pic_newfilename = this.logo_pic_newfilename.Replace(base.Server.MapPath("~/") + "admin/tm/gf/", "");
                    this.Session["logo_pic_newfilename"] = this.logo_pic_newfilename;
                }
                if (base.IsValid && this.fu_app_doc.HasFile)
                {
                    this.app_doc_newfilename = Path.Combine(this.doc_path, this.fu_app_doc.FileName.Replace(" ", "_"));
                    this.fu_app_doc.MoveTo(this.app_doc_newfilename, MoveToOptions.Overwrite);
                    this.app_doc_newfilename = this.app_doc_newfilename.Replace(base.Server.MapPath("~/") + "admin/tm/gf/", "");
                    this.Session["app_doc_newfilename"] = this.app_doc_newfilename;
                }
                if (base.IsValid && this.fu_sup_doc.HasFile)
                {
                    this.sup_doc_newfilename = Path.Combine(this.doc_path, this.fu_sup_doc.FileName.Replace(" ", "_"));
                    this.fu_sup_doc.MoveTo(this.sup_doc_newfilename, MoveToOptions.Overwrite);
                    this.sup_doc_newfilename = this.sup_doc_newfilename.Replace(base.Server.MapPath("~/") + "admin/tm/gf/", "");
                    this.Session["sup_doc_newfilename"] = this.sup_doc_newfilename;
                }
                if (((this.Session["new_miID"] != null) && (this.Session["new_miID"].ToString() != "")) && ((this.Session["g_pwalletID"] != null) && (this.Session["g_pwalletID"].ToString() != "")))
                {
                    if (Convert.ToInt16(this.t.updateG_TmDocz(this.app_doc_newfilename, this.logo_pic_newfilename, this.sup_doc_newfilename, this.Session["new_miID"].ToString())) <= 0)
                    {
                        base.Response.Redirect("http://www.iponigeria.com/userarea/dashboard");
                    }
                    else if (this.t.updateGPwalletStage(this.Session["g_pwalletID"].ToString(), "5") != "")
                    {
                        this.status = this.t.updateIpoApplicationReferenceStatus(this.Session["vid"].ToString(), this.Session["xgt"].ToString(), "1");
                        this.ack_status = "1";
                    }
                }
                else
                {
                    base.Response.Redirect("http://www.iponigeria.com/userarea/dashboard");
                }
            }
        }
    }
}

