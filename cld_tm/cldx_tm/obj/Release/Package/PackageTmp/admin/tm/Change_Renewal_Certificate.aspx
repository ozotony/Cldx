<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Change_Renewal_Certificate.aspx.cs" Inherits="cld.admin.tm.Change_Renewal_Certificate" %>

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
    </head>
    
    <body>
        
    <form class="form-login" role="form">

        <div style="width:98%; margin:auto; height:100%;   border: 6px solid #1861a4;">
            <div class="form-group" style="text-align: center; margin-top: 5px">
                    <img src="../../images/coat_of_arms.png" alt="" /><br>
                <span>NIGERIA</span>
                
            </div>
             <div id ="dd2" style="top: 0; width: 96%; height:  auto; margin:  auto ;   background: url('Coat_of_Arms_of_Nigeria.png')    no-repeat !important">
            <div class="form-group" style="text-align: center; font-size: 34px; font-family: 'Calibri'; font-weight: bold; color: #000; text-transform:uppercase">
            Certificate of Renewal of Trade Mark
                </div>
            <div class="form-group" style="text-align: center; font-size: 18px; font-family: Calibri; font-weight: bold">
            Trade Marks Act <br/>
                <div class="form-group" style="text-align: center;">
            CAP 436 Laws of the Federation of Nigeria 1990; Section 22 (3) Regulation 65
                <br/>
            </div>
                <br/>
                <% if (c_mark.logo_pic != "")
                    {%>
                <asp:Image ID="tm_img" runat="server" />
                <% }
                    else
                    {
                        Response.Write("NO DEVICE!! </br> "); %> 
                <% } %>
                <br/>
                <br/>
                </div>
            
           
            
            <div class="form-group">
          
           I hereby certify that the registration of the Trademark <b> <% Response.Write(c_mark.product_title.ToUpper()); %> </b> with File Number <b>  <% Response.Write(c_mark.reg_number.ToUpper()); %> </b> and RTM Number <b>  <% Response.Write(c_stage.rtm.ToUpper()); %> </b> shown above has been renewed in the Part A of the register in the name of <b>  <% Response.Write(c_app.xname.ToUpper()); %> </b> of <b>  <% Response.Write(c_app_addy.street.ToUpper()); %> </b> in Class <b>  <% Response.Write(c_mark.nice_class.ToUpper()); %> </b> under <b>  <% Response.Write(c_stage.rtm.ToUpper()); %> </b>  as of <b>  <% Response.Write(c_mark.reg_date.ToUpper()); %> </b> in respect of <b>  <% Response.Write((c_mark.nice_class_desc /*t.getNationalClassDesc(c_mark.nice_class.ToUpper())*/)); %> </b>. 

<br/>
<br/>
This trademark has been renewed and will remain in force for a period of Fourteen years from the <b>   <% Response.Write(vday); %> </b> day of <b>  <% Response.Write(vmonth); %></b>, <b> <% Response.Write(vyear); %></b>.
<br/>
The subsequent renewal due date for this trademark is on the <b>  <% Response.Write(vday2); %> </b> day of <b>  <% Response.Write(vmonth2); %></b> , <b>  <% Response.Write(vyear2); %></b>.
                <br/>
                 <br/>
                <b>Sealed at my direction</b>  <b>  <% Response.Write(vd[0].RECORDAL_APPROVE_DATE.ToString("d")); %> </b>
                <br/>
                <br/>
<b>Trademarks Registry</b> <br/>
<b>Federal Ministry of Industry, Trade and Investment</b> <br/>
<b>Federal Capital Territory Abuja, Nigeria.</b> <br/>

            </div>
            <div  class="form-group" style="text-align: right">
                <br/>
              
                

                <b>&nbsp;&nbsp;&nbsp;&nbsp; <% Response.Write(z.getAdminDetails(vd[0].OFFICER).xname.ToUpper()); %></b> <br/>
                <b>&nbsp;&nbsp;&nbsp;&nbsp;  FOR: REGISTRAR,TRADE MARKS</b> <br/>
               
                <br/>
           </div>
                 <input type="button" name="Printform" id="Printform"  value="Print" onclick="printAll(); return false" class="button no-print" />
        </div>

    </form>
  
    </body>
</html>
