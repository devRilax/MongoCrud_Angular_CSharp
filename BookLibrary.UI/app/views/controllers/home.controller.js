(function () {
    'use strict';

    angular
        .module('library.crud')
        .controller('homeController', homeController);

    homeController.$inject = ['$location', '$rootScope', '$scope'];

    function homeController($location, $rootScope, $scope) {
        var vm = this;

        vm.fx = {

        }

        vm.ui = {


        }

        init();

        function init() {

        }


    }
})();
