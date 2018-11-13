using CompanyRegister.Data;
using CompanyRegister.Models.Entity;
using System.Collections.Generic;

namespace CompanyRegister.Repositories
{
    public class Repository
    {
        protected CompanyRegisterContext Context = new CompanyRegisterContext();
        public IEnumerable<Employee> Employees
        {
            get { return this.Context.Employees; }
        }
    }
}
