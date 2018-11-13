using LearningSystem.App.Infrastructure.Abstract;
using LearningSystem.App.Security;
using LearningSystem.Domain.Abstract;
using LearningSystem.Domain.Bind;
using LearningSystem.Domain.View;
using System.Web;
using System.Web.Mvc;

namespace LearningSystem.App.Controllers
{
    public class AccountController : Controller
    {
        private IAuthProvider authProvider;
        private ILoginRepository repository;
        private ICourseRepository repo;

        public AccountController(IAuthProvider authProvider, ILoginRepository repository, ICourseRepository repo)
        {
            this.authProvider = authProvider;
            this.repository = repository;
            this.repo = repo;
        }
            
        [HttpGet]
        public ActionResult Login()
        {
            var httpCookie = this.Request.Cookies.Get("sessionId");
            if (httpCookie != null && AuthenticationManager.IsAuthenticated(httpCookie.Value))
            {
                return this.RedirectToAction("All", "Course");
            }
            return View(new LoginViewModel());
        }

        [HttpPost]
        public ActionResult Login(LoginStudentBm bind, string returnUrl)
        {
            //var httpCookie = this.Request.Cookies.Get("sessionId");
            //if (httpCookie != null && AuthenticationManager.IsAuthenticated(httpCookie.Value))
            //{
            //    return this.RedirectToAction("All", "Course");
            //}
            if (ModelState.IsValid)
            {
                if (authProvider.Authenticate(bind.Username, bind.Password))
                {
                    return Redirect(returnUrl ?? Url.Action("All", "Admin"));
                }
                else
                {
                    this.repository.LoginUser(bind, this.Session.SessionID);
                    this.Response.SetCookie(new HttpCookie("sessionId", Session.SessionID));
                    return this.RedirectToAction("All", "Course");
                }
            }
            return this.View(new LoginViewModel());
        }

        [HttpGet]
        public ActionResult Register()
        {
            var httpCookie = this.Request.Cookies.Get("sessionId");
            if (httpCookie != null && AuthenticationManager.IsAuthenticated(httpCookie.Value))
            {
                return RedirectToAction("All", "Course");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterStudentViewModel vm)
        {
            var httpCookie = this.Request.Cookies.Get("sessionId");
            if (httpCookie != null && AuthenticationManager.IsAuthenticated(httpCookie.Value))
            {
                return RedirectToAction("All", "Course");
            }

            if (this.repository.Register(vm))
            {
                if (ModelState.IsValid && vm.ConfirmPassword == vm.Password)
                {
                    return RedirectToAction("Login");
                }
                return RedirectToAction("Register");
            }
            else
            {
                ModelState.AddModelError("", "Username taken");
                return View();
            }
        }

        [HttpPost]
        public ActionResult Logout()
        {
            var httpCookie = this.Request.Cookies.Get("sessionId");
            if (AuthenticationManager.IsAuthenticated(httpCookie.Value))
            {
                AuthenticationManager.Logout(Request.Cookies.Get("sessionId").Value);

            }
            return RedirectToAction("Login");
        }
    }
}