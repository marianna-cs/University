using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Data;
using University.Repo;

namespace University.Service
{
    public class GroupService : IGroupService
    {
        private RepositoryGroups _repositoryGroups;

        public GroupService(TestUniversityContext context)
        {
            _repositoryGroups = new RepositoryGroups(context);
        }

        public IEnumerable<Group> GetGroups()
        {
            return _repositoryGroups.GetAllList();
        }

        public Group GetGroup(int id)
        {
            return _repositoryGroups.GetById(id);
        }

        public void Create(Group group)
        {

            _repositoryGroups.Create(group);
        }
        public void Delete(Group group)
        {
            _repositoryGroups.Delete(group);
        }
        public Group GetCategory(int id)
        {
            return _repositoryGroups.GetCategory(id);
        }

        public IEnumerable<Group> GetGroupsWithCourse()
        {
            return _repositoryGroups.GetGroupsWithCourse();
        }

        public void Update(Group group)
        {
            _repositoryGroups.Update(group);
        }

        public bool GroupExists(int id)
        {
            return _repositoryGroups.GroupExists(id);
        }

        public int GetCountStudentsOnGroup(int id)
        {
            return _repositoryGroups.GetContentGroup(id).Students.Count();
        }
    }
}
