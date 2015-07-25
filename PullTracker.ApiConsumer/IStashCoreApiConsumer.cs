
namespace PullTracker.ApiConsumer
{
    public interface IStashCoreApiConsumer
    {
        string GetOpenPullRequests(string repository);

        string GetMergeReadyPullRequests(string repository);

        string GetOpenBranches(string repository);

        string GetHooks(string repository);

        string GetProjectRepos();
    }
}
