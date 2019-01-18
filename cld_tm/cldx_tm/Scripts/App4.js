var app = angular.module('formApp', ['ngAnimate', 'ui.router', 'angular-loading-bar', 'ngSanitize', 'smart-table']);

var serviceBaseIpo = 'http://88.150.164.30/EinaoTestEnvironment.IPO/';

var serviceBaseCld = 'http://45.40.139.163/EinaoTestEnvironment.CLD/'
// configuring our routes 
// =============================================================================
app.config(function ($stateProvider, $urlRouterProvider) {

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
        .state('form.inbox', {
            url: '/inbox',
            templateUrl: 'Change_Name_Detail.html',
            controller: 'formController'
        })

         .state('form.outbox', {
             url: '/outbox',
             templateUrl: 'Change_Name_Detail3.html',
             controller: 'formController2'
         })

        // url will be /form/interests
        .state('form.detail', {
            url: '/detail',
            templateUrl: 'Change_Name_Detail2.html',
            controller: 'formController'
        })


     .state('form.detail2', {
         url: '/detail2',
         templateUrl: 'Change_Name_Detail2b.html',
         controller: 'formController'
     })



    // url will be /form/payment
       

    // catch all route
    // send users to the form page 
    $urlRouterProvider.otherwise('/form/inbox');
});

// our controller for the form
// =============================================================================
app.controller('formController', function ($scope, $state, $rootScope, $http, $stateParams, $location) {

    var serviceBase =serviceBaseCld +  'Handlers/Getupload_Email.ashx';
    //  var serviceBase = 'http://localhost:55482/Handlers/Getupload_Email.ashx';
    $(document).ready(function () {

     

        $http({
            method: 'POST',
            url: serviceBase,
            transformRequest: function (obj) {
                var str = [];
                for (var p in obj)
                    str.push(encodeURIComponent(p) + "=" + encodeURIComponent(obj[p]));
                return str.join("&");
            },
            //data: Encrypt,
            headers: { 'Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8;' }
        })
            .success(function (response) {
                var dd = [];

                dd = response;

                $scope.itemsByPage = 50;
                $scope.ListAgent = response;
                $scope.displayedCollection = [].concat($scope.ListAgent);

              

                //  IpoTradeMarks2(response.Email, response.Firstname, response.CompanyAddress, response.xid, response.PhoneNumber)
                //  ajaxindicatorstop();

            })
            .error(function (response) {
                //  ajaxindicatorstop();
            });


        //   alert(xname)

    });

    // alert($location.search().name)
  
    $scope.Payment_Reference = "";
    // we will store all of our form data in this object
    $scope.formData = {};

    //  $scope.formData.vname = $location.search().name;



    $scope.add2 = function (vrow) {
        var serviceBase2 = serviceBaseCld + 'Handlers/GetEmail2.ashx';

        var Encrypt = {
            vid: vrow.id
        }


        $http({
            method: 'POST',
            url: serviceBase2,
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
              var vurl = "";
              dd = response;

              if (dd.Data_Status == "New") {
                  vurl = serviceBaseCld +  "admin/tm/g_Recordal.aspx?param=" + dd.Online_Id;

              }

              else if (dd.Data_Status == "Kiv" && dd.Status2 == "14") {

                  vurl = serviceBaseCld + "admin/tm/verify_data_details2.aspx?x=" + dd.pt_id;
              }

              else if (dd.Data_Status == "kiv" && dd.Status2 == "5") {

                  vurl = serviceBaseCld + "admin/tm/acceptance_kiv_details.aspx?x=" + dd.pt_id;
              }
              else if (dd.Data_Status == "S_Contact") {

                  vurl = serviceBaseCld + "admin/pt/search_unit/s_contact_details.aspx?x=" + dd.pt_id;
              }

              else if (dd.Data_Status == "Valid") {

                  vurl = "http://88.150.164.30/EinaoTestEnvironment.Patent/admin/pt/search_unit/search_details.aspx?x=" + dd.pt_id;
              }

              else if (dd.Data_Status == "Further Search") {

                  vurl = "http://88.150.164.30/EinaoTestEnvironment.Patent/admin/pt/search_unit/search_r_details.aspx?x=" + dd.pt_id;
              }

              else if (dd.Data_Status == "E_Contact") {

                  vurl = "http://88.150.164.30/EinaoTestEnvironment.Patent/admin/pt/examiners_unit/examination_details.aspx?x=" + dd.pt_id;
              }

              else if (dd.Data_Status == "Search Conducted") {

                  vurl = "http://88.150.164.30/EinaoTestEnvironment.Patent/admin/pt/examiners_unit/examination_details.aspx?x=" + dd.pt_id;
              }

              else if (dd.Data_Status == "Not-Patentable") {

                  vurl = "http://88.150.164.30/EinaoTestEnvironment.Patent/admin/pt/examiners_unit/examination_r_details.aspx?x=" + dd.pt_id;
              }

              else if (dd.Data_Status == "Grant Patent") {

                  vurl = "http://88.150.164.30/EinaoTestEnvironment.Patent/admin/pt/examiners_unit/acceptance_slip_details.aspx?x=" + dd.pt_id;
              }
             
              var vtarget ="blank";
              dd.Message = dd.Message + "<br/>  <a target='" + vtarget + "'  href='" + vurl + "'  >click link to view  </a> "

              $rootScope.Message2 = dd.Message ;

              $scope.itemsByPage = 10;
              $scope.ListAgent2 = dd;
              $scope.displayedCollection2 = [].concat($scope.ListAgent2);



              //  IpoTradeMarks2(response.Email, response.Firstname, response.CompanyAddress, response.xid, response.PhoneNumber)
              //  ajaxindicatorstop();

          })
          .error(function (response) {
              //   ajaxindicatorstop();
          });

        // $rootScope.xid = vrow.xid
        $state.go('form.detail')
    }

    $scope.add3 = function (vrow) {

        window.history.back();
        location.reload();
    }


    $scope.add5 = function (vrow) {

        if (vrow.Status) {

            return false
        }
        else {

            return true;
        }

      
    }


  

 

});

app.controller('formController2', function ($scope, $state, $rootScope, $http, $stateParams, $location) {

    var serviceBase = serviceBaseCld +  'Handlers/GetOutbox_Email.ashx';
    $(document).ready(function () {



        $http({
            method: 'POST',
            url: serviceBase,
            transformRequest: function (obj) {
                var str = [];
                for (var p in obj)
                    str.push(encodeURIComponent(p) + "=" + encodeURIComponent(obj[p]));
                return str.join("&");
            },
            //data: Encrypt,
            headers: { 'Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8;' }
        })
            .success(function (response) {
                var dd = [];

                dd = response;

                $scope.itemsByPage = 50;
                $scope.ListAgent3 = response;
                $scope.displayedCollection3 = [].concat($scope.ListAgent3);



                //  IpoTradeMarks2(response.Email, response.Firstname, response.CompanyAddress, response.xid, response.PhoneNumber)
                //  ajaxindicatorstop();

            })
            .error(function (response) {
                var tx = response;
                //  ajaxindicatorstop();
            });


        //   alert(xname)

    });

    // alert($location.search().name)

    $scope.Payment_Reference = "";
    // we will store all of our form data in this object
    $scope.formData = {};

    //  $scope.formData.vname = $location.search().name;



    $scope.add2 = function (vrow) {
        var serviceBase2 = serviceBaseCld + 'Handlers/GetEmail3.ashx';

        var Encrypt = {
            vid: vrow.id
        }


        $http({
            method: 'POST',
            url: serviceBase2,
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
              var vurl = "";
              dd = response;


             // var vtarget = "blank";
              $rootScope.Message = dd.Message;
              $scope.itemsByPage = 10;
              $scope.ListAgent5 = dd;
              $scope.displayedCollection5 = [].concat($scope.ListAgent5);



              //  IpoTradeMarks2(response.Email, response.Firstname, response.CompanyAddress, response.xid, response.PhoneNumber)
              //  ajaxindicatorstop();

          })
          .error(function (response) {

              var tx = response;
              //   ajaxindicatorstop();
          });

        // $rootScope.xid = vrow.xid
        $state.go('form.detail2')
    }

    $scope.add3 = function (vrow) {

        window.history.back();
        location.reload();
    }


    $scope.add5 = function (vrow) {

        if (vrow.Status) {

            return false
        }
        else {

            return true;
        }


    }






});



