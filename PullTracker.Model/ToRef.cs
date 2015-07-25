
namespace PullTracker.Models
{
    public class ToRef
    {
        private string id;

        private string displayId;

        private string latestChangeset;

        private Repository repository;

        public string Id { get { return this.id; } set { this.id = value; } }

        public string DisplayId { get { return this.displayId; } set { this.displayId = value; } }

        public string LatestChangeset { get { return this.latestChangeset; } set { this.latestChangeset = value; } }

        public Repository Repository { get { return this.repository; } set { this.repository = value; } }
    }
}