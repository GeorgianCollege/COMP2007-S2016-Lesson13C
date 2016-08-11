app.controller('GenreController', ['$scope', 'GenreService', function ($scope, GenreService) {
    getGenres();

    function getGenres(): void {
        let callGenreService = GenreService.getGenres();

        callGenreService
            .then((response) => {
                $scope.genres = response.data;
            },
            (error) => {
                console.error("Something went woring while fetching data!");
            });
    }
}]);