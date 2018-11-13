namespace SportsStore.WebUI.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using SportsStore.Domain.Abstract;
    using SportsStore.WebUI.Models;

    public class ProductController : Controller
    {
        private IProductRepository repository;
        public int PageSize = 4;
        public ProductController(IProductRepository repository)
        {
            this.repository = repository;
        }

        public ViewResult List(string category, int page = 1)
        {
            ProductListViewModel model = new ProductListViewModel
            {
                Products = repository.Products
                                .Where(a => a.Category == category || a.Category == null)
                                .OrderBy(p => p.ProductID)
                                .Skip((page - 1) * PageSize)
                                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ? repository.Products.Count() : repository.Products.Where(e => e.Category == category).Count()


                },
                CurrentCategory = category
            };

            return View(model);
           
        }
    }
}