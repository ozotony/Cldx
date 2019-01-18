<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="profile.cs" Inherits="cld.admin.tm.acceptance_unit.profile" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
<link href="../../../css/style.css" rel="stylesheet" type="text/css" />    

     <style type="text/css">
.sidebar {
    padding-top:2px;

}

    </style>

     <style type="text/css">
        a.disabled {
   pointer-events: none;
   cursor: default;
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
                <a href="./profile.aspx">VIEW STATISTICS</a> 
                <a href="../preview_x.aspx?x=1&d=Invalid">INVALID APPS</a> 
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
                <a href="../preview_x.aspx?x=9&d=Registered">REGISTERED APPS</a> 
            </div>
            <div class="content">
        
    <table align="center" width="100%" >
        <tr>
            <td colspan="3" align="left" class="tbbg">
                WELCOME TO THE ACCEPTANCE UNIT</td>
        </tr>
       
        
                
        <tr>
            <td align="center" colspan="3">&nbsp;</td>
        </tr>
        
        <tr>
            <td style="width: 30%;" align="center">
                <a href="../../../cp.aspx?x=<% Response.Write(adminID); %>">
                    <img alt="" src="../../../images/xsync.png" style="width: 100px; height: 100px" /></a></td>
            <td style="width: 30%;" align="center">
                <a href="../acceptance.aspx">
                    <img alt="" src="../../../images/view.png" style="width: 100px; height: 100px" /></a>
                    <br /><%Response.Write("( "+lt_mi_n+" )"); %></td>
            <td style="width: 30%;" align="center">
                <a href="./aed.aspx"> 
                    <img alt="" src="../../../images/xexec.png" style="width: 100px; height: 100px" /></a></td>
        </tr>
        
        <tr>
            <td style="width: 30%;" align="center">
                <a href="../../../cp.aspx?x=<%Response.Write(adminID); %>">CHANGE PASSWORD</a></td>
            <td style="width: 30%;" align="center">
                <a href="../acceptance.aspx">MANAGE NEW APPLICATIONS</a></td>
            <td style="width: 30%;" align="center">
                <a href="./aed.aspx">CHECK STATISTICS</a></td>
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
                <a href="../rejection_slip.aspx">
                    <img alt="" src="../../../images/rejected.png" style="width: 100px; height: 100px" /></a>
                    <br /><%Response.Write("( "+lt_mi_r+" )"); %>
                    </td>
            <td align="center">
                  <a href="./index_cards.aspx">
                    <img alt="" src="../../../images/view.png" style="width: 100px; height: 100px" /></a></td>
            <td align="center">
                <a href="../acceptance_slip.aspx">
               <%-- <a href="#">--%>
                    <img alt="" src="../../../images/accepted.png" style="width: 100px; height: 100px" /></a>
                    <br /><%Response.Write("( "+lt_mi_a+" )"); %>
                    </td>
        </tr>
        
        <tr>
            <td align="center">
                <a href="../rejection_slip.aspx"> MANAGE REFUSALS</a></td>
            <td align="center">
                 &nbsp;
                <a href="index_cards.aspx">INDEX CARDS</a>&nbsp;
                &nbsp;</td>
            <td align="center">
                <a href="../acceptance_slip.aspx"> MANAGE ACCEPTANCES</a>
                 <%--<a href="#"> MANAGE ACCEPTANCES</a>--%>


            </td>
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
                &nbsp;
                    <a href="../acceptance_wd.aspx">
                    <img alt="" src="../../../images/view.png" style="width: 100px; height: 100px" /></a>
                      <br /><%Response.Write("( "+lt_mi_wd+" )"); %>
                      </td>
            <td align="center">
                  <a href="./generic_profile.aspx">
                    <img alt="" src="../../../images/view.png" style="width: 100px; height: 100px" /></a>
                    <br /><%Response.Write("( "+lt_mi_g+" )"); %>
                    </td>
            <td align="center">
                &nbsp;
                    <a href="../acceptance_kiv.aspx">
                    <img alt="" src="../../../images/view.png" style="width: 100px; height: 100px" /></a>
                      <br /><%Response.Write("( "+lt_mi_kiv+" )"); %>
                      </td>
        </tr>
        <tr>
            <td align="center">
                <a href="../acceptance_wd.aspx">WITHDRAWN APPLICATIONS</a></td>
            <td align="center">
                <a href="./generic_profile.aspx">GENERIC APPLICATIONS</a></td>
            <td align="center">
                <a href="../acceptance_kiv.aspx">KIV APPLICATIONS</a></td>
        </tr> 
           <tr>
            <td class="tbbg" colspan="3">
              
            </td>
        </tr>    
        <tr>
            <td align="center">
               <a href="../g_Recordal2.aspx">
                    <img alt="" src="../../../images/view.png" style="width: 100px; height: 100px" /></a>
                    <br /><%Response.Write("( " + lt_mi_a2 + " )"); %>
                      </td>
            <td align="center">
                  <a href="../acceptance_prt.aspx">
                    <img alt="" src="../../../images/view.png" style="width: 100px; height: 100px" /></a>
                    <br /><%Response.Write("( "+lt_mi_prt+" )"); %>
                    </td>
            <td align="center">
              <a  href="../acceptance_prt.aspx">
                    <img alt="" src="../../../images/view.png" style="width: 100px; height: 100px" /></a>
                      </td>
        </tr>
        <tr>
            <td align="center">
                <a href="../g_Recordal2.aspx">RECORDALS</a></td>
            <td align="center">
                <a href="../acceptance_prt.aspx">PRINTED APPLICATIONS</a></td>
            <td align="center">

                <a   href="../acceptance_unit/edit_apps2.aspx">EDIT APPLICATIONS</a></td>
        </tr>
              
        <tr>
            <td class="tbbg" colspan="3">
              
            </td>
        </tr>

         <tr>
            <td align="center">
               <a href="../acceptance_unit/edit_status2.aspx">
                    <img alt="" src="../../../images/view.png" style="width: 100px; height: 100px" /></a>
                   
                      </td>
            <td align="center">
                <a href="../EditAmendMent.aspx">
                    <img alt="" src="../../../images/view.png" style="width: 100px; height: 100px" /></a>
                <br /><%Response.Write("( "+lt_mi_wd2+" )"); %>
                 
                    </td>
            <td align="center">
             <a href="./index_cards3.aspx">
                    <img alt="" src="../../../images/view.png" style="width: 100px; height: 100px" /></a>
                      </td>
        </tr>
        <tr>
            <td align="center">
                <a href="../acceptance_unit/edit_status2.aspx">Edit Application Status</a></td>
            <td align="center">
                <a href="../EditAmendMent.aspx">Edit Amendment Status</a>
               </td>
            <td align="center">
                 &nbsp;
                <a href="index_cards3.aspx">INDEX CARDS 2</a>&nbsp;
                &nbsp;
                </td>
        </tr>


    </table>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
