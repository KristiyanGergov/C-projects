using System.Web;

namespace CompanyRegister.Models.View
{
    public class ProductViewModel
    {
        public string ProductName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? Price { get; set; }
        public int? ImageId { get; set; }
        public HttpPostedFileWrapper ImageFile { get; set; }
    }
}
