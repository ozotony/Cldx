<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="registrar_ack2.aspx.cs" Inherits="cld.admin.tm.Recordal2.registrar_ack2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>ACKNOWLEDGEMENT LETTER</title>
    <link rel="stylesheet" type="text/css" href="../../../css/style.css" />

<link rel="stylesheet" href="../../../css/jquery.ui.all.css" />
<script src="../../../js/funk.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
   <div>
    <div class="container">
        <div class="sidebar no-print">
                 <a href="./profile.aspx">PROFILE</a> 
             
              
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
                
            </div>
            <div id="searchform" >

    <table   class="form" >
        <tr>
            <td colspan="2" align="center" width="1100px">
              <strong> FEDERAL MINISTRY OF TRADE AND INVESTMENT<br />
COMMERCIAL LAW DEPARTMENT,
INDUSTRIAL PROPERTY OFFICE REGISTRY
</strong>
            </td>
        </tr>
       
        
        <tr>
            <td width="1100px" colspan="2" align="center" bgcolor="#006600">
                <img alt="" src="../../../images/coat_of_arms.png" style="width: 80px; height: 80px" /></td>
        </tr>
        
        <%if ((c_mark.xID != null) && (c_mark.xID != "") && (c_rep.ID != null) && (c_rep.ID != "") && (c_stage.ID != null) && (c_stage.ID != "") && (c_app.ID != null) && (c_app.ID != ""))
          { %>
       <tr>
            <td width="1100px" colspan="2" align="center">
               <strong>TRADEMARK DATA MIGRATION FORM</strong> </td>
        </tr>
        
        
        <tr>
            <td width="50%" align="right">
                &nbsp;FILLING/APPLICATION DATE :             </td>
            <td width="50%">
               
                <asp:Label ID="Label1" runat="server" Text="Label"><% Response.Write(c_mark.reg_date); %></asp:Label>&nbsp;</td>
        </tr>
           <tr>
            <td align="center">
               REGISTRATION NUMBER : </td>
            <td align="center">
              ONLINE APPLICATION ID :</td>
        </tr>       
       
           <tr>
            <td align="center">
                <% Response.Write(c_mark.reg_number); %></td>
            <td align="center">
               <% Response.Write("OAI/TM/"+(c_stage.validationID) ); %></td>
        </tr>       
        <tr>
            <td colspan="2">&nbsp;</td>
        </tr>
        <tr>
            <td style="background-color:#1C5E55; color:#ffffff; text-align:center; font-weight:bold;" 
                colspan="2">
                --- APPLICANT INFORMATION ---</td>
        </tr>
            <tr>
            <td colspan="2">&nbsp;</td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                APPLICANT NAME:</td>
        </tr>
        
        <tr>
            <td align="center" colspan="2">
                  <% Response.Write(c_app.xname); %></td>
        </tr>
         <tr>
            <td align="center" colspan="2">
                &nbsp;</td>                                
        </tr>
        <tr>
            <td align="center" colspan="2">
                ADDRESS :</td>                                
        </tr>
        
        <tr>
            <td align="center" colspan="2">
                 <% Response.Write(t.getFormattedAddressByID(c_app.addressID)); %></td>
        </tr>
         <tr>
            <td align="center" colspan="2">
                &nbsp;</td>                                
        </tr>
        <tr>
            <td align="center">
                PHONE NUMBER :
            </td>
                <td align="center">
                E-MAILS :
                   </td>
       </tr>
        
        <tr>
            <td align="center">
                <% Response.Write(t.getAgentTelephone1ByID(c_app.addressID)); %></td>
                <td align="center">
                     <% Response.Write(t.getAgentEmail1ByID(c_app.addressID)); %></td>
       </tr>
          <tr>
            <td colspan="2">&nbsp;</td>
        </tr>
        <tr>
            <td colspan="2" 
                style="background-color:#1C5E55; color:#ffffff; text-align:center; font-weight:bold;">
                --- TRADEMARK INFORMATION --- </td>
        </tr>
           <tr>
            <td colspan="2">&nbsp;</td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                &nbsp;&nbsp;TRADEMARK :</td>
        </tr>
        
        <tr>
            <td align="center" colspan="2">
                <% Response.Write(c_mark.product_title); %></td>
        </tr>
         <tr>
            <td align="center" colspan="2">
                &nbsp;</td>                                
        </tr>
        <tr>
            <td align="right">
                &nbsp;SPECIFICATION 
                OF GOODS/SERVICES :
            </td>
            <td>
                <asp:Label ID="Label4" runat="server" Text="Label"><% Response.Write(c_mark.nice_class); %></asp:Label></td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                &nbsp;</td>                                
        </tr>
        <tr>
            <td align="center" colspan="2">
                                &nbsp; SPECIFICATION OF GOODS/SERVICES DESCRIPTION : </td>
            
        </tr>
        <tr>
            <td align="center" colspan="2"> 
                                <asp:Label ID="Label5" runat="server" Text="Label"><% Response.Write(c_mark.nice_class_desc); %></asp:Label>
                                </td>
        </tr>
        
        <tr>
            <td align="center" colspan="2"> 
                                <strong>DISCLAIMER</strong></td>
        </tr>
        <tr>
            <td align="center" colspan="2"> 
                                <asp:Label ID="Label7" runat="server" Text="Label"><% Response.Write((c_mark.disclaimer) ); %></asp:Label></td>
        </tr>
           <tr>
            <td colspan="2">&nbsp;</td>
        </tr>
        <tr>
            <td style="background-color:#1C5E55; color:#ffffff; text-align:center; font-weight:bold;" 
                colspan="2"> 
                --- TRADEMARK REPRESENTATION --- </td>
        </tr>
           <tr>
            <td colspan="2">&nbsp;</td>
        </tr>
        <tr>
            <td align="center" colspan="2">   
                
                 <% if ((c_mark.logo_pic != "")&& (c_mark.logo_pic != "0")  )
                    {%>
                <asp:Image ID="tm_img" runat="server" />
                <% }
                    else
                    { %> NO DEVICE!!
                <% } %>
                </td>
        </tr>
           <tr>
            <td colspan="2">&nbsp;</td>
        </tr>
        <tr>
            <td colspan="2" 
                style="background-color:#1C5E55; color:#ffffff; text-align:center; font-weight:bold;">
                --- ACCREDITED AGENT ACCESS INFORMATION ---
            </td>
        </tr>
           <tr>
            <td colspan="2">&nbsp;</td>
        </tr>
         <tr>
            <td align="center">
                AGENT CODE : </td>
            <td align="center">
                NAME :
               </td>
        </tr>     
         <tr>
            <td align="center">
               <% Response.Write(c_rep.agent_code); %></td>
            <td align="center">
                <% Response.Write(c_rep.xname); %></td>
        </tr>
         <tr>
            <td colspan="2">&nbsp;</td>
        </tr>
        <tr>
            <td style="background-color:#1C5E55; color:#ffffff; text-align:center; font-weight:bold;" colspan="2">
                &nbsp;ADDRESS :
                </td>
        </tr>
         <tr>
            <td colspan="2">&nbsp;</td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                <asp:Label ID="Label8" runat="server" Text="Label"><% Response.Write(t.getFormattedAddressByID(c_rep.addressID)); %></asp:Label></td>
        </tr>               
        
        <tr>
            <td align="center">
                PHONE NUMBER : </td>
            <td align="center">
                E-MAIL : 
               </td>
        </tr>
        <tr>
            <td align="center">
                <% Response.Write(t.getAgentTelephone1ByID(c_rep.addressID)); %></td>
            <td align="center">
                  <% Response.Write(t.getAgentEmail1ByID(c_rep.addressID)); %></td>
        </tr>
           <tr>
            <td colspan="2">&nbsp;</td>
        </tr>
        <tr>
            <td colspan="2" 
                style="background-color:#1C5E55; color:#ffffff; text-align:center; font-weight:bold;">
                --- PAYMENT INFORMATION ---
            </td>
        </tr>
           <tr>
            <td colspan="2">&nbsp;</td>
        </tr>
         <tr>
            <td align="center">
                TRANSACTION ID : </td>
            <td align="center">
                 TRANSACTION AMOUNT : 
               </td>
        </tr>
        
         <tr>
            <td align="center">
                 <% Response.Write(c_stage.validationID); %></td>
            <td align="center">
                 <% Response.Write(c_stage.amt); %></td>
        </tr>
        
        <tr>
            <td style="background-color:#1C5E55; color:#ffffff; text-align:center; font-weight:bold;" 
                colspan="2"  >
              
                &nbsp;</td>
        </tr>
        <tr>
            <td  align="center" colspan="2">
               <br />
             <strong>Your application has been received and is receiving due attention</strong><br />
             <strong>REGISTRAR 
                (COMMERCIAL LAW DEPARTMENT NIGERIA)</strong> <br /></td>
        </tr>
         <% }%>
       
        
    </table>
        </div>

         <%if ((c_mark.xID != null) && (c_mark.xID != "") && (c_rep.ID != null) && (c_rep.ID != "") && (c_stage.ID != null) && (c_stage.ID != "") && (c_app.ID != null) && (c_app.ID != ""))
            { %>  
        <table width="1000px">
        <tr>
        <td align="left" width="1000px">
        <div style="float:left;width:100%;">
                <input type="button" name="Printform" id="Printform" value="Print" onclick="printTm('searchform');return false" class="button" />&nbsp;
                </div>
                </td>
        </tr>
        </table>
        <% } %>
    </div>
</div>
</div>
    </form>
</body>
</html>
