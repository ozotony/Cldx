<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="acceptance_slip_data_details.cs" Inherits="cld.admin.tm.acceptance_slip_data_details" %>
<link href="../../css/style.css" rel="stylesheet" type="text/css" />
<link href="../../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
<script src="../../js/funk.js" type="text/javascript"></script>
 <style>

        .bgMark
{
filter:alpha(opacity=8);
-moz-opacity:0.08;
opacity: 0.08;
}

    </style>
<STYLE TYPE="text/css">
	
strong{
    font-weight: 500;
}
     @media print
{    
    .no-print, .no-print *
    {
        display: none !important;
    }
}
	</STYLE>

    <div class="container" style="width:100%">
        
        <div class="content" style="float:none; margin: auto; width: 100%">
            <div class="header no-print" >
                <div class="xmenu">
                    <div class="menu">
                        <ul class='no-print'>
                            <li><a href="./lo.aspx">
                                <img class='no-print' alt="" src="../../images/logoff.png" width="16" height="16" />Log off</a></li>
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
                  <asp:Panel runat="server" ID="pp7">
            <table  id="pp8" class="form">
        <tr>
            <td colspan="2" align="center" width="1000px">
                <strong>FEDERAL MINISTRY OF TRADE AND INVESTMENT<br />
                    COMMERCIAL LAW DEPARTMENT<br />
                    INDUSTRIAL PROPERTY OFFICE REGISTRY </strong>
            </td>
        </tr>
        <tr>
            <td width="1000px" colspan="2" align="center"  
                style="background-color:green; border-color:green;">
                <img src="../../images/coat_of_arms.png" style="width: 80px; height: 80px" />
            </td>
        </tr>
                
                <tr id="aa2"   >
                     
                    <td colspan="2" align="center" width="1000px" style="padding: 2px">
                        
                        <strong>
                        
                        ACCEPTANCE LETTER
                        </strong>
                        &nbsp;

                        <asp:Label ID="Label3" Visible="false" runat="server" Text="Label"></asp:Label>

                     <%-- <div id="bgMark" class="bgMark" style="background-color:transparent;width:600px;height:480px; position: relative;top:-495px;left:160px;"> </div>
                          </asp:Panel>
                        <asp:Image ID="imgWaterMark"  runat="server" />--%>
                            
                    </td>
                    
                </tr>
               
                
       
        <tr>
            <td align="right" colspan="2">&nbsp;</td>
        </tr>
      
        <tr>
            <td align="center" style="width: 50%"> <strong>FILLING/APPLICATION DATE: </strong>
            </td>
            <td align="center" style="width: 50%"> <strong>REGISTRATION NUMBER:  </strong>            
           
            </td>
        </tr>
      
        <tr>
            <td align="center" style="width: 50%"><asp:Label ID="Label1" runat="server" Text="Label"><% Response.Write(c_mark.reg_date); %></asp:Label></td>
            <td  align="center" style="width: 50%"> <asp:Label ID="Label2" runat="server" Text="Label"><% Response.Write(c_mark.reg_number); %></asp:Label></td>
        </tr>
      
        <tr>
            <td align="right" colspan="2" >
                &nbsp;</td>
                  
                </tr>
      
        <tr>
            <td align="center" >
                <strong>ONLINE APPLICATION ID: </strong></td>
                  <td align="center" >
                <strong>AGENT CODE: </strong>
               </td>
                  
                </tr>
      
        <tr>
            <td align="center" >
                 <% Response.Write("OAI/TM/"+c_p.validationID); %></td>
                  <td align="center" >
                       <% Response.Write(c_rep.agent_code); %></td>
                  
                </tr>
      
        <tr>
            <td align="right" colspan="2" >
                &nbsp;</td>
                  
                </tr>
                <tr>
            <td style="background-color:#1C5E55; color:#ffffff; text-align:center; font-weight:bold;" 
                        colspan="2">
                --- APPLICANT INFORMATION ---</td>
                </tr>
                <tr>
            <td align="center" colspan="2">
                &nbsp;</td>
                </tr>
                <tr>
            <td align="center" colspan="2">
                 <strong>APPLICANT NAME: </strong></td>
                </tr>
                <tr>
            <td align="center" colspan="2">
                <% Response.Write(c_app.xname); %></td>
                </tr>
                <tr>
            <td align="right" colspan="2">
                &nbsp;</td>
                </tr>
                <tr>
            <td align="center" colspan="2">
                 <strong>ADDRESS: </strong></td>
                </tr>
                <tr>
            <td align="center" colspan="2">
                <% Response.Write(t.getFormattedAddressByID(c_app.addressID)); %></td>
                </tr>
                 <tr>
            <td align="right" colspan="2" >
                &nbsp;</td>
                  
                </tr>
                <tr>
            <td align="center" >
                 <strong>PHONE NUMBER: </strong>
                   
            </td>
               
            <td align="center">
                 <strong>E-MAIL: </strong></td>
                </tr>
                <tr>
            <td align="center" >
                 <% Response.Write(c_app_addy.telephone1); %></td>
               
            <td align="center">
               <% Response.Write(c_app_addy.email1); %></td>
                </tr>
         <tr>
            <td align="center" colspan="2" >
                &nbsp;</td>
                  
                </tr>
         <tr>
            <td align="center" colspan="2" >
                <strong>DISCLAIMER</strong></td>
                  
                </tr>
         <tr>
            <td align="center" colspan="2" >
                <% Response.Write(c_mark.disclaimer); %></td>
                  
                </tr>
        <tr>
            <td colspan="2" align="center">
                 <strong>TRADEMARK: </strong> &nbsp;</td>
        </tr>
        <tr>
            <td align="center" colspan="2" >
                <% Response.Write(c_mark.product_title); %></td>                  
                </tr>
                 <tr>
            <td align="center" colspan="2">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
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
            <td align="center" colspan="2">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="right">
                &nbsp; <strong>CLASS SPECIFICATION OF GOODS/SERVICES: </strong>&nbsp;&nbsp;
            </td>
            <td>
                <asp:Label ID="Label4" runat="server" Text="Label"><% Response.Write(c_mark.nice_class); %></asp:Label>
            </td>
        </tr>
         <tr>
            <td align="right" colspan="2" >
                &nbsp;</td>
                  
                </tr>
        <tr>
            <td align="center" colspan="2">
                <strong>CLASS SPECIFICATION OF GOODS/SERVICES DESCRIPTION: </strong>
                </td>
        </tr>       
        <tr>
            <td align="center" colspan="2">
             &nbsp;</td>
        </tr>
        <tr>
            <td align="center" colspan="2">
               <asp:Label ID="Label5" runat="server" Text="Label"><% Response.Write(c_mark.nice_class_desc); %></asp:Label></td>
        </tr>
       <tr>
            <td align="right" colspan="2" >
                &nbsp;</td>
                  
                </tr>
        <tr>
            <td style="background-color:#1C5E55; color:#ffffff; text-align:center; font-weight:bold;" 
                colspan="2" align="center">
            &nbsp;
                </td>
        </tr>
                
        <tr >
            <td colspan="2">
                &nbsp;</td>
        </tr>
                
        <tr>
            <td align="center" colspan="2">
                <strong> <asp:Label ID="Label6" Visible="false" runat="server" Text="Label"></asp:Label> 
                    <br /><br />
                      <asp:Panel ID="dt" Visible="false" runat="server"> 
               <%-- <img alt="Adewasiu" src="signatures/acceptance_signature.jpg" style=" width: 130px;height: 60px;" /><br />--%>
                 <img alt="Nkiru" src="signatures/Nkiru.jpg" style=" width: 100px;height: 50px;" /><br />
                <br />
                    
                     Ogunbanjo A. Temitope 
                    (FOR THE REGISTRAR)
                  <%-- KHASIYAT ALIYU--%>
                </asp:Panel>

                     <asp:Panel ID="dt2" Visible="false" runat="server"> 

                         “ COPY” .

                         </asp:Panel>

                    </strong>


            </td>
        </tr>
         <tr>
            <td align="center" colspan="2">
                &nbsp;
            </td>
        </tr>
    </table>
                      </asp:Panel>
    </div>
        </div>
        <table width="1000px">
        <tr>
        <td align="left" width="1000px">
          
                 <div style="float:left;width:100%;">
                     <asp:Button ID="btnMarkPrinted" runat="server" class='no-print' Text="Mark As Printed" onclick="btnMarkPrinted_Click" />
                     <% if (mark_printed == true)
                        { %>
              <input type="button" name="Printform" id="Printform"  value="Print" onclick="printAll(); return false" class="button no-print" />
              <% } %>
                </div>
        </td>
        </tr>
        </table>
        
    </div>
</div>

