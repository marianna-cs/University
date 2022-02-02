using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Data;


namespace University.Repo
{
    public class RepositoryCourses : Repository<Course>
    {
        private TestUniversityContext _context;

        public RepositoryCourses(TestUniversityContext context) : base(context)
        {
            _context = context;
        }

        public bool CourseExists(int id)
        {
            return _context.Courses.Any(e => e.Id == id);
        }
        public Course GetCategory(int id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id");
            }

            var course = _context.Courses.Include(g => g.Groups).FirstOrDefault(m => m.Id == id);

            if (course == null)
            {
                throw new ArgumentNullException("id");
            }

            return course;
        }

    }
}
