<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index_cards.aspx.cs" Inherits="cld.admin.tm.publication_unit.index_cards" %>

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

<script language="javascript" type="text/javascript">

//    $(function () {

//        $("#txtFrom").datepicker({
//            changeMonth: true,
//            changeYear: true,
//            showButtonPanel: true,
//            dateFormat: 'yy-mm-dd',
//            yearRange: 'c-100:c+0'
//        });
//        $("#txtTo").datepicker({
//            changeMonth: true,
//            changeYear: true,
//            showButtonPanel: true,
//            dateFormat: 'yy-mm-dd',
//            yearRange: 'c-100:c+0'
//        });       

//    });
</script>

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
           
            <div id="searchform">
    <table width="100%"  border="0" id="insert_news" class="form">
          <tr>
            <td colspan="2" align="center" class="tbbg">Total Records (<%=cnt %>):</td>
          </tr>  
        
          <tr>
            <td colspan="2" align="center" >
                <asp:Button ID="btnGetAll" runat="server" Text="Get All" 
                    onclick="btnGetAll_Click"  CssClass="button"/>
                <asp:Button ID="btnReload" runat="server" Text="Cancel/Reload" 
                     CssClass="button" onclick="btnReload_Click"/>
                </td>
          </tr>  
        
          <tr>
            <td colspan="2" align="center" class="tbbg">--- FILTER INDEX CARDS ---</td>
          </tr>  

           <tr>
            <td  style="font-weight:bold; text-align:center;" 
                   colspan="2" >&nbsp;From :
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
            <td colspan="2" align="center" class="tbbg">&nbsp;</td>
          </tr>  
         <tr>
            <td colspan="2" align="center" ><%=msg %></td>
          </tr>  
          <% }%> 

        
          <tr>
            <td colspan="2" align="center" class="tbbg">&nbsp;</td>
          </tr>  
        
           

        
           <%if (lt_mi.Count > 0)
             {   
                    %>          
       <tr>
       
            <td align="center" width="50%">
            <%               
                 for (i = 0; i < lt_mi.Count; i=i+2)
                 {
                     lt_p = z.getPwalletListDetailsByID(lt_mi[i].log_staff);
                     lt_app = t.getApplicantListByUserID(lt_mi[i].log_staff);
                     lt_addy = t.getAddressListByID(lt_app[0].addressID);
                     lt_rep = t.getRepListByUserID(lt_mi[i].log_staff);
                     lt_rep_addy = t.getAddressByID(lt_rep[0].addressID);
                    %> 
                  <table width="100%" id="lt_side">
        <tr>
        <td align="center" class="ic_tm">
        <%=lt_mi[i].product_title%>
         </td>
         </tr>
        
        <tr>
        <td align="center" class="ic_class">
           <span style="font-size:20px; font-weight:bolder;"> CLASS (<%=lt_mi[i].national_classID%>)</span></td>
         </tr>
        <tr>
        <td align="center" class="ic_appname">
            <%=lt_app[0].xname%></td>
         </tr>
        <tr>
        <td align="center" class="ic_fno">
            <%=lt_mi[i].reg_number%></td>
         </tr>
          <tr>
        <td align="center" class="ic_fdate">
            FILING DATE: <%=lt_mi[i].reg_date%></td>
         </tr>
        <tr>
        <td align="center" class="ic_accdate">
           <span style="color:#ff0000;"> ACCEPTED  DATE:</span> <%=acceptance_date[i]%></td>
         </tr>
        <tr>
        <td align="center" class="ic_oaid">
           <% Response.Write("OAI/TM/" + (lt_p[0].validationID)); %></td>
         </tr>
        <tr>
        <td align="center" class="ic_logo">
             <% if (lt_mi[i].logo_pic != "")
               { 
                       %>
              <img alt="" src="../<% Response.Write(lt_mi[i].logo_pic); %>"  height="25%" width="25%"/>
              <%
         }  else { Response.Write("&nbsp;"); 
               } %></td>
         </tr>
       
        <tr>
        <td align="center">
            &nbsp;</td>
         </tr>
         </table>
         <%
             }%>
         </td>       
            <td align="center" width="50%">
            <%               
                 for (i = 1; i < lt_mi.Count; i = i + 2)
                 {
                     lt_p = z.getPwalletListDetailsByID(lt_mi[i].log_staff);
                     lt_app = t.getApplicantListByUserID(lt_mi[i].log_staff);
                     lt_addy = t.getAddressListByID(lt_app[0].addressID);
                     lt_rep = t.getRepListByUserID(lt_mi[i].log_staff);
                     lt_rep_addy = t.getAddressByID(lt_rep[0].addressID);
                    %>  
            <table width="100%" id="rt_side">
        <tr>
        <td align="center" class="ic_tm">
        <%=lt_mi[i].product_title%>
         </td>
         </tr>
        <tr>
        <td align="center" class="ic_class">
           <span style="font-size:20px; font-weight:bolder;"> CLASS (<%=lt_mi[i].national_classID%>)</span></td>
         </tr>
        <tr>
        <td align="center" class="ic_appname">
            <%=lt_app[0].xname%></td>
         </tr>
        <tr>
        <td align="center" class="ic_fno">
            <%=lt_mi[i].reg_number%></td>
         </tr>
          <tr>
        <td align="center" class="ic_fdate">
            FILING DATE: <%=lt_mi[i].reg_date%></td>
         </tr>
        <tr>
        <td align="center" class="ic_accdate">
           <span style="color:#ff0000;"> ACCEPTED  DATE:</span> <%=acceptance_date[i]%></td>
         </tr>
        <tr>
        <td align="center" class="ic_oaid">
           <% Response.Write("OAI/TM/" + (lt_p[0].validationID)); %></td>
         </tr>
        <tr>
        <td align="center" class="ic_logo">
             <% if (lt_mi[i].logo_pic != "")
               { 
                       %>
              <img alt="" src="../<% Response.Write(lt_mi[i].logo_pic); %>"  height="25%" width="25%"/>
              <%
         }  else { Response.Write("&nbsp;"); 
               } %></td>
         </tr>
       
        <tr>
        <td align="center">
            &nbsp;</td>
         </tr>
         </table>
         <%
             }%>
                </td>
        </tr>
        
           <%
             }%> 
          </table>
        </div>
         <%if (lt_mi.Count > 0)
           {   
                    %> 
        <table width="100%">
        <tr>
        <td align="center" colspan="2">
         <input type="button" name="Printform" id="Printform" value="Print" onclick="printAdminTm(document.getElementById('searchform'));return false" class="button" />
         </td>
         </tr>
         </table>
        <%}  %> 
    </div>
</div>
</div>
    </form>
</body>
</html>
