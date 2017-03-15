(function () {
    'use strict';

    angular.module('app').factory('federationService', federationService);

    federationService.$inject = ['$http'];

    function federationService($http) {
        var service = {
            get: get,
            getDetails: getDetails,
            edit: edit,
            create: create,
            deleteFederation: deleteFederation

        };

        var base = 'federation';

        function get() {
            return $http.get(global.api + base);
        }

        function getDetails(federationID) {
            return $http.get(global.api + base + '?federationID=' + federationID);
        }

        function edit(federation) {
            return $http.put(global.api + base, federation);
        }

        function create(federation) {
            return $http.post(global.api + base, federation);
        }

        function deleteFederation(federationID) {
            return $http.delete(global.api + base + '?federationID=' + federationID);
        }

        return service;
    };

})();