(function () {
    'use strict';
    angular.module("app").config(function ($routeProvider) {

        $routeProvider.when("/categoria", {
            templateUrl: "app/category/manageCategories.html",
            controller: "manageCategoriesController",
        });

        $routeProvider.when("/login", {
            templateUrl: "app/login/login.html",
            controller: "loginController"
        });

        $routeProvider.otherwise({ templateUrl: "/" });
    });

})();