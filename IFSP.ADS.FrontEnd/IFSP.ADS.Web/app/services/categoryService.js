(function () {
    'use strict';

    angular.module('app').factory('categoryService', categoryService);

    categoryService.$inject = ['$http'];

    function categoryService($http) {
        var service = {
            get: get,
            getDetails: getDetails,
            edit: edit,
            create: create,
            deleteCategory: deleteCategory

        };

        var base = 'category';

        function get() {
            return $http.get(global.api + base);
        }

        function getDetails(categoryID) {
            return $http.get(global.api + base + '?categoryID=' + categoryID);
        }

        function edit(category) {
            return $http.put(global.api + base, category);
        }

        function create(category) {
            return $http.post(global.api + base, category);
        }

        function deleteCategory(categoryID) {
            return $http.delete(global.api + base + '?categoryID=' + categoryID);
        }

        return service;
    };

})();