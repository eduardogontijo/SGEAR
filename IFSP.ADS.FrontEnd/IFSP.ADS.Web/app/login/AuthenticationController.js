//(function () {
//    'use strict';
//    var controllerId = 'loginController';
//    angular.module('app').controller(controllerId, ['$scope', '$rootScope', 'common', '$cookieStore', 'loginService', 'userService', '$location', '$route', loginController]);

//    function authenticationController($scope, $rootScope, $cookieStore, userService, $location, $route) {
//        var getLogFn = common.logger.getLogFn;
//        var errorLog = getLogFn(controllerId, 'logError');
//        var vm = this;
//        vm.status = "Conectar";
//        vm.isBusy = false;

//        vm.authenticate = function () {

//            vm.isBusy = true;
//            vm.status = "Aguarde...";

//            //vm.model.login = vm.model.login.toLowerCase();

//            loginService.authenticate(vm.model.login, vm.model.password, function (data) {

//                console.log(data);
     

//            }, function (error) {
//                vm.status = "Conectar";
//                vm.isBusy = false;
//                //errorLog('Credenciais inválidas...');
//            });
//        };

//        //function setTokenCookie(token, email) {
//        //    $cookieStore.put('token', token);
//        //    $cookieStore.put('email', email);
//        //}
//    }
//})();

