<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="tm_acknowledgement_c.aspx.cs" Inherits="cld.tm_acknowledgement_c" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>TRADEMARK REGISTRATION ACKNOWLEDGEMENT FORM</title>
<script language="javascript" type="text/javascript">
// <![CDATA[
    function IpoDashboard_onclick() {
        window.location.href = "./XPay/C/profile.aspx";

// ]]>
</script>

<link href="css/print_style.css" rel="stylesheet" type="text/css" />

<script src="js/jquery.js" type="text/javascript"></script>

<script src="js/funk.js" type="text/javascript"></script>
</head>

<body>
    <form id="form1" runat="server">
    <div class="container">
    
        <div id="searchform">

    <table  class="form">
        <tr>
            <td colspan="4" align="center" width="1000px">
              <strong> FEDERAL MINISTRY OF TRADE AND INVESTMENT<br />
COMMERCIAL LAW DEPARTMENT,
INDUSTRIAL PROPERTY OFFICE REGISTRY
</strong>
            </td>
        </tr>
       
        
        <tr>
            <td width="50%" colspan="4" align="center" bgcolor="#006600">
                <img alt="" src="images/coat_of_arms.png" style="width: 80px; height: 80px" /></td>
        </tr>
        
        
        <tr>
            <td width="50%" colspan="4" align="center">
               <strong>TRADEMARK REGISTRATION ACKNOWLEDGEMENT FORM</strong> </td>
        </tr>
        
        
        <tr>
            <td width="50%" align="right" colspan="2">
                &nbsp;FILLING/APPLICATION DATE :             </td>
            <td colspan="2" width="50%">
               
                <asp:Label ID="Label1" runat="server" Text="Label"><% Response.Write(c_mark.reg_date); %></asp:Label>&nbsp;</td>
        </tr>
           <tr>
            <td align="right" style="width:25%;">
               REGISTRATION NUMBER : </td>
            <td align="left" style="width:25%;">
                <asp:Label ID="Label2" runat="server" Text="Label"><% Response.Write(c_mark.reg_number); %></asp:Label></td>
            <td align="right" style="width:25%;">
              ONLINE APPLICATION ID : 
               </td>
            <td align="left" style="width:25%;">
                <asp:Label ID="Label6" runat="server" Text="Label"><% Response.Write("OAI/TM/"+(c_stage.validationID) ); %></asp:Label></td>
        </tr>       
       
        <tr>
            <td style="background-color:#1C5E55; color:#ffffff; text-align:center; font-weight:bold;" colspan="4">
                --- APPLICANT INFORMATION ---</td>
        </tr>
        
        <tr>
            <td align="right" colspan="2">
                APPLICANT NAME:</td>
                <td colspan="2">
                    <% Response.Write(c_app.xname); %></td>
        </tr>
        
        <tr>
            <td align="center" colspan="4">
                ADDRESS :</td>                                
        </tr>
        
        <tr>
            <td align="center" colspan="4">
                 <% Response.Write(t.getFormattedAddressByID(c_app.addressID)); %></td>
        </tr>
        
        <tr>
            <td align="right" style="width:25%;">
                PHONE NUMBER :
            </td>
            <td align="left" style="width:25%;">
                <% Response.Write(c_app_addy.telephone1); %></td>
                <td align="right" style="width:25%;">
                E-MAILS :
                   </td>
                <td align="left" style="width:25%;">
                <% Response.Write(c_app_addy.email1); %>
                   </td>
        </tr>        
              
        <tr>
            <td colspan="4" style="background-color:#1C5E55; color:#ffffff; text-align:center; font-weight:bold;">
                --- TRADEMARK INFORMATION --- </td>
        </tr>
        
        <tr>
            <td align="right" colspan="2">
                &nbsp;&nbsp;TRADEMARK :</td>
                <td colspan="2">
                 
                  <asp:Label ID="Label3" runat="server" Text="Label"><% Response.Write(c_mark.product_title); %></asp:Label></td>
        </tr>
        <tr>
            <td align="right" colspan="2">
                &nbsp;SPECIFICATION 
                OF GOODS/SERVICES :
            </td>
            <td colspan="2">
                <asp:Label ID="Label4" runat="server" Text="Label"><% Response.Write(c_mark.nice_class); %></asp:Label></td>
        </tr>
       
        <tr>
            <td align="center" colspan="4">
                                &nbsp; SPECIFICATION OF GOODS/SERVICES DESCRIPTION : </td>
            
        </tr>
        <tr>
            <td align="center" colspan="4"> 
                                <asp:Label ID="Label5" runat="server" Text="Label"><% Response.Write(c_mark.nice_class_desc); %></asp:Label>
                                </td>
        </tr>
        
        <tr>
            <td align="center" colspan="4"> 
                                <strong>DISCLAIMER</strong></td>
        </tr>
        <tr>
            <td align="center" colspan="4"> 
                                <asp:Label ID="Label7" runat="server" Text="Label"><% Response.Write((c_mark.disclaimer) ); %></asp:Label></td>
        </tr>
        <tr>
            <td style="background-color:#1C5E55; color:#ffffff; text-align:center; font-weight:bold;" colspan="4"> 
                --- TRADEMARK REPRESENTATION --- </td>
        </tr>
        <tr>
            <td align="center" colspan="4">   
                
                 <% if (c_mark.logo_pic != "")
                    {%>
                <img alt="" src="<% Response.Write("./admin/tm/"+c_mark.logo_pic); %>"  height="120px" width="140px"/>
                <% } else { %> NO DEVICE!!
                <% } %>
                </td>
        </tr>
        <tr>
            <td colspan="4" style="background-color:#1C5E55; color:#ffffff; text-align:center; font-weight:bold;">
                --- ATTORNEY INFORMATION ---
            </td>
        </tr>

         <tr>
            <td align="right" style="width:25%;">
                ATTORNEY CODE : </td>
            <td align="left" style="width:25%;">
                <asp:Label ID="Label9" runat="server" Text="Label"><% Response.Write(c_rep.agent_code); %></asp:Label></td>
            <td align="right" style="width:25%;">
               ATTORNEY NAME :
               </td>
            <td align="left" style="width:25%;">
                <asp:Label ID="Label11" runat="server" Text="Label"><% Response.Write(c_rep.xname); %></asp:Label></td>
        </tr>
        
        <tr>
            <td align="center" colspan="4">
                &nbsp;ADDRESS :
                </td>
        </tr>
        <tr>
            <td align="center" colspan="4">
                <asp:Label ID="Label8" runat="server" Text="Label"><% Response.Write(t.getFormattedAddressByID(c_rep.addressID)); %></asp:Label></td>
        </tr>               
        
        <tr>
            <td align="right" style="width:25%;">
                PHONE NUMBER : </td>
            <td align="left" style="width:25%;">
                 <% Response.Write(t.getAgentTelephone1ByID(c_rep.addressID)); %></td>
            <td align="right" style="width:25%;">
                E-MAIL : 
               </td>
            <td align="left" style="width:25%;">
                 <% Response.Write(t.getAgentEmail1ByID(c_rep.addressID)); %></td>
        </tr>
        
        
        
        <tr>
            <td colspan="4" style="background-color:#1C5E55; color:#ffffff; text-align:center; font-weight:bold;">
                --- PAYMENT INFORMATION ---
            </td>
        </tr>
         <tr>
            <td align="right" style="width:25%;">
                TRANSACTION ID : </td>
            <td align="left" style="width:25%;">
                   <% Response.Write(c_stage.validationID); %></td>
            <td align="right" style="width:25%;">
                 TRANSACTION AMOUNT : 
               </td>
            <td align="left" style="width:25%;">
                 <% Response.Write(c_stage.amt); %></td>
        </tr>
        
        <tr>
            <td style="background-color:#1C5E55; color:#ffffff; text-align:center; font-weight:bold;" colspan="4">
              
                &nbsp;</td>
        </tr>
        <tr>
            <td  align="center" colspan="4">
              
             <strong>Your application has been received and is receiving due attention</strong><br />
             <strong>REGISTRAR 
                (COMMERCIAL LAW DEPARTMENT NIGERIA)</strong></td>
        </tr>        
         
    </table>
        </div>
        <table width="1000px">
        <tr>
        <td align="left" width="1000px">
                 <div style="float:left;width:100%;">
                <input type="button" name="Printform" id="Printform" value="Print" onclick="printArk(document.getElementById('searchform'));return false" class="button" />
                <input type="button" name="IpoDashboard" id="IpoDashboard" value="Back to Dashboard" class="button" onclick="return IpoDashboard_onclick()" />
                </div>
        </td>
        </tr>
        </table>
</div>
    </form>
</body>
</html>
