﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Change_Rectification_Certificate.aspx.cs" Inherits="cld.admin.tm.Change_Rectification_Certificate" %>

<!DOCTYPE html>

<html lang="en">
    <head>
        <meta charset="utf-8" />
        <title></title>
      
        <link href="../../css/bootstrap.min.css" rel="stylesheet" />
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
                font-family:  'Trebuchet MS';
            }
            span{
                font-family: Cooper;
                font-size: 14px;
                font-weight: bold
            }
            label{
                font-family: Arial;
                font-size: 18px;
                font-weight: bold;
                text-align: center;
                width: 100%
            }
            

               @media print
{     
     
    .no-print, .no-print *
    {
        display: none !important;
       
    }
}
        </style>
    </head>
    
    <body>
        
    <form class="form-login" role="form">

      <%--  <div style="width:100%; margin:auto; height:auto; border: 4px solid #077810">--%>
         <div style="width:98%; margin:auto; height:100%;   border: 6px solid #1861a4;">
            <div class="form-group" style="text-align: center; margin-top: 5px">
                <img src="../../images/coat_of_arms.png" />
               <br>
                <span>NIGERIA</span>
            </div>
            <div class="form-group" style="text-align: center; font-size: 10.5px">
            Federal Ministry of Industry, Trade and Investment<br>
Commercial Law Department,<br>
TRADEMARKS, PATENTS AND DESIGNS REGISTRY
                </div>
            <div style="top: 0; width: 96%; height:  auto; margin:  auto; background: url('Coat_of_Arms_of_Nigeria.png') no-repeat">
                <div style="width: 100%; text-align: left;">
                    <br/>
                <b>Date: <asp:Label ID="Label12" runat="server" Text="Label"></asp:Label></b><br/>
                    <br/>
                 Dear Sir(s),<br/>
                    
                </div>
            
            <div class="form-group">
                <label>AMENDMENT (CLERICAL ERRORS IN TRADEMARK TITLE) OF TRADEMARK</label>
                With reference to your FORM 26 Application dated <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>, this is to inform you that your request to change registered information on <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label> with File Number <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label> and RTM Number  <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label> in CLASS  <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label> has been effected. 
            </div>
            <div class="form-group" style="text-align: left">
              
               <b>RECORDAL INFORMATION: </b><br/>
                <br/>
                FROM : <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label><br/>
                <br/>
                TO : <asp:Label ID="Label7" runat="server" Text="Label"></asp:Label><br/>
                <br/>

                
                    OLD LOGO :<asp:Panel runat="server" style="display: inline" ID="tt2"  Visible="false" > NONE  </asp:Panel>  <asp:Image ID="tm_img" runat="server" /><br/>
                <br/>
                NEW LOGO : <asp:Panel runat="server" ID="tt3" style="display: inline" Visible="false" > NONE  </asp:Panel><asp:Image ID="tm_img2" runat="server" /><br/>
                <br/>

          
               
                <b>AGENT INFORMATION: </b><br/>
                <asp:Label ID="Label8" runat="server" Text="Label"></asp:Label><br/>
                <asp:Label ID="Label9" runat="server" Text="Label"></asp:Label><br/>
                 <asp:Label ID="Label10" runat="server" Text="Label"></asp:Label><br/>
                <asp:Label ID="Label11" runat="server" Text="Label"></asp:Label><br/>
                <br/>
               
                 
                Yours Faithfully,<br/>
               
               <%-- <img src="../../images/sig.jpg" width="100px" hidden="hidden" />--%>
               <br/>
               
                 <asp:Label ID="Label13" runat="server" Text="Label"></asp:Label>
                <br />
               <%-- NKIRU AGWU--%>
                
              
                FOR: Registrar,Trade Marks<br/>
               
                <br/>
                 
                <br/>
               
                 
            </div>
                
            <input type="button" name="Printform" id="Printform"  value="Print" onclick="printAll(); return false" class="button no-print" />
        </div>

    </form>
  
    </body>
</html>