using CompanyRegister.Models.Entity;
using CompanyRegister.Repositories.Abstract;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CompanyRegister.App.Controllers
{
    [Authorize]
    public class OperatorController : Controller
    {
        private IEmployeeRepository repository;

        public OperatorController(IEmployeeRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public ActionResult All(string name)
        {

            return View(repository.Employees);
        }


        public ViewResult Edit(int id)
        {
            Employee employee = repository.Employees.FirstOrDefault(em => em.Id == id);
            return View(employee);

        }
        
        [HttpPost]
        public ActionResult Edit(Employee employee, HttpPostedFileBase image = null)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    employee.ImageMimeType = image.ContentType;
                    employee.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(employee.ImageData, 0, image.ContentLength);
                }

                this.repository.SaveEmployee(employee);
                TempData["message"] = string.Format($"{employee.FirstName} has been saved");
                return RedirectToAction("All");
            }
            else
            {
                return View(employee);
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View("Edit", new Employee());
        }

        public ActionResult Delete(int Id)
        {
            Employee deletedProduct = repository.DeleteEmployee(Id);
            if (deletedProduct != null)
            {
                TempData["message"] = string.Format($"{deletedProduct.FirstName} {deletedProduct.LastName} was deleted");
            }
            return RedirectToAction("All");
        }

        public FileContentResult GetImage(int employeeId)
        {
            Employee product = repository.Employees
                .FirstOrDefault(e => e.Id == employeeId);
            if (product != null)
            {
                return File(product.ImageData, product.ImageMimeType);
            }
            else
            {
                return null;
            }
        }
    }
}