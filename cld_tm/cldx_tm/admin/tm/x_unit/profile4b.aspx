<%@ Page Language="C#" AutoEventWireup="true" CodeFile="profile4.aspx.cs" Inherits="admin_pt_x_unit_profile4" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" ng-app="formApp" >
<head id="Head1" runat="server">
    <title></title>
     <link href="../../../css/bootstrap.min.css" rel="stylesheet" />
<link href="../../../css/style.css" rel="stylesheet" type="text/css" />  

 

     <script type="text/javascript" src="../../../js/jquery-2.1.1.min.js"></script>


    <script src="../../../Scripts/angular.js"></script>
  
    <script src="../../../Scripts/angular-animate.js"></script>
    <script src="../../../Scripts/angular-ui-router.min.js"></script>
    <link href="../../../css/sweet-alert.css" rel="stylesheet" />
    <link href="../../../css/loading-bar.css" rel="stylesheet" />
    <link href="../../../css/animate.css" rel="stylesheet" />
  
    <script src="../../../Scripts/App4.js"></script>
   
   
    <script src="../../../js/loading-bar.js"></script>
    
    <script src="../../../js/angular-sanitize.min.js"></script>
    <script src="../../../js/smart-table.min.js"></script>  

     <style type="text/css">
 .pending-delete {
       /*color:red;
     background-color: lightgreen;*/

     /*text-decoration: line-through;*/
     font-weight:bold;
    
 }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="container">
            <div class="sidebar">                 
               <%-- <a href="./profile.aspx">PROFILE</a> --%>
              
                <a href="./profile4.aspx">INBOX</a>  
                
                 <a href="./profile4.aspx#/form/outbox">OUTBOX</a>                  
            </div>
            <div class="content">
                   <div class="header">
                    <div class="xmenu">
                        <div class="menu">
                            <ul>
                                <li><a href="../lo.aspx">
                                    <img alt="" src="../../../images/logoff.png" width="16" height="16" />Log off</a></li>
                            </ul>
                        </div>
                    </div>
                    <div class="xlogo">
                        <div class="xlogo_l">
                        </div>
                        <div class="xlogo_r">
                        </div>
                    </div>
                </div>
              <div ui-view></div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
