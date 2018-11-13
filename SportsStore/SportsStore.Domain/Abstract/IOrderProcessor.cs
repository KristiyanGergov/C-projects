namespace SportsStore.Domain.Abstract
{
    using SportsStore.Domain.Entities;
    public interface IOrderProcessor
    {
        void ProcessorOrder(Cart cart, ShippingDetails details);
    }
}
