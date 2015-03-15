(function(app) {
    'use strict';
    var authenticationModule = app.AngularRegistry.RegisterModules('authModule', ['ngRoute']);

    authenticationModule.config(['$routeProvider', function ($routeProvider) {
        $routeProvider.when('/login', {
            controller: "AuthController",
            templateUrl: "template/login.html"
        });
        //$routeProvider.otherwise('/');
    }]);

    authenticationModule.controller('AuthController', ['AuthService', function(authService) {
        var vm = this;

    }]);

    authenticationModule.factory('AuthService', ['$http', function ($http) {
        return {

        };

    }]);

}(MainModule));

