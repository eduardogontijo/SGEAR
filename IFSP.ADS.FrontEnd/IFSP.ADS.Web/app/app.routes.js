(function () {
    'use strict';

    var app = angular.module('app');

    // Collect the routes
    app.constant('routes', getRoutes());
    // Configure the routes and route resolvers
    app.config(['$routeProvider', 'routes', routeConfigurator]);

    function routeConfigurator($routeProvider, routes) {
        
        routes.forEach(function (r) {
            $routeProvider.when(r.url, r.config);
        });

        $routeProvider.otherwise({ redirectTo: '/' });
    }

    // Define the routes 
    function getRoutes() {
        return [
            {
                url: '/',
                config: {
                    title: 'Categorias',
                    templateUrl: 'app/category/manageCategories.html',
                    controller: 'manageCategoriesController',
                    controllerAs: 'vm',
                    settings: {
                    }
                }
            },
            {
                url: '/qqcoisa',
                config: {
                    title: 'Lusa Rugby',
                    templateUrl: 'index.html',
                    settings: {
                    }
                }
            }

        ];
    }
})();