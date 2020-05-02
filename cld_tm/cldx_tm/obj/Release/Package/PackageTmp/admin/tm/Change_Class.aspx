<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Change_Class.aspx.cs" Inherits="cld.admin.tm.Change_Class" %>

<!DOCTYPE html>

<html lang="en" data-ng-app="myModule" >
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
    
    <body ng-controller="myController8">
        
    <form class="form-login" role="form" >

        <div style="width:40%; margin:auto; height:auto">
            <div class="form-group" style="text-align: center">
                     <img src="../../images/coat_of_arms.png" style="width: 80px; height: 80px" />
            </div>
            <div class="form-group" style="text-align: center">
            FEDERAL REPUBLIC OF NIGERIA <br>
FEDERAL MINISTRY OF INDUSTRY, TRADE AND INVESTMENT<br>
COMMERCIAL LAW DEPARTMENT<br>
TRADEMARKS, PATENTS AND DESIGNS REGISTRY
                </div>
            <div style="top: 0; width: 80%; height:  auto; margin:  auto;"><div class="pageheader blue"><p style="height: 100%; font-size: 18px">RECLASSIFICATION OF TRADEMARK </p></div>
            
            <div class="form-group">
                <label for="email">Old Applicant Class</label>
                <div>
                   
                      <input type="text" ng-model="Applicantclass" id="email" class="form-control" disabled />
                     
                </div>
            </div>
            <div class="form-group">
                <label for="password">New Applicant Class</label>
                <div>
                    


                    
                    <select ng-model="ApplicantNewClass"  name="newclass" id="newclasss" class="form-control">
   <option value="">-- Select Class --</option>
                        <option ng-repeat="x in countries" value="{{x.classtype}}">{{x.classtype}}</option>
</select>

                  


                    
</select>

                </div>
            </div>

                 <div class="form-group">
                <label for="description">Details Of Request</label>
                <div>
                    <textarea rows="10" ng-model="description" id="description" cols="50" class="form-control">
                  </textarea>

                </div>
            </div>
            <div class="form-group" style="text-align: center; padding-top: 10px">
                    <input type="submit" value="Update Record" ng-click="submitForm()" class="btn btn-default" />
            </div>

        </div>
            <input id="xname" name="xname" type="hidden" runat="server" />
             <input id="vamount" name="vamount" type="hidden" runat="server" />
            <input id="vtranid" name="vtranid" type="hidden" runat="server" />
              <input id="vtype" name="vtranid" type="hidden" runat="server" />
    </form>
  
    </body>
</html>