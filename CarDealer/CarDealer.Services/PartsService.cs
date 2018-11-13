namespace CarDealer.Services
{
    using AutoMapper;
    using CarDealer.Models.BindingModels;
    using CarDealer.Models.EntityModels;
    using CarDealer.Models.ViewModels;
    using System.Collections.Generic;
    using System.Linq;
    public class PartsService : Service
    {
        public IEnumerable<AddPartSupplierVm> GetAddVm()
        {
            return this.Context.Suppliers.Select(supplier => new AddPartSupplierVm()
            {
                Id = supplier.Id,
                Name = supplier.Name
            });
        }
        public IEnumerable<AllPartVm> GetAllParts()
        {
            IEnumerable<Part> parts;
            parts = this.Context.Parts;
            IEnumerable<AllPartVm> viewModel = Mapper.Instance.Map<IEnumerable<Part>, IEnumerable<AllPartVm>>(parts);
            return viewModel;
        }
        public void AddPart(AddPartBm bind)
        {
            Part part = Mapper.Instance.Map<AddPartBm, Part>(bind);
            Supplier wantedSupplier = this.Context.Suppliers.Find(bind.SupplierId);
            part.Supplier = wantedSupplier;
            if (part.Quantity == 0)
            {
                part.Quantity = 1;
            }
            this.Context.Parts.Add(part);
            this.Context.SaveChanges();
        }
        public EditPartVm GetEditVm(int id)
        {
            Part part = this.Context.Parts.Find(id);
            return Mapper.Map<Part, EditPartVm>(part);
        }
        public void EditPart(EditPartBm bind)
        {
            Part part = this.Context.Parts.Find(bind.Id);
            part.Price = bind.Price;
            part.Quantity = bind.Quantity;

            this.Context.SaveChanges();
        }
        public DeletePartVm GetDeleteVm(int id)
        {
            Part part = this.Context.Parts.Find(id);
            DeletePartVm viewModel = Mapper.Instance.Map<Part, DeletePartVm>(part);
            return viewModel;
        }
        public void DeletePart(DeletePartBm bind)
        {
            Part part = this.Context.Parts.Find(bind.PartId);
            this.Context.Parts.Remove(part);
            this.Context.SaveChanges();
        }
    }
}