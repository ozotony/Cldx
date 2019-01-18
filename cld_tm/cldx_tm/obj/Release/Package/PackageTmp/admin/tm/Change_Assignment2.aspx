<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Change_Assignment2.aspx.cs" Inherits="cld.admin.tm.Change_Assignment2" %>

<!DOCTYPE html>


<html lang="en" data-ng-app="myModule">
    <head>
        <meta charset="utf-8" />
        <title></title>
       

    <script src="../../js/jquery-2.1.1.min.js"></script>

    <script src="../../js/angular.min.js"></script>

    <link href="../../css/xeditable.css" rel="stylesheet" />

    <script src="../../js/xeditable.min.js"></script>
    <link href="../../css/bootstrap.min.css" rel="stylesheet" />
    <script src="../../js/AngularLogin8.js"></script>
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
    
    <body ng-controller="myController">
        
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
            <div style="top: 0; width: 80%; height:  auto; margin:  auto;"><div class="pageheader blue"><p style="height: 100%; font-size: 18px">FORM 16 - MERGER</p></div>
            
            <div class="form-group">
                <label for="email">Applicant Name</label>
                <div>
                    <input type="text"  ng-model="ApplicantName" id="email" class="form-control" disabled />

                </div>
            </div>
                <div class="form-group">
                <label for="address">Applicant Address</label>
                <div>
                    <input type="text" ng-model="Street" id="address" class="form-control" disabled />

                </div>
            </div>
            <div class="form-group">
                <label for="Name">Merging Applicant Name</label>
                <div>
                    <input type="text" id="Name" ng-model="newApplicantName" class="form-control" />

                </div>
            </div>
                <div class="form-group">
                <label for="Assignee_Address">Merging Applicant Address</label>
                <div>
                    <input type="text" id="Assignee_Address" ng-model="newApplicantAddress" class="form-control" />

                </div>
            </div>
                 <div class="form-group">
                <label for="country">Merging Applicant Nationality</label>
                <div>
                      <select ng-model="newApplicantNationality" name="country" id="country" class="form-control" data-ng-options="c.code as c.name for c in countries" >
                                                                                                                                <option value="">-- Select Country --</option>
                                                                                                                            </select>

                  

                </div>
            </div>

                 <div class="form-group">
                <label for="Assignee_Address">Applicant Name to be displayed on Certificate of Merger</label>
                <div>
                    <input type="text" id="Assignee_Address2" ng-model="namecertificate" class="form-control" />

                </div>
            </div>
                <div class="form-group">
                <label for="email">Date of Merger</label>
                <div>
                    <input type="date" ng-model="valuedate" id="Date_of_Assignment" class="form-control" />

                </div>
            </div>
                 <div class="form-group">
                <label for="description">Details Of Request</label>
                <div>
                    <textarea rows="10" ng-model="description" id="description" cols="50" class="form-control">
                  </textarea>

                </div>
            </div>

                <div class="form-group">
                <label for="email">Upload Power of Attorney</label>
                <div>
                    <input type="file" id="File1" class="form-control" />

                </div>
            </div>
                <div class="form-group">
                <label for="email">Upload Deed of Merger</label>
                <div>
                    <input type="file" id="File2" class="form-control" />

                </div>
            </div>

                 <div class="form-group">
                <label for="email">Upload Certificate of Registration of Trademark</label>
                <div>
                    <input type="file" id="File3" class="form-control" />

                </div>
            </div>
            <div class="form-group" style="text-align: center; padding-top: 10px">
                    <input type="submit" value="Update Record" class="btn btn-default" ng-click="submitForm()" ng-disabled="processing"/>
            </div>

        </div>
 <input id="xname" name="xname" type="hidden" runat="server" />
             <input id="vamount" name="vamount" type="hidden" runat="server" />
            <input id="vtranid" name="vtranid" type="hidden" runat="server" />
             <input id="vtype" name="vtranid" type="hidden" runat="server" />
    </form>
  
    </body>
</html>