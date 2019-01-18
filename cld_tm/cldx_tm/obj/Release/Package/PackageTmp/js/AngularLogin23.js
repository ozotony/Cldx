var app = angular.module('myModule', ['smart-table', 'angular-loading-bar', 'ngModal']);

var serviceBaseIpo = 'http://88.150.164.30/EinaoTestEnvironment.IPO/';

var serviceBaseCld = 'http://88.150.164.30/EinaoTestEnvironment.CLD/'
app.controller('myController11', ['$scope', '$http', '$rootScope', function ($scope, $http, $rootScope) {
    $rootScope.vpath=  getUrlParameter("x");

    var event2s = []
    $scope.changeValue = function (row) {
        if (row.description == true) {
            //  alert(row.oai_no)
        }
    }

    $scope.changeValue2 = function () {
        event2s = []
        var vcount = 0;
        angular.forEach($scope.displayedCollection, function (item) {
            var User_Status = new Object();
            if (item.description == true) {
                User_Status.online_id = item.oai_no;
                User_Status.Status = "Examiner"

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




        $http.post( serviceBaseCld +'Handlers/PostTransaction.ashx', formData, {

            transformRequest: angular.identity,
            headers: { 'Content-Type': undefined }
        })
        .success(function (response) {

            //  ajaxindicatorstop();

            var kk = response

            swal("", "Record Updated Successfully", "success")
            window.location.assign("search2.aspx");

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



        // alert(events[0].User_Status.online_id )

    }

    $http({
        method: 'GET',
        //  url: 'http://localhost:49703//Handlers/GetData21.ashx'
        url: serviceBaseCld + 'Handlers/GetData21.ashx'
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


function getUrlParameter(param, dummyPath) {
    var sPageURL = dummyPath || window.location.search.substring(1),
        sURLVariables = sPageURL.split(/[&||?]/),
        res;

    for (var i = 0; i < sURLVariables.length; i += 1) {
        var paramName = sURLVariables[i],
            sParameterName = (paramName || '').split('=');

        if (sParameterName[0] === param) {
            res = sParameterName[1];
        }
    }

    return res;
}