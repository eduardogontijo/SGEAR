(function () {

    'use strict';

    angular.module('app').controller('editCategoriesController', editCategoriesController);

    editCategoriesController.$inject = ['$rootScope', 'categoryService', '$routeParams', '$location'];

    function editCategoriesController($rootScope, categoryService, $routeParams, $location) {
        var vm = this;
        vm.category = {};

        vm.categoryId = $routeParams.id || 0;

        activate();

        function activate() {
            if (vm.categoryId > 0)
                get();
        }

        function get() {
            categoryService.getDetails(vm.categoryId)
                .then(function (result) {
                    vm.category = result.data;
                })
                .catch(function () {
                    console.log("Erro ao consultar categoria");
                });
        }

    
        vm.save = function () {
            if (vm.categoryId == 0) {
                categoryService.create(vm.category)
                 .then(function (result) {
                     if (result.status = 200) {
                         $location.path("/categoria");
                     }
                 })
                 .catch(function () {
                     console.log("Erro ao cadastrar categoria");
                 });
            }

            else if (vm.categoryId > 0) {
                categoryService.edit(vm.category)
                  .then(function (result) {
                      if (result.status = 200) {
                          alert("Dados atualizados!");
                      }
                  })
                  .catch(function () {
                      console.log("Erro ao editar categorias");
                  });
            }
        };

        vm.cancel = function () {
            $location.path("/categoria");
        };


    };

})();