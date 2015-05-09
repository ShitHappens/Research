'use strict';

angular.module('helper.access', []).

factory('$access', function ($location, $localStorage) {
    var $access = {};

    $access.isLogin = function (hasToken) {
        var isLogin = ($location.url() === '/login');

        if (!isLogin && $localStorage.SessionID() === undefined) {
            $location.url('/login');
        }
        else if (isLogin && $localStorage.SessionID() !== undefined) {
            if (hasToken === false)
                $location.url('/profile');
            else
                $location.url('/dashboard');

        }
    }

    return $access;
});