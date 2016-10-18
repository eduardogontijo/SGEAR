(function () {

    'use strict';

    angular.module('app').controller('listContactController', listContactController);

    listContactController.$inject = ['$rootScope', 'contactService', '$location'];

    function listContactController($rootScope, contactService, $location) {
        var vm = this;

        activate();

        function activate() {
            get();
        }

        function get() {
            contactService.get()
                .then(function (result) {
                    vm.contacts = result.data;
                })
                .catch(function () {
                    console.log("Erro ao consultar contatos");
                });
        }

        vm.addContact = function () {
            $location.path("/novocontato");
        }

        vm.editContact = function (contact) {
            $location.path("/contato/"+contact.id);
        };

        vm.deleteContact = function (contact) {
            contactService.deleteContact(contact.id)
                .then(function (result) {
                    if (result.status = 200) {
                        window.location.reload();
                    }
                })
                .catch(function () {
                    console.log("Erro ao deletar contato");
                });
        }
    };

})();