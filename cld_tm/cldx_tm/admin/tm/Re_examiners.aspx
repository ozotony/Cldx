<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Re_examiners.aspx.cs" Inherits="cld.admin.tm.Re_examiners" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" data-ng-app="myModule">
<head id="Head1" runat="server">
    <title>EXAMINERS DATA</title>
    <link rel="stylesheet" type="text/css" href="../../css/style.css" />

<link rel="stylesheet" href="../../css/jquery.ui.all.css" />

 <script src="../../js/jquery-1.7.2.min.js" type="text/javascript"></script>
<script src="../../js/jquery-ui-1.8.16.custom.min.js" type="text/javascript"></script>

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
    <script src="../../Scripts/GetData.js"></script>
    <link href="../../css/font-awesome.min.css" rel="stylesheet" />
    <script type="text/javascript" src="../../js/bootstrap.min.js"></script>
    <script src="../../js/ng-modal.min.js"></script>
    <link href="../../css/ng-modal.css" rel="stylesheet" />
    <link href="../../css/sweet-alert.css" rel="stylesheet" />
    <script src="../../js/sweet-alert.min.js"></script>
<script language="javascript" type="text/javascript">
    function doPostResults(eu) {
        postwith('./examiners.aspx', { eu: eu });
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
</head>
<body ng-controller="myController3">
    <form id="form1" runat="server">
   <div>
               <table align="center" style="width: 1200px;">
                   <tr>
                       <td>
                  <table width="100%" id="Table1" style="margin-top: 0px; width:100%; font-size:11px; border: 1px dashed #1c5e55; ">
          <tr style="text-align:center;">
            <td >
               <img alt="Coat Of Arms" height="79" src="../../images/coat_of_arms.png" width="85" />
    </td>
          </tr>
          <tr >
            <td align="center" style="background-color:#1C5E55; "></td>
            </tr>
          <tr style="text-align:center;font-size:12px; ">
            <td >
                   FEDERAL REPUBLIC OF NIGERIA<br />
                    FEDERAL MINISTRY OF INDUSTRY, TRADE AND INVESTMENT<br />
                    COMMERCIAL LAW DEPARTMENT<br />
                    TRADEMARKS, PATENTS AND DESIGNS REGISTRY<br />
                    
             </td>
          </tr>
          <tr>
            <td  class="tbbg"> WELCOME TO THE EXAMINERS UNIT</td>
          </tr>
          <tr class="stripedout">
            <td align="center">
                 

                 <asp:Button ID="btnProfile" runat="server" Text="PROFILE" class="button" 
                     onclick="btnProfile_Click"  />&nbsp;
            <asp:Button ID="btnChangePin" runat="server" Text="CHANGE PASSWORD" class="button" 
                     onclick="btnChangePin_Click" />&nbsp;
            <asp:Button ID="btnViewStats" runat="server" Text="VIEW STATISTICS" class="button" 
                     onclick="btnViewStats_Click"  />&nbsp;
             <asp:Button ID="btnReloadPage" runat="server" Text="RELOAD PAGE" class="button" OnClick="btnReloadPage_Click"  />&nbsp;
              <asp:Button ID="btnLogOff" runat="server" Text="LOG OFF" class="button" onclick="btnLogOff_Click"  />
              </td>
          </tr>
         
          <tr>
            <td class="tbbg">&nbsp;PLEASE SEARCH FOR ENTRIES BELOW</td>
          </tr>
          
          <tr class="stripedout">
            <td align="center" ><%Response.Write(criteria); %></td>
          </tr>
          
          <tr >
            <td align="center" class="tbbg">
               <%-- <asp:DropDownList ID="selectSearchCriteria" runat="server" AutoPostBack="False" style="font-size:11px;">
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
              &nbsp;--%>
            </td>
          </tr>

         <tr class="stripedout">
            <td align="center">            
                <%--<asp:Button ID="btnSearch" runat="server" Text="SEARCH" class="button" 
                    onclick="btnSearch_Click"   />--%>

              </td>
            </tr>         
          <tr >
            <td align="center" style="background-color:#1C5E55; "></td>
            </tr>
       
         <tr >
            <td align="center" style="color:#ff0000; font-size: 14px; font-weight: bolder; ">         
                CODE NOTICE: <strong>Reg</strong>="Registrable"; <strong>N-Reg</strong>="Non-registrable"; <strong>RCS</strong>="Re-conduct search"; <strong>CLS</strong>="Class";  </td>
            </tr>         
         
        <tr> 
         <td style="text-align: center;font-size: 16px;font-weight: bolder; color:#000;">            
                   <%=cnt_msg %></td>
            </tr>         
         
       
          <tr >
            <td style="text-align:center;">
                            <asp:GridView ID="gvX" runat="server" AllowPaging="True" AutoGenerateColumns="False" CaptionAlign="Left" CellPadding="4" EnableModelValidation="True" ForeColor="#000000" GridLines="Both" HorizontalAlign="Left" onrowcommand="gvX_RowCommand"   onpageindexchanging="gvX_PageIndexChanging"    style="margin-top: 0px; width:100%; font-size:11px;">
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
                        <HeaderStyle HorizontalAlign="Left" Width="70px" />
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="reg_dt" HeaderText="FILING DATE" >
                        <HeaderStyle HorizontalAlign="Left" Width="50px" />
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="reg_no" HeaderText="FILE No."  ReadOnly="True">
                        <HeaderStyle HorizontalAlign="Left" Width="100px" />
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                          <asp:BoundField DataField="applicant_name" HeaderText="APPLICANT NAME">
                        <HeaderStyle HorizontalAlign="Left" Width="150px" />
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="product_title" HeaderText="PRODUCT TITLE" ReadOnly="True">
                        <HeaderStyle HorizontalAlign="Left" Width="150px" />
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="xclass" HeaderText="CLS">
                        <HeaderStyle HorizontalAlign="Left" Width="10px" />
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>  
                         <asp:BoundField DataField="xstat" HeaderText="STATUS">
                        <HeaderStyle HorizontalAlign="Left" Width="50px" />
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>  
                                   
                          <asp:BoundField DataField="scmt" HeaderText="SEARCH OFFICER COMMENT">
                        <HeaderStyle HorizontalAlign="Left" Width="150px" />
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>    
                               
                        <asp:TemplateField HeaderText="" Visible="false" >
                             <ItemTemplate>
                             <asp:Label ID="lblLogStaff" runat="server" Text='<%#Eval("log_staff") %>'  ></asp:Label>                              
                             </ItemTemplate>
                              <HeaderStyle HorizontalAlign="Left" Width="10px"/>
                             <ItemStyle HorizontalAlign="Left" />
                             </asp:TemplateField>
                                                
                        <asp:TemplateField HeaderText="VIEW">
                             <ItemTemplate>
                              <asp:HyperLink ID="btnnewTab" runat="server" Target="_blank" ImageUrl="../../images/search.gif" NavigateUrl='<%# string.Format("./examination_data_detail.aspx?x={0}&cri=n", Eval("xid")) %>' />
                             </ItemTemplate>
                              <HeaderStyle HorizontalAlign="Left" Width="10px"/>
                             <ItemStyle HorizontalAlign="Left" />
                         </asp:TemplateField>

                       <asp:TemplateField  HeaderText="ACTION" >
                     <ItemTemplate>
                    <asp:RadioButtonList ID="rbValid" runat="server" RepeatDirection="Horizontal" AutoPostBack="True" OnSelectedIndexChanged="rbValid_SelectedIndexChanged">
                    <asp:ListItem Value="Registrable">Reg </asp:ListItem>
                    <asp:ListItem Value="Non-registrable">N-Reg</asp:ListItem>
                    <asp:ListItem Value="Re-conduct search 1">RCS</asp:ListItem>
                    </asp:RadioButtonList>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" Width="100px" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:TemplateField>

                        <asp:TemplateField  HeaderText="" >
                            <ItemTemplate>
                                <asp:CheckBox ID="cbAddBatch" runat="server" Enabled="False" />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" Width="20px" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                         
                          <asp:TemplateField>
                             <ItemTemplate>
                                 <asp:ImageButton ID="lbAddTm" ImageUrl="../../images/x.gif" runat="server" Height="16px" CommandName="TmDeleteClick"  CommandArgument='<%#Eval("xid") %>'  />
                             </ItemTemplate>
                              <HeaderStyle HorizontalAlign="Left" Width="10px"/>
                        <ItemStyle HorizontalAlign="Left" />
                             </asp:TemplateField>

                    </Columns>
                    <EditRowStyle BackColor="#7C6F57" />
                    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" HorizontalAlign="Left"/>
                    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#E3EAEB" />
                    <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                </asp:GridView>
                      <table st-table="displayedCollection" st-safe-src="ListAgent" class="table table-responsive table-bordered">
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
                   <th  st-sort="xclass" class="tbbg2">COMMENT</th>
                   <th  st-sort="xstat" class="tbbg2">STATUS</th>

             
           
          
           
                 <th  class="tbbg2">View</th>
                <th  class="tbbg2">Action</th>

               

            </tr>
            <tr>
                <th colspan="12"><input st-search="" class="form-control" placeholder="global search ..." type="text" /></th>
            </tr>
        </thead>
        <tbody>
            <tr ng-repeat="row in displayedCollection" >
               
                <td align="center">{{row.Sn}}</td>

               
                <td align="center">{{row.oai_no}}</td>
                 <td align="center">{{row.reg_no}}</td>
                <td align="center">{{row.tm_type}}</td>
                 <td align="center">{{row.reg_dt}}</td>
                <td align="center">{{row.applicant_name}}</td>
                <td align="center">{{row.product_title}}</td>
                <td align="center">{{row.xclass}}</td>
                 <td align="center">{{row.comments}}</td>
                 <td align="center">{{row.xstat}}</td>
              
              
               
                
                 

                <td align="center">
               <a target="_blank" class="icon-bar" href="./examination_data_detail.aspx?x={{row.xid}}&cri=n "> <i class="fa fa-external-link"></i></a>
            </td>

                 <td align="center">
               <label>
              <input type="radio" ng-model="row.description"   value="Registrable">
                              Reg
                            </label>

                  
                            <label>
                                <input type="radio" ng-model="row.description"  value="Non-registrable">
                               N-Reg
                            </label>

                      <label>
                                <input type="radio" ng-model="row.description"  value="Re-conduct search">
                              RCS
                            </label>
            </td>
                
  

              
            </tr>
        </tbody>
        <tfoot>
            <tr>
                <td colspan="12" class="text-center">
                    <div st-pagination="" st-items-by-page="itemsByPage" st-displayed-pages="12"></div>
                </td>
            </tr>
        </tfoot>
    </table>
            </td>
             </tr>
             <tr >
            <td class="tbbg">            
                  --- ADD COMMENT --- </td>
            </tr>
            
             <tr >
            <td style="text-align: center;font-size: 16px;font-weight: bolder; color:#ff0000;">            
                   <%=xmsg %></td>
            </tr>
             <tr >
            <td align="center">
                <asp:TextBox ID="comment" runat="server" Height="50px" TextMode="MultiLine" Width="98%"></asp:TextBox>
                 </td>
            </tr>
             <tr >
            <td align="center" style="background-color:#1C5E55; "></td>
            </tr>
             <tr >
            <td align="center">
                <%--<asp:Button ID="UpdateBatch" runat="server" Text="Update Batch" class="button" 
                    onclick="UpdateBatch_Click" />--%>

                <input id="Button1" class="button" type="button" ng-click="changeValue2()" value="UPDATE BATCH " />
                 </td>
            </tr>
          </table>         
                       </td>

                   </tr>

               </table> 
</div>
        <asp:HiddenField ID="HiddenField1" runat="server" />

    </form>
</body>
</html>