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

            var options = new SessionCreateOptions
            {
                LineItems = new List<SessionLineItemOptions>
                {
                    new SessionLineItemOptions
                    {
                        Price = "5.00",
                        Quantity = 1
                    },
                },
                Mode = "payment",
                SuccessUrl = "https://localhost:5173/payment-success",
                CancelUrl = "https://localhost:5173/payment-cancel",
            };
            var service = new Stripe.Checkout.SessionService();
            Session session = service.Create(options);

            Response.Headers.Add("Location", session.Url);
            return new StatusCodeResult(303);
        }
    }

}
