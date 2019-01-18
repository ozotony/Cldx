<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="profile.aspx.cs" Inherits="cld.admin.tm.Appeal_Rejection.profile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
<link href="../../../css/style.css" rel="stylesheet" type="text/css" />    
    <style type="text/css">
        .sidebar {
            padding-top:2px;

        }

    </style>
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
                 <a href="./profile.aspx">PROFILE</a> 
                <a href="../../../cp.aspx?x=<% Response.Write(adminID); %>">CHANGE PASSWORD</a> 
              
                <%--<a href="../preview_x.aspx?x=1&d=Invalid">INVALID APPS</a> 
                <a href="../preview_x.aspx?x=2&d=Valid">VALID APPS</a> 
                <a href="../preview_x.aspx?x=3&d=Approved">APPROVED APPS</a> 
                <a href="../preview_x.aspx?x=1&d=Disapproved">DISAPPROVED APPS</a> 
                <a href="../preview_x.aspx?x=4&d=Registrable">EXAMINED APPS</a> 
                <a href="../preview_x.aspx?x=5&d=Accepted">ACCEPTED APPS</a> 
                <a href="../preview_x.aspx?x=3&d=Rejected">REFUSED APPS</a> 
                <a href="../preview_x.aspx?x=6&d=Published">PUBLISHED APPS</a> 
                <a href="../preview_x.aspx?x=7&d=Not Opposed">UNOPPOSED APPS</a> 
                <a href="../preview_x.aspx?x=5&d=Opposed">OPPOSED APPS</a> 
                <a href="../preview_x.aspx?x=8&d=Certified">CERTIFIED APPS</a> 
                <a href="../preview_x.aspx?x=9&d=Registered">REGISTERED APPS</a> --%>
               
            </div>
            <div class="content">
        
    <table align="center" width="100%" >
        <tr>
            <td colspan="3" align="left" class="tbbg">
                WELCOME TO  APPEAL REJECTION  UNIT</td>
        </tr>
       
        
                
        <tr>
            <td align="center" colspan="3">&nbsp;</td>
        </tr>
        
        <tr>
            <td style="width: 30%;" align="center">
                <a href="../AppealRejection.aspx">
                    <img alt="" src="../../../images/view.png" style="width: 100px; height: 100px" /></a>
                    <br /><%Response.Write("( "+lt_mi+" )");%></td>
            <td style="width: 30%;" align="center">
                <a href="../AppealRejection3.aspx">
                    <img alt="" src="../../../images/view.png" style="width: 100px; height: 100px" /></a>
                      <br /><%Response.Write("( "+lt_gs2+" )");%></td>
            <td style="width: 30%;" align="center">
               </td>
        </tr>
        
        <tr>
            <td style="width: 30%;" align="center">
                <a href="../AppealRejection.aspx">VIEW PENDING APPLICATIONS</a></td>
            <td style="width: 30%;" align="center">
                  <a href="../AppealRejection3.aspx">TREATED  APPLICATIONS</a></td>
            <td style="width: 30%;" align="center">
               <a href="./g_applications.aspx"></a></td>
        </tr>
        
        <tr>
            <td align="center" colspan="3">
                &nbsp;
                &nbsp;
                &nbsp;
            </td>
        </tr>
         <tr>
            <td align="center" colspan="3" class="tbbg">
                &nbsp; &nbsp; &nbsp;
            </td>
        </tr>
       
       

           
       
    </table>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
