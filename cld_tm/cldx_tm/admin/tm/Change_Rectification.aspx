<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Change_Rectification.aspx.cs" Inherits="cld.admin.tm.Change_Rectification" %>

<!DOCTYPE html>

<html lang="en" data-ng-app="myModule">
    <head>

         <script src="../../js/jquery-2.1.1.min.js"></script>
       <link href="../../css/bootstrap.min.css" rel="stylesheet" />
        <script src="../../js/angular.min.js"></script>
        <script src="../../js/AngularLogin2.js"></script>
        <script src="../../js/sweet-alert.min.js"></script>
        <link href="../../css/sweet-alert.css" rel="stylesheet" />
        <script src="../../js/loading-bar.js"></script>
        <link href="../../css/loading-bar.css" rel="stylesheet" />
        <meta charset="utf-8" />
        <title></title>
        <link href="bootstrap.min.css" rel="stylesheet">
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
        <script language=javascript type='text/javascript'>
            function toggleSubmit(sel) {
                var area = document.getElementById('image');
                var fred = document.getElementById('upload');
                if (sel.options[sel.selectedIndex].value == "wordmark") {
                    area.style.display = "none";
                    fred.style.display = "none";
                    //$("#upload").hide();
                }
                else {
                    area.style.display = "block";
                    fred.style.display = "block";
                }

            } </script>
    </head>
    
    <body ng-controller="myController4">
        
    <form class="form-login" role="form">

        <div style="width:90%; margin:auto; height:auto">
            <div class="form-group" style="text-align: center">
                    <img src="../../images/coat_of_arms.png" alt="" />
            </div>
            <div class="form-group" style="text-align: center">
            FEDERAL REPUBLIC OF NIGERIA <br>
FEDERAL MINISTRY OF INDUSTRY, TRADE AND INVESTMENT<br>
COMMERCIAL LAW DEPARTMENT<br>
TRADEMARKS, PATENTS AND DESIGNS REGISTRY
                </div>
            <div style="top: 0; width: 80%; height:  auto; margin:  auto;"><div class="pageheader blue"><p style="height: 100%; font-size: 18px">AMENDMENT (CLERICAL ERRORS IN TRADEMARK TITLE) </p></div>
            
            <div class="form-group">
                <label for="email">Logo Description</label>
                <div>
                    <select class="form-control" data-ng-change="GetStates12()"  data-ng-options="c.id as c.name for c in classtrademark" name="Logo" ng-model="Logo" required="">
                                <option value="">-- Select LOGO DESCRIPTION --</option>
                            </select>

                    <%--<select id="desc" onchange="toggleSubmit(this);">
                    <option value="1">Device</option>
                    <option value="2">WordMark</option>
                    <option value="3">Word and Device</option>
                    </select>--%>

                </div>
            </div>
            <div class="form-group">
                <label for="password">Old product title</label>
                <div>
                    <input type="text" id="oldtitle" ng-model="old_title" class="form-control" disabled />

                </div>
            </div>
                <div class="form-group" id="image">
                <label for="password">Old trademark representation</label>
                <div>
                    <img  ng-src="{{img_url}}" width="150" />

                </div>
            </div>
                <div class="form-group">
                <label for="password">New product title</label>
                <div>
                    <input type="text" id="newtitle" ng-model="new_title"  class="form-control" />

                </div>
            </div>

                 <div class="form-group">
                <label for="description">Details Of Request</label>
                <div>
                    <textarea rows="10" ng-model="description" id="description" cols="50" class="form-control">
                  </textarea>

                </div>
            </div>
                <div class="form-group" id="upload" ng-show="upload">
                <label for="password">Upload new trademark representation</label>
                <div>
                    <input type="file" id="newlogo" class="form-control" />
                    <i style="color: #f00">NOTE: Attached document should be in .jpeg or .png format and not more than 3MB</i>

                </div>
            </div>
            <div class="form-group" style="text-align: center; padding-top: 10px">
                    <input type="submit" value="Update Record" class="btn btn-default"  ng-click="submitForm()"/>
            </div>

        </div>

              <input id="xname" name="xname" type="hidden" runat="server" />
             <input id="vamount" name="vamount" type="hidden" runat="server" />
            <input id="vtranid" name="vtranid" type="hidden" runat="server" />
             <input id="vtype" name="vtranid" type="hidden" runat="server" />
 
    </form>
  
    </body>
</html>
 
