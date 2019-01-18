<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="tm_ackrep.cs" Inherits="cld.tm_ackrep" %>

<%@ Register src="tm_ark_repx.ascx" tagname="tm_ark_repx" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>TRADEMARK REGISTRATION ACKNOWLEDGEMENT FORM</title>
<script  type="text/javascript">
// <![CDATA[

    function IpoDashboard_onclick() {
        window.location.href = "http://www.iponigeria.com/userarea/dashboard";
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
        <uc1:tm_ark_repx ID="tm_ark_repx1" runat="server" />
    </div>
    </form>
</body>
</html>
