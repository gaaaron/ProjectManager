app.controller('CalendarController', function($scope, $rootScope, APP_CONFIG) {

    $scope.tagline = '... ...';
    $scope.selected = {};
    $scope.events = [];

    $scope.selected = $scope.events[0];

    $scope.eventClicked = function (item) {
        console.log(item);

        var workTimeLog = $scope.$parent.findById($rootScope.userData.workTimeLogs, item.id);
        $scope.$parent.editWorkTimeLog(workTimeLog);
    };

    $scope.createClicked = function (date) {
        console.log(date);

        var workTimeLog = { startTime : date, endTime : date };
        $scope.$parent.addWorkTimeLog(workTimeLog);
    };

    function getDate(offsetDays, hour) {
        offsetDays = offsetDays || 0;
        var offset = offsetDays * 24 * 60 * 60 * 1000;
        var date = new Date(new Date().getTime() + offset);
        if (hour) { date.setHours(hour); }
        return date;
    }
    $scope.dis = false;

    function createWorkTimeLogs(){
        var workTimeLogs = $rootScope.userData.workTimeLogs;
        $scope.events = [];
        angular.forEach(workTimeLogs, function(item) {
            $scope.events.push({id : item.id, start : new Date(item.startTime), end : new Date(item.endTime), description : item.description, title : item.taskName});
        });
    }

    function init() {
        if($rootScope.userData != null){
            createWorkTimeLogs();
        } else {
            $rootScope.$on('userDataLoaded', createWorkTimeLogs);
        }
        $rootScope.$on('calendarRefreshEvent', createWorkTimeLogs);
    }
    init();

});