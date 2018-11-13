using CompanyRegister.Models.Entity;
using CompanyRegister.Repositories.Abstract;
using System.Linq;
using System.Web.Mvc;

namespace CompanyRegister.App.Controllers
{
    public class EmployeeController : Controller
    {
        private IEmployeeRepository repository;
        public EmployeeController(IEmployeeRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public ActionResult All(string name)
        {
            var employees = from e in repository.Employees select e;
            if (!string.IsNullOrEmpty(name))
            {
                foreach (var employee in employees)
                {
                    string fullName = employee.FirstName + " " + employee.LastName;
                    if (fullName.Contains(name))
                    {
                        employees = employees.Where(i => i == employee);
                    }
                }
            }
            return View(employees);
        }
        [HttpPost]
        public ActionResult All(Employee employee)
        {
            return RedirectToAction(employee.FirstName);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var res = repository.Details(id);
            return View(res);
        }

        [HttpGet]
        public ActionResult Search()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult Search(string name)
        {
            Employee employee = repository.Employees.FirstOrDefault(e => e.FirstName.Contains(name) || e.LastName.Contains(name));
            if (employee != null)
            {
                return View(employee);
            }
            return View(employee);
        }
    }
}