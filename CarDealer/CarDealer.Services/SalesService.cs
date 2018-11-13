namespace CarDealer.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using CarDealer.Models.EntityModels;
    using CarDealer.Models.ViewModels;
    using CarDealer.Models.BindingModels.Sale;
    using CarDealer.Models.ViewModels.Sales;

    public class SalesService : Service
    {
        public IEnumerable<SaleVm> GetAllSales()
        {
            IEnumerable<Sale> sales = this.Context.Sales;

            IEnumerable<SaleVm> saleVms = Mapper.Map<IEnumerable<Sale>, IEnumerable<SaleVm>>(sales);
            return saleVms;
        }
        public SaleVm GetSale(int id)
        {
            Sale sale = this.Context.Sales.Find(id);

            SaleVm vm = Mapper.Map<Sale, SaleVm>(sale);
            return vm;
        }
        public AddSaleVm GetSaleVm()
        {
            AddSaleVm vm = new AddSaleVm();
            IEnumerable<Car> cars = this.Context.Cars;
            IEnumerable<Customer> customers = this.Context.Customers;

            IEnumerable<AddSaleCarVm> viewCars =
                Mapper.Map<IEnumerable<Car>, IEnumerable<AddSaleCarVm>>(cars);
            IEnumerable<AddSaleCustomerVm> viewCustomers =
                Mapper.Map<IEnumerable<Customer>, IEnumerable<AddSaleCustomerVm>>(customers);

            List<int> discounts = new List<int>();

            for (int i = 0; i <= 50; i += 5)
            {
                discounts.Add(i);
            }

            vm.Cars = viewCars.OrderBy(a => a.Make).ThenBy(b => b.Model);
            vm.Customers = viewCustomers.OrderBy(b => b.Name);
            vm.Discounts = discounts;
            

            return vm;
        }
        public AddSaleConfirmationVm GetSaleConfirmattionVm(AddSaleBm bind)
        {
            Car car = this.Context.Cars.Find(bind.CarId);
            Customer customer = this.Context.Customers.Find(bind.CustomerId);

            AddSaleConfirmationVm vm = new AddSaleConfirmationVm()
            {
                Discount = bind.Discount,
                CarId = car.Id,
                CarPrice = (double)car.Parts.Sum(a => a.Price),
                CustomerId = customer.Id,
                CustomerName = customer.Name,
                CarRepresentation = car.Make + " " + car.Model,
            };

            vm.Discount += customer.IsYoungDriver ? 5 : 0;
            vm.FinalCarPrice = vm.CarPrice + vm.Discount / 100.0;
            return vm;
        }
        public IEnumerable<SaleVm> GetDiscountedSales(double? percent)
        {
            percent /= 100;
            IEnumerable<Sale> sales = this.Context.Sales.Where(sale => sale.Discount != 0);

            if (percent != null)
            {
                sales = sales.Where(sale => sale.Discount == percent.Value);
            }

            IEnumerable<SaleVm> vms = Mapper.Map<IEnumerable<Sale>, IEnumerable<SaleVm>>(sales);
            return vms;
        }
        public void AddSale(AddSaleBm bind)
        {
            Car car = this.Context.Cars.Find(bind.CarId);
            Customer customer = this.Context.Customers.Find(bind.CustomerId);
            Sale sale = new Sale()
            {
                Car = car,
                Customer = customer,
                Discount = bind.Discount / 100
            };
            this.Context.Sales.Add(sale);
            this.Context.SaveChanges();
        }
    }
}
