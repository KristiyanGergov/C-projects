namespace CarDealerApp.Controllers
{
    using CarDealer.Models.BindingModels;
    using CarDealer.Models.ViewModels;
    using CarDealer.Services;
    using System.Collections.Generic;
    using System.Web.Mvc;

    [RoutePrefix("parts")]
    public class PartsController : Controller
    {
        private PartsService service;

        public PartsController()
        {
            service = new PartsService();
        }

        [HttpGet]
        [Route("add")]
        public ActionResult Add()
        {
            var vms = this.service.GetAddVm();
            return View(vms);
        }

        [HttpPost]
        [Route("add")]
        public ActionResult Add([Bind(Include = "Name, Price, Quantity, SupplierId")] AddPartBm bind)
        {

            if (this.ModelState.IsValid)
            {
                this.service.AddPart(bind);
                return RedirectToAction("All", "Cars");
            }

            var vms = this.service.GetAddVm();
            return this.View(vms);
        }

        [HttpGet]
        [Route("all")]
        public ActionResult All()
        {
            IEnumerable<AllPartVm> vm = service.GetAllParts();
            return View(vm);
        }


        [HttpGet]
        [Route("edit/{id}")]
        public ActionResult Edit(int id)
        {
            EditPartVm vm = this.service.GetEditVm(id);
            return View(vm);
        }

        [HttpPost]
        [Route("edit/{id}")]
        public ActionResult Edit([Bind(Include = "Id, Price, Quantity")] EditPartBm bind)
        {
            if (ModelState.IsValid)
            {
                this.service.EditPart(bind);
                return this.RedirectToAction("All");
            }
            EditPartVm vm = this.service.GetEditVm(bind.Id);
            return View(vm);
        }

        [HttpGet]
        [Route("delete/{id}")]
        public ActionResult Delete(int id)
        {
            DeletePartVm viewModel = this.service.GetDeleteVm(id);
            return this.View(viewModel);
        }

        [HttpPost]
        [Route("delete/{id}")]
        public ActionResult Delete([Bind(Include = "PartId")] DeletePartBm bm)
        {
            if (this.ModelState.IsValid)
            {
                this.service.DeletePart(bm);
                return RedirectToAction("All");
            }
            DeletePartVm vm = this.service.GetDeleteVm(bm.PartId);
            return View(vm);
        }
    }
}