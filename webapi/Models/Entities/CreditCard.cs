namespace webapi.Models.Entities
{
    public class CreditCard
    {

        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public string CardNumber { get; set; }
        public string NameOnCard { get; set; }
        public string ExpirationMonth { get; set; }
        public string ExpirationYear { get; set; }
        public string CVV { get; set; }

        public Customer? Customer { get; set; }

        public CreditCard(Guid id, Guid customerId, string cardNumber, string nameOnCard, string expirationMonth, string expirationYear, string cVV, Customer? customer)
        {
            Id = id;
            CustomerId = customerId;
            CardNumber = cardNumber;
            NameOnCard = nameOnCard;
            ExpirationMonth = expirationMonth;
            ExpirationYear = expirationYear;
            CVV = cVV;
            Customer = customer;
        }
    }
}
