(function () {
    'use strict';

    homeController.module('app').controller('homeController', homeController);

    homeController.$inject = ['$rootScope', 'categoryService'];

    function homeController($rootScope, categoryService) {
        var vm = this;

        activate();


    }
})();