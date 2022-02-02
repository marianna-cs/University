using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace University.Data
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Group")]
        public int GroupId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Group? Group { get; set; }
    }
}
