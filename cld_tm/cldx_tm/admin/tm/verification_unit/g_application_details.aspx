<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="g_application_details.aspx.cs" Inherits="cld.admin.tm.verification_unit.g_application_details" MaintainScrollPositionOnPostback="true" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../../css/style.css" rel="stylesheet" type="text/css" />
<script src="../../../js/funk.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
   <div>
    <div class="container">
        <div class="sidebar">
            <a href="../verification_unit/profile.aspx">PROFILE</a>
             <a href="../../cp.aspx?x=<% Response.Write(admin); %>">CHANGE PASSWORD</a> 
             <a href="../verification_unit/ved.aspx">VIEW STATISTICS</a>
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
                   REQUEST FORM DETAILS
                </td>
            </tr>
           
             <tr>
                <td colspan="4" 
                     style="background-color:#1C5E55; color:#ffffff; text-align:center; font-weight:bold;">
                    --- REQUEST INFORMATION ---</td>
            </tr>
            <tr>
                <td width="50%" align="right" colspan="2">
                    &nbsp;REQUEST FORM TYPE:</td>
                <td width="50%" align="left" colspan="2">        
                    <b><asp:Label ID="lbl_type" runat="server" Text=""></asp:Label></b>
                </td>
            </tr>
             <tr>
                <td colspan="2" align="right" >
                    &nbsp;REQUEST DATE:</td>
                <td colspan="2" align="left" >        
                   <%=g_app_info.reg_date%>
                </td>
            </tr>
             <tr>
                <td width="50%" align="right" colspan="2">
                    REQUEST NUMBER: </td>
                <td width="50%" align="left" colspan="2">        
                    <b> <%=g_tm_info.reg_number%></b></td>
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
                <td colspan="4" align="center" style="background-color:#999999; color:#000000; text-align:center; font-weight:bold;">
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
                <td colspan="4" align="center" style="background-color:#999999; color:#000000; text-align:center; font-weight:bold;">
                    &nbsp;TITLE OF TRADEMARK:</td>
            </tr>           
            
            <tr>
                <td colspan="4" align="center" >
                   <%= g_tm_info.tm_title%></td>
            </tr>   
             <tr>
                <td  style="width: 25%;text-align:right;">
                    &nbsp;RTM NUMBER(If any):</td>
                <td  style="width: 25%;text-align:left;">
                    <%=g_app_info.rtm_number%></td>
                <td style="width: 25%;text-align:right;">FILE/TP NUMBER:</td>
                <td style="width: 25%;text-align:left;"> <%=g_app_info.application_no%></td>
            </tr> 
             <tr>
                <td colspan="2" align="right" >
                    &nbsp;FILING DATE:</td>
                <td colspan="2" align="left" >        
                   <%=g_app_info.filing_date%>
                </td>
            </tr>           
            <tr>
                <td colspan="4" align="center" style="background-color:#999999; color:#000000; text-align:center; font-weight:bold;">
                    &nbsp;DESCRIPTION OF GOODS AND SERVICES:</td>
            </tr>           
                      
            <tr>
                <td colspan="4" align="center">
                    <%= g_tm_info.tm_desc%></td>
            </tr>           
                      
            <tr>
                <td colspan="4" align="center" style="background-color:#999999; color:#000000; text-align:center; font-weight:bold;">
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
            <td  colspan="4" align="center" style="background-color:#999999; color:#000000; text-align:center; font-weight:bold;">             
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
                <td colspan="4" align="center" style="background-color:#999999; color:#000000; text-align:center; font-weight:bold;">
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
                <td colspan="4" align="center" style="background-color:#999999; color:#000000; text-align:center; font-weight:bold;">
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
                 { %>
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
                  <%= g_renewal_info.renewal_type%>              
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
            <% if (xcomments != "")
               { %>
             <tr>
            <td  colspan="4" align="center">
                &nbsp;</td>
        </tr>
        <% Response.Write(xcomments); %>  
        <% } %>                          
              <tr>
            <td class="tbbg" colspan="4">
                &nbsp;
                --- ACTION ---</td>
        </tr>
        <tr>
            <td align="center" colspan="4">
               
                <asp:RadioButtonList ID="rbValid" runat="server" RepeatDirection="Horizontal" 
                    onselectedindexchanged="rbValid_SelectedIndexChanged" AutoPostBack="True">
                    <asp:ListItem Value="Invalid">Invalid</asp:ListItem>
                    <asp:ListItem Value="Valid">Valid</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
          <tr>
            <td class="tbbg" colspan="4" align="center">  --- DESTINATION UNIT --- </td>
        </tr>
        <tr>
            <td align="center" colspan="4">
                <asp:DropDownList ID="selectDestinationUnit" runat="server" CssClass="textbox">
                <asp:ListItem Value="2" Text="Search" Selected="True"></asp:ListItem>
                <asp:ListItem Value="3" Text="Opposition"></asp:ListItem>
                <asp:ListItem Value="4" Text="Certificate"></asp:ListItem>
                <asp:ListItem Value="5" Text="Acceptance"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr> 
        <tr>
            <td class="tbbg" colspan="4" align="center">  --- ADD COMMENT --- </td>
        </tr>
        <tr>
            <td align="center" colspan="4">
                <asp:TextBox ID="comment" runat="server" Height="50px" TextMode="MultiLine" Width="98%"></asp:TextBox>
            </td>
        </tr> 
        <tr>
            <td class="tbbg" colspan="4">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="center" colspan="4">
                <input type="button" name="Printform" id="Printform" value="Print" onclick="printTm(document.getElementById('searchform'));return false" class="button" />&nbsp;
                <asp:Button ID="Verify" runat="server" Text="Update" OnClick="Verify_Click" class="button" />
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
