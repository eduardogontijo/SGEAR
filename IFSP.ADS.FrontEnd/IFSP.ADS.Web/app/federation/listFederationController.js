(function () {

    'use strict';

    angular.module('app').controller('listFederationController', listFederationController);

    listFederationController.$inject = ['$rootScope', 'federationService', '$location'];

    function listFederationController($rootScope, federationService, $location) {
        var vm = this;

        activate();

        function activate() {
            get();
        }

        function get() {
            federationService.get()
                .then(function (result) {
                    vm.federation = result.data;
                })
                .catch(function () {
                    console.log("Erro ao consultar federações");
                });
        }

        vm.addFederation = function () {
            $location.path("/novafederacao");
        }

        vm.editFederation = function (federation) {
            $location.path("/federacao/" + federation.id);
        };

        vm.deleteFederation = function (federation) {
            federationService.deleteFederation(federation.id)
                .then(function (result) {
                    if (result.status = 200) {
                        window.location.reload();
                    }
                })
                .catch(function () {
                    console.log("Erro ao deletar federações");
                });
        }
    };

})();