(function () {
    'use strict';

    angular
        .module('library.crud')
        .controller('bookController', bookController);

    bookController.$inject = ['$rootScope', '$scope', 'bookService', '$location', 'toastr'];

    function bookController($rootScope, $scope, bookService, $location, toastr) {

        $scope.ui = {
            book: { authors: [] },
            author: {}
        }

        $scope.fx = {
            upsert: upsert,
            addAuthor: addAuthor,
            dropAuthor: dropAuthor,
            back: back
        }

        init();

        function init() {
            var dataService = bookService.entity();
            if (dataService) {
                $scope.ui.book = dataService;
            }
        }

        function upsert() {
            $scope.ui.showValidation = true;
            if ($scope.ui.formSubmit.$valid) {
                $scope.ui.showValidation = false;

                bookService.upsert($scope.ui.book)
                    .then(function (data) {
                        if (data._id) {
                            toastr.success("Book created!", "Book");
                            $location.url("/books");
                        }
                    }, function (errorMsg) {
                        toastr.error(errorMsg);
                    });

            }
        }

        function addAuthor() {
            var item = angular.copy($scope.ui.author);

            if (!isDuplicatedAuthor(item)) {
                $scope.ui.book.authors.push(item);
                $scope.ui.author = {};
            }
        }

        function dropAuthor(model) {
            var authors = $scope.ui.book.authors;
            for (var i = 0; i < authors.length; i++) {
                if (authors[i].name === model.name) {
                    authors.splice(i, 1);
                    break;
                }
            }
        }

        function isDuplicatedAuthor(model) {
            var exist = false;
            var msg = '';
            var authors = $scope.ui.book.authors;

            for (var i = 0; i < authors.length; i++) {
                if (authors[i].name === model.name) {
                    exist = true;
                    msg = "The name already be registered!";
                }
                break;
            }

            if (exist) {
                toastr.info(msg, 'Duplicate value');
            }

            return exist;
        }


        function back() {
            $location.url("/books");
        }


    }
})();
