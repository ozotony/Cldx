<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="preview_x.cs" Inherits="cld.admin.tm.preview_x" %>

<%--<%@ Register src="preview_cert_data.ascx" tagname="preview_cert_data" tagprefix="uc1" %>

<%@ Register src="preview_x_data.ascx" tagname="preview_x_data" tagprefix="uc2" %>--%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

    <div>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    
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
