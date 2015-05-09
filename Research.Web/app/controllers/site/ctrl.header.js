﻿function HeaderCtrl($scope, $location, ajax, $access, $localStorage, $route, $window, $window, $urls, $element, $routeParams) {

    $scope.users = [];

    $scope.selection = "";

    $scope.init = function () {

    }

    $scope.logout = function () {
        var method = { Name: 'Account.Logout' };
        ajax.send({
            Method: method,
            Callbacks: [{
                F: function () {
                    localStorage.clear();
                    $access.isLogin();
                }
            }]
        });
    }

    $scope.goToProfile = function () {
        $location.path('/profile');
    }

}