(function () {
    'use strict';

    angular
        .module('library.crud')
        .factory('bookService', bookService);

    bookService.$inject = ['$http', '$q'];

    function bookService($http, $q) {

        var baseUrl = 'http://localhost:52354/api/books/';
        var _model = null;
        var _entity = null;


        var service = {
            entity: entity,
            all: all,
            upsert: upsert,
            remove: remove
        };
        return service;


        function all() {
            var request = $http({
                method: 'Get',
                url: baseUrl + "all"
            });

            return request.then(handleSuccess, handleError);
        }

        function upsert(model) {
            var request = $http({
                method: "Post",
                url: baseUrl + "upsert",
                data: model
            });

            return request.then(handleSuccess, handleError);
        }

        function remove(id) {
            var request = $http({
                method: 'Get',
                url: baseUrl + "remove/" + id
            });

            return request.then(handleSuccess, handleError);
        }

        function entity(model) {
            if (typeof model !== 'undefined') {
                _entity = model;
            } else {
                return _entity;
            }
        }


        function handleError(response) {
            var returnMessage = ""
            if (!angular.isObject(response.data) ||
                !response.data.message) {
                returnMessage = "Se ha presentado un error desconocido; por favor póngase en contacto con el administrador del sistema";
            }
            else {
                returnMessage = response.data.message;
            }
            return ($q.reject(returnMessage));
        }

        function handleSuccess(response) {
            return response.data;
        }

    }
})();
