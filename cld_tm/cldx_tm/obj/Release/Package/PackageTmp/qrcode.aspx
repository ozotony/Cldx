<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="qrcode.aspx.cs" Inherits="cld.qrcode" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" data-ng-app="myModule">
<head runat="server">
    <title></title>
    
    <script src="js/angular.js"></script>
      <script src="js/qrcode.js"></script>
    <script src="js/qrcode_UTF8.js"></script>

    <script src="Scripts/qrcode.js"></script>
   
    <script src="js/AngularQrcode.js"></script>
</head>
<body ng-controller="myController">
    <form id="form1" runat="server">
    <div>
    <qrcode data={{string}}></qrcode>
    </div>
    </form>
</body>
</html>
