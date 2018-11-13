﻿namespace SportsStore.Domain.Entities
{
    using System.ComponentModel.DataAnnotations;
    public class ShippingDetails
    {
        [Required(ErrorMessage = "Please enter name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter the first address line")]
        [Display(Name = "Line 1")]
        public string Line1 { get; set; }
        [Display(Name = "Line 2")]
        public string Line2 { get; set; }
        [Display(Name = "Line 3")]
        public string Line3 { get; set; }
        [Required(ErrorMessage = "Please enter city name")]
        public string City { get; set; }
        [Required(ErrorMessage = "Please enter state name")]
        public string State { get; set; }
        public string Zip { get; set; }
        [Required(ErrorMessage = "Please enter country name")]
        public string Country { get; set; }
        public bool GiftWrap { get; set; }
    }
}
