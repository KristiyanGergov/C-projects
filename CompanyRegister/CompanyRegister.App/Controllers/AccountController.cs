using CompanyRegister.App.Infrastructure.Abstract;
using CompanyRegister.Models.View;
using System.Web.Mvc;

namespace CompanyRegister.App.Controllers
{
    public class AccountController : Controller
    {
        private IAuthProvider authProvider;
        public AccountController(IAuthProvider authProvider)
        {
            this.authProvider = authProvider;
        }



        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel vm, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (authProvider.Authenticate(vm.Username, vm.Password))
                {
                    return Redirect(returnUrl ?? Url.Action("All", "Operator"));
                }
                else
                {
                    ModelState.AddModelError("", "Incorect username or password");
                    return View();
                }
            }
            else
            {
                return View();
            }
        }
            
    }
}