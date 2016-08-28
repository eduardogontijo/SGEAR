(function () {
    'use strict';

    angular
    .module('app')
    .factory('bannerService', bannerService);

    bannerService.$inject = ['$http', 'common'];

    function bannerService($http, common) {
        var service = {
            get: get
        };

        var url = '/banners';

        function get(obj) {
            return $http.get(global.apiUrlAdmin + url + common.serializeToQueryString(obj));
        }

        return service;
    };

})();