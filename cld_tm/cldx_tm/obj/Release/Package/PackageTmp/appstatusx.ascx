<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="appstatusx.cs" Inherits="cld.appstatusx" %>

<link href="css/style.css" rel="stylesheet" type="text/css" />
<script src="js/jquery.js" type="text/javascript"></script>
<script src="js/funk.js" type="text/javascript"></script>

<table align="center" width="1200px">
            <tr >
                <td >                  
               
                 
           
            <table align="center" width="100%">
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
                        APPLICATION STATUS
                </td>
        </tr>
       
        
        <tr>
             <td colspan="2" style="font-size:18pt;line-height:115%;" align="center">
                        &nbsp;</td>
        </tr>
       
         <% if(showt==0) {%>
        <tr>
            <td colspan="2" align="left" class="tbbg">
                &nbsp;PLEASE ENTER YOUR TRANSACTION OR APPLICATION NUMBER TO CHECK YOUR STATUS</td>
        </tr>
       
        
        <tr>
            <td align="right">
                &nbsp;
                REFERENCE /APPLICATION NUMBER: &nbsp;
                  </td>
                
            <td style="width: 50%;">
            <asp:TextBox ID="xref" runat="server" Width="200px" CssClass="textbox"></asp:TextBox>
                </td>
        </tr>
        
        <tr>
            <td style="background-color:#999999; text-align:center;" colspan="2">
               
               </td>
        </tr>


        <tr>
            <td align="center" colspan="2">
               
                <asp:Button ID="Save" runat="server" Text="Check Status" OnClick="Save_Click" class="button" />
               
            </td>
        </tr>


    </table>
            <% }%>
            <% if (showt == 1)
               {%>
               <div id="searchform">
               <div class="xsearchform">
                <table align="center" class="form" id="table1">                  
                   
                    <tr>
                        <td width="100%" colspan="2" class="tbbg">
                            <strong>---STATUS INFORMATION---</strong>
                        </td>
                    </tr>
                    <% if (refill == 0)
                       { %>
                    <tr>
                        <td width="100%" align="justify" colspan="2">
                          <% Response.Write(msg); %>
                           
                        </td>
                    </tr>
                    <% }
                       else if(refill==1){ %>
                      
                      <tr>
                        <td width="100%" align="justify" colspan="2">
                         Dear 
                            <% Response.Write(lt_repx[0].xname); %>, 
                            <br /> This is to notify you that your application ("OAI/TM/<% Response.Write(r); %>&quot;) 
                            has not been completed successfully!!!<br /> Please click 
                            on the &quot;COMPLETE TRADEMARK APPLICATION&quot; button below to update the trademark 
                            details<br />
                            Thank you.
                        </td>
                    </tr>
                    <% } %>
                    <tr>
                        <td style="background-color:#999999; text-align:center;" colspan="2">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="left" style="width:50%">
                            <strong>&nbsp;THE TRADEMARK REGISTRY,<br />
                                &nbsp;COMMERCIAL LAW DEPARTMENT NIGERIA,<br />
                                &nbsp;FEDERAL MINISTRY OF TRADE AND INVESTMENT,<br />
                                &nbsp;FEDERAL CAPITAL TERRITORY,<br />
                                &nbsp;ABUJA,NIGERIA </strong>
                        </td>
                        <td align="right">
                            <strong>REGISTRAR OF TRADEMARKS&nbsp;&nbsp; </strong>
                           
                        </td>
                    </tr>
                   
                    <tr>
                        <td style="background-color:#999999; text-align:center;" colspan="2"> </td>
                    </tr>
                    
                </table>
               </div>
                </div>
             
               <table width="100%">
               <tr>
               <td align="center">
                <input type="button" name="Printform" id="Printform" value="PRINT" onclick="printAssessment(document.getElementById('searchform'));return false" class="button" />
                <% if (refill == 0)
                   { %>
                        <input type="button" name="btnReprint" id="btnReprint" value="REPRINT ACKNOWLEDGEMENT FORM"  onclick="doView('./tm_ackrep.aspx?0001234445= <% Response.Write(r); %>&94384238=<% Response.Write(agt); %>');" class="button" />

                        <% } else if (refill == 1)
                   { %>
                        <input type="button" name="btnCompleteTrademark" id="btnCompleteTrademark" 
                       value="COMPLETE TRADEMARK APPLICATION"  
                       onclick="doView('./tm_refill.aspx?XXX1234445=<% Response.Write(r); %>&XXX94384238=<% Response.Write(agt); %>');" 
                       class="button" />
                       <% }%>
                        <asp:Button ID="BtnCheckStatus" runat="server" Text="REFRESH SEARCH"  
                                CssClass="button" onclick="BtnCheckStatus_Click"/>
               </td>
               </tr>
               </table>
               
            <% }%>

        </td>
    </tr>
    </table>
