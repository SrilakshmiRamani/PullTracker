using System.Collections.Generic;

namespace PullTracker.Contract
{
    public class PullRequest
    {
        private int size { get; set; }

        private int limit { get; set; }

        private bool isLastPage { get; set; }

        private List<RequestValues> values { get; set; }

        public int Size { get { return this.size; } set { this.size = value; } }

        public int Limit { get { return this.limit; } set { this.limit = value; } }

        public bool IsLastPage { get { return this.isLastPage; } set { this.isLastPage = value; } }

        public List<RequestValues> Values { get { return this.values; } set { this.values = value; } }
    }
}