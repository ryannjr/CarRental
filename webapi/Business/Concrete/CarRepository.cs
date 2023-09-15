using Microsoft.EntityFrameworkCore;
using webapi.Business.Abstract;
using webapi.Contexts;
using webapi.Models.Entities;

namespace webapi.Business.Concrete {
    public class CarRepository: ICarRepository{

        private CarRentalDbContext _context;
        public CarRepository(CarRentalDbContext context) {
            _context = context;
        }
        public async Task<IEnumerable<Car>> GetCars() {
            var cars = await this._context.Cars.ToListAsync();
            return cars;
        }
        public async Task<Car> GetCarById(Guid carId) {
            return await this._context.Cars.FirstOrDefaultAsync(c => c.Id == carId);
        }

        public async Task<Car> InsertCar(Car car) {
            var result = await this._context.Cars.AddAsync(car);
            await this._context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task UpdateCar(Guid carId, Car updatedCar) {
     
            var carFound = await this._context.Cars.FirstOrDefaultAsync(c => c.Id == carId);
            if (carFound != null) {
                carFound.Id = updatedCar.Id;
                carFound.Brand = updatedCar.Brand;
                carFound.Year = updatedCar.Year;
                carFound.Colour = updatedCar.Colour;
                carFound.Description = updatedCar.Description;
                carFound.Type = updatedCar.Type;
                carFound.Price = updatedCar.Price;

                await this._context.SaveChangesAsync();
            }
        }
        public async Task DeleteCar(Guid carId) {
            var carFound = await this._context.Cars.FirstOrDefaultAsync(c => c.Id == carId);

            if (carFound != null) {
                this._context.Cars.Remove(carFound);
                await this._context.SaveChangesAsync();
            }
        }
    }
}
