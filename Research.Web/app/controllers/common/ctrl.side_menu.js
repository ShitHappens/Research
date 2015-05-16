function SideMenuCtrl($scope, $location, $element, $urls, ajax, eventService, $rootScope, $routeParams, $window) {

    $scope.$watch('$location', function () {
        HighLight($location.path());
    });

    $scope.$on('$routeChangeStart', function (next, current) {
        HighLight(current.$$route.originalPath);
    });

    HighLight($location.path());

    function HighLight(path) {

        $element.find('li').removeClass('active');

        switch (path) {
            case $urls.Test():
                angular.element('#test').addClass('active');
                break
            case $urls.Profile():
                angular.element('#profile').addClass('active');
                break
        }
    }


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