<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="rejection_slip_details.aspx.cs" Inherits="cld.admin.tm.rejection_slip_details" %>

<%@ Register src="rejection_slip_data_details.ascx" tagname="rejection_slip_data_details" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>REJECTION SLIP</title>
    <link href="../../css/print_style.css" rel="stylesheet" type="text/css" />

<script src="../../js/jquery.js" type="text/javascript"></script>

<script src="../../js/funk.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <uc1:rejection_slip_data_details ID="rejection_slip_data_details1" runat="server" />
    
    </div>
    </form>
</body>
</html>
