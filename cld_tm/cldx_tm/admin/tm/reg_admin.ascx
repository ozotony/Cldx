<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="reg_admin.ascx.cs" Inherits="cld.admin.tm.reg_admin" %>
<link href="../../css/style.css" rel="stylesheet" type="text/css" />

<script src="../../js/jquery.js" type="text/javascript"></script>

<script src="../../js/funk.js" type="text/javascript"></script>


<div>
    <div class="container">
        <div class="sidebar">
            <a href="./x_unit/profile.aspx">PROFILE</a>
             <a href="../../cp.aspx?x=<% Response.Write(admin); %>">CHANGE PASSWORD</a>
              <a href="./x_unit/profile.aspx">VIEW STATISTICS</a> 
              <a href="./preview_x.aspx?x=1&d=Invalid">INVALID APPS</a> 
              <a href="./preview_x.aspx?x=2&d=Valid">VALID APPS</a> 
              <a href="./preview_x.aspx?x=3&d=Approved">APPROVED APPS</a> 
              <a href="./preview_x.aspx?x=1&d=Disapproved">DISAPPROVED APPS</a> 
              <a href="./preview_x.aspx?x=4&d=Registrable">EXAMINED APPS</a> 
              <a href="./preview_x.aspx?x=5&d=Accepted">ACCEPTED APPS</a> 
              <a href="./preview_x.aspx?x=3&d=Refused">UN-ACCEPTED APPS</a> 
              <a href="./preview_x.aspx?x=6&d=Published">PUBLISHED APPS</a> 
              <a href="./preview_x.aspx?x=7&d=Not Opposed">UNOPPOSED APPS</a> 
              <a href="./preview_x.aspx?x=5&d=Opposed">OPPOSED APPS</a> 
              <a href="./preview_x.aspx?x=8&d=Certified">CERTIFIED APPS</a> 
              <a href="./preview_x.aspx?x=9&d=Registered">REGISTERED APPS</a>
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
                
            </div>
            <div id="searchform">
            <table align="center" width="100%" class="form">
        <tr>
            <td colspan="2" align="left" class="tbbg">
                ADMINSTRATOR REGISTRATION
            </td>
        </tr>
        
        <tr>
            <td width="30%">
                &nbsp;&nbsp;NAME:
            </td>
            <td>
                <asp:TextBox ID="xname" runat="server" Width="400px" 
                    CssClass="textbox" ></asp:TextBox>
                     <% if (name_text == "1")
                   { %>
                &nbsp;<img src="../../images/arrow-left.gif" alt="" width="16px" 
                    height="16px" />
                <% } if (enable_Save == "0")
                   { %><img src="../../images/checkmark.gif" alt="" width="16px" 
                    height="16px" />
                <% }%>               
                                   
                </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;&nbsp;ROLE :
            </td>
            <td align="left">
                <asp:DropDownList ID="xrole" runat="server" CssClass="textbox" 
                    DataSourceID="dsRole" DataTextField="name" DataValueField="ID" >
                </asp:DropDownList>
                <asp:SqlDataSource ID="dsRole" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:cldConnectionString %>" 
                    SelectCommand="SELECT * FROM [roles]"></asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;&nbsp;E-MAIL :             </td>
            <td align="left">
                <asp:TextBox ID="xemail" runat="server" Width="400px" CssClass="textbox" ></asp:TextBox>
                <% if (email_text == "1")
                   { %>
                &nbsp;<img src="../../images/arrow-left.gif" alt="" width="16px" height="16px" />
                <% } if (enable_Save == "0")
                   { %><img src="../../images/checkmark.gif" alt="" width="16px" height="16px" />
                <% }%>
            </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;&nbsp;TELEPHONE 1 :
            </td>
            <td align="left">
            <asp:TextBox ID="xtelephone1" runat="server" Width="400px" CssClass="textbox"></asp:TextBox>
                <% if (telephone1_text == "1")
                   { %>
                &nbsp;<img src="../../images/arrow-left.gif" alt="" width="16px" height="16px" />
                <% } if (enable_Save == "0")
                   { %><img src="../../images/checkmark.gif" alt="" width="16px" height="16px" />
                <% }%>
            </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;&nbsp;TELEPHONE 2&nbsp; :
            </td>
            <td align="left">
                <asp:TextBox ID="xtelephone2" runat="server" Width="400px" CssClass="textbox" ></asp:TextBox>
                <% if (telephone2_text == "1")
                   { %>
                &nbsp;<img src="../../images/arrow-left.gif" alt="" width="16px" height="16px" />
                <% } if (enable_Save == "0")
                   { %><img src="../../images/checkmark.gif" alt="" width="16px" height="16px" />
                <% }%>
            </td>
        </tr>
         <% if (enable_Captcha == "1") { %>
        <tr>
            <td class="tbbg" colspan="2">
                Please note that the letters below are not case sensitive!!!
            </td>
        </tr>
        <tr>
            <td align="right">
                <img alt="captcha" src="../../Handler.ashx" />
            </td>
            <td>
                &nbsp;Enter Code :
                <asp:TextBox ID="xcode" runat="server" Width="70px" CssClass="textbox"></asp:TextBox>
                <% if (xcode_text == "1")
                   { %>
                &nbsp;&nbsp;<img src="../../images/arrow-left.gif" alt="" width="16px" height="16px" />
                <% } if (enable_Save == "0")
                   { %>
                <img src="../../images/checkmark.gif" alt="" width="16px" height="16px" />
                <% }%>
            </td>
        </tr>
        
        <% } %>
                
        <tr>
            <td class="tbbg" colspan="2">
                <% if (enable_Confirm == "0")
                   { %>
                <asp:Button ID="ConfirmDetails" runat="server" Text="Confirm Details" OnClick="ConfirmDetails_Click" class="button" />
               
                <% }if (enable_Save == "0")
                   { %>
                <asp:Button ID="Save" runat="server" Text="Save & Continue" OnClick="Save_Click" class="button" />
                <% }%>
            </td>
        </tr>
    </table>
        </div>
    </div>
</div>
</div>
