<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="publish_apps.aspx.cs" Inherits="cld.admin.tm.publish_apps" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>TRADEMARK PUBLICATIONS</title>
    <link rel="stylesheet" type="text/css" href="../../../css/style.css" />
<script type="text/javascript" src="../../../js/jquery.js"></script>
<script src="../../../js/funk.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div class="container">
   
        <div class="content">
            <div class="header">
                <div class="xmenu">
                    <div class="menu">
                        <ul>
                            <li><a href="./lo.aspx">
                                <img alt="" src="../../../images/logoff.png" width="16" height="16" />Log off</a></li>
                        </ul>
                    </div>
                </div>
                <div class="xlogo">
                    <div class="xlogo_l">
                    </div>
                    <div class="xlogo_r">
                    </div>
                </div>
            </div>
             <div class="sidebar">
           <a href="publication_unit/profile.aspx">PROFILE</a> <a href="../../cp.aspx?x=<% Response.Write(admin); %>">CHANGE PASSWORD</a> <a href="publication_unit/ped.aspx">VIEW STATISTICS</a>
        </div>
          
    <table style="text-align:center;width:1000px; border:0px;" id="insert_news" >
                  
     
      <%=batch_html %>
   <tr>
   <td style="text-align:center;width:100%;" colspan="3">           
       Current Records Count: <%=cur_unbatched_count%>
              </td>
   </tr>
   <tr>
   <td style="text-align:center;width:100%;" colspan="3">           
       <hr /></td>
   </tr>
   <tr>
   <td style="text-align:center;width:100%;" colspan="3">           
    <asp:Button ID="btnAddToBatch" runat="server" Text="" class="button" onclick="btnAddToBatch_Click" />
              </td>
   </tr>
          </table>
              
       
    </div>
</div>
</div>
    </form>
</body>
</html>
