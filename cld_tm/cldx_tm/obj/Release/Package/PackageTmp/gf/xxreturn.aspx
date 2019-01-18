<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="xxreturn.aspx.cs" Inherits="cld.gf.xxreturn" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >

<head id="Head1" runat="server">

    <title>
TRADEMARK APPLICATION NOTICE
</title>
  <link href="../css/style.css" rel="stylesheet" type="text/css" />

<script src="../js/jquery.js" type="text/javascript"></script>

<script src="../js/funk.js" type="text/javascript"></script>
  
</head>
<body>
    <form id="form1" runat="server">
 <div>
   
      <table align="center" width="1200px">
            <tr >
                <td >
    <table align="center" width="100%" class="form">
         <tr>
            <td colspan="2" align="center" >
                <img alt="Coat Of Arms" height="79" src="../images/coat_of_arms.png" 
                        width="85" /></td>
        </tr>
       
        
        <tr>
            <td colspan="2" align="center" style=" font-size:11pt;">
                 FEDERAL REPUBLIC OF NIGERIA<br />
                    FEDERAL MINISTRY OF INDUSTRY, TRADE AND INVESTMENT<br />
                    COMMERCIAL LAW DEPARTMENT<br />
                    TRADEMARKS, PATENTS AND DESIGNS REGISTRY<br />
                     </td>
        </tr>
        <tr>
             <td colspan="2" style="font-size:18pt;line-height:115%;" align="center">
                      APPLICATION VIOLATION NOTICE                 </td>
        </tr>
        <tr>
            <td style="background-color:#999999; text-align:center;" colspan="2">
            &nbsp;
            </td>
        </tr>
        
        
        <tr>
            <td width="50%" align="left">
               
                <div align="center">AN APPLICATION HAS WITH THE TRANSACTION ID <strong>"<%=validationID.ToUpper() %>"</strong> HAS ALREADY BEEN 
                    FILED!!!<br />
                    <br />
                    PLEASE 
                    CONSULT CUSTOMER CARE TO MAKE ANY COMPLAINTS</div>
                <br />
                <br />
                <div align="center"><strong>THANK YOU FOR YOUR UNDERSTANDING AND SERVICE</strong></div> </td>
        </tr>
        
        <tr>
            <td style="background-color:#999999; text-align:center;"></td>
        </tr>
        
       
        <tr>
            <td  align="center">
                &nbsp;<asp:Button ID="Agreed" runat="server" Text="BACK TO DASHBOARD" class="button" onclick="Agreed_Click" />
                </td>
        </tr>
         
    </table>
     </td>
    </tr>
    </table>
</div>
    </form>
</body>
</html>
