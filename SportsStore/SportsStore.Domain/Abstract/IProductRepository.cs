namespace SportsStore.Domain.Abstract
{
    using Entities;
    using System.Collections.Generic;

    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; }
    }
}
