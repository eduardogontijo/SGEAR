(function () {

    'use strict';

    angular.module('app').controller('successController', successController);

    successController.$inject = ['$rootScope'];

    function successController($rootScope) {
        var vm = this;

        $rootScope.pageClass = "wr-success";

    };

})();