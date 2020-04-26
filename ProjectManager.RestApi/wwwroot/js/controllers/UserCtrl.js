app.controller('UserController', function($scope, $rootScope, $http, AuthenticationSvc, APP_CONFIG) {

    $scope.tagline = '... ...';
    $scope.IsAdmin = false;

    $scope.getUsers = function() {

        var token  = AuthenticationSvc.getUserInfo().accessToken;

        $http.get(APP_CONFIG.baseUrl + 'api/Users',{
            headers: {'Authorization': 'Bearer ' + token}
        }).success(function(users) {
            $scope.users = users;

            console.log('Users: ' + users);
        }).error(function(details) {
            console.log('Error: ' + details);
        });
    };

    $scope.deleteUser = function (user) {
        if($scope.IsAdmin == false) return;

        var token  = AuthenticationSvc.getUserInfo().accessToken;

        $http.delete(APP_CONFIG.baseUrl + 'api/Users/' + user.userId,{
            headers: {'Authorization': 'Bearer ' + token}
        }).success(function() {
            var index = $scope.users.indexOf(user);
            $scope.users.splice(index,1);
        }).error(function(details) {
            console.log('Error: ' + details);
        });
    };

    $scope.init = function () {
        $scope.getUsers();

        if($rootScope.userData != null){
            setAdminFlag();
        } else {
            $rootScope.$on('userDataLoaded', setAdminFlag);
        }
    };
    $scope.init();


    function setAdminFlag() {
        $scope.IsAdmin = ($rootScope.userData.role == 1);
    }
});