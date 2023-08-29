namespace webapi.Models {
    public class Customer : User {
        public string PhoneNumber { get; set; }
        public Address Address { get; set; }
        public ICollection<Rental> Rentals { get; set; }
        public ICollection<CreditCard> CreditCards { get; set; }


        public Customer(Guid id, string firstName, string lastName, string email, string password, string phoneNumber,
            Address address, ICollection<Rental> rentals, ICollection<CreditCard> creditCards) : 
            base(id, firstName, lastName, email, password) {

            this.PhoneNumber = phoneNumber;
            this.Address = address;
            this.Rentals = rentals;
            this.CreditCards = creditCards;

        }
    }
}
