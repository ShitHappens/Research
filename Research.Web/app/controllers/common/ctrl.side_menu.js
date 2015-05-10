function SideMenuCtrl($scope, $location, $element, $urls, ajax, eventService, $rootScope, $routeParams, $window) {

    $scope.init = function () {
        ajax.send({
            Method: {
                Name: 'Account.Read'
            },
            Callback: function (data) {

                var user = data[0].Result.Account;
                $scope.Email = user.Email;
            }
        });
    }
}