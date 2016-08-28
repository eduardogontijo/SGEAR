(function () {
    'use strict';

    var headerTopDirective = function () {
        return {
            restrict: 'AE',
            templateUrl: 'app/directives/header/headerTop.html',
            controller: ['$scope', function ($scope) {

                //$scope.logout = function () {
                //    localStorage.removeItem("userOAuth");
                //    $scope.vm = {
                //        model: {}
                //    };

                //    window.location.assign(global.urlRedirectOam);
                //};

            }]
        }
    };

    angular.module('app').directive('headerTop', headerTopDirective);

})();
