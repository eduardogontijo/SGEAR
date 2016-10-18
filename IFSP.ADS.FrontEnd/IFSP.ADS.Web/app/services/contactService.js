(function () {
    'use strict';

    angular.module('app').factory('contactService', contactService);

    contactService.$inject = ['$http'];

    function contactService($http) {
        var service = {
            get: get,
            getDetails: getDetails,
            edit: edit,
            create: create,
            deleteContact: deleteContact

        };

        var base = 'contact';

        function get() {
            return $http.get(global.api + base);
        }

        function getDetails(contactID) {
            return $http.get(global.api + base + '?contactID=' + contactID);
        }

        function edit(contact) {
            return $http.put(global.api + base, contact);
        }

        function create(contact) {
            return $http.post(global.api + base, contact);
        }

        function deleteContact(contactID) {
            return $http.delete(global.api + base + '?contactID=' + contactID);
        }

        return service;

    };

})();