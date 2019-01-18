var app = angular.module('myModule', ['smart-table', 'angular-loading-bar', 'ngModal']);



var serviceBaseIpo = 'http://88.150.164.30/EinaoTestEnvironment.IPO/';

//var serviceBaseCld = 'http://localhost:49703/'

var serviceBaseCld = 'http://45.40.139.163/EinaoTestEnvironment.CLD/'

app.controller('myController', ['$scope', '$http', '$rootScope', function ($scope, $http, $rootScope) {

    $http({
        method: 'GET',
        //  url: 'http://localhost:49703//Handlers/GetData.ashx'
        url: serviceBaseCld +  'Handlers/GetData22.ashx'
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


app.controller('myController1', ['$scope', '$http', '$rootScope', function ($scope, $http, $rootScope) {

    $http({
        method: 'GET',
        //  url: 'http://localhost:49703//Handlers/GetData.ashx'
        url:serviceBaseCld +  'Handlers/GetData23.ashx'
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

app.controller('myController2', ['$scope', '$http', '$rootScope', function ($scope, $http, $rootScope) {

    $http({
        method: 'GET',
        //  url: 'http://localhost:49703//Handlers/GetData.ashx'
        url:serviceBaseCld +  'Handlers/GetData24.ashx'
    }).success(function (data, status, headers, config) {
        var dd = data;

        $scope.itemsByPage = 50;
        $scope.ListAgent = data;
        $scope.displayedCollection = [].concat($scope.ListAgent);
    }).error(function (data, status, headers, config) {
        alert("error " + data)
        $scope.message = 'Unexpected Error';
    });

    $scope.changeValue2 = function () {
        var kkk2 = $('#comment').val();

        event2s = []
        var vcount = 0;
        var kkk = $('#HiddenField1').val();

       
        angular.forEach($scope.displayedCollection, function (item) {
            var User_Status = new Object();


            if (item.description == "Registrable") {
               
                User_Status.online_id = item.id;
                User_Status.Status = "Registrable";

                User_Status.userid = kkk;
                User_Status.xcomment = kkk2;

                event2s.push(User_Status)
                vcount = vcount + 1;
                //alert(item.oai_no)
            }

            if (item.description == "Non-registrable") {
                User_Status.online_id = item.id;
                User_Status.Status = "Non-registrable"
                User_Status.userid = kkk;

                User_Status.xcomment = kkk2;
                event2s.push(User_Status)
                vcount = vcount + 1;
                //alert(item.oai_no)
            }



            if (item.description == "Re-conduct search") {
                User_Status.online_id = item.id;
                User_Status.Status = "Re-conduct search"
                User_Status.userid = kkk;
                User_Status.xcomment = kkk2;
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




            $http.post(serviceBaseCld + 'Handlers/PostTransaction3.ashx', formData, {

                transformRequest: angular.identity,
                headers: { 'Content-Type': undefined }
            })
            .success(function (response) {

                //  ajaxindicatorstop();

                var kk = response

                swal("", "Record Updated Successfully", "success")
                window.location.assign("examiners.aspx");

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

}]);

app.controller('myController3', ['$scope', '$http', '$rootScope', function ($scope, $http, $rootScope) {

    $http({
        method: 'GET',
        //  url: 'http://localhost:49703//Handlers/GetData.ashx'
        url: serviceBaseCld +  'Handlers/GetData25.ashx'
    }).success(function (data, status, headers, config) {
        var dd = data;

        $scope.itemsByPage = 50;
        $scope.ListAgent = data;
        $scope.displayedCollection = [].concat($scope.ListAgent);
    }).error(function (data, status, headers, config) {
        alert("error " + data)
        $scope.message = 'Unexpected Error';
    });

    $scope.changeValue2 = function () {
        event2s = []
        var vcount = 0;
        var kkk = $('#HiddenField1').val();
        var kkk2 = $('#comment').val();

        angular.forEach($scope.displayedCollection, function (item) {
            var User_Status = new Object();


            if (item.description == "Registrable") {

                User_Status.online_id = item.id;
                User_Status.Status = "Registrable";

                User_Status.userid = kkk;
                User_Status.xcomment = kkk2;
                event2s.push(User_Status)
                vcount = vcount + 1;
                //alert(item.oai_no)
            }

            if (item.description == "Non-registrable") {
                User_Status.online_id = item.id;
                User_Status.Status = "Non-registrable"
                User_Status.userid = kkk;
                User_Status.xcomment = kkk2;
                event2s.push(User_Status)
                vcount = vcount + 1;
                //alert(item.oai_no)
            }



            if (item.description == "Re-conduct search") {
                User_Status.online_id = item.id;
                User_Status.Status = "Re-conduct search"
                User_Status.userid = kkk;
                User_Status.xcomment = kkk2;
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




            $http.post(serviceBaseCld + 'Handlers/PostTransaction3.ashx', formData, {

                transformRequest: angular.identity,
                headers: { 'Content-Type': undefined }
            })
            .success(function (response) {

                //  ajaxindicatorstop();

                var kk = response

                swal("", "Record Updated Successfully", "success")
                window.location.assign("Re_examiners.aspx");

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

}]);


app.controller('myController4', ['$scope', '$http', '$rootScope', function ($scope, $http, $rootScope) {

    $http({
        method: 'GET',
        //  url: 'http://localhost:49703//Handlers/GetData.ashx'
        url: serviceBaseCld + 'Handlers/GetData26.ashx'
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

app.controller('myController4b', ['$scope', '$http', '$rootScope', function ($scope, $http, $rootScope) {

    $http({
        method: 'GET',
        //  url: 'http://localhost:49703//Handlers/GetData.ashx'
        url: serviceBaseCld + 'Handlers/GetData26a.ashx'
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

app.controller('myController5', ['$scope', '$http', '$rootScope', function ($scope, $http, $rootScope) {

    $http({
        method: 'GET',
        //  url: 'http://localhost:49703//Handlers/GetData.ashx'
        url: serviceBaseCld + 'Handlers/GetData27.ashx'
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

app.controller('myController6', ['$scope', '$http', '$rootScope', function ($scope, $http, $rootScope) {

    $scope.pageno = 1; // initialize page no to 1
    $scope.total_count = 0;
    $scope.itemsPerPage = 100;
    $scope.varray44 = [{ SearchCriteria: 'OAI NUMBER', SearchCriteria: 'OAI NUMBER' }, { SearchCriteria: 'FILE NUMBER', SearchCriteria: 'FILE NUMBER' }, { SearchCriteria: 'PRODUCT TITLE', SearchCriteria: 'PRODUCT TITLE' }, { SearchCriteria: 'APPLICANT NAME', SearchCriteria: 'APPLICANT NAME' }]

    $scope.criteria = "";
    $scope.search = function () {
        $scope.getData($scope.pageno);

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

app.controller('myController7', ['$scope', '$http', '$rootScope', '$interval', function ($scope, $http, $rootScope, $interval) {

    var serviceBase6 = serviceBaseCld + 'Handlers/GetEmailCount4.ashx';
    var Encrypt6 = {
        vid: "5",
        vid2: "Kiv"

    }


    $http({
        method: 'POST',
        url: serviceBase6,
        transformRequest: function (obj) {
            var str = [];
            for (var p in obj)
                str.push(encodeURIComponent(p) + "=" + encodeURIComponent(obj[p]));
            return str.join("&");
        },
        data: Encrypt6,
        headers: { 'Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8;' }
    })
        .success(function (response) {
            // var a = parseInt(response);
            $rootScope.result = response;


        })
        .error(function (response) {
            var dd = response;
            //  ajaxindicatorstop();
        });

    $http({
        method: 'GET',
        //  url: 'http://localhost:49703//Handlers/GetData.ashx'
        url: serviceBaseCld + 'Handlers/GetData29.ashx'
    }).success(function (data, status, headers, config) {
        var dd = data;

        $scope.itemsByPage = 50;
        $scope.ListAgent = data;
        $scope.displayedCollection = [].concat($scope.ListAgent);
    }).error(function (data, status, headers, config) {
        alert("error " + data)
        $scope.message = 'Unexpected Error';
    });

    var Encrypt4 = {
        vid: "5",
        vid2: "Kiv"
    }

    var serviceBase = serviceBaseCld + 'Handlers/GetEmailCount.ashx';
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
            data: Encrypt4,
            headers: { 'Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8;' }
        })
            .success(function (response) {
                var dd = [];

                var a = parseInt(response);

                if (a > 0) {
                    $rootScope.xvv = true;

                }
                $rootScope.vcount = response



            })
            .error(function (response) {
                //  ajaxindicatorstop();
            });


        //   alert(xname)

    });

    $scope.add2 = function (dd) {

        for (var key in $rootScope.result) {

            if ($rootScope.result[key] == dd.id) {

                return true;
            }


        }





    }
    var serviceBase3 = serviceBaseCld + 'Handlers/GetEmailCount2.ashx';
    var Encrypt2 = {
        vid: "5",
        vid2: "Kiv"
    }
    $(document).ready(function () {


        $http({
            method: 'POST',
            url: serviceBase3,
            transformRequest: function (obj) {
                var str = [];
                for (var p in obj)
                    str.push(encodeURIComponent(p) + "=" + encodeURIComponent(obj[p]));
                return str.join("&");
            },
            data: Encrypt2,
            headers: { 'Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8;' }
        })
            .success(function (response) {
                if (response != "null") {
                    $scope.news = [
      { "firstName": response, "link": "../tm/x_unit/profile4.aspx" }
                    ]

                }


            })
            .error(function (response) {
                var dd = response;
                //  ajaxindicatorstop();
            });


        //   alert(xname)

    });

    $scope.conf = {
        news_length: false,
        news_pos: 200, // the starting position from the right in the news container
        news_margin: 20,
        news_move_flag: true
    };

    $scope.get_news_right = function (idx) {

        if ($scope.conf.news_pos == '0') {
            $scope.conf.news_pos = 400;
        }

        var $right = $scope.conf.news_pos;
        for (var ri = 0; ri < idx; ri++) {
            if (document.getElementById('news_' + ri)) {
                $right += $scope.conf.news_margin + angular.element(document.getElementById('news_' + ri))[0].offsetWidth;
            }
        }
        return $right + 'px';

        //  return '30px';
    };

    $scope.news_move = function () {
        if ($scope.conf.news_move_flag) {
            $scope.conf.news_pos--;
            if (angular.element(document.getElementById('news_0'))[0].offsetLeft > angular.element(document.getElementById('news_strip'))[0].offsetWidth + $scope.conf.news_margin) {
                var first_new = $scope.news[0];
                $scope.news.push(first_new);
                $scope.news.shift();
                $scope.conf.news_pos += angular.element(document.getElementById('news_0'))[0].offsetWidth + $scope.conf.news_margin;
            }
        }
    };

    $interval($scope.news_move, 50);



}]);

app.controller('myController8', ['$scope', '$http', '$rootScope', function ($scope, $http, $rootScope) {

    $http({
        method: 'GET',
        //  url: 'http://localhost:49703//Handlers/GetData.ashx'
        url: serviceBaseCld + 'Handlers/GetData30.ashx'
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

app.controller('myController10', ['$scope', '$http', '$rootScope', function ($scope, $http, $rootScope) {

    $http({
        method: 'GET',
        //  url: 'http://localhost:49703//Handlers/GetData.ashx'
        url: serviceBaseCld + 'Handlers/GetData38.ashx'
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





