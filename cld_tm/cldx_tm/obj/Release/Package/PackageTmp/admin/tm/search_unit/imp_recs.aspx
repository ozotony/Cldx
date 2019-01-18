<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="imp_recs.aspx.cs" Inherits="cld.admin.tm.search_unit.imp_recs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>IMPORT TRADEMARK RECORDS</title>
<link href="../../../css/style.css" rel="stylesheet" type="text/css" /> 
 <link href="../../../amcharts_2.6.6/samples/style.css" rel="stylesheet" type="text/css" />
 <script src="../../../amcharts_2.6.6/amcharts/amcharts.js" type="text/javascript"></script>


    <style type="text/css">
        .style1
        {
            width: 32px;
            height: 32px;
        }
    </style>


</head>
<body>
    <form id="form1" runat="server">
    <div>
       
        <div class="container">
            <div class="sidebar">
            <a href="../lo.aspx">
            <img alt="" src="../../../images/logoff.png" width="16" height="16" />Log off
            </a>
            <a href="./profile.aspx">PROFILE</a> 
            <a href="../../../cp.aspx?x=<% Response.Write("4"); %>">CHANGE PASSWORD</a> 
            </div>
            <div class="content">
        
    <table align="center" width="100%" >  
        <tr>
            <td colspan="2" align="left" class="tbbg">
                WELCOME TO THE SEARCH UNIT RECORD SECTION</td>
        </tr>
        <tr align="center">
        <td align="right" >
             <img alt="" src="../../../images/coat_of_arms.png" style="width: 60px; height: 60px" /> 
            </td>
            <td align="left" >
             <strong>FEDERAL MINISTRY OF TRADE AND INVESTMENT<br />
                COMMERCIAL LAW DEPARTMENT<br /> </strong>
            </td>
        </tr>         
        <tr>
            <td align="center" class="tbbg" colspan="2">
                PLEASE SELECT AN  EXCEL FILE TO IMPORT</td>
        </tr>
        
        <tr>
            <td  align="center" colspan="2">
               
                        <asp:FileUpload ID="excel_doc" runat="server" />
                        </td>
        </tr>
                 
        <tr>
            <td align="center" colspan="2" class="tbbg">
              
            </td>
        </tr>
        
        <tr>
            <td align="center" colspan="2" >
           <strong> <% Response.Write(validate_txt); %></strong>
           <% Response.Write(showLoader); %>
                &nbsp;<asp:Button ID="btnValidate" runat="server" Text="VALIDATE"  CssClass="button" onclick="btnValidate_Click" />
                <asp:Button ID="btnImportReport" runat="server" Text="IMPORT"  CssClass="button" onclick="btnImportReport_Click"/>
            &nbsp;<asp:Button ID="btnRefresh" runat="server" Text="NEW LIST"  
                    CssClass="button" onclick="btnRefresh_Click"/>
            &nbsp;<asp:HiddenField ID="xpwall" runat="server" />
            <asp:HiddenField ID="G_Agent_infocode" runat="server" />
            <asp:HiddenField ID="xInsertCnt" runat="server" />
              <asp:HiddenField ID="xResidence" runat="server" />
            </td>
        </tr>
        
        <tr>
            <td align="center" colspan="2" class="tbbg">
                &nbsp;</td>
        </tr>
        
        <tr>
            <td align="center">
               <div id="columndiv" style="width: 100%; height: 400px;"></div>
               </td>
               <td align="center">
               <div id="piechartdiv" style="width: 100%; height: 400px;"></div>
               </td>
        </tr>
        
        <tr>
            <td align="center" colspan="2">
                </td>
        </tr>
        
        <tr>
            <td class="tbbg" colspan="2">
              
            </td>
        </tr>
    </table>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
