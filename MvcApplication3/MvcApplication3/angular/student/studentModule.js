(function () {
    "use strict";
    var studentModule = angular.module('studentModule', ['ngRoute']);

    studentModule.config(['$routeProvider', function ($routeProvider) {
        $routeProvider.when('/', {
            controller: "StudentController",
            templateUrl: "template/editStudent.html"
        });
        $routeProvider.when('/updated', {
            controller: "StudentController",
            templateUrl: "template/updateSuccess.html"
        });
        $routeProvider.otherwise('/');
    }]);

    studentModule.controller('StudentController', ['StudentService', '$location', function (studentService, $location) {
        var vm = this;
        var getStudentPromis = studentService.getStudent(1).then(function (result) {
            vm.student = result;
        });
        vm.updateStudent = function() {
            studentService.updateStudent(vm.studentId, vm.studentName);
            $location.path('/updated');
        }

    }]);

    studentModule.factory('StudentService', ['$http', '$q',
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
}());