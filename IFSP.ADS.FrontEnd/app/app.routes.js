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
                    title: 'Loja de Benefícios',
                    templateUrl: 'app/home/home.html',
                    controller: 'homeController',
                    controllerAs: 'vm',
                    settings: {
                    }
                }
            }
             ,{
                 url: '/details',
                 config: {
                     title: 'Loja de Benefícios',
                     templateUrl: 'app/details/details.html',
                     controller: 'detailsController',
                     controllerAs: 'vm',
                     settings: {
                     }
                 }
             }
             , {
                 url: '/order',
                 config: {
                     title: 'Loja de Benefícios',
                     templateUrl: 'app/order/order.html',
                     controller: 'orderController',
                     controllerAs: 'vm',
                     settings: {
                     }
                 }
             }
             , {
                 url: '/success',
                 config: {
                     title: 'Loja de Benefícios',
                     templateUrl: 'app/success/success.html',
                     controller: 'successController',
                     controllerAs: 'vm',
                     settings: {
                     }
                 }
             }

        ];
    }
})();