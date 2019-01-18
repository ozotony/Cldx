<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="tm_acknowledgementx.cs" Inherits="cld.tm_acknowledgementx" %>

<%@ Register src="tm_arkx.ascx" tagname="tm_arkx" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>TRADEMARK REGISTRATION ACKNOWLEDGEMENT FORM</title>
<script language="javascript" type="text/javascript">
// <![CDATA[

    function IpoDashboard_onclick() {
        window.location.href = "./app_office.aspx";
    }

// ]]>
</script>

<link href="css/print_style.css" rel="stylesheet" type="text/css" />

<script src="js/jquery.js" type="text/javascript"></script>

<script src="js/funk.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <uc1:tm_arkx ID="tm_arkx" runat="server" />
    
    </div>
    </form>
</body>
</html>
