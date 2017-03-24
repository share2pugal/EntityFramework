using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirst
{
    public class Course
    {
        public Course()
        {
            Tags = new HashSet<Tag>();
        }
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        [MaxLength(2000)]
        public string Description { get; set; }

        public int Level { get; set; }

        public float FullPrize { get; set; }

        public Author Author { get; set; }

        [ForeignKey("Author")]
        public int AuthorId { get; set; }

        public ICollection<Tag> Tags { get; set; }
    }
}
