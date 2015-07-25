requestModule.controller("MergeReadyController", function ($scope, mergeReadyRepository) {
    $scope.clearCache = function() {
        $templateCache.removeAll();
    };
    mergeReadyRepository.get().then(function (mergeReadyrequests) {
        $scope.mergeReadyrequests = mergeReadyrequests;
        //$scope.gridOptions = { data: 'mergeReadyrequests' };
    });
});

//$scope.open = function() {
//    $http.get("PullRequest/Open").success(function(data) {
//        $scope.openrequests = data;
//    }).error(function() {
//        alert("Unexpected Error Occurred");
//    });
//}