using CodeFirst.EntityConfigurations;
using System.Data.Entity;

namespace CodeFirst
{
    public class PlutoContext : DbContext
    {
        public PlutoContext()
            : base("name=PlutoCodeFirstFluentAPI")
        {

        }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Video>Videos { get; set; }
        public DbSet<Genre> Genres { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CourseConfiguration());
            modelBuilder.Configurations.Add(new VideoConfiguration());
            modelBuilder.Configurations.Add(new GenreConfiguration());
        }
    }
}
