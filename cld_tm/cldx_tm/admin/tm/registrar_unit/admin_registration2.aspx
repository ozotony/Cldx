<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin_registration2.aspx.cs" Inherits="cld.admin.tm.registrar_unit.admin_registration2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>USER  MANAGEMENT</title>
<link rel="stylesheet" href="../../../css/jquery.ui.all.css" type="text/css"/>
<link rel="stylesheet" href="../../../css/jquery.ui.theme.css" type="text/css"/>
<link rel="stylesheet" href="../../../css/jquery.ui.tabs.css" type="text/css"/>

<link href="../../../css/style.css" rel="stylesheet" type="text/css" />    

<script src="../../../js/jquery-1.7.2.min.js" type="text/javascript"></script>
<script src="../../../js/jquery-ui-1.8.16.custom.min.js" type="text/javascript"></script>
<script src="../../../css/ui/jquery.cookie.js" type="text/javascript"></script>
<script src="../../../css/ui/jquery.ui.core.js" type="text/javascript"></script>
<script src="../../../css/ui/jquery.ui.widget.js" type="text/javascript"></script>
<script src="../../../css/ui/jquery.ui.tabs.js" type="text/javascript"></script>
<script src="../../../css/ui/jquery.ui.datepicker.js" type="text/javascript"></script>
<script src="../../../css/ui/jquery.ui.timepicker.js" type="text/javascript"></script>
<script src="../../../css/ui/jquery-ui-sliderAccess.js" type="text/javascript"></script>
<script src="../../../js/aj.js" type="text/javascript"></script>

      <script src="../../../js/sweet-alert.min.js"></script>
<link href="../../../css/sweet-alert.css" rel="stylesheet" />

    <script type="text/javascript">
        function showDialogue(m) {
            swal ("",m ,"error")
    



     }
        </script> 
   

<script type="text/javascript">
    $(function () {
        //$( "#tabs" ).tabs({ event: "mouseover"});
        $( "#tabs" ).tabs({	cookie: {expires: 1	}}); 
        //$('#tabs-4').load('registerbiox2.php');
        //$('#tabs-2').load('eimscrap.php #active_students');
        $("#tabs").tabs({
            ajaxOptions: {
                error: function (xhr, status, index, anchor) {
                    $(anchor.hash).html(
						"Couldn't load this tab. We'll try to fix this as soon as possible. " +
						"If this wouldn't be a demo.");
                }
            }
        });
    });
	</script>

</head>
<body>
    <form id="form1" runat="server">
    <div class="container">
        <div class="sidebar">
            <a href="./tm_profile.aspx">PROFILE</a>
             <a href="../../cp.aspx?x=<% Response.Write(admin); %>">CHANGE PASSWORD</a>
             
        </div>
        <div class="content">
            <div class="header">
                <div class="xmenu">
                    <div class="menu">
                       
                    </div>
                </div>
                <div class="xlogo">
                    <div class="xlogo_l">
                    </div>
                    <div class="xlogo_r">
                    </div>
                </div>
            </div>

    <div id="tabs">
	<ul>
		<li><a href="#add_tab">ADD USER</a>
        </li>
		<%--<li><a href="#edit_tab">EDIT ADMIN</a>
        </li>--%>
		
        
	</ul>
    <!-- +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++ --> 
    <div id="add_tab">
    <% if (x_add_tbl == 1)
  { %>
     <div id="searchform">
            <table align="center" width="100%" class="form">
        <tr>
            <td colspan="2" align="left" class="tbbg">
               USER REGISTRATION
            </td>
        </tr>
        
        <tr>
            <td width="30%">
                &nbsp;&nbsp;NAME:
            </td>
            <td>
                <asp:TextBox ID="xname" runat="server" Width="400px" 
                    CssClass="textbox" ></asp:TextBox>
                     <% if (name_text == "1")
                   { %>
                &nbsp;<img src="../../images/arrow-left.gif" alt="" width="16px" 
                    height="16px" />
                <% } if (enable_Save == "0")
                   { %><img src="../../images/checkmark.gif" alt="" width="16px" 
                    height="16px" />
                <% }%>               
                                   
                </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;&nbsp;ROLE :
            </td>
            <td align="left">
                <asp:DropDownList ID="xrole" runat="server" CssClass="textbox" 
                    DataSourceID="dsRole" DataTextField="name" DataValueField="ID" >
                </asp:DropDownList>
                <asp:SqlDataSource ID="dsRole" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:cldConnectionString %>" 
                    SelectCommand="SELECT * FROM [roles] where priv  not in (1,14)"></asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;&nbsp;E-MAIL :             </td>
            <td align="left">
                <asp:TextBox ID="xemail" runat="server" Width="400px" CssClass="textbox" AutoPostBack="true" ontextchanged="TextBox1_TextChanged" ></asp:TextBox>
                <% if (email_text == "1")
                   { %>
                &nbsp;<img src="../../images/arrow-left.gif" alt="" width="16px" height="16px" />
                <% } if (enable_Save == "0")
                   { %><img src="../../images/checkmark.gif" alt="" width="16px" height="16px" />
                <% }%>
            </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;&nbsp;TELEPHONE 1 :
            </td>
            <td align="left">
            <asp:TextBox ID="xtelephone1" runat="server" Width="400px" CssClass="textbox"></asp:TextBox>
                <% if (telephone1_text == "1")
                   { %>
                &nbsp;<img src="../../images/arrow-left.gif" alt="" width="16px" height="16px" />
                <% } if (enable_Save == "0")
                   { %><img src="../../images/checkmark.gif" alt="" width="16px" height="16px" />
                <% }%>
            </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;&nbsp;TELEPHONE 2&nbsp; :
            </td>
            <td align="left">
                <asp:TextBox ID="xtelephone2" runat="server" Width="400px" CssClass="textbox" ></asp:TextBox>
                <% if (telephone2_text == "1")
                   { %>
                &nbsp;<img src="../../images/arrow-left.gif" alt="" width="16px" height="16px" />
                <% } if (enable_Save == "0")
                   { %><img src="../../images/checkmark.gif" alt="" width="16px" height="16px" />
                <% }%>
            </td>
        </tr>
         <% if (enable_Captcha == "1") { %>
        <tr>
            <td class="tbbg" colspan="2">
                Please note that the letters below are not case sensitive!!!
            </td>
        </tr>
        <tr>
            <td align="right">
                <img alt="captcha" src="../../../Handler.ashx" />
            </td>
            <td>
                &nbsp;Enter Code :
                <asp:TextBox ID="xcode" runat="server" Width="70px" CssClass="textbox"></asp:TextBox>
                <% if (xcode_text == "1")
                   { %>
                &nbsp;&nbsp;<img src="../../images/arrow-left.gif" alt="" width="16px" height="16px" />
                <% } if (enable_Save == "0")
                   { %>
                <img src="../../images/checkmark.gif" alt="" width="16px" height="16px" />
                <% }%>
            </td>
        </tr>
        
        <% } %>
                
        <tr>
            <td class="tbbg" colspan="2">
                <% if (enable_Confirm == "0")
                   { %>
                <asp:Button ID="ConfirmDetails" runat="server" Text="Confirm Details" OnClick="ConfirmDetails_Click" class="button" />
               
                <% }if (enable_Save == "0")
                   { %>
                <asp:Button ID="Save" runat="server" Text="Save & Continue" OnClick="Save_Click" class="button" />
                <% }%>
            </td>
        </tr>
    </table>
        </div> 
        <% } %>
<% if (x_add_succ == 1)
  { %>
    <table align="center" width="100%" class="form">
        <tr>
            <td align="left" class="tbbg">
                USER REGISTRATION
            </td>
        </tr>
        
        <tr>
            <td width="30%" align="center">YOU HAVE SUCCESSFULLY COMPLETED THE REGISTRATION<br />AN E-MAIL HAS BEEN SENT TO YOU</td>
        </tr>
        <tr>
            <td align="left" class="tbbg"> 
                <asp:Button ID="btn_menu" runat="server" Text="BACK TO MENU" onclick="btn_menu_Click" />
            </td>
        </tr>
       
    </table>
<% } %>
    </div>

    <!-- +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++ --> 
    <div id="edit_tab">
     <% if (x_edit_tbl == 1)
  { %>
   
        <% } %>
<% if (x_edit_succ == 1)
  { %>
    <table align="center" width="100%" class="form">
        <tr>
            <td align="left" class="tbbg">
                ADMINSTRATOR REGISTRATION UPDATE&nbsp;
            </td>
        </tr>
        
        <tr>
            <td width="30%" align="center">YOU HAVE SUCCESSFULLY COMPLETED THE UPDATE PROCESS<br />AN E-MAIL HAS BEEN SENT TO YOU</td>
        </tr>
        <tr>
            <td align="left" class="tbbg"> 
                <asp:Button ID="EditBack" runat="server" Text="BACK TO MENU" 
                    onclick="EditBack_Click"  />
            </td>
        </tr>
       
    </table>
<% } %>
    </div>

     <!-- +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++ --> 
   

      <!-- +++++++++++++++++++++++++++++++++++++++++++++ END TABS +++++++++++++++++++++++++++++++++++++++++++ --> 
    </div>

    </div>
    </div>
    </form>
</body>
</html>