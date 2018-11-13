using BazarCamera.Domain.Entity;
using BazarCamera.Domain.View;
using BazarCamera.Repository.Abstract;
using System.Web.Mvc;
using System.Linq;
using BazarCamera.App.Security;

namespace BazarCamera.App.Controllers
{
    public class CameraController : Controller
    {
        private ICameraRepository repository;
        public CameraController(ICameraRepository repository)
        {
            this.repository = repository;
        }
        [HttpGet]
        public ActionResult All(string name)
        {
            var courses = from c in repository.Cameras select c;

            return View(courses);
        }

        [HttpPost]
        public ActionResult All(Camera camera)
        {
            return RedirectToAction(camera.Make);
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var res = this.repository.CameraDetails(id);
            return View(res);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var httpCookie = this.Request.Cookies.Get("sessionId");
            if (httpCookie == null || !AuthenticationManager.IsAuthenticated(httpCookie.Value))
            {
                return RedirectToAction("Login", "User");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Add(CameraVm vm)
        {
            repository.AddCamera(vm);
            return RedirectToAction("All");
        }

        [HttpPost]
        public ActionResult Search(string camera)
        {

            Camera res = this.repository.Search(camera);
            return View(res);
        }
    }
}