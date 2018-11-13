using CompanyRegister.Models.Entity;
using CompanyRegister.Repositories.Abstract;

namespace CompanyRegister.Repositories
{
    public class EmployeeRepository : Repository, IEmployeeRepository
    {
        public Employee Details(int id)
        {
            Employee employee = this.Context.Employees.Find(id);
            return employee;
        }
        public void SaveEmployee(Employee employee)
        {
            if (employee.Id == 0)
            {
                this.Context.Employees.Add(employee);
            }
            else
            {
                Employee dbEntry = this.Context.Employees.Find(employee.Id);
                if (dbEntry != null)
                {
                    dbEntry.FirstName = employee.FirstName;
                    dbEntry.SecondName = employee.SecondName;
                    dbEntry.LastName = employee.LastName;
                    dbEntry.Email = employee.Email;
                    dbEntry.Phone = employee.Phone;
                    dbEntry.BirthDate = employee.BirthDate;
                    dbEntry.DateHired = employee.DateHired;
                    dbEntry.Salary = employee.Salary;
                    dbEntry.ImageData = employee.ImageData;
                    dbEntry.ImageMimeType = employee.ImageMimeType;
                }
            }

            this.Context.SaveChanges();
        }
        public Employee DeleteEmployee(int Id)
        {
            Employee dbEntry = this.Context.Employees.Find(Id);
            if (dbEntry != null)
            {
                this.Context.Employees.Remove(dbEntry);
                this.Context.SaveChanges();
            }
            return dbEntry;
        }
    }
}