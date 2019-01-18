<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="searcho3.aspx.cs" Inherits="cld.admin.tm.searcho3" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
<link rel="stylesheet" type="text/css" href="../../css/style.css" />

<link rel="stylesheet" href="../../css/jquery.ui.all.css" />

<script type="text/javascript" src="../../js/jquery.js"></script>

<script type="text/javascript" src="../../ui/jquery.cookie.js"></script>

<script type="text/javascript" src="../../ui/jquery.ui.core.js"></script>

<script type="text/javascript" src="../../ui/jquery.ui.widget.js"></script>

<script type="text/javascript" src="../../ui/jquery.ui.datepicker.js"></script>

<script type="text/javascript" src="../../ui/jquery.ui.position.js"></script>

<script type="text/javascript" src="../../ui/jquery.ui.autocomplete.js"></script>
<script type="text/javascript">
    $(function () {
        $(".xtreme  tr:nth-child(even)").addClass("striped"); $(".xtreme  tr:nth-child(odd)").addClass("stripedout");
    });
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
                            <li><a href="./lo.aspx">
                                <img alt="" src="../../images/logoff.png" width="16" height="16" />Log off</a></li>
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
            <table width="100%"  border="0" id="insert_news" bgcolor="#efefef" class="form">
          <tr>
            <td colspan="8" align="center" class="tbbg">WELCOME TO THE SEARCH UNIT (PLEASE 
                SEARCH FOR ENTRIES BELOW)</td>
          </tr>
                <tr class="stripedout">
                    <td colspan="8" align="center">
                        &nbsp;
                    </td>
                </tr>
               
                <tr>
                    <td colspan="8" align="center" class="tbbg">
                        &nbsp;&nbsp; 
                        CLASS :
                        &nbsp;&nbsp;<asp:DropDownList ID="selectSearchCriteria"  runat="server" AutoPostBack="False">
                </asp:DropDownList>
                        &nbsp;TRADE MARK KEYWORD(S) :&nbsp;
                        <input name="kword" type="text" id="kword" size="70"   value="" runat="server"/></td>
                </tr>
               
                <tr class="stripedout">
                    <td colspan="8" align="center">
                <asp:Button ID="btnSearch" runat="server" Text="SEARCH" class="button" 
                            onclick="btnSearch_Click"  />
            &nbsp;</td>
                </tr>
                <tr>
                    <td class="" colspan="8">
                        &nbsp;</td>
                </tr>
           
             <% Response.Write(xresults); %> 

              <tr>
                    <td class="" colspan="8" align="center">
                    <asp:HiddenField ID="xsearchstr" runat="server" />
                    <asp:HiddenField ID="xsearchcri" runat="server" />
                   <asp:HiddenField ID="xxclass" runat="server" />
                    <asp:HiddenField ID="xmarkID" runat="server" />
                    <asp:HiddenField ID="xlof_officer" runat="server" />
                       <asp:Button ID="btnAttach" runat="server" Visible="false" Text="Attach Results" class="button" 
                            onclick="btnAttach_Click"/>
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
