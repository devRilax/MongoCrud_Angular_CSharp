(function () {
    'use stritct';

    angular
        .module('library.crud')
        .controller('booksController', booksController);

    booksController.inject = ['$rootScope', '$scope', 'bookService', '$location','$window', 'toastr']

    function booksController($rootScope, $scope, bookService, $location, $window, toastr) {


        $scope.ui = {
            books: [],
            showValidation: false

        }

        $scope.fx = {
            viewEntity: viewEntity,
            showBookView: showBookView,
            remove: remove
        }



        function viewEntity(model) {
            $scope.ui.book = model;
            $scope.ui.view.active = "edit";
        }

        function showBookView() {
            bookService.entity(null);
            $location.url("/book");
        }



        function remove(item) {
            bookService.remove(item._id)
                .then(function (data) {
                    toastr.success("Book droped");
                }, function (errorMsg) {
                    toastr.errorMsg(errorMsg);
                });

            $window.location.reload();
        }

        function viewEntity(model) {
            bookService.entity(model);
            $location.url("/book");
        }


        init();
        function init() {
            all();
        }

        function all() {
            bookService.all()
                .then(function (data) {
                    $scope.ui.books = data;
                }, function (msg) {
                    console.log(msg);
                });
        }
    }
})();