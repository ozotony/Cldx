<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="add_applicant.aspx.cs" Inherits="cld.admin.tm.x_unit.add_applicant" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

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
        
    <table align="center" width="100%" class="form">
      <% if (showsucc == "1")
                   { %>
     <tr>
            <td colspan="2" align="center">
               <strong><% Response.Write(succ_text); %>    
                </strong><br />
                <asp:Button ID="Back" runat="server" Text="Back To Application Status Check" 
                    class="button" onclick="Back_Click" />
                <asp:Button ID="BackProfile" runat="server" Text="Back To Profile" 
                    class="button" onclick="BackProfile_Click" />
            </td>
        </tr>
           <% } else{ %>
        <tr>
            <td colspan="2" align="left" class="tbbg">
                PLEASE UPDATE THE APPLICANT/PROPRIETOR 
                INFORMATION DETAILS BELOW  
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
                &nbsp;<img src="../../../images/arrow-left.gif" alt="" width="16px" height="16px" />
                <% } if (enable_Save == "0")
                   { %><img src="../../../images/checkmark.gif" alt="" width="16px" height="16px" />
                <% }%>               
                                   
                </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;&nbsp;TYPE :
            </td>
            <td align="left">
                <asp:TextBox ID="xtitle" runat="server" Width="400px" 
                    CssClass="textbox" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;&nbsp;TAX ID TYPE :
            </td>
            <td align="left">
                <asp:TextBox ID="tax_id_type" runat="server" Width="400px" 
                    CssClass="textbox" ></asp:TextBox>
               
            </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;&nbsp;TAX ID NUMBER :
            </td>
            <td align="left">
            <asp:TextBox ID="tax_id_number" runat="server" Width="400px" CssClass="textbox"></asp:TextBox>
                
            </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;&nbsp;INDIVIDUAL ID NUMBER :
            </td>
            <td align="left">
                <asp:TextBox ID="individual_id_number" runat="server" Width="400px" 
                    CssClass="textbox" ></asp:TextBox>
               
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
            <% if (nationality_text == "1")
                   { %>
                &nbsp;<img src="../../../images/arrow-left.gif" alt="" width="16px" height="16px" />
                <% } if (enable_Save == "0")
                   { %><img src="../../../images/checkmark.gif" alt="" width="16px" height="16px" />
                <% }%>     </td>
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
                    DataValueField="ID" AutoPostBack="true" 
                    onselectedindexchanged="residence_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:SqlDataSource ID="ds_DefaultCountry" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:cldConnectionString %>" 
                    SelectCommand="SELECT * FROM [country]">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="1" Name="ID" Type="Int64" />
                    </SelectParameters>
                </asp:SqlDataSource>
            <% if (residence_text == "1")
                   { %>
                &nbsp;<img src="../../../images/arrow-left.gif" alt="" width="16px" height="16px" />
                <% } if (enable_Save == "0")
                   { %><img src="../../../images/checkmark.gif" alt="" width="16px" height="16px" />
                <% }%>      </td>
        </tr>
          <% if (state_row == "0")
                    { %> 
        <tr>
            <td width="22%">
                &nbsp;STATE:             </td>
            <td>
           
                <asp:DropDownList ID="xselectState" runat="server" CssClass="textbox" 
                    DataSourceID="ds_State" DataTextField="name" DataValueField="ID" >
                </asp:DropDownList>
                <asp:SqlDataSource ID="ds_State" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:cldConnectionString %>" 
                    SelectCommand="SELECT DISTINCT * FROM [state] WHERE ([countryID] = 160)">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="residence" DefaultValue="" Name="countryID" 
                            PropertyName="SelectedValue" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
                 
               
            </td>
        </tr>
         <% }  %> 
        <tr>
            <td width="22%">
                ADDRESS:
            </td>
            <td>
                <asp:TextBox ID="xaddress" runat="server" Width="400px" CssClass="textbox" 
                    Height="50px" TextMode="MultiLine"></asp:TextBox>
                <% if (address_text == "1")
                   { %>
                &nbsp;&nbsp;<img src="../../../images/arrow-left.gif" alt="" width="16px" height="16px" />
                <% } if (enable_Save == "0")
                   { %>
                <img src="../../../images/checkmark.gif" alt="" width="16px" height="16px"  />
                <% }%>
            </td>
        </tr>       
        
        <tr>
            <td>
                &nbsp;
                ZIP CODE: &nbsp;</td>
            <td>
            <asp:TextBox ID="xzip" runat="server" Width="100px" CssClass="textbox"></asp:TextBox>
               </td>
        </tr>
        
       
        <tr>
            <td>
                                &nbsp;
                                TELEPHONE: &nbsp;</td>
            <td>
            <asp:TextBox ID="xtelephone" runat="server" Width="200px" CssClass="textbox"></asp:TextBox>
                 <% if (telephone_text == "1")
                   { %>
                &nbsp;<img src="../../../images/arrow-left.gif" alt="" width="16px" height="16px" />
                <% } if (enable_Save == "0")
                   { %><img src="../../../images/checkmark.gif" alt="" width="16px" height="16px" />
                <% }%>     </td>
        </tr>
        
        <tr>
            <td>
                &nbsp;
                E-MAIL:
                </td>
            <td>
            <asp:TextBox ID="xemail" runat="server" Width="200px" CssClass="textbox"></asp:TextBox>
            <% if (email_text == "1")
                   { %>
                &nbsp;<img src="../../../images/arrow-left.gif" alt="" width="16px" height="16px" />
                <% } if (enable_Save == "0")
                   { %><img src="../../../images/checkmark.gif" alt="" width="16px" height="16px" />
                <% }%>     </td>
        </tr>        
      
        <tr>
            <td>
                 <asp:Label ID="appID" runat="server" ForeColor="White"></asp:Label>
                  <asp:Label ID="addressID" runat="server" ForeColor="White"></asp:Label>
                  </td>
            <td>
                <asp:Button ID="UpdateApplicant" runat="server" Text="Update Applicant" 
                    class="button" onclick="UpdateApplicant_Click"  />
                                   
            </td>
        </tr>        
      <% }%> 
    </table>
       
        </div>
    </div>
</div>
    </form>
</body>
</html>
