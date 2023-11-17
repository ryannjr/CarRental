using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using webapi.Business.Abstract;
using webapi.Models.Entities;
using System;
using Stripe;
using webapi.Models.DTO;

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
        public async Task<IActionResult> AddCar([FromBody] CarDTO car) {
            if(!(car is CarDTO)) {
                return BadRequest();
            }
            Car newCar = new Car();
            newCar.Year = car.Year;
            newCar.Colour = car.Colour;
            newCar.Model = car.Model;
            newCar.Brand = car.Brand;
            newCar.Type = car.Type;
            newCar.Capacity = car.Capacity;
            newCar.Price = car.Price;
            newCar.Transmission = car.Transmission;
            newCar.Description = car.Description;
            newCar.isRented = car.isRented;
            newCar.Id = Guid.NewGuid();

            string CAR_IMAGE = string.Format("C:\\Users\\ryan_\\Pictures\\CarImages\\{0}_{1}.png", car.Brand, car.Model);
            byte[] carImage = System.IO.File.ReadAllBytes(CAR_IMAGE);
            if(carImage != null) {
                newCar.Image = carImage;
            }
            await this._carRepository.InsertCar(newCar);
            return Ok(newCar);

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
