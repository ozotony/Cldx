<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="acceptance_slip_index_card.aspx.cs" Inherits="cld.admin.tm.acceptance_slip_index_card" MaintainScrollPositionOnPostback="true" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>INDEX CARD DETAILS</title>
    <link href="../../css/style.css" rel="stylesheet" type="text/css" />

<script src="../../js/funk.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
   <div>
    <div class="container">
        <div class="sidebar">
            <a href="./acceptance_unit/profile.aspx">PROFILE</a> 
            <a href="../../cp.aspx?x=<% Response.Write(admin); %>">CHANGE PASSWORD</a> 
            <a href="./acceptance_unit/aed.aspx">VIEW STATISTICS</a>
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
                
                <table align="center" width="800px" >
                    <tr id="index_cards">
                        <td  align="center" width="100%">
                <table align="center" width="800" class="form" style="font-size:18px;">
                    <tr>
                        <td align="center" width="100%">
                            <strong>FEDERAL MINISTRY OF TRADE AND INVESTMENT<br />COMMERCIAL LAW DEPARTMENT<br />INDUSTRIAL PROPERTY OFFICE REGISTRY 
                            </strong>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <img src="../../images/coat_of_arms.png" style="width: 80px; height: 80px" />
                        </td>
                    </tr>
                    <tr>
                        <td class="tbbg" align="center" style="font-size:20px; font-weight:bolder;">
                            INDEX CARD DETAILS FOR "<% Response.Write(c_mark.product_title.ToUpper()); %>"</td>
                    </tr>
                     <tr>
                           <td align="center" style="font-size:24px; font-weight:bolder;" >  
                              <% =c_mark.product_title.ToUpper() %></td>
                           </tr>
                           
                           <tr >
                           <td align="center" style="font-size:22px; font-weight:bolder;">   
                               CLASS (<%=c_mark.national_classID%>)
                               
                               </td>
                           </tr>
                           
                           <tr >
                           <td  align="center" style="font-size:20px; font-weight:bolder;">  
                               <%=c_app.xname%></td>
                           </tr>
                           
                           <tr >
                           <td align="center" style="font-size:20px; font-weight:bolder;">  
                                <%=c_mark.reg_number%></td>
                           </tr>
                           
                           <tr>
                           <td align="center" style="font-size:18px; font-weight:bolder;">  
                              FILING DATE: <%=c_mark.reg_date%></td>
                           </tr>
                           
                           <tr>
                           <td align="center" style="font-size:18px; font-weight:bolder;">  
                                <span style="color:#ff0000;"> 
                                ACCEPTED  DATE:</span> <%=acceptance_date[0]%>
                                
                                </td>
                           </tr>
                             <tr>
                           <td align="center" style="font-size:18px;" >  
                                <% Response.Write("OAI/TM/" + (c_p.validationID)); %>
                                </td>
                           </tr>
                             <tr>
                           <td align="center" class="ic_logo">  
                              <% if (c_mark.logo_pic != "")
                    {%>
                <asp:Image ID="tm_img" runat="server" />
                <% }
                    else
                    { %> NO DEVICE!!
                <% } %>
                                </td>
                           </tr>
                    <tr>
                        <td class="tbbg" align="center">
                            &nbsp;</td>
                    </tr>

                </table>
                </td>
                </tr>
                 <tr>
                        <td  align="center" width="100%">
                        <input type="button" name="Printform" id="Printform" value="Print Index Card" onclick="printSearchReport('index_cards');return false;" class="button" />
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
