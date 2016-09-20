(function () {
    'use strict';
    angular.module("app")
        .config(function ($routeProvider) {

        $routeProvider.when("/categoria", {
            templateUrl: "app/category/manageCategories.html",
            controller: "manageCategoriesController",
        });

        $routeProvider.when("/login", {
            templateUrl: "app/login/login.html"
        });

        $routeProvider.when("/athlete", {
            templateUrl: "app/athlete/athlete.html"
        });

        $routeProvider.when("/home", {
            templateUrl: "app/home/home.html"
        });

        $routeProvider.otherwise({ templateUrl: "/" });
    });

})();