namespace webapi.Models.Entities
{
    public class Admin : User
    {

        public Admin(Guid id, string firstName, string lastName, string email, string password)
            : base(id, firstName, lastName, email, password) { }
    }
}
