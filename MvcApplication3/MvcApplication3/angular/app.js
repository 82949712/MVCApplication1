/// <reference path="../Scripts/typings/angularjs/angular.d.ts" />
/// <reference path="../Scripts/typings/jquery/jquery.d.ts" />
var MainModule;
(function (MainModule) {
    'use strict';
    var AngularRegistry = (function () {
        function AngularRegistry() {
        }
        AngularRegistry.StartApp = function () {
            angular.bootstrap($('body'), this.modules);
        };
        AngularRegistry.RegisterModules = function (name, dependencies) {
            angular.module(name, dependencies);
        };
        AngularRegistry.modules = new Array();
        return AngularRegistry;
    })();
    MainModule.AngularRegistry = AngularRegistry;
})(MainModule || (MainModule = {}));
//# sourceMappingURL=app.js.map