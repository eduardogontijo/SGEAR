/// <reference path="editFederationController.js" />
(function () {

    'use strict';

    angular.module('app').controller('editFederationController', editFederationController);

    editFederationController.$inject = ['$rootScope', 'federationService', 'contactService', '$routeParams', '$location', 'toastr'];

    function editFederationController($rootScope, federationService, contactService, $routeParams, $location, toastr) {
        var vm = this;
        vm.federation = {};

        vm.federationId = $routeParams.id || 0;
        vm.federationEdit = $routeParams.id;

        activate();

        function activate() {
            getContacts();
            if (vm.federationId > 0) {
                get();
            } else {
                //getContact();
            }
        }

        function get() {
            federationService.getDetails(vm.federationId)
                .then(function (result) {
                    vm.federation = result.data;
                })
                .catch(function () {
                    toastr.error('Não foi possível carregar federação', 'Erro');
                });
        }

        //function getContact() {
        //    federationService.getContact(vm.federationId)
        //        .then(function (result) {
        //            vm.federation.contact = result.data;
        //        })
        //        .catch(function () {
        //            toastr.error('Não foi possível carregar o contato', 'Erro');
        //        });
        //}

        function getContacts() {
            contactService.get()
                .then(function (result) {
                    vm.federation.contacts = result.data;
                })
                .catch(function () {
                    toastr.error('Não foi possível carregar lista de contatos', 'Erro');
                });
        }
    
        vm.save = function () {
            //if (!vm.modality.competitionType || !vm.modality.age || !vm.modality.gender) {
            //    return;
            //}

            if (vm.federationId == 0) {
                federationService.create(vm.federation)
                 .then(function (result) {
                     if (result.status = 200) {
                         $location.path("/federacao");
                     }
                 })
                 .catch(function () {
                     toastr.error('Não foi possível cadastrar federação', 'Erro');
                 });
            }

            else if (vm.federationId > 0) {
                federationService.edit(vm.federation)
                  .then(function (result) {
                      if (result.status = 200) {
                          toastr.success('Dados atualizados!', 'Sucesso!');
                      }
                  })
                  .catch(function () {
                      toastr.error('Não foi possível editar federação', 'Erro');
                  });
            }
        };

        vm.cancel = function () {
            $location.path("/federacao");
        };
    };

})();