<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="add_agent.aspx.cs" Inherits="cld.admin.tm.x_unit.add_agent" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
<link href="../../../css/style.css" rel="stylesheet" type="text/css" />
<link rel="stylesheet" href="../../../css/jquery.ui.all.css" />
<link rel="stylesheet" href="../../../css/jquery.ui.theme.css" />


<script src="../../../js/funk.js" type="text/javascript"></script>
<script src="../../../js/jquery.js" type="text/javascript"></script>
<script src="../../../js/jquery-ui-1.8.16.custom.min.js" type="text/javascript"></script>
<script type="text/javascript" src="../ui/jquery.ui.datepicker.js"></script>
<script src="../../../js/ui/jquery.ui.core.js" type="text/javascript"></script>
<script src="../../../js/ui/jquery.ui.widget.js" type="text/javascript"></script>
<script src="../../../js/ui/jquery.ui.tabs.js" type="text/javascript"></script>

 <script  type="text/javascript">
     $(function () {

         $(".txt_date_pri").datepicker({
             changeMonth: true,
             changeYear: true,
             showButtonPanel: true,
             dateFormat: 'yy-mm-dd',
             yearRange: 'c-100:c+0'
         });

     });
     function doChill()
     {
     }
</script>


</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div class="container">
        <div class="sidebar">
            </div>
        <div class="content">
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
                    <div class="xlogo_r">
                    </div>
                </div>
            </div>           
        
    <table align="center" width="100%" class="form">
     <tr>
            <td colspan="2" align="left" class="tbbg">
                NEW AGENT REGISTRATION
            </td>
        </tr>     
     <tr>
            <td colspan="2" align="center">
               <strong><% Response.Write(succ_text); %>    
                </strong><br />
              
            </td>
        </tr>
       

    <tr>
            <td align="left" style="width:150px;">
                FIRST NAME:</td>
            <td align="left">
               <input id="txt_firstname" runat="server" class=" textbox" name="txt_firstname" size="87" type="text" /></td>
        </tr>
       

    <tr>
            <td align="left" style="width:150px;">
                SURNAME:</td>
            <td align="left">
                <input id="txt_surname" runat="server" class=" textbox" name="txt_surname" size="87" type="text" /></td>
        </tr>
       
        <tr>
            <td align="left" style="width:150px;">
                AGENT ID:</td>
            <td align="left">
                <input id="txt_sysid" runat="server" class=" textbox" name="txt_sysid"  size="87" type="text" /></td>
        </tr

    <tr>
            <td align="left" style="width:150px;">
                E-MAIL:</td>
            <td align="left">
                <input id="txt_mail" runat="server" class=" textbox" name="txt_mail"  size="87" type="text" /></td>
        </tr>
       

    <tr>
            <td align="left" style="width:150px;">
                MOBILE NUMBER:</td>
            <td align="left">
                <input id="txt_mobile" runat="server" class=" textbox" name="txt_mobile" size="87" type="text" /></td>
        </tr>
       

    <tr>
            <td align="left" style="width:150px;">
                DATE OF BIRTH:</td>
            <td align="left">
                <input id="txt_dob" runat="server" class="txt_date_pri textbox" name="txt_mobile" size="40" type="text" />
                
            </td>
        </tr>
       

    <tr>
            <td align="left" style="width:150px;">
                NATIONALITY:</td>
            <td align="left">
                NIGERIA</td>
        </tr>
       

    <tr>
            <td align="left" colspan="2" class="sub_header">
                COMPANY INFORMATION &gt;&gt; </td>
        </tr>
       

    <tr>
            <td align="left" style="width:150px;">
                NAME:</td>
            <td align="left">
                <input id="txt_coy_name" runat="server" class=" textbox" name="txt_coy_name" size="87" type="text" /></td>
        </tr>
       

    <tr>
            <td align="left" style="width:150px;">
                ADDRESS:</td>
            <td align="left">
                <textarea id="txt_coy_addy" runat="server" class="textbox" cols="62" name="txt_coy_addy" rows="3"></textarea></td>
        </tr>
       

    <tr>
            <td align="left" style="width:150px;">
                WEBSITE:</td>
            <td align="left">
                <input id="txt_coy_web" runat="server" class=" textbox" name="txt_coy_web" size="87" type="text" /></td>
        </tr>
       

    <tr>
            <td align="left" style="width:150px;">
                DATE OF INCORPORATION:</td>
            <td align="left">
                <input id="txt_doi" runat="server" class="txt_date_pri textbox" name="txt_mobile" size="40" type="text" />
            </td>
        </tr>
       

    <tr>
            <td align="left" colspan="2" class="sub_header">
                CONTACT INFORMATION &gt;&gt;</td>
        </tr>
       

    <tr>
            <td align="left" style="width:150px;">
                FULLNAME:</td>
            <td align="left">
                <input id="txt_cont_fullname" runat="server" class=" textbox" name="txt_cont_fullname" size="87" type="text" /></td>
        </tr>
       

    <tr>
            <td align="left" style="width:150px;">
                MOBILE:</td>
            <td align="left">
                <input id="txt_cont_mobile" runat="server" class=" textbox" name="txt_cont_mobile" size="87" type="text" /></td>
        </tr>
       

    <tr>
            <td align="left" colspan="2" class="sub_header">
                LOGIN INFORMATION &gt;&gt; </td>
        </tr>
       

    <tr>
            <td align="left" style="width:150px;">
                PASSWORD:</td>
            <td align="left">
                <input id="txt_xpass" runat="server" class="textbox" name="txt_xpass" size="87" type="password" /></td>
        </tr>       

  
       
        <tr>
            <td align="center" colspan="2" style="background-color:#666;">
                 </td>
        </tr>
       

    <tr>
            <td align="center" colspan="2">
                  <div id="acc_error_img" style="display:none;"><img src="../images/delete.png"  /></div>
              <div id="acc_error_msg" style="display:none;"></div> 
             <div id="acc_success_img" style="display:none;"><img src="../images/check.png"  /></div>
            <div id="acc_success_msg" style="display:none;"></div>  

                <input id="btnAddAgent" runat="server" class="button" onserverclick="btnAddAgent_ServerClick" onclick="doChill();" type="button" value="Add Agent" />
               </td>
        </tr>
       

    </table>
       
        </div>
    </div>
</div>
    </form>
</body>
</html>
