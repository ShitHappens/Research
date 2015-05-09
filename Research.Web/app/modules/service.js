angular.module('helper.service', [])
    .factory('eventService', ['$rootScope', '$timeout', function ($rootScope, $timeout) {
        var eventService = {};

        eventService.emit = function (element, event, param) {
            $timeout(function () {
                element.closest('.controller-parent').children(':first').scope().$broadcast(event, param);
            }, 0);
        }

        //eventService.emitLoadReport = function (element) {
        //    this.emit(element, 'loadReport');
        //    $rootScope.$broadcast('loadReport');
        //}

        return eventService;
    }]);
