(function () {

    'use strict';

    angular.module('app').controller('detailsController', detailsController);

    detailsController.$inject = ['$rootScope'];

    function detailsController($rootScope) {
        var vm = this;

        $rootScope.pageClass = "wr-details";

    };

})();