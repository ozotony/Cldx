var app = angular.module('myModule', ['monospaced.qrcode']);


app.controller('myController', ['$scope', '$http', '$rootScope', 'authService', function ($scope, $http, $rootScope, authService) {
    var xname = "";
    var xname2 = "";
    $(document).ready(function () {
     

       $scope.string = $("input#registrar_c_data_details1_xrtm").val();

        
       xname = $("input#registrar_c_data_details1_xname").val();
       xname2 = $("input#registrar_c_data_details1_xname2").val();

     //   $scope.string = "testing";
      



    



    });

   



    $scope.$on('$viewContentLoaded', function () {



    });


    $scope.add = function () {
       

        $(document).ready(function () {
         





        });

        authService.save().then(function (data, status) {


            swal({
                title: "",
                text: "Do You Want To Move Record To Printed Folder",
                type: "warning",
                showCancelButton: true,
                confirmButtonColor: "#DD6B55", confirmButtonText: "MOVE",
                cancelButtonText: "No!",
                closeOnConfirm: true,
                closeOnCancel: true
            },
    function (isConfirm) {
        if (isConfirm) {

          

            authService.save2(xname, xname2).then(function (data, status) {
                swal("", "Record Moved Successfully", "success");


            })


        }
        else {
            swal("Cancelled", "Action Canceled :)", "error");
        }
    });


        })

    }



    $scope.add2 = function () {


        $(document).ready(function () {






        });

        authService.save().then(function (data, status) {





        })

    }

    //When you have entire dataset



}]);


