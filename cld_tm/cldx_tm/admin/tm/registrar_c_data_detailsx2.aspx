<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="registrar_c_data_detailsx2.aspx.cs" Inherits="cld.admin.tm.registrar_c_data_detailsx2" %>
<%@ Register src="registrar_c_data_details2.ascx" tagname="registrar_c_data_details2" tagprefix="uc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
       <title>TRADEMARK CERTIFICATE</title>
    <link href="../../css/print_style.css" rel="stylesheet" type="text/css" />

<script src="../../js/jquery.js" type="text/javascript"></script>

<script src="../../js/funk.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <uc1:registrar_c_data_details2 ID="registrar_c_data_details1" runat="server" />
    
    </div>
    </form>
</body>
</html>
