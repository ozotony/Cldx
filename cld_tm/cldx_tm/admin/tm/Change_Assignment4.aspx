<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Change_Assignment2.aspx.cs" Inherits="cld.admin.tm.Change_Assignment2" %>

<!DOCTYPE html>

<html lang="en">
    <head>
        <meta charset="utf-8" />
        <title></title>
        <link href="bootstrap.min.css" rel="stylesheet">
            <script src="Scripts/jquery-1.10.2.min.js"></script>

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
                    <img src="coat_of_arms.png" alt="" />
            </div>
            <div class="form-group" style="text-align: center">
            FEDERAL REPUBLIC OF NIGERIA <br>
FEDERAL MINISTRY OF INDUSTRY, TRADE AND INVESTMENT<br>
COMMERCIAL LAW DEPARTMENT<br>
TRADEMARKS, PATENTS AND DESIGNS REGISTRY
                </div>
            <div style="top: 0; width: 80%; height:  auto; margin:  auto;"><div class="pageheader blue"><p style="height: 100%; font-size: 18px">ASSIGNMENT - FORM 16</p></div>
            
            <div class="form-group">
                <label for="email">Assignor Name</label>
                <div>
                    <input type="text"  ng-bind="ApplicantName" id="email" class="form-control" disabled />

                </div>
            </div>
                <div class="form-group">
                <label for="address">Assignor Address</label>
                <div>
                    <input type="text" ng-bind="Street" id="address" class="form-control" disabled />

                </div>
            </div>
            <div class="form-group">
                <label for="Name">Assignee Name</label>
                <div>
                    <input type="text" id="Name" class="form-control" />

                </div>
            </div>
                <div class="form-group">
                <label for="Assignee_Address">Assignee Address</label>
                <div>
                    <input type="text" id="Assignee_Address" class="form-control" />

                </div>
            </div>
                 <div class="form-group">
                <label for="country">Assignee Nationality</label>
                <div>
                      <select ng-model="country" name="country" id="country" class="form-control" data-ng-options="c.code as c.name for c in countries" >
                                                                                                                                <option value="">-- Select Country --</option>
                                                                                                                            </select>

                  

                </div>
            </div>
                <div class="form-group">
                <label for="email">Date of Asssignment</label>
                <div>
                    <input type="date" id="Date_of_Assignment" class="form-control" />

                </div>
            </div>
                <div class="form-group">
                <label for="email">Upload Power of Attorney</label>
                <div>
                    <input type="file" id="File1" class="form-control" />

                </div>
            </div>
                <div class="form-group">
                <label for="email">Upload Deed of Assignment</label>
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
                    <input type="submit" value="Update Record" class="btn btn-default" data-ng-click="login(LoginData)"/>
            </div>

        </div>

    </form>
  
    </body>
</html>
