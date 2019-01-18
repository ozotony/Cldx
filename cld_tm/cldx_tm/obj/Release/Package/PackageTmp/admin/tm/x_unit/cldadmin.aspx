<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cldadmin.aspx.cs" Inherits="cld.admin.tm.x_unit.cldadmin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
<link href="../../../css/style.css" rel="stylesheet" type="text/css" />    
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="container">
            <div class="sidebar">                 
                
            </div>
            <div class="content">
                <div class="header">
                    <div class="xmenu">
                        <div class="menu">
                            <ul>
                                <li><a href="../lo.aspx">
                                    <img alt="" src="../../../images/logoff.png" width="16" height="16" />Log off</a></li>
                            </ul>
                        </div>
                    </div>
                    <div class="xlogo">
                        <div class="xlogo_l">
                        </div>
                    </div>
                </div>
                <div id="searchform">
        
                    <table align="center" width="100%">
        <tr>
            <td colspan="3" align="left" class="tbbg">
                WELCOME TO THE CLD ADMINSTRATION UNIT</td>
        </tr>
       
        
                
        <tr>
            <td align="center" colspan="3">&nbsp;</td>
        </tr>
        
        <tr>
            <td style="width: 30%;" align="center">
                <a href="../../../cp.aspx?x=<%Response.Write(adminID);  %>">
                    <img alt="" src="../../../images/xsync.png" style="width: 100px; height: 100px" /></a></td>
            <td style="width: 30%;" align="center">
                <a href="../admin_registration2.aspx">
                    <img alt="" src="../../../images/view.png" style="width: 100px; height: 100px" /></a></td>
            <td style="width: 30%;" align="center">
                <a href="#"> 
                    <img alt="" src="../../../images/xexec.png" style="width: 100px; height: 100px" /></a></td>
        </tr>
        
        <tr>
            <td style="width: 30%;" align="center">
                <a href="../../../cp.aspx?x=<%Response.Write(adminID); %>">CHANGE PASSWORD</a></td>
            <td style="width: 30%;" align="center">
                <a href="../admin_registration2.aspx">MANAGE ADMINISTRATORS</a></td>
            <td style="width: 30%;" align="center">
                <a href="#">CHECK STATISTICS</a></td>
        </tr>
        
        <tr>
            <td style="width: 30%;" align="center">
                <a href="./edit_apps3.aspx" target="_blank">
                    <img alt="" src="../../../images/view.png" style="width: 100px; height: 100px" /></a></td>
            <td style="width: 30%;" align="center">
                <a href="./edit_status3.aspx"  target="_blank">
                    <img alt="" src="../../../images/view.png" style="width: 100px; height: 100px" /></a></td>
            <td style="width: 30%;" align="center">
                <a href="../../../appstatusc.aspx" target="_blank">
                    <img alt="" src="../../../images/view.png" style="width: 100px; height: 100px" /></a></td>
        </tr>
        <tr>
            <td style="width: 30%;" align="center">
                <a href="./edit_apps3.aspx" target="_blank">EDIT  APPLICATION</a></td>
            <td style="width: 30%;" align="center">
                <a href="./edit_status3.aspx"  target="_blank">EDIT APPLICATION STATUS</a></td>
            <td style="width: 30%;" align="center">
                <a href="../../../appstatusc.aspx" target="_blank"> APPLICATIONS STATUS</a></td>
        </tr>
        
        <tr>
            <td align="center" colspan="3">
                &nbsp;
                &nbsp;
                &nbsp;
            </td>
        </tr>
         <tr>
            <td style="width: 30%;" align="center">
                </td>
            <td style="width: 30%;" align="center">
               </td>
            <td style="width: 30%;" align="center">
                </td>
        </tr>
        <tr>
            <td style="width: 30%;" align="center">
               </td>
            <td style="width: 30%;" align="center">
               </td>
            <td style="width: 30%;" align="center">
               </td>
        </tr>
        
        <tr>
            <td align="center" colspan="3">
                &nbsp;</td>
        </tr>
        
        <tr>
            <td style="width: 30%;" align="center">
                </td>
            <td style="width: 30%;" align="center">
                </td>
            <td style="width: 30%;" align="center">
                </td>
        </tr>
        
        <tr>
            <td align="center">
                &nbsp;
               &nbsp;
                &nbsp;
            </td>
             <td align="center">
                &nbsp;
                <a href="ipo_trans_status.aspx"></a>&nbsp;
                &nbsp;
            </td>
             <td align="center">
                &nbsp;
               
                &nbsp;
                </td>
        </tr>
        
            <tr>
            <td align="center" colspan="3">
                &nbsp;</td>
        </tr>
        
        <tr>
            <td style="width: 30%;" align="center">


                </td>
            <td style="width: 30%;" align="center">
               </td>
            <td style="width: 30%;" align="center">
                &nbsp;</td>
        </tr>
        
        <tr>
            <td align="center">
               &nbsp;
               &nbsp;
                &nbsp;</td>
             <td align="center">
                &nbsp;
               &nbsp;
                &nbsp;
            </td>
             <td align="center">
                &nbsp;
               
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
    </div>
    </form>
</body>
</html>