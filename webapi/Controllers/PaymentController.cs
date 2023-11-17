using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using webapi.Contexts;
using webapi.Models.Entities;
using Stripe;
using Stripe.BillingPortal;
using Stripe.Checkout;
using SessionCreateOptions = Stripe.Checkout.SessionCreateOptions;
using Session = Stripe.Checkout.Session;
using webapi.Models.DTO;

namespace webapi.Controllers {

    [ApiController]
    [Route("api/payment")]
    public class PaymentController: ControllerBase{

        private CarRentalDbContext _context;
        public PaymentController(CarRentalDbContext context) {
            this._context = context;
        }


        [HttpPost]
        [Route("create-checkout")]
        public IActionResult CreateCheckoutSession([FromBody] Rental rental) {

            if ((rental == null)) {
                return BadRequest(rental);
            }
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var api_key = config.GetValue<string>("Stripe:Secret_Key");
            StripeConfiguration.ApiKey = api_key;


            var options = new SessionCreateOptions
            {
                LineItems = new List<SessionLineItemOptions>
                {
                    new SessionLineItemOptions
                    {
                        PriceData = new SessionLineItemPriceDataOptions
                        {
                            Currency = "cad",
                            UnitAmount = (long)(rental.RentalPrice * 100),
                            ProductData = new SessionLineItemPriceDataProductDataOptions
                            {
                                Name = string.Format("{0} {1} | Rental", rental.Car.Brand, rental.Car.Model),
                                Description = string.Format(
                                    "Type: {0} | Capacity: {1} | Transmission: {2} | Colour: {3} | {4}"
                                    ,rental.Car.Type, rental.Car.Capacity, rental.Car.Transmission, rental.Car.Colour,
                                    rental.Car.Description, Environment.NewLine)
                            
                                }

                        },
                        Quantity = 1
                    },
                },
                Mode = "payment",
                PaymentMethodTypes = new List<string>
                {
                    "card",

                },
                SuccessUrl = "https://localhost:5173/success?id={CHECKOUT_SESSION_ID}",
                CancelUrl = "https://localhost:5173/cancel",
            };
            var service = new Stripe.Checkout.SessionService(); 
            Session session = service.Create(options);

            return Ok(session.Id);
        }
    }

}
