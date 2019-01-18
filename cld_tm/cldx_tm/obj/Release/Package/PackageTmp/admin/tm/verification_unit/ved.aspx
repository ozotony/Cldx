<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ved.aspx.cs" Inherits="cld.admin.tm.acceptance_unit.ved" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
<link href="../../../css/style.css" rel="stylesheet" type="text/css" /> 
 <link href="../../../amcharts_2.6.6/samples/style.css" rel="stylesheet" type="text/css" />
 <script src="../../../amcharts_2.6.6/amcharts/amcharts.js" type="text/javascript"></script>


 <script type="text/javascript">
     var columnchart;
     var piechart;
     var pielegend;

     var columnchartData = [{
         country: "NEW",
         value: <% Response.Write(g_new); %>,
         color: "#FDD017"
     }, {
         country: "TREATED",
         value: <% Response.Write(g_treated); %>,
         color: "#347C17"
     },{
         country: "RE-CALLED",
         value: <% Response.Write(g_rejected); %>,
         color: "#FF0000"
     }];


     AmCharts.ready(function () {
         // SERIAL CHART
         columnchart = new AmCharts.AmSerialChart();
         columnchart.dataProvider = columnchartData;
         columnchart.categoryField = "country";
         columnchart.startDuration = 2;
         // the following two lines makes chart 3D
         columnchart.depth3D = 20;
         columnchart.angle = 30;

         // AXES
         // category
         var categoryAxis = columnchart.categoryAxis;
         categoryAxis.labelRotation = 90;
         categoryAxis.dashLength = 5;
         categoryAxis.gridPosition = "start";

         // value
         var valueAxis = new AmCharts.ValueAxis();
         valueAxis.title = "Total Number";
         valueAxis.dashLength = 5;
         columnchart.addValueAxis(valueAxis);

         // GRAPH            
         var columngraph = new AmCharts.AmGraph();
         columngraph.valueField = "value";
         columngraph.colorField = "color";
         columngraph.balloonText = "[[category]]: [[value]]";
         columngraph.type = "column";
         columngraph.lineAlpha = 0;
         columngraph.fillAlphas = 1;
         columngraph.fillColors = ["#ffe78e", "#bf1c25"];
         columnchart.addGraph(columngraph);

         // PIE CHART
         piechart = new AmCharts.AmPieChart();
         piechart.dataProvider = columnchartData;
         piechart.titleField = "country";
         piechart.valueField = "value";
         piechart.colorField = "color";
         piechart.outlineColor = "#FFFFFF";
         piechart.outlineAlpha = 0.8;
         piechart.outlineThickness = 2;
         // this makes the chart 3D
         piechart.depth3D = 15;
         piechart.angle = 30;

         // WRITE
         piechart.write("piechartdiv");

         // WRITE
         columnchart.write("columndiv");
     });
        </script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
       
        <div class="container">
            <div class="sidebar">
            <a href="../lo.aspx">
            <img alt="" src="../../../images/logoff.png" width="16" height="16" />Log off
            </a>
            <a href="./profile.aspx">PROFILE</a> 
            <a href="../../../cp.aspx?x=<% Response.Write(adminID); %>">CHANGE PASSWORD</a> 
            </div>
            <div class="content">
        
    <table align="center" width="100%" >  
        <tr>
            <td colspan="5" align="left" class="tbbg">
                WELCOME TO THE VERIFICATION UNIT EXECUTIVE DASHBOARD</td>
        </tr>
        <tr align="center">
        <td colspan="2" align="right" >
             <img alt="" src="../../../images/coat_of_arms.png" style="width: 60px; height: 60px" /> 
            </td>
            <td colspan="3" align="left" >
             <strong>FEDERAL MINISTRY OF TRADE AND INVESTMENT<br />
                COMMERCIAL LAW DEPARTMENT<br /> </strong>
            </td>
        </tr>         
        <tr>
            <td style="width: 20%;" align="center" class="tbbg">
                Grand Total</td>
                 <td style="width: 20%;" align="center" class="tbbg">
                Unit Total</td>
            <td style="width: 20%;" align="center" class="tbbg">
                New </td>            
                 <td style="width: 20%;" align="center" class="tbbg">
               Treated</td>
            <td style="width: 20%;" align="center" class="tbbg">
                Re-called</td>
        </tr>
        
        <tr>
            <td  align="center">
                <% Response.Write(g_total); %></td>
                <td  align="center">
                <% Response.Write(g_utotal); %></td>
            <td  align="center">
                <% Response.Write(g_new); %></td>
            <td  align="center">
                <% Response.Write(g_treated); %></td>               
            <td  align="center">
                <% Response.Write(g_rejected); %></td>
        </tr>
                 
        <tr>
            <td align="center" colspan="5" class="tbbg">
               <strong>Search By Date Range<% if ((fromdate!="") && (todate!= ""))
                                              { %> (From  <% Response.Write(fromdate); %>to <% Response.Write(todate); %>)<% } %></strong>
            </td>
        </tr>
        
        <tr>
            <td align="center" colspan="5" >
                &nbsp;<strong>FROM</strong>
                <span class="textbox">
                &nbsp;Year:&nbsp;
                <asp:DropDownList ID="selectFromYear" runat="server"></asp:DropDownList>
                &nbsp;Month: &nbsp;
                <asp:DropDownList ID="selectFromMonth" runat="server"></asp:DropDownList>
                &nbsp;Day: &nbsp;
                <asp:DropDownList ID="selectFromDay" runat="server"></asp:DropDownList>
                </span>
                
                &nbsp;&nbsp;&nbsp;&nbsp;<strong>TO</strong>
                <span class="textbox">                
               &nbsp;Year:&nbsp;
                <asp:DropDownList ID="selectToYear" runat="server"></asp:DropDownList>
                 &nbsp;Month: &nbsp;
                <asp:DropDownList ID="selectToMonth" runat="server"></asp:DropDownList>
                 &nbsp;Day: &nbsp;
                 
                <asp:DropDownList ID="selectToDay" runat="server"></asp:DropDownList>
                </span>
                &nbsp;<asp:Button ID="btnSearch" runat="server" 
                    Text="Search"  CssClass="button" onclick="btnSearch_Click"/>
            &nbsp;<asp:Button ID="btnAll" runat="server" 
                    Text="Show All"  CssClass="button" onclick="btnAll_Click" />
            </td>
        </tr>
        
        <tr>
            <td align="center" colspan="5" class="tbbg">
                &nbsp;</td>
        </tr>
        
        <tr>
            <td align="center" colspan="2">
               <div id="columndiv" style="width: 100%; height: 400px;"></div>
               </td>
               <td align="center" colspan="3">
               <div id="piechartdiv" style="width: 100%; height: 400px;"></div>
               </td>
        </tr>
        
        <tr>
            <td align="center" colspan="5">
                </td>
        </tr>
        
        <tr>
            <td class="tbbg" colspan="5">
              
            </td>
        </tr>
    </table>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
