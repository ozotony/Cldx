<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="profilea_data.ascx.cs" Inherits="cld.admin.tm.profilea_data" %>
<link rel="stylesheet" type="text/css" href="../../css/style.css" />
<script type="text/javascript" src="../../js/jquery.js"></script>
<script src="../../js/funk.js" type="text/javascript"></script>
<div>
    <div class="container">
        <div class="sidebar">
           
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
            <table align="center" width="100%" class="form">
        <tr>
            <td colspan="2" align="center">
                <strong>FEDERAL MINISTRY OF TRADE AND INVESTMENT<br />
                    COMMERCIAL LAW DEPARTMENT<br />
                    INDUSTRIAL PROPERTY OFFICE REGISTRY </strong>
            </td>
        </tr>
        <tr>
            <td width="22%" colspan="2" align="center" bgcolor="#006600">
                <img  alt="" src="../../images/coat_of_arms.png" style="width: 80px; height: 80px" />
            </td>
        </tr>
        <tr>
            <td width="22%" colspan="2" class="tbbg" align="center">
                <strong>DATA VERIFICATION DETAILS FOR "<% Response.Write(lt_mi[0].product_title.ToUpper()); %>"</strong></td>
        </tr>
       
        <tr>
            <td width="50%" align="right">
                &nbsp;FILLING/APPLICATION DATE :
            </td>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Label"><% Response.Write(lt_mi[0].reg_date); %></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">
                REGISTRATION NUMBER :
            </td>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Label"><% Response.Write(lt_mi[0].reg_number.ToUpper()); %></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">
                SYSTEM APPLICATION NUMBER:</td>
            <td>
                 <% Response.Write("OAI/TM/"+t.ValidationIDByPwalletID(lt_mi[0].log_staff) ); %></td>
        </tr>
        <tr>
            <td align="right">
                NAME :
            </td>
            <td><asp:Label ID="Label7" runat="server" Text="Label"><% Response.Write(lt_app[0].xname.ToUpper()); %></asp:Label></td>
        </tr>
        <tr>
            <td align="right">
                TYPE :</td>
            <td><asp:Label ID="Label15" runat="server" Text="Label"><% Response.Write(lt_app[0].xtype.ToUpper()); %></asp:Label></td>
        </tr>
        <tr>
            <td align="right">
                TAX ID TYPE :</td>
            <td><asp:Label ID="Label16" runat="server" Text="Label"><% Response.Write(lt_app[0].tax_id_type.ToUpper()); %></asp:Label></td>
        </tr>
        <tr>
            <td align="right">
                TAX ID NUMBER :
            </td>
            <td><asp:Label ID="Label17" runat="server" Text="Label"><% Response.Write(lt_app[0].tax_id_number.ToUpper()); %></asp:Label></td>
        </tr>
        <tr>
            <td align="right">
                INDIVIDUAL ID NUMBER :</td>
            <td><asp:Label ID="Label18" runat="server" Text="Label"><% Response.Write(lt_app[0].individual_id_number.ToUpper()); %></asp:Label></td>
        </tr>
        <tr>
            <td align="right">
                NATIONALITY :
            </td>
            <td><asp:Label ID="Label19" runat="server" Text="Label"><% Response.Write(t.getCountryName(lt_app[0].nationality).ToUpper()); %></asp:Label></td>
        </tr>
        <tr>
            <td align="right">
                COUNTRY OF RESIDENCE :</td>
            <td><asp:Label ID="Label20" runat="server" Text="Label"><% Response.Write(t.getCountryName(lt_addy[0].countryID).ToUpper()); %></asp:Label></td>
        </tr>
        <tr>
            <td align="right">
                STATE:
            </td>
            <td><asp:Label ID="Label21" runat="server" Text="Label"><% Response.Write(t.getStateName(lt_addy[0].stateID).ToUpper()); %></asp:Label></td>
        </tr>
        <tr>
            <td align="right">
                CITY :</td>
            <td><asp:Label ID="Label22" runat="server" Text="Label"><% Response.Write(lt_addy[0].city.ToUpper()); %></asp:Label></td>
        </tr>
        <tr>
            <td align="right">
                STREET No.:
            </td>
            <td><asp:Label ID="Label23" runat="server" Text="Label"><% Response.Write(lt_addy[0].street.ToUpper()); %></asp:Label></td>
        </tr>
        <tr>
            <td align="right">
                ZIP CODE:
            </td>
            <td><asp:Label ID="Label24" runat="server" Text="Label"><% Response.Write(lt_addy[0].zip.ToUpper()); %></asp:Label></td>
        </tr>
        <tr>
            <td align="right">
                TELEPHONE:</td>
            <td><asp:Label ID="Label25" runat="server" Text="Label"><% Response.Write(lt_addy[0].telephone1.ToUpper()); %></asp:Label></td>
        </tr>
        <tr>
            <td align="right">
                E-MAIL:</td>
            <td><asp:Label ID="Label26" runat="server" Text="Label"><% Response.Write(lt_addy[0].email1.ToUpper()); %></asp:Label></td>
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
                <asp:Label ID="Label3" runat="server" Text="Label"><% Response.Write(t.getTmTypeName(lt_mi[0].tm_typeID).ToUpper()); %></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">
                LOGO DESCRIPTION :&nbsp;
            </td>
            <td>
                <asp:Label ID="Label4" runat="server" Text="Label"><% Response.Write(t.getLogoDescriptionName(lt_mi[0].logo_descriptionID).ToUpper()); %></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">
                &nbsp; TITLE OF PRODUCT :&nbsp;
            </td>
            <td>
                <asp:Label ID="Label5" runat="server" Text="Label"><% Response.Write(lt_mi[0].product_title.ToUpper()); %></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">
                &nbsp;&nbsp;CLASS OF SPECIFICATION OF GOODS/SERVICES :&nbsp;
            </td>
            <td>
                <asp:Label ID="Label6" runat="server" Text="Label"><% Response.Write(lt_mi[0].nice_class.ToUpper()); %></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">
                &nbsp;DESCRIPTION OF SPECIFICATION OF GOODS/SERVICES :
            </td>
            <td>
                <% Response.Write(lt_mi[0].nice_class_desc.ToUpper()); %></td>
        </tr>
        <tr>
            <td align="right">
                NATIONAL CLASS :
            </td>
            <td><% Response.Write(lt_mi[0].national_classID); %></td>
        </tr>
        <tr>
            <td align="right">
                DESCRIPTION OF NATIONAL CLASS :
            </td>
            <td> <% Response.Write(t.getNationalClassDesc(lt_mi[0].national_classID).ToUpper()); %></td>
        </tr>
        <tr>
            <td align="right">
                SIGN TYPE :
            </td>
            <td><% Response.Write(lt_mi[0].sign_type.ToUpper()); %></td>
        </tr>
        <tr>
            <td align="right">
                VIENNA CLASS :
            </td>
            <td><% Response.Write(lt_mi[0].vienna_class.ToUpper()); %></td>
        </tr>
        
        <tr>
            <td class="tbbg" colspan="2" align="center">
                --- ATTORNEY INFORMATION --- </td>
        </tr>
       
                <tr>
                    <td align="right">
                        ATTORNEY CODE :
                    </td>
                    <td>
                        <asp:Label ID="Label9" runat="server" Text="Label"><% Response.Write(lt_rep[0].agent_code.ToUpper()); %></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        ATTORNEY NAME :
                    </td>
                    <td>
                        <% Response.Write(lt_rep[0].xname.ToUpper()); %>
                    </td>
                </tr>

                <tr>
                    <td align="right">
                        &nbsp;INDIVIDUALID TYPE :
                    </td>
                    <td>
                        <asp:Label ID="Label8" runat="server" Text="Label"><% Response.Write(lt_rep[0].individual_id_type.ToUpper()); %></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        &nbsp;INDIVIDUAL ID NUMBER :&nbsp;
                    </td>
                    <td>
                       <% Response.Write(lt_rep[0].individual_id_number.ToUpper()); %>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        COUNTRY OF RESIDENCE :
                    </td>
                    <td> <% Response.Write(t.getCountryName(lt_rep_addy[0].countryID).ToUpper()); %></td>
                </tr>
                <tr>
                    <td align="right">
                        STATE:
                    </td>
                    <td> <% Response.Write(t.getStateName(lt_rep_addy[0].stateID).ToUpper()); %></td>
                </tr>
                <tr>
                    <td align="right">
                        CITY :
                    </td>
                    <td> <% Response.Write(lt_rep_addy[0].city.ToUpper()); %></td>
                </tr>
                <tr>
                    <td align="right">
                        STREET :
                    </td>
                    <td> <% Response.Write(lt_rep_addy[0].street.ToUpper()); %></td>
                </tr>
                <tr>
                    <td align="right">
                        ZIP:
                    </td>
                    <td> <% Response.Write(lt_rep_addy[0].zip.ToUpper()); %></td>
                </tr>
                <tr>
                    <td align="right">
                        TELEPHONE:</td>
                    <td> <% Response.Write(lt_rep_addy[0].telephone1.ToUpper()); %></td>
                </tr>
                <tr>
                    <td align="right">
                        &nbsp;E-MAIL:</td>
                    <td> <% Response.Write(lt_rep_addy[0].email1.ToUpper()); %></td>
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
                        <% Response.Write(lt_stage[0].validationID); %>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        TRANSACTION AMOUNT :
                    </td>
                    <td>
                        <% Response.Write(lt_stage[0].amt); %>
                    </td>
                </tr>
       
        <tr>
            <td class="tbbg" colspan="2" align="center">
                --- ADDRESS OF SERVICE INFORMATION ---</td>
        </tr>
       
        <tr>
            <td align="right">
                STREET : </td>
            <td>
                <asp:Label ID="Label10" runat="server" Text="Label"><% Response.Write((lt_addy_service[0].street).ToUpper()); %></asp:Label></td>
        </tr>
        <tr>
            <td align="right">
                CITY : </td>
            <td>
                <asp:Label ID="Label11" runat="server" Text="Label"><% Response.Write((lt_addy_service[0].city).ToUpper()); %></asp:Label></td>
        </tr>
        <tr> <td align="right">STATE: </td>
            <td> 
                <asp:Label ID="Label12" runat="server" Text="Label"><% Response.Write(( t.getStateName(lt_addy_service[0].stateID)).ToUpper()); %></asp:Label></td>
        </tr>
        <tr>
            <td align="right">
                ZIP CODE: </td>
            <td><% Response.Write(lt_addy_service[0].zip.ToUpper()); %></td>
        </tr>
        <tr>
            <td align="right">
                TELEPHONE: </td>
            <td>
                <asp:Label ID="Label13" runat="server" Text="Label"><% Response.Write((lt_addy_service[0].telephone1).ToUpper()); %></asp:Label></td>
        </tr>
        <tr>
            <td align="right">
                E-MAIL: </td>
            <td>
                <asp:Label ID="Label14" runat="server" Text="Label"><% Response.Write((lt_addy_service[0].email1).ToUpper()); %></asp:Label></td>
        </tr>
      
        <tr>
            <td class="tbbg" colspan="2" align="center">
                --- SUPPORTING DOCUMENTS ---</td>
        </tr>
       
        
        <tr>
            <td align="right">
                "<% Response.Write(z.getLogoDescriptionNameByID(lt_mi[0].logo_descriptionID.ToUpper())); %>" IMAGE:
            </td>
            <td>
                <% if (lt_mi[0].logo_pic != "")
               { 
               Response.Write( "<a href=" +lt_mi[0].logo_pic+" target='_blank'>View</a>");        
         }  else { Response.Write("NONE"); 
               } %>
            </td>
        </tr>
        <tr>
            <td align="right">
                AUTHORIZATION:
            </td>
            <td>
                <% if (lt_mi[0].auth_doc != "")
               {
                   Response.Write("<a href=" + lt_mi[0].auth_doc + " target='_blank'>View</a>");        
         }  else { Response.Write("NONE"); 
               } %>
            </td>
        </tr>
        <tr>
            <td align="right">
                DOCUMENT 1:
            </td>
            <td>
                <% if (lt_mi[0].sup_doc1 != "")
               {
                   Response.Write("<a href=" + lt_mi[0].sup_doc1 + " target='_blank'>View</a>");        
         }  else { Response.Write("NONE"); 
               } %>
            </td>
        </tr>
        <tr>
            <td align="right">
                DOCUMENT&nbsp; 2:
            </td>
            <td>
                <% if (lt_mi[0].sup_doc2 != "")
               {
                   Response.Write("<a href=" + lt_mi[0].sup_doc2 + " target='_blank'>View</a>");        
         }  else { Response.Write("NONE"); 
               } %>
            </td>
        </tr>
        
        <tr>
            <td class="tbbg" colspan="2">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                <input type="button" name="Printform" id="Printform" value="Print" onclick="printTm(document.getElementById('searchform'));return false" class="button" />&nbsp;
                </td>
        </tr>
    </table>
        </div>
    </div>
</div>
</div>