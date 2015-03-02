(function ($, app) {
    "use strict";
    var studentModule = app.AngularRegistry.RegisterModules('studentModule', ['ngRoute']);
        //angular.module('studentModule', ['ngRoute']);

    studentModule.config(['$routeProvider', function ($routeProvider) {
        $routeProvider.when('/', {
            controller: "StudentController",
            templateUrl: "template/students.html"
        });
        $routeProvider.when('/updated', {
            controller: "StudentController",
            templateUrl: "template/updateSuccess.html"
        });
        $routeProvider.otherwise('/');
    }]);

    studentModule.controller('StudentController', ['StudentService', '$location', function (studentService, $location) {
        var vm = this;
        var getStudentPromis = studentService.getStudents().then(function (result) {
            vm.students = result;
        });
        vm.showStudentDetails = function (id) {
            for(var i=0; i<vm.students.length; i++) {
                var student = vm.students[i];
                if (student.StudentId === id) {
                    vm.selectedStudent = student;
                }
            };
        };
        vm.updateStudent = function() {
            studentService.updateStudent(vm.studentId, vm.studentName);
            $location.path('/updated');
        }

    }]);

    studentModule.factory('StudentService', ['$http', '$q',
        function ($http, $q) {
            var defer = $q.defer();
            return {
                getStudents: function () {
                    $http.get('/home/getstudents').success(function (result) {
                   
                        defer.resolve(result);
                    }).error(function() {

                    });
                    return defer.promise;
                },
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
    //angular.bootstrap($('body'), ['studentModule']);
}(jQuery, MainModule));