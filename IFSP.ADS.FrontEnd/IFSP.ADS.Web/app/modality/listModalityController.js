(function () {

    'use strict';

    angular.module('app').controller('listModalityController', listModalityController);

    listModalityController.$inject = ['$rootScope', 'modalityService', '$location'];

    function listModalityController($rootScope, modalityService, $location) {
        var vm = this;

        activate();

        function activate() {
            get();
        }

        function get() {
            modalityService.get()
                .then(function (result) {
                    vm.modality = result.data;
                })
                .catch(function () {
                    console.log("Erro ao consultar modalidades");
                });
        }

        vm.addModality = function () {
            $location.path("/novamodalidade");
        }

        vm.editModality = function (modality) {
            $location.path("/modalidade/"+modality.id);
        };

        vm.deleteModality = function (modality) {
            modalityService.deleteModality(modality.id)
                .then(function (result) {
                    if (result.status = 200) {
                        window.location.reload();
                    }
                })
                .catch(function () {
                    console.log("Erro ao deletar modalidade");
                });

        }
    };

})();