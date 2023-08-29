namespace webapi.Models.Entities
{
    public class Customer : User
    {
        public string PhoneNumber { get; set; }
        public Address Address { get; set; }
        public ICollection<Rental> Rentals { get; set; }
        public ICollection<CreditCard> CreditCards { get; set; }


        public Customer(Guid id, string firstName, string lastName, string email, string password, string phoneNumber,
            Address address, ICollection<Rental> rentals, ICollection<CreditCard> creditCards) :
            base(id, firstName, lastName, email, password)
        {

            PhoneNumber = phoneNumber;
            Address = address;
            Rentals = rentals;
            CreditCards = creditCards;

        }
    }
}
