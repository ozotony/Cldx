<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="trademark_refill_docs.aspx.cs" Inherits="cld.trademark_refill_docs" MaintainScrollPositionOnPostback="true" %>

<%@ Register assembly="Brettle.Web.NeatUpload" namespace="Brettle.Web.NeatUpload" tagprefix="Upload" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>TRADEMARK FILING</title>

<link href="css/style.css" rel="stylesheet" type="text/css" />
<script src="js/funk.js" type="text/javascript"></script>


    </head>
<body>
    <form id="form1" runat="server">
    <div>
     <table align="center" width="1200px">
            <tr >
                <td >   
    
       <table align="center" width="100%" >
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
         <%if (ack_status == "0")
                      { %>
        <tr>
            <td colspan="2" align="left" class="tbbg">
                PLEASE ATTACH THE RELEVANT DOCUMENTS BELOW
            </td>
        </tr>
          
          <%if (logo_text == "1")
            { %>
                <tr>
                    <td align="left">
                        &nbsp; ADD &nbsp;DEVICE &nbsp;IMAGE :
                    </td>
                    <td align="left">
                          <Upload:InputFile ID="fu_logo_pic" runat="server"  CssClass="textbox"/>
                         <asp:RegularExpressionValidator id="RegularExpressionLogopic" 
				ControlToValidate="fu_logo_pic"
				ValidationExpression="(([^.;]*[.])+(JPEG|JPG|jpg|jpeg|PNG|png); *)*(([^.;]*[.])+(JPEG|JPG|jpg|jpeg|PNG|png))?$"
				Display="Static"
				ErrorMessage="DOCUMENTS ATTACHED SHOULD BE OF JPEG/PNG!!"
				EnableClientScript="True"  runat="server"/></td>
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
                       <Upload:InputFile ID="fu_auth_doc" runat="server"  CssClass="textbox"/>
                         <asp:RegularExpressionValidator id="RegularExpressionValidatorAuth_doc" 
				ControlToValidate="fu_auth_doc"
				ValidationExpression="(([^.;]*[.])+(pdf|PDF|JPEG|JPG|jpg|jpeg|PNG|png); *)*(([^.;]*[.])+(pdf|PDF|JPEG|JPG|jpg|jpeg|PNG|png))?$"
				Display="Static"
				ErrorMessage="DOCUMENTS ATTACHED SHOULD BE OF PDF/JPEG/PNG!!"
				EnableClientScript="True"  runat="server"/>
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
                        <Upload:InputFile ID="fu_sup_doc1" runat="server"  CssClass="textbox"/>
                         <asp:RegularExpressionValidator id="RegularExpressionValidatorSup_doc1" 
				ControlToValidate="fu_sup_doc1"
				ValidationExpression="(([^.;]*[.])+(pdf|PDF|JPEG|JPG|jpg|jpeg|PNG|png); *)*(([^.;]*[.])+(pdf|PDF|JPEG|JPG|jpg|jpeg|PNG|png))?$"
				Display="Static"
				ErrorMessage="DOCUMENTS ATTACHED SHOULD BE OF PDF/JPEG/PNG!!"
				EnableClientScript="True"  runat="server"/>
                        <br />
                       <Upload:InputFile ID="fu_sup_doc2" runat="server"  CssClass="textbox"/>
                         <asp:RegularExpressionValidator id="RegularExpressionValidatorSup_doc2" 
				ControlToValidate="fu_sup_doc2"
				ValidationExpression="(([^.;]*[.])+(pdf|PDF|JPEG|JPG|jpg|jpeg|PNG|png); *)*(([^.;]*[.])+(pdf|PDF|JPEG|JPG|jpg|jpeg|PNG|png))?$"
				Display="Static"
				ErrorMessage="DOCUMENTS ATTACHED SHOULD BE OF PDF/JPEG/PNG!!"
				EnableClientScript="True"  runat="server"/>
                    </td>
                </tr>    
        
        <tr>
            <td  colspan="2" style="background-color:#999999; text-align:center;"></td>
        </tr>
        <%} %>
        <tr>
            <td  colspan="2" align="center">
            
               <%if (ack_status == "0")
                      { %>
                          <asp:Button ID="btn_all_doc" runat="server" Text="Upload Documents"  
                            CssClass="button"/> 
                            <% }
                      else
                      { %>
                          <asp:Button ID="btn_ack" runat="server" Text="Print Acknowledgement Slip"  
                            CssClass="button" onclick="btn_ack_Click"/> 
                            <%} %>
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
