using CompanyRegister.Models.Entity;
using System;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;

namespace CompanyRegister.Data
{
    public class CompanyRegisterContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        //public virtual ObjectResult<Employee> GetEmployeesByName(string employeeName)
        //{
        //    var res = new ObjectParameter("Name", employeeName);

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Employee>("GetEmployeesByName", res);
        //}
    }
}
