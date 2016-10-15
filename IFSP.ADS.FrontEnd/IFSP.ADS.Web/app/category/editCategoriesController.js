(function () {

    'use strict';

    angular.module('app').controller('editCategoriesController', editCategoriesController);

    editCategoriesController.$inject = ['$rootScope', 'categoryService', '$routeParams', '$location', 'toastr'];

    function editCategoriesController($rootScope, categoryService, $routeParams, $location, toastr) {
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
                    toastr.error('Não foi possível carregar categoria', 'Erro');
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
                     toastr.error('Não foi possível cadastrar categoria', 'Erro');
                 });
            }

            else if (vm.categoryId > 0) {
                categoryService.edit(vm.category)
                  .then(function (result) {
                      if (result.status = 200) {
                          //alert("Dados atualizados!");
                          toastr.success('Dados atualizados!', 'Sucesso!');
                      }
                  })
                  .catch(function () {
                      toastr.error('Não foi possível editar categoria', 'Erro');
                  });
            }
        };

        vm.cancel = function () {
            $location.path("/categoria");
        };


    };

})();