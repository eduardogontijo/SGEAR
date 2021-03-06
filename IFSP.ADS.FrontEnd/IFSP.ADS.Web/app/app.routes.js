﻿(function () {
    'use strict';
   var app =  angular.module("app");

        app.config(function ($routeProvider) {

                $routeProvider.when("/categoria", {
                    templateUrl: "app/category/manageCategories.html"
                })
                  .when("/categoria/:id", {
                      templateUrl: "app/category/editCategories.html"
                  })
                  .when("/novacategoria", {
                      templateUrl: "app/category/editCategories.html"
                  });

                $routeProvider.when("/modalidade", {
                    templateUrl: "app/modality/listModality.html"
                })
                 .when("/modalidade/:id", {
                     templateUrl: "app/modality/editModality.html"
                 })
                 .when("/novamodalidade", {
                     templateUrl: "app/modality/editModality.html"
                 });

                $routeProvider.when("/contato", {
                    templateUrl: "app/contact/listcontact.html"
                })
                 .when("/contato/:id", {
                     templateUrl: "app/contact/editContact.html"
                 })
                 .when("/novocontato", {
                     templateUrl: "app/contact/editContact.html"
                 });

                $routeProvider.when("/login", {
                    templateUrl: "app/login/login.html"
                });

                $routeProvider.when("/federacao", {
                    templateUrl: "app/federation/listFederation.html"
                })
                 .when("/federacao/:id", {
                     templateUrl: "app/federation/editFederation.html"
                 })
                .when("/novafederacao", {
                    templateUrl: "app/federation/editFederation.html"
                });

                $routeProvider.when("/athlete", {
                    templateUrl: "app/athlete/athlete.html"
                });

                $routeProvider.when("/athlete", {
                    templateUrl: "app/athlete/editAthlete.html"
                });

                $routeProvider.when("/time", {
                    templateUrl: "app/team/listTeams.html"
                });

                $routeProvider.when("/time/:teamID", {
                    templateUrl: "app/athlete/editTeam.html"
                });

                $routeProvider.when("/home", {
                    templateUrl: "app/home/home.html"
                });

                $routeProvider.otherwise({ templateUrl: "/login" });
        });

})();