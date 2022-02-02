//using System.Data.Entity;
using Microsoft.EntityFrameworkCore;
using University.Data;

namespace University.Repo
{
    public class RepositoryGroups : Repository<Group>
    {
        public RepositoryGroups(TestUniversityContext context) : base(context)
        {
        }

        public bool GroupExists(int id)
        {
            return _context.Groups.Any(e => e.Id == id);
        }
        public IEnumerable<Group> GetGroupsWithCourse()
        {
            return _context.Groups.Include(c => c.Course).ToList();
        }
        public Group GetCategory(int id)
        {

            return _context.Groups.Include(g => g.Students).FirstOrDefault(m => m.Id == id);

        }

        public Group GetContentGroup(int id)
        {
            return _context.Groups.Include(s=>s.Students).FirstOrDefault(m => m.Id==id);
        }
    }
}
