<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="g_application_docs.aspx.cs" Inherits="cld.admin.tm.generic.g_application_docs" MaintainScrollPositionOnPostback="true" %>

<%@ Register assembly="Brettle.Web.NeatUpload" namespace="Brettle.Web.NeatUpload" tagprefix="Upload" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>TRADEMARK FILING</title>

<link href="../../../css/style.css" rel="stylesheet" type="text/css" />
<script src="../../../js/funk.js" type="text/javascript"></script>


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
                         GENERIC FORM DOCUMENTS<br />               </td>
        </tr>
         <%if (ack_status == "0")
                      { %>
        <tr>
            <td colspan="2" align="left" class="tbbg">
                PLEASE ATTACH THE RELEVANT DOCUMENTS BELOW
            </td>
        </tr>
          
          <%if (logo_text == "0")
            { %>
                <tr>
                    <td align="left">
                        &nbsp; 
                        Supporting Document 1 :
                    </td>
                    <td align="left">
                          <Upload:InputFile ID="fu_sup_doc1" runat="server"  CssClass="textbox"/>
                         <asp:RegularExpressionValidator id="RegularExpressionValidatorsup_doc1" 
				ControlToValidate="fu_sup_doc1"
				ValidationExpression="(([^.;]*[.])+(JPEG|JPG|jpg|jpeg|PDF|pdf); *)*(([^.;]*[.])+(JPEG|JPG|jpg|jpeg|PDF|pdf))?$"
				Display="Static"
				ErrorMessage="DOCUMENTS ATTACHED SHOULD BE OF JPEG/PDF!!"
				EnableClientScript="True"  runat="server"/></td>
                </tr>
                <tr>
                    <td colspan="2">
                        &nbsp;
                    </td>
                </tr>
               
                <tr>
                    <td align="left">
                        &nbsp;&nbsp; Supporting Document 2: &nbsp;
                    </td>
                    <td align="left">
                       <Upload:InputFile ID="fu_sup_doc2" runat="server"  CssClass="textbox"/>
                         <asp:RegularExpressionValidator id="RegularExpressionValidatorsup_doc2" 
				ControlToValidate="fu_sup_doc2"
				ValidationExpression="(([^.;]*[.])+(pdf|PDF|JPEG|JPG|jpg|jpeg|PDF|pdf); *)*(([^.;]*[.])+(pdf|PDF|JPEG|JPG|jpg|jpeg|PDF|pdf))?$"
				Display="Static"
				ErrorMessage="DOCUMENTS ATTACHED SHOULD BE OF PDF/JPEG/PDF!!"
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
                        &nbsp;&nbsp; 
                        Supporting Document 3:
                    </td>
                    <td align="left">
                        <Upload:InputFile ID="fu_sup_doc3" runat="server"  CssClass="textbox"/>
                         <asp:RegularExpressionValidator id="RegularExpressionValidatorSup_doc3" 
				ControlToValidate="fu_sup_doc3"
				ValidationExpression="(([^.;]*[.])+(pdf|PDF|JPEG|JPG|jpg|jpeg|PDF|pdf); *)*(([^.;]*[.])+(pdf|PDF|JPEG|JPG|jpg|jpeg|PDF|pdf))?$"
				Display="Static"
				ErrorMessage="DOCUMENTS ATTACHED SHOULD BE OF PDF/JPEG/PDF!!"
				EnableClientScript="True"  runat="server"/>
                    </td>
                </tr>    
         <%} %>
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
                            <% } %>                    
                          <asp:Button ID="btn_ack" runat="server" Text="Back to dashboard"  
                            CssClass="button" onclick="btn_ack_Click"/> 
                            
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
