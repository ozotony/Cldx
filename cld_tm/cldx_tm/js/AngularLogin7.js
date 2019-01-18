var app = angular.module("myModule", ["xeditable", "angular-loading-bar"]);
var serviceBaseIpo = 'http://88.150.164.30/EinaoTestEnvironment.IPO/';

var serviceBaseCld = 'http://88.150.164.30/EinaoTestEnvironment.CLD/';

app.run(function (editableOptions) {
    editableOptions.theme = 'bs3'; // bootstrap3 theme. Can be also 'bs2', 'default'
});




app.controller('myController', ['$scope', '$http', '$rootScope', '$filter', function ($scope, $http, $rootScope, $filter) {
  
    GetCountries();
    function GetCountries() {
        $http({
            method: 'GET',
            url: 'http://ipo.cldng.com/Handlers/Getcountry.ashx'
        }).success(function (data, status, headers, config) {
            var dd = data;
            $scope.countries = data;
        }).error(function (data, status, headers, config) {
            $scope.message = 'Unexpected Error';
        });
    }

    
    $scope.processing = false;

    $scope.newApplicantName = "click to add Name";
    $rootScope.newApplicantName2 = "Applicant Name";

    $scope.newApplicantAddress = "click to add Address ";

    $rootScope.newApplicantNationality = "click to add Nationality";

    $scope.newApplicantDescription = "click to add Applicant Description";
    $rootScope.newApplicantDescription2 = "click to add Applicant Description";

    $rootScope.newApplicantAddress2 = "Applicant Adress";

    $scope.newApplicantInstrument = "input full particulars of the instrument of assignment or transmission, if any, or statement of case";

    $scope.status = "was";
    $rootScope.status3 = "was";

    $scope.status2 = "took";
    $rootScope.status4 = "took";

    $scope.b = false;
    $scope.c = false;
    $scope.d = false;
    $scope.Days = 0;
    $rootScope.Days2 = 0;
    $scope.Month = 0;

    $rootScope.Month2 = 0; 
    $scope.Year = 0;

    $scope.valuedate=""

    $rootScope.Year2 = 0;

    $scope.Day = [{ value: 0, text: 'Select Date' }, { value: 1, text: '1' }, { value: 2, text: '2' }, { value: 3, text: '3' }, { value: 4, text: '4' }, { value: 5, text: '5' }, { value: 6, text: '6' }, { value: 7, text: '7' }, { value: 8, text: '8' }, { value: 9, text: '9' }, { value: 10, text: '10' }, { value: 11, text: '11' }, { value: 12, text: '12' }, { value: 13, text: '13' }

    , { value: 14, text: '14' }, { value: 15, text: '15' }, { value: 16, text: '16' }, { value: 17, text: '17' }, { value: 18, text: '18' }, { value: 19, text: '19' }, { value: 20, text: '20' }, { value: 21, text: '21' }, { value: 22, text: '22' }, { value: 23, text: '23' }, { value: 24, text: '24' }, { value: 25, text: '25' }, { value: 26, text: '26' }, { value: 27, text: '27' }, { value: 28, text: '28' }, { value: 29, text: '29' },  { value: 30, text: '30' }, { value: 31, text: '31' }];

    $scope.Months = [{ value: 0, text: 'Select Month' }, { value: 'January', text: 'January' }, { value: 'Febuary', text: 'Febuary' }, { value: 'March', text: 'March' }, { value: 'April', text: 'April' }, { value: 'May', text: 'May' }, { value: 'June', text: 'June' }, { value: 'July', text: 'July' }, { value: 'August', text: 'August' }, { value: 'September', text: 'September' }, { value: 'October', text: 'October' }, { value: 'November', text: 'November' }, { value: 'December', text: 'December' }];

    $scope.Years = [{ value: 0, text: 'Select Year' }, { value: 1985, text: '1985' }, { value: 1986, text: '1986' }, { value: 1987, text: '1987' }, { value: 1988, text: '1988' }, { value: 1989, text: '1989' }, { value: 1990, text: '1990' }, { value:1991, text: '1991' }, { value: 1992, text: '1992' }, { value:1993, text: '1993' }, { value: 1994, text: '1994' }, { value: 1995, text: '1995' }, { value: 1996, text: '1996' }, { value: 1997, text: '1997' }

   , { value: 1998, text: '1998' }, { value: 1999, text: '1999' }, { value: 2000, text: '2000' }, { value: 2001, text: '2001' }, { value: 2002, text: '2002' }, { value: 2003, text: '2003' }, { value: 2004, text: '2004' }, { value: 2005, text: '2005' }, { value: 2006, text: '2006' }, { value: 2007, text: '2007' }, { value: 2008, text: '2008' }, { value: 2009, text: '2009' }, { value: 2010, text: '2010' }, { value: 2011, text: '2011' }, { value: 2012, text: '2012' }, { value: 2013, text: '2013' }, { value: 2014, text: '2014' }, { value: 2015, text: '2015' }, { value: 2015, text: '2016' }, { value: 2015, text: '2017' }, { value: 2015, text: '2018' }];

    $scope.showStatus10 = function () {
        var selected = $filter('filter')($scope.Day, { value: $scope.Days });

        return ($scope.Days && selected.length) ? selected[0].text : 'Not set';
    };

    $scope.showStatus11 = function () {
        var selected = $filter('filter')($scope.Months, { value: $scope.Month });
        return ($scope.Month && selected.length) ? selected[0].text : 'Not set';
    };

    $scope.showStatus12 = function () {
        var selected = $filter('filter')($scope.Years, { value: $scope.Year });
        return ($scope.Year && selected.length) ? selected[0].text : 'Not set';
    };

    $scope.Registrar_direction = false;

    $scope.advertisements_complying = false;

    $scope.publication = false;


    $(document).ready(function () {
        var xname = $("input#xname").val();
       // var xname = "36440";

          $rootScope.xname4 = $("input#xname").val();
       // $rootScope.xname4 = '36440'
        $rootScope.xname5 = $("input#vamount").val();
       // $rootScope.xname5='12000'
           $rootScope.xname6 = $("input#vtranid").val();

       // $rootScope.xname6 = '201412111842358'



        var Encrypt = {
            vv: xname
        }
        var formData = new FormData();
        formData.append("vv", xname);
        $http({
            method: 'POST',
            url: serviceBaseCld+'Handlers/GetApplicantAssignment.ashx',
            transformRequest: function (obj) {
                var str = [];
                for (var p in obj)
                    str.push(encodeURIComponent(p) + "=" + encodeURIComponent(obj[p]));
                return str.join("&");
            },
            data: Encrypt,

            //Convert the Observable Data into JSON

            headers: { 'Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8;' }
            //JSON.stringify({ vid: countryId })
        }).success(function (response) {
           // var content = JSON.parse(response);
            //  alert(content)
            $scope.ApplicantName = response[0].applicant_name;

            $scope.Street = response[0].Street;

            $scope.product_title = response[0].product_title;

            $scope.applicantID = response[0].applicantID;

            $scope.rtm = response[0].rtm;

            $scope.xclass = response[0].xclass;

         

            $scope.oai_no = response[0].oai_no;

            $scope.CountryID = response[0].CountryID;

            

            

            //  $scope.states = data;
        }).error(function (data, status, headers, config) {
            $scope.message = 'Unexpected Error';
        });



    });

    $scope.statuses = [
    { value: "was", text: 'was' },
    { value: "was not", text: 'was not' }
    ];


    $scope.statuses2 = [
    { value: "took", text: 'took' },
    { value: "did not take", text: 'did not take' }
    ];



    $scope.showStatus = function () {
        var selected = $filter('filter')($scope.statuses, { value: $scope.status });
     

     
        return ($scope.status && selected.length) ? selected[0].text : 'Not set';
    };


    $scope.$watch('status', function (newVal, oldVal) {
        if (newVal !== oldVal) {
          
            $rootScope.status3 = newVal;


        }
    });


    $scope.$watch('Days', function (newVal, oldVal) {
        if (newVal !== oldVal) {

            $rootScope.Days2 = newVal;


        }
    });

    $scope.$watch('newApplicantDescription', function (newVal, oldVal) {
        if (newVal !== oldVal) {

            $rootScope.newApplicantDescription2 = newVal;


        }
    });

    
    $scope.$watch('Month', function (newVal, oldVal) {
        if (newVal !== oldVal) {

            $rootScope.Month2 = newVal;


        }
    });


    $scope.$watch('Year', function (newVal, oldVal) {
        if (newVal !== oldVal) {

            $rootScope.Year2 = newVal;


        }
    });



    $scope.$watch('status2', function (newVal, oldVal) {
        if (newVal !== oldVal) {

            $rootScope.status4 = newVal;


        }
    });


    $scope.showStatus2 = function () {
        var selected = $filter('filter')($scope.statuses2, { value: $scope.status2 });
        return ($scope.status2 && selected.length) ? selected[0].text : 'Not set';
    };
    $scope.submitForm = function () {

        //if ($scope.ApplicantName2 == null) {
        //    swal("Applicant Name Cannot Be Null", "error");

        //    return

        //}


        swal({
            title: "UPDATE ASSIGNMENT",
            text: "CONTINUE WITH CHANGE ",
            type: "success",
            showCancelButton: true,
            confirmButtonColor: "#DD6B55", confirmButtonText: "PROCEED!",
            cancelButtonText: "No!",
            closeOnConfirm: true,
            closeOnCancel: true
        },
function (isConfirm) {
    if (isConfirm) {
        var formData = new FormData();

        var Encrypt = {
            vv: $scope.ApplicantName,
            vv2: $rootScope.newApplicantName2,
            vv3: $scope.Street,
            vv4: $rootScope.newApplicantAddress2,
            vv5: $scope.CountryID,
            vv6: $rootScope.newApplicantNationality,
            vv7: $rootScope.status3,
            vv8: $rootScope.status4,
            vv9: $scope.valuedate,
            vv10: $rootScope.Days2,
            vv11: $rootScope.Month2,
            vv12: $rootScope.Year2,
            vv13: $rootScope.xname4,
            vv14: $rootScope.xname5,
            vv15: $rootScope.xname6,
            vv16: $rootScope.newApplicantDescription2

        }
      
        $scope.processing = true;
        formData.append("vv", JSON.stringify(Encrypt));
      
        if ($scope.valuedate == "") {

            alert("You Must Select Date")
            $scope.processing = false;
            return;

        }


        if ($rootScope.Days2 == "0") {

            alert("You Must Select Day")
            $scope.processing = false;
            return;

        }

        if ($rootScope.Month2 == "0") {

            alert("You Must Select Month")
            $scope.processing = false;
            return;

        }

        if ($rootScope.Year2 == "0") {

            alert("You Must Select Year")
            $scope.processing = false;
            return;

        }


        if ($rootScope.newApplicantName2 == "Applicant Name") {

            alert("You Must Enter  Applicant Name")
            $scope.processing = false;
            return;

        }

        if ($rootScope.newApplicantAddress2 == "Applicant Adress") {

            alert("You Must Enter  Applicant Address")
            return;

        }

        if ($rootScope.newApplicantNationality == "click to add Nationality") {

            alert("You Must  Select     Applicant Nationality")

            $scope.processing = false;
            return;

        }

        var totalFiles = document.getElementById("File1").files.length;
        //if (totalFiles == 0 && $scope.Logo != "2") {
        //    alert("Upload File")
         
        //    return;

        //}

        for (var i = 0; i < totalFiles; i++) {
            var file = document.getElementById("File1").files[i];



            formData.append("FileUpload", file);
        }


        totalFiles = document.getElementById("File2").files.length;

        for (var i = 0; i < totalFiles; i++) {
            var file = document.getElementById("File2").files[i];



            formData.append("FileUpload2", file);
        }


        totalFiles = document.getElementById("File3").files.length;

        for (var i = 0; i < totalFiles; i++) {
            var file = document.getElementById("File3").files[i];



            formData.append("FileUpload3", file);
        }

        totalFiles = document.getElementById("File4").files.length;

        for (var i = 0; i < totalFiles; i++) {
            var file = document.getElementById("File4").files[i];



            formData.append("FileUpload4", file);
        }

        totalFiles = document.getElementById("File5").files.length;

        for (var i = 0; i < totalFiles; i++) {
            var file = document.getElementById("File5").files[i];



            formData.append("FileUpload5", file);
        }


        totalFiles = document.getElementById("File6").files.length;

        if (totalFiles == 0 ) {
            alert("Upload File")
            $scope.processing = false;
           return;

        }

        for (var i = 0; i < totalFiles; i++) {
            var file = document.getElementById("File6").files[i];



            formData.append("FileUpload6", file);
        }

        totalFiles = document.getElementById("File7").files.length;

        if (totalFiles == 0) {
            alert("Upload File")
            $scope.processing = false;
            return;

        }

        for (var i = 0; i < totalFiles; i++) {
            var file = document.getElementById("File7").files[i];



            formData.append("FileUpload7", file);
        }

        totalFiles = document.getElementById("File8").files.length;

        if (totalFiles == 0) {
            alert("Upload File")
            $scope.processing = false;
            return;

        }

        for (var i = 0; i < totalFiles; i++) {
            var file = document.getElementById("File8").files[i];



            formData.append("FileUpload8", file);
        }

        $scope.processing = true;

        $http.post(serviceBaseCld+'Handlers/UpdateApplicant5.ashx', formData, {
      //  $http.post('http://localhost:49703/Handlers/UpdateApplicant5.ashx', formData, {
            transformRequest: angular.identity,
            headers: { 'Content-Type': undefined }
        })
                           .success(function (response) {


                               var content = JSON.parse(response);

                               window.location.href = "http://88.150.164.30/EinaoTestEnvironment.CLD/admin/tm/Generic_registrar_data_details4d.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + content;
                           //    window.location.href = "http://localhost:49703/admin/tm/Generic_registrar_data_details4d.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + $rootScope.xname6;


                           })
                           .error(function () {
                               $scope.processing = false;
                           });




    } else {
        swal("Cancelled", "Action Canceled :)", "error");

        $scope.processing = false;
    }
});



    }

    $scope.$watch('publication', function (newVal, oldVal) {
        if (newVal !== oldVal) {

            if (newVal) {

                $scope.d = true;
            }
            else {

                $scope.d = false;
            }


        }
    });

    
    $scope.$watch('advertisements_complying', function (newVal, oldVal) {
        if (newVal !== oldVal) {
            
            if (newVal) {

                $scope.c = true;
            }
            else {

                $scope.c = false;
            }


        }
    });
 

    $scope.$watch('Registrar_direction', function (newVal, oldVal) {
        if (newVal !== oldVal) {

            if (newVal) {

                $scope.b = true;
            }
            else {

                $scope.b = false;
            }


        }
    });



    $scope.loadGroups = function () {

        $http({
            method: 'GET',
            url: serviceBaseIpo +'Handlers/Getcountry.ashx'
        }).success(function (data, status, headers, config) {
            var dd = data;
            $scope.groups = data;
          
        }).error(function (data, status, headers, config) {
            $scope.message = 'Unexpected Error';
        });

        
    };

    
    $scope.$watch('newApplicantName', function (newVal, oldVal) {
        if (newVal !== oldVal) {
           
            $rootScope.newApplicantName2 = newVal;
            

        }
    });


    $scope.$watch('newApplicantAddress', function (newVal, oldVal) {
        if (newVal !== oldVal) {
          
            $rootScope.newApplicantAddress2 = newVal;


        }
    });



    $scope.$watch('newApplicantNationality', function (newVal, oldVal) {
        if (newVal !== oldVal) {
          
            $rootScope.newApplicantNationality = newVal
            var selected = $filter('filter')($scope.groups, { id: $rootScope.newApplicantNationality });
            $rootScope.newApplicantNationality = selected.length ? selected[0].text : null;
            $rootScope.newApplicantNationality = newVal
        }
    });


    
   

}]);












