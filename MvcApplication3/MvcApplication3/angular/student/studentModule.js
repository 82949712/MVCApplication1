var studentModule = angular.module('studentModule', ['ngRoute']);

studentModule.config(['$routeProvider', function ($routeProvider) {
    $routeProvider.when('/', {
        controller: "studentController",
        templateUrl: "template/editStudent.html"
    });
    $routeProvider.when('/updated', {
        controller: "studentController",
        templateUrl: "template/updateSuccess.html"
    });
    $routeProvider.otherwise('/');
}]);

studentModule.controller('studentController', ['$scope', 'studentService', '$location', function ($scope, studentService, $location) {
    var getStudentPromis = studentService.getStudent(1).then(function (result) {
        $scope.student = result;
    });
    $scope.updateStudent = function() {
        studentService.updateStudent($scope.studentId);
        $location.path('/updated');
    }

}]);

studentModule.factory('studentService', ['$http', '$q',
    function ($http, $q) {
        var defer = $q.defer();
        return {
            getStudent: function (studentId) {
                $http.get('/home/getstudent').success(function (result) {
                   
                    defer.resolve(result);
                }).error(function() {

                });
                return defer.promise;
            },
            updateStudent: function(studentId, studentName) {
                alert('updating student...');
            }
        }
    }
]);