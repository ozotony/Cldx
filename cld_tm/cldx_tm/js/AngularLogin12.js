var app = angular.module('myModule', ['smart-table', 'angular-loading-bar', 'ngModal', 'angularUtils.directives.dirPagination']);

var serviceBaseIpo = 'http://ipo.cldng.com/';

//var serviceBaseCld = 'http://tm.cldng.com//'

var serviceBaseCld = 'http://localhost:49703/'

var serviceBasePay = "http://payx.com.ng/X/pay_his2.aspx";

//var serviceBaseCld = 'http://localhost:49703/';
app.filter('offset', function () {
    return function (input, start) {
        start = parseInt(start, 10);
        return input.slice(start);
    };
});


app.factory('beforeUnload', function ($rootScope, $window) {
    // Events are broadcast outside the Scope Lifecycle
    
    $window.onbeforeunload = function (e) {
        var confirmation = {};
        var event = $rootScope.$broadcast('onBeforeUnload', confirmation);
        if (event.defaultPrevented) {
            return confirmation.message;
        }
    };
    
    $window.onunload = function () {
        $rootScope.$broadcast('onUnload');
    };
    return {};
})
.run(function (beforeUnload) {
    // Must invoke the service at least once
});



app.controller('myController2', ['$scope', '$http', '$rootScope', function ($scope, $http, $rootScope) {

    $rootScope.BranchCollect = false;

    $scope.pageno = 1; // initialize page no to 1
    $scope.total_count = 0;
    $scope.itemsPerPage = 100;
    $scope.varray44 = [{ SearchCriteria: 'OAI NUMBER', SearchCriteria: 'OAI NUMBER' }, { SearchCriteria: 'FILE NUMBER', SearchCriteria: 'FILE NUMBER' }, { SearchCriteria: 'PRODUCT TITLE', SearchCriteria: 'PRODUCT TITLE' }, { SearchCriteria: 'APPLICANT NAME', SearchCriteria: 'APPLICANT NAME' }]

    $scope.criteria = "";
    $scope.search = function () {
        $scope.getData($scope.pageno);

    }
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


    $scope.add3 = function (dd, dd2) {
        $scope.payment = [];
        var Encrypt = {
            vid: dd
        }
        var kk = $("#vchk").attr("checked")

        if ($("#vchk").attr("checked")) {

            $http({
                method: 'POST',
                url: serviceBaseCld + 'Handlers/GetBranchCollectPayment2.ashx',
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
            var result = dd.indexOf("-");
            if (result < 0) {

                swal("", "Enter Full Payment Id ", "error");

                return;
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
        if (dd.TransactionId != "") {

            return true;
        }
        else {
            return false;
        }

    }

    $scope.getData = function (pageno) {
        var formData = new FormData();
       
        var AgentsData = {


            criteria: $scope.criteria,
            pageno: pageno,
            status: '8',
            datastatus: 'Certified',
            valueentered: $scope.search_data



        };


        formData.append("vid3", JSON.stringify(AgentsData));
        
      //  formData.append("vid2", $scope.criteria);

        

      //  var jsonData = angular.toJson(event2s);
      //  var objectToSerialize = { 'object': jsonData };




        $http.post(serviceBaseCld + 'Handlers/GetNewData10.ashx', formData, {

            transformRequest: angular.identity,
            headers: { 'Content-Type': undefined }
        })
        .success(function (response) {
            var dd = response;

            $scope.itemsByPage = 100;
            $scope.ListAgent = dd.data;
            $scope.total_count = dd.count;
            $scope.displayedCollection = [].concat($scope.ListAgent);

        })
        .error(function (aa) {

            swal("error")
        });
    }

    $scope.getData($scope.pageno);

    //When you have entire dataset



}]);

app.controller('myController3', ['$scope', '$http', '$rootScope', function ($scope, $http, $rootScope) {

    $rootScope.BranchCollect = false;

    $scope.pageno = 1; // initialize page no to 1
    $scope.total_count = 0;
    $scope.itemsPerPage = 100;
    $scope.varray44 = [{ SearchCriteria: 'OAI NUMBER', SearchCriteria: 'OAI NUMBER' }, { SearchCriteria: 'FILE NUMBER', SearchCriteria: 'FILE NUMBER' }, { SearchCriteria: 'PRODUCT TITLE', SearchCriteria: 'PRODUCT TITLE' }, { SearchCriteria: 'APPLICANT NAME', SearchCriteria: 'APPLICANT NAME' }]

    $scope.criteria = "";
    $scope.search = function () {
        $scope.getData($scope.pageno);

    }
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


    $scope.add3 = function (dd, dd2) {
        $scope.payment = [];
        var Encrypt = {
            vid: dd
        }
        var kk = $("#vchk").attr("checked")

        if ($("#vchk").attr("checked")) {

            $http({
                method: 'POST',
                url: serviceBaseCld + 'Handlers/GetBranchCollectPayment2.ashx',
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
        if (dd.TransactionId != "") {

            return true;
        }
        else {
            return false;
        }

    }

    $scope.getData = function (pageno) {
        var formData = new FormData();

        var AgentsData = {


            criteria: $scope.criteria,
            pageno: pageno,
            status: '7',
            datastatus: 'Not Opposed',
            valueentered: $scope.search_data



        };


        formData.append("vid3", JSON.stringify(AgentsData));

        //  formData.append("vid2", $scope.criteria);



        //  var jsonData = angular.toJson(event2s);
        //  var objectToSerialize = { 'object': jsonData };




        $http.post(serviceBaseCld + 'Handlers/GetNewData10.ashx', formData, {

            transformRequest: angular.identity,
            headers: { 'Content-Type': undefined }
        })
        .success(function (response) {
            var dd = response;

            $scope.itemsByPage = 100;
            $scope.ListAgent = dd.data;
            $scope.total_count = dd.count;
            $scope.displayedCollection = [].concat($scope.ListAgent);

        })
        .error(function (aa) {

            swal("error")
        });
    }

    $scope.getData($scope.pageno);

    //When you have entire dataset



}]);

app.controller('myController4', ['$scope', '$http', '$rootScope', function ($scope, $http, $rootScope) {

    $rootScope.BranchCollect = false;

    $scope.pageno = 1; // initialize page no to 1
    $scope.total_count = 0;
    $scope.itemsPerPage = 100;
    $scope.varray44 = [{ SearchCriteria: 'OAI NUMBER', SearchCriteria: 'OAI NUMBER' }, { SearchCriteria: 'FILE NUMBER', SearchCriteria: 'FILE NUMBER' }, { SearchCriteria: 'PRODUCT TITLE', SearchCriteria: 'PRODUCT TITLE' }, { SearchCriteria: 'APPLICANT NAME', SearchCriteria: 'APPLICANT NAME' }]

    $scope.criteria = "";
    $scope.search = function () {
        $scope.getData($scope.pageno);

    }
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


    $scope.add3 = function (dd, dd2) {
        $scope.payment = [];
        var Encrypt = {
            vid: dd
        }
        var kk = $("#vchk").attr("checked")

        if ($("#vchk").attr("checked")) {

            $http({
                method: 'POST',
                url: serviceBaseCld + 'Handlers/GetBranchCollectPayment2.ashx',
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
        if (dd.TransactionId != "") {

            return true;
        }
        else {
            return false;
        }

    }


    $scope.changeValue2 = function () {
        event2s = []
        var vcount = 0;
        angular.forEach($scope.displayedCollection, function (item) {
            var User_Status = new Object();
            if (item.description == true) {
                User_Status.online_id = item.oai_no;
                User_Status.Status = "Published"

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

            swal("", "Record Updated Successfully", "success")
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
    $scope.getData = function (pageno) {
        var formData = new FormData();

        var AgentsData = {


            criteria: $scope.criteria,
            pageno: pageno,
            status: '6',
            datastatus: 'Published',
            valueentered: $scope.search_data



        };


        formData.append("vid3", JSON.stringify(AgentsData));

        //  formData.append("vid2", $scope.criteria);



        //  var jsonData = angular.toJson(event2s);
        //  var objectToSerialize = { 'object': jsonData };




        $http.post(serviceBaseCld + 'Handlers/GetNewData10.ashx', formData, {

            transformRequest: angular.identity,
            headers: { 'Content-Type': undefined }
        })
        .success(function (response) {
            var dd = response;

            $scope.itemsByPage = 100;
            $scope.ListAgent = dd.data;
            $scope.total_count = dd.count;
            $scope.displayedCollection = [].concat($scope.ListAgent);

        })
        .error(function (aa) {

            swal("error")
        });
    }

    $scope.getData($scope.pageno);

    //When you have entire dataset



}]);

app.controller('myController5', ['$scope', '$http', '$rootScope', '$window', function ($scope, $http, $rootScope, $window) {
    $scope.total_count = 0;
  
    $scope.$on('onBeforeUnload', function (e, confirmation) {
        confirmation.message = "All data willl be lost.";
        e.preventDefault();
    });
    $scope.$on('onUnload', function (e) {
        alert("aa")
        console.log('leaving page'); // Use 'Preserve Log' option in Console
    });

  

    //When you have entire dataset



}]);



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
