<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Change_Assignment.aspx.cs" Inherits="cld.admin.tm.Change_Assignment" %>

<!DOCTYPE html>

<html data-ng-app="myModule">

<head >
    <meta http-equiv="CONTENT-TYPE" content="text/html; charset=utf-8" />
    <title></title>
    <meta name="GENERATOR" content="LibreOffice 4.1.6.2 (Linux)" />
    <meta name="AUTHOR" content="taiwoolaniyan" />
    <meta name="CREATED" content="20150519;145700000000000" />
    <meta name="CHANGEDBY" content="Anthony ozoagu" />
    <meta name="CHANGED" content="20150521;105300000000000" />
    <script src="Scripts/jquery-1.10.2.min.js"></script>

    <script src="../../js/jquery-2.1.1.min.js"></script>

    <script src="../../js/angular.min.js"></script>

    <link href="../../css/xeditable.css" rel="stylesheet" />

    <script src="../../js/xeditable.min.js"></script>
    <link href="../../css/bootstrap.min.css" rel="stylesheet" />
    <script src="../../js/AngularLogin7.js"></script>
    <script src="../../js/sweet-alert.min.js"></script>
    <link href="../../css/sweet-alert.css" rel="stylesheet" />
    <script src="../../js/loading-bar.js"></script>
    <link href="../../css/loading-bar.css" rel="stylesheet" />


    <!--<script src="Scripts/bootstrap.js"></script>
   

    <script src="Scripts/ui-bootstrap-tpls.min.js"></script>

   
    <link href="Content/angular-bootstrap-datepicker.css" rel="stylesheet" />
    <script src="Scripts/angular-bootstrap-datepicker.min.js"></script>-->
   



   
    
    <style type="text/css">
        <!--
        @page {
            size: 8.5in 11in;
            margin-right: 0.75in;
            margin-top: 0.69in;
            margin-bottom: 0.75in;
        }

        P {
            margin-bottom: 0in;
            direction: ltr;
            color: #000000;
            background: #ffffff;
            line-height: 100%;
            widows: 2;
            orphans: 2;
        }

            P.western {
                font-family: "Arial", sans-serif;
                font-size: 12pt;
                so-language: en-GB;
                font-weight: bold;
            }

            P.cjk {
                font-family: "Calibri", sans-serif;
                font-size: 12pt;
                font-weight: bold;
            }

            P.ctl {
                font-family: "Arial", sans-serif;
                font-size: 12pt;
                so-language: ar-SA;
                font-weight: bold;
            }
        -->

        #exampleInput {
    background-color: transparent;
    border: 0px solid;
    height: 20px;
    width: 140px;
    color: black;
    align-content:center;
  
}

        input[type="file"] {
  display:inline
}
    </style>
</head>
<body lang="en-US" text="#000000" dir="LTR" ng-controller="myController">
   
    <p class="western" align=CENTER style="margin-right: 0.03in; line-height: 115%">
        <font face="Calibri, sans-serif">
            <font size=3>
                <b>
                    <span style="background: transparent">
                        FORM
                        16
                    </span>
                </b>
            </font>
        </font>
    </p>
    <p class="western" align=CENTER style="margin-right: 0.03in; line-height: 115%">
        <font face="Calibri, sans-serif">
            <font size=3>
                <b>
                    <span style="background: transparent">
                        TRADE
                        MARKS ACT
                    </span>
                </b>
            </font>
        </font>
    </p>
    <p class="western" align=CENTER style="margin-right: 0.03in; font-weight: normal; line-height: 100%">
        <br />
    </p>
    <p class="western" align=CENTER style="margin-right: 0.03in; font-weight: normal; line-height: 115%">
        <font face="Calibri, sans-serif">
            <font size=2 style="font-size: 11pt">
                <span style="background: transparent">
                    <font size=3>
                        <i>
                            <u>
                                <b>
                                    JOINT
                                    REQUEST TO THE REGISTRAR BY REGISTERED PROPRIETOR AND TRANSFEREE TO
                                    REGISTER THE TRANSFEREE AS SUBSEQUENT PROPRIETOR OF TRADE MARKS UPON
                                    THE SAME DEVOLUTION OF TITLE (REGULATION 73)
                                </b>
                            </u>
                        </i>
                    </font>
                </span>
            </font>
        </font>
    </p>
    <p class="western" align=CENTER style="margin-right: 0.03in; line-height: 115%">
        <br />
    </p>
    <p class="western" align=JUSTIFY style="margin-right: 0.03in; font-weight: normal; line-height: 100%">
        <span style="background: transparent">                      </span>
    </p>
    <p class="western" align=JUSTIFY style="margin-right: 0.03in; font-weight: normal; line-height: 100%">
        <br />
    </p>
    <p class="western" align=JUSTIFY style="margin-right: 0.03in; font-weight: normal; line-height: 115%">
        <font face="Calibri, sans-serif">
            <font size=2 style="font-size: 11pt">
                <span style="background: transparent">
                    <font size=3>
                        We,
                    </font><font >
                        <font size=3>

                           <span  ng-bind="ApplicantName" style="margin-right: 0.09in;">  </span><span ng-bind="Street"></span>
                        </font>
                    </font><font size=3> and </font><font color="#3333cc">
                        <font size=3>
                            <span ng-controller="myController">  <a href="#" editable-text="newApplicantName">{{ newApplicantName || 'empty' }}</a>  </span>

                            <span ng-controller="myController">

                                <a href="#" editable-textarea="newApplicantAddress" e-rows="7" e-cols="40">
                                    {{ newApplicantAddress || 'no description' }}
                                </a>

                            </span>

                            <span ng-controller="myController">
                                <a href="#" editable-select="newApplicantNationality" onshow="loadGroups()" e-ng-options="g.name as g.name for g in groups">
                                    {{ newApplicantNationality || 'not set' }}
                                </a>
                            </span>
                            <!--<div ng-controller="myController">

                            </div>-->




                        </font>
                    </font><font size=3>
                        hereby request, under Regulation 73, that the name of
                    </font><font color="#3333cc">
                        <font size=3>
                            <span > {{ newApplicantName2  }} </span>
                        </font>
                    </font><font size=3>
                        carrying on
                        business as
                    </font><font color="#3333cc">
                        <font size=3>
                            <a href="#" editable-textarea="newApplicantDescription" e-rows="7" e-cols="40">
                                {{ newApplicantDescription || 'no description' }}
                            </a>
                        </font>
                    </font><font size=3>at </font><font color="#3333cc">
                        <font size=3>
                            <span> {{ newApplicantAddress2  }} </span>
                        </font>
                    </font><font size=3>
                        may be entered
                        in the Register of Trade Marks as Proprietor of the Trade Mark
                    </font><font >
                        <font size=3>
                            <span ng-bind="product_title"> </span>
                          
                        </font>
                    </font><font size=3>with File No </font><font >
                        <font size=3>
                           <span ng-bind="oai_no"> </span>
                        </font>
                    </font><font size=3>and RTM No</font><font >
                        <font size=3>
                             <span ng-bind="rtm"> </span>
                          
                        </font>
                    </font><font size=3> in Class </font><font >
                        <font size=3>
                            <span ng-bind="xclass"> </span>
                        </font>
                    </font><font size=3> as from the </font><font color="#3333cc">
                        <font size=3>


                            <input type="date" class="span1" id="exampleInput" name="input"  ng-model="valuedate"
                                   placeholder="Select Date yyyy-MM-dd"  required />
                            <!--<span>
                                <datepicker button-next="&lt;i class='fa fa-arrow-right'&gt;&lt;/i&gt;" button-prev="&lt;i class='fa fa-arrow-left'&gt;&lt;/i&gt;" date-format="yyyy-M-d">
                                    <input name="application_date" id="txt_application_date" ng-model="dob" type="text" />
                                </datepicker>

                            </span>-->

                               
</font>
                    </font><font size=3>
                        by virtue of
                    </font><font color="#3333cc">
                        <font size=3>

                            <span ng-controller="myController">

                                <a href="#" editable-textarea="newApplicantInstrument" e-rows="7" e-cols="40">
                                    {{ newApplicantInstrument || 'no description' }}
                                </a>

                            </span>
                         
                        </font>
                    </font>
                </span>
            </font>
        </font>
    </p>
    <p class="western" align=JUSTIFY style="margin-right: 0.03in; font-weight: normal; line-height: 115%">
        <br />
    </p>
    <p class="western" align=JUSTIFY style="margin-right: 0.03in; font-weight: normal; line-height: 115%">
        <br />
    </p>
    <p class="western" align=JUSTIFY style="margin-right: 0.03in; font-weight: normal; line-height: 115%">
        <font face="Calibri, sans-serif">
            <font size=2 style="font-size: 11pt">
                <span style="background: transparent">
                    <font size=3>
                        The
                        Trade Mark at the time of assignment
                    </font><font >
                        <font size=3>
                            <i>
                                <u>
                                    <b>
                                        <span ng-controller="myController">
                                            <a href="#" editable-radiolist="status" e-ng-options="s.value as s.text for s in statuses">
                                                {{ showStatus() }}
                                            </a>
                                        </span>
                                    </b>
                                </u>
                            </i>
                        </font>
                    </font><font size=3>
                        used in a business in the
                        goods in question, and the assignment
                    </font><font>
                        <font size=3>
                            <i>
                                <u>
                                    <b>
                                        <span ng-controller="myController">
                                            <a href="#" editable-radiolist="status2" e-ng-options="s.value as s.text for s in statuses2">
                                                {{ showStatus2() }}
                                            </a>
                                        </span>
                                    </b>
                                </u>
                            </i>
                        </font>
                    </font><font size=3>
                        place on or after the
                        commencement of the Act otherwise than in connection with the
                        goodwill of a business in the goods; and there is sent herewith:
                    </font>
                </span>
            </font>
        </font>
    </p>
    <ol>
        <li>
            <p class="western" align=JUSTIFY style="margin-right: 0.03in; font-weight: normal; line-height: 115%">
                <font face="Calibri, sans-serif">
                    <font size=2 style="font-size: 11pt">
                        <span style="background: transparent">
                            <font size=3>
                                Copy
                                of the Registrar’s direction to advertise the assignment
                            </font><font >
                                <font size=3>
                                    <span ng-controller="myController">
                                        <a href="#" editable-checkbox="Registrar_direction" e-title="Registrar direction">
                                            {{ Registrar_direction && "Check!" || "UnCheck" }}
                                        </a>
                                        <input id="File1" ng-show="b"  type="file" />
                                      
                                    </span>

                                   
                                </font>
                            </font>
                        </span>
                    </font>
                </font>
            </p>
        </li>
        <li>
            <p class="western" align=JUSTIFY style="margin-right: 0.03in; font-weight: normal; line-height: 115%">
                <font face="Calibri, sans-serif">
                    <font size=2 style="font-size: 11pt">
                        <span style="background: transparent">
                            <font size=3>
                                Copy
                                of each of the advertisements complying therewith
                            </font><font >
                                <font size=3>
                                    <span ng-controller="myController">
                                        <a href="#" editable-checkbox="advertisements_complying" e-title="Advertisements Complying">
                                            {{ advertisements_complying && "Check!" || "UnCheck" }}
                                        </a>
                                        <input id="File2" ng-show="c" type="file" />

                                    </span>
                                </font>
                            </font>
                        </span>
                    </font>
                </font>
            </p>
        </li>
        <li>
            <p class="western" align=JUSTIFY style="margin-right: 0.03in; font-weight: normal; line-height: 115%">
                <font face="Calibri, sans-serif">
                    <font size=2 style="font-size: 11pt">
                        <span style="background: transparent">
                            <font size=3>
                                Statement
                                of the dates of issue of any publications containing them
                            </font><font >
                                <font size=3>
                                    <span ng-controller="myController">
                                        <a href="#" editable-checkbox="publication" e-title="Publication">
                                            {{ publication && "Check!" || "UnCheck" }}
                                        </a>
                                        <input id="File3" ng-show="d" type="file" />

                                    </span>
                                </font>
                            </font>
                        </span>
                    </font>
                </font>
            </p>
        </li>
    </ol>
    <p class="western" align=JUSTIFY style="margin-right: 0.03in; font-weight: normal; line-height: 115%">
        <br />
    </p>
    <p class="western" align=JUSTIFY style="margin-right: 0.03in; font-weight: normal; line-height: 115%">
        <br />
    </p>
    <p class="western" align=JUSTIFY style="margin-right: 0.03in; font-weight: normal; line-height: 115%">
        <font face="Calibri, sans-serif">
            <font size=2 style="font-size: 11pt">
                <span style="background: transparent">
                    <font size=3>
                        DATED
                        this
                    </font><font >
                        <font size=3>
                            <span ng-controller="myController">
                                <a href="#" editable-select="Days" e-ng-options="s.value as s.text for s in Day">
                                    {{ showStatus10() }}
                                </a>
                            </span>
                        </font>
                    </font><font size=3>
                        day
                        of
                    </font><font >
                        <font size=3>
                            <span ng-controller="myController">
                            <a href="#" editable-select="Month" e-ng-options="s.value as s.text for s in Months">
                                {{ showStatus11() }}
                            </a>
                </span>
            </font></font><font size=3>
                        ,
                    </font><font ><font size=3><span ng-controller="myController">
    <a href="#" editable-select="Year" e-ng-options="s.value as s.text for s in Years">
        {{ showStatus12() }}
    </a>
</span></font></font><font size=3>.</font>
                </span>
            </font>
        </font>
    </p>
    <p class="western" align=JUSTIFY style="margin-right: 0.03in; font-weight: normal; line-height: 115%">
        <br />
    </p>
    <p class="western" align=JUSTIFY style="margin-right: 0.03in; font-weight: normal; line-height: 115%">
        <br />
    </p>
    <p class="western" align=JUSTIFY style="margin-right: 0.03in; font-weight: normal; line-height: 115%">
        <font face="Calibri, sans-serif">
            <font size=2 style="font-size: 11pt">
                <span style="background: transparent">
                    <font size=3>
                        Signature
                        of Assignor or Transmitter
                    </font><font >
                        <font size=3>
                            <span>
                                <input id="File4" type="file" />
                            </span>
                           
                        </font>
                    </font>
                </span>
            </font>
        </font>
    </p>
    <p class="western" align=JUSTIFY style="margin-right: 0.03in; font-weight: normal; line-height: 115%">
        <font face="Calibri, sans-serif">
            <font size=2 style="font-size: 11pt">
                <span style="background: transparent">
                    <font size=3>
                        Signature
                        of Assignee or Transferee
                    </font><font >
                        <font size=3>
                            <input id="File5"  type="file" />
                        </font>
                    </font>
                </span>
            </font>
        </font>
    </p>
    <p class="western" align=JUSTIFY style="margin-right: 0.03in; font-weight: normal; line-height: 115%">
        <br />
    </p>
    <p class="western" align=JUSTIFY style="margin-right: 0.03in; font-weight: normal; line-height: 115%">
        <br />
    </p>
    <p class="western" align=JUSTIFY style="margin-right: 0.03in; font-weight: normal; line-height: 115%">
        <br />
    </p>
    <p class="western" align=JUSTIFY style="margin-right: 0.03in; font-weight: normal; line-height: 115%">
        <font face="Calibri, sans-serif">
            <font size=2 style="font-size: 11pt">
                <span style="background: transparent">
                    <font >
                        <font size=3>
                            *Deed
                            of Assignment
                        </font>
                    </font><font >
                        <font size=3>
                            <i>
                                <b>
                                    <input id="File6"  type="file" />
                                </b>
                            </i>
                        </font>
                    </font>
                </span>
            </font>
        </font>
    </p>
    <p class="western" align=JUSTIFY style="margin-right: 0.03in; font-weight: normal; line-height: 115%">
        <font face="Calibri, sans-serif">
            <font size=2 style="font-size: 11pt">
                <span style="background: transparent">
                    <font >
                        <font size=3>
                            *Power
                            of Attorney
                        </font>
                    </font><font >
                        <font size=3>
                            <i>
                                <b>
                                    <input id="File7"  type="file" />
                                </b>
                            </i>
                        </font>
                    </font>
                </span>
            </font>
        </font>
    </p>
    <p class="western" align=JUSTIFY style="margin-right: 0.03in; font-weight: normal; line-height: 115%">
        <font face="Calibri, sans-serif">
            <font size=2 style="font-size: 11pt">
                <span style="background: transparent">
                    <font >
                        <font size=3>
                            *Certificate
                            of Registration of Trade Mark
                        </font>
                    </font><font >
                        <font size=3>
                            <i>
                                <b>
                                    <input id="File8"  type="file" />
                                </b>
                            </i>
                        </font>
                    </font>
                </span>
            </font>
        </font>
        <br />
        <input id="Submit1" type="submit" ng-click="submitForm()" ng-disabled="processing" value="Submit Application" />
    </p>
    <p class="western" align=JUSTIFY style="margin-right: 0.03in; font-weight: normal; line-height: 115%">
        <br />
    </p>
    <p class="western" align=JUSTIFY style="margin-right: 0.03in; font-weight: normal; line-height: 115%">
        <br />
    </p>
    <p class="western" align=JUSTIFY style="margin-right: 0.03in; font-weight: normal; line-height: 115%">
        <br />
    </p>
    <p class="western" align=JUSTIFY style="margin-right: 0.03in; font-weight: normal; line-height: 115%">
       
    </p>
    
    <input id="xname" name="xname" type="hidden" runat="server" />
             <input id="vamount" name="vamount" type="hidden" runat="server" />
            <input id="vtranid" name="vtranid" type="hidden" runat="server" />
        
</body>
</html>