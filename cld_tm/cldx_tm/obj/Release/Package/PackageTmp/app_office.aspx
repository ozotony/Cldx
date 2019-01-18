<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="app_office.cs" Inherits="cld.app_office" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
   <link href="css/style.css" rel="stylesheet" type="text/css" />

<script src="js/jquery.js" type="text/javascript"></script>

<script src="js/funk.js" type="text/javascript"></script>

<div>
    <div class="container">
        <div class="sidebar">
        </div>
        <div class="content">
            <div class="header">
                <div class="xmenu">
                    <div class="menu">
                        <ul>
                           
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

    <table align="center" width="100%" class="form">
        <tr>
            <td colspan="2" align="left" class="tbbg">
                PLEASE FILL IN THE &quot;TRANSACTION&quot; DETAILS BELOW
            </td>
        </tr>  
        <tr>
            <td>
                &nbsp; 
                PAYMENT TYPE: &nbsp;</td>
            <td>
                <asp:DropDownList ID="xptype" runat="server" CssClass="textbox">
                <asp:ListItem Value="cbt" Text="BRANCH COLLECT"></asp:ListItem>
                <asp:ListItem Value="etz" Text="ETRANZACT"></asp:ListItem>
                </asp:DropDownList>
               </td>
        </tr>
         <tr>
            <td>
                &nbsp; AGENT CODE: &nbsp;</td>
            <td>
            <asp:TextBox ID="xagt" runat="server" Width="300px" CssClass="textbox"></asp:TextBox>
               &nbsp;*</td>
        </tr>
        <tr>
            <td>
                                &nbsp;
                                TRANSACTION No.: &nbsp;</td>
            <td>
            <asp:TextBox ID="xtransaction" runat="server" Width="300px" CssClass="textbox"></asp:TextBox>
                 *</td>
        </tr>
        
        <tr>
            <td>
                &nbsp;
                AMOUNT: 
                </td>
            <td>
            <asp:TextBox ID="xamt" runat="server" Width="300px" CssClass="textbox"></asp:TextBox>
                *</td>
        </tr>
        
        <tr>
            <td colspan="2" align="center">
                <strong><%= progress_msg %></strong>
            </td>
        </tr>
        
        <tr>
            <td class="tbbg" colspan="2">                
                <asp:Button ID="Save" runat="server" Text="Continue"  class="button" 
                    onclick="Save_Click" />
            </td>
        </tr>
    </table>
        </div>
    </div>
</div>

    </form>
</body>
</html>
