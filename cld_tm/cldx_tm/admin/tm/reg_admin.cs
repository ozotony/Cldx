namespace cld.admin.tm
{
    using admin ;
    using System;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using Odyssey;
    using System.IO;
    using cld.Classes;

    public class reg_admin : UserControl
    {
        public string admin = "";
        protected Button ConfirmDetails;
        protected SqlDataSource dsRole;
        public string email_text = "";
        public string enable_Captcha = "1";
        public string enable_Confirm = "0";
        public string enable_Save = "1";
        public string name_text = "";
        public int newState;
        public string pwalletID = "1";
        public string regID = "0";
        protected Button Save;
        public string telephone1_text = "";
        public string telephone2_text = "";
        public string vID = "";
        protected TextBox xcode;
        public string xcode_text = "";
        protected TextBox xemail;
        protected TextBox xname;
        protected DropDownList xrole;
        protected TextBox xtelephone1;
        protected TextBox xtelephone2;
        public string xType = "0";
        public zues z = new zues();
        public string file_string = "Xavier";
        public int file_len = 1024;
        public string serverpath = "";

        protected void ConfirmDetails_Click(object sender, EventArgs e)
        {
            int num = 0;
            if (this.xemail.Text == "")
            {
                this.email_text = "1";
                num++;
            }
            if (this.xname.Text == "")
            {
                this.name_text = "1";
                num++;
            }
            if (num != 0)
            {
                base.Response.Write("<script language=JavaScript>alert('Please fill in the marked fileds')</script>");
            }
            else
            {
                this.doCaptcha();
            }
        }

        protected void doCaptcha()
        {
            string str = "";
            if (Session["Captcha"] != null)
            {
                str = Session["Captcha"].ToString();
            }
            if (str == this.xcode.Text.ToUpper())
            {
                this.newState = 0;
                this.enable_Save = "0";
                this.enable_Confirm = "1";
                this.enable_Captcha = "0";
            }
            else
            {
                this.newState = 1;
                this.xcode.Text = "";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.serverpath = base.Server.MapPath("~/");
            if (Session["pwalletID"] != null)
            {
                if (Session["pwalletID"].ToString() != "")
                {
                    this.admin = Session["pwalletID"].ToString();
                }
                else
                {
                    base.Response.Redirect("./xcontrol.aspx");
                }
            }
            else
            {
                base.Response.Redirect("./xcontrol.aspx");
            }
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
            Odyssey ody = new Odyssey();
            string pass = "Password2012";
            this.regID = this.z.a_regadmin(this.xname.Text, this.xrole.SelectedValue, ody.EncryptString(this.xemail.Text, file_len, file_string), this.xtelephone1.Text, this.xtelephone2.Text, "tm", this.pwalletID, ody.EncryptString(pass, file_len, file_string));
            if (this.regID != "0")
            {
                base.Response.Redirect("../reg_tm_succ.aspx");
            }
        }
    }
}

