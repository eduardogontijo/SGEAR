(function () {
	'use strict';

	var carouselDirective = function () {
		return {
			templateUrl: 'app/directives/carousel/carousel.html',
			scope: {
				images: "="
			},
			compile: function (tElement, tAttrs, transclude) {

                //return a link function
				return function (scope, iElement, iAttrs) {

					var owl = iElement.find('.bx-carousel');

					owl.owlCarousel({
						slideSpeed: 300,
						paginationSpeed: 400,
						singleItem: true

					});

					var btns = iElement.find('.owl-buttons');
					var next = btns.find('.owl-next');
					var prev = btns.find('.owl-prev');
					var itens = $('.bx-carousel .item').length;

					next.click(function () {
						owl.trigger('owl.next');
					});
					prev.click(function () {
						owl.trigger('owl.prev');
					});

					if (itens < 2) {
					    btns.hide();
					}
                }
            }
		}
	};

	angular.module('app').directive('carousel', carouselDirective);

})();
