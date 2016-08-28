(function () {
    'use strict';

    angular
    .module('app')
    .factory('common', common);

    common.$inject = ['$http'];

    function common($http) {
        var service = {
            serializeToQueryString: serializeToQueryString
        };

        function serializeToQueryString() {
            var str = [];
            for (var p in obj)
                if (obj.hasOwnProperty(p)) {
                    str.push(encodeURIComponent(p) + "=" + encodeURIComponent(obj[p]));
                }
            return '?' + str.join("&");
        }

        return service;
    };

})();