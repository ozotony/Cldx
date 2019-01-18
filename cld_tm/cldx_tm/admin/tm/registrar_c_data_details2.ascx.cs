
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.UI.HtmlControls;

namespace cld.admin.tm
{
    using admin;
    using Classes;
    public partial class registrar_c_data_details2 : System.Web.UI.UserControl
    {
        public string admin = "";
        public string admin_status;
        public tm.AddressService c_aos = new tm.AddressService();
        public tm.Applicant c_app = new tm.Applicant();
        public tm.Address c_app_addy = new tm.Address();
        public zues.MarkInfo c_mark = new zues.MarkInfo();
        public zues.Pwallet c_p = new zues.Pwallet();
        public tm.Representative c_rep = new tm.Representative();
        public tm.Address c_rep_addy = new tm.Address();
        protected Label Label1;
        protected Label Label2;
        protected Label Label3;
        protected Label Label4;
        protected Label Label5;
        protected Label Label6;
        protected HtmlInputHidden xrtm;
        protected HtmlInputHidden xname;
        protected HtmlInputHidden xname2;
        public zues.Adminz lt_tm_admin_details = new zues.Adminz();
        public List<zues.TmOffice> lt_tm_office = new List<zues.TmOffice>();
        public string pID;
        public string rbval_text = "";
        public string search_doc_succ1 = "";
        public string search_doc_succ2 = "";
        public string search_doc_succ3 = "";
        public string succ = "";
        public tm t = new tm();
        public string xofficer;
        protected Image tm_img;
        protected string serverpath = "";
        public string sealed_date = "";
        protected Label Label33;
        protected Label Label44;

        public zues z = new zues();



        protected string getDayFormat(string day)
        {
            //string new_day = "";
            //if(day.EndsWith("1")){ new_day="st";}
            //else if (day.EndsWith("2")) { new_day = "nd"; }
            //else if (day.EndsWith("3")) { new_day = "rd"; }
            //else  { new_day = "th"; }
            //return new_day;


            switch (day)
            {
                case "1":
                case "21":
                case "31":
                    return "st";
                case "2":
                case "22":
                    return "nd";
                case "3":
                case "23":
                    return "rd";
                default:
                    return "th";
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            this.serverpath = base.Server.MapPath("~/");
            if (base.Request.QueryString["x"] != null)
            {
                Label44.Text = "<br/>PLEASE NOTE THAT THIS IS NOT AN ORIGINAL CERTIFICATE , PRINT THIS COPY AND PRESENT IT TO THE REGISTRY TO COLLECT YOUR ORIGINAL  CERTIFICATE.<br/> CONTACT THE REGISTRY FOR MORE INFORMATION ON HOW TO COLLECT YOUR ORIGINAL COPY. WWW.IPONIGERIA.COM.";
                Label33.Text = "<br/>PLEASE NOTE THAT THIS IS NOT AN ORIGINAL  CERTIFICATE , PRINT THIS COPY AND PRESENT IT TO THE REGISTRY TO COLLECT YOUR ORIGINAL CERTIFICATE .<br/> CONTACT THE REGISTRY FOR MORE INFORMATION ON HOW TO COLLECT YOUR ORIGINAL COPY. WWW.IPONIGERIA.COM.";

                //if (Session["pwalletID"] != null)
                //{
                //    if (Session["pwalletID"].ToString() != "")
                //    {
                //        this.admin = Session["pwalletID"].ToString();
                //        // xname.Value = this.admin;
                //    }
                //    else
                //    {
                //        base.Response.Redirect("./xcontrol.aspx");
                //    }
                //}
                //else
                //{
                //    base.Response.Redirect("./xcontrol.aspx");
                //}
                this.pID = base.Request.QueryString["x"].ToString();

                this.c_mark = this.z.getMarkInfoByUserID(this.pID);
                //  xname2.Value = this.c_mark.log_staff;
                this.c_p = this.z.getPwalletDetailsByID(this.c_mark.log_staff);
                this.c_app = this.t.getApplicantByUserID(this.c_p.ID);
                this.c_aos = this.t.getAddressServiceByID(this.c_p.ID);
                this.c_rep = this.t.getRepByUserID(this.c_p.ID);

                xrtm.Value = c_mark.reg_number;

                if ((c_app.addressID != null) && (c_app.addressID != "") && (c_app.addressID != "0"))
                {
                    this.c_app_addy = this.t.getAddressClassByID(this.c_app.addressID);
                }
                if ((c_rep.addressID != null) && (c_rep.addressID != "") && (c_rep.addressID != "0"))
                {
                    this.c_rep_addy = this.t.getAddressClassByID(this.c_rep.addressID);
                }
                this.lt_tm_office = this.z.getTmOfficeDetailsByID(this.c_p.ID);  //ToString("yyyy-MM-dd")
                                                                                 //  string day =getDayFormat( Convert.ToDateTime(lt_tm_office[lt_tm_office.Count - 1].reg_date).ToString("dd") );
                string day = getDayFormat(Convert.ToString(Convert.ToDateTime(lt_tm_office[lt_tm_office.Count - 1].reg_date).Day));


                sealed_date = Convert.ToDateTime(lt_tm_office[lt_tm_office.Count - 1].reg_date).ToString("dd") + day + " " + Convert.ToDateTime(lt_tm_office[lt_tm_office.Count - 1].reg_date).ToString("MMMM, yyyy");
                this.lt_tm_admin_details = this.z.getTmAdminDetailsByID(this.lt_tm_office[0].xofficer);

                if (c_mark.logo_pic != "")
                {
                    tm_img.ImageUrl = "./" + c_mark.logo_pic;

                    if (File.Exists(serverpath + "\\admin\\tm\\" + c_mark.logo_pic))
                    {
                        tm_img.Height = new Unit(70, UnitType.Pixel);
                        tm_img.Width = new Unit(180, UnitType.Pixel);
                        try
                        {
                            FileStream st = new FileStream(serverpath + "\\admin\\tm\\" + c_mark.logo_pic, FileMode.Open, FileAccess.Read);
                            System.Drawing.Image new_img = System.Drawing.Image.FromStream(st);
                            string ht = new_img.Height.ToString();
                            string wt = new_img.Width.ToString();
                            if ((ht != "") && (wt != "") && (ht != null) && (wt != null))
                            {

                                if (Convert.ToInt32(ht) > Convert.ToInt32(wt))
                                {
                                    //  tm_img.Height = new Unit(320, UnitType.Pixel);
                                    //  tm_img.Width = new Unit(240, UnitType.Pixel);

                                    //  tm_img.Height = new Unit(180, UnitType.Pixel);
                                    //  tm_img.Width = new Unit(120, UnitType.Pixel);

                                    //  tm_img.Height = new Unit(70, UnitType.Pixel);
                                    //  tm_img.Width = new Unit(170, UnitType.Pixel);
                                }
                                else
                                {
                                    // tm_img.Height = new Unit(240, UnitType.Pixel);
                                    // tm_img.Width = new Unit(320, UnitType.Pixel);


                                    //    tm_img.Height = new Unit(70, UnitType.Pixel);
                                    //    tm_img.Width = new Unit(190, UnitType.Pixel);
                                }
                            }
                            else
                            {
                                // tm_img.Height = new Unit(120, UnitType.Pixel);
                                // tm_img.Width = new Unit(120, UnitType.Pixel);
                                tm_img.Visible = false;
                            }
                        }
                        catch (Exception ex)
                        {
                            tm_img.Visible = false;
                        }
                    }
                    else
                    {
                        // tm_img.Height = new Unit(120, UnitType.Pixel);
                        // tm_img.Width = new Unit(120, UnitType.Pixel);
                        tm_img.Visible = false;
                    }

                }

            }
            else
            {
                base.Response.Redirect("./registrar_c.aspx");
            }
        }
    }
}