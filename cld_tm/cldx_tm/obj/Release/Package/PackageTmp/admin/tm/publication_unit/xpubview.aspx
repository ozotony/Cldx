<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="xpubview.aspx.cs" Inherits="cld.admin.tm.publication_unit.xpubview" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>TRADEMARK PUBLICATIONS</title>
    <link rel="stylesheet" type="text/css" href="../../../css/style.css" />
<script type="text/javascript" src="../../../js/jquery.js"></script>
<script src="../../../js/funk.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div class="container">
        <div class="sidebar">
           
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
    <table width="100%"  border="0" id="insert_news" bgcolor="#efefef" >
          <tr>
            <td colspan="8" align="center" class="tbbg">WELCOME TO THE PUBLICATION UNIT</td>
          </tr>  
        
        <tr class="stripedout">
            <td colspan="8" align="center">
                &nbsp;</td>
        
        
           <%if (lt_mi.Count > 0)
             {
                 int sn = 1;
                 for (i = 0; i < lt_mi.Count; i++)
                 { %> 
       
      </tr>
       <td align="center">
        <table align="center" width="100%" class="form">
        
        <tr>
            <td colspan="4" align="center" style=" background-color:Red; color:White;">
                <strong>PUBLICATION "<% Response.Write(sn); %>"</strong></td>
        </tr>

        <tr>
            <td width="22%" colspan="4" class="tbbg" align="center">
                <strong>DATA VERIFICATION DETAILS FOR "<% Response.Write(lt_mi[i].product_title.ToUpper()); %>"</strong></td>
        </tr>
        <tr>
            <td width="50%" align="right" colspan="2">
                &nbsp;FILLING/APPLICATION DATE :
            </td>
            <td colspan="2">
                <asp:Label ID="Label27" runat="server" Text="Label"><% Response.Write(lt_mi[i].reg_date); %></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" style="width:25%;">
                REGISTRATION NUMBER :
            </td>
            <td align="left"  style="width:25%;">
               <asp:Label ID="Label28" runat="server" Text="Label"><% Response.Write(lt_mi[i].reg_number); %></asp:Label></td>
            <td align="right"  style="width:25%;">
                SYSTEM APPLICATION NUMBER:
            </td>
            <td align="left"  style="width:25%;">
                <% 
                     Response.Write("OAI/TM/"+t.ValidationIDByPwalletID(lt_mi[i].log_staff) );
                     lt_p = z.getPwalletListDetailsByID(lt_mi[i].log_staff);
                     lt_app = t.getApplicantListByUserID(lt_mi[i].log_staff);
                     lt_addy = t.getAddressListByID(lt_app[0].addressID);
                     lt_addy_service = t.getAddressServiceListByID(lt_mi[i].log_staff);
                     lt_rep = t.getRepListByUserID(lt_mi[i].log_staff);
                     lt_rep_addy = t.getAddressByID(lt_rep[0].addressID); 
                     lt_stage = t.getStageByUserID(lt_mi[i].log_staff);                    
                     
                     %>
             </td>
        </tr>
      
        <tr>
            <td align="right" colspan="2">
                APPLICANT NAME :
            </td>
            <td colspan="2"><asp:Label ID="Label29" runat="server" Text="Label"><% Response.Write(lt_app[0].xname); %></asp:Label></td>
        </tr>
        <tr>
            <td align="right">
                NATIONALITY :
            </td>
            <td align="left">
               <asp:Label ID="Label34" runat="server" Text="Label"><% Response.Write(t.getCountryName(lt_app[0].nationality)); %></asp:Label></td>
            <td align="right">  COUNTRY OF RESIDENCE :</td>
            <td align="left"><asp:Label ID="Label35" runat="server" Text="Label"><% Response.Write(t.getCountryName(lt_addy[0].countryID)); %></asp:Label></td>
        </tr>
       
        <tr>
            <td align="right">
                STATE:
            </td>
            <td align="left">
               <asp:Label ID="Label36" runat="server" Text="Label"><% Response.Write(t.getStateName(lt_addy[0].stateID)); %></asp:Label></td>
            <td align="right">  CITY :</td>
            <td align="left"><asp:Label ID="Label37" runat="server" Text="Label"><% Response.Write(lt_addy[0].city); %></asp:Label></td>
        </tr>
        
        <tr>
            <td align="center" colspan="4">
                STREET
            </td>
            
        </tr>
        
        <tr>
            <td align="center" colspan="4">
               <asp:Label ID="Label38" runat="server" Text="Label"><% Response.Write(lt_addy[0].street); %></asp:Label></td>
        </tr>
        <tr>
            <td align="right">
                TELEPHONE:</td>
            <td align="left">
               <asp:Label ID="Label40" runat="server" Text="Label"><% Response.Write(lt_addy[0].telephone1); %></asp:Label></td>
            <td align="right"> E-MAIL:</td>
            <td align="left"><asp:Label ID="Label41" runat="server" Text="Label"><% Response.Write(lt_addy[0].email1); %></asp:Label></td>
        </tr>
       
       
        <tr>
            <td class="tbbg" colspan="4" align="center">
                --- TRADEMARK INFORMATION --- </td>
        </tr>       
        
        <tr>
            <td align="right" colspan="2">
                &nbsp; TRADEMARK:&nbsp;
            </td>
            <td colspan="2">
                <asp:Label ID="Label44" runat="server" Text="Label"><% Response.Write(lt_mi[i].product_title); %></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" colspan="2">
                &nbsp;TYPE :&nbsp;
            </td>
            <td colspan="2">
                <asp:Label ID="Label42" runat="server" Text="Label"><% Response.Write(t.getTmTypeName(lt_mi[i].tm_typeID)); %></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" colspan="2">
                NATIONAL CLASS :
            </td>
            <td colspan="2"><% Response.Write(lt_mi[i].national_classID); %></td>
        </tr>
        <tr>
            <td align="center" colspan="4">
                DESCRIPTION OF NATIONAL CLASS
            </td>
            
        </tr>        
        <tr>
            <td align="center" colspan="4">
               <% Response.Write(t.getNationalClassDesc(lt_mi[i].national_classID)); %></td>
        </tr>
        
        <tr>
            <td class="tbbg" colspan="4" align="center">
                --- ATTORNEY INFORMATION --- </td>
        </tr>
       
        <tr>
                    <td align="right">
                        ATTORNEY NAME :
                    </td>
                    <td align="left">
                      <% Response.Write(lt_rep[0].xname); %></td>
                    <td align="right">   ATTORNEY CODE :</td>
                    <td align="left"> <asp:Label ID="Label46" runat="server" Text="Label"><% Response.Write(lt_rep[0].agent_code); %></asp:Label></td>
                </tr>

                <tr>
                    <td align="center" colspan="4">
                     &nbsp;COUNTRY OF RESIDENCE :  
                        <% Response.Write("( "+t.getCountryName(lt_rep_addy[0].countryID)+" )"); %>  
                    &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;  
                    STATE:
                        <% Response.Write("( " + t.getStateName(lt_rep_addy[0].stateID) + " )"); %>   
                        &nbsp; &nbsp;&nbsp;&nbsp;&nbsp; 
                        CITY :<% Response.Write("( " + lt_rep_addy[0].city + " )"); %></td>
                </tr>
               
                <tr>
                    <td align="center" colspan="4">
                        STREET
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="4">
                        <% Response.Write(lt_rep_addy[0].street); %></td>
                </tr>
                <tr>
                    <td align="right">
                        TELEPHONE:</td>
                    <td align="left">
                        <% Response.Write(lt_rep_addy[0].telephone1); %></td>
                    <td align="right">E-MAIL:</td>
                    <td align="left">  <% Response.Write(lt_rep_addy[0].email1); %></td>
                </tr>
              
              
        <tr>
            <td class="tbbg" colspan="4" align="center">
                --- IMAGE ---</td>
        </tr>
       
        
        <tr>
            <td align="center" colspan="4">
                <% if (lt_mi[i].logo_pic != "")
               { 
                       %>
              <img alt="" src="<% Response.Write(lt_mi[i].logo_pic); %>"  height="120px" width="140px"/>
              <%
         }  else { Response.Write("NONE"); 
               } %>
            </td>
        </tr>
       
        <tr>
            <td class="tbbg" colspan="4">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="center" colspan="4">
              &nbsp;
                </td>
        </tr>
    </table>
    
       </td>
 <tr>
        <% sn++; } 
             }%>
       
            <td align="center" colspan="8">
                &nbsp;</td>
        </tr>
          </table>
        </div>
    </div>
</div>
</div>
    </form>
</body>
</html>
