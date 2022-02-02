using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Data;
using University.Repo;

namespace University.Service
{
    public class CourseService : ICourseService
    {

        private RepositoryCourses _repositoryCourses;

        public CourseService(TestUniversityContext context)
        {
           
            _repositoryCourses= new RepositoryCourses(context);
        }

        public IEnumerable<Course> GetCourses()
        {
            return _repositoryCourses.GetAllList();
        }

        public Course GetCourse(int id)
        {
            return _repositoryCourses.GetById(id);
        }

        public void Create(Course course)
        {

            _repositoryCourses.Create(course);
            
        }
        public void Delete(Course course)
        {
            _repositoryCourses.Delete(course);
        }
        public Course GetCategory(int id)
        {
            return _repositoryCourses.GetCategory(id);
        }

        public void Update(Course course)
        {
            _repositoryCourses.Update(course);
        }

        public bool CourseExists(int id)
        {
            return _repositoryCourses.CourseExists(id);
        }
    }
}
