<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="reg_tm_succ.aspx.cs" Inherits="cld.admin.reg_tm_succ" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>CONGRATULATIONS</title>    

    <link href="../css/style.css" rel="stylesheet" type="text/css" />	  
	  
</head>
<body>
    <form id="form1" runat="server">
<div >

    <table align="center" width="100%" class="form">
        <tr>
            <td align="left" class="tbbg">
                ADMINSTRATOR REGISTRATION
            </td>
        </tr>
        
        <tr>
            <td width="30%" align="center">YOU HAVE SUCCESSFULLY COMPLETED THE REGISTRATION<br />AN E-MAIL HAS BEEN SENT TO YOU</td>
        </tr>
        <tr>
            <td align="left" class="tbbg"> 
                <asp:Button ID="btn_menu" runat="server" Text="BACK TO MENU" onclick="btn_menu_Click" />
            </td>
        </tr>
       
    </table>
</div>
    </form>
</body>
</html>
