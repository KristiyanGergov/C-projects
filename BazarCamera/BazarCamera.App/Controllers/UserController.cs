using BazarCamera.App.Security;
using BazarCamera.App.Security.Abstract;
using BazarCamera.Domain.View;
using BazarCamera.Repository.Abstract;
using System.Web;
using System.Web.Mvc;

namespace BazarCamera.App.Controllers
{
    public class UserController : Controller
    {
        private IUserRepository userRepository;
        private ICameraRepository cameraRepository;
        private IAuthProvider provider;

        public UserController(IUserRepository userRepository, ICameraRepository cameraRepository, IAuthProvider provider)
        {
            this.userRepository = userRepository;
            this.cameraRepository = cameraRepository;
            this.provider = provider;
        }

        [HttpGet]
        public ActionResult Register()
        {
            var httpCookie = this.Request.Cookies.Get("sessionId");
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterUserVm vm)
        {
            if (this.userRepository.Register(vm))
            {
                if (ModelState.IsValid && vm.ConfirmPassword == vm.Password)
                {
                    return RedirectToAction("Login");

                }
                return View();

            }
            else
            {
                ModelState.AddModelError("", "Username taken");
                return View();
            }
        }
        [HttpGet]
        public ActionResult Login()
        {
            var httpCookie = this.Request.Cookies.Get("sessionId");
            if (httpCookie != null && AuthenticationManager.IsAuthenticated(httpCookie.Value))
            {
                return this.RedirectToAction("All", "Camera");
            }
            return View(new LoginVm());
        }
        [HttpPost]
        public ActionResult Login(LoginVm vm, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (provider.Authenticate(vm.Username, vm.Password))
                {
                    return Redirect(returnUrl ?? Url.Action("All", "Camera"));
                }
                else
                {
                    this.userRepository.LoginUser(vm, this.Session.SessionID);
                    this.Response.SetCookie(new HttpCookie("sessiondId", Session.SessionID));
                    return this.RedirectToAction("All", "Camera");
                }
            }
            return this.View(new LoginVm());
        }

        [HttpPost]
        public ActionResult Logout()
        {
            var httpCookie = this.Request.Cookies.Get("sessionId");

            if (AuthenticationManager.IsAuthenticated(httpCookie.Value))
            {
                AuthenticationManager.Logout(httpCookie.Value);
            }
            return this.RedirectToAction("Login");
        }
    }
}