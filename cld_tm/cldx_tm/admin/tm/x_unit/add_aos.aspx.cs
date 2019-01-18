using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace cld.admin.tm.x_unit
{
    using Classes;
    public partial class add_aos : System.Web.UI.Page
    {
        public string address_text = "";
        public string adminID = "";
        public string city_text = "";
        public string email_text = "";
        public string enable_Captcha = "1";
        public string enable_Confirm = "0";
        public string enable_Save = "1";
        public string name_text = "";
        public string nationality_text = "";
        public string residence_text = "";
        public string showsucc = "0";
        public string state_row = "0";
        public string state_text = "0";
        public string succ_text = "";
        public cld.Classes.tm t = new cld.Classes.tm();
        public string telephone_text = "";
        public string updateID;
        public List<tm.Stage> lt_pw = new List<tm.Stage>();
        public List<tm.Applicant> lt_app = new List<tm.Applicant>();
        public List<tm.MarkInfo> lt_mi = new List<tm.MarkInfo>();
        public List<tm.AddressService> lt_aos = new List<tm.AddressService>();
        public List<tm.Representative> lt_rep = new List<tm.Representative>();
        public List<tm.Address> lt_appaddy = new List<tm.Address>();
        public List<tm.Address> lt_repaddy = new List<tm.Address>();
        public cld.Classes.tm.AddressService c_aos = new Classes.tm.AddressService();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["pwalletID"] != null)
            {
                if (this.Session["pwalletID"].ToString() != "")
                {
                    this.adminID = this.Session["pwalletID"].ToString();
                }
                else
                {
                    base.Response.Redirect("../lo.aspx");
                }
            }
            else
            {
                base.Response.Redirect("../lo.aspx");
            }
            this.showsucc = "0";
            if (!IsPostBack)
            {
                if ((Request.QueryString["0636tghvoh450"] != null) && (Request.QueryString["0636tghvoh450"].ToString() != ""))
                {
                    Session["transID"] = Request.QueryString["0636tghvoh450"].ToString();
                    lt_pw = t.getStageByValidationID(Session["transID"].ToString());
                    if (lt_pw.Count == 0)
                    {
                        Response.Redirect("./app_status.aspx");
                    }
                    else
                    {
                        Session["pwID"] = lt_pw[0].ID;
                        Session["reg_date"] = lt_pw[0].reg_date;
                        Session["stage"] = Convert.ToInt32(lt_pw[0].stage);
                    }
                }
            }
        }

      
        protected void UpdateApplicant_Click(object sender, EventArgs e)
        {
            c_aos.city = "";
            c_aos.countryID = "";
            c_aos.email1 = this.xemail.Text;
            c_aos.telephone1 = this.xtelephone.Text;
            c_aos.lgaID = "";
            c_aos.log_staff = Session["pwID"].ToString();
            c_aos.reg_date = Session["reg_date"].ToString();
            c_aos.stateID = this.xselectState.SelectedValue;
            c_aos.street = this.xaddress.Text;
            c_aos.visible = "1";
            c_aos.zip = this.xzip.Text;
            updateID = t.addAos(c_aos,adminID);
            if (Convert.ToInt32(this.updateID) > 0)
            {
                if ((Session["pwID"] != null) && (Session["pwalletID"] != null) && (Session["stage"] != null))
                {
                    t.updatePwalletStage(Session["pwID"].ToString(), Session["pwalletID"].ToString(), Session["stage"].ToString());
                    this.succ_text = "THE ADDRESS OF SERVICE DATA HAS BEEN ADDED SUCCESSFULLY!!";
                    this.showsucc = "1";
                }
            }
        }

        protected void Back_Click(object sender, EventArgs e)
        {
            Session["pwID"] = null; Session["stage"] = null; Session["reg_date"] = null;
            Response.Redirect("./app_status.aspx");
        }

        protected void BackProfile_Click(object sender, EventArgs e)
        {
            Session["pwID"] = null; Session["stage"] = null; Session["reg_date"] = null;
            Response.Redirect("./profile.aspx");
        }
    }
}