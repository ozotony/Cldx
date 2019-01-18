<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pubview.aspx.cs" Inherits="cld.admin.tm.publication_unit.pubview" %>

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
    <table width="100%"  border="0" id="insert_news">
          <tr>
            <td colspan="8" align="center" class="tbbg">&nbsp;</td>
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
      <tr>
       <td align="center">
        <table align="left" width="100%">
                <tr>
            <td ><hr /></td>
        </tr>
          <% 
                     lt_p = z.getPwalletListDetailsByID(lt_mi[i].log_staff);
                     lt_app = t.getApplicantListByUserID(lt_mi[i].log_staff);
                     lt_addy = t.getAddressListByID(lt_app[0].addressID);
                     lt_rep = t.getRepListByUserID(lt_mi[i].log_staff);
                     lt_rep_addy = t.getAddressByID(lt_rep[0].addressID);                  
                     
                     %>
        <tr>
            <td width="22%" ><strong><% Response.Write(lt_mi[i].reg_number.ToUpper()); %></strong> <% Response.Write(lt_mi[i].reg_date); %> (<% Response.Write(lt_mi[i].national_classID); %>)</td>
        </tr>     
        
        <tr>
            <td align="left">
                <% if (lt_mi[i].logo_pic != "")
               { 
                       %>
              <img alt="" src="../<% Response.Write(lt_mi[i].logo_pic); %>"  height="25%" width="25%"/>
              <%
         }  else { Response.Write("&nbsp;"); 
               } %>
            </td>
        </tr>
       
        <tr>
            <td align="left">
             <strong><% Response.Write(lt_mi[i].product_title); %></strong> </td>
        </tr>
       
        <tr>
            <td align="left">
                Class <% Response.Write(lt_mi[i].national_classID); %>:</td>
        </tr>
       
        <tr>
            <td align="left">
                <% Response.Write(lt_mi[i].nice_class_desc); %></td>
        </tr>
       
        <tr>
            <td align="left">
            <strong><% Response.Write(lt_app[0].xname); %></strong><br />
             <% Response.Write(t.getFormattedAddressByID(lt_app[0].addressID)); %>
               </td>
        </tr>
       
        <tr>
            <td align="left">
                <strong>Agent:</strong> <% Response.Write(lt_rep[0].xname); %> (<em><% Response.Write(lt_rep[0].agent_code.ToUpper()); %></em> )<br />
                   <% Response.Write(t.getFormattedAddressByID(lt_rep[0].addressID)); %> </td>
        </tr>
    </table>    
       </td>
       </tr>
 <tr>
        <% sn++; } 
             }%>
       
            <td align="center" colspan="8">
                </td>
        </tr>
          </table>
        </div>
        <table width="100%">
        <tr>
        <td align="center" colspan="2">
         <input type="button" name="Printform" id="Printform" value="Print" onclick="printAdminTm(document.getElementById('searchform'));return false" class="button" />
         </td>
         </tr>
         </table>
       
    </div>
</div>
</div>
    </form>
</body>
</html>
