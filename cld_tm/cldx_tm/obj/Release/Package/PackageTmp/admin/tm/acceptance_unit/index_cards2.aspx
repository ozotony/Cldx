<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index_cards2.aspx.cs" Inherits="cld.admin.tm.acceptance_unit.index_cards2" %>

<!DOCTYPE html>

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


    <style>



               @media print
{     
   #dd2 {

      margin:auto;

      top: 0;
       width: 96%;
        height:  auto;

  
   /*margin-top:-25px;*/
   /*margin-left:-25px;*/
  

   }
                 
    .no-print, .no-print *
    {
        display: none !important;
       
    }
    /*body:before { content: url(Coat_of_Arms_of_Nigeria.png);}*/
   
}
        </style>

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
            <td colspan="2" align="center" class="tbbg"></td>
          </tr>  
        
          <tr class="no-print">
            <td colspan="2" align="center" >
                <asp:Button ID="btnGetAll" Visible="false" runat="server" Text="Get All" 
                    onclick="btnGetAll_Click"  CssClass="button"/>
                <asp:Button ID="btnReload" Visible="false" runat="server" Text="Cancel/Reload" 
                     CssClass="button" onclick="btnReload_Click"/>
                </td>
          </tr>  
        
          <tr class="no-print">
            <td colspan="2" align="center" class="tbbg">--- FILTER INDEX CARDS ---</td>
          </tr>  

           <tr class="no-print">
            <td  style="font-weight:bold; text-align:center;" 
                   colspan="2" >&nbsp;
                <asp:TextBox ID="txtFromAmount" runat="server" Visible="false" CssClass="textbox"></asp:TextBox>
                &nbsp;<asp:TextBox ID="txtToAmount" runat="server" Visible="false" CssClass="textbox"></asp:TextBox>
                &nbsp; Batch: <asp:DropDownList ID="selectBatch" runat="server">
                </asp:DropDownList>
                <asp:Button ID="btnGetByAmount" Visible="false" runat="server" Text="Get By Amount" 
                    CssClass="button" onclick="btnGetByAmount_Click"/>
               </td>
          </tr> 
        <% if (msg != "")
           {%>
          <tr>
            <td colspan="2" align="center" class="tbbg">&nbsp;</td>
          </tr>  
         <tr class="no-print">
            <td colspan="2" align="center" ><%=msg %></td>
          </tr>  
          <% }%> 

        
          <tr>
            <td colspan="2" align="center" class="tbbg"></td>
          </tr>  
        
           

        
           <%if (lt_mi.Count > 0)
             {   
                    %>          
       <tr >
       
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
           <span style="color:#ff0000;"> ACCEPTED  DATE:</span><% try
                                                                    {  %> <% = acceptance_date[i] %> <% }
    catch (Exception ee) { }  %></td>
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
            <span style="color:#ff0000;"> ACCEPTED  DATE:</span><% try
                                                                    {  %> <% = acceptance_date[i] %> <% }
    catch (Exception ee) { }  %></td>
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
        <table width="100%" class="no-print">
        <tr>
        <td align="center" colspan="2">
         <input type="button" name="Printform" id="Printform" value="Print" onclick="printAll(); return false"  class="button" />
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