<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="profile.cs" Inherits="cld.admin.tm.Recordal_unit.profile" %>

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
              
            </div>
            <div class="content">
        
    <table align="center" width="100%" >
        <tr>
            <td colspan="3" align="left" class="tbbg">
                WELCOME TO THE RECORDAL UNIT</td>
        </tr>
       
        
                
        <tr>
            <td align="center" colspan="3">&nbsp;</td>
        </tr>
        
        <tr>
            <td style="width: 30%;" align="center">
                <a href="#">
                    <img alt="" src="../../../images/xsync.png" style="width: 100px; height: 100px" /></a></td>
            <td style="width: 30%;" align="center">
                <a href="../Recordal2/Change_Name.html#/form/payment?name=Change_Name">
                    <img alt="" src="../../../images/view.png" style="width: 100px; height: 100px" /></a>
                   </td>
            <td style="width: 30%;" align="center">
                <a href="../Recordal2/Change_Name.html#/form/payment?name=Change_Address"> 
                    <img alt="" src="../../../images/xexec.png" style="width: 100px; height: 100px" /></a></td>
        </tr>
        
        <tr>
            <td style="width: 30%;" align="center">
                <a href="../../../cp.aspx?x=<%Response.Write(adminID); %>">CHANGE PASSWORD</a></td>
            <td style="width: 30%;" align="center">
                <a href="../Recordal2/Change_Name.html#/form/payment?name=Change_Name">UPDATE CHANGE OF APPLICANT NAME</a></td>
            <td style="width: 30%;" align="center">
                <a href="../Recordal2/Change_Name.html#/form/payment?name=Change_Address">UPDATE CHANGE OF APPLICANT ADDRESS</a></td>
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
                <a href="../Recordal2/Change_Name.html#/form/payment?name=Rectification">
                    <img alt="" src="../../../images/view.png" style="width: 100px; height: 100px" /></a>
                    </td>
            <td align="center">
                 <a href="../Recordal2/Change_Name.html#/form/payment?name=Form16">
                    <img alt="" src="../../../images/view.png" style="width: 100px; height: 100px" /></a></td>
            <td align="center">
                <a href="../Recordal2/Change_Name.html#/form/payment?name=Form17">
                    <img alt="" src="../../../images/accepted.png" style="width: 100px; height: 100px" /></a>
                   
                    </td>
        </tr>
        
        <tr>
            <td align="center">
                <a href="../Recordal2/Change_Name.html#/form/payment?name=Rectification"> UPDATE AMENDMENT (CLERICAL ERRORS IN TRADEMARK TITLE)</a></td>
            <td align="center">
                 &nbsp;
                <a href="../Recordal2/Change_Name.html#/form/payment?name=Form16">UPDATE MERGER</a>&nbsp;
                &nbsp;</td>
            <td align="center">
                <a href="../Recordal2/Change_Name.html#/form/payment?name=Form17"> UPDATE ASSIGNMENT</a></td>
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
             <a href="../Recordal2/Change_Name.html#/form/payment?name=Renewal">
                    <img alt="" src="../../../images/accepted.png" style="width: 100px; height: 100px" /></a>
                     
                      </td>
            <td align="center">
                 <a href="../g_Recordal5.aspx">
                    <img alt="" src="../../../images/view.png" style="width: 100px; height: 100px" /></a>
                    </td>
            <td align="center">
                &nbsp;&nbsp;
                 <a href="../Recordal2/Migrate_Generic.html#/form/Search">
                    <img alt="" src="../../../images/accepted.png" style="width: 100px; height: 100px" /></a>
                    
                      </td>
        </tr>
        <tr>
            <td align="center">
                  <a href="../Recordal2/Change_Name.html#/form/payment?name=Renewal">UPDATE  RENEWAL</a>
               </td>
            <td align="center">
                   <a href="../g_Recordal5.aspx">REQUEST FOR CHANGE OF AGENT</a>
               </td>
            <td align="center">
                 <a href="../Recordal2/Migrate_Generic.html#/form/Search">MIGRATE GENERIC RECORD</a>
               </td>
        </tr> 
              
        <tr>
            <td align="center">
             
                      </td>
            <td align="center">
               
                    </td>
            <td align="center">
                &nbsp;
                      </td>
        </tr>
        <tr>
            <td align="center">
                </td>
            <td align="center">
               </td>
            <td align="center">
                &nbsp;</td>
        </tr>
              
        <tr>
            <td class="tbbg" colspan="3">
              
            </td>
        </tr>

         <tr>
            <td align="center">
             <a href="../Recordal2/Register_Manual22.aspx">
                    <img alt="" src="../../../images/accepted.png" style="width: 100px; height: 100px" /></a>
                     
                      </td>
            <td align="center">
                  <a href="../Recordal2/registrar4.aspx">
                    <img alt="" src="../../../images/accepted.png" style="width: 100px; height: 100px" /></a>
                    </td>
            <td align="center">
                &nbsp;&nbsp;
                 <a href="../Recordal2/g_application3.aspx">
                    <img alt="" src="../../../images/accepted.png" style="width: 100px; height: 100px" /></a>
                    
                      </td>
        </tr>

           <tr>
            <td align="center">
                  <a href="../Recordal2/Register_Manual22.aspx">MANUAL APPLICATION</a>
               </td>
            <td align="center">
                  <a href="../Recordal2/registrar4.aspx">MIGRATED APPLICATIONS</a>
               </td>
            <td align="center">
                 <a href="../Recordal2/g_application3.aspx">GENERIC RECORD</a>
               </td>
        </tr> 

        <tr>
            <td class="tbbg" colspan="3">
              
            </td>
        </tr>

            <tr>
            <td align="center">
             <a href="../Recordal2/edit_app2.aspx">
                    <img alt="" src="../../../images/accepted.png" style="width: 100px; height: 100px" /></a>
                     
                      </td>
            <td align="center">
                  <a href="../Recordal2/app_status2.aspx">
                    <img alt="" src="../../../images/accepted.png" style="width: 100px; height: 100px" /></a>
                    </td>
            <td align="center">
                <a href="../Recordal2/g_Recordal2.aspx">
                    <img alt="" src="../../../images/accepted.png" style="width: 100px; height: 100px" /></a>
                 
                    
                      </td>
        </tr>

               <tr>
            <td align="center">
                  <a href="../Recordal2/edit_app2.aspx">EDIT APPLICATION</a>
               </td>
            <td align="center">
                 <a href="../Recordal2/app_status2.aspx">EDIT APPLICATION STATUS</a>
               </td>
            <td align="center">
                <a href="../Recordal2/g_Recordal2.aspx">EDIT RECORDAL</a>
               </td>
        </tr> 
        <tr>
            <td align="center">
              <a href="http://ipo.cldng.com/A/xindex_manual2.aspx">
                    <img alt="" src="../../../images/accepted.png" style="width: 100px; height: 100px" /></a>
                     
                      </td>

            <td align="center">
              <a href="../Recordal2/Change_Name.html#/form/payment?name=Form47">
                    <img alt="" src="../../../images/accepted.png" style="width: 100px; height: 100px" /></a>
                     
                      </td>
           
        </tr>
          <tr>
            <td align="center">
                  <a href="http://ipo.cldng.com/A/xindex_manual2.aspx"> ADD NEW RECORD</a>
               </td>

              <td align="center">
                  <a href="../Recordal2/Change_Name.html#/form/payment?name=Form47"> UPDATE REGISTERED USER</a>
               </td>
        </tr>

    </table>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
