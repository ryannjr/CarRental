namespace webapi.Models.Entities
{
    public class Car
    {
        public Guid Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Type { get; set; }
        public int Capacity { get; set; }
        public string Transmission { get; set; }
        public string Colour { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public bool isRented { get; set; } = false;

        public Car() { }
        public Car(Guid id, string brand, string model, int year, string type, string colour, double price, string description, int capacity)
        {
            Id = id;
            Brand = brand;
            Model = model;
            Year = year;
            Type = type;
            Capacity = capacity;
            Description = description;
            Colour = colour;
            Price = price;
            Description = description;
        }
    }
}
