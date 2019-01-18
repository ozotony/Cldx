<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="edit_status2.aspx.cs" Inherits="cld.admin.tm.acceptance_unit.edit_status2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
<link href="../../../css/style.css" rel="stylesheet" type="text/css" />
<script src="../../../js/funk.js" type="text/javascript"></script>

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
                <% if(showt==0) {%>
             <table align="center" width="100%" >
        <tr>
            <td colspan="2" align="left" class="tbbg">
                ENTER REFERENCE/APPLICATION NUMBER BELOW  
            </td>
        </tr>
        
        <tr>
            <td width="30%">
                &nbsp;&nbsp;APPLICATION 
                NUMBER:
            </td>
            <td>
                <asp:TextBox ID="xref" runat="server" Width="400px" 
                    CssClass="textbox" ></asp:TextBox>
                   
                &nbsp;                             
                                   
                </td>
        </tr>
        
        <tr>
            <td width="30%">
                &nbsp;</td>
            <td>
                <asp:Button ID="SearchApplicant" runat="server" Text="Search For Trademark" 
                    class="button" onclick="SearchApplicant_Click" />
                                   
                </td>
        </tr>
        <tr>
            <td width="30%" colspan="2" align="center">
               <% Response.Write(trans_status); %></td>
        </tr>
        </table>
         <% }%>
            <% if (showt == 1)
               {%>

  <table align="center" width="100%" class="form">
        <tr>
            <td colspan="2" align="left" class="tbbg">
                PLEASE UPDATE THE &quot;STATUS&quot; DETAILS BELOW
            </td>
        </tr>
       
        <tr>
            <td width="22%" colspan="2" align="center">
                 <% Response.Write(trans_status); %></td>
        </tr>
       
        <tr>
            <td width="22%">
                &nbsp;OFFICE/STATUS&nbsp; : </td>
            <td>
                <asp:DropDownList ID="select_xoffice" runat="server" CssClass="textbox">
                <asp:ListItem Value="Fresh|1" Text="Verification-New Application"></asp:ListItem>
                <asp:ListItem Value="Valid|2" Text="Search 1-New Application"></asp:ListItem>
                <asp:ListItem Value="Re-conduct search|2" Text="Search 1-Re-conduct search"></asp:ListItem>
                <asp:ListItem Value="Search Conducted|3" Text="Search 2-New Application"></asp:ListItem>
                <asp:ListItem Value="Re-conduct search 1|22" Text="Search 2-Re-conduct search 1"></asp:ListItem>
                <asp:ListItem Value="Search 2 Conducted|33" Text="Examiners-New Application"></asp:ListItem>
                <asp:ListItem Value="Re-examine|3" Text="Examiners-Re-examination"></asp:ListItem>
                <asp:ListItem Value="Registrable|4" Text="Acceptance-New Application"></asp:ListItem>
                <asp:ListItem Value="Refused|4" Text="Acceptance-Refused"></asp:ListItem>
                </asp:DropDownList>               
            </td>
        </tr>
        <tr>
            <td width="22%" class="style1">
                &nbsp;COMMENT:
            </td>
            <td class="style1">
                <asp:TextBox ID="txt_comment" runat="server" Width="400px" CssClass="textbox" 
                    Height="50px" TextMode="MultiLine"></asp:TextBox>              
            </td>
        </tr>
       
       <tr>
            <td>
                 <asp:Label ID="appID" runat="server" ForeColor="White"></asp:Label>
                  <asp:Label ID="addressID" runat="server" ForeColor="White"></asp:Label>
                  </td>
            <td>
                <asp:Button ID="UpdateApplicant" runat="server" Text="Update Status" 
                    class="button" onclick="UpdateApplicant_Click"  />
                                   
            </td>
        </tr>        
    </table>
     <% } %>
        </div>
    </div>
</div>
    </form>
</body>
</html>
