
namespace PullTracker.Contract
{
    public class FromRef
    {
        private string id;

        private string displayId;

        private string latestChangeset;

        private Repository repository;

        public string Id { get { return this.id; } set { this.id = value; } }

        public string DisplayId
        {
            get { return displayId; }
            set { displayId = value; }
        }

        public string LatestChangeSet { get { return this.latestChangeset; } set { this.latestChangeset = value; } }

        public Repository Repository { get { return this.repository; } set { this.repository = value; } }
    }
}