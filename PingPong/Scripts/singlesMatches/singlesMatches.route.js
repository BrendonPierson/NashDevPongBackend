(function () {
    angular
    .module('app.core')
    .config(config);

    config.$inject = ['$stateProvider'];

    function config($stateProvider) {
        $stateProvider
         .state('singlesMatches', {
             url: "/PingPong#/singlesMatches",
             controller: 'SinglesMatches',
             controllerAs: 'vm',
             templateUrl: "~/Scripts/singlesMatches/singlesMatches.html"
         });
    }
})();
