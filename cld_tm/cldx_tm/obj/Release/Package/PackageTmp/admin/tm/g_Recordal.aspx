<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="g_Recordal.aspx.cs" Inherits="cld.admin.tm.g_Recordal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" data-ng-app="myModule">
<head id="Head1" runat="server">
    <title></title>
    

<link rel="stylesheet" href="../../css/jquery.ui.all.css" />

<%--<script type="text/javascript" src="../../js/jquery.js"></script>--%>
    <script type="text/javascript" src="../../js/jquery-2.1.1.min.js"></script>

<script type="text/javascript" src="../../ui/jquery.cookie.js"></script>

<script type="text/javascript" src="../../ui/jquery.ui.core.js"></script>

<script type="text/javascript" src="../../ui/jquery.ui.widget.js"></script>

<script type="text/javascript" src="../../ui/jquery.ui.datepicker.js"></script>

<script type="text/javascript" src="../../ui/jquery.ui.position.js"></script>

<script type="text/javascript" src="../../ui/jquery.ui.autocomplete.js"></script>
<script src="../../js/funk.js" type="text/javascript"></script>
    <link href="../../css/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="../../css/style.css" />
    <script type="text/javascript" src="../../js/angular.min.js"></script>
    <link href="../../css/loading-bar.css" rel="stylesheet" />
    <script type="text/javascript" src="../../js/loading-bar.js"></script>
    <script type="text/javascript" src="../../js/smart-table.min.js"></script>
    <script type="text/javascript" src="../../js/AngularLogin.js"></script>
    <link href="../../css/font-awesome.min.css" rel="stylesheet" />
    <script type="text/javascript" src="../../js/bootstrap.min.js"></script>
    <script src="../../js/ng-modal.min.js"></script>
    <link href="../../css/ng-modal.css" rel="stylesheet" />
    <link href="../../css/sweet-alert.css" rel="stylesheet" />
    <script src="../../js/sweet-alert.min.js"></script>
<script type="text/javascript">
    $(function () {
        $("table tr:nth-child(even)").addClass("striped");
    });
</script>

<script type="text/javascript">
    $(function () {
        $("#datepickerFrom").datepicker();
    });
    $(function () {
        $("#datepickerTo").datepicker();
    });		
		
</script>

<script type="text/javascript">
    $(function () {
        var availableTags = [""];
        $("#kword").autocomplete({
            source: availableTags
        });
    });
</script>

     <script type="text/javascript">
<!--
    spe = 500;
    var na = document.getElementsByTagName("blink")
    // var   na = document.all.tags("blink");
    swi = 1;
    bringBackBlinky();

    function bringBackBlinky() {

        if (swi == 1) {
            sho = "visible";
            swi = 0;
        }
        else {
            sho = "hidden";
            swi = 1;
        }

        for (i = 0; i < na.length; i++) {
            na[i].style.visibility = sho;
        }

        setTimeout("bringBackBlinky()", spe);
    }

</script>

  <style type="text/css">
          #news_strip {
  width: 100%;
  border-bottom: 1px dotted #cccccc;
  display: block;
  height: 17px;
  position: relative;
  overflow: hidden;
  color:red;
}

#news_strip a {
  display: inline;
  text-decoration: none;
  margin-right: 250px;
  z-index: 1;
  position: absolute;
  top: 0px;

}

#news_strip a span {
  cursor: pointer;
  display: inline;
  color: #343434;
  
 
  font-weight: bold;
  padding-right: 5px;
  z-index: 1;
}

#news_strip a span.date {
  display: inline-block;
  font-weight: normal;
  color: #888888;
}

#news_strip a:hover span.title {
  text-decoration: underline;
}

/* The shadow DIVs of the sides are decorative and optional, but they add a very nice effect :) */

#news_strip div.shadow{
  position: absolute;
  top: 0px;
  width: 1px;
  height: 100%;
  z-index: 5;
  background: #ffffff;
}

#news_strip div.shadow.left{
  left: 0px;
  -webkit-box-shadow: 10px 0px 10px #fff;
  -moz-box-shadow: 10px 0px 10px #fff;
  box-shadow: 10px 0px 10px #fff;
}

#news_strip div.shadow.right{
  right: 0px;
  -webkit-box-shadow: -10px 0px 10px #fff;
  -moz-box-shadow: -10px 0px 10px #fff;
  box-shadow: -10px 0px 10px #fff;
}
            </style>

    <style type="text/css">
 .pending-delete {
     color:red;
     background-color: #FFF056;
 }
    </style>

          <style type="text/css">
        .sidebar a {
padding-left:5px;

}
    </style>

</head>
<body ng-controller="myController6">
    <form id="form1" runat="server">
   <div>
    <div class="container">
        <div class="sidebar">
            <a href="./verification_unit/profile.aspx">PROFILE</a> <a href="../../cp.aspx?x=<% Response.Write(admin); %>">CHANGE PASSWORD</a> <a href="./verification_unit/ved.aspx">VIEW STATISTICS</a>
               <a href="../tm/x_unit/profile4.aspx" ng-show="xvv" class="blinkytext" > <blink> <span id="txtblinkingtext" class="label label-danger" ng-bind="vcount"></span> </blink> </a>
               <a style="width=200px" target="_blank" href="../tm/x_unit/profile4.aspx">UPDATE NOTIFICATIONS</a> 
        </div>
        <div class="content">
            <div class="header">
                <div class="xmenu">
                    <div class="menu">
                        <ul>
                            <li><a href="./lo.aspx">
                                <img alt="" src="../../images/logoff.png" width="16" height="16" />Log off</a></li>
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
            <div id="searchform">
               <modal-dialog show='dialogShown'  dialog-title='SEARCH PAYMENT'>

       
    
        <table class="table-bordered"  >

            <tr>
                <td align="left"><input id="emailaddress" size="100px" ng-model="VEmail" name="emailaddress" placeholder="Enter TRANSACTION ID" type="text" /></td>
            </tr>
            <tr>
                <td align="left" style="padding-top:11px;">

                   
                    <input type="button" ng-click="add3(VEmail)" class="submit" value="SEARCH" />
                </td>
            </tr>
            <tr>
                <td>
                     <table width="100%" border="0" cellspacing="1" cellpadding="4" class="table" align="center">
                                        <thead>
                                            <tr>
                                                
                                                <th>Reference ID</th>

                                                <th>Applicant Name</th>
                                                <th>Email</th>
                                               
                                                <th></th>

                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr >
                                              
                                                <td>{{payment.TransId}}</td>
                                                <td>{{payment.Applicant_Name}}</td>
                                                <td>{{payment.Applicant_Email}}</td>

                                              
                                                <td>
                                                    <a href="#" ng-click="EditRow2(payment);$event.preventDefault(); $event.stopPropagation();">Confirm Update </a>
                                                </td>

                                            </tr>

                                        </tbody>
                                       

                                    </table>
                </td>
            </tr>
        </table>
   

</modal-dialog>
                 <div id="news_strip" ng-mouseover="conf.news_move_flag=false" ng-mouseout="conf.news_move_flag=true">
    <div class="shadow left">&nbsp;</div>
    <a ng-repeat="(k, n) in news track by $index" ng-style="{'right': get_news_right($index)}" id="news_{{$index}}" rel="nofollow" target="_blank" href="{{n.link}}">
        <span style="color:red; font-weight:bold" class="date">{{n.firstName}}</span>
       
    </a>
    <div class="shadow right">&nbsp;</div>
</div>
            <table width="100%" class="Table1">
          <tr>
            <td colspan="8"  class="tbbg"> WELCOME TO THE VERIFICATION UNIT</td>
          </tr>
          <tr class="stripedout">
            <td colspan="8" align="center">
            <asp:Button ID="btnReloadPage" runat="server" Text="RELOAD PAGE" class="button" 
                    onclick="btnReloadPage_Click" />
              </td>
          </tr>
         
          <tr>
            <td colspan="8" class="tbbg">&nbsp;PLEASE SEARCH FOR ENTRIES BELOW</td>
          </tr>
          
          <tr class="stripedout">
            <td colspan="8" align="center" ><%Response.Write(criteria); %></td>
          </tr>
          
          <tr >
            <td colspan="8" align="center" class="tbbg">
                <%--<asp:DropDownList ID="selectSearchCriteria" runat="server" AutoPostBack="False">
                <asp:ListItem Text="TRADEMARK" Value="product_title"></asp:ListItem>
                <asp:ListItem Text="ONLINE ID" Value="app_number"></asp:ListItem>
                </asp:DropDownList>
&nbsp;&nbsp;

              key word:&nbsp;
              <input name="kword" type="text" id="kword"  size="50"   value="" runat="server"/>
              
              From :
              <input type="text" id="datepickerFrom" runat="server"/>
              &nbsp;
              To :
              <input type="text" id="datepickerTo" runat="server"/>
              &nbsp;--%></td>
          </tr>

         <tr class="stripedout">
            <td colspan="9" align="center">            
                <asp:Button ID="btnSearch" Visible="false" runat="server" Text="SEARCH" class="button" 
                      />

          <tr >
            <td style="text-align:center;">
                            <asp:GridView ID="gvX" runat="server" AllowPaging="True" AutoGenerateColumns="False" CaptionAlign="Left" CellPadding="4" EnableModelValidation="True" ForeColor="#000000" GridLines="Both" HorizontalAlign="Left" onrowcommand="gvX_RowCommand"   onpageindexchanging="gvX_PageIndexChanging"    style="margin-top: 0px; width:100%; font-size:12px;">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:TemplateField HeaderText="S/N">
                            <ItemTemplate>
                                 <%#Container.DataItemIndex+1 %>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" Width="30px" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                         <asp:BoundField DataField="oai_no" HeaderText="OAI No.">
                        <HeaderStyle HorizontalAlign="Left" Width="100px" />
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="reg_dt" HeaderText="FILING DATE" >
                        <HeaderStyle HorizontalAlign="Left" Width="50px" />
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="reg_no" HeaderText="FILE No."  ReadOnly="True">
                        <HeaderStyle HorizontalAlign="Left" Width="120px" />
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                          <asp:BoundField DataField="applicant_name" HeaderText="APPLICANT NAME">
                        <HeaderStyle HorizontalAlign="Left" Width="250px" />
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="product_title" HeaderText="PRODUCT TITLE" ReadOnly="True">
                        <HeaderStyle HorizontalAlign="Left" Width="250px" />
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="xclass" HeaderText="CLASS">
                        <HeaderStyle HorizontalAlign="Left" Width="10px" />
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>  
                         <asp:BoundField DataField="xstat" HeaderText="STATUS">
                        <HeaderStyle HorizontalAlign="Left" Width="50px" />
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>                        
                        <asp:TemplateField HeaderText="" Visible="false" >
                             <ItemTemplate>
                             <asp:Label ID="lblLogStaff" runat="server" Text='<%#Eval("log_staff") %>'  ></asp:Label>                              
                             </ItemTemplate>
                              <HeaderStyle HorizontalAlign="Left" Width="10px"/>
                             <ItemStyle HorizontalAlign="Left" />
                             </asp:TemplateField>
                          <asp:TemplateField HeaderText="VIEW" >
                             <ItemTemplate>
                              <asp:ImageButton ID="btnXEdit" ImageUrl="../../images/search.gif" runat="server" Height="16px" CommandName="TmViewClick"  CommandArgument='<%#Eval("xid") %>'  />
                             </ItemTemplate>
                              <HeaderStyle HorizontalAlign="Left" Width="20px"/>
                             <ItemStyle HorizontalAlign="Left" />
                             </asp:TemplateField>                      
                        <asp:TemplateField HeaderText="VIEW" >
                             <ItemTemplate>
                              <asp:HyperLink ID="btnnewTab" Text="New Tab" runat="server" Target="_blank" NavigateUrl='<%# string.Format("./registrar_data_detailsx.aspx?x={0}", Eval("xid")) %>' />
                             </ItemTemplate>
                              <HeaderStyle HorizontalAlign="Left" Width="40px"/>
                             <ItemStyle HorizontalAlign="Left" />
                             </asp:TemplateField>
                      
                    </Columns>
                    <EditRowStyle BackColor="#7C6F57" />
                    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#E3EAEB" />
                    <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                </asp:GridView>
                 <input id="Button1" type="button" ng-click="changeValue2()" value="UPDATE BATCH " /> 
                       <table st-table="displayedCollection" st-safe-src="ListAgent" class="table table-responsive table-bordered">
        <thead>
            <tr>
                 <th  class="tbbg2">S/N</th>
                <th st-sort="oai_no" class="tbbg2">OAI NUMBER</th>
                <th st-sort="reg_dt" class="tbbg2">FILING DATE</th>
                 <th st-sort="reg_no" class="tbbg2"> FILE No</th>
                 <th st-sort="applicant_name" class="tbbg2">APPLICANT NAME</th>
                 <th  st-sort="product_title" class="tbbg2">PRODUCT TITLE</th>
                   <th  st-sort="product_title" class="tbbg2">CLASS</th>
                   <th  st-sort="product_title" class="tbbg2">STATUS</th>

                <th  st-sort="RECORDAL_TYPE2" class="tbbg2">RECORDAL TYPE</th>
            
            <th  st-sort="RECORDAL_STATUS" class="tbbg2">RECORDAL STATUS</th>
            <th  >ACTION</th>
                 <th  class="tbbg2">View</th>
                <th  class="tbbg2">Open New Tab</th>

                <th  class="tbbg2">ACK</th>

               

            </tr>
            <tr>
                <th colspan="16"><input id="aa" st-search="" class="form-control" placeholder="global search ..." type="text" /></th>
            </tr>
        </thead>
        <tbody>
            <tr ng-repeat="row in displayedCollection" ng-class="{'pending-delete': add2(row)}">
               
                <td align="center">{{row.Sn}}</td>
                <td align="center">{{row.oai_no}}</td>
                <td align="center">{{row.reg_dt}}</td>
                 <td align="center">{{row.reg_no}}</td>
                <td align="center">{{row.applicant_name}}</td>
                <td align="center">{{row.product_title}}</td>
                 <td align="center">{{row.xclass}}</td>
                 <td align="center">{{row.xstat}}</td>
                <td align="center">{{row.RECORDAL_TYPE2}}</td>

                <td align="center">{{row.RECORDAL_STATUS}}</td>
                
                      <td >
                
                                <input type="radio" ng-model="row.description"   value="Acceptance">
                               Acceptance
                            </label>

                  
                            <label>
                                <input type="radio" ng-model="row.description"  value="Certificate">
                                Certificate
                            </label>
               
                </td>

                <td align="center">
               <a href="Generic_registrar_data_details5.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD={{row.oai_no}} &&recordalid={{row.RecordalID}} "><i class="fa fa-link"></i></a>
                
            </td>

                 <td align="center">
               
               <a target="_blank" class="icon-bar" href="Generic_registrar_data_details5.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD={{row.oai_no}} &&recordalid={{row.RecordalID}}"> <i class="fa fa-external-link"></i></a>
            </td>

                 <td align="center">
               
               <a target="_blank" class="icon-bar" ng-click="scrollTo(row); $event.preventDefault(); $event.stopPropagation();" href=""> <i class="fa fa-external-link"></i></a>
            </td>


              <%--  <td align="center">
               
               <a target="_blank" class="icon-bar" ng-click="add3(row); $event.preventDefault(); $event.stopPropagation();" href=""> <i class="fa fa-external-link"></i></a>
            </td>--%>
                
  

              
            </tr>
        </tbody>
        <tfoot>
            <tr>
                <td colspan="16" class="text-center">
                    <div st-pagination="" st-items-by-page="itemsByPage" st-displayed-pages="7"></div>
                </td>
            </tr>
        </tfoot>
    </table>

            </td>
             </tr>
             <tr >
            <td align="center">            
                &nbsp;</td>
            </tr>
             <tr >
            <td align="center">&nbsp;</td>
            </tr>
             <tr >
            <td align="center">&nbsp;</td>
            </tr>
          </table>
        </div>
    </div>
</div>
</div>
        <input id="xname" name="xname" type="hidden" runat="server" />
    </form>
</body>
</html>