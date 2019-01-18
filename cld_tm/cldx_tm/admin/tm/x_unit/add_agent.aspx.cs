using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace cld.admin.tm.x_unit
{
    using Classes;
    public partial class add_agent : System.Web.UI.Page
    {
        protected string adminID = "";
        protected string admin = "";
        protected int succ= 0;
        protected string succ_text = "";
        protected string xreg_date = DateTime.Now.ToString("yyyy-MM-dd");
        protected string xnum = "08080001234";
        protected string xmail = "mail@mail.com";

        protected tm t = new tm();
        protected XObjs.Registration agt = new XObjs.Registration();
        protected Registration reg = new Registration();
        protected Hasher hash = new Hasher();
        public string ccode = "";
        public string x_code = "";
        public string new_hash = "";
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["pwalletID"] != null)
            {
                if (this.Session["pwalletID"].ToString() != "")
                {
                    this.admin = this.Session["pwalletID"].ToString();
                    this.Session["xofficer"] = this.admin;
                }
                else { base.Response.Redirect("../lo.aspx"); }
            }
            else { base.Response.Redirect("../lo.aspx"); } 
            agt.AccrediationType = "Corporate";
            agt.Sys_ID = "CLD/RA/";
            agt.Firstname = "Firstname";
            agt.Surname = "Surname";
            agt.Email = xmail;
            agt.xpassword = "Einao0013";
            agt.DateOfBrith = xreg_date;
            agt.IncorporatedDate = xreg_date;
            agt.Nationality = "Nigeria";
            agt.PhoneNumber = xnum;
            agt.CompanyName = "CompanyName";
            agt.CompanyAddress = "CompanyAddress";
            agt.ContactPerson = "ContactPerson";
            agt.ContactPersonPhone = xnum;
            agt.CompanyWebsite = "www.companywebsitehere.com";
            agt.Certificate = "";
            agt.Introduction = "";
            agt.Principal = "";
            agt.xreg_date = xreg_date;
            agt.xstatus = "1";
            agt.xvisible = "1";
            agt.xsync = "0";
            agt.logo = "";

            if (!base.IsPostBack)
            {

                txt_sysid.Value = agt.Sys_ID;
                txt_firstname.Value = agt.Firstname;
                txt_surname.Value = agt.Surname;
                txt_mail.Value = agt.Email;
                txt_mobile.Value = agt.PhoneNumber;
                txt_dob.Value = agt.DateOfBrith;
                txt_coy_name.Value = agt.CompanyName;
                txt_coy_addy.Value = agt.CompanyAddress;
                txt_coy_web.Value = agt.CompanyWebsite;
                txt_doi.Value = agt.IncorporatedDate;
                txt_cont_fullname.Value = agt.ContactPerson;
                txt_cont_mobile.Value = agt.ContactPersonPhone;
                txt_xpass.Value = agt.xpassword;
            }
            else
            {               
              
            }
        }

        protected void btnAddAgent_ServerClick(object sender, EventArgs e)
        {
            ccode = ConfigurationManager.AppSettings["ccode"]; 
            x_code = ConfigurationManager.AppSettings["xcode"]; 
            
            agt.Firstname = txt_firstname.Value;
            agt.Surname= txt_surname.Value;
            agt.Email =txt_mail.Value;
            agt.PhoneNumber= txt_mobile.Value;
            agt.DateOfBrith= txt_dob.Value;
            agt.CompanyName = txt_coy_name.Value;
            agt.CompanyAddress = txt_coy_addy.Value;
            agt.CompanyWebsite = txt_coy_web.Value;
            agt.IncorporatedDate = txt_doi.Value;
            agt.ContactPerson = txt_cont_fullname.Value;
            agt.ContactPersonPhone = txt_cont_mobile.Value;
            agt.Sys_ID = txt_sysid.Value;
            new_hash = hash.GetGetSHA512String(ccode + txt_xpass.Value + x_code); ;
            agt.xpassword = new_hash;

            succ=reg.addRegistration(agt);
        }

      
    }
}