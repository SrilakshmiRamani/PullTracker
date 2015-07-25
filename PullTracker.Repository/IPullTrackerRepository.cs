using PullTracker.Contract;

namespace PullTracker.Repository
{
    public interface IPullTrackerRepository
    {
        Models.Requests GetOpenPullRequests();

        Models.Requests GetMergeReadyPullRequests();

        Models.Requests GetOpenBranches();

        Models.Requests GetHooks();

        PullRequest GetProjectRepos();
    }
}
