namespace CarDealerApp.Controllers
{
    using System.Web.Mvc;
    using CarDealer.Models.ViewModels;
    using System.Collections.Generic;
    using CarDealer.Services;
    using CarDealerApp.Security;
    using CarDealer.Models.ViewModels.Sales;
    using CarDealer.Models.BindingModels.Sale;

    [RoutePrefix("sales")]
    public class SalesController : Controller
    {
        private SalesService service;

        public SalesController()
        {
            this.service = new SalesService();
        }

        [HttpGet]
        [Route("{all?}")]
        public ActionResult All()
        {
            IEnumerable<SaleVm> vms = this.service.GetAllSales();
            return this.View(vms);
        }

        [HttpGet]
        [Route("{id:int}")]
        public ActionResult About(int id)
        {
            SaleVm saleVm = this.service.GetSale(id);

            return this.View(saleVm);
        }

        [HttpGet]
        [Route("discounted/{percent?}/")]
        public ActionResult Discounted(double? percent)
        {
            IEnumerable<SaleVm> sales = this.service.GetDiscountedSales(percent);
            return this.View(sales);
        }

        [HttpGet]
        [Route("add")]
        public ActionResult Add()
        {
            var cookie = this.Request.Cookies.Get("sessionId");
            if (cookie == null || !AuthenticationManager.IsAuthenticated(cookie.Value))
            {
                return this.RedirectToAction("Login", "User");
            }
            AddSaleVm vm = this.service.GetSaleVm();
            return View(vm);
        }

        [HttpPost]
        [Route("add")]
        public ActionResult Add([Bind(Include = "CustomerId, CarId, Discount")] AddSaleBm bind)
        {
            if (ModelState.IsValid)
            {
                AddSaleConfirmationVm confirmation = this.service.GetSaleConfirmattionVm(bind);
                return RedirectToAction("AddConfirmation", confirmation);
            }
            AddSaleVm addSaleVm = this.service.GetSaleVm();
            return this.View(addSaleVm);
        }

        [HttpGet]
        [Route("AddConfirmation")]
        public ActionResult AddConfirmation(AddSaleConfirmationVm vm)
        {
            var cookie = this.Request.Cookies.Get("sessionId");
            if (cookie == null || !AuthenticationManager.IsAuthenticated(cookie.Value))
            {
                return this.RedirectToAction("Login", "User");
            }
            return View(vm);
        }

        [HttpPost]
        [Route("AddConfirmation")]
        public ActionResult AddConfirmation(AddSaleBm bind)
        {
            var cookie = this.Request.Cookies.Get("sessionId");
            if (cookie == null || !AuthenticationManager.IsAuthenticated(cookie.Value))
            {
                return RedirectToAction("Login", "User");
            }
            this.service.AddSale(bind);
            return this.RedirectToAction("All");
        }
    }
}
