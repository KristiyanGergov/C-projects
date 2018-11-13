using CompanyRegister.Models.Entity;
using CompanyRegister.Models.View;
using System.Collections.Generic;

namespace CompanyRegister.Repositories.Abstract
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> Employees { get; }
        Employee Details(int id);
        void SaveEmployee(Employee employee);
        Employee DeleteEmployee(int employeeId);
    }
}