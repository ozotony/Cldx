<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Change_ApplicantAgent.aspx.cs" Inherits="cld.admin.tm.Change_ApplicantAgent" %>

<!DOCTYPE html>

<html lang="en" data-ng-app="myModule">
    <head>
        <meta charset="utf-8" />
        <title></title>
         <script src="../../js/jquery-2.1.1.min.js"></script>
       <link href="../../css/bootstrap.min.css" rel="stylesheet" />
        <script src="../../js/angular.min.js"></script>
        <script src="../../js/AngularLogin2.js"></script>
        <script src="../../js/sweet-alert.min.js"></script>
        <link href="../../css/sweet-alert.css" rel="stylesheet" />
        <script src="../../js/loading-bar.js"></script>
        <link href="../../css/loading-bar.css" rel="stylesheet" />
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
                font-family: Calibri;
            }
        </style>
    </head>
    
    <body ng-controller="myController3">
        
    <form class="form-login" role="form">

        <div style="width:40%; margin:auto; height:auto">
            <div class="form-group" style="text-align: center">
                    <img src="../../images/coat_of_arms.png" alt="" />
            </div>
            <div class="form-group" style="text-align: center">
            FEDERAL REPUBLIC OF NIGERIA <br>
FEDERAL MINISTRY OF INDUSTRY, TRADE AND INVESTMENT<br>
COMMERCIAL LAW DEPARTMENT<br>
TRADEMARKS, PATENTS AND DESIGNS REGISTRY
                </div>
            <div style="top: 0; width: 80%; height:  auto; margin:  auto;"><div class="pageheader blue"><p style="height: 100%; font-size: 18px">CHANGE OF AGENT INFORMATION</p></div>
            <div class="pageheader blue"><p style="height: 100%; font-size: 18px">Old Agent Information</p></div>
            <div class="form-group">
                <label for="email">Agent Name</label>
                <div>
                    <input type="text" id="vname" ng-model="Agent_Name" class="form-control" disabled />

                </div>
            </div>
                <div class="form-group">
                <label for="email">Address</label>
                <div>
                    <input type="text" id="vaddress" ng-model="Address" class="form-control" disabled />

                </div>
            </div>
                <div class="form-group">
                <label for="email">Phone Number</label>
                <div>
                    <input type="text" id="vphone" ng-model="Mobile" class="form-control" disabled />

                </div>
            </div>
                <div class="form-group">
                <label for="email">Email</label>
                <div>
                    <input type="text" id="email2" ng-model="Email" class="form-control" disabled />

                </div>
            </div>
                <div class="form-group">
                <label for="email">Agent Code</label>
                <div>
                    <input type="text" id="vcode"  ng-model="Agent_Code" class="form-control" disabled />

                </div>
            </div>
                <div class="pageheader blue"><p style="height: 100%; font-size: 18px">New Agent Information</p></div>
             <div class="form-group">
                <label for="email">Agent Code</label>
                <div>
                    <input type="text" id="email" ng-model="Agent_Code2" ng-blur="checkAgent(Agent_Code2)" class="form-control" disabled />

                </div>
            </div>
                <div class="form-group">
                <label for="email">Agent Name</label>
                <div>
                    <input type="text" id="email" ng-model="Agent_Name2" class="form-control" disabled />

                </div>
            </div>
                <div class="form-group">
                <label for="email">Address</label>
                <div>
                    <input type="text" id="email" ng-model="Address2" class="form-control" disabled />

                </div>
            </div>
                <div class="form-group">
                <label for="email">Phone Number</label>
                <div>
                    <input type="text" id="email" ng-model="Mobile2" class="form-control" disabled />

                </div>
            </div>
                <div class="form-group">
                <label for="email">Email</label>
                <div>
                    <input type="text" id="email" ng-model="Email2" class="form-control" disabled />

                </div>
            </div>

                 <div class="form-group">
                <label for="email">Upload</label>
                <div>
                   <input type="file" id="File1" class="form-control" />

                </div>
            </div>
               
            <div class="form-group" style="text-align: center; padding-top: 10px">
                    <input type="submit" value="Update Record" class="btn btn-default" ng-click="submitForm()"/>
            </div>

        </div>

                 <input id="xname" name="xname" type="hidden" runat="server" />
             <input id="vamount" name="vamount" type="hidden" runat="server" />
            <input id="vtranid" name="vtranid" type="hidden" runat="server" />
             <input id="xname2" name="xname" type="hidden" runat="server" />
             <input id="xaddress" name="xaddress" type="hidden" runat="server" />
             <input id="xemail" name="xemail" type="hidden" runat="server" />
             <input id="xPhoneNumber" name="xPhoneNumber" type="hidden" runat="server" />
           <input id="xpwalletID" name="xpwalletID" type="hidden" runat="server" />
            
    </form>
  
    </body>
</html>
