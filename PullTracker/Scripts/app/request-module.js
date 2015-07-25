var requestModule = angular.module("requestModule", ['ngRoute', 'angular-loading-bar']);

requestModule.config(function ($routeProvider, $locationProvider) {
    $routeProvider.when("/PullRequest", { templateUrl: '/templates/pullrequest.html', controller: 'PullRequestController' });
    $routeProvider.when("/PullRequest/Open", { templateUrl: '/templates/open.html', controller: 'OpenRequestController' });
    $routeProvider.when("/PullRequest/MergeReady", { templateUrl: '/templates/mergeready.html', controller: 'MergeReadyController' });
    $routeProvider.when("/PullRequest/OpenBranch", { templateUrl: '/templates/openbranch.html', controller: 'OpenBranchController' });
    $routeProvider.when("/PullRequest/Permission", { templateUrl: '/templates/permission.html' });
    $routeProvider.when("/PullRequest/BuildAndMerge", { templateUrl: '/templates/buildandmerge.html' });
    $routeProvider.when("/PullRequest/Hooks", { templateUrl: '/templates/hooks.html'});
    $routeProvider.otherwise({ redirectTo: '/PullRequest' });
    $locationProvider.html5Mode(true);
});

    requestModule.run(function ($rootScope, $templateCache) {
        $rootScope.$on('$viewContentLoaded', function () {
            $templateCache.removeAll();
        });
    });