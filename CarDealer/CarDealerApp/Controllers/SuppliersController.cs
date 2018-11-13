namespace CarDealerApp.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using CarDealer.Services;
    using Security;
    using CarDealer.Models.BindingModels.Suppliers;
    using CarDealer.Models.EntityModels;
    using CarDealer.Models.ViewModels.Suppliers;

    [RoutePrefix("suppliers")]
    public class SuppliersController : Controller
    {
        private SuppliersService service;

        public SuppliersController()
        {
            this.service = new SuppliersService();
        }

        [HttpGet]
        [Route("Delete/{id:int}")]
        public ActionResult Delete(int id)
        {
            var httpCookie = this.Request.Cookies.Get("sessionId");
            if (httpCookie == null || !AuthenticationManager.IsAuthenticated(httpCookie.Value))
            {
                return RedirectToAction("All");
            }
            DeleteSupplierVm vm = this.service.GetDeleteSupplier(id);
            return this.View(vm);
        }

        [HttpPost]
        [Route("Delete/{id:int?}")]
        public ActionResult Delete([Bind(Include = "Id")] DeleteSupplierBm bind)
        {
            var httpCookie = this.Request.Cookies.Get("sessionId");
            if (httpCookie == null || !AuthenticationManager.IsAuthenticated(httpCookie.Value))
            {
                return RedirectToAction("All");
            }

            if (!ModelState.IsValid)
            {
                DeleteSupplierVm vm = this.service.GetDeleteSupplier(bind.Id);
                return this.View(vm);
            }
            User user = AuthenticationManager.GetAuthenticatedUser(httpCookie.Value);
            this.service.DeleteSupplier(bind, user.Id);
            return this.RedirectToAction("All");
        }

        [HttpGet]
        [Route("{type:regex(local|importers|all)?}")]
        public ActionResult All(string type)
        {
            var httpCookie = this.Request.Cookies.Get("sessionId");
            if (httpCookie == null || !AuthenticationManager.IsAuthenticated(httpCookie.Value))
            {
                IEnumerable<SupplierVm> viewModels = this.service.GetAllSuppliersByType(type);
                return this.View(viewModels);
            }
            User user = AuthenticationManager.GetAuthenticatedUser(httpCookie.Value);
            ViewBag.Username = user.Username;
            IEnumerable<SupplierAllVm> vm = this.service.GetAllSuppliersByTypeForUsers(type);
            return this.View("AllSuppliersForUser", vm);

        }

        [HttpGet]
        [Route("add/")]
        public ActionResult Add()
        {
            var httpCookie = this.Request.Cookies.Get("sessionId");
            if (httpCookie == null || !AuthenticationManager.IsAuthenticated(httpCookie.Value))
            {
                return RedirectToAction("All");
            }
            return this.View();
        }

        [HttpPost]
        [Route("add/")]
        public ActionResult Add([Bind(Include = "Id, Name, IsImporter")] AddSupplierBm bind)
        {
            var httpCookie = this.Request.Cookies.Get("sessionId");
            if (httpCookie == null || !AuthenticationManager.IsAuthenticated(httpCookie.Value))
            {
                return RedirectToAction("All");
            }
            User loggedInUser = AuthenticationManager.GetAuthenticatedUser(httpCookie.Value);
            this.service.AddSupplier(bind, loggedInUser.Id);
            return this.RedirectToAction("All");
        }

        [HttpGet]
        [Route("Edit/{id:int}")]
        public ActionResult Edit(int id)
        {
            var httpCookie = this.Request.Cookies.Get("sessionId");
            if (httpCookie == null || !AuthenticationManager.IsAuthenticated(httpCookie.Value))
            {
                return this.RedirectToAction("All");
            }
            EditSupplierVm vm = this.service.GetEditSupplier(id);
            return View(vm);
        }

        [HttpPost]
        [Route("Edit/{id:int}")]
        public ActionResult Edit([Bind(Include ="Id,Name,IsImporter")] EditSupplierBm bind)
        {
            var httpCookie = this.Request.Cookies.Get("sessionId");
            if (httpCookie == null || !AuthenticationManager.IsAuthenticated(httpCookie.Value))
            {
                return RedirectToAction("All");
            }

            if (this.ModelState.IsValid)
            {
                EditSupplierVm vm = this.service.GetEditSupplier(bind.Id);
                return this.View(vm);
            }

            User loggenInUser = AuthenticationManager.GetAuthenticatedUser(httpCookie.Value);

            this.service.EditSupplier(bind, loggenInUser.Id);
            return this.RedirectToAction("All");
        }

    }
}
