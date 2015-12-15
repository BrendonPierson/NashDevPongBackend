(function () {
    angular
    .module('app.core')
    .config(config);

    config.$inject = ['$stateProvider'];

    function config($stateProvider) {
        $stateProvider
         .state('singlesMatches', {
             url: "/singlesMatches",
             controller: 'SinglesMatches',
             controllerAs: 'vm',
             templateUrl: "~/scripts/singlesMatches/singlesMatches.html"
         });
    }
})();
