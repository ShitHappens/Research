'use strict';

angular.module('helper.storage', []).
factory('$localStorage', function ($location) {
    var $localStorage = {};

    $localStorage.Item = function (key, value) {
        if (value !== undefined) {
            localStorage[key] = value;
        }
        return localStorage[key];
    }

    $localStorage.SessionID = function (value) {
        return $localStorage.Item('SessionID', value);
    }

    $localStorage.Email = function (value) {
        return $localStorage.Item('Email', value);
    }

    return $localStorage;
}).
factory('$sessionStorage', function ($location) {
    var $sessionStorage = {};

    $sessionStorage.Item = function (key, value) {
        if (value !== undefined) {
            sessionStorage[key] = value;
        }
        return sessionStorage[key];
    }

    return $sessionStorage;
});