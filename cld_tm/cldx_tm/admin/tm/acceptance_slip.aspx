<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="acceptance_slip.aspx.cs" Inherits="cld.admin.tm.acceptance_slip" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" data-ng-app="myModule" >
<head runat="server">
    <title>ACCEPTANCE DATA</title>
    <link rel="stylesheet" type="text/css" href="../../css/style.css" />



    <script src="../../js/jquery-2.1.1.min.js"></script>


<script src="../../js/funk.js" type="text/javascript"></script>
     <link href="../../css/bootstrap.min.css" rel="stylesheet" />
   
    <script type="text/javascript" src="../../js/angular.min.js"></script>
    <link href="../../css/loading-bar.css" rel="stylesheet" />
    <script type="text/javascript" src="../../js/loading-bar.js"></script>
    <script type="text/javascript" src="../../js/smart-table.min.js"></script>
    <script src="../../Scripts/GetData3.js"></script>
        <script type="text/javascript" src="../../js/dirPagination.js"></script>
    <script src="../../Scripts/angular-datepicker.min.js"></script>

    <link href="../../css/angular-datepicker.min.css" rel="stylesheet" />
    <script type="text/javascript" src="../../js/bootstrap.min.js"></script>
    <script src="../../js/ng-modal.min.js"></script>
    <link href="../../css/ng-modal.css" rel="stylesheet" />
    <link href="../../css/sweet-alert.css" rel="stylesheet" />
    <script src="../../js/sweet-alert.min.js"></script>
<%--    <script src="../../js/ui-bootstrap-tpls-1.3.3.min.js"></script>--%>

     <script type="text/javascript" src="../../js/bootstrap.min.js"></script>
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.5.0/css/all.css" integrity="sha384-B4dIYHKNBt8Bc12p+WXckhzcICo0wtJAoU8YZTY5qE0Id1GSseTk6S+L3BlXeVIU" crossorigin="anonymous">

    <style type="text/css">
        .pending-delete {
    
     background-color: yellow;
 }

    </style>


</head>
<body ng-controller="myController6">
    <form id="form1" runat="server">
  
    <div class="container">
        <div class="sidebar">
             <a href="./acceptance_unit/profile.aspx">PROFILE</a> 
           
            <a href="./acceptance_unit/aed.aspx">VIEW STATISTICS</a>
            <a href="./acceptance_slip.aspx">VIEW ACCEPTANCE</a>
        </div>
        <div class="content" >
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
                  
                </div>
            </div>
            <table  id="searchform">
          <tr>
            <td  class="tbbg">WELCOME TO THE ACCEPTANCE UNIT</td>
          </tr>
          <tr >
            <td align="center">
            <asp:Button ID="btnReloadPage" runat="server" Text="RELOAD PAGE" class="button" 
                    onclick="btnReloadPage_Click" />
              </td>
          </tr>
         
          <tr>
            <td class="tbbg">&nbsp;PLEASE SEARCH FOR ENTRIES BELOW</td>
          </tr>

                          <tr >
            <td colspan="8" align="center" class="tbbg">
                 <select class="form-control " data-ng-options="c.SearchCriteria as c.SearchCriteria for c in varray44" name="criteria" ng-change="getdetails()" ng-model="criteria" >
                                <option value="">-- Select   --</option>
                            </select>
                 <input name="search_data" ng-show="val1" id="txt_application_date" class="form-control"  placeholder="Enter Filter Criteria"  ng-model="search_data" type="text" />
               <datepicker button-next="&lt;i class='fa fa-arrow-right'&gt;&lt;/i&gt;" ng-show="val2" button-prev="&lt;i class='fa fa-arrow-left'&gt;&lt;/i&gt;" date-format="yyyy-MM-dd">
                                <input name="search_data2" id="txt_application_date2" placeholder="Select Start Date"  class="form-control"  ng-model="search_data2"    type="text" />
                            </datepicker>
                    <datepicker ng-show="val3" button-next="&lt;i class='fa fa-arrow-right'&gt;&lt;/i&gt;" button-prev="&lt;i class='fa fa-arrow-left'&gt;&lt;/i&gt;" date-format="yyyy-MM-dd">
                                <input name="search_data2" id="txt_application_date3" placeholder="Select End Date"  class="form-control"  ng-model="search_data3"    type="text" />
                            </datepicker>
                
                 <button type="button" ng-click="search()" class="btn   btn-info "><i class="fa fa-search"></i>Search</button>
            </td>
          </tr>
          
          <tr class="stripedout">
            <td align="center" ></td>
          </tr>

             <tr >
            <td style="text-align:center;" >
                <asp:GridView ID="gvX" runat="server"   AutoGenerateColumns="False" CaptionAlign="Left" CellPadding="4" EnableModelValidation="True" ForeColor="#000000" GridLines="Both" HorizontalAlign="Left" onrowcommand="gvX_RowCommand"   onpageindexchanging="gvX_PageIndexChanging"  CssClass="table table-striped table-bordered table-hover"   style="margin-top: 0px; width:100%; font-size:12px;">
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

                             <asp:TemplateField HeaderText="INDEX" >
                             <ItemTemplate>
                              <asp:ImageButton ID="btnXIndex" ImageUrl="../../images/search.gif" runat="server" Height="16px" CommandName="TmIndexClick"  CommandArgument='<%#Eval("xid") %>'  />
                             </ItemTemplate>
                              <HeaderStyle HorizontalAlign="Left" Width="25px"/>
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
                              <asp:HyperLink ID="btnnewTab" Text="New Tab" runat="server" Target="_blank" NavigateUrl='<%# string.Format("./acceptance_slip_details.aspx?x={0}", Eval("xid")) %>' />
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

                              <div class="alert alert-success alert-dismissable">
  
  <strong>Note That Applications with yellow background indicates printed . </strong> 
</div>

                     <table st-table="displayedCollection" st-safe-src="ListAgent2" class="table table-responsive table-bordered">
                   
        <thead>
            <tr>
                 <th  class="tbbg2">S/N</th>
                <th st-sort="oai_no" class="tbbg2">OAI NUMBER</th>
                 <th st-sort="reg_no" class="tbbg2">FILE NUMBER</th>
                <th st-sort="req_type" class="tbbg2">REQUEST TYPE</th>
                 <th st-sort="reg_date" class="tbbg2"> REQUEST DATE</th>
                 <th st-sort="xname" class="tbbg2">APPLICANT NAME</th>
                 <th  st-sort="tm_title" class="tbbg2">TITLE OF PRODUCT</th>
                 <th  st-sort="product_title" class="tbbg2">CLASS</th>
              
                   <th  st-sort="xstat" class="tbbg2">STATUS</th>
              

             
           
               <th  class="tbbg2">View </th>
           
                 <th  class="tbbg2">View Acceptance Letter </th>
               

               

            </tr>
            <tr>
                <th colspan="12"><input st-search="" class="form-control" placeholder="global search ..." type="text" /></th>
            </tr>
        </thead>
        <tbody>
           <%-- <tr ng-repeat="row in displayedCollection" >--%>
            <tr dir-paginate="row in ListAgent2|itemsPerPage:itemsPerPage" total-items="total_count"  ng-class="{'pending-delete': add2(row)}" >

               
                <td align="center">{{row.Sn}}</td>

               
                <td align="center">{{row.oai_no}}</td>
                 <td align="center">{{row.reg_no}}</td>
                <td align="center">{{row.tm_type}}</td>
                 <td align="center">{{row.reg_dt}}</td>
                <td align="center">{{row.applicant_name}}</td>
                <td align="center">{{row.product_title}}</td>
                <td align="center">{{row.xclass}}</td>
       
                 <td align="center">{{row.xstat}}</td>
              
              
               
                  <td align="center">
               <a target="_blank"  href="./acceptance_slip_audit_details.aspx?x={{row.xid}}&cri=n "> <i class="fa fa-external-link"></i>View</a>
            </td>

                  

                <td align="center">
               <a target="_blank"  href="./acceptance_slip_details.aspx?x={{row.xid}}&cri=n "> <i class="fa fa-external-link"></i>View</a>
            </td>

             
                
  

              
            </tr>
        </tbody>
        <tfoot>
            <tr>
                <td colspan="12" class="text-center">
                    <div st-pagination="" st-items-by-page="itemsByPage" st-displayed-pages="9"></div>
                     <dir-pagination-controls    max-size="8"       direction-links="true"    boundary-links="true"   on-page-change="getData(newPageNumber)">     </dir-pagination-controls>
                </td>
            </tr>
        </tfoot>
    </table>


                              

           

                 <asp:Panel ID="Panel1" runat="server"></asp:Panel>
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

    </form>
</body>
</html>
