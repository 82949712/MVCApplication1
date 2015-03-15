(function(app) {
    'use strict';
    var authenticationModule = app.AngularRegistry.RegisterModules('authModule', ['ngRoute', 'sharedModule']);

    authenticationModule.config(['$routeProvider', function ($routeProvider) {
        $routeProvider.when('/login', {
            controller: "AuthController",
            templateUrl: "template/login.html"
        });
        //$routeProvider.otherwise('/');
    }]);

    authenticationModule.controller('AuthController', ['AuthService', '$location', function(authService, $location) {
        var vm = this;
        vm.loginData = {
            username: "",
            password: ""
        };
        vm.login = function() {
            authService.login(vm.loginData).then(function() {
                $location.path('/');
            });
        }
    }]);

    authenticationModule.factory('AuthService', ['$http', '$q', 'sessionStorageService', function ($http, $q, sessionStorageService) {
        var defer = $q.defer(),
            _login = function(loginData) {
                var requestData = "grant_type=password&username=" + loginData.username + "&password=" + loginData.password;
                $http.post("http://localhost/api/token", requestData, { headers: { 'content-type': 'application/x-www-form-urlencoded' } }).success(function (data) {
                    sessionStorageService.saveData('token', data.access_token);
                        defer.resolve(data);
                    });
                return defer.promise;
            }
        return {
            login: _login
        };

    }]);

}(MainModule));

