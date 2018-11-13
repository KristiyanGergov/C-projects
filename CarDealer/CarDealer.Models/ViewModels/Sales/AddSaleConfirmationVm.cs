namespace CarDealer.Models.ViewModels.Sales
{
    public class AddSaleConfirmationVm
    {
        public int CustomerId { get; set; }
        public int CarId { get; set; }
        public string CustomerName { get; set; }
        public string CarRepresentation { get; set; }
        public double CarPrice { get; set; }
        public double Discount { get; set; }
        public double FinalCarPrice { get; set; }
    }
}
