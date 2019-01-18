<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ipo_ark.aspx.cs" Inherits="cld.ipo_ark" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>TRADEMARK REGISTRATION ACKNOWLEDGEMENT FORM</title> 

<link href="css/print_style.css" rel="stylesheet" type="text/css" />

<script src="js/jquery.js" type="text/javascript"></script>

<script src="js/funk.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div class="container">
    <div id="searchform" >
     <table style="width:1000px; margin-left:auto;margin-right:auto;">
        <tr id="ack">
        <td style="width:1000px; text-align:left;">
    <table   class="form" >
       <tr>
            <td colspan="2" style="text-align:center;">
                <img alt="Coat Of Arms" height="79" src="./images/coat_of_arms.png" 
                        width="85" /></td>
        </tr>
       
        
        <tr>
            <td colspan="2"  style=" font-size:11pt;text-align:center;">
                 FEDERAL REPUBLIC OF NIGERIA<br />
                    FEDERAL MINISTRY OF INDUSTRY, TRADE AND INVESTMENT<br />
                    COMMERCIAL LAW DEPARTMENT<br />
                    TRADEMARKS, PATENTS AND DESIGNS REGISTRY<br />
                     </td>
        </tr>
        
        <%if ((c_mark.xID != null) && (c_mark.xID != "") && (c_rep.ID != null) && (c_rep.ID != "") && (c_stage.ID != null) && (c_stage.ID != "") && (c_app.ID != null) && (c_app.ID != ""))
          { %>
       <tr>
            <td style="font-size:16pt;line-height:115%; text-align:center;" colspan="2">
              TRADEMARK REGISTRATION ACKNOWLEDGEMENT FORM</td>
        </tr>
        
        
        <tr>
            <td  style="width:50%; text-align:right;">
                &nbsp;FILLING/APPLICATION DATE :             </td>
            <td style="width:50%;">
               
                <asp:Label ID="Label1" runat="server" Text="Label"><% Response.Write(c_mark.reg_date); %></asp:Label>&nbsp;</td>
        </tr>
           <tr>
            <td  style="text-align:center;">
               REGISTRATION NUMBER : </td>
            <td style="text-align:center;">
              ONLINE APPLICATION ID :</td>
        </tr>       
       
           <tr>
            <td style="text-align:center;">
                <% Response.Write(c_mark.reg_number); %></td>
            <td style="text-align:center;">
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
            <td style="text-align:center;" colspan="2">
                APPLICANT NAME:</td>
        </tr>
        
        <tr>
            <td style="text-align:center;" colspan="2">
                  <% Response.Write(c_app.xname); %></td>
        </tr>
        
        <tr>
            <td style="text-align:center;" colspan="2">
                &nbsp;</td>                                
        </tr>
        
        <tr>
            <td style="text-align:center;" colspan="2">
                ADDRESS :</td>                                
        </tr>
        
        <tr>
            <td style="text-align:center;" colspan="2">
                 <% Response.Write(t.getFormattedAddressByID(c_app.addressID)); %></td>
        </tr>
         <tr>
            <td style="text-align:center;" colspan="2">
                &nbsp;</td>                                
        </tr>
        <tr>
            <td style="text-align:center;">
                PHONE NUMBER :
            </td>
                <td style="text-align:center;">
                E-MAILS :
                   </td>
       </tr>
        
        <tr>
            <td style="text-align:center;">
                <% Response.Write(t.getAgentTelephone1ByID(c_app.addressID)); %></td>
                <td style="text-align:center;">
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
            <td style="text-align:center;" colspan="2">
                &nbsp;&nbsp;TRADEMARK :</td>
        </tr>
        
        <tr>
            <td style="text-align:center;" colspan="2">
                <% Response.Write(c_mark.product_title); %></td>
        </tr>
         <tr>
            <td style="text-align:center;" colspan="2">
                &nbsp;</td>                                
        </tr>
        <tr>
            <td style="text-align:right;">
                &nbsp;SPECIFICATION 
                OF GOODS/SERVICES :
            </td>
            <td>
                <asp:Label ID="Label4" runat="server" Text="Label"><% Response.Write(c_mark.nice_class); %></asp:Label></td>
        </tr>
        <tr>
            <td style="text-align:center;" colspan="2">
                &nbsp;</td>                                
        </tr>
        <tr>
            <td style="text-align:center;" colspan="2">
                                &nbsp; SPECIFICATION OF GOODS/SERVICES DESCRIPTION : </td>
            
        </tr>
        <tr>
            <td style="text-align:center;" colspan="2"> 
                                <asp:Label ID="Label5" runat="server" Text="Label"><% Response.Write(c_mark.nice_class_desc); %></asp:Label>
                                </td>
        </tr>
        
        <tr>
            <td style="text-align:center;" colspan="2"> 
                                <strong>DISCLAIMER</strong></td>
        </tr>
        <tr>
            <td style="text-align:center;" colspan="2"> 
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
            <td style="text-align:center;" colspan="2">   
                
                 <% if (c_mark.logo_pic != "")
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
                --- ATTORNEY INFORMATION ---
            </td>
        </tr>
           <tr>
            <td colspan="2">&nbsp;</td>
        </tr>
         <tr>
            <td style="text-align:center;">
                ATTORNEY CODE : </td>
            <td style="text-align:center;">
               ATTORNEY NAME :
               </td>
        </tr>
        
         <tr>
            <td style="text-align:center;">
               <% Response.Write(c_rep.agent_code); %></td>
            <td style="text-align:center;">
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
            <td style="text-align:center;" colspan="2">
            <% Response.Write(t.getFormattedAddressByID(c_rep.addressID)); %></td>
        </tr>               
        
        <tr>
            <td style="text-align:center;">
                PHONE NUMBER : </td>
            <td style="text-align:center;">
                E-MAIL : 
               </td>
        </tr>

        <tr>
            <td style="text-align:center;">
                <% Response.Write(t.getAgentTelephone1ByID(c_rep.addressID)); %></td>
            <td style="text-align:center;">
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
            <td style="text-align:center;">
                TRANSACTION ID : </td>
            <td style="text-align:center;">
                 TRANSACTION AMOUNT : 
               </td>
        </tr>
        
         <tr>
            <td style="text-align:center;">
                 <% Response.Write(c_stage.validationID); %></td>
            <td style="text-align:center;">
                 <% Response.Write(c_stage.amt); %></td>
        </tr>
        
        <tr>
            <td style="background-color:#1C5E55; color:#ffffff; text-align:center; font-weight:bold;" 
                colspan="2"  >
              
                &nbsp;</td>
        </tr>
        <tr>
            <td  style="text-align:center;" colspan="2">
             <strong>Your application has been received and is receiving due attention</strong><br />
             <strong>REGISTRAR 
                (COMMERCIAL LAW DEPARTMENT NIGERIA)</strong> <br /></td>
        </tr>
         <% }else { %>
       
         
        <tr>
            <td  style="background-color:#1C5E55; color:#ffffff; text-align:center; font-weight:bold;" 
                colspan="2" >
              
                --- ERROR PRINTING ACKNOWLEDGEMENT AT THIS TIME ---&nbsp;</td>
        </tr>       
         
        <tr>
            <td  style="text-align:center;" colspan="2">
              
                <strong>PLEASE CONTACT AN ADMINSTRATOR AS SOON AS POSSIBLE<br />
              <asp:Button ID="btnDashboard" runat="server" Text="Back to Dashboard" class="button" onclick="btnDashboard_Click"/>
                </strong></td>
        </tr>
        
        <% } %>
        
    </table>
     </td>
        </tr>
         <%if ((c_mark.xID != null) && (c_mark.xID != "") && (c_rep.ID != null) && (c_rep.ID != "") && (c_stage.ID != null) && (c_stage.ID != "") && (c_app.ID != null) && (c_app.ID != ""))
            { %>  
        <tr style="text-align:center;">
        <td>
         <input type="button" name="Printform" id="Printform" value="Print" onclick="printArk('ack');return false" class="button" />
                 <asp:Button ID="btnDashboard2" runat="server" Text="Back to Dashboard" class="button" onclick="btnDashboard2_Click"/>
        </td>
        </tr>
         <% } %>
        </table>

        </div>
       
</div>
    
    </div>
    </form>
</body>
</html>
