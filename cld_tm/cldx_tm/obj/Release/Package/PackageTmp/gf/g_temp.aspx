<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="g_temp.aspx.cs" Inherits="cld.gf.g_temp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <script src="../js/funk.js" type="text/javascript"></script>

<script  type="text/javascript">
    function doPost(transID, amt, agt, xgt, applicantname, applicantemail, applicantpnumber, agentname, agentemail, agentpnumber, product_title, item_code) {
        postwith('./xindex.aspx', { transID: transID, amt: amt, agt: agt, xgt: xgt, applicantname: applicantname, applicantemail: applicantemail, applicantpnumber: applicantpnumber, agentname: agentname, agentemail: agentemail, agentpnumber: agentpnumber, product_title: product_title, item_code: item_code });
    }	
	</script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <input id="btnPost" type="button" value="Test Post"  onclick="doPost('306139070983',
'10900', 'CLD/RA/0013', 'cbt', 'Senci Electric Machinery Co., Ltd.', 'ipgroup@banwo-ighodalo.com', '+234 1 4615203-4', 'Olufemi  Olubanwo', 'banwigho@banwo-ighodalo.com', '014615204', 'SENCI ', 'T008');" /></div>
    </form>
</body>
</html>
