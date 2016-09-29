(function () {

    'use strict';

    angular.module('app').controller('manageCategoriesController', manageCategoriesController);

    manageCategoriesController.$inject = ['$rootScope', 'categoryService', '$location'];

    function manageCategoriesController($rootScope, categoryService, $location) {
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


        vm.editCategory = function (category) {
            $location.path("/categoria/"+category.id);
        };

        vm.deleteCategory = function (category) {
            categoryService.deleteCategory(category.id)
                .then(function (result) {
                    if (result.status = 200) {
                        window.location.reload();
                    }
                })
                .catch(function () {
                    console.log("Erro ao deletar categoria");
                });

        }
    };

})();