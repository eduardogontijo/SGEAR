(function () {
    'use strict';

    editAtheleteController.module('app').controller('editAtheleteController', editAtheleteController);

    editAtheleteController.$inject = ['$rootScope', 'categoryService'];

    function editAtheleteController($rootScope, categoryService) {
        var vm = this;

        activate();


    }
})();