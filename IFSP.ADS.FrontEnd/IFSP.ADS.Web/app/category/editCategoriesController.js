(function () {

    'use strict';

    angular.module('app').controller('editCategoriesController', editCategoriesController);

    editCategoriesController.$inject = ['$rootScope', 'categoryService'];

    function editCategoriesController($rootScope, categoryService) {
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