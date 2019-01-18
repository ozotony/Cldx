using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace cld.admin.tm.x_unit
{
    public partial class add_rep : System.Web.UI.Page
    {
        public string address_text = "";
        public string adminID = "";
        public string city_text = "";
        public string code_text = "";
        public string email_text = "";
        public string enable_Captcha = "1";
        public string enable_Confirm = "0";
        public string enable_Save = "1";
        public List<cld.Classes.tm.Address> lt_addy;
        public List<cld.Classes.tm.Representative> lt_app;
        public List<cld.Classes.tm.State> lt_state;
        public string name_text = "";
        public string nationality_text = "";
        public string residence_text = "";
        public string showsucc = "0";
        public string state_row = "1";
        public string state_text = "";
        public string succ_text = "";
        public cld.Classes.tm t = new cld.Classes.tm();
        public string telephone_text = "";
        public string updateID;

        public List<cld.Classes.tm.Stage> lt_pw;
        public cld.Classes.tm.Representative c_rep = new Classes.tm.Representative();
        public cld.Classes.tm.Address c_rep_addy = new Classes.tm.Address();

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
            if (base.IsPostBack)
            {
                if (this.residence.SelectedIndex == 159)
                {
                    this.lt_state = this.t.getState(this.residence.SelectedValue);
                    if (this.lt_state.Count == 0)
                    {
                        this.state_row = "1";
                    }
                    else
                    {
                        this.state_row = "0";
                    }
                }
                else
                {
                    this.state_row = "1";
                }
            }
            else
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
                        Session["agt"] = lt_pw[0].applicantID;
                        Session["stage"] = Convert.ToInt32(lt_pw[0].stage);
                    }
                }
                this.nationality.SelectedIndex = 159;
                this.showsucc = "0";
            }
            if (Session["agt"] != null)
            {
                xcode.Text = Session["agt"].ToString();
            }
        }

       
        protected void UpdateApplicant_Click(object sender, EventArgs e)
        {
            c_rep_addy.city = "";
            c_rep_addy.countryID = this.residence.SelectedValue;
            c_rep_addy.email1 = this.xemail.Text;
            c_rep_addy.telephone1 = this.xtelephone.Text;
            c_rep_addy.lgaID = "";
            c_rep_addy.log_staff = Session["pwID"].ToString();
            c_rep_addy.reg_date = Session["reg_date"].ToString();
            if (this.residence.SelectedIndex == 159) { c_rep_addy.stateID = this.xselectState.SelectedValue; }
            else { c_rep_addy.stateID = "0"; }
            c_rep_addy.street = this.xaddress.Text;
            c_rep_addy.visible = "1";
            c_rep_addy.zip = this.xzip.Text;

            c_rep.addressID = "";
            c_rep.individual_id_number = "";
            c_rep.log_staff = Session["pwID"].ToString();
            c_rep.nationality = this.nationality.SelectedValue;
            c_rep.reg_date = Session["reg_date"].ToString();
            c_rep.individual_id_type = "";
            c_rep.visible = "1";
            c_rep.xname = this.xname.Text;
            c_rep.agent_code = Session["agt"].ToString();

            updateID = t.addRepresentative(c_rep, c_rep_addy,adminID);
            if (Convert.ToInt32(this.updateID) > 0)
            {
                if ((Session["pwID"] != null) && (Session["pwalletID"] != null) && (Session["stage"] != null))
                {
                    t.updatePwalletStage(Session["pwID"].ToString(), Session["pwalletID"].ToString(), Session["stage"].ToString());
                    this.succ_text = "THE REPRESENTATIVE DATA HAS BEEN ADDED SUCCESSFULLY!!";
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