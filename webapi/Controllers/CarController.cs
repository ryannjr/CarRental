using Microsoft.AspNetCore.Mvc;
using webapi.Business.Abstract;
using webapi.Models.Entities;

namespace webapi.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class CarController: ControllerBase {

        private readonly ICarRepository _carRepository;

        public CarController(ICarRepository carRepository) {
            this._carRepository = carRepository;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllCars() {
            IEnumerable<Car> cars = await this._carRepository.GetCars();

            if(cars == null) {
                return NotFound();
            }
            return Ok(cars);

        }
    }
}
