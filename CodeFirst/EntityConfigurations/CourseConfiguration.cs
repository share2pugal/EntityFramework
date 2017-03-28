using System.Data.Entity.ModelConfiguration;

namespace CodeFirst.EntityConfigurations
{
    public class CourseConfiguration : EntityTypeConfiguration<Course>
    {

        public CourseConfiguration()
        {
            

            Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(255);

            Property(c => c.Description)
            .IsRequired()
            .HasMaxLength(2000);

            HasRequired(c => c.Author)
            .WithMany(a => a.Courses)
            .HasForeignKey(c => c.AuthorId)
            .WillCascadeOnDelete(false);

            HasMany(c => c.Tags)
            .WithMany(t => t.Courses)
            .Map(M => M.ToTable("CourseTags"));

            HasRequired(c => c.Cover)
            .WithRequiredPrincipal(c => c.Course);

           
        }

    }
}
