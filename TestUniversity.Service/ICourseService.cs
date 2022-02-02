using University.Data;

namespace University.Service
{
    public interface ICourseService
    {
        void Create(Course course);
        void Delete(Course course);
        Course GetCategory(int id);
        Course GetCourse(int id);
        IEnumerable<Course> GetCourses();
        void Update(Course course);
        bool CourseExists(int id);
    }
}