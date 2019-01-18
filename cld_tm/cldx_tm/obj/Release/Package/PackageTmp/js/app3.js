var app = angular.module('PayXAuthApp', []);




 var serviceBase = 'http://localhost:24325/';
//var serviceBase = 'http://88.150.164.30/EinaoTestEnvironment.PayExServer/';
//app.config(function ($httpProvider) {
//    $httpProvider.interceptors.push('authInterceptorService');
//});
 
app.controller('ProfileController', function ($scope,  $rootScope,$http) {
    $scope.tab = "Images/profile.png";
    $scope.Save = function (reg) {
        //alert(reg.cat_id);
        var fData = new FormData();
        var Filex = document.getElementById("passport");
        var totalFiles = Filex.files.length;
        if (totalFiles == 0) {
            alert("Upload File")
            //  self.cac("");

            return;

        }

        for (var i = 0; i < totalFiles; i++) {
            var file = Filex.files[i];
            fData.append("FilePath", file);
        }
        var AgentsData = {

            Name: reg.Name,
            Email: reg.Email,
            PhoneNumber: reg.PhoneNumber,
            Address: reg.Address,
            BVN: reg.BVN,
            Genda: reg.Genda,
            Passport_No: reg.Passport_No,
            Issue_Date: reg.Issue_Date,
            Expiry_Date: reg.Expiry_Date,
            Place_ofissue: reg.Place_ofissue,
            Date_Of_Birth: reg.Date_Of_Birth

        };
        fData.append("RegisterBindingModel", JSON.stringify(AgentsData));

        $http.post(serviceBase + 'PostPersonalInfo', fData, {
            transformRequest: angular.identity,
            headers: { 'Content-Type': undefined }
        }).then(function (response) {
            return response;
        });

     
    };
    $scope.SaveCon = function (reg) {
        //alert(reg.cat_id);
        var fData = new FormData();
        var Filex = document.getElementById("passport");
        var totalFiles = Filex.files.length;
        if (totalFiles == 0) {
            alert("Upload File")
            //  self.cac("");

            return;

        }

        for (var i = 0; i < totalFiles; i++) {
            var file = Filex.files[i];
            fData.append("FilePath", file);
        }
        var AgentsData = {

            Name: reg.Name,
            Email: reg.Email,
            PhoneNumber: reg.PhoneNumber,
            Address: reg.Address,
            BVN: reg.BVN,
            Genda: reg.Genda,
            Passport_No: reg.Passport_No,
            Issue_Date: reg.Issue_Date,
            Expiry_Date: reg.Expiry_Date,
            Place_ofissue: reg.Place_ofissue,
            Date_Of_Birth: reg.Date_Of_Birth
           

        };
        fData.append("RegisterBindingModel", JSON.stringify(AgentsData));
        authService.saveRegistration(fData).then(function (response) {
            alert("Profile has been accepted");
          //  Scopes.store("profile", fData);
           // $location.path("/request");
        },
    function (response) {
        var errors = [];
        for (var key in response.data.modelState) {
            for (var i = 0; i < response.data.modelState[key].length; i++) {
                errors.push(response.data.modelState[key][i]);
            }
        }
        $scope.message = "Failed to register user due to:" + errors.join('');

    });
    };
   
});

