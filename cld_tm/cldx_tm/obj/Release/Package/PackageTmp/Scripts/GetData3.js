var app = angular.module('myModule', ['smart-table', 'angular-loading-bar', 'ngModal', 'angularUtils.directives.dirPagination', '720kb.datepicker']);



var serviceBaseIpo = 'http://5.77.54.44/EinaoTestEnvironment.IPO/';

//var serviceBaseCld = 'http://localhost:49703/'

var serviceBaseCld = 'http://5.77.54.44/EinaoTestEnvironment.CLD/'


app.controller('myController6', ['$scope', '$http', '$rootScope', function ($scope, $http, $rootScope) {

    $scope.pageno = 1; // initialize page no to 1
    $scope.total_count = 0;
    $scope.itemsPerPage = 100;
    $scope.val1 = false;
    $scope.val2 = false;
    $scope.val3 = false;

    $scope.varray44 = [{ SearchCriteria: 'OAI NUMBER', SearchCriteria: 'OAI NUMBER' }, { SearchCriteria: 'FILE NUMBER', SearchCriteria: 'FILE NUMBER' }, { SearchCriteria: 'PRODUCT TITLE', SearchCriteria: 'PRODUCT TITLE' }, { SearchCriteria: 'APPLICANT NAME', SearchCriteria: 'APPLICANT NAME' }, { SearchCriteria: 'BY ACCEPTANCE DATE', SearchCriteria: 'BY ACCEPTANCE DATE' }]

    $scope.criteria = "";

    $scope.getdetails = function () {
       // alert($scope.criteria)
        if ($scope.criteria == "") {
            $scope.val2 = false;
            $scope.val3 = false;
            $scope.val1 = false;
        }
       else if ($scope.criteria == "BY ACCEPTANCE DATE") {
            $scope.val2 = true;
            $scope.val3 = true;
            $scope.val1 = false;
        }
        else {
            $scope.val2 = false;
            $scope.val3 = false;
            $scope.val1 = true;
        }
       

    }
    $scope.search = function () {
      
        $scope.getData($scope.pageno);

    }

    $scope.add2 = function (dd) {
        if (dd.acc_p == "1") {

            return true;
        }
        else {
            return false;
        }

    }

    $scope.getData = function (pageno) {
        var formData = new FormData();

        var AgentsData = {


            criteria: $scope.criteria,
            pageno: pageno,
            status: '5',
            datastatus: 'Accepted',
            valueentered: $scope.search_data,
            valueentered2: $scope.search_data2,
            valueentered3: $scope.search_data3



        };


        formData.append("vid3", JSON.stringify(AgentsData));




        $http.post(serviceBaseCld + 'Handlers/GetNewData10.ashx', formData, {

            transformRequest: angular.identity,
            headers: { 'Content-Type': undefined }
        })
        .success(function (response) {
            var dd = response;

            $scope.itemsByPage = 100;
            $scope.ListAgent2 = dd.data;



            $scope.total_count = dd.count;
            $scope.displayedCollection2 = [].concat($scope.ListAgent2);

        })
        .error(function (aa) {

            swal("error")
        });
    }

    $scope.getData($scope.pageno);

    //$http({
    //    method: 'GET',
    //  url: serviceBaseCld + 'Handlers/GetData28.ashx'
    //}).success(function (data, status, headers, config) {
    //    var dd = data;

    //    $scope.itemsByPage = 50;
    //    $scope.ListAgent = data;
    //    $scope.displayedCollection = [].concat($scope.ListAgent);
    //}).error(function (data, status, headers, config) {
    //    alert("error " + data)
    //    $scope.message = 'Unexpected Error';
    //});



}]);

app.controller('myController7', ['$scope', '$http', '$rootScope', function ($scope, $http, $rootScope) {

    $scope.pageno = 1; // initialize page no to 1
    $scope.total_count = 0;
    $scope.itemsPerPage = 100;
    $scope.varray44 = [{ SearchCriteria: 'OAI NUMBER', SearchCriteria: 'OAI NUMBER' }, { SearchCriteria: 'FILE NUMBER', SearchCriteria: 'FILE NUMBER' }, { SearchCriteria: 'PRODUCT TITLE', SearchCriteria: 'PRODUCT TITLE' }, { SearchCriteria: 'APPLICANT NAME', SearchCriteria: 'APPLICANT NAME' }]

    $scope.criteria = "";
    $scope.search = function () {
        $scope.getData($scope.pageno);

    }

    $scope.add2 = function (dd) {
        if (dd.acc_p == "1") {

            return true;
        }
        else {
            return false;
        }

    }

    $scope.getData = function (pageno) {
        var formData = new FormData();

        var AgentsData = {


            criteria: $scope.criteria,
            pageno: pageno,
            status: '5',
            datastatus: 'Accepted',
            valueentered: $scope.search_data



        };


        formData.append("vid3", JSON.stringify(AgentsData));




        $http.post(serviceBaseCld + 'Handlers/GetPrintedData.ashx', formData, {

            transformRequest: angular.identity,
            headers: { 'Content-Type': undefined }
        })
        .success(function (response) {
            var dd = response;

            $scope.itemsByPage = 100;
            $scope.ListAgent2 = dd.data;



            $scope.total_count = dd.count;
            $scope.displayedCollection2 = [].concat($scope.ListAgent2);

        })
        .error(function (aa) {

            swal("error")
        });
    }

    $scope.getData($scope.pageno);

    //$http({
    //    method: 'GET',
    //  url: serviceBaseCld + 'Handlers/GetData28.ashx'
    //}).success(function (data, status, headers, config) {
    //    var dd = data;

    //    $scope.itemsByPage = 50;
    //    $scope.ListAgent = data;
    //    $scope.displayedCollection = [].concat($scope.ListAgent);
    //}).error(function (data, status, headers, config) {
    //    alert("error " + data)
    //    $scope.message = 'Unexpected Error';
    //});



}]);






