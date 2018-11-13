namespace CarDealerApp.Controllers
{
    using System.Web.Mvc;
    using Security;
    using CarDealer.Services;
    using CarDealer.Models.ViewModels.Logs;

    [RoutePrefix("Logs")]
    public class LogsController : Controller
    {
        private LogsService service;
        public LogsController()
        {
            this.service = new LogsService();
        }

        [HttpGet]
        [Route("all/{username?}")]
        public ActionResult All(string username, int? page)
        {
            var httpCookie = this.Request.Cookies.Get("sessionId");
            if (httpCookie == null || !AuthenticationManager.IsAuthenticated(httpCookie.Value))
            {
                return this.RedirectToAction("All", "Suppliers");
            }
            AllLogsPageVm vm = this.service.GetAllLogsPageVm(username, page);
            return View(vm);
        }

        [HttpGet]
        [Route("clear")]
        public ActionResult Clear()
        {
            return this.View();
        }

        [HttpPost]
        [Route("clear")]
        public ActionResult ClearAll()
        {
            var httpCookie = this.Request.Cookies.Get("sessionId");
            if (httpCookie == null || !AuthenticationManager.IsAuthenticated(httpCookie.Value))
            {
                return this.RedirectToAction("All", "Suppliers");
            }
            this.service.ClearLogs();
            return this.RedirectToAction("all");
        }
    }
}