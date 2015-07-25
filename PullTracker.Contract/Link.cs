
namespace PullTracker.Contract
{
    public class Link
    {
        private string url;

        private string rel;

        public string Url { get { return this.url; } set { this.url = value; } }

        public string Rel { get { return this.rel; } set { this.rel = value; } }

    }
}