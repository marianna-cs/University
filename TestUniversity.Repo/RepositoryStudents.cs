using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Web.Mvc;
using University.Data;

namespace University.Repo
{
    public class RepositoryStudents : Repository<Student>
    {

        public RepositoryStudents(TestUniversityContext context) : base(context)
        {
        }
        public bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.Id == id);
        }
        public IEnumerable<Student> GetStudentsWithGroups()
        {
            return _context.Students.Include(c => c.Group).ToList();
        }

        public Student GetDetails(int id)
        {
            return _context.Students.Include(g => g.Group).FirstOrDefault(m => m.Id == id);
        }
    }
}

