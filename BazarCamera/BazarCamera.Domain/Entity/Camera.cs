using System.ComponentModel.DataAnnotations;

namespace BazarCamera.Domain.Entity
{
    public class Camera
    {
        public int Id { get; set; }
        [Required]
        public string Make { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required, Range(1, 100)]
        public int Quantity { get; set; }
        public int MinShutterSpeed { get; set; }
        public int MaxShutterSpeed { get; set; }
        public int MinISO { get; set; }
        public int MaxISO { get; set; }
        public bool IsFullFrame { get; set; }
        public string VideoResolution { get; set; }
        public string LightMetering { get; set; }
        public string Description { get; set; }
        [Required]
        public string ImageUrl { get; set; }
    }
}