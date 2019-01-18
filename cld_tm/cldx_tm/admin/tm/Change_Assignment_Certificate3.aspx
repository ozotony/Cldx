<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Change_Assignment_Certificate3.aspx.cs" Inherits="cld.admin.tm.Change_Assignment_Certificate" %>

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
                font-size: 12px;
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
     
    .no-print, .no-print *
    {
        display: none !important;
       
    }
}
        </style>
    </head>
    
    <body>
        
    <form class="form-login" role="form">

        <div style="width:90%; margin:auto; height:auto;">
            <div class="form-group" style="text-align: center; margin-top: 5px">
                    <img src="../../images/coat_of_arms.png" alt="" /><br>
                <span>NIGERIA</span>
            </div>
            <div class="form-group" style="text-align: center; font-size: 48px; font-family: 'Courier New'; font-weight: bold">
            Certificate of Renewal of Trade Mark
                </div>
            <div class="form-group" style="text-align: center; font-size: 18px; font-family: Calibri; font-weight: bold">
            Trade Marks Act <br/>
                <div class="form-group" style="text-align: center;">
            CAP 436 Laws of the Federation of Nigeria 1990; Section 22 (3) Regulation 65
                <br/>
            </div>
                <br/>
                <% Response.Write(c_mark.product_title.ToUpper()); %>
              
                <br/>
                <br/>
                </div>
            
            <div style="top: 0; width: 96%; height:  auto; margin:  auto;">
            
            <div class="form-group">
            I hereby certify that your name has been entered on the Register as Proprietor(s) of the trademark <% Response.Write(c_mark.product_title.ToUpper()); %>  with File Number <% Response.Write(c_mark.reg_number.ToUpper()); %>  and RTM no  <% Response.Write(c_stage.rtm.ToUpper()); %>  shown above in the name of <% Response.Write(xp[0].newApplicantName.ToUpper()); %>  of <<% Response.Write(xp[0].newApplicantAddress.ToUpper()); %> in class   <% Response.Write(c_mark.nice_class.ToUpper()); %> under   <% Response.Write(c_stage.rtm.ToUpper()); %> as of  <% Response.Write(c_mark.reg_date.ToUpper()); %> <% Response.Write(c_mark.nice_class_desc /*t.getNationalClassDesc(c_mark.nice_class.ToUpper())*/); %>.
<br/>
                <br/>
                <br/>
                <br/>
                Sealed at my direction  <% Response.Write(vd[0].RECORDAL_APPROVE_DATE.ToString("d")); %>   
                <br/>
Trademarks Registry <br/>
Federal Ministry of Industry, Trade and Investment<br/>
Federal Capital Territory Abuja, Nigeria. <br/>

            </div>
            <div style="float: right">
                <br/>
                <br/>
             <% Response.Write(z.getAdminDetails(vd[0].OFFICER).xname.ToUpper()); %>    <br/>
                FOR: Registrar,Trade Marks<br/>
               
                <br/>
           </div>
                  <input type="button" name="Printform" id="Printform"  value="Print" onclick="printAll(); return false" class="button no-print" />
        </div>

    </form>
  
    </body>
</html>
