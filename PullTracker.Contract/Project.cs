
namespace PullTracker.Contract
{
    public class Project
    {
        private string key;

        private string id;

        private string name;

        private string description;

        private string type;

        private Link link;

        private Links links;

        public string Key { get { return this.key; } set { this.key = value; } }

        public string Id { get { return this.id; } set { this.id = value; } }

        public string Name { get { return this.name; } set { this.name = value; } }

        public string Description { get { return this.description; } set { this.description = value; } }

        public string Type { get { return this.type; } set { this.type = value; } } 

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