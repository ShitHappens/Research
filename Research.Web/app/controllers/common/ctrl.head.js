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
            //case $urls.Dashboard():
            //    return 'Dashboard';
            //    break
            //case $urls.Category():
            //    return 'Category Report';
            //    break
            //case $urls.Product():
            //    return 'Product Report';
            //    break
            //case $urls.Country():
            //    return 'Country Report';
            //    break
            //case $urls.Site():
            //    return 'Site Report';
            //    break
            //case $urls.Store():
            //    return 'Store Report';
            //    break
            //case $urls.Buyers():
            //    return 'Buyers Report';
            //    break
            //case $urls.Login():
            //    return 'Login';
            //    break
            //case $urls.Register():
            //    return 'Registration';
            //    break
            //case $urls.Request():
            //    return 'Password Request';
            //    break
            case $urls.Profile():
                return 'Profile';
                break
            //case $urls.Users():
            //    return 'Admin - Users';
            //    break
            //case $urls.Admins():
            //    return 'Admin - Admins';
            //    break
            //case $urls.Currencies():
            //    return 'Admin - Currencies';
            //    break
            //case $urls.Assemblies():
            //    return 'Admin - Assemblies';
            //    break
            //case $urls.AdminProfile():
            //    return 'Admin - AdminProfile';
            //    break
            //case $urls.Order():
            //    return 'Orders';
            //    break
            //case $urls.Items():
            //    return 'Live Items';
            //    break
            //case $urls.ItemsSpreadsheet():
            //    return 'Live Items Spreadsheet';
            //    break
        }
    }




    $scope.init = function () {
        $scope.Page = SetTitle($location.path());


    }
}