requestModule.factory('pullRequestRepository', function($http, $q) {
    return {
        get: function() {
            var deferred = $q.defer();
            $http.get('/PullRequest').success(deferred.resolve).error(deferred.reject);
            return deferred.promise;
        }
    }
});