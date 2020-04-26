app.controller('MainController', function($scope, $rootScope, $http, $route, $window, $uibModal, AuthenticationSvc, APP_CONFIG) {

	$scope.tagline = '... ...';
    $rootScope.isInTaskViewMode = false;
	var userInfo = {};

	$scope.logout = function () {
		AuthenticationSvc.logout();
		$window.location.reload();
	};

	$scope.addProject = function () {
		var modalInstance = $uibModal.open({
			controller: 'modalController as modal',
			templateUrl: 'views/modals/projectModal.html',
			backdrop: 'static',
			size: 'md',
			verticalAlign: 'center',
			resolve: {
				userNames: function () {
					return $scope.userNames;
				},
				userInfo: function () {
					return userInfo;
				},
				project : function () {
					return null;
				},
				task : function () {
					return null;
                },
                workTimeLog : function () {
                    return null;
                },
                modalState : function () {
					return ModalState.project;
                }
			}
		});

		modalInstance.result.then(function (data) {
		    data.tasks = [];
			$rootScope.userData.projects.push(data);
		}, function (data) {
		});
	};

	$scope.editProject = function (proj) {
		if($rootScope.isInTaskViewMode) return;

		var modalInstance = $uibModal.open({
			controller: 'modalController as modal',
			templateUrl: 'views/modals/projectModal.html',
			backdrop: 'static',
			size: 'md',
			verticalAlign: 'center',
			resolve: {
				userNames: function () {
					return $scope.userNames;
				},
				userInfo: function () {
					return userInfo;
				},
				project : function () {
					return proj;
				},
                task : function () {
                    return null;
                },
                workTimeLog : function () {
                    return null;
                },
                modalState : function () {
                    return ModalState.project;
                }
			}
		});

		modalInstance.result.then(function (data) {
			var index = $rootScope.userData.projects.indexOf(proj);
			$rootScope.userData.projects[index] = data;
		}, function (data) {
		});
	};

    $scope.addTask = function () {
        var userNames = $scope.findById($rootScope.userData.projects,$scope.selectedProjectId).userNames;
        var index = userNames.indexOf(userInfo.userName);
        userNames.splice(index, 1);

        var modalInstance = $uibModal.open({
            controller: 'modalController as modal',
            templateUrl: 'views/modals/taskModal.html',
            backdrop: 'static',
            size: 'md',
            verticalAlign: 'center',
            resolve: {
                userNames: function () {
                    return userNames;
                },
                userInfo: function () {
                    return userInfo;
                },
                project : function () {
                    return { id : $scope.selectedProjectId };
                },
                task : function () {
                    return null;
                },
                workTimeLog : function () {
                    return null;
                },
                modalState : function () {
                    return ModalState.task;
                }
            }
        });

        modalInstance.result.then(function (data) {
            $scope.findById($rootScope.userData.projects,$scope.selectedProjectId).tasks.push(data);
        }, function (data) {
        });
    };

    $scope.editTask = function (task) {
        var userNames = $scope.findById($rootScope.userData.projects,$scope.selectedProjectId).userNames;
        var index = userNames.indexOf(userInfo.userName);
        userNames.splice(index, 1);

        var modalInstance = $uibModal.open({
            controller: 'modalController as modal',
            templateUrl: 'views/modals/taskModal.html',
            backdrop: 'static',
            size: 'md',
            verticalAlign: 'center',
            resolve: {
                userNames: function () {
                    return userNames;
                },
                userInfo: function () {
                    return userInfo;
                },
				project : function () {
                	return { id : $scope.selectedProjectId };
				},
                task : function () {
                    return task;
                },
                workTimeLog : function () {
                    return null;
                },
                modalState : function () {
                    return ModalState.task;
                }
            }
        });

        modalInstance.result.then(function (data) {
            var taskList = $scope.findById($rootScope.userData.projects,$scope.selectedProjectId).tasks;
            var index = taskList.indexOf(task);
            taskList[index] = data;
        }, function (data) {
        });
    };

    $scope.addWorkTimeLog = function (workTimeLog) {
        if($scope.selectedTaskId == null || $scope.selectedProjectId == null){
            alert('No selected project or task!')
            return;
        }

        var modalInstance = $uibModal.open({
            controller: 'modalController as modal',
            templateUrl: 'views/modals/workTimeLogModal.html',
            backdrop: 'static',
            size: 'md',
            verticalAlign: 'center',
            resolve: {
                userNames: function () {
                    return $scope.userNames;
                },
                userInfo: function () {
                    return userInfo;
                },
                project : function () {
                    return { id : $scope.selectedProjectId };
                },
                task : function () {
                    return { id : $scope.selectedTaskId };
                },
                workTimeLog : function () {
                    return workTimeLog;
                },
                modalState : function () {
                    return ModalState.workTimeLog;
                }
            }
        });

        modalInstance.result.then(function (data) {
            var taskList = $scope.findById($rootScope.userData.projects,$scope.selectedProjectId).tasks;
            var selectedTask = $scope.findById(taskList,$scope.selectedTaskId);
            data.taskName = selectedTask.name;

            var index = $rootScope.userData.workTimeLogs.indexOf(workTimeLog);
            $rootScope.userData.workTimeLogs.push(data);
            $rootScope.$broadcast('calendarRefreshEvent');

        }, function (data) {
        });
    };

    $scope.editWorkTimeLog = function (workTimeLog) {
        var modalInstance = $uibModal.open({
            controller: 'modalController as modal',
            templateUrl: 'views/modals/workTimeLogModal.html',
            backdrop: 'static',
            size: 'md',
            verticalAlign: 'center',
            resolve: {
                userNames: function () {
                    return $scope.userNames;
                },
                userInfo: function () {
                    return userInfo;
                },
                project : function () {
                    return { id : null };
                },
                task : function () {
                    return { id : workTimeLog.taskId };
                },
                workTimeLog : function () {
                    return workTimeLog;
                },
                modalState : function () {
                    return ModalState.workTimeLog;
                }
            }
        });

        modalInstance.result.then(function (data) {
            // Törlés
            if(data == null) {
                var index = $rootScope.userData.workTimeLogs.indexOf(workTimeLog);
                $rootScope.userData.workTimeLogs.splice(index, 1);
            }
            // Módosítás
            else {
                var index = $rootScope.userData.workTimeLogs.indexOf(workTimeLog);
                $rootScope.userData.workTimeLogs[index] = data;
            }

            $rootScope.$broadcast('calendarRefreshEvent');

        }, function (data) {
        });
    };

	$scope.deleteProject = function (proj) {

		$http.delete(APP_CONFIG.baseUrl + 'api/project/' + proj.id,{
			headers: {'Authorization': 'Bearer ' + userInfo.accessToken}
		}).success(function() {
			var index = $rootScope.userData.projects.indexOf(proj);
			$rootScope.userData.projects.splice(index, 1);

            getUserDataWorkTimeLog(userInfo.userName);
		}).error(function(details) {
			console.log('Error: ' + details);
		});
	};

    $scope.deleteTask = function (task) {

        $http.delete(APP_CONFIG.baseUrl + 'api/task/' + task.id,{
            headers: {'Authorization': 'Bearer ' + userInfo.accessToken}
        }).success(function() {
            var taskList = $scope.findById($rootScope.userData.projects,$scope.selectedProjectId).tasks;
            var index = taskList.indexOf(task);
            taskList.splice(index, 1);

            getUserDataWorkTimeLog(userInfo.userName);
        }).error(function(details) {
            console.log('Error: ' + details);
        });
    };

    $scope.deleteWorkTimeLog = function (workTimeLog) {

        $http.delete(APP_CONFIG.baseUrl + 'api/worktimelog/' + workTimeLog.id,{
            headers: {'Authorization': 'Bearer ' + userInfo.accessToken}
        }).success(function() {
            var index = $rootScope.userData.workTimeLogs.indexOf(workTimeLog);
            $rootScope.userData.workTimeLogs.splice(index, 1);
        }).error(function(details) {
            console.log('Error: ' + details);
        });
    };

	$scope.openTasks = function (id) {
        var projectNode = $scope.findById($rootScope.userData.projects, Number(id));
        if(projectNode == null) return;

        $scope.selectedProject = projectNode.name;
        $scope.selectedProjectId = id;

        $rootScope.isInTaskViewMode = true;
    };

    $scope.openWorkTimeLogs = function (id) {
        var taskList = $scope.findById($rootScope.userData.projects, $scope.selectedProjectId).tasks;
        var taskNode = $scope.findById(taskList,Number(id));
        if(taskNode == null) return;

        $scope.selectedTask = taskNode.name;
        $scope.selectedTaskId = id;

        $rootScope.isInTaskViewMode = true;
        $rootScope.isTaskSelected = true;
    };

    $scope.closeTasks = function () {
        $rootScope.isInTaskViewMode = false;
        $rootScope.isTaskSelected = false;
        $scope.selectedTaskId = null;
        $scope.selectedProjectId = null;
    };

    $scope.closeWorkTimeLogs = function () {
        $rootScope.isTaskSelected = false;
        $scope.selectedTaskId = null;
    };

	function getUserNameList() {
		$http.get(APP_CONFIG.baseUrl + 'api/Users/Names',{
			headers: {'Authorization': 'Bearer ' + userInfo.accessToken}
		}).success(function(users) {
			var index = users.indexOf(userInfo.userName);
			users.splice(index, 1);
			$scope.userNames = users;
		}).error(function(details) {
			console.log('Error: ' + details);
		});
    }
    
	function getUserData(userName){
		$http.get(APP_CONFIG.baseUrl + 'api/Users/' + userInfo.id,{
			headers: {'Authorization': 'Bearer ' + userInfo.accessToken}
		}).success(function(data) {     
            console.log(data);
			$rootScope.userData = data;
			$rootScope.$broadcast('userDataLoaded');

		}).error(function(details) {
			console.log('Error: ' + details);
		});
	}

    function getUserDataWorkTimeLog(userName){
        $http.get(APP_CONFIG.baseUrl + 'api/Users/' + userInfo.id,{
            headers: {'Authorization': 'Bearer ' + userInfo.accessToken}
        }).success(function(data) {
            $rootScope.userData.workTimeLogs = data.workTimeLogs;
            $rootScope.$broadcast('calendarRefreshEvent');

        }).error(function(details) {
            console.log('Error: ' + details);
        });
    }

    $scope.findById = function(source, id) {
		if(source == null) return null;
        for (var i = 0; i < source.length; i++) {
            if (source[i].id === id) {
                return source[i];
            }
        }
    };

	$scope.init = function () {
		userInfo = AuthenticationSvc.getUserInfo();
		if(userInfo != null){
			getUserNameList();
			getUserData();
		}
	};
	$scope.init();

});

var ModalState = {
    project: 0,
    task: 1,
    workTimeLog: 2
};