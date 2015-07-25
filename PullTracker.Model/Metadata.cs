

namespace PullTracker.Models
{
    public class Metadata
    {
        private OutGoingPullRequest outgoingPullRequestProvider;

        public OutGoingPullRequest OutgoingPullRequestprovider
        {
            get { return this.outgoingPullRequestProvider; }
            set
        {
            this.outgoingPullRequestProvider = value;
        } }

    }
}