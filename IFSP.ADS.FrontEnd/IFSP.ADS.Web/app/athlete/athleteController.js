(function () {
    'use strict';

    atheleteController.module('app').controller('atheleteController', atheleteController);

    atheleteController.$inject = ['$rootScope', 'categoryService'];

    function atheleteController($rootScope, categoryService) {
        var vm = this;

        activate();


    }
})();