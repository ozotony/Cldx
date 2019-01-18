<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="appstatusc.aspx.cs" Inherits="cld.appstatusc" %>

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
        
                 <div class="header">                 
                     <div class="xmenu">
                         <div class="menu">
                             <ul>
                                 <li><a href="control.aspx">
                                     <img alt="" src="./images/logon.png" width="16" height="16" />Login</a></li>
                                
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
                 
            <% if(showt==0) {%>
            <table align="center" width="100%">
        <tr>
            <td colspan="2" align="left" class="tbbg">
                &nbsp;PLEASE ENTER YOUR TRANSACTION OR APPLICATION NUMBER TO CHECK YOUR STATUS</td>
        </tr>
       
        
        <tr>
            <td align="right">
                &nbsp;
                REFERENCE /APPLICATION NUMBER: &nbsp;
                  </td>
                
            <td style="width: 50%;">
            <asp:TextBox ID="xref" runat="server" Width="200px" CssClass="textbox"></asp:TextBox>
                </td>
        </tr>
        
        <tr>
            <td class="tbbg" colspan="2">
               
                <asp:Button ID="Save" runat="server" Text="Check Status" OnClick="Save_Click" class="button" />
               
            </td>
        </tr>


    </table>
            <% }%>
            <% if (showt == 1)
               {%>
               <div id="searchform">
               <div class="xsearchform">
                <table align="center" class="form" 
                     id="table1">
                    <tr>
                        <td colspan="2" align="center" width="100%">
                            <strong>FEDERAL MINISTRY OF TRADE AND INVESTMENT<br />
                                COMMERCIAL LAW DEPARTMENT<br />
                                INDUSTRIAL PROPERTY OFFICE REGISTRY </strong>
                        </td>
                    </tr>
                    <tr>
                        <td width="100%" colspan="2" align="center" bgcolor="#006600">
                            <img src="images/coat_of_arms.png" 
                                style="width: 80px; height: 80px" />
                        </td>
                    </tr>
                   
                    <tr>
                        <td width="100%" colspan="2" class="tbbg">
                            <strong>---STATUS INFORMATION---</strong>
                        </td>
                    </tr>
                    <tr>
                        <td width="100%" align="justify" colspan="2">
                         Dear 
                            <% Response.Write(lt_rep.xname); %>, 
                            <br /> We will like to inform you that your application ("/OAI/TM/<% Response.Write(lt_pw[0].validationID); %>") is currently at the <strong>  "<% Response.Write(status); %>" Office</strong> and is currently <strong>"<% Response.Write(data_status); %>"</strong><br />
                            Regards,
                        </td>
                    </tr>
                    <tr>
                        <td class="tbbg" colspan="2">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="left" style="width:50%">
                            <strong>&nbsp;THE TRADEMARK REGISTRY,<br />
                                &nbsp;COMMERCIAL LAW DEPARTMENT NIGERIA,<br />
                                &nbsp;FEDERAL MINISTRY OF TRADE AND INVESTMENT,<br />
                                &nbsp;FEDERAL CAPITAL TERRITORY,<br />
                                &nbsp;ABUJA,NIGERIA </strong>
                        </td>
                        <td align="right">
                            <strong>REGISTRAR OF TRADEMARKS&nbsp;&nbsp; </strong>
                           
                        </td>
                    </tr>
                    <tr>
                        <td class="tbbg" colspan="2">
                            &nbsp;
                        </td>
                    </tr>
                    
                    
                </table>
                
                </div>
               </div>
               <div  style="text-align:center;">
                <input type="button" name="Printform" id="Printform" value="PRINT" onclick="printAssessment(document.getElementById('searchform'));return false" class="button" />

                        <input type="button" name="btnReprint" id="btnReprint" value="REPRINT ACKNOWLEDGEMENT FORM"  onclick="doView('./tm_ark_repc.aspx?0001234445=<% Response.Write(r); %>&94384238=<% Response.Write(lt_rep.agent_code); %>');" class="button" />

                        <asp:Button ID="BtnCheckStatus" runat="server" Text="REFRESH SEARCH"  
                                CssClass="button" Width="154px" onclick="BtnCheckStatus_Click"/>
                                </div>
            <% }%>
        </div>
     </div> 
    
</div>
    </form>
</body>
</html>
