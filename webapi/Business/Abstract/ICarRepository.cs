using webapi.Models.Entities;

namespace webapi.Business.Abstract {
    public interface ICarRepository {

        Task<IEnumerable<Car>> GetCars();
        Task<Car> GetCarById(Guid carId);
        Task<IEnumerable<Car>> QueryCars(string? model, string? brand, string? type, string? colour, int? year, double? price);
        Task<Car> InsertCar(Car car);
        Task UpdateCar(Guid carId,Car updatedCar);
        Task DeleteCar(Guid carId);
    }
}
