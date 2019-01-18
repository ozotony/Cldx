<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="cld.Test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>

        .bgMark
{
filter:alpha(opacity=8);
-moz-opacity:0.08;
opacity: 0.08;
}

    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>

        <div id="bgMark" class="bgMark" style="background-color:transparent;width:600px;height:480px; position: relative;top:-495px;left:160px;"> </div>
<img id="imgWaterMark" style=" WIDTH: 600px; " runat="server">
    
    </div>
    </form>
</body>
</html>
