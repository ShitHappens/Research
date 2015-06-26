function HeadCtrl($scope, $location, $element, $urls, ajax, eventService, $rootScope, $routeParams, $window) {

    $scope.$watch('$location', function () {
        $scope.Page = SetTitle($location.path());
    });

    $scope.$on('$routeChangeStart', function (next, current) {
        if (current.$$route !== undefined)
            $scope.Page = SetTitle(current.$$route.originalPath);
    });

    function SetTitle(path) {

        switch (path) {
            case $urls.Test():
                return 'Test';
                break
            case $urls.Login():
                return 'Login';
                break
            case $urls.Register():
                return 'Registration';
                break
            case $urls.Profile():
                return 'Profile';
                break
            case $urls.Dashboard():
                return 'Dashboard';
                break
            case $urls.Question():
                return 'Question';
                break
        }
    }


    $scope.init = function () {
        $scope.Page = SetTitle($location.path());
    }
}