app.factory("AuthenticationSvc", function($http, $q, $window, APP_CONFIG) {
    var userInfo;

    init();
    function init() {
        if ($window.sessionStorage["userInfo"]) {
            userInfo = JSON.parse($window.sessionStorage["userInfo"]);
        }
    }

    function login(userName, password) {
        var deferred = $q.defer();

        var requestData = {password : password, username : userName};

        $http.post(APP_CONFIG.baseUrl + "api/users/authenticate", requestData ,{
            headers: { 'Content-Type': 'application/json; charset=UTF-8'},
        }).then(function(result) {
            console.log(result.data);
            userInfo = {
                accessToken: result.data.token,
                userName: userName,
                id: result.data.id
            };
            $window.sessionStorage["userInfo"] = JSON.stringify(userInfo);
            deferred.resolve(userInfo);
        }, function(error) {
            deferred.reject(error);
        });

        return deferred.promise;
    }

    function logout() {
        $window.sessionStorage["userInfo"] = null;
        userInfo = null;
    }

    function getUserInfo() {
        return userInfo;
    }

    return {
        login: login,
        logout: logout,
        getUserInfo: getUserInfo
    };

});