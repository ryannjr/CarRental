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

        public async Task<IEnumerable<Car>> QueryCars(string? model, string? brand, string? type, string? colour, int? year, double? price) {
            IQueryable<Car> filtered = this._context.Cars;
    
            if (!string.IsNullOrEmpty(model)) {
                filtered = filtered.Where(car => car.Model.ToLower().Contains(model.ToLower()));
            }
            if (!string.IsNullOrEmpty(brand)) {
                filtered = filtered.Where(car => car.Brand.ToLower().Contains(brand.ToLower()));
            }
            if (!string.IsNullOrEmpty(type)) {
                filtered = filtered.Where(car => car.Type.ToLower().Contains(type.ToLower()));
            }
            if (!string.IsNullOrEmpty(colour)) {
                filtered = filtered.Where(car => car.Colour.ToLower().Contains(colour.ToLower()));
            }
            if (year.HasValue) {
                filtered = filtered.Where(car => car.Year == year.Value);
            }
            if (price.HasValue) {
                filtered = filtered.Where(car => car.Price == price.Value);
            }

            return await filtered.ToListAsync();

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
