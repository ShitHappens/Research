'use strict';

angular.module('helper.access', []).

factory('$access', function ($location, $localStorage) {
    var $access = {};

    $access.isLogin = function () {

        var isLogin = ($location.url() === '/login');

        if (!isLogin && $localStorage.SessionID() === undefined) {
            $location.url('/login');
        }
        else if (isLogin && $localStorage.SessionID() !== undefined) {
            $location.url('/profile');

        }
    }

    return $access;
});