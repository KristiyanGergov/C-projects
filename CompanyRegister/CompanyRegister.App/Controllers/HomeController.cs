using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace CompanyRegister.App.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {        
        public void Get()
        {
            using (var conn = new SqlConnection("Data Source= .;Initial Catalog=CompanyRegister; Integrated Security = True"))
            using (var command = new SqlCommand("dbo.GetEmployeesByName", conn)
            {
                CommandType = CommandType.StoredProcedure
            })
            {
                conn.Open();
                command.Parameters.Add(new SqlParameter("@Name", "Todor"));
                int rows = command.ExecuteNonQuery();
                using (SqlDataReader rdr = command.ExecuteReader())
                {
                    // iterate through results, printing each to console
                    while (rdr.Read())
                    {
                        var test = rdr["FirstName"];
                    }
                }
            }
        }
    }
}