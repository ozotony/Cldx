﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="preview_r_details.aspx.cs" Inherits="cld.admin.tm.preview_r_details" %>

<%@ Register src="preview_cert_detailsx.ascx" tagname="preview_cert_detailsx" tagprefix="uc1" %>

<%@ Register src="preview_x_detailsx.ascx" tagname="preview_x_detailsx" tagprefix="uc2" %>

<%@ Register src="preview_r_detailsx.ascx" tagname="preview_r_detailsx" tagprefix="uc3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <uc3:preview_r_detailsx ID="preview_r_detailsx1" runat="server" />
    
    </div>
    </form>
</body>
</html>
