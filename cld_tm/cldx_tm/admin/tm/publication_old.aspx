<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="publication_old.aspx.cs" Inherits="cld.admin.tm.publication_old" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>PUBLICATION DATA</title>
    <link rel="stylesheet" type="text/css" href="../../css/style.css" />

<link rel="stylesheet" href="../../css/jquery.ui.all.css" />

<script type="text/javascript" src="../../js/jquery.js"></script>

<script type="text/javascript" src="../../ui/jquery.cookie.js"></script>

<script type="text/javascript" src="../../ui/jquery.ui.core.js"></script>

<script type="text/javascript" src="../../ui/jquery.ui.widget.js"></script>

<script type="text/javascript" src="../../ui/jquery.ui.datepicker.js"></script>

<script type="text/javascript" src="../../ui/jquery.ui.position.js"></script>

<script type="text/javascript" src="../../ui/jquery.ui.autocomplete.js"></script>
<script src="../../js/funk.js" type="text/javascript"></script>
<script language="javascript" type="text/javascript">
    function doPostResults(eu) {
        postwith('./publication.aspx', { eu: eu });
    }

	</script>
<script type="text/javascript">
    $(function () {
        $("table tr:nth-child(even)").addClass("striped");
    });
</script>

<script type="text/javascript">
    $(function () {
        $("#datepickerFrom").datepicker();
    });
    $(function () {
        $("#datepickerTo").datepicker();
    });		
		
</script>

<script type="text/javascript">
    $(function () {
        var availableTags = [""];
        $("#kword").autocomplete({
            source: availableTags
        });
    });
</script>
</head>
<body>
    <form id="form1" runat="server">
   <div>
    <div class="container">
        <div class="sidebar">
           <a href="./publication_unit/profile.aspx">PROFILE</a> <a href="../../cp.aspx?x=<% Response.Write(admin); %>">CHANGE PASSWORD</a> <a href="./publication_unit/ped.aspx">VIEW STATISTICS</a>
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
            <table width="100%" class="form">
          <tr>
            <td colspan="8"  class="tbbg"> WELCOME TO THE PUBLICATION UNIT</td>
          </tr>
          <tr class="stripedout">
            <td colspan="8" align="center">
            <asp:Button ID="btnReloadPage" runat="server" Text="RELOAD PAGE" class="button" 
                    onclick="btnReloadPage_Click" />
              </td>
          </tr>
         
          <tr>
            <td colspan="8" class="tbbg">&nbsp;PLEASE SEARCH FOR ENTRIES BELOW</td>
          </tr>
          
          <tr class="stripedout">
            <td colspan="8" align="center" ><%Response.Write(criteria); %></td>
          </tr>
          
          <tr >
            <td colspan="8" align="center" class="tbbg"><asp:DropDownList ID="selectSearchCriteria" runat="server" AutoPostBack="False">
                <asp:ListItem Text="TRADEMARK" Value="product_title"></asp:ListItem>
                <asp:ListItem Text="APP NUMBER" Value="app_number"></asp:ListItem>
                </asp:DropDownList>
&nbsp;&nbsp;

              key word:&nbsp;
              <input name="kword" type="text" id="kword"  size="50"   value="" runat="server"/>
              
              From :
              <input type="text" id="datepickerFrom" runat="server"/>
              &nbsp;
              To :
              <input type="text" id="datepickerTo" runat="server"/>
              &nbsp;</td>
          </tr>
         <tr class="stripedout">
            <td colspan="8" align="center">            
                <asp:Button ID="btnSearch" runat="server" Text="SEARCH" class="button" 
                    onclick="btnSearch_Click"   />
                <br />
                <strong>Pages <% Response.Write(eu + 1);%> of <%if (pages.Count < 1) { Response.Write("1"); } else { Response.Write(pages.Count); }%> . Total records = <%=nume %> </strong>
              </td>
            </tr>          
         
          <tr >
            <td colspan="8" align="center"><strong><% foreach (string s in pages) { Response.Write(s + " "); }%></strong></td>
            </tr>
          <tr >
            <td  colspan="8" align="center">&nbsp;</td>
            </tr>        
         
          <tr >
            <td width="5%" class="tdcolheader">S/N</td>
            <td width="20%" class="tdcolheader">REGISTRATION NUMBER</td>
            <td width="15%" class="tdcolheader">PRODUCT TITLE</td>
            <td width="20%" class="tdcolheader">TM TYPE</td>
            <td width="15%" class="tdcolheader">OAI No. </td>
            <td width="10%" class="tdcolheader">Enrolled On</td>
            <td width="10%" class="tdcolheader">Status</td>
            <td width="5%" class="tdcolheader">&nbsp;</td>
            </tr>
           <%if (lt_mi.Count > 0)
             {
                 int sn = Convert.ToInt32(dis.ToString());
                 for (int i = 0; i < lt_mi.Count; i++)
                 { %> 
        <tr>
            <td align="center">
                <%=sn %>
            </td>
            <td align="center">
                <%=lt_mi[i].reg_number.ToString() %>
            </td>
            <td  align="center">
                <%= lt_mi[i].product_title.ToString() %>
            </td>
            <td align="center">
                <%= z.getTmTypeByID(lt_mi[i].tm_typeID.ToString()) %>
            </td>
            <td align="center">
               <% =z.getValidationIDFromMarkId(lt_mi[i].xID) %>
            </td>
            <td align="center">
                <%= lt_mi[i].reg_date.ToString() %>
            </td>
            <td align="center">
                <% if( z.getTmOfficeByMID(lt_mi[i].log_staff)!="") { Response.Write(z.getTmOfficeByMID(lt_mi[i].log_staff));} else { Response.Write("None");}%></td>
            <td align="center">
               <a href="publication_data_detailsx.aspx?x=<%= lt_mi[i].xID.ToString() %>">View</a>
            </td>
        </tr>
        <% sn++; } 
             }%>
             <tr >
            <td colspan="8" align="center" class="tbbg">&nbsp;</td>
            </tr>
             <tr >
            <td colspan="8" align="center"><strong><% foreach (string s in pages) { Response.Write(s + " "); }%></strong></td>
            </tr>
             <tr >
            <td colspan="8" align="center"><strong>Pages <% Response.Write(eu + 1);%> of <%if (pages.Count < 1) { Response.Write("1"); } else { Response.Write(pages.Count); }%> . Total records = <%=nume %> </strong></td>
            </tr>
          </table>
        </div>
    </div>
</div>
</div>
    </form>
</body>
</html>
