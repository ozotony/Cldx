<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="preview_r.aspx.cs" Inherits="cld.admin.tm.preview_r" %>

<%@ Register src="preview_cert_data.ascx" tagname="preview_cert_data" tagprefix="uc1" %>

<%@ Register src="preview_x_data.ascx" tagname="preview_x_data" tagprefix="uc2" %>

<%@ Register src="preview_r_data.ascx" tagname="preview_r_data" tagprefix="uc3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <uc3:preview_r_data ID="preview_r_data1" runat="server" />
    
    </div>
    </form>
</body>
</html>
