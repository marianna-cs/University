using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data.Entity.Infrastructure;
using University.Data;
using University.Service;

namespace University.Web.Controllers
{
    public class StudentsController : Controller
    {
        private IStudentService _studentService;
        private IGroupService _groupService;

        public StudentsController(IStudentService studentService, IGroupService groupService)
        {
            _studentService = studentService;
            _groupService = groupService;
        }
        public IActionResult Index()
        {
            var students = _studentService.GetStudentsWithGroups();
            return View(students);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            var groups = _groupService.GetGroups().ToList();
            ViewData["GroupId"] = new SelectList(groups, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,GroupId,FirstName, LastName")] Student student)
        {
            if (ModelState.IsValid)
            {
                _studentService.Create(student);
                return RedirectToAction(nameof(Index));

            }
            return View(student);
        }

        // GET: Students/Delete/5
        public IActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = _studentService.GetStudent(id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var student = _studentService.GetStudent(id);
            _studentService.Delete(student);
            return RedirectToAction(nameof(Index));
        }

        // GET: Students/Edit/5
        public IActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = _studentService.GetStudent(id);
            if (student == null)
            {
                return NotFound();
            }
            ViewData["GroupId"] = new SelectList(_groupService.GetGroups().ToList(), "Id", "Name", student.GroupId);
            return View(student);
        }

        // POST: Groups/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,GroupId,FirstName,LastName")] Student student)
        {
            if (id != student.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _studentService.Update(student);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_studentService.StudentExists(student.Id))
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
            ViewData["GroupId"] = new SelectList(_groupService.GetGroups().ToList(), "Id", "Name", student.GroupId);
            return View(student);
        }

        public IActionResult Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = _studentService.GetDetails(id);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }
    }
}
