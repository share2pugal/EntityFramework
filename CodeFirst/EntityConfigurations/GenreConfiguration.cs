using System.Data.Entity.ModelConfiguration;

namespace CodeFirst.EntityConfigurations
{
    public    class GenreConfiguration:EntityTypeConfiguration<Genre>
    {
        public GenreConfiguration()
        {
            Property(g => g.Name)
                .IsRequired()
                .HasMaxLength(255);
        }
    }
}
