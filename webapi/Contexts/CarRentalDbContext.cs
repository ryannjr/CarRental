using webapi.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace webapi.Contexts {
    public class CarRentalDbContext: DbContext {

        public DbSet<User> Users { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Rental> Rentals { get; set; }

        public CarRentalDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }


    }
}
