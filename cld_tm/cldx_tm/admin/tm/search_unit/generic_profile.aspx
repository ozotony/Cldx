<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="generic_profile.aspx.cs" Inherits="cld.admin.tm.search_unit.generic_profile" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
<link href="../../../css/style.css" rel="stylesheet" type="text/css" />    
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="header">
            <div class="leftholder">
            </div>
            <div class="xmenu">
                <div class="xmenu_m">
                    <div class="xmenu_ml">
                    </div>
                    <div class="xmenu_mm">
                        <div class="menu">
                            <ul>                                
                                <li><a href="../lo.aspx">
                                    <img alt="" src="../../../images/logoff.png" width="16" height="16" />Log off</a></li>
                            </ul>
                        </div>
                    </div>
                    <div class="xmenu_mr">
                    </div>
                </div>
            </div>
            <div class="xlogoleftholder">
            </div>
            <div class="xlogo">
                <div class="xlogo_l">
                </div>
                <div class="xlogo_r">
                </div>
            </div>
        </div>
        <div class="container">
            <div class="sidebar">
            </div>
            <div class="content">
        
    <table align="center" width="100%" >
        <tr>
            <td colspan="3" align="left" class="tbbg">
                WELCOME TO THE GENERIC APPLICATIONS UNIT</td>
        </tr>
       
        
                
        <tr>
            <td align="center" colspan="3">&nbsp;</td>
        </tr>
        
        <tr>
            <td style="width: 30%;" align="center">
                &nbsp;</td>
            <td style="width: 30%;" align="center">
                <a href="../generic/g_applications.aspx">
                    <img alt="" src="../../../images/view.png" style="width: 100px; height: 100px" /></a>
                    <br /><%Response.Write("( "+lt_mi_n+" )"); %></td>
            <td style="width: 30%;" align="center">
                &nbsp;</td>
        </tr>
        
        <tr>
            <td style="width: 30%;" align="center">
                &nbsp;</td>
            <td style="width: 30%;" align="center">
                <a href="../generic/g_applications.aspx">MANAGE NEW APPLICATIONS</a></td>
            <td style="width: 30%;" align="center">
                &nbsp;</td>
        </tr>
        
        <tr>
            <td align="center" colspan="3" class="tbbg">
                &nbsp;
                &nbsp;
                &nbsp;
            </td>
        </tr>
        
        <tr>
            <td align="center">
                <a href="../generic/g_treated.aspx">
                    <img alt="" src="../../../images/rejected.png" style="width: 100px; height: 100px" /></a>
                    <br /><%Response.Write("( "+lt_mi_t+" )"); %>
                    </td>
            <td align="center">
                  <a href="../generic/g_kiv.aspx">
                    <img alt="" src="../../../images/view.png" style="width: 100px; height: 100px" /></a>
                     <br /><%Response.Write("( "+lt_mi_k+" )"); %>
                     </td>
            <td align="center">
                <a href="../generic/g_contact.aspx">
                    <img alt="" src="../../../images/accepted.png" style="width: 100px; height: 100px" /></a>
                    <br /><%Response.Write("( "+lt_mi_c+" )"); %>
                    </td>
        </tr>
        
        <tr>
            <td align="center">
                <a href="../generic/g_treated.aspx">MANAGE TREATED APPLICATIONS</a></td>
            <td align="center">
                 &nbsp;
                <a href="../generic/g_kiv.aspx">MANAGE KIV APPLICATIONS</a>&nbsp;
                &nbsp;</td>
            <td align="center">
                <a href="../generic/g_contact.aspx">MANAGE CONTACT APPLICATIONS</a></td>
        </tr>
        
        <tr>
            <td align="center" colspan="3">
                &nbsp;</td>
        </tr>
        
        <tr>
            <td align="center" colspan="3">
                &nbsp;</td>
        </tr>
        
        <tr>
            <td class="tbbg" colspan="3">
              
            </td>
        </tr>
    </table>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
