app.controller('GenreController', ['$scope', 'GenreService', function ($scope, GenreService) {
        getGenres();
        function getGenres() {
            var callGenreService = GenreService.getGenres();
            callGenreService
                .then(function (response) {
                $scope.genres = response.data;
            }, function (error) {
                console.error("Something went woring while fetching data!");
            });
        }
    }]);
//# sourceMappingURL=genre.js.map