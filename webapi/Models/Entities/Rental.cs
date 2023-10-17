namespace webapi.Models.Entities
{
    public class Rental {
        public Guid Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public double RentalPrice { get; set; }
        public Guid CarId { get; set; }
        public virtual Car? Car { get; set; }
        public Guid UserId { get; set; }
        public virtual User? User { get; set; }

        public Rental() { }
        public Rental(Guid id, Guid carId, Guid userId, DateTime startTime, DateTime endTime, double rentalPrice)
        {
            Id = id;
            CarId = carId;
            UserId = userId;
            RentalPrice = rentalPrice;
            this.StartTime = startTime;
            this.EndTime = endTime;
        }
    }

}
