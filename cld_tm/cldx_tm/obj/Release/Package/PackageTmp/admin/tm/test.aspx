<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="cld.admin.tm.test" %>

<%@ Register src="examination_data.ascx" tagname="examination_data" tagprefix="uc1" %>
<%@ Register src="verify_data.ascx" tagname="verify_data" tagprefix="uc2" %>

<%@ Register src="verification_unit/bg_temp.ascx" tagname="bg_temp" tagprefix="uc3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <uc3:bg_temp ID="bg_temp1" runat="server" />
    
    </div>
    </form>
</body>
</html>
