namespace webapi.Models.DTO {
    public class CarDTO {
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
    }
}
