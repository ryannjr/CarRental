namespace webapi.Models.Entities
{
    public class User {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool isAdmin {get; set;} = false;
        public ICollection<Rental> Rentals { get; set; }

        public User() { }
        public User(Guid id, string firstName, string lastName, string email, string password){
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
    }
    }
}
