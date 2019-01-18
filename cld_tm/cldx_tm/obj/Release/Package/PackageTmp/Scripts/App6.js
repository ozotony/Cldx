angular.module('App', [])

// =============================================================================


// our controller for the form
// =============================================================================
.controller('formController', function ($scope, $rootScope, authService) {

    // alert($location.search().name)

    $scope.Payment_Reference = "";
    // we will store all of our form data in this object
    $scope.formData = {};

    $scope.formData.vname = $location.search().name;

    $scope.add = function () {


        authService.save().then(function (data, status) {

                  alert("Printed ")

              },
        function (response) {
alert("error")
        });

       
    }

 

});