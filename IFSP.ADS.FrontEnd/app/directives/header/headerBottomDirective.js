(function () {
	'use strict';

	var headerBottomDirective = function () {
		return {
			restrict: 'AE',
			templateUrl: 'app/directives/header/headerBottom.html'
		}
	};

	angular.module('app').directive('headerBottom', headerBottomDirective);

})();
