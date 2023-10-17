using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using webapi.Business.Abstract;
using webapi.Models.Entities;

namespace webapi.Controllers {
    [ApiController]
    [Route("api/[controller]s")]
    public class CarController: ControllerBase {

        private readonly ICarRepository _carRepository;

        public CarController(ICarRepository carRepository) {
            this._carRepository = carRepository;
        }


        [HttpGet]
        [Route("get-all")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll() {
            IEnumerable<Car> cars = await this._carRepository.GetCars();

            if(cars == null) {
                return NotFound();
            }
            return Ok(cars);

        }

        [HttpGet]
        
        public async Task<IActionResult> Index([FromQuery] string? model, [FromQuery] string? brand, [FromQuery] string? type,
            [FromQuery] string? colour, [FromQuery] int? year, [FromQuery] double? price) {

            IEnumerable<Car> filtered = await this._carRepository.QueryCars(model, brand, type, colour, year, price);
            return Ok(filtered);
        }



        [HttpGet]
        [Route("{carId:Guid}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetCarById([FromRoute] Guid carId) {
            Car car = await this._carRepository.GetCarById(carId);
            if(car == null) {
                return NotFound();
            }
            return Ok(car);

        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddCar([FromBody] Car car) {
            if(!(car is Car)) {
                return BadRequest();
            }
            car.Id = Guid.NewGuid();
            await this._carRepository.InsertCar(car);
            return Ok(car);

        }

        [HttpPut]
        [Route("{carId:Guid}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateCar([FromRoute] Guid carId, [FromBody] Car car) {
            if(!(car is Car)) {
                return BadRequest();
            }

            var carFound = await this._carRepository.GetCarById(carId);
            if(carFound == null) {
                return BadRequest();
            }

            await this._carRepository.UpdateCar(carId, car);

            return Ok(carFound);
        }

        [HttpDelete]
        [Route("{carId:Guid}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteCar([FromRoute] Guid carId) {
            var carFound = await this._carRepository.GetCarById(carId);
            if(carFound == null) {
                return BadRequest();
            }

            await this._carRepository.DeleteCar(carId);
            return Ok(carFound);

        }
    }
}
