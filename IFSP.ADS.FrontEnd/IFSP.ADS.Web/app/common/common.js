(function () {
    'use strict';

    angular
    .module('app')
    .factory('common', common);

    function common() {
        var service = {
            serializeToQueryString: serializeToQueryString
        };

        function serializeToQueryString(obj) {
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