(function (app) {
    'use strict';
    var authenticationModule = app.AngularRegistry.RegisterModules('sharedModule', []);


    authenticationModule.factory('sessionStorageService', [function () {
        return {
            saveData: function(key, data) {
                sessionStorage.setItem(key, data);
            },
            getData: function(key) {
                return sessionStorage.getItem(key);
            }
        }
    }]);

}(MainModule));