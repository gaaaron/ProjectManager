app.controller('RegisterController', function($scope, $uibModal, $location, $route, APP_CONFIG) {

    $scope.tagline = '... ...';

    var modalInstance = $uibModal.open({
        controller: 'modalControllerRegister as modal',
        templateUrl: 'modal.html',
        backdrop: 'static',
        keyboard  : false,
        size: 'md',
        verticalAlign: 'center'
    });

    modalInstance.result.then(function () {
        $location.path( "/login" );
    }, function () {
    });

}).controller('modalControllerRegister', function($uibModalInstance, $http, APP_CONFIG){

    // when submitting the add form, send the text to the node API
    this.register = function() {
        $http.post(APP_CONFIG.baseUrl + 'api/users/register', this.formData)
            .success(function(data) {
                console.log(data);
                $uibModalInstance.close();
            })
            .error(function(error) {
                console.log('Error: ' + error);
                alert("Hiba a regisztráció közben!");
            });
    };
});
