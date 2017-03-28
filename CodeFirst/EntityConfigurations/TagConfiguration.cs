using System.Data.Entity.ModelConfiguration;

namespace CodeFirst.EntityConfigurations
{
    public  class TagConfiguration:EntityTypeConfiguration<Tag>
    {
        public TagConfiguration()
        {
            Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(255);
        }
    }
}
