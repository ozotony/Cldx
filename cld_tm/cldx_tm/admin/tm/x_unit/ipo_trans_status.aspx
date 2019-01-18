<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ipo_trans_status.aspx.cs" Inherits="cld.admin.tm.x_unit.ipo_trans_status" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ADMIN TRANSACTION STATUS CHECK</title>
<link href="../../../css/style.css" rel="stylesheet" type="text/css" />
<script src="../../../js/jquery.js" type="text/javascript"></script>
<script src="../../../js/funk.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="container">
    <div class="sidebar">
     <a href="./profile.aspx">PROFILE</a> 
                <a href="../../cp.aspx?x=<% Response.Write(admin); %>">CHANGE PASSWORD</a> 
                <a href="./profile.aspx">VIEW STATISTICS</a>
                </div>
       
        <div class="content">
        
                 <div class="header">                 
                     <div class="xmenu">
                         <div class="menu">
                             <ul>
                                 <li><a href="../../../control.aspx">
                                     <img alt="" src="../../../images/logon.png" width="16" height="16" />Login</a></li>
                                
                             </ul>
                         </div>
                     </div>
                     <div class="xlogo">
                         <div class="xlogo_l">
                         </div>
                         <div class="xlogo_r">
                         </div>
                     </div>                    
                 </div> 
                 
            <% if(showt==0) {%>
            <table align="center" width="100%">
        <tr>
            <td colspan="2" align="left" class="tbbg">
                &nbsp;PLEASE ENTER 
                THE DETAILS BELOW TO UPDATE THE STATUS</td>
        </tr>
       
        
        <tr>
            <td align="right">
                &nbsp;
                TRANSACTION ID: &nbsp;
                  </td>
                
            <td style="width: 50%;">
            <asp:TextBox ID="trans_id" runat="server" Width="200px" CssClass="textbox"></asp:TextBox>
                </td>
        </tr>
      
        <tr>
            <td align="right">AGENT CODE:&nbsp;&nbsp;&nbsp; </td>
            <td align="left">
            <asp:TextBox ID="agt_code" runat="server" Width="200px" CssClass="textbox"></asp:TextBox>
                </td>
        </tr>
        <tr>
            <td class="tbbg" colspan="2">               
                <asp:Button ID="Save" runat="server" Text="Update Status" OnClick="Save_Click" class="button" />               
            </td>
        </tr>


    </table>
            <% }%>
            <% if (showt == 1)
               {%>
               <div id="searchform">
                <table align="center" width="100%" class="form" 
                     id="table1">
                    <tr>
                        <td align="center" width="100%">
                            <strong>FEDERAL MINISTRY OF TRADE AND INVESTMENT<br />
                                COMMERCIAL LAW DEPARTMENT<br />
                                INDUSTRIAL PROPERTY OFFICE REGISTRY </strong>
                        </td>
                    </tr>
                    <tr>
                        <td width="100%" align="center" bgcolor="#006600">
                            <img src="../../../images/coat_of_arms.png" style="width: 80px; height: 80px" />
                        </td>
                    </tr>
                   
                    <tr align="center">
                        <td align="center">
                            &nbsp;
                      
                            <%=trans_status %></td>
                    </tr>
                    
                    <tr>
                        <td class="tbbg">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            &nbsp;
                                 
                        <asp:Button ID="btnRefresh" runat="server" Text="Refresh Search" class="button" 
                                onclick="btnRefresh_Click" />               
                        </td>
                    </tr>
                    <tr>
                        <td align="center" class="tbbg">
                           
                            &nbsp;</td>
                    </tr>
                </table>
               </div>
                <% }%>
        </div>
     </div>
    </form>
</body>
</html>
