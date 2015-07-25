using Autofac;
using PullTracker.ApiConsumer;
using PullTracker.Common;
using PullTracker.Contract;

namespace PullTracker.Facade
{
    /// <summary>
    /// This class is the Facade layer for the Stash Rest API Calls
    /// </summary>
    public class RequestProcessFacade : IRequestProcessFacade
    {
        private readonly IStashCoreApiConsumer apiConsumer;

        public RequestProcessFacade()
        {
            apiConsumer = AutofacHelper.Scope.Resolve<IStashCoreApiConsumer>();
        }

        public RequestProcessFacade(IStashCoreApiConsumer apiConsumer)
        {
            this.apiConsumer = apiConsumer;
        }

        /// <summary>
        /// This method gets all Open Pull Requests
        /// </summary>
        /// <returns>Requests</returns>
        public string GetOpenPullRequest(string repositorySlug)
        {
            var responseJson = apiConsumer.GetOpenPullRequests(repositorySlug);

            return responseJson;

        }

        /// <summary>
        /// This method gets all Merge Ready Pull Requests
        /// </summary>
        /// <returns>Requests</returns>
        public string GetMergeReadyPullRequest(string repositorySlug)
        {
            var responseJson = apiConsumer.GetMergeReadyPullRequests(repositorySlug);

            return responseJson;
        }

        /// <summary>
        /// This method gets all Open Branches without Pull Requests
        /// </summary>
        /// <returns></returns>
        public string GetOpenBranches(string repositorySlug)
        {
            var responseJson = apiConsumer.GetOpenBranches(repositorySlug);

            return responseJson;
        }

        /// <summary>
        /// This method get all Projects in the Project Repository
        /// </summary>
        /// <returns></returns>
        public PullRequest GetProjectRepos()
        {
            var responseJson = apiConsumer.GetProjectRepos();

            var projectRepos = JsonConvertor.JsonDeserializer<PullRequest>(responseJson);

            return projectRepos;

        }

        /// <summary>
        /// This method get all Hook setting for all projects
        /// </summary>
        /// <returns></returns>
        public string GetHooks(string repositorySlug)
        {

            var responseJson = apiConsumer.GetHooks(repositorySlug);

            return responseJson;

        }

        
    }
}
