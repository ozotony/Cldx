<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="registrar_c_data_details2.ascx.cs" Inherits="cld.admin.tm.registrar_c_data_details2" %>
<link href="../../css/style.css" rel="stylesheet" type="text/css" />
<%--<script src="../../js/jquery-2.1.1.min.js"></script>--%>
<script src="../../js/angular.js"></script>
<script src="../../js/qrcode.js"></script>
<script src="../../js/qrcode_UTF8.js"></script>
<script src="../../Scripts/qrcode.js"></script>
<script src="../../js/AngularQrcode.js"></script>
<script src="../../Scripts/App7.js"></script>
    <link href="../../css/sweet-alert.css" rel="stylesheet" />
    <script src="../../js/sweet-alert.min.js"></script>


<script src="../../js/funk.js" type="text/javascript"></script>

 <style type="text/css">
        
               @media print
{     
     
    .no-print, .no-print *
    {
        display: none !important;
       
    }
}
    </style>

<div>
    <div class="container" data-ng-app="myModule">
        <div class="sidebar no-print">
          
           
        </div>
        <div class="content" ng-controller="myController">
             <form class="form-login" role="form" >
            <div class="header no-print ">
                <div class="xmenu">
                    <div class="menu no-print">
                        <ul>
                            <li><a href="./lo.aspx">
                                <img alt="" src="../../images/logoff.png" width="16" height="16" />Log off</a></li>
                        </ul>
                    </div>
                </div>
                <div class="xlogo">
                    <div class="xlogo_r">
                    </div>
                </div>
            </div>
            <div id="searchform">
            <table align="center" width="800px">
            <tr id="cert">
            <td>
            <table align="center">
                   
                    <tr>
                        <td width="800px" colspan="2" align="center">
                            <img src="../../images/coat_of_arms.png" style="width: 120px; height: 120px" />
                        </td>
                    </tr>
                   
                    <tr>
                        <td width="1000px" colspan="2" align="center" style="font-family:Arial Black; font-size:22px;">
                            NIGERIA


                        </td>
                    </tr>
                    <tr>
                        <td width="800px" colspan="2" align="center">
                            <strong>
                         <%--<span style="font-family: Old English Text MT; font-size:35px; color:#009900;">Certificate of Registration of Trade Mark</span><br />--%>
                                <img src="../../images/logo3.png" height="60" width="450" /><br />
                        <span style="font-family:Arial Black; font-size:20px;">Trade Marks Act</span><br />
                         <span style="font-family:'Trebuchet MS'; font-size:12px;">CAP 436 Laws Of The Federation Of Nigeria 1990; Section 22 (3) Regulation 65)</span>
                        </strong>
                            <strong> <asp:Label ID="Label33"  runat="server" Text="Label"></asp:Label> </strong>
                        </td>
                    </tr>
                    

                     <tr>
                        <td  
                            colspan="2" align="center">
                                <% 
                                    if (c_mark.logo_descriptionID != "2")
                                    {
                                        if (c_mark.logo_pic != "")
                                        {%>
                              <asp:Image  ID="tm_img" runat="server" />
                              <% }
                                        else
                                        { %> <span style="height:70px"> NO DEVICE!! </span>
                <% }
                                    }
                                    else
                                    {%>
                                    <div style=" font-size:28px; font-weight:bolder; font-family:Segoe UI; border:2px solid #ececec;"><%=c_mark.product_title %></div>
                                    <% }%>
                         </td>
                    </tr>

                    <tr>
                        <td  colspan="2" 
                            style="text-align:left; font-weight:bold;font-family: Segoe UI; font-size:12px;">
                           The Trade Marks shown above has been registered in Part A (Or B)
                        </td>
                    </tr>
                     <tr>
                        <td  colspan="2" 
                            style="text-align:left; font-weight:bold;font-family: Segoe UI; font-size:12px;">
                           Of the register in the name of
                        </td>
                    </tr>
                     <tr>
                        <td  colspan="2" 
                            style="text-align:center; font-weight:normal;font-family: Segoe UI Symbol; font-size:18px;">
                           <strong> <%=c_app.xname %></strong></td>
                    </tr>
                     <tr>
                        <td colspan="2" 
                            style="text-align:center; font-weight:bold;font-family: Segoe UI Symbol; font-size:12px;">
                           <br /> <%=t.getFormattedAddressByID(c_app.addressID) %></td>
                    </tr>
                     <tr>
                        <td colspan="2" 
                            style="text-align:center; font-weight:bold;font-family: Segoe UI Symbol; font-size:12px;">
                            In Class <%=c_mark.national_classID %> under No. <%=c_p.rtm %>-<%=c_p.validationID %> as Of Date <%=c_mark.reg_date %> in Respect Of </td>
                    </tr>
                     <tr>
                        <td colspan="2" 
                            style="text-align:center; font-weight:normal;font-family: Segoe UI Symbol; font-size:9px;">
                            <%=c_mark.nice_class_desc %>
                          </td>
                    </tr>
                     <%--<tr>
                        <td colspan="2" 
                            style="text-align:center; font-weight:normal;font-family: Segoe UI Symbol; font-size:14px;">
                            &nbsp;</td>
                    </tr>--%>
                   <%--  <tr>
                        <td colspan="2" 
                            style="text-align:center; font-weight:normal;font-family: Segoe UI Symbol; font-size:14px;">
                            &nbsp;</td>
                    </tr>
                     <tr>
                        <td colspan="2" 
                            style="text-align:center; font-weight:normal;font-family: Segoe UI Symbol; font-size:14px;">
                            &nbsp;</td>
                    </tr>--%>
                    <%-- <tr>
                        <td width="1000px" colspan="2" 
                            style="text-align:center; font-weight:normal;font-family: Segoe UI Symbol; font-size:14px;">
                            &nbsp;</td>
                    </tr>--%>
                                      
                   
                    <tr>
                        <td align="left" style="font-family: Garamond; font-size:14px;">
                            <strong>
                        Sealed at my direction this date <%=sealed_date%><br />
                        The Trade Marks Registry, <br />
                        Federal Ministry of Industry, Trade and Investment	<br />
                        Federal Capital Territory<br />
                        Abuja, Nigeria. 
                         </strong>
                        </td>
                       <td align="right">
                           <strong>&nbsp;&nbsp; </strong>
            </td>
                    </tr>
                 
                   
                    <tr>
                        <td align="left">
                            &nbsp;</td>
                       <td style="font-family: Garamond; font-size:16px; font-weight:bold; text-align:right;">
                           <div id="tx">
                              
                         <qrcode data={{string}} download> </qrcode>   <img src="signatures/Adeyemi.jpg" style=" width: 222px;;height: 83px;vertical-align:bottom" />
                               </div>
               <%-- <img alt="Adewasiu" src="signatures/registrar_mini_png.png" style=" width: 222px;height: 83px;" />--%>
                         
                <hr  style="background-color:#1C5E55; height:1px;"/>
              WILLIAM KEFTIN AMUGA<br />
                Registrar of Trade Marks</td>
                    </tr>                   
                    <tr>
                        <td style="background-color:#1C5E55; color:#ffffff; text-align:center; font-weight:normal; font-size:16px; font-family:Calibri;" 
                            colspan="2">
                            Registration is 7 years from the date first above – mentioned, and may then
be renewed, and also at the Expiration of each period of 14 years thereafter.</td>
                    </tr>
                     <tr>
                        <td style="background-color:#1C5E55;text-align:center; font-weight:normal; " 
                            colspan="2"></td>
                    </tr>
                    <tr>
                        <td colspan="2" style="font-family: Garamond; font-size:12px; font-weight:normal; text-align:center;">
                            <br />
                            This certificate is not for use in legal proceeding or for obtaining Registration
abroad. NOTE- Upon any change of ownership of this Trade mark, or change in
address, application should AT ONCE be made to the Registrar to register the change .
                            <br />
                        </td>
                    </tr>
                    
                </table>
         <strong> <asp:Label ID="Label44" runat="server" Text="Label"></asp:Label> </strong>
            </td>
            </tr>

             <tr>
            <td align="center">
             <%--<input type="button" name="Printform" id="Printform" value="Print" onclick="printTm('cert'); return false" class="button" />--%>
                <input type="button" name="Printform" id="Printform" value="Print" ng-click="add2()"  class="button no-print" />
            </td>
            </tr>
            </table>
                 <input id="xrtm" name="xrtm" type="hidden" runat="server" />
                 <input id="xname" name="xname" type="hidden" runat="server" />
                 <input id="xname2" name="xname2" type="hidden" runat="server" />
            </div>
                 </form>
          
        </div>
    </div>
</div>



