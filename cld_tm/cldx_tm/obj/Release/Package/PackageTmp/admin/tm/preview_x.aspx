<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="preview_x.aspx.cs" Inherits="cld.admin.tm.preview_x2" %>

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
            $("#datepickerFrom").datepicker();
        });
        $(function () {
            $("#datepickerTo").datepicker();
        });

</script>

</head>
<body>
    <form id="form1" runat="server">

    <div>
       <table width="100%" border="0" id="insert_news" bgcolor="#efefef" class="form">
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

             <tr class="stripedout">
                        <td colspan="8" align="center">
                            <asp:Button ID="Button1" runat="server" Text="Search" OnClick="Button1_Click" />
                           
                        </td>
                    </tr>

           </table>
    
       <%-- <uc2:preview_x_data ID="preview_x_data1" runat="server" />--%>
          <asp:GridView ID="greport" runat="server"  AutoGenerateColumns="False" CaptionAlign="Left" CellPadding="4" EnableModelValidation="True" ForeColor="#000000" GridLines="Both" HorizontalAlign="Left"     style="margin-top: 0px; width:100%; font-size:12px;">
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

                        <asp:BoundField DataField="reg_date" HeaderText="Enrolled On" /> 
                         <asp:BoundField DataField="Status" HeaderText="Status" />
       
                          <asp:TemplateField HeaderText="VIEW" >
                             <ItemTemplate>
                              <asp:HyperLink ID="btnnewTab" Text="View" runat="server" Target="_blank" NavigateUrl='<%# string.Format("preview_x_details.aspx?x={0}", Eval("xid")) %>' />
                             </ItemTemplate>
                              <HeaderStyle HorizontalAlign="Left" Width="40px"/>
                             <ItemStyle HorizontalAlign="Left" />
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
    </form>
</body>
</html>
