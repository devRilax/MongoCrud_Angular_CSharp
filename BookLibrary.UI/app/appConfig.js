angular.module('library.crud', ['ngRoute', 'toastr','ui.bootstrap'])
    .config(_config);

_config.$inject = ["$routeProvider"]

function _config($routeProvider) {
    $routeProvider
        .when('/', {
            templateUrl: 'app/views/home.html',
            controller: 'homeController',
            controllerAs: 'vm'
        })
        .when('/book', {
            templateUrl: 'app/views/book.html',
            controller: 'bookController',
            controllerAs: 'vm'
        })
        .when('/books', {
            templateUrl: 'app/views/books.html',
            controller: 'booksController',
            controllerAs: 'vm'
        })
        .otherwise({
            redirectTo: '/'
        });
}

