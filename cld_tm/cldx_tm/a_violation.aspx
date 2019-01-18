<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="a_violation.aspx.cs" Inherits="cld.a_violation" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >

<head id="Head1" runat="server">

    <title>
TRADEMARK APPLICATION NOTICE
</title>
  <link href="css/style.css" rel="stylesheet" type="text/css" />

<script src="js/jquery.js" type="text/javascript"></script>

<script src="js/funk.js" type="text/javascript"></script>    
   
</head>
<body>
    <form id="form1" runat="server">
  

<div>
    <div class="container">
        <div class="sidebar">
        </div>
        <div class="content_tm_ack">
            <div class="header">
                <div class="xmenu">
                    <div class="menu">
                        <ul>
                            
                        </ul>
                    </div>
                </div>
                <div class="xlogo">
                    <div class="xlogo_l">
                    </div>
                </div>
            </div>
            <div id="searchform">

    <table align="center" width="100%" class="form">
        <tr>
            <td align="center" >
              <strong> FEDERAL MINISTRY OF TRADE AND INVESTMENT<br />
COMMERCIAL LAW DEPARTMENT<br />
INDUSTRIAL PROPERTY OFFICE REGISTRY
</strong>
            </td>
        </tr>
       
        
        <tr>
            <td width="22%" align="center" bgcolor="#006600">
                <img alt="" src="images/coat_of_arms.png" style="width: 80px; height: 80px" /></td>
        </tr>
        
        
        <tr>
            <td width="22%" align="center">
                <strong>&nbsp;APPLICATION VIOLATION NOTICE</strong> </td>
        </tr>
        
        
        <tr>
            <td width="50%" align="left">
               
                <div align="center">AN APPLICATION HAS ALREADY BEEN STARTED!!!<br />
                    <br />
                    PLEASE CLICK ON THE <strong>
                    &quot;CLOSE&quot;</strong> BUTTON TO CLOSE THIS TAB TO FINISH THE PREVIOUS PROCESS 
                    <br />
                    OR<br />
                    CLICK ON THE <strong>&quot;AGREED&quot;</strong> BUTTON TO GO BACK AND BEGIN A NEW APPLICATION (THIS WILL 
                    DISCARD THE PREVIOUS APPLICATION)</div>
                <br />
                <br />
                <div align="center"><strong>THANK YOU FOR YOUR UNDERSTANDING</strong></div> </td>
        </tr>
        
        <tr>
            <td class="tbbg">               
                &nbsp;</td>
        </tr>
        
       
        <tr>
            <td  align="center">
                &nbsp;<asp:Button ID="Agreed" runat="server" Text="AGREED" class="button" onclick="Agreed_Click" />
                </td>
        </tr>
         
    </table>
        </div>
    </div>
</div>
</div>

    </form>
</body>
</html>
