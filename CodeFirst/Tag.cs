using System.Collections.Generic;

namespace CodeFirst
{
    public class Tag
    {
        public Tag()
        {
            Courses = new HashSet<Course>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Course> Courses { get; set; }
    }
}
