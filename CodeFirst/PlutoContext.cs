using System.Data.Entity;

namespace CodeFirst
{
    public class PlutoContext:DbContext
    {

        public DbSet<Video> Videos { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public PlutoContext()
            :base("name=PlutoCodeFirst")
        {

        }
    }
}
