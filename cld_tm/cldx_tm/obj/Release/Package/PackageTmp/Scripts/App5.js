angular.module('formApp', ['ngAnimate', 'ui.router', 'angular-loading-bar'])
var serviceBaseIpo = 'http://88.150.164.30/EinaoTestEnvironment.IPO/';

var serviceBaseCld = 'http://45.40.139.163/EinaoTestEnvironment.CLD/'
// configuring our routes 
// =============================================================================
.config(function ($stateProvider, $urlRouterProvider) {

    $stateProvider

        // route to show our basic form (/form)
        .state('form', {
            url: '/form',
            templateUrl: 'form.html',
            controller: 'formController'
        })

        // nested states 
        // each of these sections will have their own view
        // url will be nested (/form/profile)
        .state('form.payment', {
            url: '/payment',
            templateUrl: 'Change_Name_Detail.html'
        })

        // url will be /form/interests
        .state('form.transaction', {
            url: '/transaction',
            templateUrl: 'Change_Name_Detail2.html'
        })

    // url will be /form/payment


    // catch all route
    // send users to the form page 
    $urlRouterProvider.otherwise('/form/payment');
})

// our controller for the form
// =============================================================================
.controller('formController', function ($scope, $state, $rootScope, $http, $stateParams, $location) {

    // alert($location.search().name)

    $scope.Payment_Reference = "";
    // we will store all of our form data in this object
    $scope.formData = {};

    $scope.formData.vname = $location.search().name;

    $scope.add2 = function (vrow) {

        $rootScope.xid = vrow.xid
        $state.go('form.transaction')
    }

    $scope.add = function () {

        //   $state.go('form.transaction')

        var Encrypt = {
            vv: $scope.formData.Payment_Reference
        }

        $http({
            method: 'POST',
            url:serviceBaseCld +  'Handlers/GetPwallet.ashx',
            // url: 'http://localhost:49703/Handlers/GetPaymentExist.ashx',
            transformRequest: function (obj) {
                var str = [];
                for (var p in obj)
                    str.push(encodeURIComponent(p) + "=" + encodeURIComponent(obj[p]));
                return str.join("&");
            },
            data: Encrypt,

            headers: { 'Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8;' }

        }).success(function (response) {

          //  var dd2 = parseInt(response);

            var dd = response

           

            //  $scope.states = data;
        }).error(function (data, status, headers, config) {
            $scope.message = 'Unexpected Error';
        });




    }





    $scope.add3 = function () {
        var vk = $scope.formData.OnlineNumber;


        var serviceBase = serviceBaseCld + 'Handlers/GetCertificate.ashx';

        //  var serviceBase = 'http://localhost:49703/Handlers/GetCertificate.ashx';


        var Encrypt = {
            vid: vk
        }

        $http({
            method: 'POST',
            url: serviceBase,
            transformRequest: function (obj) {
                var str = [];
                for (var p in obj)
                    str.push(encodeURIComponent(p) + "=" + encodeURIComponent(obj[p]));
                return str.join("&");
            },
            data: Encrypt,
            headers: { 'Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8;' }
        })
            .success(function (response) {
                var dd = [];

                dd = response;

                //  alert("result=" + response)

                //if (dd.length > 0 && dd[0].TransactionId != "") {


                //    swal("Oops...", "This Certificate  Has Been Paid For", "error");
                //    return;
                //}
                //alert("length =" + dd.length)
                if (dd.length > 0) {

                    $scope.itemsByPage = 50;
                    $scope.ListAgent = response;
                    $scope.displayedCollection2 = [].concat($scope.ListAgent);

                    $scope.formData.Id = response[0].id



                }

                else {

                    swal("Oops...", "Invalid Online Number!", "error");

                    $scope.displayedCollection2 = [];
                    $scope.ListAgent = [];
                }
                //  IpoTradeMarks2(response.Email, response.Firstname, response.CompanyAddress, response.xid, response.PhoneNumber)
                //  ajaxindicatorstop();

            })
            .error(function (response) {
                ajaxindicatorstop();
            });

    }

    $scope.add4 = function (d) {



        var serviceBase = serviceBaseCld +  'Handlers/UpdatePayment.ashx';

        //   var serviceBase = 'http://localhost:49703/Handlers/GetCertificate.ashx';

        //var dd = checkPopup();

        //alert(dd)

        //var Encrypt = {
        //    vid: $scope.formData.Payment_Reference
        //}





        //if ($scope.formData.vname == "Renewal") {


        //    var kk = checkPopup("http://88.150.164.30/EinaoTestEnvironment.CLD/admin/tm/Change_Renewal.aspx")

        //    if (kk == "false") {

        //        swal("Pop Is Enabled For This Browser ,Kindly Disable To Continue")

        //        return false;
        //    }






        //}

        if ($scope.formData.BranchCollect) {

            if ($scope.formData.vname == "Change_Name") {
                doUrlPost( serviceBaseCld + "admin/tm/Change_ApplicantName.aspx", $scope.formData.Id, $scope.formData.tot_amt, $scope.formData.Payment_Reference, $rootScope.xid)

                // doUrlPost("http://localhost:49703/admin/tm/Change_ApplicantName.aspx", $scope.formData.Id, $scope.formData.tot_amt, $scope.formData.Payment_Reference, $rootScope.xid)

            }

            if ($scope.formData.vname == "Change_Address") {
                doUrlPost(serviceBaseCld + "admin/tm/Change_ApplicantAddress.aspx", $scope.formData.Id, $scope.formData.tot_amt, $scope.formData.Payment_Reference, $rootScope.xid)
            }

            if ($scope.formData.vname == "Rectification") {
                doUrlPost(serviceBaseCld + "admin/tm/Change_Rectification.aspx", $scope.formData.Id, $scope.formData.tot_amt, $scope.formData.Payment_Reference, $rootScope.xid)
            }

            if ($scope.formData.vname == "Form16") {
                doUrlPost(serviceBaseCld + "admin/tm/Change_Assignment2.aspx", $scope.formData.Id, $scope.formData.tot_amt, $scope.formData.Payment_Reference, $rootScope.xid)
            }

            if ($scope.formData.vname == "Form17") {
                doUrlPost(serviceBaseCld + "admin/tm/Change_Assignment3.aspx", $scope.formData.Id, $scope.formData.tot_amt, $scope.formData.Payment_Reference, $rootScope.xid)
            }

            if ($scope.formData.vname == "Renewal") {
                doUrlPost(serviceBaseCld + "admin/tm/Change_Renewal.aspx", $scope.formData.Id, $scope.formData.tot_amt, $scope.formData.Payment_Reference, $rootScope.xid)
            }
            $scope.formData = {};
            $scope.displayedCollection2 = [];
            $scope.displayedCollection = [];


        }

        else {

            var Encrypt = {
                vid: $rootScope.xid
            }

            $http({
                method: 'POST',
                url: serviceBase,
                transformRequest: function (obj) {
                    var str = [];
                    for (var p in obj)
                        str.push(encodeURIComponent(p) + "=" + encodeURIComponent(obj[p]));
                    return str.join("&");
                },
                data: Encrypt,
                headers: { 'Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8;' }
            })
                .success(function (response) {
                    if ($scope.formData.vname == "Change_Name") {
                        doUrlPost(serviceBaseCld + "admin/tm/Change_ApplicantName.aspx", $scope.formData.Id, $scope.formData.tot_amt, $scope.formData.Payment_Reference, $rootScope.xid)

                        // doUrlPost("http://localhost:49703/admin/tm/Change_ApplicantName.aspx", $scope.formData.Id, $scope.formData.tot_amt, $scope.formData.Payment_Reference, $rootScope.xid)

                    }

                    if ($scope.formData.vname == "Change_Address") {
                        doUrlPost(serviceBaseCld + "admin/tm/Change_ApplicantAddress.aspx", $scope.formData.Id, $scope.formData.tot_amt, $scope.formData.Payment_Reference, $rootScope.xid)
                    }

                    if ($scope.formData.vname == "Rectification") {
                        doUrlPost(serviceBaseCld + "admin/tm/Change_Rectification.aspx", $scope.formData.Id, $scope.formData.tot_amt, $scope.formData.Payment_Reference, $rootScope.xid)
                    }

                    if ($scope.formData.vname == "Form16") {
                        doUrlPost(serviceBaseCld + "admin/tm/Change_Assignment2.aspx", $scope.formData.Id, $scope.formData.tot_amt, $scope.formData.Payment_Reference, $rootScope.xid)
                    }

                    if ($scope.formData.vname == "Form17") {
                        doUrlPost(serviceBaseCld + "admin/tm/Change_Assignment3.aspx", $scope.formData.Id, $scope.formData.tot_amt, $scope.formData.Payment_Reference, $rootScope.xid)
                    }

                    if ($scope.formData.vname == "Renewal") {
                        doUrlPost(serviceBaseCld + "admin/tm/Change_Renewal.aspx", $scope.formData.Id, $scope.formData.tot_amt, $scope.formData.Payment_Reference, $rootScope.xid)
                    }
                    $scope.formData = {};
                    $scope.displayedCollection2 = [];
                    $scope.displayedCollection = [];
                })
                .error(function (response) {
                    ajaxindicatorstop();
                });

        }


    }
    // function to process the form
    $scope.processForm = function () {
        alert('awesome!');
    };


    function doUrlPost(x_url, transID, vamount, vtranid, vrootscope) {

        //var kc = checkPopup(x_url)

        //if (kc == "ss") {

        postwith(x_url, {
            transID: transID, vamount: vamount, vtranid: vtranid, vtype: "backend"
        });


        var serviceBase2 = 'http://88.150.164.30/EinaoTestEnvironment.CLD/Handlers/UpdatePayment2.ashx';

        //var Encrypt = {
        //    vid: vrootscope
        //}

        //$http({
        //    method: 'POST',
        //    url: serviceBase2,
        //    transformRequest: function (obj) {
        //        var str = [];
        //        for (var p in obj)
        //            str.push(encodeURIComponent(p) + "=" + encodeURIComponent(obj[p]));
        //        return str.join("&");
        //    },
        //    data: Encrypt,
        //    headers: { 'Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8;' }
        //})
        //    .success(function (response) {
        //        postwith(x_url, {
        //            transID: transID, vamount: vamount, vtranid: vtranid, vtype: "backend"
        //        });


        //    })
        //    .error(function (response) {

        //    });




        //}




        //else {


        // }
    }

});