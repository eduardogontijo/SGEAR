(function () {
    'use strict';
    angular.module("app")
        .config(function ($routeProvider) {

        $routeProvider.when("/categoria", {
            templateUrl: "app/category/manageCategories.html"
        })
          .when("/categoria/:id", {
            templateUrl: "app/category/editCategories.html"
        })
          .when("/newcategory", {
              templateUrl: "app/category/editCategories.html"
          });

        $routeProvider.when("/login", {
            templateUrl: "app/login/login.html"
        });

        $routeProvider.when("/athlete", {
            templateUrl: "app/athlete/athlete.html"
        });
        $routeProvider.when("/athlete", {
            templateUrl: "app/athlete/editAthlete.html"
        });


        $routeProvider.when("/home", {
            templateUrl: "app/home/home.html"
        });

        //$stateProvider.state('sgear.view_category', {
        //    url: "/categoria/:id",
        //    data: {
        //        pageTitle: 'Editar Categoria',
        //    },
        //    views: {
        //        'main': {
        //            templateUrl: "app/category/editManageCategories.html",
        //            controller: 'editManageCategoriesController'
        //        }
        //    }
        //});

        $routeProvider.otherwise({ templateUrl: "/login" });
    });

})();