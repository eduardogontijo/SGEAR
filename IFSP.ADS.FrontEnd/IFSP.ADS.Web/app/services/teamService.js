(function () {
    'use strict';

    angular.module('app').factory('teamService', teamService);

    teamService.$inject = ['$http'];

    function teamService($http) {
        var service = {
            get: get,
            getDetails: getDetails,
            edit: edit,
            create: create,
            remove: remove

        };

        var base = 'team';

        function get() {
            return $http.get(global.api + base);
        }

        function getDetails(id) {
            return $http.get(global.api + base + '?teamID=' + id);
        }

        function edit(model) {
            return $http.put(global.api + base, model);
        }

        function create(model) {
            return $http.post(global.api + base, model);
        }

        function remove(id) {
            return $http.delete(global.api + base + '?teamID=' + id);
        }

        return service;
    };

})();