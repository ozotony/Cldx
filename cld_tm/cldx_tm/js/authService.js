'use strict';
var app = angular.module('PayXAuthApp');
app.factory('authService', ['$http', '$q', '$rootScope',  function ($http, $q, $rootScope) {
    var serviceBase = 'http://localhost:31530/api/Bt/';

    var _saveRegistration = function (registration) {
        // _logOut();
        return $http.post(serviceBase + 'PostPersonalInfo', registration, {
            transformRequest: angular.identity,
            headers: { 'Content-Type': undefined }
        }).then(function (response) {
            return response;
        });
    };
    var _checkAvailable = function (registration) {
        // _logOut();
        return $http.post(serviceBase + 'CheckAvailability', registration, {
            transformRequest: angular.identity,
            headers: { 'Content-Type': undefined }
        }).then(function (response) {
            return response;
        });
    };
   
    authServiceFactory.saveRegistration = _saveRegistration;
    authServiceFactory.checkAvailable = _checkAvailable;
    
    return authServiceFactory;
} ])