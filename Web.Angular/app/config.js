/// <reference path="plugins/bootstrap-select/bootstrap-select.js" />
/// <reference path="plugins/bootstrap-select/bootstrap-select.js" />

function config($stateProvider, $urlRouterProvider, $ocLazyLoadProvider) {

    // Configure Toastr
    //toastr.options.timeOut = 4000;
    //toastr.options.positionClass = 'toast-bottom-right';
    //toastr.options.newestOnTop = true;
    //toastr.options.preventOpenDuplicates = true;
    //toastr.options.preventDuplicates = true;
    //toastr.options.maxOpened = 3;
    //$urlRouterProvider.otherwise("/clusters");

    $urlRouterProvider.otherwise(function ($injector) {
        var $state = $injector.get("$state");
        $state.go("dashboard");
    });

    $ocLazyLoadProvider.config({
        // Set to true if you want to see what and when is dynamically loaded
        debug: false
    });

    $stateProvider
        .state('dashboard', {
            url: "/dashboard",
            templateUrl: "app/dashboard/dashboard.html"
        })
        .state('incidents', {
            url: "/incidents",
            templateUrl: "app/incidents/create.html"
        })
        .state('reports', {
            url: "/reports",
            templateUrl: "app/reports/reports.html"
        });

    return {
        appErrorPrefix: '[Error] ',
        version: '1.0'
    };
}
angular
    .module('app')
    .config(config)
    .run(function ($rootScope, $state) {
        $rootScope.$state = $state;
    });
