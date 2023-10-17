using Microsoft.EntityFrameworkCore;
using webapi.Business.Abstract;
using webapi.Contexts;
using webapi.Models.DTO;
using webapi.Models.Entities;

namespace webapi.Business.Concrete {
    public class RentalRepository : IRentalRepository {
        private CarRentalDbContext _context;

        public RentalRepository(CarRentalDbContext context) {
            this._context = context;
        }
        public async Task<IEnumerable<Rental>> GetAllRentals() {
            var rentals = await this._context.Rentals.ToListAsync();
            return rentals;
        }

        public async Task<Rental> GetRentalById(Guid id) {
            return await this._context.Rentals.FirstOrDefaultAsync(x => x.Id == id);

        }

        public async Task<Rental> GetRentalByUserId(Guid userId) {
            return await this._context.Rentals.FirstOrDefaultAsync(r => r.UserId == userId);
        }

        public async Task<Rental> InsertRental(Rental rental) {
            if(await this._context.Users.FirstOrDefaultAsync(u =>  u.Id == rental.UserId) == null) return null;
            if (await this._context.Cars.FirstOrDefaultAsync(c => c.Id == rental.CarId) == null) return null;

            var res = await this._context.AddAsync(rental);
            await this._context.SaveChangesAsync();
            return res.Entity;
        }



        public async Task UpdateRental(Guid rentalId, Rental rental) {
            var rentalFound = await this._context.Rentals.FirstOrDefaultAsync(r => r.Id == rentalId);
            if (rentalFound != null) {
                rentalFound.Id = rental.Id;
                rentalFound.CarId = rental.CarId;
                rentalFound.UserId = rental.UserId;
                rentalFound.StartTime = rental.StartTime;
                rentalFound.EndTime = rental.EndTime;
                rentalFound.Car = await this._context.Cars.FirstOrDefaultAsync(c => c.Id == rental.CarId);
                rentalFound.User = await this._context.Users.FirstOrDefaultAsync(u => u.Id == rental.UserId);

                await this._context.SaveChangesAsync();
            }
        }

        public async Task DeleteRental(Guid rentalId) {
            var rentalFound = await this._context.Rentals.FirstOrDefaultAsync(r => r.Id == rentalId);
            if(rentalFound != null) {
                this._context.Rentals.Remove(rentalFound);
                await this._context.SaveChangesAsync();
            }
        }

        public Task<IEnumerable<Rental>> QueryRentals() {
            throw new NotImplementedException();
        }
    }
}
