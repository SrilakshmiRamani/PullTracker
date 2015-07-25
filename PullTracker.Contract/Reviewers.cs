
namespace PullTracker.Contract
{
    public class Reviewers
    {
        private User user;

        private string role;

        private bool approved;

        public User User { get { return this.user; } set { this.user = value; } }

        public string Role { get { return this.role; } set { this.role = value; } }

        public bool Approved { get { return this.approved; } set { this.approved = value; } }
    }
}