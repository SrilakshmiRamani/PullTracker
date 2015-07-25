
namespace PullTracker.Contract
{
    public class User
    {
        private string name;

        private string emailAddress;

        private string id;

        private string displayName;

        private bool active;

        private string slug;

        private string type;

        private Link link;

        private Links links;

        public string Name { get { return this.name; } set { this.name = value; } }

        public string EmailAddress { get { return this.emailAddress; } set { this.emailAddress = value; } }

        public string Id { get { return this.id; } set { this.id = value; } }

        public string DisplayName { get { return this.displayName; } set { this.displayName = value; } }

        public bool Active { get { return this.active; } set { this.active = value; } }

        public string Slug { get { return this.slug; } set { this.slug = value; } }

        public string Type { get { return this.type; } set { this.type = value; } }

        public Link Link { get { return this.link; } set { this.link = value; } }

        public Links Links { get { return this.links; } set { this.links = value; } }
    }
}