using LearningSystem.App.Security;
using LearningSystem.Domain.Abstract;
using LearningSystem.Domain.Entity;
using System;
using System.Linq;
using System.Web.Mvc;

namespace LearningSystem.App.Controllers
{
    [RoutePrefix("Course")]
    public class CourseController : Controller
    {
        private ICourseRepository repository;
        public CourseController(ICourseRepository repository)
        {
            this.repository = repository;
        }
        [HttpGet, Route("All/{name?}")]
        public ActionResult All(string name)
        {
            var courses = from m in repository.Courses
                          select m;

            if (!String.IsNullOrEmpty(name))
            {
                courses = courses.Where(s => s.Name.Equals(name));
            }

            return View(courses);
        }
        [HttpPost, Route("All/{name?}")]
        public ActionResult All(Course course)
        {
            return RedirectToAction(course.Name);
        }

        [HttpGet]
        public ActionResult SignUp(Course course, int courseId)
        {
            var httpCookie = this.Request.Cookies.Get("sessionId");
            if (httpCookie == null || AuthenticationManager.IsAuthenticated(httpCookie.Value))
            {
                return RedirectToAction("Login", "Account");
            }
            Student student = AuthenticationManager.GetAuthenticatedUser(httpCookie.Value);
            this.repository.SignUp(student, courseId);
            return View(student);
        }
        [HttpGet]
        public ActionResult Search()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Search(string courseName)
        {
            Course course = repository.Courses.FirstOrDefault(a => a.Name == courseName);
            if (course != null)
            {
                return View(course);
            }
            return View();
        }
    }
}