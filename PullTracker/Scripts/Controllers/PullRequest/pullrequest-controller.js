requestModule.controller("PullRequestController", function ($scope, pullRequestRepository) {
    $scope.clearCache = function() {
        $templateCache.removeAll();
    };
    pullRequestRepository.get().then(function (pullrequests) {
        $scope.pullrequests = pullrequests;
    });
});

//$scope.open = function() {
//    $http.get("PullRequest/Open").success(function(data) {
//        $scope.openrequests = data;
//    }).error(function() {
//        alert("Unexpected Error Occurred");
//    });
//}