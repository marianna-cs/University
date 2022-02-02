using Microsoft.AspNetCore.Mvc;
using System.Data.Entity.Infrastructure;
using University.Data;
using University.Service;

namespace University.Web.Controllers
{
    public class CoursesController : Controller
    {
        ICourseService _courseService;

        public CoursesController(ICourseService courseService)
        {
            _courseService = courseService;
        }
        public IActionResult Index()
        {
            var courses = _courseService.GetCourses();
            return View(courses);
            
        }
        // GET: Courses/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,Description")] Course course)
        {
            if (ModelState.IsValid)
            {
                _courseService.Create(course);
                return RedirectToAction(nameof(Index));
                
            }
            return View(course);
        }

        // GET: Courses/Edit/5
        public IActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = _courseService.GetCourse(id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }

        // POST: Courses/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,Description")] Course course)
        {
            if (id != course.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _courseService.Update(course);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_courseService.CourseExists(course.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(course);
        }

        // GET: Courses/Delete/5
        public IActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = _courseService.GetCourse(id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var course = _courseService.GetCourse(id);
            _courseService.Delete(course);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult ViewListGroups(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var course = _courseService.GetCategory(id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }
    }
}
