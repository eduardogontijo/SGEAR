(function () {
    'use strict';

    angular
    .module('app')
    .factory('rewardService', rewardService);

    rewardService.$inject = ['$http', 'common'];

    function rewardService($http, common) {
        var service = {
            get: get
        };

        var url = '/rewards';

        function get(obj) {
            return $http.get(global.apiUrlAdmin + url + common.serializeToQueryString(obj));
        }

        return service;
    };

})();