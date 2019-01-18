<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="xindex.aspx.cs" Inherits="cld.gf.xind2" %>
<%@ Register assembly="Brettle.Web.NeatUpload" namespace="Brettle.Web.NeatUpload" tagprefix="Upload" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >

<head id="Head1" runat="server">

    <title>
TRADEMARK APPLICATION NOTICE
</title>
  <link href="../css/style.css" rel="stylesheet" type="text/css" />

    <link rel="stylesheet" href="../css/jquery.ui.all.css" type="text/css"/>
<link rel="stylesheet" href="../css/jquery.ui.theme.css" type="text/css"/>

<script src="../js/jquery.js" type="text/javascript"></script>

<script src="../js/funk.js" type="text/javascript"></script>

    <script src="../js/jquery-1.7.2.min.js" type="text/javascript"></script>
<script src="../js/jquery-ui-1.8.16.custom.min.js" type="text/javascript"></script>
<script src="../js/jquery.js" type="text/javascript"></script>
<script src="../ui/jquery.cookie.js" type="text/javascript"></script>
<script src="../ui/jquery.ui.core.js" type="text/javascript"></script>
<script src="../ui/jquery.ui.widget.js" type="text/javascript"></script>

<script src="../ui/jquery.ui.datepicker.js" type="text/javascript"></script>

<script language="javascript" type="text/javascript">

    $(function () {

        $("#txt_application_date").datepicker({
            changeMonth: true,
            changeYear: true,
            showButtonPanel: true,
            dateFormat: 'yy-mm-dd',
            yearRange: 'c-100:c+0'
        });
        $("#txt_merger_date").datepicker({
            changeMonth: true,
            changeYear: true,
            showButtonPanel: true,
            dateFormat: 'yy-mm-dd',
            yearRange: 'c-100:c+0'
        });
        $("#txt_cert_publicationdate").datepicker({
            changeMonth: true,
            changeYear: true,
            showButtonPanel: true,
            dateFormat: 'yy-mm-dd',
            yearRange: 'c-100:c+0'
        });
        $("#txt_assignment_date").datepicker({
            changeMonth: true,
            changeYear: true,
            showButtonPanel: true,
            dateFormat: 'yy-mm-dd',
            yearRange: 'c-100:c+0'
        });
        $("#txt_renewal_date").datepicker({
            changeMonth: true,
            changeYear: true,
            showButtonPanel: true,
            dateFormat: 'yy-mm-dd',
            yearRange: 'c-100:c+0'
        });

    });
</script>
 
  <script language="javascript" type="text/javascript">
// <![CDATA[
      function Proceed_onclick() {
          window.location.href = "./g_napplication.aspx";
      }

// ]]>
    </script>

    <style type="text/css">

 p.MsoNormal
	{margin-top:0in;
	margin-right:0in;
	margin-bottom:10.0pt;
	margin-left:0in;
	line-height:115%;
	font-size:11.0pt;
	font-family:"Calibri","sans-serif";
	}
p.MsoListParagraphCxSpFirst
	{margin-top:0in;
	margin-right:0in;
	margin-bottom:0in;
	margin-left:.5in;
	margin-bottom:.0001pt;
	line-height:115%;
	font-size:11.0pt;
	font-family:"Calibri","sans-serif";
	}
p.MsoListParagraphCxSpMiddle
	{margin-top:0in;
	margin-right:0in;
	margin-bottom:0in;
	margin-left:.5in;
	margin-bottom:.0001pt;
	line-height:115%;
	font-size:11.0pt;
	font-family:"Calibri","sans-serif";
	}
p.MsoListParagraphCxSpLast
	{margin-top:0in;
	margin-right:0in;
	margin-bottom:10.0pt;
	margin-left:.5in;
	line-height:115%;
	font-size:11.0pt;
	font-family:"Calibri","sans-serif";
	}
a:link
	{color:blue;
	text-decoration:underline;
        }
        .style1
        {
            color: black;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
  <div>
      <asp:Panel runat="server" ID="tt">
    <table align="center" width="1200px">
            <tr >
                <td >
    <table align="center" width="100%" class="form">
         <tr>
            <td colspan="2" align="center" >
                <img alt="Coat Of Arms" height="79" src="../images/coat_of_arms.png" 
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
                      APPLICATION PROCESS NOTICE           </td>
        </tr>
        <tr>
            <td style="background-color:#999999; text-align:center;" colspan="2">
            &nbsp;
            </td>
        </tr>
        
        <tr>
            <td width="50%" align="left">
               
                <div align="center">Welcome to the &quot;Trademark Application Section&quot;, Please kindly note and follow 
                the rules below for a successful application</div>
                &nbsp;<p class="MsoNormal" style="margin-bottom:0in;margin-bottom:.0001pt;text-align:
justify;line-height:normal">
                    <b style="mso-bidi-font-weight:normal">
                    <span style="font-family:&quot;Andalus&quot;,&quot;serif&quot;">Technical 
                    Information:<o:p></o:p></span></b></p>
                <p class="MsoListParagraphCxSpFirst" style="margin-bottom:0in;margin-bottom:.0001pt;
mso-add-space:auto;text-align:justify;text-indent:-.25in;line-height:normal;
mso-list:l0 level1 lfo1">
                    <![if !supportLists]>
                    <span style="font-family:Wingdings;
mso-fareast-font-family:Wingdings;mso-bidi-font-family:Wingdings"><span style="mso-list:Ignore">Ø<span 
                        style="font:7.0pt &quot;Times New Roman&quot;">&nbsp; </span></span></span><![endif]>
                    <span style="font-family:&quot;Andalus&quot;,&quot;serif&quot;">Once an 
                    application has been started, please do &quot;<strong>NOT</strong>&quot; click on the &quot;<strong>BACK</strong>&quot; 
                    button of the browser<o:p></o:p></span></p>
                <p class="MsoListParagraphCxSpMiddle" style="margin-bottom:0in;margin-bottom:
.0001pt;mso-add-space:auto;text-align:justify;text-indent:-.25in;line-height:
normal;mso-list:l0 level1 lfo1">
                    <![if !supportLists]>
                    <span style="font-family:
Wingdings;mso-fareast-font-family:Wingdings;mso-bidi-font-family:Wingdings">
                    <span style="mso-list:Ignore">Ø<span 
                        style="font:7.0pt &quot;Times New Roman&quot;">&nbsp; </span></span></span><![endif]>
                    <span style="font-family:&quot;Andalus&quot;,&quot;serif&quot;">Do &quot;<strong><span style="font-family:
&quot;Andalus&quot;,&quot;serif&quot;">NOT</span></strong>&quot; start &quot;<strong>MULTIPLE</strong>&quot; 
                    application on the same browser (That is, do not start multiple applications by 
                    creating &quot;<strong>multiple tabs</strong>&quot; within the same browser<o:p></o:p></span></p>
                <p class="MsoListParagraphCxSpMiddle" style="margin-bottom:0in;margin-bottom:
.0001pt;mso-add-space:auto;text-align:justify;text-indent:-.25in;line-height:
normal;mso-list:l0 level1 lfo1">
                    <![if !supportLists]>
                    <span style="font-family:
Wingdings;mso-fareast-font-family:Wingdings;mso-bidi-font-family:Wingdings">
                    <span style="mso-list:Ignore">Ø<span 
                        style="font:7.0pt &quot;Times New Roman&quot;">&nbsp; </span></span></span><![endif]>
                    <span style="font-family:&quot;Andalus&quot;,&quot;serif&quot;">If multiple 
                    applications are to be started, please do so by starting each one in a different 
                    browser<o:p></o:p></span></p>
                <p class="MsoListParagraphCxSpLast" style="margin-bottom:0in;margin-bottom:.0001pt;
mso-add-space:auto;text-align:justify;text-indent:-.25in;line-height:normal;
mso-list:l0 level1 lfo1">
                    <![if !supportLists]>
                    <span style="font-family:Wingdings;
mso-fareast-font-family:Wingdings;mso-bidi-font-family:Wingdings"><span style="mso-list:Ignore">Ø<span 
                        style="font:7.0pt &quot;Times New Roman&quot;">&nbsp; </span></span></span><![endif]>
                    <span style="font-family:&quot;Andalus&quot;,&quot;serif&quot;">During each step 
                    (or form), please click on the &quot;<strong>Save</strong>&quot; or &quot;<strong>Save and 
                    Continue</strong>&quot; button &quot;<strong>ONCE</strong>&quot; to proceed<o:p></o:p></span></p>
                <span style="font-size:11.0pt;line-height:115%;font-family:&quot;Andalus&quot;,&quot;serif&quot;;
mso-fareast-font-family:Calibri;mso-fareast-theme-font:minor-latin;mso-ansi-language:
EN-US;mso-fareast-language:EN-US;mso-bidi-language:AR-SA">This service is best used with 
                Internet Explorer 6, Firefox 2 or Safari 2 or later on a screen at least 1024 by 
                768 pixels in size. Our website requires the use of cookies and JavaScript and 
                supports the ISO 8859-1 character set<br />
                <br />
                <p class="MsoNormal">
                    <b style="mso-bidi-font-weight:normal">
                    <span style="font-family:&quot;Andalus&quot;,&quot;serif&quot;;color:red">Before 
                    Starting the Application Process, It Is Important To Have Clearly In Mind <o:p></o:p>
                    </span></b>
                </p>
                <p class="MsoListParagraphCxSpFirst">
                    <![if !supportLists]>
                    <span style="font-family:&quot;Andalus&quot;,&quot;serif&quot;;
mso-fareast-font-family:Andalus"><span style="mso-list:Ignore">1.<span 
                        style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;
                    </span></span></span><![endif]>
                    <span style="font-family:&quot;Andalus&quot;,&quot;serif&quot;">The Trademark 
                    you want to register; <o:p></o:p></span>
                </p>
                <p class="MsoListParagraphCxSpMiddle">
                    <![if !supportLists]><b style="mso-bidi-font-weight:
normal"><span class="style1" 
                        style="font-family: &quot;Andalus&quot;,&quot;serif&quot;; mso-fareast-font-family: Andalus;">
                    <span style="mso-list:Ignore">2.<span 
                        style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp; </span>
                    </span></span></b><![endif]>
                    <span style="font-family:&quot;Andalus&quot;,&quot;serif&quot;">The goods and/or 
                    services in connection with which you wish to register the Trademark and you are 
                    advised to specify the items for the class instead of 
                    <b style="mso-bidi-font-weight:normal"><span style="color:red"“all the goods in 
                    the class”.<o:p></o:p></span></b></span></p>
                <p class="MsoListParagraphCxSpMiddle">
                    <![if !supportLists]><span style="mso-list:Ignore">
                    <span style="font-family: &quot;Andalus&quot;,&quot;serif&quot;; mso-fareast-font-family: Andalus;">
                    3.</span><span style="font-family:
&quot;Andalus&quot;,&quot;serif&quot;;mso-fareast-font-family:Andalus;color:red"><span 
                        style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span></span><![endif]><span style="font-family:&quot;Andalus&quot;,&quot;serif&quot;">The acceptable 
                    unloadable formats for uploading trademarks representations are
                    <span style="color:red"><strong>jpeg and pdf formats only</strong>.<o:p></o:p></span></span></p>
                <p class="MsoListParagraphCxSpMiddle">
                    <![if !supportLists]>
                    <span style="font-family:
&quot;Andalus&quot;,&quot;serif&quot;;mso-fareast-font-family:Andalus">
                    <span style="mso-list:Ignore">4..<span 
                        style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;</span></span></span><![endif]><span style="font-family:&quot;Andalus&quot;,&quot;serif&quot;">Ensure that the 
                    name and address of proprietor are correct and properly filled<o:p></o:p></span></p>
                <p class="MsoListParagraphCxSpMiddle">
                    <![if !supportLists]>
                    <span style="font-family:
&quot;Andalus&quot;,&quot;serif&quot;;mso-fareast-font-family:Andalus">
                    <span style="mso-list:Ignore">5.<span 
                        style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span></span><![endif]><span style="font-family:&quot;Andalus&quot;,&quot;serif&quot;">Remember to 
                    select the local or foreign mark options<o:p></o:p></span></p>
                <p class="MsoListParagraphCxSpMiddle">
                    <![if !supportLists]>
                    <span style="font-family:
&quot;Andalus&quot;,&quot;serif&quot;;mso-fareast-font-family:Andalus">
                    <span style="mso-list:Ignore">6.<span 
                        style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span></span><![endif]><span style="font-family:&quot;Andalus&quot;,&quot;serif&quot;">All information 
                    entered and submitted cannot be retrieved, amended or corrected without the 
                    payment of an amendment fee. Please ensure that the information filled is 
                    correct.<o:p></o:p></span></p>
                <p class="MsoListParagraphCxSpMiddle">
                    <![if !supportLists]>
                    <span style="font-family:
&quot;Andalus&quot;,&quot;serif&quot;;mso-fareast-font-family:Andalus">
                    <span style="mso-list:Ignore">7.<span 
                        style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span></span><![endif]><span style="font-family:&quot;Andalus&quot;,&quot;serif&quot;">All 
                    correspondence with regards to applications filed will be sent to the agent 
                    email as specified during accreditation. <o:p></o:p></span>
                </p>
                <p class="MsoListParagraphCxSpMiddle">
                    <![if !supportLists]>
                    <span style="font-family:
&quot;Andalus&quot;,&quot;serif&quot;;mso-fareast-font-family:Andalus">
                    <span style="mso-list:Ignore">8.<span 
                        style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span></span><![endif]><span style="font-family:&quot;Andalus&quot;,&quot;serif&quot;">You will be 
                    issued an on-screen acknowledgment copy immediately after submission. If you do 
                    not receive your acknowledgment immediately kindly use the ‘check status’ link 
                    to re-print your acknowledgment. <o:p></o:p></span>
                </p>
                <p class="MsoListParagraphCxSpLast">
                    <![if !supportLists]>
                    <span style="font-family:&quot;Andalus&quot;,&quot;serif&quot;;
mso-fareast-font-family:Andalus"><span style="mso-list:Ignore">9.<span 
                        style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span></span><![endif]><span style="font-family:&quot;Andalus&quot;,&quot;serif&quot;">This form has a 
                    session of 20 minutes; ensure you complete your form within the specified period 
                    to avoid being timed out.<o:p></o:p></span></p>
                <p class="MsoNormal">
                    <span style="font-family:&quot;Andalus&quot;,&quot;serif&quot;">For more 
                    information on how to file applications using TAS, kindly send an email to
                    </span><a href="mailto:customersupport@iponoigeria.com">
                    <span style="font-family:&quot;Andalus&quot;,&quot;serif&quot;">
                    customersupport@iponoigeria.com</span></a><span 
                        style="font-family:&quot;Andalus&quot;,&quot;serif&quot;"> and all requests 
                    will be treated within 24hours Mondays- Fridays. <o:p></o:p></span>
                </p>
                </span><br />
                <br />
                <div align="center"><strong>THANK YOU FOR YOUR UNDERSTANDING<br />
                    <asp:CheckBox ID="cbAgree" runat="server"  Text="I AGREE TO COMPLY WITH THE INSTRUCTIONS ABOVE " AutoPostBack="True" OnCheckedChanged="cbAgree_CheckedChanged" TextAlign="Left"/>
                    </strong></div> </td>
        </tr>
        <% if(isagree==true) { %>
         <tr>
           <td style="background-color:#999999; text-align:center;"> </td>
        </tr>
        <tr>
           <td style="text-align:center;">  <input type="button" name="Proceed" id="Proceed" value="Proceed" class="button" onclick="return Proceed_onclick()" /></td>
        </tr>
        
        <% } %>
                
    </table>
         </td>
    </tr>
    </table>  
          </asp:Panel>
      <asp:Panel ID="tt2" Visible="false" runat="server">
            <table align="center" width="1200px">
            <tr >
                <td >
    <div id="searchform">                
        <table style="width:100%;font-family:Calibri;" id="applicantForm" align="center" class="form">
            <tr align="center">
                <td colspan="2">
                    <img alt="Coat Of Arms" height="79" src="../images/coat_of_arms.png" 
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
                <td colspan="2" style="font-size:18pt;line-height:115%;" align="center">
                        REQUEST FORM
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                <b>(PLEASE NOTE THAT THIS IS A GENERIC FORM. KINDLY FILL THE INFORMATION REQUIRED FOR THE REQUEST TYPE)</b>
                    </td>
            </tr>
             <tr>
                <td colspan="2" class="tbbg_left">
                    &nbsp;APPLICATION INFORMATION >></td>
            </tr>
            <tr>
                <td width="20%">
                    &nbsp;REQUEST FORM TYPE:</td>
                <td>        
                    <b><asp:Label ID="lbl_type" runat="server" Text="" Width="1000px"></asp:Label></b>
                </td>
            </tr>
           
           
             <tr>
                <td colspan="2" class="tbbg_left">
                    &nbsp;APPLICANT INFORMATION >></td>
            </tr>
            <tr>
                <td>
                    &nbsp;APPLICANT NAME:&nbsp;</td>
                <td>
                    <asp:TextBox ID="txt_applicant_name" runat="server" class="textbox" 
                        Width="400px" ReadOnly="true"></asp:TextBox>
                </td>
            </tr>
            
            <tr>
                <td>
                    &nbsp;APPLICANT ADDRESS:&nbsp;</td>
                <td>
                    <asp:TextBox ID="txt_applicant_address" runat="server" Width="400px" CssClass="textbox" 
                    Height="80px"></asp:TextBox>
                </td>
            </tr>
            
            <tr>
                <td>
                    &nbsp;APPLICANT E-MAIL:&nbsp;</td>
                <td>
                    <asp:TextBox ID="txt_applicant_email" runat="server" class="textbox" 
                        Width="400px" ReadOnly="false"></asp:TextBox>
                </td>
            </tr>
            
            <tr>
                <td>
                    &nbsp;APPLICANT PHONE NUMBER:</td>
                <td>
                    <asp:TextBox ID="txt_applicant_mobile" runat="server" class="textbox"  ReadOnly="false"
                        Width="400px"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td>
                    &nbsp;TRADING AS:&nbsp;</td>
                <td>
                    <asp:TextBox ID="txt_trading_as" runat="server" Width="400px" CssClass="textbox" 
                    Height="40px"></asp:TextBox>
                </td>
            </tr>
             <tr>
            <td align="left">
                &nbsp;NATIONALITY :
            </td>
            <td align="left" >
                <asp:DropDownList ID="select_applicant_nationality" runat="server" OnDataBound="newsProviderID_DataBound2" CssClass="textbox" DataSourceID="ds_Nationality" DataTextField="name" 
                    DataValueField="name" >
                </asp:DropDownList>
                <asp:SqlDataSource ID="ds_Nationality" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:cldConnectionString %>" 
                    SelectCommand="SELECT * FROM [country] order by name">                  
                    </asp:SqlDataSource>
                     </td>
            </tr>
            
            <tr>
                <td colspan="2" class="tbbg_left">
                    &nbsp;TRADEMARK INFORMATON >></td>
            </tr>
            <tr>
                    <td>
                        &nbsp;TRADEMARK TYPE :
                    </td>
                    <td>
                        <asp:SqlDataSource ID="ds_TmType" runat="server" ConnectionString="<%$ ConnectionStrings:cldConnectionString %>" SelectCommand="SELECT DISTINCT [xID], [type] FROM [tm_type]"></asp:SqlDataSource>
                        <asp:DropDownList ID="tmType" runat="server" DataSourceID="ds_TmType" DataTextField="type" DataValueField="type" CssClass="textbox">
                        </asp:DropDownList>
                    </td>
                </tr>
            <tr>
                <td >
                    &nbsp;TITLE OF TRADEMARK:</td>
                <td>
                    <asp:TextBox ID="txt_title_of_trademark" runat="server" Width="400px" CssClass="textbox" 
                    Height="40px"></asp:TextBox>
                </td>
            </tr>  
             <tr>
                <td width="20%">
                    &nbsp;RTM NUMBER(If any):</td>
                <td>        
                    <asp:TextBox ID="txt_rtm_no" runat="server" class="textbox" 
                            Width="400px"></asp:TextBox>
        </td>
            </tr>
            <tr>
                <td width="20%">
                    
                    &nbsp;FILE/TP NUMBER:</td>
                <td>        
                    <asp:TextBox ID="txt_application_no" runat="server" class="textbox" 
                            Width="400px"></asp:TextBox>
                &nbsp;</td>
            </tr>
            <tr>
                <td width="20%">
                    &nbsp;FILING DATE:</td>
                <td>        
                    <asp:TextBox ID="txt_application_date" runat="server" class="textbox" 
                            Width="100px"></asp:TextBox>
                </td>
            </tr>         
             <tr>
                <td>
                    &nbsp;CLASS OF TRADEMARK:</td>
                <td> <asp:DropDownList ID="select_class_of_trademark" runat="server" CssClass="textbox" 
                    DataSourceID="ds_Class" DataTextField="type" DataValueField="xID" >
                </asp:DropDownList>
                <asp:SqlDataSource ID="ds_Class" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:cldConnectionString %>" 
                    
                    SelectCommand="SELECT * FROM national_classes">
                    
                </asp:SqlDataSource>    </td>
            </tr>
            <tr>
                <td>
                    &nbsp;DESCRIPTION OF GOODS AND SERVICES:&nbsp;</td>
                <td>
                    <asp:TextBox ID="txt_goods_desc" runat="server" Width="400px" CssClass="textbox" 
                    Height="80px"></asp:TextBox>
                </td>
            </tr>           
               <tr>
                    <td >
                        &nbsp;LOGO DESCRIPTION :
                    </td>
                    <td>
                        <asp:SqlDataSource ID="ds_LogoDescription" runat="server" ConnectionString="<%$ ConnectionStrings:cldConnectionString %>" SelectCommand="SELECT DISTINCT [xID], [type] FROM [logo_description]"></asp:SqlDataSource>
                        <asp:DropDownList ID="logo_description" runat="server"  DataSourceID="ds_LogoDescription" DataTextField="type" DataValueField="type" CssClass="textbox" AutoPostBack="true" >
                            <asp:ListItem Value="0" Text="PLEASE SELECT AN OPTION" Selected="True"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>       
            <tr>
                <td>
                    &nbsp;DISCLAIMER(If any):</td>
                <td>               
                    <asp:TextBox ID="txt_discalimer" runat="server" Width="400px" CssClass="textbox" 
                    Height="80px"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td colspan="2" class="tbbg_left">
                   &nbsp;AGENT INFORMATION (all communications will be done using the information provided below) >></td>
            </tr>
            <tr>
            <td>
                &nbsp;CODE:             </td>
            <td >
                <asp:TextBox ID="rep_code" runat="server" Width="400px" 
                    CssClass="textbox" ReadOnly="True" ></asp:TextBox>
                                
                                   
                </td>
            </tr>
            <tr>
            <td align="left">
                &nbsp;NAME :
            </td>
            <td align="left" >
                <asp:TextBox ID="rep_xname" runat="server" Width="400px" CssClass="textbox" ReadOnly="true" ></asp:TextBox>               
            </td>
            </tr>
            <tr>
            <td align="left">
                &nbsp;NATIONALITY :
            </td>
            <td align="left" >
            <asp:TextBox ID="txt_rep_nationality" runat="server" Width="400px" CssClass="textbox" 
                   ReadOnly="true" Text="Nigeria"></asp:TextBox>  
                     </td>
            </tr>
            <tr>
            <td colspan="2" style="background-color:#999999;">
                &nbsp;ADDRESS INFORMATION >></td>
            </tr>
            <tr>
            <td >
                &nbsp;COUNTRY :
            </td>
            <td >
             <asp:TextBox ID="txt_rep_country" runat="server" Width="400px" CssClass="textbox" 
                   ReadOnly="true" Text="Nigeria"></asp:TextBox> 
           </td>
            </tr>
            <tr>
            <td >
                &nbsp;STATE:             </td>
                  
            <td >             
                <asp:SqlDataSource ID="ds_State" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:cldConnectionString %>" 
                    SelectCommand="SELECT DISTINCT * FROM [state] ">
                    
                </asp:SqlDataSource>
                 
                <asp:DropDownList ID="selectRepState" runat="server" CssClass="textbox" 
                    DataSourceID="ds_State" DataTextField="name" DataValueField="name" >
                </asp:DropDownList>
            </td>
            </tr>
            <tr>
            <td >
                &nbsp;ADDRESS :
            </td>
            <td >
                <asp:TextBox ID="txt_rep_address" runat="server" Width="400px" CssClass="textbox" 
                    Height="80px" TextMode="MultiLine"></asp:TextBox>               
            </td>
            </tr>
            <tr>
            <td>
              &nbsp;TELEPHONE: &nbsp;</td>
            <td >
            <asp:TextBox ID="txt_rep_telephone" runat="server" Width="400px" CssClass="textbox" ReadOnly="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
            <td>
                &nbsp;E-MAIL:
                </td>
            <td >
            <asp:TextBox ID="txt_rep_email" runat="server" Width="400px" CssClass="textbox" ReadOnly="true"></asp:TextBox>
                   </td>
            </tr>
            <% if (cert_show > 0)
               { %>
              <tr>
                <td colspan="2" class="tbbg_left">
                    &nbsp;&nbsp;CERTIFICATE INFORMATION&gt;&gt;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;DATE OF PUBLICATION:</td>
                <td>
                    <asp:TextBox ID="txt_cert_publicationdate" runat="server" class="textbox" 
                        Width="100px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;DETAILS OF PUBLICATION:</td>
                <td>
                 <b>(kindly state the volume and page number of journal)</b><br />
                <asp:TextBox ID="txt_cert_details" runat="server" Width="400px" CssClass="textbox" 
                    Height="80px" TextMode="MultiLine"></asp:TextBox>               
                </td>
            </tr>
             <% } %>
              <% if ((ass_show > 0)||(merger_show > 0))
                 { %>
                   <tr>
                <td colspan="2" style="background-color:#999999;" align="left">
                    &nbsp;</td>
            </tr>
              <tr>
                <td>
                    &nbsp;ASSIGNMENT OR MERGER?</td>
                <td align="left">
                   
                    <asp:RadioButtonList ID="select_merger_ass"  OnSelectedIndexChanged="Gender_SelectedIndexChanged" runat="server" AutoPostBack="True" 
                        RepeatDirection="Horizontal">
                    <asp:ListItem Value="Assignment" Text="Assignment"></asp:ListItem>
                    <asp:ListItem Value="Merger" Text="Merger"></asp:ListItem>
                    </asp:RadioButtonList>
                   
                </td>
            </tr>
              <% } %>
              <% if ((ass_show > 0) && (select_merger_ass.SelectedValue == "Assignment"))
                 { %>
            <tr>
                <td colspan="2" class="tbbg_left">
                    &nbsp;&nbsp;ASSIGNMENT INFORMATION (ONLY APPLICABLE TO ASSIGNMENT REQUEST)&gt;&gt;</td>
            </tr>
            <tr>
                <td colspan="2" style="background-color:#999999;" align="left">
                    &nbsp;ASSIGNEE</td>
            </tr>
            <tr>
                <td>
                    &nbsp;NAME:</td>
                <td>
                    <asp:TextBox ID="txt_assignee_name" runat="server" class="textbox" 
                        Width="400px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;ADDRESS:</td>
                <td>
                <asp:TextBox ID="txt_assignee_address" runat="server" Width="400px" CssClass="textbox" 
                    Height="80px" TextMode="MultiLine"></asp:TextBox>               
                </td>
            </tr>
             <tr>
            <td align="left">
                &nbsp;NATIONALITY :
            </td>
            <td align="left" >
                <asp:DropDownList ID="select_assignee_nationality" runat="server" CssClass="textbox" DataSourceID="ds_Nationality" DataTextField="name" 
                    DataValueField="ID" >
                </asp:DropDownList>
               
                     </td>
            </tr>
            <tr>
                <td colspan="2" style="background-color:#999999;" align="left">
                    &nbsp;ASSIGNOR</td>
            </tr>
            <tr>
                <td>
                    &nbsp;NAME:</td>
                <td>
                    <asp:TextBox ID="txt_assignor_name" runat="server" class="textbox" 
                        Width="400px"></asp:TextBox>
                </td>
            </tr>            
            <tr>
                <td>
                    &nbsp;ADDRESS:</td>
                <td>
                <asp:TextBox ID="txt_assignor_address" runat="server" Width="400px" CssClass="textbox" 
                    Height="80px" TextMode="MultiLine"></asp:TextBox>               
                </td>
            </tr>
             <tr>
            <td align="left">
                &nbsp;NATIONALITY :
            </td>
            <td align="left" >
                <asp:DropDownList ID="select_assignor_nationality" runat="server" CssClass="textbox" DataSourceID="ds_Nationality" DataTextField="name" 
                    DataValueField="ID" >
                </asp:DropDownList>
               
                     </td>
            </tr>
            <tr>
                <td colspan="2" style="background-color:#999999;" align="left">&nbsp;</td>
            </tr>
             <tr>
                <td width="20%">
                    &nbsp;ASSIGNMENT DATE:</td>
                <td>        
                    <asp:TextBox ID="txt_assignment_date" runat="server" class="textbox" 
                            Width="100px"></asp:TextBox>
                </td>
            </tr>
             <% } %>
               <% if ((merger_show > 0) && (select_merger_ass.SelectedValue == "Merger"))
                 { %>
            <tr>
                <td colspan="2" class="tbbg_left">
                    &nbsp;&nbsp;MERGER INFORMATION &gt;&gt;</td>
            </tr>
            <tr>
                <td colspan="2" style="background-color:#999999;" align="left">
                    &nbsp;ORIGINAL APPLICANT INFORMATION</td>
            </tr>
            <tr>
                <td>
                    &nbsp;NAME:</td>
                <td>
                    <asp:TextBox ID="txt_original_name" runat="server" class="textbox" 
                        Width="400px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;ADDRESS:</td>
                <td>
                <asp:TextBox ID="txt_original_address" runat="server" Width="400px" CssClass="textbox" 
                    Height="80px" TextMode="MultiLine"></asp:TextBox>               
                </td>
            </tr>
           
            <tr>
                <td colspan="2" style="background-color:#999999;" align="left">
                    &nbsp;MERGING APPLICANT INFORMATION</td>
            </tr>
            <tr>
                <td>
                    &nbsp;NAME:</td>
                <td>
                    <asp:TextBox ID="txt_merging_name" runat="server" class="textbox" 
                        Width="400px"></asp:TextBox>
                </td>
            </tr>            
            <tr>
                <td>
                    &nbsp;ADDRESS:</td>
                <td>
                <asp:TextBox ID="txt_merging_address" runat="server" Width="400px" CssClass="textbox" 
                    Height="80px" TextMode="MultiLine"></asp:TextBox>               
                </td>
            </tr>
             <tr>
                <td colspan="2" style="background-color:#999999;" align="left">&nbsp;</td>
            </tr>
             <tr>
                <td>
                    &nbsp;MERGED COMPANY NAME:</td>
                <td>
                    <asp:TextBox ID="txt_merged_coy_name" runat="server" class="textbox" 
                        Width="400px"></asp:TextBox>
                </td>
            </tr>    
             <tr>
                <td>
                    &nbsp;MERGER DATE:</td>
                <td>
                    <asp:TextBox ID="txt_merger_date" runat="server" class="textbox" 
                        Width="100px"></asp:TextBox>
                </td>
            </tr>    
             <% } %>
              <% if (change_show > 0)
                 { %>
            <tr>
                <td colspan="2" class="tbbg_left">
                    &nbsp;CHANGE INFORMATION (ONLY APPLICABLE TO CHANGES AND WILL BE TREATED BASED ON PAYMENT CONFIRMATION. PLEASE FILL THE INFORMATION THAT RELATES TO REQUEST TYPE &gt;&gt;</td>
            </tr>
            <tr>
                <td colspan="2" style="background-color:#999999;" align="left">
                    &nbsp;OLD APPLICANT DETAILS</td>
            </tr>
            <tr>
                <td>
                    &nbsp;APPLICANT NAME:</td>
                <td>
                    <asp:TextBox ID="txt_old_applicant_trademark" runat="server" Width="400px" CssClass="textbox" 
                    Height="40px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;APPLICANT ADDRESS:</td>
                <td>
                <asp:TextBox ID="txt_old_applicant_address" runat="server" Width="400px" CssClass="textbox" 
                    Height="80px" TextMode="MultiLine"></asp:TextBox>               
                </td>
            </tr>
         
            <tr>
                <td colspan="2" style="background-color:#999999;" align="left">
                    &nbsp;NEW APPLICANT DETAILS</td>
            </tr>
            <tr>
                <td>
                    &nbsp;APPLICANT NAME:</td>
                <td>
                    <asp:TextBox ID="txt_new_applicant_trademark" runat="server" Width="400px" CssClass="textbox" 
                    Height="40px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;APPLICANT ADDRESS:</td>
                <td>
                <asp:TextBox ID="txt_new_applicant_address" runat="server" Width="400px" CssClass="textbox" 
                    Height="80px" TextMode="MultiLine"></asp:TextBox>               
                </td>
            </tr>
            
             <% } %>
              <% if (prelim_show > 0)
                 { %>
              <tr>
                <td colspan="2" class="tbbg_left">
                    &nbsp;&nbsp;PRELIMINARY SEARCH INFORMATION &gt;&gt;</td>
            </tr>
           
            <tr>
                <td>
                    &nbsp;TITLE:</td>
                <td>
                    <asp:TextBox ID="txt_prelim_title" runat="server" class="textbox" 
                        Width="400px"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td>
                    &nbsp;CLASS OF GOODS/SERVICES:</td>
                <td>
                    <asp:DropDownList ID="select_prelim_class" runat="server" CssClass="textbox" 
                    DataSourceID="ds_Class" DataTextField="type" DataValueField="xID" >
                </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;DESCRIPTION OF GOODS/SERVICES:</td>
                <td>
                <asp:TextBox ID="txt_prelim_desc" runat="server" Width="400px" CssClass="textbox" 
                    Height="80px" TextMode="MultiLine"></asp:TextBox>               
                </td>
            </tr>
            <% } %>
             <% if (renewal_show > 0)
                 { %>
              <tr>
                <td colspan="2" class="tbbg_left">
                    &nbsp;&nbsp;RENEWAL INFORMATION &gt;&gt;</td>
            </tr>
           
            <tr>
                <td>
                    &nbsp;DATE OF LAST RENEWAL:</td>
                <td>
                   <asp:TextBox ID="txt_renewal_date" runat="server" class="textbox" 
                        Width="100px"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td>
                    &nbsp;IS THIS YOUR FIRST RENEWAL?</td>
                <td align="left">
                   
                    <asp:RadioButtonList ID="rbl_first_renewal" runat="server" AutoPostBack="True" 
                        RepeatDirection="Horizontal">
                    <asp:ListItem Value="Yes" Text="Yes"></asp:ListItem>
                    <asp:ListItem Value="No" Text="No"></asp:ListItem>
                    </asp:RadioButtonList>
                   
                </td>
            </tr>
             <% if (rbl_first_renewal.SelectedValue=="No")
                 { %>
            <tr>
                <td>
                    &nbsp;SELECT RENEWAL TYPE:</td>
                <td>
                 <asp:DropDownList ID="select_renewal_type" runat="server" CssClass="textbox" >
                </asp:DropDownList>              
                </td>
            </tr>
            <% } %>
            <% } %>

             <% if (others_show > 0)
                 { %>
            <tr>
                <td colspan="2" class="tbbg_left">
                    &nbsp;&nbsp;<%=ti.item_code %>(<%=lbl_type.Text.ToUpper() %>) INFORMATION &gt;&gt;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;DETAILS OF REQUEST:</td>
                <td>
                <asp:TextBox ID="txt_details_of_request" runat="server" Width="400px" CssClass="textbox" 
                    Height="80px" TextMode="MultiLine"></asp:TextBox>               
                </td>
            </tr>
             <% } %>

            
           
            <tr>
                <td colspan="2" style="background-color:#999999;" align="left">&nbsp;</td>
            </tr>
            <table style="width:100%;font-family:Calibri;" id="doc_tbl" align="center">
            <tr>
                    <td class="tbbg" colspan="2">                       
                        PLEASE ENTER THE NUMBER OF PAGES OF EACH ITEM ACCOMPANYING THIS FORM AND ATTACH 
                        DOCUMENTS BELOW :</td>
                </tr>
              
                <tr>
                    <td align="center" colspan="2" style="color:Red; font-size:16px;">
                       <strong>
                        (NOTE: DOCUMENTS ATTACHED SHOULD BE OF PDF FORMAT ONLY AND NOT MORE THAN 3MB EACH!!)</strong> </td>
                </tr>
                <tr style="background-color:#999999;">
                    <td align="left" class="tbbg_left2" style="width:25%;">
                        &nbsp;ITEMS</td>
                    <td align="left" class="tbbg_left2">
                        ATTACH DOCUMENT</td>
                </tr>
                <%if ((logo_desc == "yes")&&(app_doc_newfilename == ""))
                  { %>
                <tr>
                    <td align="left">
                        &nbsp;TRADEMARK REPRESENTATION :
                    </td>
                    <td align="left">
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
                    <td colspan="2" align="center">
                     
                    </td>
                </tr>
                 <%} %>
                 <%if (app_doc_newfilename == "")
                  { %>
                <tr>
                    <td align="left">
                        &nbsp;APPLICATION LETTER :
                    </td>
                    <td align="left">
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
                    <td colspan="2"></td>
                </tr>
                <%} %>
                <%if (sup_doc_newfilename == "")
                  { %>
                <tr>
                    <td align="left">
                        &nbsp;COPY OF CERTIFICATE OF REGISTRATION:
                    </td>
                    <td align="left">
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
                    <td colspan="2"></td>
                </tr>
                <%} %>
                 <%if (app_type == "cert")
                  { %>
                <tr>
                    <td align="left">
                        &nbsp;COPY OF CERTIFICATE:
                    </td>
                    <td align="left">
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
                    <td colspan="2"></td>
                </tr>
                <%} %>
                <%if (app_type == "ass")
                  { %>
                <tr>
                    <td align="left">
                        &nbsp;COPY OF ASSIGNMENT:</td>
                    <td align="left">
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
                    <td align="left">
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
                    <td align="left">
                        <upload:inputfile ID="fu_pub_doc" runat="server" CssClass="textbox" />
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
                    <td colspan="2" align="center">
                          <upload:progressbar id="pb_all_doc" runat="server" inline="true" Text="" /></td>
                </tr>


                </table>
             <tr>
            <td  align="center" colspan="2">            
                <span style="font-size:20px; color:#f00; font-weight:bolder;"><%=show_imageMsg %></span></td>
        </tr>
            <tr>
                <td colspan="2" align="center">
            
                 <asp:Button ID="SaveAll" runat="server" Text="Submit Application"  class="button" 
                    onclick="SaveAll_Click" />
                </td>
            </tr>           
            </table>
            
    
    </div>
    </td>
    </tr>
    </table>

      </asp:Panel>
      <asp:Panel ID="tt3" Visible="false" runat="server">
           <table align="center" width="1200px">
            <tr >
                <td >
    <div id="searchform">                
        <table style="font-family:Calibri;" id="applicantForm" align="center" class="xsearchform">
            <tr align="center">
                <td colspan="4">
                    <img alt="Coat Of Arms" height="79" src="../images/coat_of_arms.png" 
                        width="85" />
               </td>
            </tr>
            <tr align="center" style=" font-size:11pt;" >
                <td colspan="4">
                    FEDERAL REPUBLIC OF NIGERIA<br />
                    FEDERAL MINISTRY OF INDUSTRY, TRADE AND INVESTMENT<br />
                    COMMERCIAL LAW DEPARTMENT<br />
                    TRADEMARKS, PATENTS AND DESIGNS REGISTRY
</td>
            </tr>
            
            <tr>
                <td colspan="4" style="font-size:18pt;line-height:115%;" align="center">
                        REQUEST FORM<br />

                </td>
            </tr>
           
             <tr>
                <td colspan="4" 
                     
                     
                     style="background-color:#1C5E55; color:#ffffff; text-align:center; font-weight:bold;">
                    --- APPLICATION INFORMATION ---</td>
            </tr>
            <tr>
                <td width="50%" align="right" colspan="2">
                    &nbsp;REQUEST FORM TYPE:</td>
                <td width="50%" align="left" colspan="2">        
                    <b><asp:Label ID="Label1" runat="server" Text=""></asp:Label></b>
                </td>
            </tr>
            
            <tr>
                <td width="50%" align="right" colspan="2">
                    ONLINE REQUEST ID:</td>
                <td width="50%" align="left" colspan="2">        
                    <%=g_pwallet.validationID%></td>
            </tr>
            
            <tr>
                <td width="25%" align="right"  style="width: 25%">
                    REQUEST NUMBER: </td>
                <td width="25%" align="left" style="width: 25%">        
                    <b> <%=g_tm_info.reg_number%></b></td>
                <td width="25%" align="right" style="width: 25%">        
                     REQUEST DATE:</td>
                <td width="25%" align="left" style="width: 25%">        
                   <%=g_app_info.reg_date%></td>
            </tr>
            
            
           
           
             <tr>
                <td colspan="4" 
                     
                     
                     style="background-color:#1C5E55; color:#ffffff; text-align:center; font-weight:bold;">
                    --- APPLICANT INFORMATION ---</td>
            </tr>
            <tr>
                <td colspan="2" align="right">
                    &nbsp;APPLICANT NAME:&nbsp;</td>
                <td colspan="2" align="left">
                  <%= g_applicant_info.xname%>
                </td>
            </tr>
            
            <tr>
                <td colspan="4" align="center">
                   APPLICANT ADDRESS:</td>
            </tr>
            
            <tr>
                <td colspan="4" align="center">
                    <%= g_applicant_info.address%></td>
            </tr>
            
            <tr>
                <td align="right">
                    APPLICANT E-MAIL:&nbsp;</td>
                <td align="left">
                   <%= g_applicant_info.xemail%></td>
                <td align="right">
                  APPLICANT PHONE NUMBER:&nbsp; 
                </td>
                <td align="left">
                     <%= g_applicant_info.xmobile%></td>
            </tr>
            
          
             <tr>
                <td align="right">
                    TRADING AS:&nbsp;</td>
                <td align="left">
                   <%= g_applicant_info.trading_as%></td>
                <td align="right">
                  NATIONALITY: &nbsp;  
                </td>
                <td align="left">
                 <%= g_applicant_info.nationality%>
                   </td>
            </tr>             
            
            <tr>
                <td colspan="4" 
                    
                    
                    style="background-color:#1C5E55; color:#ffffff; text-align:center; font-weight:bold;">
                    --- TRADEMARK INFORMATON ---</td>
            </tr>
            
            <tr>
                <td colspan="4" align="center" >
                    &nbsp;TITLE OF TRADEMARK:</td>
            </tr>           
            
            <tr>
                <td colspan="4" align="center" >
                   <%= g_tm_info.tm_title%></td>
            </tr>   
             <tr>
                <td  style="text-align:right;" colspan="2">
                   &nbsp;FILING DATE:</td>
                <td style="text-align:LEFT;" colspan="2">  <%=g_app_info.filing_date%></td>
            </tr>     

            <tr>
                <td  style="width: 25%;text-align:right;">
                    &nbsp;RTM NUMBER(If any):</td>
                <td  style="width: 25%;text-align:left;">
                    <%=g_app_info.rtm_number%></td>
                <td style="width: 25%;text-align:right;">FILE/TP NUMBER:</td>
                <td style="width: 25%;text-align:left;"> <%=g_app_info.application_no%></td>
            </tr>            
             <tr>
                <td colspan="4" align="center">
                    &nbsp;CLASS:</td>
            </tr>           
             
                      
            <tr>
                <td colspan="4" align="center">
                    <%= g_tm_info.tm_class%></td>
            </tr>        
                    
            <tr>
                <td colspan="4" align="center">
                    &nbsp;DESCRIPTION OF GOODS AND SERVICES:</td>
            </tr>           
                      
            <tr>
                <td colspan="4" align="center">
                    <%= g_tm_info.tm_desc%></td>
            </tr>           
                      
            <tr>
                <td colspan="4" align="center">
                    &nbsp;DISCLAIMER(If any):</td>
            </tr>

           
                      
            <tr>
                <td colspan="4" align="center">
                   <%= g_tm_info.disclaimer%></td>
            </tr>
              <tr>
                <td colspan="2" align="right" >
                    LOGO DESCRIPTION:</td>

                 <td colspan="2" align="left" >
                   <%=   logo_description.SelectedItem.Text%></td>
                 <td>

                 </td>
                  <td>

                 </td>
            </tr>
            <tr>
                <td colspan="4" 
                     
                    
                    style="background-color:#1C5E55; color:#ffffff; text-align:center; font-weight:bold;">
                   --- TRADEMARK REPRESENTATION --- </td>
            </tr>
             <tr>
            <td align="center" colspan="4">   
                
                 <% if ((g_tm_info.logo_pic != "") && (g_tm_info.logo_pic != "0") && (g_tm_info.logo_pic !=null))
                    {%>
                <asp:Image ID="tm_img2" runat="server" />
                <% }
                    else
                    { %> NO DEVICE!!
                <% } %>
                </td>
        </tr>

             <tr>
                <td colspan="4" 
                     
                     
                     style="background-color:#1C5E55; color:#ffffff; text-align:center; font-weight:bold;">
                   --- ATTORNEY INFORMATION ---</td>
            </tr>
            <tr>
            <td align="right">
                CODE:&nbsp;</td>
            <td align="left">
                 <%=g_agent_info.code%></td>
            <td align="right">
              NAME:&nbsp;              
                </td>
            <td align="left">
            <%=g_agent_info.xname%>
               </td>
            </tr>            
            
            <tr>
            <td colspan="4" 
                    
                    
                    style="background-color:#999999; color:#000000; text-align:center; font-weight:bold;">
                --- ADDRESS INFORMATION ---</td>
            </tr>
            <tr>
            <td align="right">
                &nbsp;COUNTRY :
            </td>
            <td align="left">
                 <%=g_agent_info.country%></td>
            <td align="right">
            STATE:&nbsp;
           </td>
            <td align="left">
             <%=g_agent_info.state%>
               </td>
            </tr>
            <tr>   
            <td  colspan="4" align="center">             
                 ADDRESS:  
               </td>
            </tr>

            <tr>   
            <td  colspan="4" align="center">             
                  <%=g_agent_info.address%>         
            </td>
           
            </tr>
            
            <tr>
            <td align="right">
              TELEPHONE:&nbsp;</td>
            <td align="left">
                <%=g_applicant_info.xmobile%></td>
            <td align="right">
             E-MAIL:&nbsp;
                </td>
            <td align="left">
             <%=g_applicant_info.xemail%>
                </td>
            </tr>
            
             <tr>
            <td colspan="4" 
                
                     
                     style="background-color:#1C5E55; color:#ffffff; text-align:center; font-weight:bold;">
                --- PAYMENT INFORMATION ---
            </td>
        </tr>
           <tr>
            <td colspan="4">&nbsp;</td>
        </tr>
         <tr>
            <td align="center" colspan="2">
                TRANSACTION ID : </td>
            <td align="center" colspan="2">
                 TRANSACTION AMOUNT : 
               </td>
        </tr>
        
         <tr>
            <td align="center" colspan="2">
                 <% Response.Write(g_pwallet.validationID); %></td>
            <td align="center" colspan="2">
                 <% Response.Write(g_pwallet.amt); %></td>
        </tr>

            <% if (cert_show > 0)
               { %>
              <tr>
                <td colspan="4" 
                      
                      
                      style="background-color:#1C5E55; color:#ffffff; text-align:center; font-weight:bold;">
                    --- CERTIFICATE INFORMATION ---</td>
            </tr>
            <tr>
                <td colspan="2" align="right">
                    &nbsp;DATE OF PUBLICATION:</td>
                <td colspan="2" align="left">
                 <%= g_cert_info.pub_date%>
                </td>
            </tr>
            <tr>
                <td colspan="4" align="center">
                    &nbsp;DETAILS OF PUBLICATION:</td>
               
            </tr>
            <tr>               
                <td colspan="4" align="center">
                <%= g_cert_info.pub_details%>           
                </td>
            </tr>
             <% } %>
              
              <% if (ass_show > 0)
                 { %>
            <tr>
                <td colspan="4" 
                    
                    
                    style="background-color:#1C5E55; color:#ffffff; text-align:center; font-weight:bold;">
                    --- ASSIGNMENT INFORMATION ---</td>
            </tr>
            <tr>
                <td colspan="4" 
                    
                    
                    style="background-color:#999999; color:#000000; text-align:center; font-weight:bold;">
                    ASSIGNEE</td>
            </tr>
            <tr>
                <td colspan="2" align="right">
                    &nbsp;NAME:</td>
                <td colspan="2" align="left">
                    <%= g_ass_info.assignee_name%>
                </td>
            </tr>
            <tr>
                <td colspan="4" align="center">
                    ADDRESS:</td>               
            </tr>
            <tr>               
                <td colspan="4" align="center">
                <%= g_ass_info.assignee_address%>            
                </td>
            </tr>
             <tr>
            <td align="right" colspan="2">
                &nbsp;NATIONALITY :
            </td>
            <td align="left" colspan="2" >
                 <%= g_applicant_info.nationality%>
                     </td>
            </tr>
            <tr>
                <td colspan="4" 
                    
                    
                    style="background-color:#999999; color:#000000; text-align:center; font-weight:bold;">
                    ASSIGNOR</td>
            </tr>
            <tr>
                <td colspan="2" align="right">
                    &nbsp;NAME:</td>
                <td colspan="2" align="left">
                    <%= g_ass_info.assignor_name%>
                </td>
            </tr>
            <tr>
                <td colspan="4" align="center">
                    ADDRESS:</td>               
            </tr>
            <tr>               
                <td colspan="4" align="center">
                <%= g_ass_info.assignor_address%>            
                </td>
            </tr>
             <tr>
            <td align="right" colspan="2">
                &nbsp;NATIONALITY :
            </td>
            <td align="left" colspan="2" >
                 <%= g_applicant_info.nationality%>
                     </td>
            </tr>
            <tr>
                <td colspan="4" style="background-color:#999999;" align="left">&nbsp;</td>
            </tr>
             <tr>
                <td width="50%" colspan="2" align="right">
                    &nbsp;ASSIGNMENT DATE:</td>
                <td colspan="2" align="left">        
                    <%= g_ass_info.date_of_assignment%>
                </td>
            </tr>
             <% } %>
               <% if (merger_show > 0) 
                 { %>
            <tr>
                <td colspan="4" 
                    
                    
                    style="background-color:#1C5E55; color:#ffffff; text-align:center; font-weight:bold;">
                    --- MERGER INFORMATION ---</td>
            </tr>
            <tr>
                <td colspan="4" 
                    
                    
                    style="background-color:#999999; color:#000000; text-align:center; font-weight:bold;">
                    ORIGINAL APPLICANT INFORMATION</td>
            </tr>
            <tr>
                <td colspan="2" align="right">
                    &nbsp;NAME:</td>
                <td colspan="2"  align="left">
                     <%= g_merger_info.original_name%>
                </td>
            </tr>
            <tr>
                <td colspan="2"  align="right">
                    &nbsp;ADDRESS:</td>
                <td colspan="2"  align="left">
                <%= g_merger_info.original_address%>              
                </td>
            </tr>
           
            <tr>
                <td colspan="4" 
                    
                    
                    style="background-color:#999999; color:#000000; text-align:center; font-weight:bold;">
                    MERGING APPLICANT INFORMATION</td>
            </tr>
            <tr>
                <td colspan="2"  align="right">
                    &nbsp;NAME:</td>
                <td colspan="2"  align="left">
                    <%= g_merger_info.merging_name%>
                </td>
            </tr>            
            <tr>
                <td colspan="2"  align="right">
                    &nbsp;ADDRESS:</td>
                <td colspan="2"  align="left">
                <%= g_merger_info.merging_address%>           
                </td>
            </tr>
             <tr>
                <td colspan="4" style="background-color:#999999;" align="left">&nbsp;</td>
            </tr>
             <tr>
                <td colspan="2"  align="right">
                    &nbsp;MERGED COMPANY NAME:</td>
                <td colspan="2"  align="left">
                    <%= g_merger_info.merged_coy_name%>
                </td>
            </tr>    
             <tr>
                <td colspan="2"  align="right">
                    &nbsp;MERGER DATE:</td>
                <td colspan="2"  align="left">
                     <%= g_merger_info.merger_date%>
                </td>
            </tr>    
             <% } %>
              <% if (change_show > 0)
                 { %>
            <tr>
                <td colspan="4" 
                    
                    
                    style="background-color:#1C5E55; color:#ffffff; text-align:center; font-weight:bold;">
                    --- CHANGE INFORMATION ---</td>
            </tr>
            <tr>
                <td colspan="4" 
                    
                    
                    style="background-color:#999999; color:#000000; text-align:center; font-weight:bold;">
                    OLD APPLICANT DETAILS</td>
            </tr>
            <tr>
                <td colspan="2"  align="right">
                    &nbsp;APPLICANT NAME:</td>
                <td colspan="2"  align="left">
                     <%= g_change_info.old_name%>
                </td>
            </tr>
            <tr>
                <td colspan="2"  align="right">
                    &nbsp;APPLICANT ADDRESS:</td>
                <td colspan="2"  align="left">
                <%= g_change_info.old_address%>             
                </td>
            </tr>
          
            <tr>
                <td colspan="4" 
                    
                    
                    style="background-color:#999999; color:#000000; text-align:center; font-weight:bold;">
                    NEW APPLICANT DETAILS</td>
            </tr>
            <tr>
                <td colspan="2"  align="right">
                    &nbsp;APPLICANT NAME:</td>
                <td colspan="2"  align="left">
                    <%= g_change_info.new_name%> 
                </td>
            </tr>
            <tr>
                <td colspan="2"  align="right">
                    &nbsp;APPLICANT ADDRESS:</td>
                <td colspan="2"  align="left">
                <%= g_change_info.new_address%>              
                </td>
            </tr>
            
             <% } %>
              <% if (prelim_show > 0)
                 { %>
              <tr>
                <td colspan="4" 
                      
                      
                      style="background-color:#1C5E55; color:#ffffff; text-align:center; font-weight:bold;">
                    --- PRELIMINARY SEARCH INFORMATION ---</td>
            </tr>
           
            <tr>
                <td colspan="2"  align="right">
                    &nbsp;TITLE:</td>
                <td colspan="2"  align="left">
                    <%= g_prelim_search_info.xtitle%> 
                </td>
            </tr>
             <tr>
                <td colspan="2"  align="right">
                    &nbsp;CLASS OF GOODS/SERVICES:</td>
                <td colspan="2"  align="left">
                   <%= g_prelim_search_info.xclass%> 
                </td>
            </tr>
            <tr>
                <td colspan="2"  align="right">
                    &nbsp;DESCRIPTION OF GOODS/SERVICES:</td>
                <td colspan="2"  align="left">
                 <%= g_prelim_search_info.xclass_desc%>               
                </td>
            </tr>
            <% } %>
             <% if (renewal_show > 0)
                 { %>
              <tr>
                <td colspan="4" 
                      
                      
                      style="background-color:#1C5E55; color:#ffffff; text-align:center; font-weight:bold;">
                    --- RENEWAL INFORMATION ---</td>
            </tr>
           
            <tr>
                <td align="right">
                    DATE OF LAST RENEWAL:</td>
                <td align="left">
                   <%= g_renewal_info.prev_renewal_date%> </td>
                <td align="right">
                  NEXT RENEWAL DATE: 
                </td>
                <td align="left">
                    <%= g_renewal_info.reg_date%></td>
            </tr>             
            
            <tr>
                <td colspan="2"  align="right">
                    &nbsp;NUMBER OF RENEWALS:</td>
                <td colspan="2"  align="left">
                  <%= g_renewal_info.renewal_type%>              
                </td>
            </tr>
             
            <% } %>

             <% if (others_show > 0)
                 { %>
            <tr>
                <td colspan="4" 
                    
                    
                    style="background-color:#1C5E55; color:#ffffff; text-align:center; font-weight:bold;">
                    --- <%=g_app_info.item_code %> (<%=lbl_type.Text.ToUpper() %>) INFORMATION ---</td>
            </tr>
            <tr>
                <td colspan="2" align="right">
                   DETAILS OF REQUEST:</td>
                <td colspan="2" align="left">
                 <%= g_other_items_info.req_details%>               
                </td>
            </tr>
             <% } %>

            
           
            <tr>
                <td colspan="4" style="background-color:#999999;" align="left">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="4" align="center">            
                     <strong>Your application has been received and is receiving due attention</strong><br />
             <strong>REGISTRAR 
                (COMMERCIAL LAW DEPARTMENT NIGERIA)</strong> <br /></td>
            </tr>           
            </table>           
    </div>
     <table width="100%">
            <tr >
            <td colspan="4" align="center">
            <div style="float:left;width:100%;">
                <input type="button" name="Printform" id="Printform" value="Print" onclick="printGf('searchform'); return false" class="button" />
                <asp:Button ID="btnDashBoard" runat="server" Text="Back to Dashboard" class="button" onclick="btnDashBoard_Click" />
                </div>
           </td>
        </tr>
        </table>  
    </td>
    </tr>
    </table>

      </asp:Panel>
</div>
    </form>
</body>
</html>
