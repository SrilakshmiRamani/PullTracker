requestModule.controller("OpenBranchController", function ($scope, openBranchRepository) {
    $scope.clearCache = function() {
        $templateCache.removeAll();
    };
    openBranchRepository.get().then(function (openBranchrequests) {
        $scope.openBranchrequests = openBranchrequests;
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