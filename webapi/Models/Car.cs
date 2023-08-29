namespace webapi.Models {
    public class Car {
        public Guid Id { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public string Type { get; set; }

        public string Colour { get; set; }

        public double Price { get; set; }

        public string Description { get; set; }

        public Car(Guid id, string brand, string model, int year, string type, string colour, double price, string description) {
            this.Id = id;
            this.Brand = brand;
            this.Model = model;
            this.Year = year;
            this.Type = type;
            this.Colour = colour;
            this.Price = price;
            this.Description = description;
        }
    }
}
