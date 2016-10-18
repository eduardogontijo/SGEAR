(function () {

    'use strict';

    angular.module('app').controller('listTeamsController', listTeamsController);

    listTeamsController.$inject = ['$rootScope', '$scope', 'teamService', '$location'];

    function listTeamsController($rootScope, $scope, teamService, $location) {
        var vm = this;

        $scope.name = "Lista de Times";

        activate();

        function activate() {
            get();
        }

        function get() {
            teamService.get()
                .then(function (result) {
                    vm.model = result.data;
                })
                .catch(function () {
                    console.log("Erro ao consultar times");
                });
        }

        vm.edit = function (item) {
            $location.path("/categoria/" + item.id);
        };

        vm.add = function () {
            $location.path("/novacategoria");
        }

        vm.delete = function (category) {
            teamService.deleteCategory(category.id)
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