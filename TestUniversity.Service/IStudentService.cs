using University.Data;

namespace University.Service
{
    public interface IStudentService
    {
        void Create(Student student);
        void Delete(Student student);

        void Update(Student student);
        Student GetDetails(int id);
        bool StudentExists(int id);
        Student GetStudent(int id);
        IEnumerable<Student> GetStudents();
        IEnumerable<Student> GetStudentsWithGroups();
    }
}