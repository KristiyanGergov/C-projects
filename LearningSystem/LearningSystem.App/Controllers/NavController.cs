using LearningSystem.Domain.Abstract;
using LearningSystem.Domain.Entity;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace LearningSystem.App.Controllers
{
    [RoutePrefix("Nav")]
    public class NavController : Controller
    {
        // GET: Nav
        private ICourseRepository repository;

        public NavController(ICourseRepository repository)
        {
            this.repository = repository;
        }

        [Route("Search/{id?}")]
        public ActionResult Search(string id)
        {
            var courses = from c in repository.Courses
                          select c;
            if (!String.IsNullOrEmpty(id))
            {
                courses = courses.Where(c => c.Name.Contains(id));
            }
            return View(courses);
        }
        [HttpGet]
        [Route("Search/{id?}")]
        public ActionResult Search(string id, bool notUsed)
        {
            var courses = from m in repository.Courses
                         select m;

            if (!String.IsNullOrEmpty(id))
            {
                courses = courses.Where(s => s.Name.Equals(id));
            }

            return View(courses);
        }

    }
}