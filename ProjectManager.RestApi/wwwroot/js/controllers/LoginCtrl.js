app.controller('LoginController', function($uibModal, $scope, $location, APP_CONFIG) {

    var modalInstance = $uibModal.open({
        controller: 'modalControllerLogin as modal',
        templateUrl: 'modal.html',
        backdrop: 'static',
        keyboard  : false,
        size: 'md',
        verticalAlign: 'center'
    });

    modalInstance.result.then(function () {
        $scope.$parent.init();
        $location.path( "/" );
    }, function (error) {
    });

}).controller('modalControllerLogin', function($uibModalInstance, $location, $route, AuthenticationSvc){

    this.login = function() {
        AuthenticationSvc.login(this.userName, this.password)
            .then(function (data) {
                $uibModalInstance.close();
            },function (error) {
                alert("Hiba a bejelentkezés közben!");
            });
    };

    this.goToRegister = function () {
        $uibModalInstance.dismiss();
        $location.path( "/register" );
        $route.reload();
    };
});
