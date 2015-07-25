using PullTracker.Contract;

namespace PullTracker.Facade
{
    public interface IRequestProcessFacade
    {
        string GetOpenPullRequest(string repositorySlug);

        string GetMergeReadyPullRequest(string repositorySlug);

        string GetOpenBranches(string repositorySlug);

        PullRequest GetProjectRepos();

        string GetHooks(string repositorySlug);
    }
}
