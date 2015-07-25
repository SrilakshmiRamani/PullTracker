requestModule.factory('openBranchRepository', function ($http, $q) {
    return {
        get: function() {
            var deferred = $q.defer();
            $http.get('/PullRequest/OpenBranch').success(deferred.resolve).error(deferred.reject);
            return deferred.promise;
        }
    }
});