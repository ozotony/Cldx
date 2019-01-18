var app = angular.module('myModule');


app.factory('authService', ['$http', '$q', '$rootScope', function ($http, $q, $rootScope) {

   // var serviceBaseCld = 'http://localhost:49703/'


    var serviceBaseCld = 'http://tm.cldng.com/';



    var authServiceFactory = {};


    var _save = function () {
        var deferred = $q.defer();
        try {
            window.print()

         //   onPrintFinished(window.print());

           

            deferred.resolve("success");

        }

        catch (err) {
            deferred.resolve(err.message);

        }


        return deferred.promise;
    };

    var _save2 = function (xname, xname2) {
        var deferred = $q.defer();
        event2s = []
     
           // window.print()
        var User_Status = new Object();
            User_Status.online_id = xname2;
            User_Status.adminid = xname;
            User_Status.Status = "PrintedCertificate"

            event2s.push(User_Status)


            var formData = new FormData();


            formData.append("vid", JSON.stringify(event2s));

            var jsonData = angular.toJson(event2s);
            var objectToSerialize = { 'object': jsonData };




            $http.post(serviceBaseCld + 'Handlers/PostTransaction2.ashx', formData, {

                transformRequest: angular.identity,
                headers: { 'Content-Type': undefined }
            })
            .success(function (response) {

                //  ajaxindicatorstop();

                var kk = response

                deferred.resolve(response);

              //  swal("", "Record Updated Successfully", "success")
              //  window.location.assign("g_applications.aspx");

            })
            .error(function (aa) {
              //  var data = aa
                // ajaxindicatorstop();
                deferred.resolve(err.message);
            });

            //   onPrintFinished(window.print());



        

      


        return deferred.promise;
    };


    authServiceFactory.save = _save;

    authServiceFactory.save2 = _save2;


    return authServiceFactory;
}]);