namespace cld.admin.tm
{
    using Classes;
    using System;
    using System.Collections.Generic;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class edit_applicant : Page
    {
        public string address_text = "";
        protected Label addressID;
        public string adminID = "";
        protected Label appID;
        protected SqlDataSource ds_DefaultCountry;
        protected SqlDataSource ds_Nationality;
        protected SqlDataSource ds_State;
        public string email_text = "";
        public string enable_Captcha = "1";
        public string enable_Confirm = "0";
        public string enable_Save = "1";
        protected HtmlForm form1;
        protected TextBox individual_id_number;
        public List<updateX.Address> lt_addy;
        public List<updateX.Applicant> lt_app;
        public List<updateX.State> lt_state;
        public string name_text = "";
        protected DropDownList nationality;
        public string nationality_text = "";
        public string pwalletID = "1";
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
        protected TextBox tax_id_number;
        protected TextBox tax_id_type;
        public string telephone_text = "";
        protected Button UpdateApplicant;
        public int updateID;
        protected TextBox xaddress;
        protected TextBox xemail;
        protected TextBox xname;
        protected DropDownList xselectState;
        protected TextBox xtelephone;
        protected TextBox xtitle;
        protected TextBox xzip;
        public string yType = "0";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (base.IsPostBack)
            {
                if (this.residence.SelectedIndex == 0x9f)
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

        protected void residence_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.showsucc = "0";
            this.showsearch = "0";
            this.showupdateform = "1";
            if (this.residence.SelectedIndex == 0x9f)
            {
                this.state_row = "0";
            }
            else
            {
                this.state_row = "1";
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
                this.lt_app = this.t.getApplicantByRefID(this.searchno.Text);
                if (this.lt_app.Count > 0)
                {
                    string stateID = "";
                    this.appID.Text = this.lt_app[0].ID;
                    this.addressID.Text = this.lt_app[0].addressID;
                    this.lt_addy = this.t.getAddressByID(this.addressID.Text);
                    this.xname.Text = this.lt_app[0].xname;
                    this.xtitle.Text = this.lt_app[0].xtype;
                    this.tax_id_type.Text = this.lt_app[0].tax_id_type;
                    this.tax_id_number.Text = this.lt_app[0].tax_id_number;
                    this.individual_id_number.Text = this.lt_app[0].individual_id_number;
                   
                    if (this.residence.SelectedIndex == 0x9f)
                    {
                        if ((stateID != null) || (stateID != ""))
                        {
                            this.xselectState.SelectedIndex = Convert.ToInt32(this.lt_addy[0].stateID) - 1;
                        }
                        else
                        {
                            this.xselectState.SelectedIndex = 0;
                        }
                        this.state_row = "0";
                    }
                    else
                    {
                        this.state_row = "1";
                    }
                    if (this.lt_addy.Count > 0)
                    {
                        this.xaddress.Text = this.lt_addy[0].street;
                        this.xzip.Text = this.lt_addy[0].zip;
                        this.xtelephone.Text = this.lt_addy[0].telephone1;
                        this.xemail.Text = this.lt_addy[0].email1;
                        this.nationality.SelectedIndex = Convert.ToInt32(this.lt_app[0].nationality) - 1;
                        this.residence.SelectedIndex = Convert.ToInt32(this.lt_addy[0].countryID) - 1;
                        stateID = this.lt_addy[0].stateID;
                    }
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
            if (this.residence.SelectedIndex == 0x9f)
            {
                this.updateID = this.t.UpdateApplicant(this.xname.Text, this.xtitle.Text, this.tax_id_type.Text, this.tax_id_number.Text, this.individual_id_number.Text, this.nationality.Text, this.residence.Text, this.xselectState.Text,  this.xaddress.Text, this.xzip.Text, this.xtelephone.Text, this.xemail.Text, this.appID.Text, this.addressID.Text);
            }
            else
            {
                this.updateID = this.t.UpdateApplicant(this.xname.Text, this.xtitle.Text, this.tax_id_type.Text, this.tax_id_number.Text, this.individual_id_number.Text, this.nationality.Text, this.residence.Text, "0", this.xaddress.Text, this.xzip.Text, this.xtelephone.Text, this.xemail.Text, this.appID.Text, this.addressID.Text);
            }
            if (this.updateID > 0)
            {
                this.succ_text = "THE APPLICATION DATA HAS BEEN UPDATED SUCCESSFULLY!!";
                this.showsucc = "1";
                this.showsearch = "1";
                this.showupdateform = "0";
            }
            else
            {
                this.succ_text = "THE APPLICATION COULD NOT BE UPDATED! PLEASE TRY AGAIN";
                this.showsucc = "0";
                this.showsearch = "0";
                this.showupdateform = "1";
            }
        }
    }
}

