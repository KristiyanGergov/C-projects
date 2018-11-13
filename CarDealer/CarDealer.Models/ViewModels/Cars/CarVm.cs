namespace CarDealer.Models.ViewModels
{
    using CarDealer.Models.EntityModels;
    using System.Collections.Generic;

    public class CarVm
    {
        public CarVm()
        {
            Parts = new HashSet<Part>();
        }
        public string Make { get; set; }

        public string Model { get; set; }

        public long TravelledDistance { get; set; }

        public virtual ICollection<Part> Parts { get; set; }
    }                                      
}
