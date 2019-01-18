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
        .state('form.search', {
            url: '/search',
            templateUrl: 'Search2.html'
        })

        // url will be /form/interests
        .state('form.transaction', {
            url: '/transaction',
            templateUrl: 'Transaction2.html'
        })

    // url will be /form/payment


    // catch all route
    // send users to the form page 
    $urlRouterProvider.otherwise('/form/search');
})

// our controller for the form
// =============================================================================
.controller('formController', function ($scope, $state, $rootScope, $http, $stateParams, $location) {
    $scope.Payment_Reference = "";
    // we will store all of our form data in this object
    $scope.formData = {};
    $scope.formData.vname = "text";

    // alert($location.search().name)
    $scope.newValue = function (value) {
        if ($scope.formData.Searchname == "rtm") {
           // $("#sticky1").html('Enter a valid Rtm No as displayed on your Certificate Of Registration.');
            $scope.formData.checked = true;
            $scope.formData.checked2 = false;
        }

        if ($scope.formData.Searchname == "file") {
           // $("#sticky1").html('Enter a valid File/Tp No as displayed on your Acknowledgement Form.');
            $scope.formData.checked = false;
            $scope.formData.checked2 = true;

        }

    }

    $scope.add = function (value) {

        var serviceBase = serviceBaseCld + 'Handlers/GetCertificate2.ashx';

        if ($scope.formData.Searchname == "rtm") {
            serviceBase = serviceBaseCld + 'Handlers/GetOnlineGeneric2.ashx';
        }

        else {
            serviceBase = serviceBaseCld + 'Handlers/GetOnlineGeneric.ashx';

           
        }

        var Encrypt = {
            vv: $scope.formData.OnlineNumber
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
        }).success(function (data, status, headers, config) {
            var dd = data;
            $scope.itemsByPage = 50;
            $scope.ListAgent = data;
            $scope.displayedCollection = [].concat($scope.ListAgent);
            $state.go('form.transaction')
        }).error(function (data, status, headers, config) {
            $scope.message = 'Unexpected Error';
        });
    }

    $scope.add2 = function (value) {

      
        var serviceBase = "http://88.150.164.30/MigrateGETest/";
            var data = {
                property1: value.oai_no
            };


            $http.get(serviceBase + 'api/values/GetMigration', { params: data }, { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } }).success(function (response) {

                //  alert("tony response ="+response);
                //  localStorageService.set('authorizationData', { token: response.access_token, userName: loginData.userName });
                var kk = response;

                var kk2 = JSON.parse(kk);
                // alert(response)


                swal({
                    title: "Record Migrated Successfully, You will receive an email notification once Record is verified by the Registry",
                    text: "",
                    type: "success",
                    showCancelButton: false,
                    confirmButtonColor: "#DD6B55", confirmButtonText: "OK!",
                    cancelButtonText: "No, cancel please!",
                    closeOnConfirm: true,
                    closeOnCancel: true
                },
    function (isConfirm) {
        if (isConfirm) {

          //  window.location.assign("profile.aspx");
            window.location.assign("registrar_ack2.aspx?0001234445=" + kk2 + "&94384238=" + value.application_no);


        }

    });

               

                //  deferred.resolve(response);

            }).error(function (err, status) {
               
                swal("Cancelled", err.Message, "error");
               
            });

       


    }
  
 

});



function checkPopup(t) {
    var openWin = window.open(" \'" + t + "\'", "directories=no,height=100,width=100,menubar=no,resizable=no,scrollbars=no,status=no,titlebar=no,top=0,location=no");

    var openWin = window.open("http://www.cnn.com", "directories=no,height=100,width=100,menubar=no,resizable=no,scrollbars=no,status=no,titlebar=no,top=0,location=no");

    popupBlockerChecker.check(openWin);
    // alert("Opening Page In New Window")


    if (!openWin) {
        return "ss"
        // alert("A popup blocker was detected. Please Remove popupblocker for this site");
    } else {



        return "tt"
        //  alert("No popup blocker dectected");
    }
    //if (!openWin) {
    //    return "false"
    //  //  alert("A popup blocker was detected. Please Remove popupblocker for this site");
    //} else {


    //    openWin.close();
    //    return "true"
    //  //  alert("No popup blocker dectected");
    //}
}

function postwith(to, p) {
    var myForm = document.createElement("form");
    myForm.method = "post";
    myForm.action = to;
    myForm.target = "_blank";


    for (var k in p) {
        var myInput = document.createElement("input");
        myInput.setAttribute("name", k);
        myInput.setAttribute("value", p[k]);
        myForm.appendChild(myInput);
    }
    document.body.appendChild(myForm);
    myForm.submit();

    document.body.removeChild(myForm);


}

var popupBlockerChecker = {
    check: function (popup_window) {
        var _scope = this;
        if (popup_window) {
            if (/chrome/.test(navigator.userAgent.toLowerCase())) {
                setTimeout(function () {
                    _scope._is_popup_blocked(_scope, popup_window);
                }, 200);
            } else {
                popup_window.onload = function () {
                    _scope._is_popup_blocked(_scope, popup_window);
                };
            }
        } else {
            _scope._displayError();
        }
    },
    _is_popup_blocked: function (scope, popup_window) {
        if ((popup_window.innerHeight > 0) == false) { scope._displayError(); }
    },
    _displayError: function () {
        alert("Popup Blocker is enabled! Please add this site to your exception list.");
    }
};
