using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Odyssey;
using cld.Classes;


namespace cld
{

    public partial class cp : System.Web.UI.Page
    {
        public string adminID = "0";
        public string code_text;
        public string enable_Captcha = "1";
        public string enable_Confirm = "0";
        public string enable_Save = "1";
        public string newp = "0";
        public string newState = "0";
        public string xnewpass1_text;
        public string xnewpass2_text = "";
        public zues z = new zues();
        public Odyssey.Odyssey ody = new Odyssey.Odyssey();
        public string serverpath = "";
        public string file_string = "Xavier";
        public int file_len = 1024;


        protected void ConfirmDetails_Click(object sender, EventArgs e)
        {
            int num = 0;
            if (this.xnewpass1.Text == "")
            {
                this.xnewpass1_text = "1";
                num++;
            }
            if (this.xnewpass2.Text == "")
            {
                this.xnewpass2_text = "1";
                num++;
            }
            if (this.xcode.Text == "")
            {
                this.code_text = "1";
                num++;
            }
            if (this.xnewpass1.Text != this.xnewpass2.Text)
            {
                num++;
            }
            if (num != 0)
            {
                base.Response.Write("<script language=JavaScript>alert('Please fill in the marked fileds or make sure the passwords match!!')</script>");
            }
            else
            {
                Session["Newpass"] = xnewpass1.Text;
                this.doCaptcha();
            }
        }

        protected void doCaptcha()
        {
            string str = "";
            if (base.Session["Captcha"] != null)
            {
                str = base.Session["Captcha"].ToString();
            }
            if (str == this.xcode.Text.ToUpper())
            {
                this.newState = "0";
                this.enable_Save = "0";
                this.enable_Confirm = "1";
                this.enable_Captcha = "0";
                this.newp = "1";
            }
            else
            {
                this.newState = "1";
                this.xcode.Text = "";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.serverpath = base.Server.MapPath("~/");

           
           this.adminID = base.Request.QueryString["x"];
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            string keydir = serverpath + "\\Handlers\\bf.pke";
            if (File.Exists(keydir))
            {
                StreamReader streamReader = new StreamReader(keydir, true);
                file_string = streamReader.ReadToEnd();
                streamReader.Close();
                if (file_string != null)
                {
                    string bitStrengthString = file_string.Substring(0, file_string.IndexOf("</BitStrength>") + 14);
                    file_string = file_string.Replace(bitStrengthString, "");
                }
            }
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
            if (this.xnewpass1.Text != "")
            {
                this.xnewpass1_text = this.xnewpass1.Text;
            }
            if (this.xnewpass2.Text != "")
            {
                this.xnewpass2_text = this.xnewpass2.Text;
            }
            if (Session["Newpass"] != null) { xnewpass1_text = Session["Newpass"].ToString(); }
            if (this.z.e_xadminz(this.adminID, ody.EncryptString(xnewpass1_text, file_len, file_string)) != "0")
            {
                   Session["Newpass"]=null;
                base.Response.Redirect("./control.aspx");
            }
            else
            {
                base.Response.Redirect("./cp.aspx");
            }
        }

        protected void xnewpass1_Unload(object sender, EventArgs e)
        {
            this.xnewpass1_text = this.xnewpass1.Text;
        }

        protected void xnewpass2_Unload(object sender, EventArgs e)
        {
            this.xnewpass2_text = this.xnewpass2.Text;
        }
    }
}