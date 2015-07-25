requestModule.controller("OpenRequestController", function ($scope, openRequestRepository) {
    $scope.clearCache = function() {
        $templateCache.removeAll();
    };
    openRequestRepository.get().then(function (openrequests) {
        $scope.openrequests = openrequests;
    });
});

//$scope.open = function() {
//    $http.get("PullRequest/Open").success(function(data) {
//        $scope.openrequests = data;
//    }).error(function() {
//        alert("Unexpected Error Occurred");
//    });
//}