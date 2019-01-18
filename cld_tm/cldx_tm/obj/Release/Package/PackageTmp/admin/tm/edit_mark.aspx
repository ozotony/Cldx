<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="edit_mark.cs" Inherits="cld.admin.tm.edit_mark" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
<link href="../../css/style.css" rel="stylesheet" type="text/css" />
<script src="../../js/funk.js" type="text/javascript"></script>

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
  <% if (showsearch == "1")
                   { %>
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
                <asp:TextBox ID="searchno" runat="server" Width="400px" 
                    CssClass="textbox" ></asp:TextBox>
                   
                &nbsp;                             
                                   
                </td>
        </tr>
        
        <tr>
            <td width="30%">
                &nbsp;</td>
            <td>
                <asp:Button ID="SearchApplicant" runat="server" Text="Search For Mark" 
                    class="button" onclick="SearchApplicant_Click" />
                                   
                </td>
        </tr>
        <% if (showsucc == "1")
                   { %>
        <tr>
            <td width="30%" colspan="2" align="center">
                <% Response.Write(succ_text); %> </td>
        </tr>
         <% } %>
        </table>
         <% } %>
         <% if (showupdateform == "1")
                   { %>
    <table align="center" width="100%" class="form">
                <tr>
                    <td colspan="2" align="left" class="tbbg">
                        &nbsp;PLEASE UPDATE THE &quot;TRADEMARK&quot; DETAILS BELOW
                    </td>
                </tr>
                <tr>
                    <td width="30%">
                        &nbsp;&nbsp;TRADEMARK TYPE :
                    </td>
                    <td>
                        <asp:SqlDataSource ID="ds_TmType" runat="server" ConnectionString="<%$ ConnectionStrings:cldConnectionString %>" SelectCommand="SELECT DISTINCT [xID], [type] FROM [tm_type]"></asp:SqlDataSource>
                        <asp:DropDownList ID="tmType" runat="server" DataSourceID="ds_TmType" DataTextField="type" DataValueField="xID" CssClass="textbox">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        &nbsp;&nbsp;LOGO DESCRIPTION :
                    </td>
                    <td align="left">
                        <asp:SqlDataSource ID="ds_LogoDescription" runat="server" ConnectionString="<%$ ConnectionStrings:cldConnectionString %>" SelectCommand="SELECT DISTINCT [xID], [type] FROM [logo_description]"></asp:SqlDataSource>
                        <asp:DropDownList ID="logo_description" runat="server" DataSourceID="ds_LogoDescription" DataTextField="type" DataValueField="xID" CssClass="textbox" AutoPostBack="True" OnSelectedIndexChanged="logo_description_SelectedIndexChanged">
                            <asp:ListItem Value="0" Text="PLEASE SELECT AN OPTION" Selected="True"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        &nbsp;&nbsp;TRADEMARK :</td>
                    <td align="left">
                        <asp:TextBox ID="title_of_product" runat="server" Width="400px" CssClass="textbox" Height="50px" TextMode="MultiLine"></asp:TextBox>
                        <% if (title_of_product_text == "1")
                   { %>&nbsp;&nbsp;<img src="../../images/arrow-left.gif" alt="" width="16px" height="16px" />
                        <% } if (enable_Save == "0")
                   { %>
                        <img src="../../images/checkmark.gif" alt="" width="16px" height="16px" />
                        <% }%>
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="2">
                        &nbsp;&nbsp;CLASS 
                        OF SPECIFICATION OF GOODS/SERVICES :
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="2">
                        <asp:TextBox ID="nice_class" runat="server" Width="400px" CssClass="textbox"></asp:TextBox>
                        <% if (nice_class_text == "1")
                   { %>&nbsp;&nbsp;<img src="../../images/arrow-left.gif" alt="" width="16px" height="16px" />
                        <% } if (enable_Save == "0")
                   { %>
                        <img src="../../images/checkmark.gif" alt="" width="16px" height="16px" />
                        <% } %>
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="2">
                        &nbsp;DESCRIPTION OF SPECIFICATION OF GOODS/SERVICES :</td>
                </tr>
                <tr>
                    <td align="center" colspan="2">
                        &nbsp;
                        <asp:TextBox ID="nice_class_desc" runat="server" Height="50px" TextMode="MultiLine" Width="90%" CssClass="textbox"></asp:TextBox>
                        <% if (nice_class_desc_text == "1")
                   { %>&nbsp;<img src="../../images/arrow-left.gif" alt="" width="16px" height="16px" />
                        <% } if (enable_Save == "0")
                   { %>
                        <img src="../../images/checkmark.gif" alt="" width="16px" height="16px" />
                        <% } %>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        &nbsp;&nbsp;GENERAL 
                        GOODS IN THE CLASS :
                    </td>
                    <td align="left">
                        <asp:SqlDataSource ID="ds_NationalClass" runat="server" ConnectionString="<%$ ConnectionStrings:cldConnectionString %>" SelectCommand="SELECT [xID], [type], [description] FROM [national_classes]"></asp:SqlDataSource>
                        <asp:DropDownList ID="national_class" runat="server" DataSourceID="ds_NationalClass" DataTextField="type" DataValueField="xID" OnSelectedIndexChanged="national_class_SelectedIndexChanged" AutoPostBack="True" CssClass="textbox">
                        </asp:DropDownList>
                    </td>
                </tr>
                <% if (xdesc_national_class != "0")
           { %>
                <tr>
                    <td align="left">
                        &nbsp;&nbsp;DESCRIPTION&nbsp; OF GENERAL GOODS:
                    </td>
                    <td align="left">
                        <asp:Label ID="national_class_desc" runat="server"></asp:Label>
                    </td>
                </tr>
                <% } %>
                <tr>
                    <td width="22%">
                        &nbsp;&nbsp;SIGN TYPE :</td>
                    <td>
                        <asp:TextBox ID="sign_type" runat="server" Width="400px" CssClass="textbox"></asp:TextBox>
                        <% if (sign_type_text == "1")
                   { %>&nbsp;&nbsp;<img src="../../images/arrow-left.gif" alt="" width="16px" height="16px" />
                        <% } if (enable_Save == "0")
                   { %>
                        <img src="../../images/checkmark.gif" alt="" width="16px" height="16px" />
                        <% }%>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        &nbsp;&nbsp;VIENNA CLASS :
                    </td>
                    <td align="left">
                        <asp:TextBox ID="vienna_classes" runat="server" Width="400px" CssClass="textbox"></asp:TextBox>
                        <% if (vienna_classes_text == "1")
                   { %>&nbsp;&nbsp;<img src="../../images/arrow-left.gif" alt="" width="16px" height="16px" />
                        <% } if (enable_Save == "0")
                   { %>
                        <img src="../../images/checkmark.gif" alt="" width="16px" height="16px" />
                        <% }  %>
                    </td>
                </tr>
                <tr>
                    <td class="tbbg" colspan="2">
                       --- DISCLAIMER ---</td>
                </tr>
                <tr>
                
                    <td align="center" colspan="2">
                    DO YOU WISH TO DISCLAIM ANY PART OF THE TRADEMARK TO MAKE IT REGISTRABLE?
                        <asp:RadioButtonList ID="rbDisclaimer" runat="server" 
                            RepeatDirection="Horizontal" 
                            onselectedindexchanged="rbDisclaimer_SelectedIndexChanged" AutoPostBack="True">
                    <asp:ListItem Value="YES">YES</asp:ListItem>
                    <asp:ListItem Value="NO" >NO</asp:ListItem>
                </asp:RadioButtonList>
                    </td>
                </tr>
                <% if(disclaimer_text!="0") { %>
                <tr>
                    <td align="center" colspan="2">
                        <asp:TextBox ID="txt_discalimer" runat="server" Width="600px" 
                            CssClass="textbox" Height="50px" TextMode="MultiLine"></asp:TextBox>
                        </td>
                </tr>
                <% }%>
                             
                 <% if (logo_text == "1") { %> 
                <tr>
                    <td align="left">
                        &nbsp; ADD &nbsp;DEVICE &nbsp;IMAGE :
                    </td>
                    <td align="left">
                        <asp:FileUpload ID="logo_pic" runat="server" Height="22px" />
                  <a href="<% Response.Write(logo_pic_lbl.Text); %>" target="_blank"><asp:Label ID="logo_pic_lbl" runat="server" ForeColor="Black" Text=""></asp:Label></a>  
          </td>
                </tr>
                 <% }%>
                <tr>
                    <td colspan="2">
                        &nbsp;
                    </td>
                </tr>
                
                <tr>
                    <td align="left">
                        &nbsp; 
                        POWER OF ATTORNEY: &nbsp;
                    </td>
                    <td align="left">
                        <asp:FileUpload ID="auth_doc" runat="server" />
                <a href="<% Response.Write(auth_doc_lbl.Text); %>" target="_blank"><asp:Label ID="auth_doc_lbl" runat="server" ForeColor="Black" Text=""></asp:Label></a>  
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        &nbsp;&nbsp;SUPPORTING DOCUMENT(S) [IF ANY] :
                    </td>
                    <td align="left">
                        <asp:FileUpload ID="sup_doc1" runat="server" />
                        <a href="<% Response.Write(sup_doc1_lbl.Text); %>" target="_blank"><asp:Label ID="sup_doc1_lbl" runat="server" ForeColor="Black" Text=""></asp:Label></a>
                        </td>
                </tr>
                <tr>
                    <td align="left">
                        &nbsp;</td>
                    <td align="left">
                        <asp:FileUpload ID="sup_doc2" runat="server" />
                       <a href="<% Response.Write(sup_doc2_lbl.Text); %>" target="_blank"><asp:Label ID="sup_doc2_lbl" runat="server" ForeColor="Black" Text=""></asp:Label></a>
                    </td>
                </tr>
                 <tr>
            <td>
                 <asp:Label ID="appID" runat="server" ForeColor="White"></asp:Label>
                  </td>
            <td>
                <asp:Button ID="UpdateApplicant" runat="server" Text="Update Mark" 
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
