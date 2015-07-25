
namespace PullTracker.Contract
{
    public class Author
    {
        private User user;

        private string name;

        private string emailAddress;

        private string avatarUrl;

        private string role;

        private bool approved; 

        public User User
        {
            get { return user; }
            set { user = value; }
        }

        public string Name { get { return this.name; } set { this.name = value; } }

        public string EmailAddress { get { return this.emailAddress; } set { this.emailAddress = value; } }

        public string AvatarUrl { get { return this.avatarUrl; } set { this.avatarUrl = value; } }

        public string Role { get { return this.role; } set { this.role = value; } }

        public bool Approved { get { return this.approved; } set { this.approved = value; } }

    }
}