using System.ComponentModel.DataAnnotations;

namespace University.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Group>? Groups { get; set; }
        public Course()
        {
            Groups = new List<Group>();
        }
    }
}
