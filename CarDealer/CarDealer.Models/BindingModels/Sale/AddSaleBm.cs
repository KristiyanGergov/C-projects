namespace CarDealer.Models.BindingModels.Sale
{
    public class AddSaleBm
    {
        public int CustomerId { get; set; }
        public int CarId { get; set; }
        public double Discount { get; set; }
    }
}
