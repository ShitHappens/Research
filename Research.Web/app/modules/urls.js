'use strict';

angular.module('helper.urls', []).
provider('urls', function () {
    this.$get = function () {
        var obj = {
            //register: '/register',
            //login: '/login',
            //request: '/request',
            //emailConfirmation: '/emailConfirmation',
            profile: '/profile',
            //dashboard: '/dashboard',
            //category: '/category',
            //product: '/product',
            //country: '/country',
            //site: '/site',
            //store: '/store',
            //buyers: '/buyers',
            //order: '/order',
            //items: '/items',
            //itemsSpreadsheet: '/itemsSpreadsheet',
            //invites: '/invites',
            //subscription: '/subscription',
            //users: '/users',
            //admins: '/admins',
            //currencies: '/currencies',
            //assemblies: '/assemblies',
            //adminProfile: '/adminProfile'
        };
        return obj;
    }
}).
service('$urls', function (urls, $location) {

    this._build = function (urlName, params) {
        var url = urls[urlName];
        var result = url;
        if (typeof (params) === 'object') {

            for (var propertyName in params) {
                if (propertyName != 'redirect' && propertyName != 'sharp')
                    url = url.replace(':' + propertyName, params[propertyName]);
            }

            if (params.redirect == true)
                $location.url(url);

            if (params.sharp == true) {
                result = '#' + url;
            } else {
                result = url;
            }
        }
        return result;
    }
    //this.Register = function (params) {
    //    return this._build('register', params);
    //}
    //this.Login = function (params) {
    //    return this._build('login', params);
    //}
    //this.Request = function (params) {
    //    return this._build('request', params);
    //}
    this.Profile = function (params) {
        return this._build('profile', params);
    }
    //this.Dashboard = function (params) {
    //    return this._build('dashboard', params);
    //}
    //this.Category = function (params) {
    //    return this._build('category', params);
    //}
    //this.Product = function (params) {
    //    return this._build('product', params);
    //}
    //this.Country = function (params) {
    //    return this._build('country', params);
    //}
    //this.Site = function (params) {
    //    return this._build('site', params);
    //}
    //this.Store = function (params) {
    //    return this._build('store', params);
    //}
    //this.Buyers = function (params) {
    //    return this._build('buyers', params);
    //}
    //this.Order = function (params) {
    //    return this._build('order', params);
    //}
    //this.Items = function (params) {
    //    return this._build('items', params);
    //}
    //this.ItemsSpreadsheet = function (params) {
    //    return this._build('itemsSpreadsheet', params);
    //}
    //this.Invites = function (params) {
    //    return this._build('invites', params);
    //}
    //this.Subscription = function (params) {
    //    return this._build('subscription', params);
    //}
    //this.Users = function (params) {
    //    return this._build('users', params);
    //}
    //this.Admins = function (params) {
    //    return this._build('admins', params);
    //}
    //this.Currencies = function (params) {
    //    return this._build('currencies', params);
    //}
    //this.Assemblies = function (params) {
    //    return this._build('assemblies', params);
    //}
    //this.AdminProfile = function (params) {
    //    return this._build('adminProfile', params);
    //}
});