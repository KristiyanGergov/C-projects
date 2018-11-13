using LearningSystem.Domain.Abstract;
using LearningSystem.Domain.Entity;
using System.Linq;
using System.Web.Mvc;

namespace LearningSystem.App.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private ICourseRepository repository;

        public AdminController(ICourseRepository repository)
        {
            this.repository = repository;
        }

        // GET: Admin
        public ActionResult All()
        {
            return View(repository.Courses);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            this.repository.Delete(id);
            return View();
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Course course)
        {
            if (ModelState.IsValid)
            {
                repository.Add(course);
                return RedirectToAction("All");
            }
            else
            {
                return RedirectToAction("Add");
            }

        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Course course = repository.Courses.FirstOrDefault(t => t.Id == id);
            return View(course);
        }

        [HttpPost]
        public ActionResult Edit(Course course)
        {
            if (ModelState.IsValid)
            {
                repository.Add(course);
                return RedirectToAction("All");
            }
            return this.View(course);
        }
    }
}