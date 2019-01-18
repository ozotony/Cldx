namespace cld.admin.tm
{
    using Classes ;
    using System;
    using System.Collections.Generic;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class edit_rep : Page
    {
        public string address_text = "";
        protected Label addressID;
        public string adminID = "";
        protected Label appID;
        public string code_text = "";
        protected SqlDataSource ds_DefaultCountry;
        protected SqlDataSource ds_Nationality;
        protected SqlDataSource ds_State;
        public string email_text = "";
        public string enable_Captcha = "1";
        public string enable_Confirm = "0";
        public string enable_Save = "1";
        protected HtmlForm form1;
        protected TextBox individual_id_number;
        protected TextBox individual_id_type;
        public List<updateX.Address> lt_addy;
        public List<updateX.Representative> lt_app;
        public List<updateX.State> lt_state;
        public string name_text = "";
        protected DropDownList nationality;
        public string nationality_text = "";
        protected DropDownList residence;
        public string residence_text = "";
        protected Button SearchApplicant;
        protected TextBox searchno;
        public string showsearch = "0";
        public string showsucc = "0";
        public string showupdateform = "0";
        public string state_row = "0";
        public string state_text = "";
        public string succ_text = "";
        public updateX t = new updateX();
        public string telephone_text = "";
        protected Button UpdateApplicant;
        public int updateID;
        protected TextBox xaddress;
        protected TextBox xcode;
        protected TextBox xemail;
        protected TextBox xname;
        protected DropDownList xselectState;
        protected TextBox xstate;
        protected TextBox xtelephone;
        protected TextBox xzip;

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
                    base.Response.Redirect("./xcontrol.aspx");
                }
            }
            else
            {
                base.Response.Redirect("./xcontrol.aspx");
            }
            if (base.IsPostBack)
            {
                if (this.residence.SelectedIndex != 0x9f)
                {
                    this.lt_state = this.t.getState(this.residence.SelectedValue);
                    if (this.lt_state.Count == 0)
                    {
                        this.state_row = "1";
                    }
                }
            }
            else
            {
                this.nationality.SelectedIndex = 0x9f;
                this.showsucc = "0";
                this.showsearch = "1";
                this.showupdateform = "0";
            }
        }

        protected void SearchApplicant_Click(object sender, EventArgs e)
        {
            this.state_row = "0";
            if (this.searchno.Text != "")
            {
                if (this.searchno.Text.Contains("OAI/TM/"))
                {
                    this.searchno.Text = this.searchno.Text.Replace("OAI/TM/", "");
                }
                this.lt_app = this.t.getRepresentativeByRefID(this.searchno.Text);
                if (this.lt_app.Count > 0)
                {
                    this.appID.Text = this.lt_app[0].ID;
                    this.addressID.Text = this.lt_app[0].addressID;
                    this.lt_addy = this.t.getAddressByID(this.addressID.Text);
                    this.xcode.Text = this.lt_app[0].agent_code;
                    this.xname.Text = this.lt_app[0].xname;
                    this.individual_id_type.Text = this.lt_app[0].individual_id_type;
                    this.individual_id_number.Text = this.lt_app[0].individual_id_number;
                    this.nationality.SelectedIndex = Convert.ToInt32(this.lt_app[0].nationality) - 1;
                    this.residence.SelectedIndex = Convert.ToInt32(this.lt_addy[0].countryID) - 1;
                    this.xselectState.SelectedIndex = Convert.ToInt32(this.lt_addy[0].stateID) - 1;
                    this.xaddress.Text = this.lt_addy[0].street;
                    this.xzip.Text = this.lt_addy[0].zip;
                    this.xtelephone.Text = this.lt_addy[0].telephone1;
                    this.xemail.Text = this.lt_addy[0].email1;
                    this.showsucc = "0";
                    this.showsearch = "0";
                    this.showupdateform = "1";
                }
                else
                {
                    this.showsucc = "1";
                    this.showsearch = "1";
                    this.showupdateform = "0";
                    this.succ_text = "PLEASE CROSS CHECK THE REFERENCE NUMBER AND SEARCH AGAIN";
                }
            }
        }

        protected void UpdateApplicant_Click(object sender, EventArgs e)
        {
            this.updateID = this.t.UpdateRepresentative(this.xcode.Text, this.xname.Text, this.individual_id_type.Text, this.individual_id_number.Text, this.nationality.Text, this.residence.Text, this.xselectState.Text, this.xaddress.Text, this.xzip.Text, this.xtelephone.Text, this.xemail.Text, this.appID.Text, this.addressID.Text);
            if (this.updateID > 0)
            {
                this.succ_text = "THE REPRESENTATIVE DATA HAS BEEN UPDATED SUCCESSFULLY!!";
                this.showsucc = "1";
                this.showsearch = "1";
                this.showupdateform = "0";
            }
        }
    }
}

