(function () {

    'use strict';

    angular.module('app').controller('editModalityController', editModalityController);

    editModalityController.$inject = ['$rootScope', 'modalityService', '$routeParams', '$location', 'toastr'];

    function editModalityController($rootScope, modalityService, $routeParams, $location, toastr) {
        var vm = this;
        vm.modality = {};

        vm.modalityId = $routeParams.id || 0;
        vm.modalityEdit = $routeParams.id;

        activate();

        function activate() {
            if (vm.modalityId > 0)
                get();
        }

        function get() {
            modalityService.getDetails(vm.modalityId)
                .then(function (result) {
                    vm.modality = result.data;
                })
                .catch(function () {
                    toastr.error('Não foi possível carregar modalidade', 'Erro');
                });
        }

    
        vm.save = function () {
            if (!vm.modality.competitionType || !vm.modality.age || !vm.modality.gender) {
                return;
            }

            if (vm.modalityId == 0) {
                modalityService.create(vm.modality)
                 .then(function (result) {
                     if (result.status = 200) {
                         $location.path("/modalidade");
                     }
                 })
                 .catch(function () {
                     toastr.error('Não foi possível cadastrar modalidade', 'Erro');
                 });
            }

            else if (vm.modalityId > 0) {
                modalityService.edit(vm.modality)
                  .then(function (result) {
                      if (result.status = 200) {
                          toastr.success('Dados atualizados!', 'Sucesso!');
                      }
                  })
                  .catch(function () {
                      toastr.error('Não foi possível editar modalidade', 'Erro');
                  });
            }
        };

        vm.cancel = function () {
            $location.path("/modalidade");
        };


    };

})();