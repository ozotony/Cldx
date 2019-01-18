<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="preview_r_detailsx.ascx.cs" Inherits="cld.admin.tm.preview_r_detailsx" %>
<link href="../../css/style.css" rel="stylesheet" type="text/css" />

<script src="../../js/funk.js" type="text/javascript"></script>

<div>
    <div class="container">
        <div class="sidebar">
            <a href="./registrar_unit/profile_index.aspx">PROFILE</a>
            <a href="../../cp.aspx?x=<% Response.Write(admin); %>">CHANGE PASSWORD</a>
            <a href="./registrar_unit/profile_index.aspx">VIEW STATISTICS</a>
            <a href="./preview_r.aspx?x=1&d=Invalid">INVALID APPS</a> 
            <a href="./preview_r.aspx?x=2&d=Valid">VALID APPS</a> 
            <a href="./preview_r.aspx?x=3&d=Approved">APPROVED APPS</a> 
            <a href="./preview_r.aspx?x=1&d=Disapproved">DISAPPROVED APPS</a> 
            <a href="./preview_r.aspx?x=4&d=Registrable">EXAMINED APPS</a> 
            <a href="./preview_r.aspx?x=5&d=Accepted">ACCEPTED APPS</a> 
            <a href="./preview_r.aspx?x=3&d=Refused">UN-ACCEPTED APPS</a> 
            <a href="./preview_r.aspx?x=6&d=Published">PUBLISHED APPS</a> 
            <a href="./preview_r.aspx?x=7&d=Not Opposed">UNOPPOSED APPS</a> 
            <a href="./preview_r.aspx?x=5&d=Opposed">OPPOSED APPS</a> 
            <a href="./preview_r.aspx?x=8&d=Certified">CERTIFIED APPS</a> 
            <a href="./preview_r.aspx?x=9&d=Registered">REGISTERED APPS</a>
           
        </div>
        <div class="content">
            <div class="header">
                <div class="xmenu">
                    <div class="menu">
                        <ul>
                            <li><a href="./lo.aspx">
                                <img alt="" src="../../images/logoff.png" width="16" height="16" />Log off</a></li>
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
            <div id="searchform">
                <table align="center" width="100%" class="form">
                    <tr>
                        <td colspan="2" align="center" width="100%">
                            <strong>FEDERAL MINISTRY OF TRADE AND INVESTMENT<br />
                                COMMERCIAL LAW DEPARTMENT<br />
                                INDUSTRIAL PROPERTY OFFICE REGISTRY </strong>
                        </td>
                    </tr>
                    <tr>
                        <td width="22%" colspan="2" align="center" bgcolor="#006600">
                            <img src="../../images/coat_of_arms.png" style="width: 80px; height: 80px" />
                        </td>
                    </tr>
                    <tr>
                        <td width="22%" colspan="2" align="center">
                            <strong>CERTIFICATE OF REGISTRATION OF TRADEMARK<br />
                                TRADEMARKS ACT<br />
                                (CAP 436 LAWS OF THE FEDERATION OF NIGERIA 1990, SECTION 22(3)REGULATION 65)<br />
                                THE TRADEMARK SHOWN BELOW HAS BEEN REGISTERED IN PART A (OR B) OF THE REGISTRAR</strong>
                        </td>
                    </tr>
                    <tr>
                        <td width="22%" colspan="2" class="tbbg">
                            <strong>---TRADEMARK INFORMATION---</strong>
                        </td>
                    </tr>
                    <tr>
                        <td width="50%" align="right">
                            &nbsp;FILLING/APPLICATION DATE :&nbsp;&nbsp;
                        </td>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="Label"><% Response.Write(lt_mi[0].reg_date); %></asp:Label>&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            REGISTRATION NUMBER :&nbsp;&nbsp;
                        </td>
                        <td>
                            <asp:Label ID="Label2" runat="server" Text="Label"><% Response.Write(lt_mi[0].reg_number.ToUpper()); %></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="tbbg" colspan="2" align="center">
                            --- TRADEMARK INFORMATION ---
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            &nbsp;TITLE OF PRODUCT :&nbsp;&nbsp;
                        </td>
                        <td>
                            <asp:Label ID="Label3" runat="server" Text="Label"><% Response.Write(lt_mi[0].product_title.ToUpper()); %></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            &nbsp;NATIONAL CLASS :&nbsp;&nbsp;
                        </td>
                        <td>
                            <asp:Label ID="Label4" runat="server" Text="Label"><% Response.Write(lt_mi[0].national_classID); %></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            &nbsp; NATIONAL CLASS DESCRIPTION :&nbsp;
                        </td>
                        <td>
                            <asp:Label ID="Label5" runat="server" Text="Label"><% Response.Write(t.getNationalClassDesc(lt_mi[0].national_classID).ToUpper()); %></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            &nbsp; ONLINE APPLICATION ID :&nbsp;&nbsp;
                        </td>
                        <td>
                            <asp:Label ID="Label6" runat="server" Text="Label"><% Response.Write("OAI/TM/"+t.ValidationIDByPwalletID(lt_mi[0].log_staff) ); %></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="tbbg" colspan="2" align="center">
                            --- TRADEMARK IMAGE ---
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                            <img src="<% Response.Write(lt_mi[0].logo_pic); %>" height="30%" width="30%" />
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td class="tbbg" colspan="2">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <strong>&nbsp;THE TRADEMARK REGISTRY,<br />
                                &nbsp;INDUSTRIAL PROPERTY OFFICE NIGERIA,<br />
                                &nbsp;FEDERAL MINISTRY OF TRADE AND INVESTMENT,<br />
                                &nbsp;FEDERAL CAPITAL TERRITORY,<br />
                                &nbsp;ABUJA,NIGERIA </strong>
                        </td>
                        <td align="right">
                            Signed :REGISTRAR OF TRADEMARKS&nbsp;&nbsp; </strong>
                        </td>
                    </tr>
                    <tr>
                        <td class="tbbg" colspan="2">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                            REGISTRATION IS 7 YEARS FROM THE DATE OF FILLING AND MAY THEN BE RENEWED ALD ALSO AT THE EXPIRATION
                            <br />
                            OF EACH PERIOD OF 14 YEARS THEREAFTER.<br />
                            THIS CERTIFICATE IS NOT FOR USE IN THE LEGAL PRECEEDINGS OR FOR OBTAINING REGISTRATION ABROAD.<br />
                            UPON ANY CHANGE OF OWNERSHIP OF THIS TRADEMARK, OR CHANGE IN ADDRESS, AN APPLICATION SHOULD BE AT ONCE MADE<br />
                            TO THE <strong>REGISTRAR</strong> TO REGISTER THE CHANGE &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2" class="tbbg">
                           
                            &nbsp;</td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</div>
