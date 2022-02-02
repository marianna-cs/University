using Microsoft.AspNetCore.Mvc;
using University.Repo;
using University.Data;
using System.Web.Mvc;
using Microsoft.EntityFrameworkCore;

namespace University.Service
{
    public class StudentService : IStudentService
    {
        private RepositoryStudents _repositoryStudents;
        public StudentService(TestUniversityContext context)
        {
            _repositoryStudents = new RepositoryStudents(context);
        }

        public IEnumerable<Student> GetStudents()
        {
            return _repositoryStudents.GetAllList();
        }

        public Student GetDetails(int id)
        {
            return _repositoryStudents.GetDetails(id);
        }

        public void Update(Student student)
        {
            _repositoryStudents.Update(student);
        }
        public bool StudentExists(int id)
        {
            return _repositoryStudents.StudentExists(id);
        }
        public IEnumerable<Student> GetStudentsWithGroups()
        {
            var students = _repositoryStudents.GetStudentsWithGroups();
            return students;
        }

        public Student GetStudent(int id)
        {
            return _repositoryStudents.GetById(id);
        }

        public void Create(Student student)
        {

            _repositoryStudents.Create(student);
        }
        public void Delete(Student student)
        {
            _repositoryStudents.Delete(student);
        }
    }
}
