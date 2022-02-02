using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace University.Models
{
    public class Group
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public Course? Course { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Student>? Students { get; set; }

        public Group()
        {
            Students = new List<Student>();
        }
    }
}
