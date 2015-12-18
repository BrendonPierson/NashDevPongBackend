(function () {
    angular
    .module('app.singlesMatches')
    .controller('SinglesMatches', SinglesMatches);

    SinglesMatches.$inject = ["$http"];

    function SinglesMatches($http) {
        var vm = this;
        $http.get("api/SinglesMatches")
            .success(function (data) {
                vm.singlesMatches = data;
                console.log(data);
            })
            .error(function (error) { alert(error.error) });
    }

})();