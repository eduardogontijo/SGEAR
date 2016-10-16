(function () {
    'use strict';

    angular.module('app').factory('modalityService', modalityService);

    modalityService.$inject = ['$http'];

    function modalityService($http) {
        var service = {
            get: get,
            getDetails: getDetails,
            edit: edit,
            create: create,
            deleteModality: deleteModality

        };

        var base = 'modality';

        function get() {
            return $http.get(global.api + base);
        }

        function getDetails(modalityID) {
            return $http.get(global.api + base + '?modalityID=' + modalityID);
        }

        function edit(modality) {
            return $http.put(global.api + base, modality);
        }

        function create(modality) {
            return $http.post(global.api + base, modality);
        }

        function deleteModality(modalityID) {
            return $http.delete(global.api + base + '?modalityID=' + modalityID);
        }

        return service;

    };

})();