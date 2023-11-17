using webapi.Models.DTO;
using webapi.Models.Entities;

namespace webapi.Business.Abstract {
    public interface IRentalRepository {

        Task<IEnumerable<Rental>> GetAllRentals();
        Task<IEnumerable<Rental>> QueryRentals();
        Task<Rental> GetRentalById(Guid id);
        Task<Rental> GetRentalByCarId(Guid carId);
        Task<IEnumerable<Rental>> GetRentalsByUserId(Guid userId);
        Task<Rental> InsertRental(Rental rental);
        Task UpdateRental(Guid rentalId, Rental rental);
        Task DeleteRental(Guid id);
    }
}
