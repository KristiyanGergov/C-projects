namespace CarDealer.Models.ViewModels.Sales
{
    using System.Collections.Generic;
    public class AddSaleVm
    {
        public IEnumerable<AddSaleCustomerVm> Customers { get; set; }
        public IEnumerable<AddSaleCarVm> Cars { get; set; }
        public List<int> Discounts { get; set; }
    }

}
