var app = angular.module('myModule', ['smart-table', 'angular-loading-bar', 'ngCsv']);

var serviceBaseIpo = 'http://88.150.164.30/EinaoTestEnvironment.IPO/';

var serviceBaseCld = 'http://tm.cldng.com/'
app.controller('myController2', ['$scope', '$http', '$rootScope', function ($scope, $http, $rootScope) {
    $scope.changeValue2 = function () {
        event2s = []
        var vcount = 0;
        angular.forEach($scope.displayedCollection, function (item) {
            var User_Status = new Object();
            if (item.description == "Search") {
                User_Status.online_id = item.oai_no;
                User_Status.Status = "Search"

                event2s.push(User_Status)
                vcount = vcount + 1;
                //alert(item.oai_no)
            }

            if (item.description == "Acceptance") {
                User_Status.online_id = item.oai_no;
                User_Status.Status = "Acceptance"

                event2s.push(User_Status)
                vcount = vcount + 1;
                //alert(item.oai_no)
            }

            if (item.description == "Certificate") {
                User_Status.online_id = item.oai_no;
                User_Status.Status = "Certificate"

                event2s.push(User_Status)
                vcount = vcount + 1;
                //alert(item.oai_no)
            }

            if (item.description == "Opposition") {
                User_Status.online_id = item.oai_no;
                User_Status.Status = "Opposition"

                event2s.push(User_Status)
                vcount = vcount + 1;
                //alert(item.oai_no)
            }


        });


        if (vcount == 0) {

            swal("", "No Record Selected", "error")
            return;
        }

        swal({
            title: "",
            text: "Are you sure you want to update the status of   " + vcount + " Records",
            type: "warning",
            showCancelButton: true,
            confirmButtonColor: "#DD6B55", confirmButtonText: "UPDATE",
            cancelButtonText: "No!",
            closeOnConfirm: true,
            closeOnCancel: true
        },
function (isConfirm) {
    if (isConfirm) {

        var formData = new FormData();


        formData.append("vid", JSON.stringify(event2s));
        // formData.append("vid", event2s);




        var jsonData = angular.toJson(event2s);
        var objectToSerialize = { 'object': jsonData };




        $http.post(serviceBaseCld + 'Handlers/PostTransaction2.ashx', formData, {

            transformRequest: angular.identity,
            headers: { 'Content-Type': undefined }
        })
        .success(function (response) {

            //  ajaxindicatorstop();

            var kk = response

            swal("", "Record Updated Successfully", "success")
            window.location.assign("g_applications.aspx");

        })
        .error(function (aa) {
            var data = aa
            // ajaxindicatorstop();
            swal("error")
        });


    } else {
        swal("Cancelled", "Action Canceled :)", "error");
    }
});


    }

    $http({
        method: 'GET',
        //  url: 'http://localhost:49703//Handlers/GetGeneric.ashx'
        url: serviceBaseCld + 'Handlers/GetGeneric.ashx'
    }).success(function (data, status, headers, config) {
        var dd = data;

        $scope.itemsByPage = 50;
        $scope.ListAgent = data;
        $scope.displayedCollection = [].concat($scope.ListAgent);
    }).error(function (data, status, headers, config) {
        alert("error " + data)
        $scope.message = 'Unexpected Error';
    });

    $scope.Export = function () {
        alasql('SELECT * INTO XLSX("tony.xlsx",{headers:true}) FROM ?', [$scope.ListAgent]);
    };
 
    $scope.getHeader = function () {return ["ID", "LOG STAFF","ONLINE NUMBER","REGISTRATION DATE","FILE NO","REQUEST TYPE","TITLE OF PRODUCT","CLASS","APPLICANT NAME","STATUS","SERIAL NUMBER"]};

    //When you have entire dataset



}]);









