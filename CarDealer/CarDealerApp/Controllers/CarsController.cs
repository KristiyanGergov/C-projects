namespace CarDealerApp.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using CarDealer.Models.ViewModels;
    using CarDealer.Services;
    using CarDealer.Models.BindingModels;
    using CarDealerApp.Security;
    using CarDealer.Data;
    using System;

    [RoutePrefix("cars")]
    public class CarsController : Controller
    {
        private CarsService service;
        public CarsController()
        {
            this.service = new CarsService();
        }

        [HttpGet]
        [Route("{make?}")]
        public ActionResult All(string make)
        {
            IEnumerable<CarVm> modelCarVms = this.service.GetCarsFromGivenMakeInOrder(make);
            return this.View(modelCarVms);
        }

        [HttpGet]
        [Route("{id:int}/parts")]
        public ActionResult About(int id)
        {
            AboutCarVm vm = this.service.GetCarWithParts(id);

            return this.View(vm);
        }

        [HttpGet]
        [Route("add")]
        public ActionResult Add()
        {
            var httpCookie = this.Request.Cookies.Get("sessionId");
            if (httpCookie == null || !AuthenticationManager.IsAuthenticated(httpCookie.Value))
            {
                return RedirectToAction("Login", "User");
            }
            return this.View();
        }

        [HttpPost]
        [Route("add")]
        public ActionResult Add([Bind(Include = "Make, Model, TravelledDistance, Parts")] AddCarBm bind)
        {
            var httpCookie = this.Request.Cookies.Get("sessionId");
            if (httpCookie == null || !AuthenticationManager.IsAuthenticated(httpCookie.Value))
            {
                return RedirectToAction("Login", "User");
            }
            if (ModelState.IsValid)
            {
                this.service.AddCar(bind);
                return this.RedirectToAction("All");
            }
            return this.View();
        }

        [HandleError(ExceptionType = typeof(ArgumentOutOfRangeException), View = "MyError")]
        [Route("custom/{id:int}")]
        public ActionResult CustomErrors(int carId)
        {
            var context = new CarDealerContext();
            var car = context.Cars.Find(carId);
            if (car == null)
            {
                throw new ArgumentOutOfRangeException("id", carId, $"There is no such element with provided ID");
            }
            else if (car.TravelledDistance > 10000000)
            {
                throw new InvalidOperationException("The car is too old to be displayed");
            }
            ViewData["car"] = car;
            return View();
        }
    }
}