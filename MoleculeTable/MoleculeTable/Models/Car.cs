namespace comboboxTest.Model
{
    public class Car
    {
        public Car(string make, string model, string color, int year, decimal price,decimal? fuelConsumed)
        {
            Make = make;
            Model = model;
            Color = color;
            Year = year;
            Price = price;
            FuelConsumed = fuelConsumed;
        }
        
        public string Make { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public decimal? FuelConsumed { get; set; }
    }
}