namespace webapi.Models {
    public class CreditCard {
        
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public string CardNumber { get; set; }
        public string NameOnCard { get; set; }
        public string ExpirationMonth { get; set; }
        public string ExpirationYear { get; set;}
        public string CVV { get; set; } 

        public Customer? Customer { get; set; }
    }
}
