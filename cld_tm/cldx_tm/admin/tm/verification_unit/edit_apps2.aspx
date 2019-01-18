<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="edit_apps2.aspx.cs" Inherits="cld.admin.tm.verification_unit.edit_apps2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>TRADEMARK FILING EDIT FORM</title>
<link href="../../../css/style.css" rel="stylesheet" type="text/css" />
<link rel="stylesheet" href="../../../css/jquery.ui.all.css" />
<link rel="stylesheet" href="../../../css/jquery.ui.theme.css" />

<script src="../../../js/jquery-1.7.2.min.js"></script>
<script src="../../../js/jquery-ui-1.8.16.custom.min.js"></script>
<script src="../../../ui/jquery.cookie.js"></script>
<script src="../../../ui/jquery.ui.core.js"></script>
<script src="../../../ui/jquery.ui.widget.js"></script>
<script src="../../../ui/jquery.ui.datepicker.js"></script>
<script src="../../../js/funk.js"></script>
<script src="../../../js/sweet-alert.min.js"></script>
<link href="../../../css/sweet-alert.css" rel="stylesheet" />

<script type="text/javascript">
    $(function () {
      //  $("#txt_new_date").datepicker();

        $("#txt_new_date").datepicker({ dateFormat: 'yy-mm-dd' });
    });

</script>

     <script type="text/javascript">
     function showDialogue(m) {
         swal("", m, "error");



     }

     function showDialogue2(m) {
         swal("", m, "success");



     }

        </script> 
 

</head>
<body>
    <form id="form1" runat="server">
    <div>
     <table align="center" width="1200px">
            <tr >
                <td >        
      
            
    <table  id="applicantForm" align="center" width="100%" style="border:1px dashed #000; font-size:11px;">
      <tr>
            <td colspan="2" align="center" >
                <img alt="Coat Of Arms" height="79" src="../../../images/coat_of_arms.png" 
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
                        &nbsp;</td>
        </tr> 
          
        <% if (showsearch == 0)
                   { %>
        <tr>
             <td colspan="2" style="font-size:18pt;line-height:115%;" align="center">
                        ENTER TRANSACTION ID BELOW 

             </td>
        </tr> 
          
        
        <tr>
             <td colspan="2" style="font-size:18pt;line-height:115%;" align="center">
                <asp:TextBox ID="txt_search" runat="server" Width="400px" 
                    CssClass="textbox" ></asp:TextBox>
                   
                </td>
        </tr> 
          
        
        <tr>
             <td colspan="2" style="font-size:18pt;line-height:115%;" align="center">
                <asp:Button ID="SearchApplicant" runat="server" Text="Search For Application" 
                    class="button" onclick="SearchApplicant_Click" />
                                   
                </td>
        </tr> 
          <tr>
             <td colspan="2" style="font-size:22pt;line-height:115%; font-weight:bolder;color:#042612;" align="center">
                 <%=succ_msg %></td>
        </tr> 
        
         <% }%> 
        
        <% if (showsearch>0)
                   { %>           
        
        
      
        <tr>
             <td colspan="2" style="font-size:18pt;line-height:115%;" align="center">
                        TRADEMARK (FORM 02) EDIT SECTION</td>
        </tr> 
          
    <% if (show_image_section=="0" ) {%>
        <tr>
            <td colspan="2" align="left" class="tbbg" style="text-align:left;">
                &nbsp;&nbsp;PLEASE FILL IN THE APPLICANT/PROPRIETOR 
                INFORMATION DETAILS BELOW  
            </td>
        </tr>
        
        <tr>
            <td width="30%">
                &nbsp;&nbsp;NAME:
            </td>
            <td>
                <asp:TextBox ID="xname" runat="server" Width="400px" CssClass="textbox" ></asp:TextBox>
                            
                                   
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
       
        <tr>
            <td width="22%">
                &nbsp;STATE:             </td>
            <td>
                 
                <asp:DropDownList ID="xselectState" runat="server" CssClass="textbox" 
                    DataSourceID="ds_State" DataTextField="name" DataValueField="ID" >
                </asp:DropDownList>
                <asp:SqlDataSource ID="ds_State" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:cldConnectionString %>" 
                    SelectCommand="SELECT DISTINCT ID, name, countryID FROM state WHERE (countryID = 160)">
                   
                </asp:SqlDataSource>
                                             
              
            </td>
        </tr>
     
        <tr>
            <td width="22%">
                &nbsp;ADDRESS:
            </td>
            <td>
                <asp:TextBox ID="xaddress" runat="server" Width="400px" CssClass="textbox" 
                    Height="100px" TextMode="MultiLine" ></asp:TextBox>
             
            </td>
        </tr>          
       
        <tr>
            <td>
                                &nbsp;
                                TELEPHONE: &nbsp;</td>
            <td>
            <asp:TextBox ID="xtelephone" runat="server" Width="200px" CssClass="textbox" ></asp:TextBox>
               </td>
        </tr>
        
        <tr>
            <td>
                &nbsp;
                E-MAIL:
                </td>
            <td>
            <asp:TextBox ID="xemail" runat="server" Width="200px" CssClass="textbox" ></asp:TextBox>
                </td>
        </tr>
        
        <tr>
            <td colspan="2">
            
            </td>
        </tr>
    </table>
    
    <table align="center" width="100%" style="border:1px dashed #000;font-size:11px;">
                <tr>
                    <td colspan="2" align="left" class="tbbg" style="text-align:left;">
                        &nbsp;&nbsp;PLEASE FILL IN THE &quot;TRADEMARK&quot; DETAILS BELOW
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
                        <asp:DropDownList ID="logo_description" runat="server" DataSourceID="ds_LogoDescription" DataTextField="type" DataValueField="xID" CssClass="textbox" AutoPostBack="True" >
                            <asp:ListItem Value="0" Text="PLEASE SELECT AN OPTION" Selected="True"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        &nbsp;&nbsp;TRADEMARK :</td>
                    <td align="left">
                        <asp:TextBox ID="title_of_product" runat="server" Width="400px" CssClass="textbox" Height="50px" TextMode="MultiLine"></asp:TextBox>
                      
                    </td>
                </tr>               
         <tr>
                    <td align="left">
                        &nbsp;&nbsp;REGISTRATION NUMBER:</td>
                    <td align="left">
                        <asp:TextBox ID="TextBox1" runat="server" Width="400px" CssClass="textbox" Height="50px" TextMode="MultiLine"></asp:TextBox>
                      
                    </td>
                </tr>               
                      


                <tr>
                    <td align="left">
                        &nbsp;&nbsp;GENERAL 
                        GOODS/SERVICES IN THE CLASS :
                    </td>
                    <td align="left">
                        <asp:SqlDataSource ID="ds_NationalClass" runat="server" ConnectionString="<%$ ConnectionStrings:cldConnectionString %>" SelectCommand="SELECT [xID], [type], [description] FROM [national_classes]"></asp:SqlDataSource>
                        <asp:DropDownList ID="national_class" runat="server" DataSourceID="ds_NationalClass" DataTextField="type" DataValueField="xID"  AutoPostBack="True" CssClass="textbox">
                        </asp:DropDownList>
                    </td>
                </tr>
              
                <tr>
                    <td align="left">
                        &nbsp;&nbsp;DESCRIPTION&nbsp; OF GENERAL GOODS:
                    </td>
                    <td align="left" class="form">
                        <asp:Label ID="national_class_desc" runat="server"></asp:Label>
                    </td>
                </tr>
              
              
                <tr>
                    <td align="left" >
                       
                     
                        DESCRIPTION OF SPECIFICATION OF GOODS/SERVICES :</td>
                    <td align="left" >
                        <asp:TextBox ID="nice_class_desc" runat="server" Height="100px" TextMode="MultiLine" Width="400px" CssClass="textbox"></asp:TextBox>
                       
                       
                       
                    </td>
                </tr>
                <tr>
                    <td style="background-color:#999999; text-align:center;" colspan="2">
                       --- DISCLAIMER ---</td>
                </tr>
               
            
                <tr>
                    <td align="left">
                        DISCLAIM ANY PART OF THE TRADEMARK TO MAKE IT REGISTRABLE</td>
                    <td align="left">
                        <asp:TextBox ID="txt_discalimer" runat="server" Width="400px" 
                            CssClass="textbox" Height="100px" TextMode="MultiLine"></asp:TextBox>
                        </td>
                </tr>  
            
               
            </table>
       
               <table align="center" width="100%" style="border:1px dashed #000;font-size:11px;">
        <tr>
            <td colspan="2" align="left" class="tbbg" style="text-align:left;">
                &nbsp;&nbsp;PLEASE FILL IN THE &quot;ADDRESS OF SERVICE&quot; DETAILS BELOW
            </td>
        </tr>
       
         <% if (aos_state_row == "0")
            { %>
        <tr>
            <td width="30%">
                &nbsp;STATE:             </td>
            <td>
                <asp:DropDownList ID="aos_xselectState" runat="server" CssClass="textbox" 
                    DataSourceID="ds_AosState" DataTextField="name" DataValueField="ID" >
                </asp:DropDownList>
                <asp:SqlDataSource ID="ds_AosState" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:cldConnectionString %>" 
                    SelectCommand="SELECT * FROM [state]">
                </asp:SqlDataSource>
                           
            </td>
        </tr>
                   <% } %>
        <tr>
            <td width="30%" class="style1">
                &nbsp;ADDRESS:
            </td>
            <td class="style1">
                <asp:TextBox ID="aos_xaddress" runat="server" Width="400px" CssClass="textbox" ></asp:TextBox>
              
            </td>
        </tr>       
      
        <tr>
            <td>
                                &nbsp;
                                TELEPHONE: &nbsp;</td>
            <td>
            <asp:TextBox ID="aos_xtelephone" runat="server" Width="200px" CssClass="textbox"></asp:TextBox>
                 </td>
        </tr>
        
        <tr>
            <td>
                &nbsp;
                E-MAIL:
                </td>
            <td>
            <asp:TextBox ID="aos_xemail" runat="server" Width="200px" CssClass="textbox"></asp:TextBox>
                </td>
        </tr>
        
        <tr>
            <td  colspan="2">               
               
            </td>
        </tr>
    </table>
         
       <table align="center" width="100%" style="border:1px dashed #000;font-size:11px;">
        <tr>
            <td colspan="2" align="left" class="tbbg" style="text-align:left;">
                &nbsp;&nbsp;PLEASE FILL IN THE &quot;REPRESENTATIVE/ATTORNEY&quot; DETAILS BELOW
            </td>
        </tr>
          
        <tr>
            <td width="30%">
                &nbsp;&nbsp;AGENT CODE:             </td>
            <td class="style1">
                <asp:TextBox ID="xcode" runat="server" Width="400px" 
                    CssClass="textbox" ></asp:TextBox>
                                
                                   
                </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;&nbsp;NAME :
            </td>
            <td align="left" class="style1">
                <asp:TextBox ID="rep_xname" runat="server" Width="400px" CssClass="textbox"  ></asp:TextBox>
               
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
               
                <asp:DropDownList ID="xselectRepState" runat="server" CssClass="textbox" 
                    DataSourceID="ds_RepState" DataTextField="name" DataValueField="ID" >
                </asp:DropDownList>
                <asp:SqlDataSource ID="ds_RepState" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:cldConnectionString %>" 
                    
                    SelectCommand="SELECT DISTINCT ID, name, countryID FROM state WHERE (countryID = 160)">
                    
                </asp:SqlDataSource>
                 
                  
            </td>
        </tr>
         
        <tr>
            <td width="22%">
                &nbsp;ADDRESS:
            </td>
            <td class="style1">
                <asp:TextBox ID="rep_address" runat="server" Width="400px" CssClass="textbox" 
                    Height="100px" TextMode="MultiLine"></asp:TextBox>
              
            </td>
        </tr>
        
        <tr>
            <td>
                                &nbsp;
                                TELEPHONE: &nbsp;</td>
            <td class="style1">
            <asp:TextBox ID="rep_xtelephone" runat="server" Width="200px" CssClass="textbox"  ></asp:TextBox>
              </td>
        </tr>
        
        <tr>
            <td>
                &nbsp;
                E-MAIL:
                </td>
            <td class="style1">
            <asp:TextBox ID="rep_xemail" runat="server" Width="200px" CssClass="textbox"  ></asp:TextBox>
               </td>
        </tr>
        
        <tr>
            <td style="background-color:#999999; text-align:center;" colspan="2">
            </td>
        </tr>
        
        <tr>
            <td  align="center" colspan="2">
                           
            </td>
        </tr>
        <%  }
           {%>

           <% if (logo_pic_text == "1")
                   { %>    
                <tr>
                    <td align="left">
                        &nbsp; ADD &nbsp;DEVICE &nbsp;IMAGE :
                    </td>
                    <td align="left">
                        <asp:FileUpload ID="logo_pic" runat="server" />
                        &nbsp;&nbsp;<strong>Current Device:</strong>
                         <% if (c_mark.logo_pic != "")
               { 
               Response.Write( "<a href=../" +c_mark.logo_pic+" target='_blank'>View</a>");        
         }  else { Response.Write("NONE"); 
               } %>                   
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
                       &nbsp;&nbsp;<strong>Current Document:</strong>
                         <% if (c_mark.auth_doc != "")
               {
                   Response.Write("<a href=../" + c_mark.auth_doc + " target='_blank'>View</a>");        
         }  else { Response.Write("NONE"); 
               } %>                   
                         
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
                          &nbsp;&nbsp;<strong>Current Supporting Document 1:</strong>
                         <% if (c_mark.sup_doc1 != "")
               {
                   Response.Write("<a href=../" + c_mark.sup_doc1 + " target='_blank'>View</a>");        
         }  else { Response.Write("NONE"); 
               } %>                   
                        <br />
                        <br />
                        <asp:FileUpload ID="sup_doc2" runat="server" />
                           &nbsp;&nbsp;<strong>Current Supporting Document 2:</strong>
                         <% if (c_mark.sup_doc2 != "")
               {
                   Response.Write("<a href=../" + c_mark.sup_doc2+ " target='_blank'>View</a>");        
         }  else { Response.Write("NONE"); 
               } %>                   
                    </td>
                </tr>               

                <tr>
                    <td colspan="2">
                <asp:HiddenField ID="xhwalletID" runat="server" />
                 <asp:HiddenField ID="curtime" runat="server" />                   
                    </td>
                </tr>
        
           <tr>
            <td  colspan="2" style="background-color:#999999; text-align:center;"></td>
           </tr>
           <tr>
            <td  align="left">            
              RTM Number: </td>
            <td  align="left">            
            <asp:TextBox ID="txt_rtm" runat="server" Width="200px" CssClass="textbox" ></asp:TextBox>
                </td>
           </tr>
        
           <tr>
            <td  align="left">            
              &nbsp;<strong>Current Date/TIme :</strong><%=curtime.Value %></td> 
            <td  align="left">            
                New Date:<br />
            <asp:TextBox ID="txt_new_date" runat="server" Width="200px" CssClass="textbox" ></asp:TextBox>
                </td>
           </tr>
        
        <tr>
            <td  colspan="2" style="background-color:#999999; text-align:center;"></td>
        </tr>
        
            
        <tr>
            <td  align="center" colspan="2">            
                <span style="font-size:20px; color:#f00; font-weight:bolder;"><%=show_imageMsg %></span></td>
        </tr>
        <tr>
            <td  align="center" colspan="2">            
                <asp:Button ID="SaveAll" runat="server" Text="Update Application"  class="button" onclick="SaveAll_Click" />
               
                </td>
        </tr>
        <% 
           }
        }%>
    </table>
</td>
    </tr>
    </table>
   
    </div>
    </form>
</body>
</html>