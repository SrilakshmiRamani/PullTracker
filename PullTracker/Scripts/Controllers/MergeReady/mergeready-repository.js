requestModule.factory('mergeReadyRepository', function ($http, $q) {
    return {
        get: function() {
            var deferred = $q.defer();
            $http.get('/PullRequest/MergeReady').success(deferred.resolve).error(deferred.reject);
            return deferred.promise;
        }
    }
});