(function () {
    angular
    .module('app.singlesMatches')
    .controller('SinglesMatches', SinglesMatches);

    function SinglesMatches() {
        var vm = this;
        vm.title = "Cooking with Fire";
    }

})();