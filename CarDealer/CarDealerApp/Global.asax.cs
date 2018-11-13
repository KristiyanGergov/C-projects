namespace CarDealerApp
{
    using System.Linq;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;
    using AutoMapper;
    using CarDealer.Models.EntityModels;
    using CarDealer.Models.ViewModels;
    using CarDealer.Models.BindingModels;
    using System.Data.Entity;
    using CarDealer.Data;
    using CarDealer.Models.ViewModels.Sales;
    using CarDealer.Models.BindingModels.Suppliers;
    using CarDealer.Models.ViewModels.Suppliers;
    using System.Collections.Generic;

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            this.RegisterMaps();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<CarDealerContext>());
        }

        private void RegisterMaps()
        {
            Mapper.Initialize(expression =>
            {
                expression.CreateMap<Customer, AllCustomerVm>();
                expression.CreateMap<Car, CarVm>();
                expression.CreateMap<Supplier, SupplierVm>()
                    .ForMember(vm => vm.NumberOfPartsToSupply,
                        configurationExpression =>
                            configurationExpression.MapFrom(supplier => supplier.Parts.Count));
                expression.CreateMap<Part, PartVm>();
                expression.CreateMap<Sale, SaleVm>()
                .ForMember(vm => vm.Price,
                    configurationExpression =>
                    configurationExpression.MapFrom(sale =>
                            sale.Car.Parts.Sum(part => part.Price)));
                expression.CreateMap<AddCustomerBm, Customer>();
                expression.CreateMap<AddPartBm, Part>();
                expression.CreateMap<Part, AllPartVm>();
                expression.CreateMap<EditCustomerBm, Customer>();
                expression.CreateMap<Customer, EditCustomerVm>();
                expression.CreateMap<Part, EditPartVm>();
                expression.CreateMap<Part, DeletePartVm>();
                expression.CreateMap<AddCarBm, Car>().ForMember(car => car.Parts, config => config.Ignore());
                expression.CreateMap<RegisterUserBm, User>();
                expression.CreateMap<Car, AddSaleCarVm>();
                expression.CreateMap<Customer, AddSaleCustomerVm>();
                expression.CreateMap<AddSupplierBm, Supplier>();
                expression.CreateMap<Supplier, EditSupplierVm>();
                expression.CreateMap<Supplier, DeleteSupplierVm>();
                expression.CreateMap<Supplier, SupplierAllVm>();
            });
        }
    }
}
