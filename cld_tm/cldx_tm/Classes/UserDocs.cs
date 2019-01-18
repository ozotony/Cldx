using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.IO;


namespace cld.Classes
{
    public class UserDocs
    {
        public Retriever ret = new Retriever();
        public Registration reg = new Registration();

        public string getCertDateFormat(string dt)
        {
            string[] split_dt = dt.Split('-');
            string new_date = "";// string day = ""; string month = ""; string year = "";
            if (split_dt.Length == 3)
            {
                new_date = Convert.ToDateTime(dt).ToString("dd") + " " + Convert.ToDateTime(dt).ToString("MMMM, yyyy");
            }
            return new_date;
        }

        public string getCertNextRenewalDate(string dt)  //+14 year
        {
            //string[] split_dt = dt.Split('-');
            string new_date = "";// string day = ""; string month = ""; string year = "";
            
                new_date = Convert.ToDateTime(dt).ToString("dd") + " " + Convert.ToDateTime(dt).AddYears(14).ToString("MMMM, yyyy");
           
            return new_date;
        }
        public string getCertRenewalDueDate(string dt,string no_ren) //+7 year
        {
            string[] split_dt = dt.Split('-');
            string new_date = "";// string day = ""; string month = ""; string year = "";
            if (split_dt.Length == 3)
            {
                new_date = Convert.ToDateTime(dt).ToString("dd") + " " + Convert.ToDateTime(dt).AddYears(7 + (Convert.ToInt32(no_ren) * 14)).ToString("MMMM, yyyy");
            }
            return new_date;
        }
        public string getDayFormat(string day)
        {
            string new_day = "";
            if (day.EndsWith("1")) { new_day = "st"; }
            else if (day.EndsWith("2")) { new_day = "nd"; }
            else if (day.EndsWith("3")) { new_day = "rd"; }
            else { new_day = "th"; }
            return new_day;
        }

        public string getGfImgUrlString(string logo_pic)
        {
            string img_url = ""; string img_src = ""; string img_ht= ""; string img_wd = "";
            if (logo_pic != "")
            {
                img_src = "http://tm.cldng.com/admin/tm/gf/" + logo_pic;

                Stream str = null;
                string imageUrl = "http://tm.cldng.com/admin/tm/gf/" + logo_pic;
                try
                {
                HttpWebRequest wReq = (HttpWebRequest)WebRequest.Create(imageUrl);
                HttpWebResponse wRes = (HttpWebResponse)(wReq).GetResponse();
                str = wRes.GetResponseStream();

               
                    var imageOrig = System.Drawing.Image.FromStream(str);
                    int height = imageOrig.Height;
                    int width = imageOrig.Width;
                      img_url = "<img src=\""+img_src+" \" style=\"width:"+img_wd+"; height: "+img_ht+"\" alt=\"Device\"/>";
                    if ((height > 0) && (width > 0))
                    {
                        if ((height > 240) && (width > 240))
                        {
                            if (height > width) { img_ht = "320px"; img_wd = "240px"; }
                            else if (height < width) { img_ht ="240px"; img_wd ="320px"; }
                            else { img_ht ="320px"; img_wd ="320px"; }
                        }
                        else
                        {
                            img_ht = height.ToString(); img_wd = width.ToString();
                        }
                        img_url = "<img src=\"" + img_src + " \" style=\"width:" + img_wd + "; height: " + img_ht + "\" alt=\"Device\"/>";
                    }
                    else
                    {
                        img_src = ""; //img_src = "http://ipo.cldng.com/images/na.png";
                        img_ht ="240px"; img_wd ="240px";
                    }

                }
                catch (Exception ex)
                {
                    img_src = ""; //img_src = "http://ipo.cldng.com/images/na.png";
                    img_ht ="240px"; img_wd ="240px";
                }

              
            }
            else
            {
                img_src = ""; //img_src = "http://ipo.cldng.com/images/na.png";
                img_ht = "240px"; img_wd = "240px";
            }
            return img_url;

        }

        public string returnDoc(
            string transID,
            XObjs.G_Pwallet g_pwallet, 
            XObjs.G_App_info g_app_info, 
            XObjs.G_Applicant_info g_applicant_info, 
            XObjs.G_Tm_info g_tm_info,
            XObjs.Gen_Agent_info g_agent_info,
            XObjs.G_Ass_info g_ass_info,
            XObjs.G_Cert_info g_cert_info,
            XObjs.G_Change_info g_change_info,
            XObjs.G_Merger_info g_merger_info,
            XObjs.G_Other_items_info g_other_items_info,
            XObjs.G_Prelim_search_info g_prelim_search_info,
            XObjs.G_Renewal_info g_renewal_info,
            string comment, string name, string code_title, string user_type, string lt_g_tm_office_date
            )
        {
            switch (g_pwallet.log_officer.ToLower())
            {
                case "t001": return getT001(g_app_info, g_applicant_info, g_tm_info, g_pwallet.validationID, comment, name, code_title, user_type);
                case "t003": return getT003(g_app_info, g_applicant_info, g_tm_info, g_pwallet, lt_g_tm_office_date);//Similar to T001
                case "t008": return getT008(g_change_info, g_app_info, g_tm_info, transID, comment, name, code_title, user_type);
                case "t009": return getT009(g_app_info, g_applicant_info, g_tm_info, g_pwallet, g_renewal_info, lt_g_tm_office_date);
                case "t010": return getT001(g_app_info, g_applicant_info, g_tm_info, transID, comment, name, code_title, user_type);//Similar to T001
                case "t011": return getT001(g_app_info, g_applicant_info, g_tm_info, transID, comment, name, code_title, user_type);//Similar to T001
                case "t012": return getT001(g_app_info, g_applicant_info, g_tm_info, transID, comment, name, code_title, user_type);//Similar to T001
                case "t013": return getT001(g_app_info, g_applicant_info, g_tm_info, transID, comment, name, code_title, user_type);//Similar to T001
              //  case "t014": return getT001(g_app_info, g_applicant_info, g_tm_info, transID, comment, name, code_title, user_type);
                case "t014": return getT014(g_app_info, g_applicant_info, g_tm_info, transID, comment, name, code_title, user_type, g_ass_info, g_merger_info);
                case "t016": return getT001(g_app_info, g_applicant_info, g_tm_info, transID, comment, name, code_title, user_type);//Similar to T001
                case "t017": return getT001(g_app_info, g_applicant_info, g_tm_info, transID, comment, name, code_title, user_type);
                case "t018": return getT001(g_app_info, g_applicant_info, g_tm_info, transID, comment, name, code_title, user_type);
                case "t019": return getT001(g_app_info, g_applicant_info, g_tm_info, transID, comment, name, code_title, user_type);//Similar to T001
                case "t021": return getT001(g_app_info, g_applicant_info, g_tm_info, transID, comment, name, code_title, user_type);//Similar to T001
                case "t022": return getT001(g_app_info, g_applicant_info, g_tm_info, transID, comment, name, code_title, user_type);//Similar to T001
                case "t023": return getT001(g_app_info, g_applicant_info, g_tm_info, transID, comment, name, code_title, user_type);//Similar to T001
                case "t024": return getT001(g_app_info, g_applicant_info, g_tm_info, transID, comment, name, code_title, user_type);//Similar to T001
                case "t025": return getT001(g_app_info, g_applicant_info, g_tm_info, transID, comment, name, code_title, user_type);//Similar to T001
                case "t026": return getT001(g_app_info, g_applicant_info, g_tm_info, transID, comment, name, code_title, user_type);//Similar to T001
                case "t027": return getT001(g_app_info, g_applicant_info, g_tm_info, transID, comment, name, code_title, user_type);//Similar to T001
            }
            return "NA";
        }


        protected string getGeneralHeader()
        {
            string x_gen_header = "";

            x_gen_header += "<tr align=\"center\">";
            x_gen_header += "<td colspan=\"2\">";
            x_gen_header += "  <img alt=\"Coat Of Arms\" height=\"120\" src=\"http://tm.cldng.com/images/coat_of_arms.png\" width=\"120\" />";
            x_gen_header += " </td>";
            x_gen_header += "</tr>";
            x_gen_header += " <tr align=\"center\" style=\" font-size:11pt;\" >";
            x_gen_header += " <td colspan=\"2\">";
            x_gen_header += "<p  style=\"font-size:14.0px;font-family:Andalus;text-align:center; font-weight:bold;\">";
            x_gen_header += "<span  style=\"font-size:19.0px;\">NIGERIA</span><br />";
            x_gen_header += "Trade Marks Acts, 1990</p>";
            x_gen_header += "</td>";
            x_gen_header += "<tr>";
            x_gen_header += "<td style=\"background-color:#999999;\" align=\"left\" colspan=\"2\"></td>";
            x_gen_header += "</tr>";
            return x_gen_header;
        }

        protected string getGeneralT014Header()
        {
            string x_gen_header = "";

            x_gen_header += "<tr align=\"center\">";
            x_gen_header += "<td colspan=\"2\">";
            x_gen_header += "  <img alt=\"Coat Of Arms\" height=\"120\" src=\"http://tm.cldng.com/images/coat_of_arms.png\" width=\"120\" />";
            x_gen_header += " </td>";
            x_gen_header += "</tr>";
            x_gen_header += " <tr align=\"center\" style=\" font-size:11pt;\" >";
            x_gen_header += " <td colspan=\"2\">";
            x_gen_header += "<p  style=\"font-size:14.0px;font-family:Andalus;text-align:center; font-weight:bold;\">";
            x_gen_header += "<span  style=\"font-size:19.0px;\">NIGERIA</span><br />";
            x_gen_header += "Trade Marks Acts, 1990</p>";
            x_gen_header += "</td>";
            x_gen_header += "<tr>";
            x_gen_header += "<td style=\"background-color:#999999;\" align=\"left\" colspan=\"2\"></td>";
            x_gen_header += "</tr>";
            return x_gen_header;
        }
        protected string getGeneralHeaderT008()
        {
            string x_gen_header = "";

            x_gen_header += "<tr align=\"center\">";
            x_gen_header += "<td colspan=\"2\">";
            x_gen_header += "  <img alt=\"Coat Of Arms\" height=\"120\" src=\"http://tm.cldng.com/images/coat_of_arms.png\" width=\"120\" />";
            x_gen_header += " </td>";
            x_gen_header += "</tr>";
            x_gen_header += " <tr align=\"center\" style=\" font-size:11pt;\" >";
            x_gen_header += " <td colspan=\"2\">";
            x_gen_header += "<p  style=\"font-size:14.0px;font-family:Andalus;text-align:center; font-weight:bold;\">";
            x_gen_header += "<span  style=\"font-size:19.0px;\">NIGERIA</span><br />";
            x_gen_header += "Trade Marks Acts, 1990<br />";
            x_gen_header += "Regulation 82, 86 and 102</p>";
            x_gen_header += "</td>";            
            x_gen_header += "<tr>";
            x_gen_header += "<td style=\"background-color:#999999;\"  colspan=\"2\"></td>";
            x_gen_header += "</tr>";
            return x_gen_header;
        }
        protected string getGeneralFooter(string officer_name)
        {
            string x_gen_footer = "";

            x_gen_footer += " <tr>";
            x_gen_footer += "<td style=\"background-color:#999999;\" align=\"left\" colspan=\"2\">&nbsp;</td>";
            x_gen_footer += "</tr>";
            x_gen_footer += "<tr>";
            x_gen_footer += "<td align=\"right\" style=\"width:50%;\">&nbsp;</td>";
            x_gen_footer += " <td align=\"left\">";
            x_gen_footer += "<strong>" + officer_name + "</strong><br /><br />";
            x_gen_footer += " For: Registrar of Trade Marks <br />";
            x_gen_footer += "The Trade Marks Registry,<br /> ";
            x_gen_footer += "Federal Ministry of Industry, Trade and Investment ,<br /> ";
            x_gen_footer += "Federal Capital Territory,<br /> ";
            x_gen_footer += "Abuja, Nigeria. </td>";
            x_gen_footer += "</tr>";

            return x_gen_footer;
        }
        protected string getGeneralFooterT008(string officer_name)
        {
            string x_gen_footer = "";

            x_gen_footer += " <tr>";
            x_gen_footer += "<td style=\"background-color:#999999;\" colspan=\"2\">&nbsp;</td>";
            x_gen_footer += "</tr>";
            x_gen_footer += "<tr>";
          //  x_gen_footer += " <td align=\"center\">";
            x_gen_footer += "<td style=\"font-family: Garamond; font-size:16px; font-weight:bold; text-align:right;\">";
            x_gen_footer += "<img alt=\"Adewasiu\" src=\"http://tm.cldng.com/admin/tm/signatures/registrar_mini_png.png\" style=\" width: 222px;height: 83px;\" alt=\"Registrar\"/><br />";
            x_gen_footer += "<hr  style=\"background-color:#1C5E55; height:1px;\"/>";
            x_gen_footer += "N. SALMAN MANN MNI<br />";
            x_gen_footer += "Registrar of Trade Marks</td>";
          //  x_gen_footer += "<strong>" + officer_name + "</strong><br /><br />";
          //  x_gen_footer += " For: Registrar of Trade Marks <br />";
            x_gen_footer += "The Trade Marks Registry,<br /> ";
            x_gen_footer += "Federal Ministry of Industry, Trade and Investment ,<br /> ";
            x_gen_footer += "Federal Capital Territory,<br /> ";
            x_gen_footer += "Abuja, Nigeria. </td>";
            x_gen_footer += "</tr>";

            return x_gen_footer;
        }

        protected string getT003(XObjs.G_App_info g_app_info, XObjs.G_Applicant_info g_applicant_info, XObjs.G_Tm_info g_tm_info, XObjs.G_Pwallet g_pwallet, string lt_g_tm_office_date)
        {
            string x_html = "";
            x_html +="<table class=\"xform\"  style=\"width:1000px;border:1px solid #fff;\" align=\"center\" >";
                   
            x_html +="<tr style=\"border:1px solid #fff;\">";
            x_html +="<td colspan=\"2\" style=\"text-align:center;\">";
            x_html +="<img src=\"../../../images/coat_of_arms.png\" style=\"width: 120px; height: 120px\" alt=\"Coat Of Arms\"/></td>";
            x_html +="</tr>";                   
            x_html +=" <tr>";
            x_html += "<td colspan=\"2\"  style=\"font-family:Arial Black; font-size:22px;\" align=\"center\"> NIGERIA </td>";
            x_html +="</tr>";
            x_html +="<tr>";
            x_html += "<td  colspan=\"2\" align=\"center\" >";
            x_html +="<strong>";
            x_html +="<span style=\"font-family: Old English Text MT; font-size:35px; color:#009900;\">Certificate of Registration of Trade Mark</span><br />";
            x_html +="<span style=\"font-family:Arial Black; font-size:32px;\">Trade Marks Act</span><br />";
            x_html +="<span style=\"font-family:Arial Black; font-size:14px;\">CAP 436 Laws Of The Federation Of Nigeria 1990; Section 22 (3) Regulation 65)</span>";
            x_html +="</strong>";
            x_html +="</td>";
            x_html +="</tr>";
            x_html +="<tr>";
            x_html +="<td  colspan=\"2\" >";
            x_html +="&nbsp;</td>";
            x_html +=" </tr>";
            x_html +="<tr>";
            x_html += " <td colspan=\"2\" align=\"center\">";
           
            if (g_tm_info.logo_descID != "WORD MARK")
            {
            if (g_tm_info.logo_pic != "")
            {
            x_html +=getGfImgUrlString(g_tm_info.logo_pic);
             }
            else
            {  
                x_html +="NO DEVICE!!";
             }
            }
            else
            {
            x_html +="<div style=\" font-size:28px; font-weight:bolder; font-family:Segoe UI; border:2px solid #ececec;\">"+g_tm_info.tm_title+"</div>";
            }
            x_html +="</td>";
            x_html +="</tr>";
            x_html +="<tr>";
            x_html +="<td  colspan=\"2\"  style=\"text-align:left; font-weight:bold;font-family: Segoe UI; font-size:14px;\">";
            x_html +="The Trade Marks shown above has been registered in Part A (Or B)";
            x_html +="</td>";
            x_html +="</tr>";
            x_html +="<tr>";
            x_html +="<td  colspan=\"2\"  style=\"text-align:left; font-weight:bold;font-family: Segoe UI; font-size:14px;\">";
            x_html +="Of the register in the name of";
            x_html +="</td>";
            x_html +="</tr>";
            x_html +="<tr>";
            x_html +="<td  colspan=\"2\"  style=\"text-align:center; font-weight:normal;font-family: Segoe UI Symbol; font-size:18px;\">";
            x_html +="<strong>"+g_applicant_info.xname+"</strong></td>";
            x_html +="</tr>";
            x_html +="<tr>";
            x_html +="<td colspan=\"2\"   style=\"text-align:center; font-weight:bold;font-family: Segoe UI Symbol; font-size:14px;\">";
            x_html +="<br />"+g_applicant_info.address+"</td>";
            x_html +="</tr>";
            x_html +="<tr>";
            x_html +="<td colspan=\"2\"  style=\"text-align:center; font-weight:bold;font-family: Segoe UI Symbol; font-size:14px;\">";
            x_html += "In Class" + g_tm_info.tm_class + " under No. " + g_app_info.rtm_number + "-" + g_pwallet.validationID + " as Of Date " + g_tm_info.reg_date + "in Respect Of </td>";
            x_html +="</tr>";
            x_html +="<tr>";
            x_html +="<td colspan=\"2\"  style=\"text-align:center; font-weight:normal;font-family: Segoe UI Symbol; font-size:14px;\">";
            x_html +=g_tm_info.tm_desc;
            x_html +="</td>";
            x_html +=" </tr>";
            x_html +="<tr>";
            x_html +="<td colspan=\"2\"   style=\"text-align:center; font-weight:normal;font-family: Segoe UI Symbol; font-size:14px;\">";
            x_html +="&nbsp;</td>";
            x_html +="</tr>";
            x_html +="<tr>";
            x_html +="<td colspan=\"2\" style=\"text-align:center; font-weight:normal;font-family: Segoe UI Symbol; font-size:14px;\">";
            x_html +="&nbsp;</td>";
            x_html +="</tr>";
            x_html +="<tr>";
            x_html +="<td colspan=\"2\"  style=\"text-align:center; font-weight:normal;font-family: Segoe UI Symbol; font-size:14px;\">";
            x_html +="&nbsp;</td>";
            x_html +="</tr>";
            x_html +="<tr>";
            x_html +="<td width=\"1000px\" colspan=\"2\"  style=\"text-align:center; font-weight:normal;font-family: Segoe UI Symbol; font-size:14px;\">";
            x_html +="&nbsp;</td>";
            x_html +="</tr>"; 
            x_html +="<tr>";
            x_html +="<td align=\"left\" style=\"font-family: Garamond; font-size:16px;\">";
            x_html +="<strong>";
            x_html += " Sealed at my direction this date " + Convert.ToDateTime(lt_g_tm_office_date).ToString("dd") + getDayFormat(Convert.ToDateTime(lt_g_tm_office_date).ToString("dd")) + " " + Convert.ToDateTime(lt_g_tm_office_date).ToString("MMMM, yyyy") + "<br />";
            x_html +="The Trade Marks Registry, <br />";
            x_html +="Federal Ministry of Industry, Trade and Investment	<br />";
            x_html +="Federal Capital Territory<br />";
            x_html +="Abuja, Nigeria. ";
            x_html +="</strong>";
            x_html +="</td>";
            x_html +="<td align=\"right\">";
            x_html +="<strong>&nbsp;&nbsp; </strong>";
            x_html +="</td>";
            x_html +="</tr>";  
            x_html +="<tr>";
            x_html +="<td align=\"left\">";
            x_html +="&nbsp;</td>";
            x_html +="<td style=\"font-family: Garamond; font-size:16px; font-weight:bold; text-align:right;\">";
            x_html += "<img alt=\"Adewasiu\" src=\"http://tm.cldng.com/admin/tm/signatures/registrar_mini_png.png\" style=\" width: 222px;height: 83px;\" alt=\"Registrar\"/><br />";
            x_html +="<hr  style=\"background-color:#1C5E55; height:1px;\"/>";
            x_html +="N. SALMAN MANN MNI<br />";
            x_html +="Registrar of Trade Marks</td>";
            x_html +=" </tr> ";              
            x_html +=" <tr>";
            x_html +="<td style=\"background-color:#1C5E55; color:#ffffff; text-align:center; font-weight:normal; font-size:16px; font-family:Calibri;\" colspan=\"2\">";
            x_html +="REGISTRATION IS 7 YEARS FROM THE DATE OF FILLING AND MAY THEN<br />";
            x_html +="BE RENEWED ALD ALSO AT THE EXPIRATION OF EACH PERIOD OF 14 YEARS THEREAFTER.</td>";
            x_html +="</tr>";
            x_html +="<tr>";
            x_html +="<td style=\"background-color:#1C5E55;text-align:center; font-weight:normal; \" colspan=\"2\"></td>";
            x_html +="</tr>";
            x_html +="<tr>";
            x_html +="<td colspan=\"2\" style=\"font-family: Garamond; font-size:12px; font-weight:normal; text-align:center;\">";
            x_html +="<br />";
            x_html +="THIS CERTIFICATE IS NOT FOR USE IN LEGAL PROCEEDING OR FOR OBTAINING REGISTRATION<br />";
            x_html +=" ABROAD. NOTE- UPON ANY CHANGE OF OWNERSHIP OF THIS TRADEMARK, OR CHANGE IN<br />";
            x_html +="ADDRESS, APPLICATION SHOULD AT ONCE BE MADE TO THE REGISTRAR TO REGISTER THE CHANGE.";
            x_html +="<br />";
            x_html +="</td>";
            x_html +="</tr>";                    
            x_html +="</table>";
                      
           
            return x_html;
        }
        protected string getT009(XObjs.G_App_info g_app_info, XObjs.G_Applicant_info g_applicant_info, XObjs.G_Tm_info g_tm_info, XObjs.G_Pwallet g_pwallet, XObjs.G_Renewal_info g_renewal_info, string lt_g_tm_office_date)
        {
            string x_html = "";
            x_html += "<table class=\"xform\"  style=\"width:1000px;border:1px solid #fff;\" align=\"center\">";                  
            x_html += "<tr>";
            x_html += "<td colspan=\"2\" align=\"center\"> <img src=\"../../../images/coat_of_arms.png\" style=\"width: 120px; height: 120px\" alt=\"Coat Of Arms\"/> </td>";
            x_html += "</tr>";                  
            x_html += "<tr>";
            x_html += "<td  colspan=\"2\" align=\"center\" style=\"font-family:Arial Black; font-size:22px;\">NIGERIA</td>";
            x_html += "</tr>";
            x_html += "<tr>";
            x_html += "<td  colspan=\"2\" align=\"center\">";
            x_html += "<strong> <span style=\"font-family:Arial Black; font-size:16px;\">Trade Marks Act, 1990</span><br />";
            x_html += "<span style=\"font-family: Old English Text MT; font-size:35px; color:#009900;\">Certificate Of Renewal Of Registration</span><br /> </strong>";
            x_html += "</td>";
            x_html += "</tr>";
            x_html += "<tr>";
            x_html += "<td  colspan=\"2\" align=\"center\"> &nbsp;</td>";
            x_html += "</tr>";
            x_html += "<tr>";
            x_html += "<td  colspan=\"2\" style=\"text-align:center;font-size:16px;\" >";
            x_html += "I HEREBY CERTIFY THAT the Registration of the Trade Mark No <strong>"+g_app_info.rtm_number+"</strong> in Class <strong>"+g_tm_info.tm_class +"</strong><br />";
            x_html += "in respect of  <strong>"+g_tm_info.tm_desc +"</strong> in the name of <br /><br /><hr />";
            x_html += "<strong>"+g_applicant_info.xname +"</strong><br />";
            x_html += "<strong>"+g_applicant_info.address +"</strong><br />";
            x_html += "<br /><br />";
            x_html += "Has been renewed and will remain in force for a period of fourteen years from  <strong>" + getCertRenewalDueDate(g_app_info.filing_date, g_renewal_info.renewal_type)  /* getCertRenewalDueDate(lt_g_tm_office_date, g_renewal_info.renewal_type) */ + "</strong> in the Federal Republic of Nigeria. <br />"; 
            x_html += "A representation of the said Trade Mark is affixed hereto.<br /><br />";

            if (g_tm_info.logo_descID != "WORD MARK")
            {
                if (g_tm_info.logo_pic != "")
                {
                    x_html += getGfImgUrlString(g_tm_info.logo_pic);
                }
                else
                {
                    x_html += "NO DEVICE!!";
                }
            }
            else
            {
                x_html += "<div style=\" font-size:28px; font-weight:bolder; font-family:Segoe UI; border:2px solid #ececec;\">" + g_tm_info.tm_title + "</div>";
            }

            x_html += "</td>";
            x_html += "</tr>";                                         
            x_html += "<tr>";
            x_html += "<td colspan=\"2\"  style=\"text-align:center; font-weight:normal;font-family: Segoe UI Symbol; font-size:14px;\" > ";                           
            x_html += "<table style=\"width:100%;\" >";
            x_html += "<tr>";
            x_html += "<td style=\"text-align:center; font-weight:bolder;font-family: Segoe UI Symbol; font-size:20px;border: 1px solid #000;\" colspan=\"4\">RENEWAL INFORMATION</td>";
            x_html += "</tr>";
            x_html += "<tr style=\"text-align:center;font-size:16px;\">";
            x_html += "<td style=\"width:25%;text-align:right;border: 1px solid #000;\">Date of filing :  </td>";
           // x_html += "<td style=\"width:25%;text-align:left;border: 1px solid #000;\"><strong>"+getCertDateFormat(g_renewal_info.reg_date) +"</strong></td>";

            x_html += "<td style=\"width:25%;text-align:left;border: 1px solid #000;\"><strong>" + getCertDateFormat(g_app_info.filing_date) + "</strong></td>";
            x_html += "<td style=\"width:25%;text-align:right;border: 1px solid #000;\">No of renewals : </td>";
            x_html += "<td style=\"width:25%;text-align:left;border: 1px solid #000;\"><strong>"+g_renewal_info.renewal_type +"</strong></td>";
            x_html += "</tr>";
            x_html += "<tr style=\"text-align:center;font-size:16px;\">";
            x_html += "<td style=\"width:25%; text-align:right;border: 1px solid #000;\">Renewed date : </td>";
           // x_html += "<td style=\"width:25%; text-align:left;border: 1px solid #000;\"><strong>" + getCertRenewalDueDate(lt_g_tm_office_date, g_renewal_info.renewal_type) + "</strong></td>";
            x_html += "<td style=\"width:25%; text-align:left;border: 1px solid #000;\"><strong>" + getCertRenewalDueDate(g_app_info.filing_date, g_renewal_info.renewal_type) + "</strong></td>";
            x_html += "<td style=\"width:25%; text-align:right;border: 1px solid #000;\">Next renewal date : </td>";
         //   x_html += "<td style=\"width:25%; text-align:left;border: 1px solid #000;\"><strong>" + getCertNextRenewalDate(getCertRenewalDueDate(lt_g_tm_office_date, g_renewal_info.renewal_type)) + "</strong></td>";
            x_html += "<td style=\"width:25%; text-align:left;border: 1px solid #000;\"><strong>" + getCertNextRenewalDate(getCertRenewalDueDate(g_app_info.filing_date, g_renewal_info.renewal_type)) + "</strong></td>";

            x_html += "</tr>";                                
            x_html += "</table>";
            x_html += "</td>";
            x_html += "</tr>";     
            x_html += "<tr>";
            x_html += "<td style=\"background-color:#1C5E55; color:#fff; text-align:center; font-weight:normal; font-size:16px; font-family:Calibri;\" colspan=\"2\"> </td>";
            x_html += "</tr>";
            x_html += "<tr>";
            x_html += "<td align=\"center\" style=\"font-family: Garamond; font-size:16px;\" colspan=\"2\">";
            x_html += "<strong>";
            x_html += "For: Registrar of Trade Marks<br />";
            x_html += "The Trade Marks Registry,<br />";
            x_html += "Federal Ministry Of Industry, Trade and Investment<br />";
            x_html += "Federal Capital Territory<br />";
            x_html += "Abuja, Nigeria.<br /><br />";
            x_html += "<span style=\"font-family:Garamond; font-size:20px; font-weight:bold;color:#c00;\"> " + getCertDateFormat(lt_g_tm_office_date) + "</span> <br />";
            x_html += "<span style=\"text-align:center;\"> <img alt=\"Adewasiu\" src=\"../signatures/t009signature.jpg\" style=\" width: 222px;height: 83px;\" /><br /> </span>";
            x_html += "<hr />  NKIRU AGWU </strong> </td>";
            x_html += "</tr>";                       
            x_html += "</table>";


            return x_html;
        }

        protected string getT001(XObjs.G_App_info g_app_info, XObjs.G_Applicant_info g_applicant_info, XObjs.G_Tm_info g_tm_info, string transID, string comment, string name, string code_title, string user_type)
        {
 string x_html = ""; string x_header = ""; string x_gen_header = ""; string x_title = ""; string x_body = ""; string x_msg = ""; string x_footer = ""; string x_gen_footer = "";
 if (user_type != "admin")
 {
     x_title += "<html xmlns=\"http://www.w3.org/1999/xhtml\">";
     x_title += "<head runat=\"server\">";
     x_title += "<title>USER DOCUMENT</title>";
     x_title += "<link href=\"http://tm.cldng.com/css/style.css\" rel=\"stylesheet\" type=\"text/css\" />";
     x_title += "<script src=\"http://tm.cldng.com/js/funk.js\" type=\"text/javascript\"></script>";
     x_title += "</head>";
     x_title += "<body>";
     x_title += "<form id=\"form1\" runat=\"server\">";
 }
x_title += "<div style=\"width:100%;\">";
x_title += "<table style=\"font-family:Calibri;\" id=\"applicantForm\" align=\"center\" class=\"form\">";
x_gen_header = getGeneralHeader();//Gen Header here
x_header += "<tr>";
x_header += "<td style=\"font-size:18pt;line-height:115%;\" align=\"center\" colspan=\"2\">";
x_header += code_title;
x_header += "</td>";
x_header += "</tr>";
         
x_body+="<tr>";
x_body+=" <td style=\"background-color:#999999;\" align=\"left\" colspan=\"2\"></td>";
x_body+="</tr>";
x_body+=" <tr>";
           
x_body += "<tr><td align=\"right\">Applicant name:</td> <td align=\"left\">"+g_applicant_info.xname +"</td></tr>";
x_body += "<tr><td align=\"right\">Applicant address:</td> <td align=\"left\">" + g_applicant_info.address + "</td></tr>";
x_body += "<tr><td align=\"right\">Title of product:</td> <td align=\"left\">" + g_tm_info.tm_title + "</td></tr>";
x_body += "<tr><td align=\"right\">Representation Of TradeMark:</td> <td align=\"left\">" + g_tm_info.tm_class + "</td></tr>";
x_body += "<tr><td align=\"right\">Description of goods/services:</td> <td align=\"left\">" + g_tm_info.tm_desc + "</td></tr>";
//x_body += "<tr><td align=\"right\">Application number/file no:</td> <td align=\"left\">" + g_app_info.application_no + "</td></tr>";
x_body += "<tr><td align=\"right\">Request No:</td> <td align=\"left\">" + g_app_info.reg_no + "/" + g_app_info.rtm_number + "</td></tr>";
//x_body += "<tr><td align=\"right\">Filing date:</td> <td align=\"left\">" + g_app_info.filing_date + "</td></tr>";
x_body += "<tr><td align=\"right\">Request date:</td> <td align=\"left\">" + g_app_info.reg_date + "</td></tr>";
x_body += "<tr><td align=\"right\">Payment id:</td> <td align=\"left\">" + transID + "</td></tr>";
x_body += "<td align=\"center\" colspan=\"2\">  ";
if (g_tm_info.logo_pic != ""){  x_body += " <img alt=\"Trademark\" src=\"http://tm.cldng.com/admin/tm/gf/" + g_tm_info.logo_pic + "\" width=\"20%\" height=\"20%\" /><br />";}
x_body += "</td>";
x_body += "</tr> ";
  
x_msg += " <tr>";  
x_msg += "<td align=\"center\" colspan=\"2\">  ";
x_msg += " <strong>\"Search Report\"</strong> <br />";
x_msg += " <strong>" + comment + "</strong> <br /><hr />";
x_msg += "<br />This is to inform you that your request has been treated<br /> ";
x_msg += "Thank you<br />";
x_msg += "</td>";
x_msg += "</tr> ";
x_gen_footer = getGeneralFooter(name);//Gen Footer here
x_footer += "</table>";
x_footer += "</div>";
if (user_type != "admin")
{
    x_footer += "</form>";
    x_footer += "</body>";
    x_footer += "</html>";
}
x_html = x_title  + x_gen_header + x_header + x_body + x_msg + x_gen_footer + x_footer;
return x_html;
        }

        protected string getT014(XObjs.G_App_info g_app_info, XObjs.G_Applicant_info g_applicant_info, XObjs.G_Tm_info g_tm_info, string transID, string comment, string name, string code_title, string user_type, XObjs.G_Ass_info g_ass_info,XObjs.G_Merger_info g_merger_info)
        {
            DateTime dt = DateTime.Now;
           // String.Format("{0:MM-dd-yyyy}", dt);  
            string x_html = ""; string x_header = ""; string x_gen_header = ""; string x_title = ""; string x_body = ""; string x_msg = ""; string x_footer = ""; string x_gen_footer = "";
            if (user_type != "admin")
            {
                x_title += "<html xmlns=\"http://www.w3.org/1999/xhtml\">";
                x_title += "<head runat=\"server\">";
                x_title += "<title>USER DOCUMENT</title>";
                x_title += "<link href=\"http://tm.cldng.com/css/style.css\" rel=\"stylesheet\" type=\"text/css\" />";
                x_title += "<script src=\"http://tm.cldng.com/js/funk.js\" type=\"text/javascript\"></script>";
                x_title += "</head>";
                x_title += "<body>";
                x_title += "<form id=\"form1\" runat=\"server\">";
            }
            if (g_ass_info.xid != null)
            {
                x_title = "<P LANG=\"en-GB\" CLAx_title=\"western\" ALIGN=CENTER STYLE=\"margin-top: 0in\">";
                x_title = x_title + "<IMG SRC=\"http://tm.cldng.com/images/coat_of_arms.png\" height=\"120\"  width=\"120\"  STYLE=\"padding-top: 0.11in\" NAME=\"Picture 1\"   BORDER=0></P>";
             //   x_title += "  <img alt=\"Coat Of Arms\" height=\"120\" src=\"http://tm.cldng.com/images/coat_of_arms.png\" width=\"120\" />";
                //x_title = x_title + "<P LANG=\"en-GB\" CLAx_title=\"western\" STYLE=\"margin-bottom: 0.11in\"> </P>";
                x_title = x_title + "<P LANG=\"en-GB\" CLAx_title=\"western\" ALIGN=CENTER STYLE=\"margin-bottom: 0in; line-height: 100%\">";
                x_title = x_title + "<FONT FACE=\"Andalus, serif\"><FONT SIZE=5 STYLE=\"font-size: 20pt\">NIGERIA</FONT></FONT></P>";
                //x_title = x_title + "<P LANG=\"en-GB\" CLAx_title=\"western\" ALIGN=CENTER STYLE=\"margin-bottom: 0in; line-height: 100%\">";
                x_title = x_title + "<FONT FACE=\"Andalus, serif\"><FONT SIZE=4>Trade Marks Acts, 1990</FONT></FONT></P>";
                x_title = x_title + "<P LANG=\"en-GB\" CLAx_title=\"western\" ALIGN=CENTER STYLE=\"margin-bottom: 0in; line-height: 100%\"><A NAME=\"_GoBack\"></A>";
                x_title = x_title + "<FONT FACE=\"Andalus, serif\"><FONT SIZE=6 STYLE=\"font-size: 22pt\">CERTIFICATE OF ASSIGNMENT</FONT></FONT><FONT FACE=\"Andalus, serif\"><FONT SIZE=4></FONT></FONT> </P>";
                x_title = x_title + "<P LANG=\"en-GB\" CLAx_title=\"western\" STYLE=\"margin-bottom: 0in; line-height: 100%\" ><FONT FACE=\"Andalus, serif\"><FONT SIZE=3>To  </FONT></FONT><FONT ><FONT FACE=\"Andalus, serif\"><FONT SIZE=3>" + g_ass_info.assignee_name + " " + g_ass_info.assignee_address + "</FONT></FONT></FONT></P>";
                x_title = x_title + "<P LANG=\"en-GB\" CLAx_title=\"western\" STYLE=\"margin-bottom: 0.11in\"><FONT FACE=\"Andalus, serif\"><FONT SIZE=3>I HEREBY CERTIFY THAT your name has been entered on the register as proprietor/proprietors of Trade Mark No </FONT></FONT><FONT ><FONT FACE=\"Andalus, serif\"><FONT SIZE=3>" + g_app_info.reg_no + "</FONT></FONT></FONT><FONT FACE=\"Andalus, serif\"><FONT SIZE=3> </FONT></FONT><FONT ><FONT FACE=\"Andalus, serif\"><FONT SIZE=3>" + g_tm_info.tm_title + "</FONT></FONT></FONT><FONT FACE=\"Andalus, serif\"><FONT SIZE=3> in respect of </FONT></FONT><FONT ><FONT FACE=\"Andalus, serif\"><FONT SIZE=3> " + g_tm_info.tm_desc + "</FONT></FONT></FONT><FONT FACE=\"Andalus, serif\"><FONT SIZE=3> Pursuant to deed of Assignment  </FONT></FONT><FONT ><FONT FACE=\"Andalus, serif\"><FONT SIZE=3> " + g_ass_info.date_of_assignment + "</FONT></FONT></FONT></P>";
                x_title = x_title + "<P LANG=\"en-GB\" CLAx_title=\"western\" STYLE=\"margin-bottom: 0.11in\"><FONT FACE=\"Andalus, serif\"><FONT SIZE=3>A representation of the said Trade Mark is affixed hereto.</FONT></FONT></P>";
                x_title = x_title + "<P LANG=\"en-GB\" CLAx_title=\"western\" STYLE=\"margin-bottom: 0.11in\"><FONT FACE=\"Andalus, serif\"><FONT SIZE=3>Witness my hand this </FONT></FONT><FONT ><FONT FACE=\"Andalus, serif\"><FONT SIZE=3> " + g_app_info.reg_date + "</FONT></FONT></FONT></P>";
                x_title = x_title + "<P LANG=\"en-GB\" CLAx_title=\"western\" ALIGN=CENTER STYLE=\"margin-bottom: 0in\"> <FONT FACE=\"Andalus, serif\"><FONT SIZE=4>" + g_tm_info.tm_title + "</FONT></FONT></P>";
                if (g_tm_info.logo_pic != "") { x_title += "<P LANG=\"en-GB\" CLAx_title=\"western\" ALIGN=CENTER  STYLE=\"margin-bottom: 0in; line-height: 10%\" > <img alt=\"Trademark\" ALIGN=\"CENTER\" src=\"http://tm.cldng.com/admin/tm/gf/" + g_tm_info.logo_pic + "\" width=\"20%\" height=\"10%\" /> </P><br />"; }
                //x_title = x_title + "<P LANG=\"en-GB\" CLAx_title=\"western\" STYLE=\"margin-bottom: 0.11in\"><BR><BR> </P>";
                x_title = x_title + "<P LANG=\"en-GB\" CLAx_title=\"western\" ALIGN=CENTER STYLE=\"margin-bottom: 0in; line-height: 100%\"> <FONT FACE=\"Andalus, serif\"><FONT SIZE=2>Dated this </FONT></FONT><FONT ><FONT FACE=\"Andalus, serif\"><FONT SIZE=2><B> " + String.Format("{0:yyyy-MM-dd}", dt) + " </B></FONT></FONT></FONT></P>";
                x_title = x_title + "<P LANG=\"en-GB\" CLAx_title=\"western\" ALIGN=CENTER STYLE=\"margin-bottom: 0in; \"> <FONT ><FONT FACE=\"Andalus, serif\"><FONT SIZE=2><B>  <img alt=\"Trademark\" src=\"http://tm.cldng.com/images/sig.jpg\" width=\"20%\" height=\"10%\" />   </B></FONT></FONT></FONT></P>";
                x_title = x_title + "<P LANG=\"en-GB\" CLAx_title=\"western\" ALIGN=CENTER STYLE=\"margin-bottom: 0in; line-height: 100%\"> <FONT ><FONT FACE=\"Andalus, serif\"><FONT SIZE=2><B>  Nkiru Agwu </B></FONT></FONT></FONT></P>";
               
                x_title = x_title + "<DIV TYPE=FOOTER>";

                x_title = x_title + "<P LANG=\"en-GB\" CLAx_title=\"western\" ALIGN=CENTER STYLE=\"margin-top: 0.46in; margin-bottom: 0in; line-height: 100%\"> <FONT FACE=\"Arial Rounded MT Bold, serif\"><FONT SIZE=3>For:	Registrar of Trade Marks</FONT></FONT></P>";
                x_title = x_title + "<P LANG=\"en-GB\" CLAx_title=\"western\" ALIGN=CENTER STYLE=\"margin-bottom: 0in; line-height: 100%\"> 	<FONT FACE=\"Arial Rounded MT Bold, serif\"><FONT SIZE=3>The Trade 	Marks Registry,</FONT></FONT></P>";
                x_title = x_title + "<P LANG=\"en-GB\" CLAx_title=\"western\" ALIGN=CENTER STYLE=\"margin-bottom: 0in; line-height: 100%\"> 	<FONT FACE=\"Arial Rounded MT Bold, serif\"><FONT SIZE=3>Federal 	Ministry Of Industry, Trade and Investment</FONT></FONT></P>";
                x_title = x_title + "<P LANG=\"en-GB\" CLAx_title=\"western\" ALIGN=CENTER STYLE=\"margin-bottom: 0in; line-height: 100%\"> 	<FONT FACE=\"Arial Rounded MT Bold, serif\"><FONT SIZE=3>Federal 	Capital Territory</FONT></FONT></P>";
                x_title = x_title + "<P LANG=\"en-GB\" CLAx_title=\"western\" ALIGN=CENTER STYLE=\"margin-bottom: 0in; line-height: 100%\"> 	<FONT FACE=\"Arial Rounded MT Bold, serif\"><FONT SIZE=3>Abuja, 	Nigeria.</FONT></FONT></P>";
                x_title = x_title + "<P LANG=\"en-GB\" STYLE=\"margin-bottom: 0in; line-height: 100%\"><BR>";
                x_title = x_title + "</DIV>";
                //  x_gen_footer = getGeneralFooter(name);//Gen Footer here
            }

            else if (g_merger_info.xid != null)
            {

                x_title = "<P LANG=\"en-GB\" CLAx_title=\"western\" ALIGN=CENTER STYLE=\"margin-top: 0in\">";
                x_title = x_title + "<IMG SRC=\"http://tm.cldng.com/images/coat_of_arms.png\" height=\"120\"  width=\"120\"  STYLE=\"padding-top: 0.11in\" NAME=\"Picture 1\"   BORDER=0></P>";
                //   x_title += "  <img alt=\"Coat Of Arms\" height=\"120\" src=\"http://tm.cldng.com/images/coat_of_arms.png\" width=\"120\" />";
                //x_title = x_title + "<P LANG=\"en-GB\" CLAx_title=\"western\" STYLE=\"margin-bottom: 0.11in\"> </P>";
                x_title = x_title + "<P LANG=\"en-GB\" CLAx_title=\"western\" ALIGN=CENTER STYLE=\"margin-bottom: 0in; line-height: 100%\">";
                x_title = x_title + "<FONT FACE=\"Andalus, serif\"><FONT SIZE=5 STYLE=\"font-size: 20pt\">NIGERIA</FONT></FONT></P>";
                //x_title = x_title + "<P LANG=\"en-GB\" CLAx_title=\"western\" ALIGN=CENTER STYLE=\"margin-bottom: 0in; line-height: 100%\">";
                x_title = x_title + "<FONT FACE=\"Andalus, serif\"><FONT SIZE=4>Trade Marks Acts, 1990</FONT></FONT></P>";
                x_title = x_title + "<P LANG=\"en-GB\" CLAx_title=\"western\" ALIGN=CENTER STYLE=\"margin-bottom: 0in; line-height: 100%\"><A NAME=\"_GoBack\"></A>";
                x_title = x_title + "<FONT FACE=\"Andalus, serif\"><FONT SIZE=6 STYLE=\"font-size: 22pt\">CERTIFICATE OF MERGER</FONT></FONT><FONT FACE=\"Andalus, serif\"><FONT SIZE=4></FONT></FONT> </P>";
                x_title = x_title + "<P LANG=\"en-GB\" CLAx_title=\"western\" STYLE=\"margin-bottom: 0in; line-height: 100%\" ><FONT FACE=\"Andalus, serif\"><FONT SIZE=3>To  </FONT></FONT><FONT ><FONT FACE=\"Andalus, serif\"><FONT SIZE=3>" + g_merger_info.merging_name + " " + g_merger_info.merging_address + "</FONT></FONT></FONT></P>";
                x_title = x_title + "<P LANG=\"en-GB\" CLAx_title=\"western\" STYLE=\"margin-bottom: 0.11in\"><FONT FACE=\"Andalus, serif\"><FONT SIZE=3>I HEREBY CERTIFY THAT your name has been entered on the register as proprietor/proprietors of Trade Mark No </FONT></FONT><FONT ><FONT FACE=\"Andalus, serif\"><FONT SIZE=3>" + g_app_info.reg_no + "</FONT></FONT></FONT><FONT FACE=\"Andalus, serif\"><FONT SIZE=3> </FONT></FONT><FONT ><FONT FACE=\"Andalus, serif\"><FONT SIZE=3>" + g_tm_info.tm_title + "</FONT></FONT></FONT><FONT FACE=\"Andalus, serif\"><FONT SIZE=3> in respect of </FONT></FONT><FONT ><FONT FACE=\"Andalus, serif\"><FONT SIZE=3> " + g_tm_info.tm_desc + "</FONT></FONT></FONT><FONT FACE=\"Andalus, serif\"><FONT SIZE=3> Pursuant to deed of Assignment  </FONT></FONT><FONT ><FONT FACE=\"Andalus, serif\"><FONT SIZE=3> " + g_merger_info.merger_date + "</FONT></FONT></FONT></P>";
                x_title = x_title + "<P LANG=\"en-GB\" CLAx_title=\"western\" STYLE=\"margin-bottom: 0.11in\"><FONT FACE=\"Andalus, serif\"><FONT SIZE=3>A representation of the said Trade Mark is affixed hereto.</FONT></FONT></P>";
                x_title = x_title + "<P LANG=\"en-GB\" CLAx_title=\"western\" STYLE=\"margin-bottom: 0.11in\"><FONT FACE=\"Andalus, serif\"><FONT SIZE=3>Witness my hand this </FONT></FONT><FONT ><FONT FACE=\"Andalus, serif\"><FONT SIZE=3> " + g_app_info.reg_date + "</FONT></FONT></FONT></P>";
                x_title = x_title + "<P LANG=\"en-GB\" CLAx_title=\"western\" ALIGN=CENTER STYLE=\"margin-bottom: 0in\"> <FONT FACE=\"Andalus, serif\"><FONT SIZE=4>" + g_tm_info.tm_title + "</FONT></FONT></P>";
                if (g_tm_info.logo_pic != "") { x_title += "<P LANG=\"en-GB\" CLAx_title=\"western\" ALIGN=CENTER  STYLE=\"margin-bottom: 0in; line-height: 10%\" > <img alt=\"Trademark\" ALIGN=\"CENTER\" src=\"http://tm.cldng.com/admin/tm/gf/" + g_tm_info.logo_pic + "\" width=\"20%\" height=\"10%\" /> </P><br />"; }
                //x_title = x_title + "<P LANG=\"en-GB\" CLAx_title=\"western\" STYLE=\"margin-bottom: 0.11in\"><BR><BR> </P>"; 
                x_title = x_title + "<P LANG=\"en-GB\" CLAx_title=\"western\" ALIGN=CENTER STYLE=\"margin-bottom: 0in; line-height: 100%\"> <FONT FACE=\"Andalus, serif\"><FONT SIZE=2>Dated this </FONT></FONT><FONT ><FONT FACE=\"Andalus, serif\"><FONT SIZE=2><B> " + String.Format("{0:yyyy-MM-dd}", dt) + " </B></FONT></FONT></FONT></P>";
                x_title = x_title + "<P LANG=\"en-GB\" CLAx_title=\"western\" ALIGN=CENTER STYLE=\"margin-bottom: 0in; \"> <FONT ><FONT FACE=\"Andalus, serif\"><FONT SIZE=2><B>  <img alt=\"Trademark\" src=\"http://tm.cldng.com/images/sig.jpg\" width=\"20%\" height=\"10%\" />   </B></FONT></FONT></FONT></P>";
                x_title = x_title + "<P LANG=\"en-GB\" CLAx_title=\"western\" ALIGN=CENTER STYLE=\"margin-bottom: 0in; line-height: 100%\"> <FONT ><FONT FACE=\"Andalus, serif\"><FONT SIZE=2><B>  Nkiru Agwu </B></FONT></FONT></FONT></P>";

                x_title = x_title + "<DIV TYPE=FOOTER>";

                x_title = x_title + "<P LANG=\"en-GB\" CLAx_title=\"western\" ALIGN=CENTER STYLE=\"margin-top: 0.46in; margin-bottom: 0in; line-height: 100%\"> <FONT FACE=\"Arial Rounded MT Bold, serif\"><FONT SIZE=3>For:	Registrar of Trade Marks</FONT></FONT></P>";
                x_title = x_title + "<P LANG=\"en-GB\" CLAx_title=\"western\" ALIGN=CENTER STYLE=\"margin-bottom: 0in; line-height: 100%\"> 	<FONT FACE=\"Arial Rounded MT Bold, serif\"><FONT SIZE=3>The Trade 	Marks Registry,</FONT></FONT></P>";
                x_title = x_title + "<P LANG=\"en-GB\" CLAx_title=\"western\" ALIGN=CENTER STYLE=\"margin-bottom: 0in; line-height: 100%\"> 	<FONT FACE=\"Arial Rounded MT Bold, serif\"><FONT SIZE=3>Federal 	Ministry Of Industry, Trade and Investment</FONT></FONT></P>";
                x_title = x_title + "<P LANG=\"en-GB\" CLAx_title=\"western\" ALIGN=CENTER STYLE=\"margin-bottom: 0in; line-height: 100%\"> 	<FONT FACE=\"Arial Rounded MT Bold, serif\"><FONT SIZE=3>Federal 	Capital Territory</FONT></FONT></P>";
                x_title = x_title + "<P LANG=\"en-GB\" CLAx_title=\"western\" ALIGN=CENTER STYLE=\"margin-bottom: 0in; line-height: 100%\"> 	<FONT FACE=\"Arial Rounded MT Bold, serif\"><FONT SIZE=3>Abuja, 	Nigeria.</FONT></FONT></P>";
                x_title = x_title + "<P LANG=\"en-GB\" STYLE=\"margin-bottom: 0in; line-height: 100%\"><BR>";
                x_title = x_title + "</DIV>";
            }


            if (user_type != "admin")
            {
                x_footer += "</form>";
                x_footer += "</body>";
                x_footer += "</html>";
            }
            x_html = x_title +   x_footer;
            return x_html;
        }

        protected string getT008( XObjs.G_Change_info g_change_info,XObjs.G_App_info g_app_info, XObjs.G_Tm_info g_tm_info, string transID, string comment, string name, string code_title, string user_type)
        {
            string x_html = ""; string x_header = ""; string x_gen_header = ""; string x_title = ""; string x_body = ""; string x_msg = ""; string x_footer = ""; string x_gen_footer = "";
            if (user_type != "admin")
            {
                x_title += "<html xmlns=\"http://www.w3.org/1999/xhtml\">";
                x_title += "<head runat=\"server\">";
                x_title += "<title>USER DOCUMENT</title>";
                x_title += "<link href=\"http://tm.cldng.com/css/style.css\" rel=\"stylesheet\" type=\"text/css\" />";
                x_title += "<script src=\"http://tm.cldng.com/js/funk.js\" type=\"text/javascript\"></script>";
                x_title += "</head>";
                x_title += "<body>";
                x_title += "<form id=\"form1\" runat=\"server\">";
            }
            x_title += "<div style=\"width:100%;\">";
            x_title += "<table style=\"font-family:Calibri;\" id=\"applicantForm\" align=\"center\" class=\"form\">";
            x_gen_header = getGeneralHeaderT008();//Gen Header here
            x_header += "<tr>";
            x_header += "<td style=\"font-size:18pt;line-height:115%;\" align=\"center\" colspan=\"2\">";
            x_header += code_title;
            x_header += "</td>";
            x_header += "</tr>";

          
            x_body += "<tr>";
            x_body += "<td >";
            x_body += "<div style=\"text-align:justify;padding-left:150px;\"> ";
            x_body += "In the Matter of <strong>" + g_tm_info.tm_title + "</strong> No <strong>" + g_app_info.rtm_number + "</strong> registered in class <br />";
            x_body += "<strong>" + g_tm_info.tm_class + "</strong><br />";
            x_body += "I/we  <strong>" + g_change_info.old_name + "</strong> being the registered  proprietor(s) / user(s) of the Trade <br />";
            x_body += "Mark(s) numbered as above, request that my/our trade address in the Register <br />";
            x_body += "of Trade Mark(s) be altered to <strong>" + g_change_info.new_address + "</strong>, formerly known as <strong>" + g_change_info.old_address + "</strong><br />";
            x_body += "Dated this <strong>..... </strong>day of <strong>...</strong> <strong>20………….</strong>br /><br /><br /><br />";
            x_body += " </div>";
            x_body += "</td>";
            x_body += "</tr> ";
          
            
            x_gen_footer = getGeneralFooterT008("C. C.  Okeke");//Gen Footer here
            x_footer += "</table>";
            x_footer += "</div>";
            if (user_type != "admin")
            {
                x_footer += "</form>";
                x_footer += "</body>";
                x_footer += "</html>";
            }
            x_html = x_title + x_gen_header + x_header + x_body + x_gen_footer + x_footer;
            return x_html;
        }

        //protected string getT014(XObjs.G_App_info g_app_info, XObjs.G_Applicant_info g_applicant_info, XObjs.G_Tm_info g_tm_info, string transID, string comment, string name, string code_title,string user_type)
        //{
        //    string x_html = ""; string x_header = ""; string x_gen_header = ""; string x_title = ""; string x_body = ""; string x_msg = ""; string x_footer = ""; string x_gen_footer = "";
        //    if (user_type != "admin")
        //    {
        //        x_title += "<html xmlns=\"http://www.w3.org/1999/xhtml\">";
        //        x_title += "<head runat=\"server\">";
        //        x_title += "<title>USER DOCUMENT</title>";
        //        x_title += "<link href=\"http://tm.cldng.com/css/style.css\" rel=\"stylesheet\" type=\"text/css\" />";
        //        x_title += "<script src=\"http://tm.cldng.com/js/funk.js\" type=\"text/javascript\"></script>";
        //        x_title += "</head>";
        //        x_title += "<body>";
        //        x_title += "<form id=\"form1\" runat=\"server\">";
        //    }
        //    x_title += "<div style=\"width:100%;\">";
        //    x_title += "<table style=\"font-family:Calibri;\" id=\"applicantForm\" align=\"center\" class=\"form\">";
        //    x_gen_header = getGeneralHeader();//Gen Header here
        //    x_header += "<tr>";
        //    x_header += "<td style=\"font-size:18pt;line-height:115%;\" align=\"center\" colspan=\"2\">";
        //    x_header += code_title;
        //    x_header += "</td>";
        //    x_header += "</tr>";

        //    x_body += "<tr>";
        //    x_body += " <td style=\"background-color:#999999;\" align=\"left\" colspan=\"2\"></td>";
        //    x_body += "</tr>";
        //    x_body += " <tr>";
        //    x_body += "<tr><td align=\"right\">Applicant name:</td> <td align=\"left\">" + g_applicant_info.xname + "</td></tr>";
        //    x_body += "<tr><td align=\"right\">Applicant address:</td> <td align=\"left\">" + g_applicant_info.address + "</td></tr>";
        //    x_body += "<tr><td align=\"right\">Title of product:</td> <td align=\"left\">" + g_tm_info.tm_title + "</td></tr>";
        //    x_body += "<tr><td align=\"right\">Class:</td> <td align=\"left\">" + g_tm_info.tm_class + "</td></tr>";
        //    x_body += "<tr><td align=\"right\">Description of goods/services:</td> <td align=\"left\">" + g_tm_info.tm_desc + "</td></tr>";
        //    x_body += "<tr><td align=\"right\">Application number/file no:</td> <td align=\"left\">" + g_app_info.application_no + "</td></tr>";
        //    x_body += "<tr><td align=\"right\">Registration no/RTM:</td> <td align=\"left\">" + g_app_info.reg_no + "/" + g_app_info.rtm_number + "</td></tr>";
        //    x_body += "<tr><td align=\"right\">Filing date:</td> <td align=\"left\">" + g_app_info.filing_date + "</td></tr>";
        //    x_body += "<tr><td align=\"right\">Request date:</td> <td align=\"left\">" + g_app_info.reg_date + "</td></tr>";
        //    x_body += "<tr><td align=\"right\">Payment id:</td> <td align=\"left\">" + transID + "</td></tr>";
        //    x_body += "<td align=\"center\" colspan=\"2\">  ";
        //    if (g_tm_info.logo_pic != "") { x_body += " <img alt=\"Trademark\" src=\"http://tm.cldng.com/admin/tm/gf/" + g_tm_info.logo_pic + "\" width=\"20%\" height=\"20%\" /><br />"; }
        //    x_body += "</td>";
        //    x_body += "</tr> ";

        //    x_msg += " <tr>";
        //    x_msg += "<td align=\"center\" colspan=\"2\">  ";
        //    x_msg += " <strong>\"Units Comment\"</strong> <br />";
        //    x_msg += " <strong>" + comment + "</strong> <br /><hr />";
        //    x_msg += "<br />This is to inform you that your request has been treated<br /> ";
        //    x_msg += "Thank you<br />";
        //    x_msg += "</td>";
        //    x_msg += "</tr> ";
        //    x_gen_footer = getGeneralFooter(name);//Gen Footer here
        //    x_footer += "</table>";
        //    x_footer += "</div>";
        //    if (user_type != "admin")
        //    {
        //        x_footer += "</form>";
        //        x_footer += "</body>";
        //        x_footer += "</html>";
        //    }
        //    x_html = x_title + x_gen_header + x_header + x_body + x_msg + x_gen_footer + x_footer;
        //    return x_html;
        //}

        protected string getT017(XObjs.G_App_info g_app_info, XObjs.G_Applicant_info g_applicant_info, XObjs.G_Tm_info g_tm_info, string transID, string comment, string name, string code_title,string user_type)
        {
            string x_html = ""; string x_header = ""; string x_gen_header = ""; string x_title = ""; string x_body = ""; string x_msg = ""; string x_footer = ""; string x_gen_footer = "";
            if (user_type != "admin")
            {
                x_title += "<html xmlns=\"http://www.w3.org/1999/xhtml\">";
                x_title += "<head runat=\"server\">";
                x_title += "<title>USER DOCUMENT</title>";
                x_title += "<link href=\"http://tm.cldng.com/css/style.css\" rel=\"stylesheet\" type=\"text/css\" />";
                x_title += "<script src=\"http://tm.cldng.com/js/funk.js\" type=\"text/javascript\"></script>";
                x_title += "</head>";
                x_title += "<body>";
                x_title += "<form id=\"form1\" runat=\"server\">";
            }
            x_title += "<div style=\"width:100%;\">";
            x_title += "<table style=\"font-family:Calibri;\" id=\"applicantForm\" align=\"center\" class=\"form\">";
            x_gen_header = getGeneralHeader();//Gen Header here
            x_header += "<tr>";
            x_header += "<td style=\"font-size:18pt;line-height:115%;\" align=\"center\" colspan=\"2\">";
            x_header += code_title;
            x_header += "</td>";
            x_header += "</tr>";

            x_body += "<tr>";
            x_body += " <td style=\"background-color:#999999;\" align=\"left\" colspan=\"2\"></td>";
            x_body += "</tr>";
            x_body += " <tr>";
            x_body += "<tr><td align=\"right\">Applicant name:</td> <td align=\"left\">" + g_applicant_info.xname + "</td></tr>";
            x_body += "<tr><td align=\"right\">Applicant address:</td> <td align=\"left\">" + g_applicant_info.address + "</td></tr>";
            x_body += "<tr><td align=\"right\">Title of product:</td> <td align=\"left\">" + g_tm_info.tm_title + "</td></tr>";
            x_body += "<tr><td align=\"right\">Class:</td> <td align=\"left\">" + g_tm_info.tm_class + "</td></tr>";
            x_body += "<tr><td align=\"right\">Description of goods/services:</td> <td align=\"left\">" + g_tm_info.tm_desc + "</td></tr>";
            x_body += "<tr><td align=\"right\">Application number/file no:</td> <td align=\"left\">" + g_app_info.application_no + "</td></tr>";
            x_body += "<tr><td align=\"right\">Registration no/RTM:</td> <td align=\"left\">" + g_app_info.reg_no + "/" + g_app_info.rtm_number + "</td></tr>";
            x_body += "<tr><td align=\"right\">Filing date:</td> <td align=\"left\">" + g_app_info.filing_date + "</td></tr>";
            x_body += "<tr><td align=\"right\">Request date:</td> <td align=\"left\">" + g_app_info.reg_date + "</td></tr>";
            x_body += "<tr><td align=\"right\">Payment id:</td> <td align=\"left\">" + transID + "</td></tr>";
            x_body += "<td align=\"center\" colspan=\"2\">  ";
            if (g_tm_info.logo_pic != "") { x_body += " <img alt=\"Trademark\" src=\"http://tm.cldng.com/admin/tm/gf/" + g_tm_info.logo_pic + "\" width=\"20%\" height=\"20%\" /><br />"; }
            x_body += "</td>";
            x_body += "</tr> ";

            x_msg += " <tr>";
            x_msg += "<td align=\"center\" colspan=\"2\">  ";
            x_msg += " <strong>\"Units Comment\"</strong> <br />";
            x_msg += " <strong>" + comment + "</strong> <br /><hr />";
            x_msg += "<br />This is to inform you that your request has been treated<br /> ";
            x_msg += "Thank you<br />";
            x_msg += "</td>";
            x_msg += "</tr> ";
            x_gen_footer = getGeneralFooter(name);//Gen Footer here
            x_footer += "</table>";
            x_footer += "</div>";
            if (user_type != "admin")
            {
                x_footer += "</form>";
                x_footer += "</body>";
                x_footer += "</html>";
            }
            x_html = x_title + x_gen_header + x_header + x_body + x_msg + x_gen_footer + x_footer;
            return x_html;
        }


    }
}