(function (app) {
    'use strict';
    var authenticationModule = app.AngularRegistry.RegisterModules('authInterceptor', []);

    authenticationModule.config(['$httpProvider', function ($httpProvider) {
        $httpProvider.interceptors.push('requestInterceptor');
    }]);

    authenticationModule.factory('requestInterceptor', ['$location', '$q', function ($location, $q) {
        return {
            'request': function(config) {
                $location.path('/login');
                return config || $q.when(config);
            }
        }
    }]);

}(MainModule));