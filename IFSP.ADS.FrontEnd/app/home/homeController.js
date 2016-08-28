(function () {

    'use strict';

    angular.module('app').controller('homeController', homeController);

    homeController.$inject = ['$rootScope'];

    function homeController($rootScope) {
        var vm = this;

        $rootScope.pageClass = "wr-home";

        vm.images = [
			{ url: '../../../content/img/home/banners/banner-home.jpg' }
        ];

    };

})();