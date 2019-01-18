var app = angular.module("myModule", ["angular-loading-bar"]);

var serviceBaseIpo = 'http://ipo.cldng.com/';

//var serviceBaseCld = 'http://localhost:49703/'

var serviceBaseCld = 'http://45.40.139.163/EinaoTestEnvironment.CLD/'

app.controller('myController', ['$scope', '$http', '$rootScope', '$filter', function ($scope, $http, $rootScope, $filter) {

    GetCountries();
    function GetCountries() {
        $http({
            method: 'GET',
            url: serviceBaseIpo +  'Handlers/Getcountry.ashx'
        }).success(function (data, status, headers, config) {
            var dd = data;
            $scope.countries = data;
        }).error(function (data, status, headers, config) {
            $scope.message = 'Unexpected Error';
        });
    }


    $scope.processing = false;

    $scope.newApplicantName = "";


    $scope.newApplicantAddress = "";


    $scope.valuedate = "";




    $scope.b = false;
    $scope.c = false;
    $scope.d = false;
    $scope.Days = 0;

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

        $scope.xname6a = $("input#vtype").val();
        // $rootScope.xname6 = '201412111842358'



        var Encrypt = {
            vv: xname
        }
        var formData = new FormData();
        formData.append("vv", xname);
        $http({
            method: 'POST',
            url: serviceBaseCld +  'Handlers/GetApplicantAssignment.ashx',
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
            vv2: $scope.newApplicantName,
            vv3: $scope.Street,
            vv4: $scope.newApplicantAddress,
            vv5: $scope.CountryID,
            vv6: $scope.newApplicantNationality,

            vv9: $scope.valuedate,

            vv13: $rootScope.xname4,
            vv14: $rootScope.xname5,
            vv15: $rootScope.xname6,
            vv16: $scope.description

        }

        $scope.processing = true;
        formData.append("vv", JSON.stringify(Encrypt));

        if ($scope.valuedate == "") {

            alert("You Must Select Date")
            $scope.processing = false;
            return;

        }






        if ($scope.newApplicantName == "") {

            alert("You Must Enter  Applicant Name")
            $scope.processing = false;
            return;

        }

        if ($scope.newApplicantAddress == "") {

            alert("You Must Enter  Applicant Address")
            return;

        }

        if ($scope.newApplicantNationality == "") {

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


        $scope.processing = true;

        $http.post( serviceBaseCld + 'Handlers/UpdateApplicant6.ashx', formData, {
            //  $http.post('http://localhost:49703/Handlers/UpdateApplicant5.ashx', formData, {
            transformRequest: angular.identity,
            headers: { 'Content-Type': undefined }
        })
                           .success(function (response) {


                            //   var content = JSON.parse(response);

                               if ($scope.xname6a == "backend") {
                                   window.location.href = serviceBaseCld +  "admin/tm/Generic_registrar_data_details4dd.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + response.TransactionId + "&&Recordalid=" + response.Recordal_Id;
                               }

                               else {
                                   window.location.href = serviceBaseCld +  "admin/tm/Generic_registrar_data_details4d.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + response.TransactionId + "&&Recordalid=" + response.Recordal_Id;

                               }

                             
                               //    window.location.href = "http://localhost:49703/admin/tm/Generic_registrar_data_details4d.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + $rootScope.xname6;


                           })
                           .error(function (e) {
                               var dd = e;
                               $scope.processing = false;
                           });




    } else {
        swal("Cancelled", "Action Canceled :)", "error");

        $scope.processing = false;
    }
});



    }




    $scope.loadGroups = function () {

        $http({
            method: 'GET',
            url: serviceBaseIpo +  'Handlers/Getcountry.ashx'
        }).success(function (data, status, headers, config) {
            var dd = data;
            $scope.groups = data;

        }).error(function (data, status, headers, config) {
            $scope.message = 'Unexpected Error';
        });


    };







}]);


app.controller('myController2', ['$scope', '$http', '$rootScope', '$filter', function ($scope, $http, $rootScope, $filter) {




    $scope.processing = false;

    $scope.newApplicantName = "";


    $scope.newApplicantAddress = "";


    $scope.valuedate = "";




    $scope.b = false;
    $scope.c = false;
    $scope.d = false;
    $scope.Days = 0;

    $scope.Registrar_direction = false;

    $scope.advertisements_complying = false;

    $scope.publication = false;


    $(document).ready(function () {

        



       


    });

    
    $scope.getData = function () {
        try {
            var rr = $scope.from;
            var rr2 = $scope.to;
            var vcount = occurrences(rr, "/");
            var vcount2 = occurrences(rr2, "/");

            if (vcount != 4) {
                alert("Invalid Tp Number Format")
                return;
            }
            if (vcount2 != 4) {
                alert("Invalid Tp Number Format")
                return;
            }

        

            
            var res = rr.split("/");
            var res2 = rr2.split("/");
            res = parseInt(res[4])
            res2 = parseInt(res2[4])

            if (rr.indexOf("/") >= 0) {


            }
            if (res2 < res) {

                alert("From FileNumber Cannot Be Greater Than To")

                Return;
            }
        }

        catch (err) {
            alert("Invalid Tp Number ")
            Return;
        }
        var Encrypt = {
            vv: $scope.from,
            vv2: $scope.to,
        }
        var formData = new FormData();
      //  formData.append("vv", xname);
        $http({
            method: 'POST',
            url: serviceBaseCld + 'Handlers/GetCard.ashx',
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
        }).success(function (data, status, headers, config) {
            // var content = JSON.parse(response);
            //  alert(content)
           
            $scope.groups = data;
          //  $scope.groups = response;


            //  $scope.states = data;
        }).error(function (response) {

            console.log(response)
            $scope.message = 'Unexpected Error';
        });


    }

    $rootScope.matrixList = function (data, n) {
        var grid = [], i = 0, x = data.length, col, row = -1;
        for (var i = 0; i < x; i++) {
            col = i % n;
            if (col === 0) {
                grid[++row] = [];
            }
            grid[row][col] = data[i];
        }
        return grid;
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
            vv2: $scope.newApplicantName,
            vv3: $scope.Street,
            vv4: $scope.newApplicantAddress,
            vv5: $scope.CountryID,
            vv6: $scope.newApplicantNationality,

            vv9: $scope.valuedate,

            vv13: $rootScope.xname4,
            vv14: $rootScope.xname5,
            vv15: $rootScope.xname6,
            vv16: $scope.description

        }

        $scope.processing = true;
        formData.append("vv", JSON.stringify(Encrypt));

        if ($scope.valuedate == "") {

            alert("You Must Select Date")
            $scope.processing = false;
            return;

        }






        if ($scope.newApplicantName == "") {

            alert("You Must Enter  Applicant Name")
            $scope.processing = false;
            return;

        }

        if ($scope.newApplicantAddress == "") {

            alert("You Must Enter  Applicant Address")
            return;

        }

        if ($scope.newApplicantNationality == "") {

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


        $scope.processing = true;

        $http.post(serviceBaseCld + 'Handlers/UpdateApplicant6.ashx', formData, {
            //  $http.post('http://localhost:49703/Handlers/UpdateApplicant5.ashx', formData, {
            transformRequest: angular.identity,
            headers: { 'Content-Type': undefined }
        })
                           .success(function (response) {


                               //   var content = JSON.parse(response);

                               if ($scope.xname6a == "backend") {
                                   window.location.href = serviceBaseCld + "admin/tm/Generic_registrar_data_details4dd.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + response.TransactionId + "&&Recordalid=" + response.Recordal_Id;
                               }

                               else {
                                   window.location.href = serviceBaseCld + "admin/tm/Generic_registrar_data_details4d.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + response.TransactionId + "&&Recordalid=" + response.Recordal_Id;

                               }


                               //    window.location.href = "http://localhost:49703/admin/tm/Generic_registrar_data_details4d.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + $rootScope.xname6;


                           })
                           .error(function (e) {
                               var dd = e;
                               $scope.processing = false;
                           });




    } else {
        swal("Cancelled", "Action Canceled :)", "error");

        $scope.processing = false;
    }
});



    }




    $scope.loadGroups = function () {

        $http({
            method: 'GET',
            url: serviceBaseIpo + 'Handlers/Getcountry.ashx'
        }).success(function (data, status, headers, config) {
            var dd = data;
            $scope.groups = data;

        }).error(function (data, status, headers, config) {
            $scope.message = 'Unexpected Error';
        });


    };




    function occurrences(string, subString, allowOverlapping) {

        string += "";
        subString += "";
        if (subString.length <= 0) return (string.length + 1);

        var n = 0,
            pos = 0,
            step = allowOverlapping ? 1 : subString.length;

        while (true) {
            pos = string.indexOf(subString, pos);
            if (pos >= 0) {
                ++n;
                pos += step;
            } else break;
        }
        return n;
    }


}]);












