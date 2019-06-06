﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="g_treated_details.aspx.cs" Inherits="cld.admin.tm.generic.g_treated_details" MaintainScrollPositionOnPostback="true" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml"  data-ng-app="formApp">
<head runat="server">
    <title></title>
    <link href="../../../css/style.css" rel="stylesheet" type="text/css" />
<script src="../../../js/funk.js" type="text/javascript"></script>

        <script src="../../../js/jquery-2.1.1.min.js"></script>
    <script src="../../../js/angular.js"></script>
    <script src="../../../Scripts/ng-wig.min.js"></script>
    <link href="../../../css/ng-wig.css" rel="stylesheet" />
    <script src="../../../js/sweet-alert.min.js"></script>
    <link href="../../../css/sweet-alert.css" rel="stylesheet" />


    <script src="../../../Scripts/App8.js"></script>

<style type="text/css" >

.xform td {
    border: 0 solid #000;
    padding: 1px 2px;
}
</style>

    <script type="text/javascript">
        $(document).ready(function () {

            //$('#Button1').click(function () {
            //    var aa = $.trim($("[id*=h1]").val());
            //    alert("you clicked " + aa);
            //});

        });

    </script>
</head>
<body  ng-controller="formController2">
    <form id="form1" runat="server">
   <div>
    <div class="container">
        <div class="sidebar">
           <a href="./g_applications.aspx">NEW</a>
            <a href="./g_contact.aspx">CONTACT</a>
            <a href="./g_kiv.aspx">KIV</a>
            <a href="./g_treated.aspx">TREATED</a>
            <a href="../lo.aspx">LOG OFF</a>
        </div>
        <div class="content">
           

            <div id="searchform">                        
        <table style="width:100%;font-family:Calibri;" id="applicantForm" align="center" class="form">
            <tr align="center">
                <td colspan="4">
                    <img alt="Coat Of Arms" height="79" src="../../../images/coat_of_arms.png" 
                        width="85" />
               </td>
            </tr>
            <tr align="center" style=" font-size:11pt;" >
                <td colspan="4">
                    FEDERAL REPUBLIC OF NIGERIA<br />
                    FEDERAL MINISTRY OF INDUSTRY, TRADE AND INVESTMENT<br />
                    COMMERCIAL LAW DEPARTMENT<br />
                    TRADEMARKS, PATENTS AND DESIGNS REGISTRY
</td>
            </tr>
            
            <tr>
                <td colspan="4" style="font-size:18pt;line-height:115%;" align="center">
                        GENERIC FORM DETAILS<br />
                </td>
            </tr>
           
             <tr>
                <td colspan="4" 
                     style="background-color:#1C5E55; color:#ffffff; text-align:center; font-weight:bold;">
                    --- APPLICATION INFORMATION ---</td>
            </tr>
            <tr>
                <td width="50%" align="right" colspan="2">
                    &nbsp;REQUEST FORM TYPE:</td>
                <td width="50%" align="left" colspan="2">        
                    <b><asp:Label ID="lbl_type" runat="server" Text=""></asp:Label></b>
                </td>
            </tr>
            
             <tr>
                <td  style="width: 25%;text-align:right;">
                    &nbsp;TM APPLICATION FILING DATE:</td>
                <td  style="width: 25%;text-align:left;">
                    <%=g_app_info.filing_date%></td>
                <td style="width: 25%;text-align:right;">DATE OF SUBMISSION:</td>
                <td style="width: 25%;text-align:left;"> <%=g_app_info.reg_date%></td>
            </tr>  

             <tr>
                <td width="50%" align="right" colspan="2">
                    REQUEST NUMBER: </td>
                <td width="50%" align="left" colspan="2">        
                    <b> <%=g_tm_info.reg_number%></b></td>
            </tr>
            <tr>
                <td  style="width: 25%;text-align:right;">
                    &nbsp;RTM NUMBER(If any):</td>
                <td  style="width: 25%;text-align:left;">
                    <%=g_app_info.rtm_number%></td>
                <td style="width: 25%;text-align:right;">APPLICATION NUMBER:</td>
                <td style="width: 25%;text-align:left;"> <%=g_app_info.application_no%></td>
            </tr>            
           
           
             <tr>
                <td colspan="4" 
                     style="background-color:#1C5E55; color:#ffffff; text-align:center; font-weight:bold;">
                    --- APPLICANT INFORMATION ---</td>
            </tr>
            <tr>
                <td colspan="2" align="right">
                    &nbsp;APPLICANT NAME:&nbsp;</td>
                <td colspan="2" align="left">
                  <%= g_applicant_info.xname%>
                </td>
            </tr>
            
            <tr>
                <td colspan="4" align="center">
                   APPLICANT ADDRESS:</td>
            </tr>
            
            <tr>
                <td colspan="4" align="center">
                    <%= g_applicant_info.address%></td>
            </tr>
            
            <tr>
                <td align="right">
                    APPLICANT E-MAIL:&nbsp;</td>
                <td align="left">
                   <%= g_applicant_info.xemail%></td>
                <td align="right">
                  APPLICANT PHONE NUMBER:&nbsp; 
                </td>
                <td align="left">
                     <%= g_applicant_info.xmobile%></td>
            </tr>
            
          
             <tr>
                <td align="right">
                    TRADING AS:&nbsp;</td>
                <td align="left">
                   <%= g_applicant_info.trading_as%></td>
                <td align="right">
                  NATIONALITY: &nbsp;  
                </td>
                <td align="left">
                 <%= g_applicant_info.nationality%>
                   </td>
            </tr>             
            
            <tr>
                <td colspan="4" 
                    style="background-color:#1C5E55; color:#ffffff; text-align:center; font-weight:bold;">
                    --- TRADEMARK INFORMATON ---</td>
            </tr>
            
            <tr>
                <td colspan="4" align="center" >
                    &nbsp;TITLE OF TRADEMARK:</td>
            </tr>           
            
            <tr>
                <td colspan="4" align="center" >
                   <%= g_tm_info.tm_title%></td>
            </tr>           
            <tr>
                <td colspan="4" align="center">
                    &nbsp;DESCRIPTION OF GOODS AND SERVICES:</td>
            </tr>           
                      
            <tr>
                <td colspan="4" align="center">
                    <%= g_tm_info.tm_desc%></td>
            </tr>           
                      
            <tr>
                <td colspan="4" align="center">
                    &nbsp;DISCLAIMER(If any):</td>
            </tr>
                      
            <tr>
                <td colspan="4" align="center">
                   <%= g_tm_info.disclaimer%></td>
            </tr>
             <tr>
                <td colspan="4" 
                     style="background-color:#1C5E55; color:#ffffff; text-align:center; font-weight:bold;">
                   --- ATTORNEY INFORMATION ---</td>
            </tr>
            <tr>
            <td align="right">
                CODE:&nbsp;</td>
            <td align="left">
                 <%=g_agent_info.code%></td>
            <td align="right">
              NAME:&nbsp;              
                </td>
            <td align="left">
            <%=g_agent_info.xname%>
               </td>
            </tr>            
            
            <tr>
            <td colspan="4" 
                    style="background-color:#999999; color:#000000; text-align:center; font-weight:bold;">
                --- ADDRESS INFORMATION ---</td>
            </tr>
            <tr>
            <td align="right">
                &nbsp;COUNTRY :
            </td>
            <td align="left">
                 <%=g_agent_info.country%></td>
            <td align="right">
            STATE:&nbsp;
           </td>
            <td align="left">
             <%=g_agent_info.state%>
               </td>
            </tr>
            <tr>   
            <td  colspan="4" align="center">             
                 ADDRESS:  
               </td>
            </tr>

            <tr>   
            <td  colspan="4" align="center">             
                  <%=g_agent_info.address%>         
            </td>
           
            </tr>
            
            <tr>
            <td align="right">
              TELEPHONE:&nbsp;</td>
            <td align="left">
                <%=g_agent_info.telephone%></td>
            <td align="right">
             E-MAIL:&nbsp;
                </td>
            <td align="left">
             <%=g_agent_info.email%>
                </td>
            </tr>
            
            <% if (cert_show > 0)
               { %>
              <tr>
                <td colspan="4" 
                      style="background-color:#1C5E55; color:#ffffff; text-align:center; font-weight:bold;">
                    --- CERTIFICATE INFORMATION ---</td>
            </tr>
            <tr>
                <td colspan="2" align="right">
                    &nbsp;DATE OF PUBLICATION:</td>
                <td colspan="2" align="left">
                 <%= g_cert_info.pub_date%>
                </td>
            </tr>
            <tr>
                <td colspan="4" align="center">
                    &nbsp;DETAILS OF PUBLICATION:</td>
               
            </tr>
            <tr>               
                <td colspan="4" align="center">
                <%= g_cert_info.pub_details%>           
                </td>
            </tr>
             <% } %>
              
              <% if (ass_show > 0)
                 { %>
            <tr>
                <td colspan="4" 
                    style="background-color:#1C5E55; color:#ffffff; text-align:center; font-weight:bold;">
                    --- ASSIGNMENT INFORMATION ---</td>
            </tr>
            <tr>
                <td colspan="4" 
                    style="background-color:#999999; color:#000000; text-align:center; font-weight:bold;">
                    ASSIGNEE</td>
            </tr>
            <tr>
                <td colspan="2" align="right">
                    &nbsp;NAME:</td>
                <td colspan="2" align="left">
                    <%= g_ass_info.assignee_name%>
                </td>
            </tr>
            <tr>
                <td colspan="4" align="center">
                    ADDRESS:</td>               
            </tr>
            <tr>               
                <td colspan="4" align="center">
                <%= g_ass_info.assignee_address%>            
                </td>
            </tr>
             <tr>
            <td align="right" colspan="2">
                &nbsp;NATIONALITY :
            </td>
            <td align="left" colspan="2" >
                 <%= g_ass_info.assignee_nationality%>
                     </td>
            </tr>
            <tr>
                <td colspan="4" 
                    style="background-color:#999999; color:#000000; text-align:center; font-weight:bold;">
                    ASSIGNOR</td>
            </tr>
            <tr>
                <td colspan="2" align="right">
                    &nbsp;NAME:</td>
                <td colspan="2" align="left">
                    <%= g_ass_info.assignor_name%>
                </td>
            </tr>
            <tr>
                <td colspan="4" align="center">
                    ADDRESS:</td>               
            </tr>
            <tr>               
                <td colspan="4" align="center">
                <%= g_ass_info.assignor_address%>            
                </td>
            </tr>
             <tr>
            <td align="right" colspan="2">
                &nbsp;NATIONALITY :
            </td>
            <td align="left" colspan="2" >
                 <%= g_ass_info.assignor_nationality%>
                     </td>
            </tr>
            <tr>
                <td colspan="4" style="background-color:#999999;" align="left">&nbsp;</td>
            </tr>
             <tr>
                <td width="50%" colspan="2" align="right">
                    &nbsp;ASSIGNMENT DATE:</td>
                <td colspan="2" align="left">        
                    <%= g_ass_info.date_of_assignment%>
                </td>
            </tr>
             <% } %>
               <% if (merger_show > 0) 
                 { %>
            <tr>
                <td colspan="4" 
                    style="background-color:#1C5E55; color:#ffffff; text-align:center; font-weight:bold;">
                    --- MERGER INFORMATION ---</td>
            </tr>
            <tr>
                <td colspan="4" 
                    style="background-color:#999999; color:#000000; text-align:center; font-weight:bold;">
                    ORIGINAL APPLICANT INFORMATION</td>
            </tr>
            <tr>
                <td colspan="2" align="right">
                    &nbsp;NAME:</td>
                <td colspan="2"  align="left">
                     <%= g_merger_info.original_name%>
                </td>
            </tr>
            <tr>
                <td colspan="2"  align="right">
                    &nbsp;ADDRESS:</td>
                <td colspan="2"  align="left">
                <%= g_merger_info.original_address%>              
                </td>
            </tr>
           
            <tr>
                <td colspan="4" 
                    style="background-color:#999999; color:#000000; text-align:center; font-weight:bold;">
                    MERGING APPLICANT INFORMATION</td>
            </tr>
            <tr>
                <td colspan="2"  align="right">
                    &nbsp;NAME:</td>
                <td colspan="2"  align="left">
                    <%= g_merger_info.merging_name%>
                </td>
            </tr>            
            <tr>
                <td colspan="2"  align="right">
                    &nbsp;ADDRESS:</td>
                <td colspan="2"  align="left">
                <%= g_merger_info.merging_address%>           
                </td>
            </tr>
             <tr>
                <td colspan="4" style="background-color:#999999;" align="left">&nbsp;</td>
            </tr>
             <tr>
                <td colspan="2"  align="right">
                    &nbsp;MERGED COMPANY NAME:</td>
                <td colspan="2"  align="left">
                    <%= g_merger_info.merged_coy_name%>
                </td>
            </tr>    
             <tr>
                <td colspan="2"  align="right">
                    &nbsp;MERGER DATE:</td>
                <td colspan="2"  align="left">
                     <%= g_merger_info.merger_date%>
                </td>
            </tr>    
             <% } %>
              <% if (change_show > 0)
                 { %>
            <tr>
                <td colspan="4" 
                    style="background-color:#1C5E55; color:#ffffff; text-align:center; font-weight:bold;">
                    --- CHANGE INFORMATION ---</td>
            </tr>
            <tr>
                <td colspan="4" 
                    style="background-color:#999999; color:#000000; text-align:center; font-weight:bold;">
                    OLD APPLICANT DETAILS</td>
            </tr>
            <tr>
                <td colspan="2"  align="right">
                    &nbsp;APPLICANT NAME:</td>
                <td colspan="2"  align="left">
                     <%= g_change_info.old_name%>
                </td>
            </tr>
            <tr>
                <td colspan="2"  align="right">
                    &nbsp;APPLICANT ADDRESS:</td>
                <td colspan="2"  align="left">
                <%= g_change_info.old_address%>             
                </td>
            </tr>
          
            <tr>
                <td colspan="4" 
                    style="background-color:#999999; color:#000000; text-align:center; font-weight:bold;">
                    NEW APPLICANT DETAILS</td>
            </tr>
            <tr>
                <td colspan="2"  align="right">
                    &nbsp;APPLICANT NAME:</td>
                <td colspan="2"  align="left">
                    <%= g_change_info.new_name%> 
                </td>
            </tr>
            <tr>
                <td colspan="2"  align="right">
                    &nbsp;APPLICANT ADDRESS:</td>
                <td colspan="2"  align="left">
                <%= g_change_info.new_address%>              
                </td>
            </tr>
            
             <% } %>
              <% if (prelim_show > 0)
                 { %>
              <tr>
                <td colspan="4" 
                      style="background-color:#1C5E55; color:#ffffff; text-align:center; font-weight:bold;">
                    --- PRELIMINARY SEARCH INFORMATION ---</td>
            </tr>
           
            <tr>
                <td colspan="2"  align="right">
                    &nbsp;TITLE:</td>
                <td colspan="2"  align="left">
                    <%= g_prelim_search_info.xtitle%> 
                </td>
            </tr>
             <tr>
                <td colspan="2"  align="right">
                    &nbsp;CLASS OF GOODS/SERVICES:</td>
                <td colspan="2"  align="left">
                   <%= g_prelim_search_info.xclass%> 
                </td>
            </tr>
            <tr>
                <td colspan="2"  align="right">
                    &nbsp;DESCRIPTION OF GOODS/SERVICES:</td>
                <td colspan="2"  align="left">
                 <%= g_prelim_search_info.xclass_desc%>               
                </td>
            </tr>
            <% } %>
             <% if (renewal_show > 0)
                {
                    h1.Value = g_renewal_info.xid; %>
              <tr>
                <td colspan="4" 
                      style="background-color:#1C5E55; color:#ffffff; text-align:center; font-weight:bold;">
                    --- RENEWAL INFORMATION ---</td>
            </tr>
           
            <tr>
                <td align="right">
                    DATE OF LAST RENEWAL:</td>
                <td align="left">
                   <%= g_renewal_info.prev_renewal_date%> </td>
                <td align="right">
                  NEXT RENEWAL DATE: 
                </td>
                <td align="left">
                    <%= g_renewal_info.reg_date%></td>
            </tr>             
            
            <tr>
                <td colspan="2"  align="right">
                    &nbsp;NUMBER OF RENEWALS:</td>
                <td colspan="2"  align="left">
                    <asp:Panel ID="tt" runat="server"> 

                  <%= g_renewal_info.renewal_type%>  

                          <asp:Button ID="Button2" runat="server" OnClick="Vchange_Click" Text="Change" />
                        </asp:Panel>    
                    
                     <asp:Panel ID="tt2" Visible="false"  runat="server"> 
                         <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>

                         <input type="hidden" id="h1" runat="server"  /> 
                         <asp:Button ID="Button1" runat="server"  OnClick="Vupdate_Click" Text="Update" />
                
                        </asp:Panel>             
                </td>
            </tr>
             
            <% } %>

             <% if (others_show > 0)
                 { %>
            <tr>
                <td colspan="4" 
                    style="background-color:#1C5E55; color:#ffffff; text-align:center; font-weight:bold;">
                    --- <%=g_app_info.item_code %> (<%=lbl_type.Text.ToUpper() %>) INFORMATION ---</td>
            </tr>
            <tr>
                <td colspan="2" align="right">
                   DETAILS OF REQUEST:</td>
                <td colspan="2" align="left">
                 <%= g_other_items_info.req_details%>               
                </td>
            </tr>
             <% } %>

            
           
            <tr>
                <td colspan="4" style="background-color:#999999;" align="left">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="4" align="center">            
                     <strong>Your application has been received and is receiving due attention</strong><br />
             <strong>REGISTRAR 
                (COMMERCIAL LAW DEPARTMENT NIGERIA)</strong> <br /></td>
            </tr> 
             <tr>
            <td class="tbbg" colspan="4" align="center">
                &nbsp;</td>
        </tr>
             <tr>
            <td  colspan="4" align="center">
                
                
                 </td>
        </tr>
             <tr>
            <td class="tbbg" colspan="4" align="center">
                &nbsp;
                -- PREVIOUS ADMINISTRATOR'S COMMENT --</td>
        </tr>
        <% Response.Write(xcomments); %>   
            

                    <tr>
            <td align="center" colspan="4">
               
                <asp:RadioButtonList ID="rbValid" runat="server" RepeatDirection="Vertical"  Width="200px"   AutoPostBack="True">
                   
                     <asp:ListItem Value="Ping">Send Applicant Email</asp:ListItem>
                </asp:RadioButtonList>

                 <table class="table tt2" id="rich"> 
                 <tr>
                  <td> <input id="emailaddress" size="100px" ng-model="EmailSubject" name="emailaddress" placeholder="Enter Email Subject" type="text" />  </td>

              </tr>
              <tr>
                  <td> <textarea ng-wig="model.content"    ></textarea>  </td>

              </tr>

        <tr>
                  <td>
                      
                      
                      <input id="Button1" type="button" ng-click="add3(model.content)" value="Send Email" />  </td>

              </tr>


              </table>
            </td>
        </tr>
        
             
             
             <%if (user_doc_show >0) {  %>
             <tr>
            <td class="tbbg" colspan="4" align="center">
                &nbsp;
                --- USER DOCUMENT ---</td>
        </tr>
        <tr>
            <td align="center" colspan="4" id="user_doc_section" >
               
                  <% Response.Write(user_doc); %>
            </td>
        </tr>
             <tr>
            <td align="center" colspan="4" >
               
                 <input type="button" name="Printform" id="PrintUserDocform" value="Print User Document" onclick="printGenTm('user_doc_section'); return false" class="button" />
            </td>
        </tr>
            <%} %>   
      
      
        <tr>
            <td  style="background-color:#1C5E55; color:#ffffff; text-align:center; font-weight:bold;" colspan="4">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="center" colspan="4">
                  <asp:Button ID="ViewUserDoc" runat="server" class="button" OnClick="ViewUserDoc_Click" Text="View User Document" />
                <input type="button" name="Printform" id="Printform" value="Print" onclick="printTm('searchform'); return false" class="button" />&nbsp;
                <asp:Button ID="BtnProfile" runat="server" Text="Back to Profile"  class="button" OnClick="BtnProfile_Click"  />
                </td>
        </tr>   
            </table>        
           </div>
    </div>
</div>
</div>
        <input id="xname5" name="xname5" type="hidden" runat="server" />
    </form>
</body>
</html>
