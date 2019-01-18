<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="edit_apps2.aspx.cs" Inherits="cld.admin.tm.x_unit.edit_apps2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" data-ng-app="myModule">
<head runat="server">
    <title></title>
    <script src="../../../js/jquery-1.7.2.min.js"></script>
    <script src="../../../js/angular.min.js"></script>
    <link href="../../../css/bootstrap.min.css" rel="stylesheet" />
    <script src="../../../js/AngularLogin.js"></script>
    <link href="../../../css/sweet-alert.css" rel="stylesheet" />
    <script src="../../../js/sweet-alert.min.js"></script>

    <link href="../../../css/style.css" rel="stylesheet" type="text/css" />

    <style type="text/css">
    table,tr, td{

         border-top:none;

     }   

    .table>thead>tr>th, .table>tbody>tr>th, .table>tfoot>tr>th, .table>thead>tr>td, .table>tbody>tr>td, .table>tfoot>tr>td {

border-top: 0px solid #ddd;
}

    </style>
</head>
<body ng-controller="myController">
    <form id="form1" runat="server">
    <div>
        <div class="col-lg-12"> 
        <table class="table " style=" font-size:11px;"  >
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
            <td align="center" style="font-size:18pt;line-height:115%;"  >
            ENTER TRANSACTION ID BELOW
                <br />
               <input id="Text1" ng-model="trans" type="text" />
                </td>
        </tr>
         <tr>
            <td align="center" >
            
               <input id="Button1" type="button" ng-click="search()" value="Search" />
                    </td>
        </tr>


            <tr>
                <td align="center">
                  

                </td>

            </tr>


        </table>

            </div>
        <div class=" col-lg-offset-1"> 
           <table class="table " ng-show="isDisabled" style="border:1px dashed #000; font-size:11px;" >

                <tr>
            <td colspan="2" align="left" class="tbbg" style="text-align:left;">
                &nbsp;&nbsp;EDIT APPLICANT 
                INFORMATION DETAILS BELOW  
            </td>
        </tr>
            <tr>
                <td align="right" >

                    Name
                </td>

                <td align="left">
                  

                    <textarea class="form-control" rows="2" ng-model="Name" id="Name"></textarea>

                </td>


            </tr>


            <tr>
                <td align="right">

                   Address
                </td>

                <td>
                   

                     <textarea class="form-control" rows="3" ng-model="Applicant_Address" id="Text2"></textarea>

                </td>


            </tr>

            <tr>
                <td align="right">

                    Email
                </td>

                <td>
                    <input id="Text3" class="input-lg" ng-model="email"  type="text" />

                </td>


            </tr>

            <tr>
                <td align="right">

                    Mobile
                </td>

                <td>
                    <input id="Text4" class="input-lg" ng-model="mobile" type="text" />

                </td>


            </tr>


                <tr>
                <td align="right">

                  
                </td>

                <td>
                     <input id="Button2" type="button"  ng-click="EditRow()" value="Submit" />
                   

                </td>


            </tr>



            </table>

            </div>

       
    
    </div>
    </form>
</body>
</html>
