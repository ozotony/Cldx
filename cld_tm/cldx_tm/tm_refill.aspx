<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="tm_refill.aspx.cs" Inherits="cld.tm_refill"  MaintainScrollPositionOnPostback="true"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>TRADEMARK FILING</title>

<link href="css/style.css" rel="stylesheet" type="text/css" />
<script src="js/funk.js" type="text/javascript"></script>


    <style type="text/css">
        .style1
        {
            height: 60px;
        }
    </style>


</head>
<body>
    <form id="form1" runat="server">
    <div>
     <table align="center" width="1200px">
            <tr >
                <td >        
      
    <table  id="applicantForm" align="center" width="100%"  >
    
     <tr>
            <td colspan="2" align="center" >
                <img alt="Coat Of Arms" height="79" src="images/coat_of_arms.png" 
                        width="85" /></td>
        </tr>
       
        
        <tr>
            <td colspan="2" align="center" style=" font-size:11pt;">
                 FEDERAL REPUBLIC OF NIGERIA<br />
                    FEDERAL MINISTRY OF INDUSTRY, TRADE AND INVESTMENT<br />
                    COMMERCIAL LAW DEPARTMENT<br />
                    TRADEMARKS, PATENTS AND DESIGNS REGISTRY<br />
                     </td>
        </tr>
       
        
        <tr>
             <td colspan="2" style="font-size:18pt;line-height:115%;" align="center">
                        TRADEMARK APPLICATION                 </td>
        </tr>
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
                <asp:TextBox ID="xname" runat="server" Width="400px" CssClass="textbox" ></asp:TextBox>
                <% if (name_text == "1")
                   { %>&nbsp;<img src="images/arrow-left.gif" alt="" width="16px" height="16px" />
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
            <td width="22%" colspan="2" style="background-color:#999999; text-align:center;">
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
                    SelectCommand="SELECT DISTINCT * FROM [state] WHERE ([countryID] = @countryID)">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="residence" DefaultValue="" Name="countryID" 
                            PropertyName="SelectedValue" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
                                             
                
                <% if (state_text == "1")
                   { %>&nbsp;<img src="images/arrow-left.gif" alt="" width="16px" height="16px"   />
                <% } if (enable_AppSave == "0")
                   { %>
                <img src="images/checkmark.gif" alt="" width="16px" height="16px" />  
                             <% }  %>
            </td>
        </tr>
        <% } %>
        <tr>
            <td width="22%" class="style1">
                &nbsp;&nbsp;ADDRESS:
            </td>
            <td class="style1">
                <asp:TextBox ID="xaddress" runat="server" Width="400px" CssClass="textbox" 
                    Height="50px" TextMode="MultiLine"></asp:TextBox>
                <% if (address_text == "1")
                   { %>&nbsp;&nbsp;<img src="images/arrow-left.gif" alt="" width="16px" height="16px" />
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
            <asp:TextBox ID="xtelephone" runat="server" Width="200px" CssClass="textbox"></asp:TextBox>
                <% if (telephone_text == "1")
                   { %>&nbsp;<img src="images/arrow-left.gif" alt="" width="16px" height="16px" />
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
            <asp:TextBox ID="xemail" runat="server" Width="200px" CssClass="textbox"></asp:TextBox>
                <% if (email_text == "1")
                   { %>&nbsp;<img src="images/arrow-left.gif" alt="" width="16px" height="16px" />
                <% } if (enable_AppSave == "0")
                   { %><img src="images/checkmark.gif" alt="" width="16px" height="16px" />
                <% }%>     </td>
        </tr>
        
        <tr>
            <td colspan="2">
            &nbsp;
            </td>
        </tr>
    </table>
    
    <table align="center" width="100%" >
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
                        <asp:TextBox ID="title_of_product" runat="server" Width="400px" CssClass="textbox" Height="50px" TextMode="MultiLine"></asp:TextBox>
                        <% if (title_of_product_text == "1")
                   { %>&nbsp;&nbsp;<img src="images/arrow-left.gif" alt="" width="16px" height="16px" />
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
                    <td align="left" class="form">
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
                   { %>&nbsp;<img src="images/arrow-left.gif" alt="" width="16px" height="16px" />
                        <% } if (enable_MarkSave == "0")
                   { %>
                        <img src="images/checkmark.gif" alt="" width="16px" height="16px" />
                        <% } %>
                    </td>
                </tr>
                <tr>
                    <td style="background-color:#999999; text-align:center;" colspan="2">
                       --- DISCLAIMER ---</td>
                </tr>
                <tr>
                
                    <td align="center" colspan="2">
                    DO YOU WISH TO CLAIM OR DISCLAIM ANY PART OF THE TRADEMARK TO MAKE IT REGISTRABLE?&nbsp;
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
                             
                <tr>
                    <td  colspan="2">
                      
                        &nbsp;</td>
                </tr>

            
               
            </table>
       
               <table align="center" width="100%" >
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
                &nbsp;<img src="images/arrow-left.gif" alt="" width="16px" height="16px"   />
                <% } if (enable_AosSave == "0")
                   { %>
                <img src="images/checkmark.gif" alt="" width="16px" height="16px" />  
                             <% }  %>
            </td>
        </tr>
                   <% } %>
        <tr>
            <td width="22%" class="style1">
                &nbsp;&nbsp;ADDRESS: 
            </td>
            <td class="style1">
                <asp:TextBox ID="aos_xaddress" runat="server" Width="400px" CssClass="textbox" 
                    Height="50px" TextMode="MultiLine"></asp:TextBox>
                <% if (aos_address_text == "1")
                   { %>&nbsp;&nbsp;<img src="images/arrow-left.gif" alt="" width="16px" height="16px" />
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
                   { %>&nbsp;<img src="images/arrow-left.gif" alt="" width="16px" height="16px" />
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
                   { %>&nbsp;<img src="images/arrow-left.gif" alt="" width="16px" height="16px" />
                <% } if (enable_AosSave == "0")
                   { %><img src="images/checkmark.gif" alt="" width="16px" height="16px" />
                <% }%>     </td>
        </tr>
        
        <tr>
            <td  colspan="2">               
               
            </td>
        </tr>
    </table>
         
       <table align="center" width="100%" >
        <tr>
            <td colspan="2" align="left" class="tbbg">
                FORM 4 : PLEASE FILL IN THE &quot;REPRESENTATIVE/ATTORNEY&quot; DETAILS BELOW
            </td>
        </tr>
          
        <tr>
            <td width="30%">
                &nbsp;&nbsp;AGENT CODE:             </td>
            <td class="style1">
                <asp:TextBox ID="xcode" runat="server" Width="400px" 
                    CssClass="textbox" ReadOnly="True"></asp:TextBox>
                                
                                   
                </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;&nbsp;NAME :
            </td>
            <td align="left" class="style1">
                <asp:TextBox ID="rep_xname" runat="server" Width="400px" CssClass="textbox" ></asp:TextBox>
                <% if (rep_name_text == "1")
                   { %>&nbsp;<img src="images/arrow-left.gif" alt="" width="16px" height="16px" />
                <% } if (enable_RepSave == "0")
                   { %><img src="images/checkmark.gif" alt="" width="16px" height="16px" />
                <% }%>    
            </td>
        </tr>
       
        <tr>
            <td align="left">
                &nbsp;&nbsp;NATIONALITY :
            </td>
            <td align="left" class="style1">
                <asp:DropDownList ID="rep_nationality" runat="server" CssClass="textbox" DataSourceID="ds_Nationality" DataTextField="name" 
                    DataValueField="ID" >
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:cldConnectionString %>" 
                    SelectCommand="SELECT * FROM [country]">                  
                    </asp:SqlDataSource>
                     </td>
        </tr>        
        <tr>
            <td colspan="2" style="background-color:#999999; text-align:center;">
                ADDRESS INFORMATION</td>
        </tr>
        <tr>
            <td width="22%">
                &nbsp;COUNTRY :
            </td>
            <td class="style1">
                <asp:DropDownList ID="rep_residence" runat="server" CssClass="textbox" 
                    DataSourceID="ds_RepCountry" DataTextField="name" 
                    DataValueField="ID" >
                </asp:DropDownList>
                <asp:SqlDataSource ID="ds_RepCountry" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:cldConnectionString %>" 
                    SelectCommand="SELECT * FROM [country] WHERE ([ID] = @ID)">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="160" Name="ID" Type="Int64" />
                    </SelectParameters>
                </asp:SqlDataSource>
           </td>
        </tr>
       
        <tr>
            <td width="22%">
                &nbsp;STATE:             </td>
                  
            <td class="style1">
                <% if (rep_state_row == "0")
                    { %>  
                <asp:DropDownList ID="xselectRepState" runat="server" CssClass="textbox" 
                    DataSourceID="ds_RepState" DataTextField="name" DataValueField="ID" >
                </asp:DropDownList>
                <asp:SqlDataSource ID="ds_RepState" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:cldConnectionString %>" 
                    
                    SelectCommand="SELECT DISTINCT ID, name, countryID FROM state WHERE (countryID = 160)">
                    
                </asp:SqlDataSource>
                 
                   <% } else
            { %>                
                <asp:TextBox ID="rep_xstate" runat="server" Width="100px" CssClass="textbox"></asp:TextBox>
                <% } if (rep_state_text == "1")
                   { %>&nbsp;<img src="images/arrow-left.gif" alt="" width="16px" height="16px"   />
                <% } if (enable_RepSave == "0")
                   { %>
                <img src="images/checkmark.gif" alt="" width="16px" height="16px" />  
                            
            </td>
        </tr>
           <% } %>
        <tr>
            <td width="22%">
                &nbsp;&nbsp;ADDRESS : 
            </td>
            <td class="style1">
                <asp:TextBox ID="rep_address" runat="server" Width="400px" CssClass="textbox" 
                    Height="50px" TextMode="MultiLine"></asp:TextBox>
                <% if (rep_address_text == "1")
                   { %>&nbsp;&nbsp;<img src="images/arrow-left.gif" alt="" width="16px" height="16px" />
                <% } if (enable_RepSave == "0")
                   { %>
                <img src="images/checkmark.gif" alt="" width="16px" height="16px"  />
                <% }%>
            </td>
        </tr>
        
        <tr>
            <td>
                                &nbsp;
                                TELEPHONE: &nbsp;</td>
            <td class="style1">
            <asp:TextBox ID="rep_xtelephone" runat="server" Width="200px" CssClass="textbox" ></asp:TextBox>
                <% if (rep_telephone_text == "1")
                   { %>&nbsp;<img src="images/arrow-left.gif" alt="" width="16px" height="16px" />
                <% } if (enable_RepSave == "0")
                   { %><img src="images/checkmark.gif" alt="" width="16px" height="16px" />
                <% }%>     </td>
        </tr>
        
        <tr>
            <td>
                &nbsp;
                E-MAIL:
                </td>
            <td class="style1">
            <asp:TextBox ID="rep_xemail" runat="server" Width="200px" CssClass="textbox" ></asp:TextBox>
                <% if (rep_email_text == "1")
                   { %>&nbsp;<img src="images/arrow-left.gif" alt="" width="16px" height="16px" />
                <% } if (enable_RepSave == "0")
                   { %><img src="images/checkmark.gif" alt="" width="16px" height="16px" />
                <% }%>     </td>
        </tr>
        
        <tr>
            <td style="background-color:#999999; text-align:center;" colspan="2">
               </td>
        </tr>
        
        <tr>
            <td  align="center" colspan="2">                 
               
                <asp:Button ID="SaveAll" runat="server" Text="Submit Application"  class="button" 
                    onclick="SaveAll_Click" />
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
                <asp:HiddenField ID="G_Agent_infoemail" runat="server" />
                <asp:HiddenField ID="xcname" runat="server" />
                <asp:HiddenField ID="G_Agent_infopnumber" runat="server" />
                <asp:HiddenField ID="xapplicantname" runat="server" />
                <asp:HiddenField ID="xproduct_title" runat="server" />
                 <asp:HiddenField ID="xref" runat="server" />
                    </td>
                </tr>
        
    </table>

    </td>
    </tr>
    </table>
    </div>
    </form>
</body>
</html>
