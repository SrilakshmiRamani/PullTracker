

namespace PullTracker.Contract
{
    public class ChangesetMetadata
    {
        private string id;

        private string displayId;

        private Author author;

        private string authorTimeStamp;

        private string message;

        public string Id { get { return this.id; } set { this.id = value; } }

        public string DisplayId { get { return this.displayId; } set { this.displayId = value; } }

        public Author Author { get { return this.author; } set { this.author = value; } }

        public string AuthorTimeStamp { get { return this.authorTimeStamp; } set { this.authorTimeStamp = value; } }

        public string Message { get { return this.message; } set { this.message = value; } }
    }
}