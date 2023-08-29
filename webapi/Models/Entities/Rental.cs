namespace webapi.Models.Entities
{
    public class Rental
    {
        public Guid Id { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        
        public Guid CarId { get; set; }
        public virtual Car? Car { get; set; }

        public Guid UserId { get; set; }
        public virtual Customer? Customer { get; set; }


        public Rental(Guid id, Guid carId, Guid userId, DateTime startTime, DateTime endTime, Car? car, Customer? customer)
        {
            Id = id;
            CarId = carId;
            UserId = userId;
            this.startTime = startTime;
            this.endTime = endTime;
            Car = car;
            Customer = customer;
        }
    }

}
