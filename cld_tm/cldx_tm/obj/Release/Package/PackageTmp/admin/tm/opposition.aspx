<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="opposition.aspx.cs" Inherits="cld.admin.tm.opposition" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" data-ng-app="myModule">
<head id="Head1" runat="server">
    <title>OPPOSITION DATA</title>


<link rel="stylesheet" href="../../css/jquery.ui.all.css" />

<script type="text/javascript" src="../../js/jquery.js"></script>

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
<%--    <script src="../../Scripts/GetData.js"></script>--%>
         <script type="text/javascript" src="../../js/AngularLogin12.js"></script>
    <script type="text/javascript" src="../../js/dirPagination.js"></script>
    <link href="../../css/font-awesome.min.css" rel="stylesheet" />
    <script type="text/javascript" src="../../js/bootstrap.min.js"></script>
    <script src="../../js/ng-modal.min.js"></script>
    <link href="../../css/ng-modal.css" rel="stylesheet" />
    <link href="../../css/sweet-alert.css" rel="stylesheet" />
    <script src="../../js/sweet-alert.min.js"></script>
<script language="javascript" type="text/javascript">
    function doPostResults(eu) {
        postwith('./opposition.aspx', { eu: eu });
    }

	</script>
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

         <style type="text/css">
 .pending-delete {
     color:red;
     background-color: lightgreen;
 }
    </style>
</head>
<body ng-controller="myController4">
    <form id="form1" runat="server">
   <div>
    <div class="container">
        <div class="sidebar" >
            <a href="./opposition_unit/profile.aspx">PROFILE</a> 
            <a  href="../../cp.aspx?x=<% Response.Write(admin); %>">CHANGE PASSWORD</a> 
            <a href="./opposition_unit/oed.aspx">VIEW STATISTICS</a>
            <a  href="./opposed.aspx">VIEW OPPOSED APPS</a>
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
            <table width="100%" id="Table1">
          <tr>
            <td colspan="8"  class="tbbg"> WELCOME TO THE OPPOSITION UNIT</td>
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
                 <select class="form-control " data-ng-options="c.SearchCriteria as c.SearchCriteria for c in varray44" name="criteria" ng-model="criteria" >
                                <option value="">-- Select   --</option>
                            </select>
                 <input name="search_data" id="txt_application_date" class="form-control"  placeholder="Enter Filter Criteria"  ng-model="search_data" type="text" />
                
                
                <asp:DropDownList Visible="false" ID="selectSearchCriteria" runat="server" AutoPostBack="False">
                <asp:ListItem Text="TRADEMARK" Value="product_title"></asp:ListItem>
                <asp:ListItem Text="ONLINE ID" Value="app_number"></asp:ListItem>
                </asp:DropDownList>
&nbsp;&nbsp;

             
              <input visible="false" name="kword" type="text" id="kword"  size="50"   value="" runat="server"/>
              
             
              <input visible="false" type="text" id="datepickerFrom" runat="server"/>
              &nbsp;
            
              <input visible="false" type="text" id="datepickerTo" runat="server"/>
              &nbsp;</td>
          </tr>

         <tr class="stripedout">
            <td colspan="9" align="center">  
                 <button type="button" ng-click="search()" class="btn   btn-info "><i class="fa fa-search"></i>Search</button>          
                <asp:Button Visible="false" ID="btnSearch" runat="server" Text="SEARCH" class="button" 
                    onclick="btnSearch_Click"   />

                <asp:Button Visible="false" ID="Button1" runat="server" Text="Move Record To Certificate Unit" class="button" 
                    onclick="btnSearch_Click2"   />
          <tr >
            <td style="text-align:center;">
                            <asp:GridView ID="gvX" runat="server" AllowPaging="True" AutoGenerateColumns="False"   OnSorting="gvEmployee_Sorting" AllowSorting="true" CaptionAlign="Left" CellPadding="4" EnableModelValidation="True" ForeColor="#000000" GridLines="Both" HorizontalAlign="Left" onrowcommand="gvX_RowCommand"   onpageindexchanging="gvX_PageIndexChanging"    style="margin-top: 0px; width:100%; font-size:12px;">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:templatefield HeaderText="Select">
        <itemtemplate>
            <asp:checkbox ID="cbSelect" CssClass="gridCB" runat="server"></asp:checkbox>
        </itemtemplate>
    </asp:templatefield>
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
                         <asp:BoundField DataField="batches" SortExpression="batches" HeaderText="Batch.">
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
                             <asp:Label ID="applicantID" runat="server" Text='<%#Eval("applicantID") %>'  ></asp:Label>                              
                             </ItemTemplate>
                              <HeaderStyle HorizontalAlign="Left" Width="10px"/>
                             <ItemStyle HorizontalAlign="Left" />
                             </asp:TemplateField>                     
                        <asp:TemplateField HeaderText="" Visible="false" >
                             <ItemTemplate>
                             <asp:Label ID="lblLogStaff" runat="server" Text='<%#Eval("log_staff") %>'  ></asp:Label>                              
                             </ItemTemplate>
                              <HeaderStyle HorizontalAlign="Left" Width="10px"/>
                             <ItemStyle HorizontalAlign="Left" />
                             </asp:TemplateField>
                        <asp:TemplateField HeaderText="REPORT" >
                             <ItemTemplate>
                              <asp:ImageButton ID="btnXEdits" ImageUrl="../../images/search.gif" runat="server" Target="_blank" Height="16px" NavigateUrl='<%# string.Format("./s_data_details_report.aspx?x={0}", Eval("xid")) %>'  />
                             </ItemTemplate>
                              <HeaderStyle HorizontalAlign="Left" Width="20px"/>
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
                              <asp:HyperLink ID="btnnewTab" Text="New Tab" runat="server" Target="_blank" NavigateUrl='<%# string.Format("./opposition_data_detailsx.aspx?x={0}", Eval("xid")) %>' />
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
                  <th st-sort="oai_no" class="tbbg2">  Batch</th>
              
                 <th st-sort="reg_no" class="tbbg2">FILE NUMBER</th>
                <th st-sort="req_type" class="tbbg2">REQUEST TYPE</th>
                 <th st-sort="reg_date" class="tbbg2"> REQUEST DATE</th>
                 <th st-sort="xname" class="tbbg2">APPLICANT NAME</th>
                 <th  st-sort="tm_title" class="tbbg2">TITLE OF PRODUCT</th>
                 <th  st-sort="product_title" class="tbbg2">CLASS</th>
                 <%--  <th  st-sort="xclass" class="tbbg2">COMMENT</th>--%>
                   <th  st-sort="xstat" class="tbbg2">STATUS</th>
                  
             <th  st-sort="xstat" class="tbbg2">ACTION</th>
               <th  st-sort="TransactionId" class="tbbg2">TRANSACTION ID</th>

             
           
          
                <th  class="tbbg2">Report</th>
                 <th  class="tbbg2">View</th>
                 <th  class="tbbg2"></th>

               

            </tr>
           
        </thead>
        <tbody>
          <%--  <tr ng-repeat="row in displayedCollection" >--%>
             <tr dir-paginate="row in ListAgent|itemsPerPage:itemsPerPage" total-items="total_count" ng-class="{'pending-delete': add2(row)}">
               
                <td align="center">{{row.Sn}}</td>

               
                <td align="center">{{row.oai_no}}</td>
                 <td align="center">{{row.batches}}</td>
                 <td align="center">{{row.reg_no}}</td>
                <td align="center">{{row.tm_type}}</td>
                 <td align="center">{{row.reg_dt}}</td>
                <td align="center">{{row.applicant_name}}</td>
                <td align="center">{{row.product_title}}</td>
                <td align="center">{{row.xclass}}</td>
                <%-- <td align="center">{{row.comments}}</td>--%>
                 <td align="center">{{row.xstat}}</td>
                  <td align="center"><span>Certificate Unit </span</span> <input type="checkbox"  {{row.description}} ng-checked="changeValue(row)" ng-model="row.description"></td>
               <td align="center">{{row.TransactionId2}}</td>
              
               
                <td align="center">
               <a target="_blank" class="icon-bar" href="./s_data_details_report.aspx?x={{row.xid}}&cri=n "> <i class="fa fa-external-link"></i></a>
            </td>
                  

                <td align="center">
               <a target="_blank" class="icon-bar" href="./opposition_data_detailsx.aspx?x={{row.xid}}&cri=n "> <i class="fa fa-external-link"></i></a>
            </td>

             
                          </td>
                
  <td align="center">   <input id="Button2" type="button" ng-show="!show(row)" ng-click="EditRow44(row)" value="View Receipt" />  </td>  
  

              
            </tr>
        </tbody>
        <tfoot>
            <tr>
                <td colspan="13" class="text-center">
                    <div st-pagination="" st-items-by-page="itemsByPage" st-displayed-pages="12"></div>
                      <dir-pagination-controls    max-size="8"       direction-links="true"    boundary-links="true"   on-page-change="getData(newPageNumber)">     </dir-pagination-controls>
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
    </form>
</body>
</html>
