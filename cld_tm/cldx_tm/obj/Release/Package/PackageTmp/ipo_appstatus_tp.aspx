<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ipo_appstatus_tp.aspx.cs" Inherits="cld.ipo_appstatus_tp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CLD:CLIENT APPLICATION STATUS</title>
    <link href="css/style.css" rel="stylesheet" type="text/css" />
<script src="js/jquery.js" type="text/javascript"></script>
<script src="js/funk.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
   <div>
    <div class="container">
    <div class="sidebar"></div>
       
        <div class="content">
           
            <table style="text-align:center; width:100%">
             <tr>
            <td style="text-align:center;">
              <img alt="Coat Of Arms" height="79" src="./images/coat_of_arms.png" 
                        width="85" /></td>
        </tr>
         <tr>
            <td style="text-align:center;">
               FEDERAL REPUBLIC OF NIGERIA<br />
                    FEDERAL MINISTRY OF INDUSTRY, TRADE AND INVESTMENT<br />
                    COMMERCIAL LAW DEPARTMENT<br />
                    TRADEMARKS, PATENTS AND DESIGNS REGISTRY<br />
                    </td>
        </tr>

        <tr>
            <td style="background-color:#1C5E55; color:#ffffff; text-align:center; font-weight:bold;">
                &nbsp;PLEASE SELECT AN ITEM TYPE TO CHECK YOUR STATUS</td>
        </tr>
       
        
        <tr>
            <td align="center">
                <asp:DropDownList ID="ddl_itemcode" runat="server" CssClass="textbox" AutoPostBack="true">
                    <asp:ListItem Selected="True" Text="T002" Value="t002"></asp:ListItem>
                    <asp:ListItem Text="Others" Value="t000"></asp:ListItem>
                </asp:DropDownList>
            </td>
                
        </tr>
        
        <tr>
            <td style="background-color:#1C5E55; color:#ffffff; text-align:center; font-weight:bold;"></td>
        </tr>


        <tr>
            <td style="text-align:center;">
               
                <asp:Button ID="btnDashBoard" runat="server" Text="Back to Dashboard" class="button" onclick="btnDashBoard_Click" />
               
            </td>
        </tr>


    </table>
         
        </div>
     </div> 
    
</div>
    </form>
</body>
</html>
