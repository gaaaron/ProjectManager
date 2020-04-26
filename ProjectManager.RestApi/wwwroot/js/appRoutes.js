app.config(['$routeProvider', '$locationProvider', function($routeProvider, $locationProvider) {

	$locationProvider.html5Mode(false);

	$routeProvider

    // calendar page
        .when('/', {
            templateUrl: 'views/calendar.html',
            controller: 'CalendarController',
            resolve: {
                auth: ["$q", "AuthenticationSvc", function($q, authenticationSvc) {
                    var userInfo = authenticationSvc.getUserInfo();

                    if (userInfo) {
                        return $q.when(userInfo);
                    } else {
                        return $q.reject({ authenticated: false });
                    }
                }]
            }
        })

		// home page
		.when('/about', {
			templateUrl: 'views/about.html',
			resolve: {
				auth: ["$q", "AuthenticationSvc", function($q, authenticationSvc) {
					var userInfo = authenticationSvc.getUserInfo();

					if (userInfo) {
						return $q.when(userInfo);
					} else {
						return $q.reject({ authenticated: false });
					}
				}]
			}
		})

		// users page
		.when('/users', {
			templateUrl: 'views/users.html',
			controller: 'UserController',
			resolve: {
				auth: ["$q", "AuthenticationSvc", function($q, authenticationSvc) {
					var userInfo = authenticationSvc.getUserInfo();

					if (userInfo) {
						return $q.when(userInfo);
					} else {
						return $q.reject({ authenticated: false });
					}
				}]
			}
		})

		// login page
		.when('/login', {
			templateUrl: 'views/login.html',
			controller: 'LoginController'
		})

		// register page
		.when('/register', {
			templateUrl: 'views/register.html',
			controller: 'RegisterController'
		})

}]);