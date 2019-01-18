<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="edit_forms_docs.aspx.cs" Inherits="cld.admin.tm.x_unit.generic.edit_forms_docs" %>

<%@ Register assembly="Brettle.Web.NeatUpload" namespace="Brettle.Web.NeatUpload" tagprefix="Upload" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>PATENT APPLICATION</title>
<style type="text/css">
		.ProgressBar {
			margin: 0px;
			border: 0px;
			padding: 0px;
			width: 100%;
			height: 3em;
		}
		</style>
<link href="../../../../css/style.css" rel="stylesheet" type="text/css" />
<link rel="stylesheet" href="../../../../css/jquery.ui.all.css" type="text/css"/>
<link rel="stylesheet" href="../../../../css/jquery.ui.theme.css" type="text/css"/>
</head>
<body>
    <form id="form1" runat="server">
    <table align="center" width="1200px">
            <tr >
                <td >
    <div id="searchform">                
        <table style="width:100%;font-family:Calibri;" id="applicantForm" align="center" >
            <tr align="center">
                <td colspan="2">
                    <img alt="Coat Of Arms" height="79" src="../../../../images/coat_of_arms.png" 
                        width="85" />
               </td>
            </tr>
            <tr align="center" style=" font-size:11pt;" >
                <td colspan="2">
                    FEDERAL REPUBLIC OF NIGERIA<br />
                    FEDERAL MINISTRY OF INDUSTRY, TRADE AND INVESTMENT<br />
                    COMMERCIAL LAW DEPARTMENT<br />
                    TRADEMARKS, PATENTS AND DESIGNS REGISTRY
</td>
            </tr>
           
           <tr>
           <td colspan="3">                       
            <table style="width:100%;font-family:Calibri;" id="doc_tbl" align="center">
            <tr>
                    <td class="tbbg" colspan="3">                       
                        PLEASE ENTER THE NUMBER OF PAGES OF EACH ITEM ACCOMPANYING THIS FORM AND ATTACH 
                        DOCUMENTS BELOW :<%=app_type %></td>
                </tr>
              
                <tr>
                    <td align="center" colspan="3" style="color:Red; font-size:16px;">
                       <strong>
                        (NOTE: DOCUMENTS ATTACHED SHOULD BE OF PDF FORMAT ONLY AND NOT MORE THAN 3MB EACH!!)</strong> </td>
                </tr>
                <tr style="background-color:#999999;">
                    <td align="left" class="tbbg_left2" style="width:25%;">
                        &nbsp;ITEMS</td>
                    <td align="left" class="tbbg_left2" colspan="2">
                        ATTACH DOCUMENT</td>
                </tr>
                <%if ((logo_desc == "yes")&&(app_doc_newfilename == ""))
                  { %>
                <tr>
                    <td align="left">
                        &nbsp;TRADEMARK REPRESENTATION :
                    </td>
                    <td align="left" colspan="2">
                          <Upload:InputFile ID="fu_logo_pic" runat="server"  CssClass="textbox"/>
                         <asp:RegularExpressionValidator id="RegularExpression_logo_pic" 
				ControlToValidate="fu_logo_pic"
				ValidationExpression="(([^.;]*[.])+(JPEG|JPG|jpg|jpeg|PNG|png); *)*(([^.;]*[.])+(JPEG|JPG|jpg|jpeg|PNG|png))?$"
				Display="Static"
				ErrorMessage="DOCUMENTS ATTACHED SHOULD BE OF TYPE JPEG/PNG!!"
				EnableClientScript="True"  runat="server"/>
                        </td>
                </tr>               
                
                <tr>
                    <td colspan="3" align="center">
                     
                    </td>
                </tr>
                 <%} %>
                 <%if (app_doc_newfilename == "")
                  { %>
                <tr>
                    <td align="left">
                        &nbsp;APPLICATION LETTER :
                    </td>
                    <td align="left" colspan="2">
                        <Upload:InputFile ID="fu_app_doc" runat="server" CssClass="textbox" />
                         <asp:RegularExpressionValidator id="RegularExpression_app_doc" 
				ControlToValidate="fu_app_doc"
				ValidationExpression="(([^.;]*[.])+(pdf|PDF|JPEG|JPG|jpg|jpeg|PNG|png); *)*(([^.;]*[.])+(pdf|PDF|JPEG|JPG|jpg|jpeg|PNG|png))?$"
				Display="Static"
				ErrorMessage="DOCUMENTS ATTACHED SHOULD BE OF TYPE PDF/JPEG/PNG!!"
				EnableClientScript="True"  runat="server"/>
                        </td>
                </tr>
               
                <tr>
                    <td colspan="3"></td>
                </tr>
                <%} %>
                <%if (sup_doc_newfilename == "")
                  { %>
                <tr>
                    <td align="left">
                        &nbsp;SUPPORTING DOCUMENT:
                    </td>
                    <td align="left" colspan="2">
                        <Upload:InputFile ID="fu_sup_doc" runat="server" CssClass="textbox" />
                         <asp:RegularExpressionValidator id="RegularExpression_sup_doc" 
				ControlToValidate="fu_sup_doc"
				ValidationExpression="(([^.;]*[.])+(pdf|PDF|JPEG|JPG|jpg|jpeg|PNG|png); *)*(([^.;]*[.])+(pdf|PDF|JPEG|JPG|jpg|jpeg|PNG|png))?$"
				Display="Static"
				ErrorMessage="DOCUMENTS ATTACHED SHOULD BE OF TYPE PDF/JPEG/PNG"
				EnableClientScript="True"  runat="server"/>
                        </td>
                </tr>
                
                 <tr>
                    <td colspan="3"></td>
                </tr>
                <%} %>
                 <%if (app_type == "cert")
                  { %>
                <tr>
                    <td align="left">
                        &nbsp;COPY OF CERTIFICATE:
                    </td>
                    <td align="left" colspan="2">
                        <Upload:InputFile ID="fu_cert_doc" runat="server" CssClass="textbox" />
                         <asp:RegularExpressionValidator id="RegularExpression_cert_doc" 
				ControlToValidate="fu_cert_doc"
				ValidationExpression="(([^.;]*[.])+(pdf|PDF|JPEG|JPG|jpg|jpeg|PNG|png); *)*(([^.;]*[.])+(pdf|PDF|JPEG|JPG|jpg|jpeg|PNG|png))?$"
				Display="Static"
				ErrorMessage="DOCUMENTS ATTACHED SHOULD BE OF TYPE PDF/JPEG/PNG!!"
				EnableClientScript="True"  runat="server"/>
                        </td>
                </tr>
               
                 <tr>
                    <td colspan="3"></td>
                </tr>
                <%} %>
                <%if (app_type == "ass")
                  { %>
                <tr>
                    <td align="left">
                        &nbsp;COPY OF ASSIGNMENT:</td>
                    <td align="left" colspan="2">
                        <Upload:InputFile ID="fu_ass_doc" runat="server" CssClass="textbox" />
                         <asp:RegularExpressionValidator id="RegularExpression_ass_doc" 
				ControlToValidate="fu_ass_doc"
				ValidationExpression="(([^.;]*[.])+(pdf|PDF); *)*(([^.;]*[.])+(pdf|PDF))?$"
				Display="Static"
				ErrorMessage="DOCUMENTS ATTACHED SHOULD BE OF TYPE PDF!!"
				EnableClientScript="True"  runat="server"/>
                    </td>
                </tr>
                <%} %>
                 <%if (app_type == "merger")
                  { %>
                <tr>
                    <td align="left">
                        &nbsp;COPY OF MERGER:</td>
                    <td align="left" colspan="2">
                        <Upload:InputFile ID="fu_merger_doc" runat="server" CssClass="textbox" />
                         <asp:RegularExpressionValidator id="RegularExpression_merger_doc" 
				ControlToValidate="fu_merger_doc"
				ValidationExpression="(([^.;]*[.])+(pdf|PDF); *)*(([^.;]*[.])+(pdf|PDF))?$"
				Display="Static"
				ErrorMessage="DOCUMENTS ATTACHED SHOULD BE OF TYPE PDF!!"
				EnableClientScript="True"  runat="server"/>
                    </td>
                </tr>
                <%} %>
                 <%if (app_type == "cert")
                  { %>
                <tr>
                    <td align="left">
                        &nbsp;COPY OF PUBLICATION:</td>
                    <td align="left" colspan="2">
                        <Upload:InputFile ID="fu_pub_doc" runat="server" CssClass="textbox" />
                         <asp:RegularExpressionValidator id="RegularExpression_pub_doc" 
				ControlToValidate="fu_pub_doc"
				ValidationExpression="(([^.;]*[.])+(pdf|PDF); *)*(([^.;]*[.])+(pdf|PDF))?$"
				Display="Static"
				ErrorMessage="DOCUMENTS ATTACHED SHOULD BE OF TYPE PDF!!"
				EnableClientScript="True"  runat="server"/>
                    </td>
                </tr>
                <%} %>
                <tr>
                    <td colspan="3" align="center">
                          <Upload:ProgressBar id="pb_all_doc" runat="server" inline="true" Text="" /></td>
                </tr>


                <tr>
                    <td align="left">
                        &nbsp;</td>
                    <td align="left">
                        &nbsp;</td>
                    <td align="left">
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
                          &nbsp;<asp:Button ID="BtnBack" runat="server" Text="Back to Profile" 
                       CssClass="button" onclick="BtnBack_Click" />
                          </td>
                </tr>
                </table>
           
            </td>
            </tr>
            </table>
            
    
    </div>
    </td>
    </tr>
    </table>
    </form>
</body>
</html>
