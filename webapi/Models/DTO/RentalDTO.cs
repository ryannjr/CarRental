using webapi.Models.Entities;

namespace webapi.Models.DTO {
    public class RentalDTO {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public double RentalPrice { get; set; }
        public Guid CarId { get; set; }
        public Guid UserId { get; set; }

        public RentalDTO() { }
        public RentalDTO(DateTime start, DateTime end,  Guid carId, Guid userId, double rentalPrice) {
            this.StartTime = start;
            this.EndTime = end;
            this.CarId = carId;
            this.UserId = userId;
            RentalPrice = rentalPrice;
        }
    }
}
