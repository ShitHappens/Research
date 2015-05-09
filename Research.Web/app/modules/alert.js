'use strict';

angular.module('helper.alert', []).

factory('$alert', function () {
    var $alert = {};

    //$alert.show = function (message) {
    //    $().toastmessage('showErrorToast', message);
    //}


    //$alert.error = function (message) {
    //    $().toastmessage('showToast', {
    //        inEffectDuration: 600,
    //        stayTime: 5000,
    //        text: message,
    //        sticky: false,
    //        position: 'top-right',
    //        type: 'error',
    //        close: null
    //    });
    //}

    return $alert;
});
