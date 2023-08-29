namespace webapi.Models {
    public class Rental {
        public Guid Id { get; set; }
        public Guid CarId { get; set; }
        public Guid UserId { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public virtual Car? Car { get; set; }
        public virtual User? User { get; set; }
    
    
        public Rental(Guid id, Guid carId, Guid userId, DateTime startTime, DateTime endTime, Car? car, User? user) {
            this.Id = id;
            this.CarId = carId;
            this.UserId = userId;
            this.startTime = startTime;
            this.endTime = endTime;
            this.Car = car;
            this.User = user;
        }
    }

}
