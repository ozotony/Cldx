﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="journal2.aspx.cs" Inherits="cld.admin.tm.publication_unit.journal2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>TRADEMARK PUBLICATIONS</title>
<link rel="stylesheet" type="text/css" href="../../../css/style.css" />
<link rel="stylesheet" href="../../../css/jquery.ui.all.css" type="text/css"/>
<link rel="stylesheet" href="../../../css/jquery.ui.theme.css" type="text/css"/>


<script type="text/javascript" src="../../../js/jquery.js"></script>
<script src="../../../js/funk.js" type="text/javascript"></script>
<script src="../../../js/jquery-1.7.2.min.js" type="text/javascript"></script>
<script src="../../../js/jquery-ui-1.8.16.custom.min.js" type="text/javascript"></script>
<script src="../../../js/jquery.js" type="text/javascript"></script>
<script src="../../../ui/jquery.cookie.js" type="text/javascript"></script>
<script src="../../../ui/jquery.ui.core.js" type="text/javascript"></script>
<script src="../../../ui/jquery.ui.widget.js" type="text/javascript"></script>

<script src="../../../ui/jquery.ui.datepicker.js" type="text/javascript"></script>


</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div class="container">
        <div class="content">
            <div class="header">
                <div class="xmenu">
                </div>
                <div class="xlogo">
                    <div class="xlogo_l">
                    </div>
                </div>
            </div>
           
        
    <table style="text-align:center; width:100%;border:0px;" id="searchform2" >
          <tr>
            <td  class="tbbg">Total Records (<%=cnt %>):</td>
          </tr>  
        
          <tr>
            <td style="text-align:center;" >
                <asp:Button ID="btnGetAll" runat="server" Text="Get All" 
                    onclick="btnGetAll_Click"  CssClass="button"/>
                <asp:Button ID="btnReload" runat="server" Text="Cancel/Reload" 
                     CssClass="button" onclick="btnReload_Click"/>
                </td>
          </tr>  
        
          <tr>
            <td  class="tbbg">--- FILTER APPLICATIONS ---</td>
          </tr>  

           <tr>
            <td  style="font-weight:bold; text-align:center;" >&nbsp;From :
                <asp:TextBox ID="txtFromAmount" runat="server" CssClass="textbox"></asp:TextBox>
                &nbsp;To :<asp:TextBox ID="txtToAmount" runat="server" CssClass="textbox"></asp:TextBox>
                &nbsp; Batch: <asp:DropDownList ID="selectBatch" runat="server">
                </asp:DropDownList>
                <asp:Button ID="btnGetByAmount" runat="server" Text="Get By Amount" 
                    CssClass="button" onclick="btnGetByAmount_Click"/>
               </td>
          </tr> 
        <% if (msg != "")
           {%>
          <tr>
            <td class="tbbg">&nbsp;</td>
          </tr>  
         <tr>
            <td style="text-align:center;" ><%=msg %></td>
          </tr>  
          <% }%> 
        
           
        
       <tr>       
            <td style="text-align:center; width:100%;">
            
            

         </td>       
        </tr>
        
          </table>



            <div style="text-align:justify; width:100%;border:0px;" id="searchform" >
<div id="journal">
                  <% 
                      if (lt_mi.Count > 0)
                     {
                         int sn = 1;
                         for (i = 0; i < lt_mi.Count; i++)
                         {
                     lt_p = z.getPwalletListDetailsByID(lt_mi[i].log_staff);
                     lt_app = t.getApplicantListByUserID(lt_mi[i].log_staff);
                     lt_addy = t.getAddressListByID(lt_app[0].addressID);
                     lt_rep = t.getRepListByUserID(lt_mi[i].log_staff);
                     lt_rep_addy = t.getAddressByID(lt_rep[0].addressID); 
                     %>  

<div id="product_title" style="font-size:22px;font-weight:bold; text-align:left; font-family:Calibri;">
      <% if ((lt_mi[i].logo_pic != "")&&(lt_mi[i].logo_pic != "0"))
               { 
                       %>
              <img alt="" src="../<% =lt_mi[i].logo_pic %>"  height="25%" width="25%"/>
              <%
               }
         else
         {
            %> 
     <div ><% =lt_mi[i].product_title %></div>
     <%
               } %>

</div> 
                <div id="general_info">
                    <%=lt_mi[i].reg_date %> | OAI/TM/<%=lt_p[0].validationID %> | <%=lt_mi[i].reg_number %> | <%=lt_mi[i].national_classID %> |  <%=lt_mi[i].nice_class_desc %>|                   
                </div>
                <div id="applicant_info">
                     <strong> Applicant:  <%=lt_app[0].xname %> </strong>| <%=t.getFormattedAddressByID(lt_app[0].addressID) %> |
                </div>
                <div id="agent_info">
                   <strong>Agent:</strong>  <%=lt_rep[0].agent_code.ToUpper() %> | <%=lt_rep[0].xname.ToUpper() %> |  <%=t.getFormattedAddressByID(lt_rep[0].addressID) %>|
                </div> <br />
                    <% sn++; } 
                 }%>

    </div>
            </div>
<table style="text-align:center; width:100%;" >
 <%if (lt_mi.Count > 0)
             {
             %>
 <tr>       
       
            <td style="text-align:center;" >
             <input type="button" name="Printform" id="Printform" value="Print" onclick="printAdminJournal('journal');return false" class="button" /> 
              </td>
        </tr>
        <% 
             }%>
 </table>
       
     
    </div>
</div>
</div>
    </form>
</body>
</html>
