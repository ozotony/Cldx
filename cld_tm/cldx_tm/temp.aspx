<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="temp.cs" Inherits="cld.temp" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <script src="js/funk.js" type="text/javascript"></script>

<script type="text/javascript">
    function doPost(transID, amt, agt, xgt, applicantname, applicantemail, applicantpnumber, agentname, agentemail, agentpnumber, product_title, item_code) {
        postwith('./xindex.aspx', { transID: transID, amt: amt, agt: agt, xgt: xgt, applicantname: applicantname, applicantemail: applicantemail, applicantpnumber: applicantpnumber, agentname: agentname, agentemail: agentemail, agentpnumber: agentpnumber, product_title: product_title,item_code:item_code });
    }

	</script>

</head>
<body>
    <form id="form1" runat="server">
    <div> 
        <input id="btnPost" type="button" value="Test Post"  onclick="doPost('5512981200','15000','CLD/RA/0003','cbt','3Niti-Z ','info@3nitix.com','08098367527','Online Registry Office','oro@cld.com','08098753333','3Niti X Pay','T002');" /><br />          
            </div>
    </form>
</body>
</html>
