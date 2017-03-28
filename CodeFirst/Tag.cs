using System.Collections.Generic;

namespace CodeFirst
{
    public class Tag
    {
        public Tag()
        {
            Courses = new HashSet<Course>();
            Videos = new HashSet<Video>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Course> Courses { get; set; }
        public ICollection<Video> Videos { get; set; }
    }
}
