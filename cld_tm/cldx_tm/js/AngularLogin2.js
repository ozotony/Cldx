var app = angular.module('myModule', ['angular-loading-bar']);

var serviceBaseIpo = 'http://ipo.cldng.com/';

var serviceBaseCld = 'http://tm.cldng.com/';

app.controller('myController', ['$scope', '$http', '$rootScope', function ($scope, $http, $rootScope) {

    $scope.BranchCollect = [];
    $scope.itemsPerPage = 10;
    $scope.currentPage = 0;
    $scope.items = [];
    $scope.isDisabled = false;
    var url3 = serviceBaseIpo +'Handlers/GetRegistration2.ashx';

    // var url3 = ' http://localhost:21936/home/GetAgent';

    $(document).ready(function () {
        var xname = $("input#xname").val();

        $scope.xname4 = $("input#xname").val();
        $scope.xname5 = $("input#vamount").val();
        $scope.xname6 = $("input#vtranid").val();
        $scope.xname6a = $("input#vtype").val();
        
      

        var Encrypt = {
            vv: xname
        }
        var formData = new FormData();
        formData.append("vv", xname);
        $http({
            method: 'POST',
            url: serviceBaseCld +'Handlers/GetApplicantName.ashx',
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
            var content = JSON.parse(response);
          //  alert(content)
            //  $scope.ApplicantName = response.Applicant_Name;
            $scope.ApplicantName = content;
           
          //  $scope.states = data;
        }).error(function (data, status, headers, config) {
            $scope.message = 'Unexpected Error';
        });



    });


    $scope.submitForm = function () {

        if ($scope.ApplicantName2 == null) {
            swal("Applicant Name Cannot Be Null", "error");

            return 

        }


        swal({
            title: "UPDATE NAME",
            text: "CONTINUE WITH CHANGE OF APPLICANT NAME",
            type: "success",
            showCancelButton: true,
            confirmButtonColor: "#DD6B55", confirmButtonText: "PROCEED!",
            cancelButtonText: "No!",
            closeOnConfirm: true,
            closeOnCancel: true
        },
function (isConfirm) {
    if (isConfirm) {

        var Encrypt = {
            vv: $scope.ApplicantName,
            vv2: $scope.ApplicantName2,
            vv3: $scope.xname4,
            vv4: $scope.xname5,
            vv5: $scope.xname6,
            vv6: $scope.description

        }

        $http({
            method: 'POST',
            url: serviceBaseCld +'Handlers/UpdateApplicant.ashx',
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

          //  var content = JSON.parse(response);
            if ($scope.xname6a == "backend") {
                window.location.href = serviceBaseCld +"admin/tm/Generic_registrar_data_details4bb.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + response.TransactionId + "&&Recordalid=" + response.Recordal_Id;

            }

            else {

                window.location.href = serviceBaseCld +"admin/tm/Generic_registrar_data_details4b.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + response.TransactionId;

            }
            //     
        }).error(function (data, status, headers, config) {
            $scope.message = 'Unexpected Error';
        });



    } else {
        swal("Cancelled", "Action Canceled :)", "error");
    }
});




    }
    //When you have entire dataset



}]);

app.controller('myController2', ['$scope', '$http', '$rootScope', function ($scope, $http, $rootScope) {

    $scope.BranchCollect = [];
    $scope.itemsPerPage = 10;
    $scope.currentPage = 0;
    $scope.items = [];
    $scope.isDisabled = false;
    var url3 = serviceBaseIpo +'Handlers/GetRegistration2.ashx';

    // var url3 = ' http://localhost:21936/home/GetAgent';

    $(document).ready(function () {
        var xname = $("input#xname").val();

        $scope.xname4 = $("input#xname").val();
        $scope.xname5 = $("input#vamount").val();
        $scope.xname6 = $("input#vtranid").val();
        $scope.xname6a = $("input#vtype").val();


        var Encrypt = {
            vv: xname
        }
        var formData = new FormData();
        formData.append("vv", xname);
        $http({
            method: 'POST',
            url: serviceBaseCld +'Handlers/GetApplicantAddress.ashx',
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
            var content = JSON.parse(response);
            //  alert(content)
            $scope.ApplicantAddress = content

            //  $scope.states = data;
        }).error(function (data, status, headers, config) {
            $scope.message = 'Unexpected Error';
        });



    });


    $scope.submitForm = function () {

        if ($scope.ApplicantAddress2 == null) {
            swal("Applicant Address Cannot Be Null", "error");

            return

        }


        swal({
            title: "UPDATE ADDRESS",
            text: "CONTINUE WITH CHANGE OF APPLICANT ADDRESS",
            type: "success",
            showCancelButton: true,
            confirmButtonColor: "#DD6B55", confirmButtonText: "PROCEED!",
            cancelButtonText: "No!",
            closeOnConfirm: true,
            closeOnCancel: true
        },
function (isConfirm) {
    if (isConfirm) {

        var Encrypt = {
            vv: $scope.ApplicantAddress,
            vv2: $scope.ApplicantAddress2,
            vv3: $scope.xname4,
            vv4: $scope.xname5,
            vv5: $scope.xname6,
            vv6: $scope.description

        }

        $http({
            method: 'POST',
            url: serviceBaseCld +'Handlers/UpdateApplicant2.ashx',
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

          //  var content = JSON.parse(response);
            if ($scope.xname6a == "backend") {
                window.location.href = serviceBaseCld +"admin/tm/Generic_registrar_data_details4bb.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + response.TransactionId + "&&Recordalid=" + response.Recordal_Id;

            }

            else {
                window.location.href = serviceBaseCld +"admin/tm/Generic_registrar_data_details4b.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + response.TransactionId + "&&Recordalid=" + response.Recordal_Id;

            }
            //     
        }).error(function (data, status, headers, config) {
            $scope.message = 'Unexpected Error';
        });



    } else {
        swal("Cancelled", "Action Canceled :)", "error");
    }
});




    }
    //When you have entire dataset



}]);


app.controller('myController3', ['$scope', '$http', '$rootScope', function ($scope, $http, $rootScope) {

    $scope.BranchCollect = [];
    $scope.itemsPerPage = 10;
    $scope.currentPage = 0;
    $scope.items = [];
    $scope.isDisabled = false;
    var url3 = serviceBaseIpo +'Handlers/GetRegistration2.ashx';

    // var url3 = ' http://localhost:21936/home/GetAgent';

    $(document).ready(function () {
        var xname = $("input#xname").val();
        var xname2 = $("input#xname2").val();
        var xaddress = $("input#xaddress").val();
        var xemail = $("input#xemail").val();
        var xPhoneNumber = $("input#xPhoneNumber").val();
        var xpwalletID = $("input#xpwalletID").val();

        $scope.xname4 = $("input#xname").val();
        $scope.xname5 = $("input#vamount").val();
        $scope.xname6 = $("input#vtranid").val();

        $scope.Agent_Code2 = xpwalletID;

        $scope.Agent_Name2 = xname2;
        $scope.Address2 = xaddress;
        $scope.Mobile2 = xPhoneNumber;

        $scope.Email2 = xemail;


        var Encrypt = {
            vv: xname
        }
        var formData = new FormData();
        formData.append("vv", xname);
        $http({
            method: 'POST',
            url: serviceBaseCld +'Handlers/GetAgentInfo.ashx',
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
            $scope.Agent_Name = response.Agent_Name;
            $scope.Agent_Code = response.Agent_Code;
            $scope.Address = response.Address;
            $scope.Mobile = response.Mobile;
            $scope.Email = response.Email;

            //  $scope.states = data;
        }).error(function (data, status, headers, config) {
            $scope.message = 'Unexpected Error';
        });



    });
    $scope.checkAgent = function (name) {
        var Encryptz = {
            vv: name
        }
        var formData = new FormData();
        formData.append("vv", name);
        $http({
            method: 'POST',
            url: serviceBaseCld + 'Handlers/GetAgentInfo2.ashx',
            transformRequest: function (obj) {
                var str = [];
                for (var p in obj)
                    str.push(encodeURIComponent(p) + "=" + encodeURIComponent(obj[p]));
                return str.join("&");
            },
            data: Encryptz,

            //Convert the Observable Data into JSON

            headers: { 'Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8;' }
            //JSON.stringify({ vid: countryId })
        }).success(function (response) {
            var content = JSON.parse(response);
            if ((content == "empty")) {
                swal("", "No Agent information found", "error");
                $scope.Agent_Code2 = "";
                return;
            }
           // alert("name =" + response )
            
              //alert(content)
            $scope.Agent_Name2 = content;

            //  $scope.states = data;
        }).error(function (data, status, headers, config) {
            swal("", "No Agent information found", "error");
            $scope.Agent_Code2 = "";
        });
    }

    $scope.submitForm = function () {
        var formData = new FormData();
        if ($scope.Agent_Name2 == null) {
            swal("Agent Name  Cannot Be Null", "error");

            return

        }

        if ($scope.Agent_Code2 == null) {
            swal("Agent Code   Cannot Be Null", "error");

            return

        }


        if ($scope.Address2 == null) {
            swal("Agent Address    Cannot Be Null", "error");

            return

        }
        

        if ($scope.Mobile2 == null) {
            swal("Agent Telephone Number    Cannot Be Null", "error");

            return

        }

        if ($scope.Email2 == null) {
            swal("Agent Email    Cannot Be Null", "error");

            return

        }

        swal({
            title: "UPDATE AGENT",
            text: "CONTINUE WITH CHANGE OF APPLICANT AGENT INFO",
            type: "success",
            showCancelButton: true,
            confirmButtonColor: "#DD6B55", confirmButtonText: "PROCEED!",
            cancelButtonText: "No!",
            closeOnConfirm: true,
            closeOnCancel: true
        },
function (isConfirm) {
    if (isConfirm) {

        var Encrypt = {
            vv: $scope.Agent_Name,
            vv2: $scope.Agent_Name2,
            vv3: $scope.xname4,
            vv4: $scope.xname5,
            vv5: $scope.xname6,
            ff: $scope.Agent_Code,
            ff2: $scope.Agent_Code2,
            ff3: $scope.Address,
            ff4: $scope.Address2,
            ff5: $scope.Mobile,
            ff6: $scope.Mobile2,
            ff7: $scope.Email,
            ff8: $scope.Email2

        }
        formData.append("vv", JSON.stringify(Encrypt));

        var totalFiles = document.getElementById("File1").files.length;

        for (var i = 0; i < totalFiles; i++) {
            var file = document.getElementById("File1").files[i];



            formData.append("FileUpload", file);
        }
        $http.post(serviceBaseCld + 'Handlers/UpdateAgent.ashx', formData, {
            transformRequest: angular.identity,
            headers: { 'Content-Type': undefined }
        }).success(function (response) {

           // var content = JSON.parse(response);
            if (response.TransactionId != "") {
                window.location = serviceBaseCld + "admin/tm/Generic_registrar_data_details6b.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + response.TransactionId + "&&Recordalid=" + response.Recordal_Id;
            } else {
                $scope.message = 'Unexpected Error';
                window.alert($scope.message);
            }
            }).error(function (data, status, headers, config) {
            $scope.message = 'Unexpected Error';
            alert($scope.message);
        });



    } else {
        swal("Cancelled", "Action Canceled :)", "error");
    }
});




    }
    //When you have entire dataset



}]);


app.controller('myController4', ['$scope', '$http', '$rootScope', function ($scope, $http, $rootScope) {

    $scope.BranchCollect = [];
    $scope.itemsPerPage = 10;
    $scope.currentPage = 0;
    $scope.items = [];
    $scope.isDisabled = false;
    $scope.upload = false;
    $scope.classtrademark = [{ name: 'DEVICE', id: '1' }, { name: 'WORD MARK', id: '2' }, { name: 'WORD AND DEVICE', id: '3' }]
    var url3 = serviceBaseIpo +'Handlers/GetRegistration2.ashx';

    // var url3 = ' http://localhost:21936/home/GetAgent';

    $scope.GetStates12 = function () {
        if ($scope.Logo == "2") {

            $scope.upload = false;
        }
        else {
            $scope.upload = true;
        }
    }

    $(document).ready(function () {
        var xname = $("input#xname").val();

        $scope.xname4 = $("input#xname").val();
        $scope.xname5 = $("input#vamount").val();
        $scope.xname6 = $("input#vtranid").val();
        $scope.xname6a = $("input#vtype").val();


        var Encrypt = {
            vv: xname
        }
        var formData = new FormData();
        formData.append("vv", xname);
        $http({
            method: 'POST',
            url: serviceBaseCld +'Handlers/GetApplicantRectify.ashx',
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
            $scope.old_title = response.product_title;
            $scope.img_url = serviceBaseCld +"Admin/Tm/" + response.logo_pic;
            $scope.img_url2 = response.logo_pic;

            //  $scope.states = data;
        }).error(function (data, status, headers, config) {
            $scope.message = 'Unexpected Error';
        });



    });


    $scope.submitForm = function () {

        var formData = new FormData();
        if ($scope.new_title == null) {
            swal("Trademark Title  Cannot Be Null", "error");

            return

        }
        if ($scope.Logo == null) {
            swal("You Must Select Logo Desc", "error");

            return

        }
       

        var totalFiles = document.getElementById("newlogo").files.length;
        if (totalFiles == 0 && $scope.Logo !="2") {
            alert("Upload File")
            //  self.cac("");

            return;

        }

        for (var i = 0; i < totalFiles; i++) {
            var file = document.getElementById("newlogo").files[i];



            formData.append("FileUpload", file);
        }


        swal({
            title: "UPDATE DATA",
            text: "CONTINUE WITH AMENDMENT (CLERICAL ERRORS IN TRADEMARK TITLE)",
            type: "success",
            showCancelButton: true,
            confirmButtonColor: "#DD6B55", confirmButtonText: "PROCEED!",
            cancelButtonText: "No!",
            closeOnConfirm: true,
            closeOnCancel: true
        },
function (isConfirm) {
    if (isConfirm) {

        var Encrypt = {
            vv: $scope.old_title,
            vv2: $scope.new_title,
            vv3: $scope.xname4,
            vv4: $scope.xname5,
            vv5: $scope.xname6,
            vv6: $scope.img_url2,
            vv7: $scope.Logo,
            vv8: $scope.description

        }

        formData.append("vv",JSON.stringify(Encrypt));





        $http.post(serviceBaseCld +'Handlers/UpdateApplicant4.ashx', formData, {
            transformRequest: angular.identity,
            headers: { 'Content-Type': undefined }
        })
                           .success(function (response) {


                           //    var content = JSON.parse(response);

                               if ($scope.xname6a == "backend") {

                                   window.location.href = serviceBaseCld +"admin/tm/Generic_registrar_data_details4cc.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + response.TransactionId + "&&Recordalid=" + response.Recordal_Id;
                               }
                               else {

                                   window.location.href = serviceBaseCld +"admin/tm/Generic_registrar_data_details4c.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + response.TransactionId + "&&Recordalid=" + response.Recordal_Id;
                               }
                           })
                           .error(function () {

                           });




    } else {
        swal("Cancelled", "Action Canceled :)", "error");
    }
});




    }
    //When you have entire dataset



}]);


app.controller('myController5', ['$scope', '$http', '$rootScope', function ($scope, $http, $rootScope) {

    $scope.BranchCollect = [];
    $scope.itemsPerPage = 10;
    $scope.currentPage = 0;
    $scope.items = [];
    $scope.isDisabled = false;
    var url3 = serviceBaseIpo +'Handlers/GetRegistration2.ashx';

    // var url3 = ' http://localhost:21936/home/GetAgent';

    $(document).ready(function () {
        var xname = $("input#xname").val();

        $scope.xname = $("input#xname").val();
        $scope.xname5 = $("input#vamount").val();
        $scope.xname6 = $("input#vtranid").val();
        $scope.xname6a = $("input#vtype").val();
      


        var Encrypt = {
            vv: xname
        }
        var formData = new FormData();
        formData.append("vv", xname);
        $http({
            method: 'POST',
            url: serviceBaseCld +'Handlers/GetApplicantName2.ashx',
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
            $scope.ApplicantName = response.new_applicantname;

            $scope.OldApplicantName = response.old_applicantname;

            $scope.log_staff = response.log_staff;


            //  $scope.states = data;
        }).error(function (data, status, headers, config) {
            $scope.message = 'Unexpected Error';
        });



    });


    $scope.submitForm = function () {

        if ($scope.ApplicantName == null) {
            swal("Applicant Name Cannot Be Null", "error");

            return

        }

        if ($scope.OldApplicantName == null) {
            swal("Applicant Name Cannot Be Null", "error");

            return

        }


        swal({
            title: "",
            text: "CONTINUE WITH UPDATE OF APPLICANT NAME",
            type: "success",
            showCancelButton: true,
            confirmButtonColor: "#DD6B55", confirmButtonText: "PROCEED!",
            cancelButtonText: "No!",
            closeOnConfirm: true,
            closeOnCancel: true
        },
function (isConfirm) {
    if (isConfirm) {

        var Encrypt = {
            vv: $scope.xname,
            vv2: $scope.OldApplicantName,
            vv3:$scope.ApplicantName  ,
            vv4: $scope.log_staff

        }

        $http({
            method: 'POST',
            url: serviceBaseCld +'Handlers/UpdateApplicantName.ashx',
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

            swal("", "Record Update Successfully", "success");
            //  var content = JSON.parse(response);
         
            //     
        }).error(function (data, status, headers, config) {
            $scope.message = 'Unexpected Error';
        });



    } else {
        swal("Cancelled", "Action Canceled :)", "error");
    }
});




    }
    //When you have entire dataset



}]);


app.controller('myController6', ['$scope', '$http', '$rootScope', function ($scope, $http, $rootScope) {

    $scope.BranchCollect = [];
    $scope.itemsPerPage = 10;
    $scope.currentPage = 0;
    $scope.items = [];
    $scope.isDisabled = false;
    var url3 = serviceBaseIpo +'Handlers/GetRegistration2.ashx';

    // var url3 = ' http://localhost:21936/home/GetAgent';

    $(document).ready(function () {
        var xname = $("input#xname").val();

        $scope.xname = $("input#xname").val();
        $scope.xname5 = $("input#vamount").val();
        $scope.xname6 = $("input#vtranid").val();
        $scope.xname6a = $("input#vtype").val();



        var Encrypt = {
            vv: xname
        }
        var formData = new FormData();
        formData.append("vv", xname);
        $http({
            method: 'POST',
            url: serviceBaseCld +'Handlers/GetApplicantAddress3.ashx',
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
            $scope.ApplicantAddress = response.new_applicantname;

            $scope.OldApplicantAddress = response.old_applicantname;

            $scope.log_staff = response.log_staff;


            //  $scope.states = data;
        }).error(function (data, status, headers, config) {
            $scope.message = 'Unexpected Error';
        });



    });


    $scope.submitForm = function () {

        if ($scope.ApplicantAddress == null) {
            swal("Applicant Address Cannot Be Null", "error");

            return

        }

        if ($scope.OldApplicantAddress == null) {
            swal("Applicant Address Cannot Be Null", "error");

            return

        }


        swal({
            title: "",
            text: "CONTINUE WITH UPDATE OF APPLICANT ADDRESS",
            type: "success",
            showCancelButton: true,
            confirmButtonColor: "#DD6B55", confirmButtonText: "PROCEED!",
            cancelButtonText: "No!",
            closeOnConfirm: true,
            closeOnCancel: true
        },
function (isConfirm) {
    if (isConfirm) {

        var Encrypt = {
            vv: $scope.xname,
            vv2: $scope.OldApplicantAddress,
            vv3: $scope.ApplicantAddress,
            vv4: $scope.log_staff

        }

        $http({
            method: 'POST',
            url: serviceBaseCld +'Handlers/UpdateApplicantAddress.ashx',
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

            swal("", "Record Update Successfully", "success");
            //  var content = JSON.parse(response);

            //     
        }).error(function (data, status, headers, config) {
            $scope.message = 'Unexpected Error';
        });



    } else {
        swal("Cancelled", "Action Canceled :)", "error");
    }
});




    }
    //When you have entire dataset



}]);

app.controller('myController7', ['$scope', '$http', '$rootScope', function ($scope, $http, $rootScope) {

    $scope.BranchCollect = [];
    $scope.itemsPerPage = 10;
    $scope.currentPage = 0;
    $scope.items = [];
    $scope.isDisabled = false;
    var url3 = serviceBaseIpo + 'Handlers/GetRegistration2.ashx';

    // var url3 = ' http://localhost:21936/home/GetAgent';

    $(document).ready(function () {
        var xname = $("input#xname").val();


        $scope.xname4 = $("input#xname").val();
        $scope.xname5 = $("input#vamount").val();
        $scope.xname6 = $("input#vtranid").val();
        $scope.xname6a = $("input#vtype").val();



        var Encrypt = {
            vv: xname
        }
        var formData = new FormData();
        formData.append("vv", xname);
        $http({
            method: 'POST',
            url: serviceBaseCld + 'Handlers/GetApplicantName3.ashx',
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
          //  var content = JSON.parse(response);
           
            $scope.ApplicantName = response.Applicant_Name;

            $scope.ApplicantName4 = response.Applicant_Address;

            //  $scope.states = data;
        }).error(function (data, status, headers, config) {
            $scope.message = 'Unexpected Error';
        });



    });


    $scope.submitForm = function () {

        if ($scope.ApplicantName2 == null) {
            swal("Grantee Name Cannot Be Null", "error");

            return

        }


        if ($scope.ApplicantName3 == null) {
            swal("Grantee  Address Cannot Be Null", "error");

            return

        }


        swal({
            title: "UPDATE NAME",
            text: "CONTINUE WITH CHANGE OF REGISTERED USER",
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
            vv2: $scope.ApplicantName2,
            vv3: $scope.xname4,
            vv4: $scope.xname5,
            vv5: $scope.xname6,
            vv6: $scope.description,
            vv7: $scope.ApplicantName3,
            vv8: $scope.ApplicantName4

        }

        formData.append("vv", JSON.stringify(Encrypt));

        var totalFiles = document.getElementById("File1").files.length;

        for (var i = 0; i < totalFiles; i++) {
            var file = document.getElementById("File1").files[i];



            formData.append("FileUpload", file);
        }


        var totalFiles = document.getElementById("File2").files.length;

        for (var i = 0; i < totalFiles; i++) {
            var file = document.getElementById("File2").files[i];



            formData.append("FileUpload2", file);
        }

        var totalFiles = document.getElementById("File3").files.length;

        for (var i = 0; i < totalFiles; i++) {
            var file = document.getElementById("File3").files[i];



            formData.append("FileUpload3", file);
        }

        $http.post(serviceBaseCld + 'Handlers/UpdateApplicant3.ashx', formData, {
            transformRequest: angular.identity,
            headers: { 'Content-Type': undefined }
        }).success(function (response) {

            if ($scope.xname6a == "backend") {
                window.location.href = serviceBaseCld + "admin/tm/Generic_registrar_data_details4bb.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + response.TransactionId + "&&Recordalid=" + response.Recordal_Id;

            }

            else {

                window.location.href = serviceBaseCld + "admin/tm/Generic_registrar_data_details4b.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + response.TransactionId;

            }
            // var content = JSON.parse(response);

        }).error(function (data, status, headers, config) {
            $scope.message = 'Unexpected Error';
            console.log(data)
            alert($scope.message);
        });

        //$http({
        //    method: 'POST',
        //    url: serviceBaseCld + 'Handlers/UpdateApplicant3.ashx',
        //    transformRequest: function (obj) {
        //        var str = [];
        //        for (var p in obj)
        //            str.push(encodeURIComponent(p) + "=" + encodeURIComponent(obj[p]));
        //        return str.join("&");
        //    },
        //    data: Encrypt,

         

        //    headers: { 'Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8;' }
          
        //}).success(function (response) {

          
        //    if ($scope.xname6a == "backend") {
        //        window.location.href = serviceBaseCld + "admin/tm/Generic_registrar_data_details4bb.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + response.TransactionId + "&&Recordalid=" + response.Recordal_Id;

        //    }

        //    else {

        //        window.location.href = serviceBaseCld + "admin/tm/Generic_registrar_data_details4b.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + response.TransactionId;

        //    }
           
        //}).error(function (data, status, headers, config) {
        //    $scope.message = 'Unexpected Error';
        //});



    } else {
        swal("Cancelled", "Action Canceled :)", "error");
    }
});




    }
    //When you have entire dataset



}]);










