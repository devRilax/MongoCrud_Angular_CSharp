'use strict';
angular
    .module('library.crud', [])
    .controller('indexController', ['$rootScope', '$scope', '$location',
        function ($rootScope, $scope, $location) {
            /* jshint validthis: true */
            var vm = this;
            $scope.navbarProperties = {
                isCollapsed: true
            };

            $scope.init = function () {
                console.log("INDEX!!");
            }

            $scope.init();

        }]);

