function SideMenuCtrl($scope, $location, $element, $urls, ajax, eventService, $rootScope, $routeParams, $window) {

    //$scope.menulist = [];

    //var userSideMenu = [{ Name: 'Dashboard', id: 'dashboard', url: '#' + $urls.Dashboard() }
    //    , { Name: 'Category report', id: 'category', url: '#' + $urls.Category() }
    //    , { Name: 'Product report', id: 'product', url: '#' + $urls.Product() }
    //    , { Name: 'Country report', id: 'country', url: '#' + $urls.Country() }
    //    , { Name: 'Site report', id: 'site', url: '#' + $urls.Site() }
    //    , { Name: 'Store report', id: 'store', url: '#' + $urls.Store() }
    //    //, { Name: 'Buyers report', id: 'buyers', url: '#' + $urls.Buyers() }
    //    , { Name: '', id: '', url: '', disabled: 'disabled' }
    //    , { Name: 'Order Labels', id: 'orders', url: '#' + $urls.Order() }
    //    , { Name: 'Live Items', id: 'items', url: '#' + $urls.Items() }
    //    , { Name: 'Live Items Spreadsheet', id: 'itemsSpreadsheet', url: '#' + $urls.ItemsSpreadsheet() }
    //];

    //var adminSideMenu = [{ Name: 'Users', id: 'users', url: '#' + $urls.Users() }
    //    , { Name: 'Admins', id: 'admins', url: '#' + $urls.Admins() }
    //    , { Name: 'Currencies', id: 'currencies', url: '#' + $urls.Currencies() }
    //    , { Name: 'Assemblies', id: 'assemblies', url: '#' + $urls.Assemblies() }
    //, { Name: 'Invites', id: 'invites', url: '#' + $urls.Invites() }];


    ////$scope.$on('$rootScope', function () {
    ////    SideMenuContent();
    ////});


    $scope.init = function () {

        //$scope.hasEmailToReview = localStorage.getItem('EmailToReview');

        //ajax.send(
        //    {
        //        Method: { Name: 'Account.Read' },
        //        Callbacks: [{
        //            Params: ['Users'],
        //            F: function (Users) {
        //                $scope.url = '#' + $location.path();
        //                $scope.isAdmin = Users[0].IsAdmin;
        //                $scope.isSubs = Users[0].IsSubs;

        //                if (Users[0].IsAdmin === 0)
        //                    $scope.hasStore = Users[0].HasStore;
        //            }
        //        }]
        //    }
        //    );

        //angular.element('#users').addClass('active');
        //SideMenuContent($location.path());
        //$scope.showToAdmin = SideMenuContent($location.path());
        //HighLight($location.path());
    }

    //$scope.$watch('$location', function () {
    //    SideMenuContent($location.path());
    //    $scope.showToAdmin = SideMenuContent($location.path());
    //    HighLight($location.path());
    //});

    //$scope.$on('$routeChangeStart', function (next, current) {
    //    SideMenuContent(current.$$route.originalPath);
    //    $scope.showToAdmin = SideMenuContent(current.$$route.originalPath);
    //    HighLight(current.$$route.originalPath);
    //});

    //$scope.toUsers = function () {
    //    $location.path('/users');
    //    localStorage.removeItem('EmailToReview');
    //    angular.element('#th').val('');
    //    //$window.location.replace('#/users').reload();
    //}

    //HighLight($location.path());
    //SideMenuContent($location.path());
    ////SideMenuContent();
    //function HighLight(path) {

    //    $element.find('li').removeClass('active');

    //    switch (path) {
    //        case $urls.Dashboard():
    //            angular.element('#dashboard').addClass('active');
    //            break
    //        case $urls.Category():
    //        case $urls.Category() + '/:categoryid':
    //        case $urls.Category() + '/' + $routeParams.categoryid:
    //            angular.element('#category').addClass('active');
    //            break
    //        case $urls.Product():
    //            angular.element('#product').addClass('active');
    //            break
    //        case $urls.Country():
    //            angular.element('#country').addClass('active');
    //            break
    //        case $urls.Site():
    //            angular.element('#site').addClass('active');
    //            break
    //        case $urls.Store():
    //        case $urls.Store() + '/:customcategoryid':
    //        case $urls.Store() + '/' + $routeParams.customcategoryid:
    //        case $urls.Store():
    //            angular.element('#store').addClass('active');
    //            break
    //        case $urls.Buyers():
    //            angular.element('#buyers').addClass('active');
    //            break
    //        case $urls.Order():
    //            angular.element('#orders').addClass('active');
    //            break
    //        case $urls.Items():
    //            angular.element('#items').addClass('active');
    //            break
    //        case $urls.Items():
    //            angular.element('#itemsSpreadsheet').addClass('active');
    //            break
    //        case $urls.Users():
    //            angular.element('#users').addClass('active');
    //            break
    //        case $urls.Admins():
    //            angular.element('#admins').addClass('active');
    //            break
    //        case $urls.Currencies():
    //            angular.element('#currencies').addClass('active');
    //            break
    //        case $urls.Assemblies():
    //            angular.element('#assemblies').addClass('active');
    //            break
    //        case $urls.Invites():
    //            angular.element('#invites').addClass('active');
    //            break
    //    }
    //}

    //function SideMenuContent(path) {
    //    switch (path) {

    //        case $urls.Dashboard():
    //        case $urls.Category():
    //        case $urls.Category() + '/:categoryid':
    //        case $urls.Category() + '/' + $routeParams.categoryid:
    //        case $urls.Product():
    //        case $urls.Country():
    //        case $urls.Site():
    //        case $urls.Store():
    //        case $urls.Store() + '/:customcategoryid':
    //        case $urls.Store() + '/' + $routeParams.customcategoryid:
    //        case $urls.Buyers():
    //        case $urls.Order():
    //        case $urls.Items():
    //        case $urls.ItemsSpreadsheet():
    //        case $urls.Profile():
    //        case $urls.Subscription():
    //            $scope.menulist = userSideMenu;
    //            return true;
    //            break

    //        case $urls.Users():
    //        case $urls.Admins():
    //        case $urls.Currencies():
    //        case $urls.Assemblies():
    //        case $urls.AdminProfile():
    //        case $urls.Invites():
    //            $scope.menulist = adminSideMenu;
    //            return false;
    //            break
    //    }
    //}
}