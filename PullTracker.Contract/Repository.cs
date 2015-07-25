
namespace PullTracker.Contract
{
    public class Repository
    {
        private string slug;

        private string id;

        private string name;

        private string scmId;

        private string state;

        private string statusMessage;

        private bool forkable;

        private Project project;

        private Link link;

        private Links links;

        private string clone;

        public string Slug { get { return this.slug; } set { this.slug = value; } }

        public string Id { get { return this.id; } set { this.id = value; } }

        public string Name { get { return this.name; } set { this.name = value; } }

        public string ScmId { get { return this.scmId; } set { this.scmId = value; } }

        public string State { get { return this.state; } set { this.state = value; } }

        public string StatusMessage { get { return this.statusMessage; } set { this.statusMessage = value; } }

        public bool Forkable { get { return this.forkable; } set { this.forkable = value; } }

        public string Clone { get { return this.clone; } set { this.clone = value; } }

        public Project Project
        {
            get { return project; }
            set { project = value; }
        } 

        public Link Link
        {
            get { return link; }
            set { link = value; }
        } 

        public Links Links
        {
            get { return links; }
            set { links = value; }
        }
    }
}