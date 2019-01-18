var app = angular.module('myModule', ['smart-table', 'angular-loading-bar', 'ngModal']);

var serviceBaseIpo = 'http://ipo.cldng.com/';

var serviceBaseCld = 'http://tm.cldng.com/'

//var serviceBaseCld = 'http://localhost:49703/'

var serviceBasePay = "http://88.150.164.30/Payx/";

//var serviceBaseCld = 'http://localhost:49703/';
app.filter('offset', function () {
    return function (input, start) {
        start = parseInt(start, 10);
        return input.slice(start);
    };
});


app.controller('myController', ['$scope', '$http', '$rootScope', function ($scope, $http, $rootScope) {

    $scope.BranchCollect = [];
    $scope.itemsPerPage = 10;
    $scope.currentPage = 0;
    $scope.items = [];
    $scope.isDisabled = false;
   // var url3 = 'http://88.150.164.30/EinaoTestEnvironment.IPO/Handlers/GetRegistration2.ashx';

    var url3 = serviceBase + 'Handlers/GetRegistration2.ashx';

    // var url3 = ' http://localhost:21936/home/GetAgent';

    $scope.search = function () {
        //  alert(user.DateOfBrith)

       
        var formData = new FormData();
        formData.append("vid", $scope.trans);


        $.ajax({
            type: "POST",
          //  url: 'http://payx.com.ng/Handler/GetTransaction2.ashx',

            url: serviceBaseCld +'Handlers/GetApplicant.ashx',
            data: formData,

            contentType: false,
            processData: false,
            //Convert the Observable Data into JSON
            dataType: 'json',
            success: function (data) {
                $scope.isDisabled = true;
                $scope.Name = data.Applicant_Name;

                $scope.Id = data.Applicant_Id;
                $scope.Applicant_Address = data.Applicant_Address;
                $scope.email = data.Applicant_Email;
                $scope.mobile = data.Applicant_Mobile;
             //   $scope.BranchCollect = data;

             //   alert($scope.BranchCollect.cust_id)
              

                $scope.$apply();
                //ajaxindicatorstop();


                //   self.availablesponsor(data);
                //self.EmpNo(data.EmpNo);
                //alert("The New Employee Id :" + self.EmpNo());
                //GetEmployees();
            },
            error: function (ee) {
                //ajaxindicatorstop();
                //alert(ee);
            }
        });



    }

    $scope.EditRow = function () {
        //  alert(user.DateOfBrith)
        var formData = new FormData();
        var AgentsData = {


            Applicant_Name: $scope.Name,
            Applicant_Id: $scope.Id,
            Applicant_Address: $scope.Applicant_Address,
            Applicant_Email: $scope.email,
            Applicant_Mobile: $scope.mobile



        };


        formData.append("vv", JSON.stringify(AgentsData));
       // formData.append("vv", AgentsData);
        $http.post(serviceBaseCld +'Handlers/GetApplicant2.ashx', formData, {
            transformRequest: angular.identity,
            headers: { 'Content-Type': undefined }
        })
        .success(function (response) {

          //  ajaxindicatorstop();

            swal("Record Updated Successfully")


        })
        .error(function () {
           // ajaxindicatorstop();
            swal("error")
        });

    }

  

    $scope.prevPage = function () {
        if ($scope.currentPage > 0) {
            $scope.currentPage--;
        }
    };

    $scope.prevPageDisabled = function () {
        return $scope.currentPage === 0 ? "disabled" : "";
    };

    $scope.pageCount = function () {
        return Math.ceil($scope.BranchCollect.length / $scope.itemsPerPage) - 1;
    };

    $scope.nextPage = function () {
        if ($scope.currentPage < $scope.pageCount()) {
            $scope.currentPage++;
        }
    };

    $scope.nextPageDisabled = function () {
        return $scope.currentPage === $scope.pageCount() ? "disabled" : "";
    };



    $scope.$on('$viewContentLoaded', function () {



    });
   


    //When you have entire dataset



}]);



app.controller('myController2', ['$scope', '$http', '$rootScope', function ($scope, $http, $rootScope) {

    $rootScope.BranchCollect = false;
    $scope.EditRow = function (dd) {
       
        $scope.VEmail = "";
        $rootScope.VEmail = "";
        $("input#emailaddress").val("")
        $scope.payment = "";
        $rootScope.oai_no = dd.oai_no;
        $scope.dialogShown = true;

    }

    $scope.EditRow2 = function (dd) {
       

        var Encrypt = {
            vid: dd.TransId,
            vid2: $rootScope.oai_no
        }

        $http({
            method: 'POST',
            url: serviceBaseCld + 'Handlers/GetCld.ashx',
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
                response = response.split('"').join('');

                

                if (response == "This Payment  Id Is not For This Transaction") {

                    swal("", "This Payment  Id Is not For This Transaction", "error")
                    return;
                }
                if (response == "Id Already Exist") {

                    swal("", "Id Already Used", "error")
                    return;
                }
             
                swal(response)
              //  swal("Record Updated Successfully")
                location.reload();

            })
            .error(function (error) {

               

                //document.open();
                //document.write(error);
                //document.close();
             // alert(  document.writeln(error) )
                swal("", error, "error")
               
               
            });

    }

    $scope.EditRow4 = function (dd) {


        var Encrypt = {
            vid: dd.TransId,
            vid2: $rootScope.oai_no
        }


        doUrlPost(serviceBasePay, dd.TransId)


    }


    $scope.EditRow44 = function (dd) {


        var pp = dd.TransactionId2;

        if (pp.indexOf("-") != -1) {
            pp = pp.split('-');
            doUrlPost(serviceBasePay, pp[0])
            return;
        }


        doUrlPost(serviceBasePay, pp)


    }
    

    $scope.add3 = function (dd,dd2) {
        $scope.payment = [];
        var Encrypt = {
            vid: dd
        }
        var kk = $("#vchk").attr("checked")

        if ($("#vchk").attr("checked")) {

            $http({
                method: 'POST',
                url:serviceBaseCld +  'Handlers/GetBranchCollectPayment2.ashx',
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
                if (response.TransId == null) {
                    swal("Record Not Found Please Complete T003 Payment")


                }

                $scope.payment = response;


            })
            .error(function (response) {
              

                alert("error " + response)
            });

        }
        else {

            $http({
                method: 'POST',
                url: serviceBaseCld +  'Handlers/GetPayment.ashx',
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

                    try {
                   
                        response = response.split('"').join('');



                        if (response == "Full Transaction  Id Search Not Allowed ") {

                            swal("", "Full Transaction  Id Search Not Allowed", "error")
                            return;
                        }

                    }

                    catch (err) {


                    }

                    if (response.TransId == null) {
                        swal("Record Not Found Please Complete T003 Payment")


                    }

                    $scope.payment = response;


                })
                .error(function (response) {

                    swal("", "Please Enter Correct Payment ID", "error")
                  //  alert("error " + response)
                });

        }
    

    }
   
    $scope.show = function (dd) {
        if (dd.TransactionId == "") {

            return true;
        }
        else {
            return false;
        }
    }

    $scope.add2 = function (dd) {
        if ( dd.TransactionId != "") {
           
            return true;
        }
        else {
            return false;
        }

    }
    $http({
        method: 'GET',
      //  url: 'http://localhost:49703//Handlers/GetData.ashx'
        url: serviceBaseCld + 'Handlers/GetData.ashx'
    }).success(function (data, status, headers, config) {
        var dd = data;

        $scope.itemsByPage = 100;
        $scope.ListAgent = data;
        $scope.displayedCollection = [].concat($scope.ListAgent);
    }).error(function (data, status, headers, config) {
        //  alert("error " + data)

        swal("",data,"error")
        $scope.message = 'Unexpected Error';
    });


    //When you have entire dataset



}]);

app.controller('myController3', ['$scope', '$http', '$rootScope', function ($scope, $http, $rootScope) {
   
    $scope.add2 = function (dd) {
        if (dd.TransactionId != "") {

            return true;
        }
        else {
            return false;
        }

    }

    $http({
        method: 'GET',
         // url: 'http://localhost:49703/Handlers/GetData2.ashx'
        url: serviceBaseCld +  'Handlers/GetData2.ashx'
    }).success(function (data, status, headers, config) {
        var dd = data;

        $scope.itemsByPage = 50;
        $scope.ListAgent = data;
        $scope.displayedCollection = [].concat($scope.ListAgent);
    }).error(function (data, status, headers, config) {
        alert("error " + data)
        $scope.message = 'Unexpected Error';
    });


    //When you have entire dataset



}]);

app.controller('myController4', ['$scope', '$http', '$rootScope', function ($scope, $http, $rootScope) {

    $scope.add2 = function (dd) {
        if (dd.TransactionId != "") {

            return true;
        }
        else {
            return false;
        }

    }

    $http({
        method: 'GET',
        // url: 'http://localhost:49703/Handlers/GetData3.ashx'
        url: serviceBaseCld +  'Handlers/GetData4.ashx'
    }).success(function (data, status, headers, config) {
        var dd = data;

        $scope.itemsByPage = 50;
        $scope.ListAgent = data;
        $scope.displayedCollection = [].concat($scope.ListAgent);
    }).error(function (data, status, headers, config) {
        alert("error " + data)
        $scope.message = 'Unexpected Error';
    });


    //When you have entire dataset



}]);

app.controller('myController5', ['$scope', '$http', '$rootScope', function ($scope, $http, $rootScope) {


   


    $scope.add3 = function (dd) {
        $scope.payment = [];
        var Encrypt = {
            vid: dd
        }

        $http({
            method: 'POST',
            url: serviceBaseCld + 'Handlers/GetPayment.ashx',
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
                if (response.TransId == null) {
                    swal("Record Not Found Please Complete T003 Payment")


                }

                $scope.payment = response;


            })
            .error(function (response) {
                alert("error " + response)
            });




    }

    $scope.show = function (dd) {
        if (dd.TransactionId == "") {

            return true;
        }
        else {
            return false;
        }
    }

    $scope.add2 = function (dd) {
        if (dd.TransactionId != "") {

            return true;
        }
        else {
            return false;
        }

    }
    $http({
        method: 'GET',
        // url: 'http://88.150.164.30/CLD/Handlers/GetData.ashx'
        url: serviceBaseCld + 'Handlers/GetData5.ashx'
    }).success(function (data, status, headers, config) {
        var dd = data;

        $scope.itemsByPage = 50;
        $scope.ListAgent = data;
        $scope.displayedCollection = [].concat($scope.ListAgent);
    }).error(function (data, status, headers, config) {
        alert("error " + data)
        $scope.message = 'Unexpected Error';
    });


    //When you have entire dataset



}]);

app.controller('myController6', ['$scope', '$http', '$rootScope', '$interval', function ($scope, $http, $rootScope, $interval) {
    var serviceBase6 = serviceBaseCld + 'Handlers/GetEmailCount4.ashx';

    $scope.changeValue2 = function () {
        event2s = []
        var vcount = 0;
        angular.forEach($scope.displayedCollection, function (item) {
            var User_Status = new Object();
          

            if (item.description == "Acceptance") {
                User_Status.online_id = item.oai_no;
                User_Status.Status = "Acceptance"
                User_Status.Recordid = item.RecordalID;

                event2s.push(User_Status)
                vcount = vcount + 1;
                //alert(item.oai_no)
            }

            if (item.description == "Certificate") {
                User_Status.online_id = item.oai_no;
                User_Status.Status = "Certificate"
                User_Status.Recordid = item.RecordalID;
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




        $http.post( serviceBaseCld + 'Handlers/PostTransaction.ashx', formData, {

            transformRequest: angular.identity,
            headers: { 'Content-Type': undefined }
        })
        .success(function (response) {

            //  ajaxindicatorstop();

            var kk = response

            swal("", "Record Updated Successfully", "success")
            window.location.assign("g_Recordal.aspx");

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

    var Encrypt6 = {
        vid: "10",
        vid2: "New"

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

    $scope.add2 = function (dd) {

        for (var key in $rootScope.result) {

            if ($rootScope.result[key] == dd.RecordalID) {

                return true;
            }


        }





    }

    var Encrypt4 = {
        vid: "10",
        vid2: "New"
    }

    var serviceBase = serviceBaseCld +  'Handlers/GetEmailCount.ashx';
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



    $(document).ready(function () {
        var xname = $("input#xname").val();

        $("input#aa").val(xname);

        

    });

    var serviceBase3 = serviceBaseCld +  'Handlers/GetEmailCount2.ashx';
    var Encrypt2 = {
        vid: "10",
        vid2: "New"
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

    //$scope.news = [
    //{ "firstName": "AGENT John Just uploaded data click to view ","link":"http://www.cnn.com"},
    //{ "firstName": "AGENT Anna JUST uploaded data click to view ", "link": "http://www.cnn.com" },
    //{ "firstName": "AGENT Peter JUST uploaded data click to view ", "link": "http://www.cnn.com" }
    //]
    $scope.add3 = function (dd) {

        if (dd.RECORDAL_TYPE == "Change_Name") {
            //  window.location.href = "http://88.150.164.30/EinaoTestEnvironment.CLD/admin/tm/Generic_registrar_data_details4c.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + id.oai_no

            window.open(
           serviceBaseCld +   "admin/tm/Change_ApplicantName3.aspx?transID=" + dd.RecordalID + "&&vtranid=" + dd.oai_no,
             // "http://localhost:49703/admin/tm/Change_ApplicantName3.aspx?transID=" + dd.RecordalID + "&&vtranid=" + dd.oai_no,
             '_blank' // <- This is what makes it open in a new window.
           );
        }



    }
    $scope.scrollTo = function (id) {
        if (id.RECORDAL_TYPE == "Change_Address") {
            //  window.location.href = "http://88.150.164.30/EinaoTestEnvironment.CLD/admin/tm/Generic_registrar_data_details4c.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + id.oai_no
            window.open(
                        serviceBaseCld +  "admin/tm/Generic_registrar_data_details4cc.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + id.oai_no + "&&Recordalid=" + id.RecordalID,
                         '_blank' // <- This is what makes it open in a new window.
                       );
        }

        if (id.RECORDAL_TYPE == "Change_Name") {
            //  window.location.href = "http://88.150.164.30/EinaoTestEnvironment.CLD/admin/tm/Generic_registrar_data_details4c.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + id.oai_no

            window.open(
            serviceBaseCld +  "admin/tm/Generic_registrar_data_details4cc.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + id.oai_no + "&&Recordalid=" + id.RecordalID,
             '_blank' // <- This is what makes it open in a new window.
           );
        }

        if (id.RECORDAL_TYPE == "registered_user") {
            //  window.location.href = "http://88.150.164.30/EinaoTestEnvironment.CLD/admin/tm/Generic_registrar_data_details4c.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + id.oai_no

            window.open(
            serviceBaseCld + "admin/tm/Generic_registrar_data_details4cc.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + id.oai_no + "&&Recordalid=" + id.RecordalID,
             '_blank' // <- This is what makes it open in a new window.
           );
        }

        if (id.RECORDAL_TYPE == "Change_Rectification") {

            //  window.location.href = "http://88.150.164.30/EinaoTestEnvironment.CLD/admin/tm/Generic_registrar_data_details4c.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + id.oai_no
            window.open(
            serviceBaseCld +  "admin/tm/Generic_registrar_data_details4cc.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + id.oai_no + "&&Recordalid=" + id.RecordalID,
             '_blank' // <- This is what makes it open in a new window.
           );
        }


        if (id.RECORDAL_TYPE == "Change_Assignment") {

            //    window.location.href = "http://88.150.164.30/EinaoTestEnvironment.CLD/admin/tm/Generic_registrar_data_details4d.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + id.oai_no

            window.open(
            serviceBaseCld +  "admin/tm/Generic_registrar_data_details4dd.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + id.oai_no + "&&Recordalid=" + id.RecordalID,
             '_blank' // <- This is what makes it open in a new window.
           );
        }


        if (id.RECORDAL_TYPE == "Change_Assignment2") {

            //    window.location.href = "http://88.150.164.30/EinaoTestEnvironment.CLD/admin/tm/Generic_registrar_data_details4d.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + id.oai_no

            window.open(
           serviceBaseCld +   "admin/tm/Generic_registrar_data_details4dd.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + id.oai_no + "&&Recordalid=" + id.RecordalID,
             '_blank' // <- This is what makes it open in a new window.
           );
        }


        if (id.RECORDAL_TYPE == "Change_Renewal") {

            //    window.location.href = "http://88.150.164.30/EinaoTestEnvironment.CLD/admin/tm/Generic_registrar_data_details4ee.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + id.oai_no

            window.open(
            serviceBaseCld +  "admin/tm/Generic_registrar_data_details4ee.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + id.oai_no + "&&Recordalid=" + id.RecordalID,
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
        // url: 'http://localhost:49703//Handlers/GetData6.ashx'
        url: serviceBaseCld + 'Handlers/GetData6.ashx'
    }).success(function (data, status, headers, config) {
        var dd = data;

        $scope.itemsByPage = 50;
        $scope.ListAgent = data;
        $scope.displayedCollection = [].concat($scope.ListAgent);
    }).error(function (data, status, headers, config) {
        alert("error " + data)
        $scope.message = 'Unexpected Error';
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

    //When you have entire dataset



}]);

app.controller('myController7', ['$scope', '$http', '$rootScope', function ($scope, $http, $rootScope) {


    $scope.scrollTo = function (id) {
        if (id.RECORDAL_TYPE == "Change_Address") {
            //  window.location.href = "http://88.150.164.30/EinaoTestEnvironment.CLD/admin/tm/Generic_registrar_data_details4c.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + id.oai_no
            window.open(
                       serviceBaseCld +   "admin/tm/Generic_registrar_data_details4cc.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + id.oai_no + "&&Recordalid=" + id.RecordalID,
                         '_blank' // <- This is what makes it open in a new window.
                       );
        }

        if (id.RECORDAL_TYPE == "Change_Name") {
            //  window.location.href = "http://88.150.164.30/EinaoTestEnvironment.CLD/admin/tm/Generic_registrar_data_details4c.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + id.oai_no

            window.open(
            serviceBaseCld +  "admin/tm/Generic_registrar_data_details4cc.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + id.oai_no + "&&Recordalid=" + id.RecordalID,
             '_blank' // <- This is what makes it open in a new window.
           );
        }


        if (id.RECORDAL_TYPE == "registered_user") {
            //  window.location.href = "http://88.150.164.30/EinaoTestEnvironment.CLD/admin/tm/Generic_registrar_data_details4c.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + id.oai_no

            window.open(
            serviceBaseCld + "admin/tm/Generic_registrar_data_details4cc.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + id.oai_no + "&&Recordalid=" + id.RecordalID,
             '_blank' // <- This is what makes it open in a new window.
           );
        }

        if (id.RECORDAL_TYPE == "Change_Rectification") {

            //  window.location.href = "http://88.150.164.30/EinaoTestEnvironment.CLD/admin/tm/Generic_registrar_data_details4c.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + id.oai_no
            window.open(
            serviceBaseCld +  "admin/tm/Generic_registrar_data_details4cc.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + id.oai_no + "&&Recordalid=" + id.RecordalID,
             '_blank' // <- This is what makes it open in a new window.
           );
        }


        if (id.RECORDAL_TYPE == "Change_Assignment") {

            //    window.location.href = "http://88.150.164.30/EinaoTestEnvironment.CLD/admin/tm/Generic_registrar_data_details4d.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + id.oai_no

            window.open(
            serviceBaseCld +  "admin/tm/Generic_registrar_data_details4dd.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + id.oai_no + "&&Recordalid=" + id.RecordalID,
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
            serviceBaseCld +  "admin/tm/Generic_registrar_data_details4ee.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + id.oai_no + "&&Recordalid=" + id.RecordalID,
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
        url: serviceBaseCld + 'Handlers/GetData7.ashx'
    }).success(function (data, status, headers, config) {
        var dd = data;

        $scope.itemsByPage = 50;
        $scope.ListAgent = data;
        $scope.displayedCollection = [].concat($scope.ListAgent);
    }).error(function (data, status, headers, config) {
        alert("error " + data)
        $scope.message = 'Unexpected Error';
    });


    //When you have entire dataset
 

}]);

app.controller('myController8', ['$scope', '$http', '$rootScope', function ($scope, $http, $rootScope) {


    $scope.scrollTo = function (id) {
        if (id.RECORDAL_TYPE == "Change_Address") {
            //  window.location.href = "http://88.150.164.30/EinaoTestEnvironment.CLD/admin/tm/Generic_registrar_data_details4c.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + id.oai_no
            window.open(
                        serviceBaseCld +  "admin/tm/Generic_registrar_data_details4cc.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + id.oai_no + "&&Recordalid=" + id.RecordalID,
                         '_blank' // <- This is what makes it open in a new window.
                       );
        }

        if (id.RECORDAL_TYPE == "Change_Name") {
            //  window.location.href = "http://88.150.164.30/EinaoTestEnvironment.CLD/admin/tm/Generic_registrar_data_details4c.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + id.oai_no

            window.open(
            serviceBaseCld +  "admin/tm/Generic_registrar_data_details4cc.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + id.oai_no + "&&Recordalid=" + id.RecordalID,
             '_blank' // <- This is what makes it open in a new window.
           );
        }



        if (id.RECORDAL_TYPE == "registered_user") {
            //  window.location.href = "http://88.150.164.30/EinaoTestEnvironment.CLD/admin/tm/Generic_registrar_data_details4c.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + id.oai_no

            window.open(
            serviceBaseCld + "admin/tm/Generic_registrar_data_details4cc.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + id.oai_no + "&&Recordalid=" + id.RecordalID,
             '_blank' // <- This is what makes it open in a new window.
           );
        }
        if (id.RECORDAL_TYPE == "Change_Rectification") {

            //  window.location.href = "http://88.150.164.30/EinaoTestEnvironment.CLD/admin/tm/Generic_registrar_data_details4c.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + id.oai_no
            window.open(
            serviceBaseCld +  "admin/tm/Generic_registrar_data_details4cc.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + id.oai_no + "&&Recordalid=" + id.RecordalID,
             '_blank' // <- This is what makes it open in a new window.
           );
        }


        if (id.RECORDAL_TYPE == "Change_Assignment") {

            //    window.location.href = "http://88.150.164.30/EinaoTestEnvironment.CLD/admin/tm/Generic_registrar_data_details4d.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + id.oai_no

            window.open(
           serviceBaseCld +   "admin/tm/Generic_registrar_data_details4dd.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + id.oai_no + "&&Recordalid=" + id.RecordalID,
             '_blank' // <- This is what makes it open in a new window.
           );
        }


        if (id.RECORDAL_TYPE == "Change_Assignment2") {

            //    window.location.href = "http://88.150.164.30/EinaoTestEnvironment.CLD/admin/tm/Generic_registrar_data_details4d.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + id.oai_no

            window.open(
           serviceBaseCld +   "admin/tm/Generic_registrar_data_details4dd.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + id.oai_no + "&&Recordalid=" + id.RecordalID,
             '_blank' // <- This is what makes it open in a new window.
           );
        }


        if (id.RECORDAL_TYPE == "Change_Renewal") {

            //    window.location.href = "http://88.150.164.30/EinaoTestEnvironment.CLD/admin/tm/Generic_registrar_data_details4ee.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + id.oai_no

            window.open(
            serviceBaseCld +  "admin/tm/Generic_registrar_data_details4ee.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + id.oai_no + "&&Recordalid=" + id.RecordalID,
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
        url: serviceBaseCld +  'Handlers/GetData8.ashx'
    }).success(function (data, status, headers, config) {
        var dd = data;

        $scope.itemsByPage = 50;
        $scope.ListAgent = data;
        $scope.displayedCollection = [].concat($scope.ListAgent);
    }).error(function (data, status, headers, config) {
        alert("error " + data)
        $scope.message = 'Unexpected Error';
    });


    //When you have entire dataset



}]);

app.controller('myController9', ['$scope', '$http', '$rootScope', function ($scope, $http, $rootScope) {

    $scope.Export = function () {
        alasql('SELECT * INTO XLSX("trademark.xlsx",{headers:true}) FROM ?', [$scope.ListAgent]);
    };


    $scope.scrollTo = function (id) {
        if (id.RECORDAL_TYPE == "Change_Address") {
            //  window.location.href = "http://88.150.164.30/EinaoTestEnvironment.CLD/admin/tm/Generic_registrar_data_details4c.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + id.oai_no
            window.open(
                        serviceBaseCld +  "admin/tm/Generic_registrar_data_details4cc.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + id.oai_no + "&&Recordalid=" + id.RecordalID,
                         '_blank' // <- This is what makes it open in a new window.
                       );
        }

        if (id.RECORDAL_TYPE == "Change_Name") {
            //  window.location.href = "http://88.150.164.30/EinaoTestEnvironment.CLD/admin/tm/Generic_registrar_data_details4c.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + id.oai_no

            window.open(
           serviceBaseCld +   "admin/tm/Generic_registrar_data_details4cc.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + id.oai_no + "&&Recordalid=" + id.RecordalID,
             '_blank' // <- This is what makes it open in a new window.
           );
        }


        if (id.RECORDAL_TYPE == "registered_user") {
            //  window.location.href = "http://88.150.164.30/EinaoTestEnvironment.CLD/admin/tm/Generic_registrar_data_details4c.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + id.oai_no

            window.open(
            serviceBaseCld + "admin/tm/Generic_registrar_data_details4cc.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + id.oai_no + "&&Recordalid=" + id.RecordalID,
             '_blank' // <- This is what makes it open in a new window.
           );
        }


        if (id.RECORDAL_TYPE == "Change_Rectification") {

            //  window.location.href = "http://88.150.164.30/EinaoTestEnvironment.CLD/admin/tm/Generic_registrar_data_details4c.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + id.oai_no
            window.open(
           serviceBaseCld +   "admin/tm/Generic_registrar_data_details4cc.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + id.oai_no + "&&Recordalid=" + id.RecordalID,
             '_blank' // <- This is what makes it open in a new window.
           );
        }


        if (id.RECORDAL_TYPE == "Change_Assignment") {

            //    window.location.href = "http://88.150.164.30/EinaoTestEnvironment.CLD/admin/tm/Generic_registrar_data_details4d.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + id.oai_no

            window.open(
           serviceBaseCld +   "admin/tm/Generic_registrar_data_details4dd.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + id.oai_no + "&&Recordalid=" + id.RecordalID,
             '_blank' // <- This is what makes it open in a new window.
           );
        }


        if (id.RECORDAL_TYPE == "Change_Assignment2") {

            //    window.location.href = "http://88.150.164.30/EinaoTestEnvironment.CLD/admin/tm/Generic_registrar_data_details4d.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + id.oai_no

            window.open(
           serviceBaseCld +   "admin/tm/Generic_registrar_data_details4dd.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + id.oai_no + "&&Recordalid=" + id.RecordalID,
             '_blank' // <- This is what makes it open in a new window.
           );
        }


        if (id.RECORDAL_TYPE == "Change_Renewal") {

            //    window.location.href = "http://88.150.164.30/EinaoTestEnvironment.CLD/admin/tm/Generic_registrar_data_details4ee.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + id.oai_no

            window.open(
            serviceBaseCld +  "admin/tm/Generic_registrar_data_details4ee.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + id.oai_no + "&&Recordalid=" + id.RecordalID,
             '_blank' // <- This is what makes it open in a new window.
           );
        }

        // $location.hash(id);
        // $anchorScroll();
    }



    $http({
        method: 'GET',
        // url: 'http://88.150.164.30/CLD/Handlers/GetData.ashx'
        url: serviceBaseCld +  'Handlers/GetData9.ashx'
    }).success(function (data, status, headers, config) {
        var dd = data;

        $scope.itemsByPage = 50;
        $scope.ListAgent = data;
        $scope.displayedCollection = [].concat($scope.ListAgent);
    }).error(function (data, status, headers, config) {
        alert("error " + data)
        $scope.message = 'Unexpected Error';
    });


    //When you have entire dataset



}]);

app.controller('myController10', ['$scope', '$http', '$rootScope', function ($scope, $http, $rootScope) {
    $scope.add = function () {
        $scope.payment = [];
        var Encrypt = {
            vid: $scope.vinput
        }

        $http({
            method: 'POST',
            url: serviceBaseCld +  'Handlers/GetData19.ashx',
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
                var dd = response;

                $scope.itemsByPage = 50;
                $scope.ListAgent = response;
                $scope.displayedCollection = [].concat($scope.ListAgent);


            })
            .error(function (response) {
                alert("error " + response)
            });




    }

    $scope.add3 = function (dd) {

        if (dd.RECORDAL_TYPE == "Change_Name") {
            //  window.location.href = "http://88.150.164.30/EinaoTestEnvironment.CLD/admin/tm/Generic_registrar_data_details4c.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + id.oai_no

            window.open(
            serviceBaseCld +  "admin/tm/Change_ApplicantName3.aspx?transID=" + dd.RecordalID + "&&vtranid=" + dd.oai_no,
             // "http://localhost:49703/admin/tm/Change_ApplicantName3.aspx?transID=" + dd.RecordalID + "&&vtranid=" + dd.oai_no,
             '_blank' // <- This is what makes it open in a new window.
           );
        }


        if (dd.RECORDAL_TYPE == "Change_Address") {
            //  window.location.href = "http://88.150.164.30/EinaoTestEnvironment.CLD/admin/tm/Generic_registrar_data_details4c.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + id.oai_no

            window.open(
            serviceBaseCld +  "admin/tm/Change_ApplicantAddress2.aspx?transID=" + dd.RecordalID + "&&vtranid=" + dd.oai_no,
             // "http://localhost:49703/admin/tm/Change_ApplicantName3.aspx?transID=" + dd.RecordalID + "&&vtranid=" + dd.oai_no,
             '_blank' // <- This is what makes it open in a new window.
           );
        }


    }

    $scope.scrollTo = function (id) {
        if (id.RECORDAL_TYPE == "Change_Address") {
            //  window.location.href = "http://88.150.164.30/EinaoTestEnvironment.CLD/admin/tm/Generic_registrar_data_details4c.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + id.oai_no
            window.open(
                       serviceBaseCld +   "admin/tm/Generic_registrar_data_details4cc.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + id.oai_no + "&&Recordalid=" + id.RecordalID,
                         '_blank' // <- This is what makes it open in a new window.
                       );
        }

        if (id.RECORDAL_TYPE == "Change_Name") {
            //  window.location.href = "http://88.150.164.30/EinaoTestEnvironment.CLD/admin/tm/Generic_registrar_data_details4c.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + id.oai_no

            window.open(
           serviceBaseCld +   "admin/tm/Generic_registrar_data_details4cc.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + id.oai_no + "&&Recordalid=" + id.RecordalID,
             '_blank' // <- This is what makes it open in a new window.
           );
        }


        if (id.RECORDAL_TYPE == "registered_user") {
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
            serviceBaseCld +  "admin/tm/Generic_registrar_data_details4dd.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + id.oai_no + "&&Recordalid=" + id.RecordalID,
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
            serviceBaseCld +  "admin/tm/Generic_registrar_data_details4ee.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + id.oai_no + "&&Recordalid=" + id.RecordalID,
             '_blank' // <- This is what makes it open in a new window.
           );
        }

        // $location.hash(id);
        // $anchorScroll();
    }
}]);

app.controller('myController11', ['$scope', '$http', '$rootScope', function ($scope, $http, $rootScope) {
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
                User_Status.Status = "Search"

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




        $http.post(serviceBaseCld + 'Handlers/PostTransaction.ashx', formData, {

            transformRequest: angular.identity,
            headers: { 'Content-Type': undefined }
        })
        .success(function (response) {

            //  ajaxindicatorstop();

            var kk = response

            swal("","Record Updated Successfully","success")
            window.location.assign("verify_data.aspx");

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
        //  url: 'http://localhost:49703//Handlers/GetData.ashx'
        url: serviceBaseCld + 'Handlers/GetData20.ashx'
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

app.controller('myController12', ['$scope', '$http', '$rootScope','$interval', function ($scope, $http, $rootScope,$interval) {
    var event2s = []
    var serviceBase6 = serviceBaseCld + 'Handlers/GetEmailCount4.ashx';
    var Encrypt6 = {
        vid: "14",
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
        url: serviceBaseCld + 'Handlers/GetData20b.ashx'
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
        vid: "14",
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

    var serviceBase3 = serviceBaseCld + 'Handlers/GetEmailCount2.ashx';
    var Encrypt2 = {
        vid: "14",
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

    $scope.add2 = function (dd) {

        for (var key in $rootScope.result) {

            if ($rootScope.result[key] == dd.id) {

                return true;
            }


        }





    }

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


app.controller('myController33', ['$scope', '$http', '$rootScope', function ($scope, $http, $rootScope) {

    $scope.add2 = function (dd) {
        if (dd.TransactionId != "") {

            return true;
        }
        else {
            return false;
        }

    }

    $http({
        method: 'GET',
        // url: 'http://localhost:49703/Handlers/GetData2.ashx'
        url: serviceBaseCld + 'Handlers/GetData33.ashx'
    }).success(function (data, status, headers, config) {
        var dd = data;

        $scope.itemsByPage = 50;
        $scope.ListAgent = data;
        $scope.displayedCollection = [].concat($scope.ListAgent);
    }).error(function (data, status, headers, config) {
        alert("error " + data)
        $scope.message = 'Unexpected Error';
    });


    //When you have entire dataset



}]);


app.controller('myController34', ['$scope', '$http', '$rootScope', '$interval', function ($scope, $http, $rootScope, $interval) {
    var event2s = []
    var serviceBase6 = serviceBaseCld + 'Handlers/GetEmailCount4.ashx';
    var Encrypt6 = {
        vid: "14",
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
        url: serviceBaseCld + 'Handlers/AppealRejection2.ashx'
    }).success(function (data, status, headers, config) {
        var dd = data;

        $scope.itemsByPage = 50;
        $scope.ListAgent = data;

        $scope.displayedCollection = [].concat($scope.ListAgent);
    }).error(function (data, status, headers, config) {
        alert("error " + data)
        $scope.message = 'Unexpected Error';
    });


    $scope.add22 = function (dd) {

        //  alert(dd.xid)
        OpenWindowWithPost2("http://45.40.139.163/EinaoTestEnvironment.CLD/admin/tm/rejection_slip_details.aspx?x=" + dd.xid, "width=1000, height=600, left=100, top=100, resizable=yes, scrollbars=yes", "NewFile");
        //  $scope.detailFrame = "http://45.40.139.163/EinaoTestEnvironment.CLD/admin/tm/rejection_slip_details.aspx?x=" + dd.xid;

    }

    

}]);

app.controller('myController35', ['$scope', '$http', '$rootScope', '$interval', function ($scope, $http, $rootScope, $interval) {
    var event2s = []
    var serviceBase6 = serviceBaseCld + 'Handlers/GetEmailCount4.ashx';
    var Encrypt6 = {
        vid: "14",
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
        url: serviceBaseCld + 'Handlers/AppealRejection3.ashx'
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






function OpenWindowWithPost2(url, windowoption, name) {

    window.open(url, name, windowoption);
}

function ajaxindicatorstart(text) {

    if (jQuery('body').find('#resultLoading').attr('id') != 'resultLoading') {

        jQuery('body').append('<div id="resultLoading" style="display:none"><div><img src="../ajax-loader.jpg"><div>' + text + '</div></div><div class="bg"></div></div>');

    }



    jQuery('#resultLoading').css({

        'width': '100%',

        'height': '100%',

        'position': 'fixed',

        'z-index': '10000000',

        'top': '0',

        'left': '0',

        'right': '0',

        'bottom': '0',

        'margin': 'auto'

    });



    jQuery('#resultLoading .bg').css({

        'background': '#000000',

        'opacity': '0.7',

        'width': '100%',

        'height': '100%',

        'position': 'absolute',

        'top': '0'

    });



    jQuery('#resultLoading>div:first').css({

        'width': '250px',

        'height': '75px',

        'text-align': 'center',

        'position': 'fixed',

        'top': '0',

        'left': '0',

        'right': '0',

        'bottom': '0',

        'margin': 'auto',

        'font-size': '16px',

        'z-index': '10',

        'color': '#ffffff'



    });



    jQuery('#resultLoading .bg').height('100%');

    jQuery('#resultLoading').fadeIn(300);

    jQuery('body').css('cursor', 'wait');

}

function ajaxindicatorstop() {

    jQuery('#resultLoading .bg').height('100%');

    jQuery('#resultLoading').fadeOut(300);

    jQuery('body').css('cursor', 'default');

}


function doUrlPost(x_url, transID) {

    //var kc = checkPopup(x_url)

    //if (kc == "ss") {
   
    postwith(x_url, {
        vtranid: transID
    });


    var serviceBase2 = serviceBaseCld + 'Handlers/UpdatePayment2.ashx';

    //var Encrypt = {
    //    vid: vrootscope
    //}

    //$http({
    //    method: 'POST',
    //    url: serviceBase2,
    //    transformRequest: function (obj) {
    //        var str = [];
    //        for (var p in obj)
    //            str.push(encodeURIComponent(p) + "=" + encodeURIComponent(obj[p]));
    //        return str.join("&");
    //    },
    //    data: Encrypt,
    //    headers: { 'Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8;' }
    //})
    //    .success(function (response) {
    //        postwith(x_url, {
    //            transID: transID, vamount: vamount, vtranid: vtranid, vtype: "backend"
    //        });


    //    })
    //    .error(function (response) {

    //    });




    //}




    //else {


    // }
}


function postwith(to, p) {
    var myForm = document.createElement("form");
    myForm.method = "post";
    myForm.action = to;
    myForm.target = "_blank";


    for (var k in p) {
        var myInput = document.createElement("input");
        myInput.setAttribute("name", k);
        myInput.setAttribute("value", p[k]);
        myForm.appendChild(myInput);
    }
    document.body.appendChild(myForm);
    myForm.submit();

    document.body.removeChild(myForm);


}
