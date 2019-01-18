<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Generic_registrar_data_details4d.aspx.cs" Inherits="cld.admin.tm.Generic_registrar_data_details4d" %>

<!DOCTYPE html>

<html lang="en">
    <head>
        <meta charset="utf-8" />
        <title></title>
        <script src="../../js/jquery-2.1.1.min.js"></script>
<script src="../../js/funk.js" type="text/javascript"></script>
        <style>
            body{
                font-family: 'Trebuchet MS';
                font-size: 11px;
            }
            .auto-style1 {
                height: 20px;
            }
        </style>
          <style type="text/css">
        
               @media print
{     
     
    .no-print, .no-print *
    {
        display: none !important;
       
    }
}
    </style>
    </head>
    <body>
        <form runat="server">
        <table class="inv" width="100%" border="1px inline">
       <tbody><tr>
            <td colspan="2" style="text-align:center;">
                <img alt="Coat Of Arms" height="79" src="../../images/coat_of_arms.png" width="85"></td>
        </tr>
       
        
        <tr>
            <td colspan="2" style=" font-size:11pt;text-align:center;">
                 FEDERAL REPUBLIC OF NIGERIA<br>
                    FEDERAL MINISTRY OF INDUSTRY, TRADE AND INVESTMENT<br>
                    COMMERCIAL LAW DEPARTMENT<br>
                    TRADEMARKS, PATENTS AND DESIGNS REGISTRY<br>
                     </td>
        </tr>
          
        
       <tr>
            <td style="font-size:16pt;line-height:175%; text-align:center;" colspan="2">

              RECORDAL ACKNOWLEDGEMENT FORM

                <br />

                 
                           <a href="http://88.150.164.30/EinaoTestEnvironment.IPO/A/profile.aspx" class="no-print">
                                <img alt="" src="../../images/logoff.png" width="16" height="16" />Back To Profile</a>
                       
            </td>
        </tr>
        
        
        <tr>
            <td style="width:50%; text-align:right;">
                &nbsp;FILLING/APPLICATION DATE :             </td>
            <td style="width:50%;">
               
                <span id="Label4"><asp:Label ID="Label1" runat="server" Text="Label"><% Response.Write( c_mark.reg_date.ToUpper()); %></asp:Label></span></td>
        </tr>
           <tr>
            <td style="text-align:center;">
               REGISTRATION NUMBER : </td>
            <td style="text-align:center;">
              ONLINE APPLICATION ID :</td>
        </tr>       
       
           <tr>
            <td style="text-align:center;">
                <span id="Label4"><asp:Label ID="Label8" runat="server" Text="Label"><% Response.Write( c_mark.reg_number.ToUpper()); %></asp:Label></span></td>
            <td style="text-align:center;">
               OAI/TM/ <span id="Label4"><asp:Label ID="Label6" runat="server" Text="Label"><% Response.Write( c_stage.validationID.ToUpper()); %></asp:Label></span></td>
        </tr>       
       
        <tr>
            <td style="background-color:#1C5E55; color:#ffffff; text-align:center; font-weight:bold;" colspan="2">
                --- APPLICANT INFORMATION ---</td>
        </tr>
        
        <tr>
            <td style="text-align:center;" colspan="2">
                APPLICANT NAME:</td>
        </tr>
        
        <tr>
            <td style="text-align:center;" colspan="2" class="auto-style1">
                  <asp:Label ID="Label2" runat="server" Text="Label"><% Response.Write(c_app.xname.ToUpper()); %></asp:Label></td>
        </tr>
        
      
        
        <tr>
            <td style="text-align:center;" colspan="2">
                ADDRESS :</td>                                
        </tr>
        
        <tr>
            <td style="text-align:center;" colspan="2">
                 <asp:Label ID="Label23" runat="server" Text="Label"><% Response.Write(c_app_addy.street.ToUpper()); %></asp:Label></td>
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
               <asp:Label ID="Label25" runat="server" Text="Label"><% Response.Write(c_app_addy.telephone1.ToUpper()); %></asp:Label></td>
                <td style="text-align:center;">
                     <asp:Label ID="Label26" runat="server" Text="Label"><% Response.Write(c_app_addy.email1.ToUpper()); %></asp:Label></td>
       </tr>
         
        <tr>
            <td colspan="2" style="background-color:#1C5E55; color:#ffffff; text-align:center; font-weight:bold;">
                --- TRADEMARK INFORMATION --- </td>
        </tr>
          
        <tr>
            <td style="text-align:center;" colspan="2">
                &nbsp;&nbsp;TRADEMARK :</td>
        </tr>
        
        <tr>
            <td style="text-align:center;" colspan="2">
               <asp:Label ID="Label3" runat="server" Text="Label"><% Response.Write(c_mark.product_title.ToUpper()); %></asp:Label></td>
        </tr>
         <tr>
            <td style="text-align:center;" colspan="2">
                &nbsp;</td>                                
        </tr>
        <tr>
            <td style="text-align:right;">
                &nbsp;CLASS OF TRADEMARK :
            </td>
            <td>
                <span id="Label4"><asp:Label ID="Label28" runat="server" Text="Label"><% Response.Write(c_mark.nice_class.ToUpper()); %></asp:Label></span></td>
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
                                <span id="Label5"><% Response.Write(c_mark.nice_class_desc/* t.getNationalClassDesc2(c_mark.nice_class)*/); %></span>
                                </td>
        </tr>
        
        <tr>
            <td style="text-align:center;" colspan="2"> 
                                <strong>DISCLAIMER</strong></td>
        </tr>
        <tr>
            <td style="text-align:center;" colspan="2"> 
                                 <span id="Label5"><% Response.Write(c_mark.disclaimer.ToUpper()); %></span></td>
        </tr>
         
        <tr>
            <td style="background-color:#1C5E55; color:#ffffff; text-align:center; font-weight:bold;" colspan="2"> 
                --- TRADEMARK REPRESENTATION --- </td>
        </tr>
          
        <tr>
            <td align="center" colspan="4">   
                <% if (g_tm_info.logo_pic != "")
               {
                 //  Response.Write("<a href=" + "../tm/gf/" + c_mark.logo_pic + " target='_blank'>View</a>");   
                      Response.Write("<a href=" + "../tm/" + c_mark.logo_pic + " target='_blank'>View</a>");       
         }  else { Response.Write("NONE"); 
                        
               } %>
                <asp:Image ID="tm_img" Visible="false" runat="server" />
                 <%--<% if ((g_tm_info.logo_pic != "") && (g_tm_info.logo_pic != "0") && (g_tm_info.logo_pic !=null))
                   Response.Write( "<a href=" +g_tm_info.logo_pic+" target='_blank'>View</a>");
                    {%>
                  
                <asp:Image ID="tm_img" runat="server" />
                <% }
                    else
                    { %> NO DEVICE!!
                <% } %>--%>
                </td>
        </tr>
        <tr>
            <td align="center" colspan="4">   
                <% if (c_mark.sup_doc1 != "")
               {
                  // Response.Write("<a href=" + "../tm/gf/" + c_mark.sup_doc1 + " target='_blank'>View</a>");   
                   Response.Write("<a href=" + "../tm/" + c_mark.sup_doc1 + " target='_blank'>View</a>");      
         }  else { Response.Write("NONE"); 
                        
               } %>
                <asp:Image ID="Image1" Visible="false" runat="server" />
                 <%--<% if ((g_tm_info.logo_pic != "") && (g_tm_info.logo_pic != "0") && (g_tm_info.logo_pic !=null))
                   Response.Write( "<a href=" +g_tm_info.logo_pic+" target='_blank'>View</a>");
                    {%>
                  
                <asp:Image ID="tm_img" runat="server" />
                <% }
                    else
                    { %> NO DEVICE!!
                <% } %>--%>
                </td>
        </tr>
           
        <tr>
            <td colspan="2" style="background-color:#1C5E55; color:#ffffff; text-align:center; font-weight:bold;">
                --- ATTORNEY INFORMATION ---
            </td>
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
               <% Response.Write(c_rep.agent_code.ToUpper()); %></td>
            <td style="text-align:center;">
                 <% Response.Write(c_rep.xname.ToUpper()); %></td>
        </tr>
        
        <tr>
            <td style=" text-align:center; " colspan="2">
                &nbsp;ADDRESS :
                </td>
        </tr>
        
        <tr>
            <td style="text-align:center;" colspan="2">
           <% Response.Write(c_rep_addy.street.ToUpper()); %></td>
        </tr>               
        
        <tr>
            <td style="text-align:center;">
                PHONE NUMBER :  </td>
            <td style="text-align:center;">
                E-MAIL :
               </td>
        </tr>

        <tr>
            <td style="text-align:center;">
               <% Response.Write(c_rep_addy.telephone1.ToUpper()); %></td>
            <td style="text-align:center;">
                 <% Response.Write(c_rep_addy.email1.ToUpper()); %></td>
        </tr>

                 <tr>
            <td colspan="2" style="background-color:#1C5E55; color:#ffffff; text-align:center; font-weight:bold;">
                --- ATTORNEY INFORMATION(REQUESTING AGENT) ---
            </td>
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
               <% Response.Write(vp.Sys_ID.ToUpper()); %></td>
            <td style="text-align:center;">
                 <% Response.Write(vp.Surname.ToUpper()); %></td>
        </tr>
        
        <tr>
            <td style=" text-align:center; " colspan="2">
                &nbsp;ADDRESS :
                </td>
        </tr>
        
        <tr>
            <td style="text-align:center;" colspan="2">
           <% Response.Write(vp.CompanyAddress.ToUpper()); %></td>
        </tr>               
        
        <tr>
            <td style="text-align:center;">
                PHONE NUMBER :  </td>
            <td style="text-align:center;">
                E-MAIL :
               </td>
        </tr>

        <tr>
            <td style="text-align:center;">
               <% Response.Write(vp.PhoneNumber.ToUpper()); %></td>
            <td style="text-align:center;">
                 <% Response.Write(vp.Email.ToUpper()); %></td>
        </tr>
            <tr>
            <td colspan="2" style="background-color:#1C5E55; color:#ffffff; text-align:center; font-weight:bold;">
                --- RECORDAL INFORMATION ---
            </td>
        </tr>
            <tr>
            <td style="text-align:center;">
                RECORDAL TYPE :</td>
            <td style="text-align:center;">
                  RECORDAL REQUEST DATE :</td>
        </tr>
            <tr>
            <td style="text-align:center;">
                 <% Response.Write(Px.RECORDAL_TYPE); %></td>
            <td style="text-align:center;">
                   <% Response.Write(Px.RECORDAL_REQUEST_DATE); %></td>
        </tr>
           <tr>
            <td style="text-align:center;">
           <% Response.Write(xusr); %>   :</td>
            <td style="text-align:center;">
                  <% Response.Write(xusr2); %>  :</td>
        </tr>
           <tr>
            <td style="text-align:center;">
                 <% Response.Write(xusr3); %> </td>
            <td style="text-align:center;">
                   <% Response.Write(xusr4); %> </td>
        </tr>


            <tr>
            <td style="text-align:center;">
           <% Response.Write(xusr5); %>   :</td>
            <td style="text-align:center;">
                  <% Response.Write(xusr6); %>  :</td>
        </tr>
           <tr>
            <td style="text-align:center;">
                 <% Response.Write(xusr7); %> </td>
            <td style="text-align:center;">
                   <% Response.Write(xusr8); %> </td>
        </tr>
         
            <tr>
            <td style="text-align:center;">
           <% Response.Write(xusr9); %>   :</td>
            <td style="text-align:center;">
                  <% Response.Write(xusr10); %>  :</td>
        </tr>
           <tr>
            <td style="text-align:center;">
                 <% Response.Write(xusr11); %> </td>
            <td style="text-align:center;">
                   <% Response.Write(xusr12); %> </td>
        </tr>

            <tr>
            <td style="text-align:center;">
                 <% Response.Write(xusr13); %> </td>
            <td style="text-align:center;">
                 </td>
        </tr>

             <tr>
            <td style="text-align:center;">
                 <% Response.Write(xusr14); %> </td>
            <td style="text-align:center;">
                 </td>
        </tr>

           <tr>
            <td style="text-align:center;">
                DETAILS OF REQUEST :</td>
            <td style="text-align:center;">
                 </td>
        </tr>
            <tr>
            <td style="text-align:center;">
                 <% Response.Write(vd[0].description); %></td>
            <td style="text-align:center;">
                </td>
        </tr>

        <tr>
            <td colspan="2" style="background-color:#1C5E55; color:#ffffff; text-align:center; font-weight:bold;">
                --- PAYMENT INFORMATION ---
            </td>
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
                 <% Response.Write(Px.TRANSACTIONID); %></td>
            <td style="text-align:center;">
                 <% Response.Write(Px.AMOUNT); %></td>
        </tr>
        
        <tr>
            <td style="background-color:#1C5E55; color:#ffffff; text-align:center; font-weight:bold;" colspan="2">              
                &nbsp;</td>
        </tr>
        <tr>
            <td style="text-align:center;" colspan="2">
             <strong>Your application has been received and is receiving due attention</strong><br>
             <strong>REGISTRAR 
                (COMMERCIAL LAW DEPARTMENT NIGERIA)</strong> <br></td>
        </tr>
         
        
    </tbody></table>
         <input type="button" name="Printform" id="Printform" value="Print" onclick="printAll(); return false" class="button no-print" />
             </form>
    </body>
</html>