var app = angular.module('myModule', ['smart-table', 'angular-loading-bar', 'ngCsv', 'ui.bootstrap']);

var serviceBaseIpo = 'http://5.77.54.44/IpoCldng/';

var serviceBaseCld = 'http://tm.cldng.com/'

//var serviceBaseCld = 'http://localhost:49703/'

app.controller('myController2', function ($scope, $uibModal, $http,$rootScope) {
    $scope.title = "";


    $scope.submitForm3 = function (row) {
       

        var Encrypt = {
            vv: row.tm_title
        }



        $http({
            method: 'POST',
            url: serviceBaseCld + 'Handlers/Search.ashx',
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


                $scope.payment = response;

                var dd = response;

                $scope.itemsByPage = 10;
                $scope.ListAgent2 = response;
                $scope.displayedCollection2 = [].concat($scope.ListAgent2);

                console.log(response)
                $uibModal.open({
                    templateUrl: 'myModalContent2.html',
                    scope: $scope,
                    size: 'lg',
                    controller: function ($scope, $uibModalInstance) {
                        $scope.ok = function () {
                            $uibModalInstance.close();
                        };

                        $scope.cancel = function () {
                            $uibModalInstance.dismiss('cancel');
                        };
                    }
                })


            })
            .error(function (response) {


                alert("error " + response)
            });
  


    }
    $scope.submitForm2 = function () {
 

    }


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

    $scope.getHeader = function () { return ["ID", "LOG STAFF", "ONLINE NUMBER", "REGISTRATION DATE", "FILE NO", "REQUEST TYPE", "TITLE OF PRODUCT", "CLASS", "APPLICANT NAME", "STATUS", "SERIAL NUMBER"] };
})
app.controller('myController2a', ['$scope', '$http', '$rootScope', function ($scope, $http, $rootScope) {



    //When you have entire dataset



}]);









