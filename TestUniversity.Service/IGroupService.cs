using University.Data;

namespace University.Service
{
    public interface IGroupService
    {
        void Create(Group group);
        void Delete(Group group);
        void Update(Group group);
        bool GroupExists(int id);
        int GetCountStudentsOnGroup(int id);
        Group GetCategory(int id);
        IEnumerable<Group> GetGroupsWithCourse();
        Group GetGroup(int id);
        IEnumerable<Group> GetGroups();
    }
}