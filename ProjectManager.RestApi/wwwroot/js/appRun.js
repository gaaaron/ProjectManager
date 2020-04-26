app.run(["$rootScope", "$location", function($rootScope, $location) {
    $rootScope.$on("$routeChangeSuccess", function(userInfo) {
    });

    $rootScope.$on("$routeChangeError", function(event, current, previous, eventObj) {
        if (eventObj.authenticated === false) {
            $location.path("/login");
        }
    });
}]);
