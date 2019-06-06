var app = angular.module('formApp', ['ngWig']);
var serviceBaseIpo = 'http://ipo.cldng.com/';

var serviceBaseCld = 'http://tm.cldng.com/'

//var serviceBaseCld = 'http://5.77.54.44/EinaoTestEnvironment.CLD/'





app.controller('formController2', function ($scope, $rootScope, $http, $location) {

    $(document).ready(function () {

        //$scope.xname = $("input#xname2").val();
        //$scope.xname2 = $("input#xname3").val();

    });

    $scope.Payment_Reference = "";
    // we will store all of our form data in this object
    $scope.formData = {};
    $scope.EmailSubject =""
    $scope.model = {};
    $scope.content = "";
    var selectedVal = "";
    $(".table").hide();
    var selected = $("#rbValid input[type='radio']:checked");
    if (selected.length > 0) {
        //  alert(selected.val())
        if (selected.val() == "Ping") {


            $("#Verify").hide();
            $(".table").show();
            //  $("#rich").show();

            $("#comment").hide();

           // var vurl = serviceBaseIpo + "A/SearchTradeMark.aspx#/form/search?MessageID=" + $("input#xname3").val();
           // var vtarget = "blank";

            //  $scope.model.content = "<b> AGENT CODE  </b> :<span>" + $("input#xname6").val() + "</span> <br/> <b> TRADEMARK NAME  </b> :<span>" + $("input#xname2").val() + "</span> <br/> <b> FILE NUMBER   </b> :<span>" + $("input#xname3").val() + "<br/> "

           // $scope.model.content = "<b> AGENT CODE  </b> :<span>" + $("input#xname6").val() + "</span> <br/> <b> TRADEMARK NAME  </b> :<span>" + $("input#xname2").val() + "</span> <br/> <b> FILE NUMBER   </b> :<span>" + $("input#xname3").val() + "<br/> <b> TRADEMARK  UPLOAD URL  </b> :  <a target='" + vtarget + "'  href='" + vurl + "'  >click link to view Application  </a> <br/><b> ONLINE APPLICATION ID  </b> :<span>" + $("input#xname4").val() + "</span> ";

            //  $scope.dialogShown = true;


        }

        else if (selected.val() == "Invalid") {

            $("#Verify").show();

            $(".table").hide();

            $("#comment").show();


        }

        else if (selected.val() == "Valid") {

            $("#Verify").show();

            $(".table").hide();

            $("#comment").show();


        }



        else if (selected.val() == "Treated") {

            $("#Verify").show();

            $(".table").hide();

            $("#comment").show();


        }

        else if (selected.val() == "Kiv") {

            $("#Verify").show();

            $(".table").hide();

            $("#comment").show();


        }



        else {



        }
        // alert(selected.val())
        //  selectedVal = selected.val();
    }
    // $scope.dialogShown = true;
    $scope.add3 = function (vv) {
        var serviceBase = serviceBaseCld + 'Handlers/AddEmail2.ashx';
        var pp3 = "Verification KIV Information"
        var xname = $("input#xname").val();
        var subject = $("input#emailaddress").val();
        var applicantEmail = $("input#xname5").val();


        var Encrypt = {
            vid: vv,
            vid2: xname,
            vid3: subject,
            vid4: applicantEmail
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
                //  $rootScope.vcount = response

                swal({
                    title: "Email Sent  Successfully",
                    text: "",
                    type: "success",
                    showCancelButton: false,
                    confirmButtonColor: "#DD6B55", confirmButtonText: "OK!",
                    cancelButtonText: "No, cancel please!",
                    closeOnConfirm: true,
                    closeOnCancel: true
                },
                    function (isConfirm) {
                        if (isConfirm) {

                            window.location.assign("Kiv_Data.aspx");


                        }

                    });


                //  IpoTradeMarks2(response.Email, response.Firstname, response.CompanyAddress, response.xid, response.PhoneNumber)
                //  ajaxindicatorstop();

            })
            .error(function (response) {

                var ds = response;
                //  ajaxindicatorstop();
            });



    }
    $(document).ready(function () {
        var selectedVal = "";



    });




});