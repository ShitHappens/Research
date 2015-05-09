angular.module('app', ['ngRoute', 'route-segment', 'view-segment', 'helper.service', 'helper.storage', 'helper.ajax', 'helper.access', 'helper.urls', 'helper.alert']).config(function ($routeProvider, $routeSegmentProvider, /*urlsProvider,*/ $httpProvider, $provide) {
    $httpProvider.defaults.useXDomain = true;
    delete $httpProvider.defaults.headers.common['X-Requested-With']; //Для работы обратной геолокации

    //#region routes
    $routeSegmentProvider.options.autoLoadTemplates = true;
    $routeSegmentProvider.options.strictMode = true;

    $routeSegmentProvider
    //.when('/register', 'start.register')
    //.when('/login', 'start.login')
    .when('/request', 'start.request')
    //.when('/emailConfirmation', 'start.emailConfirmation')
    //.when('/dashboard', 'site.dashboard')
    //.when('/category/:categoryid', 'site.category')
    //.when('/category', 'site.category')
    //.when('/product', 'site.product')
    //.when('/country', 'site.country')
    //.when('/site', 'site.site')
    //.when('/store/:customcategoryid', 'site.store')
    //.when('/store', 'site.store')
    //.when('/buyers', 'site.buyers')
    //.when('/order', 'site.order')
    //.when('/items', 'site.items')
    //.when('/itemsSpreadsheet', 'site.itemsSpreadsheet')
    //.when('/invites', 'site.invites')
    .when('/profile', 'site.profile')
    //.when('/subscription', 'site.subscription')
    //.when('/users', 'site.users')
    //.when('/admins', 'site.admins')
    //.when('/currencies', 'site.currencies')
    //.when('/assemblies', 'site.assemblies')
    //.when('/adminProfile', 'site.adminProfile');
    //#endregion routes

    //#region master segments
    $routeSegmentProvider.segment('start', {
        templateUrl: '/templates/master/start.html',
        controller: PageCtrl
    });

    $routeSegmentProvider.segment('site', {
        templateUrl: '/templates/master/site.html',
        controller: PageCtrl
    });
    //#endregion master segments


    //#region segments
    //$routeSegmentProvider.within('start').segment('register', { templateUrl: '/templates/start/register.html' });

    //$routeSegmentProvider.within('start').segment('login', { templateUrl: '/templates/start/login.html' });

    //$routeSegmentProvider.within('start').segment('request', { templateUrl: '/templates/start/request.html' });

    //$routeSegmentProvider.within('start').segment('emailConfirmation', { templateUrl: '/templates/start/emailConfirmation.html' });

    //$routeSegmentProvider.within('site').segment('dashboard', { templateUrl: '/templates/dashboard/common.html' });

    //$routeSegmentProvider.within('site').segment('category', { templateUrl: '/templates/category/common.html', dependencies: ['categoryid'] });

    //$routeSegmentProvider.within('site').segment('product', { templateUrl: '/templates/product/common.html' });

    //$routeSegmentProvider.within('site').segment('country', { templateUrl: '/templates/country/common.html' });

    //$routeSegmentProvider.within('site').segment('site', { templateUrl: '/templates/sitereport/common.html' });

    //$routeSegmentProvider.within('site').segment('store', { templateUrl: '/templates/store/common.html', dependencies: ['customcategoryid'] });

    //$routeSegmentProvider.within('site').segment('buyers', { templateUrl: '/templates/buyers/common.html' });

    //$routeSegmentProvider.within('site').segment('order', { templateUrl: '/templates/order/common.html' });

    //$routeSegmentProvider.within('site').segment('items', { templateUrl: '/templates/items/common.html' });

    //$routeSegmentProvider.within('site').segment('itemsSpreadsheet', { templateUrl: '/templates/items/spreadsheet.html' });

    //$routeSegmentProvider.within('site').segment('invites', { templateUrl: '/templates/invites/common.html' });

    $routeSegmentProvider.within('site').segment('profile', { templateUrl: '/templates/profile/common.html' });

    //$routeSegmentProvider.within('site').segment('subscription', { templateUrl: '/templates/subscription/common.html' });

    //$routeSegmentProvider.within('site').segment('users', { templateUrl: '/templates/admin/users.html' });

    //$routeSegmentProvider.within('site').segment('admins', { templateUrl: '/templates/admin/admins.html' });

    //$routeSegmentProvider.within('site').segment('currencies', { templateUrl: '/templates/admin/currencies.html' });

    //$routeSegmentProvider.within('site').segment('assemblies', { templateUrl: '/templates/admin/assemblies.html' });

    //$routeSegmentProvider.within('site').segment('adminProfile', { templateUrl: '/templates/adminProfile/common.html' });

    //#endregion segments

    $routeProvider.otherwise({
        redirectTo: function () { return '/profile'; }
    });
})
.factory('Page', function () {
    var title = 'Inventorix';
    return {
        title: function () { return title; },
        setTitle: function (newTitle) { title = newTitle }
    };
});