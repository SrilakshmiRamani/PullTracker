﻿

namespace PullTracker.Contract
{
    public class OutGoingPullRequest
    {
        private PullRequest pullRequest;

        public PullRequest PullRequest { get {return this.pullRequest; } set { this.pullRequest = value; } } 
    }
}