requestModule.factory('openRequestRepository', function($http, $q) {
    return {
        get: function() {
            var deferred = $q.defer();
            $http.get('/PullRequest/Open').success(deferred.resolve).error(deferred.reject);
            return deferred.promise;
        }
    }
});