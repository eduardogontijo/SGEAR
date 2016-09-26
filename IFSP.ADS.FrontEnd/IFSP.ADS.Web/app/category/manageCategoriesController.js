(function () {

    'use strict';

    angular.module('app').controller('manageCategoriesController', manageCategoriesController);

    manageCategoriesController.$inject = ['$rootScope', 'categoryService'];

    function manageCategoriesController($rootScope, categoryService) {
        var vm = this;

        activate();

        function activate() {
            get();
        }

        function get() {
            categoryService.get()
                .then(function (result) {
                    vm.categories = result.data;
                })
                .catch(function () {
                    console.log("Erro ao consultar categorias");
                });
        }
    };

})();