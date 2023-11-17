using Microsoft.AspNetCore.Mvc;
using webapi.Business.Abstract;
using webapi.Models.DTO;
using webapi.Models.Entities;

namespace webapi.Controllers {
    [ApiController]
    [Route("api/[controller]s")]
    public class RentalController: ControllerBase {
        
        private readonly IRentalRepository _repository;

        public RentalController(IRentalRepository repository) {
            _repository = repository;
        }


        [HttpGet]
        [Route("get-all")]
        public async Task<IActionResult> GetAllRentals() {
            var rentals = await this._repository.GetAllRentals();
            return Ok(rentals);
        }

        [HttpGet]
        [Route("{rentalId:Guid}")]
        public async Task<IActionResult> GetRentalById([FromBody] Guid rentalId) {
            Rental rental = await _repository.GetRentalById(rentalId);

            if(rental  == null) {
                return NotFound("Rental does not exists in database");
            }
            return Ok(rental);
        }


        [HttpGet]
        [Route("get-by-id/{userId:Guid}")]
        public async Task<IActionResult> GetRentalsByUserId([FromRoute] Guid userId) {
            var rentals = await this._repository.GetRentalsByUserId(userId);
            return Ok(rentals);
        }

        [HttpPost]
        public async Task<IActionResult> AddRental([FromBody] RentalDTO rental) {

            Rental alreadyExists = await _repository.GetRentalByCarId(rental.CarId);

            /*
            if (alreadyExists != null) {
                return BadRequest("Car already exists ");
            }

            */
            Rental rent = new Rental(Guid.NewGuid(), rental.CarId, rental.UserId, rental.StartTime, rental.EndTime, rental.RentalPrice);
            var newRental = await this._repository.InsertRental(rent);

            /*
            if(newRental == null) {
                return NotFound("User or Car does not exist");
            }
            */
            return Ok(newRental);
        }

        [HttpPatch]
        [Route("{rentalId}")]
        public async Task<IActionResult> UpdateRental([FromRoute] Guid rentalId, [FromBody] Rental rental) {
            if (!(rental is Rental)) {
                return BadRequest();
            }

            var rentalFound = await this._repository.GetRentalById(rentalId);
            if (rentalFound == null) {
                return NotFound();
            }

            await this._repository.UpdateRental(rentalId, rental);

            return Ok(rental);
        }

        [HttpDelete]
        [Route("{rentalId}")]
        public async Task<IActionResult> DeleteRental([FromRoute] Guid rentalId) {
            var rentalFound = this._repository.GetRentalById(rentalId);
            if (rentalFound == null) {
                return NotFound();
            }
            await this._repository.DeleteRental(rentalId);
            return Ok(rentalFound);
        }
    }
}
