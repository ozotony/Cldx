<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="c_trademark.aspx.cs" Inherits="cld.c_trademark" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>TRADEMARK FILING</title>

<link href="css/style.css" rel="stylesheet" type="text/css" />
<script src="js/funk.js" type="text/javascript"></script>


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
            
  <table  id="applicantForm" align="center" width="100%" class="form" >
    <% if (show_image_section == "0")
       {%>
        <tr>
            <td colspan="2" align="left" class="tbbg">
                FORM 1 : PLEASE FILL IN THE APPLICANT/PROPRIETOR 
                INFORMATION DETAILS BELOW  
            </td>
        </tr>
        
        <tr>
            <td width="30%">
                &nbsp;&nbsp;NAME:
            </td>
            <td>
                <asp:TextBox ID="xname" runat="server" Width="400px" 
                    CssClass="textbox"  ReadOnly="true"></asp:TextBox>
                <% if (name_text == "1")
                   { %>&nbsp;<img src="images/checkmark.gif" alt="" width="16px" height="16px" />
                <% } if (enable_AppSave == "0")
                   { %><img src="images/checkmark.gif" alt="" width="16px" height="16px" />
                <% }%>               
                                   
                </td>
        </tr>
        
        <tr>
            <td align="left">
                &nbsp;&nbsp;NATIONALITY :
            </td>
            <td align="left">
                <asp:DropDownList ID="nationality" runat="server" CssClass="textbox" DataSourceID="ds_Nationality" DataTextField="name" 
                    DataValueField="ID" >
                </asp:DropDownList>
                <asp:SqlDataSource ID="ds_Nationality" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:cldConnectionString %>" 
                    SelectCommand="SELECT * FROM [country]"></asp:SqlDataSource>
           </td>
        </tr>        
        <tr>
            <td width="22%" colspan="2" class="tbbg">
                APPLICANT/PROPRIETOR
                ADDRESS INFORMATION DETAILS</td>
        </tr>
        <tr>
            <td width="22%">
                &nbsp;COUNTRY :
            </td>
            <td>
                <asp:DropDownList ID="residence" runat="server" CssClass="textbox" 
                    DataSourceID="ds_DefaultCountry" DataTextField="name" 
                    DataValueField="ID" AutoPostBack="true">
                </asp:DropDownList>
                <asp:SqlDataSource ID="ds_DefaultCountry" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:cldConnectionString %>" 
                    SelectCommand="SELECT * FROM [country]">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="1" Name="ID" Type="Int64" />
                    </SelectParameters>
                </asp:SqlDataSource>
                </td>
        </tr>
         
        <tr>
            <td width="22%">
                &nbsp;STATE:             </td>
            <td>
                <% if (state_row == "0")
                   { %> 
                <asp:DropDownList ID="xselectState" runat="server" CssClass="textbox" 
                    DataSourceID="ds_State" DataTextField="name" DataValueField="ID" >
                </asp:DropDownList>
                <asp:SqlDataSource ID="ds_State" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:cldConnectionString %>" 
                    SelectCommand="SELECT DISTINCT * FROM [state] WHERE ([countryID] = @countryID)">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="residence" DefaultValue="" Name="countryID" 
                            PropertyName="SelectedValue" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <% }
                   else
                   { %>   
                              
                <asp:TextBox ID="xstate" runat="server" Width="100px" CssClass="textbox"></asp:TextBox>
                <% if (state_text == "1")
                   { %>&nbsp;<img src="images/checkmark.gif" alt="" width="16px" height="16px"   />
                <% } if (enable_AppSave == "0")
                   { %>
                <img src="images/checkmark.gif" alt="" width="16px" height="16px" />  
                             <% }  %>
            </td>
        </tr>
        <% } %>
        <tr>
            <td width="22%">
                &nbsp;STREET 
                No.:
            </td>
            <td>
                <asp:TextBox ID="xaddress" runat="server" Width="400px" CssClass="textbox" 
                    Height="50px" TextMode="MultiLine" ReadOnly="true"></asp:TextBox>
                <% if (address_text == "1")
                   { %>&nbsp;&nbsp;<img src="images/checkmark.gif" alt="" width="16px" height="16px" />
                <% } if (enable_AppSave == "0")
                   { %>
                <img src="images/checkmark.gif" alt="" width="16px" height="16px"  />
                <% }%>
            </td>
        </tr>          
       
        <tr>
            <td>
                                &nbsp;
                                TELEPHONE: &nbsp;</td>
            <td>
            <asp:TextBox ID="xtelephone" runat="server" Width="200px" CssClass="textbox" ReadOnly="true"></asp:TextBox>
                <% if (telephone_text == "1")
                   { %>&nbsp;<img src="images/checkmark.gif" alt="" width="16px" height="16px" />
                <% } if (enable_AppSave == "0")
                   { %><img src="images/checkmark.gif" alt="" width="16px" height="16px" />
                <% }%>     </td>
        </tr>
        
        <tr>
            <td>
                &nbsp;
                E-MAIL:
                </td>
            <td>
            <asp:TextBox ID="xemail" runat="server" Width="200px" CssClass="textbox" ReadOnly="true"></asp:TextBox>
                <% if (email_text == "1")
                   { %>&nbsp;<img src="images/checkmark.gif" alt="" width="16px" height="16px" />
                <% } if (enable_AppSave == "0")
                   { %><img src="images/checkmark.gif" alt="" width="16px" height="16px" />
                <% }%>     </td>
        </tr>
        
        <tr>
            <td colspan="2">
            
            </td>
        </tr>
    </table>
    
    <table align="center" width="100%" class="form">
                <tr>
                    <td colspan="2" align="left" class="tbbg">
                        FORM 2 : PLEASE FILL IN THE &quot;TRADEMARK&quot; DETAILS BELOW
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
                        <asp:TextBox ID="title_of_product" runat="server" Width="400px" CssClass="textbox" ReadOnly="true" Height="50px" TextMode="MultiLine"></asp:TextBox>
                        <% if (title_of_product_text == "1")
                           { %>&nbsp;&nbsp;<img src="images/checkmark.gif" alt="" width="16px" height="16px" />
                        <% } if (enable_MarkSave == "0")
                           { %>
                        <img src="images/checkmark.gif" alt="" width="16px" height="16px" />
                        <% }%>
                    </td>
                </tr>               
               
                <tr>
                    <td align="left">
                        &nbsp;&nbsp;GENERAL 
                        GOODS/SERVICES IN THE CLASS :
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
                    <td align="center" colspan="2">
                        &nbsp;DESCRIPTION OF SPECIFICATION OF GOODS/SERVICES :</td>
                </tr>
                <tr>
                    <td align="center" colspan="2">
                        &nbsp;
                        <asp:TextBox ID="nice_class_desc" runat="server" Height="50px" TextMode="MultiLine" Width="90%" CssClass="textbox"></asp:TextBox>
                        <% if (nice_class_desc_text == "1")
                           { %>&nbsp;<img src="images/checkmark.gif" alt="" width="16px" height="16px" />
                        <% } if (enable_MarkSave == "0")
                           { %>
                        <img src="images/checkmark.gif" alt="" width="16px" height="16px" />
                        <% } %>
                    </td>
                </tr>
                <tr>
                    <td class="tbbg" colspan="2">
                       --- DISCLAIMER ---</td>
                </tr>
                <tr>
                
                    <td align="center" colspan="2">
                   DO YOU WISH TO CLAIM OR DISCLAIM ANY PART OF THE TRADEMARK TO MAKE IT REGISTRABLE? 
                        <asp:RadioButtonList ID="rbDisclaimer" runat="server" 
                            RepeatDirection="Horizontal" 
                            onselectedindexchanged="rbDisclaimer_SelectedIndexChanged" AutoPostBack="True">
                    <asp:ListItem Value="YES">YES</asp:ListItem>
                    <asp:ListItem Value="NO" >NO</asp:ListItem>
                </asp:RadioButtonList>
                    </td>
                </tr>
                <% if (disclaimer_text != "0")
                   { %>
                <tr>
                    <td align="center" colspan="2">
                        <asp:TextBox ID="txt_discalimer" runat="server" Width="600px" 
                            CssClass="textbox" Height="50px" TextMode="MultiLine"></asp:TextBox>
                        </td>
                </tr>
                <% }%>
                <tr>
                    <td class="tbbg" colspan="2">
                      
                        <asp:Label ID="confirmLbl" runat="server" Text="DEVICE IMAGE AND SUPPORTING DOCUMENTS SECTION" Visible="False"></asp:Label>
                    </td>
                </tr>

            
               
            </table>
       
               <table align="center" width="100%" class="form">
        <tr>
            <td colspan="2" align="left" class="tbbg">
                FORM 3: PLEASE FILL IN THE &quot;ADDRESS OF SERVICE&quot; DETAILS BELOW
            </td>
        </tr>
       
         <% if (aos_state_row == "0")
            { %>
        <tr>
            <td width="22%">
                &nbsp;STATE:             </td>
            <td>
                <asp:DropDownList ID="aos_xselectState" runat="server" CssClass="textbox" 
                    DataSourceID="ds_AosState" DataTextField="name" DataValueField="ID" >
                </asp:DropDownList>
                <asp:SqlDataSource ID="ds_AosState" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:cldConnectionString %>" 
                    SelectCommand="SELECT * FROM [state]">
                </asp:SqlDataSource>
                <% if (aos_state_text == "1")
                   { %>                
                <asp:TextBox ID="aos_xstate" runat="server" Width="100px" CssClass="textbox"></asp:TextBox>
                &nbsp;<img src="images/checkmark.gif" alt="" width="16px" height="16px"   />
                <% } if (enable_AosSave == "0")
                   { %>
                <img src="images/checkmark.gif" alt="" width="16px" height="16px" />  
                             <% }  %>
            </td>
        </tr>
                   <% } %>
        <tr>
            <td width="22%">
                &nbsp;CITY :
            </td>
            <td>
            <asp:TextBox ID="aos_xcity" runat="server" Width="200px" CssClass="textbox"></asp:TextBox>
                <% if (aos_city_text == "1")
                   { %>&nbsp;<img src="images/checkmark.gif" alt="" width="16px" height="16px" />
                <% } if (enable_AosSave == "0")
                   { %><img src="images/checkmark.gif" alt="" width="16px" height="16px" />
                <% }%>     </td>
        </tr>
        <tr>
            <td width="22%" class="style1">
                &nbsp;STREET 
                No.:
            </td>
            <td class="style1">
                <asp:TextBox ID="aos_xaddress" runat="server" Width="400px" CssClass="textbox" 
                    Height="50px" TextMode="MultiLine"></asp:TextBox>
                <% if (aos_address_text == "1")
                   { %>&nbsp;&nbsp;<img src="images/checkmark.gif" alt="" width="16px" height="16px" />
                <% } if (enable_AosSave == "0")
                   { %>
                <img src="images/checkmark.gif" alt="" width="16px" height="16px"  />
                <% }%>
            </td>
        </tr>       
      
        <tr>
            <td>
                                &nbsp;
                                TELEPHONE: &nbsp;</td>
            <td>
            <asp:TextBox ID="aos_xtelephone" runat="server" Width="200px" CssClass="textbox"></asp:TextBox>
                <% if (aos_telephone_text == "1")
                   { %>&nbsp;<img src="images/checkmark.gif" alt="" width="16px" height="16px" />
                <% } if (enable_AosSave == "0")
                   { %><img src="images/checkmark.gif" alt="" width="16px" height="16px" />
                <% }%>     </td>
        </tr>
        
        <tr>
            <td>
                &nbsp;
                E-MAIL:
                </td>
            <td>
            <asp:TextBox ID="aos_xemail" runat="server" Width="200px" CssClass="textbox"></asp:TextBox>
                <% if (aos_email_text == "1")
                   { %>&nbsp;<img src="images/checkmark.gif" alt="" width="16px" height="16px" />
                <% } if (enable_AosSave == "0")
                   { %><img src="images/checkmark.gif" alt="" width="16px" height="16px" />
                <% }%>     </td>
        </tr>
        
        <tr>
            <td  colspan="2">               
               
            </td>
        </tr>
    </table>
         
       <table align="center" width="100%" class="form">
        <tr>
            <td class="tbbg" colspan="2">
            
                <% if (enable_RepConfirm == "0")
                   { %>
                <asp:Button ID="ConfirmRepresentativeDetails" runat="server" 
                    Text="Confirm Details" class="button" 
                    onclick="ConfirmRepresentativeDetails_Click" />
               
                <% } if (enable_RepSave == "0")
                   { %>
                <asp:Button ID="SaveAll" runat="server" Text="Submit Application"  class="button" 
                    onclick="SaveAll_Click" />
                <% }%>
            </td>
        </tr>
        <%   }         
            if (show_image_section == "1")
            {%>

          <%if (logo_text != "")
            { %>
                <tr>
                    <td align="left">
                        &nbsp; ADD &nbsp;DEVICE &nbsp;IMAGE :
                    </td>
                    <td align="left">
                        <asp:FileUpload ID="logo_pic" runat="server" />
                        &nbsp;Current Image: <asp:Label ID="lblLogoPic" runat="server"></asp:Label>
                        <% if (logo_text == "2")
                           { %>
                       
                        <img src="images/checkmark.gif" alt="" width="16px" height="16px" />
                        <% } if (enable_Save_Doc == "0")
                           { %>
                        <img src="images/checkmark.gif" alt="" width="16px" height="16px" />
                        <% }%>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        &nbsp;
                    </td>
                </tr>
                <%} %>
                <tr>
                    <td align="left">
                        &nbsp; 
                        POWER OF ATTORNEY: &nbsp;
                    </td>
                    <td align="left">
                        <asp:FileUpload ID="auth_doc" runat="server" />
                        &nbsp;Current Document:
                        <asp:Label ID="lblPoa" runat="server"></asp:Label>
                         
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
                        &nbsp;Current Supporting Document 1:
                        <asp:Label ID="lblDoc1" runat="server"></asp:Label>
                        <br />
                        <asp:FileUpload ID="sup_doc2" runat="server" />
                        &nbsp;Current Supporting Document 2:
                        <asp:Label ID="lblDoc2" runat="server"></asp:Label>
                    </td>
                </tr>               

                <tr>
                    <td colspan="2">
                <asp:HiddenField ID="xaid" runat="server" />
                <asp:HiddenField ID="xvid" runat="server" />
                <asp:HiddenField ID="xamt" runat="server" />
                <asp:HiddenField ID="xgt" runat="server" />
                <asp:HiddenField ID="xpc" runat="server" />
                <asp:HiddenField ID="xpwalletID" runat="server" />
                <asp:HiddenField ID="xmarkID" runat="server" />

                    </td>
                </tr>
         <tr>
            <td  colspan="2"><% Response.Write(show_imageMsg); %></td>
        </tr>
        <tr>
            <td class="tbbg" colspan="2">
            
                <asp:Button ID="SaveDocs" runat="server" Text="Submit Documents"  
                    class="button" onclick="SaveDocs_Click"  />
                </td>
        </tr>
        <% } %>
    </table>

        </div>

        </div>
    </div>
    </form>
</body>
</html>
