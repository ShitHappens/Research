angular.module('helper.ajax', []).

    factory('ajax', ['$http', '$access', '$localStorage', '$alert', function (
            $http,
            $access,
            $localStorage,
            $alert
        ) {
        'use strict';

        var ajax = {};

        ajax.send = function (options) {

            //angular.element('#navbar-main').css('background-color', 'rgb(49, 51, 48)');
            //var progress = angular.element('#navbar-main .navbar-inner');
            //var main = angular.element('.main');
            //var loading = angular.element('#dataloading');
            //var c = progress.data('count');
            //if (c === undefined) c = 0;
            //c++;
            //progress.data('count', c);
            //main.css('opacity', '0.3');
            //progress.css('background', 'url("/img/animated-overlay.gif")');
            //loading.show();

            var request = {
                Params: {
                    SessionID: localStorage['SessionID']
                },
                Method: []
            };

            if (options.Methods !== undefined) {
                request.Method = options.Methods;
            }

            if (options.Method !== undefined) {
                if (angular.isArray(options.Method)) {
                    request.Method = request.Method.concat(options.Method);
                } else if (angular.isObject(options.Method)) {
                    request.Method.push(options.Method);
                }
            }

            var _url = g_ApiRoot + '/Default.aspx?callback=JSON_CALLBACK&requestMode=body&Login=' + (localStorage['Email'] || '') + '&Session=' + (localStorage['SessionID'] || '');

            $http({
                method: 'POST',
                url: _url,
                data: JSON.stringify(request)
            }).success(function (data, status, headers, config) {

                //var c = progress.data('count');
                //c--;
                //if (c < 0) c = 0;
                //progress.data('count', c);
                //if (c == 0) {
                //    progress.css('background', '');
                //    main.css('opacity', '1');
                //    loading.hide();
                //}
                if (data !== undefined && data.Params !== undefined && data.Params.Lang !== undefined) {
                    localStorage['Language'] = data.Params.Lang;
                    //moment.lang(data.Params.Lang);
                }

                var iSsessionEnd = false;

                var showError = false;

                var error = '';

                for (var i = 0; i < data.Method.length; i++) {

                    if (data.Method[i].Result !== undefined) {

                        if (data.Method[i].Result.Error.Code == 11) {
                            //$localStorage.ClearSessionID();
                            iSsessionEnd = true;
                            break;
                        } else if (data.Method[i].Result.Error.Code == 1) {
                            showError = true;
                            error = data.Method[i].Result.Error.Message;
                        }

                    }
                }

                if (showError) {
                    $alert.error(error);
                }

                if (iSsessionEnd) {
                    localStorage.clear();
                    $access.isLogin();
                } else {

                    if (options.Callbacks !== undefined && Object.prototype.toString.call(options.Callbacks) === '[object Array]') {
                        for (var i = 0; i < options.Callbacks.length; i++) {
                            if (options.Callbacks[i] !== null && options.Callbacks[i] !== undefined) {
                                if (options.Callbacks[i].F !== undefined && options.Callbacks[i].F && typeof (options.Callbacks[i].F) === 'function') {
                                    if (data.Method !== undefined) {
                                        if (options.Callbacks[i].Check === false || data.Method[i].Result !== undefined) {
                                            if (options.Callbacks[i].Params !== undefined && Object.prototype.toString.call(options.Callbacks[i].Params) === '[object Array]') {
                                                var p = options.Callbacks[i].Params;
                                                switch (p.length) {
                                                    case (0):
                                                        options.Callbacks[i].F();
                                                        break;
                                                    case (1):
                                                        options.Callbacks[i].F(data.Method[i].Result[p[0]]);
                                                        break;
                                                    case (2):
                                                        options.Callbacks[i].F(data.Method[i].Result[p[0]], data.Method[i].Result[p[1]]);
                                                        break;
                                                    case (3):
                                                        options.Callbacks[i].F(data.Method[i].Result[p[0]], data.Method[i].Result[p[1]], data.Method[i].Result[p[2]]);
                                                        break;
                                                    case (4):
                                                        options.Callbacks[i].F(data.Method[i].Result[p[0]], data.Method[i].Result[p[1]], data.Method[i].Result[p[2]], data.Method[i].Result[p[3]]);
                                                        break;
                                                    case (5):
                                                        options.Callbacks[i].F(data.Method[i].Result[p[0]], data.Method[i].Result[p[1]], data.Method[i].Result[p[2]], data.Method[i].Result[p[3]], data.Method[i].Result[p[4]]);
                                                        break;
                                                    case (6):
                                                        options.Callbacks[i].F(data.Method[i].Result[p[0]], data.Method[i].Result[p[1]], data.Method[i].Result[p[2]], data.Method[i].Result[p[3]], data.Method[i].Result[p[4]], data.Method[i].Result[p[5]]);
                                                        break;
                                                    case (7):
                                                        options.Callbacks[i].F(data.Method[i].Result[p[0]], data.Method[i].Result[p[1]], data.Method[i].Result[p[2]], data.Method[i].Result[p[3]], data.Method[i].Result[p[4]], data.Method[i].Result[p[5]], data.Method[i].Result[p[6]]);
                                                        break;
                                                }

                                                //options.Callbacks[i].F(data.Method[i]);
                                            } else {
                                                options.Callbacks[i].F(data.Method[i]);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                    if (options.Callback !== undefined && options.Callback && typeof (options.Callback) === 'function') {
                        options.Callback(data.Method);
                    }

                    for (var i = 0; i < data.Method.length; i++) {
                        console.log(data.Method[i].Name);
                        console.log(data.Method[i]);
                    }
                }

            }).error(function (data, status, headers, config) {

                //todo: 

            });

        };
        return ajax;
    }]);