var app = angular.module('formApp', ['ngAnimate', 'ui.router', 'angular-loading-bar']);

var serviceBaseIpo = 'http://ipo.cldng.com/';

var serviceBaseCld = 'http://tm.cldng.com/';
//var serviceBaseCld = 'http://localhost:49703/';
// configuring our routes 
// =============================================================================
app.config(function ($stateProvider, $urlRouterProvider) {

    $stateProvider

        // route to show our basic form (/form)
        .state('form', {
            url: '/form',
            templateUrl: 'form.html',
            controller: 'formController'
        })

        // nested states 
        // each of these sections will have their own view
        // url will be nested (/form/profile)
        .state('form.payment', {
            url: '/payment',
            templateUrl: 'Change_Name_Detail.html'
        })

        // url will be /form/interests
        .state('form.transaction', {
            url: '/transaction',
            templateUrl: 'Change_Name_Detail2.html'
        })

        // url will be /form/payment
       

    // catch all route
    // send users to the form page 
    $urlRouterProvider.otherwise('/form/payment?name');
})

// our controller for the form
// =============================================================================
.controller('formController', function ($scope, $state,$rootScope, $http, $stateParams,$location) {

   
 
    $scope.Payment_Reference = "";
    // we will store all of our form data in this object
    $scope.formData = {};

    $scope.formData.vname = $location.search().name;

    $scope.add2 = function (vrow) {

        $rootScope.xid= vrow.xid
        $state.go('form.transaction')
    }

    $scope.add = function () {

        //   $state.go('form.transaction')

        var Encrypt = {
            vv: $scope.formData.Payment_Reference
        }

        $http({
            method: 'POST',
            url: serviceBaseCld +'Handlers/GetPaymentExist.ashx',
           // url: 'http://localhost:49703/Handlers/GetPaymentExist.ashx',
            transformRequest: function (obj) {
                var str = [];
                for (var p in obj)
                    str.push(encodeURIComponent(p) + "=" + encodeURIComponent(obj[p]));
                return str.join("&");
            },
            data: Encrypt,

            headers: { 'Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8;' }

        }).success(function (response) {

            var    dd2 =parseInt( response);



            if (dd2 > 0) {

                swal("Transaction is Used", "Transaction Id  Has been Used", "error");

                $scope.formData.Payment_Reference = "";

                return;


            }

            else {
                if ($scope.formData.BranchCollect) {

                    $http({
                        method: 'POST',
                        url: serviceBaseCld +  'Handlers/GetBranchCollectPayment.ashx',
                      //  url: 'http://localhost:49703/Handlers/GetBranchCollectPayment.ashx',
                        transformRequest: function (obj) {
                            var str = [];
                            for (var p in obj)
                                str.push(encodeURIComponent(p) + "=" + encodeURIComponent(obj[p]));
                            return str.join("&");
                        },
                        data: Encrypt,

                        headers: { 'Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8;' }

                    }).success(function (response) {

                        dd = response;



                        if (dd.length > 0) {

                            $scope.itemsByPage = 50;
                            $scope.ListAgent = response;
                            $scope.displayedCollection = [].concat($scope.ListAgent);

                            $scope.formData.tot_amt = response[0].tot_amt;


                        }

                        //  $scope.states = data;
                    }).error(function (data, status, headers, config) {
                        $scope.message = 'Unexpected Error';
                    });


                }

                else if ($scope.formData.vname == "Change_Name" || $scope.formData.vname == "Change_Address") {

                    $http({
                        method: 'POST',
                        url: serviceBaseCld  +'Handlers/GetPayment2.ashx',
                        //  url: 'http://localhost:49703/Handlers/GetPayment2.ashx',
                        transformRequest: function (obj) {
                            var str = [];
                            for (var p in obj)
                                str.push(encodeURIComponent(p) + "=" + encodeURIComponent(obj[p]));
                            return str.join("&");
                        },
                        data: Encrypt,

                        headers: { 'Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8;' }

                    }).success(function (response) {

                        dd = response;



                        if (dd.length > 0) {

                            $scope.itemsByPage = 50;
                            $scope.ListAgent = response;
                            $scope.displayedCollection = [].concat($scope.ListAgent);

                            $scope.formData.tot_amt = response[0].tot_amt;


                        }

                        //  $scope.states = data;
                    }).error(function (data, status, headers, config) {
                        $scope.message = 'Unexpected Error';
                    });


                }

               else  if ($scope.formData.vname == "Form16" || $scope.formData.vname == "Form17") {

                    $http({
                        method: 'POST',
                        url: serviceBaseCld  +'Handlers/GetPayment4.ashx',
                        transformRequest: function (obj) {
                            var str = [];
                            for (var p in obj)
                                str.push(encodeURIComponent(p) + "=" + encodeURIComponent(obj[p]));
                            return str.join("&");
                        },
                        data: Encrypt,

                        headers: { 'Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8;' }

                    }).success(function (response) {

                        dd = response;



                        if (dd.length > 0) {

                            $scope.itemsByPage = 50;
                            $scope.ListAgent = response;
                            $scope.displayedCollection = [].concat($scope.ListAgent);

                            $scope.formData.tot_amt = response[0].tot_amt;


                        }

                        //  $scope.states = data;
                    }).error(function (data, status, headers, config) {
                        $scope.message = 'Unexpected Error';
                    });


                }
               else  if ($scope.formData.vname == "Rectification") {

                    $http({
                        method: 'POST',
                        url: serviceBaseCld  +'Handlers/GetPayment3.ashx',
                        transformRequest: function (obj) {
                            var str = [];
                            for (var p in obj)
                                str.push(encodeURIComponent(p) + "=" + encodeURIComponent(obj[p]));
                            return str.join("&");
                        },
                        data: Encrypt,

                        headers: { 'Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8;' }

                    }).success(function (response) {

                        dd = response;



                        if (dd.length > 0) {

                            $scope.itemsByPage = 50;
                            $scope.ListAgent = response;
                            $scope.displayedCollection = [].concat($scope.ListAgent);

                            $scope.formData.tot_amt = response[0].tot_amt;


                        }

                        //  $scope.states = data;
                    }).error(function (data, status, headers, config) {
                        $scope.message = 'Unexpected Error';
                    });


                }


               else  if ($scope.formData.vname == "Renewal") {

                    $http({
                        method: 'POST',
                        url: serviceBaseCld  +'Handlers/GetPayment5.ashx',
                        transformRequest: function (obj) {
                            var str = [];
                            for (var p in obj)
                                str.push(encodeURIComponent(p) + "=" + encodeURIComponent(obj[p]));
                            return str.join("&");
                        },
                        data: Encrypt,

                        headers: { 'Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8;' }

                    }).success(function (response) {

                        dd = response;



                        if (dd.length > 0) {

                            $scope.itemsByPage = 50;
                            $scope.ListAgent = response;
                            $scope.displayedCollection = [].concat($scope.ListAgent);

                            $scope.formData.tot_amt = response[0].tot_amt;


                        }

                        //  $scope.states = data;
                    }).error(function (data, status, headers, config) {
                        $scope.message = 'Unexpected Error';
                    });


               }


               else if ($scope.formData.vname == "Form47") {

                   $http({
                       method: 'POST',
                       url: serviceBaseCld + 'Handlers/GetPayment6.ashx',
                       transformRequest: function (obj) {
                           var str = [];
                           for (var p in obj)
                               str.push(encodeURIComponent(p) + "=" + encodeURIComponent(obj[p]));
                           return str.join("&");
                       },
                       data: Encrypt,

                       headers: { 'Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8;' }

                   }).success(function (response) {

                       dd = response;



                       if (dd.length > 0) {

                           $scope.itemsByPage = 50;
                           $scope.ListAgent = response;
                           $scope.displayedCollection = [].concat($scope.ListAgent);

                           $scope.formData.tot_amt = response[0].tot_amt;


                       }

                       //  $scope.states = data;
                   }).error(function (data, status, headers, config) {
                       $scope.message = 'Unexpected Error';
                   });


               }


            }

            //  $scope.states = data;
        }).error(function (data, status, headers, config) {
            $scope.message = 'Unexpected Error';
        });

      


    }


   


    $scope.add3 = function () {
        var vk = $scope.formData.OnlineNumber;


        var serviceBase = serviceBaseCld  +'Handlers/GetCertificate.ashx';

      //  var serviceBase = 'http://localhost:49703/Handlers/GetCertificate.ashx';

      
        var Encrypt = {
            vid: vk
        }

        $http({
            method: 'POST',
            url: serviceBase,
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
                var dd = [];

                dd = response;

              //  alert("result=" + response)

                //if (dd.length > 0 && dd[0].TransactionId != "") {


                //    swal("Oops...", "This Certificate  Has Been Paid For", "error");
                //    return;
                //}
                //alert("length =" + dd.length)
                if (dd.length > 0) {

                    $scope.itemsByPage = 50;
                    $scope.ListAgent = response;
                    $scope.displayedCollection2 = [].concat($scope.ListAgent);

                    $scope.formData.Id = response[0].id

                  

                }

                else {

                    swal("Oops...", "Invalid Online Number!", "error");

                    $scope.displayedCollection2 = [];
                    $scope.ListAgent = [];
                }
                //  IpoTradeMarks2(response.Email, response.Firstname, response.CompanyAddress, response.xid, response.PhoneNumber)
                //  ajaxindicatorstop();

            })
            .error(function (response) {
                ajaxindicatorstop();
            });

    }

    $scope.add4 = function (d) {

       

        var serviceBase = serviceBaseCld  +'Handlers/UpdatePayment.ashx';

       //   var serviceBase = 'http://localhost:49703/Handlers/GetCertificate.ashx';

        //var dd = checkPopup();

        //alert(dd)

        //var Encrypt = {
        //    vid: $scope.formData.Payment_Reference
        //}

       



        //if ($scope.formData.vname == "Renewal") {

          
        //    var kk = checkPopup(serviceBaseCld  +"admin/tm/Change_Renewal.aspx")

        //    if (kk == "false") {

        //        swal("Pop Is Enabled For This Browser ,Kindly Disable To Continue")

        //        return false;
        //    }


         

          

        //}

        if ($scope.formData.BranchCollect) {

            if ($scope.formData.vname == "Change_Name") {
                doUrlPost(serviceBaseCld + "admin/tm/Change_ApplicantName.aspx", $scope.formData.Id, $scope.formData.tot_amt, $scope.formData.Payment_Reference, $rootScope.xid)

                // doUrlPost("http://localhost:49703/admin/tm/Change_ApplicantName.aspx", $scope.formData.Id, $scope.formData.tot_amt, $scope.formData.Payment_Reference, $rootScope.xid)

            }

            if ($scope.formData.vname == "Change_Address") {
                doUrlPost(serviceBaseCld  +"admin/tm/Change_ApplicantAddress.aspx", $scope.formData.Id, $scope.formData.tot_amt, $scope.formData.Payment_Reference, $rootScope.xid)
            }

            if ($scope.formData.vname == "Rectification") {
                doUrlPost(serviceBaseCld  +"admin/tm/Change_Rectification.aspx", $scope.formData.Id, $scope.formData.tot_amt, $scope.formData.Payment_Reference, $rootScope.xid)
            }

            if ($scope.formData.vname == "Form16") {
                doUrlPost(serviceBaseCld  +"admin/tm/Change_Assignment2.aspx", $scope.formData.Id, $scope.formData.tot_amt, $scope.formData.Payment_Reference, $rootScope.xid)
            }

            if ($scope.formData.vname == "Form17") {
                doUrlPost(serviceBaseCld  +"admin/tm/Change_Assignment3.aspx", $scope.formData.Id, $scope.formData.tot_amt, $scope.formData.Payment_Reference, $rootScope.xid)
            }

            if ($scope.formData.vname == "Renewal") {
                doUrlPost(serviceBaseCld  +"admin/tm/Change_Renewal.aspx", $scope.formData.Id, $scope.formData.tot_amt, $scope.formData.Payment_Reference, $rootScope.xid)
            }

            if ($scope.formData.vname == "Form47") {
                doUrlPost(serviceBaseCld + "admin/tm/RegisteredUser.aspx", $scope.formData.Id, $scope.formData.tot_amt, $scope.formData.Payment_Reference, $rootScope.xid)
            }
            $scope.formData = {};
            $scope.displayedCollection2 = [];
            $scope.displayedCollection = [];


        }

        else {

            var Encrypt = {
                vid: $rootScope.xid
            }

            $http({
                method: 'POST',
                url: serviceBase,
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
                    if ($scope.formData.vname == "Change_Name") {
                        doUrlPost(serviceBaseCld  +"admin/tm/Change_ApplicantName.aspx", $scope.formData.Id, $scope.formData.tot_amt, $scope.formData.Payment_Reference, $rootScope.xid)

                        // doUrlPost("http://localhost:49703/admin/tm/Change_ApplicantName.aspx", $scope.formData.Id, $scope.formData.tot_amt, $scope.formData.Payment_Reference, $rootScope.xid)

                    }

                    if ($scope.formData.vname == "Change_Address") {
                        doUrlPost(serviceBaseCld  +"admin/tm/Change_ApplicantAddress.aspx", $scope.formData.Id, $scope.formData.tot_amt, $scope.formData.Payment_Reference, $rootScope.xid)
                    }

                    if ($scope.formData.vname == "Rectification") {
                        doUrlPost(serviceBaseCld  +"admin/tm/Change_Rectification.aspx", $scope.formData.Id, $scope.formData.tot_amt, $scope.formData.Payment_Reference, $rootScope.xid)
                    }

                    if ($scope.formData.vname == "Form16") {
                        doUrlPost(serviceBaseCld  +"admin/tm/Change_Assignment2.aspx", $scope.formData.Id, $scope.formData.tot_amt, $scope.formData.Payment_Reference, $rootScope.xid)
                    }

                    if ($scope.formData.vname == "Form17") {
                        doUrlPost(serviceBaseCld  +"admin/tm/Change_Assignment3.aspx", $scope.formData.Id, $scope.formData.tot_amt, $scope.formData.Payment_Reference, $rootScope.xid)
                    }

                    if ($scope.formData.vname == "Renewal") {
                        doUrlPost(serviceBaseCld  +"admin/tm/Change_Renewal.aspx", $scope.formData.Id, $scope.formData.tot_amt, $scope.formData.Payment_Reference, $rootScope.xid)
                    }

                    if ($scope.formData.vname == "Form47") {
                        doUrlPost(serviceBaseCld + "admin/tm/RegisteredUser.aspx", $scope.formData.Id, $scope.formData.tot_amt, $scope.formData.Payment_Reference, $rootScope.xid)
                    }
                    $scope.formData = {};
                    $scope.displayedCollection2 = [];
                    $scope.displayedCollection = [];
                })
                .error(function (response) {
                    ajaxindicatorstop();
                });

        }


    }
    // function to process the form
    $scope.processForm = function () {
        alert('awesome!');
    };


    function doUrlPost(x_url, transID, vamount, vtranid, vrootscope) {

        //var kc = checkPopup(x_url)
     
        //if (kc == "ss") {

        postwith(x_url, {
            transID: transID, vamount: vamount, vtranid: vtranid, vtype: "backend"
        });

         
            var serviceBase2 = serviceBaseCld  +'Handlers/UpdatePayment2.ashx';

    }

});



function checkPopup( t) {
    var openWin = window.open(" \'" + t + "\'", "directories=no,height=100,width=100,menubar=no,resizable=no,scrollbars=no,status=no,titlebar=no,top=0,location=no");

    var openWin = window.open("http://www.cnn.com", "directories=no,height=100,width=100,menubar=no,resizable=no,scrollbars=no,status=no,titlebar=no,top=0,location=no");

    popupBlockerChecker.check(openWin);
    // alert("Opening Page In New Window")
   

    if (!openWin) {
        return "ss"
       // alert("A popup blocker was detected. Please Remove popupblocker for this site");
    } else {


       
        return "tt"
       //  alert("No popup blocker dectected");
    }
    //if (!openWin) {
    //    return "false"
    //  //  alert("A popup blocker was detected. Please Remove popupblocker for this site");
    //} else {


    //    openWin.close();
    //    return "true"
    //  //  alert("No popup blocker dectected");
    //}
}

function postwith(to, p) {
    var myForm = document.createElement("form");
    myForm.method = "post";
    myForm.action = to;
   // myForm.target = "_blank";
  

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


function OpenWindowWithPost(url, windowoption, name, params) {
    var form = document.createElement("form");
    form.setAttribute("method", "post");
    form.setAttribute("action", url);
    form.setAttribute("target", name);
    for (var i in params) {
        if (params.hasOwnProperty(i)) {
            var input = document.createElement('input');
            input.type = 'hidden';
            input.name = i;
            input.value = params[i];
            form.appendChild(input);
        }
    }
    document.body.appendChild(form);
    //note I am using a post.htm page since I did not want to make double request to the page
    //it might have some Page_Load call which might screw things up.
    window.open("post.htm", name, windowoption);
    form.submit();
    document.body.removeChild(form);
}

var popupBlockerChecker = {
    check: function (popup_window) {
        var _scope = this;
        if (popup_window) {
            if (/chrome/.test(navigator.userAgent.toLowerCase())) {
                setTimeout(function () {
                    _scope._is_popup_blocked(_scope, popup_window);
                }, 200);
            } else {
                popup_window.onload = function () {
                    _scope._is_popup_blocked(_scope, popup_window);
                };
            }
        } else {
            _scope._displayError();
        }
    },
    _is_popup_blocked: function (scope, popup_window) {
        if ((popup_window.innerHeight > 0) == false) { scope._displayError(); }
    },
    _displayError: function () {
        alert("Popup Blocker is enabled! Please add this site to your exception list.");
    }
};
