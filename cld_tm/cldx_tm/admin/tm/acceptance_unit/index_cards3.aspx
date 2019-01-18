<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index_cards3.aspx.cs" Inherits="cld.admin.tm.acceptance_unit.index_cards3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" data-ng-app="myModule">
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
 <link href="../../../css/bootstrap.min.css" rel="stylesheet" />

    <script src="../../../js/angular.min.js"></script>
    <script src="../../../js/loading-bar.js"></script>
    <script src="../../../js/AngularLogin9.js"></script>
    <link href="../../../css/loading-bar.css" rel="stylesheet" />

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

 <style type="text/css">
        
               @media print
{     
     
    .no-print, .no-print *
    {
        display: none !important;
       
    }
}

.table>thead>tr>th, .table>tbody>tr>th, .table>tfoot>tr>th, .table>thead>tr>td, .table>tbody>tr>td, .table>tfoot>tr>td {
 
    border-top: 0px solid #ddd;
}
    </style>

</head>
<body ng-controller="myController2">
     <div class="container-fluid">
    <form id="form1" runat="server">
    <div>
    <div >
        <div >
           
            <div class="no-print">
                <div class="xmenu">
                </div>
                <div class="xlogo">
                    <div class="xlogo_l">
                    </div>
                </div>
            </div>
           
            <div id="searchform" class="no-print">
    <table width="100%"  border="0" id="insert_news" class="form table">
          <tr>
            <td colspan="2" align="center" class="tbbg">Total Records ({{groups.length}}):</td>
          </tr>  
        
          <tr>
            <td colspan="2" align="center" >
                <asp:Button ID="btnGetAll" runat="server" Visible="false" Text="Get All" 
                    onclick="btnGetAll_Click"  CssClass="button"/>
                <asp:Button ID="btnReload" Visible="false" runat="server" Text="Cancel/Reload" 
                     CssClass="button" onclick="btnReload_Click"/>
                </td>
          </tr>  
        
          <tr>
            <td colspan="2" align="center" class="tbbg">--- FILTER INDEX CARDS ---</td>
          </tr>  

           <tr>
            <td  style="font-weight:bold; text-align:center;" 
                   colspan="2" >&nbsp;From TpNumber :
                <input type="text" ng-model="from" id="from2"  />
                <asp:TextBox ID="txtFromAmount"  Visible="false" runat="server" CssClass="textbox"></asp:TextBox>
                &nbsp;To TpNumber : <input type="text" ng-model="to" id="to2"  /> <asp:TextBox ID="txtToAmount" Visible="false" runat="server" CssClass="textbox"></asp:TextBox>
                &nbsp; <asp:DropDownList ID="selectBatch" Visible="false" runat="server">
                </asp:DropDownList>
                <asp:Button ID="btnGetByAmount" Visible="false" runat="server" Text="Get By Amount" 
                    CssClass="button" onclick="btnGetByAmount_Click"/>
                <button class="button" type="button" ng-click="getData()" >Search</button>
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
        <table width="100%">
        <tr>
        <td align="center" colspan="2">
         <input type="button" name="Printform" id="Printform" value="Print" onclick="printTm(document.getElementById('searchform'));return false" class="button" />
         </td>
         </tr>
         </table>
        <%}  %> 
    </div>
</div>
</div>
    </form>

         

             <div class="row">
   <div class="col-md-6" ng-repeat="item in groups | filter:$even">

                 <table class="table " width="100%" id="rt_side">
        <tr>
        <td align="center" class="ic_tm">
     <span style="font-size:20px; font-weight:bolder;">  {{item.MarkInfo.product_title}} </span>    
         </td>
         </tr>
             <tr>
        <td align="center" class="ic_fno" style="font-size:14px">
        {{item.MarkInfo.reg_number}}    </td>
         </tr>
            <tr>
        <td align="center" class="ic_oaid"  style="font-size:14px">
         OAI/TM/  {{item.Pwallet.validationID}} 

        </td>
         </tr>
             <tr>
        <td align="center" class="ic_fdate"  style="font-size:14px">
            FILING DATE: {{item.MarkInfo.reg_date}}   </td>
         </tr>
        <tr>
         <tr>
        <td align="center" class="ic_accdate"  style="font-size:14px">
            <span style="color:#ff0000;"> ACCEPTED  DATE:</span> {{item.AcceptanceDate}} </td>
         </tr>
        
        <td align="center" class="ic_class" >
            <span style="font-size:14px; font-weight:bolder;"> CLASS ( {{item.MarkInfo.national_classID}}) </span></td>
         </tr>
        <tr>
        <td align="center" class="ic_appname"  style="font-size:14px">
        {{item.Applicant.xname}}    </td>
         </tr>
       
         
       

         <tr data-ng-if="item.MarkInfo.logo_pic">
        <td align="center" class="ic_logo">
       <img class="img-thumbnail img-responsive" width="100" height="100" ng-src="http://tm.cldng.com/admin/tm/{{item.MarkInfo.logo_pic}}"/>

        </td>
         </tr>
       
       </table>
      
   </div>
    
</div>
     <table class="table" width="100%">
        <tr>
        <td align="center" colspan="2">
         <input type="button" name="Printform" id="Printform" value="Print" onclick="printAll(); return false" class="button no-print" />
         </td>
         </tr>
         </table>
</div>


</body>
</html>