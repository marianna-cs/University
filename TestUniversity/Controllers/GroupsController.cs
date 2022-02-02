using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data.Entity.Infrastructure;
using University.Data;
using University.Service;

namespace University.Web.Controllers
{
    public class GroupsController : Controller
    {
        IGroupService _groupService;
        ICourseService _courseService;
        public GroupsController(IGroupService groupService, ICourseService courseService)
        {
            _groupService = groupService;
            _courseService = courseService;
        }
        public IActionResult Index()
        {
            var groups = _groupService.GetGroupsWithCourse();
            return View(groups);
        }

        // GET: Groups/Create
        public IActionResult Create()
        {
            var courses = _courseService.GetCourses().ToList();            
            ViewData["CourseId"] = new SelectList(courses, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,CourseId,Name")] Group group)
        {
            if (ModelState.IsValid)
            {
                _groupService.Create(group);
                return RedirectToAction(nameof(Index));

            }
            return View(group);
        }

        // GET: Courses/Delete/5
        public IActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var group = _groupService.GetGroup(id);
            if (group == null)
            {
                return NotFound();
            }
            var count = _groupService.GetCountStudentsOnGroup(id);
            if(count > 0)
            {
                return BadRequest("You can't delete a group that has students");
            }

            return View(group);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var group = _groupService.GetGroup(id);
            _groupService.Delete(group);
            return RedirectToAction(nameof(Index));
        }

        // GET: Groups/Edit/5
        public IActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var group = _groupService.GetGroup(id);
            if (group == null)
            {
                return NotFound();
            }
            ViewData["CourseId"] = new SelectList(_courseService.GetCourses().ToList(), "Id", "Name", group.CourseId);
            return View(group);
        }

        // POST: Groups/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,CourseId,Name")] Group @group)
        {
            if (id != @group.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _groupService.Update(group);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_groupService.GroupExists(group.Id))
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
            ViewData["CourseId"] = new SelectList(_courseService.GetCourses().ToList(), "Id", "Name", @group.CourseId);
            return View(@group);
        }

        public IActionResult ViewListStudents(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var group = _groupService.GetCategory(id);
            if (group == null)
            {
                return NotFound();
            }

            return View(group);
        }
    }
}
