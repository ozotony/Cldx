﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Generic_registrar_data_details5.aspx.cs" Inherits="cld.admin.tm.Generic_registrar_data_details5" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" data-ng-app="formApp">
<head runat="server">
    <title></title>
    <link href="../../css/style.css" rel="stylesheet" type="text/css" />

    <script src="../../js/jquery-2.1.1.min.js"></script>
<script src="../../js/funk.js" type="text/javascript"></script>
<script src="../../js/sweet-alert.min.js"></script>
<link href="../../css/sweet-alert.css" rel="stylesheet" />

    <script src="../../Scripts/angular.js"></script>
    <script src="../../js/angular-sanitize.min.js"></script>
    <script src="../../Scripts/ng-wig.min.js"></script>

    <link href="../../css/ng-wig.css" rel="stylesheet" />
   
    <script src="../../Scripts/App3.js"></script>
    <script src="../../js/ng-modal.min.js"></script>
    <link href="../../css/ng-modal.css" rel="stylesheet" />
   

   
    <script type="text/javascript">
    function test(x) {
      //  swal(x)
    }

    </script>

<style type="text/css">
        
               @media print
{     
     
    .no-print, .no-print *
    {
        display: none !important;
       
    }
}

               .form table a {
  color: black;

}
    </style>
</head>
<body  ng-controller="formController">
     <form id="form2" >
      <modal-dialog show='dialogShown'  dialog-title='SEARCH PAYMENT'>
        <%--  <textarea ng-wig="content"></textarea>--%>
          <table class="table"> 
              <tr>
                  <td> <textarea ng-wig="model.content"    ></textarea>  </td>

              </tr>

        <tr>
                  <td>
                      
                      
                      <input id="Button1" type="button" ng-click="add3(model.content)" value="button" />  </td>

              </tr>


              </table>


          </modal-dialog>

         </form>
    <form id="form1" runat="server">
     <div class="container">
       <div class="sidebar no-print">
            <a href="./verification_unit/profile.aspx">PROFILE</a> <a href="../../cp.aspx?x=<% Response.Write(admin); %>">CHANGE PASSWORD</a> <a href="./verification_unit/ved.aspx">VIEW STATISTICS</a>
        </div>
        <div class="content">
            <div class="header">
                <div class="xmenu">
                    <div class="menu">
                        <ul>
                            <li></li>
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
                <strong>DATA DETAILS FOR "<% Response.Write(c_mark.product_title.ToUpper()); %>"</strong></td>
        </tr>
         <tr>
            <td width="50%" align="right">
                &nbsp;FILLING/APPLICATION DATE :&nbsp;&nbsp;
            </td>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Label"><% Response.Write(c_app.reg_date); %></asp:Label>&nbsp;
            </td>
        </tr>
        <tr>
            <td align="right">
                REGISTRATION NUMBER :&nbsp;&nbsp;
            </td>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Label"><% Response.Write(c_mark.reg_number.ToUpper()); %></asp:Label>
            </td>
        </tr>
         <tr>
            <td align="right">
                SYSTEM APPLICATION NUMBER:</td>
            <td>
                 <% Response.Write("OAI/TM/" + c_stage.validationID); %></td>
        </tr>
        <tr>
            <td align="right">
                NAME :
            </td>
            <td><asp:Label ID="Label7" runat="server" Text="Label"><% Response.Write(c_app.xname.ToUpper()); %></asp:Label></td>
        </tr>
       
        <tr>
            <td align="right">
                NATIONALITY :
            </td>
            <td><asp:Label ID="Label19" runat="server" Text="Label"><% Response.Write(ret.getCountryName(c_app_addy.countryID)); %></asp:Label></td>
        </tr>
        <tr>
            <td align="right">
                COUNTRY OF RESIDENCE :</td>
            <td><asp:Label ID="Label20" runat="server" Text="Label"><% Response.Write(ret.getCountryName(c_app_addy.countryID)); %></asp:Label></td>
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
            <td><asp:Label ID="Label23" runat="server" Text="Label"><% Response.Write(c_app_addy.street.ToUpper()); %></asp:Label></td>
        </tr>
       
        <tr>
            <td align="right">
                TELEPHONE:</td>
            <td><asp:Label ID="Label25" runat="server" Text="Label"><% Response.Write(c_app_addy.telephone1.ToUpper()); %></asp:Label></td>
        </tr>
        <tr>
            <td align="right">
                E-MAIL:</td>
            <td><asp:Label ID="Label26" runat="server" Text="Label"><% Response.Write(c_app_addy.email1.ToUpper()); %></asp:Label></td>
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
                <asp:Label ID="Label6" runat="server" Text="Label"><% Response.Write(t.getTmTypeName(c_mark.tm_typeID)); %></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">
                LOGO DESCRIPTION :&nbsp;
            </td>
            <td>
                <%--<asp:Label ID="Label27" runat="server" Text="Label"><% Response.Write(t.getLogoDescriptionName(g_tm_info.logo_descID).ToUpper()); %></asp:Label>--%>
                 <asp:Label ID="Label4" runat="server" Text="Label"><% Response.Write(t.getLogoDescriptionName(c_mark.logo_descriptionID)); %></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">
                &nbsp;TRADEMARK :&nbsp;&nbsp;
            </td>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Label"><% Response.Write(c_mark.product_title.ToUpper()); %></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">
                &nbsp;&nbsp;CLASS OF SPECIFICATION OF GOODS/SERVICES :&nbsp;
            </td>
            <td>
                <asp:Label ID="Label28" runat="server" Text="Label"><% Response.Write(c_mark.nice_class.ToUpper()); %></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">
                &nbsp;DESCRIPTION OF SPECIFICATION OF GOODS/SERVICES :&nbsp;&nbsp;
            </td>
            <td>
                <% Response.Write(c_mark.nice_class_desc.ToUpper()); %></td>
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
                        <% Response.Write(c_rep.xname.ToUpper()); %>
                    </td>
                </tr>
                 <tr>
                    <td align="right">
                        ATTORNEY CODE :
                    </td>
                    <td>
                       
                        <% Response.Write(c_rep.agent_code.ToUpper()); %>
                    </td>
                </tr>
               
                <tr>
                    <td align="right">
                        COUNTRY OF RESIDENCE :
                    </td>
                    <td> <% 
                             Response.Write(ret.getCountryName(c_rep.nationality)); 
                            
                            
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
                    <td> <% Response.Write(c_rep_addy.street.ToUpper()); %></td>
                </tr>
              
                <tr>
                    <td align="right">
                        TELEPHONE:</td>
                    <td> <% Response.Write(c_rep_addy.telephone1.ToUpper()); %></td>
                </tr>
                <tr>
                    <td align="right">
                        &nbsp;E-MAIL:</td>
                    <td> <% Response.Write(c_rep_addy.email1.ToUpper()); %></td>
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
                        <% Response.Write(c_stage.validationID); %>
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
                <% if (c_mark.logo_pic != "")
               {
                   Response.Write("<a href=" + "../tm/" + c_mark.logo_pic + " target='_blank'>View</a>");        
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
                <% if (c_mark.sup_doc1 != "")
               {
                   Response.Write("<a href=" + "../tm/" + c_mark.sup_doc1 + " target='_blank'>View</a>");        
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
            <td align="center" colspan="4">   
                <% if (c_mark.sup_doc2 != "")
               {
                   Response.Write("<a href=" + "../tm/" + c_mark.sup_doc2 + " target='_blank'>View</a>");        
         }  else { Response.Write("NONE"); 
                        
               } %>
                <asp:Image ID="Image2" Visible="false" runat="server" />
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
                <% if (c_mark.auth_doc != "")
               {
                   Response.Write("<a href=" + "../tm/" + c_mark.auth_doc + " target='_blank'>View</a>");        
         }  else { Response.Write("NONE"); 
                        
               } %>
                <asp:Image ID="Image3" Visible="false" runat="server" />
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
            <td class="tbbg" colspan="2" align="center">
                &nbsp;
              -- RECORDAL INFORMATION --</td>
        </tr>

                 <% Response.Write(xrecordal); %>   

        <tr>
            <td class="tbbg" colspan="2">
                --- ACTION ---
            </td>
        </tr>
        <tr>
            <td align="center"  colspan="2"> <asp:RadioButtonList ID="rbValid" runat="server" RepeatDirection="Horizontal" onselectedindexchanged="rbValid_SelectedIndexChanged" AutoPostBack="true">
                    <asp:ListItem Value="Accepted" >Acceptance Unit</asp:ListItem>
                     <asp:ListItem Value="Opposed" >Opposition Unit</asp:ListItem>
                     <asp:ListItem Value="Certified" >Certificate Unit</asp:ListItem>
                 
                      <asp:ListItem Value="Ping" >Ping Agent</asp:ListItem>
                    
                   
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td class="tbbg" colspan="2">  --- ADD COMMENT --- </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                <asp:TextBox ID="comment" runat="server" Height="50px" TextMode="MultiLine" Width="98%"></asp:TextBox>


                   <table class="table tt2" id="rich"> 
              <tr>
                  <td> <textarea ng-wig="model.content"    ></textarea>  </td>

              </tr>

        <tr>
                  <td>
                      
                      
                      <input id="Button1" type="button" ng-click="add3(model.content)" value="Update" />  </td>

              </tr>


              </table>

              
            </td>
        </tr>
        <tr>
            <td class="tbbg" colspan="2">
                &nbsp;
                --- ATTACH DOCUMENTS ---</td>
        </tr>
               
        
        <tr>
            <td align="center" colspan="2">
                <input type="button" name="Printform" id="Printform" value="Print" onclick="printAll(); return false" class="button no-print" />
                <asp:Button ID="Verify" runat="server" Text="Update" OnClick="Verify_Click" class="button no-print" />
            </td>
        </tr>
    </table>
                 <input id="xname" name="xname" type="hidden" runat="server" />
                  <input id="xname2" name="xname2" type="hidden" runat="server" />
                <input id="xname3" name="xname3" type="hidden" runat="server" />
                 <input id="xname4" name="xname4" type="hidden" runat="server" />
         <input id="xname5" name="xname5" type="hidden" runat="server" />

         <input id="xname6" name="xname6" type="hidden" runat="server" />
        </div>
    </div>
</div>
       <%-- <input id="Hidden1" name="xname" type="hidden" runat="server" />--%>
         
      
    </form>
</body>
</html>