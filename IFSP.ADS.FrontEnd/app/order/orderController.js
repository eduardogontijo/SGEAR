(function () {

    'use strict';

    angular.module('app').controller('orderController', orderController);

    orderController.$inject = ['$rootScope'];

    function orderController($rootScope) {
        var vm = this;

        $rootScope.pageClass = "wr-order";

    };

})();