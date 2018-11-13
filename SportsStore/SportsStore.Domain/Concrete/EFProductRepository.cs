namespace SportsStore.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using Abstract;
    using SportsStore.Domain.Entities;

    public class EFProductRepository : IProductRepository
    {
        private EFDbContext context = new EFDbContext();
        public IEnumerable<Product> Products
        {
            get { return context.Products; }
        }
    }
}
