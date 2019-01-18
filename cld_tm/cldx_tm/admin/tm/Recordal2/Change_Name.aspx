<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Change_Name.aspx.cs" Inherits="cld.admin.tm.Recordal2.Change_Name" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link href="../../../css/bootstrap.min.css" rel="stylesheet" />
<link href="../../../css/style.css" rel="stylesheet" type="text/css" />  
    <script src="../../../Scripts/angular.js"></script>  
    <script src="../../../Scripts/angular-route.min.js"></script>
    <script src="../../../Scripts/angular-animate.js"></script>
    <script src="../../../Scripts/App.js"></script>

     <style type="text/css">
.sidebar {
    padding-top:2px;

}

    </style>
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
<body ng-app="formApp">
    <form id="form1" runat="server">
    <div>
        <div class="header">
            <div class="leftholder">
            </div>
            <div class="xmenu">
                <div class="xmenu_m">
                    <div class="xmenu_ml">
                    </div>
                    <div class="xmenu_mm">
                        <div class="menu">
                            <ul>                                
                                <li><a href="../lo.aspx">
                                    <img alt="" src="../../../images/logoff.png" width="16" height="16" />Log off</a></li>
                            </ul>
                        </div>
                    </div>
                    <div class="xmenu_mr">
                    </div>
                </div>
            </div>
            <div class="xlogoleftholder">
            </div>
            <div class="xlogo">
                <div class="xlogo_l">
                </div>
                <div class="xlogo_r">
                </div>
            </div>
        </div>
        <div class="container">
            <div class="sidebar">
                 <a href="./profile.aspx">PROFILE</a> 
                <a href="../../../cp.aspx?x=<% Response.Write(adminID); %>">CHANGE PASSWORD</a> 
              
            </div>
            <div class="content">
        
    <div ui-view></div>
  
            </div>
        </div>
    </div>
    </form>
</body>
</html>