<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ipo_appstatus.aspx.cs" Inherits="cld.ipo_appstatus" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CLD:CLIENT APPLICATION STATUS</title>
    <link href="css/style.css" rel="stylesheet" type="text/css" />
<script src="js/jquery.js" type="text/javascript"></script>
<script src="js/funk.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
   <div>
    <div class="container">
    <div class="sidebar"></div>
       
        <div class="content">
        
                  
                 
            <% if(showt==0) {%>
            <table style="text-align:center; width:100%">
             <tr>
            <td colspan="2" style="text-align:center;">
              <img alt="Coat Of Arms" height="79" src="./images/coat_of_arms.png" 
                        width="85" /></td>
        </tr>
         <tr>
            <td colspan="2" style="text-align:center;">
               FEDERAL REPUBLIC OF NIGERIA<br />
                    FEDERAL MINISTRY OF INDUSTRY, TRADE AND INVESTMENT<br />
                    COMMERCIAL LAW DEPARTMENT<br />
                    TRADEMARKS, PATENTS AND DESIGNS REGISTRY<br />
                    </td>
        </tr>

        <tr>
            <td colspan="2" style="background-color:#1C5E55; color:#ffffff; text-align:center; font-weight:bold;">
                &nbsp;PLEASE ENTER YOUR TRANSACTION OR APPLICATION NUMBER TO CHECK YOUR STATUS</td>
        </tr>
       
        
        <tr>
            <td align="right">
                &nbsp;
                REFERENCE /APPLICATION NUMBER: &nbsp;
                  </td>
                
            <td style="width: 50%; text-align:left;">
            <asp:TextBox ID="xref" runat="server" Width="200px" CssClass="textbox"></asp:TextBox>
                </td>
        </tr>
        
        <tr>
            <td style="background-color:#1C5E55; color:#ffffff; text-align:center; font-weight:bold;" colspan="2"></td>
        </tr>


        <tr>
            <td style="text-align:center;" colspan="2">
               
                <asp:Button ID="Save" runat="server" Text="Check Status" OnClick="Save_Click" class="button" />
               
            </td>
        </tr>


    </table>
            <% }%>
            <% if (showt == 1)
               {%>
               <div id="searchform">
               <table>
               <tr id="report">
               <td>
               <table align="center" class="form"  id="table1">
                    <tr>
                        <td colspan="2" align="center" width="100%">
                            <strong>FEDERAL MINISTRY OF TRADE AND INVESTMENT<br />
                                COMMERCIAL LAW DEPARTMENT<br />
                                INDUSTRIAL PROPERTY OFFICE REGISTRY </strong>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style=" text-align:center; width:100%;">
                            <img src="images/coat_of_arms.png" 
                                style="width: 80px; height: 80px" />
                        </td>
                    </tr>
                   
                    <tr>
                        <td colspan="2" style="background-color:#1C5E55; color:#ffffff; text-align:center; font-weight:bold;width:100%">
                            <strong>---STATUS INFORMATION---</strong>
                        </td>
                    </tr>
                    <tr>
                        <td width="100%" align="justify" colspan="2">
                         Dear 
                            <% Response.Write(lt_rep.xname); %>, 
                            <br /> We will like to inform you that your application ("/OAI/TM/<% Response.Write(lt_pw[0].validationID); %>") is currently at the <strong>  "<% Response.Write(status); %>" Office</strong> and is currently <strong>"<% Response.Write(data_status); %>"</strong><br />
                            Regards,
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color:#1C5E55; color:#ffffff; text-align:center; font-weight:bold;width:100%" colspan="2">
                           
                        </td>
                    </tr>
                    <tr>
                        <td align="left" style="width:50%">
                            <strong>&nbsp;THE TRADEMARK REGISTRY,<br />
                                &nbsp;COMMERCIAL LAW DEPARTMENT NIGERIA,<br />
                                &nbsp;FEDERAL MINISTRY OF TRADE AND INVESTMENT,<br />
                                &nbsp;FEDERAL CAPITAL TERRITORY,<br />
                                &nbsp;ABUJA,NIGERIA </strong>
                        </td>
                        <td align="right">
                            <strong>REGISTRAR OF TRADEMARKS&nbsp;&nbsp; </strong>
                           
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color:#1C5E55; color:#ffffff; text-align:center; font-weight:bold;width:100%" colspan="2">
                            
                        </td>
                    </tr>
                </table>
               </td>
               </tr>

                <tr>
               <td style="text-align:center;">
 <input type="button" name="Printform" id="Printform" value="PRINT" onclick="printAssessment('report');return false" class="button" />
             <asp:Button ID="BtnReprintAck" runat="server" Text="REPRINT ACKNOWLEDGEMENT FORM"  CssClass="button" onclick="BtnReprintAck_Click" />
              <asp:Button ID="BtnCheckStatus" runat="server" Text="REFRESH SEARCH"  CssClass="button" onclick="BtnCheckStatus_Click"/>
               <asp:Button ID="BtnDashBoard" runat="server" Text="DASHBOARD"  CssClass="button" onclick="BtnDashBoard_Click"  />
               </td>
               </tr>
               </table>
              
               </div>
            <% }%>
        </div>
     </div> 
    
</div>
    </form>
</body>
</html>
