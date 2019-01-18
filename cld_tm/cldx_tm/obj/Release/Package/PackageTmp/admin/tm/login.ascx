<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="login.cs" Inherits="cld.admin.tm.login" %>

<link href="../../css/style.css" rel="stylesheet" type="text/css" />
<script src="../../js/jquery.js" type="text/javascript"></script>
<script src="../../js/funk.js" type="text/javascript"></script>


<div>
    <div class="container">
        <div class="sidebar">           
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
                <div class="xlogo">
                    <div class="xlogo_l">
                    </div>
                    <div class="xlogo_r">
                    </div>
                </div>
            </div>
            <div id="searchform">

    <table align="center" width="100%">
        <tr>
            <td colspan="2" align="left" class="tbbg">
                SESSION EXPIRED!!!----&nbsp;PLEASE LOGIN IN USING YOUE E-MAIL ADDRESS AND PASSWORD</td>
        </tr>
       
        
        <tr>
            <td align="right">
                &nbsp;
                E-MAIL: &nbsp;</td>
                
            <td rowspan="5" style="width: 50%;">
                <img alt="login" src="../../images/login.png" style="width: 128px; height: 128px" /></td>
        </tr>
        <tr>
            <td align="right">
            <asp:TextBox ID="xemail" runat="server" Width="200px" CssClass="textbox"></asp:TextBox>
                <% if (email_text == "1")
                   { %>
                <img src="../../images/arrow-left.gif" alt="" width="16px" height="16px" />
                <%  } if (enable_Save == "0")
                   { %><img src="../../images/checkmark.gif" alt="" width="16px" height="16px" />
                <% }%></td>
        </tr>
        
        <tr class="green_bg_l">
            <td align="right" > Please note that the letters below are not case sensitive!!!
                </td>
        </tr>
        
        <tr>
            <td align="right"> 
                <img alt="captcha" src="../../Handler.ashx" /><br />
                </td>
        </tr>
        
        <tr>
            <td align="right">
                ENTER CODE : 
            <asp:TextBox ID="xcode" runat="server" Width="90px" CssClass="textbox"></asp:TextBox>
            <% if (code_text == "1")
                   { %>
                <img src="../../images/arrow-left.gif" alt="" width="16px" height="16px" />
                <% } if (enable_Save == "0")
                   { %><img src="../../images/checkmark.gif" alt="" width="16px" height="16px" />
                <% }%>     
                </td>
        </tr>
        
        <% if (newState!= "0")
           { %>
        <tr>
            <td colspan="2" align="center">
                <strong>SORRY BUT THE CODE YOU ENTERED IS INVALID.</strong>
            </td>
        </tr>
        <% } %>
        <% if (newp != "0")
           { %>
        <tr>
            <td class="tbbg" colspan="2">
                &nbsp;</td>
        </tr>
        
        
        <tr>
            <td align="right">
                PASSWORD: </td>
            <td>
            <asp:TextBox ID="xpassword" runat="server" Width="200px" CssClass="textbox" TextMode="Password" onunload="xpassword_Unload" ></asp:TextBox>
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
                <asp:Button ID="Save" runat="server" Text="Login" OnClick="Save_Click" class="button" />
                <% }%>
            </td>
        </tr>
    </table>
        </div>
    </div>
</div>
</div>
