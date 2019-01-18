<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="tm_profile.cs" Inherits="cld.admin.tm.registrar_unit.tm_profile" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" data-ng-app="myModule" >
<head runat="server">

    <title></title>

  

    <script src="../../../js/jquery.js"></script>

        <script type="text/javascript" src="../../../js/angular.min.js"></script>
    <link href="../../../css/loading-bar.css" rel="stylesheet" />
    <script type="text/javascript" src="../../../js/loading-bar.js"></script>
    <script type="text/javascript" src="../../../js/smart-table.min.js"></script>
   <%-- <script type="text/javascript" src="../../js/AngularLogin.js"></script>--%>
     <script type="text/javascript" src="../../../js/AngularLogin12.js"></script>
    <script type="text/javascript" src="../../../js/dirPagination.js"></script>
    <link href="../../../css/font-awesome.min.css" rel="stylesheet" />
    <script type="text/javascript" src="../../../js/bootstrap.min.js"></script>
    <script src="../../../js/ng-modal.min.js"></script>
    <link href="../../../css/ng-modal.css" rel="stylesheet" />
    <link href="../../../css/sweet-alert.css" rel="stylesheet" />
    <script src="../../../js/sweet-alert.min.js"></script>



    <script type="text/javascript">
        $(window).bind('unload', function () {
            if (event.clientY < 0) {
                alert('Thank you for using this app.');
                endSession(); // here you can do what you want ...
            }
        });
        window.onbeforeunload = function () {
            $(window).unbind('unload');
            //If a string is returned, you automatically ask the 
            //user if he wants to logout or not...
            //return ''; //'beforeunload event'; 
            if (event.clientY < 0) {
                alert('Thank you for using this service.');
                endSession();
            }
        }
        </script>
<link href="../../../css/style.css" rel="stylesheet" type="text/css" />    
</head>
<body  ng-controller="myController5" >
    <form id="form1" runat="server">
    <div>
        <div class="container">
            <div class="sidebar"> 
                <a href="./profile_index.aspx">MAIN PROFILE</a>
                <a href="./tm_profile.aspx">PROFILE</a>  
                <a href="../../../cp.aspx?x=<% Response.Write(adminID); %>">CHANGE PASSWORD</a> 
                <a href="./red.aspx">VIEW STATISTICS</a>  
               <%-- <a href="../preview_r.aspx?d=Accepted">ACCEPTED APPS</a> 
                <a href="../preview_r.aspx?d=Refused">REFUSED APPS</a> 
                <a href="../preview_r.aspx?d=Published">PUBLISHED APPS</a>  
                <a href="../preview_r.aspx?d=Opposed">OPPOSED APPS</a> --%>
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
                        <div class="xlogo_r">
                        </div>
                    </div>
                </div>
                <div id="searchform">
        
    <table align="center" width="100%" >
        <tr>
            <td colspan="3" align="left" class="tbbg">
                WELCOME TO THE REGISTRAR UNIT</td>
        </tr>
       
        
                
        <tr>
            <td align="center" colspan="3">&nbsp;</td>
        </tr>
        
        <tr>
            <td style="width: 30%;" align="center">
                <a href="../registrar.aspx">
                    <img alt="" src="../../../images/view.png" style="width: 100px; height: 100px" /></a>
                    <br /><%Response.Write("( "+lt_mi_n+" )");%></td>
            <td style="width: 30%;" align="center">
               <a href="../registrard.aspx">
                    <img alt="" src="../../../images/view.png" style="width: 100px; height: 100px" /></a>
                    <br /><%Response.Write("( "+lt_mi_d+" )");%>
                    </td>
            <td style="width: 30%;" align="center">
                <a href="../registrar_c.aspx"> 
                    <img alt="" src="../../../images/xexec.png" style="width: 100px; height: 100px" /></a>
                    <br /><%Response.Write("( "+lt_mi_i+" )");%></td>
        </tr>
        
        <tr>
            <td style="width: 30%;" align="center">
               <a href="../registrar.aspx">VIEW NEW APPLICATIONS</a></td>
            <td style="width: 30%;" align="center">
                 <a href="../registrard.aspx">VIEW DEFERRED APPLICATIONS</a></td>
            <td style="width: 30%;" align="center">
                 <a href="../registrar_c.aspx">ISSUE CERTIFICATE</a></td>
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
                <a href="../registrar_c2.aspx.aspx">
                    <img alt="" src="../../../images/cert.png" style="width: 100px; height: 100px" /></a>
                      <br /><%Response.Write("");%>
                    </td>
            <td align="center">
                 <a href="../registrar_unit/edit_apps2.aspx" >
                    <img alt="" src="../../../images/cert.png" style="width: 100px; height: 100px" /></a>
                     
             </td>
            <td align="center">
                 <a href="../registrar_unit/admin_registration2.aspx" >
                    <img alt="" src="../../../images/cert.png" style="width: 100px; height: 100px" /></a>
                    </td>
        </tr>
        
        <tr>
            <td align="center">
                <a href="../registrar_c2.aspx">PRINTED CERTIFICATE</a></td>
            <td align="center">
                 <a href="../registrar_unit/edit_apps2.aspx">EDIT APPLICATION</a>
            </td>
            <td align="center">
                 <a href="../registrar_unit/admin_registration2.aspx">CREATE USER</a>
               </td>
        </tr>
        
        <tr>
            <td align="center" colspan="3">
                &nbsp;</td>
        </tr>
         <tr>
            <td align="center" colspan="3" >
                &nbsp; &nbsp; &nbsp;
            </td>
        </tr>
        <tr>
            <td align="center">
                <%--<a href="../register_ass.aspx">
                    <img alt="" src="../../../images/cert.png" style="width: 100px; height: 100px" /></a>
                      <br /><%Response.Write("");%>--%>
                      </td>
            <td align="center">
               <%-- <a href="../registrar_nch.aspx">
                    <img alt="" src="../../../images/cert.png" style="width: 100px; height: 100px" /></a>
                      <br /><%Response.Write("");%>--%>
                      </td>
            <td align="center">
                <%--<a href="../registrar_rwl.aspx">
                    <img alt="" src="../../../images/cert.png" style="width: 100px; height: 100px" /></a>
                      <br /><%Response.Write("");%>--%>
                      </td>
        </tr>
        <tr>
            <td align="center">
                <%--<a href="../register_ass.aspx">MANAGE ASSIGNMENTS</a>--%></td>
            <td align="center">
                <%--<a href="../registrar_nch.aspx">MANAGE NAME CHANGES</a>--%></td>
            <td align="center">
               <%-- <a href="../registrar_rwl.aspx">MANAGE RENEWALS</a>--%>
                &nbsp;&nbsp;</td>
        </tr>
        <tr>
            <td  colspan="3">
              
            </td>
        </tr>

           <tr>
            <td align="center">
               
                      </td>
            <td align="center">
               
                     
                      </td>
            <td align="center">
                
                      </td>
        </tr>
        <tr>
            <td align="center">
               </td>
            <td align="center">
               </td>
            <td align="center">
               
                &nbsp;&nbsp;</td>
        </tr>
          <tr>
            <td align="center" colspan="3" >
                &nbsp;&nbsp; &nbsp;
            </td>
        </tr>
        <tr>
            <td align="center">
                <%--<a href="../../registrar2.aspx">
                    <img alt="" src="../../../images/cert.png" style="width: 100px; height: 100px" /></a>
                      <br /><%Response.Write("( " + lt_mi_d3 + " )");%>--%>
                      </td>
            <td align="center">
                <
                      </td>
            <td align="center">
               
                   
                      </td>
        </tr>
        <tr>
            <td align="center">
               <%-- <a href="../registrar2.aspx">MIGRATED APPLICATIONS</a>--%></td>
            <td align="center">
                </td>
            <td align="center">
               
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
