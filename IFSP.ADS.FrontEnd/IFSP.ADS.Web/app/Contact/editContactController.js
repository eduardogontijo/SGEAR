(function () {

    'use strict';

    angular.module('app').controller('editContactController', editContactController);

    editContactController.$inject = ['$rootScope', 'contactService', '$routeParams', '$location', 'toastr'];

    function editContactController($rootScope, contactService, $routeParams, $location, toastr) {
        var vm = this;
        vm.contact = {};

        vm.contactId = $routeParams.id || 0;
        vm.contactEdit = $routeParams.id;

        activate();

        function activate() {
            if (vm.contactId > 0)
                get();
        }

        function get() {
            contactService.getDetails(vm.contactId)
                .then(function (result) {
                    vm.contact = result.data;
                })
                .catch(function () {
                    toastr.error('Não foi possível carregar contato', 'Erro');
                });
        }

    
        vm.save = function () {
            if (!vm.contact.name || !vm.contact.phone || !vm.contact.cellPhone || !vm.contact.email || !vm.contact.description) {
                return;
            }

            if (vm.contactId == 0) {
                contactService.create(vm.contact)
                 .then(function (result) {
                     if (result.status = 200) {
                         $location.path("/contato");
                     }
                 })
                 .catch(function () {
                     toastr.error('Não foi possível cadastrar contato', 'Erro');
                 });
            }

            else if (vm.contactId > 0) {
                contactService.edit(vm.contact)
                  .then(function (result) {
                      if (result.status = 200) {
                          toastr.success('Dados atualizados!', 'Sucesso!');
                      }
                  })
                  .catch(function () {
                      toastr.error('Não foi possível editar contato', 'Erro');
                  });
            }
        };

        vm.cancel = function () {
            $location.path("/contato");
        };
    };

})();