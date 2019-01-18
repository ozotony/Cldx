<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="preview_x_data.ascx.cs" Inherits="cld.admin.tm.preview_x_data" %>
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
      $(function() {
        $("table tr:nth-child(even)").addClass("striped");
      });
</script>

<script type="text/javascript">
	$(function() {
		$( "#datepickerFrom" ).datepicker();
	     });
		 $(function() {
		$( "#datepickerTo" ).datepicker();
	     });		
		
</script>

<script type="text/javascript">
    $(function() {
        var availableTags = [""];
        $("#kword").autocomplete({
            source: availableTags
        });
    });
</script>

<div>
    <div class="container">
        <div class="sidebar">
            <a href="./x_unit/profile.aspx">PROFILE</a> 
            <a href="../../cp.aspx?x=<% Response.Write(admin); %>">CHANGE PASSWORD</a>
             <a href="./x_unit/profile.aspx">VIEW STATISTICS</a>
             <a href="./preview_x.aspx?x=1&d=Invalid">INVALID APPS</a>
             <a href="./preview_x.aspx?x=2&d=Valid">VALID APPS</a>
             <a href="./preview_x.aspx?x=3&d=Approved">APPROVED APPS</a>
             <a href="./preview_x.aspx?x=1&d=Disapproved">DISAPPROVED APPS</a>
               <a href="./preview_x.aspx?x=4&d=Registrable">EXAMINED APPS</a>               
              <a href="./preview_x.aspx?x=5&d=Accepted">ACCEPTED APPS</a>
               <a href="./preview_x.aspx?x=3&d=Refused">UN-ACCEPTED APPS</a> 
               <a href="./preview_x.aspx?x=6&d=Published">PUBLISHED APPS</a>               
                <a href="./preview_x.aspx?x=7&d=Not Opposed">UNOPPOSED APPS</a> 
                <a href="./preview_x.aspx?x=5&d=Opposed">OPPOSED APPS</a>               
                <a href="./preview_x.aspx?x=8&d=Certified">CERTIFIED APPS</a>
                <a href="./preview_x.aspx?x=9&d=Registered">REGISTERED APPS</a>
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
               <%-- <table width="100%" border="0" id="insert_news" bgcolor="#efefef" class="form">
                    <tr>
                        <td colspan="8" align="center" class="tbbg">
                         VIEW ALL "<% Response.Write(xtitle); %>" APPLICATIONS
                        </td>
                    </tr>
                    <tr class="stripedout">
                        <td colspan="8" align="center">
                            &nbsp;<input type="button" name="Reload" id="Reload" value="Reload page" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="8" class="tbbg">
                            &nbsp;PLEASE SEARCH FOR ENTRIES BELOW
                        </td>
                    </tr>
                    <tr class="stripedout">
                        <td colspan="8" align="center">
                            Result(s) found for criteria ()!!
                        </td>
                    </tr>
                    <tr>
                        <td colspan="8" align="center" class="tbbg">
                            <asp:DropDownList ID="selectSearchCriteria" runat="server" AutoPostBack="True" >
                                <asp:ListItem Text="SELECT CRITERIA" Value=""></asp:ListItem>
                                <asp:ListItem Text="PRODUCT TITLE" Value="title"></asp:ListItem>
                                <asp:ListItem Text="REG NUMBER" Value="reg_number"></asp:ListItem>
                                <asp:ListItem Text="TM TYPE" Value="tm_type"></asp:ListItem>
                                <asp:ListItem Text="STATUS" Value="status"></asp:ListItem>
                            </asp:DropDownList>
                            &nbsp;&nbsp; key word:&nbsp;
                            <input name="kword" type="text" id="kword" size="20" value="" />
                            From :
                            <input type="text" id="datepickerFrom" />
                            &nbsp; To :
                            <input type="text" id="datepickerTo" />
                            &nbsp;
                        </td>
                    </tr>
                    <% if (criteria_type == "tm_type")
            { %>
                    <tr>
                        <td colspan="8" align="center">
                            TM TYPE: &nbsp;&nbsp;
                            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True">
                                <asp:ListItem Text="" Value="SELECT AN OPTION"></asp:ListItem>
                                <asp:ListItem Text="LOCAL" Value="LOCAL"></asp:ListItem>
                                <asp:ListItem Text="FOREIGN" Value="FOREIGN"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <% }%>
                    <% if (criteria_type == "status")
            { %>
                    <tr>
                        <td colspan="8" align="center">
                            Status : &nbsp;&nbsp;
                            <asp:DropDownList ID="ddl_Status" runat="server" AutoPostBack="True">
                                <asp:ListItem Text="" Value="SELECT AN OPTION"></asp:ListItem>
                                <asp:ListItem Text="NONE" Value="NONE"></asp:ListItem>
                                <asp:ListItem Text="VALID" Value="VALID"></asp:ListItem>
                                <asp:ListItem Text="INVALID" Value="INVALID"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <% }%>
                    <tr class="stripedout">
                        <td colspan="8" align="center">
                            <input type="button" name="Search" id="Search" value="Search" onclick="doEnrolleeSearch()" class="button" />
                        </td>
                    </tr>
                    <tr>
                        <td width="5%" class="tdcolheader">
                            S/N
                        </td>
                        <td width="20%" class="tdcolheader">
                            REGISTRATION NUMBER
                        </td>
                        <td width="15%" class="tdcolheader">
                            PRODUCT TITLE
                        </td>
                        <td width="20%" class="tdcolheader">
                            TM TYPE
                        </td>
                        <td width="15%" class="tdcolheader">
                            OAI No. 
                        </td>
                        <td width="10%" class="tdcolheader">
                            Enrolled On
                        </td>
                        <td width="10%" class="tdcolheader">
                            Status
                        </td>
                        <td width="5%" class="tdcolheader">
                            &nbsp;
                        </td>
                    </tr>
                    <%if (lt_mi.Count > 0)
             {
                 int sn = 1;
                 for (int i = 0; i < lt_mi.Count; i++)
                 { %>
                    <tr>
                        <td width="5%" align="center">
                            <%=sn %>
                        </td>
                        <td width="20%" align="center">
                            <%=lt_mi[i].reg_number.ToString() %>
                        </td>
                        <td width="15%" align="center">
                            <%= lt_mi[i].product_title.ToString() %>
                        </td>
                        <td width="20%" align="center">
                            <%= z.getTmTypeByID(lt_mi[i].tm_typeID.ToString()) %>
                        </td>
                        <td width="20%" align="center">
                           <% =z.getValidationIDFromMarkId(lt_mi[i].xID) %>
                        </td>
                        <td width="15%" align="center">
                            <%= lt_mi[i].reg_date.ToString() %>
                        </td>
                        <td width="15%" align="center">
                            <% if( z.getTmOfficeByMID(lt_mi[i].log_staff)!="") { Response.Write(z.getTmOfficeByMID(lt_mi[i].log_staff));} else { Response.Write("None");}%>
                        </td>
                        <td width="5%" align="center">
                            <a href="preview_x_details.aspx?x=<%= lt_mi[i].xID.ToString() %>">View</a>
                        </td>
                    </tr>
                    <% sn++; } 
             }%>
                </table>--%>

                 <asp:GridView ID="gvX" runat="server" AllowPaging="True" AutoGenerateColumns="False" CaptionAlign="Left" CellPadding="4" EnableModelValidation="True" ForeColor="#000000" GridLines="Both" HorizontalAlign="Left"     style="margin-top: 0px; width:100%; font-size:12px;">
                    <AlternatingRowStyle BackColor="White" />
                   <Columns>
        <asp:BoundField DataField="reg_number" HeaderText="Registration Number" />
        <asp:BoundField DataField="product_title" HeaderText=" PRODUCT TITLE" />
        <asp:TemplateField HeaderText="TM TYPE">
    <ItemTemplate>
        <%# z.getTmTypeByID(Eval("tm_typeID").ToString() ) %>
    </ItemTemplate>
    <ItemStyle HorizontalAlign="Right" />
</asp:TemplateField>

                        <asp:TemplateField HeaderText="OAI No">
    <ItemTemplate>
        <%# z.getValidationIDFromMarkId(Eval("xid").ToString() ) %>
    </ItemTemplate>
    <ItemStyle HorizontalAlign="Right" />
</asp:TemplateField>
       
                              <%-- <asp:BoundField DataField="UnitPrice" HeaderText="Unit Price" DataFormatString="{0:#0.00}" >
            <ItemStyle HorizontalAlign="Right" />
        </asp:BoundField>
        <asp:BoundField DataField="Quantity" HeaderText="Quantity" >
            <ItemStyle HorizontalAlign="Right" />
        </asp:BoundField>
        <asp:BoundField DataField="Discount" HeaderText="Discount" DataFormatString="{0:#0.00}" >
            <ItemStyle HorizontalAlign="Right" />
        </asp:BoundField>
        <asp:TemplateField HeaderText="Amount">
            <ItemTemplate>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Right" />
        </asp:TemplateField>--%>
    </Columns>
                    <EditRowStyle BackColor="#7C6F57" />
                    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#E3EAEB" />
                    <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                </asp:GridView>

            </div>
        </div>
    </div>
</div>
