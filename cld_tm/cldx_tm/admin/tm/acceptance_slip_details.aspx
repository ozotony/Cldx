<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="acceptance_slip_details.cs" Inherits="cld.admin.tm.acceptance_slip_details" %>

<%@ Register Src="acceptance_slip_data_details.ascx" TagName="acceptance_slip_data_details" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>ACCEPTANCE SLIP</title>
    <link href="../../css/print_style.css" rel="stylesheet" type="text/css" />

<script src="../../js/jquery.js" type="text/javascript"></script>

<script src="../../js/funk.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    

        <uc1:acceptance_slip_data_details ID="acceptance_slip_data_details1" runat="server" />
    
    </div>
    </form>
</body>
</html>
