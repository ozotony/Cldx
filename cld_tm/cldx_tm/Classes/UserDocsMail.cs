using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cld.Classes
{
    public class UserDocsMail
    {
        public Retriever ret = new Retriever();
        public Registration reg = new Registration();


        public string returnDoc(
            string item_code, 
            string transID,
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
            string comment, string name, string code_title
            )
        {
            switch (item_code.ToLower())
            {
                case "t001": return getT001(g_app_info, g_applicant_info, g_tm_info, transID, comment,name,code_title);
                case "t003": return getT001(g_app_info, g_applicant_info, g_tm_info, transID, comment, name, code_title);//Similar to T001
                case "t008": return getT008(g_change_info,g_app_info, g_tm_info, transID, comment, name, code_title);
                case "t009": return getT001(g_app_info, g_applicant_info, g_tm_info, transID, comment,name,code_title);
                case "t010": return getT001(g_app_info, g_applicant_info, g_tm_info, transID, comment, name, code_title);//Similar to T001
                case "t011": return getT001(g_app_info, g_applicant_info, g_tm_info, transID, comment, name, code_title);//Similar to T001
                case "t012": return getT001(g_app_info, g_applicant_info, g_tm_info, transID, comment, name, code_title);//Similar to T001
                case "t013": return getT001(g_app_info, g_applicant_info, g_tm_info, transID, comment, name, code_title);//Similar to T001
                case "t014": return getT001(g_app_info, g_applicant_info, g_tm_info, transID, comment,name,code_title);
                case "t016": return getT001(g_app_info, g_applicant_info, g_tm_info, transID, comment, name, code_title);//Similar to T001
                case "t017": return getT001(g_app_info, g_applicant_info, g_tm_info, transID, comment,name,code_title);
                case "t018": return getT001(g_app_info, g_applicant_info, g_tm_info, transID, comment,name,code_title);
                case "t019": return getT001(g_app_info, g_applicant_info, g_tm_info, transID, comment, name, code_title);//Similar to T001
                case "t021": return getT001(g_app_info, g_applicant_info, g_tm_info, transID, comment, name, code_title);//Similar to T001
                case "t022": return getT001(g_app_info, g_applicant_info, g_tm_info, transID, comment, name, code_title);//Similar to T001
                case "t023": return getT001(g_app_info, g_applicant_info, g_tm_info, transID, comment, name, code_title);//Similar to T001
                case "t024": return getT001(g_app_info, g_applicant_info, g_tm_info, transID, comment, name, code_title);//Similar to T001
                case "t025": return getT001(g_app_info, g_applicant_info, g_tm_info, transID, comment, name, code_title);//Similar to T001
                case "t026": return getT001(g_app_info, g_applicant_info, g_tm_info, transID, comment, name, code_title);//Similar to T001
                case "t027": return getT001(g_app_info, g_applicant_info, g_tm_info, transID, comment, name, code_title);//Similar to T001
            }
            return "NA";
        }


        protected string getGeneralHeader()
        {
            string x_gen_header = "";

            x_gen_header += "<tr align=\"center\">";
            x_gen_header += "<td colspan=\"2\">";
            x_gen_header += "  <img alt=\"Coat Of Arms\" height=\"120\" src=\"http://tm.cldng.com/xtm/images/coat_of_arms.png\" width=\"120\" />";
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
            x_gen_header += "  <img alt=\"Coat Of Arms\" height=\"120\" src=\"http://tm.cldng.com/xtm/images/coat_of_arms.png\" width=\"120\" />";
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
            x_gen_footer += " <td align=\"center\">";
            x_gen_footer += "<strong>" + officer_name + "</strong><br /><br />";
            x_gen_footer += " For: Registrar of Trade Marks <br />";
            x_gen_footer += "The Trade Marks Registry,<br /> ";
            x_gen_footer += "Federal Ministry of Industry, Trade and Investment ,<br /> ";
            x_gen_footer += "Federal Capital Territory,<br /> ";
            x_gen_footer += "Abuja, Nigeria. </td>";
            x_gen_footer += "</tr>";

            return x_gen_footer;
        }
        protected string getT001(XObjs.G_App_info g_app_info, XObjs.G_Applicant_info g_applicant_info, XObjs.G_Tm_info g_tm_info, string transID, string comment, string name,string code_title)
        {
 string x_html = ""; string x_header = ""; string x_gen_header = ""; string x_title = ""; string x_body = ""; string x_msg = ""; string x_footer = ""; string x_gen_footer = "";          

x_title+="<html xmlns=\"http://www.w3.org/1999/xhtml\">";
x_title+="<head runat=\"server\">";
x_title+="<title>USER DOCUMENT</title>";
x_title += "<link href=\"http://tm.cldng.com/xtm/css/style.css\" rel=\"stylesheet\" type=\"text/css\" />";
x_title += "<script src=\"http://tm.cldng.com/xtm/js/funk.js\" type=\"text/javascript\"></script>";  
x_title+="</head>";
x_title += "<body>";
x_title += "<form id=\"form1\" runat=\"server\">";
x_title += "<div style=\"width:70%;\">";
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
x_body += "<tr><td align=\"right\">Class:</td> <td align=\"left\">" + g_tm_info.tm_class + "</td></tr>";
x_body += "<tr><td align=\"right\">Description of goods/services:</td> <td align=\"left\">" + g_tm_info.tm_desc + "</td></tr>";
x_body += "<tr><td align=\"right\">Application number/file no:</td> <td align=\"left\">" + g_app_info.application_no + "</td></tr>";
x_body += "<tr><td align=\"right\">Registration no/RTM:</td> <td align=\"left\">" + g_app_info.reg_no + "/" + g_app_info.rtm_number + "</td></tr>";
x_body += "<tr><td align=\"right\">Filing date:</td> <td align=\"left\">" + g_app_info.filing_date + "</td></tr>";
x_body += "<tr><td align=\"right\">Request date:</td> <td align=\"left\">" + g_app_info.reg_date + "</td></tr>";
x_body += "<tr><td align=\"right\">Payment id:</td> <td align=\"left\">" + transID + "</td></tr>";
x_body += "<td align=\"center\" colspan=\"2\">  ";
if (g_tm_info.logo_pic != ""){  x_body += " <img alt=\"Trademark\" src=\"http://tm.cldng.com/xtm/admin/tm/gf/" + g_tm_info.logo_pic + "\" width=\"20%\" height=\"20%\" /><br />";}
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
x_footer += "</form>";
x_footer += "</body>";
x_footer += "</html>";
x_html = x_title  + x_gen_header + x_header + x_body + x_msg + x_gen_footer + x_footer;
return x_html;
        }

        protected string getT008( XObjs.G_Change_info g_change_info,XObjs.G_App_info g_app_info, XObjs.G_Tm_info g_tm_info, string transID, string comment, string name, string code_title)
        {
            string x_html = ""; string x_header = ""; string x_gen_header = ""; string x_title = ""; string x_body = ""; string x_msg = ""; string x_footer = ""; string x_gen_footer = "";

            x_title += "<html xmlns=\"http://www.w3.org/1999/xhtml\">";
            x_title += "<head runat=\"server\">";
            x_title += "<title>USER DOCUMENT</title>";
            x_title += "<link href=\"http://tm.cldng.com/xtm/css/style.css\" rel=\"stylesheet\" type=\"text/css\" />";
            x_title += "<script src=\"http://tm.cldng.com/xtm/js/funk.js\" type=\"text/javascript\"></script>";
            x_title += "</head>";
            x_title += "<body>";
            x_title += "<form id=\"form1\" runat=\"server\">";
            x_title += "<div style=\"width:70%;\">";
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
            x_footer += "</form>";
            x_footer += "</body>";
            x_footer += "</html>";
            x_html = x_title + x_gen_header + x_header + x_body + x_gen_footer + x_footer;
            return x_html;
        }

        protected string getT014(XObjs.G_App_info g_app_info, XObjs.G_Applicant_info g_applicant_info, XObjs.G_Tm_info g_tm_info, string transID, string comment, string name, string code_title)
        {
            string x_html = ""; string x_header = ""; string x_gen_header = ""; string x_title = ""; string x_body = ""; string x_msg = ""; string x_footer = ""; string x_gen_footer = "";

            x_title += "<html xmlns=\"http://www.w3.org/1999/xhtml\">";
            x_title += "<head runat=\"server\">";
            x_title += "<title>USER DOCUMENT</title>";
            x_title += "<link href=\"http://tm.cldng.com/xtm/css/style.css\" rel=\"stylesheet\" type=\"text/css\" />";
            x_title += "<script src=\"http://tm.cldng.com/xtm/js/funk.js\" type=\"text/javascript\"></script>";
            x_title += "</head>";
            x_title += "<body>";
            x_title += "<form id=\"form1\" runat=\"server\">";
            x_title += "<div style=\"width:70%;\">";
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
            if (g_tm_info.logo_pic != "") { x_body += " <img alt=\"Trademark\" src=\"http://tm.cldng.com/xtm/admin/tm/gf/" + g_tm_info.logo_pic + "\" width=\"20%\" height=\"20%\" /><br />"; }
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
            x_footer += "</form>";
            x_footer += "</body>";
            x_footer += "</html>";
            x_html = x_title + x_gen_header + x_header + x_body + x_msg + x_gen_footer + x_footer;
            return x_html;
        }

        protected string getT017(XObjs.G_App_info g_app_info, XObjs.G_Applicant_info g_applicant_info, XObjs.G_Tm_info g_tm_info, string transID, string comment, string name, string code_title)
        {
            string x_html = ""; string x_header = ""; string x_gen_header = ""; string x_title = ""; string x_body = ""; string x_msg = ""; string x_footer = ""; string x_gen_footer = "";

            x_title += "<html xmlns=\"http://www.w3.org/1999/xhtml\">";
            x_title += "<head runat=\"server\">";
            x_title += "<title>USER DOCUMENT</title>";
            x_title += "<link href=\"http://tm.cldng.com/xtm/css/style.css\" rel=\"stylesheet\" type=\"text/css\" />";
            x_title += "<script src=\"http://tm.cldng.com/xtm/js/funk.js\" type=\"text/javascript\"></script>";
            x_title += "</head>";
            x_title += "<body>";
            x_title += "<form id=\"form1\" runat=\"server\">";
            x_title += "<div style=\"width:70%;\">";
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
            if (g_tm_info.logo_pic != "") { x_body += " <img alt=\"Trademark\" src=\"http://tm.cldng.com/xtm/admin/tm/gf/" + g_tm_info.logo_pic + "\" width=\"20%\" height=\"20%\" /><br />"; }
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
            x_footer += "</form>";
            x_footer += "</body>";
            x_footer += "</html>";
            x_html = x_title + x_gen_header + x_header + x_body + x_msg + x_gen_footer + x_footer;
            return x_html;
        }


    }
}