using webapi.Models.Entities;

namespace webapi.Business.Abstract {
    public interface ICarRepository {

        Task<IEnumerable<Car>> GetCars();
        Task<Car> GetCarById(Guid carId);
        Task<Car> InsertCar(Car car);
        Task UpdateCar(Guid carId,Car updatedCar);
        Task DeleteCar(Guid carId);
    }
}
