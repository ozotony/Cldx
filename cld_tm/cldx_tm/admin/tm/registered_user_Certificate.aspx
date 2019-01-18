<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="registered_user_Certificate.aspx.cs" Inherits="cld.admin.tm.registered_user_Certificate" %>

<!DOCTYPE html>

<HTML>
<HEAD>
	<META HTTP-EQUIV="CONTENT-TYPE" CONTENT="text/html; charset=utf-8">
	<TITLE></TITLE>
	<META NAME="GENERATOR" CONTENT="LibreOffice 4.1.6.2 (Linux)">
	<META NAME="AUTHOR" CONTENT="Administrator">
	<META NAME="CREATED" CONTENT="20160906;130600000000000">
	<META NAME="CHANGEDBY" CONTENT="HP">
	<META NAME="CHANGED" CONTENT="20160906;161400000000000">
	<STYLE TYPE="text/css">
	<!--
		@page { size: 8.5in 11in; margin: 0.27in }
		P { margin-bottom: 0.08in; direction: ltr; color: #000000; widows: 2; orphans: 2 }
		P.western { font-family: "Times New Roman", serif; font-size: 10pt; so-language: en-ZW }
		P.cjk { font-family: "Times New Roman", serif; font-size: 10pt }
		P.ctl { font-family: "Times New Roman", serif; font-size: 10pt; so-language: ar-SA }
	-->
	</STYLE>

               <script src="../../js/funk.js"></script>
        <style>
            .pageheader{
    width:  100%;
    height: 40px;
    padding: 10px;
    color: #fff;
    margin-top: 30px;
    margin-bottom: 10px;
    background: #006699;
     text-align: center;
}
            .btn-default{
                background-color: #006699;
                color: #fff;
                padding: 10px;
            }
            body{
                font-family:  Calibri;
                font-size: 14px;
color:#000;
            }
            span{
                font-family: 'Times New Roman';
                font-size: 18px;
                font-weight: bold
            }
            label{
                font-family: Arial;
                font-size: 18px;
                font-weight: bold;
                text-align: center;
                width: 100%
            }
            r{
                display: inline;
                color: #f00
            }

                @media print
{     
        #dd2 {

      margin:auto;

      top: 0;
       width: 96%;
        height:  auto;

  
   /*margin-top:-25px;*/
   /*margin-left:-25px;*/
  

   }
    .no-print, .no-print *
    {
        display: none !important;
       
    }
}
        </style>
</HEAD>
<BODY LANG="en-US" TEXT="#000000" DIR="LTR" STYLE="border: 4.50pt double #000000; padding: 0in 0.85in">

    <div style="top: 0; width: 96%; height:  auto; margin:  auto ;   background: url('Coat_of_Arms_of_Nigeria.png')    no-repeat !important">


    <P LANG="en-ZW" CLASS="western" ALIGN=CENTER>
                
                <IMG src="../../images/coat_of_arms.png"  NAME="graphics1" ALIGN=BOTTOM WIDTH=113 HEIGHT=96 BORDER=0>


			</P>
<P LANG="en-ZW" CLASS="western" ALIGN=CENTER STYLE="margin-bottom: 0in">
<BR>
</P>
<P LANG="en-ZW" CLASS="western" ALIGN=CENTER STYLE="margin-bottom: 0in">
<FONT COLOR="#00b050"><FONT SIZE=5><B>NIGERIA</B></FONT></FONT></P>
<P LANG="en-ZW" CLASS="western" ALIGN=CENTER STYLE="margin-bottom: 0in">
<FONT COLOR="#00b050"><FONT SIZE=3><B>Trade Marks Act, 1990</B></FONT></FONT></P>
<P LANG="en-ZW" CLASS="western" ALIGN=CENTER STYLE="margin-bottom: 0in">
<BR>
</P>
<P LANG="en-ZW" CLASS="western" ALIGN=CENTER STYLE="margin-bottom: 0in">
<FONT COLOR="#00b050"><FONT SIZE=3><B>CERTIFICATE OF REGISTERED USER</B></FONT></FONT></P>
<P LANG="en-ZW" CLASS="western" ALIGN=CENTER STYLE="margin-bottom: 0in">
<BR>
</P>
<P LANG="en-ZW" CLASS="western" ALIGN=CENTER STYLE="margin-bottom: 0in">
<BR>
</P>
<P LANG="en-ZW" CLASS="western" STYLE="margin-bottom: 0in"><BR>
</P>
<P LANG="en-ZW" CLASS="western" STYLE="margin-bottom: 0in">To:</P>
<P LANG="en-ZW" CLASS="western" STYLE="margin-bottom: 0in"><% Response.Write(vd[0].NEW_APPLICANTNAME); %> </P>
<P LANG="en-ZW" CLASS="western" STYLE="margin-bottom: 0in"><% Response.Write(vd[0].NEW_APPLICANTADDRESS); %></P>
<P LANG="en-ZW" CLASS="western" STYLE="margin-bottom: 0in"><BR>
</P>
<P LANG="en-ZW" CLASS="western" STYLE="margin-bottom: 0in">I hereby
certify that your name has been entered on the Register as registered
user of Trade mark No <FONT > <b>  <% Response.Write(c_mark.reg_number.ToUpper()); %> </b> </FONT>
 and RTM<FONT > </FONT><FONT ><B>  <% Response.Write(c_stage.rtm); %></B></FONT><B>
</B>in class <FONT ><b>  <% Response.Write(c_mark.nice_class.ToUpper()); %> </b></FONT> in respect of <FONT ><b>  <% Response.Write(c_mark.nice_class_desc.ToUpper()); %> </b></FONT></P>
<P LANG="en-ZW" CLASS="western" STYLE="margin-bottom: 0in"><BR>
</P>
<P LANG="en-ZW" CLASS="western" STYLE="margin-bottom: 0in">A
representation of the said trademark is affixed hereto.</P>
<P LANG="en-ZW" CLASS="western" STYLE="margin-bottom: 0in"><BR>
</P>
<P LANG="en-ZW" CLASS="western" STYLE="margin-bottom: 0in">Witness my
hand this<FONT > </FONT><FONT ><B><% Response.Write(vd[0].RECORDAL_APPROVE_DATE.ToString("d")); %></B></FONT></P>
<P LANG="en-ZW" CLASS="western" STYLE="margin-bottom: 0in"><BR>
</P>
<P LANG="en-ZW" CLASS="western" STYLE="margin-bottom: 0in"><BR>
</P>
<TABLE WIDTH=225 CELLPADDING=7 CELLSPACING=0>
	<COL WIDTH=207>
	<TR>
		<TD WIDTH=207 VALIGN=TOP STYLE="border: 1.50pt solid #008000; padding: 0in 0.08in">
			<% if (c_mark.logo_pic != "")
                    {%>
                <asp:Image ID="tm_img" runat="server" />
                <% }
                    else
                    {
                        Response.Write("NO DEVICE!! </br> "+c_mark.product_title); %> 
                <% } %>
		</TD>
	</TR>
</TABLE>
<P LANG="en-ZW" CLASS="western" ALIGN=RIGHT STYLE="margin-bottom: 0in">
 
</P>
<P LANG="en-ZW" CLASS="western" ALIGN=RIGHT STYLE="margin-bottom: 0in">
<BR>
</P>
<P LANG="en-ZW" CLASS="western" ALIGN=RIGHT STYLE="margin-bottom: 0in">
<BR>
</P>
<P LANG="en-ZW" CLASS="western" ALIGN=RIGHT STYLE="margin-bottom: 0in">
<FONT ><% Response.Write(vofficer); %> </FONT></P>
<P LANG="en-ZW" CLASS="western" ALIGN=RIGHT STYLE="margin-bottom: 0in">
For Trade Marks Office, Abuja Nigeria 
</P>

<DIV TYPE=FOOTER>
	<P LANG="en-US" STYLE="margin-top: 0.45in; margin-bottom: 0in"><BR>
	</P>
     <input type="button" name="Printform" id="Printform"  value="Print" onclick="printAll(); return false" class="button no-print" />
</DIV>
        </div>
</BODY>
</HTML>