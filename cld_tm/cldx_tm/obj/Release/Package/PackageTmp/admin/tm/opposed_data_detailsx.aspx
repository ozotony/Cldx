﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="opposed_data_detailsx.aspx.cs"
    Inherits="cld.admin.tm.opposed_data_detailsx" %>

<%@ Register src="opposition_data_details.ascx" tagname="opposition_data_details" tagprefix="uc1" %>

<%@ Register src="opposed_data_details.ascx" tagname="opposed_data_details" tagprefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <uc2:opposed_data_details ID="opposed_data_details1" 
            runat="server" />
    
    </div>
    </form>
</body>
</html>
