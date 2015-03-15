(function (app) {
    'use strict';
    var authenticationModule = app.AngularRegistry.RegisterModules('authInterceptor', ['sharedModule']);

    authenticationModule.config(['$httpProvider', function ($httpProvider) {
        $httpProvider.interceptors.push('requestInterceptor');
    }]);

    authenticationModule.factory('requestInterceptor', ['$location', '$q', 'sessionStorageService', function ($location, $q, sessionStorageService) {
        return {
            'request': function (config) {
                if (sessionStorageService.getData('token') == null && config.url.indexOf("token") === -1) {
                    $location.path('/login');
                }
                return config || $q.when(config);
            }
        }
    }]);

}(MainModule));