<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Generic_registrar_data_details2.aspx.cs" Inherits="cld.admin.tm.Generic_registrar_data_details2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../css/style.css" rel="stylesheet" type="text/css" />
<script src="../../js/jquery-2.1.1.min.js"></script>
<script src="../../js/funk.js" type="text/javascript"></script>
<script src="../../js/sweet-alert.min.js"></script>
<link href="../../css/sweet-alert.css" rel="stylesheet" />
    <script type="text/javascript">
    function test(x) {
      //  swal(x)
    }

    </script>

<div>
</head>
<body>
    <form id="form1" runat="server">
     <div class="container">
        <div class="sidebar">
           <a href="./registrar_unit/profile_index.aspx">MAIN PROFILE</a>
             <a href="./registrar_unit/tm_profile.aspx">PROFILE</a>
            <a href="../../cp.aspx?x=<% Response.Write(admin); %>">CHANGE PASSWORD</a> 
            <a href="./registrar_unit/red.aspx">VIEW STATISTICS</a>
           <a href="./preview_r.aspx?d=Accepted">ACCEPTED APPS</a> 
                <a href="./preview_r.aspx?d=Refused">REFUSED APPS</a> 
                <a href="./preview_r.aspx?d=Published">PUBLISHED APPS</a>  
                <a href="./preview_r.aspx?d=Opposed">OPPOSED APPS</a> 
        </div>
        <div class="content">
            <div class="header">
                <div class="xmenu">
                    <div class="menu">
                        <ul>
                            <li><a href="./lo.aspx">
                                <img alt="" src="../../images/logoff.png" width="16" height="16" />Log off</a></li>
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
            <table align="center" width="100%" class="form" >
        <tr>
            <td colspan="2" align="center" width="100%">
                <strong>FEDERAL MINISTRY OF TRADE AND INVESTMENT<br />
                    COMMERCIAL LAW DEPARTMENT<br />
                    INDUSTRIAL PROPERTY OFFICE REGISTRY </strong>
            </td>
        </tr>
        <tr>
            <td width="22%" colspan="2" align="center" bgcolor="#006600">
                <img src="../../images/coat_of_arms.png" style="width: 80px; height: 80px" />
            </td>
        </tr>
      <tr>
            <td width="22%" colspan="2" class="tbbg" align="center">
                <strong>DATA DETAILS FOR "<% Response.Write(g_tm_info.tm_title.ToUpper()); %>"</strong></td>
        </tr>
         <tr>
            <td width="50%" align="right">
                &nbsp;FILLING/APPLICATION DATE :&nbsp;&nbsp;
            </td>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Label"><% Response.Write(g_app_info.filing_date); %></asp:Label>&nbsp;
            </td>
        </tr>
        <tr>
            <td align="right">
                REGISTRATION NUMBER :&nbsp;&nbsp;
            </td>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Label"><% Response.Write(g_app_info.application_no.ToUpper()); %></asp:Label>
            </td>
        </tr>
         <tr>
            <td align="right">
                SYSTEM APPLICATION NUMBER:</td>
            <td>
                 <% Response.Write("OAI/TM/" + g_pwallet.validationID); %></td>
        </tr>
        <tr>
            <td align="right">
                NAME :
            </td>
            <td><asp:Label ID="Label7" runat="server" Text="Label"><% Response.Write(g_applicant_info.xname.ToUpper()); %></asp:Label></td>
        </tr>
       
        <tr>
            <td align="right">
                NATIONALITY :
            </td>
            <td><asp:Label ID="Label19" runat="server" Text="Label"><% Response.Write(g_applicant_info.nationality.ToUpper()); %></asp:Label></td>
        </tr>
        <tr>
            <td align="right">
                COUNTRY OF RESIDENCE :</td>
            <td><asp:Label ID="Label20" runat="server" Text="Label"><% Response.Write(g_applicant_info.nationality.ToUpper()); %></asp:Label></td>
        </tr>
     <%--   <% if (c_app_addy.countryID == "160")
           { %>
        <tr>
            <td align="right">
                STATE:
            </td>
            <td><asp:Label ID="Label21" runat="server" Text="Label"><% Response.Write(t.getStateName(c_app_addy.stateID).ToUpper()); %></asp:Label></td>
        </tr>
        <%} %>--%>
       <%-- <tr>
            <td align="right">
                CITY :</td>
            <td><asp:Label ID="Label22" runat="server" Text="Label"><% Response.Write(c_app_addy.city.ToUpper()); %></asp:Label></td>
        </tr>--%>
        <tr>
            <td align="right">
                STREET No.:
            </td>
            <td><asp:Label ID="Label23" runat="server" Text="Label"><% Response.Write(g_applicant_info.address.ToUpper()); %></asp:Label></td>
        </tr>
       
        <tr>
            <td align="right">
                TELEPHONE:</td>
            <td><asp:Label ID="Label25" runat="server" Text="Label"><% Response.Write(g_applicant_info.xmobile.ToUpper()); %></asp:Label></td>
        </tr>
        <tr>
            <td align="right">
                E-MAIL:</td>
            <td><asp:Label ID="Label26" runat="server" Text="Label"><% Response.Write(g_applicant_info.xemail.ToUpper()); %></asp:Label></td>
        </tr>
        <tr>
            <td class="tbbg" colspan="2" align="center">
                --- TRADEMARK INFORMATION --- </td>
        </tr>
       <tr>
            <td align="right">
                &nbsp;TRADEMARK TYPE :&nbsp;
            </td>
            <td>
                <asp:Label ID="Label6" runat="server" Text="Label"><% Response.Write(g_tm_info.xtype.ToUpper()); %></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">
                LOGO DESCRIPTION :&nbsp;
            </td>
            <td>
                <%--<asp:Label ID="Label27" runat="server" Text="Label"><% Response.Write(t.getLogoDescriptionName(g_tm_info.logo_descID).ToUpper()); %></asp:Label>--%>
                 <asp:Label ID="Label4" runat="server" Text="Label"><% Response.Write(g_tm_info.logo_descID); %></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">
                &nbsp;TRADEMARK :&nbsp;&nbsp;
            </td>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Label"><% Response.Write(g_tm_info.tm_title.ToUpper()); %></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">
                &nbsp;&nbsp;CLASS OF SPECIFICATION OF GOODS/SERVICES :&nbsp;
            </td>
            <td>
                <asp:Label ID="Label28" runat="server" Text="Label"><% Response.Write(g_tm_info.tm_class.ToUpper()); %></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">
                &nbsp;DESCRIPTION OF SPECIFICATION OF GOODS/SERVICES :&nbsp;&nbsp;
            </td>
            <td>
                <% Response.Write(g_tm_info.tm_desc.ToUpper()); %></td>
        </tr>
       <%-- <tr>
            <td align="right">
                &nbsp;GENERAL GOODS IN THE CLASS :&nbsp;&nbsp; 
            </td>
            <td>
                <asp:Label ID="Label4" runat="server" Text="Label"><% Response.Write(c_mark.national_classID); %></asp:Label>
            </td>
        </tr>--%>
       <%-- <tr>
            <td align="right">
               &nbsp; DESCRIPTION&nbsp; OF GENERAL GOODS :&nbsp;
            </td>
            <td>
                <asp:Label ID="Label5" runat="server" Text="Label"><% Response.Write(t.getNationalClassDesc(c_mark.national_classID).ToUpper()); %></asp:Label>
            </td>
        </tr>--%>
       
        <tr>
            <td class="tbbg" colspan="2" align="center">
                --- ATTORNEY INFORMATION ---  </td>
        </tr>
         <tr>
                    <td align="right">
                        ATTORNEY NAME :
                    </td>
                    <td>
                        <% Response.Write(g_agent_info.xname.ToUpper()); %>
                    </td>
                </tr>
                 <tr>
                    <td align="right">
                        ATTORNEY CODE :
                    </td>
                    <td>
                       
                        <% Response.Write(g_agent_info.code.ToUpper()); %>
                    </td>
                </tr>
               
                <tr>
                    <td align="right">
                        COUNTRY OF RESIDENCE :
                    </td>
                    <td> <% 
                             Response.Write(g_agent_info.nationality.ToUpper()); 
                            
                            
                           //  string addID = t.getAddressByID(c_rep.addressID)[0].countryID;
          //   Response.Write(t.getCountryName(c_rep_addy.countryID.ToUpper())); %></td>
                      
                    </td>
                </tr>
              <%--  <tr>
                    <td align="right">
                        STATE:
                    </td>
                    <td> <% Response.Write(t.getStateName(c_rep_addy.stateID.ToUpper())); %></td>
                </tr>--%>
              <%--  <tr>
                    <td align="right">
                        CITY :
                    </td>
                    <td> <%
                             ;
                             Response.Write(c_rep_addy.city.ToUpper()); %></td>
                </tr>--%>
                <tr>
                    <td align="right">
                        STREET :
                    </td>
                    <td> <% Response.Write(g_agent_info.address.ToUpper()); %></td>
                </tr>
              
                <tr>
                    <td align="right">
                        TELEPHONE:</td>
                    <td> <% Response.Write(g_agent_info.telephone.ToUpper()); %></td>
                </tr>
                <tr>
                    <td align="right">
                        &nbsp;E-MAIL:</td>
                    <td> <% Response.Write(g_agent_info.email.ToUpper()); %></td>
                </tr>
        <tr>
            <td class="tbbg" colspan="2" align="center">
                --- PAYMENT INFORMATION ---</td>
        </tr>       
                <tr>
                    <td align="right">
                        TRANSACTION ID :
                    </td>
                    <td>
                        <% Response.Write(g_pwallet.validationID); %>
                    </td>
                </tr>
               <%-- <tr>
                    <td align="right">
                        TRANSACTION AMOUNT :
                    </td>
                    <td>
                        <% Response.Write(c_p.amt); %>
                    </td>
                </tr>--%>
       
      <%--  <tr>
            <td class="tbbg" colspan="2" align="center">
                --- ADDRESS OF SERVICE INFORMATION ---</td>
        </tr>
         <tr>
            <td align="right">
                STREET : </td>
            <td>
                <asp:Label ID="Label10" runat="server" Text="Label"><% Response.Write(c_aos.street.ToUpper()); %></asp:Label></td>
        </tr>
        <tr>
            <td align="right">
                CITY : </td>
            <td>
                <asp:Label ID="Label11" runat="server" Text="Label"><% Response.Write(c_aos.city.ToUpper()); %></asp:Label></td>
        </tr>
        <tr> <td align="right">STATE: </td>
            <td> 
                <asp:Label ID="Label12" runat="server" Text="Label"><% Response.Write(t.getStateName(c_aos.stateID).ToUpper()); %></asp:Label></td>
        </tr>
       
        <tr>
            <td align="right">
                TELEPHONE: </td>
            <td>
                <asp:Label ID="Label13" runat="server" Text="Label"><% Response.Write(c_aos.telephone1.ToUpper()); %></asp:Label></td>
        </tr>
        <tr>
            <td align="right">
                E-MAIL: </td>
            <td>
                <asp:Label ID="Label14" runat="server" Text="Label"><% Response.Write(c_aos.email1.ToUpper()); %></asp:Label></td>
        </tr>--%>
        <tr>
            <td class="tbbg" colspan="2" align="center">
                --- SUPPORTING DOCUMENTS ---</td>
        </tr>
      
        
         <tr>
            <td align="center" colspan="4">   
                <% if (g_tm_info.logo_pic != "")
               {
                   Response.Write("<a href=" + "../tm/gf/" + g_tm_info.logo_pic + " target='_blank'>View</a>");        
         }  else { Response.Write("NONE"); 
                        
               } %>
                <asp:Image ID="tm_img" Visible="false" runat="server" />
                 <%--<% if ((g_tm_info.logo_pic != "") && (g_tm_info.logo_pic != "0") && (g_tm_info.logo_pic !=null))
                   Response.Write( "<a href=" +g_tm_info.logo_pic+" target='_blank'>View</a>");
                    {%>
                  
                <asp:Image ID="tm_img" runat="server" />
                <% }
                    else
                    { %> NO DEVICE!!
                <% } %>--%>
                </td>
        </tr>
        <tr>
            <td align="center" colspan="4">   
                <% if (g_tm_info.app_letter_doc != "")
               {
                   Response.Write("<a href=" + "../tm/gf/" + g_tm_info.app_letter_doc + " target='_blank'>View</a>");        
         }  else { Response.Write("NONE"); 
                        
               } %>
                <asp:Image ID="Image1" Visible="false" runat="server" />
                 <%--<% if ((g_tm_info.logo_pic != "") && (g_tm_info.logo_pic != "0") && (g_tm_info.logo_pic !=null))
                   Response.Write( "<a href=" +g_tm_info.logo_pic+" target='_blank'>View</a>");
                    {%>
                  
                <asp:Image ID="tm_img" runat="server" />
                <% }
                    else
                    { %> NO DEVICE!!
                <% } %>--%>
                </td>
        </tr>
     
        <tr>
            <td align="right" colspan="2">
                </td>
        </tr>
        <tr>
            <td class="tbbg" colspan="2" align="center">
                &nbsp;
                -- PREVIOUS ADMINISTRATOR'S COMMENT --</td>
        </tr>
        <% Response.Write(xcomments); %>      
        
        <tr>
            <td class="tbbg" colspan="2">
                --- ACTION ---
            </td>
        </tr>
        <tr>
            <td align="center"  colspan="2"> <asp:RadioButtonList ID="rbValid" runat="server" RepeatDirection="Horizontal" onselectedindexchanged="rbValid_SelectedIndexChanged" AutoPostBack="true">
                  <%--  <asp:ListItem Value="Migrated" >Verify</asp:ListItem>--%>
                   
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td class="tbbg" colspan="2">  --- ADD COMMENT --- </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                <asp:TextBox ID="comment" runat="server" Height="50px" TextMode="MultiLine" Width="98%"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="tbbg" colspan="2">
                &nbsp;
                --- ATTACH DOCUMENTS ---</td>
        </tr>
               
        
        <tr>
            <td align="center" colspan="2">
                <input type="button" name="Printform" id="Printform" value="Print" onclick="printTm(document.getElementById('searchform')); return false" class="button" />
                <asp:Button ID="Verify" runat="server" Text="Update" OnClick="Verify_Click" class="button" />
            </td>
        </tr>
    </table>
        </div>
    </div>
</div>
    </form>
</body>
</html>
