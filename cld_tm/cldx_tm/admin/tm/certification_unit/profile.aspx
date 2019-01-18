<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="profile.cs" Inherits="cld.admin.tm.certification_unit.profile" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
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
                WELCOME TO THE CERTIFICATION UNIT</td>
        </tr>
       
        
                
        <tr>
            <td align="center" colspan="3">&nbsp;</td>
        </tr>
        
        <tr>
            <td style="width: 30%;" align="center">
                <a href="../../../cp.aspx?x=<%Response.Write(adminID); %>">
                    <img alt="" src="../../../images/xsync.png" style="width: 100px; height: 100px" /></a></td>
            <td style="width: 30%;" align="center">
                <a href="../certification.aspx">
                    <img alt="" src="../../../images/view.png" style="width: 100px; height: 100px" /></a>
                      <br /><%Response.Write("( "+lt_mi_n+" )");%>
                      </td>
            <td style="width: 30%;" align="center">
                <a href="./ced.aspx"> 
                    <img alt="" src="../../../images/xexec.png" style="width: 100px; height: 100px" /></a></td>
        </tr>
        
        <tr>
            <td style="width: 30%;" align="center">
                <a href="../../../cp.aspx?x=<%Response.Write(adminID);  %>">CHANGE PASSWORD</a></td>
            <td style="width: 30%;" align="center">
                <a href="../certification.aspx">MANAGE&nbsp; NEW APPLICATIONS</a></td>
            <td style="width: 30%;" align="center">
                <a href="./ced.aspx">CHECK STATISTICS</a></td>
        </tr>
        <tr>
            <td align="center" colspan="3" class="tbbg">
                &nbsp; &nbsp; &nbsp;
            </td>
        </tr>
        <tr>
            <td align="center">
                <a href="../certificationd.aspx">
                    <img alt="" src="../../../images/view.png" style="width: 100px; height: 100px" /></a>
                      <br /><%Response.Write("( "+lt_mi_d+" )");%>
                      </td>
            <td align="center">
                <a href="./generic_profile.aspx">
                    <img alt="" src="../../../images/view.png" style="width: 100px; height: 100px" /></a>
                     <br /><%Response.Write("( "+lt_mi_g+" )"); %>
                     </td>
            <td align="center">
                <a href="../preview_certs.aspx">
                    <img alt="" src="../../../images/view.png" style="width: 100px; height: 100px" /></a>
                      <br /><%Response.Write("( "+lt_mi_p+" )");%>
                      </td>
        </tr>
        <tr>
            <td align="center">
                <a href="../certificationd.aspx">MANAGE DEFERRED APPLICATIONS</a></td>
            <td align="center">
                <a href="./generic_profile.aspx">GENERIC APPLICATIONS</a></td>
            <td align="center">
                <a href="../preview_certs.aspx">PREVIEW CERTIFICATES</a>
                &nbsp;&nbsp;</td>
        </tr>

        <tr>
            <td align="center" colspan="3" class="tbbg">
                &nbsp; &nbsp; &nbsp;
            </td>
        </tr>
          <tr>
            <td align="center">
                <a href="../Register_Manual2.aspx">
                    <img alt="" src="../../../images/view.png" style="width: 100px; height: 100px" /></a>
                      <br /><%Response.Write("( "+lt_mi_d2+" )");%>
                      </td>
            <td align="center">
                <a href="../g_Recordal4.aspx">
                    <img alt="" src="../../../images/view.png" style="width: 100px; height: 100px" /></a>
                      <br /><%Response.Write("( " + lt_mi_d3 + " )");%>
                     </td>
            <td align="center">

                 <a href="../g_Recordal4b.aspx">
                    <img alt="" src="../../../images/view.png" style="width: 100px; height: 100px" /></a>
                      <br /><%Response.Write("( " + lt_mi_d4 + " )");%>
                
                      </td>
        </tr>
        <tr>
            <td align="center">
                <a href="../Register_Manual2.aspx">MANUAL APPLICATIONS</a></td>
            <td align="center">
                <a href="../g_Recordal4.aspx">FRESH RECORDALS APPLICATIONS</a>
               </td>
            <td align="center">
               
              <a href="../g_Recordal4b.aspx">TREATED RECORDALS</a></td>
        </tr>
        <tr>
            <td align="center" colspan="3" class="tbbg">
                &nbsp; &nbsp; &nbsp;
            </td>
        </tr>
         <tr>
            <td align="center">
                <a href="../certification_unit/g_Recordal3.aspx">
                    <img alt="" src="../../../images/view.png" style="width: 100px; height: 100px" /></a>
                    
                      </td>
             <td align="center">
                <a href="../g_Recordal5.aspx">
                    <img alt="" src="../../../images/view.png" style="width: 100px; height: 100px" /></a>
                    
                      </td>
            <td align="center">
               <a href="../certification_unit/Migrated.aspx">
                    <img alt="" src="../../../images/view.png" style="width: 100px; height: 100px" /></a>
                     </td>
            <td align="center">

               
                
                      </td>
        </tr>
        <tr>
            <td align="center">
                <a href="../certification_unit/g_Recordal3.aspx">Edit Recordal</a></td>
            <td align="center">
                <a href="../g_Recordal5.aspx">Request for change of Agent</a></td>
            <td align="center">
                <a href="../certification_unit/Migrated.aspx">MIGRATED APPLICATIONS</a>
               </td>
            <td align="center">
                
               
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
