(function () {
    angular
    .module('app.core')
    .config(config);

    config.$inject = ['$urlRouterProvider'];

    function config($urlRouterProvider) {
        $urlRouterProvider.otherwise("/singlesMatches");
    }
})();