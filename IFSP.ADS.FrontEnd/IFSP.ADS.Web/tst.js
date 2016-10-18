(function () {
    'use strict';

    angular
        .module('app')
        .controller('profilesEditController', profilesEditController);

    profilesEditController.$inject = ['$location', '$routeParams', 'utilsFactory', 'profilesFactory', 'permissionFactory', '$uibModal'];

    function profilesEditController($location, $routeParams, utilsFactory, profilesFactory, permissionFactory, $uibModal) {
        var vm = this;
        vm.title = 'profilesEditController';
        vm.permissions = [];

        vm.saveProfile = saveProfile;
        vm.backToList = backToList;
        vm.isEditing = true;
        vm.notEditing = true;
        vm.edit = editing;
        vm.status = [{ StatusID: 1, Name: "Ativo" }, { StatusID: 2, Name: "Inativo" }];

        activate();

        function activate() {
            loadProfile();
            vm.notEditing = true;
        }

        function loadProfile() {
            if ($routeParams.profileId) {

                profilesFactory.getProfileById($routeParams.profileId)
    .then(function (response) {

        vm.profile = response.data;
        vm.isEditing = true;
    })
          .catch(function () {
              utilsFactory.showError('Não foi possível carregar o perfil');
          });
            }
            vm.isEditing = false;
        }

        function backToList() {
            vm.isEditing = true;
            vm.profile = {};
            location.href = "#/profiles";
        }

        function isValideModel(item) {
            if (!item) {
                utilsFactory.showError('Não foi possível salvar o perfil');
                return false;
            }

            if (!item.Name) {
                utilsFactory.showError('O nome do perfil é obrigatório.');
                return false;
            }

            if (!item.Description) {
                utilsFactory.showError('A descrição é obrigatório.');
                return false;
            }

            if (!item.Status.StatusID) {
                utilsFactory.showError('O Status é obrigatório.');
                return false;
            }

            return true;
        }

        function saveProfile() {

            if ($routeParams.profileId) {
                if (!isValideModel(vm.profile))
                    return;

                profilesFactory.EditProfile(vm.profile)
                  .then(function (response) {
                      utilsFactory.showSuccess('Perfil editado com sucesso');
                      backToList();
                  })
                  .catch(function (err) {

                  });


            } else {

                if (!isValideModel(vm.profile))
                    return;

                profilesFactory.saveProfile(vm.profile)
                .then(function (response) {

                    vm.profile = response.data;
                    utilsFactory.showSuccess('Perfil salvo com sucesso');
                    backToList();
                })
                .catch(function (err) {
                    if (err.status === 422) {
                        var modalInstance = $uibModal.open({
                            templateUrl: "app/directives/confirmModal/confirmModal.html",
                            controller: "confirmModalController",
                            resolve: {
                                message: function () {
                                    return err.data;
                                }
                            }
                        });
                        modalInstance.result.then(function () {
                            vm.profile.Reactive = true;
                            profilesFactory.saveProfile(vm.profile)
                                .then(function () {
                                    utilsFactory.showSuccess('Perfil reativado com sucesso!');
                                    backToList();
                                })
                                .catch(function () {

                                    utilsFactory.showError('Não foi possível salvar o perfil');
                                });

                        })
                    }
                })
            }
        }

        function editing() {
            vm.profile.ProfileID = parseInt($routeParams.profileId);
            vm.isEditing = false;
        };

        vm.verifyPermission = function (featureId, needsChange) {
            return permissionFactory.verifyPermission(featureId, needsChange);
        };

        vm.redirectToReturn = function () {
            location.href = '#/profiles';
        };

    }
})();