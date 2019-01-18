<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="s_data_details2_report.aspx.cs" Inherits="cld.admin.tm.s_data_details2_report" MaintainScrollPositionOnPostback="true" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SEARCH DETAILS</title>
    <link href="../../css/style.css" rel="stylesheet" type="text/css" />

<script src="../../js/funk.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
   <div>
    <div class="container">
        <div class="sidebar">
            <a href="./search_unit2/profile.aspx">PROFILE</a> 
            <a href="../../cp.aspx?x=<% Response.Write(admin); %>">CHANGE PASSWORD</a> 
            <a href="./search_unit2/sed.aspx">VIEW STATISTICS</a>
        </div>
        <div class="content">
            <div class="header">
                <div class="xmenu">
                    <div class="menu">
                        <ul>
                            <li><a href="./lo.aspx">
                                <img alt="" src="../../images/logoff.png" width="16" height="16" />Log off</a></li>
                        </ul>
                    </div>
                </div>
                
                <table align="center" width="100%" >
                    <tr id="search_report">
                        <td  align="center" width="100%">
                <table align="center" width="1200" class="form" style="font-size:18px;">
                    <tr>
                        <td colspan="4" align="center" width="100%">
                            <strong>FEDERAL MINISTRY OF TRADE AND INVESTMENT<br />COMMERCIAL LAW DEPARTMENT<br />INDUSTRIAL PROPERTY OFFICE REGISTRY 
                            </strong>
                        </td>
                    </tr>
                    <tr>
                        <td  colspan="4" align="center">
                            <img src="../../images/coat_of_arms.png" style="width: 80px; height: 80px" />
                        </td>
                    </tr>
                      <tr>
                        <td colspan="4" align="center" style="font-weight:bold; font-size:18px;">
                             THIS REPORT IS NOT OPEN TO PUBLIC INSPECTION AND MUST NOT BE REMOVED FROM THE FILE</td>
                    </tr>
                    <tr>
                        <td  colspan="4" class="tbbg" align="center" style="font-size:20px; font-weight:bolder;">
                           SEARCH REPORT DETAILS FOR "<% Response.Write(c_mark.product_title.ToUpper()); %>"</td>
                    </tr>
                    <tr style="font-size:17px;">
                        <td  align="right" width="25%">              
                 SYSTEM APPLICATION NUMBER :&nbsp;&nbsp;
                        </td>
                        <td  align="left" width="25%">
                            &nbsp;<% Response.Write("OAI/TM/"+c_p.validationID); %>
                            </td>
                        <td align="right">
                              REGISTRATION NUMBER :&nbsp;&nbsp;
                            
                        </td>
                        <td align="left" width="25%">
                            &nbsp;<% Response.Write(c_mark.reg_number.ToUpper()); %></td>
                    </tr>
                    <tr style="font-size:17px;">
                        <td align="center" colspan="4">
                            FILLING/APPLICATION DATE
                           </td>
                    </tr>
                    <tr style="font-size:17px;">
                        <td align="center" colspan="4">
                         <% Response.Write(c_mark.reg_date); %>
               </td>
                    </tr>
                    <tr style="font-size:17px;">
                        <td align="center" colspan="4">
                            APPLICANT NAME</td>
                    </tr>
       
      
                    <tr style="font-size:17px;">
                        <td align="center" colspan="4">
                            <% Response.Write(c_app.xname.ToUpper()); %></td>
                    </tr>
       
      
                    <tr style="font-size:17px;">
                        <td class="tbbg" colspan="4" align="center">
                --- TRADEMARK INFORMATION --- 
                        </td>
                    </tr>
                    <tr style="font-size:17px;">
                        <td align="right" colspan="2">
                &nbsp;TRADEMARK TYPE :&nbsp;
                        </td>
                        <td colspan="2" align="left">
                           <% Response.Write(t.getTmTypeName(c_mark.tm_typeID).ToUpper()); %>
                        </td>
                    </tr>
                    <tr style="font-size:17px;">
                        <td align="right" colspan="2">
                &nbsp;TRADEMARK :&nbsp;&nbsp;
                        </td>
                        <td colspan="2" align="left">
                           <% Response.Write(c_mark.product_title.ToUpper()); %>
                        </td>
                    </tr>
                    <tr style="font-size:17px;">
                        <td align="right" colspan="2">
                &nbsp;&nbsp;CLASS OF SPECIFICATION OF GOODS/SERVICES :&nbsp;
                        </td>
                        <td colspan="2" align="left">
                            <% Response.Write(c_mark.nice_class.ToUpper()); %>
                        </td>
                    </tr>
                    <tr style="font-size:17px;">
                        <td align="right" colspan="2">
                &nbsp;DESCRIPTION OF SPECIFICATION OF GOODS/SERVICES :&nbsp;&nbsp;
                        </td>
                        <td colspan="2" align="left">
                <% Response.Write(c_mark.nice_class_desc.ToUpper()); %>
                        </td>
                    </tr>
                    <tr style="font-size:17px;">
                        <td class="tbbg" colspan="4" align="center">
                            --- TRADEMARK REPRESENTATION ---</td>
                    </tr>
                    <tr style="font-size:17px;">
                        <td  colspan="4" align="center">
                            <% if (c_mark.logo_pic != "")
                    {%>
                <asp:Image ID="tm_img" runat="server" />
                <% }
                    else
                    { %> NO DEVICE!!
                <% } %>
                </td>
                    </tr>
                    <tr style="font-size:17px;">
                        <td class="tbbg" colspan="4" align="center">
                --- 
                ADMINISTRATIVE OFFICER ---</td>
                    </tr>
                    <tr style="font-size:17px;">
                        <td align="center" colspan="4">
                         <% Response.Write(xcomments); %>
                        </td>
                    </tr>
                    <tr>
                        <td class="tbbg" colspan="4" align="center">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td  colspan="4" align="center">
                           <table width="100%">
                           <tr style="font-weight:bold;font-size:18px;">
                           <td width="60%" colspan="3">
                           
                               SEARCH RESULTS</td>
                           <td colspan="2">
                           
                               DATE</td>
                           </tr>
                           
                           <tr style="font-weight:bold;font-size:18px;">
                           <td width="10%">
                           
                               SN</td>
                           <td width="30%">
                           
                               TRADEMARKS </td>
                           <td width="20%">
                           
                               TP NUMBER</td>
                           <td width="20%">
                           
                               DATE</td>
                           <td width="20%">
                           
                               APPLICANT NAME</td>
                           </tr>
                           
                           <tr style="font-weight:bold;font-size:18px;">
                           <td width="10%">
                           
                               <br />
                               <br />
                               </td>
                           <td width="30%">
                           
                               &nbsp;</td>
                           <td width="20%">
                           
                               &nbsp;</td>
                           <td width="20%">
                           
                               &nbsp;</td>
                           <td width="20%">
                           
                               &nbsp;</td>
                           </tr>
                           
                           <tr style="font-weight:bold;font-size:18px;">
                           <td width="10%">
                           
                               <br />
                               <br />
                               </td>
                           <td width="30%">
                           
                               &nbsp;</td>
                           <td width="20%">
                           
                               &nbsp;</td>
                           <td width="20%">
                           
                               &nbsp;</td>
                           <td width="20%">
                           
                               &nbsp;</td>
                           </tr>
                           
                           <tr style="font-weight:bold;font-size:18px;">
                           <td width="10%">
                           
                               <br />
                               <br />
                               </td>
                           <td width="30%">
                           
                               &nbsp;</td>
                           <td width="20%">
                           
                               &nbsp;</td>
                           <td width="20%">
                           
                               &nbsp;</td>
                           <td width="20%">
                           
                               &nbsp;</td>
                           </tr>
                           
                           <tr style="font-weight:bold;font-size:18px;">
                           <td width="10%">
                           
                               <br />
                               <br />
                               </td>
                           <td width="30%">
                           
                               &nbsp;</td>
                           <td width="20%">
                           
                               &nbsp;</td>
                           <td width="20%">
                           
                               &nbsp;</td>
                           <td width="20%">
                           
                               &nbsp;</td>
                           </tr>
                           
                           <tr style="font-weight:bold;font-size:18px;">
                           <td width="10%">
                           
                               <br />
                               <br />
                               </td>
                           <td width="30%">
                           
                               &nbsp;</td>
                           <td width="20%">
                           
                               &nbsp;</td>
                           <td width="20%">
                           
                               &nbsp;</td>
                           <td width="20%">
                           
                               &nbsp;</td>
                           </tr>
                           
                           <tr style="font-weight:bold;font-size:18px;">
                           <td width="10%">
                           
                               <br />
                               <br />
                               </td>
                           <td width="30%">
                           
                               &nbsp;</td>
                           <td width="20%">
                           
                               &nbsp;</td>
                           <td width="20%">
                           
                               &nbsp;</td>
                           <td width="20%">
                           
                               &nbsp;</td>
                           </tr>
                           
                           <tr style="font-weight:bold;font-size:18px;">
                           <td width="10%">
                           
                               <br />
                               <br />
                               </td>
                           <td width="30%">
                           
                               &nbsp;</td>
                           <td width="20%">
                           
                               &nbsp;</td>
                           <td width="20%">
                           
                               &nbsp;</td>
                           <td width="20%">
                           
                               &nbsp;</td>
                           </tr>
                           
                           <tr style="font-weight:bold;font-size:18px;">
                           <td width="10%">
                           
                               <br />
                               <br />
                               </td>
                           <td width="30%">
                           
                               &nbsp;</td>
                           <td width="20%">
                           
                               &nbsp;</td>
                           <td width="20%">
                           
                               &nbsp;</td>
                           <td width="20%">
                           
                               &nbsp;</td>
                           </tr>
                           
                           <tr style="font-weight:bold;font-size:18px;">
                           <td width="10%">
                           
                               <br />
                               <br />
                               </td>
                           <td width="30%">
                           
                               &nbsp;</td>
                           <td width="20%">
                           
                               &nbsp;</td>
                           <td width="20%">
                           
                               &nbsp;</td>
                           <td width="20%">
                           
                               &nbsp;</td>
                           </tr>
                           
                           <tr style="font-weight:bold;font-size:18px;">
                           <td width="10%">
                           
                               <br />
                               <br />
                               </td>
                           <td width="30%">
                           
                               &nbsp;</td>
                           <td width="20%">
                           
                               &nbsp;</td>
                           <td width="20%">
                           
                               &nbsp;</td>
                           <td width="20%">
                           
                               &nbsp;</td>
                           </tr>
                           
                           </table>
                            
                            
                            </td>
                    </tr>
                    <tr>
                        <td class="tbbg" colspan="4" align="center">
                            &nbsp;</td>
                    </tr>
                     <tr>
                        <td colspan="4" align="center" style=" font-weight:bold; font-size:18px;">
                             THIS REPORT IS NOT OPEN TO PUBLIC INSPECTION AND MUST NOT BE REMOVED FROM THE FILE</td>
                    </tr>

                    <tr>
                        <td class="tbbg" colspan="4" align="center">
                            &nbsp;</td>
                    </tr>
                </table>
                </td>
                </tr>
                 <tr>
                        <td  align="center" width="100%">
                        <input type="button" name="Printform" id="Printform" value="Print Search Report" onclick="printSearchReport('search_report');return false;" class="button" />
                         </td>
                </tr>
                </table>
                
            </div>
    </div>
</div>
</div>
    </form>
</body>
</html>
