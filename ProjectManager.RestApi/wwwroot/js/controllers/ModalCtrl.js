app.controller('modalController', function($uibModalInstance, $http, $rootScope, userNames, userInfo, modalState, project, task, workTimeLog, APP_CONFIG){

	this.users = userNames;
	this.formData = {};
	this.edit = false;

	var outer = {
		data : {}
	};

	this.addProject = function() {
		this.formData.userNames.push(userInfo.userName);
		outer.data = this.formData;

		$http.post(APP_CONFIG.baseUrl + 'api/project/', this.formData,{
			headers: {'Authorization': 'Bearer ' + userInfo.accessToken}
		}).success(function(data) {
			console.log(data);
			outer.data.id = data;
			$uibModalInstance.close(outer.data);
		}).error(function(error) {
			console.log('Error: ' + error);
			$uibModalInstance.dismiss();
		});
	};

	this.editProject = function() {
        this.formData.userNames.push(userInfo.userName);
        outer.data = this.formData;

        $http.put(APP_CONFIG.baseUrl + 'api/project/' + this.formData.id, this.formData,{
            headers: {'Authorization': 'Bearer ' + userInfo.accessToken}
        }).success(function(data) {
            $uibModalInstance.close(outer.data);
        }).error(function(error) {
            console.log('Error: ' + error);
            $uibModalInstance.dismiss();
        });
    };

    this.addTask = function() {
        this.formData.userNames.push(userInfo.userName);
        outer.data = this.formData;

        $http.post(APP_CONFIG.baseUrl + 'api/task/', this.formData,{
            headers: {'Authorization': 'Bearer ' + userInfo.accessToken}
        }).success(function(data) {
            console.log(data);
            outer.data.id = data;
            $uibModalInstance.close(outer.data);
        }).error(function(error) {
            console.log('Error: ' + error);
            $uibModalInstance.dismiss();
        });
    };

    this.editTask = function() {
        this.formData.userNames.push(userInfo.userName);
        outer.data = this.formData;

        $http.put(APP_CONFIG.baseUrl + 'api/task/' + this.formData.id, this.formData,{
            headers: {'Authorization': 'Bearer ' + userInfo.accessToken}
        }).success(function(data) {
            $uibModalInstance.close(outer.data);
        }).error(function(error) {
            console.log('Error: ' + error);
            $uibModalInstance.dismiss();
        });
    };

    this.addWorkTimeLog = function() {
        outer.data = this.formData;

        $http.post(APP_CONFIG.baseUrl + 'api/worktimelog/', this.formData,{
            headers: {'Authorization': 'Bearer ' + userInfo.accessToken}
        }).success(function(data) {
            console.log(data);
            outer.data.id = data;
            $uibModalInstance.close(outer.data);
        }).error(function(error) {
            console.log('Error: ' + error);
            $uibModalInstance.dismiss();
        });
    };

    this.editWorkTimeLog = function() {
        outer.data = this.formData;

        $http.put(APP_CONFIG.baseUrl + 'api/worktimelog/' + this.formData.id, this.formData,{
            headers: {'Authorization': 'Bearer ' + userInfo.accessToken}
        }).success(function(data) {
            $uibModalInstance.close(outer.data);
        }).error(function(error) {
            console.log('Error: ' + error);
            $uibModalInstance.dismiss();
        });
    };

    this.deleteWorkTimeLog = function() {
        outer.data = this.formData;

        $http.delete(APP_CONFIG.baseUrl + 'api/worktimelog/' + this.formData.id,{
            headers: {'Authorization': 'Bearer ' + userInfo.accessToken}
        }).success(function(data) {
            $uibModalInstance.close();
        }).error(function(error) {
            console.log('Error: ' + error);
            $uibModalInstance.dismiss();
        });
    };

	this.cancel = function () {
		$uibModalInstance.dismiss();
	};

	this.init = function() {
		if(modalState == ModalState.project){
            if(project != null){
                this.edit = true;
                this.formData = angular.copy(project);

                var index = this.formData.userNames.indexOf(userInfo.userName);
                this.formData.userNames.splice(index, 1);
            } else {
                this.formData.userNames = [];
            }
		} else if(modalState == ModalState.task){
            if(task != null){
                this.edit = true;
                this.formData = angular.copy(task);

                var index = this.formData.userNames.indexOf(userInfo.userName);
                this.formData.userNames.splice(index, 1);
            } else {
                this.formData.userNames = [];
            }
            this.formData.projectId = project.id;
		} else if(modalState == ModalState.workTimeLog){
            if(workTimeLog.id != null){
                this.edit = true;
            }
            this.formData = angular.copy(workTimeLog);
            this.formData.taskId = task.id;
            this.formData.userId = $rootScope.userData.id;
		}
	};
	this.init();

	/* BEGIN : TimePicker config */
    this.hstep = 1;
    this.mstep = 15;
    this.ismeridian = false;
    /* END : TimePicker config */

});

var ModalState = {
    project: 0,
    task: 1,
    workTimeLog: 2
};