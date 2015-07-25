using System.Collections.Generic;

namespace PullTracker.Models
{
    public class Requests
    {
        private List<PullRequest> pullRequests;

        public List<PullRequest> PullRequests { get { return this.pullRequests; } set { this.pullRequests = value; } } 
    }
}