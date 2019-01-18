<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="rejection_slip_data_details.cs" Inherits="cld.admin.tm.rejection_slip_data_details" %>
<link href="../../css/style.css" rel="stylesheet" type="text/css" />

<script src="../../js/funk.js" type="text/javascript"></script>

<div>
    <div class="container">       
        <div class="content">
            <div class="header">
                <div class="xmenu">
                    <div class="menu">
                        <ul>
                            <li></li>
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
            <div id="searchform">
                  <asp:Panel runat="server" ID="pp7">
               <table class="form">
        <tr>
            <td colspan="2" align="center" width="1000px">
                <strong>FEDERAL MINISTRY OF TRADE AND INVESTMENT<br />
                    COMMERCIAL LAW DEPARTMENT<br />
                    INDUSTRIAL PROPERTY OFFICE REGISTRY </strong>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2" style="background-color:green; border-color:green;" width="1000px">
                <img src="../../images/coat_of_arms.png" style="width: 80px; height: 80px" />
            </td>
                   <tr>
                       <td align="center" colspan="2" width="1000px"><strong>
                           <br />
                           REFUSAL LETTER</strong>
                           <br />
                           &nbsp; </td>
                   </tr>
                   <tr>
                       <td align="right" colspan="2">&nbsp;</td>
                   </tr>
                   <tr>
                       <td align="center" style="width: 50%"><strong>FILLING/APPLICATION DATE: </strong></td>
                       <td align="center" style="width: 50%"><strong>REGISTRATION NUMBER: </strong></td>
                   </tr>
                   <tr>
                       <td align="center" style="width: 50%">
                           <asp:Label ID="Label1" runat="server" Text="Label"><% Response.Write(c_mark.reg_date); %></asp:Label>
                       </td>
                       <td align="center" style="width: 50%">
                           <asp:Label ID="Label2" runat="server" Text="Label"><% Response.Write(c_mark.reg_number.ToUpper()); %></asp:Label>
                       </td>
                   </tr>
                   <tr>
                       <td align="right" colspan="2">&nbsp;</td>
                   </tr>
                   <tr>
                       <td align="center"><strong>ONLINE APPLICATION ID: </strong></td>
                       <td align="center"><strong>AGENT CODE: </strong></td>
                   </tr>
                   <tr>
                       <td align="center"><% Response.Write("OAI/TM/"+c_p.validationID); %></td>
                       <td align="center"><% Response.Write(c_rep.agent_code.ToUpper()); %></td>
                   </tr>
                   <tr>
                       <td align="right" colspan="2">&nbsp;</td>
                   </tr>
                   <tr>
                       <td colspan="2" style="background-color:#1C5E55; color:#ffffff; text-align:center; font-weight:bold;">--- APPLICANT INFORMATION ---</td>
                   </tr>
                   <tr>
                       <td align="center" colspan="2">&nbsp;</td>
                   </tr>
                   <tr>
                       <td align="center" colspan="2"><strong>APPLICANT NAME: </strong></td>
                   </tr>
                   <tr>
                       <td align="center" colspan="2"><% Response.Write(c_app.xname.ToUpper()); %></td>
                   </tr>
                   <tr>
                       <td align="right" colspan="2">&nbsp;</td>
                   </tr>
                   <tr>
                       <td align="center" colspan="2"><strong>ADDRESS: </strong></td>
                   </tr>
                   <tr>
                       <td align="center" colspan="2"><% Response.Write(t.getFormattedAddressByID(c_app.addressID.ToUpper())); %></td>
                   </tr>
                   <tr>
                       <td align="right" colspan="2">&nbsp;</td>
                   </tr>
                   <tr>
                       <td align="center"><strong>PHONE NUMBER: </strong></td>
                       <td align="center"><strong>E-MAIL: </strong></td>
                   </tr>
                   <tr>
                       <td align="center"><% Response.Write(c_app_addy.telephone1.ToUpper()); %></td>
                       <td align="center"><% Response.Write(c_app_addy.email1.ToUpper()); %></td>
                   </tr>
                   <tr>
                       <td align="right" colspan="2">&nbsp;</td>
                   </tr>
                   <tr>
                       <td align="center" colspan="2"><strong>TRADEMARK: </strong>&nbsp;</td>
                   </tr>
                   <tr>
                       <td align="center" colspan="2"><% Response.Write(c_mark.product_title.ToUpper()); %></td>
                   </tr>
                   <tr>
                       <td align="center" colspan="2">&nbsp; </td>
                   </tr>
                   <tr>
                       <td align="center" colspan="2"><% if (c_mark.logo_pic != "")
                    {%>
                           <asp:Image ID="tm_img" runat="server" />
                           <% }
                    else
                    { %>NO DEVICE!! <% } %></td>
                   </tr>
                   <tr>
                       <td align="center" colspan="2">&nbsp; </td>
                   </tr>
                   <tr>
                       <td align="right">&nbsp; <strong>CLASS SPECIFICATION OF GOODS/SERVICES: </strong>&nbsp;&nbsp; </td>
                       <td>
                           <asp:Label ID="Label4" runat="server" Text="Label"><% Response.Write(c_mark.nice_class); %></asp:Label>
                       </td>
                   </tr>
                   <tr>
                       <td align="right" colspan="2">&nbsp;</td>
                   </tr>
                   <tr>
                       <td align="center" colspan="2"><strong>CLASS SPECIFICATION OF GOODS/SERVICES DESCRIPTION: </strong></td>
                   </tr>
                   <tr>
                       <td align="center" colspan="2">
                           <asp:Label ID="Label5" runat="server" Text="Label"><% Response.Write(c_mark.nice_class_desc.ToUpper()); %></asp:Label>
                       </td>
                   </tr>
                   <tr>
                       <td align="right" colspan="2">&nbsp;</td>
                   </tr>
                   <tr>
                       <td align="center" colspan="2" style="background-color:#1C5E55; color:#ffffff; text-align:center; font-weight:bold;">&nbsp; </td>
                   </tr>
                   <tr>
                       <td colspan="2">&nbsp;</td>
                   </tr>
                   <tr>
                       <td align="center" colspan="4"><strong>This is to inform you that your trademark has been refused !!Please contact our personnel for further details<br />
                           <br />
                           <strong>REASON:<br /> </strong><%Response.Write(xreason.ToUpper()); %>
                           <br />
                           <img alt="Nkiru" src="signatures/Nkiru.jpg" style=" width: 100px;height: 50px;" />
                           <br />
                           <br />
                           Ogunbanjo A. Temitope (FOR THE REGISTRAR)</strong></td>
                       <%-- <img alt="Adewasiu" src="signatures/acceptance_signature.jpg" style=" width: 130px;height: 60px;" /><br /><br />--%>
                   </tr>
                   <tr>
                       <td colspan="4" style="background-color:#1C5E55; color:#ffffff; text-align:center; font-weight:bold;">&nbsp;</td>
                   </tr>
                   <tr>
                       <td align="center" colspan="2">&nbsp; </td>
                   </tr>
    </table>
                      </asp:Panel>
        </div>
        <table width="1000px">
        <tr>
        <td align="left" width="1000px">
                 <div style="float:left;width:100%;">
              <input type="button" name="Printform" id="Printform" value="Print" onclick="printTm('searchform');return false" class="button" />
                </div>
        </td>
        </tr>
        </table>
    </div>
</div>
</div>
