
namespace PullTracker.Models
{
    public class Links
    {
        private Clone[] clone;

        private Self[] self; 

        public Clone[] Clone
        {
            get { return clone; }
            set { clone = value; }
        } 

        public Self[] Self
        {
            get { return self; }
            set { self = value; }
        }
    }
}