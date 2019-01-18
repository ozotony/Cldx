<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="app_status2.aspx.cs" Inherits="cld.admin.tm.Recordal2.app_status2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ADMIN TRANSACTION STATUS CHECK</title>
<link href="../../../css/style.css" rel="stylesheet" type="text/css" />
<script src="../../../js/jquery.js" type="text/javascript"></script>
<script src="../../../js/funk.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="container">
     <div class="sidebar no-print">
                 <a href="./profile.aspx">PROFILE</a> 
             
              
            </div>
        <div class="content">
        
                 <div class="header">                 
                     <div class="xmenu">
                         <div class="menu">
                             <ul>
                                 <li><a href="../../../control.aspx">
                                     <img alt="" src="../../../images/logon.png" width="16" height="16" />Login</a></li>
                                
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
        <% if (trans_status != "")
           { %>
        <tr>
            <td  colspan="2" align="center">&nbsp;<strong><% Response.Write(trans_status.ToUpper()); %></strong></td>
        </tr>

         <% } %>
        <tr>
            <td class="tbbg" colspan="2">               
                <asp:Button ID="Save" runat="server" Text="Check Status" OnClick="Save_Click" class="button" />               
                <asp:Button ID="btnRefresh0" runat="server" class="button" 
                    onclick="btnRefresh0_Click" Text="Refresh" />
            </td>
        </tr>


    </table>
            <% }%>
            <% if (showt == 1)
               {%>
               <div id="searchform">
                <table align="center" width="100%" class="form" 
                     id="table1">
                    <tr>
                        <td align="center" width="100%">
                            <strong>FEDERAL MINISTRY OF TRADE AND INVESTMENT<br />
                                COMMERCIAL LAW DEPARTMENT<br />
                                INDUSTRIAL PROPERTY OFFICE REGISTRY </strong>
                        </td>
                    </tr>
                    <tr>
                        <td width="100%" align="center" bgcolor="#006600">
                            <img src="../../../images/coat_of_arms.png" style="width: 80px; height: 80px" />
                        </td>
                    </tr>
                   
                    <tr>
                        <td width="100%" class="tbbg">
                            <strong>---STATUS INFORMATION: <% Response.Write(multiple_succ_status.ToUpper()); %>---</strong>
                        </td>
                    </tr>
                    <tr>
                        <td >
                            &nbsp; Transaction Record : <strong><%Response.Write(pwallet_status); %></strong> &nbsp;
                            Number of records: <strong><%Response.Write(lt_pw.Count.ToString()); %></strong>
                      <% if (pwallet_status == "")
                         { %>  <asp:Button ID="btnPwallet" runat="server" Text="ADD"  CssClass="button"  /><% } %> 
                        </td>
                    </tr>
                    <tr>
                        <td class="tbbg">
                            &nbsp;
                        </td>
                    </tr>
                    <% if (lt_pw.Count > 0)
                       { %>
                    <tr>
                        <td>
                            &nbsp;
                            Applicant Record : <strong><%Response.Write(appx_status); %></strong>&nbsp;
                            Number of records: <strong><%Response.Write(lt_app.Count.ToString()); %></strong>
                     <% if (appx_status != "None")
                        { %>    <asp:Button ID="btnApp" runat="server" Text="EDIT" CssClass="button" 
                                 onclick="btnApp_Click" />
                                 <% } %> 
                                  <% if ((lt_app.Count==0)&&(lt_pw.Count==1))
                        { %>
                            <asp:Button ID="btnAddApp" runat="server" Text="ADD NEW" CssClass="button" 
                                onclick="btnAddApp_Click"  /> 
                                <% } %> 
                        </td>
                    </tr>
                    <tr>
                        <td class="tbbg">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                            Trademark Record : <strong><%Response.Write(mark_status); %></strong>&nbsp;
                            Number of records: <strong><%Response.Write(lt_mi.Count.ToString()); %></strong>
                     <% if (mark_status != "None")
                        { %>    <asp:Button ID="btnMark" runat="server" Text="EDIT" CssClass="button" 
                                 onclick="btnMark_Click" />
                                 <% } %> 
                                   <% if ((lt_mi.Count==0)&&(lt_pw.Count==1))
                        { %>
                            <asp:Button ID="btnAddMark" runat="server" Text="ADD NEW" CssClass="button" 
                                onclick="btnAddMark_Click"  /> 
                            <% } %> 
                        </td>
                    </tr>
                    <tr>
                        <td class="tbbg">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp; Address Of Service Record : <strong><%Response.Write(aos_status); %></strong>&nbsp;
                         Number of records: <strong><%Response.Write(lt_aos.Count.ToString()); %></strong>
                        <% if (aos_status != "None")
                           { %>  <asp:Button ID="btnAos" runat="server" Text="EDIT" CssClass="button" 
                                 onclick="btnAos_Click" />
                         <% } %> 
                           <% if ((lt_aos.Count==0)&&(lt_pw.Count==1))
                        { %>
                            <asp:Button ID="btnAddAos" runat="server" Text="ADD NEW" CssClass="button" 
                                onclick="btnAddAos_Click" /> 
                                 <% } %> 
                        </td>
                    </tr>
                    <tr>
                        <td class="tbbg">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                            Representative Record : <strong><%Response.Write(rep_status); %></strong>&nbsp;
                           Number of records: <strong><%Response.Write(lt_rep.Count.ToString()); %></strong>
                        <% if (rep_status != "None")
                           { %>  <asp:Button ID="btnRep" runat="server" Text="EDIT" CssClass="button" 
                                 onclick="btnRep_Click" />
                         <% } %>
                          <% if ((lt_rep.Count==0)&&(lt_pw.Count==1))
                        { %> 
                            <asp:Button ID="btnAddRep" runat="server" Text="ADD NEW" CssClass="button" 
                                onclick="btnAddRep_Click" /> 
                             <% } %>
                        </td>
                    </tr>
                    <tr>
                        <td class="tbbg">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td> &nbsp;
                            Applicant Address Record : <strong><%Response.Write(appaddy_status); %></strong>&nbsp;
                            Number of records: <strong><%Response.Write(lt_appaddy.Count.ToString()); %></strong>
                         <% if (appaddy_status != "None")
                            { %> <asp:Button ID="btnAppAddy" runat="server" Text="EDIT" CssClass="button" 
                                 onclick="btnAppAddy_Click"/>
                         <% } %> 
                         
                        </td>
                    </tr>
                    <tr>
                        <td class="tbbg">
                            &nbsp;
                        </td>
                    </tr>
                     <tr>
                        <td>
                             &nbsp; Representative Address Record : <strong><%Response.Write(repaddy_status); %></strong>&nbsp;
                             Number of records: <strong><%Response.Write(lt_repaddy.Count.ToString()); %></strong>
                         <% if (repaddy_status != "None")
                            { %> <asp:Button ID="btnRepAddy" runat="server" Text="EDIT" CssClass="button" 
                                  onclick="btnRepAddy_Click" />
                         <% } %> 
                          
                        </td>
                    </tr>
                     <% } %>
                    <tr>
                        <td class="tbbg">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            &nbsp;
                            <% if (multiple_status != "")
                               { %>
                        <asp:Button ID="btnDeleteMultiple" runat="server" Text="Delete Multiple" 
                                class="button" onclick="btnDeleteMultiple_Click" />  
                        <% } %>             
                        <asp:Button ID="btnRefresh" runat="server" Text="Refresh Search" class="button" 
                                onclick="btnRefresh_Click" />               
                        </td>
                    </tr>
                    <tr>
                        <td align="center" class="tbbg">
                           
                            &nbsp;</td>
                    </tr>
                </table>
               </div>
            <% }%>
        </div>
     </div>
    </form>
</body>
</html>
