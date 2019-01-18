var app = angular.module('myModule', ['smart-table', 'angular-loading-bar', 'ngModal']);

var serviceBaseIpo = 'http://ipo.cldng.com/';

//var serviceBaseCld = 'http://tm.cldng.com/';

//var serviceBaseIpo = 'http://ipo.cldng.com/';

var serviceBaseCld = 'http://tm.cldng.com/';



app.controller('myController9', ['$scope', '$http', '$rootScope', function ($scope, $http, $rootScope) {


    $scope.Export = function () {
        alasql('SELECT * INTO XLSX("trademark.xlsx",{headers:true}) FROM ?', [$scope.ListAgent]);
    };

    $scope.getters = {
        registrationDate: function (row) {
            return new Date(row.Approval_Date).getTime();
        }
    }


    $scope.scrollTo = function (id) {
        if (id.RECORDAL_TYPE == "Change_Address") {
            //  window.location.href = "http://88.150.164.30/EinaoTestEnvironment.CLD/admin/tm/Generic_registrar_data_details4c.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + id.oai_no
            window.open(
                         serviceBaseCld + "admin/tm/Generic_registrar_data_details4cc.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + id.oai_no + "&&Recordalid=" + id.RecordalID,
                         '_blank' // <- This is what makes it open in a new window.
                       );
        }

        if (id.RECORDAL_TYPE == "Change_Name") {
            //  window.location.href = "http://88.150.164.30/EinaoTestEnvironment.CLD/admin/tm/Generic_registrar_data_details4c.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + id.oai_no

            window.open(
             serviceBaseCld + "admin/tm/Generic_registrar_data_details4cc.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + id.oai_no + "&&Recordalid=" + id.RecordalID,
             '_blank' // <- This is what makes it open in a new window.
           );
        }

        if (id.RECORDAL_TYPE == "Change_Rectification") {

            //  window.location.href = "http://88.150.164.30/EinaoTestEnvironment.CLD/admin/tm/Generic_registrar_data_details4c.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + id.oai_no
            window.open(
            serviceBaseCld + "admin/tm/Generic_registrar_data_details4cc.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + id.oai_no + "&&Recordalid=" + id.RecordalID,
             '_blank' // <- This is what makes it open in a new window.
           );
        }


        if (id.RECORDAL_TYPE == "Change_Assignment") {

            //    window.location.href = "http://88.150.164.30/EinaoTestEnvironment.CLD/admin/tm/Generic_registrar_data_details4d.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + id.oai_no

            window.open(
             serviceBaseCld +"admin/tm/Generic_registrar_data_details4dd.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + id.oai_no + "&&Recordalid=" + id.RecordalID,
             '_blank' // <- This is what makes it open in a new window.
           );
        }


        if (id.RECORDAL_TYPE == "Change_Assignment2") {

            //    window.location.href = "http://88.150.164.30/EinaoTestEnvironment.CLD/admin/tm/Generic_registrar_data_details4d.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + id.oai_no

            window.open(
            serviceBaseCld +  "admin/tm/Generic_registrar_data_details4dd.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + id.oai_no + "&&Recordalid=" + id.RecordalID,
             '_blank' // <- This is what makes it open in a new window.
           );
        }


        if (id.RECORDAL_TYPE == "Change_Renewal") {

            //    window.location.href = "http://88.150.164.30/EinaoTestEnvironment.CLD/admin/tm/Generic_registrar_data_details4ee.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + id.oai_no

            window.open(
             serviceBaseCld + "admin/tm/Generic_registrar_data_details4ee.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + id.oai_no + "&&Recordalid=" + id.RecordalID,
             '_blank' // <- This is what makes it open in a new window.
           );
        }

        
        if (id.RECORDAL_TYPE == "Change_Agent") {

            //    window.location.href = "http://88.150.164.30/EinaoTestEnvironment.CLD/admin/tm/Generic_registrar_data_details4ee.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + id.oai_no

            window.open(
            serviceBaseCld + "admin/tm/Generic_registrar_data_details6bb.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + id.oai_no + "&&Recordalid=" + id.RecordalID,
             '_blank' // <- This is what makes it open in a new window.
           );
        }

        // $location.hash(id);
        // $anchorScroll();
    }



    $http({
        method: 'GET',
        // url: 'http://88.150.164.30/CLD/Handlers/GetData.ashx'
        url: serviceBaseCld +'Handlers/GetData9a.ashx'
    }).success(function (data, status, headers, config) {
        var dd = data;

        $scope.itemsByPage = 50;
        var dd2 = [];

   

        $scope.ListAgent = dd;
        $scope.displayedCollection = [].concat($scope.ListAgent);
    }).error(function (data, status, headers, config) {
        alert("error " + data)
        $scope.message = 'Unexpected Error';
    });

}]);

app.controller('myController9b', ['$scope', '$http', '$rootScope', function ($scope, $http, $rootScope) {


    $scope.Export = function () {
        alasql('SELECT * INTO XLSX("trademark.xlsx",{headers:true}) FROM ?', [$scope.ListAgent]);
    };

    $scope.getters = {
        registrationDate: function (row) {
            return new Date(row.Approval_Date).getTime();
        }
    }


    $scope.scrollTo = function (id) {
        if (id.RECORDAL_TYPE == "Change_Address") {
            //  window.location.href = "http://88.150.164.30/EinaoTestEnvironment.CLD/admin/tm/Generic_registrar_data_details4c.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + id.oai_no
            window.open(
                         serviceBaseCld + "admin/tm/Generic_registrar_data_details4cc.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + id.oai_no + "&&Recordalid=" + id.RecordalID,
                         '_blank' // <- This is what makes it open in a new window.
                       );
        }

        if (id.RECORDAL_TYPE == "Change_Name") {
            //  window.location.href = "http://88.150.164.30/EinaoTestEnvironment.CLD/admin/tm/Generic_registrar_data_details4c.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + id.oai_no

            window.open(
             serviceBaseCld + "admin/tm/Generic_registrar_data_details4cc.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + id.oai_no + "&&Recordalid=" + id.RecordalID,
             '_blank' // <- This is what makes it open in a new window.
           );
        }

        if (id.RECORDAL_TYPE == "Change_Rectification") {

            //  window.location.href = "http://88.150.164.30/EinaoTestEnvironment.CLD/admin/tm/Generic_registrar_data_details4c.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + id.oai_no
            window.open(
            serviceBaseCld + "admin/tm/Generic_registrar_data_details4cc.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + id.oai_no + "&&Recordalid=" + id.RecordalID,
             '_blank' // <- This is what makes it open in a new window.
           );
        }


        if (id.RECORDAL_TYPE == "Change_Assignment") {

            //    window.location.href = "http://88.150.164.30/EinaoTestEnvironment.CLD/admin/tm/Generic_registrar_data_details4d.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + id.oai_no

            window.open(
             serviceBaseCld + "admin/tm/Generic_registrar_data_details4dd.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + id.oai_no + "&&Recordalid=" + id.RecordalID,
             '_blank' // <- This is what makes it open in a new window.
           );
        }


        if (id.RECORDAL_TYPE == "Change_Assignment2") {

            //    window.location.href = "http://88.150.164.30/EinaoTestEnvironment.CLD/admin/tm/Generic_registrar_data_details4d.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + id.oai_no

            window.open(
            serviceBaseCld + "admin/tm/Generic_registrar_data_details4dd.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + id.oai_no + "&&Recordalid=" + id.RecordalID,
             '_blank' // <- This is what makes it open in a new window.
           );
        }


        if (id.RECORDAL_TYPE == "Change_Renewal") {

            //    window.location.href = "http://88.150.164.30/EinaoTestEnvironment.CLD/admin/tm/Generic_registrar_data_details4ee.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + id.oai_no

            window.open(
             serviceBaseCld + "admin/tm/Generic_registrar_data_details4ee.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + id.oai_no + "&&Recordalid=" + id.RecordalID,
             '_blank' // <- This is what makes it open in a new window.
           );
        }


        if (id.RECORDAL_TYPE == "Change_Agent") {

            //    window.location.href = "http://88.150.164.30/EinaoTestEnvironment.CLD/admin/tm/Generic_registrar_data_details4ee.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + id.oai_no

            window.open(
            serviceBaseCld + "admin/tm/Generic_registrar_data_details6bb.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + id.oai_no + "&&Recordalid=" + id.RecordalID,
             '_blank' // <- This is what makes it open in a new window.
           );
        }


        if (id.RECORDAL_TYPE == "registered_user") {

            //    window.location.href = "http://88.150.164.30/EinaoTestEnvironment.CLD/admin/tm/Generic_registrar_data_details4ee.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + id.oai_no

            window.open(
            serviceBaseCld + "admin/tm/Generic_registrar_data_details6bb.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + id.oai_no + "&&Recordalid=" + id.RecordalID,
             '_blank' // <- This is what makes it open in a new window.
           );
        }

        // $location.hash(id);
        // $anchorScroll();
    }



    $http({
        method: 'GET',
        // url: 'http://88.150.164.30/CLD/Handlers/GetData.ashx'
        url: serviceBaseCld + 'Handlers/GetData9b.ashx'
    }).success(function (data, status, headers, config) {
        var dd = data;

        $scope.itemsByPage = 50;
        var dd2 = [];



        $scope.ListAgent = dd;
        $scope.displayedCollection = [].concat($scope.ListAgent);
    }).error(function (data, status, headers, config) {
        alert("error " + data)
        $scope.message = 'Unexpected Error';
    });

}]);
app.controller('myController10', ['$scope', '$http', '$rootScope', function ($scope, $http, $rootScope) {


    $scope.Export = function () {
        alasql('SELECT * INTO XLSX("trademark.xlsx",{headers:true}) FROM ?', [$scope.ListAgent]);
    };


    $scope.scrollTo = function (id) {
        if (id.RECORDAL_TYPE == "Change_Agent") {
            //  window.location.href = "http://88.150.164.30/EinaoTestEnvironment.CLD/admin/tm/Generic_registrar_data_details4c.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + id.oai_no
            window.open(
                         serviceBaseCld + "admin/tm/Generic_registrar_data_details6c.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + id.oai_no + "&&Recordalid=" + id.RecordalID,
                         '_blank' // <- This is what makes it open in a new window.
                       );
        }


        // $location.hash(id);
        // $anchorScroll();
    }



    $http({
        method: 'GET',
        // url: 'http://88.150.164.30/CLD/Handlers/GetData.ashx'
        url: serviceBaseCld + 'Handlers/GetData10.ashx'
    }).success(function (data, status, headers, config) {
        var dd = data;

        $scope.itemsByPage = 50;
        $scope.ListAgent = data;
        $scope.displayedCollection = [].concat($scope.ListAgent);
    }).error(function (data, status, headers, config) {
        alert("error " + data)
        $scope.message = 'Unexpected Error';
    });

}]);






